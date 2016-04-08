#pragma once

#include <iostream>
#include <string>
#include <sstream>
#include <fstream>
#include "SFResponse.h"
#include "DevInfo.h"
#include "SerialConnection.h"
#include "TcpConnection.h"
#include "GMPMessage.h"
#include "FPURequest.h"
#include "FPUResponse.h"
#include "JSONDocument.h"

#ifdef WIN32
#include <windows.h>

#if defined(HUGINAPI_DLL_BUILD) // inside DLL
#   define HUGINAPI   __declspec(dllexport)
 #else // outside DLL
#   define HUGINAPI   __declspec(dllimport)
#endif  // _WINDLL

#else

#define HUGINAPI 
#include <unistd.h>

#endif

using namespace std;

enum MatchingState
{
    NoMatchedDevice,
    Matched
};

enum Settings
{
    CUTTER,
    PAY_WITH_EFT,
    RECEIPT_LIMIT,
    GRAPHIC_LOGO1,
    RECEIPT_BARCODE
};

enum PaymentType
{
    CASH,
    CREDIT1,
    CHECK,
    FCURRENCY1
};

enum AdjustmentType
{
    Fee,
    PercentFee,
    Discount,
    PercentDiscount
};


class ProgramOption
{
public:
	int No;
    string Value;

	ProgramOption()
	{
		No = 0;
		Value = "";
	}
};

class Adjustment
{
public:
	AdjustmentType Type;
	double Amount;
    int percentage;

	Adjustment()
	{
		Type = Discount;
		Amount = 0.0;
		percentage = 0;
	}
};

class PaymentInfo
{
public:
	PaymentType Type;
    int Index;
    double PaidTotal;

	PaymentInfo()
	{
		Index = 0;
		PaidTotal = 0.0;
	}
};

class JSONItem
{
public:
	int Id;
    double Quantity;
    double Price;
    string Name;
    int DeptId;
    int Status;
    Adjustment Adj;
};

class JSONDocument
{
public:
	vector<JSONItem> FiscalItems;
    vector<Adjustment> Adjustments;
    vector<PaymentInfo> Payments;
    vector<string> FooterNotes;
};

class HUGINAPI  HuginPrinter
{
private:
	DevInfo devInfo;
	string licanceKey;
	Connection* connection;
    MatchingState matchState;
    wstring currentLog;
    static int PRINTER_LINE_LENGTH;
    string FiscalRegisterNo;

	vector<unsigned char> EncapsulateMessage(int msgType, vector<unsigned char> reqPacket);

    void SendMessage(GMPMessage* msg);

    void Log(vector<unsigned char> msgBuff, string note);
    
	vector<unsigned char> FormatFPUMessage(GMPMessage* msg);

    vector<unsigned char> Read();


public:
	HuginPrinter(void);

	~HuginPrinter(void);

	bool SerialConnect(string portName, int baudRate);

	bool TcpConnect(string ip, int port);

    int GetTimeout();

    void SetTimeout(int timeout);

    string SetDepartment(int id, vector<unsigned char> name, int vatId, double price, int weighable);

    string GetDepartment(int deptId);

    string SetCreditInfo(int id, vector<unsigned char> name);

    string GetCreditInfo(int id);

    string SetCurrencyInfo(int id, vector<unsigned char> name, double exchangeRate);

    string GetCurrencyInfo(int index);

    string SetMainCategory(int id, vector<unsigned char> name);

    string GetMainCategory(int mainCatId);

    string SetSubCategory(int id, vector<unsigned char> name, int mainCatId);

    string GetSubCategory(int subCatId);

    string SaveCashier(int id, vector<unsigned char> name, vector<unsigned char> password);

    string GetCashier(int cashierId);

	string SignInCashier(int id, vector<unsigned char> password);

    string CheckCashierIsValid(int id, vector<unsigned char> password);

    string GetLogo(int index);

    string SetLogo(int index, vector<unsigned char> line);

    tm GetDateTime();

    string SetDateTime(tm date, tm time);

    string GetVATRate(int index);

    string SetVATRate(int index, double taxRate);

