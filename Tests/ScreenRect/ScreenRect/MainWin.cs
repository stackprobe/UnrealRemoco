using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenRect
{
	public partial class MainWin : Form
	{
		public MainWin()
		{
			InitializeComponent();
		}

		private void MainWin_Load(object sender, EventArgs e)
		{
			string imgFile = @"C:\var\壁紙\yande.re_268445~1000.png";

			this.pbScreen.Image = new Bitmap(imgFile);

			this.pbScreen.Left = 0;
			this.pbScreen.Top = 0;
			this.pbScreen.Width = this.pbScreen.Image.Width;
			this.pbScreen.Height = this.pbScreen.Image.Height;
		}

		private void mainTimer_Tick(object sender, EventArgs e)
		{
			int mouseL;
			int mouseT;

			{
				int l = this.pbScreen.Left;
				int t = this.pbScreen.Top;

				mouseL = l;
				mouseT = t;
			}

			int screenL;
			int screenT;
			int screenR;
			int screenB;

			{
				int l = this.mainPanel.Left;
				int t = this.mainPanel.Top;

				{
					Point pt = this.PointToScreen(new Point(l, t));

					l = pt.X;
					t = pt.Y;
				}

				int w = this.mainPanel.ClientSize.Width;
				int h = this.mainPanel.ClientSize.Height;
				int r = l + w;
				int b = t + h;

				screenL = l;
				screenT = t;
				screenR = r;
				screenB = b;
			}

			this.lblStatus.Text =
				mouseL + ", " +
				mouseT + ", " +
				screenL + ", " +
				screenT + ", " +
				screenR + ", " +
				screenB;
		}

		private void MainWin_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.mainTimer.Enabled = false;
		}

		private void MainWin_Shown(object sender, EventArgs e)
		{
			this.mainTimer.Enabled = true;
		}

		private void MainWin_Activated(object sender, EventArgs e)
		{
			this.lblStatus.Text = "Activated";
		}

		private void MainWin_Deactivate(object sender, EventArgs e)
		{
			this.lblStatus.Text = "Deactivated";
		}

		private void MainWin_Move(object sender, EventArgs e)
		{
			this.lblStatus.Text = "Move";
		}

		private void MainWin_ResizeEnd(object sender, EventArgs e)
		{
			this.lblStatus.Text = "ResizeEnd";
		}
	}
}
