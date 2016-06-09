#include <jni.h>
#include <iostream>
#include "Hugin_FP300Service.h"
#include "HuginConvert.h"
#include "HuginPrinter.h"

using namespace std;

HuginPrinter huginPrinter;

/*
 * Class:     FP300Service
 * Method:    SerialConnect
 * Signature: (Ljava/lang/String;I)Z
 */
JNIEXPORT jboolean JNICALL Java_Hugin_FP300Service_SerialConnect
  (JNIEnv *env, jobject thisObj, jstring portName, jint baudRate)
{
	return (jboolean)huginPrinter.SerialConnect(
		HuginConvert::ToString(env, portName), 
		(int)baudRate);
}
/*
 * Class:     FP300Service
 * Method:    TCPConnect
 * Signature: (Ljava/lang/String;I)Z
 */
JNIEXPORT jboolean JNICALL Java_Hugin_FP300Service_TCPConnect
  (JNIEnv *env, jobject thisObj, jstring ip, jint port)
{
	return (jboolean)huginPrinter.TcpConnect(
		HuginConvert::ToString(env, ip), 
		(int)port);
}


/*
 * Class:     FP300Service
 * Method:    GetTimeout
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_Hugin_FP300Service_GetTimeout
  (JNIEnv *env, jobject thisObj)
{
	return (jint)huginPrinter.GetTimeout();
}

/*
 * Class:     FP300Service
 * Method:    SetFPUTimeout
 * Signature: (I)V
 */
JNIEXPORT void JNICALL Java_Hugin_FP300Service_SetFPUTimeout
  (JNIEnv *env, jobject thisObj, jint timeout) 
{ 
	huginPrinter.SetTimeout((int)timeout);
}

