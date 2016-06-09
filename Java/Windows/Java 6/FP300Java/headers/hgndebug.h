#ifndef _HGNDEBUG_H_
#define _HGNDEBUG_H_

#if 1 //HUGINDEBUG
#include <cstdio>
#include <cstdlib>
#include <iostream>
#include <fstream>
#include <sstream>
#include <algorithm>
#include <string>
extern std::ofstream debugfile;
{\
	debugfile<<__FUNCTION__<<","<<__LINE__<<"  "<<#x<<": "<<x<<std::endl;\
}
{\
	debugfile<<__FUNCTION__<<","<<__LINE__<<"  "<<#x<<std::endl;\
	for(int i = 0; i < len ; i++) \
	{\
		debugfile<<std::hex<<x[i]<<" ";\
	}\
	debugfile<<std::dec<<std::endl;\
}

#else
#endif
#endif// _HGNDEBUG_H_
