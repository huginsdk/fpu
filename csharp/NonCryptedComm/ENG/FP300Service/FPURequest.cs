using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Hugin.ExDevice;

namespace FP300Service
{
    public enum Command : int
    {
        NULL = 0,
        LOGO = 0x11,
        VAT = 0x12,
        DEPARTMENT = 0x13,
        PLU = 0x14,
        CREDIT = 0x15,
        MAIN_CAT = 0x16,
        SUB_CAT = 0x17,
        CASHIER = 0x18,
        PRG_OPTIONS = 0x19,
        FCURRENCY = 0x1A,
        TSM_IP_PORT = 0x1B,
        GRAPHIC_LOGO = 0x1C,
        NETWORK = 0x1D,


        START_RCPT = 0x21,
        SALE_ITEM = 0x22,
        ADJUSTMENT = 0x23,
        CORRECTION = 0x24,
        VOID_ITEM = 0x25,
        SUBTOTAL = 0x26,
        PAYMENT = 0x27,
        CLOSE_RCPT = 0x28,
        VOID_RCPT = 0x29,
        CUSTOMER_NOTe = 0x2A,
        RCPT_BARCODE = 0x2B,

        X_DAILY = 0x31,
        X_PLU = 0x32,
        X_DETAIL_SALE = 0x33,

        Z_DAILY = 0x41,
        Z_FM_ZZ = 0x42, 
        Z_FM_ZZ_DETAIL = 0x43, 
        Z_FM_DATE = 0x44, 
        Z_FM_DATE_DETAIL = 0x45,
        Z_ENDDAY = 0x46, //Endday bank
        CMD_Z_OLD_DAILY = 0x47,

        EJ_DETAIL = 0x51,
        EJ_RCPTCOPY_ZR = 0x52,//both single and periodic
        EJ_RCPTCOPY_DATE = 0x53,//both single and periodic. either daily

        SRV_CLEAR_DAILY = 0x61,
        SRV_SET_DATETIME = 0x62,
        SRV_FACTORY_SETTINGS = 0x63,
        SRV_STOP_FM = 0x64,
        SRV_EXTERNAL_DEV_SETTINGS = 0x65,
        SRV_UPDATE_FIRMWARE = 0x66,
        SRV_PRINT_LOGS = 0x67,
        SRV_CREATE_DB = 0x68,
        SRV_EXIT_SERVICE = 0x6F,

        INFO_LAST_Z = 0x71,
        INFO_LAST_RCPT = 0x72,
        INFO_DRAWER = 0x73,

        STATUS = 0x81,
        LAST_RESPONSE = 0x82,
        BREAK = 0x83,
        START_FM = 0x84,
        FISCALIZE = 0x85,
        INIT_EJ = 0x86,
        CASHIER_LOGIN = 0x87,
        CASHIER_LOGOUT = 0x88,
        CASH_IN = 0x89,
        CASH_OUT = 0x8A,
        START_NF_RCPT = 0x8B,
        ADD_NF_LINE = 0x8C,
        END_NF_RCPT = 0x8D,
        EJ_LIMIT = 0x8E,
        START_SERVICE = 0x8F,
        ENTER_SERVICE = 0x90,
        FILE_TRANSFER = 0x91,
        OPEN_DRAWER = 0x92

    }
    public class FPURequest
    {

#region Definitions
        const int REQUEST_MSG_ID = 0xFF8B21;
        const int MAX_PRCSS_SEC_NUM = 999999;

        Command command;
        Byte[] data;
        Byte[] request;
        int sequence;

#endregion

#region Accessor

        internal Command Command
        {
            get { return command; }
        }

        public Byte[] Data
        {
            get { return data; }
        }

        internal Byte[] Request
        {
            get { return request; }
        }

        public int Sequence
        {
            get { return sequence; }
        }
#endregion

        public FPURequest(Command command, byte[] data)
        {
            int dataLength = 0;
            if (data!= null)
            {
                dataLength = data.Length;
            }
            request = CreateRequest(MainForm.FiscalId, REQUEST_MSG_ID, command, data, dataLength);
        }
        public FPURequest(int msgId, byte[] data)
        {
            int dataLength = 0;
            if (data != null)
            {
                dataLength = data.Length;
            }
            request = CreateRequest(MainForm.FiscalId, msgId, Command.NULL, data, dataLength);
        }
        private byte[] CreateRequest(String terminalNo, int messageType, Command cmd, byte[] data, int dataLen)
        {
            /*          General Message for Request
            *  XX      Length 
            *  ASCII   Terminal Serial
            *  XX      Message Type
            *  BCD     SequenceNum
            *  BCD     Date
            *  BCD     Time
            *          [Detail]
            *  XX      LRC
            */

            Encoding encode         = Encoding.GetEncoding(1254);
            List<byte> reqPacket    = new List<byte>();
            List<byte> msgPacket    = new List<byte>();
            int allLen              = dataLen;

            this.command    = cmd;
            this.data       = data;
            this.sequence   = (MainForm.SequenceNumber++) % MAX_PRCSS_SEC_NUM;

            //SEQUNCE
            reqPacket.AddRange(MessageBuilder.HexToByteArray(GMPCommonTags.TAG_SEQUNCE));
            reqPacket.Add((byte)GMPConstants.LEN_SEQUENCE);
            byte[] arrVal = MessageBuilder.ConvertIntToBCD(this.Sequence, GMPConstants.LEN_SEQUENCE);
            reqPacket.AddRange(arrVal);
            //DATE and TIME
            reqPacket.AddRange(MessageBuilder.GetDateTimeInBytes(DateTime.Now));
            // Fiscal Command
            if (cmd != Command.NULL)
            {
                reqPacket.AddRange(MessageBuilder.HexToByteArray(FPUCommonTags.FPU_FISCAL_COMMAND));
                reqPacket.Add((byte)GMPConstants.LEN_FISCAL_COMMAND);
                reqPacket.Add((byte)cmd);
            }

            if (dataLen > 0)
            {
                reqPacket.AddRange(data);
            }

            // Terminal ID
            msgPacket.AddRange(encode.GetBytes(terminalNo.PadLeft(12, ' ')));
            // Message TAG
            msgPacket.AddRange(MessageBuilder.HexToByteArray(messageType));
            // Message length
            int msgLen = reqPacket.Count; 
            msgPacket.AddRange(MessageBuilder.AddLength(msgLen));
            // Message Data
            msgPacket.AddRange(reqPacket);
            // CRC
            short crc = MessageBuilder.CalculateCRC(msgPacket.ToArray(), 0, msgPacket.Count);
            msgPacket.Add((byte)(crc >> 8));
            msgPacket.Add((byte)(crc));            
            
            // All Length
            allLen = msgPacket.Count;
            msgPacket.Insert(0, (byte)(allLen % 256));
            msgPacket.Insert(0, (byte)(allLen / 256));

            return msgPacket.ToArray();
        }

    }
}