/*
 * Class:     FP300Service
 * Method:    SetDepartment
 * Signature: (ILjava/lang/String;IDI)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_SetDepartment
  (JNIEnv *env, jobject thisObj, jint id, jstring name, jint vatId, 
  jdouble price, jint weighable) 
{ 
	return HuginConvert::ToString(env, huginPrinter.SetDepartment(
		(int)id,
		HuginConvert::ToVector(env, name), 
		(int)vatId,
		(double)price,
		(int)weighable));
}

/*
 * Class:     FP300Service
 * Method:    GetDepartment
 * Signature: (I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_GetDepartment
  (JNIEnv *env, jobject thisObj, jint deptId)
{
	return HuginConvert::ToString(env, huginPrinter.GetDepartment(
		(int)deptId));
}

/*
 * Class:     FP300Service
 * Method:    SetCreditInfo
 * Signature: (ILjava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_SetCreditInfo
  (JNIEnv *env, jobject thisObj, jint id, jstring name)
{ 
	return HuginConvert::ToString(env, huginPrinter.SetCreditInfo(
		(int)id,
		HuginConvert::ToVector(env, name)));
}

/*
 * Class:     FP300Service
 * Method:    GetCreditInfo
 * Signature: (I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_GetCreditInfo
  (JNIEnv *env, jobject thisObj, jint id) 
{
	return HuginConvert::ToString(env, huginPrinter.GetCreditInfo(
		(int)id));
}

/*
 * Class:     FP300Service
 * Method:    SetCurrencyInfo
 * Signature: (ILjava/lang/String;D)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_SetCurrencyInfo
  (JNIEnv *env, jobject thisObj, jint id, jstring name, jdouble exchangeRate)
{
	return HuginConvert::ToString(env, huginPrinter.SetCurrencyInfo(
		(int)id,
		HuginConvert::ToVector(env, name), 
		(double)exchangeRate));
}

/*
 * Class:     FP300Service
 * Method:    GetCurrencyInfo
 * Signature: (I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_GetCurrencyInfo
  (JNIEnv *env, jobject thisObj, jint index) 
{ 
	return HuginConvert::ToString(env, huginPrinter.GetCurrencyInfo(
		(int)index));
}

/*
 * Class:     FP300Service
 * Method:    SetMainCategory
 * Signature: (ILjava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_SetMainCategory
  (JNIEnv *env, jobject thisObj, jint id, jstring name) 
{
	return HuginConvert::ToString(env, huginPrinter.SetMainCategory(
		(int)id,
		HuginConvert::ToVector(env, name)));
}

/*
 * Class:     FP300Service
 * Method:    GetMainCategory
 * Signature: (I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_GetMainCategory
  (JNIEnv *env, jobject thisObj, jint mainCatId)
{ 
	return HuginConvert::ToString(env, huginPrinter.GetMainCategory(
		(int)mainCatId));
}

/*
 * Class:     FP300Service
 * Method:    SetSubCategory
 * Signature: (ILjava/lang/String;I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_SetSubCategory
  (JNIEnv *env, jobject thisObj, jint id, jstring name, jint mainCatId)
{ 
	return HuginConvert::ToString(env, huginPrinter.SetSubCategory(
		(int)id,
		HuginConvert::ToVector(env, name), 
		(int)mainCatId));
}

/*
 * Class:     FP300Service
 * Method:    GetSubCategory
 * Signature: (I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_GetSubCategory
  (JNIEnv *env, jobject thisObj, jint subCatId)
{ 
	return HuginConvert::ToString(env, huginPrinter.GetSubCategory(
		(int)subCatId));
}

/*
 * Class:     FP300Service
 * Method:    SaveCashier
 * Signature: (ILjava/lang/String;Ljava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_SaveCashier
  (JNIEnv *env, jobject thisObj, jint id, jstring name, jstring password)
{ 
	return HuginConvert::ToString(env, huginPrinter.SaveCashier(
		(int)id,
		HuginConvert::ToVector(env, name), 
		HuginConvert::ToVector(env, password)));
}

/*
 * Class:     FP300Service
 * Method:    GetCashier
 * Signature: (I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_GetCashier
  (JNIEnv *env, jobject thisObj, jint cashierId)
{ 
	return HuginConvert::ToString(env, huginPrinter.GetCashier(
		(int)cashierId));
}

/*
 * Class:     FP300Service
 * Method:    SignInCashier
 * Signature: (ILjava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_SignInCashier
  (JNIEnv *env, jobject thisObj, jint id, jstring password)
{ 
	return HuginConvert::ToString(env, huginPrinter.SignInCashier(
		(int)id,
		HuginConvert::ToVector(env, password)));
}

/*
 * Class:     FP300Service
 * Method:    CheckCashierIsValid
 * Signature: (ILjava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_CheckCashierIsValid
  (JNIEnv *env, jobject thisObj, jint id, jstring password)
{ 
	return HuginConvert::ToString(env, huginPrinter.CheckCashierIsValid(
		(int)id,
		HuginConvert::ToVector(env, password)));
}

/*
 * Class:     FP300Service
 * Method:    GetLogo
 * Signature: (I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_GetLogo
  (JNIEnv *env, jobject thisObj, jint index)
{ 
	return HuginConvert::ToString(env, huginPrinter.GetLogo(
		(int)index));
}

/*
 * Class:     FP300Service
 * Method:    SetLogo
 * Signature: (ILjava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_SetLogo
  (JNIEnv *env, jobject thisObj, jint index, jstring line)
{ 
	return HuginConvert::ToString(env, huginPrinter.SetLogo(
		(int)index,
		HuginConvert::ToVector(env, line)));
}

/*
 * Class:     FP300Service
 * Method:    GetDateTime
 * Signature: ()Ljava/util/Calendar;
 */
JNIEXPORT jobject JNICALL Java_Hugin_FP300Service_GetDateTime
  (JNIEnv *env, jobject thisObj)
{ 
	return HuginConvert::ToDateTime(env, thisObj, huginPrinter.GetDateTime());
}

