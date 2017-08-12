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
		public Gnd.KeyData retKeyData = null;

		public KeyDataDlg(Gnd.KeyData kd)
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

		private void setKeyData(Gnd.KeyData kd)
		{
			this.txtIdent.Text = kd.ident;
			this.txtRaw.Text = kd.raw;
			this.txtHash.Text = kd.hash;
		}

		private Gnd.KeyData getKeyData()
		{
			return new Gnd.KeyData()
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
			setKeyData(Gnd.KeyData.create());
		}

		private void btnImport_Click(object sender, EventArgs e)
		{
			try
			{
				//OpenFileDialogクラスのインスタンスを作成
				using (OpenFileDialog ofd = new OpenFileDialog())
				{
					//はじめのファイル名を指定する
					//はじめに「ファイル名」で表示される文字列を指定する
					ofd.FileName = "default.unreal-remo-key";
					//はじめに表示されるフォルダを指定する
					//指定しない（空の文字列）の時は、現在のディレクトリが表示される
					//ofd.InitialDirectory = @"C:\";
					ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
					//[ファイルの種類]に表示される選択肢を指定する
					//指定しないとすべてのファイルが表示される
					ofd.Filter = "鍵ファイル(*.unreal-remo-key)|*.unreal-remo-key|すべてのファイル(*.*)|*.*";
					//[ファイルの種類]ではじめに選択されるものを指定する
					//2番目の「すべてのファイル」が選択されているようにする
					ofd.FilterIndex = 1;
					//タイトルを設定する
					ofd.Title = "鍵ファイルを選択してください";
					//ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
					ofd.RestoreDirectory = true;
					//存在しないファイルの名前が指定されたとき警告を表示する
					//デフォルトでTrueなので指定する必要はない
					ofd.CheckFileExists = true;
					//存在しないパスが指定されたとき警告を表示する
					//デフォルトでTrueなので指定する必要はない
					ofd.CheckPathExists = true;

					//ダイアログを表示する
					if (ofd.ShowDialog() == DialogResult.OK)
					{
						//OKボタンがクリックされたとき、選択されたファイル名を表示する
						//Console.WriteLine(ofd.FileName);

						string keyFile = ofd.FileName;
						XNode root = XNode.load(keyFile);

						string ident = root.get("Ident").value;
						string key = root.get("Key").value;
						string hash = root.get("Hash").value;

						if (ident != JString.toJString(ident, false, false, false, false))
							throw new FailedOperation("鍵ファイルが壊れています。(Ident format)");

						if (ident.Length < 1 || 100 < ident.Length) // XXX 上限適当
							throw new FailedOperation("鍵ファイルが壊れています。(Ident length)");

						if (StringTools.hex(key).Length != 64)
							throw new FailedOperation("鍵ファイルが壊れています。(Key length)");

						if (hash != Gnd.KeyData.getHash(key))
							throw new FailedOperation("鍵ファイルが壊れています。(Hash)");

						txtIdent.Text = ident;
						txtRaw.Text = key;
						txtHash.Text = hash;

						throw new Completed("鍵をインポートしました。");
					}
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

				//SaveFileDialogクラスのインスタンスを作成
				using (SaveFileDialog sfd = new SaveFileDialog())
				{
					//はじめのファイル名を指定する
					//はじめに「ファイル名」で表示される文字列を指定する
					sfd.FileName = this.txtIdent.Text + ".unreal-remo-key";
					//はじめに表示されるフォルダを指定する
					sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
					//[ファイルの種類]に表示される選択肢を指定する
					//指定しない（空の文字列）の時は、現在のディレクトリが表示される
					sfd.Filter = "鍵ファイル(*.unreal-remo-key)|*.unreal-remo-key|すべてのファイル(*.*)|*.*";
					//[ファイルの種類]ではじめに選択されるものを指定する
					//2番目の「すべてのファイル」が選択されているようにする
					sfd.FilterIndex = 1;
					//タイトルを設定する
					sfd.Title = "保存先の鍵ファイルを選択してください";
					//ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
					sfd.RestoreDirectory = true;
					//既に存在するファイル名を指定したとき警告する
					//デフォルトでTrueなので指定する必要はない
					sfd.OverwritePrompt = true;
					//存在しないパスが指定されたとき警告を表示する
					//デフォルトでTrueなので指定する必要はない
					sfd.CheckPathExists = true;

					//ダイアログを表示する
					if (sfd.ShowDialog() == DialogResult.OK)
					{
						//OKボタンがクリックされたとき、選択されたファイル名を表示する
						//Console.WriteLine(sfd.FileName);

						string keyFile = sfd.FileName;
						XNode root = new XNode("UnrealRemoco-Key");

						root.children.Add(new XNode("Ident", this.txtIdent.Text));
						root.children.Add(new XNode("Key", this.txtRaw.Text));
						root.children.Add(new XNode("Hash", this.txtHash.Text));

						root.save(keyFile);

						throw new Completed("鍵ファイルに保存しました。");
					}
				}
			}
			catch (Exception ex)
			{
				FailedOperation.caught(ex);
			}
		}
	}
}
