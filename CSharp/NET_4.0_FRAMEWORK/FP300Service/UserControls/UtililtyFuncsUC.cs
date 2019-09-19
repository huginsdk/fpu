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
        private Button btnStartFM;
        private Button btnQueryStatus;
        private Button btnLastResponse;
        private Button btnInterruptProcess;
        private Button btnSignInCashier;
        private Button btnPayIn;
        private Button btnPayOut;
        private Label lblPayAmount;
        private NumericUpDown nmrPayAmount;
        private Button btnStartNFReceipt;
        private Button btnSampleNF;
        private Button btnCloseNF;
        private Label lblCashierNo;
        private Label lblPass;
        private NumericUpDown nmrCashierNo;
        private TextBox txtPassword;
        private Label lblStatusInfo;
        private Label lblNFReceipt;
        private Label lblFiscalOperations;
        private Label lblCashierOptions;
        private Label lblDrawerOptions;
        private Label lblKeypadOptions;
        private Button btnUnlockKeys;
        private Button btnLockKeys;
        private static TestUC saleForm = null;

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

            SetLanguageOption();
        }

        private void SetLanguageOption()
        {
            this.lblStatusInfo.Text = FormMessage.STATUS_INFO;
            this.btnInterruptProcess.Text = FormMessage.INTERRUPT_PROCESS;
            this.btnLastResponse.Text = FormMessage.LAST_RESPONSE;
            this.btnQueryStatus.Text = FormMessage.CHECK_STATUS;
            this.lblFiscalOperations.Text = FormMessage.FISCAL_OPERATIONS;
            this.btnStartFM.Text = FormMessage.START_FM;
            this.lblCashierOptions.Text = FormMessage.CASHIER_LOGIN;
            this.lblPass.Text = FormMessage.PASSWORD;
            this.lblCashierNo.Text = FormMessage.CASHIER_ID;
            this.btnSignInCashier.Text = FormMessage.CASHIER_LOGIN;
            this.lblDrawerOptions.Text = FormMessage.CASH_IN_CASH_OUT;
            this.btnPayOut.Text = FormMessage.CASH_OUT;
            this.lblPayAmount.Text = FormMessage.AMOUNT;
            this.btnPayIn.Text = FormMessage.CASH_IN;
            this.lblNFReceipt.Text = FormMessage.SPECIAL_RECEIPT;
            this.btnSampleNF.Text = FormMessage.PRINT_SAMPLE_CONTEXT;
            this.btnCloseNF.Text = FormMessage.CLOSE_NF_RECEIPT;
            this.btnStartNFReceipt.Text = FormMessage.START_NF_RECEIPT;

            this.lblKeypadOptions.Text = FormMessage.KEYPAD_OPTIONS;
            this.btnLockKeys.Text = FormMessage.LOCK_KEYS;
            this.btnUnlockKeys.Text = FormMessage.UNLOCK_KEYS;
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCloseNF = new System.Windows.Forms.Button();
            this.btnSampleNF = new System.Windows.Forms.Button();
            this.btnStartNFReceipt = new System.Windows.Forms.Button();
            this.btnPayOut = new System.Windows.Forms.Button();
            this.btnPayIn = new System.Windows.Forms.Button();
            this.nmrPayAmount = new System.Windows.Forms.NumericUpDown();
            this.lblPayAmount = new System.Windows.Forms.Label();
            this.btnSignInCashier = new System.Windows.Forms.Button();
            this.lblCashierNo = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.nmrCashierNo = new System.Windows.Forms.NumericUpDown();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnStartFM = new System.Windows.Forms.Button();
            this.btnInterruptProcess = new System.Windows.Forms.Button();
            this.btnLastResponse = new System.Windows.Forms.Button();
            this.btnQueryStatus = new System.Windows.Forms.Button();
            this.lblStatusInfo = new System.Windows.Forms.Label();
            this.lblNFReceipt = new System.Windows.Forms.Label();
            this.lblFiscalOperations = new System.Windows.Forms.Label();
            this.lblCashierOptions = new System.Windows.Forms.Label();
            this.lblDrawerOptions = new System.Windows.Forms.Label();
            this.lblKeypadOptions = new System.Windows.Forms.Label();
            this.btnUnlockKeys = new System.Windows.Forms.Button();
            this.btnLockKeys = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPayAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrCashierNo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCloseNF
            // 
            this.btnCloseNF.Location = new System.Drawing.Point(560, 140);
            this.btnCloseNF.Name = "btnCloseNF";
            this.btnCloseNF.Size = new System.Drawing.Size(225, 30);
            this.btnCloseNF.TabIndex = 12;
            this.btnCloseNF.Text = "CLOSE NF RECEIPT";
            this.btnCloseNF.UseVisualStyleBackColor = true;
            this.btnCloseNF.Click += new System.EventHandler(this.btnCloseNF_Click);
            // 
            // btnSampleNF
            // 
            this.btnSampleNF.Location = new System.Drawing.Point(560, 100);
            this.btnSampleNF.Name = "btnSampleNF";
            this.btnSampleNF.Size = new System.Drawing.Size(225, 30);
            this.btnSampleNF.TabIndex = 11;
            this.btnSampleNF.Text = "PRINT SAMPLE CONTEXT";
            this.btnSampleNF.UseVisualStyleBackColor = true;
            this.btnSampleNF.Click += new System.EventHandler(this.btnSampleNF_Click);
            // 
            // btnStartNFReceipt
            // 
            this.btnStartNFReceipt.Location = new System.Drawing.Point(560, 60);
            this.btnStartNFReceipt.Name = "btnStartNFReceipt";
            this.btnStartNFReceipt.Size = new System.Drawing.Size(225, 30);
            this.btnStartNFReceipt.TabIndex = 7;
            this.btnStartNFReceipt.Text = "START NF RECEIPT";
            this.btnStartNFReceipt.UseVisualStyleBackColor = true;
            this.btnStartNFReceipt.Click += new System.EventHandler(this.btnStartNFReceipt_Click);
            // 
            // btnPayOut
            // 
            this.btnPayOut.Location = new System.Drawing.Point(700, 305);
            this.btnPayOut.Name = "btnPayOut";
            this.btnPayOut.Size = new System.Drawing.Size(150, 30);
            this.btnPayOut.TabIndex = 10;
            this.btnPayOut.Text = "CASH OUT";
            this.btnPayOut.UseVisualStyleBackColor = true;
            this.btnPayOut.Click += new System.EventHandler(this.btnPayOut_Click);
            // 
            // btnPayIn
            // 
            this.btnPayIn.Location = new System.Drawing.Point(515, 305);
            this.btnPayIn.Name = "btnPayIn";
            this.btnPayIn.Size = new System.Drawing.Size(150, 30);
            this.btnPayIn.TabIndex = 7;
            this.btnPayIn.Text = "CASH IN";
            this.btnPayIn.UseVisualStyleBackColor = true;
            this.btnPayIn.Click += new System.EventHandler(this.btnPayIn_Click);
            // 
            // nmrPayAmount
            // 
            this.nmrPayAmount.DecimalPlaces = 2;
            this.nmrPayAmount.Location = new System.Drawing.Point(145, 305);
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
            this.nmrPayAmount.Size = new System.Drawing.Size(195, 26);
            this.nmrPayAmount.TabIndex = 10;
            this.nmrPayAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrPayAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPayAmount
            // 
            this.lblPayAmount.AutoSize = true;
            this.lblPayAmount.Location = new System.Drawing.Point(10, 305);
            this.lblPayAmount.Name = "lblPayAmount";
            this.lblPayAmount.Size = new System.Drawing.Size(85, 20);
            this.lblPayAmount.TabIndex = 9;
            this.lblPayAmount.Text = "AMOUNT :";
            // 
            // btnSignInCashier
            // 
            this.btnSignInCashier.Location = new System.Drawing.Point(700, 225);
            this.btnSignInCashier.Name = "btnSignInCashier";
            this.btnSignInCashier.Size = new System.Drawing.Size(150, 30);
            this.btnSignInCashier.TabIndex = 7;
            this.btnSignInCashier.Text = "LOGIN";
            this.btnSignInCashier.UseVisualStyleBackColor = true;
            this.btnSignInCashier.Click += new System.EventHandler(this.btnSignInCashier_Click);
            // 
            // lblCashierNo
            // 
            this.lblCashierNo.AutoSize = true;
            this.lblCashierNo.Location = new System.Drawing.Point(10, 225);
            this.lblCashierNo.Name = "lblCashierNo";
            this.lblCashierNo.Size = new System.Drawing.Size(111, 20);
            this.lblCashierNo.TabIndex = 11;
            this.lblCashierNo.Text = "CASHIER ID :";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(365, 225);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(111, 20);
            this.lblPass.TabIndex = 12;
            this.lblPass.Text = "PASSWORD :";
            // 
            // nmrCashierNo
            // 
            this.nmrCashierNo.Location = new System.Drawing.Point(145, 225);
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
            this.nmrCashierNo.Size = new System.Drawing.Size(150, 26);
            this.nmrCashierNo.TabIndex = 13;
            this.nmrCashierNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrCashierNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(515, 225);
            this.txtPassword.MaxLength = 10;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(150, 26);
            this.txtPassword.TabIndex = 14;
            // 
            // btnStartFM
            // 
            this.btnStartFM.Location = new System.Drawing.Point(10, 60);
            this.btnStartFM.Name = "btnStartFM";
            this.btnStartFM.Size = new System.Drawing.Size(225, 30);
            this.btnStartFM.TabIndex = 7;
            this.btnStartFM.Text = "START FM";
            this.btnStartFM.UseVisualStyleBackColor = true;
            this.btnStartFM.Click += new System.EventHandler(this.btnStartFM_Click);
            // 
            // btnInterruptProcess
            // 
            this.btnInterruptProcess.Location = new System.Drawing.Point(285, 140);
            this.btnInterruptProcess.Name = "btnInterruptProcess";
            this.btnInterruptProcess.Size = new System.Drawing.Size(225, 30);
            this.btnInterruptProcess.TabIndex = 9;
            this.btnInterruptProcess.Text = "INTERRUPT PROCESS";
            this.btnInterruptProcess.UseVisualStyleBackColor = true;
            this.btnInterruptProcess.Click += new System.EventHandler(this.btnInterruptProcess_Click);
            // 
            // btnLastResponse
            // 
            this.btnLastResponse.Location = new System.Drawing.Point(285, 100);
            this.btnLastResponse.Name = "btnLastResponse";
            this.btnLastResponse.Size = new System.Drawing.Size(225, 30);
            this.btnLastResponse.TabIndex = 8;
            this.btnLastResponse.Text = "LAST RESPONSE";
            this.btnLastResponse.UseVisualStyleBackColor = true;
            this.btnLastResponse.Click += new System.EventHandler(this.btnLastResponse_Click);
            // 
            // btnQueryStatus
            // 
            this.btnQueryStatus.Location = new System.Drawing.Point(285, 60);
            this.btnQueryStatus.Name = "btnQueryStatus";
            this.btnQueryStatus.Size = new System.Drawing.Size(225, 30);
            this.btnQueryStatus.TabIndex = 7;
            this.btnQueryStatus.Text = "CHECK STATUS";
            this.btnQueryStatus.UseVisualStyleBackColor = true;
            this.btnQueryStatus.Click += new System.EventHandler(this.btnQueryStatus_Click);
            // 
            // lblStatusInfo
            // 
            this.lblStatusInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblStatusInfo.Location = new System.Drawing.Point(285, 20);
            this.lblStatusInfo.Name = "lblStatusInfo";
            this.lblStatusInfo.Size = new System.Drawing.Size(225, 25);
            this.lblStatusInfo.TabIndex = 15;
            this.lblStatusInfo.Text = "STATUS INFO";
            // 
            // lblNFReceipt
            // 
            this.lblNFReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblNFReceipt.Location = new System.Drawing.Point(560, 20);
            this.lblNFReceipt.Name = "lblNFReceipt";
            this.lblNFReceipt.Size = new System.Drawing.Size(225, 25);
            this.lblNFReceipt.TabIndex = 16;
            this.lblNFReceipt.Text = "NONFISCAL RCPT.";
            // 
            // lblFiscalOperations
            // 
            this.lblFiscalOperations.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFiscalOperations.Location = new System.Drawing.Point(10, 20);
            this.lblFiscalOperations.Name = "lblFiscalOperations";
            this.lblFiscalOperations.Size = new System.Drawing.Size(225, 25);
            this.lblFiscalOperations.TabIndex = 17;
            this.lblFiscalOperations.Text = "FISCAL OPERATIONS";
            // 
            // lblCashierOptions
            // 
            this.lblCashierOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCashierOptions.Location = new System.Drawing.Point(10, 190);
            this.lblCashierOptions.Name = "lblCashierOptions";
            this.lblCashierOptions.Size = new System.Drawing.Size(200, 25);
            this.lblCashierOptions.TabIndex = 24;
            this.lblCashierOptions.Text = "CASHIER OPTIONS";
            // 
            // lblDrawerOptions
            // 
            this.lblDrawerOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDrawerOptions.Location = new System.Drawing.Point(10, 270);
            this.lblDrawerOptions.Name = "lblDrawerOptions";
            this.lblDrawerOptions.Size = new System.Drawing.Size(200, 25);
            this.lblDrawerOptions.TabIndex = 25;
            this.lblDrawerOptions.Text = "DRAWER OPTIONS";
            // 
            // lblKeypadOptions
            // 
            this.lblKeypadOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKeypadOptions.Location = new System.Drawing.Point(10, 355);
            this.lblKeypadOptions.Name = "lblKeypadOptions";
            this.lblKeypadOptions.Size = new System.Drawing.Size(200, 25);
            this.lblKeypadOptions.TabIndex = 26;
            this.lblKeypadOptions.Text = "KEYPAD OPTIONS";
            // 
            // btnUnlockKeys
            // 
            this.btnUnlockKeys.Location = new System.Drawing.Point(700, 385);
            this.btnUnlockKeys.Name = "btnUnlockKeys";
            this.btnUnlockKeys.Size = new System.Drawing.Size(150, 30);
            this.btnUnlockKeys.TabIndex = 28;
            this.btnUnlockKeys.Text = "UNLOCK KEYS";
            this.btnUnlockKeys.UseVisualStyleBackColor = true;
            this.btnUnlockKeys.Click += new System.EventHandler(this.btnUnlockKeys_Click);
            // 
            // btnLockKeys
            // 
            this.btnLockKeys.Location = new System.Drawing.Point(515, 385);
            this.btnLockKeys.Name = "btnLockKeys";
            this.btnLockKeys.Size = new System.Drawing.Size(150, 30);
            this.btnLockKeys.TabIndex = 27;
            this.btnLockKeys.Text = "LOCK KEYS";
            this.btnLockKeys.UseVisualStyleBackColor = true;
            this.btnLockKeys.Click += new System.EventHandler(this.btnLockKeys_Click);
            // 
            // UtililtyFuncsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUnlockKeys);
            this.Controls.Add(this.btnLockKeys);
            this.Controls.Add(this.lblKeypadOptions);
            this.Controls.Add(this.btnPayOut);
            this.Controls.Add(this.nmrPayAmount);
            this.Controls.Add(this.lblDrawerOptions);
            this.Controls.Add(this.btnPayIn);
            this.Controls.Add(this.lblCashierOptions);
            this.Controls.Add(this.lblPayAmount);
            this.Controls.Add(this.lblFiscalOperations);
            this.Controls.Add(this.btnStartFM);
            this.Controls.Add(this.btnSignInCashier);
            this.Controls.Add(this.lblStatusInfo);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblNFReceipt);
            this.Controls.Add(this.nmrCashierNo);
            this.Controls.Add(this.btnStartNFReceipt);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.btnSampleNF);
            this.Controls.Add(this.lblCashierNo);
            this.Controls.Add(this.btnInterruptProcess);
            this.Controls.Add(this.btnQueryStatus);
            this.Controls.Add(this.btnLastResponse);
            this.Controls.Add(this.btnCloseNF);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "UtililtyFuncsUC";
            ((System.ComponentModel.ISupportInitialize)(this.nmrPayAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrCashierNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
                        bridge.Log(String.Format(FormMessage.DATE.PadRight(12, ' ') + ":{0}", retVal));
                    }

                    retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        bridge.Log(String.Format(FormMessage.TIME.PadRight(12, ' ') + ":{0}", retVal));
                    }
                    retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        bridge.Log(String.Format("NOTE".PadRight(12, ' ') + ":{0}", retVal));
                    }
                    retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        bridge.Log(String.Format(FormMessage.AMOUNT.PadRight(12, ' ') + ":{0}", retVal));
                    }
                    retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        bridge.Log(FormMessage.DOCUMENT_ID.PadRight(12, ' ') + ":" + retVal);
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

                            bridge.Log(FormMessage.AUTHORIZATION.PadRight(12, ' ') + ":" + authNote);
                        }
                        catch { }
                    }
                }
                
            }
            catch (Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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

                    CPResponse response = new CPResponse(bridge.Printer.StartFM(fiscalNumber));
                    ParseResponse(response);
                }
            }
            catch (FormatException)
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

        private void btnLockKeys_Click(object sender, EventArgs e)
        {
            try
            {
                ParseResponse(new CPResponse(bridge.Printer.ChangeKeyLockStatus(true)));
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
        }

        private void btnUnlockKeys_Click(object sender, EventArgs e)
        {
            try
            {
                ParseResponse(new CPResponse(bridge.Printer.ChangeKeyLockStatus(false)));
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
        }
    }
}
