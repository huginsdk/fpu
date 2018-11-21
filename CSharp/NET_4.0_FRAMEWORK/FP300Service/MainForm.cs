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
    public enum FormLanguage
    {
        TR,
        EN
    }

    public class MainForm : Form,IBridge
    {
        private const string LV_PROGRAM = "PROGRAM";
        private const string LV_SALE = "SALE";
        private const string LV_REPORT = "REPORTS";
        private const string LV_SERVICE = "SERVICE";
        private const string LV_REG_INFO = "CR INFO";
        private const string LV_STATUS = "STATUS CHECK";
        
        private System.Windows.Forms.ImageList imgLstMenus;
        private System.Windows.Forms.ListView lvievMenu;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.RichTextBox txtLog;

        private static string fiscalId = "FP12345678";
        public static Encoding DefaultEncoding = Encoding.GetEncoding(1254);
        private static string[] credits = new string[ProgramConfig.MAX_CREDIT_COUNT];
        private static FCurrency[] currencies = new FCurrency[ProgramConfig.MAX_FCURRENCY_COUNT];
        private static string[] foodCards = new string[ProgramConfig.MAX_CREDIT_COUNT];

        private FormLanguage language = FormLanguage.TR;
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
        private TableLayoutPanel tableLayoutPanelMain;
        private TableLayoutPanel tableLayoutPanelScreens;
        private TableLayoutPanel tableLayoutMainPanel;
        private TableLayoutPanel tableLayoutConnection;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("PROGRAM", 2);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("SALE", 4);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("CR INFO", 1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("STATUS CHECK", 0);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("REPORTS", 3);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("SERVICE", 5);
            this.imgLstMenus = new System.Windows.Forms.ImageList(this.components);
            this.lvievMenu = new System.Windows.Forms.ListView();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tableLayoutMainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tabConn = new System.Windows.Forms.TabControl();
            this.tabTCP = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblIP = new System.Windows.Forms.Label();
            this.txtTcpPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtTCPIP = new System.Windows.Forms.TextBox();
            this.tabComPort = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBaudrate = new System.Windows.Forms.TextBox();
            this.lblComport = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.tableLayoutConnection = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFiscalId = new System.Windows.Forms.TextBox();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelScreens = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMain.SuspendLayout();
            this.tabConn.SuspendLayout();
            this.tabTCP.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tabComPort.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.tableLayoutConnection.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelScreens.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgLstMenus
            // 
            this.imgLstMenus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLstMenus.ImageStream")));
            this.imgLstMenus.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLstMenus.Images.SetKeyName(0, "status.jpg");
            this.imgLstMenus.Images.SetKeyName(1, "kasainfo.jpg");
            this.imgLstMenus.Images.SetKeyName(2, "service.jpg");
            this.imgLstMenus.Images.SetKeyName(3, "reports.jpg");
            this.imgLstMenus.Images.SetKeyName(4, "sales.jpg");
            this.imgLstMenus.Images.SetKeyName(5, "program.jpg");
            this.imgLstMenus.Images.SetKeyName(6, "");
            // 
            // lvievMenu
            // 
            this.lvievMenu.BackColor = System.Drawing.Color.White;
            this.lvievMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvievMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvievMenu.FullRowSelect = true;
            this.lvievMenu.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6});
            this.lvievMenu.LargeImageList = this.imgLstMenus;
            this.lvievMenu.Location = new System.Drawing.Point(4, 103);
            this.lvievMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lvievMenu.Name = "lvievMenu";
            this.lvievMenu.Size = new System.Drawing.Size(256, 792);
            this.lvievMenu.SmallImageList = this.imgLstMenus;
            this.lvievMenu.TabIndex = 4;
            this.lvievMenu.UseCompatibleStateImageBehavior = false;
            this.lvievMenu.View = System.Windows.Forms.View.SmallIcon;
            this.lvievMenu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvievMenu_MouseClick);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.tableLayoutMainPanel);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(4, 5);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(894, 782);
            this.pnlMain.TabIndex = 3;
            // 
            // tableLayoutMainPanel
            // 
            this.tableLayoutMainPanel.ColumnCount = 1;
            this.tableLayoutMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMainPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMainPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutMainPanel.Name = "tableLayoutMainPanel";
            this.tableLayoutMainPanel.RowCount = 1;
            this.tableLayoutMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutMainPanel.Size = new System.Drawing.Size(892, 780);
            this.tableLayoutMainPanel.TabIndex = 0;
            // 
            // tabConn
            // 
            this.tabConn.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabConn.Controls.Add(this.tabTCP);
            this.tabConn.Controls.Add(this.tabComPort);
            this.tabConn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabConn.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabConn.ItemSize = new System.Drawing.Size(25, 120);
            this.tabConn.Location = new System.Drawing.Point(3, 3);
            this.tabConn.Multiline = true;
            this.tabConn.Name = "tabConn";
            this.tabConn.Padding = new System.Drawing.Point(0, 0);
            this.tabConn.SelectedIndex = 0;
            this.tabConn.Size = new System.Drawing.Size(893, 80);
            this.tabConn.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabConn.TabIndex = 2;
            this.tabConn.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabConn_DrawItem);
            // 
            // tabTCP
            // 
            this.tabTCP.Controls.Add(this.tableLayoutPanel4);
            this.tabTCP.Location = new System.Drawing.Point(244, 4);
            this.tabTCP.Name = "tabTCP";
            this.tabTCP.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabTCP.Size = new System.Drawing.Size(645, 72);
            this.tabTCP.TabIndex = 0;
            this.tabTCP.Text = "TCP/IP";
            this.tabTCP.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.lblIP, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtTcpPort, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblPort, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.txtTCPIP, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(639, 66);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // lblIP
            // 
            this.lblIP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(143, 6);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(32, 20);
            this.lblIP.TabIndex = 1;
            this.lblIP.Text = "IP :";
            // 
            // txtTcpPort
            // 
            this.txtTcpPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTcpPort.Location = new System.Drawing.Point(322, 36);
            this.txtTcpPort.Name = "txtTcpPort";
            this.txtTcpPort.Size = new System.Drawing.Size(314, 26);
            this.txtTcpPort.TabIndex = 2;
            this.txtTcpPort.Text = "4444";
            // 
            // lblPort
            // 
            this.lblPort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(136, 39);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(46, 20);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "Port :";
            // 
            // txtTCPIP
            // 
            this.txtTCPIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTCPIP.Location = new System.Drawing.Point(322, 3);
            this.txtTCPIP.Name = "txtTCPIP";
            this.txtTCPIP.Size = new System.Drawing.Size(314, 26);
            this.txtTCPIP.TabIndex = 0;
            this.txtTCPIP.Text = "127.0.0.1";
            // 
            // tabComPort
            // 
            this.tabComPort.Controls.Add(this.tableLayoutPanel3);
            this.tabComPort.Location = new System.Drawing.Point(244, 4);
            this.tabComPort.Name = "tabComPort";
            this.tabComPort.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabComPort.Size = new System.Drawing.Size(643, 70);
            this.tabComPort.TabIndex = 1;
            this.tabComPort.Text = "SERIAL PORT";
            this.tabComPort.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.cmbPorts, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtBaudrate, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblComport, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(637, 64);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // cmbPorts
            // 
            this.cmbPorts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbPorts.FormattingEnabled = true;
            this.cmbPorts.Location = new System.Drawing.Point(321, 3);
            this.cmbPorts.Name = "cmbPorts";
            this.cmbPorts.Size = new System.Drawing.Size(313, 28);
            this.cmbPorts.TabIndex = 8;
            this.cmbPorts.DropDown += new System.EventHandler(this.cmbPorts_DropDown);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "BAUDRATE :";
            // 
            // txtBaudrate
            // 
            this.txtBaudrate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBaudrate.Location = new System.Drawing.Point(321, 35);
            this.txtBaudrate.Name = "txtBaudrate";
            this.txtBaudrate.Size = new System.Drawing.Size(313, 26);
            this.txtBaudrate.TabIndex = 6;
            this.txtBaudrate.Text = "115200";
            // 
            // lblComport
            // 
            this.lblComport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblComport.AutoSize = true;
            this.lblComport.Location = new System.Drawing.Point(129, 6);
            this.lblComport.Name = "lblComport";
            this.lblComport.Size = new System.Drawing.Size(60, 20);
            this.lblComport.TabIndex = 5;
            this.lblComport.Text = "PORT :";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtLog.ForeColor = System.Drawing.Color.White;
            this.txtLog.Location = new System.Drawing.Point(905, 3);
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(658, 786);
            this.txtLog.TabIndex = 5;
            this.txtLog.Text = "";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.tableLayoutConnection);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(268, 5);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1566, 88);
            this.pnlHeader.TabIndex = 4;
            // 
            // tableLayoutConnection
            // 
            this.tableLayoutConnection.ColumnCount = 2;
            this.tableLayoutConnection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.54082F));
            this.tableLayoutConnection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.45918F));
            this.tableLayoutConnection.Controls.Add(this.tabConn, 0, 0);
            this.tableLayoutConnection.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutConnection.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutConnection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutConnection.Name = "tableLayoutConnection";
            this.tableLayoutConnection.RowCount = 1;
            this.tableLayoutConnection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutConnection.Size = new System.Drawing.Size(1564, 86);
            this.tableLayoutConnection.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnConnect, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(903, 5);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(657, 76);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btnConnect
            // 
            this.btnConnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnect.Location = new System.Drawing.Point(331, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(323, 70);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "CONNECT";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtFiscalId, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 5);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(320, 66);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 33);
            this.label2.TabIndex = 6;
            this.label2.Text = "FISCAL ID :";
            // 
            // txtFiscalId
            // 
            this.txtFiscalId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFiscalId.Location = new System.Drawing.Point(3, 36);
            this.txtFiscalId.Name = "txtFiscalId";
            this.txtFiscalId.Size = new System.Drawing.Size(314, 26);
            this.txtFiscalId.TabIndex = 5;
            this.txtFiscalId.Text = "111";
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.White;
            this.pnlLogo.BackgroundImage = global::FP300Service.Properties.Resources.FP300_All_mini;
            this.pnlLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogo.Location = new System.Drawing.Point(4, 5);
            this.pnlLogo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(256, 88);
            this.pnlLogo.TabIndex = 4;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.36735F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.63265F));
            this.tableLayoutPanelMain.Controls.Add(this.pnlHeader, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.pnlLogo, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.lvievMenu, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelScreens, 1, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.94017F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.05983F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1838, 900);
            this.tableLayoutPanelMain.TabIndex = 6;
            // 
            // tableLayoutPanelScreens
            // 
            this.tableLayoutPanelScreens.ColumnCount = 2;
            this.tableLayoutPanelScreens.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.66283F));
            this.tableLayoutPanelScreens.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.33717F));
            this.tableLayoutPanelScreens.Controls.Add(this.txtLog, 1, 0);
            this.tableLayoutPanelScreens.Controls.Add(this.pnlMain, 0, 0);
            this.tableLayoutPanelScreens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelScreens.Location = new System.Drawing.Point(268, 103);
            this.tableLayoutPanelScreens.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanelScreens.Name = "tableLayoutPanelScreens";
            this.tableLayoutPanelScreens.RowCount = 1;
            this.tableLayoutPanelScreens.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelScreens.Size = new System.Drawing.Size(1566, 792);
            this.tableLayoutPanelScreens.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1838, 900);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "MainForm";
            this.Text = "FP300 Servis";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlMain.ResumeLayout(false);
            this.tabConn.ResumeLayout(false);
            this.tabTCP.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tabComPort.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.tableLayoutConnection.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelScreens.ResumeLayout(false);
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

        public FormLanguage Language
        {
            get { return language; }
        }

        public static string[] Credits
        {
            get { return credits; }
        }
        public static string[] FoodCards
        {
            get { return foodCards; }
        }

        public static void SetCredit(int id, string creditName)
        {
            credits[id] = creditName;
        }

        public static void SetFoodCard(int id, string foodCardName)
        {
            credits[id] = foodCardName;
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

            this.WindowState = FormWindowState.Maximized;
            
            if (!String.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["Language"]))
            {
                string code = System.Configuration.ConfigurationManager.AppSettings["Language"];
                switch (code)
                {
                    case "TR":
                        language = FormLanguage.TR;
                        break;
                    case "EN":
                        language = FormLanguage.EN;
                        break;
                    default:
                        language = FormLanguage.TR;
                        break;
                }
            }

            InitializeComponent();

            SetLanguageOption();


