using System;
using System.Collections.Generic;
using System.Text;
using Hugin.ExDevice;

namespace FP300Service
{
    public class RSAItems
    {
        private int seqNumber;
        private byte[] modulus;
        private byte[] exponent;
        private DeviceInfo devInfo;

        public byte[] Modulus
        {
            get { return modulus; }
            set { modulus = value; }
        }

        public byte[] Exponent
        {
            get { return exponent; }
            set { exponent = value; }
        }

        public DeviceInfo DevInfo
        {
            get { return devInfo; }
            set { devInfo = value; }
        }

        public int SeqNumber
        {
            get { return seqNumber; }
            set { seqNumber = value; }
        }

    }

    public class Identifier
    {
        #region request messages

        public const int KEY_REQUEST = 0xFF8901;
        public const int KEY_RESPONSE = 0xFF8D01;

        public const int TRIPLEDES_REQUEST = 0xFF8902;
        public const int TRIPLEDES_RESPONSE = 0xFF8D02;
        

        #endregion


        #region helper funcs


        private static String localIP = "";
        private static String getLocalIP()
        {
            if (localIP.Length == 0)
            {
                System.Net.IPHostEntry host;
                host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
                foreach (System.Net.IPAddress ip in host.AddressList)
                {
                    if ((ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) && (ip.IsIPv6LinkLocal == false))
                    {
                        localIP = ip.ToString();
                        break;
                    }
                }
            }
            return localIP;
        }
        #endregion

        #region interpreters

        internal static RSAItems InterpretRSA(byte[] identityBytes)
        {
            int index = 0;
            RSAItems rsaItems = new RSAItems();

            rsaItems.DevInfo = new DeviceInfo();

            try
            {
                int len = MessageBuilder.GetLength(identityBytes, index, out index);
                int tagLen = 0;
                String tagValStr = "";
                while (true)
                {
                    if (index > (len - GMPConstants.LEN_DATA_TAG))
                        break;
                    //get next tag
                    int tag = MessageBuilder.GetTag(identityBytes, index, out index);
                    int tagVal = 0;
                    switch (tag)
                    {
                        case GMPCommonTags.TAG_SEQUNCE:
                            tagLen = MessageBuilder.GetLength(identityBytes, index, out index);
                            tagVal = MessageBuilder.ConvertBcdToInt(identityBytes, index, tagLen);
                            index += tagLen;
                            rsaItems.SeqNumber = tagVal;
                            break;
                        case GMPDataTags.DT_MOD_KEY:
                            tagLen = MessageBuilder.GetLength(identityBytes, index, out index);
                            rsaItems.Modulus = MessageBuilder.GetBytesFromOffset(identityBytes, index, tagLen);
                            index += tagLen;
                            break;
                        case GMPDataTags.DT_EXP_KEY:
                            tagLen = MessageBuilder.GetLength(identityBytes, index, out index);
                            rsaItems.Exponent = MessageBuilder.GetBytesFromOffset(identityBytes, index, tagLen);
                            index += tagLen;
                            break;
                        case GMPDataTags.DT_ECR_BRAND:
                            tagLen = MessageBuilder.GetLength(identityBytes, index, out index);
                            tagValStr = MessageBuilder.ByteArrayToString(identityBytes, index, tagLen);
                            index += tagLen;
                            rsaItems.DevInfo.Brand = tagValStr;
                            break;
                        case GMPDataTags.DT_ECR_MODEL:
                            tagLen = MessageBuilder.GetLength(identityBytes, index, out index);
                            tagValStr = MessageBuilder.ByteArrayToString(identityBytes, index, tagLen);
                            index += tagLen;
                            rsaItems.DevInfo.Model = tagValStr;
                            break;
                        case GMPCommonTags.TAG_RESP_CODE:
                            tagLen = MessageBuilder.GetLength(identityBytes, index, out index);
                            tagValStr = MessageBuilder.ByteArrayToString(identityBytes, index, tagLen);
                            index += tagLen;
                            if (!tagValStr.Equals(GMPResCodes.SUCCESS))
                            {
                                throw new Exception("İşlem başarısız");
                            }
                            break;
                        case GMPDataTags.DT_ECR_SERIAL:
                            tagLen = MessageBuilder.GetLength(identityBytes, index, out index);
                            tagValStr = MessageBuilder.ByteArrayToString(identityBytes, index, tagLen);
                            index += tagLen;
                            rsaItems.DevInfo.TerminalNo = tagValStr;
                            break;
                        default:
                            tagLen = MessageBuilder.GetLength(identityBytes, index, out index);
                            index += tagLen;
                            break;
                    }
                }
            }
            catch { rsaItems.SeqNumber = -1; }

            //if no response code
            //rsaItems.SeqNumber = -1; 
            return rsaItems;
        }


