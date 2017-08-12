#include "all.h"

// ---- 初期設定 ----

static uint KeyStrokeDelayMillis = 150;
static uint MouseClickDelayMillis = 150;
static uint MouseDoubleClickIntervalMillis = 200;
static uint SamplingIntervalMillis = 10;
static int IgnoreVk16To18 = 1;

// ---- 動的設定 ----

static int Active = 1;
static int MouseActiveOutOfScreen = 0; // ? マウスカーソルがスクリーン外に出たときもマウス操作を送信する。
static sint Mouse_L = 0;
static sint Mouse_T = 0;
static sint Screen_L = 0;
static sint Screen_T = 0;
static sint Screen_R = 800;
static sint Screen_B = 600;

// ----

static Frtwv_t *Sender;
static Frtwv_t *Recver;

static uint EvStop;

static int MouseHoldPos;
static int MouseOutOfScreen;
static sint Mouse_X;
static sint Mouse_Y;

typedef struct KeyInfo_st
{
	int State;
	int LastState;
	uint KeptMillis;
	uint Phase;
}
KeyInfo_t;

#define VK_MOUSE_L 1
#define VK_MOUSE_M 4
#define VK_MOUSE_R 2

static KeyInfo_t KeyInfos[0x100];
static KeyInfo_t MouseInfos[3]; // [左, 中, 右]

