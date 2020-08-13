using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Charlotte.Tools;

namespace Charlotte
{
	public partial class SettingDlg : Form
	{
		public SettingDlg()
		{
			InitializeComponent();

			// load
			{
				this.txtRelayPortNo.Text = "" + Ground.i.relayPortNo;
				this.cbActivateOutOfScreen.Checked = Ground.i.mouseActiveOutOfScreen;
			}
		}

		private void SettingDlg_Load(object sender, EventArgs e)
		{
			// noop
		}

		private void SettingDlg_Shown(object sender, EventArgs e)
		{
			Utils.PostShown(this);
		}

		private void SettingDlg_FormClosing(object sender, FormClosingEventArgs e)
		{
			// noop
		}

		private void SettingDlg_FormClosed(object sender, FormClosedEventArgs e)
		{
			// noop
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			try
			{
				try
				{
					if (IntTools.isRange(int.Parse(this.txtRelayPortNo.Text), 1, 65535) == false)
						throw null;
				}
				catch
				{
					throw new FailedOperation(
						"中継用ポート番号に問題があります。\n" +
						"・指定できる値は 1 以上 65535 以下の整数です。"
						);
				}

				// save
				{
					Ground.i.relayPortNo = int.Parse(this.txtRelayPortNo.Text);
					Ground.i.mouseActiveOutOfScreen = this.cbActivateOutOfScreen.Checked;
				}
				this.Close();
			}
			catch (Exception ex)
			{
				FailedOperation.caught(ex);
			}
		}
	}
}
