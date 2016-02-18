#pragma once

#include <jni.h>
#include <string>
#include <vector>
#include "DevInfo.h"
#include "JSONDocument.h"

using namespace std;

class HuginConvert
{
public:
	static string ToString(JNIEnv *env, jstring str)
	{
		const char *inCStr = env->GetStringUTFChars(str, NULL);
		if (NULL == inCStr) return "";
 
		string s = string(inCStr);
		
		env->ReleaseStringUTFChars(str, inCStr);  // release resources
		
		return s;
	}

	static jstring ToString(JNIEnv *env, string str)
	{
		return env->NewStringUTF(str.c_str());
	}

	static jstring ToString(JNIEnv *env, wstring str)
	{
		return env->NewString((jchar*)str.c_str(), (jsize)str.size() * 2);
	}

	static vector<unsigned char> ToVector(JNIEnv *env, jstring str)
	{
		const char *inCStr = env->GetStringUTFChars(str, NULL);
		if (NULL == inCStr) return vector<unsigned char>();
 
		int len = (int)env->GetStringUTFLength(str);
		vector<unsigned char> v = vector<unsigned char>(len);
		for(int i = 0; i < len; i++) v[i] = inCStr[i];

		env->ReleaseStringUTFChars(str, inCStr);  // release resources
		
		return v;
	}

	static vector<string> ToVectorCollection(JNIEnv *env, jobjectArray lines)
	{
		int len = (int)env->GetArrayLength(lines);
		vector<string> vCollection = vector<string>(len);
		for(int i = 0; i < len; i++) 
		{
			jstring s = (jstring)env->GetObjectArrayElement(lines, i);
			if (NULL == s) continue;
			vCollection[i] = ToString(env, s);
		}
		return vCollection;
	}

	static jobject ToDateTime(JNIEnv *env, jobject thisObj, tm date)
	{
		jclass cls = env->GetObjectClass(thisObj);
		jmethodID midCallBack = env->GetMethodID(cls, "GetNewDateTime", "()LDateTime;");
		jobject dt = env->CallObjectMethod(thisObj, midCallBack);

		cls = env->GetObjectClass(dt);
		jfieldID fid = env->GetFieldID(cls, "Year", "I");
		env->SetIntField(dt, fid, date.tm_year + 1900);

		fid = env->GetFieldID(cls, "Month", "I");
		env->SetIntField(dt, fid, date.tm_mon);

		fid = env->GetFieldID(cls, "Day", "I");
		env->SetIntField(dt, fid, date.tm_mday);

		fid = env->GetFieldID(cls, "Hour", "I");
		env->SetIntField(dt, fid, date.tm_hour);

		fid = env->GetFieldID(cls, "Minute", "I");
		env->SetIntField(dt, fid, date.tm_min);

		fid = env->GetFieldID(cls, "Second", "I");
		env->SetIntField(dt, fid, date.tm_sec);

		return dt;
	}

	static tm ToTM(JNIEnv *env, jobject date)
	{
		tm dt;

		jclass cls = env->GetObjectClass(date);

		jfieldID fid = env->GetFieldID(cls, "Year", "I");
		if (NULL != fid) dt.tm_year = (int)env->GetIntField(date, fid) - 1900;

		fid = env->GetFieldID(cls, "Month", "I");
		if (NULL != fid) dt.tm_mon = (int)env->GetIntField(date, fid);

		fid = env->GetFieldID(cls, "Day", "I");
		if (NULL != fid) dt.tm_mday = (int)env->GetIntField(date, fid);

		fid = env->GetFieldID(cls, "Hour", "I");
		if (NULL != fid) dt.tm_hour = (int)env->GetIntField(date, fid);

		fid = env->GetFieldID(cls, "Minute", "I");
		if (NULL != fid) dt.tm_min = (int)env->GetIntField(date, fid);

		fid = env->GetFieldID(cls, "Second", "I");
		if (NULL != fid) dt.tm_sec = (int)env->GetIntField(date, fid);

		return dt;
	}

