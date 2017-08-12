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
			this.txtRelayPortNo = new System.Windows.Forms.TextBox();
			this.cbActivateOutOfScreen = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			//
			// btnOk
			//
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(244, 152);
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
			this.btnCancel.Location = new System.Drawing.Point(366, 152);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(116, 48);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "キャンセル";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 50);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(126, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "中継用ポート番号：";
			//
			// txtRelayPortNo
			//
			this.txtRelayPortNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtRelayPortNo.Location = new System.Drawing.Point(152, 47);
			this.txtRelayPortNo.MaxLength = 5;
			this.txtRelayPortNo.Name = "txtRelayPortNo";
			this.txtRelayPortNo.Size = new System.Drawing.Size(327, 27);
			this.txtRelayPortNo.TabIndex = 1;
			this.txtRelayPortNo.Text = "65535";
			this.txtRelayPortNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			// cbActivateOutOfScreen
			//
			this.cbActivateOutOfScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbActivateOutOfScreen.AutoSize = true;
			this.cbActivateOutOfScreen.Location = new System.Drawing.Point(90, 100);
			this.cbActivateOutOfScreen.Name = "cbActivateOutOfScreen";
			this.cbActivateOutOfScreen.Size = new System.Drawing.Size(392, 24);
			this.cbActivateOutOfScreen.TabIndex = 2;
			this.cbActivateOutOfScreen.Text = "マウスカーソルがスクリーンの外に出てもアクティブにする。";
			this.cbActivateOutOfScreen.UseVisualStyleBackColor = true;
			//
			// SettingDlg
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(494, 212);
			this.Controls.Add(this.cbActivateOutOfScreen);
			this.Controls.Add(this.txtRelayPortNo);
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
			this.Text = "UnrealRemoco / Client / 設定";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingDlg_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingDlg_FormClosed);
			this.Load += new System.EventHandler(this.SettingDlg_Load);
			this.Shown += new System.EventHandler(this.SettingDlg_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtRelayPortNo;
		private System.Windows.Forms.CheckBox cbActivateOutOfScreen;
	}
}
