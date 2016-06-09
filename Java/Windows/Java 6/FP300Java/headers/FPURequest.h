#pragma once

#include <iostream>
#include <string>
#include <vector>
#include "MessageBuilder.h"
#include "MessageConstants.h"

using namespace std;

enum Command
{
    NULL1 = 0,
    LOGO = 0x11,
    VAT = 0x12,
    DEPARTMENT = 0x13,
    PLU = 0x14,
    CREDIT = 0x15,
    MAIN_CAT = 0x16,
    SUB_CAT = 0x17,
    CASHIER = 0x18,
    PRG_OPTIONS = 0x19,
    FCURRENCY = 0x1A,
    TSM_IP_PORT = 0x1B,
    GRAPHIC_LOGO = 0x1C,
    NETWORK = 0x1D,

    START_RCPT = 0x21,
    SALE_ITEM = 0x22,
    ADJUSTMENT = 0x23,
    CORRECTION = 0x24,
    VOID_ITEM = 0x25,
    SUBTOTAL = 0x26,
    PAYMENT = 0x27,
    CLOSE_RCPT = 0x28,
    VOID_RCPT = 0x29,
    CUSTOMER_NOTE = 0x2A,
    RCPT_BARCODE = 0x2B,
    VOID_PAYMENT = 0x2C,
	SALE_DEPT = 0x2D,

    X_DAILY = 0x31,
    X_PLU = 0x32,
	SYSTEM_INFO_REP = 0x33,
    RECEIPT_TOTAL = 0x34,

    Z_DAILY = 0x41,
    Z_FM_ZZ = 0x42, 
    Z_FM_ZZ_DETAIL = 0x43, 
    Z_FM_DATE = 0x44, 
    Z_FM_DATE_DETAIL = 0x45,
    Z_ENDDAY = 0x46, //Endday bank
    CMD_Z_OLD_DAILY = 0x47,

    EJ_DETAIL = 0x51,
    EJ_RCPTCOPY_ZR = 0x52,//both single and periodic
    EJ_RCPTCOPY_DATE = 0x53,//both single and periodic. either daily

    SRV_CLEAR_DAILY = 0x61,
    SRV_SET_DATETIME = 0x62,
    SRV_FACTORY_SETTINGS = 0x63,
    SRV_STOP_FM = 0x64,
    SRV_EXTERNAL_DEV_SETTINGS = 0x65,
    SRV_UPDATE_FIRMWARE = 0x66,
    SRV_PRINT_LOGS = 0x67,
    SRV_CREATE_DB = 0x68,
    SRV_EXIT_SERVICE = 0x6F,

    INFO_LAST_Z = 0x71,
    INFO_LAST_RCPT = 0x72,
    INFO_DRAWER = 0x73,
	INFO_RECEIPT = 0x74,

    STATUS = 0x81,
    LAST_RESPONSE = 0x82,
    BREAK = 0x83,
    START_FM = 0x84,
    FISCALIZE = 0x85,
    INIT_EJ = 0x86,
    CASHIER_LOGIN = 0x87,
    CASHIER_LOGOUT = 0x88,
    CASH_IN = 0x89,
    CASH_OUT = 0x8A,
    START_NF_RCPT = 0x8B,
    ADD_NF_LINE = 0x8C,
    END_NF_RCPT = 0x8D,
    EJ_LIMIT = 0x8E,
    START_SERVICE = 0x8F,
    ENTER_SERVICE = 0x90,
    FILE_TRANSFER = 0x91,
    OPEN_DRAWER = 0x92,

    EFT_PAYMENT = 0xA0,
	EFT_CARD_INFO = 0xA7,
	EFT_CARD_INFO_LIST = 0xA8,
	EFT_VOID = 0xA9,
	EFT_REFUND = 0xAA,
	EFT_BANK_LIST = 0xAB,
	EFT_END_DAY = 0xA6
};

class FPURequest
{
public:
	static int REQUEST_MSG_ID;
    static int MAX_PRCSS_SEC_NUM;

	static string FiscalId;
	static int SequenceNum;

    Command command;
    vector<unsigned char> data;
    vector<unsigned char> Request;
    int sequence;

	FPURequest(Command command, vector<unsigned char> data);

	~FPURequest(void);
	
	vector<unsigned char> CreateRequest(string terminalNo, int messageType);

	static wstring GetCommand(Command command);
};

