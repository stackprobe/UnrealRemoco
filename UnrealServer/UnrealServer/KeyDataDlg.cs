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
	public partial class KeyDataDlg : Form
	{
		public Ground.KeyData retKeyData = null;

		public KeyDataDlg(Ground.KeyData kd)
		{
			InitializeComponent();

			this.MinimumSize = this.Size;

			if (kd == null)
			{
				txtIdent.Text = "";
				txtRaw.Text = "";
				txtHash.Text = "";
			}
			else
			{
				txtIdent.Text = kd.ident;
				txtRaw.Text = kd.raw;
				txtHash.Text = kd.hash;
			}
		}

		private void KeyDataDlg_Load(object sender, EventArgs e)
		{
			// noop
		}

		private void KeyDataDlg_Shown(object sender, EventArgs e)
		{
			this.btnOk.Focus();

			Utils.PostShown(this);
		}

		private void KeyDataDlg_FormClosing(object sender, FormClosingEventArgs e)
		{
			// noop
		}

		private void KeyDataDlg_FormClosed(object sender, FormClosedEventArgs e)
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
				if (txtIdent.Text == "") // ? 未入力
				{
					throw new FailedOperation("鍵が生成されていません。");
				}
				retKeyData = getKeyData();
				this.Close();
			}
			catch (Exception ex)
			{
				FailedOperation.caught(ex);
			}
		}

		private void setKeyData(Ground.KeyData kd)
		{
			this.txtIdent.Text = kd.ident;
			this.txtRaw.Text = kd.raw;
			this.txtHash.Text = kd.hash;
		}

		private Ground.KeyData getKeyData()
		{
			return new Ground.KeyData()
			{
				ident = txtIdent.Text,
				raw = txtRaw.Text,
				hash = txtHash.Text,
			};
		}

		private void txtIdent_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)1) // ctrl_a
			{
				txtIdent.SelectAll();
				e.Handled = true;
			}
		}

		private void txtKey_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)1) // ctrl_a
			{
				txtRaw.SelectAll();
				e.Handled = true;
			}
		}

		private void txtHash_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)1) // ctrl_a
			{
				txtHash.SelectAll();
				e.Handled = true;
			}
		}

		private void btnNew_Click(object sender, EventArgs e)
		{
			setKeyData(Ground.KeyData.create());
		}

		private void btnImport_Click(object sender, EventArgs e)
		{
			try
			{
				string keyFile = SaveLoadDialogs.LoadFile(
					"鍵ファイルを選択してください",
					"鍵:unreal-remo-key",
					Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
					"default.unreal-remo-key"
					);

				if (keyFile != null)
				{
					XNode root = XNode.load(keyFile);

					string ident = root.get("Ident").value;
					string key = root.get("Key").value;
					string hash = root.get("Hash").value;

					if (ident != JString.toJString(ident, false, false, false, false))
						throw new FailedOperation("鍵ファイルが壊れています。(Ident format)");

					if (ident.Length < 1 || 100 < ident.Length) // HACK: 上限適当
						throw new FailedOperation("鍵ファイルが壊れています。(Ident length)");

					if (StringTools.hex(key).Length != 64)
						throw new FailedOperation("鍵ファイルが壊れています。(Key length)");

					if (hash != Ground.KeyData.getHash(key))
						throw new FailedOperation("鍵ファイルが壊れています。(Hash)");

					txtIdent.Text = ident;
					txtRaw.Text = key;
					txtHash.Text = hash;

					throw new Completed("鍵をインポートしました。");
				}
			}
			catch (Exception ex)
			{
				FailedOperation.caught(ex);
			}
		}

		private void btnExport_Click(object sender, EventArgs e)
		{
			try
			{
				if (txtIdent.Text == "") // ? 未生成
					throw new FailedOperation("鍵を生成して下さい。");

				string keyFile = SaveLoadDialogs.SaveFile(
					"保存先の鍵ファイルを選択してください",
					"鍵:unreal-remo-key",
					Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
					this.txtIdent.Text + ".unreal-remo-key"
					);

				if (keyFile != null)
				{
					XNode root = new XNode("UnrealRemoco-Key");

					root.children.Add(new XNode("Ident", this.txtIdent.Text));
					root.children.Add(new XNode("Key", this.txtRaw.Text));
					root.children.Add(new XNode("Hash", this.txtHash.Text));

					root.save(keyFile);

					throw new Completed("鍵ファイルに保存しました。");
				}
			}
			catch (Exception ex)
			{
				FailedOperation.caught(ex);
			}
		}
	}
}
