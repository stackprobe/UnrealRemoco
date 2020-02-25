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
	public static class Utils
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

		// sync > @ AntiWindowsDefenderSmartScreen

		public static void AntiWindowsDefenderSmartScreen()
		{
			WriteLog("awdss_1");

			if (Is初回起動())
			{
				WriteLog("awdss_2");

				foreach (string exeFile in Directory.GetFiles(BootTools.SelfDir, "*.exe", SearchOption.TopDirectoryOnly))
				{
					try
					{
						WriteLog("awdss_exeFile: " + exeFile);

						if (exeFile.ToLower() == BootTools.SelfFile.ToLower())
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

		// < sync

		public static bool Is初回起動()
		{
			return Gnd.i.is初回起動();
		}

		private static long WriteLogCount = 0L;

		public static void WriteLog(object message)
		{
			string logFile = Path.Combine(Program.selfDir, Path.GetFileNameWithoutExtension(Program.selfFile) + ".log");

			using (StreamWriter writer = new StreamWriter(logFile, WriteLogCount++ % Gnd.i.clearLogCycle != 0, Encoding.UTF8))
			{
				writer.WriteLine("[" + DateTime.Now + "] " + message);
			}
		}

		// sync > @ PostShown

		public static void PostShown_GetAllControl(Form f, Action<Control> reaction)
		{
			Queue<Control.ControlCollection> controlTable = new Queue<Control.ControlCollection>();

			controlTable.Enqueue(f.Controls);

			while (1 <= controlTable.Count)
			{
				foreach (Control control in controlTable.Dequeue())
				{
					GroupBox gb = control as GroupBox;

					if (gb != null)
					{
						controlTable.Enqueue(gb.Controls);
					}
					TabControl tc = control as TabControl;

					if (tc != null)
					{
						foreach (TabPage tp in tc.TabPages)
						{
							controlTable.Enqueue(tp.Controls);
						}
					}
					SplitContainer sc = control as SplitContainer;

					if (sc != null)
					{
						controlTable.Enqueue(sc.Panel1.Controls);
						controlTable.Enqueue(sc.Panel2.Controls);
					}
					Panel p = control as Panel;

					if (p != null)
					{
						controlTable.Enqueue(p.Controls);
					}
					reaction(control);
				}
			}
		}

		public static void PostShown(Form f)
		{
			PostShown_GetAllControl(f, control =>
			{
				Control c = new Control[]
				{
					control as TextBox,
					control as NumericUpDown,
				}
				.FirstOrDefault(v => v != null);

				if (c != null)
				{
					if (c.ContextMenuStrip == null)
					{
						ToolStripMenuItem item = new ToolStripMenuItem();

						item.Text = "項目なし";
						item.Enabled = false;

						ContextMenuStrip menu = new ContextMenuStrip();

						menu.Items.Add(item);

						c.ContextMenuStrip = menu;
					}
				}
			});
		}

		// < sync
	}
}
