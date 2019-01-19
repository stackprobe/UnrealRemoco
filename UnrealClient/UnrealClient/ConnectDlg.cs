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
	public partial class ConnectDlg : Form
	{
		public Connection retCon = null; // null == キャンセル

		public ConnectDlg()
		{
			InitializeComponent();

			this.MinimumSize = this.Size;

			// init cmbCipherMode
			{
				cmbCipherMode.Items.Clear();

				foreach (string item in Consts.cipherModes)
					cmbCipherMode.Items.Add(item);

				cmbCipherMode.SelectedIndex = 0;
			}

			//this.txtTitle.Text = "";
			//this.txtHost.Text = "";
			//this.txtPortNo.Text = "";
			this.txtKeyIdent.Text = "";
			this.txtPassphrase.Text = "";
			this.txtRelayPortNo.Text = "" + Gnd.i.relayPortNo;

			if (Gnd.i.lastConServerInfo != null)
				setServerInfo(Gnd.i.lastConServerInfo);

			refreshUI();
		}

		private void ConnectDlg_Load(object sender, EventArgs e)
		{
			// noop
		}

		private void ConnectDlg_Shown(object sender, EventArgs e)
		{
			siSheetInit();

			// load siSheet
			{
				siSheet.RowCount = Gnd.i.serverInfos.Count;

				for (int index = 0; index < Gnd.i.serverInfos.Count; index++)
				{
					siSheetSetRow(index, Gnd.i.serverInfos[index]);
				}
			}

			Utils.adjustColumnsWidth(siSheet);
			siSheet.ClearSelection();

			Utils.PostShown(this);
		}

		private void ConnectDlg_FormClosing(object sender, FormClosingEventArgs e)
		{
			// noop
		}

		private void ConnectDlg_FormClosed(object sender, FormClosedEventArgs e)
		{
			// save siSheet
			{
				Gnd.i.serverInfos.Clear();

				for (int rowidx = 0; rowidx < siSheet.RowCount; rowidx++)
				{
					Gnd.i.serverInfos.Add(siSheetGetRow(rowidx));
				}
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			try
			{
				Gnd.ServerInfo si = getServerInfo(true);
				Gnd.i.lastConServerInfo = si;
				Connection con = new Connection(si, 0);
				retCon = con;
				this.Close();
			}
			catch (Exception ex)
			{
				FailedOperation.caught(ex);
			}
		}

		private void refreshUI()
		{
			{
				bool flag = this.cmbCipherMode.SelectedIndex == (int)Consts.CipherMode_e.ENCRYPT_BY_KEY;

				this.lblKey.Enabled = flag;
				this.txtKeyIdent.Enabled = flag;
				this.btnKey.Enabled = flag;
			}

			{
				bool flag = this.cmbCipherMode.SelectedIndex == (int)Consts.CipherMode_e.ENCRYPT_BY_PASSPHRASE;

				this.lblPassphrase.Enabled = flag;
				this.txtPassphrase.Enabled = flag;
			}

			{
				bool flag = this.cmbCipherMode.SelectedIndex == (int)Consts.CipherMode_e.NOT_ENCRYPT;

				flag = !flag;

				this.lblRelayPortNo.Enabled = flag;
				this.txtRelayPortNo.Enabled = flag;
				this.lblRelayPortNoMemo.Enabled = flag;
			}

			if (_keyData == null)
				this.txtKeyIdent.Text = "";
			else
				this.txtKeyIdent.Text = _keyData.ident;
		}

		private void cmbCipherMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			refreshUI();
		}

		private void txtKeyIdent_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)1) // ctrl_a
			{
				txtKeyIdent.SelectAll();
				e.Handled = true;
			}
		}

		private void siSheetInit()
		{
			siSheet.RowCount = 0;
			siSheet.ColumnCount = 0;
			siSheet.ColumnCount = 7;

			siSheet.RowHeadersVisible = false; // 行ヘッダ_非表示

			foreach (DataGridViewColumn column in this.siSheet.Columns) // 列ソート_禁止
			{
				column.SortMode = DataGridViewColumnSortMode.NotSortable;
			}

			int colidx = 0;

			Utils.addColumn(siSheet, colidx++, "名前");
			Utils.addColumn(siSheet, colidx++, "ホスト名");
			Utils.addColumn(siSheet, colidx++, "ポート番号");
			Utils.addColumn(siSheet, colidx++, "暗号モード");
			Utils.addColumn(siSheet, colidx++, "鍵");
			Utils.addColumn(siSheet, colidx++, "パスフレーズ");
			Utils.addColumn(siSheet, colidx++, "args", true);
		}

		private void siSheetSetRow(int rowidx, Gnd.ServerInfo si)
		{
			DataGridViewRow row = siSheet.Rows[rowidx];
			int colidx = 0;

			row.Cells[colidx++].Value = si.title;
			row.Cells[colidx++].Value = si.host;
			row.Cells[colidx++].Value = "" + si.portNo;
			row.Cells[colidx++].Value = Consts.cipherModes[(int)si.cipherMode];
			row.Cells[colidx++].Value = si.keyIdent;
			row.Cells[colidx++].Value = si.passphrase;
			row.Cells[colidx++].Value = StringTools.encodeLines(FieldsSerializer.serialize(si));
		}

		private Gnd.ServerInfo siSheetGetRow(int rowidx)
		{
			Gnd.ServerInfo si = new Gnd.ServerInfo();
			FieldsSerializer.deserialize(si, StringTools.decodeLines(siSheet.Rows[rowidx].Cells[siSheet.ColumnCount - 1].Value.ToString()));
			return si;
		}

		private void siSheet_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			// noop
		}

		private void siSheet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int rowidx = e.RowIndex;

			if (rowidx == -1)
				return;

			connect(rowidx);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				Gnd.ServerInfo si = getServerInfo();
				int rowidx = getRowIndexByTitle(si.title);

				if (rowidx == -1)
				{
					if (Gnd.i.serverInfoCountMax <= siSheet.RowCount)
					{
						MessageBox.Show(
							"項目数の上限に達したため、これ以上追加できません。",
							"保存できません",
							MessageBoxButtons.OK,
							MessageBoxIcon.Warning
							);
						return;
					}
					siSheet.RowCount++;
					siSheetSetRow(siSheet.RowCount - 1, si);
				}
				else
				{
					if (MessageBox.Show(
						"設定「" + si.title + "」を上書きします。\n宜しいですか？",
						"確認",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Warning
						) != DialogResult.Yes
						)
						return;

					siSheetSetRow(rowidx, si);
				}
				doSortSISheet();
				Utils.adjustColumnsWidth(siSheet);
			}
			catch (Exception ex)
			{
				FailedOperation.caught(ex);
			}
		}

		private Gnd.KeyData _keyData = null;

		/// <summary>
		/// 画面の入力値から ServerInfo を生成する。
		/// 入力に問題があれば、例外を投げる。
		/// </summary>
		/// <returns></returns>
		private Gnd.ServerInfo getServerInfo(bool anonimousMode = false)
		{
			if (!anonimousMode)
			{
				if (this.txtTitle.Text == "")
					throw new FailedOperation("名前が指定されていません。");

				if (this.txtTitle.Text != this.txtTitle.Text.Trim())
					throw new FailedOperation(
						"名前に問題があります。\n" +
						"・前後に空白は使用できません。"
						);
			}
			if (this.txtHost.Text == "")
				throw new FailedOperation("ホスト名が指定されていません。");

			if (this.txtHost.Text != JString.toJString(this.txtHost.Text, false, false, false, false))
				throw new FailedOperation(
					"ホスト名に問題があります。\n" +
					"・ASCIIに変換できない文字は使用できません。\n" +
					"・空白は使用できません。"
					);

			if (this.txtPortNo.Text == "")
				throw new FailedOperation("ポート番号が指定されていません。");

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
						if (_keyData == null)
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

			// <-- check

			Gnd.ServerInfo si = new Gnd.ServerInfo();

			si.title = this.txtTitle.Text;
			si.host = this.txtHost.Text;
			si.portNo = int.Parse(this.txtPortNo.Text);
			si.key = null;
			si.passphrase = "";

			switch (this.cmbCipherMode.SelectedIndex)
			{
				case (int)Consts.CipherMode_e.ENCRYPT_BY_KEY:
					si.key = _keyData;
					break;

				case (int)Consts.CipherMode_e.ENCRYPT_BY_PASSPHRASE:
					si.passphrase = this.txtPassphrase.Text;
					break;

				default:
					break;
			}

			Gnd.i.relayPortNo = int.Parse(this.txtRelayPortNo.Text); // ここでいいのか？

			return si;
		}

		private void setServerInfo(Gnd.ServerInfo si)
		{
			this.txtTitle.Text = si.title;
			this.txtHost.Text = si.host;
			this.txtPortNo.Text = "" + si.portNo;
			this.cmbCipherMode.SelectedIndex = (int)si.cipherMode;
			_keyData = si.key;
			this.txtPassphrase.Text = si.passphrase;

			refreshUI();
		}

		private void doSortSISheet()
		{
			List<Gnd.ServerInfo> list = new List<Gnd.ServerInfo>();

			for (int rowidx = 0; rowidx < siSheet.RowCount; rowidx++)
				list.Add(siSheetGetRow(rowidx));

			ArrayTools.sort<Gnd.ServerInfo>(list, delegate(Gnd.ServerInfo a, Gnd.ServerInfo b)
			{
				return StringTools.comp(a.title, b.title);
			});

			for (int rowidx = 0; rowidx < siSheet.RowCount; rowidx++)
				siSheetSetRow(rowidx, list[rowidx]);
		}

		private void 接続SToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int rowidx = getFirstSelectedRowIndex();

			if (rowidx == -1)
				return;

			connect(rowidx);
		}

		private void connect(int rowidx)
		{
			try
			{
				Gnd.ServerInfo si = siSheetGetRow(rowidx);
				Connection con = new Connection(si, 0);
				retCon = con;
				this.Close();
			}
			catch (Exception ex)
			{
				FailedOperation.caught(ex);
			}
		}

		private void 読み込むLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int rowidx = getFirstSelectedRowIndex();

			if (rowidx == -1)
				return;

			Gnd.ServerInfo si = siSheetGetRow(rowidx);
			setServerInfo(si);
		}

		private void 名前を変更するRToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int rowidx = getFirstSelectedRowIndex();

			if (rowidx == -1)
				return;

			Gnd.ServerInfo si = siSheetGetRow(rowidx);
			string valTitle = si.title;

			for (; ; )
			{
				if (InputStringDlg.perform(
					"新しい名前を入力して下さい。",
					ref valTitle,
					1000
					) == false
					)
					break;

				try
				{
					if (valTitle == "")
						throw new FailedOperation("名前が入力されていません。");

					for (int rr = 0; rr < siSheet.RowCount; rr++)
						if (rr != rowidx && valTitle == siSheetGetRow(rr).title)
							throw new FailedOperation("名前が重複しています。");

					// 変更を反映
					si.title = valTitle;
					siSheetSetRow(rowidx, si);
					Utils.adjustColumnsWidth(siSheet);

					break;
				}
				catch (Exception ex)
				{
					FailedOperation.caught(ex);
				}
			}
		}

		private void 削除DToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int rowidx = getFirstSelectedRowIndex();

			if (rowidx == -1)
				return;

			Gnd.ServerInfo si = siSheetGetRow(rowidx);

			if (MessageBox.Show(
				"設定「" + si.title + "」を削除します。\n宜しいですか？",
				"確認",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Information
				) != DialogResult.Yes
				)
				return;

			siSheet.Rows.RemoveAt(rowidx);
		}

		private int getFirstSelectedRowIndex()
		{
			for (int rowidx = 0; rowidx < siSheet.RowCount; rowidx++)
				if (siSheet.Rows[rowidx].Selected)
					return rowidx;

			return -1; // not found
		}

		private int getRowIndexByTitle(string title)
		{
			for (int rowidx = 0; rowidx < siSheet.RowCount; rowidx++)
				if (siSheetGetRow(rowidx).title == title)
					return rowidx;

			return -1; // not found
		}

		private void btnKey_Click(object sender, EventArgs e)
		{
			using (KeyDataDlg f = new KeyDataDlg(_keyData))
			{
				f.ShowDialog();

				if (f.retKeyData != null)
				{
					_keyData = f.retKeyData;
					refreshUI();
				}
			}
		}
	}
}
