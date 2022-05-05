#include <iostream>
#include <string>

// theading libraries
#include <atomic>
#include <thread> 
#include <mutex>

#include <vector>
#include <algorithm> // for_each

#include <WinSock2.h>
#include <ws2tcpip.h>
#include <Windows.h>

#include <conio.h>

// Link with ws2_32.lib
#pragma comment(lib, "Ws2_32.lib")

const int BUF_SIZE = 128;
typedef struct _DATA {
	char ID[BUF_SIZE];
	char partnerID[BUF_SIZE];
	char buf[BUF_SIZE];
}DATA, * PDATA;


struct idpair {
	SOCKET socket;
	std::string id;
};

typedef struct _SOCKET_INFO_ {
	SOCKET socket;
	SOCKADDR_IN addr;
}SOCKET_INFO, * PSOCKET_INFO;

class safe_client_storage {
private:
	std::mutex _mtx;
	std::vector<SOCKET_INFO*> _vclients;
	std::vector<SOCKET_INFO*>::iterator _it;
public:

	void list() {
		for (_it = _vclients.begin(); _it != _vclients.end(); _it++)
		{
			std::cout << (*_it)->socket;
		}
	}

	void add(PSOCKET_INFO pClient)
	{
		std::lock_guard<std::mutex>lock{ _mtx };
		_vclients.push_back(pClient);
	}

	void remove(PSOCKET_INFO pClient)
	{
		std::lock_guard<std::mutex>lock{ _mtx };

		for (_it = _vclients.begin(); _it != _vclients.end(); _it++)
		{
			if (*_it == pClient)
			{
				closesocket((*_it)->socket);
				delete* _it;

				_vclients.erase(_it);

				return;
			}
		}

	}

	void cleanup()
	{
		std::lock_guard<std::mutex>lock{ _mtx };

		// close all clients 
		std::for_each(_vclients.begin(), _vclients.end(),
			[](SOCKET_INFO* pInfo) {

				closesocket(pInfo->socket);
				delete pInfo;
			}
		);
	}

}client_list;

std::atomic_bool bRun;
std::vector<idpair> pairs;
const unsigned short PORT = 3399;
const int MAX_PENDING_CONNECTS = 16;

const char* LOCAL_HOST = "127.0.0.3";

void ioThread(SOCKET server);
void client_thread(PSOCKET_INFO pClient);

int main()
{
	bRun = true;
	int iWSAStatus;

	
	std::vector<std::thread> VClients;


	SOCKADDR_IN addrServer;	 // socket address structure

	addrServer.sin_family = AF_INET;
	addrServer.sin_port = htons(PORT);
	inet_pton(AF_INET, LOCAL_HOST, &addrServer.sin_addr);

	WSADATA wsaData;
	if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
	{
		std::cout << "error starting sockets " << WSAGetLastError() << std::endl;
		return 1;
	}

	SOCKET serverSocket = socket(AF_INET,		// Address family Internet
		SOCK_STREAM,	// TCP stream socket
		IPPROTO_TCP);	// TCP protocol

	if (serverSocket == INVALID_SOCKET)
	{
		std::cout << "Error creating socket: " << WSAGetLastError() << std::endl;
		return 1;
	}

	// associate the socket with this address and port 
	if (bind(serverSocket, (LPSOCKADDR)&addrServer, sizeof(addrServer)) == SOCKET_ERROR)
	{
		closesocket(serverSocket);
		std::cout << "error binding server " << WSAGetLastError() << std::endl;
		return 1;
	}

	// server socket will listen for clients connecting 
	if (listen(serverSocket, MAX_PENDING_CONNECTS) == SOCKET_ERROR)
	{
		closesocket(serverSocket);
		std::cout << "Error listen: " << WSAGetLastError() << std::endl;
		return 1;
	}

	std::thread io{ ioThread, serverSocket };

	while (bRun) // server thread 
	{
		SOCKET clientSocket;
		SOCKADDR_IN clientAddr;
		int clientAddrLen = sizeof(clientAddr);
		SOCKET_INFO* pClientInfo;

		clientSocket = accept(serverSocket,
			(sockaddr*)&clientAddr, &clientAddrLen);

		if (clientSocket == INVALID_SOCKET)
		{
			int error = WSAGetLastError();

			if (error == WSAENOTSOCK || error == WSAEINTR) {
				std::cout << "shutting down ..." << std::endl;
			}
			else {
				closesocket(serverSocket);
				std::cout << "Accept error " << error << std::endl;
			}

			bRun = false;
		}
		else
		{
			pClientInfo = new SOCKET_INFO{ clientSocket, clientAddr }; // destroyed in client thread
			client_list.add(pClientInfo);
			VClients.push_back(std::thread{ client_thread, pClientInfo });
		}

	}// end while main 

	io.join(); // wait for io thread to end 

	client_list.cleanup();

	// wait for each thread
	std::for_each(VClients.begin(), VClients.end(), [](std::thread& t) { t.join(); });

	system("pause"); // see results 

	return 0;
} // end main


