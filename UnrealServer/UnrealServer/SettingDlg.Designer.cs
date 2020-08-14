namespace Charlotte
{
	partial class SettingDlg
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingDlg));
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtPortNo = new System.Windows.Forms.TextBox();
			this.cmbCipherMode = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblForwardPortNoMemoSub = new System.Windows.Forms.Label();
			this.lblForwardPortNoMemo = new System.Windows.Forms.Label();
			this.lblForwardPortNo = new System.Windows.Forms.Label();
			this.txtForwardPortNo = new System.Windows.Forms.TextBox();
			this.lblPassphrase = new System.Windows.Forms.Label();
			this.txtPassphrase = new System.Windows.Forms.TextBox();
			this.lblKey = new System.Windows.Forms.Label();
			this.btnKey = new System.Windows.Forms.Button();
			this.txtKey = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnDefault = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(444, 311);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(116, 48);
			this.btnOk.TabIndex = 5;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(566, 311);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(116, 48);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "キャンセル";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "ポート番号：";
			// 
			// txtPortNo
			// 
			this.txtPortNo.Location = new System.Drawing.Point(126, 20);
			this.txtPortNo.MaxLength = 5;
			this.txtPortNo.Name = "txtPortNo";
			this.txtPortNo.Size = new System.Drawing.Size(135, 27);
			this.txtPortNo.TabIndex = 1;
			this.txtPortNo.Text = "65535";
			this.txtPortNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cmbCipherMode
			// 
			this.cmbCipherMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbCipherMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCipherMode.FormattingEnabled = true;
			this.cmbCipherMode.Location = new System.Drawing.Point(114, 36);
			this.cmbCipherMode.Name = "cmbCipherMode";
			this.cmbCipherMode.Size = new System.Drawing.Size(540, 28);
			this.cmbCipherMode.TabIndex = 0;
			this.cmbCipherMode.SelectedIndexChanged += new System.EventHandler(this.cmbCipherMode_SelectedIndexChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.lblForwardPortNoMemoSub);
			this.groupBox1.Controls.Add(this.lblForwardPortNoMemo);
			this.groupBox1.Controls.Add(this.lblForwardPortNo);
			this.groupBox1.Controls.Add(this.txtForwardPortNo);
			this.groupBox1.Controls.Add(this.lblPassphrase);
			this.groupBox1.Controls.Add(this.txtPassphrase);
			this.groupBox1.Controls.Add(this.lblKey);
			this.groupBox1.Controls.Add(this.btnKey);
			this.groupBox1.Controls.Add(this.txtKey);
			this.groupBox1.Controls.Add(this.cmbCipherMode);
			this.groupBox1.Location = new System.Drawing.Point(12, 66);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(670, 229);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "暗号化";
			// 
			// lblForwardPortNoMemoSub
			// 
			this.lblForwardPortNoMemoSub.AutoSize = true;
			this.lblForwardPortNoMemoSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lblForwardPortNoMemoSub.Location = new System.Drawing.Point(281, 189);
			this.lblForwardPortNoMemoSub.Name = "lblForwardPortNoMemoSub";
			this.lblForwardPortNoMemoSub.Size = new System.Drawing.Size(217, 20);
			this.lblForwardPortNoMemoSub.TabIndex = 9;
			this.lblForwardPortNoMemoSub.Text = "このポートは開放しないで下さい。";
			// 
			// lblForwardPortNoMemo
			// 
			this.lblForwardPortNoMemo.AutoSize = true;
			this.lblForwardPortNoMemo.ForeColor = System.Drawing.Color.Teal;
			this.lblForwardPortNoMemo.Location = new System.Drawing.Point(281, 169);
			this.lblForwardPortNoMemo.Name = "lblForwardPortNoMemo";
			this.lblForwardPortNoMemo.Size = new System.Drawing.Size(347, 20);
			this.lblForwardPortNoMemo.TabIndex = 8;
			this.lblForwardPortNoMemo.Text = "このコンピュータの空いているポートを指定して下さい。";
			// 
			// lblForwardPortNo
			// 
			this.lblForwardPortNo.AutoSize = true;
			this.lblForwardPortNo.Location = new System.Drawing.Point(8, 169);
			this.lblForwardPortNo.Name = "lblForwardPortNo";
			this.lblForwardPortNo.Size = new System.Drawing.Size(126, 20);
			this.lblForwardPortNo.TabIndex = 6;
			this.lblForwardPortNo.Text = "中継用ポート番号：";
			// 
			// txtForwardPortNo
			// 
			this.txtForwardPortNo.Location = new System.Drawing.Point(140, 166);
			this.txtForwardPortNo.MaxLength = 5;
			this.txtForwardPortNo.Name = "txtForwardPortNo";
			this.txtForwardPortNo.Size = new System.Drawing.Size(135, 27);
			this.txtForwardPortNo.TabIndex = 7;
			this.txtForwardPortNo.Text = "65535";
			this.txtForwardPortNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblPassphrase
			// 
			this.lblPassphrase.AutoSize = true;
			this.lblPassphrase.Location = new System.Drawing.Point(8, 126);
			this.lblPassphrase.Name = "lblPassphrase";
			this.lblPassphrase.Size = new System.Drawing.Size(100, 20);
			this.lblPassphrase.TabIndex = 4;
			this.lblPassphrase.Text = "パスフレーズ：";
			// 
			// txtPassphrase
			// 
			this.txtPassphrase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPassphrase.Location = new System.Drawing.Point(114, 123);
			this.txtPassphrase.MaxLength = 1000;
			this.txtPassphrase.Name = "txtPassphrase";
			this.txtPassphrase.Size = new System.Drawing.Size(540, 27);
			this.txtPassphrase.TabIndex = 5;
			this.txtPassphrase.Text = "1111";
			// 
			// lblKey
			// 
			this.lblKey.AutoSize = true;
			this.lblKey.Location = new System.Drawing.Point(8, 83);
			this.lblKey.Name = "lblKey";
			this.lblKey.Size = new System.Drawing.Size(35, 20);
			this.lblKey.TabIndex = 1;
			this.lblKey.Text = "鍵：";
			// 
			// btnKey
			// 
			this.btnKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnKey.Location = new System.Drawing.Point(594, 80);
			this.btnKey.Name = "btnKey";
			this.btnKey.Size = new System.Drawing.Size(60, 27);
			this.btnKey.TabIndex = 3;
			this.btnKey.Text = "設定";
			this.btnKey.UseVisualStyleBackColor = true;
			this.btnKey.Click += new System.EventHandler(this.btnKey_Click);
			// 
			// txtKey
			// 
			this.txtKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtKey.Location = new System.Drawing.Point(114, 80);
			this.txtKey.Name = "txtKey";
			this.txtKey.ReadOnly = true;
			this.txtKey.Size = new System.Drawing.Size(480, 27);
			this.txtKey.TabIndex = 2;
			this.txtKey.Text = "UnrealRemoco-Key_0123456789abcdef0123456789abcdef";
			this.txtKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKey_KeyPress);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.Teal;
			this.label3.Location = new System.Drawing.Point(267, 23);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(217, 20);
			this.label3.TabIndex = 2;
			this.label3.Text = "待ち受けポートを指定して下さい。";
			// 
			// btnDefault
			// 
			this.btnDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDefault.Location = new System.Drawing.Point(12, 311);
			this.btnDefault.Name = "btnDefault";
			this.btnDefault.Size = new System.Drawing.Size(116, 48);
			this.btnDefault.TabIndex = 7;
			this.btnDefault.Text = "デフォルト";
			this.btnDefault.UseVisualStyleBackColor = true;
			this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.Blue;
			this.label2.Location = new System.Drawing.Point(267, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(191, 20);
			this.label2.TabIndex = 3;
			this.label2.Text = "このポートを開放して下さい。";
			// 
			// SettingDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(694, 371);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnDefault);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.txtPortNo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "UnrealRemoco / Server / 設定";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingDlg_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingDlg_FormClosed);
			this.Load += new System.EventHandler(this.SettingDlg_Load);
			this.Shown += new System.EventHandler(this.SettingDlg_Shown);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPortNo;
		private System.Windows.Forms.ComboBox cmbCipherMode;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblPassphrase;
		private System.Windows.Forms.TextBox txtPassphrase;
		private System.Windows.Forms.Label lblKey;
		private System.Windows.Forms.Button btnKey;
		private System.Windows.Forms.TextBox txtKey;
		private System.Windows.Forms.Label lblForwardPortNoMemo;
		private System.Windows.Forms.Label lblForwardPortNo;
		private System.Windows.Forms.TextBox txtForwardPortNo;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnDefault;
		private System.Windows.Forms.Label lblForwardPortNoMemoSub;
		private System.Windows.Forms.Label label2;
	}
}
