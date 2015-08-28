using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Hugin.POS.CompactPrinter.FP300;
using Hugin.Common;

namespace FP300Service
{
    public class MainForm : Form,IBridge
    {
        private const string LV_CONNECTION  = "Bağlantı";
        private const string LV_PROGRAM     = "Programlama";
        private const string LV_SALE        = "Satış";
        private const string LV_REPORT      = "Raporlar";
        private const string LV_SERVICE     = "Servis";
        private const string LV_REG_INFO    = "Kasa Bilgileri";
        private const string LV_STATUS      = "Durum Kontrolü";
        
        private System.Windows.Forms.ImageList imgLstMenus;
        private System.Windows.Forms.ListView lvievMenu;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.RichTextBox txtLog;

        private const string FISCAL_PREFIX = "FP";

        private static string fiscalId = FISCAL_PREFIX + "12345678";
        public static Encoding DefaultEncoding = Encoding.GetEncoding(1254);
        private static string[] credits = new string[ProgramConfig.MAX_CREDIT_COUNT];
        private static FCurrency[] currencies = new FCurrency[ProgramConfig.MAX_FCURRENCY_COUNT];

        private static ICompactPrinter printer = null;

        private Panel pnlHeader;
        private TabControl tabConn;
        private TabPage tabTCP;
        private Label lblPort;
        private TextBox txtTcpPort;
        private Label lblIP;
        private TextBox txtTCPIP;
        private TabPage tabComPort;
        private ComboBox cmbPorts;
        private Label label1;
        private TextBox txtBaudrate;
        private Label lblComport;
        private Label label2;
        private TextBox txtFiscalId;
        private Button btnConnect;
        private Panel pnlLogo;
        #region Windows Form Designer generated code
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Programlama", 2);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Satış", 4);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Kasa Bilgileri", 1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Durum Kontrolü", 0);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Raporlar", 3);
            this.imgLstMenus = new System.Windows.Forms.ImageList(this.components);
            this.lvievMenu = new System.Windows.Forms.ListView();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFiscalId = new System.Windows.Forms.TextBox();
            this.tabConn = new System.Windows.Forms.TabControl();
            this.tabTCP = new System.Windows.Forms.TabPage();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtTcpPort = new System.Windows.Forms.TextBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.txtTCPIP = new System.Windows.Forms.TextBox();
            this.tabComPort = new System.Windows.Forms.TabPage();
            this.cmbPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBaudrate = new System.Windows.Forms.TextBox();
            this.lblComport = new System.Windows.Forms.Label();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            this.tabConn.SuspendLayout();
            this.tabTCP.SuspendLayout();
            this.tabComPort.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgLstMenus
            // 
            this.imgLstMenus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLstMenus.ImageStream")));
            this.imgLstMenus.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLstMenus.Images.SetKeyName(0, "status.jpg");
            this.imgLstMenus.Images.SetKeyName(1, "kasainfo.jpg");
            this.imgLstMenus.Images.SetKeyName(3, "reports.jpg");
            this.imgLstMenus.Images.SetKeyName(4, "sales.jpg");
            this.imgLstMenus.Images.SetKeyName(5, "program.jpg");
            this.imgLstMenus.Images.SetKeyName(6, "");
            // 
            // lvievMenu
            // 
            this.lvievMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvievMenu.BackColor = System.Drawing.Color.White;
            this.lvievMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvievMenu.FullRowSelect = true;
            this.lvievMenu.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.lvievMenu.LargeImageList = this.imgLstMenus;
            this.lvievMenu.Location = new System.Drawing.Point(8, 74);
            this.lvievMenu.Margin = new System.Windows.Forms.Padding(4);
            this.lvievMenu.Name = "lvievMenu";
            this.lvievMenu.Size = new System.Drawing.Size(159, 546);
            this.lvievMenu.SmallImageList = this.imgLstMenus;
            this.lvievMenu.TabIndex = 4;
            this.lvievMenu.UseCompatibleStateImageBehavior = false;
            this.lvievMenu.View = System.Windows.Forms.View.SmallIcon;
            this.lvievMenu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvievMenu_MouseClick);
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Location = new System.Drawing.Point(171, 74);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(789, 546);
            this.pnlMain.TabIndex = 3;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLog.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtLog.ForeColor = System.Drawing.Color.White;
            this.txtLog.Location = new System.Drawing.Point(8, 626);
            this.txtLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(949, 93);
            this.txtLog.TabIndex = 5;
            this.txtLog.Text = "";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.btnConnect);
            this.pnlHeader.Controls.Add(this.label2);
            this.pnlHeader.Controls.Add(this.txtFiscalId);
            this.pnlHeader.Controls.Add(this.tabConn);
            this.pnlHeader.Location = new System.Drawing.Point(169, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(787, 66);
            this.pnlHeader.TabIndex = 4;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(547, 2);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(147, 50);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Bağlantıyı Aç";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(399, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cihaz Seri No :";
            // 
            // txtFiscalId
            // 
            this.txtFiscalId.Location = new System.Drawing.Point(403, 30);
            this.txtFiscalId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFiscalId.Name = "txtFiscalId";
            this.txtFiscalId.Size = new System.Drawing.Size(109, 22);
            this.txtFiscalId.TabIndex = 5;
            this.txtFiscalId.Text = "111";
            // 
            // tabConn
            // 
            this.tabConn.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabConn.Controls.Add(this.tabTCP);
            this.tabConn.Controls.Add(this.tabComPort);
            this.tabConn.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabConn.ItemSize = new System.Drawing.Size(25, 120);
            this.tabConn.Location = new System.Drawing.Point(0, 0);
            this.tabConn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabConn.Multiline = true;
            this.tabConn.Name = "tabConn";
            this.tabConn.Padding = new System.Drawing.Point(0, 0);
            this.tabConn.SelectedIndex = 0;
            this.tabConn.Size = new System.Drawing.Size(392, 145);
            this.tabConn.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabConn.TabIndex = 2;
            this.tabConn.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabConn_DrawItem);
            // 
            // tabTCP
            // 
            this.tabTCP.Controls.Add(this.lblPort);
            this.tabTCP.Controls.Add(this.txtTcpPort);
            this.tabTCP.Controls.Add(this.lblIP);
            this.tabTCP.Controls.Add(this.txtTCPIP);
            this.tabTCP.Location = new System.Drawing.Point(124, 4);
            this.tabTCP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabTCP.Name = "tabTCP";
            this.tabTCP.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabTCP.Size = new System.Drawing.Size(264, 137);
            this.tabTCP.TabIndex = 0;
            this.tabTCP.Text = "TCP/IP";
            this.tabTCP.UseVisualStyleBackColor = true;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(20, 30);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(64, 17);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "Port No :";
            // 
            // txtTcpPort
            // 
            this.txtTcpPort.Location = new System.Drawing.Point(101, 30);
            this.txtTcpPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTcpPort.Name = "txtTcpPort";
            this.txtTcpPort.Size = new System.Drawing.Size(143, 22);
            this.txtTcpPort.TabIndex = 2;
            this.txtTcpPort.Text = "4444";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(20, 9);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(72, 17);
            this.lblIP.TabIndex = 1;
            this.lblIP.Text = "IP Adresi :";
            // 
            // txtTCPIP
            // 
            this.txtTCPIP.Location = new System.Drawing.Point(101, 6);
            this.txtTCPIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTCPIP.Name = "txtTCPIP";
            this.txtTCPIP.Size = new System.Drawing.Size(143, 22);
            this.txtTCPIP.TabIndex = 0;
            this.txtTCPIP.Text = "127.0.0.1";
            // 
            // tabComPort
            // 
            this.tabComPort.Controls.Add(this.cmbPorts);
            this.tabComPort.Controls.Add(this.label1);
            this.tabComPort.Controls.Add(this.txtBaudrate);
            this.tabComPort.Controls.Add(this.lblComport);
            this.tabComPort.Location = new System.Drawing.Point(124, 4);
            this.tabComPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabComPort.Name = "tabComPort";
            this.tabComPort.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabComPort.Size = new System.Drawing.Size(264, 137);
            this.tabComPort.TabIndex = 1;
            this.tabComPort.Text = "Seri Port";
            this.tabComPort.UseVisualStyleBackColor = true;
            // 
            // cmbPorts
            // 
            this.cmbPorts.FormattingEnabled = true;
            this.cmbPorts.Location = new System.Drawing.Point(101, 6);
            this.cmbPorts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbPorts.Name = "cmbPorts";
            this.cmbPorts.Size = new System.Drawing.Size(121, 24);
            this.cmbPorts.TabIndex = 8;
            this.cmbPorts.DropDown += new System.EventHandler(this.cmbPorts_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Baudrate :";
            // 
            // txtBaudrate
            // 
            this.txtBaudrate.Location = new System.Drawing.Point(101, 30);
            this.txtBaudrate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBaudrate.Name = "txtBaudrate";
            this.txtBaudrate.Size = new System.Drawing.Size(121, 22);
            this.txtBaudrate.TabIndex = 6;
            this.txtBaudrate.Text = "115200";
            // 
            // lblComport
            // 
            this.lblComport.AutoSize = true;
            this.lblComport.Location = new System.Drawing.Point(20, 9);
            this.lblComport.Name = "lblComport";
            this.lblComport.Size = new System.Drawing.Size(62, 17);
            this.lblComport.TabIndex = 5;
            this.lblComport.Text = "Port Adı:";
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.White;
            this.pnlLogo.BackgroundImage = global::FP300Service.Properties.Resources.FP300_All_mini;
            this.pnlLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLogo.Location = new System.Drawing.Point(8, 0);
            this.pnlLogo.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(159, 66);
            this.pnlLogo.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 720);
            this.Controls.Add(this.pnlLogo);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lvievMenu);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "FPU";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tabConn.ResumeLayout(false);
            this.tabTCP.ResumeLayout(false);
            this.tabTCP.PerformLayout();
            this.tabComPort.ResumeLayout(false);
            this.tabComPort.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public ICompactPrinter Printer
        {
            get
            {
                return printer;
            }
        }

        public static string[] Credits
        {
            get { return credits; }
        }

        public static void SetCredit(int id, string creditName)
        {
            credits[id] = creditName;
        }

        public static FCurrency[] Currencies
        {
            get { return currencies; }
        }

        public static void SetCurrency(int id, FCurrency currency)
        {
            if (id < currencies.Length)
            {
                currencies[id] = currency;
            }
        }

        public static string FiscalId
        {
            get { return fiscalId; }
        }

        public static void SetFiscalId(string strId)
        {
            int id = int.Parse(strId.Substring(2));

            if (id==0 || id>99999999)
            {
                throw new Exception("Geçersiz mali numara.");
            }
            fiscalId = strId;

            if (printer != null)
                printer.FiscalRegisterNo = fiscalId;
        }

        public MainForm()
        {
            InitializeComponent();


#if EJ_READER
            this.Text = "EKÜ OKUYUCU - HUGIN";
#endif


            try
            {
                if (System.Configuration.ConfigurationSettings.AppSettings["CommLog"] == "ON")
                {
                    LogForm lf = new LogForm();
                    lf.Show();
                }
            }
            catch (System.Exception ex)
            {

            }

            try
            {
                if (!String.IsNullOrEmpty(System.Configuration.ConfigurationSettings.AppSettings["FiscalId"]))
                {
                    txtFiscalId.Text = System.Configuration.ConfigurationSettings.AppSettings["FiscalId"];
                }
                if (!String.IsNullOrEmpty(System.Configuration.ConfigurationSettings.AppSettings["IP"]))
                {
                    txtTCPIP.Text = System.Configuration.ConfigurationSettings.AppSettings["IP"];
                }
                if (!String.IsNullOrEmpty(System.Configuration.ConfigurationSettings.AppSettings["Port"]))
                {
                    txtTcpPort.Text = System.Configuration.ConfigurationSettings.AppSettings["Port"];
                }

            }
            catch { }


            this.Text = "HUGIN FPU Rev:" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Revision;
        }

        private void lvievMenu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvievMenu_MouseClick(object sender, MouseEventArgs e)
        {
            if (((ListView)sender).FocusedItem == null) return;
            
            if (pnlMain.Controls.Count > 0 && pnlMain.Controls[0] is TestUC)
                ((TestUC)pnlMain.Controls[0]).CloseUC();

            TestUC uc = null;
            switch (((ListView)sender).FocusedItem.Text)
            {
                case LV_PROGRAM://Program
                    uc = UserControls.ProgramUC.Instance(this);
                    break;
                case LV_SALE://Sale
                    uc = UserControls.SaleUC.Instance(this);                    
                    break;
                case LV_REPORT://Report
                    uc = UserControls.ReportUC.Instance(this);      
                    break;
                case LV_REG_INFO://Info
                    uc = UserControls.FiscalInfoUC.Instance(this);
                    break;
                case LV_STATUS://Other
                    uc = UserControls.UtililtyFuncsUC.Instance(this);      
                    break;
            }


            if (uc != null)
            {
                uc.Dock = DockStyle.Fill;
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(uc);
            }

        }
        
        public void Log(string log)
        {
            txtLog.AppendText("## " + log + "\r\n");
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }

        public void Log()
        {
            // 1 Command
            // 2 Sequnce Number
            // 3 FPU State
            // 4 Error Code
            // 5 Error Message

            if (printer != null)
            {
                string lastlog = printer.GetLastLog();

                if (!String.IsNullOrEmpty(lastlog))
                {
                    if (!lastlog.Contains("|"))
                    {
                        Log(lastlog);
                        return;
                    }

                    string[] parsedLog = lastlog.Split('|');

                    if (parsedLog.Length == 5)
                    {

                        string command = parsedLog[0];
                        string sequnce = parsedLog[1];
                        string state = parsedLog[2];
                        string errorCode = parsedLog[3];
                        string errorMsg = parsedLog[4];

                        if (command != "NULL")
                        {

                            txtLog.AppendText(String.Format("{0} Komut :", sequnce));
                            txtLog.SelectionColor = Color.Red;
                            txtLog.AppendText(command + "\t");

                            txtLog.SelectionColor = Color.White;
                            txtLog.AppendText("FPU Durum :");
                            txtLog.SelectionColor = Color.Red;
                            txtLog.AppendText(state + "\t");
                        }
                        txtLog.SelectionColor = Color.White;
                        txtLog.AppendText("Cevap :");

                        Color responseColor = Color.LimeGreen;

                        if (errorCode != "0")
                        {
                            responseColor = Color.Red;
                            if (state == "SERVİS GEREKLİ" && errorCode != "3")
                            {
                                responseColor = Color.Yellow;
                            }
                        }

                        txtLog.SelectionColor = responseColor;
                        txtLog.AppendText(errorMsg + Environment.NewLine);

                        txtLog.SelectionStart = txtLog.Text.Length;
                        txtLog.ScrollToCaret();
                        txtLog.SelectionColor = Color.White;
                    }
                }
            }
        }

        private static IConnection conn;
        public IConnection Connection
        {
            get
            {
                return conn;
            }
            set
            {
                conn = value;
            }
        }

        private static int seqNumber = 1;
        public static int SequenceNumber
        {
            get { return seqNumber; }
            set { seqNumber = value; }
        }

        private void tabConn_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabConn.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabConn.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.WhiteSmoke);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Arial", (float)12.0, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Connection == null || !this.Connection.IsOpen)
                {
                    if (tabConn.SelectedTab == tabComPort)
                    {
                        this.Connection = new SerialConnection(cmbPorts.Text, int.Parse(txtBaudrate.Text));
                    }
                    else
                    {
                        int port = Convert.ToInt32(txtTcpPort.Text);
                        this.Connection = new TCPConnection(txtTCPIP.Text, port);
                    }

                    this.Connection.Open();

                    MatchExDevice();

                    MainForm.SetFiscalId(txtFiscalId.Text);
                    btnConnect.Text = "Bağlantıyı Kapat";
                    this.Log("Bağlantı Açıldı");
                }
                else
                {
                    this.Connection.Close();
                    this.Connection = null;
                    btnConnect.Text = "Bağlantıyı Aç";
                    this.Log("Bağlantı Kapatıldı");
                }


            }
            catch (System.Exception ex)
            {
                this.Log("Hata: Bağlantı Kurulamadı: " + ex.Message);
            }
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        private string GetMBId()
        {
            System.Management.ManagementObjectSearcher mos = new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            System.Management.ManagementObjectCollection moc = mos.Get();
            string motherBoard = "";
            foreach (System.Management.ManagementObject mo in moc)
            {
                motherBoard = (string)mo["SerialNumber"];
            }

            return motherBoard;
        }

        private void MatchExDevice()
        {
            MainForm.SetFiscalId(txtFiscalId.Text);

            DeviceInfo serverInfo = new DeviceInfo();
            serverInfo.Brand = System.Environment.MachineName;
            serverInfo.IP = System.Net.IPAddress.Parse(GetIPAddress());
            serverInfo.IPProtocol = IPProtocol.IPV4;
            serverInfo.Model = CreateMD5(GetMBId()).Substring(0, 8);// "FP300";
            serverInfo.Port = Convert.ToInt32(txtTcpPort.Text);
            serverInfo.TerminalNo = txtFiscalId.Text.PadLeft(8, '0');
            serverInfo.Version = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).LastWriteTime.ToShortDateString();

            if (conn.IsOpen)
            {
                try
                {
                    printer = new CompactPrinter();
                    printer.FiscalRegisterNo = fiscalId;
                    if (!printer.Connect(conn.ToObject(), serverInfo))
                    {
                        throw new OperationCanceledException("Eşleme yapılamadı");
                    }
                }
                catch (Exception ex)
                {
                    Log();
                    throw ex;
                }
                Log();
                CPResponse.Bridge = this;
            }
        }


        private string GetIPAddress()
        {
            System.Net.IPHostEntry host;
            string localIP = "?";
            host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            foreach (System.Net.IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        private void cmbPorts_DropDown(object sender, EventArgs e)
        {
            cmbPorts.Items.Clear();
            cmbPorts.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
        }

        private void btnEchoMsg_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conn != null)
                conn.Close();

            Dispose();
        }
    }
}
