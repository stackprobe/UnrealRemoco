using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Charlotte.Tools;
using System.Drawing.Imaging;
using System.IO;

namespace Charlotte
{
	public partial class QualityDlg : Form
	{
		private Bitmap _imgSample;

		public QualityDlg(Bitmap imgSample)
		{
			_imgSample = imgSample;

			InitializeComponent();

			// load
			{
				this.barQuality.Value = Gnd.i.quality;
			}
		}

		private void QualityDlg_Load(object sender, EventArgs e)
		{
			// noop
		}

		private void QualityDlg_Shown(object sender, EventArgs e)
		{
			refreshUI();
			this.mtEnabled = true;
		}

		private void QualityDlg_FormClosing(object sender, FormClosingEventArgs e)
		{
			// noop
		}

		private void QualityDlg_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.mtEnabled = false;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			// save
			{
				Gnd.i.quality = this.barQuality.Value;
			}
			this.Close();
		}

		private bool refreshUI_req = false;

		private void refreshUI()
		{
			refreshUI_req = true;
		}

		private int _lastQuality = -1;

		private void refreshUI_main()
		{
			int quality = this.barQuality.Value;

			if (quality == _lastQuality)
				return;

			if (quality <= 100)
			{
				using (WorkingDir wd = new WorkingDir())
				{
					string imgFile = wd.makePath() + ".jpg";

					{
						EncoderParameters eps = new EncoderParameters(1);
						eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)quality);
						_imgSample.Save(imgFile, Utils.getImageCodecInfo(ImageFormat.Jpeg), eps);
					}

					this.pbSample.Image = Bitmap.FromStream(new MemoryStream(File.ReadAllBytes(imgFile)));
				}
			}
			else
			{
				this.pbSample.Image = _imgSample;
			}
			this.lblQuality.Text = "画質 = " + quality;

			_lastQuality = quality;

			GC.Collect();
		}

		private void barQuality_ValueChanged(object sender, EventArgs e)
		{
			refreshUI();
		}

		private void btnDefault_Click(object sender, EventArgs e)
		{
			this.barQuality.Value = 70;
		}

		private bool mtEnabled;
		private bool mtBusy;
		private long mtCount;

		private void mainTimer_Tick(object sender, EventArgs e)
		{
			if (this.mtEnabled == false || this.mtBusy)
				return;

			this.mtBusy = true;

			try
			{
				if (refreshUI_req)
				{
					refreshUI_req = false;
					refreshUI_main();
				}
			}
			finally
			{
				this.mtBusy = false;
				this.mtCount++;
			}
		}
	}
}
