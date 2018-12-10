package Hugin.Test;

import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.Scanner;
import java.io.FileInputStream;
import java.util.Calendar;
import java.io.BufferedReader;

import Hugin.DeviceInfo;
import Hugin.FP300Service;
import Hugin.Utility;
import Hugin.DateTime;

public class ECRTest {

  public static void main(String[] args) {
    FP300Service fp300Service = new FP300Service();

	// Get the version of the library
	System.out.println("**************************");
	System.out.println("Library version : " + fp300Service.LibraryVersion());	
	System.out.println("**************************");
	
    Scanner key = new Scanner(System.in);

    System.out.print("1-TCP/IP\n");
    System.out.print("2-Serial Port\n");
    System.out.print("Your choice: ");
    int tcp = key.nextInt();

    String IpAddress = "207.46.128.217";
	int port = 4444;
    switch (tcp) {
      case 1:
        System.out.print("IP Address(207.46.128.217): ");
        IpAddress = key.next();
		System.out.print("Port: ");
		port = key.nextInt();

        System.out.print("Connecting to server(" + IpAddress + ":"+port+")...");
        if (fp300Service.TCPConnect(IpAddress, port)) System.out.println("OK\n");
        else {
          System.out.println("Failed");
          return;
        }
        break;
      default:
        System.out.print("Port Name(Ex. COM3): ");
        String portName = key.next();
        System.out.print("Connecting to server(" + portName + ":115200)...");
        if (fp300Service.SerialConnect(portName, 115200)) System.out.println("OK\n");
        else {
          System.out.println("Failed");
          return;
        }
    }

    System.out.print("Enter Fiscal Id: ");
    String fiscalId= key.next();
    
    DeviceInfo serverInfo = new DeviceInfo();
    serverInfo.Brand = "HUGIN";
    serverInfo.IP = IpAddress;
    serverInfo.Model = "HUGIN COMPACT";
    serverInfo.Port = 5555;
    serverInfo.TerminalNo = fiscalId;// "FP11004397";
    serverInfo.Version = "";
    serverInfo.SerialNum = "";

    fp300Service.SetDebugLevel(FP300Service.LogLevel.HIDE_BUG.getValue());

    System.out.print("Connecting to printer... : " + serverInfo.TerminalNo);

    if (fp300Service.Connect(serverInfo, serverInfo.TerminalNo, "")) 
  	{
  		System.out.println(" OK\n");
  	}
    else 
	{
      System.out.println(" Failed");
	  System.out.println(fp300Service.GetLastLog());
      return;
    }

    System.out.println("CheckPrinterStatus()...");
    System.out.println(fp300Service.CheckPrinterStatus());
    System.out.println(fp300Service.GetLastLog() + "\n");

    System.out.println("SignInCashier(9, 14710)...");
    System.out.println(fp300Service.SignInCashier(9, "14710"));
    System.out.println(fp300Service.GetLastLog() + "\n");
    int dec;
/*
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
		dec = key.nextInt();

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
	*/

    while (true) {
      int indx = 0;
      String response = "";

      try {
        System.out.println(indx++ + " - EXIT");
        System.out.println(indx++ + " - START RECEIPT");
        System.out.println(indx++ + " - SALE PRODUCT");
        System.out.println(indx++ + " - SALE DEPARTMENT");
        System.out.println(indx++ + " - SALE FROM JSON FILE");
        System.out.println(indx++ + " - ADJUST PRODUCT");
        System.out.println(indx++ + " - PAY");
        System.out.println(indx++ + " - PAY by EFT-POS(with params)");
        System.out.println(indx++ + " - CLOSE RECEIPT");
        System.out.println(indx++ + " - VOID RECEIPT");
        System.out.println(indx++ + " - PRINT REMARK");
        System.out.println(indx++ + " - CLEAR ERROR");
        System.out.println(indx++ + " - CHECK PRINTER STATUS");
        System.out.println(indx++ + " - PRINT SUBTOTAL");
        System.out.println(indx++ + " - AUTO ORDER TEST");
        System.out.println(indx++ + " - LOAD GRAPHIC LOGO");
        System.out.println(indx++ + " - PAIR with NGCR");
        System.out.println(indx++ + " - EFT: VOID PAYMENT");
        System.out.println(indx++ + " - EFT: REFUND PAYMENT");
        System.out.println(indx++ + " - EFT: GET BANK LIST");
        System.out.println(indx++ + " - EFT: END DAY REPORT");
        System.out.println(indx++ + " - PRINT RECEIPT BARCODE");
		System.out.println(indx++ + " - GET DRAWER INFO");
		System.out.println(indx++ + " - GET CREDITS");
		System.out.println(indx++ + " - GET VAT RATES");
		System.out.println(indx++ + " - STRESS TEST (DRAWER INFO)");
		System.out.println(indx++ + " - PRINT X REPORT");
		System.out.println(indx++ + " - PRINT Z REPORT");
		System.out.println(indx++ + " - PRINT DOCUMENT HEADER");
		System.out.println(indx++ + " - PAY by EFT-POS(with no card number)");
		System.out.println(indx++ + " - PRINT JSON SALE DOCUMENT (DEPT)");
		System.out.println(indx++ + " - PAY WITH CREDIT");
		System.out.println(indx++ + " - EFT: GET SLIP COPY");
		
		System.out.print("Select Menu : ");
        dec = key.nextInt();
        if (dec == 0)
          break;
        switch (dec) {
          case 1:
            response = fp300Service.PrintDocumentHeader();
            break;
          case 2:
            response = fp300Service.PrintItem(1, 15, 3.00, "SAMPLE PRODUCT", "", 1, 1);
            break;
          case 3:
            System.out.print("Price: ");
            double deptPrice = key.nextDouble();
            response = fp300Service.PrintDepartment(1, 1, deptPrice, "SAMPLE DEPARTMENT", 1);
            break;
          case 4:
            response = fp300Service.PrintJSONDocumentDeptOnly(readFile("./samples/order.txt"));
            break;
          case 5:
            response = fp300Service.PrintAdjustment(1, 0.15, 5);
            break;
          case 6: //PAY
            System.out.print("Amount: ");
            double amount = key.nextDouble();
            response = fp300Service.PrintPayment(0, -1, amount);
            break;
			
          case 7: //PAY BY CREDIT
            System.out.print("Amount: ");
            double ccAmount = key.nextDouble();

			System.out.print("Installment: ");
			int installment = key.nextInt();

			System.out.print("Card Number: ");
			String cn = key.next();

            response = fp300Service.GetEFTAuthorisation(ccAmount, installment, cn);

            break;
          case 8:
            response = fp300Service.CloseReceipt(false);
            break;
          case 9:
            response = fp300Service.VoidReceipt();
            break;
          case 10:
			response = fp300Service.PrintRemarkLine(new String[]{"REMARK LINE 1",
																	"REMARK LINE 2",
																	"REMARK LINE 3",
																	"REMARK LINE 3",
																	"REMARK LINE 3",
																	"REMARK LINE 3",
																	"REMARK LINE 3",
																	"REMARK LINE 4"});
            break;
          case 11:
            response = fp300Service.ClearError();
            break;
          case 12:
            response = fp300Service.CheckPrinterStatus();
            break;
          case 13:
            response = fp300Service.PrintSubtotal(true);
            break;			
          case 14:
		  int autoOrderRes=0;
		  int loopCount =1;
		    while(autoOrderRes == 0)
			{
				System.out.println("Count :" + loopCount);
				autoOrderRes = testOrder(fp300Service);
				try {
				  Thread.sleep(200);
				} catch (InterruptedException ie) {
					//Handle exception
				}
				loopCount++;
			}
            break;			
		case 15:
            response = fp300Service.LoadGraphicLogo(readFileAllBytes("./samples/logo1.bmp"));
			break;	
		case 16:
		    System.out.println("Pairing with " + serverInfo.TerminalNo);
			if (fp300Service.Connect(serverInfo, serverInfo.TerminalNo, "")) 
				System.out.println("OK\n");
			else 
			  System.out.println("Failed");
		  
			break;
    
    case 17:

            System.out.print("Enter Acquirer ID: ");
            int voidAcquirerId = key.nextInt();
            System.out.print("Enter Batch No: ");
            int batch = key.nextInt();
            System.out.print("Enter Stan No: ");
            int stan = key.nextInt();
            response = fp300Service.VoidEFTPayment(voidAcquirerId, batch, stan);
      break;      
    case 18:
            System.out.print("Enter Acquirer ID: ");
            int refundAcquirerId = key.nextInt();
            System.out.print("Enter Amount: ");
            double eftRefundAmount = key.nextDouble();
            response = fp300Service.RefundEFTPayment(refundAcquirerId, eftRefundAmount);
      break; 
    case 19:
            response = fp300Service.GetBankListOnEFT();
      break;  
    case 20:
            response = fp300Service.PrintEndDayReport();
      break;  
    case 21:          
            System.out.print("Barcode Type: ");
            int barcodeType = key.nextInt();
            System.out.print("Barcode: ");
            String barcode = key.next();
            response = fp300Service.PrintReceiptBarcode(barcodeType, barcode);
      break;  
	case 22:
			response = fp300Service.GetDrawerInfo();
	  break;
	case 23:
			response = fp300Service.GetCreditInfo(0);
			printResponse(response);
			response = fp300Service.GetCreditInfo(1);
			printResponse(response);
			response = fp300Service.GetCreditInfo(2);
			printResponse(response);
			response = fp300Service.GetCreditInfo(3);
			printResponse(response);
			response = fp300Service.GetCreditInfo(4);
			printResponse(response);
			response = fp300Service.GetCreditInfo(5);
			printResponse(response);
			response = fp300Service.GetCreditInfo(6);
			printResponse(response);
			response = fp300Service.GetCreditInfo(7);
	  break;
	case 24:
			response = fp300Service.GetVATRate(0);
			printResponse(response);
			response = fp300Service.GetVATRate(1);
			printResponse(response);
			response = fp300Service.GetVATRate(2);
			printResponse(response);
			response = fp300Service.GetVATRate(3);
			printResponse(response);
			response = fp300Service.GetVATRate(4);
			printResponse(response);
			response = fp300Service.GetVATRate(5);
			printResponse(response);
			response = fp300Service.GetVATRate(6);
			printResponse(response);
			response = fp300Service.GetVATRate(7);
	  break;
	case 25:
			//System.out.print("VAT index: ");
            //int VATIndx = key.nextInt();
			System.out.print("Loop Count: ");
            int count = key.nextInt();

			for (int i = 0;i<count ;i++ ) {
				System.out.println("*** " + (i+1) + " ***");
				System.out.println("---------------------");
				response = fp300Service.GetDrawerInfo();
				printResponse(response);
				System.out.println(" ");
            }

	  break;
	case 26:
			response = fp300Service.PrintXReport(3);
	  break;
	case 27:
			response = fp300Service.PrintZReport();
	  break;
	case 28:
			System.out.print("Document Type: ");
			int dType = key.nextInt();

			System.out.print("TCKN/VKN: ");
			String tcknVkn = key.next();

			System.out.print("Document Serial: ");
			String serial = key.next();
			//String serial = "";
			DateTime dt = new DateTime(Calendar.getInstance());
			response = fp300Service.PrintDocumentHeader(dType, tcknVkn, serial, dt);
      break;
	  case 29: //PAY BY CREDIT
            System.out.print("Amount: ");
            double a = key.nextDouble();

			System.out.print("Installment: ");
			int i = key.nextInt();

            response = fp300Service.GetEFTAuthorisation(a, i, "");
        break;
	case 30:
			String jsonStr = "{\"FiscalItems\":[{\"Id\":20,\"Quantity\":1.0,\"Price\":25.75,\"Name\":\"KITAP\",\"DeptId\":4,\"Status\":0,\"Adj\":{\"Type\":2,\"Amount\":20.0,\"percentage\":0,\"NoteLine1\":null,\"NoteLine2\":null},\"NoteLine1\":\"## 000020\",\"NoteLine2\":null},{\"Id\":20,\"Quantity\":1.0,\"Price\":25.0,\"Name\":\"KITAP\",\"DeptId\":4,\"Status\":0,\"Adj\":null,\"NoteLine1\":\"## 000020\",\"NoteLine2\":null},{\"Id\":26,\"Quantity\":20.0,\"Price\":4.5,\"Name\":\"LARK\",\"DeptId\":1,\"Status\":0,\"Adj\":null,\"NoteLine1\":\"## 000026\",\"NoteLine2\":null}],\"Adjustments\":[{\"Type\":2,\"Amount\":18.0,\"percentage\":0,\"NoteLine1\":null,\"NoteLine2\":null}],\"Payments\":[{\"Type\":0,\"Index\":0,\"PaidTotal\":200.25,\"viaByEFT\":false,\"SequenceNo\":0}],\"FooterNotes\":[\"URUN INDIRIMI  :   *20,00\",\"ARATOP INDIRIMI:   *18,00\",\"TOPLAM INDIRIM : *38,00\"],\"EndOfReceiptInfo\":{\"CloseReceiptFlag\":true,\"BarcodeFlag\":false,\"Barcode\":null}}";

			System.out.print("CHECK CODE: 11 ");
			System.out.print("Yazdiriliyor...:  " + jsonStr);
			response = fp300Service.PrintJSONDocumentDeptOnly(jsonStr);

		
		break;
	case 31:
			System.out.print("Credit Index: ");
			int creditIdx = key.nextInt();

			System.out.print("Amount: ");
			double creditAmount = key.nextDouble();

			response = fp300Service.PrintPayment(1, creditIdx, creditAmount);
			
		break;
	case 32:
			System.out.print("Acquier ID: ");
			int acquierID = key.nextInt();

			System.out.print("Batch No: ");
			int batchNo = key.nextInt();

			System.out.print("Stan No: ");
			int stanNo = key.nextInt();

			System.out.print("Z No: ");
			int zNo = key.nextInt();

			System.out.print("docNo No: ");
			int docNo = key.nextInt();

			response = fp300Service.GetEFTSlipCopy(acquierID, batchNo, stanNo, zNo, docNo);
			
		break;
        }

        printResponse(response);

      } catch (Exception ex) {
        System.out.println(ex.getMessage() + "\n");
        ex.printStackTrace();
      }
    }

  }
  
