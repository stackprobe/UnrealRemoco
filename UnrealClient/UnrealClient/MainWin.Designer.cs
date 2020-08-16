namespace Charlotte
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.アプリAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.終了XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.接続CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.接続CToolStripMenuItemSub = new System.Windows.Forms.ToolStripMenuItem();
			this.再接続RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.モニタ選択MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.miSelectMonitor01 = new System.Windows.Forms.ToolStripMenuItem();
			this.miSelectMonitor02 = new System.Windows.Forms.ToolStripMenuItem();
			this.miSelectMonitor03 = new System.Windows.Forms.ToolStripMenuItem();
			this.miSelectMonitor04 = new System.Windows.Forms.ToolStripMenuItem();
			this.miSelectMonitor05 = new System.Windows.Forms.ToolStripMenuItem();
			this.miSelectMonitor06 = new System.Windows.Forms.ToolStripMenuItem();
			this.miSelectMonitor07 = new System.Windows.Forms.ToolStripMenuItem();
			this.miSelectMonitor08 = new System.Windows.Forms.ToolStripMenuItem();
			this.miSelectMonitor09 = new System.Windows.Forms.ToolStripMenuItem();
			this.miSelectMonitor10 = new System.Windows.Forms.ToolStripMenuItem();
			this.miSelectMonitor11 = new System.Windows.Forms.ToolStripMenuItem();
			this.miSelectMonitor12 = new System.Windows.Forms.ToolStripMenuItem();
			this.miSelectMonitor13 = new System.Windows.Forms.ToolStripMenuItem();
			this.miSelectMonitor14 = new System.Windows.Forms.ToolStripMenuItem();
			this.miSelectMonitor15 = new System.Windows.Forms.ToolStripMenuItem();
			this.miSelectMonitor16 = new System.Windows.Forms.ToolStripMenuItem();
			this.miSelectMonitor17 = new System.Windows.Forms.ToolStripMenuItem();
			this.miSelectMonitor18 = new System.Windows.Forms.ToolStripMenuItem();
			this.miSelectMonitor19 = new System.Windows.Forms.ToolStripMenuItem();
			this.miSelectMonitor20 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.切断DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.設定SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.画質QToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.その他の設定SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.クリップボードToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.クライアントからサーバーへToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.サーバーからクライアントへToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.テストToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.テストToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.mainTimer = new System.Windows.Forms.Timer(this.components);
			this.mainPanel = new System.Windows.Forms.Panel();
			this.lblMessage = new System.Windows.Forms.Label();
			this.pbScreen = new System.Windows.Forms.PictureBox();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.mainPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbScreen)).BeginInit();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
			this.statusStrip1.Location = new System.Drawing.Point(0, 439);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(484, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lblStatus
			// 
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(469, 17);
			this.lblStatus.Spring = true;
			this.lblStatus.Text = "準備しています...";
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.アプリAToolStripMenuItem,
            this.接続CToolStripMenuItem,
            this.設定SToolStripMenuItem,
            this.クリップボードToolStripMenuItem,
            this.テストToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(484, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// アプリAToolStripMenuItem
			// 
			this.アプリAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.終了XToolStripMenuItem});
			this.アプリAToolStripMenuItem.Name = "アプリAToolStripMenuItem";
			this.アプリAToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
			this.アプリAToolStripMenuItem.Text = "アプリ";
			this.アプリAToolStripMenuItem.DropDownClosed += new System.EventHandler(this.アプリAToolStripMenuItem_DropDownClosed);
			this.アプリAToolStripMenuItem.DropDownOpened += new System.EventHandler(this.アプリAToolStripMenuItem_DropDownOpened);
			// 
			// 終了XToolStripMenuItem
			// 
			this.終了XToolStripMenuItem.Name = "終了XToolStripMenuItem";
			this.終了XToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
			this.終了XToolStripMenuItem.Text = "終了";
			this.終了XToolStripMenuItem.Click += new System.EventHandler(this.終了XToolStripMenuItem_Click);
			// 
			// 接続CToolStripMenuItem
			// 
			this.接続CToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.接続CToolStripMenuItemSub,
            this.再接続RToolStripMenuItem,
            this.モニタ選択MToolStripMenuItem,
            this.toolStripMenuItem1,
            this.切断DToolStripMenuItem});
			this.接続CToolStripMenuItem.Name = "接続CToolStripMenuItem";
			this.接続CToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.接続CToolStripMenuItem.Text = "接続";
			this.接続CToolStripMenuItem.DropDownClosed += new System.EventHandler(this.接続CToolStripMenuItem_DropDownClosed);
			this.接続CToolStripMenuItem.DropDownOpened += new System.EventHandler(this.接続CToolStripMenuItem_DropDownOpened);
			// 
			// 接続CToolStripMenuItemSub
			// 
			this.接続CToolStripMenuItemSub.Name = "接続CToolStripMenuItemSub";
			this.接続CToolStripMenuItemSub.Size = new System.Drawing.Size(125, 22);
			this.接続CToolStripMenuItemSub.Text = "接続";
			this.接続CToolStripMenuItemSub.Click += new System.EventHandler(this.接続CToolStripMenuItemSub_Click);
			// 
			// 再接続RToolStripMenuItem
			// 
			this.再接続RToolStripMenuItem.Name = "再接続RToolStripMenuItem";
			this.再接続RToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
			this.再接続RToolStripMenuItem.Text = "再接続";
			this.再接続RToolStripMenuItem.Click += new System.EventHandler(this.再接続RToolStripMenuItem_Click);
			// 
			// モニタ選択MToolStripMenuItem
			// 
			this.モニタ選択MToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSelectMonitor01,
            this.miSelectMonitor02,
            this.miSelectMonitor03,
            this.miSelectMonitor04,
            this.miSelectMonitor05,
            this.miSelectMonitor06,
            this.miSelectMonitor07,
            this.miSelectMonitor08,
            this.miSelectMonitor09,
            this.miSelectMonitor10,
            this.miSelectMonitor11,
            this.miSelectMonitor12,
            this.miSelectMonitor13,
            this.miSelectMonitor14,
            this.miSelectMonitor15,
            this.miSelectMonitor16,
            this.miSelectMonitor17,
            this.miSelectMonitor18,
            this.miSelectMonitor19,
            this.miSelectMonitor20});
			this.モニタ選択MToolStripMenuItem.Name = "モニタ選択MToolStripMenuItem";
			this.モニタ選択MToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
			this.モニタ選択MToolStripMenuItem.Text = "モニタ選択";
			// 
			// miSelectMonitor01
			// 
			this.miSelectMonitor01.Name = "miSelectMonitor01";
			this.miSelectMonitor01.Size = new System.Drawing.Size(119, 22);
			this.miSelectMonitor01.Text = "プライマリ";
			this.miSelectMonitor01.Click += new System.EventHandler(this.miSelectMonitor01_Click);
			// 
			// miSelectMonitor02
			// 
			this.miSelectMonitor02.Name = "miSelectMonitor02";
			this.miSelectMonitor02.Size = new System.Drawing.Size(119, 22);
			this.miSelectMonitor02.Text = "セカンダリ";
			this.miSelectMonitor02.Click += new System.EventHandler(this.miSelectMonitor02_Click);
			// 
			// miSelectMonitor03
			// 
			this.miSelectMonitor03.Name = "miSelectMonitor03";
			this.miSelectMonitor03.Size = new System.Drawing.Size(119, 22);
			this.miSelectMonitor03.Text = "&3";
			this.miSelectMonitor03.Click += new System.EventHandler(this.miSelectMonitor03_Click);
			// 
			// miSelectMonitor04
			// 
			this.miSelectMonitor04.Name = "miSelectMonitor04";
			this.miSelectMonitor04.Size = new System.Drawing.Size(119, 22);
			this.miSelectMonitor04.Text = "&4";
			this.miSelectMonitor04.Click += new System.EventHandler(this.miSelectMonitor04_Click);
			// 
			// miSelectMonitor05
			// 
			this.miSelectMonitor05.Name = "miSelectMonitor05";
			this.miSelectMonitor05.Size = new System.Drawing.Size(119, 22);
			this.miSelectMonitor05.Text = "&5";
			this.miSelectMonitor05.Click += new System.EventHandler(this.miSelectMonitor05_Click);
			// 
			// miSelectMonitor06
			// 
			this.miSelectMonitor06.Name = "miSelectMonitor06";
			this.miSelectMonitor06.Size = new System.Drawing.Size(119, 22);
			this.miSelectMonitor06.Text = "&6";
			this.miSelectMonitor06.Click += new System.EventHandler(this.miSelectMonitor06_Click);
			// 
			// miSelectMonitor07
			// 
			this.miSelectMonitor07.Name = "miSelectMonitor07";
			this.miSelectMonitor07.Size = new System.Drawing.Size(119, 22);
			this.miSelectMonitor07.Text = "&7";
			this.miSelectMonitor07.Click += new System.EventHandler(this.miSelectMonitor07_Click);
			// 
			// miSelectMonitor08
			// 
			this.miSelectMonitor08.Name = "miSelectMonitor08";
			this.miSelectMonitor08.Size = new System.Drawing.Size(119, 22);
			this.miSelectMonitor08.Text = "&8";
			this.miSelectMonitor08.Click += new System.EventHandler(this.miSelectMonitor08_Click);
			// 
			// miSelectMonitor09
			// 
			this.miSelectMonitor09.Name = "miSelectMonitor09";
			this.miSelectMonitor09.Size = new System.Drawing.Size(119, 22);
			this.miSelectMonitor09.Text = "&9";
			this.miSelectMonitor09.Click += new System.EventHandler(this.miSelectMonitor09_Click);
			// 
			// miSelectMonitor10
			// 
			this.miSelectMonitor10.Name = "miSelectMonitor10";
			this.miSelectMonitor10.Size = new System.Drawing.Size(119, 22);
			this.miSelectMonitor10.Text = "10";
			this.miSelectMonitor10.Click += new System.EventHandler(this.miSelectMonitor10_Click);
			// 
			// miSelectMonitor11
			// 
			this.miSelectMonitor11.Name = "miSelectMonitor11";
			this.miSelectMonitor11.Size = new System.Drawing.Size(119, 22);
			this.miSelectMonitor11.Text = "11";
			this.miSelectMonitor11.Click += new System.EventHandler(this.miSelectMonitor11_Click);
			// 
			// miSelectMonitor12
			// 
			this.miSelectMonitor12.Name = "miSelectMonitor12";
			this.miSelectMonitor12.Size = new System.Drawing.Size(119, 22);
			this.miSelectMonitor12.Text = "12";
			this.miSelectMonitor12.Click += new System.EventHandler(this.miSelectMonitor12_Click);
			// 
			// miSelectMonitor13
			// 
			this.miSelectMonitor13.Name = "miSelectMonitor13";
			this.miSelectMonitor13.Size = new System.Drawing.Size(119, 22);
			this.miSelectMonitor13.Text = "13";
			this.miSelectMonitor13.Click += new System.EventHandler(this.miSelectMonitor13_Click);
			// 
			// miSelectMonitor14
			// 
			this.miSelectMonitor14.Name = "miSelectMonitor14";
			this.miSelectMonitor14.Size = new System.Drawing.Size(119, 22);
			this.miSelectMonitor14.Text = "14";
			this.miSelectMonitor14.Click += new System.EventHandler(this.miSelectMonitor14_Click);
			// 
			// miSelectMonitor15
			// 
			this.miSelectMonitor15.Name = "miSelectMonitor15";
			this.miSelectMonitor15.Size = new System.Drawing.Size(119, 22);
			this.miSelectMonitor15.Text = "15";
			this.miSelectMonitor15.Click += new System.EventHandler(this.miSelectMonitor15_Click);
			// 
			// miSelectMonitor16
			// 
			this.miSelectMonitor16.Name = "miSelectMonitor16";
			this.miSelectMonitor16.Size = new System.Drawing.Size(119, 22);
			this.miSelectMonitor16.Text = "16";
			this.miSelectMonitor16.Click += new System.EventHandler(this.miSelectMonitor16_Click);
			// 
			// miSelectMonitor17
			// 
			this.miSelectMonitor17.Name = "miSelectMonitor17";
			this.miSelectMonitor17.Size = new System.Drawing.Size(119, 22);
			this.miSelectMonitor17.Text = "17";
			this.miSelectMonitor17.Click += new System.EventHandler(this.miSelectMonitor17_Click);
			// 
			// miSelectMonitor18
			// 
			this.miSelectMonitor18.Name = "miSelectMonitor18";
			this.miSelectMonitor18.Size = new System.Drawing.Size(119, 22);
			this.miSelectMonitor18.Text = "18";
			this.miSelectMonitor18.Click += new System.EventHandler(this.miSelectMonitor18_Click);
			// 
			// miSelectMonitor19
			// 
			this.miSelectMonitor19.Name = "miSelectMonitor19";
			this.miSelectMonitor19.Size = new System.Drawing.Size(119, 22);
			this.miSelectMonitor19.Text = "19";
			this.miSelectMonitor19.Click += new System.EventHandler(this.miSelectMonitor19_Click);
			// 
			// miSelectMonitor20
			// 
			this.miSelectMonitor20.Name = "miSelectMonitor20";
			this.miSelectMonitor20.Size = new System.Drawing.Size(119, 22);
			this.miSelectMonitor20.Text = "20";
			this.miSelectMonitor20.Click += new System.EventHandler(this.miSelectMonitor20_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(122, 6);
			// 
			// 切断DToolStripMenuItem
			// 
			this.切断DToolStripMenuItem.Name = "切断DToolStripMenuItem";
			this.切断DToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
			this.切断DToolStripMenuItem.Text = "切断";
			this.切断DToolStripMenuItem.Click += new System.EventHandler(this.切断DToolStripMenuItem_Click);
			// 
			// 設定SToolStripMenuItem
			// 
			this.設定SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.画質QToolStripMenuItem,
            this.toolStripMenuItem2,
            this.その他の設定SToolStripMenuItem});
			this.設定SToolStripMenuItem.Name = "設定SToolStripMenuItem";
			this.設定SToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.設定SToolStripMenuItem.Text = "設定";
			this.設定SToolStripMenuItem.DropDownClosed += new System.EventHandler(this.設定SToolStripMenuItem_DropDownClosed);
			this.設定SToolStripMenuItem.DropDownOpened += new System.EventHandler(this.設定SToolStripMenuItem_DropDownOpened);
			// 
			// 画質QToolStripMenuItem
			// 
			this.画質QToolStripMenuItem.Name = "画質QToolStripMenuItem";
			this.画質QToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.画質QToolStripMenuItem.Text = "画質";
			this.画質QToolStripMenuItem.Click += new System.EventHandler(this.画質QToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(136, 6);
			// 
			// その他の設定SToolStripMenuItem
			// 
			this.その他の設定SToolStripMenuItem.Name = "その他の設定SToolStripMenuItem";
			this.その他の設定SToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.その他の設定SToolStripMenuItem.Text = "その他の設定";
			this.その他の設定SToolStripMenuItem.Click += new System.EventHandler(this.その他の設定SToolStripMenuItem_Click);
			// 
			// クリップボードToolStripMenuItem
			// 
			this.クリップボードToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.クライアントからサーバーへToolStripMenuItem,
            this.サーバーからクライアントへToolStripMenuItem});
			this.クリップボードToolStripMenuItem.Name = "クリップボードToolStripMenuItem";
			this.クリップボードToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
			this.クリップボードToolStripMenuItem.Text = "クリップボード";
			this.クリップボードToolStripMenuItem.DropDownClosed += new System.EventHandler(this.クリップボードToolStripMenuItem_DropDownClosed);
			this.クリップボードToolStripMenuItem.DropDownOpened += new System.EventHandler(this.クリップボードToolStripMenuItem_DropDownOpened);
			// 
			// クライアントからサーバーへToolStripMenuItem
			// 
			this.クライアントからサーバーへToolStripMenuItem.Name = "クライアントからサーバーへToolStripMenuItem";
			this.クライアントからサーバーへToolStripMenuItem.Size = new System.Drawing.Size(411, 22);
			this.クライアントからサーバーへToolStripMenuItem.Text = "「クライアント」のクリップボード・テキストを「サーバー」のクリップボードへコピー";
			this.クライアントからサーバーへToolStripMenuItem.Click += new System.EventHandler(this.クライアントからサーバーへToolStripMenuItem_Click);
			// 
			// サーバーからクライアントへToolStripMenuItem
			// 
			this.サーバーからクライアントへToolStripMenuItem.Name = "サーバーからクライアントへToolStripMenuItem";
			this.サーバーからクライアントへToolStripMenuItem.Size = new System.Drawing.Size(411, 22);
			this.サーバーからクライアントへToolStripMenuItem.Text = "「サーバー」のクリップボード・テキストを「クライアント」のクリップボードへコピー";
			this.サーバーからクライアントへToolStripMenuItem.Click += new System.EventHandler(this.サーバーからクライアントへToolStripMenuItem_Click);
			// 
			// テストToolStripMenuItem
			// 
			this.テストToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.テストToolStripMenuItem1});
			this.テストToolStripMenuItem.Name = "テストToolStripMenuItem";
			this.テストToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
			this.テストToolStripMenuItem.Text = "テスト";
			// 
			// テストToolStripMenuItem1
			// 
			this.テストToolStripMenuItem1.Name = "テストToolStripMenuItem1";
			this.テストToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
			this.テストToolStripMenuItem1.Text = "テスト";
			this.テストToolStripMenuItem1.Click += new System.EventHandler(this.テストToolStripMenuItem1_Click);
			// 
			// mainTimer
			// 
			this.mainTimer.Enabled = true;
			this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
			// 
			// mainPanel
			// 
			this.mainPanel.AutoScroll = true;
			this.mainPanel.Controls.Add(this.lblMessage);
			this.mainPanel.Controls.Add(this.pbScreen);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Location = new System.Drawing.Point(0, 24);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(484, 415);
			this.mainPanel.TabIndex = 1;
			this.mainPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.mainPanel_Scroll);
			this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
			// 
			// lblMessage
			// 
			this.lblMessage.AutoSize = true;
			this.lblMessage.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lblMessage.Location = new System.Drawing.Point(12, 117);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new System.Drawing.Size(144, 29);
			this.lblMessage.TabIndex = 0;
			this.lblMessage.Text = "unconnected";
			// 
			// pbScreen
			// 
			this.pbScreen.Location = new System.Drawing.Point(12, 3);
			this.pbScreen.Name = "pbScreen";
			this.pbScreen.Size = new System.Drawing.Size(111, 111);
			this.pbScreen.TabIndex = 0;
			this.pbScreen.TabStop = false;
			this.pbScreen.Click += new System.EventHandler(this.pbScreen_Click);
			// 
			// MainWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 461);
			this.Controls.Add(this.mainPanel);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "MainWin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "UnrealRemoco / Client";
			this.Activated += new System.EventHandler(this.MainWin_Activated);
			this.Deactivate += new System.EventHandler(this.MainWin_Deactivate);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWin_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWin_FormClosed);
			this.Load += new System.EventHandler(this.MainWin_Load);
			this.Shown += new System.EventHandler(this.MainWin_Shown);
			this.ResizeBegin += new System.EventHandler(this.MainWin_ResizeBegin);
			this.ResizeEnd += new System.EventHandler(this.MainWin_ResizeEnd);
			this.SizeChanged += new System.EventHandler(this.MainWin_SizeChanged);
			this.Move += new System.EventHandler(this.MainWin_Move);
			this.Resize += new System.EventHandler(this.MainWin_Resize);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.mainPanel.ResumeLayout(false);
			this.mainPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbScreen)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem アプリAToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 終了XToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel lblStatus;
		private System.Windows.Forms.Timer mainTimer;
		private System.Windows.Forms.ToolStripMenuItem 接続CToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 接続CToolStripMenuItemSub;
		private System.Windows.Forms.ToolStripMenuItem 再接続RToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 切断DToolStripMenuItem;
		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.ToolStripMenuItem モニタ選択MToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem miSelectMonitor01;
		private System.Windows.Forms.ToolStripMenuItem miSelectMonitor02;
		private System.Windows.Forms.ToolStripMenuItem miSelectMonitor03;
		private System.Windows.Forms.ToolStripMenuItem miSelectMonitor04;
		private System.Windows.Forms.ToolStripMenuItem miSelectMonitor05;
		private System.Windows.Forms.ToolStripMenuItem miSelectMonitor06;
		private System.Windows.Forms.ToolStripMenuItem miSelectMonitor07;
		private System.Windows.Forms.ToolStripMenuItem miSelectMonitor08;
		private System.Windows.Forms.ToolStripMenuItem miSelectMonitor09;
		private System.Windows.Forms.ToolStripMenuItem miSelectMonitor10;
		private System.Windows.Forms.ToolStripMenuItem miSelectMonitor11;
		private System.Windows.Forms.ToolStripMenuItem miSelectMonitor12;
		private System.Windows.Forms.ToolStripMenuItem miSelectMonitor13;
		private System.Windows.Forms.ToolStripMenuItem miSelectMonitor14;
		private System.Windows.Forms.ToolStripMenuItem miSelectMonitor15;
		private System.Windows.Forms.ToolStripMenuItem miSelectMonitor16;
		private System.Windows.Forms.ToolStripMenuItem miSelectMonitor17;
		private System.Windows.Forms.ToolStripMenuItem miSelectMonitor18;
		private System.Windows.Forms.ToolStripMenuItem miSelectMonitor19;
		private System.Windows.Forms.ToolStripMenuItem miSelectMonitor20;
		private System.Windows.Forms.PictureBox pbScreen;
		private System.Windows.Forms.ToolStripMenuItem 設定SToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 画質QToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem テストToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem テストToolStripMenuItem1;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem その他の設定SToolStripMenuItem;
		private System.Windows.Forms.Label lblMessage;
		private System.Windows.Forms.ToolStripMenuItem クリップボードToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem クライアントからサーバーへToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem サーバーからクライアントへToolStripMenuItem;
	}
}

