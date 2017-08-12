using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace Charlotte
{
	public class CaptureScreen
	{
		private const int SRCCOPY = 13369376;
		private const int CAPTUREBLT = 1073741824;

		[DllImport("user32.dll")]
		private static extern IntPtr GetDC(IntPtr hwnd);

		[DllImport("gdi32.dll")]
		private static extern int BitBlt(
			IntPtr hDestDC,
			int x,
			int y,
			int nWidth,
			int nHeight,
			IntPtr hSrcDC,
			int xSrc,
			int ySrc,
			int dwRop
			);

		[DllImport("user32.dll")]
		private static extern IntPtr ReleaseDC(IntPtr hwnd, IntPtr hdc);

		/// <summary>
		/// プライマリスクリーンの画像を取得する
		/// </summary>
		/// <returns>プライマリスクリーンの画像</returns>
		public static Bitmap getRectangle(int l, int t, int w, int h)
		{
			//プライマリモニタのデバイスコンテキストを取得
			IntPtr disDC = GetDC(IntPtr.Zero);
			//Bitmapの作成
			Bitmap bmp = new Bitmap(w, h);
			//Graphicsの作成
			Graphics g = Graphics.FromImage(bmp);
			//Graphicsのデバイスコンテキストを取得
			IntPtr hDC = g.GetHdc();
			//Bitmapに画像をコピーする
			BitBlt(hDC, l, t, w, h, disDC, 0, 0, SRCCOPY);
			//解放
			g.ReleaseHdc(hDC);
			g.Dispose();
			ReleaseDC(IntPtr.Zero, disDC);
			return bmp;
		}
	}
}