#if EJ_READER
            this.Text = "EKÜ OKUYUCU - HUGIN";
#endif
            
            try
            {
                if (!String.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["FiscalId"]))
                {
                    txtFiscalId.Text = System.Configuration.ConfigurationManager.AppSettings["FiscalId"];
                }
                if (!String.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["IP"]))
                {
                    txtTCPIP.Text = System.Configuration.ConfigurationManager.AppSettings["IP"];
                }
                if (!String.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["Port"]))
                {
                    txtTcpPort.Text = System.Configuration.ConfigurationManager.AppSettings["Port"];
                }             
            }
            catch { }

            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.Text = String.Format("ECR TEST v{0}", version.Substring(version.Length-3));
        }

        private void SetLanguageOption()
        {
            this.btnConnect.Text = FormMessage.CONNECT;
            this.tabComPort.Text = FormMessage.SERIAL_PORT;
            this.lvievMenu.Items[0].Text = FormMessage.STATUS_CHECK;
            this.lvievMenu.Items[1].Text = FormMessage.CASH_REGISTER_INFO;
            this.lvievMenu.Items[2].Text = FormMessage.PROGRAM;
            this.lvievMenu.Items[3].Text = FormMessage.REPORTS;
            this.lvievMenu.Items[4].Text = FormMessage.SALE;
            this.lvievMenu.Items[5].Text = FormMessage.SERVICE;
        }

        private void lvievMenu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvievMenu_MouseClick(object sender, MouseEventArgs e)
        {
            if (((ListView)sender).FocusedItem == null) return;

            //if (pnlMain.Controls.Count > 0 && pnlMain.Controls[0] is TestUC)
            //    ((TestUC)pnlMain.Controls[0]).CloseUC();

            if (tableLayoutMainPanel.Controls.Count > 0 && tableLayoutMainPanel.Controls[0] is TestUC)
                ((TestUC)tableLayoutMainPanel.Controls[0]).CloseUC();

            TestUC uc = null;
            switch (((ListView)sender).FocusedItem.Text)
            {
                case FormMessage.PROGRAM://Program
                    uc = UserControls.ProgramUC.Instance(this);
                    break;
                case FormMessage.SALE://Sale
                    uc = UserControls.SaleUC.Instance(this);
                    break;
                case FormMessage.REPORTS://Report
                    uc = UserControls.ReportUC.Instance(this);      
                    break;
                case FormMessage.SERVICE://Service
                    uc = UserControls.ServiceUC.Instance(this);
                    break;
                case FormMessage.CASH_REGISTER_INFO://Info
                    uc = UserControls.FiscalInfoUC.Instance(this);
                    break;
                case FormMessage.STATUS_CHECK://Other
                    uc = UserControls.UtililtyFuncsUC.Instance(this);      
                    break;
            }


            if (uc != null)
            {
                uc.Dock = DockStyle.Fill;
                tableLayoutMainPanel.Controls.Clear();
                tableLayoutMainPanel.Controls.Add(uc);
            }

        }

        private delegate void LogDelegate(String log);
        public void Log(string log)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new LogDelegate(Log), log);
            }
            else
            {
                txtLog.AppendText("# " + log + "\r\n");
                txtLog.SelectionStart = txtLog.Text.Length;
                txtLog.ScrollToCaret();
            }
        }

        private delegate void LogDelegate2();
        public void Log()
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new LogDelegate2(Log));
            }
            else
            {
                // 1 Command
                // 2 Sequnce Number
                // 3 FPU State
                // 4 Error Code
                // 5 Error Message

                if (printer != null)
                {
                    string lastlog = printer.GetLastLog();

                    txtLog.SelectionColor = Color.CornflowerBlue;
                    txtLog.AppendText("***************************************************" + Environment.NewLine);

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
                                txtLog.SelectionColor = Color.White;
                                if (sequnce.Length == 1)
                                    txtLog.AppendText(String.Format("{0} {1}:", sequnce, FormMessage.COMMAND.PadRight(12, ' ')));
                                else if (sequnce.Length == 2)
                                    txtLog.AppendText(String.Format("{0} {1}:", sequnce, FormMessage.COMMAND.PadRight(11, ' ')));
                                else
                                    txtLog.AppendText(String.Format("{0} {1}:", sequnce, FormMessage.COMMAND.PadRight(10, ' ')));


                                txtLog.SelectionColor = Color.Red;
                                txtLog.AppendText(command + "\t" + Environment.NewLine);

                                txtLog.SelectionColor = Color.White;
                                txtLog.AppendText("  " + FormMessage.FPU_STATE.PadRight(12, ' ') + ":");
                                txtLog.SelectionColor = Color.LightSkyBlue;
                                txtLog.AppendText(state + "\t" + Environment.NewLine);
                            }
                            txtLog.SelectionColor = Color.White;
                            txtLog.AppendText("  " + FormMessage.RESPONSE.PadRight(12, ' ') + ":");

                            Color responseColor = Color.LimeGreen;

                            if (errorCode != "0")
                            {
                                responseColor = Color.Red;
                                if (state == FormMessage.NEED_SERVICE && errorCode != "3")
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
        }

#if CPP
        private static bool conn = false;
        public bool Connection2
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

        private static BridgeConn conn2 = new BridgeConn();
        public BridgeConn Connection
        {
            get { return conn2; }
            set { conn2 = value; }
        }
#else
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
#endif

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
            string errPrefix = FormMessage.CONNECTION_ERROR + ": ";
            try
            {
                if (this.Connection == null)
                {
                    if (tabConn.SelectedTab == tabComPort)
                    {
                        // Seri port bağlantısı oluşturulur
                        this.Connection = new SerialConnection(cmbPorts.Text, int.Parse(txtBaudrate.Text));
                    }
                    else
                    {
                        // TCP/IP bağlantı oluşturulur
                        int port = Convert.ToInt32(txtTcpPort.Text);
                        this.Connection = new TCPConnection(txtTCPIP.Text, port);
                    }

                    this.Log(FormMessage.CONNECTING + "... ("+FormMessage.PLEASE_WAIT+")");
                    this.Connection.Open();

                    errPrefix = FormMessage.MATCHING_ERROR + ": ";

                    // ÖKC ile eşleme adımı
                    MatchExDevice();

                    MainForm.SetFiscalId(txtFiscalId.Text);
                    btnConnect.Text = FormMessage.DISCONNECT;
                    this.Log(FormMessage.CONNECTED);
                }
                else
                {
                    this.Connection.Close();
                    this.Connection = null;
                    btnConnect.Text = FormMessage.CONNECT;
                    this.Log(FormMessage.DISCONNECTED);
                }
            }
            catch (System.Exception ex)
            {
                this.Log(FormMessage.OPERATION_FAILS + ": " + errPrefix + ex.Message);

                if (conn != null)
                {
                    btnConnect.Text = FormMessage.DISCONNECT;
                }
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


        private static bool isMatchedBefore = false;
        private void MatchExDevice()
        {
            MainForm.SetFiscalId(txtFiscalId.Text);

            // DeviceInfo sınıfı gerekli bilgiler ile doldurulur
            DeviceInfo serverInfo = new DeviceInfo();
            serverInfo.IP = System.Net.IPAddress.Parse(GetIPAddress());
            serverInfo.IPProtocol = IPProtocol.IPV4;

            serverInfo.Brand = "HUGIN";

            if (!String.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["Brand"]))
            {
                serverInfo.Brand = System.Configuration.ConfigurationManager.AppSettings["Brand"];
            }
            
            serverInfo.Model = "HUGIN COMPACT";
            serverInfo.Port = Convert.ToInt32(txtTcpPort.Text);
            serverInfo.TerminalNo = txtFiscalId.Text.PadLeft(8, '0');
            serverInfo.Version = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).LastWriteTime.ToShortDateString();
            try
            {
                // Motherboard serisi alınır
                serverInfo.SerialNum = CreateMD5(GetMBId()).Substring(0, 8);
            }
            catch
            {
                // Seri alınırken sıkıntı yaşanırsa default bir değer verilebilir
                serverInfo.SerialNum = "ABCD1234";
            }


            if (conn.IsOpen)
            {
                if (isMatchedBefore)
                {
                    // Eğer önceden eşleme yapıldıysa sadece connection objesinin kütüphaneye set edlmesi yeterli olacaktır.
                    printer.SetCommObject(conn.ToObject());
                    return;
                }
                try
                {
                    printer = new CompactPrinter();

                    // Eşleme öncesi ÖKC sicil numarası kütüphane üzerinde ilgili alana set edilir.
                    printer.FiscalRegisterNo = fiscalId;

                    try
                    {
                        // Loglama yapılacak dizin ve log seviyesi istenirse set edilir. Opsiyonel seçeneklerdir. 
                        //Set edilmemesi durumunda default değerler kullanılır.
                        if (!String.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["LogDirectory"]))
                        {
                            printer.LogDirectory = System.Configuration.ConfigurationManager.AppSettings["LogDirectory"];
                        }

                        printer.LogerLevel = int.Parse(System.Configuration.ConfigurationManager.AppSettings["LogLevel"]);
                    }
                    catch { }

                    // Eşleme başlatılır. Başarılı ise true, başarısız ise false döner.
                    if (!printer.Connect(conn.ToObject(), serverInfo))
                    {
                        throw new OperationCanceledException(FormMessage.UNABLE_TO_MATCH);
                    }

                    // ÖKC üzerinde desteklenen bağlantı kapasitesi kontrol edilir, oluşturulan connection ile farklı ise düzenleme yapılır.
                    // Check supported printer size and set if it is different
                    if (printer.PrinterBufferSize != conn.BufferSize)
                    {
                        conn.BufferSize = printer.PrinterBufferSize;
                    }
                    printer.SetCommObject(conn.ToObject());
                    isMatchedBefore = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conn != null)
                conn.Close();

            Dispose();
        }


        int currentWidth = 1366;
        int currentHeight = 768;
        private void MainForm_Load(object sender, EventArgs e)
        {
            Rectangle clientResolution = new Rectangle();

            clientResolution = Screen.GetBounds(clientResolution);

            float widthRatio = (float)clientResolution.Width / (float)currentWidth;
            float heightRatio = (float)clientResolution.Height / (float)currentHeight;

            SizeF ratioSize = new SizeF(widthRatio, heightRatio);

            this.Scale(ratioSize);

            foreach (Control c in pnlMain.Controls)
            {
                c.Scale(ratioSize);
            }

        }
    }
}
