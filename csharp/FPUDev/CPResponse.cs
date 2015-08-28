using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
