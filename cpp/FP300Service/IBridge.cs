using System;
using System.Collections.Generic;
using System.Text;
#if SINGLE_DLL
using Hugin.CompactPrinterFPU;
#elif CPP

#else
using Hugin.POS.CompactPrinter.FP300;
#endif

namespace FP300Service
{
    public interface IBridge
    {
#if CPP
        void Log(String log);
        void Log();
        PrinterWrapper.CompactPrinterWrapper Printer { get; }
        BridgeConn Connection { get; set; }
#else
        IConnection Connection { get; set; }
        void Log(String log);
        void Log();
        ICompactPrinter Printer { get; }      
#endif
    }

#if CPP
    public class BridgeConn
    {
        private IBridge bridge;
        private int fpuTimeout;

        public IBridge Bridge
        {
            set { bridge = value; }
            get { return bridge; }
        }

        public int FPUTimeout
        {
            set
            {
                if (bridge != null)
                    bridge.Printer.SetFPUTimeout(value);
            }
        }

        public BridgeConn()
        {
        }
    }
#endif
}
