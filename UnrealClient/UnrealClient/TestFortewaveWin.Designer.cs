namespace Charlotte
{
	partial class TestFortewaveWin
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
			this.txtSend = new System.Windows.Forms.TextBox();
			this.txtRecv = new System.Windows.Forms.TextBox();
			this.lblStatus = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtSend
			// 
			this.txtSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSend.Location = new System.Drawing.Point(12, 12);
			this.txtSend.Multiline = true;
			this.txtSend.Name = "txtSend";
			this.txtSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtSend.Size = new System.Drawing.Size(630, 66);
			this.txtSend.TabIndex = 0;
			this.txtSend.Text = "ここにメッセージを書いて下さい。\r\n１行を１メッセージとして送ります。\r\n送るには ctrl+enter を押して下さい。";
			this.txtSend.TextChanged += new System.EventHandler(this.txtSend_TextChanged);
			this.txtSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSend_KeyPress);
			// 
			// txtRecv
			// 
			this.txtRecv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtRecv.Location = new System.Drawing.Point(12, 104);
			this.txtRecv.Multiline = true;
			this.txtRecv.Name = "txtRecv";
			this.txtRecv.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtRecv.Size = new System.Drawing.Size(630, 385);
			this.txtRecv.TabIndex = 2;
			this.txtRecv.Text = "受信メッセージ";
			this.txtRecv.TextChanged += new System.EventHandler(this.txtRecv_TextChanged);
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(12, 81);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(61, 20);
			this.lblStatus.TabIndex = 1;
			this.lblStatus.Text = "送信可能";
			// 
			// TestFortewaveWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(654, 501);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.txtRecv);
			this.Controls.Add(this.txtSend);
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "TestFortewaveWin";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "TestFortewaveWin";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TestFortewaveWin_FormClosed);
			this.Load += new System.EventHandler(this.TestFortewaveWin_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtSend;
		private System.Windows.Forms.TextBox txtRecv;
		private System.Windows.Forms.Label lblStatus;
	}
}
