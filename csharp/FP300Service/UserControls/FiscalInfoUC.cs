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
            this.gbcEjLimit.SuspendLayout();
            this.tableLayoutPanelEJLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrEjLine)).BeginInit();
            this.gbxStatusFuncs.SuspendLayout();
            this.tableLayoutPanelFiscalRcptInfo.SuspendLayout();
            this.tableLayoutPanelFiscalInfoUC.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbcEjLimit
            // 
            this.gbcEjLimit.Controls.Add(this.tableLayoutPanelEJLimit);
            this.gbcEjLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbcEjLimit.Location = new System.Drawing.Point(2, 90);
            this.gbcEjLimit.Margin = new System.Windows.Forms.Padding(2);
            this.gbcEjLimit.Name = "gbcEjLimit";
            this.gbcEjLimit.Padding = new System.Windows.Forms.Padding(2);
            this.gbcEjLimit.Size = new System.Drawing.Size(352, 71);
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
            this.tableLayoutPanelEJLimit.Size = new System.Drawing.Size(348, 54);
            this.tableLayoutPanelEJLimit.TabIndex = 0;
            // 
            // btnSetEjLimit
            // 
            this.btnSetEjLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetEjLimit.Location = new System.Drawing.Point(2, 2);
            this.btnSetEjLimit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetEjLimit.Name = "btnSetEjLimit";
            this.btnSetEjLimit.Size = new System.Drawing.Size(110, 50);
            this.btnSetEjLimit.TabIndex = 6;
            this.btnSetEjLimit.Text = "EKÜ Limit Ekle";
            this.btnSetEjLimit.UseVisualStyleBackColor = true;
            this.btnSetEjLimit.Click += new System.EventHandler(this.btnSetEjLimit_Click);
            // 
            // nmrEjLine
            // 
            this.nmrEjLine.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nmrEjLine.Location = new System.Drawing.Point(248, 17);
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
            this.lblEjLimit.Location = new System.Drawing.Point(116, 0);
            this.lblEjLimit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEjLimit.Name = "lblEjLimit";
            this.lblEjLimit.Size = new System.Drawing.Size(110, 54);
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
            this.gbxStatusFuncs.Size = new System.Drawing.Size(352, 84);
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
            this.tableLayoutPanelFiscalRcptInfo.Size = new System.Drawing.Size(348, 67);
            this.tableLayoutPanelFiscalRcptInfo.TabIndex = 0;
            // 
            // btnDrawerInfo
            // 
            this.btnDrawerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDrawerInfo.Location = new System.Drawing.Point(230, 2);
            this.btnDrawerInfo.Margin = new System.Windows.Forms.Padding(2);
            this.btnDrawerInfo.Name = "btnDrawerInfo";
            this.btnDrawerInfo.Size = new System.Drawing.Size(116, 63);
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
            this.btnLastZInfo.Size = new System.Drawing.Size(110, 63);
            this.btnLastZInfo.TabIndex = 6;
            this.btnLastZInfo.Text = "Son Z Bilgisi";
            this.btnLastZInfo.UseVisualStyleBackColor = true;
            this.btnLastZInfo.Click += new System.EventHandler(this.btnLastZInfo_Click);
            // 
            // btnLastReceiptInfo
            // 
            this.btnLastReceiptInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLastReceiptInfo.Location = new System.Drawing.Point(116, 2);
            this.btnLastReceiptInfo.Margin = new System.Windows.Forms.Padding(2);
            this.btnLastReceiptInfo.Name = "btnLastReceiptInfo";
            this.btnLastReceiptInfo.Size = new System.Drawing.Size(110, 63);
            this.btnLastReceiptInfo.TabIndex = 7;
            this.btnLastReceiptInfo.Text = "Son Fiş Bilgisi";
            this.btnLastReceiptInfo.UseVisualStyleBackColor = true;
            this.btnLastReceiptInfo.Click += new System.EventHandler(this.btnLastReceiptInfo_Click);
            // 
            // tableLayoutPanelFiscalInfoUC
            // 
            this.tableLayoutPanelFiscalInfoUC.ColumnCount = 2;
            this.tableLayoutPanelFiscalInfoUC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelFiscalInfoUC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelFiscalInfoUC.Controls.Add(this.gbxStatusFuncs, 0, 0);
            this.tableLayoutPanelFiscalInfoUC.Controls.Add(this.gbcEjLimit, 0, 1);
            this.tableLayoutPanelFiscalInfoUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFiscalInfoUC.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelFiscalInfoUC.Name = "tableLayoutPanelFiscalInfoUC";
            this.tableLayoutPanelFiscalInfoUC.RowCount = 3;
            this.tableLayoutPanelFiscalInfoUC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelFiscalInfoUC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelFiscalInfoUC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanelFiscalInfoUC.Size = new System.Drawing.Size(591, 427);
            this.tableLayoutPanelFiscalInfoUC.TabIndex = 21;
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

        private void btnLastZInfo_Click(object sender, EventArgs e)
        {
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
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void btnSetEjLimit_Click(object sender, EventArgs e)
        {
            SendCommand(new CPResponse(bridge.Printer.SetEJLimit((int)nmrEjLine.Value)));
        }
    }
}

