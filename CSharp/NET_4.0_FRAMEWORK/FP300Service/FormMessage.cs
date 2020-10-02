using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FP300Service
{
    public class FormMessage
    {
#if LANG_ENG
        #region FiscalInfoUC

        public const String EJ_LIMIT = "EJ Limit";
        public const String LINE_COUNT = "Line Count";
        public const String SET_EJ_LIMIT = "Set EJ Limit";
        public const String FISCAL_RECEIPT_INFO = "Fiscal Receipt Info";
        public const String DRAWER_INFO = "Drawer Info";
        public const String LAST_RECEIPT_INFO = "Last Receipt Info";
        public const String LAST_Z_REPORT_INFO = "Last Z Report Info";

        #endregion

        #region ProgramUC

        public const String LOGO_LINE = "LOGO LINE";
        public const String SAVE_AS = "SAVE AS";

        public const String DEPARTMENT = "DEPARTMENT";
        public const string DEFINE_DEPARTMENT = "DEPARTMENT DEFINITION";
        public const String SAVE_DEPARTMENT = "SAVE DEPARTMENT";
        public const String GET_DEPARTMENT = "GET DEPARTMENT";
        public const String DEPARTMENT_ID = "DEP. ID";
        public const String DEPARTMENT_NAME = "DEP. NAME";
        public const String VAT_GROUP_ID = "VAT GROUP ID";
        public const String DEPARTMENT_PRICE = "PRICE";
        public const String WEIGHABLE = "WEIGHABLE";
        public const String COMMIT = "COMMIT?";

        public const String PLU = "PLU";
        public const String PLU_ADDRESS_TAG = "Enter comma to between PLUs to call more than one PLU. For calling range" +
    " put  \'-\' between two values.";
        public const String PLU_ID = "PLU ID";
        public const String DEPARTMENT_DEFINITION = "DEPARTMENT DEFINITION";
        public const string SAVE_PLU = "SAVE PLU";
        public const String GET_PLU = "GET PLU";
        public const String PLU_NAME = "PLU NAME";
        public const String PRICE = "PRICE";
        public const String BARCODE = "BARCODE";
        public const String SUB_CATEGORY = "SUB CATEGORY";
        public const String DEPT_ID = "DEPT ID";
        public const String VOID_DEPARTMENT = "VOID DEPARTMENT";

        public const String CREDIT = "CREDIT";
        public const String CREDIT_DEFINITION = "CREDIT DEFINITION";
        public const String SAVE_CREDIT = "SAVE CREDIT";
        public const String GET_CREDIT = "GET CREDIT";
        public const String CREDIT_INDEX = "CREDIT ID";
        public const String CREDIT_NAME = "CREDIT NAME";

        public const String CURRENCY_DEFINITION = "F.CURRENCY DEFINITION";
        public const String SAVE_F_CURRENCY = "SAVE F.CURRENCY";
        public const String GET_F_CURRENCY = "GET F.CURRENCY";
        public const String F_CURRENCY_ID = "F.CURRENCY ID";
        public const String F_CURRENCY_CODE_NAME = "F.CURRENCY CODE";
        public const string EXCHANGE_RATE = "EXC RATE";
        public const String CURRENCY = "F.CURRENCY";
        public const String FOODCARD = "FOOD CARD";

        public const String CATEGORY = "CATEGORY";
        public const String MAIN_GROUP = "MAIN GROUP";
        public const String SAVE_SUB_CATEGORY = "SAVE SUBCATEGORY";
        public const String GET_SUB_CATEGORY = "GET SUBCATEGORY";
        public const String SUBCATEGORY_ID = "SUBCATEGORY ID";
        public const string SUBCAT_NAME = "SUBCATEGORY NAME";
        public const String SAVE_MAIN_CATEGORY = "SAVE MAIN CAT.";
        public const String GET_MAIN_CATEGORY = "GET MAIN CAT.";
        public const String MAIN_CAT_ID = "MAIN CAT. ID";
        public const String MAIN_CAT_NAME = "MAIN CAT. NAME";

        public const String CASHIER = "CASHIER";
        public const string CASHIER_LIST = "CASHIER LIST";
        public const String SAVE_CASHIER = "SAVE CASHIER";
        public const String GET_CASHIER = "GET CASHIER";
        public const String CASHIER_ID = "CASHIER ID";
        public const String CASHIER_NAME = "CASHIER NAME";
        public const String CASHIER_PWD = "CASHIER PWD";

        public const String PROGRAM_OPTIONS = "PROGRAM OPTIONS";
        public const String SAVE_PROG_OPTIONS = "SAVE PROG. OPTIONS";
        public const String GET_PROG_OPTIONS = "GET PROG. OPTIONS";
        public const String PROG_OPT_ID = "ID";
        public const string PROG_OPT_NAME = "NAME";
        public const String PROG_OPT_VALUE = "VALUE";

        public const string GRAPHIC_LOGO = "GRAPHIC LOGO";
        public const String PREVIEW = "PREVIEW";
        public const String SAVE_LOGO = "SAVE LOGO";
        public const String BROWSE_BITMAP = "BROWSE BITMAP";
        public const String LOGO = "LOGO";
        public const String GET_LOGO = "GET LOGO";
        public const String VAT = "VAT";
        public const String DEFINE_VAT = "DEFINE VAT RATE";
        public const String SAVE_VAT = "SAVE VAT";
        public const String GET_VAT = "GET VAT";
        public const String VAT_ID = "VAT ID";
        public const String VAT_RATE = "VAT RATE";

        public const String CC_LIST = "CC LIST";
        public const String OPEN_CSV = "OPEN .CSV";
        public const String BIN_LIST = "BIN LIST";
        public const String SAVE_CARD_LIST = "SAVE CARD LIST";
        public const String CC_ID = "CC ID";
        public const String CC_NAME = "CC NAME";
        public const String BIN = "BIN";

        public const String NETWORK_SETTINGS = "NETWORK SETTINGS";
        public const String AUTOMATIC_IP_MESSSAGE = "* Blank field for dynamic IP";

        public const String GROUP_ID = "GROUP ID";
        public const String GROUP_NAME = "GROUP NAME";

        #endregion

        #region ReportUC

        public const String X_REPORTS = "X REPORTS";
        public const String FIRST_PLU = "FIRST PLU";
        public const String LAST_PLU = "LAST PLU";
        public const String SYSTEM_INFO_REPORT = "SYSTEM INFO REPORT";
        public const String PLU_REPORT = "PLU REPORT";
        public const string X_REPORT = "X REPORT";
        public const String GET_REPORT = "GET REPORT";
        public const String REPORT_CONTENT = "REPORT CONTENT";
        public const String RECEIPT_TOTAL_REPORT = "RECEIPTS TOTAL REPORT";

        public const String Z_REPORTS = "Z REPORTS";
        public const String Z_DETAILED = "Z DETAILED";
        public const String DATE_DETAILED = "DATE DETAILED";
        public const String FIRST_Z_DATE = "FIRST Z DATE";
        public const String LAST_Z_DATE = "LAST Z DATE";
        public const String FIRST_Z_ID = "FIRST Z ID";
        public const String LAST_Z_ID = "LAST Z ID";
        public const String Z_REPORT = "Z REPORT";
        public const String Z_COPY = "Z COPY";

        public const String FM_REPORT_DATE = "FISCAL MEMORY REPORT(DATE)";
        public const String FM_REPORT_ZZ = "FISCAL MEMORY REPORT(Z-Z)";

        public const String EJ_SINGLE_REPORT = "EJ SINGLE REPORT";
        public const String EJ_DETAIL_REPORT = "EJ DETAIL REPORT";
        public const String EJ_SINGLE_REPORT_DATE_TIME = "EJ SINGLE REPORT(DATE/TIME)";
        public const String EJ_SINGLE_REPORT_ZID_DOCID = "EJ SINGLE REPORT(Z ID/DOC ID)";
        public const String EJ_PERIODIC = "EJ PERIODIC";
        public const String EJ_PERIODIC_REPORT_DATE_TIME = "EJ PERIODIC(DATE/TIME)";
        public const String EJ_PERIODIC_REPORT_ZID_DOCID = "EJ PERIODIC(Z ID/DOC ID)";
        public const String EJ_PERIODIC_DAILY = "EJ PERIODIC (DAILY)";
        public const String LAST_HOUR = "LAST HOUR";
        public const String LAST_DATE = "LAST DATE";
        public const String LAST_DOC_ID = "LAST DOC ID";
        public const String FIRST_HOUR = "FIRST HOUR";
        public const String FIRST_DATE = "FIRST DATE";
        public const String FIRST_DOC_ID = "FIRST DOC ID";

        public const String OTHER_DOC = "OTHER DOCS";
        public const String OTHER_DOC_TYPE = "OTHER DOCS TYPE";
        public const String DAILY_OTHER_DOC_REPORT = "OTHER DOC (DAILY)";
        public const String PERIODIC_OTHER_DOC_REPORT = "OTHER DOC (PERIODIC)";

        #endregion

        #region SaleUC

        public const String SAVE_AND_SALE = "SAVE & SALE";
        public const String SALE = "SALE";
        public const String DOC_TOTAL = "DOC TOTAL";

        public const String ENTRY_TIME = "ENTRY TIME";
        public const String PLATE = "PLATE";

        public const String REMARK = "REMARK";
        public const String CORRECT = "CORRECT";
        public const String VOID_QUANTITY = "VOID QUANTITY";
        public const String VOID_SALE = "VOID SALE";

        public const String FEE = "FEE";
        public const String DISCOUNT = "DISCOUNT";
        public const String PERCENTAGE = "PERCENTAGE";

        public const String ADJUST = "ADJUST";
        public const String ADJUSTMENT_AMOUNT = "ADJ. AMOUNT";

        public const String SUBTOTAL = "SUBTOTAL";
        public const String VOID_DOCUMENT = "VOID DOCUMENT";
        public const String CLOSE_DOCUMENT = "CLOSE DOCUMENT";
        public const String START_DOCUMENT = "START DOCUMENT";

        public const String OPEN_DRAWER = "OPEN DRAWER";
        public const String SLIP_COPY = "SLIP COPY";

        public const String VOID_PAYMENT = "VOID PAYMENT";
        public const String CASH_PAYMENTS = "CASH PAYMENTS";
        public const String PRINT_JSON = "PRINT JSON";
        public const String EFT_PAYMENT = "EFT PAYMENT";
        public const String CARD_NUMBER = "CARD NUMBER";
        public const string INSTALLMENT = "INSTALLMENT";
        public const String GET_EFT_PAYMENT = "GET EFT PAYMENT";
        public const String CHECK_CARD = "CHECK CARD";

        public const String ADJUSTMENT = "ADJUSTMENT";
        public const String FOOTER_NOTES = "FOOTER NOTES";
        public const String FOOTER_NOTES_EXTRA = "FOOTER NOTE EXTRA";

        public const String RECEIPT = "RECEIPT";
        public const String INVOICE_TYPES = "INVOICE TYPES";
        public const String PAID_DOCUMENTS = "PAID DOCUMENTS";
        public const String PARKING = "PARKING";
        public const string ADVANCE = "ADVANCE";

        public const String VOIDED_DOC_ID = "VOIDED DOC. ID";
        public const String PAID_TOTAL = "PAID TOTAL";

        public const String CASH = "CASH";
        public const String CHECK = "CHECK";
        public const String INVOICE = "INVOICE";
        public const String E_INVOICE = "E-INVOICE";
        public const string E_ARCHIVE = "E-ARCHIVE";
        public const string FOOD_DOC = "MEAL TICKET";
        public const String CURRENCIES = "CURRENCIES";

        public const String CREDITS_LOADING = "CREDITS LOADING";
        public const String CREDITS_LOADED = "CREDITS LOADED";
        public const String CREDITS = "CREDITS";

        public const String FOODCARDS_LOADED = "FOOD CARDS LOADED";

        public const string JSON_FILE_NOT_EXISTS = "JSON FILE DOES NOT EXIST";
        public const String DISCOUNT_ACTIVE = "DISCOUNT ACTIVE";
        public const String PROVISION_CODE = "PROVISION CODE";
        public const String BANK_INFO = "BANK INFO";

        public const String SAVE_AND_SALE_INFO = "INFO: Only 9.th cashier is authorizated on SAVE and SALE";

        public const String VOID_EFT = "VOID EFT";
        public const String STAN_NO = "STAN NO";
        public const String BATCH_NO = "BATCH NO";
        public const String ACQUIER_ID = "ACQUIER NO";
        public const String REFUND = "REFUND";
        public const String EFT_REFUND = "EFT REFUND";
        public const String BANK_LIST = "BANK LIST";
        public const String GET_BANK_LIST = "GET BANK LIST";

        public const String PRINT_EDOCUMENT_SAMPLE = "PRINT E-DOCUMENT SAMPLE";

        #endregion

        #region ServiceUC

        public const String SERVICE_OPERATIONS = "SERVICE OPERATIONS";
        public const String ORDER_CODE = "ORDER CODE";
        public const String FILE_NAME = "FILE NAME";
        public const String FILE_TRANSFER = "FILE TRANSFER";
        public const String SET_DATE_TIME = "SET DATE/TIME";
        public const String ENTER_SERVICE_MODE = "ENTER SERVICE MODE";
        public const String EXIT_SERVICE_MODE = "EXIT SERVICE MODE";
        public const String PASSWORD = "PASSWORD";
        public const String SET_EXT_DEVICE_SETTINGS = "SET EXT DEVICE SETTINGS";
        public const string START_FM_TEST = "START FM TEST";
        public const String CREATE_SALE_DB = "CREATE SALE DB";
        public const String CLOSE_FM = "CLOSE FM";
        public const String FACTORY_SETTINGS = "FACTORY SETTINGS";
        public const String PRINT_LOGS = "PRINT LOGS";
        public const String FORMAT_DAILY_MEMORY = "FORMAT DAILY MEMORY";
        public const string INITIALIZE_EJ = "INITIALIZE EJ";
        public const String UPDATE_FIRMWARE = "UPDATE FIRMWARE";
        public const String FISCAL_MODE_NOW = "FISCAL MODE NOW";
        public const String TEST_COMMANDS = "TEST COMMANDS";

        #endregion

        #region UtilityUC

        public const String STATUS_INFO = "STATUS INFO";
        public const String INTERRUPT_PROCESS = "INTERRUPT PROCESS";
        public const String LAST_RESPONSE = "LAST RESPONSE";
        public const String CHECK_STATUS = "CHECK STATUS";
        public const string FISCAL_OPERATIONS = "FISCAL OPERATIONS";
        public const String START_FM = "START FM";
        public const String CASHIER_LOGIN = "CASHIER LOGIN";
        public const String CASH_IN_CASH_OUT = "CASH IN/OUT";
        public const String CASH_IN = "CASH IN";
        public const String CASH_OUT = "CASH OUT";
        public const String AMOUNT = "AMOUNT";
        public const string SPECIAL_RECEIPT = "NF RECEIPT";
        public const String PRINT_SAMPLE_CONTEXT = "PRINT SAMPLE CONTEXT";
        public const string START_NF_RECEIPT = "START NF RECEIPT";
        public const String CLOSE_NF_RECEIPT = "CLOSE NF RECEIPT";
        public const String ALL = "ALL";
        public const String AUTHORIZATION = "AUTHORIZATION";
        public const string PLS_ENTER_FISCAL_ID = "PLEASE ENTER FISCAL ID";
        public const String INAPPROPRIATE_FISCAL_ID = "INAPPROPRIATE FISCAL ID";
        public const String SAMPLE_LINE = "SAMPLE LINE";

        #endregion

        #region MainForm 

        public const string CONNECTION = "CONNECTION";
        public const String PROGRAM = "PROGRAM";
        public const String REPORTS = "REPORTS";
        public const String SERVICE = "SERVICE";
        public const string CASH_REGISTER_INFO = "CR INFO";
        public const String STATUS_CHECK = "STATUS CHECK";
        public const String CONNECT = "CONNECT";
        public const String SERIAL_PORT = "SERIAL PORT";
        public const String COMMAND = "COMMAND";
        public const String FPU_STATE = "FPU STATE";
        public const String RESPONSE = "RESPONSE";
        public const String NEED_SERVICE = "NEED SERVICE";
        public const String CONNECTION_ERROR = "CONNECTION ERROR";
        public const String CONNECTING = "CONNECTING";
        public const String PLEASE_WAIT = "PLEASE WAIT";
        public const String MATCHING_ERROR = "MATCHING ERROR";
        public const String DISCONNECT = "DISCONNECT";
        public const string CONNECTED = "CONNECTED";
        public const String DISCONNECTED = "DISCONNECTED";
        public const String UNABLE_TO_MATCH = "UNABLE TO MATCH";

        #endregion

        #region GENERAL

        public const String OPERATION_FAILS = "OPERATION FAILS";
        public const String OPERATION_SUCCESSFULL = "OPERATION SUCCESSFULL";
        public const String TIMEOUT_ERROR = "TIMEOUT ERROR";
        public const String PRODUCT_COULD_NOT_BE_READ = "PRODUCT COULD NOT BE READ";
        public const String PRODUCT_COULD_NOT_BE_SAVED = "PRODUCT COULD NOT BE SAVED";
        public const String MAIN_CATEGORY_NOT_SAVED = "MAIN CAT. COULD NOT BE SAVED";
        public const String MAIN_CAT_NOT_GET = "MAIN CAT. COULD NOT BE GET";
        public const String SUBCAT_NOT_SAVE = "SUBCATEGORY COULD NOT BE SAVED";
        public const String SUBCAT_NOT_GET = "SUBCATEGORY COULD NOT BE GET";

        public const String INFO_PLU_CLICK_1 = "Getting more than one PLU, put comma between PLUs";
        public const String INFO_PLU_CLICK_2 = "Sample: 1,5,7";
        public const String INFO_PLU_CLICK_3 = "For getting range of PLU, put '-' between values.";
        public const String INFO_PLU_CLICK_4 = "Sample: 1-20";

        public const String DOCUMENT_ID = "Document Id";
        public const String Z_ID = "Z Id";
        public const String EJ_ID = "EJ Id";
        public const String DOCUMENT_TYPE = "Document Type";
        public const String DATE = "Date";
        public const String TIME = "Time";
        public const String NOTE = "NOTE";
        public const String QUANTITY = "QUANTITY";

        public const String RETURN_AMOUNT = "RETURN AMOUNT";
        public const String RETURN_COUNT = "RETURN COUNT";
        public const String RETURN_AFFECT_DRAWER = "RETURN AFFECT DRAWER";

        public const String TOTAL_INFO = "TOTAL INFO";
        public const String TOTAL_RECEIPT_COUNT = "TOTAL RECEIPT COUNT";
        public const String TOTAL_AMOUNT = "TOTAL AMOUNT";
        public const String SALE_INFO = "SALE INFO";
        public const String TOTAL_SALE_RECEIPT_COUNT = "TOTAL SALE RECEIPT COUNT";
        public const String TOTAL_SALE_AMOUNT = "TOTAL SALE AMOUNT";
        public const String VOID_INFO = "VOID INFO";
        public const String TOTAL_VOID_RECEIPT_COUNT = "TOTAL VOID RECEIPT COUNT";
        public const String TOTAL_VOID_AMOUNT = "TOTAL VOID AMOUNT";
        public const String ADJUSTMENT_INFO = "ADJUSTMENT INFO";
        public const String TOTAL_ADJUSTED_AMOUNT = "TOTAL ADJUSTED AMOUNT";
        public const String PAYMENT_INFO = "PAYMENT INFO";
        public const String PAYMENT = "PAYMENT";
        public const String PAYMENT_TYPE = "PAYMENT TYPE";
        public const String PAYMENT_INDEX = "PAYMENT INDEX";
        public const String PAYMENT_AMOUNT = "PAYMENT AMOUNT";

        public const String CONTEXT = "CONTEXT";
        public const String PRINT = "PRINT";
        public const String SAVE = "SAVE";

        #endregion

        public const string TCKN = "TCKN";
        public const string CUSTOMER_NAME = "CUSTOMER NAME";
        public const string COLLECTION_DOC = "COLLECTION INVOICE";
        public const string PLU_DEFINITION = "PLU DEFINITION";
        public const string END_DAY_REPORT = "END DAY REPORT";
        public const string SAVE_BITMAP_MESSAGE = "PLEASE WAIT. BITMAP LOGO SAVING..";
        public const string FILL_DEPT_NAME = "PLEASE FILL THE DEPARTMAN NAME AREA";
        public const string PRINT_SALES_DOCUMENT = "PRINT SALES DOCUMENT";

        public const string BARCODE_TYPE = "BARCODE TYPE";
        public const string BARCODE_EAN = "EAN";
        public const string BARCODE_QRN = "QRN";
        public const string BARCODE_CO39 = "CO39";
        public const string BARCODE_C128 = "C128";
        public const string BARCODE_NONE = "NONE";

        public const string DOCUMENT_SERIAL = "DOCUMENT SERIAL";
        public const string CURRENT_ACCOUNT_COLLECTION_DOC = "CUURENT ACCOUNT COLLECTION DOCUMENT";

        public const string END_OF_RECEIPT_NOTE = "END OF RECEIPT NOTE";
        public const string LINE = "LINE";
        public const string GET = "GET";
        public const string SET = "SET";

        public const string VERSION_INFO = "VERSION INFO";
        public const string ECR_INFO = "ECR INFO";
        public const string LIBRARY_INFO = "LIBRARY INFO";

        public const string COLLECT = "COLLECT";
        public const string COLLECT_INFO = "COLLECT INFO";
        public const string COLLECT_TYPE = "COLLECT TYPE";
        public const string COLLECT_QUANTITY = "COLLECT QUANTITY";
        public const string COLLECT_AMOUNT = "COLLECT AMOUNT";

        public const string NOTE_OF_EXPENSES = "NOTE OF EXPENSES";
        public const string SELF_EMPLOYEMENT_INVOICE = "SELF EMPLOYEMENT INVOICE";

        public const string DOCUMENT_ORDER_NO = "DOC ORDER NO";
        public const string TAX_OFFICE = "TAX OFFICE";
        public const string ADDRESS = "ADDRESS";

        public const string ADD = "ADD";
        public const string CLEAR = "CLEAR";
        public const string UPDATE_CUSTOMER = "UPDATE CUSTOMER";
        public const string ADD_CUSTOMER = "ADD CUSTOMER";
        public const string LABEL = "LABEL";
        public const string STOPPAGE = "STOPPAGE";
        public const string SEND_STOPPAGE = "SEND STOPPAGE";
        public const string RETURN_DOCUMENT = "RETURN DOCUMENT";

        public const string ADD_SERVICE = "ADD SERVICE";
        public const string REMOVE_SERVICE = "REMOVE SERVICE";

        public const string INDEX = "INDEX";
        public const string SERVICES_SEI = "SERVICES";

        public static string SERVICE_DEFINITION = "SERVICE DEFINITION";
        public static string BRUT_AMOUNT = "BRUT AMOUNT";
        public static string GROSS_WAGES = "GROSS WAGES";
        public static string WAGE_RATE = "WAGE RATE";
        public static string STOPPAGE_OTHER = "STOPPAGE OTHER %";
        public static string STOPPAGE_RATE = "STOPPAGE %";

        public static string KEYPAD_OPTIONS = "KEYPAD OPTIONS";
        public static string LOCK_KEYS = "LOCK KEYS";
        public static string UNLOCK_KEYS = "UNLOCK KEYS";

        public const string ADDRESS_LINE = "ADDRESS LINE";

#else
        #region FiscalInfoUC

        public const String EJ_LIMIT = "EKÜ Limit";
        public const String LINE_COUNT = "Satır Sayısı";
        public const String SET_EJ_LIMIT = "EKÜ Limit Ekle";
        public const String FISCAL_RECEIPT_INFO = "Mali Fiş Bilgileri";
        public const String DRAWER_INFO = "Çekmece Bilgileri";
        public const String LAST_RECEIPT_INFO = "Son Fiş Bilgisi";
        public const String LAST_Z_REPORT_INFO = "Son Z Bilgisi";

        #endregion

        #region ProgramUC

        public const String LOGO_LINE = "LOGO SATIRI";
        public const String SAVE_AS = "KAYDET";

        public const String DEPARTMENT = "KISIM";
        public const string DEFINE_DEPARTMENT = "DEPARTMAN TANIMLAMA";
        public const String SAVE_DEPARTMENT = "DEPARTMAN KAYDET";
        public const String GET_DEPARTMENT = "DEPARTMAN GETİR";
        public const String DEPARTMENT_ID = "KISIM NO";
        public const String DEPARTMENT_NAME = "KISIM ADI";
        public const String VAT_GROUP_ID = "KDV NO";
        public const String DEPARTMENT_PRICE = "TUTAR";
        public const String WEIGHABLE = "TARTILABİLİR";
        public const String COMMIT = "İŞLE?";

        public const String PLU = "PLU";
        public const String PLU_ADDRESS_TAG = "Birden fazla PLU getirmek için PLU no aralarına virgül koyunuz. Aralık okumak için iki değer arasına çizgi \'-\' koyunuz.";
        public const String PLU_ID = "PLU NO";
        public const String DEPARTMENT_DEFINITION = "DEPARTMAN TANIMLAMA";
        public const String SAVE_PLU = "PLU KAYDET";
        public const String GET_PLU = "PLU GETİR";
        public const String PLU_NAME = "ÜRÜN ADI";
        public const String PRICE = "FİYAT";
        public const String BARCODE = "BARKOD";
        public const String SUB_CATEGORY = "ALT KATEGORİ";
        public const String DEPT_ID = "DEPT NO";
        public const String VOID_DEPARTMENT = "DEPARTMAN İPTALİ";

        public const String CREDIT = "KREDİ";
        public const String CREDIT_DEFINITION = "KREDİ TANIMLAMA";
        public const String SAVE_CREDIT = "KREDİ KAYDET";
        public const String GET_CREDIT = "KREDİ GETİR";
        public const String CREDIT_INDEX = "KREDİ NO";
        public const String CREDIT_NAME = "KREDİ ADI";

        public const String CURRENCY_DEFINITION = "DÖVİZ TANIMLAMA";
        public const String SAVE_F_CURRENCY = "DÖVİZ KAYDET";
        public const String GET_F_CURRENCY = "DÖVİZ GETİR";
        public const String F_CURRENCY_ID = "DÖVİZ NO";
        public const String F_CURRENCY_CODE_NAME = "DÖVİZ KODU";
        public const String EXCHANGE_RATE = "KUR";
        public const String CURRENCY = "DÖVİZ";
        public const String FOODCARD = "YEMEK KARTI"; 

        public const String CATEGORY = "KATEGORİ";
        public const String MAIN_GROUP = "ANA ÜRÜN GRUBU";
        public const String SAVE_SUB_CATEGORY = "ALT GRUP KAYDET";
        public const String GET_SUB_CATEGORY = "ALT GRUP GETİR";
        public const String SUBCATEGORY_ID = "ALT GRUP NO";
        public const String SUBCAT_NAME = "ALT GRUP ADI";
        public const String SAVE_MAIN_CATEGORY = "ANA GRUP KAYDET";
        public const String GET_MAIN_CATEGORY = "ANA GRUP GETİR";
        public const String MAIN_CAT_ID = "ANA GRUP NO";
        public const String MAIN_CAT_NAME = "ANA GRUP ADI";

        public const String CASHIER = "KASİYER";
        public const String CASHIER_LIST = "KASİYER LİSTESİ";
        public const String SAVE_CASHIER = "KASİYER KAYDET";
        public const String GET_CASHIER = "KASİYER GETİR";
        public const String CASHIER_ID = "KASİYER NO";
        public const String CASHIER_NAME = "KASİYER ADI";
        public const String CASHIER_PWD = "KASİYER ŞİFRE";

        public const String PROGRAM_OPTIONS = "PROGRAM AYARLARI";
        public const String SAVE_PROG_OPTIONS = "AYARLARI KAYDET";
        public const String GET_PROG_OPTIONS = "AYARLARI GETİR";
        public const String PROG_OPT_ID = "NO";
        public const string PROG_OPT_NAME = "PARAMETRE ADI";
        public const String PROG_OPT_VALUE = "DEĞER";

        public const string GRAPHIC_LOGO = "GRAFİK LOGO";
        public const String PREVIEW = "ÖNİZLEME";
        public const String SAVE_LOGO = "LOGO KAYDET";
        public const String BROWSE_BITMAP = "DOSYA SEÇ";
        public const String LOGO = "LOGO";
        public const String GET_LOGO = "LOGO GETİR";

        public const String VAT = "KDV";
        public const String DEFINE_VAT = "KDV TANIMLAMA";
        public const String SAVE_VAT = "KDV KAYDET";
        public const String GET_VAT = "KDV GETİR";
        public const String VAT_ID = "KDV NO";
        public const String VAT_RATE = "KDV ORANI";

        public const String CC_LIST = "CC LİSTE";
        public const String OPEN_CSV = "CSV AÇ";
        public const String BIN_LIST = "BIN LİSTE";
        public const String SAVE_CARD_LIST = "KART LİSTE KAYDET";
        public const String CC_ID = "CC NO";
        public const String CC_NAME = "CC ADI";
        public const String BIN = "BIN";

        public const String NETWORK_SETTINGS = "AĞ AYARLARI";
        public const String AUTOMATIC_IP_MESSSAGE = "* Otomatik IP tanımlamak için boş bırakınız.";

        public const String GROUP_ID = "GRUP NO";
        public const String GROUP_NAME = "GRUP ADI";

        #endregion

        #region ReportUC

        public const String X_REPORTS = "X RAPORLARI";
        public const String FIRST_PLU = "İLK PLU";
        public const String LAST_PLU = "SON PLU";
        public const String SYSTEM_INFO_REPORT = "SİSTEM BİLGİ RAPORU";
        public const String PLU_REPORT = "PLU RAPORU";
        public const string X_REPORT = "X RAPORU";
        public const String GET_REPORT = "RAPOR AL";
        public const String REPORT_CONTENT = "İÇERİK GETİR";
        public const String RECEIPT_TOTAL_REPORT = "FİŞ TOPLAMLARI RAPORU";

        public const String Z_REPORTS = "Z RAPORLARI";
        public const String Z_DETAILED = "Z DETAYLI";
        public const String DATE_DETAILED = "TARİH DETAYLI";
        public const String FIRST_Z_DATE = "İLK Z TARİH";
        public const String LAST_Z_DATE = "SON Z TARİH";
        public const String FIRST_Z_ID = "İLK Z NO";
        public const String LAST_Z_ID = "SON Z NO";
        public const String Z_REPORT = "Z RAPORU";
        public const String Z_COPY = "Z KOPYASI";

        public const String FM_REPORT_DATE = "MALİ BELLEK RAPORU(TARİH)";
        public const String FM_REPORT_ZZ = "MALİ BELLEK RAPORU(Z-Z)";

        public const String EJ_SINGLE_REPORT = "EKÜ TEK BELGE";
        public const String EJ_DETAIL_REPORT = "EKÜ DETAY RAPORU";
        public const String EJ_SINGLE_REPORT_DATE_TIME = "EKÜ TEK BELGE(TARİH/SAAT)";
        public const String EJ_SINGLE_REPORT_ZID_DOCID = "EKÜ TEK BELGE(Z NO/FİŞ NO)";
        public const String EJ_PERIODIC = "EKÜ PERİYODİK";
        public const String EJ_PERIODIC_REPORT_DATE_TIME = "EKÜ PERİYODİK(TARİH/SAAT)";
        public const String EJ_PERIODIC_REPORT_ZID_DOCID = "EKÜ PERİYODİK(Z NO/FİŞ NO)";
        public const String EJ_PERIODIC_DAILY = "EKÜ PERİYODİK(GÜNLÜK)";
        public const String FIRST_HOUR = "İLK SAAT";
        public const String LAST_HOUR = "SON SAAT";
        public const String FIRST_DATE = "İLK TARİH";
        public const String LAST_DATE = "SON TARİH";
        public const String FIRST_DOC_ID = "İLK FİŞ NO";
        public const String LAST_DOC_ID = "SON FİŞ NO";

        public const String OTHER_DOC = "DİĞER BELGELER";
        public const String OTHER_DOC_TYPE = "DİĞER BELGE TİPİ";
        public const String DAILY_OTHER_DOC_REPORT = "DİĞER BELGE (GÜNLÜK)";
        public const String PERIODIC_OTHER_DOC_REPORT = "DİĞER BELGE (PERİYODİK)";
        #endregion

        #region SaleUC

        public const String SAVE_AND_SALE = "KAYDET ve SAT";
        public const String SALE = "SATIŞ YAP";
        public const String DOC_TOTAL = "BELGE TOPLAMI";

        public const String ENTRY_TIME = "ARAÇ GİRİŞ ZAMANI";
        public const String PLATE = "PLAKA";

        public const String REMARK = "AÇIKLAMA";
        public const String CORRECT = "DÜZELTME";
        public const String VOID_QUANTITY = "İPTAL MİKTARI";
        public const String VOID_SALE = "SATIŞ İPTAL";

        public const String FEE = "ARTTIRIM";
        public const String DISCOUNT = "INDIRIM";
        public const String PERCENTAGE = "YÜZDE";

        public const String ADJUST = "İND/ART UYGULA";
        public const String ADJUSTMENT_AMOUNT = "İND/ART MİKTARI";

        public const String SUBTOTAL = "ARATOPLAM";
        public const String VOID_DOCUMENT = "BELGE İPTAL";
        public const String CLOSE_DOCUMENT = "BELGE KAPAT";
        public const String START_DOCUMENT = "BELGE BAŞLAT";

        public const String OPEN_DRAWER = "ÇEKMECE AÇ";
        public const String SLIP_COPY = "İŞ YERİ NÜSHASI";

        public const String VOID_PAYMENT = "ÖDEME İPTAL";
        public const String CASH_PAYMENTS = "NAKİT ÖDEMELER";
        public const String PRINT_JSON = "JSON YAZDIR";

        public const String EFT_PAYMENT = "KARTLI ÖDEME";
        public const String CARD_NUMBER = "KART NUMARASI";
        public const string INSTALLMENT = "TAKSİT";
        public const String GET_EFT_PAYMENT = "EFT ÖDEME AL";
        public const String CHECK_CARD = "KART SORGULAMA";

        public const String ADJUSTMENT = "İNDİRİM/ARTTIRIM";

        public const String FOOTER_NOTES = "BELGE SONU SATIRLAR";
        public const String FOOTER_NOTES_EXTRA = "BELGE SONU DİĞER";

        public const String RECEIPT = "FİŞ";
        public const String INVOICE_TYPES = "FAT/EFAT/EARS";
        public const String PAID_DOCUMENTS = "TUTAR GİRİŞLİ BELGE";
        public const String PARKING = "OTOPARK";
        public const string ADVANCE = "AVANS";

        public const String VOIDED_DOC_ID = "İPTAL BELGE NO";
        public const String PAID_TOTAL = "ÖDEME TOPLAMI";

        public const String CASH = "NAKİT";
        public const String CHECK = "ÇEK";
        public const String INVOICE = "FATURA";
        public const String E_INVOICE = "E-FATURA";
        public const string E_ARCHIVE = "E-ARŞİV";
        public const string FOOD_DOC = "YEMEK FİŞİ";
        public const String CURRENCIES = "DÖVİZLER";

        public const String CREDITS_LOADING = "KREDİLER YÜKLENİYOR";
        public const String CREDITS_LOADED = "KREDİLER YÜKLENDİ";
        public const String CREDITS = "KREDİLER";

        public const String FOODCARDS_LOADED = "YEMEK KARTLARI YÜKLENDİ";

        public const string JSON_FILE_NOT_EXISTS = "JSON SATIŞ DOSYASI BULUNAMADI";
        public const String DISCOUNT_ACTIVE = "İNDİRİM AKTİF";
        public const String PROVISION_CODE = "PROVİZYON KODU";
        public const String BANK_INFO = "BANKA BİLGİLERİ";

        public const String SAVE_AND_SALE_INFO = "Bilgi: 9 numaralı kasiyer ile satıştan ürün kaydedilebilir.";

        public const String VOID_EFT = "EFT İPTAL";
        public const String STAN_NO = "SIRA NO";
        public const String BATCH_NO = "BATCH NO";
        public const String ACQUIER_ID = "ACQUIER NO";
        public const String REFUND = "İADE";
        public const String EFT_REFUND = "EFT İADE";
        public const String BANK_LIST = "BANKA LİSTESİ";
        public const String GET_BANK_LIST = "BANKA LİSTESİ GETİR";

        public const String PRINT_EDOCUMENT_SAMPLE = "E-BELGE ÖRNEĞİ YAZDIR";

        #endregion

        #region ServiceUC

        public const String SERVICE_OPERATIONS = "SERVİS İŞLEMLERİ";
        public const String ORDER_CODE = "İŞLEM KODU";
        public const String FILE_NAME = "DOSYA ADI";
        public const String FILE_TRANSFER = "DOSYA TRANSFERİ";
        public const String SET_DATE_TIME = "TARİH/SAAT AYARLA";
        public const String ENTER_SERVICE_MODE = "SERVİS MODU BAŞLAT";
        public const String EXIT_SERVICE_MODE = "SERVİS MODU ÇIKIŞ";
        public const String PASSWORD = "ŞİFRE";
        public const String SET_EXT_DEVICE_SETTINGS = "HARICI DONANIM AYARLA";
        public const string START_FM_TEST = "FM TEST BAŞLAT";
        public const String CREATE_SALE_DB = "SATIŞ DB OLUŞTUR";
        public const String CLOSE_FM = "FM SONLANDIR";
        public const String FACTORY_SETTINGS = "FABRIKA AYARLARI";
        public const String PRINT_LOGS = "LOG YAZDIR";
        public const String FORMAT_DAILY_MEMORY = "GÜNLÜK BELLEK SIFIRLA";
        public const string INITIALIZE_EJ = "EJ FORMATLA";
        public const String UPDATE_FIRMWARE = "UYGULAMA GÜNCELLE";
        public const String FISCAL_MODE_NOW = "MALİ KONUMA GEÇ";
        public const String TEST_COMMANDS = "TEST KOMUTLARI";


        #endregion

        #region UtilityUC

        public const String STATUS_INFO = "DURUM BİLGİSİ";
        public const String INTERRUPT_PROCESS = "İŞLEM DURDURMA";
        public const String LAST_RESPONSE = "SON CEVAP";
        public const String CHECK_STATUS = "STATUS SORGULA";
        public const string FISCAL_OPERATIONS = "MALİ İŞLEMLER";
        public const String START_FM = "MALİ BELLEK BAŞLAT";
        public const String CASHIER_LOGIN = "KASİYER GİRİŞİ";
        public const String CASH_IN_CASH_OUT = "KASA ALDI/VERDİ";
        public const String CASH_IN = "NAKİT GİRİŞ";
        public const String CASH_OUT = "NAKİT ÇIKIŞ";
        public const String AMOUNT = "MİKTAR";
        public const string SPECIAL_RECEIPT = "ÖZEL FİŞ";
        public const String PRINT_SAMPLE_CONTEXT = "ÖRNEK İÇERİK YAZDIR";
        public const string START_NF_RECEIPT = "ÖZEL FİŞ BAŞLAT";
        public const String CLOSE_NF_RECEIPT = "ÖZEL FİŞ KAPAT";
        public const String ALL = "HEPSİ";
        public const String AUTHORIZATION = "YETKİ";
        public const string PLS_ENTER_FISCAL_ID = "LÜTFEN MALİ NUMARA GİRİNİZ";
        public const String INAPPROPRIATE_FISCAL_ID = "MALİ NUMARA UYGUN DEĞİL";
        public const String SAMPLE_LINE = "ÖRNEK SATIR";

        #endregion

        #region MainForm

        public const string CONNECTION = "BAĞLANTI";
        public const String PROGRAM = "PROGRAMLAMA";
        public const String REPORTS = "RAPORLAR";
        public const String SERVICE = "SERVİS";
        public const string CASH_REGISTER_INFO = "KASA BİLGİLERİ";
        public const String STATUS_CHECK = "DURUM KONTROLÜ";
        public const String CONNECT = "BAĞLANTIYI AÇ";
        public const String SERIAL_PORT = "SERİ PORT";
        public const String COMMAND = "KOMUT";
        public const String FPU_STATE = "FPU DURUM";
        public const String RESPONSE = "CEVAP";
        public const String NEED_SERVICE = "SERVICE GEREKLİ";
        public const String CONNECTION_ERROR = "BAĞLANTI HATASI";
        public const String CONNECTING = "BAĞLANTI AÇILIYOR";
        public const String PLEASE_WAIT = "BEKLEYİNİZ";
        public const String MATCHING_ERROR = "EŞLEME HATASI";
        public const String DISCONNECT = "BAĞLANTIYI KAPAT";
        public const string CONNECTED = "BAĞLANDI";
        public const String DISCONNECTED = "BAĞLANTI KAPATILDI";
        public const String UNABLE_TO_MATCH = "EŞLEME YAPILAMADI";

        #endregion

        #region GENERAL

        public const String OPERATION_SUCCESSFULL = "İŞLEM BAŞARILI";
        public const String OPERATION_FAILS = "İŞLEM BAŞARISIZ";
        public const String TIMEOUT_ERROR = "TIMEOUT HATASI";
        public const String PRODUCT_COULD_NOT_BE_READ = "ÜRÜN OKUNAMADI";
        public const String PRODUCT_COULD_NOT_BE_SAVED = "ÜRÜN KAYDEDİLEMEDİ";
        public const String MAIN_CATEGORY_NOT_SAVED = "ANA ÜRÜN GRUBU KAYDEDİLEMEDİ";
        public const String MAIN_CAT_NOT_GET = "ANA ÜRÜN GRUBU ALINAMADI";
        public const String SUBCAT_NOT_SAVE = "ALT ÜRÜN GRUBU KAYDEDİLEMEDİ";
        public const String SUBCAT_NOT_GET = "ALT ÜRÜN GRUBU GETİRİLEMEDİ";

        public const String INFO_PLU_CLICK_1 = "Birden fazla PLU getirmek için PLU no aralarına virgül koyunuz";
        public const String INFO_PLU_CLICK_2 = "Örnek: 1,5,7";
        public const String INFO_PLU_CLICK_3 = "Aralık okumak için iki değer arasına çizgi '-' koyunuz.";
        public const String INFO_PLU_CLICK_4 = "Örnek: 1-20";

        public const String DOCUMENT_ID = "FİŞ NO";
        public const String Z_ID = "Z NO";
        public const String EJ_ID = "EJ NO";
        public const String DOCUMENT_TYPE = "BELGE TİPİ";
        public const String DATE = "TARİH";
        public const String TIME = "SAAT";
        public const String NOTE = "NOT";
        public const String QUANTITY = "MİKTAR";

        public const String RETURN_AMOUNT = "İADE TUTARI";
        public const String RETURN_COUNT = "İADE SAYISI";
        public const String RETURN_AFFECT_DRAWER = "ÇEKMECE ETKİLENSİN";

        public const String TOTAL_INFO = "TOPLAM BİLGİLERİ";
        public const String TOTAL_RECEIPT_COUNT = "TOPLAM FİŞ SAYISI";
        public const String TOTAL_AMOUNT = "TOPLAM TUTAR";
        public const String SALE_INFO = "SATIŞ BİLGİLERİ";
        public const String TOTAL_SALE_RECEIPT_COUNT = "TOPLAM SATIŞ FİŞİ SAYISI";
        public const String TOTAL_SALE_AMOUNT = "TOPLAM SATIŞ TUTARI";
        public const String VOID_INFO = "İPTAL BİLGİLERİ";
        public const String TOTAL_VOID_RECEIPT_COUNT = "TOPLAM İPTAL FİŞ SAYISI";
        public const String TOTAL_VOID_AMOUNT = "TOPLAM İPTAL TUTARI";
        public const String ADJUSTMENT_INFO = "İNDİRİM BİLGİLERİ";
        public const String TOTAL_ADJUSTED_AMOUNT = "TOPLAM İNDİRİM TUTARI";
        public const String PAYMENT_INFO = "ÖDEME BİLGİLERİ";
        public const String PAYMENT = "ÖDEME";
        public const String PAYMENT_TYPE = "ÖDEME TİPİ";
        public const String PAYMENT_INDEX = "ÖDEME İNDEKS";
        public const String PAYMENT_AMOUNT = "ÖDEME TOPLAMI";

        public const String CONTEXT = "İÇERİK";
        public const String PRINT = "YAZDIR";
        public const String SAVE = "KAYDET";




        public const string TCKN = "TCKN";

        public const string CUSTOMER_NAME = "MÜŞTERİ ADI";

        public const string COLLECTION_DOC = "FATURA TAHSİLAT";

        public const string PLU_DEFINITION = "PLU TANIMLAMA";

        public const string END_DAY_REPORT = "GÜN SONU RAPORU";

        public const string SAVE_BITMAP_MESSAGE = "LÜTFEN BEKLEYİNİZ.LOGO KAYDEDİLİYOR..";

        public const string FILL_DEPT_NAME = "DEPARTMAN ADI ALANINI DOLDURUNUZ";

        public const string PRINT_SALES_DOCUMENT = "TÜM BELGE YAZDIR";

        public const string BARCODE_TYPE = "BARKOD TİPİ";
        public const string BARCODE_EAN = "EAN";
        public const string BARCODE_QRN = "QRN";
        public const string BARCODE_CO39 = "CO39";
        public const string BARCODE_C128 = "C128";
        public const string BARCODE_NONE = "NONE";

        public const string DOCUMENT_SERIAL = "BELGE SERİ NO";
        public const string CURRENT_ACCOUNT_COLLECTION_DOC = "CARİ HESAP TAHSİLAT FİŞİ";

        public const string END_OF_RECEIPT_NOTE = "FİŞ SONU NOTU";
        public const string LINE = "SATIR";
        public const string GET = "GETİR";
        public const string SET = "KAYDET";

        public const string GROUP_VERSION_INFO = "VERSİYON BİLGİLERİ";
        public const string ECR_VERSION_INFO = "MALİ UYGULAMA VERSİYONU";
        public const string LIBRARY_VERSION_INFO = "KÜTÜPHANE VERSİYONU";

        public const string GROUP_OTHER = "DİĞER";
        public const string DAILY_SUMMARY = "GÜNLÜK ÖZET";

        public const string COLLECT = "TAHSİL";
        public const string COLLECT_INFO = "TAHSİL BİLGİSİ";
        public const string COLLECT_TYPE = "TAHSİLAT TİPİ";
        public const string COLLECT_QUANTITY = "TAHSİLAT ADEDİ";
        public const string COLLECT_AMOUNT = "TAHSİLAT TUTARI";
        public const string NOTE_OF_EXPENSES = "GİDER PUSULASI";
        public const string SELF_EMPLOYEMENT_INVOICE = "SERBEST MESLEK MAKBUZU";

        public const string DOCUMENT_ORDER_NO = "BELGE SIRA NO";

        public const string TAX_OFFICE = "VERGİ DAİRESİ";

        public const string ADDRESS = "ADRES";
        public const string ADDRESS_LINE = "ADRES SATIRI";

        public const string ADD = "EKLE";
        public const string CLEAR = "TEMİZLE";

        public const string UPDATE_CUSTOMER = "MÜŞTERİ GÜNCELLE";

        public const string ADD_CUSTOMER = "MÜŞTERİ EKLE";

        public const string LABEL = "ÜNVAN/ETİKET";

        public const string STOPPAGE = "STOPAJ";

        public const string SEND_STOPPAGE = "STOPAJ UYGULA";

        public const string RETURN_DOCUMENT = "GİDER PUSULASI";

        public const string ADD_SERVICE = "HİZMET EKLE";
        public const string REMOVE_SERVICE = "HİZMET KALDIR";

        public const string INDEX = "İNDEKS";
        public const string SERVICES_SEI = "HİZMETLER";

        public static string SERVICE_DEFINITION = "HİZMET TANIMI";
        public static string BRUT_AMOUNT = "BRÜT ÜCRET";
        public static string WAGE_RATE = "KDV TEVKİFAT %";
        public static string STOPPAGE_RATE = "STOPAJ %";

        public static string KEYPAD_OPTIONS = "TUŞ SEÇENEKLERİ";
        public static string LOCK_KEYS = "TUŞ KİLİTLE";
        public static string UNLOCK_KEYS = "TUŞ KİLİDİ AÇ";

        #endregion

#endif
    }
}
