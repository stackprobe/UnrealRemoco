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
		private Ground.KeyData _key;

		public SettingDlg()
		{
			InitializeComponent();

			// init cmbCipherMode
			{
				cmbCipherMode.Items.Clear();

				foreach (string item in Consts.cipherModes)
					cmbCipherMode.Items.Add(item);

				cmbCipherMode.SelectedIndex = 0;
			}

			// load
			{
				this.txtPortNo.Text = "" + Ground.i.portNo;
				this.cmbCipherMode.SelectedIndex = (int)Ground.i.cipherMode;
				_key = Ground.i.key;
				this.txtPassphrase.Text = Ground.i.passphrase;
				this.txtForwardPortNo.Text = "" + Ground.i.forwardPortNo;
			}

			refreshUI();
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
					if (IntTools.isRange(int.Parse(this.txtPortNo.Text), 1, 65535) == false)
						throw null;
				}
				catch
				{
					throw new FailedOperation(
						"ポート番号に問題があります。\n" +
						"・指定できる値は 1 以上 65535 以下の整数です。"
						);
				}

				switch (this.cmbCipherMode.SelectedIndex)
				{
					case (int)Consts.CipherMode_e.NOT_ENCRYPT:
						break;

					case (int)Consts.CipherMode_e.ENCRYPT_BY_KEY:
						{
							if (_key == null)
								throw new FailedOperation("鍵が指定されていません。");
						}
						break;

					case (int)Consts.CipherMode_e.ENCRYPT_BY_PASSPHRASE:
						{
							if (this.txtPassphrase.Text == "")
								throw new FailedOperation("パスフレーズが指定されていません。");

							if (this.txtPassphrase.Text != JString.toJString(this.txtPassphrase.Text, true, false, false, false))
								throw new FailedOperation(
									"パスフレーズに問題があります。\n" +
									"・Shift_JISに変換できない文字は使用できません。\n" +
									"・空白は使用できません。"
									);
						}
						break;

					default:
						throw null;
				}

				if (this.cmbCipherMode.SelectedIndex != (int)Consts.CipherMode_e.NOT_ENCRYPT)
				{
					try
					{
						if (IntTools.isRange(int.Parse(this.txtForwardPortNo.Text), 1, 65535) == false)
							throw null;
					}
					catch
					{
						throw new FailedOperation(
							"中継用ポート番号に問題があります。\n" +
							"・指定できる値は 1 以上 65535 以下の整数です。"
							);
					}
				}

				// <-- check

				// save
				{
					Ground.i.portNo = int.Parse(this.txtPortNo.Text);
					Ground.i.key = null;
					Ground.i.passphrase = "";

					switch (this.cmbCipherMode.SelectedIndex)
					{
						case (int)Consts.CipherMode_e.NOT_ENCRYPT:
							break;

						case (int)Consts.CipherMode_e.ENCRYPT_BY_KEY:
							Ground.i.key = _key;
							break;

						case (int)Consts.CipherMode_e.ENCRYPT_BY_PASSPHRASE:
							Ground.i.passphrase = this.txtPassphrase.Text;
							break;

						default:
							throw null;
					}

					Ground.i.forwardPortNo = IntTools.toInt(this.txtForwardPortNo.Text, 1, 65535, 55901);
				}
				this.Close();
			}
			catch (Exception ex)
			{
				FailedOperation.caught(ex);
			}
		}

		private void txtKey_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)1) // ctrl_a
			{
				this.txtKey.SelectAll();
				e.Handled = true;
			}
		}

		private void btnKey_Click(object sender, EventArgs e)
		{
			using (KeyDataDlg f = new KeyDataDlg(_key))
			{
				f.ShowDialog();

				if (f.retKeyData != null)
				{
					_key = f.retKeyData;
					refreshUI();
				}
			}
		}

		private void refreshUI()
		{
			{
				bool flag = this.cmbCipherMode.SelectedIndex != (int)Consts.CipherMode_e.NOT_ENCRYPT;

				this.lblForwardPortNo.Enabled = flag;
				this.txtForwardPortNo.Enabled = flag;
				this.lblForwardPortNoMemo.Enabled = flag;
				this.lblForwardPortNoMemoSub.Enabled = flag;
			}

			{
				bool flag = this.cmbCipherMode.SelectedIndex == (int)Consts.CipherMode_e.ENCRYPT_BY_KEY;

				this.lblKey.Enabled = flag;
				this.txtKey.Enabled = flag;
				this.btnKey.Enabled = flag;
			}

			{
				bool flag = this.cmbCipherMode.SelectedIndex == (int)Consts.CipherMode_e.ENCRYPT_BY_PASSPHRASE;

				this.lblPassphrase.Enabled = flag;
				this.txtPassphrase.Enabled = flag;
			}

			if (_key != null)
				this.txtKey.Text = _key.ident;
			else
				this.txtKey.Text = "";
		}

		private void cmbCipherMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			refreshUI();
		}

		private void btnDefault_Click(object sender, EventArgs e)
		{
			// デフォルト値 -> UI
			{
				this.txtPortNo.Text = "" + 55900;
				this.cmbCipherMode.SelectedIndex = (int)Consts.CipherMode_e.NOT_ENCRYPT;
				_key = null;
				this.txtPassphrase.Text = "";
				this.txtForwardPortNo.Text = "" + 55901;
			}

			refreshUI();
		}
	}
}
