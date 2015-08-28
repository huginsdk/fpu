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
        }


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbxStatusFuncs = new System.Windows.Forms.GroupBox();
            this.btnDrawerInfo = new System.Windows.Forms.Button();
            this.btnLastReceiptInfo = new System.Windows.Forms.Button();
            this.btnLastZInfo = new System.Windows.Forms.Button();
            this.gbxStatusFuncs.SuspendLayout();
            this.SuspendLayout();
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
            this.gbxStatusFuncs.Text = "Mali Fiş Bilgileri";
            // 
            // btnDrawerInfo
            // 
            this.btnDrawerInfo.Location = new System.Drawing.Point(362, 31);
            this.btnDrawerInfo.Name = "btnDrawerInfo";
            this.btnDrawerInfo.Size = new System.Drawing.Size(147, 37);
            this.btnDrawerInfo.TabIndex = 8;
            this.btnDrawerInfo.Text = "Çekmece Bilgileri";
            this.btnDrawerInfo.UseVisualStyleBackColor = true;
            this.btnDrawerInfo.Click += new System.EventHandler(this.btnDrawerInfo_Click);
            // 
            // btnLastReceiptInfo
            // 
            this.btnLastReceiptInfo.Location = new System.Drawing.Point(182, 31);
            this.btnLastReceiptInfo.Name = "btnLastReceiptInfo";
            this.btnLastReceiptInfo.Size = new System.Drawing.Size(147, 37);
            this.btnLastReceiptInfo.TabIndex = 7;
            this.btnLastReceiptInfo.Text = "Son Fiş Bilgisi";
            this.btnLastReceiptInfo.UseVisualStyleBackColor = true;
            this.btnLastReceiptInfo.Click += new System.EventHandler(this.btnLastReceiptInfo_Click);
            // 
            // btnLastZInfo
            // 
            this.btnLastZInfo.Location = new System.Drawing.Point(6, 31);
            this.btnLastZInfo.Name = "btnLastZInfo";
            this.btnLastZInfo.Size = new System.Drawing.Size(147, 37);
            this.btnLastZInfo.TabIndex = 6;
            this.btnLastZInfo.Text = "Son Z Bilgisi";
            this.btnLastZInfo.UseVisualStyleBackColor = true;
            this.btnLastZInfo.Click += new System.EventHandler(this.btnLastZInfo_Click);
            // 
            // FiscalInfoUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxStatusFuncs);
            this.Name = "FiscalInfoUC";
            this.gbxStatusFuncs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxStatusFuncs;
        private System.Windows.Forms.Button btnDrawerInfo;
        private System.Windows.Forms.Button btnLastReceiptInfo;
        private System.Windows.Forms.Button btnLastZInfo;
        private static TestUC statusForm = null;
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
            SendCommand(new CPResponse(bridge.Printer.GetLastDocumentInfo(true)));
        }

        private void btnLastReceiptInfo_Click(object sender, EventArgs e)
        {
            lastCmd = FiscalCmd.LAST_RECEIPT_INFO;
            SendCommand(new CPResponse(bridge.Printer.GetLastDocumentInfo(false)));
        }

        private void btnDrawerInfo_Click(object sender, EventArgs e)
        {
            lastCmd = FiscalCmd.DRAWER_INFO;
            SendCommand(new CPResponse(bridge.Printer.GetDrawerInfo()));
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
                            bridge.Log("Fiş No      : " + paramVal);
                        }
                        paramVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(paramVal))
                        {
                            bridge.Log("Z No        : " + paramVal);
                        }
                        paramVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(paramVal))
                        {
                            bridge.Log("Ej No       : " + paramVal);
                        }
                        paramVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(paramVal))
                        {
                            bridge.Log("Belge Tipi  : " + paramVal);
                        }
                        paramVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(paramVal))
                        {
                            bridge.Log(String.Format("Tarih       : {0}", paramVal));
                        }

                        paramVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(paramVal))
                        {
                            bridge.Log(String.Format("Saat        : {0}", paramVal));
                        }
                    }
                    // TOPLAM BİLGİLERİ                   
                    paramVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(paramVal))
                    {
                        bridge.Log("--- TOPLAM BİLGİLERİ ---");
                        bridge.Log(String.Format("TOP. FİŞ    : {0}", paramVal));
                    }
                    paramVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(paramVal))
                    {
                        bridge.Log(String.Format("TOP. TUTAR  : {0}", paramVal));
                    }
                    
                    // SATIŞ BİLGİLERİ                          
                    paramVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(paramVal))
                    {
                        bridge.Log("--- SATIŞ BİLGİLERİ ---");
                        bridge.Log(String.Format("TOP. SAT FİŞ: {0}", paramVal));
                    }
                    paramVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(paramVal))
                    {
                        bridge.Log(String.Format("SATIŞ TOPLAM: {0}", paramVal));
                    }
                     
                    // İPTAL BİLGİLERİ                   
                    paramVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(paramVal))
                    {
                        bridge.Log("--- İPTAL BİLGİLERİ ---");
                        bridge.Log(String.Format("TOP. İPT FİŞ: {0}", paramVal));
                    }
                    paramVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(paramVal))
                    {
                        bridge.Log(String.Format("İPTAL TOPLAM: {0}", paramVal));
                    }

                    // İNDİRİM BİLGİLERİ                 
                    paramVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(paramVal))
                    {
                        bridge.Log("--- İNDİRİM BİLGİLERİ ---");
                        bridge.Log(String.Format("İNDİRİM TOP.: {0}", paramVal));
                    }

                    // ÖDEME BİLGİLERİ                  
                    paramVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(paramVal))
                    {
                        bridge.Log("--- ÖDEME BİLGİLERİ ---");
                        int paymentType = int.Parse(paramVal);
                        bridge.Log(String.Format("ÖDEME TİPİ  : {0}", paymentType));
                    }
                    paramVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(paramVal))
                    {
                        bridge.Log(String.Format("ÖDEME İNDEKS: {0}", paramVal));
                    }
                    paramVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(paramVal))
                    {
                        bridge.Log(String.Format("ÖDEME TOPLAM: {0}", paramVal));
                    }                                       
                }
            }
            catch (System.Exception ex)
            {
                bridge.Log("Hata: İşlem başarısız.");
            }
        }

    }
}

