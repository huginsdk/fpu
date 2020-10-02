using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace FP300Service.UserControls
{
    enum FiscalCmd
    {
        LAST_Z_INFO,
        LAST_RECEIPT_INFO,
        DRAWER_INFO
    }

    enum CollectType
    {
        CASH_IN = 1,
        CASH_OUT
    }
    public class FiscalInfoUC : TestUC
    {
        public FiscalInfoUC()
            :base()
        {
            InitializeComponent();

            SetLanguageOption();
        }

        private void SetLanguageOption()
        {
            this.gbxStatusFuncs.Text = FormMessage.FISCAL_RECEIPT_INFO;
            this.btnDrawerInfo.Text = FormMessage.DRAWER_INFO;
            this.btnLastReceiptInfo.Text = FormMessage.LAST_RECEIPT_INFO;
            this.btnLastZInfo.Text = FormMessage.LAST_Z_REPORT_INFO;
            this.gbcEjLimit.Text = FormMessage.EJ_LIMIT;
            this.lblEjLimit.Text = FormMessage.LINE_COUNT + ":";
            this.btnSetEjLimit.Text = FormMessage.SET_EJ_LIMIT;

            this.groupBoxVersiyonInfo.Text = FormMessage.GROUP_VERSION_INFO;
            this.btnGetECRVersion.Text = FormMessage.ECR_VERSION_INFO;
            this.btnLibraryVersion.Text = FormMessage.LIBRARY_VERSION_INFO;

            this.groupBoxOther.Text = FormMessage.GROUP_OTHER;
            this.btnDailySummary.Text = FormMessage.DAILY_SUMMARY;
        }


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbcEjLimit = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelEJLimit = new System.Windows.Forms.TableLayoutPanel();
            this.btnSetEjLimit = new System.Windows.Forms.Button();
            this.nmrEjLine = new System.Windows.Forms.NumericUpDown();
            this.lblEjLimit = new System.Windows.Forms.Label();
            this.gbxStatusFuncs = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelFiscalRcptInfo = new System.Windows.Forms.TableLayoutPanel();
            this.btnDrawerInfo = new System.Windows.Forms.Button();
            this.btnLastZInfo = new System.Windows.Forms.Button();
            this.btnLastReceiptInfo = new System.Windows.Forms.Button();
            this.tableLayoutPanelFiscalInfoUC = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxOther = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelOther = new System.Windows.Forms.TableLayoutPanel();
            this.btnLibraryVersion = new System.Windows.Forms.Button();
            this.groupBoxVersiyonInfo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelVersiyonInfo = new System.Windows.Forms.TableLayoutPanel();
            this.btnGetECRVersion = new System.Windows.Forms.Button();
            this.btnDailySummary = new System.Windows.Forms.Button();
            this.gbcEjLimit.SuspendLayout();
            this.tableLayoutPanelEJLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrEjLine)).BeginInit();
            this.gbxStatusFuncs.SuspendLayout();
            this.tableLayoutPanelFiscalRcptInfo.SuspendLayout();
            this.tableLayoutPanelFiscalInfoUC.SuspendLayout();
            this.groupBoxOther.SuspendLayout();
            this.tableLayoutPanelOther.SuspendLayout();
            this.groupBoxVersiyonInfo.SuspendLayout();
            this.tableLayoutPanelVersiyonInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbcEjLimit
            // 
            this.gbcEjLimit.Controls.Add(this.tableLayoutPanelEJLimit);
            this.gbcEjLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbcEjLimit.Location = new System.Drawing.Point(2, 108);
            this.gbcEjLimit.Margin = new System.Windows.Forms.Padding(2);
            this.gbcEjLimit.Name = "gbcEjLimit";
            this.gbcEjLimit.Padding = new System.Windows.Forms.Padding(2);
            this.gbcEjLimit.Size = new System.Drawing.Size(388, 102);
            this.gbcEjLimit.TabIndex = 20;
            this.gbcEjLimit.TabStop = false;
            this.gbcEjLimit.Text = "EKÜ Limit";
            // 
            // tableLayoutPanelEJLimit
            // 
            this.tableLayoutPanelEJLimit.ColumnCount = 3;
            this.tableLayoutPanelEJLimit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanelEJLimit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanelEJLimit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanelEJLimit.Controls.Add(this.btnSetEjLimit, 0, 0);
            this.tableLayoutPanelEJLimit.Controls.Add(this.nmrEjLine, 2, 0);
            this.tableLayoutPanelEJLimit.Controls.Add(this.lblEjLimit, 1, 0);
            this.tableLayoutPanelEJLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelEJLimit.Location = new System.Drawing.Point(2, 15);
            this.tableLayoutPanelEJLimit.Name = "tableLayoutPanelEJLimit";
            this.tableLayoutPanelEJLimit.RowCount = 1;
            this.tableLayoutPanelEJLimit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelEJLimit.Size = new System.Drawing.Size(384, 85);
            this.tableLayoutPanelEJLimit.TabIndex = 0;
            // 
            // btnSetEjLimit
            // 
            this.btnSetEjLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetEjLimit.Location = new System.Drawing.Point(2, 2);
            this.btnSetEjLimit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetEjLimit.Name = "btnSetEjLimit";
            this.btnSetEjLimit.Size = new System.Drawing.Size(122, 81);
            this.btnSetEjLimit.TabIndex = 6;
            this.btnSetEjLimit.Text = "EKÜ Limit Ekle";
            this.btnSetEjLimit.UseVisualStyleBackColor = true;
            this.btnSetEjLimit.Click += new System.EventHandler(this.btnSetEjLimit_Click);
            // 
            // nmrEjLine
            // 
            this.nmrEjLine.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nmrEjLine.Location = new System.Drawing.Point(278, 32);
            this.nmrEjLine.Margin = new System.Windows.Forms.Padding(2);
            this.nmrEjLine.Maximum = new decimal(new int[] {
            40000000,
            0,
            0,
            0});
            this.nmrEjLine.Name = "nmrEjLine";
            this.nmrEjLine.Size = new System.Drawing.Size(79, 20);
            this.nmrEjLine.TabIndex = 15;
            this.nmrEjLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrEjLine.UseWaitCursor = true;
            this.nmrEjLine.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblEjLimit
            // 
            this.lblEjLimit.AutoSize = true;
            this.lblEjLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEjLimit.Location = new System.Drawing.Point(128, 0);
            this.lblEjLimit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEjLimit.Name = "lblEjLimit";
            this.lblEjLimit.Size = new System.Drawing.Size(122, 85);
            this.lblEjLimit.TabIndex = 16;
            this.lblEjLimit.Text = "Satır Sayısı:";
            this.lblEjLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxStatusFuncs
            // 
            this.gbxStatusFuncs.Controls.Add(this.tableLayoutPanelFiscalRcptInfo);
            this.gbxStatusFuncs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxStatusFuncs.Location = new System.Drawing.Point(2, 2);
            this.gbxStatusFuncs.Margin = new System.Windows.Forms.Padding(2);
            this.gbxStatusFuncs.Name = "gbxStatusFuncs";
            this.gbxStatusFuncs.Padding = new System.Windows.Forms.Padding(2);
            this.gbxStatusFuncs.Size = new System.Drawing.Size(388, 102);
            this.gbxStatusFuncs.TabIndex = 19;
            this.gbxStatusFuncs.TabStop = false;
            this.gbxStatusFuncs.Text = "Mali Fiş Bilgileri";
            // 
            // tableLayoutPanelFiscalRcptInfo
            // 
            this.tableLayoutPanelFiscalRcptInfo.ColumnCount = 3;
            this.tableLayoutPanelFiscalRcptInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanelFiscalRcptInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanelFiscalRcptInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanelFiscalRcptInfo.Controls.Add(this.btnDrawerInfo, 2, 0);
            this.tableLayoutPanelFiscalRcptInfo.Controls.Add(this.btnLastZInfo, 0, 0);
            this.tableLayoutPanelFiscalRcptInfo.Controls.Add(this.btnLastReceiptInfo, 1, 0);
            this.tableLayoutPanelFiscalRcptInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFiscalRcptInfo.Location = new System.Drawing.Point(2, 15);
            this.tableLayoutPanelFiscalRcptInfo.Name = "tableLayoutPanelFiscalRcptInfo";
            this.tableLayoutPanelFiscalRcptInfo.RowCount = 1;
            this.tableLayoutPanelFiscalRcptInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFiscalRcptInfo.Size = new System.Drawing.Size(384, 85);
            this.tableLayoutPanelFiscalRcptInfo.TabIndex = 0;
            // 
            // btnDrawerInfo
            // 
            this.btnDrawerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDrawerInfo.Location = new System.Drawing.Point(254, 2);
            this.btnDrawerInfo.Margin = new System.Windows.Forms.Padding(2);
            this.btnDrawerInfo.Name = "btnDrawerInfo";
            this.btnDrawerInfo.Size = new System.Drawing.Size(128, 81);
            this.btnDrawerInfo.TabIndex = 8;
            this.btnDrawerInfo.Text = "Çekmece Bilgileri";
            this.btnDrawerInfo.UseVisualStyleBackColor = true;
            this.btnDrawerInfo.Click += new System.EventHandler(this.btnDrawerInfo_Click);
            // 
            // btnLastZInfo
            // 
            this.btnLastZInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLastZInfo.Location = new System.Drawing.Point(2, 2);
            this.btnLastZInfo.Margin = new System.Windows.Forms.Padding(2);
            this.btnLastZInfo.Name = "btnLastZInfo";
            this.btnLastZInfo.Size = new System.Drawing.Size(122, 81);
            this.btnLastZInfo.TabIndex = 6;
            this.btnLastZInfo.Text = "Son Z Bilgisi";
            this.btnLastZInfo.UseVisualStyleBackColor = true;
            this.btnLastZInfo.Click += new System.EventHandler(this.btnLastZInfo_Click);
            // 
            // btnLastReceiptInfo
            // 
            this.btnLastReceiptInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLastReceiptInfo.Location = new System.Drawing.Point(128, 2);
            this.btnLastReceiptInfo.Margin = new System.Windows.Forms.Padding(2);
            this.btnLastReceiptInfo.Name = "btnLastReceiptInfo";
            this.btnLastReceiptInfo.Size = new System.Drawing.Size(122, 81);
            this.btnLastReceiptInfo.TabIndex = 7;
            this.btnLastReceiptInfo.Text = "Son Fiş Bilgisi";
            this.btnLastReceiptInfo.UseVisualStyleBackColor = true;
            this.btnLastReceiptInfo.Click += new System.EventHandler(this.btnLastReceiptInfo_Click);
            // 
            // btnDailySummary
            // 
            this.btnDailySummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDailySummary.Location = new System.Drawing.Point(128, 2);
            this.btnDailySummary.Margin = new System.Windows.Forms.Padding(2);
            this.btnDailySummary.Name = "btnDailySummary";
            this.btnDailySummary.Size = new System.Drawing.Size(122, 81);
            this.btnDailySummary.TabIndex = 7;
            this.btnDailySummary.Text = "Günlük Özet";
            this.btnDailySummary.UseVisualStyleBackColor = true;
            this.btnDailySummary.Click += new System.EventHandler(this.btnDailySummary_Click);

            // 
            // tableLayoutPanelFiscalInfoUC
            // 
            this.tableLayoutPanelFiscalInfoUC.ColumnCount = 2;
            this.tableLayoutPanelFiscalInfoUC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.49746F));
            this.tableLayoutPanelFiscalInfoUC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.50254F));
            this.tableLayoutPanelFiscalInfoUC.Controls.Add(this.groupBoxOther, 0, 3);
            this.tableLayoutPanelFiscalInfoUC.Controls.Add(this.gbxStatusFuncs, 0, 0);
            this.tableLayoutPanelFiscalInfoUC.Controls.Add(this.gbcEjLimit, 0, 1);
            this.tableLayoutPanelFiscalInfoUC.Controls.Add(this.groupBoxVersiyonInfo, 0, 2);
            this.tableLayoutPanelFiscalInfoUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFiscalInfoUC.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelFiscalInfoUC.Name = "tableLayoutPanelFiscalInfoUC";
            this.tableLayoutPanelFiscalInfoUC.RowCount = 4;
            this.tableLayoutPanelFiscalInfoUC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelFiscalInfoUC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelFiscalInfoUC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelFiscalInfoUC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelFiscalInfoUC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelFiscalInfoUC.Size = new System.Drawing.Size(591, 427);
            this.tableLayoutPanelFiscalInfoUC.TabIndex = 21;
            // 
            // groupBoxOther
            // 
            this.groupBoxOther.Controls.Add(this.tableLayoutPanelOther);
            this.groupBoxOther.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxOther.Location = new System.Drawing.Point(3, 321);
            this.groupBoxOther.Name = "groupBoxLibraryInfo";
            this.groupBoxOther.Size = new System.Drawing.Size(386, 103);
            this.groupBoxOther.TabIndex = 22;
            this.groupBoxOther.TabStop = false;
            this.groupBoxOther.Text = "Diğer İşlemler";
            // 
            // tableLayoutPanelOther
            // 
            this.tableLayoutPanelOther.ColumnCount = 3;
            this.tableLayoutPanelOther.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanelOther.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanelOther.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanelOther.Controls.Add(this.btnDailySummary, 0, 0);
            this.tableLayoutPanelOther.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelOther.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelOther.Name = "tableLayoutPanelOther";
            this.tableLayoutPanelOther.RowCount = 1;
            this.tableLayoutPanelOther.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelOther.Size = new System.Drawing.Size(380, 84);
            this.tableLayoutPanelOther.TabIndex = 0;
            // 
            // btnLibraryVersion
            // 
            this.btnLibraryVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLibraryVersion.Location = new System.Drawing.Point(3, 3);
            this.btnLibraryVersion.Name = "btnLibraryVersion";
            this.btnLibraryVersion.Size = new System.Drawing.Size(119, 78);
            this.btnLibraryVersion.TabIndex = 0;
            this.btnLibraryVersion.Text = "Kütüphane Versiyonu";
            this.btnLibraryVersion.UseVisualStyleBackColor = true;
            this.btnLibraryVersion.Click += new System.EventHandler(this.btnLibraryVersion_Click);
            // 
            // groupBoxVersiyonInfo
            // 
            this.groupBoxVersiyonInfo.Controls.Add(this.tableLayoutPanelVersiyonInfo);
            this.groupBoxVersiyonInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxVersiyonInfo.Location = new System.Drawing.Point(3, 215);
            this.groupBoxVersiyonInfo.Name = "groupBoxECRInfo";
            this.groupBoxVersiyonInfo.Size = new System.Drawing.Size(386, 100);
            this.groupBoxVersiyonInfo.TabIndex = 21;
            this.groupBoxVersiyonInfo.TabStop = false;
            this.groupBoxVersiyonInfo.Text = "Versiyon Bilgileri";
            // 
            // tableLayoutPanelVersiyonInfo
            // 
            this.tableLayoutPanelVersiyonInfo.ColumnCount = 3;
            this.tableLayoutPanelVersiyonInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanelVersiyonInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanelVersiyonInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanelVersiyonInfo.Controls.Add(this.btnGetECRVersion, 0, 0);
            this.tableLayoutPanelVersiyonInfo.Controls.Add(this.btnLibraryVersion, 0, 0);
            this.tableLayoutPanelVersiyonInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelVersiyonInfo.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelVersiyonInfo.Name = "tableLayoutPanelVersiyonInfo";
            this.tableLayoutPanelVersiyonInfo.RowCount = 1;
            this.tableLayoutPanelVersiyonInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelVersiyonInfo.Size = new System.Drawing.Size(380, 81);
            this.tableLayoutPanelVersiyonInfo.TabIndex = 0;
            // 
            // btnGetECRVersion
            // 
            this.btnGetECRVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetECRVersion.Location = new System.Drawing.Point(3, 3);
            this.btnGetECRVersion.Name = "btnGetECRVersion";
            this.btnGetECRVersion.Size = new System.Drawing.Size(119, 75);
            this.btnGetECRVersion.TabIndex = 0;
            this.btnGetECRVersion.Text = "Mali Uygulama Versiyonu";
            this.btnGetECRVersion.UseVisualStyleBackColor = true;
            this.btnGetECRVersion.Click += new System.EventHandler(this.btnGetECRVersion_Click);
            // 
            // FiscalInfoUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelFiscalInfoUC);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FiscalInfoUC";
            this.gbcEjLimit.ResumeLayout(false);
            this.tableLayoutPanelEJLimit.ResumeLayout(false);
            this.tableLayoutPanelEJLimit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrEjLine)).EndInit();
            this.gbxStatusFuncs.ResumeLayout(false);
            this.tableLayoutPanelFiscalRcptInfo.ResumeLayout(false);
            this.tableLayoutPanelFiscalInfoUC.ResumeLayout(false);
            this.groupBoxOther.ResumeLayout(false);
            this.tableLayoutPanelOther.ResumeLayout(false);
            this.groupBoxVersiyonInfo.ResumeLayout(false);
            this.tableLayoutPanelVersiyonInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxStatusFuncs;
        private System.Windows.Forms.Button btnDrawerInfo;
        private System.Windows.Forms.Button btnLastReceiptInfo;
        private System.Windows.Forms.Button btnLastZInfo;
        private static TestUC statusForm = null;
        private GroupBox gbcEjLimit;
        private Button btnSetEjLimit;
        private Label lblEjLimit;
        private NumericUpDown nmrEjLine;
        private static IBridge bridge = null;
        private TableLayoutPanel tableLayoutPanelEJLimit;
        private TableLayoutPanel tableLayoutPanelFiscalRcptInfo;
        private TableLayoutPanel tableLayoutPanelFiscalInfoUC;

        private GroupBox groupBoxVersiyonInfo;
        private TableLayoutPanel tableLayoutPanelVersiyonInfo;
        private Button btnGetECRVersion;
        private Button btnLibraryVersion;

        private GroupBox groupBoxOther;
        private TableLayoutPanel tableLayoutPanelOther;
        private Button btnDailySummary;

        private static FiscalCmd lastCmd;
        
        internal static TestUC Instance(IBridge iBridge)
        {
            if (statusForm == null)
            {
                statusForm = new FiscalInfoUC();
                bridge = iBridge;
            }
            return statusForm;
        }

        private void testPeriodic()
        {
            DateTime dateStart = DateTime.Now;
            DateTime dateLastReceipt = DateTime.Now;
            int counter = 0;
            int errorCount = 0;
            while (true)
            {
                try
                {
                    DateTime dateNow = DateTime.Now;
                    if ((dateNow - dateStart).Seconds > 5 * 60)
                    {
                        break;
                    }
                    if ((dateNow - dateLastReceipt).Seconds > 50)
                    {
                        CPResponse response = new CPResponse(bridge.Printer.PrintDocumentHeader());

                        response = new CPResponse(bridge.Printer.PrintDepartment(1, Decimal.Parse("2,831"), Decimal.Parse("1,28"), "DEPARTSMPLE", 1));
                        response = new CPResponse(bridge.Printer.PrintPayment(1, 0, 5));

                        response = new CPResponse(bridge.Printer.CloseReceipt(false));
                        dateLastReceipt = dateNow;
                    }
                    else
                    {
                        CPResponse response = new CPResponse(bridge.Printer.CheckPrinterStatus());
                        counter++;
                        if (counter % 20 == 19)
                        {
                            response = new CPResponse(bridge.Printer.GetLastDocumentInfo(true));
                        }
                    }
                    if (!System.IO.File.Exists("periodicStatus.test"))
                    {
                        break;
                    }
                    System.Threading.Thread.Sleep(1000);
                }catch(Exception ex)
                {
                    errorCount++;
                }
            }
        }
        private void btnLastZInfo_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("periodicStatus.test"))
            {
                testPeriodic();
            }
            lastCmd = FiscalCmd.LAST_Z_INFO;

            try
            {
                SendCommand(new CPResponse(bridge.Printer.GetLastDocumentInfo(true)));
            }
            catch
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void btnLastReceiptInfo_Click(object sender, EventArgs e)
        {
            lastCmd = FiscalCmd.LAST_RECEIPT_INFO;
            try
            {
                SendCommand(new CPResponse(bridge.Printer.GetLastDocumentInfo(false)));
            }
            catch
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void btnDrawerInfo_Click(object sender, EventArgs e)
        {
            lastCmd = FiscalCmd.DRAWER_INFO;
            try
            {
                SendCommand(new CPResponse(bridge.Printer.GetDrawerInfo()));
            }
            catch
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void SendCommand(CPResponse response)
        {
            try
            {   
                if (response.ErrorCode == 0 && response.ParamList != null)
                {                    
                    string paramVal = "";

                    if (lastCmd != FiscalCmd.DRAWER_INFO)
                    {
                        paramVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(paramVal))
                        {
                            bridge.Log(FormMessage.DOCUMENT_ID.PadLeft(12, ' ') + ": " + paramVal);
                        }
                        paramVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(paramVal))
                        {
                            bridge.Log(FormMessage.Z_ID.PadLeft(12, ' ') + ": " + paramVal);
                        }
                        paramVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(paramVal))
                        {
                            bridge.Log(FormMessage.EJ_ID.PadLeft(12, ' ') + ": " + paramVal);
                        }
                        paramVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(paramVal))
                        {
                            bridge.Log(FormMessage.DOCUMENT_TYPE.PadLeft(12, ' ') + ": " + paramVal);
                        }
                        paramVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(paramVal))
                        {
                            bridge.Log(String.Format(FormMessage.DATE.PadLeft(12, ' ') + ": {0}", paramVal));
                        }

                        paramVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(paramVal))
                        {
                            bridge.Log(String.Format(FormMessage.TIME.PadLeft(12, ' ') + ": {0}", paramVal));
                        }
                    }
                    // TOPLAM BİLGİLERİ                   
                    paramVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(paramVal))
                    {
                        bridge.Log("--- "+FormMessage.TOTAL_INFO+" ---");
                        bridge.Log(String.Format(FormMessage.TOTAL_RECEIPT_COUNT + ": {0}", paramVal));
                    }
                    paramVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(paramVal))
                    {
                        bridge.Log(String.Format(FormMessage.TOTAL_AMOUNT + ": {0}", paramVal));
                    }
                    
                    // SATIŞ BİLGİLERİ                          
                    paramVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(paramVal))
                    {
                        bridge.Log("--- "+FormMessage.SALE_INFO+" ---");
                        bridge.Log(String.Format(FormMessage.TOTAL_SALE_RECEIPT_COUNT + ": {0}", paramVal));
                    }
                    paramVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(paramVal))
                    {
                        bridge.Log(String.Format(FormMessage.TOTAL_SALE_AMOUNT + ": {0}", paramVal));
                    }
                     
                    // İPTAL BİLGİLERİ                   
                    paramVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(paramVal))
                    {
                        bridge.Log("--- "+FormMessage.VOID_INFO+" ---");
                        bridge.Log(String.Format(FormMessage.TOTAL_VOID_RECEIPT_COUNT + ": {0}", paramVal));
                    }
                    paramVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(paramVal))
                    {
                        bridge.Log(String.Format(FormMessage.TOTAL_VOID_AMOUNT + ": {0}", paramVal));
                    }

                    // İNDİRİM BİLGİLERİ                 
                    paramVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(paramVal))
                    {
                        bridge.Log("--- "+FormMessage.ADJUSTMENT_INFO+" ---");
                        bridge.Log(String.Format(FormMessage.TOTAL_ADJUSTED_AMOUNT + ": {0}", paramVal));
                    }

                    // ÇEKMECE GİRİŞ BİLGİLERİ
                    bridge.Log("--- " + FormMessage.CASH_IN + " ---");                   
                    {
                        paramVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(paramVal))
                        {
                            int paymentType = int.Parse(paramVal);
                            bridge.Log(String.Format(FormMessage.COLLECT_TYPE.PadLeft(15, ' ') + ": {0}", Common.CollectTypes[paymentType-1]));
                        }
                        paramVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(paramVal))
                        {
                            bridge.Log(String.Format(FormMessage.COLLECT_QUANTITY.PadLeft(15, ' ') + ": {0}", paramVal));
                        }
                        paramVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(paramVal))
                        {
                            bridge.Log(String.Format(FormMessage.COLLECT_AMOUNT.PadLeft(15, ' ') + ": {0}", paramVal));
                        }
                    }

                    // ÇEKMECE ÇIKIŞ BİLGİLERİ
                    bridge.Log("--- " + FormMessage.CASH_OUT + " ---");
                    {
                        paramVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(paramVal))
                        {
                            int paymentType = int.Parse(paramVal);
                            bridge.Log(String.Format(FormMessage.COLLECT_TYPE.PadLeft(15, ' ') + ": {0}", Common.CollectTypes[paymentType - 1]));
                        }
                        paramVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(paramVal))
                        {
                            bridge.Log(String.Format(FormMessage.COLLECT_QUANTITY.PadLeft(15, ' ') + ": {0}", paramVal));
                        }
                        paramVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(paramVal))
                        {
                            bridge.Log(String.Format(FormMessage.COLLECT_AMOUNT.PadLeft(15, ' ') + ": {0}", paramVal));
                        }
                    }

                    // ÖDEME BİLGİLERİ 
                    bridge.Log("--- "+FormMessage.PAYMENT_INFO+" ---");
                    int i = 0;
                    while (response.CurrentParamIndex < response.ParamList.Count)
                    {
                        i++;
                        bridge.Log("** " + FormMessage.PAYMENT + " " + i + " **");
                        paramVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(paramVal))
                        {                      
                            int paymentType = int.Parse(paramVal);
                            bridge.Log(String.Format(FormMessage.PAYMENT_TYPE.PadLeft(15, ' ') + ": {0}", Common.Payments[paymentType]));
                        }
                        paramVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(paramVal))
                        {
                            bridge.Log(String.Format(FormMessage.PAYMENT_INDEX.PadLeft(15, ' ') + ": {0}", paramVal));
                        }
                        paramVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(paramVal))
                        {
                            bridge.Log(String.Format(FormMessage.PAYMENT_AMOUNT.PadLeft(15, ' ') + ": {0}", paramVal));
                        }
                    }             
                }
            }
            catch (Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
        }

        private void btnSetEjLimit_Click(object sender, EventArgs e)
        {
            SendCommand(new CPResponse(bridge.Printer.SetEJLimit((int)nmrEjLine.Value)));
        }

        private void btnGetECRVersion_Click(object sender, EventArgs e)
        {
            try
            {
                string version = bridge.Printer.GetECRVersion();

                bridge.Log("***************************************************" + Environment.NewLine);
                bridge.Log(String.Format(FormMessage.ECR_VERSION_INFO + ": {0}", version));
            }
            catch(Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
        }

        private void btnLibraryVersion_Click(object sender, EventArgs e)
        {
            try
            {
                string version = bridge.Printer.LibraryVersion;

                bridge.Log("***************************************************" + Environment.NewLine);
                bridge.Log(String.Format(FormMessage.ECR_VERSION_INFO + ": {0}", version));
            }
            catch (Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
        }

        private void btnDailySummary_Click(object sender, EventArgs e)
        {
            try
            {
                string strJsonDailySummary = bridge.Printer.GetDailySummary();

                bridge.Log("***************************************************" + Environment.NewLine);
                bridge.Log(FormMessage.DAILY_SUMMARY + ":" + Environment.NewLine);
                bridge.Log(strJsonDailySummary + Environment.NewLine);
            }
            catch (Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
        }
    }
}

