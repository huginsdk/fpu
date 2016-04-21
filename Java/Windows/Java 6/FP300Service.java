import java.util.*;

public class FP300Service {
	static {
		System.loadLibrary("printerlib"); // libprinterlib.so (Unixes)
	}
 
	private native boolean SerialConnect(String portName, int baudRate);
	private native boolean TCPConnect(String serverIp, int port);
	private native int GetTimeout();
	private native void SetFPUTimeout(int timeout);
	private native String SetDepartment(int id, String name, int vatId, double price, int weighable);
	private native String GetDepartment(int deptId);
	private native String SetCreditInfo(int id, String name);
	private native String GetCreditInfo(int id);
	private native String SetCurrencyInfo(int id, String name, double exchangeRate);
	private native String GetCurrencyInfo(int index);
	private native String SetMainCategory(int id, String name);
	private native String GetMainCategory(int mainCatId);
	private native String SetSubCategory(int id, String name, int mainCatId);
	private native String GetSubCategory(int subCatId);
	private native String SaveCashier(int id, String name, String password);
	private native String GetCashier(int cashierId);
	private native String SignInCashier(int id, String password);
	private native String CheckCashierIsValid(int id, String password);
	private native String GetLogo(int index);
	private native String SetLogo(int index, String line);
	private native DateTime GetDateTime();
	private native String SetDateTime(DateTime date, DateTime time);
	private native String GetVATRate(int index);
	private native String SetVATRate(int index, double taxRate);
	private native String SaveProduct(int productId, String productName, int deptId, double price,
		int weighable, String barcode, int subCatId);
	private native String GetProduct(int pluNo);
	private native String SaveGMPConnectionInfo(String ip, int port);
	private native String GetProgramOptions(int progEnum);
	private native String SaveProgramOptions(int progEnum, String progValue);
	private native String PrintDocumentHeader();
	private native String PrintDocumentHeader(String tckn_vkn, double amount, int docType);
	private native String PrintParkDocument(String plate, DateTime entrenceDate);
	private native String PrintItem(int PLUNo, double quantity, double amount, String name, 
		int deptId, int weighable);
	private native String PrintAdjustment(int adjustmentType, double amount, int percentage);
	private native String Correct();
	private native String Void(int PLUNo, double quantity);
	private native String PrintSubtotal(boolean isQuery);
	private native String PrintPayment(int paymentType, int index, double paidTotal);
	private native String CloseReceipt(boolean slipCopy);
	private native String VoidReceipt();
	private native String PrintRemarkLine(String line);
	private native String PrintReceiptBarcode(String barcode);
	private native String PrintXReport(int copy);
	private native String PrintXPluReport(int firstPlu, int lastPlu, int copy);
	private native String PrintZReport();
	private native String PrintPeriodicZZReport(int firstZ, int lastZ, int copy, boolean detail);
	private native String PrintPeriodicDateReport(DateTime firstDay, DateTime lastDay, int copy, boolean detail);
	private native String PrintEJPeriodic(DateTime day, int copy);
	private native String PrintEJPeriodic(DateTime startTime, DateTime endTime, int copy);
	private native String PrintEJPeriodic(int ZStartId, int docStartId, int ZEndId, int docEndId, int copy);
	private native String PrintEJDetail(int copy);
	private native String EnterServiceMode(String password);
	private native String ExitServiceMode(String password);
	private native String ClearDailyMemory();
	private native String FactorySettings();
	private native String CloseFM();
	private native String SetExternalDevAddress(String ip, int port);
	private native String UpdateFirmware(String ip, int port);
	private native String PrintLogs(DateTime date);
	private native String CreateDB();
	private native boolean Connect(DeviceInfo devInfo, String fiscalRegNo, String licanceKey);
	private native String CheckPrinterStatus();
	private native String GetLastResponse();
	private native String CashIn(double amount);
	private native String CashOut(double amount);
	private native String CloseNFReceipt();
	private native String Fiscalize(String password);
	private native String StartFMTest();
	private native String GetDrawerInfo();
	private native String GetLastDocumentInfo(boolean lastZ);
	private native String GetServiceCode();
	private native String InterruptReport();
	private native String OpenDrawer();
	private native String SaveNetworkSettings(String ip, String subnet, String gateway);
	private native String SetEJLimit(int index);
	private native String StartEJ();
	private native String StartFM(int fiscalNo);
	private native String StartNFReceipt();
	private native String StartNFDocument(int documentType);
	private native String TransferFile(String fileName);
	private native String WriteNFLine(String[] lines);
	private native String GetPrinterDate();
	private native String PrintEJReport(int firstZNo, int firstDocId, int lastZNo, int lastDocId, int copy);
	private native String GetLastLog();
	//private native String PrintPaymentByEFT(double paidTotal, int installment);
	private native String PrintSystemInfoReport(int copy);
	private native String PrintReceiptTotalReport(int copy);
	private native String VoidPayment(int paymentSequenceNo);
	private native String GetEFTAuthorisation(double amount, int installment, String cardNumber);

	private DateTime GetNewDateTime() { return new DateTime(); }

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
