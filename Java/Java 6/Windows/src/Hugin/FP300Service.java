package Hugin;

public class FP300Service {
	static {
 		if (System.getProperty("os.name", "generic").startsWith("Windows"))
 		{
 			System.loadLibrary("libgcc_s_dw2-1");
			System.loadLibrary("libstdc++-6");
			System.loadLibrary("libeay32");
			System.loadLibrary("ssleay32");
			System.loadLibrary("printerlib"); 
 		}
 		else		// (Unixes)  
 		{	
 			System.loadLibrary("printerlib"); 
 		}	
	}

		public enum LogLevel
		{
			FATAL		(1),
			ERROR		(2),
			WARN		(3),
			INFO		(4),
			DEBUG		(5),
			HIDE_BUG	(6);

			private int value;    

			private LogLevel(int value) {
				this.value = value;
			}

			public int getValue() {
				return value;
			}
		}
 
	public native void SetDebugLevel(int level);
	public native void SetDebugFolder(String path);
	public native String LibraryVersion();
	public native boolean SerialConnect(String portName, int baudRate);
	public native boolean TCPConnect(String serverIp, int port);
	public native int GetTimeout();
	public native void SetFPUTimeout(int timeout);
	public native String SetDepartment(int id, String name, int vatId, double price, int weighable);
	public native String GetDepartment(int deptId);
	public native String SetCreditInfo(int id, String name);
	public native String GetCreditInfo(int id);
	public native String SetCurrencyInfo(int id, String name, double exchangeRate);
	public native String GetCurrencyInfo(int index);
	public native String SetMainCategory(int id, String name);
	public native String GetMainCategory(int mainCatId);
	public native String SetSubCategory(int id, String name, int mainCatId);
	public native String GetSubCategory(int subCatId);
	public native String SaveCashier(int id, String name, String password);
	public native String GetCashier(int cashierId);
	public native String SignInCashier(int id, String password);
	public native String CheckCashierIsValid(int id, String password);
	public native String GetLogo(int index);
	public native String SetLogo(int index, String line);
	public native DateTime GetDateTime();
	public native String SetDateTime(DateTime date, DateTime time);
	public native String GetVATRate(int index);
	public native String SetVATRate(int index, double taxRate);
	public native String SaveProduct(int productId, String productName, int deptId, double price,
		int weighable, String barcode, int subCatId);
	public native String GetProduct(int pluNo);
	public native String SaveGMPConnectionInfo(String ip, int port);
	public native String GetProgramOptions(int progEnum);
	public native String SaveProgramOptions(int progEnum, String progValue);
	
	public native String PrintDocumentHeader();
	public native String PrintDocumentHeader(String tckn_vkn, double amount, int docType);
	public native String PrintDocumentHeader(int docType, String tckn_vkn, String docSerial, DateTime docDateTime);
	public native String PrintParkDocument(String plate, DateTime entrenceDate);
	public native String PrintAdvanceDocumentHeader(String tckn, String name, double amount);
	public native String PrintCollectionDocumentHeader(String invoiceSerial, DateTime invoiceDate, double amount, String subscriberNo, String institutionName, double comissionAmount);
	public native String PrintFoodDocumentHeader();

	public native String PrintItem(int PLUNo, double quantity, double amount, String name, String barcode,	int deptId, int weighable);
	public native String PrintAdjustment(int adjustmentType, double amount, int percentage);
	public native String Correct();
	public native String Void(int PLUNo, double quantity);
	public native String PrintSubtotal(boolean isQuery);
	public native String PrintPayment(int paymentType, int index, double paidTotal);
	public native String CloseReceipt(boolean slipCopy);
	public native String VoidReceipt();
	public native String PrintRemarkLine(String[] line);
	public native String PrintReceiptBarcode(String barcode);
	public native String PrintReceiptBarcode(int barcodeType, String barcode);
	public native String PrintXReport(int copy);
	public native String PrintXPluReport(int firstPlu, int lastPlu, int copy);
	public native String PrintZReport();
	public native String PrintPeriodicZZReport(int firstZ, int lastZ, int copy, boolean detail);
	public native String PrintPeriodicDateReport(DateTime firstDay, DateTime lastDay, int copy, boolean detail);
	public native String PrintEJPeriodic(DateTime day, int copy);
	public native String PrintEJPeriodic(DateTime startTime, DateTime endTime, int copy);
	public native String PrintEJPeriodic(int ZStartId, int docStartId, int ZEndId, int docEndId, int copy);
	public native String PrintEJDetail(int copy);
	public native String EnterServiceMode(String password);
	public native String ExitServiceMode(String password);
	public native String ClearDailyMemory();
	public native String FactorySettings();
	public native String CloseFM();
	public native String SetExternalDevAddress(String ip, int port);
	public native String UpdateFirmware(String ip, int port);
	public native String PrintLogs(DateTime date);
	public native String CreateDB();
	public native boolean Connect(DeviceInfo devInfo, String fiscalRegNo, String licanceKey);
	public native String CheckPrinterStatus();
	public native String GetLastResponse();
	public native String CashIn(double amount);
	public native String CashOut(double amount);
	public native String CloseNFReceipt();
	public native String Fiscalize(String password);
	public native String StartFMTest();
	public native String GetDrawerInfo();
	public native String GetLastDocumentInfo(boolean lastZ);
	public native String GetServiceCode();
	public native String InterruptReport();
	public native String ClearError();
	public native String OpenDrawer();
	public native String SaveNetworkSettings(String ip, String subnet, String gateway);
	public native String SetEJLimit(int index);
	public native String StartEJ();
	public native String StartFM(int fiscalNo);
	public native String StartNFReceipt();
	public native String StartNFDocument(int documentType);
	public native String TransferFile(String fileName);
	public native String WriteNFLine(String[] lines);
	public native String GetPrinterDate();
	public native String PrintEJReport(int firstZNo, int firstDocId, int lastZNo, int lastDocId, int copy);
	public native String GetLastLog();
	public native String PrintSystemInfoReport(int copy);
	public native String PrintReceiptTotalReport(int copy);
	public native String VoidPayment(int paymentSequenceNo);
	public native String GetEFTAuthorisation(double amount, int installment, String cardNumber);
   public native String PrintJSONDocumentDeptOnly(String jsonStr);
   public native String PrintDepartment(int deptId, double quantity, double amount, String name, int weighable);
   public native String VoidDepartment(int deptId, String deptName, double quantity);
   public native String GetEFTCardInfo(double amount);
   public native String VoidEFTPayment(int acquierID, int batchNo, int stanNo);
   public native String RefundEFTPayment(int acquierID);
   public native String RefundEFTPayment(int acquierID, double amount);
   public native String GetEFTSlipCopy(int acquierID, int batchNo, int stanNo, int zNo, int receiptNo);
   public native String GetBankListOnEFT();
   public native String GetSalesInfo();
   public native String PrintEndDayReport();
	public DateTime GetNewDateTime() { return new DateTime(); }
	public native String LoadGraphicLogo(byte[] monochromeBitmapData);
   
};

