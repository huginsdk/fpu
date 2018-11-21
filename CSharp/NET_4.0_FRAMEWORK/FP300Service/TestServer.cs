using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace FP300Service
{
    public partial class TestServer : Form,IDisposable
    {
        public string IpAddress = String.Empty;
        public int Port = 0;

        public TestServer()
        {
            InitializeComponent();
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(75, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(150, 64);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Başlat";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtLog.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtLog.ForeColor = System.Drawing.Color.White;
            this.txtLog.Location = new System.Drawing.Point(0, 91);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(366, 128);
            this.txtLog.TabIndex = 9;
            // 
            // TestServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 219);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TestServer";
            this.Text = "TestServer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtLog;

        private TcpListener listener;
        private Socket socket = null;
        System.Threading.Thread threadClient = null;

        private void StartTestServer(string tcpIp, int port)
        {
            try
            {
                String[] split = tcpIp.Split(',');

                if (split.Length != 4)
                    throw new Exception("IP Geçersiz");

                byte[] ip = new byte[4];

                for (int i = 0; i < split.Length; i++)
                {
                    ip[i] = Convert.ToByte(split[i].Trim());
                }
                System.Net.IPAddress addr = new System.Net.IPAddress(ip);
                if (listener != null)
                {
                    //listener.Server.Shutdown(SocketShutdown.Receive);
                    listener.Server.Close();
                    System.Threading.Thread.Sleep(200);
                }
                listener = new TcpListener(addr, port);
                listener.Start();
                Log("Ip ve port dinleme başladı");

                //wait for client
                System.Threading.ThreadStart ts = new System.Threading.ThreadStart(AccepClient);
                threadClient = new System.Threading.Thread(ts);
                threadClient.Priority = System.Threading.ThreadPriority.Highest;
                threadClient.IsBackground = true;
                threadClient.Start();

                while (!threadClient.IsAlive)
                {
                    System.Threading.Thread.Sleep(10);
                }

            }
            catch (Exception ex)
            {
                Log("Hata :" + ex.Message);
            }
        }

        private delegate void LogDelegate(string line);
        private void Log(string line)
        {
            if (txtLog.InvokeRequired)
            {
                try
                {
                    txtLog.Invoke(new LogDelegate(Log), line);
                }
                catch { }
            }
            else
            {
                txtLog.Text += line + Environment.NewLine;
                txtLog.SelectionStart = txtLog.Text.Length;
                txtLog.ScrollToCaret();
            }
        }

        private void AccepClient()
        {
            try
            {
                Log("Client bekleniyor.");
                TcpClient client = listener.AcceptTcpClient();
                client.ReceiveTimeout = 500;
                WaitMessage(client);

            }
            catch (Exception ex)
            {
                Log("Hata: " + ex.Message);
            }
            try
            {
                if (socket != null && socket.Connected)
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                    Log("Server kapatıldı.");
                }
            }
            catch (Exception ex)
            {
                Log("Hata: " + ex.Message);
            }
        }

        private void WaitMessage(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            while (true)
            {                
                Log("Mesaj bekleniyor");
                while (!stream.DataAvailable)
                {
                    System.Threading.Thread.Sleep(10);
                }
                byte[] buffer = new byte[1024];
                stream.Read(buffer, 0, buffer.Length);
                String recvMsg = MainForm.DefaultEncoding.GetString(buffer);
                Log("Mesaj alındı: " + recvMsg);
                if (recvMsg.StartsWith("UPDATE"))
                {
                    byte[] resBuff = MainForm.DefaultEncoding.GetBytes("DONE");
                    buffer = new byte[resBuff.Length + 2];
                    buffer[0] = (byte)(resBuff.Length / 256);
                    buffer[1] = (byte)(resBuff.Length % 256);
                    Array.Copy(resBuff, 0, buffer, 2, resBuff.Length);
                    //socket.Send(buffer);
                    stream.Write(buffer, 0, buffer.Length);
                    Log("Cevap gönderildi.");
                }
                else
                {
                    Log("Gelen mesaj çözümlenemedi.");
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (threadClient != null && threadClient.IsAlive)
                {
                    threadClient.Abort();
                    threadClient = null;
                    btnStart.Text = "Başlat";
                }
                else
                {
                    StartTestServer(IpAddress, Port);
                    btnStart.Text = "Durdur";
                }
            }
            catch { }
        }
        protected override void Dispose(bool disposing)
        {
         
            if (disposing)
            {
                try
                {
                    if (threadClient != null && threadClient.IsAlive)
                    {
                        listener.Stop();
                        threadClient.Abort();
                    }
                }
                catch { }             
            }
            base.Dispose(disposing);
        }
    }
}
