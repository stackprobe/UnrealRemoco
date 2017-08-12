using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MouseCursorSet
{
	public partial class MainWin : Form
	{
		public MainWin()
		{
			InitializeComponent();
		}

		private Cursor[] cursors = new Cursor[]
		{
			Cursors.AppStarting,
			Cursors.Arrow,
			Cursors.Cross,
			Cursors.Default, // == Arrow ???
			Cursors.IBeam,
			Cursors.No,
			Cursors.SizeAll,
			Cursors.SizeNESW,
			Cursors.SizeNS,
			Cursors.SizeNWSE,
			Cursors.SizeWE,
			Cursors.UpArrow,
			Cursors.WaitCursor,
			Cursors.Help,
			Cursors.HSplit,
			Cursors.VSplit,
			Cursors.NoMove2D,
			Cursors.NoMoveHoriz,
			Cursors.NoMoveVert,
			Cursors.PanEast,
			Cursors.PanNE,
			Cursors.PanNorth,
			Cursors.PanNW,
			Cursors.PanSE,
			Cursors.PanSouth,
			Cursors.PanSW,
			Cursors.PanWest,
			Cursors.Hand,
		};

		private int cursorIndex = -1;

		private void button1_Click(object sender, EventArgs e)
		{
			cursorIndex++;
			cursorIndex %= cursors.Length;

			this.Cursor = cursors[cursorIndex];
			this.label1.Text = "" + cursorIndex;
		}

		private void MainWin_Load(object sender, EventArgs e)
		{
			List<string> lines = new List<string>();

			foreach (Cursor cursor in cursors)
			{
				lines.Add(cursor + " = " + cursor.Handle);
			}
			label2.Text = string.Join("\n", lines);
		}
	}
}
