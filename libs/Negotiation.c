#include "all.h"

#define NEGO_TIMEOUT_SEC 20

#define SIG_PREFIX "UNREAL-REMOCO/" __DATE__ " " __TIME__ "/"
#define SIG_CLIENT_TO_SERVER SIG_PREFIX "C2S"
#define SIG_SERVER_TO_CLIENT SIG_PREFIX "S2C"

static int DoNegotiation(int sock, uint evStop, char *sendPtn, char *recvPtn)
{
	SockStream_t *ss = CreateSockStream(sock, NEGO_TIMEOUT_SEC);
	char *line;
	int ret;

	cout("DoNegotiation_go\n");
	cout("sendPtn: %s\n", sendPtn);
	cout("recvPtn: %s\n", recvPtn);

	SockSendLine(ss, sendPtn);

	// 少なくとも１文字受信するまで待つ。その間終了をリクエストされたら 0 を返す。
	while(!SockRecvCharWait(ss, 2000))
		if(handleWaitForMillis(evStop, 0))
			DestroySockStream(ss);

	line = SockRecvLine(ss, strlen(recvPtn) + 10); // + margin
	ReleaseSockStream(ss);

	ret = !strcmp(line, recvPtn);
	cout("DoNegotiation_ret: %d\n", ret);

	memFree(line);
	return ret;
}
int NegotiationClient(int sock, uint evStop)
{
	return DoNegotiation(
		sock,
		evStop,
		SIG_CLIENT_TO_SERVER,
		SIG_SERVER_TO_CLIENT
		);
}
int NegotiationServer(int sock, uint evStop)
{
	return DoNegotiation(
		sock,
		evStop,
		SIG_SERVER_TO_CLIENT,
		SIG_CLIENT_TO_SERVER
		);
}
