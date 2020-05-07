C:\Factory\Tools\RDMD.exe /RC out
C:\Factory\Tools\RDMD.exe /MD out\Client
C:\Factory\Tools\RDMD.exe /MD out\Server

COPY /B UnrealPlayer.exe out\Client
COPY /B UnrealPlayer.exe out\Server

C:\Factory\SubTools\EmbedConfig.exe --factory-dir-disabled out\Client\UnrealPlayer.exe
C:\Factory\SubTools\EmbedConfig.exe --factory-dir-disabled out\Server\UnrealPlayer.exe

COPY /B UnrealClient\UnrealClient\bin\Release\UnrealClient.exe out\Client
COPY /B UnrealServer\UnrealServer\bin\Release\UnrealServer.exe out\Server

COPY /B C:\Factory\Labo\Socket\tunnel\crypTunnel.exe out\Client
COPY /B C:\Factory\Labo\Socket\tunnel\crypTunnel.exe out\Server

C:\Factory\SubTools\EmbedConfig.exe --factory-dir-disabled out\Client\crypTunnel.exe
C:\Factory\SubTools\EmbedConfig.exe --factory-dir-disabled out\Server\crypTunnel.exe

C:\Factory\Tools\xcp.exe doc out

C:\Factory\SubTools\zip.exe /O out\Client UnrealClient
C:\Factory\SubTools\zip.exe /O out\Server UnrealServer

MOVE out\Client\* out\.
MOVE out\Server\* out\.

RD out\Client
RD out\Server

C:\Factory\SubTools\zip.exe /O out UnrealRemoco

IF NOT "%1" == "/-P" PAUSE
