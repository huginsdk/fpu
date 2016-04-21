#pragma once

class Logger
{
public:
	Logger(void);
	~Logger(void);
};

//
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.IO;
//
//namespace Hugin.ExDevice
//{
//    public enum LogLevel
//    {
//        Warning = 0x01,
//        Debug = 0x02,
//        High = 0x04
//    }
//    public class Logger
//    {
//
//        private static LogLevel logLevel = LogLevel.Debug;
//        private static string logFileName = "SCLogger.txt";
//
//
//        public static void Enter(object strClass, string strFunc)
//        {
//            if ((logLevel & LogLevel.Debug) == LogLevel.Debug)
//                AddLog(String.Format("Entered {0} \t {1}", strClass, strFunc));
//        }
//        public static void Exit(object strClass, string strFunc)
//        {
//            if ((logLevel & LogLevel.Debug) == LogLevel.Debug)
//                AddLog(String.Format("Exit {0} \t {1}", strClass, strFunc));
//        }
//        public static void DebugLine(object strClass, string strFunc, int line)
//        {
//            if ((logLevel & LogLevel.Debug) == LogLevel.Debug)
//                AddLog(String.Format("Exit {0} \t {1}:{2:D5}", strClass, strFunc, line));
//        }
//
//        private static void AddLog(string log)
//        {
//            log = String.Format("{0:HH.mm.ss.fff} : {1}{2}", DateTime.Now, log, Environment.NewLine);
//
//            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(logFileName, true))
//            {
//                sw.Write(log);
//                sw.Close();
//            }
//        }
//
//        public static void Log(LogLevel level, string log)
//        {
//            if ((logLevel & level) == level)
//            {
//                AddLog(log);
//            }
//        }
//
//        public static void Log(vector<unsigned char> buffer)
//        {
//            if ((logLevel & LogLevel.Debug) == LogLevel.Debug)
//            {
//                string formatedLog = "";
//
//                for (int i = 0; i < buffer.Length; i++)
//                {
//                    formatedLog += buffer[i].ToString("X2") + " ";
//                }
//
//                AddLog(formatedLog);
//            }
//        }
//
//        public static void Log(vector<unsigned char> buffer, string note)
//        {
//            string formatedLog = "";
//
//            if ((logLevel & LogLevel.Debug) == LogLevel.Debug)
//            {
//                for (int i = 0; i < buffer.Length; i++)
//                {
//                    formatedLog += buffer[i].ToString("X2") + " ";
//                }
//
//                AddLog(note);
//                AddLog(formatedLog);
//            }
//        }
//    }
//}
