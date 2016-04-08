#pragma once

#include <string>
#include <vector>
#include <map>
using namespace std;

class GMPItem
{
public:
	virtual int Tag();
    virtual int Length();
    virtual vector<unsigned char> Value();
    virtual bool IsField();
};

class GMPField : public GMPItem
{
private:
	int tag;
    int length;
    vector<unsigned char> value;

public:
	int Tag();
    
	int Length();
    
	vector<unsigned char> Value();

	bool IsField();
	    
	GMPField(int tag, vector<unsigned char> value);

    GMPField(int tag, int length, vector<unsigned char> value);
        
    GMPField(int tag, string value);

    static vector<GMPField> Parse(vector<unsigned char> bytesRead);
};

class GMPGroup : public GMPItem
{
private:
	int groupTag;
    map<int, GMPField*> tags;

public:
	int Tag();

    int Length();

    vector<unsigned char> Value();

	bool IsField();

    map<int, GMPField*>& Tags();

    GMPGroup(int groupTag);

    ~GMPGroup();

    void Add(GMPField* tlv);

    GMPField* FindTag(int tag);
};

class GMPMessage
{
private:
	int msgType;
    string terminalNo;
    map<int, GMPItem*> items;

public:
	int MsgType();

    string GetTerminalNo();

    void SetTerminalNo(string value);

    GMPMessage();
        
    GMPMessage(int msgType);

    ~GMPMessage();

    void AddItem(GMPItem* item);

    void InsertItem(int index, GMPItem* item);

    GMPGroup* FindGroup(int groupTag);

    GMPField* FindTag(int tag);

    static GMPMessage* Parse(vector<unsigned char> bytesRead);

    vector<unsigned char> ToByte();
};

