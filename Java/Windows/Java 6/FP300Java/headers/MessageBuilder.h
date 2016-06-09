#pragma once

#include <ctime>
#include <cmath>
#include <string>
#include <sstream>
#include <vector>
#include <cstdlib>
#include "MessageConstants.h"
using namespace std;

#ifdef WIN32
#include <windows.h>

#if defined(HUGINAPI_DLL_BUILD) // inside DLL
#   define HUGINAPI   __declspec(dllexport)
#elif defined __MINGW32__
#   define HUGINAPI
#else // outside DLL
#   define HUGINAPI   __declspec(dllimport)
#endif  // _WINDLL

#else
#define HUGINAPI 
#endif

class HUGINAPI MessageBuilder
{
public:

	static vector<unsigned char> GetDateTimeInBytes(tm date);

	static vector<unsigned char> GetDateInBytes(tm date);

	static vector<unsigned char> Date2Bytes(tm date);

	static vector<unsigned char> GetTimeInBytes(tm time);

	static vector<unsigned char> Time2Bytes(tm time);

	static tm GetDateFromBcd(vector<unsigned char> blockData, int index, int& outIndex);

	static tm AddTimeFromBcd(vector<unsigned char> blockData, int index, int& outIndex, tm dtToAdd);

	static vector<unsigned char> AddLength(int len);

	static vector<unsigned char> HexToByteArray(int hexNum);

	static int ByteArrayToHex(vector<unsigned char> bytesArray, int offset, int len);

	static int GetTag(vector<unsigned char> bytesArray, int offset, int& outOffset);

	static tm ConvertBytesToDate(vector<unsigned char> bytesBCD, int offset);
        
	static tm ConvertBytesToTime(vector<unsigned char> bytesBCD, int offset);

	static int ConvertBcdToInt(vector<unsigned char> bytesBCD, int offset, int len);

	static vector<unsigned char> ByteArrayToString(vector<unsigned char> bytesArray, int offset, int len);

	static vector<unsigned char> GetString(vector<unsigned char> bytesArray, int index, int& outIndex);

	static vector<unsigned char> GetBytesFromOffset(vector<unsigned char> bytesArray, int offset, int len);

	static unsigned char CalculateLRC(vector<unsigned char> reqPacket);

	static short CalculateCRC(vector<unsigned char> buffer, int offset, int length);

	static vector<unsigned char> ConvertIntToBCD(int value, int bcdLen);

	static vector<unsigned char> ConvertDecimalToBCD(double value, int decimalCnt);

	static int GetLength(vector<unsigned char> msgBytes, int offset, int& outIndex);

	static string BytesToHexString(vector<unsigned char> bytesArr);

	static string ByteToHexString(unsigned char byte);

	static vector<unsigned char> HexStringToBytes(string strBytes);

	static string FixTurkish(string str);

	static string IntToString(int val, int len = 0);

	static string DoubleToString(double val, int decimal = 2);

	static string ToString(vector<unsigned char> v);

	static vector<unsigned char> ToVector(string str);

	static int ToInt32(vector<unsigned char> v);

	static int ToInt32(vector<string> s, int offset, int count);

	static string PadLeft(string s, int len, unsigned char ch);

	static vector<unsigned char> PadRight(vector<unsigned char> v, int len, unsigned char ch);

	static vector<string> Split(string str, char ch);

	static string PadRight(string s, int len, unsigned char ch);

	static string DateToString(tm date);

	static string TimeToHHMM(tm date);

	static double RoundToDouble(double val);
};

class Crc16
{
private:
	static unsigned short polynomial;
	static unsigned short table[];

public:
	// CRC16_BYTE(crc, data) (crc16_table[ ((crc >> 8) ^ data) ] ^ (crc << 8));
	static unsigned short ComputeChecksum(vector<unsigned char> bytes, int offset, int length);

	static vector<unsigned char> ComputeChecksumBytes(vector<unsigned char> bytes);
};