static void ProcState(KeyInfo_t *i)
{
	if(i->State ? i->LastState : !i->LastState) // ? 同じ。
	{
		i->KeptMillis += SamplingIntervalMillis;
	}
	else
	{
		i->KeptMillis = 0;
		i->LastState = i->State;
	}
}
static void DoSend(char *command, uint prm, int kbop)
{
	char *line = xcout("XYCP %d %d %s %u", Mouse_L + Mouse_X - Screen_L, Mouse_T + Mouse_Y - Screen_T, command, prm); // スクリーン範囲外の座標を送るかも！？

	cout("SEND: %s\n", line);

	if(Active && (kbop || MouseActiveOutOfScreen || !MouseOutOfScreen))
	{
		autoBlock_t *sendData = ab_makeBlockLine(line);

		Frtwv_Send(Sender, sendData);
		releaseAutoBlock(sendData);
	}
	else
		cout("Not active!\n");

	memFree(line);
}
static void DoSend_M(char *command, uint prm)
{
	DoSend(command, prm, 0);
}
static void DoSend_K(char *command, uint prm)
{
	DoSend(command, prm, 1);
}
static int IsOutOfScreen(uint mou_x, uint mou_y)
{
	return
		mou_x < Screen_L || Screen_R <= mou_x ||
		mou_y < Screen_T || Screen_B <= mou_y;
}
static int IsShiftVk(uint vk)
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
		if(shiftVks[index] == vk)
			return 1;

	return 0;
}
void RecorderMain(void)
{
	uint vk;
	uint vm;

	LOGPOS();

	// 設定ファイル読み込み
	{
		char *confFile = changeExt(getSelfFile(), "recorder.conf");

		if(existFile(confFile))
		{
			autoList_t *lines = readResourceLines(confFile);
			uint c = 0;

			// items >

			KeyStrokeDelayMillis           = toValue(refLine(lines, c++));
			MouseClickDelayMillis          = toValue(refLine(lines, c++));
			MouseDoubleClickIntervalMillis = toValue(refLine(lines, c++));
			SamplingIntervalMillis         = toValue(refLine(lines, c++));
			IgnoreVk16To18                 = toValue(refLine(lines, c++));

			// < items

			releaseDim(lines, 1);
		}
		memFree(confFile);
	}

	LOGPOS();

	m_range(KeyStrokeDelayMillis, 1, IMAX);
	m_range(MouseClickDelayMillis, 1, IMAX);
	m_range(MouseDoubleClickIntervalMillis, 1, IMAX);
	m_range(SamplingIntervalMillis, 1, IMAX);
	// IgnoreVk16To18

	cout("KeyStrokeDelayMillis: %u\n", KeyStrokeDelayMillis);
	cout("MouseClickDelayMillis: %u\n", MouseClickDelayMillis);
	cout("MouseDoubleClickIntervalMillis: %u\n", MouseDoubleClickIntervalMillis);
	cout("SamplingIntervalMillis: %u\n", SamplingIntervalMillis);
	cout("IgnoreVk16To18: %d\n", IgnoreVk16To18);

	Sender = Frtwv_Create(FRTWV_RECORDER_TO_SENDER);
	Recver = Frtwv_Create(FRTWV_SENDER_TO_RECORDER);

	LOGPOS();

	Frtwv_Clear(Sender);
	Frtwv_Clear(Recver);

	LOGPOS();

	EvStop = eventOpen(EV_STOP_RECORDER);

	LOGPOS();

	for(vk = 0; vk <= 0xff; vk++)
		GetAsyncKeyState(vk);

	LOGPOS();

	while(!handleWaitForMillis(EvStop, SamplingIntervalMillis))
	{
		// Recv
		{
			autoList_t *olRecv = (autoList_t *)Frtwv_RecvOL(Recver, 1, 0);

			if(olRecv)
			{
				autoList_t *lines = OLToLines(olRecv);
				char *command;
				uint c = 0;

				command = refLine(lines, c++);

				if(!strcmp(command, "ACTIVE"))
				{
					Active = atoi(refLine(lines, c++));
				}
				else if(!strcmp(command, "MOUSE-ACTIVE-OUT-OF-SCREEN"))
				{
					MouseActiveOutOfScreen = atoi(refLine(lines, c++));
				}
				else if(!strcmp(command, "MOUSE-LT"))
				{
					Mouse_L = atoi(refLine(lines, c++));
					Mouse_T = atoi(refLine(lines, c++));
				}
				else if(!strcmp(command, "SCREEN-LTRB"))
				{
					Screen_L = atoi(refLine(lines, c++));
					Screen_T = atoi(refLine(lines, c++));
					Screen_R = atoi(refLine(lines, c++));
					Screen_B = atoi(refLine(lines, c++));
				}
				else if(!strcmp(command, "MOUSE-POS"))
				{
					DoSend_M("NOOP", 0);
				}
				else
				{
					error();
				}
				releaseDim(lines, 1);
			}
		}

		if(!MouseHoldPos)
		{
			POINT pos;
			uint mou_x;
			uint mou_y;

			GetCursorPos(&pos);

			mou_x = pos.x;
			mou_y = pos.y;

			if(!IsOutOfScreen(mou_x, mou_y))
			{
				MouseOutOfScreen = 0;
				Mouse_X = mou_x;
				Mouse_Y = mou_y;
			}
			else
				MouseOutOfScreen = 1;
		}

		for(vk = 0; vk <= 0xff; vk++)
		{
			KeyInfos[vk].State = GetAsyncKeyState(vk) ? 1 : 0;
		}
		MouseInfos[0].State = KeyInfos[VK_MOUSE_L].State;
		MouseInfos[1].State = KeyInfos[VK_MOUSE_M].State;
		MouseInfos[2].State = KeyInfos[VK_MOUSE_R].State;

		KeyInfos[VK_MOUSE_L].State = 0;
		KeyInfos[VK_MOUSE_M].State = 0;
		KeyInfos[VK_MOUSE_R].State = 0;

		if(IgnoreVk16To18)
		{
			KeyInfos[16].State = 0; // Shift
			KeyInfos[17].State = 0; // Control
			KeyInfos[18].State = 0; // Alt
		}
		for(vk = 0; vk <= 0xff; vk++)
		{
			KeyInfo_t *i = KeyInfos + vk;

			ProcState(i);

			switch(i->Phase)
			{
			case 0: // 離している。
				if(i->State)
				{
					if(IsShiftVk(vk))
					{
						i->Phase = 2;
						DoSend_K("DOWN", vk);
					}
					else
					{
						i->Phase = 1;
					}
				}
				break;

			case 1: // 押している。ストローク又はホールド中
				if(!i->State)
				{
					i->Phase = 0;
					DoSend_K("STROKE", vk);
				}
				else if(KeyStrokeDelayMillis <= i->KeptMillis)
				{
					i->Phase = 2;
					DoSend_K("DOWN", vk);
				}
				break;

			case 2: // 押している。ホールド中
				if(!i->State)
				{
					i->Phase = 0;
					DoSend_K("UP", vk);
				}
				break;

			default:
				error();
			}
		}
		for(vm = 0; vm < 3; vm++)
		{
			KeyInfo_t *i = MouseInfos + vm;

			ProcState(i);

			switch(vm)
			{
			case 0: vk = VK_MOUSE_L; break;
			case 1: vk = VK_MOUSE_M; break;
			case 2: vk = VK_MOUSE_R; break;

			default:
				error();
			}
			switch(i->Phase)
			{
			case 0: // 離している。
				if(i->State)
				{
					i->Phase = 1;
					MouseHoldPos = 1;
				}
				break;

			case 1: // 押している。クリック、ダブルクリック又はドラッグ中
				if(!i->State)
				{
					i->Phase = 2;
				}
				else if(MouseClickDelayMillis <= i->KeptMillis)
				{
					i->Phase = 4;
					DoSend_M("DOWN", vk);
					MouseHoldPos = 0;
				}
				break;

			case 2: // クリック・インターバル
				if(i->State)
				{
					i->Phase = 3;
				}
				else if(MouseDoubleClickIntervalMillis <= i->KeptMillis)
				{
					i->Phase = 0;
					DoSend_M("CLICK", vk);
					MouseHoldPos = 0;
				}
				break;

			case 3: // 押してる。ダブルクリックの２回目
				if(!i->State)
				{
					i->Phase = 0;
					DoSend_M("DOUBLE-CLICK", vk);
					MouseHoldPos = 0;
				}
				else if(MouseClickDelayMillis <= i->KeptMillis)
				{
					i->Phase = 4;
					DoSend_M("CLICK", vk);
					DoSend_M("DOWN", vk);
					MouseHoldPos = 0;
				}
				break;

			case 4: // 押している。ドラッグ中
				if(!i->State)
				{
					i->Phase = 0;
					DoSend_M("UP", vk);
				}
				break;

			default:
				error();
			}
		}
	}

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
