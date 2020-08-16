using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using System.Threading;
using System.Windows.Forms;

namespace Charlotte
{
	public class Service : IDisposable
	{
		private PlayerProc _playerProc;
		private RecverProc _recverProc;
		private CrypTunnelProc _crypTunnelProc = null; // null == 暗号化なし
		private Fortewave _frtwv;

		public Service()
		{
			if (Ground.i.cipherMode == Consts.CipherMode_e.NOT_ENCRYPT)
			{
				_playerProc = new PlayerProc();
				_recverProc = new RecverProc(Ground.i.portNo);
			}
			else
			{
				_playerProc = new PlayerProc();
				_recverProc = new RecverProc(Ground.i.forwardPortNo);
				_crypTunnelProc = new CrypTunnelProc(Ground.i.portNo, Ground.i.forwardPortNo, Ground.i.key, Ground.i.passphrase + Ground.i.passphraseSuffix);
			}
			_frtwv = new Fortewave(Consts.FRTWV_RECVER_TO_SERVER, Consts.FRTWV_SERVER_TO_RECVER);
			_frtwv.clear();
		}

		public int monitorIndex = 0;
		public int quality = 0;

		public void eachTimerTick()
		{
			try
			{
				for (; ; )
				{
					ObjectList ol = (ObjectList)_frtwv.recv(0);

					if (ol == null)
						break;

					byte[] recvData = (byte[])ol[0];
					string recvLine = StringTools.ENCODING_SJIS.GetString(recvData);
					List<string> prms = StringTools.tokenize(recvLine, " ");
					int c = 0;
					string command = prms[c++];

					// 受信コマンド処理 >

					if (command == "SENDER-IDLING")
					{
						_frtwv.send(Utils.toOL(
							"SEND-TO-CLIENT",
							Utils.getScreenImage(monitorIndex, quality),
							""
							));
					}
					else if (command == "MONITOR-INDEX")
					{
						monitorIndex = int.Parse(prms[c++]);
						monitorIndex = IntTools.toRange(monitorIndex, 0, IntTools.IMAX);
						monitorIndex %= Ground.i.monitorCenter.getCount();

						MonitorCenter.Monitor monitor = Ground.i.monitorCenter.get(monitorIndex);

						_frtwv.send(Utils.toOL(
							"MOUSE_LTRB " +
							monitor.l + " " +
							monitor.t + " " +
							monitor.r + " " +
							monitor.b
							));
					}
					else if (command == "QUALITY")
					{
						quality = int.Parse(prms[c++]);
						quality = IntTools.toRange(quality, 0, 101);
					}
					else if (command == "DISCONNECTED")
					{
						if (Ground.i.disconnectAndShiftKeysUp)
						{
							_frtwv.send(Utils.toOL("SHIFT-KEYS-UP"));
						}
					}
					else if (command == "SET-CLIP-BOARD-TEXT")
					{
						byte[] bText = StringTools.decodeBase64(prms[c++]);
						string text = JString.toJString(bText, true, true, true, true);

						Clipboard.SetText(text);
					}
					else if (command == "GET-CLIP-BOARD-TEXT")
					{
						string text = Clipboard.GetText();

						if (text == null)
							text = "(クリップボードにテキストはありません[S])";

						_frtwv.send(Utils.toOL(
							"SEND-TO-CLIENT",
							"",
							text
							));
					}
					else
					{
						Utils.WriteLog("不明なコマンド：" + command);
					}

					// < 受信コマンド処理
				}
			}
			catch (Exception e)
			{
				Utils.WriteLog("Service each-timer error: " + e);
				GC.Collect();
			}
		}

		public void Dispose()
		{
			if (_playerProc != null)
			{
				Thread.Sleep(500); // zantei: クライアントから停止しようとした時にマウスカーソルの位置を調整する猶予

				_playerProc.Dispose();
				_playerProc = null;

				_recverProc.Dispose();
				_recverProc = null;

				if (_crypTunnelProc != null)
				{
					_crypTunnelProc.Dispose();
					_crypTunnelProc = null;
				}
				_frtwv.Dispose();
				_frtwv = null;
			}
		}
	}
}
