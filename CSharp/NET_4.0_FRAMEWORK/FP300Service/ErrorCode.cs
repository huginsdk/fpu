using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;


namespace FP300Service
{
    public enum ErrorCode
    {
        [Description("Operation is successful")]
        ERR_SUCCESS = 0,

        [Description("Missing data (it should come up as length) Call function again")]
        ERR_DATA_CORRUPT = 1,

        [Description("Data changed Call function again")]
        ERR_CRC = 2,

        [Description("Application state is not suitable ECR state is not support called function. For example: You cannot call PrintItem function in payment state, or you cannot call VoidReceipt if payment start.")]
        ERR_INVALID_STATE = 3,

        [Description("Invalid command ECR model don't support called function.")]
        ERR_INVALID_CMD = 4,

        [Description("Invalid parameter Given parameter of function is invalid.")]
        ERR_INVALID_PRM = 5,

        [Description("Operation failed Call function again")]
        ERR_OPERATION_FAILED = 6,

        [Description("Clear required after error ECR waits confirm from Cashier to continue current operation. Call ClearError function to continue. It occurs usually new paper plugged.")]
        ERR_CLEAR_REQUIRED = 7,

        [Description("No paper on printer ECR returns this error if there is no paper. If you get this error, check printer status until gets error code 7. After papers plugged (error code 7), you have to call ClearError function to continue.")]
        ERR_NO_PAPER = 8,

        [Description("Could not match device You have to call authorised service for match ECR and PC.")]
        ERR_MATCH_ERROR = 9,

        [Description("Sequence number is not sequenced")]
        ERR_SEQUENCE_NUMBER = 10,

        /******************************************************************************************************************************/

        [Description("Error occured when getting fiscal memory info ECR is blocked, Service intervention required.")]
        ERR_FM_LOAD_ERROR = 11,

        [Description("Fiscal memory not connected ECR is blocked, Service intervention required.")]
        ERR_FM_REMOVED = 12,

        [Description("Fiscal Memory mismatch Service intervention required or if you get this error when connect to ECR, fiscal id which given as parameter differ from ECR's fiscal id.")]
        ERR_FM_MISMATCH = 13,

        [Description("Fiscal memory needs to format ECR is blocked, Service intervention required.")]
        ERR_NEW_FM = 14,

        [Description("Error occured when formatting FM ECR is blocked, Service intervention required.")]
        ERR_FM_INIT = 15,

        [Description("FM could not fiscalize ECR is blocked, Service intervention required.")]
        ERR_FM_FISCALIZE = 16,

        [Description("Daily Z limit * This error occurs, if you exceed Z report count per a day. You have to wait next day to take Z report.*")]
        ERR_FM_DAILY_LIMIT = 17,

        [Description("FM is full ECR is blocked, Service intervention required.")]
        ERR_FM_FULL = 18,

        [Description("FM formatted before ECR is blocked, Service intervention required.")]
        ERR_FM_FORMATTED = 19,

        [Description("FM closed ECR is blocked, Service intervention required.")]
        ERR_FM_CLOSED = 20,

        [Description("Invalid FM ECR is blocked, Service intervention required.")]
        ERR_FM_INVALID = 21,

        [Description("Certificate could not getting SAM card ECR is blocked, Service intervention required.")]
        ERR_FM_SAM_CARD = 22,

        /****************************************************************************************************************/

        [Description("Error occured when getting EJ(Electronic journal) info Electronic journal may broke down. Service intervention required.")]
        ERR_EJ_LOAD = 31,

        [Description("EJ removed if electronic journal is removedi this error occurs. Plug electronic journal and call ClearError function.")]
        ERR_EJ_REMOVED = 32,

        [Description("EJ mismatch This error occurs if different ECR's EJ plugged.")]
        ERR_EJ_MISMATCH = 33,

        [Description("Old EJ (Only EJ reportsı) If old EJ plugged to ECR, this error occurs. You can only EJ reports if you get this error.")]
        ERR_EJ_OLD = 34,

        [Description("New EJ, waiting for approval Confirm new EJ, call ClearError.")]
        ERR_NEW_EJ = 35,

        [Description("EJ could not change, Z report required To change EJ, you have to take Z Report. Last document have to Z report to pass new EJ.")]
        ERR_EJ_ZREQUIRED = 36,

        [Description("EJ could not initialize Plug different EJ.")]
        ERR_EJ_INIT = 37,

        [Description("EJ is full You have to take Z Report and plug new EJ.")]
        ERR_EJ_FULL = 38,

        [Description("EJ formatted before Format new EJ.")]
        ERR_EJ_FORMATTED = 39,

        /***************************************************************************************************************************/

