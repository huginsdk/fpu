using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace FP300Service.UserControls
{
    public class UtililtyFuncsUC : TestUC
    {

        private static IBridge bridge = null;
        private static TestUC saleForm = null;

        private GroupBox gbxStatusFuncs;
        private Button btnInterruptProcess;
        private Button btnLastResponse;
        private GroupBox gbxCashier;
        private TextBox txtPassword;
        private Label lblPass;
        private Label lblCashierNo;
        private NumericUpDown nmrCashierNo;
        private Button btnSignInCashier;
        private GroupBox grpPayInOut;
        private Label lblPayAmount;
        private NumericUpDown nmrPayAmount;
        private Button btnPayIn;
        private Button btnPayOut;
        private GroupBox gbxSpecialReceipt;
        private Button btnSampleNF;
        private Button btnCloseNF;
        private Button btnStartNFReceipt;
        private Button btnQueryStatus;

        internal static TestUC Instance(IBridge iBridge)
        {
            if (saleForm == null)
            {
                saleForm = new UtililtyFuncsUC();
                bridge = iBridge;
            }
            return saleForm;
        }

        public UtililtyFuncsUC()
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
            this.btnInterruptProcess = new System.Windows.Forms.Button();
            this.btnLastResponse = new System.Windows.Forms.Button();
            this.btnQueryStatus = new System.Windows.Forms.Button();
            this.gbxCashier = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblCashierNo = new System.Windows.Forms.Label();
            this.nmrCashierNo = new System.Windows.Forms.NumericUpDown();
            this.btnSignInCashier = new System.Windows.Forms.Button();
            this.grpPayInOut = new System.Windows.Forms.GroupBox();
            this.btnPayOut = new System.Windows.Forms.Button();
            this.lblPayAmount = new System.Windows.Forms.Label();
            this.nmrPayAmount = new System.Windows.Forms.NumericUpDown();
            this.btnPayIn = new System.Windows.Forms.Button();
            this.gbxSpecialReceipt = new System.Windows.Forms.GroupBox();
            this.btnSampleNF = new System.Windows.Forms.Button();
            this.btnCloseNF = new System.Windows.Forms.Button();
            this.btnStartNFReceipt = new System.Windows.Forms.Button();
            this.gbxStatusFuncs.SuspendLayout();
            this.gbxCashier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrCashierNo)).BeginInit();
            this.grpPayInOut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPayAmount)).BeginInit();
            this.gbxSpecialReceipt.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxStatusFuncs
            // 
            this.gbxStatusFuncs.Controls.Add(this.btnInterruptProcess);
            this.gbxStatusFuncs.Controls.Add(this.btnLastResponse);
            this.gbxStatusFuncs.Controls.Add(this.btnQueryStatus);
            this.gbxStatusFuncs.Location = new System.Drawing.Point(3, 106);
            this.gbxStatusFuncs.Name = "gbxStatusFuncs";
            this.gbxStatusFuncs.Size = new System.Drawing.Size(534, 84);
            this.gbxStatusFuncs.TabIndex = 18;
            this.gbxStatusFuncs.TabStop = false;
            this.gbxStatusFuncs.Text = "Durum Bilgisi";
            // 
            // btnInterruptProcess
            // 
            this.btnInterruptProcess.Location = new System.Drawing.Point(362, 31);
            this.btnInterruptProcess.Name = "btnInterruptProcess";
            this.btnInterruptProcess.Size = new System.Drawing.Size(147, 37);
            this.btnInterruptProcess.TabIndex = 8;
            this.btnInterruptProcess.Text = "İşlem Durdurma";
            this.btnInterruptProcess.UseVisualStyleBackColor = true;
            this.btnInterruptProcess.Click += new System.EventHandler(this.btnInterruptProcess_Click);
            // 
            // btnLastResponse
            // 
            this.btnLastResponse.Location = new System.Drawing.Point(182, 31);
            this.btnLastResponse.Name = "btnLastResponse";
            this.btnLastResponse.Size = new System.Drawing.Size(147, 37);
            this.btnLastResponse.TabIndex = 7;
            this.btnLastResponse.Text = "Son Cevap İste";
            this.btnLastResponse.UseVisualStyleBackColor = true;
            this.btnLastResponse.Click += new System.EventHandler(this.btnLastResponse_Click);
            // 
            // btnQueryStatus
            // 
            this.btnQueryStatus.Location = new System.Drawing.Point(6, 31);
            this.btnQueryStatus.Name = "btnQueryStatus";
            this.btnQueryStatus.Size = new System.Drawing.Size(147, 37);
            this.btnQueryStatus.TabIndex = 6;
            this.btnQueryStatus.Text = "Status Sorgulama";
            this.btnQueryStatus.UseVisualStyleBackColor = true;
            this.btnQueryStatus.Click += new System.EventHandler(this.btnQueryStatus_Click);
            // 
            // gbxCashier
            // 
            this.gbxCashier.Controls.Add(this.txtPassword);
            this.gbxCashier.Controls.Add(this.lblPass);
            this.gbxCashier.Controls.Add(this.lblCashierNo);
            this.gbxCashier.Controls.Add(this.nmrCashierNo);
            this.gbxCashier.Controls.Add(this.btnSignInCashier);
            this.gbxCashier.Location = new System.Drawing.Point(3, 211);
            this.gbxCashier.Name = "gbxCashier";
            this.gbxCashier.Size = new System.Drawing.Size(534, 84);
            this.gbxCashier.TabIndex = 20;
            this.gbxCashier.TabStop = false;
            this.gbxCashier.Text = "Kasiyer Girişi";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(297, 48);
            this.txtPassword.MaxLength = 10;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(81, 22);
            this.txtPassword.TabIndex = 10;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(212, 51);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(45, 17);
            this.lblPass.TabIndex = 9;
            this.lblPass.Text = "Şifre :";
            // 
            // lblCashierNo
            // 
            this.lblCashierNo.AutoSize = true;
            this.lblCashierNo.Location = new System.Drawing.Point(212, 21);
            this.lblCashierNo.Name = "lblCashierNo";
            this.lblCashierNo.Size = new System.Drawing.Size(85, 17);
            this.lblCashierNo.TabIndex = 8;
            this.lblCashierNo.Text = "Kasiyer No :";
            // 
            // nmrCashierNo
            // 
            this.nmrCashierNo.Location = new System.Drawing.Point(297, 19);
            this.nmrCashierNo.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nmrCashierNo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrCashierNo.Name = "nmrCashierNo";
            this.nmrCashierNo.Size = new System.Drawing.Size(81, 22);
            this.nmrCashierNo.TabIndex = 7;
            this.nmrCashierNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrCashierNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnSignInCashier
            // 
            this.btnSignInCashier.Location = new System.Drawing.Point(6, 31);
            this.btnSignInCashier.Name = "btnSignInCashier";
            this.btnSignInCashier.Size = new System.Drawing.Size(147, 37);
            this.btnSignInCashier.TabIndex = 6;
            this.btnSignInCashier.Text = "Kasiyer Girişi";
            this.btnSignInCashier.UseVisualStyleBackColor = true;
            this.btnSignInCashier.Click += new System.EventHandler(this.btnSignInCashier_Click);
            // 
            // grpPayInOut
            // 
            this.grpPayInOut.Controls.Add(this.btnPayOut);
            this.grpPayInOut.Controls.Add(this.lblPayAmount);
            this.grpPayInOut.Controls.Add(this.nmrPayAmount);
            this.grpPayInOut.Controls.Add(this.btnPayIn);
            this.grpPayInOut.Location = new System.Drawing.Point(3, 301);
            this.grpPayInOut.Name = "grpPayInOut";
            this.grpPayInOut.Size = new System.Drawing.Size(534, 84);
            this.grpPayInOut.TabIndex = 21;
            this.grpPayInOut.TabStop = false;
            this.grpPayInOut.Text = "Kasa Aldı/Verdi";
            // 
            // btnPayOut
            // 
            this.btnPayOut.Location = new System.Drawing.Point(182, 31);
            this.btnPayOut.Name = "btnPayOut";
            this.btnPayOut.Size = new System.Drawing.Size(147, 37);
            this.btnPayOut.TabIndex = 9;
            this.btnPayOut.Text = "Kasa Verdi";
            this.btnPayOut.UseVisualStyleBackColor = true;
            this.btnPayOut.Click += new System.EventHandler(this.btnPayOut_Click);
            // 
            // lblPayAmount
            // 
            this.lblPayAmount.AutoSize = true;
            this.lblPayAmount.Location = new System.Drawing.Point(368, 38);
            this.lblPayAmount.Name = "lblPayAmount";
            this.lblPayAmount.Size = new System.Drawing.Size(54, 17);
            this.lblPayAmount.TabIndex = 8;
            this.lblPayAmount.Text = "Miktar :";
            // 
            // nmrPayAmount
            // 
            this.nmrPayAmount.DecimalPlaces = 2;
            this.nmrPayAmount.Location = new System.Drawing.Point(428, 36);
            this.nmrPayAmount.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            131072});
            this.nmrPayAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrPayAmount.Name = "nmrPayAmount";
            this.nmrPayAmount.Size = new System.Drawing.Size(81, 22);
            this.nmrPayAmount.TabIndex = 7;
            this.nmrPayAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrPayAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnPayIn
            // 
            this.btnPayIn.Location = new System.Drawing.Point(6, 31);
            this.btnPayIn.Name = "btnPayIn";
            this.btnPayIn.Size = new System.Drawing.Size(147, 37);
            this.btnPayIn.TabIndex = 6;
            this.btnPayIn.Text = "Kasa Aldı";
            this.btnPayIn.UseVisualStyleBackColor = true;
            this.btnPayIn.Click += new System.EventHandler(this.btnPayIn_Click);
            // 
            // gbxSpecialReceipt
            // 
            this.gbxSpecialReceipt.Controls.Add(this.btnSampleNF);
            this.gbxSpecialReceipt.Controls.Add(this.btnCloseNF);
            this.gbxSpecialReceipt.Controls.Add(this.btnStartNFReceipt);
            this.gbxSpecialReceipt.Location = new System.Drawing.Point(3, 391);
            this.gbxSpecialReceipt.Name = "gbxSpecialReceipt";
            this.gbxSpecialReceipt.Size = new System.Drawing.Size(534, 115);
            this.gbxSpecialReceipt.TabIndex = 22;
            this.gbxSpecialReceipt.TabStop = false;
            this.gbxSpecialReceipt.Text = "Özel Fiş";
            // 
            // btnSampleNF
            // 
            this.btnSampleNF.Location = new System.Drawing.Point(176, 62);
            this.btnSampleNF.Name = "btnSampleNF";
            this.btnSampleNF.Size = new System.Drawing.Size(147, 37);
            this.btnSampleNF.TabIndex = 10;
            this.btnSampleNF.Text = "Örnek İçerik Yazdır";
            this.btnSampleNF.UseVisualStyleBackColor = true;
            this.btnSampleNF.Click += new System.EventHandler(this.btnSampleNF_Click);
            // 
            // btnCloseNF
            // 
            this.btnCloseNF.Location = new System.Drawing.Point(365, 62);
            this.btnCloseNF.Name = "btnCloseNF";
            this.btnCloseNF.Size = new System.Drawing.Size(147, 37);
            this.btnCloseNF.TabIndex = 9;
            this.btnCloseNF.Text = "Özel Fiş Kapat";
            this.btnCloseNF.UseVisualStyleBackColor = true;
            this.btnCloseNF.Click += new System.EventHandler(this.btnCloseNF_Click);
            // 
            // btnStartNFReceipt
            // 
            this.btnStartNFReceipt.Location = new System.Drawing.Point(6, 62);
            this.btnStartNFReceipt.Name = "btnStartNFReceipt";
            this.btnStartNFReceipt.Size = new System.Drawing.Size(147, 37);
            this.btnStartNFReceipt.TabIndex = 6;
            this.btnStartNFReceipt.Text = "Özel Fiş Başlat";
            this.btnStartNFReceipt.UseVisualStyleBackColor = true;
            this.btnStartNFReceipt.Click += new System.EventHandler(this.btnStartNFReceipt_Click);
            // 
            // UtililtyFuncsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxSpecialReceipt);
            this.Controls.Add(this.grpPayInOut);
            this.Controls.Add(this.gbxCashier);
            this.Controls.Add(this.gbxStatusFuncs);
            this.Name = "UtililtyFuncsUC";
            this.gbxStatusFuncs.ResumeLayout(false);
            this.gbxCashier.ResumeLayout(false);
            this.gbxCashier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrCashierNo)).EndInit();
            this.grpPayInOut.ResumeLayout(false);
            this.grpPayInOut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPayAmount)).EndInit();
            this.gbxSpecialReceipt.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private void ParseResponse(CPResponse response)
        {
            try
            {
                if (response.ErrorCode == 0)
                {
                    string retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        bridge.Log(String.Format("Tarih : {0}", retVal));
                    }

                    retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        bridge.Log(String.Format("Saat : {0}", retVal));
                    }
                    retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        bridge.Log(String.Format("NOTE : {0}", retVal));
                    }
                    retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        bridge.Log(String.Format("Miktar: {0}", retVal));
                    }
                    retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        bridge.Log("Fiş No: " + retVal);
                    }

                    retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                    }

                    retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        String authNote = "";

                        switch (int.Parse(retVal))
                        {
                            case 0:
                                authNote = "SATIŞ";
                                break;
                            case 1:
                                authNote = "PROGRAM";
                                break;
                            case 2:
                                authNote = "SATIŞ & Z";
                                break;
                            case 3:
                                authNote = "HEPSİ";
                                break;
                            default:
                                authNote = "";
                                break;
                        }
                        
                        bridge.Log("Yetki : " + authNote);
                        }
                    }
                
            }
            catch (System.Exception ex)
            {
                bridge.Log("Hata: İşlem başarısız.");
            }
        }
        
        private void btnQueryStatus_Click(object sender, EventArgs e)
        {
            try
            {
                CPResponse response = new CPResponse(bridge.Printer.CheckPrinterStatus());
                ParseResponse(response);

            }
            catch (System.Exception ex)
            {
                bridge.Log("Hata: " + ex.Message);
            }
        }

        private void btnLastResponse_Click(object sender, EventArgs e)
        {
            try
            {
            ParseResponse(new CPResponse(bridge.Printer.GetLastResponse()));
            }
            catch (System.Exception ex)
            {
                bridge.Log("Hata: " + ex.Message);
            }
        }

        private void btnInterruptProcess_Click(object sender, EventArgs e)
        {
            try
            {
                ParseResponse(new CPResponse(bridge.Printer.InterruptReport()));
            }
            catch (System.Exception ex)
            {
                bridge.Log("Hata: " + ex.Message);
            }
        }

        private void btnSignInCashier_Click(object sender, EventArgs e)
        {
            // Cashier Id
            int id = (int)nmrCashierNo.Value;

            // Password
            string password = txtPassword.Text;

            try
            {
                ParseResponse(new CPResponse(bridge.Printer.SignInCashier(id, password)));
            }
            catch (System.Exception ex)
            {
                bridge.Log("Hata: " + ex.Message);
            }
        }

        private void btnPayIn_Click(object sender, EventArgs e)
        {
            // Amount
            decimal amount = nmrPayAmount.Value;

            try
            {
                ParseResponse(new CPResponse(bridge.Printer.CashIn(amount)));
            }
            catch (System.Exception ex)
            {
                bridge.Log("Hata: " + ex.Message);
            }
        }

        private void btnPayOut_Click(object sender, EventArgs e)
        {
            // Amount
            decimal amount = nmrPayAmount.Value;

            try
            {
                ParseResponse(new CPResponse(bridge.Printer.CashOut(amount)));
            }
            catch (System.Exception ex)
            {
                bridge.Log("Hata: " + ex.Message);
            }
        }

        private void btnStartNFReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                ParseResponse(new CPResponse(bridge.Printer.StartNFReceipt()));
            }
            catch (System.Exception ex)
            {
                bridge.Log("Hata: " + ex.Message);
            }
        }

        private void btnSampleNF_Click(object sender, EventArgs e)
        {
            List<string> lines = new List<string>();

            for (int i = 0; i < 50; i++)
            {
                lines.Add(String.Format("ÖRNEK SATIR {0}", i));
            }

            try
            {
                CPResponse response = new CPResponse(bridge.Printer.WriteNFLine(lines.ToArray()));
            }
            catch (System.Exception ex)
            {
                bridge.Log("Hata: " + ex.Message);
            }
        }

        private void btnCloseNF_Click(object sender, EventArgs e)
        {
            try
            {
                ParseResponse(new CPResponse(bridge.Printer.CloseNFReceipt()));
            }
            catch (System.Exception ex)
            {
                bridge.Log("Hata: " + ex.Message);
            }
        }
    }
}
