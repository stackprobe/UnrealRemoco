using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using System.Diagnostics;
using System.IO;

namespace Charlotte
{
	public class CrypTunnelProc : IDisposable
	{
		private WorkingDir _wd = new WorkingDir();
		private int _recvPortNo;
		private int _forwardPortNo;
		private Gnd.KeyData _key; // null == パスフレーズで暗号化する。
		private string _passphrase;
		private Process _proc;

		public CrypTunnelProc(int recvPortNo, int forwardPortNo, Gnd.KeyData key, string passphrase)
		{
			_recvPortNo = recvPortNo;
			_forwardPortNo = forwardPortNo;
			_key = key;
			_passphrase = passphrase;

			startProc();
		}

		private void startProc()
		{
			// Kill Zombie
			{
				Utils.startConsole(getCrypTunnelFile(), _recvPortNo + " a 1 /S").WaitForExit();
			}

			string prmFile = _wd.makePath();
			string keyFile = _wd.makePath();
			string passphrase;

			if (_key != null)
			{
				File.WriteAllText(keyFile, _key.raw, Encoding.ASCII);
				passphrase = keyFile;
			}
			else
				passphrase = "*" + _passphrase;

			File.WriteAllLines(
				prmFile,
				new string[]
				{
					"" + _recvPortNo,
					"localhost",
					"" + _forwardPortNo,
					"/R", // サーバーなのでリバースモード
					passphrase,
				}
				);

			_proc = Utils.startConsole(getCrypTunnelFile(), "//R " + prmFile);

			// 読まれるタイミングと同期出来ないので、削除しない。
			//File.Delete(prmFile);
			//File.Delete(keyFile);
		}

		private void endProc()
		{
			do
			{
				Utils.startConsole(getCrypTunnelFile(), _recvPortNo + " a 1 /S").WaitForExit();
			}
			while (_proc.WaitForExit(2000) == false);
		}

		private static string getCrypTunnelFile()
		{
			string file = "crypTunnel.exe";

			if (File.Exists(file) == false)
				file = @"C:\Factory\Labo\Socket\tunnel\crypTunnel.exe";

			file = FileTools.makeFullPath(file);
			return file;
		}

		public void Dispose()
		{
			if (_wd != null)
			{
				endProc();

				_wd.Dispose();
				_wd = null;
			}
		}
	}
}
