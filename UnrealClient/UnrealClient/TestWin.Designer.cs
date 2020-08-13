namespace Charlotte
{
	partial class TestWin
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
			this.btnTestFieldsSerializer = new System.Windows.Forms.Button();
			this.btnTestFieldsSerializer_02 = new System.Windows.Forms.Button();
			this.btnTestFortewave = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnTestFieldsSerializer
			// 
			this.btnTestFieldsSerializer.Location = new System.Drawing.Point(12, 12);
			this.btnTestFieldsSerializer.Name = "btnTestFieldsSerializer";
			this.btnTestFieldsSerializer.Size = new System.Drawing.Size(201, 49);
			this.btnTestFieldsSerializer.TabIndex = 0;
			this.btnTestFieldsSerializer.Text = "FieldsSerializer";
			this.btnTestFieldsSerializer.UseVisualStyleBackColor = true;
			this.btnTestFieldsSerializer.Click += new System.EventHandler(this.btnTestFieldsSerializer_Click);
			// 
			// btnTestFieldsSerializer_02
			// 
			this.btnTestFieldsSerializer_02.Location = new System.Drawing.Point(12, 67);
			this.btnTestFieldsSerializer_02.Name = "btnTestFieldsSerializer_02";
			this.btnTestFieldsSerializer_02.Size = new System.Drawing.Size(201, 49);
			this.btnTestFieldsSerializer_02.TabIndex = 1;
			this.btnTestFieldsSerializer_02.Text = "FieldsSerializer_02";
			this.btnTestFieldsSerializer_02.UseVisualStyleBackColor = true;
			this.btnTestFieldsSerializer_02.Click += new System.EventHandler(this.btnTestFieldsSerializer_02_Click);
			// 
			// btnTestFortewave
			// 
			this.btnTestFortewave.Location = new System.Drawing.Point(12, 122);
			this.btnTestFortewave.Name = "btnTestFortewave";
			this.btnTestFortewave.Size = new System.Drawing.Size(201, 49);
			this.btnTestFortewave.TabIndex = 2;
			this.btnTestFortewave.Text = "Fortewave";
			this.btnTestFortewave.UseVisualStyleBackColor = true;
			this.btnTestFortewave.Click += new System.EventHandler(this.btnTestFortewave_Click);
			// 
			// TestWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(401, 486);
			this.Controls.Add(this.btnTestFortewave);
			this.Controls.Add(this.btnTestFieldsSerializer_02);
			this.Controls.Add(this.btnTestFieldsSerializer);
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "TestWin";
			this.Text = "TestWin";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnTestFieldsSerializer;
		private System.Windows.Forms.Button btnTestFieldsSerializer_02;
		private System.Windows.Forms.Button btnTestFortewave;
	}
}
