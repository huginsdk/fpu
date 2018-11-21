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
        int BufferSize { get; set; }
    }

        public class MySerialPort : SerialPort
    {
        public MySerialPort(string portName, int baudrate) :
            base(portName, baudrate)
        {
        }
#if ON_RDP
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
#endif
    }

#if ON_RDP
    public class SerialConnection : IConnection, IDisposable
#else
    public class SerialConnection : IConnection
#endif
    {
        private string portName = String.Empty;
        private int baudRate = 115200;
        private static MySerialPort sp = null;
        private static int supportedBufferSize = ProgramConfig.DEFAULT_BUFFER_SIZE;

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

#if ON_RDP
        ~SerialConnection()
        {
            Dispose();
        }
#endif

        public void Open()
        {
            sp = new MySerialPort(portName, baudRate);
            sp.WriteTimeout =4500;
            sp.ReadTimeout = 4500;
            sp.ReadBufferSize = supportedBufferSize;
            sp.WriteBufferSize = supportedBufferSize;
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

#if ON_RDP
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
#endif


        public int BufferSize
        {
            get
            {
                return sp.ReadBufferSize;
            }
            set
            {
                // Close the connection
                Close();
                // Set new buffer size
                supportedBufferSize = value;
                // Re-open the connection
                Open();
            }
        }
    }
    public class TCPConnection : IConnection, IDisposable
    {
        private Socket client = null;
        private string ipAddress = String.Empty;
        private int port = 0;
        private static int supportedBufferSize = ProgramConfig.DEFAULT_BUFFER_SIZE;

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
            // Set initalize values
            client.ReceiveTimeout = 4500;
            client.ReceiveBufferSize = supportedBufferSize;
            client.SendBufferSize = supportedBufferSize;
            // Connect to destination
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
        
        public int BufferSize
        {
            get
            {
                return client.SendBufferSize;
            }
            set
            {
                // Close the connection
                Close();
                // Set new buffer size
                supportedBufferSize = value;
                // Re-open the connection
                Open();
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