        internal static int InterpretEnd(byte[] decodedData)
        {
            int retVal = 0;
            int index = 0;
            try
            {
                int len = decodedData.Length;
                int tagLen = 0;
                String tagValStr = "";
                while (true)
                {
                    if (index > (len - GMPConstants.LEN_DATA_TAG))
                        break;
                    //get next tag
                    int tag = MessageBuilder.GetTag(decodedData, index, out index);

                    switch (tag)
                    {
                        case GMPCommonTags.TAG_RESP_CODE:
                            tagLen = MessageBuilder.GetLength(decodedData, index, out index);
                            tagValStr = MessageBuilder.ByteArrayToString(decodedData, index, tagLen);
                            index += tagLen;
                            if (!tagValStr.Equals(GMPResCodes.SUCCESS))
                            {
                                throw new Exception("İşlem başarısız");
                            }
                            break;
                    }
                }
            }
            catch { retVal = -1; }

            return retVal;

        }

        #endregion

        #region formatters

        internal static byte[] CreateKeyChange(DeviceInfo devInfo)
        {
            List<byte> keyChangePacket = new List<byte>();

            //LOCAL IP
            keyChangePacket.AddRange(MessageBuilder.HexToByteArray(GMPDataTags.DT_IP));
            keyChangePacket.AddRange(MessageBuilder.AddLength(6));

            String[] strLocalIP = getLocalIP().Split('.');//devInfo.DevIP.ToString().Split('.');

            String ip12Format = "";
            for (int i = 0; i < strLocalIP.Length; i++)
            {
                ip12Format += String.Format("{0:D3}", Convert.ToInt32(strLocalIP[i]));
            }
            for (int i = 0; i < ip12Format.Length; i++)
            {
                String strByte = ip12Format.Substring(i, 2);

                keyChangePacket.AddRange(MessageBuilder.ConvertIntToBCD(Convert.ToInt32(strByte), 1));
                i++;
            }

            //BRAND
            keyChangePacket.AddRange(MessageBuilder.HexToByteArray(GMPDataTags.DT_BRAND));
            keyChangePacket.AddRange(MessageBuilder.AddLength(devInfo.Brand.Length));
            keyChangePacket.AddRange(Encoding.ASCII.GetBytes(devInfo.Brand));

            //MODEL
            keyChangePacket.AddRange(MessageBuilder.HexToByteArray(GMPDataTags.DT_MODEL));
            keyChangePacket.AddRange(MessageBuilder.AddLength(devInfo.Model.Length));
            keyChangePacket.AddRange(Encoding.ASCII.GetBytes(devInfo.Model));

            //SERIAL
            keyChangePacket.AddRange(MessageBuilder.HexToByteArray(GMPDataTags.DT_SERIAL));
            keyChangePacket.AddRange(MessageBuilder.AddLength(devInfo.TerminalNo.Length));
            keyChangePacket.AddRange(Encoding.ASCII.GetBytes(devInfo.TerminalNo));

            return keyChangePacket.ToArray();
        }


        internal static byte[] CreateTripleDES(RSAItems rsaItems, byte[] tripleKey)
        {
            List<byte> triplePacket = new List<byte>();
            
            triplePacket.AddRange(MessageBuilder.HexToByteArray(GMPDataTags.DT_ENC_KEY));
            triplePacket.AddRange(MessageBuilder.AddLength(256));
            //tripleKey = Encoding.ASCII.GetBytes("1234567890123456");
            triplePacket.AddRange(MessageBuilder.EncryptRSA(rsaItems.Modulus, rsaItems.Exponent, tripleKey));

            //KEY VALUE
            byte[] arrCheck = new byte[32];
            for (int i = 0; i < 32; i++)
            {
                arrCheck[i] = (byte)0;
            }
            arrCheck = MessageBuilder.EncryptTriple(arrCheck, arrCheck.Length, tripleKey);
            List<byte> chk = new List<byte>();
            for (int i = 0; i < 16; i++)
            {
                chk.Add(arrCheck[i]);
            }
            triplePacket.AddRange(MessageBuilder.HexToByteArray(GMPDataTags.DT_CHK_VAL));
            triplePacket.AddRange(MessageBuilder.AddLength(16));
            triplePacket.AddRange(chk.ToArray());

            return triplePacket.ToArray();
        }

        #endregion 
    }
}
