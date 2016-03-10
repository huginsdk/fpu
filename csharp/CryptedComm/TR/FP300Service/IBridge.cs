using System;
using System.Collections.Generic;
using System.Text;
#if SINGLE_DLL
using Hugin.CompactPrinterFPU;
#else
using Hugin.POS.CompactPrinter.FP300;
#endif

namespace FP300Service
{
    interface IBridge
    {
        IConnection Connection { get; set; }
        void Log(String log);
        void Log();
        ICompactPrinter Printer { get; }      
    }
}
