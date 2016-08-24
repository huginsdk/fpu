package Hugin.Test;

import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.Scanner;
import java.io.FileInputStream;
import java.util.Date;

import Hugin.DeviceInfo;
import Hugin.FP300Service;
import Hugin.Utility;

public class ECRTest {

  public static void main(String[] args) {
    FP300Service fp300Service = new FP300Service();

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
        if (fp300Service.TCPConnect(IpAddress, 5555)) System.out.println("OK\n");
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
    serverInfo.Port = 5555;
    serverInfo.TerminalNo = "FP11004397";
    serverInfo.Version = "";
    serverInfo.SerialNum = "";

    System.out.print("Connecting to printer...");
    if (fp300Service.Connect(serverInfo, serverInfo.TerminalNo, "")) System.out.println("OK\n");
    else {
      System.out.println("Failed");
      return;
    }

    System.out.println("Tesing CheckPrinterStatus()...");
    System.out.println(fp300Service.CheckPrinterStatus());
    System.out.println(fp300Service.GetLastLog() + "\n");

    System.out.println("Tesing SignInCashier(6, 1357)...");
    System.out.println(fp300Service.SignInCashier(6, "1357"));
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
        System.out.println(indx++ + " - START DOCUMENT");
		
		System.out.print("Select Menu : ");
        dec = key.nextInt();
        if (dec == 0)
          break;
        switch (dec) {
          case 1:
            response = fp300Service.PrintDocumentHeader();
            break;
          case 2:
            response = fp300Service.PrintItem(1, 15, 3.00, "SAMPLE PRODUCT", 1, 1);
            break;
          case 3:
            System.out.print("Price: ");
            int deptPrice = key.nextInt();
            response = fp300Service.PrintDepartment(1, 5, deptPrice, "SAMPLE DEPARTMENT", 1);
            break;
          case 4:
            response = fp300Service.PrintJSONDocumentDeptOnly(readFile("order.txt"));
            break;
          case 5:
            response = fp300Service.PrintAdjustment(1, 0.15, 5);
            break;
          case 6: //PAY
            System.out.print("Amount: ");
            int amount = key.nextInt();
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
            //System.out.print("Enter Remark: ");
			String s = "ğüşiöçĞÜŞİÖÇ";//key.next();
										
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
            response = fp300Service.LoadGraphicLogo(readFileAllBytes("logo1.bmp"));
			break;	
		case 16:
            System.out.print("1-Invoice\n2-E-Invoice\n3- E-Archive\n4-Food\n5-Parking\n6-Advenced Payment\nDocType : ");
            int docType = key.nextInt();
            //response = fp300Service.PrintDocumentHeader(docType, "11111111111", "HG-125789", fp300Service.GetNewDateTime());
			response = fp300Service.PrintAdvanceDocumentHeader("11111111111", "CENK TOSUN", 5);
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
																	"REMARK LINE 4"}));
	}
	/**/
	if(0 == res)
	{
		res = getErrorCode(fp300Service.PrintReceiptBarcode("123456789012"));
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