namespace Charlotte
{
	partial class QualityDlg
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QualityDlg));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.pbSample = new System.Windows.Forms.PictureBox();
			this.barQuality = new System.Windows.Forms.TrackBar();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.lblQuality = new System.Windows.Forms.Label();
			this.btnDefault = new System.Windows.Forms.Button();
			this.mainTimer = new System.Windows.Forms.Timer(this.components);
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbSample)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barQuality)).BeginInit();
			this.SuspendLayout();
			//
			// groupBox1
			//
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.pbSample);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(712, 432);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "サンプル";
			//
			// pbSample
			//
			this.pbSample.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pbSample.Location = new System.Drawing.Point(6, 26);
			this.pbSample.Name = "pbSample";
			this.pbSample.Size = new System.Drawing.Size(700, 400);
			this.pbSample.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pbSample.TabIndex = 0;
			this.pbSample.TabStop = false;
			//
			// barQuality
			//
			this.barQuality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
			this.barQuality.Location = new System.Drawing.Point(12, 450);
			this.barQuality.Maximum = 101;
			this.barQuality.Name = "barQuality";
			this.barQuality.Size = new System.Drawing.Size(712, 45);
			this.barQuality.TabIndex = 1;
			this.barQuality.ValueChanged += new System.EventHandler(this.barQuality_ValueChanged);
			//
			// btnCancel
			//
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(608, 501);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(116, 48);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "キャンセル";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			//
			// btnOk
			//
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(486, 501);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(116, 48);
			this.btnOk.TabIndex = 4;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			//
			// lblQuality
			//
			this.lblQuality.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblQuality.AutoSize = true;
			this.lblQuality.Location = new System.Drawing.Point(134, 515);
			this.lblQuality.Name = "lblQuality";
			this.lblQuality.Size = new System.Drawing.Size(77, 20);
			this.lblQuality.TabIndex = 3;
			this.lblQuality.Text = "画質 = 101";
			//
			// btnDefault
			//
			this.btnDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDefault.Location = new System.Drawing.Point(12, 501);
			this.btnDefault.Name = "btnDefault";
			this.btnDefault.Size = new System.Drawing.Size(116, 48);
			this.btnDefault.TabIndex = 2;
			this.btnDefault.Text = "デフォルト";
			this.btnDefault.UseVisualStyleBackColor = true;
			this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
			//
			// mainTimer
			//
			this.mainTimer.Enabled = true;
			this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
			//
			// QualityDlg
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(736, 561);
			this.Controls.Add(this.btnDefault);
			this.Controls.Add(this.lblQuality);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.barQuality);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "QualityDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "UnrealRemoco / Client / 画質";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QualityDlg_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.QualityDlg_FormClosed);
			this.Load += new System.EventHandler(this.QualityDlg_Load);
			this.Shown += new System.EventHandler(this.QualityDlg_Shown);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbSample)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barQuality)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.PictureBox pbSample;
		private System.Windows.Forms.TrackBar barQuality;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label lblQuality;
		private System.Windows.Forms.Button btnDefault;
		private System.Windows.Forms.Timer mainTimer;
	}
}
