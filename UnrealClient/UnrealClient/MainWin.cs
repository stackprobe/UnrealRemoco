using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Charlotte.Tools;
using System.Runtime.InteropServices;

namespace Charlotte
{
	public partial class MainWin : Form
	{
		public MainWin()
		{
			InitializeComponent();

			this.MinimumSize = new Size(400, 300);
			this.lblStatus.Text = "";

			Utils.enableDoubleBuffer(this.pbScreen);

			//this.lblMessage.Text = "unconnected";

#if !DEBUG
			this.テストToolStripMenuItem.Visible = false;
#endif
		}

		private void MainWin_Load(object sender, EventArgs e)
		{
			// noop
		}

		//private string _test_imgFile = @"C:\var\デスクトップのスクリーンショット.png";

		private void MainWin_Shown(object sender, EventArgs e)
		{
			// test
			/*
			{
				Bitmap pic = new Bitmap(_test_imgFile);
				PictureBox pb = pbScreen;

				pb.Image = pic;
				pb.Left = 0;
				pb.Top = 0;
				pb.Width = pic.Width;
				pb.Height = pic.Height;

				this.mainPanel.Controls.Add(pb);
			}
			*/

			if (Ground.i.mainWin_w == -1)
			{
				Ground.i.mainWin_l = Ground.i.monitorCenter.get(0).l + 50;
				Ground.i.mainWin_t = Ground.i.monitorCenter.get(0).t + 50;
				Ground.i.mainWin_w = Ground.i.monitorCenter.get(0).w - 100;
				Ground.i.mainWin_h = Ground.i.monitorCenter.get(0).h - 100;
			}
			loadLTWH();
			disconnected();
			this.mtEnabled = true;
		}

		private void loadLTWH()
		{
			if (Ground.i.mainWin_w == -1)
				return;

			this.Left = Ground.i.mainWin_l;
			this.Top = Ground.i.mainWin_t;
			this.Width = Ground.i.mainWin_w;
			this.Height = Ground.i.mainWin_h;
		}

		private void saveLTWH()
		{
			if (this.mtCount < 2) // ? まだ開いたばかり。
				return;

			if (this.WindowState != FormWindowState.Normal)
				return;

			Ground.i.mainWin_l = this.Left;
			Ground.i.mainWin_t = this.Top;
			Ground.i.mainWin_w = this.Width;
			Ground.i.mainWin_h = this.Height;
		}

		private void MainWin_FormClosing(object sender, FormClosingEventArgs e)
		{
			saveLTWH();
		}

		private void MainWin_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.mtEnabled = false;
			disconnect();
		}

		private void 終了XToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
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
				// test
				/*
				{
					if (mtCount % 5 == 0)
						pbScreen.Image = Bitmap.FromFile(_test_imgFile);
				}
				*/

