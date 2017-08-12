using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Charlotte.Tools;

namespace Charlotte
{
	public class RecorderProc : IDisposable
	{
		private Process _proc;

		public RecorderProc()
		{
			_proc = Utils.startConsole(Gnd.i.getUnrealPlayerFile(), "RECORDER");
		}

		public bool hasAccident()
		{
			return _proc.HasExited;
		}

		public void Dispose()
		{
			if (_proc != null)
			{
				using (NamedEventObject evStop = new NamedEventObject(Consts.EV_STOP_RECORDER))
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
