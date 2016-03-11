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
        private GroupBox gbxFiscalMode;
        private Button btnStartFM;
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
            this.gbxFiscalMode = new System.Windows.Forms.GroupBox();
            this.btnStartFM = new System.Windows.Forms.Button();
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
            this.gbxFiscalMode.SuspendLayout();
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
            this.gbxStatusFuncs.Location = new System.Drawing.Point(2, 86);
            this.gbxStatusFuncs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxStatusFuncs.Name = "gbxStatusFuncs";
            this.gbxStatusFuncs.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxStatusFuncs.Size = new System.Drawing.Size(400, 68);
            this.gbxStatusFuncs.TabIndex = 18;
            this.gbxStatusFuncs.TabStop = false;
            this.gbxStatusFuncs.Text = "STATUS INFO";
            // 
            // btnInterruptProcess
            // 
            this.btnInterruptProcess.Location = new System.Drawing.Point(272, 25);
            this.btnInterruptProcess.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInterruptProcess.Name = "btnInterruptProcess";
            this.btnInterruptProcess.Size = new System.Drawing.Size(110, 30);
            this.btnInterruptProcess.TabIndex = 8;
            this.btnInterruptProcess.Text = "INTERRUPT PROCESS";
            this.btnInterruptProcess.UseVisualStyleBackColor = true;
            this.btnInterruptProcess.Click += new System.EventHandler(this.btnInterruptProcess_Click);
            // 
            // btnLastResponse
            // 
            this.btnLastResponse.Location = new System.Drawing.Point(136, 25);
            this.btnLastResponse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLastResponse.Name = "btnLastResponse";
            this.btnLastResponse.Size = new System.Drawing.Size(110, 30);
            this.btnLastResponse.TabIndex = 7;
            this.btnLastResponse.Text = "LAST RESPONSE";
            this.btnLastResponse.UseVisualStyleBackColor = true;
            this.btnLastResponse.Click += new System.EventHandler(this.btnLastResponse_Click);
            // 
            // btnQueryStatus
            // 
            this.btnQueryStatus.Location = new System.Drawing.Point(4, 25);
            this.btnQueryStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnQueryStatus.Name = "btnQueryStatus";
            this.btnQueryStatus.Size = new System.Drawing.Size(110, 30);
            this.btnQueryStatus.TabIndex = 6;
            this.btnQueryStatus.Text = "CHECK STATUS";
            this.btnQueryStatus.UseVisualStyleBackColor = true;
            this.btnQueryStatus.Click += new System.EventHandler(this.btnQueryStatus_Click);
            // 
            // gbxFiscalMode
            // 
            this.gbxFiscalMode.Controls.Add(this.btnStartFM);
            this.gbxFiscalMode.Location = new System.Drawing.Point(2, 13);
            this.gbxFiscalMode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxFiscalMode.Name = "gbxFiscalMode";
            this.gbxFiscalMode.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxFiscalMode.Size = new System.Drawing.Size(400, 68);
            this.gbxFiscalMode.TabIndex = 19;
            this.gbxFiscalMode.TabStop = false;
            this.gbxFiscalMode.Text = "FISCAL OPERATIONS";
            // 
            // btnStartFM
            // 
            this.btnStartFM.Location = new System.Drawing.Point(4, 25);
            this.btnStartFM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStartFM.Name = "btnStartFM";
            this.btnStartFM.Size = new System.Drawing.Size(110, 30);
            this.btnStartFM.TabIndex = 6;
            this.btnStartFM.Text = "START FM";
            this.btnStartFM.UseVisualStyleBackColor = true;
            this.btnStartFM.Click += new System.EventHandler(this.btnStartFM_Click);
            // 
            // gbxCashier
            // 
            this.gbxCashier.Controls.Add(this.txtPassword);
            this.gbxCashier.Controls.Add(this.lblPass);
            this.gbxCashier.Controls.Add(this.lblCashierNo);
            this.gbxCashier.Controls.Add(this.nmrCashierNo);
            this.gbxCashier.Controls.Add(this.btnSignInCashier);
            this.gbxCashier.Location = new System.Drawing.Point(2, 171);
            this.gbxCashier.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxCashier.Name = "gbxCashier";
            this.gbxCashier.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxCashier.Size = new System.Drawing.Size(400, 68);
            this.gbxCashier.TabIndex = 20;
            this.gbxCashier.TabStop = false;
            this.gbxCashier.Text = "CASHIER LOGIN";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(237, 39);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPassword.MaxLength = 10;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(62, 20);
            this.txtPassword.TabIndex = 10;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(159, 41);
            this.lblPass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(76, 13);
            this.lblPass.TabIndex = 9;
            this.lblPass.Text = "PASSWORD :";
            // 
            // lblCashierNo
            // 
            this.lblCashierNo.AutoSize = true;
            this.lblCashierNo.Location = new System.Drawing.Point(159, 17);
            this.lblCashierNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCashierNo.Name = "lblCashierNo";
            this.lblCashierNo.Size = new System.Drawing.Size(74, 13);
            this.lblCashierNo.TabIndex = 8;
            this.lblCashierNo.Text = "CASHIER ID :";
            // 
            // nmrCashierNo
            // 
            this.nmrCashierNo.Location = new System.Drawing.Point(237, 15);
            this.nmrCashierNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.nmrCashierNo.Size = new System.Drawing.Size(61, 20);
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
            this.btnSignInCashier.Location = new System.Drawing.Point(4, 25);
            this.btnSignInCashier.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSignInCashier.Name = "btnSignInCashier";
            this.btnSignInCashier.Size = new System.Drawing.Size(110, 30);
            this.btnSignInCashier.TabIndex = 6;
            this.btnSignInCashier.Text = "CASHIER LOGIN";
            this.btnSignInCashier.UseVisualStyleBackColor = true;
            this.btnSignInCashier.Click += new System.EventHandler(this.btnSignInCashier_Click);
            // 
            // grpPayInOut
            // 
            this.grpPayInOut.Controls.Add(this.btnPayOut);
            this.grpPayInOut.Controls.Add(this.lblPayAmount);
            this.grpPayInOut.Controls.Add(this.nmrPayAmount);
            this.grpPayInOut.Controls.Add(this.btnPayIn);
            this.grpPayInOut.Location = new System.Drawing.Point(2, 245);
            this.grpPayInOut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpPayInOut.Name = "grpPayInOut";
            this.grpPayInOut.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpPayInOut.Size = new System.Drawing.Size(400, 68);
            this.grpPayInOut.TabIndex = 21;
            this.grpPayInOut.TabStop = false;
            this.grpPayInOut.Text = "CASH IN/OUT";
            // 
            // btnPayOut
            // 
            this.btnPayOut.Location = new System.Drawing.Point(136, 25);
            this.btnPayOut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPayOut.Name = "btnPayOut";
            this.btnPayOut.Size = new System.Drawing.Size(110, 30);
            this.btnPayOut.TabIndex = 9;
            this.btnPayOut.Text = "CASH OUT";
            this.btnPayOut.UseVisualStyleBackColor = true;
            this.btnPayOut.Click += new System.EventHandler(this.btnPayOut_Click);
            // 
            // lblPayAmount
            // 
            this.lblPayAmount.AutoSize = true;
            this.lblPayAmount.Location = new System.Drawing.Point(263, 34);
            this.lblPayAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPayAmount.Name = "lblPayAmount";
            this.lblPayAmount.Size = new System.Drawing.Size(54, 13);
            this.lblPayAmount.TabIndex = 8;
            this.lblPayAmount.Text = "MİKTAR :";
            // 
            // nmrPayAmount
            // 
            this.nmrPayAmount.DecimalPlaces = 2;
            this.nmrPayAmount.Location = new System.Drawing.Point(321, 29);
            this.nmrPayAmount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.nmrPayAmount.Size = new System.Drawing.Size(61, 20);
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
            this.btnPayIn.Location = new System.Drawing.Point(4, 25);
            this.btnPayIn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPayIn.Name = "btnPayIn";
            this.btnPayIn.Size = new System.Drawing.Size(110, 30);
            this.btnPayIn.TabIndex = 6;
            this.btnPayIn.Text = "CASH IN";
            this.btnPayIn.UseVisualStyleBackColor = true;
            this.btnPayIn.Click += new System.EventHandler(this.btnPayIn_Click);
            // 
            // gbxSpecialReceipt
            // 
            this.gbxSpecialReceipt.Controls.Add(this.btnSampleNF);
            this.gbxSpecialReceipt.Controls.Add(this.btnCloseNF);
            this.gbxSpecialReceipt.Controls.Add(this.btnStartNFReceipt);
            this.gbxSpecialReceipt.Location = new System.Drawing.Point(2, 318);
            this.gbxSpecialReceipt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxSpecialReceipt.Name = "gbxSpecialReceipt";
            this.gbxSpecialReceipt.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxSpecialReceipt.Size = new System.Drawing.Size(400, 93);
            this.gbxSpecialReceipt.TabIndex = 22;
            this.gbxSpecialReceipt.TabStop = false;
            this.gbxSpecialReceipt.Text = "NF RECEIPT";
            // 
            // btnSampleNF
            // 
            this.btnSampleNF.Location = new System.Drawing.Point(132, 50);
            this.btnSampleNF.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSampleNF.Name = "btnSampleNF";
            this.btnSampleNF.Size = new System.Drawing.Size(110, 30);
            this.btnSampleNF.TabIndex = 10;
            this.btnSampleNF.Text = "PRINT SAMPLE CONTEXT";
            this.btnSampleNF.UseVisualStyleBackColor = true;
            this.btnSampleNF.Click += new System.EventHandler(this.btnSampleNF_Click);
            // 
            // btnCloseNF
            // 
            this.btnCloseNF.Location = new System.Drawing.Point(274, 50);
            this.btnCloseNF.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCloseNF.Name = "btnCloseNF";
            this.btnCloseNF.Size = new System.Drawing.Size(110, 30);
            this.btnCloseNF.TabIndex = 9;
            this.btnCloseNF.Text = "CLOSE NF RECEIPT";
            this.btnCloseNF.UseVisualStyleBackColor = true;
            this.btnCloseNF.Click += new System.EventHandler(this.btnCloseNF_Click);
            // 
            // btnStartNFReceipt
            // 
            this.btnStartNFReceipt.Location = new System.Drawing.Point(4, 50);
            this.btnStartNFReceipt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStartNFReceipt.Name = "btnStartNFReceipt";
            this.btnStartNFReceipt.Size = new System.Drawing.Size(110, 30);
            this.btnStartNFReceipt.TabIndex = 6;
            this.btnStartNFReceipt.Text = "START NF RECEIPT";
            this.btnStartNFReceipt.UseVisualStyleBackColor = true;
            this.btnStartNFReceipt.Click += new System.EventHandler(this.btnStartNFReceipt_Click);
            // 
            // UtililtyFuncsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxSpecialReceipt);
            this.Controls.Add(this.grpPayInOut);
            this.Controls.Add(this.gbxCashier);
            this.Controls.Add(this.gbxFiscalMode);
            this.Controls.Add(this.gbxStatusFuncs);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UtililtyFuncsUC";
            this.gbxStatusFuncs.ResumeLayout(false);
            this.gbxFiscalMode.ResumeLayout(false);
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
                        bridge.Log(String.Format(FormMessage.DATE + " :{0}", retVal));
                    }

                    retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        bridge.Log(String.Format(FormMessage.TIME + " :{0}", retVal));
                    }
                    retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        bridge.Log(String.Format("NOTE :{0}", retVal));
                    }
                    retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        bridge.Log(String.Format(FormMessage.AMOUNT + " :{0}", retVal));
                    }
                    retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        bridge.Log(FormMessage.DOCUMENT_ID + " :" + retVal);
                    }

                    retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                    }

                    retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        String authNote = "";
                        try
                        {
                            switch (int.Parse(retVal))
                            {
                                case 0:
                                    authNote = FormMessage.SALE;
                                    break;
                                case 1:
                                    authNote = "PROGRAM";
                                    break;
                                case 2:
                                    authNote = FormMessage.SALE + " & Z";
                                    break;
                                case 3:
                                    authNote = FormMessage.ALL;
                                    break;
                                default:
                                    authNote = "";
                                    break;
                            }

                            bridge.Log(FormMessage.AUTHORIZATION + "     :" + authNote);
                        }
                        catch { }
                    }
                }
                
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void btnStartFM_Click(object sender, EventArgs e)
        {
            try
            {
                InputBox ib = new InputBox(FormMessage.PLS_ENTER_FISCAL_ID + "(1-99999999) :", 8);
                if (ib.ShowDialog(this) == DialogResult.OK)
                {
                    // Fiscal number
                    int fiscalNumber = int.Parse(ib.input);
                    if (fiscalNumber == 0 || fiscalNumber > 99999999)
                    {
                        bridge.Log(FormMessage.INAPPROPRIATE_FISCAL_ID);
                    }

                    bridge.Connection.FPUTimeout = ProgramConfig.FPU_START_FM_TIMEOUT;
                    CPResponse response = new CPResponse(bridge.Printer.StartFM(fiscalNumber));
                    ParseResponse(response);
                    bridge.Connection.FPUTimeout = ProgramConfig.FPU_CMD_TIMEOUT;
                }
            }
            catch (FormatException fe)
            {
                bridge.Log(FormMessage.INAPPROPRIATE_FISCAL_ID);
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
        }

        private void btnSampleNF_Click(object sender, EventArgs e)
        {
            List<string> lines = new List<string>();

            for (int i = 0; i < 25; i++)
            {
                lines.Add(String.Format("{1} {0}", i, FormMessage.SAMPLE_LINE));
            }

            try
            {
                CPResponse response = new CPResponse(bridge.Printer.WriteNFLine(lines.ToArray()));
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
        }
    }
}
