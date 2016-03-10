using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;


namespace FP300Service.UserControls
{
    public class ServiceUC : TestUC
    {


        public ServiceUC()
            :base()
            
        {
            InitializeComponent();
         
            mtbxIP.ValidatingType = typeof(System.Net.IPAddress);
#if !IN_TEST
            btnTestServer.Visible = false;
#endif
        }

        private static TestUC serviceForm = null;      
        private TabPage tabSRVOperation;
        private GroupBox gbxServiceMode;
        private Label lblOrderNum;
        private Button btnOrderNum;
        private GroupBox groupBox2;
        private TextBox txtFileName;
        private Label lblFileName;
        private Button btnxFer;
        private GroupBox gbxDateTime;
        private CheckBox cbxTime;
        private CheckBox cbxSetDate;
        private DateTimePicker dtFPTime;
        private DateTimePicker dtFPDate;
        private Button btnSetDateTime;
        private GroupBox gbxServiceInOut;
        private Button btnEnterService;
        private Button btnExitService;
        private TextBox txtPassword;
        private Label lblPass;
        private GroupBox gbxExtDevice;
        private Label lblPort;
        private Label lblIP;
        private TextBox tbxPort;
        private MaskedTextBox mtbxIP;
        private Button btnSetExternalSettings;
        private GroupBox groupBox1;
        private Button btnStartFMTest;
        private Button btnCreateDB;
        private Button btnCloseFM;
        private Button btnFatorySettings;
        private Button btnPrintLogs;
        private Button btnFormatDailyMem;
        private Button btnEJInit;
        private GroupBox gbxFirmUpdate;
        private Button btnTestServer;
        private Label lblServPort;
        private Label lblServIP;
        private TextBox txtServerPort;
        private MaskedTextBox mtbxServerIp;
        private Button btnUpdateFirmware;
        private GroupBox gbxFiscalMode;
        private TextBox txtPrgmPass;
        private Label lblPrgrmPass;
        private Button btnFiscalMode;
        private TabControl tcntService;
        private TabPage tabSRVTest;
        private GroupBox gbxTestGmp;
        private Button btnTestGmp;
        private ComboBox cmbGmpCmds;
        private Label lblGMPPort;
        private TextBox txtGMPPort;
        private Button btnGMPPort;
        private Label lblTsmIp;
        private MaskedTextBox mtbxTSMIp;
        private GroupBox gbxLog;
        private DateTimePicker dtpLog;
        private static IBridge bridge = null;

