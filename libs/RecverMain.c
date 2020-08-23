#include "all.h"

// ---- 初期設定 ----

static uint PortNo = 55900;
static uint CycleMillis = 100;
static uint SenderIdlingSentPeriod = 20;

// ----

static Frtwv_t *ServerSender;
static Frtwv_t *ServerRecver;
static Frtwv_t *PlayerSender;
static Frtwv_t *PlayerRecver;

static uint EvStop;

thread_tls uint ThId;
static uint ConnectionHolderThId;
static int Death;
static uint SendingIdlingSentCount; // cd

#define RECV_LINE_LENMAX   70000000 // 70 MB // 上りクリップボード・テキストのサイズの上限を 50 MB くらいとすると Base64 で 1.333... 倍になって -> 67 MB くらい -> なので 70 MB
#define SEND_DATA_SIZE_MAX 50000000 // 50 MB
#define SEND_BUFF_SIZE_MAX 100000000 // 100 MB

static void SendToServer(char *command)
{
	if(100 < Frtwv_GetJamDataCount(ServerSender))
	{
		cout("Warning: 送信バッファが溜まり過ぎている。(TO_SERVER)\n");
		return;
	}

	{
		autoList_t *lines = newList();
		autoList_t *ol;

		addElement(lines, (uint)strx(command));

		ol = LinesToOL(lines);
		Frtwv_SendOL(ServerSender, ol, 1);
		ReleaseOL(ol);
	}
}
static void SendToPlayer(char *command)
{
	if(100 < Frtwv_GetJamDataCount(PlayerSender))
	{
		cout("Warning: 送信バッファが溜まり過ぎている。(TO_PLAYER)\n");
		return;
	}

	{
		autoBlock_t gab;

		Frtwv_Send(PlayerSender, gndBlockLineVar(command, gab));
	}
}
static uint GetRecvLineEndPos(autoBlock_t *recvBuff)
{
	uint recvBuffSize = getSize(recvBuff);
	uint index;

	for(index = 0; index < recvBuffSize; index++)
		if(b_(recvBuff)[index] == '\0')
			break;

	return index;
}

static autoList_t *MusCursorHdls;