    string SaveProduct(int productId, vector<unsigned char> productName, int deptId, double price, int weighable, vector<unsigned char> barcode, int subCatId);

    string GetProduct(int pluNo);

    string SaveGMPConnectionInfo(vector<unsigned char> ip, int port);

   // string LoadGraphicLogo(Image imageObj);

    string GetProgramOptions(int progEnum);

    string SaveProgramOptions(int progEnum, vector<unsigned char> progValue);

    string PrintDocumentHeader();

    string PrintDocumentHeader(vector<unsigned char> tckn_vkn, double amount, int docType);

    string PrintParkDocument(vector<unsigned char> plate, tm entrenceDate);

    string PrintItem(int PLUNo, double quantity, double amount, vector<unsigned char> name, int deptId, int weighable);

    string PrintItems(vector<JSONItem3> itemList);

    string PrintAdjustment(int adjustmentType, double amount, int percentage);

    string Correct();

    string Void(int PLUNo, double quantity);

    string PrintSubtotal(bool isQuery);

    string PrintPayment(int paymentType, int index, double paidTotal);

    string VoidPayment(int paymentSequenceNo);

    string CloseReceipt(bool slipCopy);

    string VoidReceipt();

    string PrintRemarkLine(vector<unsigned char> line);

    string PrintReceiptBarcode(vector<unsigned char> barcode);

    string PrintJSONDocument(JSONDocument3 jsonDoc);
	string PrintJSONDocument(string json);	

    string PrintXReport(int copy);

    string PrintXPluReport(int firstPlu, int lastPlu, int copy);

    string PrintZReport();

    string PrintPeriodicZZReport(int firstZ, int lastZ, int copy, bool detail);

    string PrintPeriodicDateReport(tm firstDay, tm lastDay, int copy, bool detail);

    string PrintEJPeriodic(tm day, int copy);

    string PrintEJPeriodic(tm startTime, tm endTime, int copy);

    string PrintEJPeriodic(int ZStartId, int docStartId, int ZEndId, int docEndId, int copy);

    string PrintEJDetail(int copy);

    string EnterServiceMode(vector<unsigned char> password);

    string ExitServiceMode(vector<unsigned char> password);

    string ClearDailyMemory();

    string FactorySettings();

    string CloseFM();

    string SetExternalDevAddress(vector<unsigned char> ip, int port);

    string UpdateFirmware(vector<unsigned char> ip, int port);

    string PrintLogs(tm date);

    string CreateDB();

	bool Connect(DevInfo devInfo, string fiscalRegNo, string licanceKey);

	string CheckPrinterStatus();

	string GetLastResponse();

	string CashIn(double amount);

	string CashOut(double amount);

    string CloseNFReceipt();

    string Fiscalize(vector<unsigned char> password);

    string StartFMTest();

    string GetDrawerInfo();

    string GetLastDocumentInfo(bool lastZ);

    string GetServiceCode();

    string InterruptReport();

    string OpenDrawer();

    string SaveNetworkSettings(vector<unsigned char> ip, vector<unsigned char> subnet, vector<unsigned char> gateway);

    string SetEJLimit(int index);

    string StartEJ();

    string StartFM(int fiscalNo);

    string StartNFReceipt();

    string StartNFDocument(int documentType);

    string TransferFile(string fileName);

    string WriteNFLine(vector<string> lines);

    string GetPrinterDate();

    ProgramOption ParsePrmOption(vector<unsigned char> data);

    string SendReport(Command command, vector<unsigned char> buffer);

    string PrintEJReport(int firstZNo, int firstDocId, int lastZNo, int lastDocId, int copy);

	string SendCommand(Command command, vector<unsigned char> data);

    vector<unsigned char> ConvertAddIp(vector<unsigned char> ipAddr);

	FPUResponse Send(FPURequest request);

    void SetLog(FPURequest request, FPUResponse response);

    wstring GetLastLog();

  //  string PrintPaymentByEFT(double paidTotal, int installment);

	string GetEFTAuthorisation(double amount, int installment, vector<unsigned char> cardNumber);

	string PrintSystemInfoReport(int copy);

	string PrintReceiptTotalReport(int copy);
};