        internal static TestUC Instance(IBridge iBridge)
        {
            if (serviceForm == null)
            {
                serviceForm = new ServiceUC();
                bridge = iBridge;
            }
            return serviceForm;
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabSRVOperation = new System.Windows.Forms.TabPage();
            this.gbxLog = new System.Windows.Forms.GroupBox();
            this.dtpLog = new System.Windows.Forms.DateTimePicker();
            this.btnPrintLogs = new System.Windows.Forms.Button();
            this.gbxServiceMode = new System.Windows.Forms.GroupBox();
            this.lblOrderNum = new System.Windows.Forms.Label();
            this.btnOrderNum = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnxFer = new System.Windows.Forms.Button();
            this.gbxDateTime = new System.Windows.Forms.GroupBox();
            this.cbxTime = new System.Windows.Forms.CheckBox();
            this.cbxSetDate = new System.Windows.Forms.CheckBox();
            this.dtFPTime = new System.Windows.Forms.DateTimePicker();
            this.dtFPDate = new System.Windows.Forms.DateTimePicker();
            this.btnSetDateTime = new System.Windows.Forms.Button();
            this.gbxServiceInOut = new System.Windows.Forms.GroupBox();
            this.btnEnterService = new System.Windows.Forms.Button();
            this.btnExitService = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.gbxExtDevice = new System.Windows.Forms.GroupBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.tbxPort = new System.Windows.Forms.TextBox();
            this.mtbxIP = new System.Windows.Forms.MaskedTextBox();
            this.btnSetExternalSettings = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStartFMTest = new System.Windows.Forms.Button();
            this.btnCreateDB = new System.Windows.Forms.Button();
            this.btnCloseFM = new System.Windows.Forms.Button();
            this.btnFatorySettings = new System.Windows.Forms.Button();
            this.btnFormatDailyMem = new System.Windows.Forms.Button();
            this.btnEJInit = new System.Windows.Forms.Button();
            this.gbxFirmUpdate = new System.Windows.Forms.GroupBox();
            this.btnTestServer = new System.Windows.Forms.Button();
            this.lblServPort = new System.Windows.Forms.Label();
            this.lblServIP = new System.Windows.Forms.Label();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.mtbxServerIp = new System.Windows.Forms.MaskedTextBox();
            this.btnUpdateFirmware = new System.Windows.Forms.Button();
            this.gbxFiscalMode = new System.Windows.Forms.GroupBox();
            this.txtPrgmPass = new System.Windows.Forms.TextBox();
            this.lblPrgrmPass = new System.Windows.Forms.Label();
            this.btnFiscalMode = new System.Windows.Forms.Button();
            this.tcntService = new System.Windows.Forms.TabControl();
            this.tabSRVTest = new System.Windows.Forms.TabPage();
            this.gbxTestGmp = new System.Windows.Forms.GroupBox();
            this.lblTsmIp = new System.Windows.Forms.Label();
            this.mtbxTSMIp = new System.Windows.Forms.MaskedTextBox();
            this.lblGMPPort = new System.Windows.Forms.Label();
            this.txtGMPPort = new System.Windows.Forms.TextBox();
            this.btnGMPPort = new System.Windows.Forms.Button();
            this.cmbGmpCmds = new System.Windows.Forms.ComboBox();
            this.btnTestGmp = new System.Windows.Forms.Button();
            this.tabSRVOperation.SuspendLayout();
            this.gbxLog.SuspendLayout();
            this.gbxServiceMode.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbxDateTime.SuspendLayout();
            this.gbxServiceInOut.SuspendLayout();
            this.gbxExtDevice.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbxFirmUpdate.SuspendLayout();
            this.gbxFiscalMode.SuspendLayout();
            this.tcntService.SuspendLayout();
            this.tabSRVTest.SuspendLayout();
            this.gbxTestGmp.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSRVOperation
            // 
            this.tabSRVOperation.Controls.Add(this.gbxLog);
            this.tabSRVOperation.Controls.Add(this.gbxServiceMode);
            this.tabSRVOperation.Controls.Add(this.groupBox2);
            this.tabSRVOperation.Controls.Add(this.gbxDateTime);
            this.tabSRVOperation.Controls.Add(this.gbxServiceInOut);
            this.tabSRVOperation.Controls.Add(this.gbxExtDevice);
            this.tabSRVOperation.Controls.Add(this.groupBox1);
            this.tabSRVOperation.Controls.Add(this.gbxFirmUpdate);
            this.tabSRVOperation.Controls.Add(this.gbxFiscalMode);
            this.tabSRVOperation.Location = new System.Drawing.Point(4, 22);
            this.tabSRVOperation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabSRVOperation.Name = "tabSRVOperation";
            this.tabSRVOperation.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabSRVOperation.Size = new System.Drawing.Size(583, 401);
            this.tabSRVOperation.TabIndex = 0;
            this.tabSRVOperation.Text = "SERVICE OPERATIONS";
            this.tabSRVOperation.UseVisualStyleBackColor = true;
            // 
            // gbxLog
            // 
            this.gbxLog.Controls.Add(this.dtpLog);
            this.gbxLog.Controls.Add(this.btnPrintLogs);
            this.gbxLog.Location = new System.Drawing.Point(410, 5);
            this.gbxLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxLog.Name = "gbxLog";
            this.gbxLog.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxLog.Size = new System.Drawing.Size(160, 87);
            this.gbxLog.TabIndex = 28;
            this.gbxLog.TabStop = false;
            // 
            // dtpLog
            // 
            this.dtpLog.CustomFormat = "dd-MM-yyyy";
            this.dtpLog.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLog.Location = new System.Drawing.Point(14, 16);
            this.dtpLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpLog.Name = "dtpLog";
            this.dtpLog.Size = new System.Drawing.Size(95, 20);
            this.dtpLog.TabIndex = 37;
            // 
            // btnPrintLogs
            // 
            this.btnPrintLogs.Location = new System.Drawing.Point(4, 43);
            this.btnPrintLogs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPrintLogs.Name = "btnPrintLogs";
            this.btnPrintLogs.Size = new System.Drawing.Size(110, 30);
            this.btnPrintLogs.TabIndex = 6;
            this.btnPrintLogs.Text = "PRINT LOGS";
            this.btnPrintLogs.UseVisualStyleBackColor = true;
            this.btnPrintLogs.Click += new System.EventHandler(this.btnPrintLogs_Click);
            // 
            // gbxServiceMode
            // 
            this.gbxServiceMode.Controls.Add(this.lblOrderNum);
            this.gbxServiceMode.Controls.Add(this.btnOrderNum);
            this.gbxServiceMode.Location = new System.Drawing.Point(4, 5);
            this.gbxServiceMode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxServiceMode.Name = "gbxServiceMode";
            this.gbxServiceMode.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxServiceMode.Size = new System.Drawing.Size(400, 44);
            this.gbxServiceMode.TabIndex = 19;
            this.gbxServiceMode.TabStop = false;
            // 
            // lblOrderNum
            // 
            this.lblOrderNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOrderNum.Location = new System.Drawing.Point(146, 10);
            this.lblOrderNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrderNum.Name = "lblOrderNum";
            this.lblOrderNum.Size = new System.Drawing.Size(70, 30);
            this.lblOrderNum.TabIndex = 14;
            // 
            // btnOrderNum
            // 
            this.btnOrderNum.Location = new System.Drawing.Point(4, 10);
            this.btnOrderNum.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOrderNum.Name = "btnOrderNum";
            this.btnOrderNum.Size = new System.Drawing.Size(110, 30);
            this.btnOrderNum.TabIndex = 13;
            this.btnOrderNum.Text = "ORDER CODE";
            this.btnOrderNum.UseVisualStyleBackColor = true;
            this.btnOrderNum.Click += new System.EventHandler(this.btnOrderNum_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFileName);
            this.groupBox2.Controls.Add(this.lblFileName);
            this.groupBox2.Controls.Add(this.btnxFer);
            this.groupBox2.Location = new System.Drawing.Point(4, 337);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(400, 51);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(201, 20);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFileName.MaxLength = 50;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(174, 20);
            this.txtFileName.TabIndex = 14;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(136, 23);
            this.lblFileName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(69, 13);
            this.lblFileName.TabIndex = 13;
            this.lblFileName.Text = "FILE NAME :";
            // 
            // btnxFer
            // 
            this.btnxFer.Location = new System.Drawing.Point(6, 15);
            this.btnxFer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnxFer.Name = "btnxFer";
            this.btnxFer.Size = new System.Drawing.Size(110, 30);
            this.btnxFer.TabIndex = 7;
            this.btnxFer.Text = "FILE TRANSFER";
            this.btnxFer.UseVisualStyleBackColor = true;
            this.btnxFer.Click += new System.EventHandler(this.btnxFer_Click);
            // 
            // gbxDateTime
            // 
            this.gbxDateTime.Controls.Add(this.cbxTime);
            this.gbxDateTime.Controls.Add(this.cbxSetDate);
            this.gbxDateTime.Controls.Add(this.dtFPTime);
            this.gbxDateTime.Controls.Add(this.dtFPDate);
            this.gbxDateTime.Controls.Add(this.btnSetDateTime);
            this.gbxDateTime.Location = new System.Drawing.Point(4, 92);
            this.gbxDateTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxDateTime.Name = "gbxDateTime";
            this.gbxDateTime.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxDateTime.Size = new System.Drawing.Size(400, 56);
            this.gbxDateTime.TabIndex = 20;
            this.gbxDateTime.TabStop = false;
            // 
            // cbxTime
            // 
            this.cbxTime.AutoSize = true;
            this.cbxTime.Checked = true;
            this.cbxTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxTime.Location = new System.Drawing.Point(166, 33);
            this.cbxTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxTime.Name = "cbxTime";
            this.cbxTime.Size = new System.Drawing.Size(55, 17);
            this.cbxTime.TabIndex = 39;
            this.cbxTime.Text = "Time :";
            this.cbxTime.UseVisualStyleBackColor = true;
            this.cbxTime.CheckedChanged += new System.EventHandler(this.cbxTime_CheckedChanged);
            // 
            // cbxSetDate
            // 
            this.cbxSetDate.AutoSize = true;
            this.cbxSetDate.Checked = true;
            this.cbxSetDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxSetDate.Location = new System.Drawing.Point(166, 11);
            this.cbxSetDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxSetDate.Name = "cbxSetDate";
            this.cbxSetDate.Size = new System.Drawing.Size(55, 17);
            this.cbxSetDate.TabIndex = 38;
            this.cbxSetDate.Text = "Date :";
            this.cbxSetDate.UseVisualStyleBackColor = true;
            this.cbxSetDate.CheckedChanged += new System.EventHandler(this.cbxSetDate_CheckedChanged);
            // 
            // dtFPTime
            // 
            this.dtFPTime.CustomFormat = "HH:mm";
            this.dtFPTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFPTime.Location = new System.Drawing.Point(232, 35);
            this.dtFPTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtFPTime.Name = "dtFPTime";
            this.dtFPTime.ShowUpDown = true;
            this.dtFPTime.Size = new System.Drawing.Size(95, 20);
            this.dtFPTime.TabIndex = 37;
            // 
            // dtFPDate
            // 
            this.dtFPDate.CustomFormat = "dd-MM-yyyy";
            this.dtFPDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFPDate.Location = new System.Drawing.Point(232, 11);
            this.dtFPDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtFPDate.Name = "dtFPDate";
            this.dtFPDate.Size = new System.Drawing.Size(95, 20);
            this.dtFPDate.TabIndex = 36;
            // 
            // btnSetDateTime
            // 
            this.btnSetDateTime.Location = new System.Drawing.Point(4, 19);
            this.btnSetDateTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSetDateTime.Name = "btnSetDateTime";
            this.btnSetDateTime.Size = new System.Drawing.Size(110, 30);
            this.btnSetDateTime.TabIndex = 7;
            this.btnSetDateTime.Text = "SET DATE/TIME";
            this.btnSetDateTime.UseVisualStyleBackColor = true;
            this.btnSetDateTime.Click += new System.EventHandler(this.btnSetDateTime_Click);
            // 
            // gbxServiceInOut
            // 
            this.gbxServiceInOut.Controls.Add(this.btnEnterService);
            this.gbxServiceInOut.Controls.Add(this.btnExitService);
            this.gbxServiceInOut.Controls.Add(this.txtPassword);
            this.gbxServiceInOut.Controls.Add(this.lblPass);
            this.gbxServiceInOut.Location = new System.Drawing.Point(4, 38);
            this.gbxServiceInOut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxServiceInOut.Name = "gbxServiceInOut";
            this.gbxServiceInOut.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxServiceInOut.Size = new System.Drawing.Size(400, 54);
            this.gbxServiceInOut.TabIndex = 26;
            this.gbxServiceInOut.TabStop = false;
            // 
            // btnEnterService
            // 
            this.btnEnterService.Location = new System.Drawing.Point(4, 17);
            this.btnEnterService.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEnterService.Name = "btnEnterService";
            this.btnEnterService.Size = new System.Drawing.Size(110, 30);
            this.btnEnterService.TabIndex = 6;
            this.btnEnterService.Text = "ENTER SERVICE MODE";
            this.btnEnterService.UseVisualStyleBackColor = true;
            this.btnEnterService.Click += new System.EventHandler(this.btnEnterService_Click);
            // 
            // btnExitService
            // 
            this.btnExitService.Location = new System.Drawing.Point(147, 17);
            this.btnExitService.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExitService.Name = "btnExitService";
            this.btnExitService.Size = new System.Drawing.Size(110, 30);
            this.btnExitService.TabIndex = 7;
            this.btnExitService.Text = "EXIT SERVICE MODE";
            this.btnExitService.UseVisualStyleBackColor = true;
            this.btnExitService.Click += new System.EventHandler(this.btnExitService_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(275, 27);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPassword.MaxLength = 10;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(70, 20);
            this.txtPassword.TabIndex = 12;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(272, 15);
            this.lblPass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(76, 13);
            this.lblPass.TabIndex = 11;
            this.lblPass.Text = "PASSWORD :";
            // 
            // gbxExtDevice
            // 
            this.gbxExtDevice.Controls.Add(this.lblPort);
            this.gbxExtDevice.Controls.Add(this.lblIP);
            this.gbxExtDevice.Controls.Add(this.tbxPort);
            this.gbxExtDevice.Controls.Add(this.mtbxIP);
            this.gbxExtDevice.Controls.Add(this.btnSetExternalSettings);
            this.gbxExtDevice.Location = new System.Drawing.Point(4, 150);
            this.gbxExtDevice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxExtDevice.Name = "gbxExtDevice";
            this.gbxExtDevice.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxExtDevice.Size = new System.Drawing.Size(400, 68);
            this.gbxExtDevice.TabIndex = 22;
            this.gbxExtDevice.TabStop = false;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(203, 42);
            this.lblPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(32, 13);
            this.lblPort.TabIndex = 13;
            this.lblPort.Text = "Port :";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(203, 20);
            this.lblIP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(23, 13);
            this.lblIP.TabIndex = 12;
            this.lblIP.Text = "IP :";
            // 
            // tbxPort
            // 
            this.tbxPort.Location = new System.Drawing.Point(289, 40);
            this.tbxPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxPort.MaxLength = 5;
            this.tbxPort.Name = "tbxPort";
            this.tbxPort.Size = new System.Drawing.Size(56, 20);
            this.tbxPort.TabIndex = 8;
            this.tbxPort.Text = "4444";
            // 
            // mtbxIP
            // 
            this.mtbxIP.Location = new System.Drawing.Point(262, 17);
            this.mtbxIP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mtbxIP.Mask = "###.###.###.###";
            this.mtbxIP.Name = "mtbxIP";
            this.mtbxIP.PromptChar = ' ';
            this.mtbxIP.Size = new System.Drawing.Size(83, 20);
            this.mtbxIP.TabIndex = 7;
            this.mtbxIP.Text = "192168  0 66";
            // 
            // btnSetExternalSettings
            // 
            this.btnSetExternalSettings.Location = new System.Drawing.Point(4, 25);
            this.btnSetExternalSettings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSetExternalSettings.Name = "btnSetExternalSettings";
            this.btnSetExternalSettings.Size = new System.Drawing.Size(130, 30);
            this.btnSetExternalSettings.TabIndex = 6;
            this.btnSetExternalSettings.Text = "SET EXT DEVICE SETTINGS";
            this.btnSetExternalSettings.UseVisualStyleBackColor = true;
            this.btnSetExternalSettings.Click += new System.EventHandler(this.btnSetExternalSettings_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStartFMTest);
            this.groupBox1.Controls.Add(this.btnCreateDB);
            this.groupBox1.Controls.Add(this.btnCloseFM);
            this.groupBox1.Controls.Add(this.btnFatorySettings);
            this.groupBox1.Controls.Add(this.btnFormatDailyMem);
            this.groupBox1.Controls.Add(this.btnEJInit);
            this.groupBox1.Location = new System.Drawing.Point(410, 92);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(160, 297);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // btnStartFMTest
            // 
            this.btnStartFMTest.Location = new System.Drawing.Point(4, 215);
            this.btnStartFMTest.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStartFMTest.Name = "btnStartFMTest";
            this.btnStartFMTest.Size = new System.Drawing.Size(110, 30);
            this.btnStartFMTest.TabIndex = 10;
            this.btnStartFMTest.Text = "START FM TEST";
            this.btnStartFMTest.UseVisualStyleBackColor = true;
            this.btnStartFMTest.Click += new System.EventHandler(this.btnStartFMTest_Click);
            // 
            // btnCreateDB
            // 
            this.btnCreateDB.Location = new System.Drawing.Point(4, 132);
            this.btnCreateDB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCreateDB.Name = "btnCreateDB";
            this.btnCreateDB.Size = new System.Drawing.Size(110, 30);
            this.btnCreateDB.TabIndex = 9;
            this.btnCreateDB.Text = "CREATE SALE DB";
            this.btnCreateDB.UseVisualStyleBackColor = true;
            this.btnCreateDB.Click += new System.EventHandler(this.btnCreateDB_Click);
            // 
            // btnCloseFM
            // 
            this.btnCloseFM.Location = new System.Drawing.Point(4, 96);
            this.btnCloseFM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCloseFM.Name = "btnCloseFM";
            this.btnCloseFM.Size = new System.Drawing.Size(110, 30);
            this.btnCloseFM.TabIndex = 6;
            this.btnCloseFM.Text = "CLOSE FM";
            this.btnCloseFM.UseVisualStyleBackColor = true;
            this.btnCloseFM.Click += new System.EventHandler(this.btnCloseFM_Click);
            // 
            // btnFatorySettings
            // 
            this.btnFatorySettings.Location = new System.Drawing.Point(4, 54);
            this.btnFatorySettings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFatorySettings.Name = "btnFatorySettings";
            this.btnFatorySettings.Size = new System.Drawing.Size(110, 30);
            this.btnFatorySettings.TabIndex = 7;
            this.btnFatorySettings.Text = "FACTORY SETTINGS";
            this.btnFatorySettings.UseVisualStyleBackColor = true;
            this.btnFatorySettings.Click += new System.EventHandler(this.btnFatorySettings_Click);
            // 
            // btnFormatDailyMem
            // 
            this.btnFormatDailyMem.Location = new System.Drawing.Point(4, 11);
            this.btnFormatDailyMem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFormatDailyMem.Name = "btnFormatDailyMem";
            this.btnFormatDailyMem.Size = new System.Drawing.Size(110, 30);
            this.btnFormatDailyMem.TabIndex = 6;
            this.btnFormatDailyMem.Text = "FORMAT DAILY MEMORY";
            this.btnFormatDailyMem.UseVisualStyleBackColor = true;
            this.btnFormatDailyMem.Click += new System.EventHandler(this.btnFormatDailyMem_Click);
            // 
            // btnEJInit
            // 
            this.btnEJInit.Location = new System.Drawing.Point(4, 173);
            this.btnEJInit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEJInit.Name = "btnEJInit";
            this.btnEJInit.Size = new System.Drawing.Size(110, 30);
            this.btnEJInit.TabIndex = 8;
            this.btnEJInit.Text = "INITIALIZE EJ";
            this.btnEJInit.UseVisualStyleBackColor = true;
            this.btnEJInit.Visible = false;
            this.btnEJInit.Click += new System.EventHandler(this.btnEJInit_Click);
            // 
            // gbxFirmUpdate
            // 
            this.gbxFirmUpdate.Controls.Add(this.btnTestServer);
            this.gbxFirmUpdate.Controls.Add(this.lblServPort);
            this.gbxFirmUpdate.Controls.Add(this.lblServIP);
            this.gbxFirmUpdate.Controls.Add(this.txtServerPort);
            this.gbxFirmUpdate.Controls.Add(this.mtbxServerIp);
            this.gbxFirmUpdate.Controls.Add(this.btnUpdateFirmware);
            this.gbxFirmUpdate.Location = new System.Drawing.Point(4, 216);
            this.gbxFirmUpdate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxFirmUpdate.Name = "gbxFirmUpdate";
            this.gbxFirmUpdate.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxFirmUpdate.Size = new System.Drawing.Size(400, 68);
            this.gbxFirmUpdate.TabIndex = 23;
            this.gbxFirmUpdate.TabStop = false;
            // 
            // btnTestServer
            // 
            this.btnTestServer.Location = new System.Drawing.Point(348, 20);
            this.btnTestServer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTestServer.Name = "btnTestServer";
            this.btnTestServer.Size = new System.Drawing.Size(48, 36);
            this.btnTestServer.TabIndex = 14;
            this.btnTestServer.Text = "Test Server";
            this.btnTestServer.UseVisualStyleBackColor = true;
            this.btnTestServer.Click += new System.EventHandler(this.btnTestServer_Click);
            // 
            // lblServPort
            // 
            this.lblServPort.AutoSize = true;
            this.lblServPort.Location = new System.Drawing.Point(169, 44);
            this.lblServPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblServPort.Name = "lblServPort";
            this.lblServPort.Size = new System.Drawing.Size(66, 13);
            this.lblServPort.TabIndex = 13;
            this.lblServPort.Text = "Server Port :";
            // 
            // lblServIP
            // 
            this.lblServIP.AutoSize = true;
            this.lblServIP.Location = new System.Drawing.Point(169, 20);
            this.lblServIP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblServIP.Name = "lblServIP";
            this.lblServIP.Size = new System.Drawing.Size(57, 13);
            this.lblServIP.TabIndex = 12;
            this.lblServIP.Text = "Server IP :";
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(289, 40);
            this.txtServerPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtServerPort.MaxLength = 5;
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(56, 20);
            this.txtServerPort.TabIndex = 8;
            this.txtServerPort.Text = "5001";
            // 
            // mtbxServerIp
            // 
            this.mtbxServerIp.Location = new System.Drawing.Point(262, 17);
            this.mtbxServerIp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mtbxServerIp.Mask = "###.###.###.###";
            this.mtbxServerIp.Name = "mtbxServerIp";
            this.mtbxServerIp.PromptChar = ' ';
            this.mtbxServerIp.Size = new System.Drawing.Size(83, 20);
            this.mtbxServerIp.TabIndex = 7;
            this.mtbxServerIp.Text = "192168  0 66";
            // 
            // btnUpdateFirmware
            // 
            this.btnUpdateFirmware.Location = new System.Drawing.Point(4, 25);
            this.btnUpdateFirmware.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUpdateFirmware.Name = "btnUpdateFirmware";
            this.btnUpdateFirmware.Size = new System.Drawing.Size(130, 30);
            this.btnUpdateFirmware.TabIndex = 6;
            this.btnUpdateFirmware.Text = "UPDATE FIRMWARE";
            this.btnUpdateFirmware.UseVisualStyleBackColor = true;
            this.btnUpdateFirmware.Click += new System.EventHandler(this.btnUpdateFirmware_Click);
            // 
            // gbxFiscalMode
            // 
            this.gbxFiscalMode.Controls.Add(this.txtPrgmPass);
            this.gbxFiscalMode.Controls.Add(this.lblPrgrmPass);
            this.gbxFiscalMode.Controls.Add(this.btnFiscalMode);
            this.gbxFiscalMode.Location = new System.Drawing.Point(4, 284);
            this.gbxFiscalMode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxFiscalMode.Name = "gbxFiscalMode";
            this.gbxFiscalMode.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxFiscalMode.Size = new System.Drawing.Size(400, 51);
            this.gbxFiscalMode.TabIndex = 24;
            this.gbxFiscalMode.TabStop = false;
            // 
            // txtPrgmPass
            // 
            this.txtPrgmPass.Location = new System.Drawing.Point(216, 20);
            this.txtPrgmPass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPrgmPass.MaxLength = 10;
            this.txtPrgmPass.Name = "txtPrgmPass";
            this.txtPrgmPass.PasswordChar = '*';
            this.txtPrgmPass.Size = new System.Drawing.Size(62, 20);
            this.txtPrgmPass.TabIndex = 14;
            // 
            // lblPrgrmPass
            // 
            this.lblPrgrmPass.AutoSize = true;
            this.lblPrgrmPass.Location = new System.Drawing.Point(136, 23);
            this.lblPrgrmPass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrgrmPass.Name = "lblPrgrmPass";
            this.lblPrgrmPass.Size = new System.Drawing.Size(76, 13);
            this.lblPrgrmPass.TabIndex = 13;
            this.lblPrgrmPass.Text = "PASSWORD :";
            // 
            // btnFiscalMode
            // 
            this.btnFiscalMode.Location = new System.Drawing.Point(6, 15);
            this.btnFiscalMode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFiscalMode.Name = "btnFiscalMode";
            this.btnFiscalMode.Size = new System.Drawing.Size(110, 30);
            this.btnFiscalMode.TabIndex = 7;
            this.btnFiscalMode.Text = "FISCAL MODE NOW";
            this.btnFiscalMode.UseVisualStyleBackColor = true;
            this.btnFiscalMode.Click += new System.EventHandler(this.btnFiscalMode_Click);
            // 
            // tcntService
            // 
            this.tcntService.Controls.Add(this.tabSRVOperation);
            this.tcntService.Controls.Add(this.tabSRVTest);
            this.tcntService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcntService.Location = new System.Drawing.Point(0, 0);
            this.tcntService.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tcntService.Name = "tcntService";
            this.tcntService.SelectedIndex = 0;
            this.tcntService.Size = new System.Drawing.Size(591, 427);
            this.tcntService.TabIndex = 28;
            // 
            // tabSRVTest
            // 
            this.tabSRVTest.Controls.Add(this.gbxTestGmp);
            this.tabSRVTest.Location = new System.Drawing.Point(4, 22);
            this.tabSRVTest.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabSRVTest.Name = "tabSRVTest";
            this.tabSRVTest.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabSRVTest.Size = new System.Drawing.Size(583, 401);
            this.tabSRVTest.TabIndex = 3;
            this.tabSRVTest.Text = "TEST COMMANDS";
            this.tabSRVTest.UseVisualStyleBackColor = true;
            // 
            // gbxTestGmp
            // 
            this.gbxTestGmp.Controls.Add(this.lblTsmIp);
            this.gbxTestGmp.Controls.Add(this.mtbxTSMIp);
            this.gbxTestGmp.Controls.Add(this.lblGMPPort);
            this.gbxTestGmp.Controls.Add(this.txtGMPPort);
            this.gbxTestGmp.Controls.Add(this.btnGMPPort);
            this.gbxTestGmp.Controls.Add(this.cmbGmpCmds);
            this.gbxTestGmp.Controls.Add(this.btnTestGmp);
            this.gbxTestGmp.Location = new System.Drawing.Point(4, 5);
            this.gbxTestGmp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxTestGmp.Name = "gbxTestGmp";
            this.gbxTestGmp.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxTestGmp.Size = new System.Drawing.Size(400, 144);
            this.gbxTestGmp.TabIndex = 20;
            this.gbxTestGmp.TabStop = false;
            this.gbxTestGmp.Text = "GMP Test";
            // 
            // lblTsmIp
            // 
            this.lblTsmIp.AutoSize = true;
            this.lblTsmIp.Location = new System.Drawing.Point(163, 86);
            this.lblTsmIp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTsmIp.Name = "lblTsmIp";
            this.lblTsmIp.Size = new System.Drawing.Size(23, 13);
            this.lblTsmIp.TabIndex = 19;
            this.lblTsmIp.Text = "IP :";
            // 
            // mtbxTSMIp
            // 
            this.mtbxTSMIp.Location = new System.Drawing.Point(221, 84);
            this.mtbxTSMIp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mtbxTSMIp.Mask = "###.###.###.###";
            this.mtbxTSMIp.Name = "mtbxTSMIp";
            this.mtbxTSMIp.PromptChar = ' ';
            this.mtbxTSMIp.Size = new System.Drawing.Size(83, 20);
            this.mtbxTSMIp.TabIndex = 18;
            this.mtbxTSMIp.Text = "192168  0234";
            // 
            // lblGMPPort
            // 
            this.lblGMPPort.AutoSize = true;
            this.lblGMPPort.Location = new System.Drawing.Point(160, 109);
            this.lblGMPPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGMPPort.Name = "lblGMPPort";
            this.lblGMPPort.Size = new System.Drawing.Size(32, 13);
            this.lblGMPPort.TabIndex = 17;
            this.lblGMPPort.Text = "Port :";
            // 
            // txtGMPPort
            // 
            this.txtGMPPort.Location = new System.Drawing.Point(248, 109);
            this.txtGMPPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtGMPPort.MaxLength = 5;
            this.txtGMPPort.Name = "txtGMPPort";
            this.txtGMPPort.Size = new System.Drawing.Size(56, 20);
            this.txtGMPPort.TabIndex = 16;
            this.txtGMPPort.Text = "5059";
            // 
            // btnGMPPort
            // 
            this.btnGMPPort.Location = new System.Drawing.Point(4, 94);
            this.btnGMPPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGMPPort.Name = "btnGMPPort";
            this.btnGMPPort.Size = new System.Drawing.Size(110, 30);
            this.btnGMPPort.TabIndex = 15;
            this.btnGMPPort.Text = "GMP Port";
            this.btnGMPPort.UseVisualStyleBackColor = true;
            this.btnGMPPort.Click += new System.EventHandler(this.btnGMPPort_Click);
            // 
            // cmbGmpCmds
            // 
            this.cmbGmpCmds.FormattingEnabled = true;
            this.cmbGmpCmds.Items.AddRange(new object[] {
            "Debug Modu",
            "First Init",
            "Parametre Yükleme",
            "Log Gönder",
            "Fiş Gönder",
            "İptal Fişi Gönder",
            "Z Gönder",
            "First Init Kontrol Etme",
            "-",
            "Printer Debug Açık",
            "Printer Debug Kapalı",
            "-",
            "-",
            "Logs to tsm"});
            this.cmbGmpCmds.Location = new System.Drawing.Point(170, 39);
            this.cmbGmpCmds.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbGmpCmds.Name = "cmbGmpCmds";
            this.cmbGmpCmds.Size = new System.Drawing.Size(134, 21);
            this.cmbGmpCmds.TabIndex = 14;
            // 
            // btnTestGmp
            // 
            this.btnTestGmp.Location = new System.Drawing.Point(4, 33);
            this.btnTestGmp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTestGmp.Name = "btnTestGmp";
            this.btnTestGmp.Size = new System.Drawing.Size(110, 30);
            this.btnTestGmp.TabIndex = 13;
            this.btnTestGmp.Text = "Test";
            this.btnTestGmp.UseVisualStyleBackColor = true;
            this.btnTestGmp.Click += new System.EventHandler(this.btnTestGmp_Click);
            // 
            // ServiceUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcntService);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ServiceUC";
            this.tabSRVOperation.ResumeLayout(false);
            this.gbxLog.ResumeLayout(false);
            this.gbxServiceMode.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbxDateTime.ResumeLayout(false);
            this.gbxDateTime.PerformLayout();
            this.gbxServiceInOut.ResumeLayout(false);
            this.gbxServiceInOut.PerformLayout();
            this.gbxExtDevice.ResumeLayout(false);
            this.gbxExtDevice.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.gbxFirmUpdate.ResumeLayout(false);
            this.gbxFirmUpdate.PerformLayout();
            this.gbxFiscalMode.ResumeLayout(false);
            this.gbxFiscalMode.PerformLayout();
            this.tcntService.ResumeLayout(false);
            this.tabSRVTest.ResumeLayout(false);
            this.gbxTestGmp.ResumeLayout(false);
            this.gbxTestGmp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion


        private void ParseServiceResponse(CPResponse response)
        {
            try
            {             
                if (response.ErrorCode == 0)
                {
                    string retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        bridge.Log(String.Format("{1} : {0}", retVal, FormMessage.DATE));
                    }

                    retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        bridge.Log(String.Format("{1} : {0}", retVal, FormMessage.TIME));
                    }

                    retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        bridge.Log(String.Format("NOTE : {0}", retVal));
                    }

                    retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        bridge.Log(String.Format("{1} : {0}", retVal, FormMessage.QUANTITY));
                    }

                    retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        bridge.Log(FormMessage.DOCUMENT_ID + " : " + retVal);
                    }

