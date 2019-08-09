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

		public const string FRTWV_SERVER_TO_RECVER = "UnrealRemoco_{ffba9efd-177c-4a67-b43a-cb5d2c55fe29}"; // shared_uuid
		public const string FRTWV_RECVER_TO_SERVER = "UnrealRemoco_{e5dcdc68-37a7-4c21-9a62-414dc939e423}"; // shared_uuid

		public const string EV_STOP_RECVER = "{5f980732-fe1e-42f9-91cd-4ed63322cea8}"; // shared_uuid
		public const string EV_STOP_PLAYER = "{eaaeec02-3417-4b28-bd8e-a58a5f31db5d}"; // shared_uuid

		/// <summary>
		/// UnrealClient.sln の Consts.cs と対応する。
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
	}
}
