using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Charlotte
{
	public static class Consts
	{
		public const string PROJECT_GUI_IDENT = "{62ec54fe-ec8e-4379-a2e8-6b6ab7715066}"; // shared_uuid:2 // UnrealClient と UnrealServer

		public enum CipherMode_e
		{
			NOT_ENCRYPT,
			ENCRYPT_BY_KEY,
			ENCRYPT_BY_PASSPHRASE,
		};

		public static readonly string[] cipherModes = new string[]
		{
			"暗号化なし",
			"鍵を使って暗号化",
			"パスフレーズを使って暗号化（非推奨）",
		};

		public const string KEY_IDENT_PREFIX = "UnrealRemoco-Key_";

		public const string FRTWV_CLIENT_TO_SENDER = "UnrealRemoco_{19752573-d24a-49ca-bd89-9df8d5e796d8}"; // shared_uuid
		public const string FRTWV_SENDER_TO_CLIENT = "UnrealRemoco_{cf69f23f-3ead-4783-828e-aad810251eb2}"; // shared_uuid

		public const string EV_STOP_RECORDER = "{c0cdb1c2-1bf5-4afd-8088-08d52ca9f9c6}"; // shared_uuid
		public const string EV_STOP_SENDER = "{ff6be2c1-2003-4b00-8f8e-ef81cb3ae826}"; // shared_uuid

		/// <summary>
		/// UnrealServer.sln の Consts.cs と対応する。
		/// </summary>
		public static readonly Cursor[] mouseCursors = new Cursor[]
		{
			Cursors.AppStarting,
			Cursors.Arrow,
			Cursors.Cross,
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

		public const int CLIPBOARD_TEXT_LEN_MAX = 50000000 / 2; // 50 MB / 2
	}
}
