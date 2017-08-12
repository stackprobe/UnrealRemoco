using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using System.IO;

namespace Charlotte
{
	public class Gnd
	{
#if true
		public static Gnd i;
#else
		private static Gnd _i = null;

		public static Gnd i
		{
			get
			{
				if (_i == null)
					_i = new Gnd();

				return _i;
			}
		}

		private Gnd()
		{ }
#endif

		// ---- conf data ----

		public ProcessTools.WindowStyle_e consoleWinStyle = ProcessTools.WindowStyle_e.INVISIBLE;
		public string passphraseSuffix = "[x25]";
		public int screen_w_min = 100;
		public int screen_h_min = 100;
		public int screen_w_max = 10000;
		public int screen_h_max = 10000;
		public int serverInfoCountMax = 255;

		public void loadConf()
		{
			try
			{
				List<string> lines = new List<string>();

				foreach (string line in FileTools.readAllLines(getConfFile(), StringTools.ENCODING_SJIS))
					if (line != "" && line[0] != ';')
						lines.Add(line);

				int c = 0;

				// items >

				consoleWinStyle = (ProcessTools.WindowStyle_e)int.Parse(lines[c++]);
				passphraseSuffix = lines[c++];
				screen_w_min = IntTools.toInt(lines[c++], 1);
				screen_h_min = IntTools.toInt(lines[c++], 1);
				screen_w_max = IntTools.toInt(lines[c++], screen_w_min);
				screen_h_max = IntTools.toInt(lines[c++], screen_h_min);
				serverInfoCountMax = IntTools.toInt(lines[c++], 1);

				// < items
			}
			catch
			{ }
		}

		private string getConfFile()
		{
			return Path.Combine(Program.selfDir, Path.GetFileNameWithoutExtension(Program.selfFile) + ".conf");
		}

		// ---- saved data ----

		public List<ServerInfo> serverInfos = new List<ServerInfo>();
		public int relayPortNo = 60001; // 中継用ポート番号
		public int quality = 70; // 0 ～ 100 == Jpeg, 101 == Png
		public int mainWin_l;
		public int mainWin_t;
		public int mainWin_w = -1; // -1 == mainWin_ltwh 未設定
		public int mainWin_h;
		public bool mouseActiveOutOfScreen = false;
		public ServerInfo lastConServerInfo = null;

		public void loadData()
		{
			try
			{
				string[] lines = File.ReadAllLines(getDataFile(), Encoding.UTF8);
				int c = 0;

				// items >

				{
					serverInfos.Clear();

					foreach (string line in StringTools.decodeLines(lines[c++]))
					{
						ServerInfo si = new ServerInfo();
						FieldsSerializer.deserialize(si, StringTools.decodeLines(line));
						serverInfos.Add(si);
					}
				}

				relayPortNo = int.Parse(lines[c++]);
				quality = int.Parse(lines[c++]);
				mainWin_l = int.Parse(lines[c++]);
				mainWin_t = int.Parse(lines[c++]);
				mainWin_w = int.Parse(lines[c++]);
				mainWin_h = int.Parse(lines[c++]);
				mouseActiveOutOfScreen = StringTools.toFlag(lines[c++]);

				// conDlgServerInfo
				{
					string line = lines[c++];

					if (line != "")
					{
						lastConServerInfo = new ServerInfo();
						FieldsSerializer.deserialize(lastConServerInfo, StringTools.decodeLines(line));
					}
					else
						lastConServerInfo = null;
				}

				// < items
			}
			catch
			{ }
		}

		public void saveData()
		{
			try
			{
				List<string> lines = new List<string>();

				// items >

				{
					List<string> siLines = new List<string>();

					foreach (ServerInfo si in serverInfos)
					{
						siLines.Add(StringTools.encodeLines(FieldsSerializer.serialize(si)));
					}
					lines.Add(StringTools.encodeLines(siLines.ToArray()));
				}

				lines.Add("" + relayPortNo);
				lines.Add("" + quality);
				lines.Add("" + mainWin_l);
				lines.Add("" + mainWin_t);
				lines.Add("" + mainWin_w);
				lines.Add("" + mainWin_h);
				lines.Add(StringTools.toString(mouseActiveOutOfScreen));

				if (lastConServerInfo != null)
					lines.Add(StringTools.encodeLines(FieldsSerializer.serialize(lastConServerInfo)));
				else
					lines.Add("");

				// < items

				File.WriteAllLines(getDataFile(), lines, Encoding.UTF8);
			}
			catch
			{ }
		}

		private string getDataFile()
		{
			return Path.Combine(Program.selfDir, Path.GetFileNameWithoutExtension(Program.selfFile) + ".dat");
		}

		// ----

		public MonitorCenter monitorCenter = new MonitorCenter();
		public Logger logger = new Logger();

		public class ServerInfo
		{
			public string title = "名無しの設定さん";
			public string host = "localhost";
			public int portNo = 55900;
			public KeyData key = null; // null == 指定無し
			public string passphrase = ""; // "" == 指定無し

			public Consts.CipherMode_e cipherMode
			{
				get
				{
					if (key != null)
						return Consts.CipherMode_e.ENCRYPT_BY_KEY;

					if (passphrase != "")
						return Consts.CipherMode_e.ENCRYPT_BY_PASSPHRASE;

					return Consts.CipherMode_e.NOT_ENCRYPT;
				}
			}

			public string keyIdent
			{
				get
				{
					if (key == null)
						return "";

					return key.ident;
				}
			}

			public string keyString
			{
				get
				{
					if (key == null)
						return "";

					return key.raw;
				}
			}

			public string keyHash
			{
				get
				{
					if (key == null)
						return "";

					return key.hash;
				}
			}
		}

		public class KeyData : FieldsSerializer.Serializable
		{
			public string ident = Consts.KEY_IDENT_PREFIX + "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"; // prefix + 128 bit
			public string raw = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"; // 512 bit
			public string hash = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"; // 128 bit

			public static KeyData create()
			{
				byte[] bRaw = SecurityTools.getCRand(64);
				byte[] bHash = BinaryTools.getSubBytes(SecurityTools.getSHA512(bRaw), 0, 16);

				return new KeyData()
				{
					ident = Consts.KEY_IDENT_PREFIX + StringTools.toHex(SecurityTools.getCRand(16)),
					raw = StringTools.toHex(bRaw),
					hash = StringTools.toHex(bHash),
				};
			}

			/// <summary>
			/// hash == key の sha-512 の最初の16バイト
			/// </summary>
			/// <param name="key"></param>
			/// <returns></returns>
			public static string getHash(string key)
			{
				return StringTools.toHex(SecurityTools.getSHA512(StringTools.hex(key))).Substring(0, 32);
			}
		}

		public Connection con = null; // null == 未接続

		public string getUnrealPlayerFile()
		{
			string file = "UnrealPlayer.exe";

			if (File.Exists(file) == false)
				file = @"..\..\..\..\UnrealPlayer.exe"; // devenv

			file = FileTools.makeFullPath(file);
			return file;
		}
	}
}
