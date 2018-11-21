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
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox gbxFiscalMode;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnStartFM;
        private GroupBox gbxStatusFuncs;
        private TableLayoutPanel tableLayoutPanel3;
        private Button btnQueryStatus;
        private Button btnLastResponse;
        private Button btnInterruptProcess;
        private GroupBox gbxCashier;
        private TableLayoutPanel tableLayoutPanel4;
        private Button btnSignInCashier;
        private GroupBox grpPayInOut;
        private TableLayoutPanel tableLayoutPanel7;
        private Button btnPayIn;
        private Button btnPayOut;
        private TableLayoutPanel tableLayoutPanel8;
        private Label lblPayAmount;
        private NumericUpDown nmrPayAmount;
        private GroupBox gbxSpecialReceipt;
        private TableLayoutPanel tableLayoutPanel9;
        private Button btnStartNFReceipt;
        private Button btnSampleNF;
        private Button btnCloseNF;
        private TableLayoutPanel tableLayoutPanel5;
        private Label lblCashierNo;
        private Label lblPass;
        private NumericUpDown nmrCashierNo;
        private TextBox txtPassword;
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
            this.gbxStatusFuncs.Text = FormMessage.STATUS_INFO;
            this.btnInterruptProcess.Text = FormMessage.INTERRUPT_PROCESS;
            this.btnLastResponse.Text = FormMessage.LAST_RESPONSE;
            this.btnQueryStatus.Text = FormMessage.CHECK_STATUS;
            this.gbxFiscalMode.Text = FormMessage.FISCAL_OPERATIONS;
            this.btnStartFM.Text = FormMessage.START_FM;
            this.gbxCashier.Text = FormMessage.CASHIER_LOGIN;
            this.lblPass.Text = FormMessage.PASSWORD;
            this.lblCashierNo.Text = FormMessage.CASHIER_ID;
            this.btnSignInCashier.Text = FormMessage.CASHIER_LOGIN;
            this.grpPayInOut.Text = FormMessage.CASH_IN_CASH_OUT;
            this.btnPayOut.Text = FormMessage.CASH_OUT;
            this.lblPayAmount.Text = FormMessage.AMOUNT;
            this.btnPayIn.Text = FormMessage.CASH_IN;
            this.gbxSpecialReceipt.Text = FormMessage.SPECIAL_RECEIPT;
            this.btnSampleNF.Text = FormMessage.PRINT_SAMPLE_CONTEXT;
            this.btnCloseNF.Text = FormMessage.CLOSE_NF_RECEIPT;
            this.btnStartNFReceipt.Text = FormMessage.START_NF_RECEIPT;
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbxSpecialReceipt = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCloseNF = new System.Windows.Forms.Button();
            this.btnSampleNF = new System.Windows.Forms.Button();
            this.btnStartNFReceipt = new System.Windows.Forms.Button();
            this.grpPayInOut = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPayOut = new System.Windows.Forms.Button();
            this.btnPayIn = new System.Windows.Forms.Button();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.nmrPayAmount = new System.Windows.Forms.NumericUpDown();
            this.lblPayAmount = new System.Windows.Forms.Label();
            this.gbxCashier = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSignInCashier = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCashierNo = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.nmrCashierNo = new System.Windows.Forms.NumericUpDown();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.gbxFiscalMode = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnStartFM = new System.Windows.Forms.Button();
            this.gbxStatusFuncs = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnInterruptProcess = new System.Windows.Forms.Button();
            this.btnLastResponse = new System.Windows.Forms.Button();
            this.btnQueryStatus = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbxSpecialReceipt.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.grpPayInOut.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPayAmount)).BeginInit();
            this.gbxCashier.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrCashierNo)).BeginInit();
            this.gbxFiscalMode.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gbxStatusFuncs.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gbxSpecialReceipt, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.grpPayInOut, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.gbxCashier, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.gbxFiscalMode, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbxStatusFuncs, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(591, 427);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gbxSpecialReceipt
            // 
            this.gbxSpecialReceipt.Controls.Add(this.tableLayoutPanel9);
            this.gbxSpecialReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxSpecialReceipt.Location = new System.Drawing.Point(2, 342);
            this.gbxSpecialReceipt.Margin = new System.Windows.Forms.Padding(2);
            this.gbxSpecialReceipt.Name = "gbxSpecialReceipt";
            this.gbxSpecialReceipt.Padding = new System.Windows.Forms.Padding(2);
            this.gbxSpecialReceipt.Size = new System.Drawing.Size(587, 83);
            this.gbxSpecialReceipt.TabIndex = 25;
            this.gbxSpecialReceipt.TabStop = false;
            this.gbxSpecialReceipt.Text = "NF RECEIPT";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 3;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel9.Controls.Add(this.btnCloseNF, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.btnSampleNF, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.btnStartNFReceipt, 0, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(2, 15);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(583, 66);
            this.tableLayoutPanel9.TabIndex = 0;
            // 
            // btnCloseNF
            // 
            this.btnCloseNF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCloseNF.Location = new System.Drawing.Point(386, 2);
            this.btnCloseNF.Margin = new System.Windows.Forms.Padding(2);
            this.btnCloseNF.Name = "btnCloseNF";
            this.btnCloseNF.Size = new System.Drawing.Size(195, 62);
            this.btnCloseNF.TabIndex = 12;
            this.btnCloseNF.Text = "CLOSE NF RECEIPT";
            this.btnCloseNF.UseVisualStyleBackColor = true;
            this.btnCloseNF.Click += new System.EventHandler(this.btnCloseNF_Click);
            // 
            // btnSampleNF
            // 
            this.btnSampleNF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSampleNF.Location = new System.Drawing.Point(194, 2);
            this.btnSampleNF.Margin = new System.Windows.Forms.Padding(2);
            this.btnSampleNF.Name = "btnSampleNF";
            this.btnSampleNF.Size = new System.Drawing.Size(188, 62);
            this.btnSampleNF.TabIndex = 11;
            this.btnSampleNF.Text = "PRINT SAMPLE CONTEXT";
            this.btnSampleNF.UseVisualStyleBackColor = true;
            this.btnSampleNF.Click += new System.EventHandler(this.btnSampleNF_Click);
            // 
            // btnStartNFReceipt
            // 
            this.btnStartNFReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartNFReceipt.Location = new System.Drawing.Point(2, 2);
            this.btnStartNFReceipt.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartNFReceipt.Name = "btnStartNFReceipt";
            this.btnStartNFReceipt.Size = new System.Drawing.Size(188, 62);
            this.btnStartNFReceipt.TabIndex = 7;
            this.btnStartNFReceipt.Text = "START NF RECEIPT";
            this.btnStartNFReceipt.UseVisualStyleBackColor = true;
            this.btnStartNFReceipt.Click += new System.EventHandler(this.btnStartNFReceipt_Click);
            // 
            // grpPayInOut
            // 
            this.grpPayInOut.Controls.Add(this.tableLayoutPanel7);
            this.grpPayInOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPayInOut.Location = new System.Drawing.Point(2, 257);
            this.grpPayInOut.Margin = new System.Windows.Forms.Padding(2);
            this.grpPayInOut.Name = "grpPayInOut";
            this.grpPayInOut.Padding = new System.Windows.Forms.Padding(2);
            this.grpPayInOut.Size = new System.Drawing.Size(587, 81);
            this.grpPayInOut.TabIndex = 24;
            this.grpPayInOut.TabStop = false;
            this.grpPayInOut.Text = "CASH IN/OUT";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel7.Controls.Add(this.btnPayOut, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.btnPayIn, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 2, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(2, 15);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(583, 64);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // btnPayOut
            // 
            this.btnPayOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPayOut.Location = new System.Drawing.Point(194, 2);
            this.btnPayOut.Margin = new System.Windows.Forms.Padding(2);
            this.btnPayOut.Name = "btnPayOut";
            this.btnPayOut.Size = new System.Drawing.Size(188, 60);
            this.btnPayOut.TabIndex = 10;
            this.btnPayOut.Text = "CASH OUT";
            this.btnPayOut.UseVisualStyleBackColor = true;
            this.btnPayOut.Click += new System.EventHandler(this.btnPayOut_Click);
            // 
            // btnPayIn
            // 
            this.btnPayIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPayIn.Location = new System.Drawing.Point(2, 2);
            this.btnPayIn.Margin = new System.Windows.Forms.Padding(2);
            this.btnPayIn.Name = "btnPayIn";
            this.btnPayIn.Size = new System.Drawing.Size(188, 60);
            this.btnPayIn.TabIndex = 7;
            this.btnPayIn.Text = "CASH IN";
            this.btnPayIn.UseVisualStyleBackColor = true;
            this.btnPayIn.Click += new System.EventHandler(this.btnPayIn_Click);
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.nmrPayAmount, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.lblPayAmount, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(387, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(193, 58);
            this.tableLayoutPanel8.TabIndex = 11;
            // 
            // nmrPayAmount
            // 
            this.nmrPayAmount.DecimalPlaces = 2;
            this.nmrPayAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nmrPayAmount.Location = new System.Drawing.Point(2, 31);
            this.nmrPayAmount.Margin = new System.Windows.Forms.Padding(2);
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
            this.nmrPayAmount.Size = new System.Drawing.Size(189, 20);
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
            this.lblPayAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPayAmount.AutoSize = true;
            this.lblPayAmount.Location = new System.Drawing.Point(69, 8);
            this.lblPayAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPayAmount.Name = "lblPayAmount";
            this.lblPayAmount.Size = new System.Drawing.Size(54, 13);
            this.lblPayAmount.TabIndex = 9;
            this.lblPayAmount.Text = "MİKTAR :";
            // 
            // gbxCashier
            // 
            this.gbxCashier.Controls.Add(this.tableLayoutPanel4);
            this.gbxCashier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxCashier.Location = new System.Drawing.Point(2, 172);
            this.gbxCashier.Margin = new System.Windows.Forms.Padding(2);
            this.gbxCashier.Name = "gbxCashier";
            this.gbxCashier.Padding = new System.Windows.Forms.Padding(2);
            this.gbxCashier.Size = new System.Drawing.Size(587, 81);
            this.gbxCashier.TabIndex = 23;
            this.gbxCashier.TabStop = false;
            this.gbxCashier.Text = "CASHIER LOGIN";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel4.Controls.Add(this.btnSignInCashier, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(2, 15);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(583, 64);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // btnSignInCashier
            // 
            this.btnSignInCashier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSignInCashier.Location = new System.Drawing.Point(2, 2);
            this.btnSignInCashier.Margin = new System.Windows.Forms.Padding(2);
            this.btnSignInCashier.Name = "btnSignInCashier";
            this.btnSignInCashier.Size = new System.Drawing.Size(188, 60);
            this.btnSignInCashier.TabIndex = 7;
            this.btnSignInCashier.Text = "CASHIER LOGIN";
            this.btnSignInCashier.UseVisualStyleBackColor = true;
            this.btnSignInCashier.Click += new System.EventHandler(this.btnSignInCashier_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 5;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.Controls.Add(this.lblCashierNo, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblPass, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.nmrCashierNo, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.txtPassword, 3, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(195, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(385, 58);
            this.tableLayoutPanel5.TabIndex = 8;
            // 
            // lblCashierNo
            // 
            this.lblCashierNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCashierNo.AutoSize = true;
            this.lblCashierNo.Location = new System.Drawing.Point(68, 8);
            this.lblCashierNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCashierNo.Name = "lblCashierNo";
            this.lblCashierNo.Size = new System.Drawing.Size(74, 13);
            this.lblCashierNo.TabIndex = 11;
            this.lblCashierNo.Text = "CASHIER ID :";
            // 
            // lblPass
            // 
            this.lblPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(67, 37);
            this.lblPass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(76, 13);
            this.lblPass.TabIndex = 12;
            this.lblPass.Text = "PASSWORD :";
            // 
            // nmrCashierNo
            // 
            this.nmrCashierNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.nmrCashierNo.Location = new System.Drawing.Point(212, 2);
            this.nmrCashierNo.Margin = new System.Windows.Forms.Padding(2);
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
            this.nmrCashierNo.Size = new System.Drawing.Size(130, 20);
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
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtPassword.Location = new System.Drawing.Point(212, 31);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.MaxLength = 10;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(130, 20);
            this.txtPassword.TabIndex = 14;
            // 
            // gbxFiscalMode
            // 
            this.gbxFiscalMode.Controls.Add(this.tableLayoutPanel2);
            this.gbxFiscalMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxFiscalMode.Location = new System.Drawing.Point(2, 2);
            this.gbxFiscalMode.Margin = new System.Windows.Forms.Padding(2);
            this.gbxFiscalMode.Name = "gbxFiscalMode";
            this.gbxFiscalMode.Padding = new System.Windows.Forms.Padding(2);
            this.gbxFiscalMode.Size = new System.Drawing.Size(587, 81);
            this.gbxFiscalMode.TabIndex = 21;
            this.gbxFiscalMode.TabStop = false;
            this.gbxFiscalMode.Text = "FISCAL OPERATIONS";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel2.Controls.Add(this.btnStartFM, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 15);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(583, 64);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnStartFM
            // 
            this.btnStartFM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartFM.Location = new System.Drawing.Point(2, 2);
            this.btnStartFM.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartFM.Name = "btnStartFM";
            this.btnStartFM.Size = new System.Drawing.Size(188, 60);
            this.btnStartFM.TabIndex = 7;
            this.btnStartFM.Text = "START FM";
            this.btnStartFM.UseVisualStyleBackColor = true;
            this.btnStartFM.Click += new System.EventHandler(this.btnStartFM_Click);
            // 
            // gbxStatusFuncs
            // 
            this.gbxStatusFuncs.Controls.Add(this.tableLayoutPanel3);
            this.gbxStatusFuncs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxStatusFuncs.Location = new System.Drawing.Point(2, 87);
            this.gbxStatusFuncs.Margin = new System.Windows.Forms.Padding(2);
            this.gbxStatusFuncs.Name = "gbxStatusFuncs";
            this.gbxStatusFuncs.Padding = new System.Windows.Forms.Padding(2);
            this.gbxStatusFuncs.Size = new System.Drawing.Size(587, 81);
            this.gbxStatusFuncs.TabIndex = 22;
            this.gbxStatusFuncs.TabStop = false;
            this.gbxStatusFuncs.Text = "STATUS INFO";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel3.Controls.Add(this.btnInterruptProcess, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnLastResponse, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnQueryStatus, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 15);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(583, 64);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btnInterruptProcess
            // 
            this.btnInterruptProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInterruptProcess.Location = new System.Drawing.Point(386, 2);
            this.btnInterruptProcess.Margin = new System.Windows.Forms.Padding(2);
            this.btnInterruptProcess.Name = "btnInterruptProcess";
            this.btnInterruptProcess.Size = new System.Drawing.Size(195, 60);
            this.btnInterruptProcess.TabIndex = 9;
            this.btnInterruptProcess.Text = "INTERRUPT PROCESS";
            this.btnInterruptProcess.UseVisualStyleBackColor = true;
            this.btnInterruptProcess.Click += new System.EventHandler(this.btnInterruptProcess_Click);
            // 
            // btnLastResponse
            // 
            this.btnLastResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLastResponse.Location = new System.Drawing.Point(194, 2);
            this.btnLastResponse.Margin = new System.Windows.Forms.Padding(2);
            this.btnLastResponse.Name = "btnLastResponse";
            this.btnLastResponse.Size = new System.Drawing.Size(188, 60);
            this.btnLastResponse.TabIndex = 8;
            this.btnLastResponse.Text = "LAST RESPONSE";
            this.btnLastResponse.UseVisualStyleBackColor = true;
            this.btnLastResponse.Click += new System.EventHandler(this.btnLastResponse_Click);
            // 
            // btnQueryStatus
            // 
            this.btnQueryStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQueryStatus.Location = new System.Drawing.Point(2, 2);
            this.btnQueryStatus.Margin = new System.Windows.Forms.Padding(2);
            this.btnQueryStatus.Name = "btnQueryStatus";
            this.btnQueryStatus.Size = new System.Drawing.Size(188, 60);
            this.btnQueryStatus.TabIndex = 7;
            this.btnQueryStatus.Text = "CHECK STATUS";
            this.btnQueryStatus.UseVisualStyleBackColor = true;
            this.btnQueryStatus.Click += new System.EventHandler(this.btnQueryStatus_Click);
            // 
            // UtililtyFuncsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UtililtyFuncsUC";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbxSpecialReceipt.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.grpPayInOut.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPayAmount)).EndInit();
            this.gbxCashier.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrCashierNo)).EndInit();
            this.gbxFiscalMode.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.gbxStatusFuncs.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
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
    }
}
