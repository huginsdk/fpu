#pragma once

#include <iostream>
#include <fstream> 
#include <cmath>
#include <string>
#include <vector>
#include <cstdio>
#include <cstdlib>
#include <cstring>
#include <fcntl.h> 

#ifdef WIN32
#include <windows.h>
#else
#include <termios.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <netdb.h>
#include <unistd.h>
#include <errno.h>
#include <pthread.h>

#endif
#include "Utilities.h"


#define MAX_TRY_COUNT	1
#define TIMEOUT			(8000)
#define STX				0x02
#define ETX				0x03
#define ACK				0x06
#define NACK			0x15

#define _min(a,b)		((a<b)?(a):(b))

#define BLOCK_SIZE		8192

using namespace std;

class Connection
{
public:
	enum 
	{
		NOT_INIT,
		INITED,
		OPENED,
		CLOSING,
		CLOSED
	};
	
	int				opened;		
	long			recvTimeout;
	vector<char>	_queue;
	char			_recvbuf[BLOCK_SIZE];
	char			ConnectionString[128];

	Connection(void);
	virtual ~Connection(void);
	
	virtual bool Open();
	virtual bool Write(unsigned char* buffer, unsigned long writeBytes, unsigned long& writtenBytes);

	virtual void Close();
	bool IsOpen();

	int GetTimeout();
	void SetTimeout(int timeout); 

	void Enqueue(char* buffer, int len);
	int Dequeue(char* buffer, int len);

	bool Read(unsigned char* buffer, unsigned long receiveBytes, unsigned long& receivedBytes); // without timeout
	void ReadExisting();
    vector<unsigned char> Read(unsigned long bytesToRead);
	 bool ReadByte(byte &data);

	int Write(vector<unsigned char> v); 


#ifdef WIN32
	HANDLE			_mutex; 
#else
	pthread_mutex_t _mutex; 
#endif
};
