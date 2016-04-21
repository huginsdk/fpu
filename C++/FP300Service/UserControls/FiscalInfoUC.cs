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
            this.lblEjLimit = new System.Windows.Forms.Label();
            this.nmrEjLine = new System.Windows.Forms.NumericUpDown();
            this.btnSetEjLimit = new System.Windows.Forms.Button();
            this.gbxStatusFuncs = new System.Windows.Forms.GroupBox();
            this.btnDrawerInfo = new System.Windows.Forms.Button();
            this.btnLastReceiptInfo = new System.Windows.Forms.Button();
            this.btnLastZInfo = new System.Windows.Forms.Button();
            this.gbcEjLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrEjLine)).BeginInit();
            this.gbxStatusFuncs.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbcEjLimit
            // 
            this.gbcEjLimit.Controls.Add(this.lblEjLimit);
            this.gbcEjLimit.Controls.Add(this.nmrEjLine);
            this.gbcEjLimit.Controls.Add(this.btnSetEjLimit);
            this.gbcEjLimit.Location = new System.Drawing.Point(3, 125);
            this.gbcEjLimit.Name = "gbcEjLimit";
            this.gbcEjLimit.Size = new System.Drawing.Size(534, 84);
            this.gbcEjLimit.TabIndex = 20;
            this.gbcEjLimit.TabStop = false;
            this.gbcEjLimit.Text = FormMessage.EJ_LIMIT;
            // 
            // lblEjLimit
            // 
            this.lblEjLimit.AutoSize = true;
            this.lblEjLimit.Location = new System.Drawing.Point(197, 21);
            this.lblEjLimit.Name = "lblEjLimit";
            this.lblEjLimit.Size = new System.Drawing.Size(82, 17);
            this.lblEjLimit.TabIndex = 16;
            this.lblEjLimit.Text = FormMessage.LINE_COUNT + ":";
            // 
            // nmrEjLine
            // 
            this.nmrEjLine.Location = new System.Drawing.Point(200, 42);
            this.nmrEjLine.Maximum = new decimal(new int[] {
            40000000,
            0,
            0,
            0});
            this.nmrEjLine.Name = "nmrEjLine";
            this.nmrEjLine.Size = new System.Drawing.Size(105, 22);
            this.nmrEjLine.TabIndex = 15;
            this.nmrEjLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrEjLine.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btnSetEjLimit
            // 
            this.btnSetEjLimit.Location = new System.Drawing.Point(6, 31);
            this.btnSetEjLimit.Name = "btnSetEjLimit";
            this.btnSetEjLimit.Size = new System.Drawing.Size(147, 37);
            this.btnSetEjLimit.TabIndex = 6;
            this.btnSetEjLimit.Text = FormMessage.SET_EJ_LIMIT;
            this.btnSetEjLimit.UseVisualStyleBackColor = true;
            this.btnSetEjLimit.Click += new System.EventHandler(this.btnSetEjLimit_Click);
            // 
            // gbxStatusFuncs
            // 
            this.gbxStatusFuncs.Controls.Add(this.btnDrawerInfo);
            this.gbxStatusFuncs.Controls.Add(this.btnLastReceiptInfo);
            this.gbxStatusFuncs.Controls.Add(this.btnLastZInfo);
            this.gbxStatusFuncs.Location = new System.Drawing.Point(3, 20);
            this.gbxStatusFuncs.Name = "gbxStatusFuncs";
            this.gbxStatusFuncs.Size = new System.Drawing.Size(534, 84);
            this.gbxStatusFuncs.TabIndex = 19;
            this.gbxStatusFuncs.TabStop = false;
            this.gbxStatusFuncs.Text = FormMessage.FISCAL_RECEIPT_INFO;
            // 
            // btnDrawerInfo
            // 
            this.btnDrawerInfo.Location = new System.Drawing.Point(362, 31);
            this.btnDrawerInfo.Name = "btnDrawerInfo";
            this.btnDrawerInfo.Size = new System.Drawing.Size(147, 37);
            this.btnDrawerInfo.TabIndex = 8;
            this.btnDrawerInfo.Text = FormMessage.DRAWER_INFO;
            this.btnDrawerInfo.UseVisualStyleBackColor = true;
            this.btnDrawerInfo.Click += new System.EventHandler(this.btnDrawerInfo_Click);
            // 
            // btnLastReceiptInfo
            // 
            this.btnLastReceiptInfo.Location = new System.Drawing.Point(182, 31);
            this.btnLastReceiptInfo.Name = "btnLastReceiptInfo";
            this.btnLastReceiptInfo.Size = new System.Drawing.Size(147, 37);
            this.btnLastReceiptInfo.TabIndex = 7;
            this.btnLastReceiptInfo.Text = FormMessage.LAST_RECEIPT_INFO;
            this.btnLastReceiptInfo.UseVisualStyleBackColor = true;
            this.btnLastReceiptInfo.Click += new System.EventHandler(this.btnLastReceiptInfo_Click);
            // 
            // btnLastZInfo
            // 
            this.btnLastZInfo.Location = new System.Drawing.Point(6, 31);
            this.btnLastZInfo.Name = "btnLastZInfo";
            this.btnLastZInfo.Size = new System.Drawing.Size(147, 37);
            this.btnLastZInfo.TabIndex = 6;
            this.btnLastZInfo.Text = FormMessage.LAST_Z_REPORT_INFO;
            this.btnLastZInfo.UseVisualStyleBackColor = true;
            this.btnLastZInfo.Click += new System.EventHandler(this.btnLastZInfo_Click);
            // 
            // FiscalInfoUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbcEjLimit);
            this.Controls.Add(this.gbxStatusFuncs);
            this.Name = "FiscalInfoUC";
            this.gbcEjLimit.ResumeLayout(false);
            this.gbcEjLimit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrEjLine)).EndInit();
            this.gbxStatusFuncs.ResumeLayout(false);
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

