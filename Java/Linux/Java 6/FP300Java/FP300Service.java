package Hugin;

import java.util.*;

public class FP300Service {
	static {
		System.loadLibrary("printerlib"); // libprinterlib.so (Unixes)
	}
 
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
	public native String PrintParkDocument(String plate, DateTime entrenceDate);
	public native String PrintItem(int PLUNo, double quantity, double amount, String name, 
		int deptId, int weighable);
	public native String PrintAdjustment(int adjustmentType, double amount, int percentage);
	public native String Correct();
	public native String Void(int PLUNo, double quantity);
	public native String PrintSubtotal(boolean isQuery);
	public native String PrintPayment(int paymentType, int index, double paidTotal);
	public native String CloseReceipt(boolean slipCopy);
	public native String VoidReceipt();
	public native String PrintRemarkLine(String line);
	public native String PrintReceiptBarcode(String barcode);
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
	//public native String PrintPaymentByEFT(double paidTotal, int installment);
	public native String PrintSystemInfoReport(int copy);
	public native String PrintReceiptTotalReport(int copy);
	public native String VoidPayment(int paymentSequenceNo);
	public native String PrintJSONDocumentDeptOnly(String jsonStr);
	public native String PrintDepartment(int deptId, double quantity, double amount, String name, int weighable);
	public native String VoidDepartment(int deptId, String deptName, double quantity);
	public native String GetEFTCardInfo(double amount);
	public native String VoidEFTPayment(int acquierID, int batchNo, int stanNo);
	public native String RefundEFTPayment(int acquierID);
	public native String GetBankListOnEFT();
	public native String GetSalesInfo();

	public DateTime GetNewDateTime() { return new DateTime(); }

	public static void main(String[] args) 
	{
		FP300Service fp300Service = new FP300Service();

		Scanner key = new Scanner(System.in);
		
		System.out.print("1-TCP/IP\n");
		System.out.print("2-Serial Port\n");
		System.out.print("Your choice: ");
		int tcp = key.nextInt();

		String IpAddress = "207.46.128.217";
		switch(tcp)
		{
			case 1:
				System.out.print("IP Address(207.46.128.217): ");
				IpAddress = key.next();
				System.out.print("Connecting to server(" + IpAddress + ":5555)...");
				if(fp300Service.TCPConnect(IpAddress, 5555)) System.out.println("OK\n");
				else
				{
					System.out.println("Failed");
					return;
				}
				break;
			default:
				System.out.print("Port Name(COM3): ");
				String portName = key.next();
				System.out.print("Connecting to server(" + portName + ":115200)...");
				if(fp300Service.SerialConnect(portName, 115200)) System.out.println("OK\n");
				else
				{
					System.out.println("Failed");
					return;
				}
		}

		DeviceInfo serverInfo = new DeviceInfo();
        serverInfo.Brand = "HUGIN";
        serverInfo.IP = IpAddress;
        serverInfo.Model = "HUGIN COMPACT";
        serverInfo.Port = 5555;
        serverInfo.TerminalNo = "FP00000010";
        serverInfo.Version = "";
        serverInfo.SerialNum  = "";

		System.out.print("Connecting to printer...");
        if (fp300Service.Connect(serverInfo, "FP00000010", "")) System.out.println("OK\n");
		else
		{
			System.out.println("Failed");
			return;
		}

		System.out.println("Tesing CheckPrinterStatus()...");
		System.out.println(fp300Service.CheckPrinterStatus());
		System.out.println(fp300Service.GetLastLog() + "\n");

		System.out.println("Tesing SignInCashier(6, 1357)...");
		System.out.println(fp300Service.SignInCashier(6, "1357"));
		System.out.println(fp300Service.GetLastLog() + "\n");

		System.out.println("Tesing Cash_In(amount)...");
		System.out.print("Amount: ");
		double amount = key.nextDouble();
		fp300Service.CashIn(amount);
		System.out.println(fp300Service.GetLastLog() + "\n");

		int tmp = fp300Service.GetTimeout();
		System.out.println("Get Report?");
		System.out.println("1-X Report");
		System.out.println("2-Z Report");
		System.out.print("Input: ");
		int dec = key.nextInt();

		fp300Service.SetFPUTimeout(30000);
		if(dec == 1)
		{
			fp300Service.PrintXReport(2);
			System.out.println(fp300Service.GetLastLog() + "\n");
		} 
		if(dec == 2)
		{
			fp300Service.PrintZReport();
			System.out.println(fp300Service.GetLastLog() + "\n");
		}
		fp300Service.SetFPUTimeout(tmp);
	
		while(true)
		{
			System.out.println("0 - EXIT");
			System.out.println("1 - Start Receipt");
			System.out.println("2 - Sale Product");
			System.out.println("3 - Adjust Product");
			System.out.println("4 - Pay");
			System.out.println("5 - Close Receipt");

			dec = key.nextInt();
			if(dec == 0)
				break;
			switch(dec)
			{
				case 1:
					fp300Service.PrintDocumentHeader();
					System.out.println(fp300Service.GetLastLog() + "\n");	
					break;
				case 2:
					fp300Service.PrintItem(1, 15, 3.00, "SAMPLE PRODUCT", 1, 1);
					System.out.println(fp300Service.GetLastLog() + "\n");	
					break;
				case 3:
					fp300Service.PrintAdjustment(1, 0.15, 5);
					System.out.println(fp300Service.GetLastLog() + "\n");	
					break;
				case 4:
					fp300Service.PrintPayment(0, -1, 10.00);
					System.out.println(fp300Service.GetLastLog() + "\n");	
					break;
				case 5:
					fp300Service.CloseReceipt(false);
					System.out.println(fp300Service.GetLastLog() + "\n");	
					break;
			}

		}
	}
};

class DeviceInfo {
	public String IP;
	public int Port;
	public String TerminalNo;
	public String SerialNum;
	public String Model;
	public String Brand;
	public String Version;
};

class DateTime
{
	public int Year = 1;
	public int Month = 0;
	public int Day = 1;
	public int Hour = 0;
	public int Minute = 0;
	public int Second = 0;
	
	DateTime() { }

	DateTime(Calendar calendar)
	{
		Year = calendar.get(Calendar.YEAR);
		Month = calendar.get(Calendar.MONTH);
		Day = calendar.get(Calendar.DAY_OF_MONTH);
		Hour = calendar.get(Calendar.HOUR);
		Minute = calendar.get(Calendar.MINUTE);
		Second = calendar.get(Calendar.SECOND);
	}

	Calendar ToCalendar()
	{
		return new GregorianCalendar(Year,Month,Day,Hour,Minute,Second);
	}
};
