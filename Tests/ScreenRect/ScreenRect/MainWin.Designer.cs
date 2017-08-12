namespace ScreenRect
{
	partial class MainWin
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
			this.mainPanel = new System.Windows.Forms.Panel();
			this.pbScreen = new System.Windows.Forms.PictureBox();
			this.lblStatus = new System.Windows.Forms.Label();
			this.mainTimer = new System.Windows.Forms.Timer(this.components);
			this.mainPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbScreen)).BeginInit();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mainPanel.AutoScroll = true;
			this.mainPanel.Controls.Add(this.pbScreen);
			this.mainPanel.Location = new System.Drawing.Point(12, 12);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(460, 418);
			this.mainPanel.TabIndex = 0;
			// 
			// pbScreen
			// 
			this.pbScreen.Location = new System.Drawing.Point(44, 44);
			this.pbScreen.Name = "pbScreen";
			this.pbScreen.Size = new System.Drawing.Size(111, 111);
			this.pbScreen.TabIndex = 0;
			this.pbScreen.TabStop = false;
			// 
			// lblStatus
			// 
			this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(12, 433);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(115, 20);
			this.lblStatus.TabIndex = 1;
			this.lblStatus.Text = "準備しています...";
			// 
			// mainTimer
			// 
			this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
			// 
			// MainWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 462);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.mainPanel);
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "MainWin";
			this.Text = "MainWin";
			this.Activated += new System.EventHandler(this.MainWin_Activated);
			this.Deactivate += new System.EventHandler(this.MainWin_Deactivate);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWin_FormClosed);
			this.Load += new System.EventHandler(this.MainWin_Load);
			this.Shown += new System.EventHandler(this.MainWin_Shown);
			this.ResizeEnd += new System.EventHandler(this.MainWin_ResizeEnd);
			this.Move += new System.EventHandler(this.MainWin_Move);
			this.mainPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbScreen)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.PictureBox pbScreen;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Timer mainTimer;
	}
}

