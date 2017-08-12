﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Diagnostics;

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
	}
}
