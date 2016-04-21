#pragma once

#include <iostream>
#include "MessageConstants.h"
#include "MessageBuilder.h"
#include "GMPMessage.h"

using namespace std;

class FPUResponse
{
public:
    static int RESPONSE_MSG_ID;
    string fiscalId;
    int SequenceNum;
    int ErrorCode;
    State FPUState;
    vector<unsigned char> Data;
    vector<GMPField*> Detail;

	FPUResponse();

	FPUResponse(vector<unsigned char> bytesRead);

	~FPUResponse(void);
};