void ioThread(SOCKET server)
{
	std::cout << "press any key to end application ... " << std::endl;
	_getch(); // wait for keyboard hit 

	bRun = false; // tell everyone to end 

	closesocket(server); // tell server to end 
}

void client_thread(PSOCKET_INFO pClient)
{
	struct cleanup {
		PSOCKET_INFO p;
		~cleanup()
		{
			client_list.remove(p);
		}
	}x{ pClient };

	char s_ip[INET_ADDRSTRLEN];
	inet_ntop(AF_INET, &pClient->addr.sin_addr, s_ip, sizeof(s_ip));

	std::cout << "Starting client thread for " << s_ip
		<< " on port " << ntohs(pClient->addr.sin_port) << std::endl;

	char p[BUF_SIZE * 3];

	//buf[nRecvBytes] = '\0';

	std::vector<idpair>::iterator _it2;

	std::string list;

	for (_it2 = pairs.begin(); _it2 != pairs.end(); _it2++)
	{
		list += _it2->id + "\n";
	}
	char* pc = const_cast<char*>(list.c_str());

	send(pClient->socket, pc, BUF_SIZE * 10, 0);

	int nRecvBytes = recv(pClient->socket, p, sizeof(p), 0);
	
	DATA* dp = (DATA*)p;
	SOCKET partnerSocket;
	pairs.push_back(idpair{ pClient->socket, dp->ID });

	int c = 0;
	while (c != 1) {
		recv(pClient->socket, p, sizeof(p), 0);
		DATA* dp = (DATA*)p;
		for (_it2 = pairs.begin(); _it2 != pairs.end(); _it2++)
		{
			if (dp->partnerID == _it2->id) {
				std::string request = "Would you like to chat with " + (std::string)dp->ID + "? (Y/N)";
				char* cr = const_cast<char*>(request.c_str());
				send(_it2->socket, cr, 400, 0);
				char response[50];
				std::cout << "Waiting" << std::endl;
				recv(_it2->socket, response, sizeof(response), 0);
				std::cout << "Received";
				if (response[0] == 'Y') {
					partnerSocket = _it2->socket;
					char s[] = "Success";
					send(pClient->socket, s, sizeof(s), 0);
					c++;
				}
			}
		}
		if (c == 0) {
			char f[] = "Failed";
			send(pClient->socket, f, sizeof(f), 0);
		}
	}


	/*
	//send Client list
	send(pClient->socket, client_list, strlen(client_list), 0);
	*/

	while (bRun)
	{
		int nRecvBytes = recv(pClient->socket, p, sizeof(p), 0);

		//buf[nRecvBytes] = '\0';

		DATA* dp = (DATA*)p;

		// use id to identify client
		std::cout << dp->ID << " : " << dp->buf << std::endl;

		if (nRecvBytes == SOCKET_ERROR)
		{
			int error = WSAGetLastError();

			switch (error)
			{
			case WSAECONNABORTED:
				std::cout << "Client closing..." << std::endl;
				break;
			case WSAECONNRESET:
				std::cout << "Lost connection with client" << std::endl;
				break;
			default:
				std::cout << "Client closing " << WSAGetLastError() << std::endl;
			}

			return;
		}
		else // recv OK
		{
			if (nRecvBytes > 0)
			{
				char* d = (char*)&dp;
				send(partnerSocket, d, nRecvBytes, 0); // echo 

				if (strlen(dp->buf) == 1 && toupper(dp->buf[0]) == 'Q' )
				{
					std::cout << "Client closed connection" << std::endl;

					return;
				}
			}
		}

	}// end while run 

}// end client thread 



