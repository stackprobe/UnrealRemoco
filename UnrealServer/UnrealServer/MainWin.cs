﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;

namespace Charlotte
{
	public partial class MainWin : Form
	{
		#region ALT_F4 抑止

		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		protected override void WndProc(ref Message m)
		{
			const int WM_SYSCOMMAND = 0x112;
			const long SC_CLOSE = 0xF060L;

			if (m.Msg == WM_SYSCOMMAND && (m.WParam.ToInt64() & 0xFFF0L) == SC_CLOSE)
				return;

			base.WndProc(ref m);
		}

		#endregion

		public MainWin()
		{
			InitializeComponent();
		}

		private void MainWin_Load(object sender, EventArgs e)
		{
			// noop
		}

		private void MainWin_Shown(object sender, EventArgs e)
		{
			startService();

			this.Visible = false;
			this.taskTrayIcon.Visible = true;
			this.mtEnabled = true;
		}

		private void startService()
		{
			endService();
			Gnd.i.service = new Service();
		}

		private void endService()
		{
			if (Gnd.i.service != null)
			{
				BusyDlg.perform(delegate
				{
					Gnd.i.service.Dispose();
					Gnd.i.service = null;
				});
			}
		}

		private void MainWin_FormClosing(object sender, FormClosingEventArgs e)
		{
			// noop
		}

		private void MainWin_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.mtEnabled = false;
			this.taskTrayIcon.Visible = false;

			endService();
		}

		private void 終了XToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.mtEnabled = false;
			this.Close();
		}

		private bool mtEnabled;
		private bool mtBusy;
		private long mtCount;

		private void mainTimer_Tick(object sender, EventArgs e)
		{
			if (this.mtEnabled == false || this.mtBusy)
				return;

			this.mtBusy = true;

			try
			{
				// 停止状態になることが無い！
				Gnd.i.service.eachTimerTick();
			}
			finally
			{
				this.mtBusy = false;
				this.mtCount++;
			}
		}

		private void 設定SToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.mtEnabled = false;
			endService();

			using (SettingDlg f = new SettingDlg())
			{
				f.ShowDialog();
			}
			startService();
			this.mtEnabled = true;
		}

		private void 再起動RToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.mtEnabled = false;
			endService();
			startService();
			this.mtEnabled = true;
		}
	}
}
