using System;
using System.Collections.Generic;
using System.Text;
using Hugin.ExDevice;

namespace FP300Service
{
    public enum State
    {
        ST_IDLE = 1,
        ST_SELLING,
        ST_SUBTOTAL,
        ST_PAYMENT,
        ST_OPEN_SALE,
        ST_INFO_RCPT,
        ST_CUSTOM_RCPT,
        ST_IN_SERVICE,
        ST_SRV_REQUIRED,
        ST_LOGIN,
        ST_NONFISCAL,
        ST_ON_PWR_RCOVR,
        ST_INVOICE,
        ST_CONFIRM_REQUIRED
    }
    public class FPUResponse
    {
        private const int RESPONSE_MSG_ID = 0xFF8F21;

        private string fiscalId;
        private int seqNum;
        private int errCode;
        private State fpuState;
        private byte[] data;
        private GMPField[] detail;

        public string FiscalId
        {
            get { return fiscalId; }
        }

        public int SequenceNum
        {
            get { return seqNum; }
        }

        public int ErrorCode
        {
            get { return errCode; }
        }

        public State FPUState
        {
            get { return fpuState; }
        }

        public byte[] Data
        {
            get { return data; }
        }

        public GMPField[] Detail
        {
            get { return detail; }
            set { detail = value; }
        }

        public FPUResponse(byte[] bytesRead)
        {
            int index = 0;
            int msgType = 0;
            try
            {
                byte lrc = 0;
                for (int i = 0; i < (bytesRead.Length - 1); i++)
                {
                    lrc ^= bytesRead[i];
                }
                if (bytesRead[bytesRead.Length - 1] != lrc)
                {
                    // Throw CRCException 
                    throw new Exception("LRC not match");
                }

                index = 0;
                //TERMINAL SERIAL
                List<byte> serial = new List<byte>();
                for (int i = 0; i < GMPConstants.LEN_SERIAL; i++)
                {
                    serial.Add(bytesRead[index + i]);
                }
                this.fiscalId = Encoding.ASCII.GetString(serial.ToArray());
                index += GMPConstants.LEN_SERIAL;

                //MESSAGE TYPE
                msgType = MessageBuilder.ByteArrayToHex(bytesRead, index, 3);


                /* get message len */
                index += 3;

                if (msgType == Identifier.KEY_RESPONSE)
                {
                    int tempIndex = 0;
                    int len = MessageBuilder.GetLength(bytesRead, index, out tempIndex);
                    data = MessageBuilder.GetBytesFromOffset(bytesRead, index, len + tempIndex - index);
                    return;
                }

                if (msgType != RESPONSE_MSG_ID)
                {
                    if (msgType != Identifier.TRIPLEDES_RESPONSE)
                    {
                        throw new InvalidOperationException("Response Message Incorrect");
                    }
                }
            }
            catch (InvalidOperationException)
            {
                throw new Exception("Message id error");
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid data");
            }
            try
            {
                int len = MessageBuilder.GetLength(bytesRead, index, out index);
                if (MainForm.TripleKey != null &&  msgType == RESPONSE_MSG_ID)
                {
                    byte[] msgBuffer = MessageBuilder.GetBytesFromOffset(bytesRead, index, len);
                    byte[] desData = MessageBuilder.DecryptTriple(msgBuffer, 
                                                    msgBuffer.Length, 
                                                    MainForm.TripleKey);
                    bytesRead = desData;
                    index = 0;
                    len = bytesRead.Length;
                }
                int msgOffset = index;
                int lastIndex = index;
                while (index < len + msgOffset)
                {
                    //get next tag
                    lastIndex = index;
                    int tag = MessageBuilder.GetTag(bytesRead, index, out index);

                    switch (tag)
                    {
                        case GMPCommonTags.TAG_SEQUNCE:
                            int lenSeq = MessageBuilder.GetLength(bytesRead, index, out index);
                            int seq = MessageBuilder.ConvertBcdToInt(bytesRead, index, lenSeq);
                            index += lenSeq;
                            this.seqNum = seq;
                            break;
                        case FPUDataTags.ERROR:
                            int lenErrorTag = MessageBuilder.GetLength(bytesRead, index, out index);
                            this.errCode = bytesRead[index];// MessageBuilder.ConvertBcdToInt(bytesRead, index, lenErrorTag);
                            index += lenErrorTag;
                            break;
                        case FPUDataTags.STATE:
                            int lenStateTag = MessageBuilder.GetLength(bytesRead, index, out index);
                            int state = MessageBuilder.ConvertBcdToInt(bytesRead, index, lenStateTag);
                            index += lenStateTag;
                            this.fpuState = (State)state;
                            break;
                        case FPUDataTags.ENDOFMSG:
                            int lenEndMsg = MessageBuilder.GetLength(bytesRead, index, out index);
                            index = len;
                            break;
                        default:
                            int tagLenValue = MessageBuilder.GetLength(bytesRead, index, out index);
                            int buffIndx = 0;
                            int counter = 0;
                            int tagIdSize = (index - lastIndex);
                            if (data != null && data.Length > 0)
                            {
                                buffIndx = data.Length;
                                int buffSize = data.Length + tagLenValue + tagIdSize;
                                Array.Resize(ref data, buffSize);
                            }
                            else
                            {
                                data = new byte[tagLenValue + tagIdSize];
                            }
                            while (buffIndx < data.Length)
                            {
                                data[buffIndx] = bytesRead[counter + lastIndex];
                                counter++;
                                buffIndx++;
                            }
                            index += tagLenValue;                            
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid Data");
            }

            if (errCode == 0)
            {
                if (this.SequenceNum < 0)
                {
                    throw new Exception("Invalid Data");
                }
            }
        }
    }
}
