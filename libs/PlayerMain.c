#include "all.h"

// ---- 初期設定 ----

static uint KeyStrokeDelayMillis = 30;
static uint MouseClickDelayMillis = 30;
static uint MouseDoubleClickIntervalMillis = 30;
static uint MouseMovedAfterMillis = 5;
static uint KeyChangedAfterMillis = 5;

// ---- 動的設定 ----

static sint Mouse_L = 0;
static sint Mouse_T = 0;
static sint Mouse_R = 800;
static sint Mouse_B = 600;

// ----

static Frtwv_t *Sender;
static Frtwv_t *Recver;

static uint EvStop;

static sint LastMouse_X = IMAX;
static sint LastMouse_Y = IMAX;

#define VK_MOUSE_L 1
#define VK_MOUSE_M 4
#define VK_MOUSE_R 2

static void DoMouseCursor(sint x, sint y)
{
	INPUT i;

	zeroclear(i);

	i.type = INPUT_MOUSE;
	i.mi.dx = d2i(x * (65536.0 / GetSystemMetrics(SM_CXSCREEN)));
	i.mi.dy = d2i(y * (65536.0 / GetSystemMetrics(SM_CYSCREEN)));
	i.mi.dwFlags = MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE;
	i.mi.dwExtraInfo = GetMessageExtraInfo();

	SendInput(1, &i, sizeof(INPUT));
}
static void DoMouseButton(uint kind, int downFlag) // kind: 1-3 == { 左, 中, 右 }
{
	INPUT i;
	int flag;

	switch(kind)
	{
	case 1: flag = downFlag ? MOUSEEVENTF_LEFTDOWN   : MOUSEEVENTF_LEFTUP;   break;
	case 2: flag = downFlag ? MOUSEEVENTF_MIDDLEDOWN : MOUSEEVENTF_MIDDLEUP; break;
	case 3: flag = downFlag ? MOUSEEVENTF_RIGHTDOWN  : MOUSEEVENTF_RIGHTUP;  break;

	default:
		error();
	}

	zeroclear(i);

	i.type = INPUT_MOUSE;
	i.mi.dwFlags = flag;
	i.mi.dwExtraInfo = GetMessageExtraInfo();

	SendInput(1, &i, sizeof(INPUT));
}
static void DoKeyboard(uint16 vk, int downFlag)
{
	INPUT i;

	zeroclear(i);

	i.type = INPUT_KEYBOARD;
	i.ki.wVk = vk;
	i.ki.wScan = MapVirtualKey(vk, 0);
	i.ki.dwFlags = KEYEVENTF_EXTENDEDKEY | (downFlag ? 0 : KEYEVENTF_KEYUP); // KEYEVENTF_EXTENDEDKEY を指定しないとシフトが押せない？？？
	i.mi.dwExtraInfo = GetMessageExtraInfo();

	SendInput(1, &i, sizeof(INPUT));
}
static uint VKToMouse(uint vk)
{
	uint kind;

	switch(vk)
	{
	case VK_MOUSE_L: kind = 1; break;
	case VK_MOUSE_M: kind = 2; break;
	case VK_MOUSE_R: kind = 3; break;

	default:
		kind = 0;
	}
	return kind;
}
static void DoSubCommand_DownUp(uint vk, int downFlag)
{
	uint kind = VKToMouse(vk);

	if(kind)
		DoMouseButton(kind, downFlag);
	else
		DoKeyboard(vk, downFlag);

	sleep(KeyChangedAfterMillis);
}
void PlayerMain(void)
{
	LOGPOS();

	// 設定ファイル読み込み
	{
		char *confFile = changeExt(getSelfFile(), "conf");

		if(existFile(confFile))
		{
			autoList_t *lines = readResourceLines(confFile);
			uint c = 0;

			// items >

			KeyStrokeDelayMillis           = toValue(refLine(lines, c++));
			MouseClickDelayMillis          = toValue(refLine(lines, c++));
			MouseDoubleClickIntervalMillis = toValue(refLine(lines, c++));
			MouseMovedAfterMillis          = toValue(refLine(lines, c++));
			KeyChangedAfterMillis          = toValue(refLine(lines, c++));

			// < items

			releaseDim(lines, 1);
		}
		memFree(confFile);
	}

	LOGPOS();

	m_range(KeyStrokeDelayMillis, 1, IMAX);
	m_range(MouseClickDelayMillis, 1, IMAX);
	m_range(MouseDoubleClickIntervalMillis, 1, IMAX);
	m_range(MouseMovedAfterMillis, 1, IMAX);
	m_range(KeyChangedAfterMillis, 1, IMAX);

	cout("KeyStrokeDelayMillis: %u\n", KeyStrokeDelayMillis);
	cout("MouseClickDelayMillis: %u\n", MouseClickDelayMillis);
	cout("MouseDoubleClickIntervalMillis: %u\n", MouseDoubleClickIntervalMillis);
	cout("MouseMovedAfterMillis: %u\n", MouseMovedAfterMillis);
	cout("KeyChangedAfterMillis: %u\n", KeyChangedAfterMillis);

	Sender = Frtwv_Create(FRTWV_PLAYER_TO_RECVER);
	Recver = Frtwv_Create(FRTWV_RECVER_TO_PLAYER);

	LOGPOS();

	Frtwv_Clear(Sender);
	Frtwv_Clear(Recver);

	LOGPOS();

	EvStop = eventOpen(EV_STOP_PLAYER);

	LOGPOS();

	while(!handleWaitForMillis(EvStop, 0))
	{
		autoBlock_t *recvData = Frtwv_Recv(Recver, 2000);

		if(recvData)
		{
			char *recvLine = unbindBlock2Line(recvData);
			autoList_t *prms;
			uint c = 0;
			char *command;

			cout("recvLine: [%s]\n", recvLine); // Recver で正規化しているので、表示しても問題無い。

			prms = tokenize(recvLine, ' ');
			command = refLine(prms, c++);

			// コマンドの処理 >

			if(!strcmp(command, "XYCP"))
			{
				sint mus_x;
				sint mus_y;
				char *subCommand;
				uint subPrm;

				mus_x = atoi(refLine(prms, c++));
				mus_y = atoi(refLine(prms, c++));
				subCommand = refLine(prms, c++);
				subPrm = toValue(refLine(prms, c++));

				m_range(mus_x, Mouse_L, Mouse_R - 1);
				m_range(mus_y, Mouse_T, Mouse_B - 1);

				if(LastMouse_X != mus_x || LastMouse_Y != mus_y)
				{
					DoMouseCursor(mus_x, mus_y);

					sleep(MouseMovedAfterMillis);

					LastMouse_X = mus_x;
					LastMouse_Y = mus_y;
				}

				// サブ・コマンドの処理 >

				if(!strcmp(subCommand, "NOOP"))
				{
					// noop
				}
				else if(!strcmp(subCommand, "DOWN"))
				{
					DoSubCommand_DownUp(subPrm, 1);
				}
				else if(!strcmp(subCommand, "UP"))
				{
					DoSubCommand_DownUp(subPrm, 0);
				}
				else if(!strcmp(subCommand, "STROKE"))
				{
					uint vk = subPrm & 0xff;

					DoKeyboard(vk, 1);
					sleep(KeyStrokeDelayMillis);
					DoKeyboard(vk, 0);
					sleep(KeyChangedAfterMillis);
				}
				else if(!strcmp(subCommand, "CLICK"))
				{
					uint kind = VKToMouse(subPrm);

					if(kind)
					{
						DoMouseButton(kind, 1);
						sleep(MouseClickDelayMillis);
						DoMouseButton(kind, 0);
						sleep(KeyChangedAfterMillis);
					}
					else
					{
						cout("Warning: クリック, 不明なvk：%u\n", subPrm);
					}
				}
				else if(!strcmp(subCommand, "DOUBLE-CLICK"))
				{
					uint kind = VKToMouse(subPrm);

					if(kind)
					{
						DoMouseButton(kind, 1);
						sleep(MouseClickDelayMillis);
						DoMouseButton(kind, 0);
						sleep(MouseDoubleClickIntervalMillis);
						DoMouseButton(kind, 1);
						sleep(MouseClickDelayMillis);
						DoMouseButton(kind, 0);
						sleep(KeyChangedAfterMillis);
					}
					else
					{
						cout("Warning: ダブル・クリック, 不明なvk：%u\n", subPrm);
					}
				}
				else
				{
					cout("Warning: Unknown subCommand: %s\n", subCommand);
				}

				// < サブ・コマンドの処理
			}
			else if(!strcmp(command, "MOUSE_LTRB"))
			{
				Mouse_L = atoi(refLine(prms, c++));
				Mouse_T = atoi(refLine(prms, c++));
				Mouse_R = atoi(refLine(prms, c++));
				Mouse_B = atoi(refLine(prms, c++));

				m_range(Mouse_L, -IMAX, IMAX);
				m_range(Mouse_T, -IMAX, IMAX);
				m_range(Mouse_R, -IMAX, IMAX);
				m_range(Mouse_B, -IMAX, IMAX);
			}
			else if(!strcmp(command, "SHIFT-KEYS-UP"))
			{
				static uint shiftVks[] =
				{
					16,  // Shift
					160, // L Shift
					161, // R Shift
					17,  // Control
					162, // L Control
					163, // R Control
					18,  // Alt
					164, // L Alt
					165, // R Alt
					240, // CapsLock
					91,  // Windows
				};

				uint index;

				for(index = 0; index < lengthof(shiftVks); index++)
				{
					DoSubCommand_DownUp(shiftVks[index], 0);
				}
			}
			else
			{
				cout("Warning: Unknown command: %s\n", command);
			}

			// < コマンドの処理

			memFree(recvLine);
			releaseDim(prms, 1);
		}
	}

endLoop:
	LOGPOS();

	Frtwv_Clear(Sender);
	Frtwv_Clear(Recver);

	LOGPOS();

	Frtwv_Release(Sender);
	Frtwv_Release(Recver);

	LOGPOS();

	handleClose(EvStop);

	LOGPOS();
}
