package Hugin.Test;

import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.Scanner;

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
    serverInfo.TerminalNo = "FP00000010";
    serverInfo.Version = "";
    serverInfo.SerialNum = "";

    System.out.print("Connecting to printer...");
    if (fp300Service.Connect(serverInfo, "FP00000010", "")) System.out.println("OK\n");
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
        System.out.println(indx++ + " - Start Receipt");
        System.out.println(indx++ + " - Sale Product");
        System.out.println(indx++ + " - Sale Department");
        System.out.println(indx++ + " - Sale from JSON File");
        System.out.println(indx++ + " - Adjust Product");
        System.out.println(indx++ + " - Pay");
        System.out.println(indx++ + " - Close Receipt");
        System.out.println(indx++ + " - Void Receipt");
        System.out.println(indx++ + " - Print Remark");
        System.out.println(indx++ + " - Clear Error");
        System.out.println(indx++ + " - Check Printer Status");
        System.out.println(indx++ + " - Print Subtotal");

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
            response = fp300Service.PrintDepartment(1, 1, deptPrice, "SAMPLE DEPARTMENT", 1);
            break;
          case 4:
            response = fp300Service.PrintJSONDocumentDeptOnly(readFile("order.txt"));
            break;
          case 5:
            response = fp300Service.PrintAdjustment(1, 0.15, 5);
            break;
          case 6:
            System.out.print("Amount: ");
            int amount = key.nextInt();
            response = fp300Service.PrintPayment(0, -1, amount);
            break;
          case 7:
            response = fp300Service.CloseReceipt(false);
            break;
          case 8:
            response = fp300Service.VoidReceipt();
            break;
          case 9:
            System.out.print("Enter Remark: ");
            response = fp300Service.PrintRemarkLine(new String[]{key.next()});
            break;
          case 10:
            response = fp300Service.ClearError();
            break;
          case 11:
            response = fp300Service.CheckPrinterStatus();
            break;
          case 12:
            response = fp300Service.PrintSubtotal(true);
            break;

        }

        printResponse(response);

      } catch (Exception ex) {
        System.out.println(ex.getMessage() + "\n");
        ex.printStackTrace();
      }
    }

  }

  private static void printResponse(String response) {
    String[] splitted = response.split("\\|", 0);

    if (splitted.length >= 2) {
      System.out.println("Error Code    : " + Utility.GetErrorMessage(Integer.parseInt(splitted[0])));
      System.out.println("State         : " + Utility.GetStateMessage(Integer.parseInt(splitted[1])));
    }

    System.out.println("Full Response : " + response);
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
}