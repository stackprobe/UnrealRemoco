using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using Charlotte.Tools;

namespace Charlotte
{
	public class Utils
	{
		public static ObjectList toOL(params object[] prms)
		{
			ObjectList ol = new ObjectList();

			foreach (object prm in prms)
			{
				if (prm is string)
				{
					ol.add(StringTools.ENCODING_SJIS.GetBytes((string)prm));
				}
				else
				{
					ol.add(prm);
				}
			}
			return ol;
		}

		public static byte[] getScreenImage(int monitorIndex, int quality)
		{
			MonitorCenter.Monitor monitor = Gnd.i.monitorCenter.get(monitorIndex);

			int l = monitor.l;
			int t = monitor.t;
			int w = monitor.w;
			int h = monitor.h;

			Bitmap bmp = new Bitmap(w, h);

			using (Graphics g = Graphics.FromImage(bmp))
			{
				g.CopyFromScreen(new Point(l, t), new Point(0, 0), new Size(w, h));
			}
			MemoryStream ms = new MemoryStream();

			if (quality <= 100)
			{
				EncoderParameters eps = new EncoderParameters(1);
				eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)quality);
				bmp.Save(ms, getImageCodecInfo(ImageFormat.Jpeg), eps);
			}
			else
				bmp.Save(ms, ImageFormat.Png);

			byte[] ret = ms.ToArray();
			GC.Collect();
			return ret;
		}

		public static ImageCodecInfo getImageCodecInfo(ImageFormat imgFmt)
		{
			return (from ici in ImageCodecInfo.GetImageEncoders() where ici.FormatID == imgFmt.Guid select ici).ToList()[0];
		}

		public static Process startConsole(string file, string args)
		{
			Process p;

			switch (Gnd.i.consoleWinStyle)
			{
				case ProcessTools.WindowStyle_e.INVISIBLE:
					p = ProcessTools.start(file, "//-C " + args);
					break;

				case ProcessTools.WindowStyle_e.MINIMIZED:
					p = ProcessTools.start(file, args, null, ProcessTools.WindowStyle_e.MINIMIZED);
					break;

				case ProcessTools.WindowStyle_e.NORMAL:
					p = ProcessTools.start(file, args, null, ProcessTools.WindowStyle_e.NORMAL);
					break;

				default:
					throw null;
			}
			return p;
		}

		public static void antiWindowsDefenderSmartScreen()
		{
			WriteLog("awdss_1");

			if (Gnd.i.is初回起動())
			{
				WriteLog("awdss_2");

				foreach (string exeFile in Directory.GetFiles(Program.selfDir, "*.exe", SearchOption.TopDirectoryOnly))
				{
					try
					{
						WriteLog("awdss_exeFile: " + exeFile);

						if (StringTools.equalsIgnoreCase(exeFile, Program.selfFile))
						{
							WriteLog("awdss_self_noop");
						}
						else
						{
							byte[] exeData = File.ReadAllBytes(exeFile);
							File.Delete(exeFile);
							File.WriteAllBytes(exeFile, exeData);
						}
						WriteLog("awdss_OK");
					}
					catch (Exception e)
					{
						WriteLog(e);
					}
				}
				WriteLog("awdss_3");
			}
			WriteLog("awdss_4");
		}

		private static StreamWriter LogWriter = null;

		public static void WriteLog(object message)
		{
			if (LogWriter == null)
			{
				string logFile = Path.Combine(Program.selfDir, Path.GetFileNameWithoutExtension(Program.selfFile) + ".log");

				LogWriter = new StreamWriter(logFile, false, Encoding.UTF8);
			}
			LogWriter.WriteLine("[" + DateTime.Now + "] " + message);
			LogWriter.Flush();
		}
	}
}
