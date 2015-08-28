using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Net.Sockets;
using System.Net;
using System.Threading;


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

    public class SerialConnection : IConnection
    {
        private string portName = String.Empty;
        private int baudRate = 115200;
        private SerialPort sp = null;

        public SerialConnection(string portName, int baudrate)
        {
            this.portName = portName;
            this.baudRate = baudrate;
        }

        public void Open()
        {
            sp = new SerialPort(portName, baudRate);
            sp.WriteTimeout = 4600;
            sp.ReadTimeout = 4600;
            sp.ReadBufferSize = 40000;
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
            if (sp != null && sp.IsOpen)
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
            client.ReceiveTimeout = 500;
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