/*
 * Class:     FP300Service
 * Method:    SetDateTime
 * Signature: (Ljava/util/Calendar;Ljava/util/Calendar;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_SetDateTime
  (JNIEnv *env, jobject thisObj, jobject date, jobject time)
{ 
	return HuginConvert::ToString(env, huginPrinter.SetDateTime(
		HuginConvert::ToTM(env, date), 
		HuginConvert::ToTM(env, time)));
}

/*
 * Class:     FP300Service
 * Method:    GetVATRate
 * Signature: (I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_GetVATRate
  (JNIEnv *env, jobject thisObj, jint index)
{ 
	return HuginConvert::ToString(env, huginPrinter.GetVATRate(
		(int)index));
}

/*
 * Class:     FP300Service
 * Method:    SetVATRate
 * Signature: (ID)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_SetVATRate
  (JNIEnv *env, jobject thisObj, jint index, jdouble taxRate)
{ 
	return HuginConvert::ToString(env, huginPrinter.SetVATRate(
		(int)index,
		(double)taxRate));
}

/*
 * Class:     FP300Service
 * Method:    SaveProduct
 * Signature: (ILjava/lang/String;IDILjava/lang/String;I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_SaveProduct
  (JNIEnv *env, jobject thisObj, jint productId, jstring productName, 
  jint deptId, jdouble price, jint weighable, jstring barcode, jint subCatId)
{ 
	return HuginConvert::ToString(env, huginPrinter.SaveProduct(
		(int)productId,
		HuginConvert::ToVector(env, productName), 
		(int)deptId,
		(double)price,
		(int)weighable,
		HuginConvert::ToVector(env, barcode), 
		(int)subCatId));
}

/*
 * Class:     FP300Service
 * Method:    GetProduct
 * Signature: (I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_GetProduct
  (JNIEnv *env, jobject thisObj, jint pluNo)
{ 
	return HuginConvert::ToString(env, huginPrinter.GetProduct(
		(int)pluNo));
}

/*
 * Class:     FP300Service
 * Method:    SaveGMPConnectionInfo
 * Signature: (Ljava/lang/String;I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_SaveGMPConnectionInfo
  (JNIEnv *env, jobject thisObj, jstring ip, jint port)
{ 
	return HuginConvert::ToString(env, huginPrinter.SaveGMPConnectionInfo(
		HuginConvert::ToVector(env, ip), 
		(int)port));
}

/*
 * Class:     FP300Service
 * Method:    GetProgramOptions
 * Signature: (I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_GetProgramOptions
  (JNIEnv *env, jobject thisObj, jint progEnum)
{ 
	return HuginConvert::ToString(env, huginPrinter.GetProgramOptions(
		(int)progEnum));
}

/*
 * Class:     FP300Service
 * Method:    SaveProgramOptions
 * Signature: (ILjava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_SaveProgramOptions
  (JNIEnv *env, jobject thisObj, jint progEnum, jstring progValue)
{ 
	return HuginConvert::ToString(env, huginPrinter.SaveProgramOptions(
		(int)progEnum,
		HuginConvert::ToVector(env, progValue)));
}

/*
 * Class:     FP300Service
 * Method:    PrintDocumentHeader
 * Signature: ()Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_PrintDocumentHeader__
  (JNIEnv *env, jobject thisObj)
{ 
	return HuginConvert::ToString(env, huginPrinter.PrintDocumentHeader());
}

/*
 * Class:     FP300Service
 * Method:    PrintDocumentHeader
 * Signature: (Ljava/lang/String;DI)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_PrintDocumentHeader__Ljava_lang_String_2DI
  (JNIEnv *env, jobject thisObj, jstring tckn_vkn, jdouble amount, jint docType)
{ 
	return HuginConvert::ToString(env, huginPrinter.PrintDocumentHeader(
		HuginConvert::ToVector(env, tckn_vkn), 
		(double)amount,
		(int)docType));
}

/*
 * Class:     FP300Service
 * Method:    PrintParkDocument
 * Signature: (Ljava/lang/String;Ljava/util/Calendar;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_PrintParkDocument
  (JNIEnv *env, jobject thisObj, jstring plate, jobject entrenceDate)
{ 
	return HuginConvert::ToString(env, huginPrinter.PrintParkDocument(
		HuginConvert::ToVector(env, plate), 
		HuginConvert::ToTM(env, entrenceDate)));
}

/*
 * Class:     FP300Service
 * Method:    PrintItem
 * Signature: (IDDLjava/lang/String;II)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_PrintItem
  (JNIEnv *env, jobject thisObj, jint PLUNo, jdouble quantity, jdouble amount, 
  jstring name, jint deptId, jint weighable)
{ 
	return HuginConvert::ToString(env, huginPrinter.PrintItem(
		(int)PLUNo,
		(double)quantity,
		(double)amount,
		HuginConvert::ToVector(env, name), 
		(int)deptId,
		(int)weighable));
}

/*
 * Class:     FP300Service
 * Method:    PrintAdjustment
 * Signature: (IDI)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_PrintAdjustment
  (JNIEnv *env, jobject thisObj, jint adjustmentType, jdouble amount, jint percentage)
{ 
	return HuginConvert::ToString(env, huginPrinter.PrintAdjustment(
		(int)adjustmentType,
		(double)amount,
		(int)percentage));
}

/*
 * Class:     FP300Service
 * Method:    Correct
 * Signature: ()Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_Correct
  (JNIEnv *env, jobject thisObj)
{ 
	return HuginConvert::ToString(env, huginPrinter.Correct());
}

/*
 * Class:     FP300Service
 * Method:    Void
 * Signature: (ID)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_Void
  (JNIEnv *env, jobject thisObj, jint PLUNo, jdouble quantity)
{ 
	return HuginConvert::ToString(env, huginPrinter.Void(
		(int)PLUNo,
		(double)quantity));
}

/*
 * Class:     FP300Service
 * Method:    PrintSubtotal
 * Signature: (Z)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_PrintSubtotal
  (JNIEnv *env, jobject thisObj, jboolean isQuery)
{ 
	return HuginConvert::ToString(env, huginPrinter.PrintSubtotal(
		(bool)isQuery));
}

/*
 * Class:     FP300Service
 * Method:    PrintPayment
 * Signature: (IID)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_PrintPayment
  (JNIEnv *env, jobject thisObj, jint paymentType, jint index, jdouble paidTotal)
{ 
	return HuginConvert::ToString(env, huginPrinter.PrintPayment(
		(int)paymentType,
		(int)index,
		(double)paidTotal));
}

/*
 * Class:     FP300Service
 * Method:    CloseReceipt
 * Signature: (Z)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_CloseReceipt
  (JNIEnv *env, jobject thisObj, jboolean slipCopy)
{ 
	return HuginConvert::ToString(env, huginPrinter.CloseReceipt(
		(bool)slipCopy));
}

/*
 * Class:     FP300Service
 * Method:    VoidReceipt
 * Signature: ()Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_VoidReceipt
  (JNIEnv *env, jobject thisObj)
{ 
	return HuginConvert::ToString(env, huginPrinter.VoidReceipt());
}

/*
 * Class:     FP300Service
 * Method:    PrintRemarkLine
 * Signature: (Ljava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_PrintRemarkLine
  (JNIEnv *env, jobject thisObj, jobjectArray line)
{ 
	return HuginConvert::ToString(env, huginPrinter.PrintRemarkLine(
		HuginConvert::ToVectorCollection(env, line)));
}

/*
 * Class:     FP300Service
 * Method:    PrintReceiptBarcode
 * Signature: (Ljava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_PrintReceiptBarcode
  (JNIEnv *env, jobject thisObj, jstring barcode)
{ 
	return HuginConvert::ToString(env, huginPrinter.PrintReceiptBarcode(
		HuginConvert::ToVector(env, barcode)));
}

/*
 * Class:     FP300Service
 * Method:    PrintXReport
 * Signature: (I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_PrintXReport
  (JNIEnv *env, jobject thisObj, jint copy)
{ 
	return HuginConvert::ToString(env, huginPrinter.PrintXReport(
		(int)copy));
}

/*
 * Class:     FP300Service
 * Method:    PrintXPluReport
 * Signature: (III)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_PrintXPluReport
  (JNIEnv *env, jobject thisObj, jint firstPlu, jint lastPlu, jint copy)
{ 
	return HuginConvert::ToString(env, huginPrinter.PrintXPluReport(
		(int)firstPlu,
		(int)lastPlu,
		(int)copy));
}

/*
 * Class:     FP300Service
 * Method:    PrintZReport
 * Signature: ()Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_PrintZReport
  (JNIEnv *env, jobject thisObj)
{ 
	return HuginConvert::ToString(env, huginPrinter.PrintZReport());
}

/*
 * Class:     FP300Service
 * Method:    PrintPeriodicZZReport
 * Signature: (IIIZ)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_PrintPeriodicZZReport
  (JNIEnv *env, jobject thisObj, jint firstZ, jint lastZ, jint copy, jboolean detail)
{ 
	return HuginConvert::ToString(env, huginPrinter.PrintPeriodicZZReport(
		(int)firstZ,
		(int)lastZ,
		(int)copy,
		(bool)detail));
}

/*
 * Class:     FP300Service
 * Method:    PrintPeriodicDateReport
 * Signature: (Ljava/util/Calendar;Ljava/util/Calendar;IZ)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_PrintPeriodicDateReport
  (JNIEnv *env, jobject thisObj, jobject firstDay, jobject lastDay, jint copy, 
  jboolean detail)
{ 
	return HuginConvert::ToString(env, huginPrinter.PrintPeriodicDateReport(
		HuginConvert::ToTM(env, firstDay), 
		HuginConvert::ToTM(env, lastDay), 
		(int)copy,
		(bool)detail));
}

/*
 * Class:     FP300Service
 * Method:    PrintEJPeriodic
 * Signature: (Ljava/util/Calendar;I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_PrintEJPeriodic__Ljava_util_Calendar_2I
  (JNIEnv *env, jobject thisObj, jobject day, jint copy)
{ 
	return HuginConvert::ToString(env, huginPrinter.PrintEJPeriodic(
		HuginConvert::ToTM(env, day), 
		(int)copy));
}

/*
 * Class:     FP300Service
 * Method:    PrintEJPeriodic
 * Signature: (Ljava/util/Calendar;Ljava/util/Calendar;I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_PrintEJPeriodic__Ljava_util_Calendar_2Ljava_util_Calendar_2I
  (JNIEnv *env, jobject thisObj, jobject startTime, jobject endTime, jint copy)
{ 
	return HuginConvert::ToString(env, huginPrinter.PrintEJPeriodic(
		HuginConvert::ToTM(env, startTime), 
		HuginConvert::ToTM(env, endTime), 
		(int)copy));
}

/*
 * Class:     FP300Service
 * Method:    PrintEJPeriodic
 * Signature: (IIIII)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_PrintEJPeriodic__IIIII
  (JNIEnv *env, jobject thisObj, jint ZStartId, jint docStartId, jint ZEndId, 
  jint docEndId, jint copy)
{ 
	return HuginConvert::ToString(env, huginPrinter.PrintEJPeriodic(
		(int)ZStartId,
		(int)docStartId,
		(int)ZEndId,
		(int)docEndId,
		(int)copy));
}

/*
 * Class:     FP300Service
 * Method:    PrintEJDetail
 * Signature: (I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_PrintEJDetail
  (JNIEnv *env, jobject thisObj, jint copy)
{ 
	return HuginConvert::ToString(env, huginPrinter.PrintEJDetail(
		(int)copy));
}

/*
 * Class:     FP300Service
 * Method:    EnterServiceMode
 * Signature: (Ljava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_EnterServiceMode
  (JNIEnv *env, jobject thisObj, jstring password)
{ 
	return HuginConvert::ToString(env, huginPrinter.EnterServiceMode(
		HuginConvert::ToVector(env, password)));
}

/*
 * Class:     FP300Service
 * Method:    ExitServiceMode
 * Signature: (Ljava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_ExitServiceMode
  (JNIEnv *env, jobject thisObj, jstring password)
{ 
	return HuginConvert::ToString(env, huginPrinter.ExitServiceMode(
		HuginConvert::ToVector(env, password)));
}

/*
 * Class:     FP300Service
 * Method:    ClearDailyMemory
 * Signature: ()Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_ClearDailyMemory
  (JNIEnv *env, jobject thisObj)
{ 
	return HuginConvert::ToString(env, huginPrinter.ClearDailyMemory());
}

/*
 * Class:     FP300Service
 * Method:    FactorySettings
 * Signature: ()Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_FactorySettings
  (JNIEnv *env, jobject thisObj)
{ 
	return HuginConvert::ToString(env, huginPrinter.FactorySettings());
}

/*
 * Class:     FP300Service
 * Method:    CloseFM
 * Signature: ()Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_CloseFM
  (JNIEnv *env, jobject thisObj)
{ 
	return HuginConvert::ToString(env, huginPrinter.CloseFM());
}

/*
 * Class:     FP300Service
 * Method:    SetExternalDevAddress
 * Signature: (Ljava/lang/String;I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_SetExternalDevAddress
  (JNIEnv *env, jobject thisObj, jstring ip, jint port)
{ 
	return HuginConvert::ToString(env, huginPrinter.SetExternalDevAddress(
		HuginConvert::ToVector(env, ip), 
		(int)port));
}

/*
 * Class:     FP300Service
 * Method:    UpdateFirmware
 * Signature: (Ljava/lang/String;I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_UpdateFirmware
  (JNIEnv *env, jobject thisObj, jstring ip, jint port)
{ 
	return HuginConvert::ToString(env, huginPrinter.UpdateFirmware(
		HuginConvert::ToVector(env, ip), 
		(int)port));
}

/*
 * Class:     FP300Service
 * Method:    PrintLogs
 * Signature: (Ljava/util/Calendar;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_PrintLogs
  (JNIEnv *env, jobject thisObj, jobject date)
{ 
	return HuginConvert::ToString(env, huginPrinter.PrintLogs(
		HuginConvert::ToTM(env, date)));
}

/*
 * Class:     FP300Service
 * Method:    CreateDB
 * Signature: ()Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_CreateDB
  (JNIEnv *env, jobject thisObj)
{ 
	return HuginConvert::ToString(env, huginPrinter.CreateDB());
}

/*
 * Class:     FP300Service
 * Method:    Connect
 * Signature: (LDeviceInfo;Ljava/lang/String;Ljava/lang/String;)Z
 */
