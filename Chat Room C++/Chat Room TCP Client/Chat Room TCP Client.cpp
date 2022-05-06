

#include <winsock2.h> 
#include <ws2tcpip.h>
#include <windows.h>

// Link with ws2_32.lib
#pragma comment(lib, "Ws2_32.lib")

#include <iostream>
using namespace std;

const unsigned short PORT = 3399;
const int BUF_SIZE = 128;

typedef struct _DATA {
	char ID[BUF_SIZE];
	char partnerID[BUF_SIZE];
	char buf[BUF_SIZE];
}DATA, * PDATA;

int main()
{
	DATA msg;
	SOCKADDR_IN addr;	 // socket address structure
	SOCKET ClientSocket;
	WSADATA wsaData;     // Windows Socket API data

	int sockErr;

	char dataToSend[BUF_SIZE]; // output buffer
	char dataToRecv[BUF_SIZE]; // output buffer

	// start the Windows Socket API version 2.2 (we might not get this version)
	WSAStartup(MAKEWORD(2, 2), &wsaData); // sometimes you will see version 1,1

	addr.sin_family = AF_INET;
	addr.sin_port = htons(PORT); // host to network short
	inet_pton(AF_INET, "127.0.0.3", &addr.sin_addr);

	ClientSocket = socket(AF_INET,		// Address family
		SOCK_STREAM,		// Socket type
		IPPROTO_TCP);	// Protocol

	if (ClientSocket == INVALID_SOCKET)
	{
		cout << "Error connecting: " << WSAGetLastError() << endl;
		WSACleanup();
		return 1;
	}

	sockErr = connect(ClientSocket, (sockaddr*)&addr, sizeof(addr));

	if (sockErr == SOCKET_ERROR)
	{

		closesocket(ClientSocket);
		WSACleanup();

		return 1;
	}



	//Gets the user's ID, and sends it

	int pl = 0;
	cout << "Enter an id to go by: ";
	cin.getline(msg.ID, BUF_SIZE);
	char* p = (char*)&msg;
	send(ClientSocket, p, (BUF_SIZE * 3), 0);//Just user ID




	char list[BUF_SIZE * 10];
	int a = recv(ClientSocket, list, BUF_SIZE * 10, 0);//Receives user list

	if (list[0] != NULL) {
		cout << "All active users:" << endl;
		printf("%s", list);
		cout << endl << endl;
		int c = 0;
		while (c != 1) {
			cout << "Please select a user from the list to chat with: ";
			cin.getline(msg.partnerID, BUF_SIZE);
			//Send a message, server returns whether it was valid, if so leave loop
			char* p = (char*)&msg;
			send(ClientSocket, p, (BUF_SIZE * 3), 0);//Send User ID and Partner ID
			char r[20];
			recv(ClientSocket, r, sizeof(r), 0);//Recieve chat request response
			if (r[0] == 'F') {
				cout << "The user either rejected your request or doesn't exist." << endl;
			}
			else if (r[0] == 'S') {
				pl++;
				cout << "You are now speaking to " << msg.partnerID << ", have fun!" << endl;
			}
		}
	}
	else {
		cout << "It seems like no one's online, either wait for someone to request to message you, or check back later." << endl;
	}
	
	
	//Waiting for chat request loop
	while (pl != 1) {
		char r[400];
		recv(ClientSocket, r, sizeof(r), 0);//Recieve chat request
		DATA* n = (DATA*)r;
		printf("%s", n->buf);
		printf("%s", n->ID);
		cout << endl;
		cin.getline(n->buf, BUF_SIZE);
		char* response = (char*)&n;
		send(ClientSocket, response, BUF_SIZE * 3, 0);//Sends response
		if (n->buf[0] == 'Y') {
			pl++;
			strcpy_s(msg.partnerID, n->ID);
		}
	}


	bool run = true;

	cout << "Enter q to quit the chat whenever" << endl;
	while (run)
	{
		cout << endl;
		
		cout << msg.ID << ": ";
		cin.getline(msg.buf, BUF_SIZE);

		char* p = (char*)&msg;

		sockErr = send(ClientSocket, p, (BUF_SIZE * 3), 0);

		int ret = recv(ClientSocket, dataToRecv, sizeof(dataToRecv), 0);

		//dataToRecv[ret] = '\0';

		DATA* dp = (DATA*)dataToRecv;

		cout << "Recv: " << dp->buf << endl;

		switch (dataToRecv[ret])
		{
		case 'Q':
		case 'q':
			run = false;
		}
	}



	closesocket(ClientSocket); // do this at the end of your program
	WSACleanup();

	system("pause");

	return 0;
}