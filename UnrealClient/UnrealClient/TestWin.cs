using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Charlotte.Tools;

namespace Charlotte
{
	public partial class TestWin : Form
	{
		public TestWin()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				Gnd.ServerInfo si = new Gnd.ServerInfo();
				string[] lines = FieldsSerializer.serialize(si);
				FieldsSerializer.deserialize(si, lines);
			}
			catch (Exception ex)
			{
				FailedOperation.caught(ex);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				Gnd.ServerInfo si = new Gnd.ServerInfo();

				si.key = new Gnd.KeyData();

				string[] lines = FieldsSerializer.serialize(si);
				FieldsSerializer.deserialize(si, lines);
			}
			catch (Exception ex)
			{
				FailedOperation.caught(ex);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			new TestFortewaveWin().Show();
		}
	}
}
