#include "all.h"

// ---- 初期設定 ----

static char *ServerHost = "localhost";
static uint ServerPortNo = 55900;
static uint CycleMillis = 100;

// ----

static Frtwv_t *ClientSender;
static Frtwv_t *ClientRecver;
static Frtwv_t *RecorderSender;
static Frtwv_t *RecorderRecver;

#define EV_SEND_DATA_QUEUE_ADDED "{ef301aa0-2b79-4f27-9926-c06ebb02579b}"

static uint EvStop;
static uint EvSendDataQueueAddedForSet;
static uint EvSendDataQueueAddedForWait;

#define RECV_DATA_SIZE_MAX 50000000 // 50 MB
#define RECV_DATA_TOTAL_SIZE_MAX 100000000 // 100 MB

static autoList_t *SendDataQueue;
static autoList_t *RecvDataQueue;
static uint RecvDataTotalSize;

static int Death;
static int Sock;

static void SenderTh(void *prm_dummy)
{
	critical();
	{
		autoList_t *q = newList(); // g
		autoBlock_t *sendData;
		uint index;

		LOGPOS();

		while(!Death)
		{
			inner_uncritical();
			{
				collectEvents(EvSendDataQueueAddedForWait, 2000);
			}
			inner_critical();

			m_swap(SendDataQueue, q, autoList_t *);

			foreach(q, sendData, index)
			{
				uint rPos = 0;

				addByte(sendData, '\0'); // 文字列なので、サイズを送る代わりに閉じる。

				while(rPos < getSize(sendData))
					if(SockSendISequ(Sock, sendData, &rPos, 2000) == -1 || Death)
						goto endLoop; // g

				releaseAutoBlock(sendData);
			}
			setCount(q, 0);
		}
	endLoop:
		LOGPOS();
	}
	uncritical();

	Death = 1;
}
static void RecverTh(void *prm_dummy)
{
	critical();
	{
		LOGPOS();

		while(!Death)
		{
			autoBlock_t *buff = newBlock();
			uint size;

			do
			{
				if(SockRecvSequLoop(Sock, buff, 2000, 4) == -1 || Death)
					goto endLoop; // g
			}
			while(getSize(buff) < 4);

			size = ab_getValue(buff, 0);

			if(RECV_DATA_SIZE_MAX < size) // ? 受信データが大き過ぎる。
			{
				cout("Warning: 受信データが大き過ぎる。\n");

				goto endLoop; // g
			}
			setSize(buff, 0);

			do
			{
				if(SockRecvSequLoop(Sock, buff, 2000, size) == -1 || Death)
					goto endLoop;
			}
			while(getSize(buff) < size);

			if(RECV_DATA_TOTAL_SIZE_MAX < RecvDataTotalSize + size) // ? 受信データが溜まり過ぎている。
			{
				cout("Warning: 受信データが溜まり過ぎている。\n");

				releaseAutoBlock(buff);
			}
			else
			{
				addElement(RecvDataQueue, (uint)buff);
				RecvDataTotalSize += size;
			}
		}
	endLoop:
		LOGPOS();
	}
	uncritical();

	Death = 1;
}
static void AddToSendDataQueue(autoBlock_t *sendData) // sendData: bind
{
	if(100 < getCount(SendDataQueue)) // ? 送信データが溜まり過ぎている。
	{
		cout("Warning: 送信データが溜まり過ぎている。\n");

		releaseAutoBlock(sendData);
		return;
	}
	addElement(SendDataQueue, (uint)sendData);
	eventSet(EvSendDataQueueAddedForSet);
}
static int Perform(int sock, uint prm_dummy)
{
	uint th_s;
	uint th_r;

	if(!NegotiationClient(sock, EvStop))
		return 0;

	Sock = sock;

	critical();
	{
		LOGPOS();

		th_s = runThread(SenderTh, NULL);
		th_r = runThread(RecverTh, NULL);

		LOGPOS();

		while(!Death && !handleWaitForMillis(EvStop, 0))
		{
			// Recorder -> Server
			{
				autoBlock_t *sendData = Frtwv_Recv(RecorderRecver, CycleMillis);

				if(sendData)
				{
					AddToSendDataQueue(sendData);
				}
				else if(!Frtwv_GetJamDataCount(RecorderSender) && !getCount(SendDataQueue)) // 色々溜まってたらビジーっぽいので送らない。
				{
					autoList_t *lines = newList();
					autoList_t *ol;

					addElement(lines, (uint)strx("MOUSE-POS"));

					ol = LinesToOL(lines);
					Frtwv_SendOL(RecorderSender, ol, 1);
					ReleaseOL(ol);
				}
			}

			for(; ; ) // Client -> Recorder, Server
			{
				autoList_t *ol = Frtwv_RecvOL(ClientRecver, 1, 0);

				if(!ol)
					break;

				{
					autoList_t *lines = OLToLines(ol);
					char *command;
					uint c = 0;

					command = refLine(lines, c++);

					if(!strcmp(command, "SEND-TO-SERVER")) // ? サーバー行き
					{
						AddToSendDataQueue(ab_makeBlockLine(refLine(lines, c++)));
						releaseDim(lines, 1);
					}
					else // ? レコーダー行き
					{
						ol = LinesToOL(lines); // XXX ol -> lines -> ol
						Frtwv_SendOL(RecorderSender, ol, 1);
						ReleaseOL(ol);
					}
				}
			}

			// Server -> Client
			{
				static autoList_t *q;
				autoBlock_t *recvData;
				uint index;

				if(!q)
					q = newList(); // g

				m_swap(RecvDataQueue, q, autoList_t *);
				RecvDataTotalSize = 0;

				foreach(q, recvData, index)
				{
					if(10 < Frtwv_GetJamDataCount(ClientSender)) // ? クライアントへの送信データが溜まり過ぎている。
					{
						cout("Warning: 受信データ(クライアントへの送信データ)が溜まり過ぎている。\n");
					}
					else
					{
						autoList_t *ol = newList();

						addElement(ol, (uint)recvData);

						Frtwv_SendOL(ClientSender, ol, 1);
						releaseAutoList(ol);
					}
					releaseAutoBlock(recvData);
				}
				setCount(q, 0);
			}
		}
		LOGPOS();
	}
	uncritical();

	Death = 1;

	waitThread(th_s);
	waitThread(th_r);

	return 1;
}
void SenderMain(void)
{
	int ret;

	LOGPOS();

	ServerHost = nextArg();
	ServerPortNo = toValue(nextArg());

	LOGPOS();

	// 設定ファイル読み込み
	{
		char *confFile = changeExt(getSelfFile(), "sender.conf");

		if(existFile(confFile))
		{
			autoList_t *lines = readResourceLines(confFile);
			uint c = 0;

			// items >

			CycleMillis = toValue(refLine(lines, c++));

			// < items

			releaseDim(lines, 1);
		}
		memFree(confFile);
	}

	LOGPOS();

	errorCase_m(!*ServerHost, "接続先ホスト名が指定されていません。");
	errorCase_m(!isAsciiLine(ServerHost, 0, 0, 0), "接続先ホスト名に問題があります。");
	errorCase_m(!m_isRange(ServerPortNo, 1, 65535), "接続先ポート番号に問題があります。");
	m_range(CycleMillis, 1, IMAX);

	cout("ServerHost: %s\n", ServerHost);
	cout("ServerPortNo: %u\n", ServerPortNo);
	cout("CycleMillis: %u\n", CycleMillis);

	ClientSender = Frtwv_Create(FRTWV_SENDER_TO_CLIENT);
	ClientRecver = Frtwv_Create(FRTWV_CLIENT_TO_SENDER);
	RecorderSender = Frtwv_Create(FRTWV_SENDER_TO_RECORDER);
	RecorderRecver = Frtwv_Create(FRTWV_RECORDER_TO_SENDER);

	LOGPOS();

	Frtwv_Clear(ClientSender);
	Frtwv_Clear(ClientRecver);
	Frtwv_Clear(RecorderSender);
	Frtwv_Clear(RecorderRecver);

	LOGPOS();

	EvStop = eventOpen(EV_STOP_SENDER);
	EvSendDataQueueAddedForSet  = eventOpen(EV_SEND_DATA_QUEUE_ADDED);
	EvSendDataQueueAddedForWait = eventOpen(EV_SEND_DATA_QUEUE_ADDED);

	LOGPOS();

	// ここのは開放しないよ。
	{
		SendDataQueue = newList();
		RecvDataQueue = newList();
	}

	LOGPOS();

	ret = SClient(ServerHost, ServerPortNo, Perform, 0);

	LOGPOS();

	Frtwv_Clear(ClientSender);
	Frtwv_Clear(ClientRecver);
	Frtwv_Clear(RecorderSender);
	Frtwv_Clear(RecorderRecver);

	LOGPOS();

	Frtwv_Release(ClientSender);
	Frtwv_Release(ClientRecver);
	Frtwv_Release(RecorderSender);
	Frtwv_Release(RecorderRecver);

	LOGPOS();

	handleClose(EvStop);
	handleClose(EvSendDataQueueAddedForSet);
	handleClose(EvSendDataQueueAddedForWait);

	LOGPOS();

	errorCase_m(!ret, "サーバーとの接続又は通信に失敗しました。");
}
