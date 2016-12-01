package Hugin.Test;

import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.Scanner;
import java.io.FileInputStream;

import Hugin.DeviceInfo;
import Hugin.FP300Service;
import Hugin.Utility;

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
    switch (tcp) {
      case 1:
        System.out.print("IP Address(207.46.128.217): ");
        IpAddress = key.next();
        System.out.print("Connecting to server(" + IpAddress + ":5555)...");
        if (fp300Service.TCPConnect(IpAddress, 4444)) System.out.println("OK\n");
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

    DeviceInfo serverInfo = new DeviceInfo();
    serverInfo.Brand = "HUGIN";
    serverInfo.IP = IpAddress;
    serverInfo.Model = "HUGIN COMPACT";
    serverInfo.Port = 4444;
    serverInfo.TerminalNo = "FP11004397";
    serverInfo.Version = "";
    serverInfo.SerialNum = "";

    System.out.print("Connecting to printer... : " + serverInfo.TerminalNo);
    if (fp300Service.Connect(serverInfo, serverInfo.TerminalNo, "")) 
	{
		System.out.println(" OK\n");
	}
    else 
	{
      System.out.println(" Failed");
      return;
    }

    System.out.println("Tesing CheckPrinterStatus()...");
    System.out.println(fp300Service.CheckPrinterStatus());
    System.out.println(fp300Service.GetLastLog() + "\n");

    System.out.println("Tesing SignInCashier(9, 14710)...");
    System.out.println(fp300Service.SignInCashier(9, "14710"));
    System.out.println(fp300Service.GetLastLog() + "\n");
    int dec;

	fp300Service.SetDebugLevel(FP300Service.LogLevel.HIDE_BUG.getValue());

    while (true) {
      int indx = 0;
      String response = "";

      try {
        System.out.println(indx++ + " - EXIT");
        System.out.println(indx++ + " - START RECEIPT");
        System.out.println(indx++ + " - SALE PRODUCT");
        System.out.println(indx++ + " - Sale DEPARTMENT");
        System.out.println(indx++ + " - SALE FROM JSON FILE");
        System.out.println(indx++ + " - ADJUST PRODUCT");
        System.out.println(indx++ + " - PAY");
        System.out.println(indx++ + " - PAY by CREDIT CARD");
        System.out.println(indx++ + " - CLOSE RECEIPT");
        System.out.println(indx++ + " - VOID RECEIPT");
        System.out.println(indx++ + " - PRINT REMARK");
        System.out.println(indx++ + " - CLEAR ERROR");
        System.out.println(indx++ + " - CHECK PRINTER STATUS");
        System.out.println(indx++ + " - PRINT SUBTOTAL");
        System.out.println(indx++ + " - AUTO ORDER TEST");
        System.out.println(indx++ + " - LOAD GRAPHIC LOGO");
        System.out.println(indx++ + " - PAIR with NGCR");
        System.out.println(indx++ + " - PRINT Z REPORT");
        System.out.println(indx++ + " - SET RECEIPT LIMIT");
    
		System.out.print("Select Menu : ");
        dec = key.nextInt();
        if (dec == 0)
          break;
        switch (dec) {
          case 1: // Print Receipt Header
            response = fp300Service.PrintDocumentHeader();
            break;
          case 2: // Sale Product
            response = fp300Service.PrintItem(1, 15, 3.00, "SAMPLE PRODUCT", "", 1, 1);
            break;
          case 3: // Sale Department 
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
            response = fp300Service.GetEFTAuthorisation(ccAmount, 1, "");
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
            response = fp300Service.PrintZReport();
          break;

          case 18:
            double rcpLimit = key.nextDouble();
            response = fp300Service.SaveProgramOptions(2, rcpLimit);
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
  
  private static int getErrorCode(String response) 
  {
	int res = 6;
    String[] splitted = response.split("\\|", 0);
    if (splitted.length >= 2) {
		res = Integer.parseInt(splitted[0]);
    }
	
	return res;
  }
  
  private static int printResponse(String response) 
  {
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

  private static String readFile(String fileName) 
  {
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