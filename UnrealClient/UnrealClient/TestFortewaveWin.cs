using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Charlotte.Tools;
using System.Threading;

namespace Charlotte
{
	public partial class TestFortewaveWin : Form
	{
		// 通信相手 = <Project-Root>\Tests\Fortewave\EchoServer.c

		public TestFortewaveWin()
		{
			InitializeComponent();
		}

		private Fortewave _ftwv;
		private bool _death;
		private Thread _th;

		private void TestFortewaveWin_Load(object sender, EventArgs e)
		{
			_ftwv = new Fortewave("UNREAL-TEST-CS-R", "UNREAL-TEST-CS-S"); // 引数の並びが、Recver -> Sender になってるよ！

			_th = new Thread((ThreadStart)delegate
			{
				while (_death == false)
				{
					object recvObj = _ftwv.recv(2000);

					if (recvObj != null)
					{
						string message = StringTools.ENCODING_SJIS.GetString((byte[])recvObj);

						this.BeginInvoke((MethodInvoker)delegate
						{
							textBox2.Text += "\r\n" + message;
							textBox2.SelectionStart = textBox2.TextLength;
							textBox2.ScrollToCaret();
						});
					}
				}
			});
			_th.Start();
		}

		private void TestFortewaveWin_FormClosed(object sender, FormClosedEventArgs e)
		{
			_death = true;

			_th.Join();
			_th = null;

			_ftwv.Dispose();
			_ftwv = null;
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			// noop
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)10) // ctrl_enter
			{
				string message = textBox1.Text;
				textBox1.Text = "";
				message = message.Replace("\r", "");
				string[] lines = message.Split('\n');

				new Thread((ThreadStart)delegate
				{
					this.BeginInvoke((MethodInvoker)delegate
					{
						label1.Text = "Sending...";
					});

					foreach (string line in lines)
						_ftwv.send(StringTools.ENCODING_SJIS.GetBytes(line));

					this.BeginInvoke((MethodInvoker)delegate
					{
						label1.Text = "Sent!";
					});
				})
				.Start();

				e.Handled = true;
			}
		}
	}
}
