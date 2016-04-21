#pragma once

#include <string>

using namespace std; 

#if defined(_WINDLL) // inside DLL
#   define HUGINAPI   __declspec(dllexport)
#else // outside DLL
#   define HUGINAPI   __declspec(dllimport)
#endif  // _WINDLL

class HUGINAPI DevInfo
{
public:
	DevInfo(void) { }
	~DevInfo(void) { }

	string IP;
	int Port;
	string TerminalNo;
	string SerialNum;
	string Model;
	string Brand;
	string Version;
};