  private static int testOrder(FP300Service fp300Service)
  {
	int res = getErrorCode(fp300Service.CheckPrinterStatus());

	if(0 == res)
	{
		res = getErrorCode(fp300Service.PrintDocumentHeader());
	}
	if(0 == res)
	{
		res = getErrorCode(fp300Service.PrintDepartment(1, 1, 12.25, "DEPT 1", 1));
	}
	
	if(0 == res)
	{
		res = getErrorCode(fp300Service.PrintDepartment(2, 1, 14.25, "DEPT 2", 1));
	}
	
	if(0 == res)
	{
		res = getErrorCode(fp300Service.PrintDepartment(3, 2, 16.25, "DEPT 3", 1));
	}
	if(0 == res)
	{
		res = getErrorCode(fp300Service.PrintDepartment(4, 1, 18.25, "DEPT 4", 1));
	}
	if(0 == res)
	{
		res = getErrorCode(fp300Service.PrintAdjustment(1, 0.15, 5));
	}
	if(0 == res)
	{
		res = getErrorCode(fp300Service.PrintPayment(0, -1, 78.16));
	}
	if(0 == res)
	{
		res = getErrorCode(fp300Service.PrintRemarkLine(new String[]{"REMARK LINE 1",
																	"REMARK LINE 2",
																	"REMARK LINE 3",
																	"REMARK LINE 3"}));
	}
	
	if(0 == res)
	{
		res = getErrorCode(fp300Service.PrintReceiptBarcode("123456789000"));
	}
	
	if(0 == res)
	{
		res = getErrorCode(fp300Service.CloseReceipt(false));
	}
	
      System.out.println("Error Code    : " + Utility.GetErrorMessage(res));
	  
	  return res;
  }
  