static int GetMouseCursorKind(void)
{
	CURSORINFO ci = { sizeof(CURSORINFO) };

	if(GetCursorInfo(&ci))
	{
		uint hCursor;
		uint index;

		foreach(MusCursorHdls, hCursor, index)
			if(hCursor == (uint)ci.hCursor)
				return index;
	}
	return 1; // arrow
}
static void PerformTh(int sock, char *strip)
{
	autoBlock_t *sendBuff = newBlock();
	autoBlock_t *recvBuff = newBlock();

	fixBytes(sendBuff);
	fixBytes(recvBuff);

	if(!NegotiationServer(sock, EvStop))
		goto endNegoFault;

	ThId = GetCurrentThreadId();
	ConnectionHolderThId = ThId;

	cout("ConnectionHolderThId: %u\n", ConnectionHolderThId);

	while(!Death && ConnectionHolderThId == ThId)
	{
		if(getSize(sendBuff)) // ? 送信データ有り
		{
			if(SockSendSequ(sock, sendBuff, CycleMillis) == -1)
			{
				cout("Warning: 送信エラー\n");
				break;
			}
			if(SockRecvSequ(sock, recvBuff, 0) == -1)
			{
				cout("Warning: 受信エラー_0\n");
				break;
			}
		}
		else // ? 送信データ無し
		{
			if(SockRecvSequ(sock, recvBuff, CycleMillis) == -1)
			{
				cout("Warning: 受信エラー_n0\n");
				break;
			}
		}

		for(; ; ) // 受信データ処理 from クライアント方面
		{
			uint endPos = GetRecvLineEndPos(recvBuff);
			char *recvLine;

			if(endPos == getSize(recvBuff)) // ? not found
			{
				if(RECV_LINE_LENMAX < getSize(recvBuff))
				{
					cout("Warning: recvLine が長過ぎます。(recvBuff サイズ超過)\n");
					goto endLoop;
				}
				break;
			}
			if(RECV_LINE_LENMAX < endPos)
			{
				cout("Warning: recvLine が長過ぎます。\n");
				goto endLoop;
			}
			recvLine = (char *)ab_makeBlock_x(desertBytes(recvBuff, 0, endPos + 1));

			// クライアント方面からの受信ラインの反応 ...

			Line2AsciiKana(recvLine);

			if(recvLine[0] == '#' && recvLine[1]) // ? starts with '#-'
			{
				SendToServer(recvLine + 2);
			}
			else
			{
				SendToPlayer(recvLine);
			}

			// ... 受信ライン反応ここまで

			memFree(recvLine);
		}

		for(; ; ) // 受信データ処理 from SERVER
		{
			autoList_t *ol = Frtwv_RecvOL(ServerRecver, 1, 0);
			char *command;
			uint c = 0;

			if(!ol)
				break;

			command = ab_toLine((autoBlock_t *)getElement(ol, c++)); // HACK: 要素が無ければ error();

			if(!strcmp(command, "SEND-TO-CLIENT")) // ? クライアント方面へ
			{
				autoBlock_t *imgData = (autoBlock_t *)getElement(ol, c++); // HACK: 要素が無ければ error();
				autoBlock_t *cbtxtData;

				cbtxtData = (autoBlock_t *)getElement(ol, c++); // HACK: 要素が無ければ error();

				if(SEND_DATA_SIZE_MAX < getSize(imgData))
				{
					cout("Warning: 画像データが大き過ぎます。\n");
				}
				else if(SEND_DATA_SIZE_MAX - getSize(imgData) < getSize(cbtxtData))
				{
					cout("Warning: 画像・テキストデータが大き過ぎます。\n");
				}
				else if(SEND_BUFF_SIZE_MAX < getSize(sendBuff) + 4 + getSize(imgData) + 4 + getSize(cbtxtData))
				{
					cout("Warning: 送信バッファが溜まり過ぎている。(SERVER to CLIENT)\n");
				}
				else
				{
					// クライアント方面へ送信 ...

					if(getSize(imgData)) // screen Image
					{
						ab_addValue(sendBuff, 1 + getSize(imgData));
						addByte(sendBuff, 'I');
						ab_addBytes(sendBuff, imgData);
					}
					if(getSize(cbtxtData)) // clip-Board text
					{
						ab_addValue(sendBuff, 1 + getSize(cbtxtData));
						addByte(sendBuff, 'B');
						ab_addBytes(sendBuff, cbtxtData);
					}
					// mouse Cursor kind
					{
						int mouseCursorKind = GetMouseCursorKind();

						ab_addValue(sendBuff, 2);
						addByte(sendBuff, 'C');
						addByte(sendBuff, mouseCursorKind);
					}
				}
			}
			else // ? PLAYER へ
			{
				SendToPlayer(command);
			}
			ReleaseOL(ol);
		}

		if(!getSize(sendBuff))
		{
			if(!Frtwv_GetJamDataCount(ServerSender)) // 空いていれば、送信データが無いことを通知
			{
				if(!SendingIdlingSentCount)
				{
					SendToServer("SENDER-IDLING");
					SendingIdlingSentCount = SenderIdlingSentPeriod; // 再送抑止期間をセット
				}
				else
					SendingIdlingSentCount--;
			}
		}
		else
			SendingIdlingSentCount = 0;
	}
endLoop:
	LOGPOS();

	SendToServer("DISCONNECTED");

	LOGPOS();

endNegoFault:
	releaseAutoBlock(sendBuff);
	releaseAutoBlock(recvBuff);

	LOGPOS();
}
static int IdleTh(void)
{
	if(handleWaitForMillis(EvStop, 0))
	{
		Death = 1;
		return 0;
	}
	return 1;
}
void RecverMain(void)
{
	LOGPOS();

	PortNo = toValue(nextArg());

	// load MusCursorHdls
	{
		autoList_t *sHdls = tokenize(nextArg(), ':');
		char *sHdl;
		uint index;

		MusCursorHdls = newList();

		foreach(sHdls, sHdl, index)
		{
			uint hCursor = toValue(sHdl);

			addElement(MusCursorHdls, hCursor);
		}
		releaseDim(sHdls, 1);
	}

	LOGPOS();

	// 設定ファイル読み込み
	{
		char *confFile = changeExt(getSelfFile(), "recver.conf");

		if(existFile(confFile))
		{
			autoList_t *lines = readResourceLines(confFile);
			uint c = 0;

			// items >

			CycleMillis            = toValue(refLine(lines, c++));
			SenderIdlingSentPeriod = toValue(refLine(lines, c++));

			// < items

			errorCase_m(strcmp(refLine(lines, c++), "\\e"), "Bad conf");

			releaseDim(lines, 1);
		}
		memFree(confFile);
	}

	LOGPOS();

	m_range(PortNo, 1, 65535);
	m_range(CycleMillis, 1, IMAX);
	m_range(SenderIdlingSentPeriod, 1, IMAX);

	cout("PortNo: %u\n", PortNo);
	cout("CycleMillis: %u\n", CycleMillis);
	cout("SenderIdlingSentPeriod: %u\n", SenderIdlingSentPeriod);

	ServerSender = Frtwv_Create(FRTWV_RECVER_TO_SERVER);
	ServerRecver = Frtwv_Create(FRTWV_SERVER_TO_RECVER);
	PlayerSender = Frtwv_Create(FRTWV_RECVER_TO_PLAYER);
	PlayerRecver = Frtwv_Create(FRTWV_PLAYER_TO_RECVER);

	LOGPOS();

	Frtwv_Clear(ServerSender);
	Frtwv_Clear(ServerRecver);
	Frtwv_Clear(PlayerSender);
	Frtwv_Clear(PlayerRecver);

	LOGPOS();

	EvStop = eventOpen(EV_STOP_RECVER);

	LOGPOS();

	sockServerTh(PerformTh, PortNo, 50, IdleTh);

	LOGPOS();

	Frtwv_Clear(ServerSender);
	Frtwv_Clear(ServerRecver);
	Frtwv_Clear(PlayerSender);
	Frtwv_Clear(PlayerRecver);

	LOGPOS();

	Frtwv_Release(ServerSender);
	Frtwv_Release(ServerRecver);
	Frtwv_Release(PlayerSender);
	Frtwv_Release(PlayerRecver);

	LOGPOS();

	handleClose(EvStop);

	LOGPOS();
}
