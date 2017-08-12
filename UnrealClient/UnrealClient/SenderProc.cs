using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Charlotte.Tools;

namespace Charlotte
{
	public class SenderProc : IDisposable
	{
		private Process _proc;

		public SenderProc(string serverHost, int serverPortNo)
		{
			_proc = Utils.startConsole(Gnd.i.getUnrealPlayerFile(), "SENDER " + serverHost + " " + serverPortNo);
		}

		public bool hasAccident()
		{
			return _proc.HasExited;
		}

		public void Dispose()
		{
			if (_proc != null)
			{
				using (NamedEventObject evStop = new NamedEventObject(Consts.EV_STOP_SENDER))
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