	static DevInfo ToDevInfo(JNIEnv *env, jobject deviceInfo)
	{
		DevInfo devInfo;

		jclass cls = env->GetObjectClass(deviceInfo);

		jfieldID fid = env->GetFieldID(cls, "IP", "Ljava/lang/String;");
		if (NULL != fid) devInfo.IP = ToString(env, (jstring)env->GetObjectField(deviceInfo, fid));

		fid = env->GetFieldID(cls, "Port", "I");
		if (NULL != fid) devInfo.Port = (int)env->GetIntField(deviceInfo, fid);

		fid = env->GetFieldID(cls, "TerminalNo", "Ljava/lang/String;");
		if (NULL != fid) devInfo.TerminalNo = ToString(env, (jstring)env->GetObjectField(deviceInfo, fid));

		fid = env->GetFieldID(cls, "SerialNum", "Ljava/lang/String;");
		if (NULL != fid) devInfo.SerialNum = ToString(env, (jstring)env->GetObjectField(deviceInfo, fid));

		fid = env->GetFieldID(cls, "Model", "Ljava/lang/String;");
		if (NULL != fid) devInfo.Model = ToString(env, (jstring)env->GetObjectField(deviceInfo, fid));

		fid = env->GetFieldID(cls, "Brand", "Ljava/lang/String;");
		if (NULL != fid) devInfo.Brand = ToString(env, (jstring)env->GetObjectField(deviceInfo, fid));

		fid = env->GetFieldID(cls, "Version", "Ljava/lang/String;");
		if (NULL != fid) devInfo.Version = ToString(env, (jstring)env->GetObjectField(deviceInfo, fid));

		return devInfo;
	}

	static Adjustment3 ToAdjustment3(JNIEnv *env, jobject adj2)
		{
			Adjustment3 adj3;

			jclass cls = env->GetObjectClass(adj2);

			if(adj2 != nullptr)
			{
				/*adj3.isNull = false;

				//adj3.Amount = Convert::ToDouble(adj2->Amount);
				jfieldID fid = env->GetFieldID(cls, "Amount", "D");
				if (NULL != fid) adj3.Amount = Convert::ToDouble(env, (jdouble)env->GetObjectField(adj2, fid));				

				//adj3.Percentage = adj2->Percentage;
				fid = env->GetFieldID(cls, "Percentage", "I");
				if(NULL != fid) adj3.Percentage = (int)env->GetIntField(adj2, fid);

				if(adj3.Amount > 0)
				{
					if(adj3.Percentage > 0)
						adj3.AdjType = 1;//PERCENT_FEE3;
					else
						adj3.AdjType = 0;//FEE3;
				}
				else
				{
					if(adj3.Percentage > 0)
						adj3.AdjType = 3;//PERCENT_DISCOUNT3;
					else
						adj3.AdjType = 2;//DISCOUNT3;
				}*/
			}
			else
				adj3.isNull = true;

			return adj3;
		}

		static PaymentInfo3 ToPaymentInfo3(JNIEnv *env, jobject pi2)
		{
			PaymentInfo3 pi3;

			jclass cls = env->GetObjectClass(pi2);

			if(pi2 != nullptr)
			{
				/*pi3.isNull = false;

				//pi3.Type = static_cast<PaymentType3>(pi2->Type);
				jfieldID fid = env->GetFieldID(cls, "Type", "I");
				if(NULL != fid)pi3.Type = (int)env->GetIntField(pi2, fid);

				//pi3.Index = pi2->Index;
				fid = env->GetFieldID(cls, "Index", "I");
				if(NULL != fid) pi3.Index = (int)env->GetIntField(pi2, fid);
				
				//pi3.PaidTotal = Convert::ToDouble(pi2->PaidTotal);
				fid = env->GetFieldID(cls, "PaidTotal", "D");
				if(NULL != fid) pi3.PaidTotal = Convert::ToDouble(env, (jdouble)env->GetObjectField(pi2, fid));				

				//pi3.ViaByEFT = pi2->ViaByEFT;
				fid = env->GetFieldID(cls, "ViaByEFT", "Z");
				if(NULL != fid) pi3.ViaByEFT = (bool)env->GetIntField(pi2, fid);*/
			}
			else
				pi3.isNull = true;

			return pi3;
		}

