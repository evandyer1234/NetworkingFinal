#include <iostream>
using namespace std;

#define _WINSOCK_DEPRECATED_NO_WARNINGS

#include <WinSock2.h>
#include <ws2tcpip.h>
#include <Windows.h>

// Link with ws2_32.lib
#pragma comment(lib, "Ws2_32.lib")

const int BUF_SIZE = 64;
#define AS_BYTE(c) ( ((int)c) & 0xFF )

#pragma pack(1)

typedef struct _DATA_ {
	char id[BUF_SIZE];
	char buf[BUF_SIZE];
}DATA, * PDATA;
#pragma pop

int main()
{
	DATA msg;
	SOCKET s;
	SOCKADDR_IN addr;

	int iWSAStatus;		// Windows Socket API Status
	WSADATA wsaData;

	int sockErr;

	char buf[BUF_SIZE * 2];
	char* p = new char[BUF_SIZE * 2];
	bool loop;

	iWSAStatus = WSAStartup(MAKEWORD(2, 2), &wsaData);

	// what did we get?
	cout << wsaData.szDescription << endl;

	// address family (TCP, UDP), datagram socket (UDP), 0 for default protocol
	s = socket(AF_INET, SOCK_DGRAM, 0);

	if (s == INVALID_SOCKET)
	{
		// see windows socket errors
		cout << "Error creating socket: " << WSAGetLastError() << endl;
		WSACleanup();
		return 1;
	}

	addr.sin_family = AF_INET;
	addr.sin_port = htons(49152);
	inet_pton(AF_INET, "127.0.0.1", &(addr.sin_addr));

	sockaddr* address = (sockaddr*)&addr;

	// associate local address with a socket
	sockErr = bind(s, address, sizeof(addr));

	if (sockErr == SOCKET_ERROR)
	{
		closesocket(s);
		cout << "Error bind: " << WSAGetLastError() << endl;
		WSACleanup();
		return 1;
	}

	loop = true;

	while (loop)
	{
		int bytesRecv = recv(s, p, (BUF_SIZE * 2), 0);

		DATA* dp = (DATA*)p;
		cout << dp->id << ": " << dp->buf << endl;

		if (bytesRecv == SOCKET_ERROR)
		{
			closesocket(s);
			cout << "Error recv: " << WSAGetLastError() << endl;
			return 0;
		}

		if (!_stricmp(dp->buf, "quit"))
		{
			loop = false;
		}
	}

	closesocket(s);
	WSACleanup();

	return 0;
}