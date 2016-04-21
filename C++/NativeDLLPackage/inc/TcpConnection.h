#pragma once

#include "Connection.h"

#ifdef WIN32
#pragma comment (lib, "ws2_32.lib")
class TcpConnection : public Connection
{
private:
	string			ip;
	int				port;
	SOCKET			_socket;

public:
	TcpConnection(string ip, int port);

	~TcpConnection();

	bool Open();

	void Close();
		
	void RecvProc();

	bool Write(unsigned char* buffer, unsigned long writeBytes, unsigned long& writtenBytes); 
};
#else
class TcpConnection : public Connection
{
private:
	string			ip;
	int				port;
	int				sd;
	pthread_t		threadRecv;

public:
	TcpConnection(string ip, int port);

	~TcpConnection();

	bool Open();

	void Close();
		
	void RecvProc();

	bool Write(unsigned char* buffer, unsigned long writeBytes, unsigned long& writtenBytes); 
};
#endif

