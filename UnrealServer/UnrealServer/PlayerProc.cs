using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Charlotte.Tools;

namespace Charlotte
{
	public class PlayerProc : IDisposable
	{
		private Process _proc;

		public PlayerProc()
		{
			_proc = Utils.startConsole(Ground.i.getUnrealPlayerFile(), "PLAYER");
		}

		public void Dispose()
		{
			if (_proc != null)
			{
				using (NamedEventObject evStop = new NamedEventObject(Consts.EV_STOP_PLAYER))
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
