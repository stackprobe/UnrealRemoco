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
		public bool disconnectAndShiftKeysUp = true;

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
				disconnectAndShiftKeysUp = StringTools.toFlag(lines[c++]);

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

		public int portNo = 55900;
		public KeyData key = null; // null == 指定無し
		public string passphrase = ""; // "" == 指定無し
		public int forwardPortNo = 55901;

		public void loadData()
		{
			try
			{
				string[] lines = File.ReadAllLines(getDataFile(), Encoding.UTF8);
				int c = 0;

				// items >

				portNo = IntTools.toInt(lines[c++]);

				if (lines[c] != "")
				{
					key = new KeyData();
					FieldsSerializer.deserialize(key, StringTools.decodeLines(lines[c++]));
				}
				else
					key = null;

				passphrase = lines[c++];
				forwardPortNo = int.Parse(lines[c++]);

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

				lines.Add("" + portNo);

				if (key != null)
					lines.Add(StringTools.encodeLines(FieldsSerializer.serialize(key)));
				else
					lines.Add("");

				lines.Add(passphrase);
				lines.Add("" + forwardPortNo);

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
		public Service service = null; // null == 停止中

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
