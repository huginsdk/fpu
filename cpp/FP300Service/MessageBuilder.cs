using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace FP300Service
{
    public class MessageBuilder
    {
        #region Public Static Functions

        public static Encoding DefaultEncoding = ASCIIEncoding.GetEncoding(1254);

        public static byte[] ConvertIpToBcd(String idAddress)
        {
            List<byte> bytes = new List<byte>();

            string[] spltIPAddrs = idAddress.Split(new char[] { ',' , '.'});
            string ipVal = "";
            for (int i = 0; i < spltIPAddrs.Length; i++)
            {
                ipVal += int.Parse(spltIPAddrs[i]).ToString().PadLeft(3, '0');
            }
            for (int i = 0; i < ipVal.Length / 2; i++)
            {
                bytes.AddRange(MessageBuilder.ConvertIntToBCD(
                                int.Parse(ipVal.Substring(i * 2, 2)), 1));
            }

            return bytes.ToArray();
        }


        public static byte[] GetDateTimeInBytes(DateTime date)
        {
            List<byte> dtBytes = new List<byte>();

            //date
            dtBytes.AddRange(GetDateInBytes(date));
            //time
            dtBytes.AddRange(GetTimeInBytes(date));

            return dtBytes.ToArray();
        }

        public static byte[] GetDateInBytes(DateTime date)
        {
            List<byte> dtBytes = new List<byte>();

            Encoding encode = Encoding.GetEncoding(1254);
            //date
            dtBytes.AddRange(HexToByteArray(GMPCommonTags.TAG_OP_DATE));
            dtBytes.Add((byte)GMPConstants.LEN_DATE);
            dtBytes.AddRange(ConvertIntToBCD(date.Date.Year, 1));
            dtBytes.AddRange(ConvertIntToBCD(date.Date.Month, 1));
            dtBytes.AddRange(ConvertIntToBCD(date.Date.Day, 1));

            return dtBytes.ToArray();
        }

        public static byte[] GetTimeInBytes(DateTime time)
        {
            List<byte> dtBytes = new List<byte>();

            Encoding encode = Encoding.GetEncoding(1254);
            //time
            dtBytes.AddRange(HexToByteArray(GMPCommonTags.TAG_OP_TIME));
            dtBytes.Add((byte)GMPConstants.LEN_TIME);
            dtBytes.AddRange(ConvertIntToBCD(time.Hour, 1));
            dtBytes.AddRange(ConvertIntToBCD(time.Minute, 1));
            dtBytes.AddRange(ConvertIntToBCD(time.Second, 1));

            return dtBytes.ToArray();
        }
        public static DateTime GetDateFromBcd(byte[] blockData, int index, out int outIndex)
        {
            outIndex = index;
            int day = MessageBuilder.ConvertBcdToInt(blockData, outIndex++, 1);
            int month = MessageBuilder.ConvertBcdToInt(blockData, outIndex++, 1);
            int year = MessageBuilder.ConvertBcdToInt(blockData, outIndex++, 1) + 2000;

            return new DateTime(year, month, day);
        }

        public static DateTime AddTimeFromBcd(byte[] blockData, int index, out int outIndex, DateTime dtToAdd)
        {
            outIndex = index;
            int hour = MessageBuilder.ConvertBcdToInt(blockData, outIndex++, 1);
            int min = MessageBuilder.ConvertBcdToInt(blockData, outIndex++, 1);
            int sec = MessageBuilder.ConvertBcdToInt(blockData, outIndex++, 1);

            dtToAdd = dtToAdd.AddHours(hour);
            dtToAdd = dtToAdd.AddMinutes(min);
            dtToAdd = dtToAdd.AddSeconds(sec);

            return dtToAdd;
        }

        public static byte[] AddLength(int len)
        {
            List<byte> lenBytes = new List<byte>();

            if (len > 0xFF)
            {
                lenBytes.Add(0x82);
            }
            else if (len > 0x7F)
            {
                lenBytes.Add(0x81);
            }
            lenBytes.AddRange(HexToByteArray(len));

            return lenBytes.ToArray();
        }

        public static byte[] HexToByteArray(int hexNum)
        {
            List<byte> msgBytes = new List<byte>();

            while (true)
            {
                msgBytes.Insert(0, (byte)(hexNum % 256));
                hexNum = hexNum / 256;
                if (hexNum == 0) break;
            }
            return msgBytes.ToArray();
        }

        public static int ByteArrayToHex(byte[] bytesArray, int offset, int len)
        {
            int res = 0;

            for (int i = 0; i < len; i++)
            {
                res += res * 0xFF + bytesArray[i + offset];
            }
            return res;
        }


        public static int GetTag(byte[] bytesArray, int offset, out int outOffset)
        {
            int res = 0;
            outOffset = offset;
            for (int i = 0; i < GMPConstants.LEN_DATA_TAG; i++)
            {
                res += res * 0xFF + bytesArray[i + offset];
                outOffset++;
                if (bytesArray[i + offset] < 0x7F)
                {
                    break;
                }
            }
            return res;
        }

        public static DateTime ConvertBytesToDate(byte[] bytesBCD, int offset)
        {
            int year, month, day;

            year = ConvertBcdToInt(bytesBCD, offset, 1) + 2000;
            offset++;
            month = ConvertBcdToInt(bytesBCD, offset, 1);
            offset++;
            day = ConvertBcdToInt(bytesBCD, offset, 1);
            offset++;

            return new DateTime(year, month, day);
        }
        
        public static DateTime ConvertBytesToTime(byte[] bytesBCD, int offset)
        {
            int hour, minute, second;

            hour = ConvertBcdToInt(bytesBCD, offset, 1);
            offset++;
            minute = ConvertBcdToInt(bytesBCD, offset, 1);
            offset++;
            second = ConvertBcdToInt(bytesBCD, offset, 1);
            offset++;

            return new DateTime(1970, 1, 1, hour, minute, second);
        }

        public static int ConvertBcdToInt(byte[] bytesBCD, int offset, int len)
        {
            int res = 0;

            for (int i = 0; i < len; i++)
            {
                int curr = bytesBCD[i + offset];
                curr = (curr / 16) * 10 + curr % 16;
                res = res * 100 + curr;
            }
            return res;
        }

        public static string ByteArrayToString(byte[] bytesArray, int offset, int len)
        {
            List<byte> copyBytes = new List<byte>();
            for (int i = 0; i < len; i++)
            {
                copyBytes.Add(bytesArray[i + offset]);
            }
            return Encoding.ASCII.GetString(copyBytes.ToArray());
        }

        public static string GetString(byte[] bytesArray, int index, out int outIndex, Encoding encoding)
        {
            outIndex = index;
            int len = MessageBuilder.GetLength(bytesArray, outIndex, out outIndex);

            List<byte> copyBytes = new List<byte>();
            for (int i = 0; i < len; i++)
            {
                copyBytes.Add(bytesArray[outIndex]);
                outIndex++;
            }
            return encoding.GetString(copyBytes.ToArray());
        }

        public static byte[] GetBytesFromOffset(byte[] bytesArray, int offset, int len)
        {
            List<byte> copyBytes = new List<byte>();
            for (int i = 0; i < len; i++)
            {
                copyBytes.Add(bytesArray[i + offset]);
            }
            return copyBytes.ToArray();
        }

        public static byte CalculateLRC(List<byte> reqPacket)
        {
            byte lrc = 0;
            for (int i = 0; i < reqPacket.Count; i++)
            {
                lrc ^= reqPacket[i];
            }
            return lrc;
        }


        public static byte[] ConvertIntToBCD(int value, int bcdLen)
        {
            List<byte> bcdBytes = new List<byte>();
            uint val = (uint)value;
            int i = 0;
            while (true)
            {
                uint current = val % 100;
                current = ((current / 10) * 16) + (current % 10);
                bcdBytes.Insert(0, (byte)current);
                val = val / 100;
                i++;
                if (i >= bcdLen)
                {
                    break;
                }
            }

            return bcdBytes.ToArray();
        }

        public static byte[] ConvertDecimalToBCD(decimal value, int decimalCnt)
        {
            List<byte> bcdBytes = new List<byte>();
            uint val = (uint)(value * (int)Math.Pow(10, decimalCnt));
            int i = 0;
            while (true)
            {
                uint current = val % 100;
                current = ((current / 10) * 16) + (current % 10);
                bcdBytes.Insert(0, (byte)current);
                val = val / 100;
                if (val == 0)
                {
                    break;
                }
                i++;
            }

            return bcdBytes.ToArray();
        }

        public static int GetLength(byte[] msgBytes, int offset, out int outIndex)
        {
            int len = 0;
            outIndex = offset;
            switch (msgBytes[offset])
            {
                case 0x81:
                    len = msgBytes[outIndex + 1];
                    outIndex += 2;
                    break;
                case 0x82:
                    len = msgBytes[outIndex + 1] * 0x100 + msgBytes[outIndex + 2];
                    outIndex += 3;
                    break;
                default:
                    len = msgBytes[outIndex];
                    outIndex += 1;
                    break;
            }
            return len;
        }


        public static string BytesToHexString(List<byte> bytesArr)
        {
            String resp = "";
            for (int i = 0; i < bytesArr.Count; i++)
            {
                resp += String.Format("{0:X2}", bytesArr[i]);
            }
            resp += "";
            return resp;
        }

        public static List<byte> HexStringToBytes(string strBytes)
        {
            List<byte> listBytes = new List<byte>();
            int len = strBytes.Length / 2;
            for (int i = 0; i < len; i++)
            {
                listBytes.Add(Convert.ToByte(strBytes.Substring(i * 2, 2), 16));
            }

            return listBytes;
        }

        internal static string FixTurkish(string str)
        {
            string response = String.Empty;

            for (int i = 0; i < str.Length; i++)
            {
                switch (str[i])
                {
                    case 'Ç':
                        response += (char)199;
                        break;
                    case 'Ğ':
                        response += (char)208;
                        break;
                    case 'Ö':
                        response += (char)214;
                        break;
                    case 'Ü':
                        response += (char)220;
                        break;
                    case 'İ':
                        response += (char)221;
                        break;
                    case 'Ş':
                        response += (char)222;
                        break;
                    default:
                        response += str[i];
                        break;
                }
            }

            return response;
        }
        #endregion

        #region Crypto
        private static TripleDESCryptoServiceProvider GetTripleDESProvider(byte [] tripleKey)
        {
            try
            {
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                des.Mode = CipherMode.ECB;
                des.KeySize = 128;
                des.Key = tripleKey;
                //des.IV = tripleIV;
                des.Padding = PaddingMode.Zeros;
                return des;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //3DES Encryption
        public static byte[] EncryptTriple(byte[] data, int len, byte[] tripleKey)
        {
            TripleDESCryptoServiceProvider des = GetTripleDESProvider(tripleKey);
            try
            {
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, des.CreateEncryptor(), CryptoStreamMode.Write);

                cStream.Write(data, 0, len);
                cStream.FlushFinalBlock();

                byte[] retVal = mStream.ToArray();

                cStream.Close();
                mStream.Close();

                return retVal;
            }
            catch (CryptographicException e)
            {
                return null;
            }

        }

        //3DES Decryption
        public static byte[] DecryptTriple(byte[] data, int len, byte[] tripleKey)
        {
            TripleDESCryptoServiceProvider des = GetTripleDESProvider(tripleKey);
            MemoryStream msDecrypt = new MemoryStream(data);
            CryptoStream csDecrypt = new CryptoStream(msDecrypt, des.CreateDecryptor(), CryptoStreamMode.Read);

            byte[] retVal = new byte[data.Length];
            csDecrypt.Read(retVal, 0, len);

            return retVal;
        }

        //create key and IV(vector) values for encryption
        public static byte[] Create3DESKey()
        {
            System.Security.Cryptography.TripleDES tDES = System.Security.Cryptography.TripleDES.Create();
            tDES.KeySize = 128;
            tDES.GenerateKey();
            tDES.Mode = CipherMode.ECB;
            return tDES.Key;
        }

        //RSA encryption
        public static byte[] EncryptRSA(byte[] rsaModulus, byte[] exponent, byte[] data)
        {
            byte[] response = null;
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            RSAParameters rsaPar = rsa.ExportParameters(false);

            rsaPar.Modulus = rsaModulus;
            rsaPar.Exponent = exponent;

            rsa.ImportParameters(rsaPar);

            response = rsa.Encrypt(data, false);

            return response;
        }
        public static bool VerifyRSA(byte[] rsaModulus, byte[] exponent, byte[] data, byte[] sign)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            RSAParameters rsaPar = rsa.ExportParameters(false);

            rsaPar.Modulus = rsaModulus;
            rsaPar.Exponent = exponent;

            rsa.ImportParameters(rsaPar);

            bool resp;

            resp = rsa.VerifyHash(data, "SHA256", sign);

            //resp = rsa.VerifyData(data, "SHA256", sign);

            return resp;
        }
        #endregion

    }
}
