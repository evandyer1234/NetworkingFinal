#include <iostream>
using namespace std;

#include <WinSock2.h>
#include <ws2tcpip.h>
#include <Windows.h>

const int BUF_SIZE = 64;
#define AS_BYTE(c) ( ((int)c) & 0xFF )

// Link with ws2_32.lib
#pragma comment(lib, "Ws2_32.lib")

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

	bool loop;

	iWSAStatus = WSAStartup(MAKEWORD(2, 2), &wsaData);

	// what did we get?
	cout << wsaData.szDescription << endl;

	// address family (TCP, UDP), datagram socket (UDP), 0 for default protocol
	s = socket(AF_INET, SOCK_DGRAM, 0);

	addr.sin_family = AF_INET;
	addr.sin_port = htons(49152);
	//addr.sin_addr.S_un.S_addr = inet_addr("127.0.0.1"); // OLD method 

	inet_pton(AF_INET, "127.0.0.1", &(addr.sin_addr));

	if (s == INVALID_SOCKET)
	{
		// see windows socket errors
		cout << "Error creating socket: " << WSAGetLastError() << endl;
		WSACleanup();
		return 1;
	}

	// associate with the server or another socket 
	sockErr = connect(s, (sockaddr*)&addr, sizeof(addr));

	if (sockErr == SOCKET_ERROR)
	{
		closesocket(s);
		cout << "Error connecting: " << WSAGetLastError() << endl;

		WSACleanup();
		return 1;
	}

	cout << "Enter an id to go by: ";
	cin.getline(msg.id, BUF_SIZE);

	loop = true;

	while (loop)
	{
		cout << msg.id << ": ";
		cin.getline(msg.buf, BUF_SIZE);

		if (cin.fail())
		{
			cin.clear();
			cin.ignore(255, '\n');
		}

		char* p = (char*)&msg;

		send(s, p, (BUF_SIZE * 2), 0);

		if (sockErr == SOCKET_ERROR)
		{
			closesocket(s);
			WSACleanup();
			cout << "Error connecting: " << WSAGetLastError() << endl;
			return 1;
		}

		if (!_stricmp(msg.buf, "quit"))
		{
			loop = false;
		}
	}

	closesocket(s);
	WSACleanup();

	return 0;
}