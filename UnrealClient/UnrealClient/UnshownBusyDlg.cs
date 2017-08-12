using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Threading;

namespace Charlotte
{
	public partial class UnshownBusyDlg : Form
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

		public delegate void operation_d();

		private operation_d _operation;

		public static void perform(operation_d operation)
		{
			using (UnshownBusyDlg f = new UnshownBusyDlg(operation))
			{
				f.ShowDialog();
			}
		}

		public UnshownBusyDlg(operation_d operation)
		{
			_operation = operation;

			InitializeComponent();
		}

		private void InvisibleBusyDlg_Load(object sender, EventArgs e)
		{
			// noop
		}

		private void InvisibleBusyDlg_Shown(object sender, EventArgs e)
		{
			new Thread((ThreadStart)delegate
			{
				try
				{
					_operation();
				}
				catch
				{ }

				this.BeginInvoke((MethodInvoker)delegate
				{
					this.Close();
				});
			})
			.Start();
		}

		private void InvisibleBusyDlg_FormClosing(object sender, FormClosingEventArgs e)
		{
			// noop
		}

		private void InvisibleBusyDlg_FormClosed(object sender, FormClosedEventArgs e)
		{
			// noop
		}
	}
}
