#include "C:\Factory\Common\all.h"
#include "C:\Factory\Satellite\libs\Flowertact\Fortewave.h"

static Frtwv_t *Recver;
static Frtwv_t *Sender;

int main(int argc, char **argv)
{
	Recver = Frtwv_Create("UNREAL-TEST-CS-S");
	Sender = Frtwv_Create("UNREAL-TEST-CS-R");

	cout("I—¹‚·‚é‚É‚Í ESC ‚ð‰Ÿ‚µ‚Ä‰º‚³‚¢B\n");

	while(waitKey(0) != 0x1b)
	{
		autoBlock_t *bRecv = (autoBlock_t *)Frtwv_RecvOL(Recver, 0, 2000);

		if(bRecv)
		{
			char *message = unbindBlock2Line(bRecv);
			char *messageNew;
			autoBlock_t *bSend;

			cout("> %s\n", message);

			messageNew = xcout("Echo[%s]", message);

			cout("< %s\n", messageNew);

			bSend = ab_makeBlockLine(messageNew);

			Frtwv_SendOL(Sender, bSend, 0);

			memFree(message);
			memFree(messageNew);
			releaseAutoBlock(bSend);
		}
	}

	Frtwv_Release(Recver);
	Frtwv_Release(Sender);
}
