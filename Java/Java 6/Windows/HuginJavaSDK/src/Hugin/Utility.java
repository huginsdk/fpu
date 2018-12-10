package Hugin;

public class Utility {

  private static String[] stateMessages =
      {
          "IDLE",            /*ST_IDLE*/
          "SELLING",         /*ST_SELLING*/
          "SUBTOTAL",            /*ST_SUBTOTAL*/
          "PAYMENT",        /*ST_PAYMENT*/
          "OPEN SALE",            /*ST_OPEN_SALE*/
          "INFO RECEIPT",           /*ST_INFO_RCPT*/
          "CUSTOM RECEIPT",             /*ST_CUSTOM_RCPT*/
          "IN SERVICE",       /*ST_IN_SERVICE*/
          "SERVICE REQUIRED",       /*ST_SRV_REQUIRED*/
          "LOGIN",       /*ST_LOGIN*/
          "NONFISCAL",     /*ST_NONFISCAL*/
          "ON POWER RECOVERY",   /*ST_ON_PWR_RCOVR*/
          "INVOICE",       /*ST_INVOICE*/
          "CONFIRM REQUIRED",      /*ST_CONFIRM_REQUIRED*/
          "ECR ON USE",      /*ST_ECR_ON_USE*/
      };
  private static String[][] errorMessages =
      {
            /*ErrorCode , Message*/
          {"0", "OPERATION SUCCESSFUL"},
          {"1", "CORRUPTED DATA (LENGTH SHOULD COME UP)"},
          {"2", "CRC ERROR"},
          {"3", "INVALID FPU STATE"},
          {"4", "INVALID COMMAND"},
          {"5", "INVALID PARAMETER"},
          {"6", "OPERATION FAILS"},
          {"7", "CLEAR REQUIRED (AFTER ERROR)"},
          {"8", "NO PAPER"},
          {"9", "UNABLE TO MATCH"},
          {"11", "FM LOAD ERROR"},
          {"12", "FM REMOVED"},
          {"13", "FM MISMATCH"},
          {"14", "NEW FM"},
          {"15", "FM INIT ERROR"},
          {"16", "FM COULD NOT FISCALIZE"},
          {"17", "DAILY Z LIMIT"},
          {"18", "FM FULL"},
          {"19", "FM INITIALIZED BEFORE"},
          {"20", "FM CLOSED"},
          {"21", "FM INVALID"},
          {"22", "CERTIFICATES CANNOT BE LOADED"},
          {"31", "EJ LOAD ERROR"},
          {"32", "EJ REMOVED"},
          {"33", "EJ MISMATCH"},
          {"34", "EJ OLD (EJ REPORTS)"},
          {"35", "NEW EJ, WAITING FOR INIT"},
          {"36", "EJ CANNOT CHANGE, Z REQUIRED"},
          {"37", "EJ INIT"},
          {"38", "EJ FULL, Z REQUIRED"},
          {"39", "EJ FORMATTED"},
          {"51", "RECEIPT LIMIT EXCEEDED"},
          {"52", "RECEIPT SALE COUNT EXCEEDED"},
          {"53", "INVALID SALE"},
          {"54", "INVALID VOID"},
          {"55", "INVALID CORRECTION"},
          {"56", "INVALID ADJUSTMENT"},
          {"57", "INVALID PAYMENT"},
          {"58", "PAYMENT LIMIT EXCEEDED"},
          {"59", "DAILY SALE EXCEEDED"},
          {"71", "INVALID VAT RATE"},
          {"72", "UNDEFINED DEPARTMENT"},
          {"73", "INVALID PLU"},
          {"74", "INVALID CREDIT PAYMENT"},
          {"75", "INVALID F.CURRENCY PAYMENT"},
          {"76", "NO DOCUMENT FOUND"},
          {"77", "NO PROPER Z FOUND"},
          {"78", "INVALID SUBCATEGORY"},
          {"79", "FILE NOT FOUND"},
          {"91", "CASHIER AUTHORIZATION EXCEPTION"},
          {"92", "HAS SALE"},
          {"93", "LAST DOCUMENT NOT Z "},
          {"94", "NOT ENOUGH CASH ON CR"},
          {"95", "DAILY RECEIPT LIMIT EXCEEDED"},
          {"96", "DAILY TOTAL EXCEEDED"},
          {"97", "ECR NONFISCAL"},
          {"111", "LINE LENGTH EXCEEDED"},
          {"112", "INVALID VAT RATE"},
          {"113", "INVALID DEPARTMENT"},
          {"114", "INVALID PLU"},
          {"115", "INVALID DEFINITION (PLU NAME, DEPT, CREDIT NAME...etc)"},
          {"116", "INVALID BARCODE"},
          {"117", "INVALID OPTION"},
          {"118", "TOTAL MISMATCH"},
          {"119", "INVALID QUANTITY"},
          {"120", "INVALID AMOUNT"},
          {"121", "INVALID FISCAL ID"},
          {"131", "COVER OPENED"},
          {"132", "FM MESH DAMAGED"},
          {"133", "HUB MESH DAMAGED"},
          {"134", "Z REQUIRED(24 HOURS PASSED)"},
          {"135", "EJ NOT FOUND"},
          {"136", "CERTIFICATES NOT DOWNLOADED"},
          {"137", "SET DATE-TIME"},
          {"138", "DAILY-FM MISMATCH"},
          {"139", "DB ERROR"},
          {"140", "LOG ERROR"},
          {"141", "SRAM ERROR"},
          {"142", "CERTIFICATE MISMATCH"},
          {"143", "VERSION ERROR"},
          {"144", "DAILY LOG LIMIT EXCEEDED"},
          {"145", "RESTART ECR"},
          {"146", "WRONG PASSWORD LIMIT EXCEEDED"},
          {"147", "FISCALIZE SUCCESSFUL. RESTART ECR"},
          {"148", "CANNOT CONNECT TO GIB. TRY AGAIN(CLEAR ERROR)"},
          {"149", "CERTIFICATES DOWNLOADED. RESTART ECR"},
          {"150", "CANNOT FORMAT SAFE ZONE"},
          {"151", "REMOVE THEN PUT JUMPER "},
          {"170", "NO CONNECTED EFT"},
          {"171", "EFT-POS STATE NOT SUITABLE"},
          {"172", "INVALID CARD"},
          {"173", "AMOUNT MISMATCH"},
          {"174", "NO PROVISION"},
          {"175", "INVALID INSTALLMENT"},
		  {"176", "EFT VOID FAIL"},
		  {"177", "EFT RETURN FAIL"},
		  {"178", "EFT SLIPCOPY FAIL"},
		  {"179", "INVALID OFFLINE EFT MODE"},
		  {"180", "INVALID EFT MODE"}
      };

  public static String GetErrorMessage(int errorCode) {
    if (errorCode == 42)
      errorCode = 0;

    String msg = "" + errorCode;

    for (String[] errorMessage : errorMessages) {
      if (Integer.parseInt(errorMessage[0]) == errorCode) {
        msg = errorMessage[1];
        break;
      }
    }

    return msg;
  }

  public static String GetStateMessage(int state) {
    return stateMessages[(state) - 1];
  }

}