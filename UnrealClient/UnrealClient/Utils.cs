using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Charlotte.Tools;

namespace Charlotte
{
	public class Utils
	{
		public static void enableDoubleBuffer(Control ctrl)
		{
			ctrl.GetType().InvokeMember(
				   "DoubleBuffered",
				   BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
				   null,
				   ctrl,
				   new object[] { true }
				   );
		}

		public static ImageCodecInfo getImageCodecInfo(ImageFormat imgFmt)
		{
			return (from ici in ImageCodecInfo.GetImageEncoders() where ici.FormatID == imgFmt.Guid select ici).ToList()[0];
		}

		public static void addColumn(DataGridView sheet, int colidx, string title, bool invisible = false)
		{
			DataGridViewColumn column = sheet.Columns[colidx];

			column.HeaderText = title;

			if (invisible)
				column.Visible = false;
			else
				column.Width = 200;
		}

		public static void adjustColumnsWidth(DataGridView sheet)
		{
			for (int colidx = 0; colidx < sheet.ColumnCount; colidx++)
			{
				if (sheet.RowCount == 0)
				{
					sheet.Columns[colidx].Width = 200;
				}
				else
				{
					sheet.Columns[colidx].Width = 10000; // 一旦思いっきり広げてからでないとダメな時がある。
					sheet.AutoResizeColumn(colidx, DataGridViewAutoSizeColumnMode.AllCells);
					sheet.Columns[colidx].Width += 10; // margin
				}
			}
		}

		public class IsProcActive
		{
			[DllImport("user32.dll")]
			private static extern IntPtr GetForegroundWindow();

			[DllImport("user32.dll")]
			private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

			public static bool get()
			{
				IntPtr hWnd = GetForegroundWindow();
				int pid;

				GetWindowThreadProcessId(hWnd, out pid);

				int selfPId = Process.GetCurrentProcess().Id;

				return pid == selfPId;
			}
		}

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

		public static void PostShown(Form f)
		{
			List<Control.ControlCollection> controlTable = new List<Control.ControlCollection>();

			controlTable.Add(f.Controls);

			for (int index = 0; index < controlTable.Count; index++)
			{
				foreach (Control control in controlTable[index])
				{
					GroupBox gb = control as GroupBox;

					if (gb != null)
					{
						controlTable.Add(gb.Controls);
					}
					TextBox tb = control as TextBox;

					if (tb != null)
					{
						if (tb.ContextMenuStrip == null)
						{
							ToolStripMenuItem item = new ToolStripMenuItem();

							item.Text = "項目なし";
							item.Enabled = false;

							ContextMenuStrip menu = new ContextMenuStrip();

							menu.Items.Add(item);

							tb.ContextMenuStrip = menu;
						}
					}
				}
			}
		}
	}
}
