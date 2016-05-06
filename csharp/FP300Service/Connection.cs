using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Net.Sockets;
using System.Net;


namespace FP300Service
{
    enum ContentType
    {
        NONE,
        REPORT,
        FILE
    }
    public interface IConnection
    {
        void Open();
        bool IsOpen { get; }
        void Close();
        int FPUTimeout { get; set; }
        object ToObject();
    }

        public class MySerialPort : SerialPort
    {
        public MySerialPort(string portName, int baudrate) :
            base(portName, baudrate)
        {
        }
        protected override void Dispose(bool disposing)
        {
            // our variant for
            // 
            // http://social.msdn.microsoft.com/Forums/en-US/netfxnetcom/thread/8b02d5d0-b84e-447a-b028-f853d6c6c690
            // http://connect.microsoft.com/VisualStudio/feedback/details/140018/serialport-crashes-after-disconnect-of-usb-com-port

            var stream = (System.IO.Stream)typeof(SerialPort).GetField("internalSerialStream", 
                                                                    System.Reflection.BindingFlags.Instance | 
                                                                    System.Reflection.BindingFlags.NonPublic).GetValue(this);

            if (stream != null)
            {
                try { stream.Dispose(); }
                catch { }
            }

            base.Dispose(disposing);
        }
    }
    public class SerialConnection : IConnection, IDisposable
    {
        private string portName = String.Empty;
        private int baudRate = 115200;
        private static MySerialPort sp = null;

        public SerialConnection(string portName, int baudrate)
        {
            this.portName = portName;
            this.baudRate = baudrate;

            try
            {
                if (IsOpen)
                {
                    Close();
                }
            }
            catch
            {
            }
        }

        ~SerialConnection()
        {
            Dispose();
        }

        public void Open()
        {
            sp = new MySerialPort(portName, baudRate);
            sp.WriteTimeout =4500;
            sp.ReadTimeout = 4500;
            sp.ReadBufferSize = 4096;
            sp.Encoding = MainForm.DefaultEncoding;
            sp.Open();
        }

        public bool IsOpen
        {
            get 
            {
                if (sp!= null && sp.IsOpen)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Close()
        {
            if (sp != null) 
            {
              //  if (sp.IsOpen)
                    sp.Close();
            }
        }

        public int FPUTimeout
        {
            get
            {
                return sp.ReadTimeout;
            }
            set
            {
                sp.ReadTimeout = value;
            }
        }

        public object ToObject()
        {
            return sp;
        }

        public void Dispose()
        {
            try
            {
                Close();
                sp = null;
            }
            catch
            {
            }
        }
    }
    public class TCPConnection : IConnection, IDisposable
    {
        private Socket client = null;
        private string ipAddress = String.Empty;
        private int port = 0;

        public TCPConnection(String ipAddress, int port)
        {
            this.ipAddress = ipAddress;
            this.port = port;
        }

        // Destructor of this class.
        ~TCPConnection()
        {
            Dispose();
        }

        public void Open()
        {
            // Close if there is any idle connection
            this.Close();

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(this.ipAddress), this.port);
            client = new Socket(AddressFamily.InterNetwork,
                              SocketType.Stream, ProtocolType.Tcp);
            client.ReceiveTimeout = 4500;
            client.Connect(ipep);


        }

        public bool IsOpen
        {
            get
            {
                if (client != null && client.Connected)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Close()
        {
            if (IsOpen)
            {
                client.Shutdown(SocketShutdown.Both);
                client.Close();
                client.Dispose();
            }
        }

        public int FPUTimeout
        {
            get
            {
                return client.ReceiveTimeout;
            }
            set
            {
                client.ReceiveTimeout = value;
            }
        }

        public void Dispose()
        {
            try
            {
                Close();
            }
            catch (System.Exception)
            {
            	
            }
        }

        public object ToObject()
        {
            return client;
        }
    }
}
