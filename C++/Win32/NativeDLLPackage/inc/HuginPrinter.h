
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
#include "Logger.h"

using namespace Hugin::GMPCommon;

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
#include <unistd.h>
typedef unsigned char byte;

#endif

using namespace std;

class UsbInfo;

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

#ifdef HUGINAPI
class HUGINAPI HuginPrinter
#else
class HuginPrinter
#endif
{
private:
	DevInfo devInfo;
	string licanceKey;
	Connection* connection;
    MatchingState matchState;
    wstring currentLog;
    string FiscalRegisterNo;
	bool onReporting;

	vector<unsigned char> EncapsulateMessage(int msgType, vector<unsigned char> reqPacket);
    void SendMessage(GMPMessage* msg);
	vector<unsigned char> FormatFPUMessage(GMPMessage* msg);
    vector<unsigned char> Read();
	vector<unsigned char> read();
	int Send( vector<unsigned char> buffer );

public:
	HuginPrinter(void);
	void DeviceAdded(UsbInfo& dev);
	void DeviceRemoved(const string& DevNode);
	~HuginPrinter(void);
	

	string LibraryVersion();
	void SetDebugLevel(Logger::LogLevel level);
	void SetDebugFolder(string folderPath);

	bool SerialConnect(string portName, int baudRate);
	bool TcpConnect(string ip, int port);
	bool MatchExDevice(DevInfo devInfo, string fiscalNo);
	int GetTimeout();
    void SetTimeout(int timeout);
	bool IsConnected();
	void Disconnect();
	bool Connect(DevInfo devInfo, string fiscalRegNo, string licanceKey);

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
	string GetProgramOptions(int progEnum);
	string SaveProgramOptions(int progEnum, vector<unsigned char> progValue);
	string SaveGMPConnectionInfo(vector<unsigned char> ip, int port);
    
    string PrintDocumentHeader();
    string PrintDocumentHeader(vector<unsigned char> tckn_vkn, double amount, int docType);
	string PrintDocumentHeader(int docType, string tckn_vkn, string docSerial, tm docDateTime);
	string PrintParkDocument(vector<unsigned char> plate, tm entrenceDate);
	string PrintAdvanceDocumentHeader(string tckn, string name, double amount);
	string PrintCollectionDocumentHeader(string invoiceSerial, tm invoiceDate, double amount, string subscriberNo, string institutionName, double comissionAmount);
	string PrintFoodDocumentHeader();

    string PrintItem(int PLUNo, double quantity, double amount, vector<unsigned char> name, vector<unsigned char> barcode, int deptId, int weighable);
    string PrintItems(vector<JSONItem3> itemList);
	string PrintDeptItems(vector<JSONItem3> itemList);
	string PrintDepartment(int deptId, double quantity, double amount, string name, int weighable);
	string VoidDepartment(int deptId, string deptName, double quantity);
    string PrintAdjustment(int adjustmentType, double amount, int percentage);
    string Correct();
    string Void(int PLUNo, double quantity);
    string PrintSubtotal(bool isQuery);
    string PrintPayment(int paymentType, int index, double paidTotal);
    string VoidPayment(int paymentSequenceNo);
    string CloseReceipt(bool slipCopy);
    string VoidReceipt();

    string PrintRemarkLine(vector<string> line);
	string PrintRemarkLine( vector<vector<byte> > lines );
    string PrintReceiptBarcode(vector<unsigned char> barcode);
    string PrintReceiptBarcode(int barcodeType, vector<unsigned char> barcode);

    string PrintJSONDocument(JSONDocument3 jsonDoc);
	string PrintJSONDocument(string json);	
	string PrintJSONDocumentDeptOnly(const JSONDocument3& jsonDoc);
	string PrintJSONDocumentDeptOnly(string jsonStr);
	string PrintSalesDocument(string jsonStr);

    string PrintXReport(int copy);
    string PrintXPluReport(int firstPlu, int lastPlu, int copy);
    string PrintZReport();
    string PrintPeriodicZZReport(int firstZ, int lastZ, int copy, bool detail);
    string PrintPeriodicDateReport(tm firstDay, tm lastDay, int copy, bool detail);
    string PrintEJPeriodic(tm day, int copy);
    string PrintEJPeriodic(tm startTime, tm endTime, int copy);
    string PrintEJPeriodic(int ZStartId, int docStartId, int ZEndId, int docEndId, int copy);
    string PrintEJDetail(int copy);
	string PrintEndDayReport();
	string PrintEJReport(int firstZNo, int firstDocId, int lastZNo, int lastDocId, int copy);
	string PrintSystemInfoReport(int copy);
	string PrintReceiptTotalReport(int copy);


    string EnterServiceMode(vector<unsigned char> password);
    string ExitServiceMode(vector<unsigned char> password);

    string ClearDailyMemory();
    string FactorySettings();
    string CloseFM();
    string SetExternalDevAddress(vector<unsigned char> ip, int port);
    string UpdateFirmware(vector<unsigned char> ip, int port);

    string PrintLogs(tm date);

    string CreateDB();


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

	string ClearError();
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

	string SendCommand(Command command, vector<unsigned char> data);

    vector<unsigned char> ConvertAddIp(vector<unsigned char> ipAddr);

	FPUResponse Send(FPURequest request);

    void SetLog(FPURequest request, FPUResponse response);

    wstring GetLastLog();

   string LoadGraphicLogo(const vector<byte>& monoChromeBitmapData);
		
	
	
	string GetEFTAuthorisation(double amount, int installment, vector<unsigned char> cardNumber);
	string GetEFTCardInfo(double amount);
	string VoidEFTPayment(int acquierID, int batchNo, int stanNo);
	string RefundEFTPayment(int acquierID);
	string RefundEFTPayment(int acquierID, double amount);
	string GetEFTSlipCopy(int acquierID, int batchNo, int stanNo, int zNo, int receiptNo);
	string GetBankListOnEFT();
	
	string GetSalesInfo();	
};