                    retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        bridge.Log("Kod: " + retVal);

                        retVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(retVal))
                        {
                            lblOrderNum.Text = String.Format("{0}", retVal);
                        }
                    }
                    
                }
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void btnEnterService_Click(object sender, EventArgs e)
        {
            // Password
            string password = txtPassword.Text;
            try
            {
                CPResponse response = new CPResponse(bridge.Printer.EnterServiceMode(password));

                ParseServiceResponse(response);
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void btnExitService_Click(object sender, EventArgs e)
        {
            // Password
            string password = txtPassword.Text;
            try
            {
                CPResponse response = new CPResponse(bridge.Printer.ExitServiceMode(password));

                ParseServiceResponse(response);
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }

        }

        private void cbxSetDate_CheckedChanged(object sender, EventArgs e)
        {
            dtFPDate.Enabled = cbxSetDate.Checked;
        }

        private void cbxTime_CheckedChanged(object sender, EventArgs e)
        {
            dtFPTime.Enabled = cbxTime.Checked;
        }

        private void btnFormatDailyMem_Click(object sender, EventArgs e)
        {
            try
            {
                CPResponse response = new CPResponse(bridge.Printer.ClearDailyMemory());

                ParseServiceResponse(response);
            }
            catch (System.Exception ex)
            {

            }

        }

        private void btnSetDateTime_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.MinValue;
            DateTime time = DateTime.MinValue;
            if (cbxSetDate.Checked)
            {
                //Receipt Date
                date = dtFPDate.Value;
            }

            if (cbxTime.Checked)
            {
                //Receipt Time
                time = dtFPTime.Value;
            }
            try
            {
                CPResponse response = new CPResponse(bridge.Printer.SetDateTime(date, time));

                ParseServiceResponse(response);
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void btnFatorySettings_Click(object sender, EventArgs e)
        {
            try
            {            
                CPResponse response = new CPResponse(bridge.Printer.FactorySettings());
                ParseServiceResponse(response);

            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void btnCloseFM_Click(object sender, EventArgs e)
        {
            try
            {
                CPResponse response = new CPResponse(bridge.Printer.CloseFM());
                ParseServiceResponse(response);
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void btnSetExternalSettings_Click(object sender, EventArgs e)
        {
            try
            {
                List<byte> bytes = new List<byte>();

                // IP Address
                string ip = mtbxIP.Text;

                int port = -1;
                if (!String.IsNullOrEmpty(tbxPort.Text))
                {
                    // Port
                    port = Convert.ToInt32(tbxPort.Text);
                }

                CPResponse response = new CPResponse(bridge.Printer.SetExternalDevAddress(ip, port));
                ParseServiceResponse(response);
            }
            catch(Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
        }

        private void btnUpdateFirmware_Click(object sender, EventArgs e)
        {

            try
            {
                // IP Address
                string ip = mtbxServerIp.Text;

                int port = -1;
                if (!String.IsNullOrEmpty(txtServerPort.Text))
                {
                    // Port
                    port = Convert.ToInt32(txtServerPort.Text);
                }

                CPResponse response = new CPResponse(bridge.Printer.UpdateFirmware(ip, port));
                ParseServiceResponse(response);
            }
            catch (Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
        }

        TestServer server = null;
        private void btnTestServer_Click(object sender, EventArgs e)
        {
            server = new TestServer();
            server.IpAddress = mtbxServerIp.Text;
            server.Port = Convert.ToInt32(txtServerPort.Text);
            server.Show(this);
            //StartTestServer(mtbxServerIp.Text, Convert.ToInt32(txtServerPort.Text));
        }

        private void btnOrderNum_Click(object sender, EventArgs e)
        {
            try
            {
                CPResponse response = new CPResponse(bridge.Printer.GetServiceCode());
                ParseServiceResponse(response);
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void btnFiscalMode_Click(object sender, EventArgs e)
        {
            // Password
            string password = txtPrgmPass.Text;

            bridge.Connection.FPUTimeout = ProgramConfig.FPU_SRV_TIMEOUT;
            CPResponse response = new CPResponse(bridge.Printer.Fiscalize(password));
            ParseServiceResponse(response);
            bridge.Connection.FPUTimeout = ProgramConfig.FPU_CMD_TIMEOUT;
        }

        private void btnEJInit_Click(object sender, EventArgs e)
        {
            bridge.Connection.FPUTimeout = ProgramConfig.FPU_START_FM_TIMEOUT;
            CPResponse response = new CPResponse(bridge.Printer.StartEJ());
            ParseServiceResponse(response);
            bridge.Connection.FPUTimeout = ProgramConfig.FPU_CMD_TIMEOUT;
        }

        private void btnPrintLogs_Click(object sender, EventArgs e)
        {
            bridge.Connection.FPUTimeout = ProgramConfig.FPU_SRV_TIMEOUT;
            CPResponse response = new CPResponse(bridge.Printer.PrintLogs(dtpLog.Value));
            ParseServiceResponse(response);
            bridge.Connection.FPUTimeout = ProgramConfig.FPU_CMD_TIMEOUT;
        }

        private void btnCreateDB_Click(object sender, EventArgs e)
        {
            bridge.Connection.FPUTimeout = ProgramConfig.FPU_SRV_TIMEOUT;
            CPResponse response = new CPResponse(bridge.Printer.CreateDB());
            ParseServiceResponse(response);
            bridge.Connection.FPUTimeout = ProgramConfig.FPU_CMD_TIMEOUT;
        }



        private void btnStartFMTest_Click(object sender, EventArgs e)
        {
            CPResponse response = new CPResponse(bridge.Printer.StartFMTest());
            ParseServiceResponse(response);
        }
        private void btnxFer_Click(object sender, EventArgs e)
        {
            try
            {
                // SEND COMMAND
                CPResponse response = new CPResponse(bridge.Printer.TransferFile(txtFileName.Text));

                if (response.ErrorCode == 0)
                {
                    ParseServiceResponse(response);
                }
            }
            catch
            {

            }
        }

#region COMMON
        private Control GetControlByName(string name)
        {
            return this.Controls.Find(name, true)[0];
        }
#endregion

#region TEST COMMANDS
        private void btnTestGmp_Click(object sender, EventArgs e)
        {
            int index = cmbGmpCmds.SelectedIndex;

            CPResponse response = new CPResponse(bridge.Printer.SetEJLimit(index));
            ParseServiceResponse(response);
        }

        private void btnGMPPort_Click(object sender, EventArgs e)
        {
            // IP Address
            string[] spltIPAddrs = mtbxTSMIp.Text.Split(new char[] { ',' });
            string ipVal = "";
            try
            {
                for (int i = 0; i < spltIPAddrs.Length; i++)
                {
                    ipVal += int.Parse(spltIPAddrs[i]).ToString().PadLeft(3, '0');
                }
            }
            catch (System.Exception ex)
            {
            	
            }
            // Port
            int port = Convert.ToInt32(txtGMPPort.Text);

            bridge.Connection.FPUTimeout = ProgramConfig.FPU_SRV_TIMEOUT;
            CPResponse response = new CPResponse(bridge.Printer.SaveGMPConnectionInfo(ipVal, port));
            ParseServiceResponse(response);
            bridge.Connection.FPUTimeout = ProgramConfig.FPU_CMD_TIMEOUT;
        }

#endregion TEST COMMANDS

    }
}
