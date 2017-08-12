#include "libs\all.h"

int main(int argc, char **argv)
{
	if(argIs("PLAYER"))
	{
		PlayerMain();
	}
	else if(argIs("RECORDER"))
	{
		RecorderMain();
	}
	else if(argIs("RECVER"))
	{
		RecverMain();
	}
	else if(argIs("SENDER"))
	{
		SenderMain();
	}
}
