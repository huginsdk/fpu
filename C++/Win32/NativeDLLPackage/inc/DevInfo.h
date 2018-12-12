#pragma once

#include <string>

using namespace std; 

#if defined(HUGINAPI_DLL_BUILD) // inside DLL
#   define HUGINAPI   __declspec(dllexport)
#elif defined __MINGW32__
#   define HUGINAPI
#elif defined(WIN32) // outside DLL
#   define HUGINAPI   __declspec(dllimport)
#else
#   define HUGINAPI   
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

typedef DevInfo DeviceInfo;
