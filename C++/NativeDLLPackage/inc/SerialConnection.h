#pragma once

#include "Connection.h"

#ifdef WIN32
class SerialConnection : public Connection
{
private:
	string		portName;
	int			baudRate;
	HANDLE		hFile;		
	OVERLAPPED  osRead;
	OVERLAPPED  osWrite;

public:
	SerialConnection(string portName, int baudRate);

	~SerialConnection();

	bool Open();

	void Close();

	void RecvProc();

	bool Write(BYTE* buffer, DWORD writeBytes, DWORD& writtenBytes); 
};
#else
class SerialConnection : public Connection
{
private:
	string		portName;
	int			baudRate;

    int			tty_fd;

public:
	SerialConnection(string portName, int baudRate);

	~SerialConnection();

	bool Open();

	void Close();

	void RecvProc();

	bool Write(unsigned char* buffer, unsigned long writeBytes, unsigned long& writtenBytes); 
};
#endif

