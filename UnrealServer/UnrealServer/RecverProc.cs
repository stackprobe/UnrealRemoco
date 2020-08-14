using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Charlotte.Tools;
using System.Windows.Forms;

namespace Charlotte
{
	public class RecverProc : IDisposable
	{
		private Process _proc;

		public RecverProc(int portNo)
		{
			_proc = Utils.startConsole(Ground.i.getUnrealPlayerFile(), "RECVER " + portNo + " " + getArgCursorHandles());
		}

		private string getArgCursorHandles()
		{
			List<string> sHdls = new List<string>();

			foreach (Cursor cursor in Consts.mouseCursors)
				sHdls.Add("" + (uint)cursor.Handle);

			return string.Join(":", sHdls);
		}

		public void Dispose()
		{
			if (_proc != null)
			{
				using (NamedEventObject evStop = new NamedEventObject(Consts.EV_STOP_RECVER))
				{
					do
					{
						evStop.set();
					}
					while (_proc.WaitForExit(2000) == false);
				}
				_proc = null;
			}
		}
	}
}
