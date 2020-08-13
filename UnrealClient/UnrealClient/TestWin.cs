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

		private void btnTestFieldsSerializer_Click(object sender, EventArgs e)
		{
			try
			{
				Ground.ServerInfo si = new Ground.ServerInfo();
				string[] lines = FieldsSerializer.serialize(si);
				FieldsSerializer.deserialize(si, lines);
			}
			catch (Exception ex)
			{
				FailedOperation.caught(ex);
			}
		}

		private void btnTestFieldsSerializer_02_Click(object sender, EventArgs e)
		{
			try
			{
				Ground.ServerInfo si = new Ground.ServerInfo();

				si.key = new Ground.KeyData();

				string[] lines = FieldsSerializer.serialize(si);
				FieldsSerializer.deserialize(si, lines);
			}
			catch (Exception ex)
			{
				FailedOperation.caught(ex);
			}
		}

		private void btnTestFortewave_Click(object sender, EventArgs e)
		{
			new TestFortewaveWin().Show();
		}
	}
}
