namespace Charlotte
{
	partial class ConnectDlg
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectDlg));
			this.siSheet = new System.Windows.Forms.DataGridView();
			this.siSheetMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.接続SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.読み込むLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.名前を変更するRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.削除DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnConnect = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtTitle = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.lblRelayPortNoMemo = new System.Windows.Forms.Label();
			this.lblRelayPortNo = new System.Windows.Forms.Label();
			this.txtRelayPortNo = new System.Windows.Forms.TextBox();
			this.lblPassphrase = new System.Windows.Forms.Label();
			this.txtPassphrase = new System.Windows.Forms.TextBox();
			this.btnKey = new System.Windows.Forms.Button();
			this.txtKeyIdent = new System.Windows.Forms.TextBox();
			this.lblKey = new System.Windows.Forms.Label();
			this.cmbCipherMode = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPortNo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtHost = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.siSheet)).BeginInit();
			this.siSheetMenu.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			//
			// siSheet
			//
			this.siSheet.AllowUserToAddRows = false;
			this.siSheet.AllowUserToDeleteRows = false;
			this.siSheet.AllowUserToResizeRows = false;
			this.siSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
			this.siSheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.siSheet.ContextMenuStrip = this.siSheetMenu;
			this.siSheet.Location = new System.Drawing.Point(12, 12);
			this.siSheet.MultiSelect = false;
			this.siSheet.Name = "siSheet";
			this.siSheet.ReadOnly = true;
			this.siSheet.RowTemplate.Height = 21;
			this.siSheet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.siSheet.Size = new System.Drawing.Size(665, 200);
			this.siSheet.TabIndex = 0;
			this.siSheet.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.siSheet_CellContentClick);
			this.siSheet.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.siSheet_CellDoubleClick);
			//
			// siSheetMenu
			//
			this.siSheetMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.接続SToolStripMenuItem,
            this.toolStripMenuItem1,
            this.読み込むLToolStripMenuItem,
            this.名前を変更するRToolStripMenuItem,
            this.削除DToolStripMenuItem});
			this.siSheetMenu.Name = "siSheetMenu";
			this.siSheetMenu.Size = new System.Drawing.Size(179, 120);
			//
			// 接続SToolStripMenuItem
			//
			this.接続SToolStripMenuItem.Name = "接続SToolStripMenuItem";
			this.接続SToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			this.接続SToolStripMenuItem.Text = "接続(&S)";
			this.接続SToolStripMenuItem.Click += new System.EventHandler(this.接続SToolStripMenuItem_Click);
			//
			// toolStripMenuItem1
			//
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(175, 6);
			//
			// 読み込むLToolStripMenuItem
			//
			this.読み込むLToolStripMenuItem.Name = "読み込むLToolStripMenuItem";
			this.読み込むLToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			this.読み込むLToolStripMenuItem.Text = "読み込む(&L)";
			this.読み込むLToolStripMenuItem.Click += new System.EventHandler(this.読み込むLToolStripMenuItem_Click);
			//
			// 名前を変更するRToolStripMenuItem
			//
			this.名前を変更するRToolStripMenuItem.Name = "名前を変更するRToolStripMenuItem";
			this.名前を変更するRToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			this.名前を変更するRToolStripMenuItem.Text = "名前を変更する(&R)";
			this.名前を変更するRToolStripMenuItem.Click += new System.EventHandler(this.名前を変更するRToolStripMenuItem_Click);
			//
			// 削除DToolStripMenuItem
			//
			this.削除DToolStripMenuItem.Name = "削除DToolStripMenuItem";
			this.削除DToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			this.削除DToolStripMenuItem.Text = "削除(&D)";
			this.削除DToolStripMenuItem.Click += new System.EventHandler(this.削除DToolStripMenuItem_Click);
			//
			// btnConnect
			//
			this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnConnect.Location = new System.Drawing.Point(439, 489);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(116, 48);
			this.btnConnect.TabIndex = 3;
			this.btnConnect.Text = "接続";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			//
			// btnCancel
			//
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(561, 489);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(116, 48);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "キャンセル";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			//
			// groupBox1
			//
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.txtTitle);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.lblRelayPortNoMemo);
			this.groupBox1.Controls.Add(this.lblRelayPortNo);
			this.groupBox1.Controls.Add(this.txtRelayPortNo);
			this.groupBox1.Controls.Add(this.lblPassphrase);
			this.groupBox1.Controls.Add(this.txtPassphrase);
			this.groupBox1.Controls.Add(this.btnKey);
			this.groupBox1.Controls.Add(this.txtKeyIdent);
			this.groupBox1.Controls.Add(this.lblKey);
			this.groupBox1.Controls.Add(this.cmbCipherMode);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtPortNo);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtHost);
			this.groupBox1.Location = new System.Drawing.Point(12, 218);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(665, 265);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "設定";
			//
			// label8
			//
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 29);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(48, 20);
			this.label8.TabIndex = 0;
			this.label8.Text = "名前：";
			//
			// txtTitle
			//
			this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTitle.Location = new System.Drawing.Point(112, 26);
			this.txtTitle.MaxLength = 1000;
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(540, 27);
			this.txtTitle.TabIndex = 1;
			this.txtTitle.Text = "名無しの設定さん";
			//
			// label7
			//
			this.label7.AutoSize = true;
			this.label7.ForeColor = System.Drawing.Color.Teal;
			this.label7.Location = new System.Drawing.Point(253, 95);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(217, 20);
			this.label7.TabIndex = 6;
			this.label7.Text = "接続先のポートを指定して下さい。";
			//
			// lblRelayPortNoMemo
			//
			this.lblRelayPortNoMemo.AutoSize = true;
			this.lblRelayPortNoMemo.ForeColor = System.Drawing.Color.Teal;
			this.lblRelayPortNoMemo.Location = new System.Drawing.Point(279, 228);
			this.lblRelayPortNoMemo.Name = "lblRelayPortNoMemo";
			this.lblRelayPortNoMemo.Size = new System.Drawing.Size(347, 20);
			this.lblRelayPortNoMemo.TabIndex = 15;
			this.lblRelayPortNoMemo.Text = "このコンピュータの空いているポートを指定して下さい。";
			//
			// lblRelayPortNo
			//
			this.lblRelayPortNo.AutoSize = true;
			this.lblRelayPortNo.Location = new System.Drawing.Point(6, 228);
			this.lblRelayPortNo.Name = "lblRelayPortNo";
			this.lblRelayPortNo.Size = new System.Drawing.Size(126, 20);
			this.lblRelayPortNo.TabIndex = 13;
			this.lblRelayPortNo.Text = "中継用ポート番号：";
			//
			// txtRelayPortNo
			//
			this.txtRelayPortNo.Location = new System.Drawing.Point(138, 225);
			this.txtRelayPortNo.MaxLength = 5;
			this.txtRelayPortNo.Name = "txtRelayPortNo";
			this.txtRelayPortNo.Size = new System.Drawing.Size(135, 27);
			this.txtRelayPortNo.TabIndex = 14;
			this.txtRelayPortNo.Text = "65535";
			this.txtRelayPortNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			// lblPassphrase
			//
			this.lblPassphrase.AutoSize = true;
			this.lblPassphrase.Location = new System.Drawing.Point(6, 195);
			this.lblPassphrase.Name = "lblPassphrase";
			this.lblPassphrase.Size = new System.Drawing.Size(100, 20);
			this.lblPassphrase.TabIndex = 11;
			this.lblPassphrase.Text = "パスフレーズ：";
			//
			// txtPassphrase
			//
			this.txtPassphrase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPassphrase.Location = new System.Drawing.Point(112, 192);
			this.txtPassphrase.MaxLength = 1000;
			this.txtPassphrase.Name = "txtPassphrase";
			this.txtPassphrase.Size = new System.Drawing.Size(540, 27);
			this.txtPassphrase.TabIndex = 12;
			this.txtPassphrase.Text = "1111";
			//
			// btnKey
			//
			this.btnKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnKey.Location = new System.Drawing.Point(580, 159);
			this.btnKey.Name = "btnKey";
			this.btnKey.Size = new System.Drawing.Size(72, 27);
			this.btnKey.TabIndex = 10;
			this.btnKey.Text = "設定";
			this.btnKey.UseVisualStyleBackColor = true;
			this.btnKey.Click += new System.EventHandler(this.btnKey_Click);
			//
			// txtKeyIdent
			//
			this.txtKeyIdent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtKeyIdent.Location = new System.Drawing.Point(112, 159);
			this.txtKeyIdent.Name = "txtKeyIdent";
			this.txtKeyIdent.ReadOnly = true;
			this.txtKeyIdent.Size = new System.Drawing.Size(468, 27);
			this.txtKeyIdent.TabIndex = 9;
			this.txtKeyIdent.Text = "UnrealRemoco-Key_0123456789abcdef0123456789abcdef";
			this.txtKeyIdent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKeyIdent_KeyPress);
			//
			// lblKey
			//
			this.lblKey.AutoSize = true;
			this.lblKey.Location = new System.Drawing.Point(6, 162);
			this.lblKey.Name = "lblKey";
			this.lblKey.Size = new System.Drawing.Size(35, 20);
			this.lblKey.TabIndex = 8;
			this.lblKey.Text = "鍵：";
			//
			// cmbCipherMode
			//
			this.cmbCipherMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCipherMode.FormattingEnabled = true;
			this.cmbCipherMode.Location = new System.Drawing.Point(112, 125);
			this.cmbCipherMode.Name = "cmbCipherMode";
			this.cmbCipherMode.Size = new System.Drawing.Size(270, 28);
			this.cmbCipherMode.TabIndex = 7;
			this.cmbCipherMode.SelectedIndexChanged += new System.EventHandler(this.cmbCipherMode_SelectedIndexChanged);
			//
			// label2
			//
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 95);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(87, 20);
			this.label2.TabIndex = 4;
			this.label2.Text = "ポート番号：";
			//
			// txtPortNo
			//
			this.txtPortNo.Location = new System.Drawing.Point(112, 92);
			this.txtPortNo.MaxLength = 5;
			this.txtPortNo.Name = "txtPortNo";
			this.txtPortNo.Size = new System.Drawing.Size(135, 27);
			this.txtPortNo.TabIndex = 5;
			this.txtPortNo.Text = "55900";
			this.txtPortNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 62);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 20);
			this.label1.TabIndex = 2;
			this.label1.Text = "ホスト名：";
			//
			// txtHost
			//
			this.txtHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtHost.Location = new System.Drawing.Point(112, 59);
			this.txtHost.MaxLength = 300;
			this.txtHost.Name = "txtHost";
			this.txtHost.Size = new System.Drawing.Size(540, 27);
			this.txtHost.TabIndex = 3;
			this.txtHost.Text = "localhost";
			//
			// btnSave
			//
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSave.Location = new System.Drawing.Point(12, 489);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(116, 48);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "設定を保存";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			//
			// ConnectDlg
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(689, 549);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnConnect);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.siSheet);
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ConnectDlg";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "UnrealRemoco / Client / 接続";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConnectDlg_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConnectDlg_FormClosed);
			this.Load += new System.EventHandler(this.ConnectDlg_Load);
			this.Shown += new System.EventHandler(this.ConnectDlg_Shown);
			((System.ComponentModel.ISupportInitialize)(this.siSheet)).EndInit();
			this.siSheetMenu.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView siSheet;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPortNo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtHost;
		private System.Windows.Forms.ComboBox cmbCipherMode;
		private System.Windows.Forms.Label lblKey;
		private System.Windows.Forms.TextBox txtKeyIdent;
		private System.Windows.Forms.Button btnKey;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblRelayPortNoMemo;
		private System.Windows.Forms.Label lblRelayPortNo;
		private System.Windows.Forms.TextBox txtRelayPortNo;
		private System.Windows.Forms.Label lblPassphrase;
		private System.Windows.Forms.TextBox txtPassphrase;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.ContextMenuStrip siSheetMenu;
		private System.Windows.Forms.ToolStripMenuItem 接続SToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 読み込むLToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 削除DToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 名前を変更するRToolStripMenuItem;
	}
}
