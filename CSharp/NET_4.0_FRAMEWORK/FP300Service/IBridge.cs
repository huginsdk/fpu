using System;
using System.Collections.Generic;
using System.Text;
using Hugin.POS.CompactPrinter.FP300;


namespace FP300Service
{
    public interface IBridge
    {
        IConnection Connection { get; }
        void Log(String log);
        void Log();
        ICompactPrinter Printer { get; }
    }
}