  private static int getErrorCode(String response) {
	int res = 6;
    String[] splitted = response.split("\\|", 0);
    if (splitted.length >= 2) {
		res = Integer.parseInt(splitted[0]);
    }
	
	return res;
  }
  
  private static int printResponse(String response) {
	int res = 6;
    String[] splitted = response.split("\\|", 0);
    if (splitted.length >= 2) {
		res = Integer.parseInt(splitted[0]);
      System.out.println("Error Code    : " + Utility.GetErrorMessage(res));
      System.out.println("State         : " + Utility.GetStateMessage(Integer.parseInt(splitted[1])));
    }

    System.out.println("Full Response : " + response);
	return res;
  }

  private static String readFile(String fileName) {
    String content = null;
    File file = new File(fileName); //for ex foo.txt
    FileReader reader;

    try {
      reader = new FileReader(file);
      char[] chars = new char[(int) file.length()];
      reader.read(chars);
      content = new String(chars);
      reader.close();
    } catch (IOException e) {
      e.printStackTrace();
    }
    return content;
  }
  
  	private static byte[] readFileAllBytes(String fileName)
	{
		byte [] content = null;
		try {
			File file = new File(fileName);
			content = new byte[(int) file.length()];
			FileInputStream fileStream=new FileInputStream(file);
			
			fileStream.read(content,0,content.length);
			fileStream.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
		return content;
	} 
}
