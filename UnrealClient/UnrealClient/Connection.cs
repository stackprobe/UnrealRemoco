using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Charlotte
{
	public class Connection : IDisposable
	{
		public Ground.ServerInfo si;
		public int monitorIndex;

		/// <summary>
		/// 接続に失敗したら例外を投げる。
		/// -- 今のところ例外を投げるケース無し。問題があれば、接続後すぐに切断する。@ 2017.5.2
		/// </summary>
		/// <param name="si"></param>
		/// <param name="monitorIndex"></param>
		public Connection(Ground.ServerInfo si, int monitorIndex)
		{
			this.si = si;
			this.monitorIndex = monitorIndex;

			connect();
		}

		private SenderProc _senderProc;
		private RecorderProc _recorderProc;
		private CrypTunnelProc _crypTunnelProc = null; // null == 暗号化しない。
		private Fortewave _frtwv;

		private void connect()
		{
			if (si.cipherMode == Consts.CipherMode_e.NOT_ENCRYPT)
			{
				_senderProc = new SenderProc(si.host, si.portNo);
				_recorderProc = new RecorderProc();
			}
			else
			{
				_senderProc = new SenderProc("localhost", Ground.i.relayPortNo);
				_recorderProc = new RecorderProc();
				_crypTunnelProc = new CrypTunnelProc(Ground.i.relayPortNo, si.host, si.portNo, si.key, si.passphrase + Ground.i.passphraseSuffix);
			}
			_frtwv = new Fortewave(Consts.FRTWV_SENDER_TO_CLIENT, Consts.FRTWV_CLIENT_TO_SENDER);
			_frtwv.clear();
		}

		public Image lastScreenImage = null;
		public Cursor lastMouseCursor = null;

		public void eachTimerTick()
		{
			lastScreenImage = null;
			lastMouseCursor = null;

			for (; ; )
			{
				object recvObj = _frtwv.recv(0);

				if (recvObj == null)
					break;

				ObjectList ol = (ObjectList)recvObj;
				byte[] recvData = (byte[])ol[0];
				int c = 0;

				try
				{
					switch ((char)recvData[c++])
					{
						case 'I': // screen Image
							{
								Image img = Bitmap.FromStream(new MemoryStream(recvData, c, recvData.Length - c));

								if (img.Width < Ground.i.screen_w_min)
									throw new Exception("スクリーンの幅が小さすぎます。");

								if (img.Height < Ground.i.screen_h_min)
									throw new Exception("スクリーンの高さが小さすぎます。");

								if (Ground.i.screen_w_max < img.Width)
									throw new Exception("スクリーンの幅が大き過ぎます。");

								if (Ground.i.screen_h_max < img.Height)
									throw new Exception("スクリーンの高さが大き過ぎます。");

								lastScreenImage = img;
							}
							break;

						case 'C': // mouse Cursor kind
							{
								Cursor mouseCursor = Consts.mouseCursors[recvData[c++]];
								lastMouseCursor = mouseCursor;
							}
							break;

						default:
							throw null;
					}
				}
				catch (Exception e)
				{
					Utils.WriteLog("受信データが壊れています：" + e);
				}
				GC.Collect();
			}
		}

		public void sendToSender(params string[] lines)
		{
			_frtwv.send(Utils.toOL(lines));
		}

		public bool hasAccident()
		{
			return
				_senderProc.hasAccident() ||
				_recorderProc.hasAccident() ||
				(_crypTunnelProc != null && _crypTunnelProc.hasAccident());
		}

		public void Dispose()
		{
			if (_senderProc != null)
			{
				_senderProc.Dispose();
				_senderProc = null;

				_recorderProc.Dispose();
				_recorderProc = null;

				if (_crypTunnelProc != null)
				{
					_crypTunnelProc.Dispose();
					_crypTunnelProc = null;
				}
				_frtwv.Dispose();
				_frtwv = null;
			}
		}
	}
}