JNIEXPORT jboolean JNICALL Java_Hugin_FP300Service_Connect
  (JNIEnv *env, jobject thisObj, jobject devInfo, jstring fiscalRegNo, jstring licanceKey)
{ 
	return (jboolean)huginPrinter.Connect(
		HuginConvert::ToDevInfo(env, devInfo), 
		HuginConvert::ToString(env, fiscalRegNo), 
		HuginConvert::ToString(env, licanceKey));
}

/*
 * Class:     FP300Service
 * Method:    CheckPrinterStatus
 * Signature: ()Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_CheckPrinterStatus
  (JNIEnv *env, jobject thisObj)
{ 
	return HuginConvert::ToString(env, huginPrinter.CheckPrinterStatus());
}

/*
 * Class:     FP300Service
 * Method:    GetLastResponse
 * Signature: ()Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_GetLastResponse
  (JNIEnv *env, jobject thisObj)
{ 
	return HuginConvert::ToString(env, huginPrinter.GetLastResponse());
}

/*
 * Class:     FP300Service
 * Method:    CashIn
 * Signature: (D)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_CashIn
  (JNIEnv *env, jobject thisObj, jdouble amount)
{ 
	return HuginConvert::ToString(env, huginPrinter.CashIn(
		(double)amount));
}

/*
 * Class:     FP300Service
 * Method:    CashOut
 * Signature: (D)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_CashOut
  (JNIEnv *env, jobject thisObj, jdouble amount)
{ 
	return HuginConvert::ToString(env, huginPrinter.CashOut(
		(double)amount));
}

/*
 * Class:     FP300Service
 * Method:    CloseNFReceipt
 * Signature: ()Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_CloseNFReceipt
  (JNIEnv *env, jobject thisObj)
{ 
	return HuginConvert::ToString(env, huginPrinter.CloseNFReceipt());
}

/*
 * Class:     FP300Service
 * Method:    Fiscalize
 * Signature: (Ljava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_Fiscalize
  (JNIEnv *env, jobject thisObj, jstring password)
{ 
	return HuginConvert::ToString(env, huginPrinter.Fiscalize(
		HuginConvert::ToVector(env, password)));
}

/*
 * Class:     FP300Service
 * Method:    StartFMTest
 * Signature: ()Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_StartFMTest
  (JNIEnv *env, jobject thisObj)
{ 
	return HuginConvert::ToString(env, huginPrinter.StartFMTest());
}

/*
 * Class:     FP300Service
 * Method:    GetDrawerInfo
 * Signature: ()Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_GetDrawerInfo
  (JNIEnv *env, jobject thisObj)
{ 
	return HuginConvert::ToString(env, huginPrinter.GetDrawerInfo());
}

/*
 * Class:     FP300Service
 * Method:    GetLastDocumentInfo
 * Signature: (Z)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_GetLastDocumentInfo
  (JNIEnv *env, jobject thisObj, jboolean lastZ)
{ 
	return HuginConvert::ToString(env, huginPrinter.GetLastDocumentInfo(
		(bool)lastZ));
}

/*
 * Class:     FP300Service
 * Method:    GetServiceCode
 * Signature: ()Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_GetServiceCode
  (JNIEnv *env, jobject thisObj)
{ 
	return HuginConvert::ToString(env, huginPrinter.GetServiceCode());
}

/*
 * Class:     FP300Service
 * Method:    InterruptReport
 * Signature: ()Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_InterruptReport
  (JNIEnv *env, jobject thisObj)
{ 
	return HuginConvert::ToString(env, huginPrinter.InterruptReport());
}

/*
 * Class:     FP300Service
 * Method:    InterruptReport
 * Signature: ()Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_ClearError
  (JNIEnv *env, jobject thisObj)
{ 
	return HuginConvert::ToString(env, huginPrinter.ClearError());
}

/*
 * Class:     FP300Service
 * Method:    OpenDrawer
 * Signature: ()Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_OpenDrawer
  (JNIEnv *env, jobject thisObj)
{ 
	return HuginConvert::ToString(env, huginPrinter.OpenDrawer());
}

/*
 * Class:     FP300Service
 * Method:    SaveNetworkSettings
 * Signature: (Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_SaveNetworkSettings
  (JNIEnv *env, jobject thisObj, jstring ip, jstring subnet, jstring gateway)
{ 
	return HuginConvert::ToString(env, huginPrinter.SaveNetworkSettings(
		HuginConvert::ToVector(env, ip), 
		HuginConvert::ToVector(env, subnet), 
		HuginConvert::ToVector(env, gateway)));
}

/*
 * Class:     FP300Service
 * Method:    SetEJLimit
 * Signature: (I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_SetEJLimit
  (JNIEnv *env, jobject thisObj, jint index)
{ 
	return HuginConvert::ToString(env, huginPrinter.SetEJLimit(
		(int)index));
}

/*
 * Class:     FP300Service
 * Method:    StartEJ
 * Signature: ()Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_StartEJ
  (JNIEnv *env, jobject thisObj)
{ 
	return HuginConvert::ToString(env, huginPrinter.StartEJ());
}

/*
 * Class:     FP300Service
 * Method:    StartFM
 * Signature: (I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_StartFM
  (JNIEnv *env, jobject thisObj, jint fiscalNo)
{ 
	return HuginConvert::ToString(env, huginPrinter.StartFM(
		(int)fiscalNo));
}

/*
 * Class:     FP300Service
 * Method:    StartNFReceipt
 * Signature: ()Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_StartNFReceipt
  (JNIEnv *env, jobject thisObj)
{ 
	return HuginConvert::ToString(env, huginPrinter.StartNFReceipt());
}

/*
 * Class:     FP300Service
 * Method:    StartNFDocument
 * Signature: (I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_StartNFDocument
  (JNIEnv *env, jobject thisObj, jint documentType)
{ 
	return HuginConvert::ToString(env, huginPrinter.StartNFDocument(
		(int)documentType));
}

/*
 * Class:     FP300Service
 * Method:    TransferFile
 * Signature: (Ljava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_TransferFile
  (JNIEnv *env, jobject thisObj, jstring fileName)
{ 
	return HuginConvert::ToString(env, huginPrinter.TransferFile(
		HuginConvert::ToString(env, fileName)));
}

/*
 * Class:     FP300Service
 * Method:    WriteNFLine
 * Signature: ([Ljava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_WriteNFLine
  (JNIEnv *env, jobject thisObj, jobjectArray lines)
{ 
	return HuginConvert::ToString(env, huginPrinter.WriteNFLine(
		HuginConvert::ToVectorCollection(env, lines)));
}

/*
 * Class:     FP300Service
 * Method:    GetPrinterDate
 * Signature: ()Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_GetPrinterDate
  (JNIEnv *env, jobject thisObj)
{ 
	return HuginConvert::ToString(env, huginPrinter.GetPrinterDate());
}

/*
 * Class:     FP300Service
 * Method:    PrintEJReport
 * Signature: (IIIII)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_PrintEJReport
  (JNIEnv *env, jobject thisObj, jint firstZNo, jint firstDocId, jint lastZNo, 
  jint lastDocId, jint copy)
{ 
	return HuginConvert::ToString(env, huginPrinter.PrintEJReport(
		(int)firstZNo,
		(int)firstDocId,
		(int)lastZNo,
		(int)lastDocId,
		(int)copy));
}

/*
 * Class:     FP300Service
 * Method:    GetLastLog
 * Signature: ()Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_GetLastLog
  (JNIEnv *env, jobject thisObj)
{ 
	return HuginConvert::ToString(env, huginPrinter.GetLastLog());
}

/*
 * Class:     FP300Service
 * Method:    GetEFTAuthorisation
 * Signature: (DILjava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_GetEFTAuthorisation
  (JNIEnv *env, jobject thisObj, jdouble amount, jint installment, jstring cardNumber)
{
	return HuginConvert::ToString(env, huginPrinter.GetEFTAuthorisation(
		(double)amount,
		(int)installment,
		HuginConvert::ToVector(env, cardNumber)));
}

/*
 * Class:     FP300Service
 * Method:    VoidPayment
 * Signature: (I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_VoidPayment
  (JNIEnv *env, jobject thisObj, jint paymentSequenceNo)
{
	return HuginConvert::ToString(env, huginPrinter.VoidPayment(
		(int)paymentSequenceNo));
}

/*
 * Class:     FP300Service
 * Method:    PrintSystemInfoReport
 * Signature: (I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_PrintSystemInfoReport
  (JNIEnv *env, jobject thisObj, jint copy)
{
	return HuginConvert::ToString(env, huginPrinter.PrintSystemInfoReport(
		(int)copy));
}

/*
 * Class:     FP300Service
 * Method:    PrintReceiptTotalReport
 * Signature: (Ljava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_PrintReceiptTotalReport
  (JNIEnv *env, jobject thisObj, jint copy)
{
	return HuginConvert::ToString(env, huginPrinter.PrintReceiptTotalReport(
		(int)copy));
}

/*
 * Class:     Hugin_FP300Service
 * Method:    PrintJSONDocumentDeptOnly
 * Signature: (Ljava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_PrintJSONDocumentDeptOnly
  (JNIEnv *env, jobject, jstring a)
{
	return HuginConvert::ToString(env, huginPrinter.PrintJSONDocumentDeptOnly(
		HuginConvert::ToString(env, a)));
}
/*
 * Class:     FP300Service
 * Method:    PrintDepartment
 * Signature: (DILjava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_PrintDepartment
  (JNIEnv *env, jobject thisObj, jint a,jdouble b,jdouble c,jstring d,jint e)
{
	return HuginConvert::ToString(env, huginPrinter.PrintDepartment(
		(int)a, (double)b, (double) c, HuginConvert::ToString(env, d), (int) e));
}
/*
 * Class:     FP300Service
 * Method:    VoidDepartment
 * Signature: (DILjava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_VoidDepartment
  (JNIEnv *env, jobject, jint a,jstring b,jdouble c)
{
	return HuginConvert::ToString(env, huginPrinter.VoidDepartment(
		(int)a, HuginConvert::ToString(env, b), (double) c));
}
/*
 * Class:     Hugin_FP300Service
 * Method:    GetEFTCardInfo
 * Signature: (DILjava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_GetEFTCardInfo
  (JNIEnv *env, jobject, jdouble a)
{
	return HuginConvert::ToString(env, huginPrinter.GetEFTCardInfo(
		(double) a));
}
/*
 * Class:     Hugin_FP300Service
 * Method:    VoidEFTPayment
 * Signature: (DILjava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_VoidEFTPayment
  (JNIEnv *env, jobject, jint a,jint b,jint c)
{
	return HuginConvert::ToString(env, huginPrinter.VoidEFTPayment(
		(int) a, (int) b, (int) c));
}
/*
 * Class:     Hugin_FP300Service
 * Method:    RefundEFTPayment
 * Signature: (DILjava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_RefundEFTPayment
  (JNIEnv *env, jobject, jint a)
{
	return HuginConvert::ToString(env, huginPrinter.RefundEFTPayment(
		(int) a));
}

/*
 * Class:     Hugin_FP300Service
 * Method:    GetBankListOnEFT
 * Signature: (DILjava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_GetBankListOnEFT
  (JNIEnv *env, jobject)
{
	return HuginConvert::ToString(env, huginPrinter.GetBankListOnEFT());
}

/*
 * Class:     Hugin_FP300Service
 * Method:    GetSalesInfo
 * Signature: (DILjava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_Hugin_FP300Service_GetSalesInfo
  (JNIEnv *env,jobject)
{
	return HuginConvert::ToString(env, huginPrinter.GetSalesInfo());
}
