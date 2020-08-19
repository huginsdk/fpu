using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace FP300Service
{
    public class CPResponse
    {
        private const char SPLIT_CHAR = '|';

        private static int paramIndex = 0;
        private static IBridge bridge = null;

        private int errorCode;
        private int statusCode;
        private List<String> paramList = null;
        
        public int ErrorCode
        {
            get
            {
                return errorCode;
            }
        }
        public int StatusCode
        {
            get
            {
                return statusCode;
            }
        }
        public List<String> ParamList
        {
            get
            {
                return paramList;
            }
        }

        public ErrorCode EnumErrorCode
        {
            get
            {
                return (ErrorCode)errorCode;
            }
        }

        public StatusCode EnumStatusCode
        {
            get
            {
                return (StatusCode)statusCode;
            }
        }

        public string ErrorMessage
        {
            get
            {
                string result = string.Empty;
                try
                {
                    ErrorCode enumError = (ErrorCode)this.errorCode;
                    result = DescriptionAttr(enumError);
                    return result;
                }
                catch { }

                return result;
            }
        }


        public string StatusMessage
        {
            get
            {
                string result = string.Empty;
                try
                {
                    StatusCode enumStatus = (StatusCode)this.statusCode;
                    result = DescriptionAttr(enumStatus);
                }
                catch { }

                return result;
            }
        }

        private static string DescriptionAttr<T>(T source)
        {
            string result = string.Empty;
            FieldInfo fieldInfo = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                result = attributes[0].Description;
            return result;
        }


        public int CurrentParamIndex
        {
            get { return paramIndex; }
        }

        internal static IBridge Bridge
        {
            set { bridge = value; }
        }

        public CPResponse(String response)
        {
            bridge.Log();
            paramIndex = 0;

            if (!String.IsNullOrEmpty(response))
            {
                String[] strArray = response.Split(SPLIT_CHAR);
                List<String> strList = new List<string>(strArray);

                int index = 0;

                if (strList.Count > 2)
                    paramList = new List<string>();

                foreach (String str in strList)
                {
                    if (!String.IsNullOrEmpty(str))
                    {
                        if (index == 0)
                            errorCode = int.Parse(str);
                        else if (index == 1)
                            statusCode = int.Parse(str);
                        else
                        {
                            paramList.Add(str);
                        }
                    }
                    else if (index > 1)
                        paramList.Add(null);
                        
                    index++;
                }                
            }              
        }

        public string GetNextParam()
        {
            if (paramList != null)
            {
                if (paramIndex >= paramList.Count)
                    return null;

                string retVal = paramList[paramIndex];
                paramIndex++;
                return retVal;
            }
            else
                return null;
        }

        public string GetParamByIndex(int index)
        {
            if (paramList != null)
            {
                if (paramIndex >= paramList.Count)
                    return null;

                if (index > paramList.Count || index <= 0)
                    return null;

                string retVal = paramList[index - 1];
                return retVal;
            }
            else
                return null;
        }
    }
}