				if (Ground.i.con != null)
				{
					Ground.i.con.eachTimerTick();

					// スクリーン更新
					{
						Image img = Ground.i.con.lastScreenImage;

						if (img != null)
						{
							if (pbScreen.Width != img.Width || pbScreen.Height != img.Height)
							{
								pbScreen.Width = img.Width;
								pbScreen.Height = img.Height;
							}
							pbScreen.Image = img;

							GC.Collect();
						}
					}

					// マウスカーソル変更
					{
						Cursor cursor = Ground.i.con.lastMouseCursor;

						if (cursor != null)
						{
							if (pbScreen.Cursor != cursor)
								pbScreen.Cursor = cursor;

							GC.Collect();
						}
					}

					if (isTimeToNotify())
					{
						bool activeFlag =
							Utils.IsProcActive.get() &&
							this.WindowState != FormWindowState.Minimized &&
							isMenuBarMenuDroppingDown() == false &&
							isWinMovingResizing() == false;

						int mouseL;
						int mouseT;

						{
							int l = this.pbScreen.Left;
							int t = this.pbScreen.Top;

							mouseL = -l;
							mouseT = -t;
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

							if (this.pbScreen.Image != null)
							{
								w = Math.Min(w, this.pbScreen.Image.Width);
								h = Math.Min(h, this.pbScreen.Image.Height);
							}
							int r = l + w;
							int b = t + h;

							screenL = l;
							screenT = t;
							screenR = r;
							screenB = b;
						}

						Ground.i.con.sendToSender(
							"ACTIVE",
							"" + (activeFlag ? 1 : 0)
							);

						Ground.i.con.sendToSender(
							"MOUSE-ACTIVE-OUT-OF-SCREEN",
							"" + (Ground.i.mouseActiveOutOfScreen ? 1 : 0)
							);

						Ground.i.con.sendToSender(
							"MOUSE-LT",
							"" + mouseL,
							"" + mouseT
							);

						Ground.i.con.sendToSender(
							"SCREEN-LTRB",
							"" + screenL,
							"" + screenT,
							"" + screenR,
							"" + screenB
							);

						Ground.i.con.sendToSender(
							"SEND-TO-SERVER",
							"#-MONITOR-INDEX " + Ground.i.con.monitorIndex
							);

						Ground.i.con.sendToSender(
							"SEND-TO-SERVER",
							"#-QUALITY " + Ground.i.quality
							);

						// ステータス表示の更新
						{
							string state =
								"Active: " +
								activeFlag + ", Mouse_LT: " +
								mouseL + ", " +
								mouseT + ", Screen_LTRB: " +
								screenL + ", " +
								screenT + ", " +
								screenR + ", " +
								screenB;

							if (this.lblStatus.Text != state)
								this.lblStatus.Text = state;
						}
					}

					if (Ground.i.con.hasAccident()) // 相手側からの切断など、disconnect するので最後に！
					{
						disconnect();
					}
				}

				eachTimerTick_winMocingResizing();
				eachTimerTick_winResized();

