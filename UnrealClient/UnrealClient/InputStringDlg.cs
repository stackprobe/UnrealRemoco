using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Charlotte
{
	public partial class InputStringDlg : Form
	{
		public InputStringDlg(string prompt, string value, int lenmax = 1000)
		{
			InitializeComponent();

			this.lblPrompt.Text = prompt;
			this.txtInput.Text = value;
			this.txtInput.MaxLength = lenmax;
		}

		private void InputStringDlg_Load(object sender, EventArgs e)
		{
			// noop
		}

		private void InputStringDlg_Shown(object sender, EventArgs e)
		{
			// noop
		}

		private void InputStringDlg_FormClosing(object sender, FormClosingEventArgs e)
		{
			// noop
		}

		private void InputStringDlg_FormClosed(object sender, FormClosedEventArgs e)
		{
			// noop
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		public bool okPressed = false;
		public string retValue;

		private void btnOk_Click(object sender, EventArgs e)
		{
			this.okPressed = true;
			this.retValue = this.txtInput.Text;
			this.Close();
		}

		public static bool perform(string prompt, ref string value, int lenmax = 1000)
		{
			using (InputStringDlg f = new InputStringDlg(prompt, value, lenmax))
			{
				f.ShowDialog();

				if (f.okPressed)
				{
					value = f.retValue;
					return true;
				}
			}
			return false;
		}
	}
}
