#pragma once

#include <iostream>
#include <cmath>
#include <string>
#include <vector>
#include <cstdio>
#include <cstdlib>
#include <cstring>
#include <fcntl.h> 
#include "MessageBuilder.h"

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

#define MAX_TRY_COUNT	10
#define TIMEOUT			4000
#define STX				0x02
#define ETX				0x03
#define ACK				0x06
#define NACK			0x15

#define min(a,b)		((a<b)?(a):(b))
#define BLOCK_SIZE		4096

using namespace std;

class Connection
{
private:
    vector<unsigned char> Read(unsigned long bytesToRead);

    int ReadByte();

	// for dummy
	void ReadExisting();

	int Write(vector<unsigned char> v); 

public:
	long			recvTimeout;
	bool			opened;		
	vector<char>	_queue;
	char			_recvbuf[BLOCK_SIZE];

	Connection(void);
	
	virtual ~Connection(void);
	
	virtual bool Open();
	virtual bool Write(unsigned char* buffer, unsigned long writeBytes, unsigned long& writtenBytes);

	bool IsOpen();

	int GetTimeout();

	void SetTimeout(int timeout); 
	void Enqueue(char* buffer, int len);

	int Dequeue(char* buffer, int len);
    vector<unsigned char> Read();
	bool Read(unsigned char* buffer, unsigned long receiveBytes, unsigned long& receivedBytes);

	int Send(vector<unsigned char> buffer);

#ifdef WIN32
	HANDLE			_mutex; 
#else
	pthread_mutex_t _mutex; 
#endif
};