        [Description("Receipt limit has been exceeded If subtotal exceed receipt limit, this error occurs.")]
        ERR_RCPT_TOTAL_LIMIT = 51,

        [Description("Sale count has been exceeded on receipt Max sale count is 128. You have close document after payment.")]
        ERR_RCPT_SALE_COUNT = 52,

        [Description("Invalid sale This error occurs if sale amount is zero.")]
        ERR_INVALID_SALE = 53,

        [Description("Invalid void operation If there is no item to be voided, this error occurs.")]
        ERR_INVALID_VOID = 54,

        [Description("Invalid correction operation If last item cannot be correct, this error occurs. For example you cannot correct payment.")]
        ERR_INVALID_CORR = 55,

        [Description("Invalid discount or fee Check you adjustment values. For example you cannot apply %100 discount.")]
        ERR_INVALID_ADJ = 56,

        [Description("Invalid payment Check you payment parameters.")]
        ERR_INVALID_PAYMENT = 57,

        [Description("Payment limit has been exceeded Maximum payment count is 10, if you get this error, you have to pay remain total. ECR cannot allows partial payment if you get this error.")]
        ERR_PAYMENT_LIMIT = 58,

        [Description("Exceed daily sale Daily quantity total is 9999999 for same product. You have to take Z report for sell product which exceeded limit.")]
        ERR_DAILY_PLU_LIMIT = 59,

        [Description("Exceed departman sale amount limit.")]
        ERR_OVER_DEPT_LIMIT = 60,

        /************************************************************************************************************************/

        [Description("VAT rate not defined before You have to define VAT rate firstly.")]
        ERR_VAT_NOT_DEFINED = 71,

        [Description("Section not defined before You have to define section firstly.")]
        ERR_SECTION_NOT_DEFINED = 72,

        [Description("PLU not defined before You have to define PLU firstly.")]
        ERR_PLU_NOT_DEFINED = 73,

        [Description("Invalid or missing credit payment info You have to define Credit firstly.")]
        ERR_CREDIT_NOT_DEFINED = 74,

        [Description("Invalid or missing currency payment info You have to define foreign currency firstly.")]
        ERR_CURRENCY_NOT_DEFINED = 75,

        [Description("No records were found on EJ Check parameters.")]
        ERR_EJSEARCH_NO_RESULT = 76,

        [Description("No records were found on FM Check parameters.")]
        ERR_FMSEARCH_NO_RESULT = 77,

        [Description("Invalid sub-category You have to define sub category firstly.")]
        ERR_SUBCAT_NOT_DEFINED = 78,

        [Description("No result were found on file search Check parameters.")]
        ERR_FILESEARCH_NO_RESULT = 79,

        /************************************************************************************************************************/

        [Description("Insufficient cashier authority You have to login as authorized cashier.")]
        ERR_CASHIER_AUTH = 91,

        [Description("FPU has sale Ex: Vat rate cannot change if last document is not Z Report.")]
        ERR_HAS_SALE = 92,

        [Description("FPU has receipt, Z required Ex: Logo cannot change if last document is not Z Report.")]
        ERR_HAS_RECEIPT = 93,

        [Description("Not enough cash on drawer Ex. If there is 20TL on cash drawer, you cannot give customer change 21 TL, or you cannot cash out 21 TL.")]
        ERR_NOT_ENOUGH_MONEY = 94,

        [Description("Daily receipt limit has been exceeded You have to take Z Report. You cannot start new receipt.")]
        ERR_DAILY_RCPT_COUNT = 95,

        [Description("Daily TOTAL limit has been exceeded You have to take Z Report. You cannot start new receipt.")]
        ERR_DAILY_TOTAL_LIMIT = 96,

        [Description("ECR is not fiscal You have to fiscalize ECR, if you want to do fiscal operation.")]
        ERR_ECR_NONFISCAL = 97,

        /************************************************************************************************************************/

        [Description("Line length too long Check parameter.")]
        ERR_LINE_LEN = 111,

        [Description("Invalid VAT rate Define VAT rate.")]
        ERR_INVALID_VATRATE = 112,

        [Description("Invalid depertmant number Define department. ")]
        ERR_INVALID_DEPTNO = 113,

        [Description("Invalid PLU number Define PLU.")]
        ERR_INVALID_PLUNO = 114,

        [Description("Invalid definiton(product name, PLU name, section name,....) Check parameters.")]
        ERR_INVALID_NAME = 115,

        [Description("Invalid barcode Check parameter.")]
        ERR_INVALID_BARCODE = 116,

        [Description("Invalid option Check parameter.")]
        ERR_INVALID_OPTION = 117,