				if (mtCount % 200 == 0)
				{
					GC.Collect();
				}
			}
			finally
			{
				this.mtBusy = false;
				this.mtCount++;
			}
		}

		private int _notifyCount;
		private int _notifyPeriod = 1;
		private int _notifyDelay;

		private bool isTimeToNotify()
		{
			if (0 < _notifyDelay)
			{
				_notifyDelay--;
				return false;
			}
			_notifyCount++;
			_notifyCount %= _notifyPeriod;

			if (_notifyCount == 0)
			{
				if (_notifyPeriod < 50)
					_notifyPeriod++;

				return true;
			}
			return false;
		}

		private void doNotify()
		{
			_notifyPeriod = 1;
		}

		private void doNotifyDelay()
		{
			doNotify();
			_notifyDelay = 10;
		}

		private void mainPanel_Paint(object sender, PaintEventArgs e)
		{
			// noop
		}

		private void pbScreen_Click(object sender, EventArgs e)
		{
			// noop
		}

		private void 接続CToolStripMenuItemSub_Click(object sender, EventArgs e)
		{
			this.mtEnabled = false;
			disconnect(); // 同じところに繋ぐかもしれないので、new Connection() する前に disconnect() する必要がある！

			using (ConnectDlg f = new ConnectDlg())
			{
				f.ShowDialog();

				if (f.retCon != null)
				{
					connected(f.retCon);
				}
			}
			this.mtEnabled = true;
		}

		private void 再接続RToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.mtEnabled = false;

			if (Ground.i.con != null)
			{
				Ground.ServerInfo si = Ground.i.con.si;
				int monitorIndex = Ground.i.con.monitorIndex;

				disconnect(); // 同じところに繋ぐので、new Connection() する前に disconnect() する必要がある！
				connected(new Connection(si, monitorIndex));
			}
			this.mtEnabled = true;
		}

		private void 切断DToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.mtEnabled = false;
			disconnect();
			this.mtEnabled = true;
		}

		private void 画質QToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.mtEnabled = false;
			this.Visible = false;

			Bitmap imgSample = null;

			{
				MonitorCenter.Monitor m = Ground.i.monitorCenter.get(0);

				int l = m.l;
				int t = m.t;
				int w = m.w;
				int h = m.h;

				// QualityDlg.pbSample のサイズに合わせる。
				{
					w = Math.Min(w, 700);
					h = Math.Min(h, 400);
				}

				UnshownBusyDlg.perform(delegate
				{
					Thread.Sleep(500); // MainWin が完全に隠れるのを待つ。
					imgSample = CaptureScreen.getRectangle(l, t, w, h);
				});
			}

			this.Visible = true;

			using (QualityDlg f = new QualityDlg(imgSample))
			{
				f.ShowDialog();
			}
			this.mtEnabled = true;
		}

		// ---- winMovingResizing ----

		private int _winMovingResizingCount = 0;

		private bool isWinMovingResizing()
		{
			return 0 < _winMovingResizingCount;
		}

		private void eachTimerTick_winMocingResizing()
		{
			if (0 < _winMovingResizingCount)
			{
				_winMovingResizingCount--;
			}
		}

		private void winMovingResizing()
		{
			_winMovingResizingCount = 5;
		}

		// ---- winResized ----

		private bool _winResized = false;

		private void eachTimerTick_winResized()
		{
			if (_winResized)
			{
				_winResized = false;

				this.lblMessage.Left = (this.mainPanel.Width - this.lblMessage.Width) / 2;
				this.lblMessage.Top = (this.mainPanel.Height - this.lblMessage.Height) / 2;
			}
		}

		private void winResized()
		{
			_winResized = true;
		}

		// ----

		private void MainWin_Move(object sender, EventArgs e)
		{
			winMovingResizing();
			saveLTWH();
			doNotify();
		}

		private void MainWin_ResizeEnd(object sender, EventArgs e)
		{
			winMovingResizing();
			saveLTWH();
			winResized();
			doNotify();
		}

		private void MainWin_Resize(object sender, EventArgs e)
		{
			winMovingResizing();
			winResized();
			doNotify();
		}

		private void MainWin_ResizeBegin(object sender, EventArgs e)
		{
			winMovingResizing();
		}

		private void miSelectMonitor01_Click(object sender, EventArgs e)
		{
			selectMonitor(0);
		}

		private void miSelectMonitor02_Click(object sender, EventArgs e)
		{
			selectMonitor(1);
		}

		private void miSelectMonitor03_Click(object sender, EventArgs e)
		{
			selectMonitor(2);
		}

		private void miSelectMonitor04_Click(object sender, EventArgs e)
		{
			selectMonitor(3);
		}

		private void miSelectMonitor05_Click(object sender, EventArgs e)
		{
			selectMonitor(4);
		}

		private void miSelectMonitor06_Click(object sender, EventArgs e)
		{
			selectMonitor(5);
		}

		private void miSelectMonitor07_Click(object sender, EventArgs e)
		{
			selectMonitor(6);
		}

		private void miSelectMonitor08_Click(object sender, EventArgs e)
		{
			selectMonitor(7);
		}

		private void miSelectMonitor09_Click(object sender, EventArgs e)
		{
			selectMonitor(8);
		}

		private void miSelectMonitor10_Click(object sender, EventArgs e)
		{
			selectMonitor(9);
		}

		private void miSelectMonitor11_Click(object sender, EventArgs e)
		{
			selectMonitor(10);
		}

		private void miSelectMonitor12_Click(object sender, EventArgs e)
		{
			selectMonitor(11);
		}

		private void miSelectMonitor13_Click(object sender, EventArgs e)
		{
			selectMonitor(12);
		}

		private void miSelectMonitor14_Click(object sender, EventArgs e)
		{
			selectMonitor(13);
		}

		private void miSelectMonitor15_Click(object sender, EventArgs e)
		{
			selectMonitor(14);
		}

		private void miSelectMonitor16_Click(object sender, EventArgs e)
		{
			selectMonitor(15);
		}

		private void miSelectMonitor17_Click(object sender, EventArgs e)
		{
			selectMonitor(16);
		}

		private void miSelectMonitor18_Click(object sender, EventArgs e)
		{
			selectMonitor(17);
		}

		private void miSelectMonitor19_Click(object sender, EventArgs e)
		{
			selectMonitor(18);
		}

		private void miSelectMonitor20_Click(object sender, EventArgs e)
		{
			selectMonitor(19);
		}

		private void selectMonitor(int monitorIndex)
		{
			this.mtEnabled = false;

			if (Ground.i.con != null)
			{
				Ground.ServerInfo si = Ground.i.con.si;

				disconnect(); // 同じところに繋ぐので、new Connection() する前に disconnect() する必要がある！
				connected(new Connection(si, monitorIndex));
			}
			this.mtEnabled = true;
		}

		/// <summary>
		/// 切断する。
		/// </summary>
		private void disconnect()
		{
			if (Ground.i.con != null)
			{
				BusyDlg.perform(delegate
				{
					Ground.i.con.Dispose();
					Ground.i.con = null;
				},
				this
				);

				disconnected();
			}
		}

		/// <summary>
		/// 切断した後のリアクション
		/// 切断状態に入ってからすべきこと。
		/// </summary>
		private void disconnected()
		{
			this.pbScreen.Image = null;
			this.pbScreen.Cursor = Cursors.Default;
			this.pbScreen.Visible = false;

			this.mainPanel.BackColor = new Panel().BackColor;

			this.lblMessage.Visible = true;

			winResized();

			refreshUI_miSelectMonitors(-1);
		}

		/// <summary>
		/// 接続した後のリアクション
		/// 接続状態に入ってからすべきこと。
		/// </summary>
		/// <param name="con">接続オブジェクト</param>
		private void connected(Connection con)
		{
			disconnect();

			Ground.i.con = con;

			this.pbScreen.Left = 0;
			this.pbScreen.Top = 0;
			this.pbScreen.Width = 800;
			this.pbScreen.Height = 600;
			this.pbScreen.Visible = true;

			this.mainPanel.BackColor = Color.Teal;

			this.lblMessage.Visible = false;

			doNotify();

			refreshUI_miSelectMonitors(con.monitorIndex);
		}

		private void refreshUI_miSelectMonitors(int monitorIndex)
		{
			ToolStripMenuItem[] miSelectMonitors = getMISelectMonitors();

			for (int index = 0; index < miSelectMonitors.Length; index++)
			{
				miSelectMonitors[index].Checked = index == monitorIndex;
			}
		}

		private ToolStripMenuItem[] getMISelectMonitors()
		{
			return new ToolStripMenuItem[]
			{
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
				this.miSelectMonitor20,
			};
		}

		private void テストToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			new TestWin().Show();
		}

		private void その他の設定SToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.mtEnabled = false;
			disconnect();
			this.Visible = false;

			using (SettingDlg f = new SettingDlg())
			{
				f.ShowDialog();
			}
			this.Visible = true;
			this.mtEnabled = true;
		}

		private void MainWin_Activated(object sender, EventArgs e)
		{
			doNotify();
		}

		private void MainWin_Deactivate(object sender, EventArgs e)
		{
			doNotify();
		}

		// 最小化・元に戻すを検出
		private void MainWin_SizeChanged(object sender, EventArgs e)
		{
			doNotify();
		}

		private void mainPanel_Scroll(object sender, ScrollEventArgs e)
		{
			doNotify();
		}

		// ----

		//
		// 画面上部のメニューが増えたら追加する。
		//

		private bool isMenuBarMenuDroppingDown()
		{
			return
				droppingDownアプリA ||
				droppingDown接続C ||
				droppingDown設定S;
			// ここへ追加..
		}

		public bool droppingDownアプリA = false;
		public bool droppingDown接続C = false;
		public bool droppingDown設定S = false;
		// ここへ追加..

		private void アプリAToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
		{
			droppingDownアプリA = true;
			doNotify();
		}

		private void アプリAToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
		{
			droppingDownアプリA = false;
			doNotifyDelay();
		}

		private void 接続CToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
		{
			droppingDown接続C = true;
			doNotify();
		}

		private void 接続CToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
		{
			droppingDown接続C = false;
			doNotifyDelay();
		}

		private void 設定SToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
		{
			droppingDown設定S = true;
			doNotify();
		}

		private void 設定SToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
		{
			droppingDown設定S = false;
			doNotifyDelay();
		}

		// ここへ追加..

		// ----
	}
}