		static JSONItem3 ToJSONItem3(JNIEnv *env, jobject item2)
		{
			JSONItem3 item3;

			jclass cls = env->GetObjectClass(item2);

			if(item2 != nullptr)
			{
				/*item3.isNull = false;

				//item3.Id = item2->Id;
				jfieldID fid = env->GetFieldID(cls, "Id", "I");
				if(NULL != fid) item3.Id = (int)env->GetIntField(item2, fid);

				//item3.Quantity = Convert::ToDouble(item2->Quantity);
				fid = env->GetFieldID(cls, "Quantity", "D");
				if(NULL != fid) item3.Quantity = Convert::ToDouble(env, (jdouble)env->GetObjectField(item2, fid));
			

				//item3.Price = Convert::ToDouble(item2->Price);
				fid = env->GetFieldID(cls, "Price", "D");
				if(NULL != fid) item3.Price = Convert::ToDouble(env, (jdouble)env->GetObjectField(item2, fid));

				//item3.Name = ToVector(item2->Name);
				fid = env->GetFieldID(cls, "Name", "Ljava/lang/String;");
				if (NULL != fid) item3.Name = ToString(env, (jstring)env->GetObjectField(item2, fid));

				//item3.DeptId = item2->DeptId;
				fid = env->GetFieldID(cls, "DeptId", "I");
				if(NULL != fid) item3.DeptId = (int)env->GetIntField(item2, fid);

				//item3.Status = item2->Status;
				fid = env->GetFieldID(cls, "Status", "I");
				if(NULL != fid) item3.Status = (int)env->GetIntField(item2, fid);

				//item3.Adj = ToAdjustment3(item2->Adj);
				fid = env->GetFieldID(cls, "Adj", "LAdjustment2");
				if(NULL != fid) item3.Adj = ToAdjustment3(env, (jobject)env->GetObjectField(item2, fid));

				//item3.Weighable = item2->Weighable;
				fid = env->GetFieldID(cls, "Weighable", "I");
				if(NULL != fid) item3.Weighable = (int)env->GetIntField(item2, fid);*/
			}
			else 
				item3.isNull = true;

			return item3;
		}

		static JSONDocument3 ToJSONDocument(JNIEnv *env, jstring jsonStr)
		{
			//JSONDoc^ jsonDoc = Newtonsoft::Json::JsonConvert::DeserializeObject<JSONDoc^>(jsonStr);

			JSONDocument3 jsonDocument;

			/*jclass cls = env->GetObjectClass(jsonDoc);

			int i = 0;
			vector<JSONItem3> items = vector<JSONItem3>(jsonDoc->FiscalItems->Length);
			for(i=0; i < jsonDoc->FiscalItems->Length; i++)
			{
				JSONItem2^ item = jsonDoc->FiscalItems[i];
				items[i] = ToJSONItem3(item);
			}
			jsonDocument.FiscalItems = items;

			i=0;
			vector<Adjustment3> adjustments = vector<Adjustment3>(jsonDoc->Adjustments->Length);
			for(i = 0; i < jsonDoc->Adjustments->Length; i++)
			{
				Adjustment2^ adj = jsonDoc->Adjustments[i];
				adjustments[i] = ToAdjustment3(adj);
			}
			jsonDocument.Adjustments = adjustments;

			i=0;
			vector<PaymentInfo3> payments = vector<PaymentInfo3>(jsonDoc->Payments->Length);
			for(i = 0; i < jsonDoc->Payments->Length; i++)
			{
				PaymentInfo2^ pi = jsonDoc->Payments[i];
				payments[i] = ToPaymentInfo3(pi);
			}
			jsonDocument.Payments = payments;

			i=0;
			vector<vector<unsigned char>> footers = vector<vector<unsigned char>>(jsonDoc->FooterNotes->Length);
			for(i = 0; i< jsonDoc->FooterNotes->Length; i++)
			{
				String^ str = jsonDoc->FooterNotes[i];
				footers[i] = ToVector(str);
				i++;
			}
			jsonDocument.FooterNotes = footers;*/

			return jsonDocument;
		}
};

