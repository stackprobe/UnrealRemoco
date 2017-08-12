namespace Charlotte
{
	partial class KeyDataDlg
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyDataDlg));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtHash = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtRaw = new System.Windows.Forms.TextBox();
			this.txtIdent = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnNew = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnImport = new System.Windows.Forms.Button();
			this.btnExport = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			//
			// groupBox1
			//
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtHash);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtRaw);
			this.groupBox1.Controls.Add(this.txtIdent);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.btnNew);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(582, 188);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "鍵";
			//
			// label3
			//
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 137);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 20);
			this.label3.TabIndex = 4;
			this.label3.Text = "Hash：";
			//
			// txtHash
			//
			this.txtHash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtHash.Location = new System.Drawing.Point(78, 134);
			this.txtHash.Name = "txtHash";
			this.txtHash.ReadOnly = true;
			this.txtHash.Size = new System.Drawing.Size(376, 27);
			this.txtHash.TabIndex = 5;
			this.txtHash.Text = "0123456789abcdef0123456789abcdef";
			this.txtHash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHash_KeyPress);
			//
			// label2
			//
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 65);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Key：";
			//
			// txtRaw
			//
			this.txtRaw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtRaw.Location = new System.Drawing.Point(78, 62);
			this.txtRaw.Multiline = true;
			this.txtRaw.Name = "txtRaw";
			this.txtRaw.ReadOnly = true;
			this.txtRaw.Size = new System.Drawing.Size(486, 66);
			this.txtRaw.TabIndex = 3;
			this.txtRaw.Text = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0" +
    "123456789abcdef0123456789abcdef0123456789abcdef";
			this.txtRaw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKey_KeyPress);
			//
			// txtIdent
			//
			this.txtIdent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtIdent.Location = new System.Drawing.Point(78, 29);
			this.txtIdent.Name = "txtIdent";
			this.txtIdent.ReadOnly = true;
			this.txtIdent.Size = new System.Drawing.Size(486, 27);
			this.txtIdent.TabIndex = 1;
			this.txtIdent.Text = "UnrealRemoco-Key_0123456789abcdef0123456789abcdef";
			this.txtIdent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdent_KeyPress);
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ident：";
			//
			// btnNew
			//
			this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNew.Location = new System.Drawing.Point(460, 134);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(116, 48);
			this.btnNew.TabIndex = 6;
			this.btnNew.Text = "生成";
			this.btnNew.UseVisualStyleBackColor = true;
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			//
			// btnOk
			//
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(356, 206);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(116, 48);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			//
			// btnCancel
			//
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(478, 206);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(116, 48);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "キャンセル";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			//
			// btnImport
			//
			this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnImport.Location = new System.Drawing.Point(12, 206);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(116, 48);
			this.btnImport.TabIndex = 1;
			this.btnImport.Text = "インポート";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			//
			// btnExport
			//
			this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnExport.Location = new System.Drawing.Point(134, 206);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(116, 48);
			this.btnExport.TabIndex = 2;
			this.btnExport.Text = "エクスポート";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			//
			// KeyDataDlg
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(606, 266);
			this.Controls.Add(this.btnExport);
			this.Controls.Add(this.btnImport);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "KeyDataDlg";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "鍵の設定";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KeyDataDlg_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.KeyDataDlg_FormClosed);
			this.Load += new System.EventHandler(this.KeyDataDlg_Load);
			this.Shown += new System.EventHandler(this.KeyDataDlg_Shown);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnImport;
		private System.Windows.Forms.Button btnExport;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtHash;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtRaw;
		private System.Windows.Forms.TextBox txtIdent;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnNew;
	}
}