        [Description("Invalid quantity Check parameter.")]
        ERR_INVALID_QUANTITY = 119,

        [Description("Invalid amount Check parameter.")]
        ERR_INVALID_AMOUNT = 120,

        [Description("Invalid ECR fiscal serial number")]
        ERR_INVALID_FISCAL_ID = 121,

        /************************************************************************************************************************/

        [Description("Cover opened ECR is blocked, Service intervention required.")]
        ERR_BLK_COVER_OPEN = 131,

        [Description("FM mesh has damaged ECR is blocked, Service intervention required.")]
        ERR_BLK_FM_MESH = 132,

        [Description("HUB mesh has damaged ECR is blocked, Service intervention required.")]
        ERR_BLK_HUB_MESH = 133,

        [Description("Z report required(After 24 hours) ECR waits confirm to take Z Report, call ClearError.")]
        ERR_BLK_Z_REQUIRED = 134,

        [Description("Invalid EJ Plug EJ and restart ECR.")]
        ERR_BLK_EJ_INVALID = 135,

        [Description("Certificates could not load ECR is blocked, Service intervention required.")]
        ERR_BLK_NOT_LOAD_CERTIFICATE = 136,

        [Description("Set date and time ECR is blocked, Service intervention required. Set date and time in service menu.")]
        ERR_BLK_DT = 137,

        [Description("Incompatible daily and FM ECR is blocked, Service intervention required. Clear daily memory in service menu.")]
        ERR_BLK_DAILY_FISCAL = 138,

        [Description("Database error ECR is blocked, Service intervention required. Restore factory settings in service menu.")]
        ERR_BLK_DB = 139,

        [Description("Log error ECR is blocked, Service intervention required.")]
        ERR_BLK_LOG = 140,

        [Description("SRAM error ECR is blocked, Service intervention required.")]
        ERR_BLK_SRAM = 141,

        [Description("Incompatible certificate ECR is blocked, Service intervention required.")]
        ERR_BLK_CERT_MISMATCH = 142,

        [Description("Version error ECR is blocked, Service intervention required.")]
        ERR_BLK_VERSION = 143,

        [Description("Daily log limit has been exceeded ECR is blocked, Service intervention required.")]
        ERR_BLK_DAILY_LOG_OVER = 144,

        [Description("Re-start ECR Power off-on")]
        ERR_BLK_RESTART_ECR = 145,

        [Description("Daily incorrect password has been exceeded by cashier or service *Wait 24 hour and try to sign in locked cashier or log in different cashier. *")]
        ERR_BLK_LOCK_SIGN_IN = 146,

        [Description("Could not connect to GIB server, try again Checks ECR internet connection and then call ClearError")]
        ERR_BLK_RETRY_TO_CONNECT_RAD = 148,

        [Description("Certificate loaded, restart ECR")]
        ERR_BLK_LOADED_CERTIFICATE = 149,

        [Description("Secured area(HSM) format error")]
        ERR_BLK_HSM_FORMAT = 150,

        [Description("Required jumper clear")]
        ERR_BLK_REQUIRED_JUMPER_CLEAR = 151,

        /************************************************************************************************************************/

        [Description("No EFT connection Check you EFT-POS connection, or if you didnt match ECR and EFT-POS you have to match devices in service menu.")]
        ERR_EFT_NOT_CONNECT = 170,

        [Description("EFT-POS state is invalid Check EFT-POS and then try again.")]
        ERR_EFT_INVALID_STATE = 171,

        [Description("Invalid Credit Card Card is not supported for EFT-POS")]
        ERR_EFT_INCORRECT_CARD = 172,

        [Description("Different amount is not supported You cannot change amount if you get card info.")]
        ERR_EFT_DIFFERENT_AMOUNT = 173,

        [Description("No provision Check EFT-POS and try again.")]
        ERR_EFT_NO_PROVISION = 174,

        [Description("Unsupported installment Try with EFT-POS payment with different installment.")]
        ERR_EFT_UNSUPPORTED_INSTALLMENT = 175,

        [Description("Payment void error Payment cannot voided. Continue payment or close receipt.")]
        ERR_EFT_VOID_FAIL = 176,

        [Description("EFT refund operation failed")]
        ERR_EFT_RETURN_FAIL = 177,

        [Description("EFT slip copy operation failed")]
        ERR_EFT_SLIP_COPY_FAIL = 178,

        [Description("Invalid EFT mode, you cannot do this operation in current installment-point management mode (Offline)")]
        ERR_INVALID_OFFLINE_EFT_MODE = 179,

        [Description("Invalid EFT mode")]
        ERR_INVALID_EFT_MODE = 180
    }

}