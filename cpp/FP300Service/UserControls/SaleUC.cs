using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace FP300Service.UserControls
{
    public enum AdjustmentType : sbyte
    {
        Fee,
        PercentFee,
        Discount,
        PercentDiscount
    }
    public class SaleUC : TestUC
    {
        private Button btnSale;
        private Button btnCloseReceipt;
        private Button btnVoidReceipt;
        private Button btnSubtotal;
        private Button btnPayment;
        private Label lblPayAmount;
        private ComboBox cbxPaymentType;
        private Label lblPayType;
        private Label lblAdjAmount;
        private Button btnAdjust;
        private CheckBox cbxPerc;
        private RadioButton rbtnFee;
        private RadioButton rbtnDiscount;
        private NumericUpDown nmrPrice;
        private Label lblQuantity;
        private NumericUpDown nmrQuantity;
        private Label lblPlu;
        private NumericUpDown nmrPlu;
        private Label lblVoidQtty;
        private NumericUpDown nmrVoidQtty;
        private Label lblVoidPlu;
        private NumericUpDown nmrVoidPlu;
        private Button btnVoidSale;
        private Button btnCorrect;
        private TextBox txtRemarkLine;
        private Button btnRemark;
        private NumericUpDown nmrPaymentAmount;
        private NumericUpDown nmrAdjAmount;
        private Label lblPayIndx;
        private ComboBox cbxSubPayments;
        private Button btnStartReceipt;


        private static TestUC saleForm = null;
        private static IBridge bridge = null;
        private CheckBox cbxSaveAndSale;
        private Label lblFCurrValue;
        private TextBox txtRcptBarcode;
        private Button btnRcptBarcode;
        private Label lblNFTotal;
        private NumericUpDown nmrInvoiceTotal;
        private TextBox txtTCKN_VKN;
        private Label lblInvSerial;
        private Button btnOpenDrawer;
        private TextBox txtPlate;
        private Label lblPlate;
        private Label label1;
        private DateTimePicker dtParkTime;
        private DateTimePicker dtParkDate;
        private CheckBox chbSlipCopy;
        private Button btnVoidPayment;
        private Label label2;
        private NumericUpDown nmrVoidPayIndex;
        private Button bntPrintJSONDoc;
        private TabControl tbcPayment;
        private TabPage tbpPay1;
        private TabPage tbpPayEFT;
        private Button btnEFTAuthorization;
        private Button btnCardQuery;
        private TabPage tbpVoidPay;
        private TabControl tbcSale;
        private TabPage tbpSale;
        private TabPage tbpVoidSale;
        private TabPage tbpAdj;
        private TabControl tbcFooter;
        private TabPage tbpNotes;
        private TabPage tbpExtra;
        private TabControl tbcStartDoc;
        private TabPage tbStrtRcpt;
        private TabPage tbStrtInvoice;
        private Button btnStartInvoice;
        private TabPage tbStrtPaidDocs;
        private Button btnPaidDoc;
        private TabPage tbpStartParking;
        private Button btnStartParkDoc;
        private Label lblEFTAmount;
        private NumericUpDown nmrEFTAmount;
        private Label lblCardNum;
        private Label lblInstallment;
        private NumericUpDown nmrInstallment;
        private TextBox txtCardNumber;
        private Label labelPaidDocType;
        private ComboBox comboBoxPaidDocuments;
        private NumericUpDown nmrDept;
        private Label lblDeptId;
        private Label lblBarcode;
        private TextBox txtBarcode;
        private Label lblAmount;
        private Label lblName;
        private TextBox txtName;
        private Panel pnlExtraPlufields;
        private Label lblDocTypeInv;
        private ComboBox cbxInvTypes;
        private CheckBox checkBoxForPrice;
        private Label lblWeighable;
        private CheckBox checkBoxWeighable;
        private Button btnRefreshCredit;


        public SaleUC()
            : base()
        {
            InitializeComponent();

            cbxPaymentType.Items.AddRange(Common.Payments);
            cbxPaymentType.SelectedIndex = 0;

            comboBoxPaidDocuments.Items.AddRange(Common.PaidDocTypes);
            comboBoxPaidDocuments.SelectedIndex = 0;

            cbxInvTypes.Items.AddRange(Common.InvDocTypes);
            cbxInvTypes.SelectedIndex = 0;

            nmrPrice.Enabled = false;
            lblAmount.Enabled = false;
            checkBoxForPrice.Checked = false;
        }

        private int LoadCreditData()
        {
            int successCount = 0;

            for (int i = 0; i < ProgramConfig.MAX_CREDIT_COUNT; i++)
            {
                try
                {
                    CPResponse response = new CPResponse(bridge.Printer.GetCreditInfo(i));

                    if (response.ErrorCode == 0)
                    {
                        String name = response.GetNextParam();
                        MainForm.SetCredit(i, name);
                        successCount++;
                    }
                }
                catch (TimeoutException)
                {
                    bridge.Log(FormMessage.TIMEOUT_ERROR);
                }
                catch
                {
                    bridge.Log(FormMessage.OPERATION_FAILS);
                }
            }
            return successCount;
        }

        private int LoadCurrency()
        {
            int successCount = 0;

            for (int i = 0; i < ProgramConfig.MAX_FCURRENCY_COUNT; i++)
            {
                try
                {
                    CPResponse response = new CPResponse(bridge.Printer.GetCurrencyInfo(i));

                    if (response.ErrorCode == 0)
                    {
                        FCurrency curr = new FCurrency();
                        curr.ID = i;
                        curr.Name = response.GetNextParam();
                        curr.Rate = decimal.Parse(response.GetNextParam());
                        MainForm.SetCurrency(curr.ID, curr);
                    }
                }
                catch
                {
                }
            }
            return successCount;
        }

        internal static TestUC Instance(IBridge iBridge)
        {
            if (saleForm == null)
            {
                bridge = iBridge;
                saleForm = new SaleUC();
            }
            return saleForm;
        }
        protected override void OnParentChanged(EventArgs e)
        {
            try
            {/*
                if (MainForm.Credits[0] == null)
                {
                    RefreshCredits();
                }

                if (MainForm.Currencies[0] == null)
                {
                    RefreshCurrencyList();
                }*/
            }
            catch (System.Exception ex)
            {
            	
            }
            base.OnParentChanged(e);
        }
        private void InitializeComponent()
        {
            this.cbxSaveAndSale = new System.Windows.Forms.CheckBox();
            this.nmrPrice = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.nmrQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblPlu = new System.Windows.Forms.Label();
            this.nmrPlu = new System.Windows.Forms.NumericUpDown();
            this.btnSale = new System.Windows.Forms.Button();
            this.dtParkTime = new System.Windows.Forms.DateTimePicker();
            this.dtParkDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPlate = new System.Windows.Forms.TextBox();
            this.lblPlate = new System.Windows.Forms.Label();
            this.txtTCKN_VKN = new System.Windows.Forms.TextBox();
            this.lblInvSerial = new System.Windows.Forms.Label();
            this.lblNFTotal = new System.Windows.Forms.Label();
            this.nmrInvoiceTotal = new System.Windows.Forms.NumericUpDown();
            this.txtRcptBarcode = new System.Windows.Forms.TextBox();
            this.btnRcptBarcode = new System.Windows.Forms.Button();
            this.txtRemarkLine = new System.Windows.Forms.TextBox();
            this.btnRemark = new System.Windows.Forms.Button();
            this.btnCorrect = new System.Windows.Forms.Button();
            this.lblVoidQtty = new System.Windows.Forms.Label();
            this.nmrVoidQtty = new System.Windows.Forms.NumericUpDown();
            this.lblVoidPlu = new System.Windows.Forms.Label();
            this.nmrVoidPlu = new System.Windows.Forms.NumericUpDown();
            this.btnVoidSale = new System.Windows.Forms.Button();
            this.lblFCurrValue = new System.Windows.Forms.Label();
            this.btnRefreshCredit = new System.Windows.Forms.Button();
            this.lblPayIndx = new System.Windows.Forms.Label();
            this.cbxSubPayments = new System.Windows.Forms.ComboBox();
            this.nmrPaymentAmount = new System.Windows.Forms.NumericUpDown();
            this.btnPayment = new System.Windows.Forms.Button();
            this.lblPayType = new System.Windows.Forms.Label();
            this.lblPayAmount = new System.Windows.Forms.Label();
            this.cbxPaymentType = new System.Windows.Forms.ComboBox();
            this.nmrAdjAmount = new System.Windows.Forms.NumericUpDown();
            this.rbtnFee = new System.Windows.Forms.RadioButton();
            this.rbtnDiscount = new System.Windows.Forms.RadioButton();
            this.cbxPerc = new System.Windows.Forms.CheckBox();
            this.btnAdjust = new System.Windows.Forms.Button();
            this.lblAdjAmount = new System.Windows.Forms.Label();
            this.btnSubtotal = new System.Windows.Forms.Button();
            this.btnVoidReceipt = new System.Windows.Forms.Button();
            this.btnCloseReceipt = new System.Windows.Forms.Button();
            this.btnStartReceipt = new System.Windows.Forms.Button();
            this.btnOpenDrawer = new System.Windows.Forms.Button();
            this.chbSlipCopy = new System.Windows.Forms.CheckBox();
            this.btnVoidPayment = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nmrVoidPayIndex = new System.Windows.Forms.NumericUpDown();
            this.bntPrintJSONDoc = new System.Windows.Forms.Button();
            this.tbcPayment = new System.Windows.Forms.TabControl();
            this.tbpPay1 = new System.Windows.Forms.TabPage();
            this.tbpPayEFT = new System.Windows.Forms.TabPage();
            this.lblEFTAmount = new System.Windows.Forms.Label();
            this.nmrEFTAmount = new System.Windows.Forms.NumericUpDown();
            this.lblCardNum = new System.Windows.Forms.Label();
            this.lblInstallment = new System.Windows.Forms.Label();
            this.nmrInstallment = new System.Windows.Forms.NumericUpDown();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.btnEFTAuthorization = new System.Windows.Forms.Button();
            this.btnCardQuery = new System.Windows.Forms.Button();
            this.tbpVoidPay = new System.Windows.Forms.TabPage();
            this.tbcSale = new System.Windows.Forms.TabControl();
            this.tbpSale = new System.Windows.Forms.TabPage();
            this.checkBoxForPrice = new System.Windows.Forms.CheckBox();
            this.pnlExtraPlufields = new System.Windows.Forms.Panel();
            this.lblWeighable = new System.Windows.Forms.Label();
            this.checkBoxWeighable = new System.Windows.Forms.CheckBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDeptId = new System.Windows.Forms.Label();
            this.nmrDept = new System.Windows.Forms.NumericUpDown();
            this.lblAmount = new System.Windows.Forms.Label();
            this.tbpVoidSale = new System.Windows.Forms.TabPage();
            this.tbpAdj = new System.Windows.Forms.TabPage();
            this.tbcFooter = new System.Windows.Forms.TabControl();
            this.tbpNotes = new System.Windows.Forms.TabPage();
            this.tbpExtra = new System.Windows.Forms.TabPage();
            this.tbcStartDoc = new System.Windows.Forms.TabControl();
            this.tbStrtRcpt = new System.Windows.Forms.TabPage();
            this.tbStrtInvoice = new System.Windows.Forms.TabPage();
            this.lblDocTypeInv = new System.Windows.Forms.Label();
            this.cbxInvTypes = new System.Windows.Forms.ComboBox();
            this.btnStartInvoice = new System.Windows.Forms.Button();
            this.tbStrtPaidDocs = new System.Windows.Forms.TabPage();
            this.labelPaidDocType = new System.Windows.Forms.Label();
            this.comboBoxPaidDocuments = new System.Windows.Forms.ComboBox();
            this.btnPaidDoc = new System.Windows.Forms.Button();
            this.tbpStartParking = new System.Windows.Forms.TabPage();
            this.btnStartParkDoc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPlu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrInvoiceTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrVoidQtty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrVoidPlu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPaymentAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrAdjAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrVoidPayIndex)).BeginInit();
            this.tbcPayment.SuspendLayout();
            this.tbpPay1.SuspendLayout();
            this.tbpPayEFT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrEFTAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrInstallment)).BeginInit();
            this.tbpVoidPay.SuspendLayout();
            this.tbcSale.SuspendLayout();
            this.tbpSale.SuspendLayout();
            this.pnlExtraPlufields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrDept)).BeginInit();
            this.tbpVoidSale.SuspendLayout();
            this.tbpAdj.SuspendLayout();
            this.tbcFooter.SuspendLayout();
            this.tbpNotes.SuspendLayout();
            this.tbpExtra.SuspendLayout();
            this.tbcStartDoc.SuspendLayout();
            this.tbStrtRcpt.SuspendLayout();
            this.tbStrtInvoice.SuspendLayout();
            this.tbStrtPaidDocs.SuspendLayout();
            this.tbpStartParking.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxSaveAndSale
            // 
            this.cbxSaveAndSale.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxSaveAndSale.Location = new System.Drawing.Point(272, 2);
            this.cbxSaveAndSale.Margin = new System.Windows.Forms.Padding(2);
            this.cbxSaveAndSale.Name = "cbxSaveAndSale";
            this.cbxSaveAndSale.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbxSaveAndSale.Size = new System.Drawing.Size(140, 17);
            this.cbxSaveAndSale.TabIndex = 20;
            this.cbxSaveAndSale.Text = "SAVE & SALE";
            this.cbxSaveAndSale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxSaveAndSale.UseVisualStyleBackColor = true;
            this.cbxSaveAndSale.CheckedChanged += new System.EventHandler(this.cbxSaveAndSale_CheckedChanged);
            // 
            // nmrPrice
            // 
            this.nmrPrice.DecimalPlaces = 2;
            this.nmrPrice.Location = new System.Drawing.Point(184, 66);
            this.nmrPrice.Margin = new System.Windows.Forms.Padding(2);
            this.nmrPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nmrPrice.Name = "nmrPrice";
            this.nmrPrice.Size = new System.Drawing.Size(62, 20);
            this.nmrPrice.TabIndex = 19;
            this.nmrPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(118, 43);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(65, 13);
            this.lblQuantity.TabIndex = 16;
            this.lblQuantity.Text = "QUANTITY:";
            // 
            // nmrQuantity
            // 
            this.nmrQuantity.DecimalPlaces = 3;
            this.nmrQuantity.Location = new System.Drawing.Point(185, 37);
            this.nmrQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.nmrQuantity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nmrQuantity.Name = "nmrQuantity";
            this.nmrQuantity.Size = new System.Drawing.Size(62, 20);
            this.nmrQuantity.TabIndex = 15;
            this.nmrQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPlu
            // 
            this.lblPlu.AutoSize = true;
            this.lblPlu.Location = new System.Drawing.Point(134, 13);
            this.lblPlu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlu.Name = "lblPlu";
            this.lblPlu.Size = new System.Drawing.Size(31, 13);
            this.lblPlu.TabIndex = 14;
            this.lblPlu.Text = "PLU:";
            // 
            // nmrPlu
            // 
            this.nmrPlu.Location = new System.Drawing.Point(185, 6);
            this.nmrPlu.Margin = new System.Windows.Forms.Padding(2);
            this.nmrPlu.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.nmrPlu.Name = "nmrPlu";
            this.nmrPlu.Size = new System.Drawing.Size(62, 20);
            this.nmrPlu.TabIndex = 3;
            this.nmrPlu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrPlu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnSale
            // 
            this.btnSale.Location = new System.Drawing.Point(4, 20);
            this.btnSale.Margin = new System.Windows.Forms.Padding(2);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(110, 37);
            this.btnSale.TabIndex = 2;
            this.btnSale.Text = "SALE";
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Click += new System.EventHandler(this.btnSaleSample_Click);
            // 
            // dtParkTime
            // 
            this.dtParkTime.CustomFormat = "HH:mm";
            this.dtParkTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtParkTime.Location = new System.Drawing.Point(341, 44);
            this.dtParkTime.Margin = new System.Windows.Forms.Padding(2);
            this.dtParkTime.Name = "dtParkTime";
            this.dtParkTime.ShowUpDown = true;
            this.dtParkTime.Size = new System.Drawing.Size(56, 20);
            this.dtParkTime.TabIndex = 37;
            // 
            // dtParkDate
            // 
            this.dtParkDate.CustomFormat = "dd-MM-yyyy";
            this.dtParkDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtParkDate.Location = new System.Drawing.Point(243, 44);
            this.dtParkDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtParkDate.Name = "dtParkDate";
            this.dtParkDate.Size = new System.Drawing.Size(95, 20);
            this.dtParkDate.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "ENTRY TIME :";
            // 
            // txtPlate
            // 
            this.txtPlate.Location = new System.Drawing.Point(185, 12);
            this.txtPlate.Margin = new System.Windows.Forms.Padding(2);
            this.txtPlate.MaxLength = 11;
            this.txtPlate.Name = "txtPlate";
            this.txtPlate.Size = new System.Drawing.Size(87, 20);
            this.txtPlate.TabIndex = 29;
            this.txtPlate.Text = "34 FP 300";
            // 
            // lblPlate
            // 
            this.lblPlate.AutoSize = true;
            this.lblPlate.Location = new System.Drawing.Point(142, 16);
            this.lblPlate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlate.Name = "lblPlate";
            this.lblPlate.Size = new System.Drawing.Size(41, 13);
            this.lblPlate.TabIndex = 28;
            this.lblPlate.Text = "PLATE";
            // 
            // txtTCKN_VKN
            // 
            this.txtTCKN_VKN.Location = new System.Drawing.Point(205, 16);
            this.txtTCKN_VKN.Margin = new System.Windows.Forms.Padding(2);
            this.txtTCKN_VKN.MaxLength = 11;
            this.txtTCKN_VKN.Name = "txtTCKN_VKN";
            this.txtTCKN_VKN.Size = new System.Drawing.Size(87, 20);
            this.txtTCKN_VKN.TabIndex = 26;
            this.txtTCKN_VKN.Text = "1234567890";
            // 
            // lblInvSerial
            // 
            this.lblInvSerial.AutoSize = true;
            this.lblInvSerial.Location = new System.Drawing.Point(136, 20);
            this.lblInvSerial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInvSerial.Name = "lblInvSerial";
            this.lblInvSerial.Size = new System.Drawing.Size(69, 13);
            this.lblInvSerial.TabIndex = 25;
            this.lblInvSerial.Text = "TCKN / VKN";
            // 
            // lblNFTotal
            // 
            this.lblNFTotal.AutoSize = true;
            this.lblNFTotal.Location = new System.Drawing.Point(142, 16);
            this.lblNFTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNFTotal.Name = "lblNFTotal";
            this.lblNFTotal.Size = new System.Drawing.Size(74, 13);
            this.lblNFTotal.TabIndex = 10;
            this.lblNFTotal.Text = "DOC TOTAL :";
            // 
            // nmrInvoiceTotal
            // 
            this.nmrInvoiceTotal.DecimalPlaces = 2;
            this.nmrInvoiceTotal.Location = new System.Drawing.Point(226, 13);
            this.nmrInvoiceTotal.Margin = new System.Windows.Forms.Padding(2);
            this.nmrInvoiceTotal.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            131072});
            this.nmrInvoiceTotal.Name = "nmrInvoiceTotal";
            this.nmrInvoiceTotal.Size = new System.Drawing.Size(62, 20);
            this.nmrInvoiceTotal.TabIndex = 9;
            this.nmrInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrInvoiceTotal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtRcptBarcode
            // 
            this.txtRcptBarcode.Location = new System.Drawing.Point(155, 39);
            this.txtRcptBarcode.Margin = new System.Windows.Forms.Padding(2);
            this.txtRcptBarcode.MaxLength = 25;
            this.txtRcptBarcode.Name = "txtRcptBarcode";
            this.txtRcptBarcode.Size = new System.Drawing.Size(226, 20);
            this.txtRcptBarcode.TabIndex = 12;
            // 
            // btnRcptBarcode
            // 
            this.btnRcptBarcode.Location = new System.Drawing.Point(8, 36);
            this.btnRcptBarcode.Margin = new System.Windows.Forms.Padding(2);
            this.btnRcptBarcode.Name = "btnRcptBarcode";
            this.btnRcptBarcode.Size = new System.Drawing.Size(110, 23);
            this.btnRcptBarcode.TabIndex = 10;
            this.btnRcptBarcode.Text = "BARCODE";
            this.btnRcptBarcode.UseVisualStyleBackColor = true;
            this.btnRcptBarcode.Click += new System.EventHandler(this.btnRcptBarcode_Click);
            // 
            // txtRemarkLine
            // 
            this.txtRemarkLine.Location = new System.Drawing.Point(155, 14);
            this.txtRemarkLine.Margin = new System.Windows.Forms.Padding(2);
            this.txtRemarkLine.MaxLength = 45;
            this.txtRemarkLine.Name = "txtRemarkLine";
            this.txtRemarkLine.Size = new System.Drawing.Size(226, 20);
            this.txtRemarkLine.TabIndex = 9;
            // 
            // btnRemark
            // 
            this.btnRemark.Location = new System.Drawing.Point(8, 12);
            this.btnRemark.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemark.Name = "btnRemark";
            this.btnRemark.Size = new System.Drawing.Size(110, 23);
            this.btnRemark.TabIndex = 6;
            this.btnRemark.Text = "REMARK";
            this.btnRemark.UseVisualStyleBackColor = true;
            this.btnRemark.Click += new System.EventHandler(this.btnRemark_Click);
            // 
            // btnCorrect
            // 
            this.btnCorrect.Location = new System.Drawing.Point(477, 250);
            this.btnCorrect.Margin = new System.Windows.Forms.Padding(2);
            this.btnCorrect.Name = "btnCorrect";
            this.btnCorrect.Size = new System.Drawing.Size(110, 35);
            this.btnCorrect.TabIndex = 19;
            this.btnCorrect.Text = "CORRECT";
            this.btnCorrect.UseVisualStyleBackColor = true;
            this.btnCorrect.Click += new System.EventHandler(this.btnCorrect_Click);
            // 
            // lblVoidQtty
            // 
            this.lblVoidQtty.AutoSize = true;
            this.lblVoidQtty.Location = new System.Drawing.Point(246, 16);
            this.lblVoidQtty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVoidQtty.Name = "lblVoidQtty";
            this.lblVoidQtty.Size = new System.Drawing.Size(94, 13);
            this.lblVoidQtty.TabIndex = 16;
            this.lblVoidQtty.Text = "VOID QUANTITY:";
            // 
            // nmrVoidQtty
            // 
            this.nmrVoidQtty.DecimalPlaces = 3;
            this.nmrVoidQtty.Location = new System.Drawing.Point(249, 33);
            this.nmrVoidQtty.Margin = new System.Windows.Forms.Padding(2);
            this.nmrVoidQtty.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nmrVoidQtty.Name = "nmrVoidQtty";
            this.nmrVoidQtty.Size = new System.Drawing.Size(62, 20);
            this.nmrVoidQtty.TabIndex = 15;
            this.nmrVoidQtty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrVoidQtty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblVoidPlu
            // 
            this.lblVoidPlu.AutoSize = true;
            this.lblVoidPlu.Location = new System.Drawing.Point(171, 16);
            this.lblVoidPlu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVoidPlu.Name = "lblVoidPlu";
            this.lblVoidPlu.Size = new System.Drawing.Size(31, 13);
            this.lblVoidPlu.TabIndex = 14;
            this.lblVoidPlu.Text = "PLU:";
            // 
            // nmrVoidPlu
            // 
            this.nmrVoidPlu.Location = new System.Drawing.Point(172, 33);
            this.nmrVoidPlu.Margin = new System.Windows.Forms.Padding(2);
            this.nmrVoidPlu.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.nmrVoidPlu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrVoidPlu.Name = "nmrVoidPlu";
            this.nmrVoidPlu.Size = new System.Drawing.Size(62, 20);
            this.nmrVoidPlu.TabIndex = 3;
            this.nmrVoidPlu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrVoidPlu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnVoidSale
            // 
            this.btnVoidSale.Location = new System.Drawing.Point(4, 24);
            this.btnVoidSale.Margin = new System.Windows.Forms.Padding(2);
            this.btnVoidSale.Name = "btnVoidSale";
            this.btnVoidSale.Size = new System.Drawing.Size(110, 37);
            this.btnVoidSale.TabIndex = 2;
            this.btnVoidSale.Text = "VOID SALE";
            this.btnVoidSale.UseVisualStyleBackColor = true;
            this.btnVoidSale.Click += new System.EventHandler(this.btnVoidSale_Click);
            // 
            // lblFCurrValue
            // 
            this.lblFCurrValue.AutoSize = true;
            this.lblFCurrValue.Location = new System.Drawing.Point(151, 67);
            this.lblFCurrValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFCurrValue.Name = "lblFCurrValue";
            this.lblFCurrValue.Size = new System.Drawing.Size(0, 13);
            this.lblFCurrValue.TabIndex = 20;
            // 
            // btnRefreshCredit
            // 
            this.btnRefreshCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshCredit.Image = global::FP300Service.Properties.Resources.refresh;
            this.btnRefreshCredit.Location = new System.Drawing.Point(422, 34);
            this.btnRefreshCredit.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefreshCredit.Name = "btnRefreshCredit";
            this.btnRefreshCredit.Size = new System.Drawing.Size(30, 37);
            this.btnRefreshCredit.TabIndex = 19;
            this.btnRefreshCredit.UseVisualStyleBackColor = true;
            this.btnRefreshCredit.Visible = false;
            this.btnRefreshCredit.Click += new System.EventHandler(this.btnRefreshCredit_Click);
            // 
            // lblPayIndx
            // 
            this.lblPayIndx.AutoSize = true;
            this.lblPayIndx.Location = new System.Drawing.Point(291, 24);
            this.lblPayIndx.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPayIndx.Name = "lblPayIndx";
            this.lblPayIndx.Size = new System.Drawing.Size(0, 13);
            this.lblPayIndx.TabIndex = 18;
            // 
            // cbxSubPayments
            // 
            this.cbxSubPayments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSubPayments.FormattingEnabled = true;
            this.cbxSubPayments.Location = new System.Drawing.Point(292, 44);
            this.cbxSubPayments.Margin = new System.Windows.Forms.Padding(2);
            this.cbxSubPayments.Name = "cbxSubPayments";
            this.cbxSubPayments.Size = new System.Drawing.Size(129, 21);
            this.cbxSubPayments.TabIndex = 17;
            this.cbxSubPayments.SelectedIndexChanged += new System.EventHandler(this.cbxSubPayments_SelectedIndexChanged);
            // 
            // nmrPaymentAmount
            // 
            this.nmrPaymentAmount.DecimalPlaces = 2;
            this.nmrPaymentAmount.Location = new System.Drawing.Point(248, 10);
            this.nmrPaymentAmount.Margin = new System.Windows.Forms.Padding(2);
            this.nmrPaymentAmount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nmrPaymentAmount.Name = "nmrPaymentAmount";
            this.nmrPaymentAmount.Size = new System.Drawing.Size(62, 20);
            this.nmrPaymentAmount.TabIndex = 16;
            this.nmrPaymentAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrPaymentAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrPaymentAmount.ValueChanged += new System.EventHandler(this.nmrPaymentAmount_ValueChanged);
            // 
            // btnPayment
            // 
            this.btnPayment.Location = new System.Drawing.Point(4, 27);
            this.btnPayment.Margin = new System.Windows.Forms.Padding(2);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(110, 35);
            this.btnPayment.TabIndex = 6;
            this.btnPayment.Text = "PAYMENT";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // lblPayType
            // 
            this.lblPayType.AutoSize = true;
            this.lblPayType.Location = new System.Drawing.Point(124, 49);
            this.lblPayType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPayType.Name = "lblPayType";
            this.lblPayType.Size = new System.Drawing.Size(90, 13);
            this.lblPayType.TabIndex = 10;
            this.lblPayType.Text = "PAYMENT TYPE";
            // 
            // lblPayAmount
            // 
            this.lblPayAmount.AutoSize = true;
            this.lblPayAmount.Location = new System.Drawing.Point(124, 12);
            this.lblPayAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPayAmount.Name = "lblPayAmount";
            this.lblPayAmount.Size = new System.Drawing.Size(109, 13);
            this.lblPayAmount.TabIndex = 8;
            this.lblPayAmount.Text = "PAYMENT AMOUNT";
            // 
            // cbxPaymentType
            // 
            this.cbxPaymentType.FormattingEnabled = true;
            this.cbxPaymentType.Location = new System.Drawing.Point(218, 44);
            this.cbxPaymentType.Margin = new System.Windows.Forms.Padding(2);
            this.cbxPaymentType.Name = "cbxPaymentType";
            this.cbxPaymentType.Size = new System.Drawing.Size(70, 21);
            this.cbxPaymentType.TabIndex = 9;
            this.cbxPaymentType.SelectedIndexChanged += new System.EventHandler(this.cbxPaymentType_SelectedIndexChanged);
            // 
            // nmrAdjAmount
            // 
            this.nmrAdjAmount.DecimalPlaces = 2;
            this.nmrAdjAmount.Location = new System.Drawing.Point(154, 36);
            this.nmrAdjAmount.Margin = new System.Windows.Forms.Padding(2);
            this.nmrAdjAmount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nmrAdjAmount.Name = "nmrAdjAmount";
            this.nmrAdjAmount.Size = new System.Drawing.Size(62, 20);
            this.nmrAdjAmount.TabIndex = 17;
            this.nmrAdjAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrAdjAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rbtnFee
            // 
            this.rbtnFee.AutoSize = true;
            this.rbtnFee.Location = new System.Drawing.Point(345, 46);
            this.rbtnFee.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnFee.Name = "rbtnFee";
            this.rbtnFee.Size = new System.Drawing.Size(45, 17);
            this.rbtnFee.TabIndex = 16;
            this.rbtnFee.Text = "FEE";
            this.rbtnFee.UseVisualStyleBackColor = true;
            // 
            // rbtnDiscount
            // 
            this.rbtnDiscount.AutoSize = true;
            this.rbtnDiscount.Checked = true;
            this.rbtnDiscount.Location = new System.Drawing.Point(345, 22);
            this.rbtnDiscount.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnDiscount.Name = "rbtnDiscount";
            this.rbtnDiscount.Size = new System.Drawing.Size(81, 17);
            this.rbtnDiscount.TabIndex = 15;
            this.rbtnDiscount.TabStop = true;
            this.rbtnDiscount.Text = "DISCOUNT";
            this.rbtnDiscount.UseVisualStyleBackColor = true;
            // 
            // cbxPerc
            // 
            this.cbxPerc.AutoSize = true;
            this.cbxPerc.Location = new System.Drawing.Point(228, 36);
            this.cbxPerc.Margin = new System.Windows.Forms.Padding(2);
            this.cbxPerc.Name = "cbxPerc";
            this.cbxPerc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbxPerc.Size = new System.Drawing.Size(113, 17);
            this.cbxPerc.TabIndex = 14;
            this.cbxPerc.Text = "PERCENTAGE(%)";
            this.cbxPerc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxPerc.UseVisualStyleBackColor = true;
            this.cbxPerc.CheckedChanged += new System.EventHandler(this.cbxPerc_CheckedChanged);
            // 
            // btnAdjust
            // 
            this.btnAdjust.Location = new System.Drawing.Point(4, 26);
            this.btnAdjust.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdjust.Name = "btnAdjust";
            this.btnAdjust.Size = new System.Drawing.Size(110, 35);
            this.btnAdjust.TabIndex = 11;
            this.btnAdjust.Text = "ADJUST";
            this.btnAdjust.UseVisualStyleBackColor = true;
            this.btnAdjust.Click += new System.EventHandler(this.btnAdjust_Click);
            // 
            // lblAdjAmount
            // 
            this.lblAdjAmount.AutoSize = true;
            this.lblAdjAmount.Location = new System.Drawing.Point(142, 19);
            this.lblAdjAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAdjAmount.Name = "lblAdjAmount";
            this.lblAdjAmount.Size = new System.Drawing.Size(80, 13);
            this.lblAdjAmount.TabIndex = 13;
            this.lblAdjAmount.Text = "ADJ. AMOUNT";
            // 
            // btnSubtotal
            // 
            this.btnSubtotal.Location = new System.Drawing.Point(477, 210);
            this.btnSubtotal.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubtotal.Name = "btnSubtotal";
            this.btnSubtotal.Size = new System.Drawing.Size(110, 35);
            this.btnSubtotal.TabIndex = 5;
            this.btnSubtotal.Text = "SUBTOTAL";
            this.btnSubtotal.UseVisualStyleBackColor = true;
            this.btnSubtotal.Click += new System.EventHandler(this.btnSubtotal_Click);
            // 
            // btnVoidReceipt
            // 
            this.btnVoidReceipt.Location = new System.Drawing.Point(477, 339);
            this.btnVoidReceipt.Margin = new System.Windows.Forms.Padding(2);
            this.btnVoidReceipt.Name = "btnVoidReceipt";
            this.btnVoidReceipt.Size = new System.Drawing.Size(110, 35);
            this.btnVoidReceipt.TabIndex = 4;
            this.btnVoidReceipt.Text = "VOID DOCUMENT";
            this.btnVoidReceipt.UseVisualStyleBackColor = true;
            this.btnVoidReceipt.Click += new System.EventHandler(this.btnVoidReceipt_Click);
            // 
            // btnCloseReceipt
            // 
            this.btnCloseReceipt.Location = new System.Drawing.Point(477, 299);
            this.btnCloseReceipt.Margin = new System.Windows.Forms.Padding(2);
            this.btnCloseReceipt.Name = "btnCloseReceipt";
            this.btnCloseReceipt.Size = new System.Drawing.Size(110, 35);
            this.btnCloseReceipt.TabIndex = 3;
            this.btnCloseReceipt.Text = "CLOSE DOCUMENT";
            this.btnCloseReceipt.UseVisualStyleBackColor = true;
            this.btnCloseReceipt.Click += new System.EventHandler(this.btnCloseReceipt_Click);
            // 
            // btnStartReceipt
            // 
            this.btnStartReceipt.Location = new System.Drawing.Point(2, 4);
            this.btnStartReceipt.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartReceipt.Name = "btnStartReceipt";
            this.btnStartReceipt.Size = new System.Drawing.Size(110, 37);
            this.btnStartReceipt.TabIndex = 1;
            this.btnStartReceipt.Text = "START DOCUMENT";
            this.btnStartReceipt.UseVisualStyleBackColor = true;
            this.btnStartReceipt.Click += new System.EventHandler(this.btnStartReceipt_Click);
            // 
            // btnOpenDrawer
            // 
            this.btnOpenDrawer.Location = new System.Drawing.Point(4, 20);
            this.btnOpenDrawer.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenDrawer.Name = "btnOpenDrawer";
            this.btnOpenDrawer.Size = new System.Drawing.Size(110, 30);
            this.btnOpenDrawer.TabIndex = 22;
            this.btnOpenDrawer.Text = "OPEN DRAWER";
            this.btnOpenDrawer.UseVisualStyleBackColor = true;
            this.btnOpenDrawer.Click += new System.EventHandler(this.btnOpenDrawer_Click);
            // 
            // chbSlipCopy
            // 
            this.chbSlipCopy.AutoSize = true;
            this.chbSlipCopy.Location = new System.Drawing.Point(338, 14);
            this.chbSlipCopy.Margin = new System.Windows.Forms.Padding(2);
            this.chbSlipCopy.Name = "chbSlipCopy";
            this.chbSlipCopy.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chbSlipCopy.Size = new System.Drawing.Size(81, 17);
            this.chbSlipCopy.TabIndex = 21;
            this.chbSlipCopy.Text = "SLIP COPY";
            this.chbSlipCopy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbSlipCopy.UseVisualStyleBackColor = true;
            // 
            // btnVoidPayment
            // 
            this.btnVoidPayment.Location = new System.Drawing.Point(4, 22);
            this.btnVoidPayment.Margin = new System.Windows.Forms.Padding(2);
            this.btnVoidPayment.Name = "btnVoidPayment";
            this.btnVoidPayment.Size = new System.Drawing.Size(110, 35);
            this.btnVoidPayment.TabIndex = 23;
            this.btnVoidPayment.Text = "VOID PAYMENT";
            this.btnVoidPayment.UseVisualStyleBackColor = true;
            this.btnVoidPayment.Click += new System.EventHandler(this.btnVoidPayment_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "PAYMENT INDEX:";
            // 
            // nmrVoidPayIndex
            // 
            this.nmrVoidPayIndex.Location = new System.Drawing.Point(248, 32);
            this.nmrVoidPayIndex.Margin = new System.Windows.Forms.Padding(2);
            this.nmrVoidPayIndex.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.nmrVoidPayIndex.Name = "nmrVoidPayIndex";
            this.nmrVoidPayIndex.Size = new System.Drawing.Size(40, 20);
            this.nmrVoidPayIndex.TabIndex = 24;
            this.nmrVoidPayIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bntPrintJSONDoc
            // 
            this.bntPrintJSONDoc.Location = new System.Drawing.Point(477, 170);
            this.bntPrintJSONDoc.Margin = new System.Windows.Forms.Padding(2);
            this.bntPrintJSONDoc.Name = "bntPrintJSONDoc";
            this.bntPrintJSONDoc.Size = new System.Drawing.Size(110, 37);
            this.bntPrintJSONDoc.TabIndex = 26;
            this.bntPrintJSONDoc.Text = "PRINT JSON";
            this.bntPrintJSONDoc.UseVisualStyleBackColor = true;
            this.bntPrintJSONDoc.Click += new System.EventHandler(this.bntPrintJSONDoc_Click);
            // 
            // tbcPayment
            // 
            this.tbcPayment.Controls.Add(this.tbpPay1);
            this.tbcPayment.Controls.Add(this.tbpPayEFT);
            this.tbcPayment.Controls.Add(this.tbpVoidPay);
            this.tbcPayment.Location = new System.Drawing.Point(10, 287);
            this.tbcPayment.Margin = new System.Windows.Forms.Padding(2);
            this.tbcPayment.Name = "tbcPayment";
            this.tbcPayment.SelectedIndex = 0;
            this.tbcPayment.Size = new System.Drawing.Size(466, 109);
            this.tbcPayment.TabIndex = 27;
            // 
            // tbpPay1
            // 
            this.tbpPay1.Controls.Add(this.lblFCurrValue);
            this.tbpPay1.Controls.Add(this.btnPayment);
            this.tbpPay1.Controls.Add(this.btnRefreshCredit);
            this.tbpPay1.Controls.Add(this.cbxPaymentType);
            this.tbpPay1.Controls.Add(this.lblPayIndx);
            this.tbpPay1.Controls.Add(this.lblPayAmount);
            this.tbpPay1.Controls.Add(this.cbxSubPayments);
            this.tbpPay1.Controls.Add(this.lblPayType);
            this.tbpPay1.Controls.Add(this.nmrPaymentAmount);
            this.tbpPay1.Location = new System.Drawing.Point(4, 22);
            this.tbpPay1.Margin = new System.Windows.Forms.Padding(2);
            this.tbpPay1.Name = "tbpPay1";
            this.tbpPay1.Padding = new System.Windows.Forms.Padding(2);
            this.tbpPay1.Size = new System.Drawing.Size(458, 83);
            this.tbpPay1.TabIndex = 0;
            this.tbpPay1.Text = "CASH PAYMENTS";
            this.tbpPay1.UseVisualStyleBackColor = true;
            // 
            // tbpPayEFT
            // 
            this.tbpPayEFT.Controls.Add(this.lblEFTAmount);
            this.tbpPayEFT.Controls.Add(this.nmrEFTAmount);
            this.tbpPayEFT.Controls.Add(this.lblCardNum);
            this.tbpPayEFT.Controls.Add(this.lblInstallment);
            this.tbpPayEFT.Controls.Add(this.nmrInstallment);
            this.tbpPayEFT.Controls.Add(this.txtCardNumber);
            this.tbpPayEFT.Controls.Add(this.btnEFTAuthorization);
            this.tbpPayEFT.Controls.Add(this.btnCardQuery);
            this.tbpPayEFT.Controls.Add(this.chbSlipCopy);
            this.tbpPayEFT.Location = new System.Drawing.Point(4, 22);
            this.tbpPayEFT.Margin = new System.Windows.Forms.Padding(2);
            this.tbpPayEFT.Name = "tbpPayEFT";
            this.tbpPayEFT.Padding = new System.Windows.Forms.Padding(2);
            this.tbpPayEFT.Size = new System.Drawing.Size(458, 83);
            this.tbpPayEFT.TabIndex = 1;
            this.tbpPayEFT.Text = "EFT PAYMENT";
            this.tbpPayEFT.UseVisualStyleBackColor = true;
            // 
            // lblEFTAmount
            // 
            this.lblEFTAmount.AutoSize = true;
            this.lblEFTAmount.Location = new System.Drawing.Point(132, 66);
            this.lblEFTAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEFTAmount.Name = "lblEFTAmount";
            this.lblEFTAmount.Size = new System.Drawing.Size(109, 13);
            this.lblEFTAmount.TabIndex = 29;
            this.lblEFTAmount.Text = "PAYMENT AMOUNT";
            // 
            // nmrEFTAmount
            // 
            this.nmrEFTAmount.DecimalPlaces = 2;
            this.nmrEFTAmount.Location = new System.Drawing.Point(248, 61);
            this.nmrEFTAmount.Margin = new System.Windows.Forms.Padding(2);
            this.nmrEFTAmount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nmrEFTAmount.Name = "nmrEFTAmount";
            this.nmrEFTAmount.Size = new System.Drawing.Size(62, 20);
            this.nmrEFTAmount.TabIndex = 30;
            this.nmrEFTAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrEFTAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCardNum
            // 
            this.lblCardNum.AutoSize = true;
            this.lblCardNum.Location = new System.Drawing.Point(136, 14);
            this.lblCardNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCardNum.Name = "lblCardNum";
            this.lblCardNum.Size = new System.Drawing.Size(90, 13);
            this.lblCardNum.TabIndex = 28;
            this.lblCardNum.Text = "CARD NUMBER:";
            // 
            // lblInstallment
            // 
            this.lblInstallment.AutoSize = true;
            this.lblInstallment.Location = new System.Drawing.Point(136, 39);
            this.lblInstallment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInstallment.Name = "lblInstallment";
            this.lblInstallment.Size = new System.Drawing.Size(85, 13);
            this.lblInstallment.TabIndex = 27;
            this.lblInstallment.Text = "INSTALLMENT:";
            // 
            // nmrInstallment
            // 
            this.nmrInstallment.Location = new System.Drawing.Point(270, 36);
            this.nmrInstallment.Margin = new System.Windows.Forms.Padding(2);
            this.nmrInstallment.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.nmrInstallment.Name = "nmrInstallment";
            this.nmrInstallment.Size = new System.Drawing.Size(40, 20);
            this.nmrInstallment.TabIndex = 26;
            this.nmrInstallment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.Location = new System.Drawing.Point(242, 12);
            this.txtCardNumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtCardNumber.MaxLength = 6;
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(68, 20);
            this.txtCardNumber.TabIndex = 22;
            // 
            // btnEFTAuthorization
            // 
            this.btnEFTAuthorization.Location = new System.Drawing.Point(4, 44);
            this.btnEFTAuthorization.Margin = new System.Windows.Forms.Padding(2);
            this.btnEFTAuthorization.Name = "btnEFTAuthorization";
            this.btnEFTAuthorization.Size = new System.Drawing.Size(110, 35);
            this.btnEFTAuthorization.TabIndex = 5;
            this.btnEFTAuthorization.Text = "GET EFT PAYMENT";
            this.btnEFTAuthorization.UseVisualStyleBackColor = true;
            this.btnEFTAuthorization.Click += new System.EventHandler(this.btnEFTAuthorization_Click);
            // 
            // btnCardQuery
            // 
            this.btnCardQuery.Location = new System.Drawing.Point(2, 4);
            this.btnCardQuery.Margin = new System.Windows.Forms.Padding(2);
            this.btnCardQuery.Name = "btnCardQuery";
            this.btnCardQuery.Size = new System.Drawing.Size(110, 35);
            this.btnCardQuery.TabIndex = 4;
            this.btnCardQuery.Text = "CHECK CARD";
            this.btnCardQuery.UseVisualStyleBackColor = true;
            this.btnCardQuery.Click += new System.EventHandler(this.btnCardQuery_Click);
            // 
            // tbpVoidPay
            // 
            this.tbpVoidPay.Controls.Add(this.btnVoidPayment);
            this.tbpVoidPay.Controls.Add(this.label2);
            this.tbpVoidPay.Controls.Add(this.nmrVoidPayIndex);
            this.tbpVoidPay.Location = new System.Drawing.Point(4, 22);
            this.tbpVoidPay.Margin = new System.Windows.Forms.Padding(2);
            this.tbpVoidPay.Name = "tbpVoidPay";
            this.tbpVoidPay.Padding = new System.Windows.Forms.Padding(2);
            this.tbpVoidPay.Size = new System.Drawing.Size(458, 83);
            this.tbpVoidPay.TabIndex = 2;
            this.tbpVoidPay.Text = "VOID PAYMENT";
            this.tbpVoidPay.UseVisualStyleBackColor = true;
            // 
            // tbcSale
            // 
            this.tbcSale.Controls.Add(this.tbpSale);
            this.tbcSale.Controls.Add(this.tbpVoidSale);
            this.tbcSale.Controls.Add(this.tbpAdj);
            this.tbcSale.Location = new System.Drawing.Point(8, 145);
            this.tbcSale.Margin = new System.Windows.Forms.Padding(2);
            this.tbcSale.Name = "tbcSale";
            this.tbcSale.SelectedIndex = 0;
            this.tbcSale.Size = new System.Drawing.Size(464, 140);
            this.tbcSale.TabIndex = 28;
            // 
            // tbpSale
            // 
            this.tbpSale.Controls.Add(this.checkBoxForPrice);
            this.tbpSale.Controls.Add(this.pnlExtraPlufields);
            this.tbpSale.Controls.Add(this.lblAmount);
            this.tbpSale.Controls.Add(this.cbxSaveAndSale);
            this.tbpSale.Controls.Add(this.btnSale);
            this.tbpSale.Controls.Add(this.nmrPrice);
            this.tbpSale.Controls.Add(this.nmrPlu);
            this.tbpSale.Controls.Add(this.lblQuantity);
            this.tbpSale.Controls.Add(this.lblPlu);
            this.tbpSale.Controls.Add(this.nmrQuantity);
            this.tbpSale.Location = new System.Drawing.Point(4, 22);
            this.tbpSale.Margin = new System.Windows.Forms.Padding(2);
            this.tbpSale.Name = "tbpSale";
            this.tbpSale.Padding = new System.Windows.Forms.Padding(2);
            this.tbpSale.Size = new System.Drawing.Size(456, 114);
            this.tbpSale.TabIndex = 0;
            this.tbpSale.Text = "SALE";
            this.tbpSale.UseVisualStyleBackColor = true;
            // 
            // checkBoxForPrice
            // 
            this.checkBoxForPrice.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxForPrice.Location = new System.Drawing.Point(116, 69);
            this.checkBoxForPrice.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxForPrice.Name = "checkBoxForPrice";
            this.checkBoxForPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxForPrice.Size = new System.Drawing.Size(20, 17);
            this.checkBoxForPrice.TabIndex = 29;
            this.checkBoxForPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxForPrice.UseVisualStyleBackColor = true;
            this.checkBoxForPrice.CheckedChanged += new System.EventHandler(this.checkBoxForPrice_CheckedChanged);
            // 
            // pnlExtraPlufields
            // 
            this.pnlExtraPlufields.Controls.Add(this.lblWeighable);
            this.pnlExtraPlufields.Controls.Add(this.checkBoxWeighable);
            this.pnlExtraPlufields.Controls.Add(this.txtBarcode);
            this.pnlExtraPlufields.Controls.Add(this.lblName);
            this.pnlExtraPlufields.Controls.Add(this.lblBarcode);
            this.pnlExtraPlufields.Controls.Add(this.txtName);
            this.pnlExtraPlufields.Controls.Add(this.lblDeptId);
            this.pnlExtraPlufields.Controls.Add(this.nmrDept);
            this.pnlExtraPlufields.Enabled = false;
            this.pnlExtraPlufields.Location = new System.Drawing.Point(272, 18);
            this.pnlExtraPlufields.Margin = new System.Windows.Forms.Padding(2);
            this.pnlExtraPlufields.Name = "pnlExtraPlufields";
            this.pnlExtraPlufields.Size = new System.Drawing.Size(182, 92);
            this.pnlExtraPlufields.TabIndex = 28;
            // 
            // lblWeighable
            // 
            this.lblWeighable.AutoSize = true;
            this.lblWeighable.Location = new System.Drawing.Point(47, 73);
            this.lblWeighable.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWeighable.Name = "lblWeighable";
            this.lblWeighable.Size = new System.Drawing.Size(71, 13);
            this.lblWeighable.TabIndex = 30;
            this.lblWeighable.Text = "WEIGHABLE";
            // 
            // checkBoxWeighable
            // 
            this.checkBoxWeighable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxWeighable.Location = new System.Drawing.Point(20, 73);
            this.checkBoxWeighable.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxWeighable.Name = "checkBoxWeighable";
            this.checkBoxWeighable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxWeighable.Size = new System.Drawing.Size(20, 17);
            this.checkBoxWeighable.TabIndex = 30;
            this.checkBoxWeighable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxWeighable.UseVisualStyleBackColor = true;
            this.checkBoxWeighable.CheckedChanged += new System.EventHandler(this.checkBoxWeighable_CheckedChanged);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(77, 3);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(2);
            this.txtBarcode.MaxLength = 15;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(90, 20);
            this.txtBarcode.TabIndex = 22;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 48);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(62, 13);
            this.lblName.TabIndex = 27;
            this.lblName.Text = "PLU NAME";
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(3, 6);
            this.lblBarcode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(59, 13);
            this.lblBarcode.TabIndex = 23;
            this.lblBarcode.Text = "BARCODE";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(77, 45);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(90, 20);
            this.txtName.TabIndex = 26;
            // 
            // lblDeptId
            // 
            this.lblDeptId.AutoSize = true;
            this.lblDeptId.Location = new System.Drawing.Point(4, 28);
            this.lblDeptId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeptId.Name = "lblDeptId";
            this.lblDeptId.Size = new System.Drawing.Size(46, 13);
            this.lblDeptId.TabIndex = 25;
            this.lblDeptId.Text = "DEP. ID";
            // 
            // nmrDept
            // 
            this.nmrDept.Location = new System.Drawing.Point(77, 23);
            this.nmrDept.Margin = new System.Windows.Forms.Padding(2);
            this.nmrDept.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nmrDept.Name = "nmrDept";
            this.nmrDept.Size = new System.Drawing.Size(62, 20);
            this.nmrDept.TabIndex = 24;
            this.nmrDept.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrDept.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(140, 71);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(39, 13);
            this.lblAmount.TabIndex = 21;
            this.lblAmount.Text = "PRICE";
            // 
            // tbpVoidSale
            // 
            this.tbpVoidSale.Controls.Add(this.lblVoidQtty);
            this.tbpVoidSale.Controls.Add(this.btnVoidSale);
            this.tbpVoidSale.Controls.Add(this.nmrVoidQtty);
            this.tbpVoidSale.Controls.Add(this.nmrVoidPlu);
            this.tbpVoidSale.Controls.Add(this.lblVoidPlu);
            this.tbpVoidSale.Location = new System.Drawing.Point(4, 22);
            this.tbpVoidSale.Margin = new System.Windows.Forms.Padding(2);
            this.tbpVoidSale.Name = "tbpVoidSale";
            this.tbpVoidSale.Padding = new System.Windows.Forms.Padding(2);
            this.tbpVoidSale.Size = new System.Drawing.Size(456, 114);
            this.tbpVoidSale.TabIndex = 1;
            this.tbpVoidSale.Text = "VOID SALE";
            this.tbpVoidSale.UseVisualStyleBackColor = true;
            // 
            // tbpAdj
            // 
            this.tbpAdj.Controls.Add(this.nmrAdjAmount);
            this.tbpAdj.Controls.Add(this.btnAdjust);
            this.tbpAdj.Controls.Add(this.rbtnFee);
            this.tbpAdj.Controls.Add(this.lblAdjAmount);
            this.tbpAdj.Controls.Add(this.rbtnDiscount);
            this.tbpAdj.Controls.Add(this.cbxPerc);
            this.tbpAdj.Location = new System.Drawing.Point(4, 22);
            this.tbpAdj.Margin = new System.Windows.Forms.Padding(2);
            this.tbpAdj.Name = "tbpAdj";
            this.tbpAdj.Padding = new System.Windows.Forms.Padding(2);
            this.tbpAdj.Size = new System.Drawing.Size(456, 114);
            this.tbpAdj.TabIndex = 2;
            this.tbpAdj.Text = "ADJUSTMENT";
            this.tbpAdj.UseVisualStyleBackColor = true;
            // 
            // tbcFooter
            // 
            this.tbcFooter.Controls.Add(this.tbpNotes);
            this.tbcFooter.Controls.Add(this.tbpExtra);
            this.tbcFooter.Location = new System.Drawing.Point(6, 400);
            this.tbcFooter.Margin = new System.Windows.Forms.Padding(2);
            this.tbcFooter.Name = "tbcFooter";
            this.tbcFooter.SelectedIndex = 0;
            this.tbcFooter.Size = new System.Drawing.Size(463, 93);
            this.tbcFooter.TabIndex = 29;
            // 
            // tbpNotes
            // 
            this.tbpNotes.Controls.Add(this.txtRcptBarcode);
            this.tbpNotes.Controls.Add(this.btnRemark);
            this.tbpNotes.Controls.Add(this.btnRcptBarcode);
            this.tbpNotes.Controls.Add(this.txtRemarkLine);
            this.tbpNotes.Location = new System.Drawing.Point(4, 22);
            this.tbpNotes.Margin = new System.Windows.Forms.Padding(2);
            this.tbpNotes.Name = "tbpNotes";
            this.tbpNotes.Padding = new System.Windows.Forms.Padding(2);
            this.tbpNotes.Size = new System.Drawing.Size(455, 67);
            this.tbpNotes.TabIndex = 0;
            this.tbpNotes.Text = "FOOTER NOTES";
            this.tbpNotes.UseVisualStyleBackColor = true;
            // 
            // tbpExtra
            // 
            this.tbpExtra.Controls.Add(this.btnOpenDrawer);
            this.tbpExtra.Location = new System.Drawing.Point(4, 22);
            this.tbpExtra.Margin = new System.Windows.Forms.Padding(2);
            this.tbpExtra.Name = "tbpExtra";
            this.tbpExtra.Padding = new System.Windows.Forms.Padding(2);
            this.tbpExtra.Size = new System.Drawing.Size(455, 67);
            this.tbpExtra.TabIndex = 1;
            this.tbpExtra.Text = "FOOTER NOTE EXTRA";
            this.tbpExtra.UseVisualStyleBackColor = true;
            // 
            // tbcStartDoc
            // 
            this.tbcStartDoc.Controls.Add(this.tbStrtRcpt);
            this.tbcStartDoc.Controls.Add(this.tbStrtInvoice);
            this.tbcStartDoc.Controls.Add(this.tbStrtPaidDocs);
            this.tbcStartDoc.Controls.Add(this.tbpStartParking);
            this.tbcStartDoc.Location = new System.Drawing.Point(6, 11);
            this.tbcStartDoc.Margin = new System.Windows.Forms.Padding(2);
            this.tbcStartDoc.Name = "tbcStartDoc";
            this.tbcStartDoc.SelectedIndex = 0;
            this.tbcStartDoc.Size = new System.Drawing.Size(466, 130);
            this.tbcStartDoc.TabIndex = 30;
            // 
            // tbStrtRcpt
            // 
            this.tbStrtRcpt.Controls.Add(this.btnStartReceipt);
            this.tbStrtRcpt.Location = new System.Drawing.Point(4, 22);
            this.tbStrtRcpt.Margin = new System.Windows.Forms.Padding(2);
            this.tbStrtRcpt.Name = "tbStrtRcpt";
            this.tbStrtRcpt.Padding = new System.Windows.Forms.Padding(2);
            this.tbStrtRcpt.Size = new System.Drawing.Size(458, 104);
            this.tbStrtRcpt.TabIndex = 0;
            this.tbStrtRcpt.Text = "RECEIPT";
            this.tbStrtRcpt.UseVisualStyleBackColor = true;
            // 
            // tbStrtInvoice
            // 
            this.tbStrtInvoice.Controls.Add(this.lblDocTypeInv);
            this.tbStrtInvoice.Controls.Add(this.cbxInvTypes);
            this.tbStrtInvoice.Controls.Add(this.btnStartInvoice);
            this.tbStrtInvoice.Controls.Add(this.txtTCKN_VKN);
            this.tbStrtInvoice.Controls.Add(this.lblInvSerial);
            this.tbStrtInvoice.Location = new System.Drawing.Point(4, 22);
            this.tbStrtInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.tbStrtInvoice.Name = "tbStrtInvoice";
            this.tbStrtInvoice.Padding = new System.Windows.Forms.Padding(2);
            this.tbStrtInvoice.Size = new System.Drawing.Size(458, 104);
            this.tbStrtInvoice.TabIndex = 1;
            this.tbStrtInvoice.Text = "INVOICE TYPES";
            this.tbStrtInvoice.UseVisualStyleBackColor = true;
            // 
            // lblDocTypeInv
            // 
            this.lblDocTypeInv.AutoSize = true;
            this.lblDocTypeInv.Location = new System.Drawing.Point(142, 57);
            this.lblDocTypeInv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDocTypeInv.Name = "lblDocTypeInv";
            this.lblDocTypeInv.Size = new System.Drawing.Size(83, 13);
            this.lblDocTypeInv.TabIndex = 28;
            this.lblDocTypeInv.Text = "Document Type";
            // 
            // cbxInvTypes
            // 
            this.cbxInvTypes.FormattingEnabled = true;
            this.cbxInvTypes.Location = new System.Drawing.Point(226, 54);
            this.cbxInvTypes.Margin = new System.Windows.Forms.Padding(2);
            this.cbxInvTypes.Name = "cbxInvTypes";
            this.cbxInvTypes.Size = new System.Drawing.Size(91, 21);
            this.cbxInvTypes.TabIndex = 27;
            // 
            // btnStartInvoice
            // 
            this.btnStartInvoice.Location = new System.Drawing.Point(2, 4);
            this.btnStartInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartInvoice.Name = "btnStartInvoice";
            this.btnStartInvoice.Size = new System.Drawing.Size(110, 37);
            this.btnStartInvoice.TabIndex = 2;
            this.btnStartInvoice.Text = "START DOCUMENT";
            this.btnStartInvoice.UseVisualStyleBackColor = true;
            this.btnStartInvoice.Click += new System.EventHandler(this.btnStartInvoice_Click);
            // 
            // tbStrtPaidDocs
            // 
            this.tbStrtPaidDocs.Controls.Add(this.labelPaidDocType);
            this.tbStrtPaidDocs.Controls.Add(this.comboBoxPaidDocuments);
            this.tbStrtPaidDocs.Controls.Add(this.btnPaidDoc);
            this.tbStrtPaidDocs.Controls.Add(this.lblNFTotal);
            this.tbStrtPaidDocs.Controls.Add(this.nmrInvoiceTotal);
            this.tbStrtPaidDocs.Location = new System.Drawing.Point(4, 22);
            this.tbStrtPaidDocs.Margin = new System.Windows.Forms.Padding(2);
            this.tbStrtPaidDocs.Name = "tbStrtPaidDocs";
            this.tbStrtPaidDocs.Padding = new System.Windows.Forms.Padding(2);
            this.tbStrtPaidDocs.Size = new System.Drawing.Size(458, 104);
            this.tbStrtPaidDocs.TabIndex = 2;
            this.tbStrtPaidDocs.Text = "PAID DOCUMENTS";
            this.tbStrtPaidDocs.UseVisualStyleBackColor = true;
            // 
            // labelPaidDocType
            // 
            this.labelPaidDocType.AutoSize = true;
            this.labelPaidDocType.Location = new System.Drawing.Point(142, 55);
            this.labelPaidDocType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPaidDocType.Name = "labelPaidDocType";
            this.labelPaidDocType.Size = new System.Drawing.Size(83, 13);
            this.labelPaidDocType.TabIndex = 12;
            this.labelPaidDocType.Text = "Document Type";
            // 
            // comboBoxPaidDocuments
            // 
            this.comboBoxPaidDocuments.FormattingEnabled = true;
            this.comboBoxPaidDocuments.Location = new System.Drawing.Point(226, 52);
            this.comboBoxPaidDocuments.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxPaidDocuments.Name = "comboBoxPaidDocuments";
            this.comboBoxPaidDocuments.Size = new System.Drawing.Size(91, 21);
            this.comboBoxPaidDocuments.TabIndex = 11;
            // 
            // btnPaidDoc
            // 
            this.btnPaidDoc.Location = new System.Drawing.Point(2, 4);
            this.btnPaidDoc.Margin = new System.Windows.Forms.Padding(2);
            this.btnPaidDoc.Name = "btnPaidDoc";
            this.btnPaidDoc.Size = new System.Drawing.Size(110, 37);
            this.btnPaidDoc.TabIndex = 3;
            this.btnPaidDoc.Text = "START DOCUMENT";
            this.btnPaidDoc.UseVisualStyleBackColor = true;
            this.btnPaidDoc.Click += new System.EventHandler(this.btnPaidDoc_Click);
            // 
            // tbpStartParking
            // 
            this.tbpStartParking.Controls.Add(this.dtParkTime);
            this.tbpStartParking.Controls.Add(this.btnStartParkDoc);
            this.tbpStartParking.Controls.Add(this.dtParkDate);
            this.tbpStartParking.Controls.Add(this.lblPlate);
            this.tbpStartParking.Controls.Add(this.label1);
            this.tbpStartParking.Controls.Add(this.txtPlate);
            this.tbpStartParking.Location = new System.Drawing.Point(4, 22);
            this.tbpStartParking.Margin = new System.Windows.Forms.Padding(2);
            this.tbpStartParking.Name = "tbpStartParking";
            this.tbpStartParking.Padding = new System.Windows.Forms.Padding(2);
            this.tbpStartParking.Size = new System.Drawing.Size(458, 104);
            this.tbpStartParking.TabIndex = 3;
            this.tbpStartParking.Text = "OTOPARK";
            this.tbpStartParking.UseVisualStyleBackColor = true;
            // 
            // btnStartParkDoc
            // 
            this.btnStartParkDoc.Location = new System.Drawing.Point(2, 4);
            this.btnStartParkDoc.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartParkDoc.Name = "btnStartParkDoc";
            this.btnStartParkDoc.Size = new System.Drawing.Size(110, 37);
            this.btnStartParkDoc.TabIndex = 4;
            this.btnStartParkDoc.Text = "START DOCUMENT";
            this.btnStartParkDoc.UseVisualStyleBackColor = true;
            this.btnStartParkDoc.Click += new System.EventHandler(this.btnStartParkDoc_Click);
            // 
            // SaleUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbcStartDoc);
            this.Controls.Add(this.tbcFooter);
            this.Controls.Add(this.tbcSale);
            this.Controls.Add(this.tbcPayment);
            this.Controls.Add(this.bntPrintJSONDoc);
            this.Controls.Add(this.btnCorrect);
            this.Controls.Add(this.btnSubtotal);
            this.Controls.Add(this.btnVoidReceipt);
            this.Controls.Add(this.btnCloseReceipt);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SaleUC";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Size = new System.Drawing.Size(605, 498);
            ((System.ComponentModel.ISupportInitialize)(this.nmrPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPlu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrInvoiceTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrVoidQtty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrVoidPlu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPaymentAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrAdjAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrVoidPayIndex)).EndInit();
            this.tbcPayment.ResumeLayout(false);
            this.tbpPay1.ResumeLayout(false);
            this.tbpPay1.PerformLayout();
            this.tbpPayEFT.ResumeLayout(false);
            this.tbpPayEFT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrEFTAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrInstallment)).EndInit();
            this.tbpVoidPay.ResumeLayout(false);
            this.tbpVoidPay.PerformLayout();
            this.tbcSale.ResumeLayout(false);
            this.tbpSale.ResumeLayout(false);
            this.tbpSale.PerformLayout();
            this.pnlExtraPlufields.ResumeLayout(false);
            this.pnlExtraPlufields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrDept)).EndInit();
            this.tbpVoidSale.ResumeLayout(false);
            this.tbpVoidSale.PerformLayout();
            this.tbpAdj.ResumeLayout(false);
            this.tbpAdj.PerformLayout();
            this.tbcFooter.ResumeLayout(false);
            this.tbpNotes.ResumeLayout(false);
            this.tbpNotes.PerformLayout();
            this.tbpExtra.ResumeLayout(false);
            this.tbcStartDoc.ResumeLayout(false);
            this.tbStrtRcpt.ResumeLayout(false);
            this.tbStrtInvoice.ResumeLayout(false);
            this.tbStrtInvoice.PerformLayout();
            this.tbStrtPaidDocs.ResumeLayout(false);
            this.tbStrtPaidDocs.PerformLayout();
            this.tbpStartParking.ResumeLayout(false);
            this.tbpStartParking.PerformLayout();
            this.ResumeLayout(false);

        }

        private void btnStartReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                CPResponse response = new CPResponse(bridge.Printer.PrintDocumentHeader());
                if (response.ErrorCode == 0)
                {
                    bridge.Log(FormMessage.DOCUMENT_ID + "    :" + response.GetNextParam());
                }
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void btnSaleSample_Click(object sender, EventArgs e)
        {
            int pluNo = (int)nmrPlu.Value;
            Decimal quantity = nmrQuantity.Value;
            Decimal price = Decimal.MinusOne;
            int weighable = -1;

            if (checkBoxForPrice.Checked)
                price = nmrPrice.Value;

            if (checkBoxWeighable.Checked)
                weighable = 1;

            try
            {
                CPResponse response = null;
                if (cbxSaveAndSale.Checked)
                {
#if CPP
                    response = new CPResponse(bridge.Printer.PrintItem(pluNo, quantity, price, txtName.Text, (int)nmrDept.Value, weighable));
#else
                    response = new CPResponse(bridge.Printer.PrintItem(pluNo, quantity, price, txtName.Text, txtBarcode.Text, (int)nmrDept.Value, weighable));
#endif
                } 
                else
                {
#if CPP
                    response = new CPResponse(bridge.Printer.PrintItem(pluNo, quantity, price, null, -1, -1));
#else
                    response = new CPResponse(bridge.Printer.PrintItem(pluNo, quantity, price, null, null, -1, -1));
#endif
                }

                if (response.ErrorCode == 0)
                {
                    bridge.Log(String.Format(FormMessage.SUBTOTAL + " :{0}", response.GetNextParam()));
                }
            }
            catch
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void btnCloseReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                bridge.Connection.FPUTimeout = ProgramConfig.FPU_RPRT_TIMEOUT;

                CPResponse response = new CPResponse(bridge.Printer.CloseReceipt(chbSlipCopy.Checked));
                
                if (response.ErrorCode == 0)
                {
                     bridge.Log(FormMessage.DOCUMENT_ID + "    :" + response.GetNextParam());
                }
            }
            catch
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
            finally
            {
                bridge.Connection.FPUTimeout = ProgramConfig.FPU_CMD_TIMEOUT;
            }
        }

        private void btnVoidReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                bridge.Connection.FPUTimeout = ProgramConfig.FPU_RPRT_TIMEOUT;
                CPResponse response = new CPResponse(bridge.Printer.VoidReceipt());

                if (response.ErrorCode == 0)
                {
                    bridge.Log(FormMessage.VOIDED_DOC_ID + ":" + response.GetNextParam());
                }
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
            finally
            {
                bridge.Connection.FPUTimeout = ProgramConfig.FPU_CMD_TIMEOUT;
            }
        }

        private void btnSubtotal_Click(object sender, EventArgs e)
        {
            try
            {
                CPResponse response = new CPResponse(bridge.Printer.PrintSubtotal(false));

                if (response.ErrorCode == 0)
                {
                    bridge.Log(String.Format(FormMessage.SUBTOTAL + " :{0}", response.GetNextParam()));

                    bridge.Log(String.Format(FormMessage.PAID_TOTAL + ":{0}", response.GetNextParam()));
                }
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                int index = -1;
                CPResponse response = null;

                //PAYMENT TYPE
                int paymentType = cbxPaymentType.SelectedIndex;

                //IF PAYMENT IS FOREIGN CURRENCY OR CREDIT
                if (cbxPaymentType.Text == FormMessage.CURRENCY || cbxPaymentType.Text == FormMessage.CREDIT)
                {
                    //Index
                    index = cbxSubPayments.SelectedIndex;
                }

                //PAYMENT AMOUNT
                decimal amount = nmrPaymentAmount.Value;

                // SEND COMMAND
                response = new CPResponse(bridge.Printer.PrintPayment(paymentType, index, amount));

                if (response.ErrorCode == 0)
                {
                    bridge.Log(String.Format(FormMessage.SUBTOTAL + " :{0}", response.GetNextParam()));

                    bridge.Log(String.Format(FormMessage.PAID_TOTAL + ":{0}", response.GetNextParam()));

                }

            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void cbxPerc_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPerc.Checked)
            {
                nmrAdjAmount.DecimalPlaces = 0;
            }
            else
            {
                nmrAdjAmount.DecimalPlaces = 2;
            }
        }

        private void btnAdjust_Click(object sender, EventArgs e)
        {
            try
            {
                int percantege = 0;
                decimal amount = 0;
                AdjustmentType adjType;

                bool IsFee = false;
                if (rbtnFee.Checked)
                {
                    IsFee = true;
                }

                if (cbxPerc.Checked)
                {
                    //Percantage
                    percantege = (int)nmrAdjAmount.Value;

                    adjType = IsFee ? AdjustmentType.PercentFee : AdjustmentType.PercentDiscount;
                }
                else
                {
                    //AMOUNT
                    amount = nmrAdjAmount.Value;

                    adjType = IsFee ? AdjustmentType.Fee : AdjustmentType.Discount;
                }

                // SEND COMMAND
                CPResponse response = new CPResponse(bridge.Printer.PrintAdjustment((int)adjType, amount, percantege));

                if (response.ErrorCode == 0)
                {
                    bridge.Log(String.Format(FormMessage.SUBTOTAL + " :{0:#0.00}", response.GetNextParam()));
                }
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }

        }

        private void btnCorrect_Click(object sender, EventArgs e)
        {
            try
            {
                CPResponse response = new CPResponse(bridge.Printer.Correct());

                if (response.ErrorCode == 0)
                {
                    bridge.Log(String.Format("{1} :{0:#0.00}", response.GetNextParam(), FormMessage.SUBTOTAL));
                }
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void btnVoidSale_Click(object sender, EventArgs e)
        {
            try
            {
                //PLU NO
                int pluNo = (int)nmrVoidPlu.Value;

                //VOID QUANTITY
                decimal quantity = nmrVoidQtty.Value;

                bridge.Connection.FPUTimeout = ProgramConfig.FPU_RPRT_TIMEOUT;
                // SEND COMMAND
                CPResponse response = new CPResponse(bridge.Printer.Void(pluNo, quantity));

                if (response.ErrorCode == 0)
                {
                    bridge.Log(String.Format("{1} :{0}", response.GetNextParam(), FormMessage.SUBTOTAL));
                }
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
            finally
            {
                bridge.Connection.FPUTimeout = ProgramConfig.FPU_CMD_TIMEOUT;
            }
        }

        private void btnRemark_Click(object sender, EventArgs e)
        {
            try
            {
                List<byte> bytes = new List<byte>();

                //REMARK
                string line = txtRemarkLine.Text.PadRight(ProgramConfig.LOGO_LINE_LENGTH - 3, ' ');
                // SEND COMMAND
#if CPP 
                CPResponse response = new CPResponse(bridge.Printer.PrintRemarkLine( line ));
#else
                CPResponse response = new CPResponse(bridge.Printer.PrintRemarkLine(new string[]{line}));
#endif
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void cbxPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRefreshCredit.Visible = false;
            lblFCurrValue.Visible = false;

            switch (cbxPaymentType.Text)
            {
                case FormMessage.CURRENCY:
                    RefreshCurrencyList();
                        lblPayIndx.Visible = true;
                        cbxSubPayments.Visible = true;
                        lblFCurrValue.Visible = true;
                    break;
                case FormMessage.CREDIT:
                    int creditCount = 0;
                    btnRefreshCredit.Visible = true;

                    //if (MainForm.Credits[0] == null)
                    {
                        creditCount = RefreshCredits();
                    }
                    if (MainForm.Credits[0] != null || creditCount>0)
                    {
                        lblPayIndx.Visible = true;
                        cbxSubPayments.Visible = true;
                    }
                    break;
                default:
                    lblPayIndx.Visible = false;
                    cbxSubPayments.Visible = false;
                    break;
            }
        }

        private void RefreshCurrencyList()
        {
            cbxSubPayments.Items.Clear();
            lblPayIndx.Text = FormMessage.CURRENCIES;
            if (MainForm.Currencies[0]== null)
            {
                LoadCurrency();
            }
            for (int i = 0; i < 4; i++)
            {
                cbxSubPayments.Items.Add(String.Format("{0} - {1}",MainForm.Currencies[i].Name , MainForm.Currencies[i].Rate));
            }
            cbxSubPayments.SelectedIndex = 0;
        }

        private void btnRefreshCredit_Click(object sender, EventArgs e)
        {
            MainForm.Credits[0] = null;
            RefreshCredits();
        }

        private int RefreshCredits()
        {
            int creditCount = 0;
            if (MainForm.Credits[0] == null)
            {
                bridge.Log(FormMessage.CREDITS_LOADING);
                creditCount = LoadCreditData();
                bridge.Log(FormMessage.CREDITS_LOADED);
            }
            else
            {
                creditCount = MainForm.Credits.Length;
            }
            if (creditCount > 0)
            {
                try
                {
                    cbxSubPayments.Items.Clear();
                    lblPayIndx.Text = FormMessage.CREDITS;
                    for (int i = 0; i < MainForm.Credits.Length; i++)
                    {
                        if (!String.IsNullOrEmpty(MainForm.Credits[i]))
                        {
                            cbxSubPayments.Items.Add(MainForm.Credits[i]);
                        }
                    }
                    cbxSubPayments.SelectedIndex = 0;

                }
                catch (System.Exception ex)
                {
                    bridge.Log(FormMessage.OPERATION_FAILS);
                }
            }


            return creditCount;
        }

        private void nmrPaymentAmount_ValueChanged(object sender, EventArgs e)
        {
            if (cbxPaymentType.Text == FormMessage.CURRENCY)
            {
                CalculateFCurrency();
            }
        }

        private decimal CalculateFCurrency()
        {
            decimal amount = Math.Round(nmrPaymentAmount.Value * MainForm.Currencies[cbxSubPayments.SelectedIndex].Rate,2,MidpointRounding.AwayFromZero);
            lblFCurrValue.Text = String.Format("{0:#0.00}", amount);

            return amount;
        }

        private void cbxSubPayments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPaymentType.Text == FormMessage.CURRENCY)
            {
                CalculateFCurrency();
            }
        }

        private void btnRcptBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                List<byte> bytes = new List<byte>();

                //BARCODE
                string barcode = txtRcptBarcode.Text;
                // SEND COMMAND
                CPResponse response = new CPResponse(bridge.Printer.PrintReceiptBarcode(barcode));
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void cbxInvoice_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnOpenDrawer_Click(object sender, EventArgs e)
        {
            try
            {
                // SEND COMMAND
                CPResponse response = new CPResponse(bridge.Printer.OpenDrawer());
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void btnVoidPayment_Click(object sender, EventArgs e)
        {
            try
            {
                // SEND COMMAND
                CPResponse response = new CPResponse(bridge.Printer.VoidPayment((int)nmrVoidPayIndex.Value));
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void bntPrintJSONDoc_Click(object sender, EventArgs e)
        {
            string jsonFileName = System.Configuration.ConfigurationSettings.AppSettings["JSONDocName"];
            string jsonStr = "";
            if (!File.Exists(jsonFileName))
            {
                bridge.Log(FormMessage.JSON_FILE_NOT_EXISTS);
                return;
            }

            try
            {
                jsonStr = File.ReadAllText(jsonFileName);
#if CPP

#else
                CPResponse response = new CPResponse(bridge.Printer.PrintJSONDocument(jsonStr));
#endif
            }
            catch(Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + " : " + ex.Message);
            }
            
        }

        private void btnCardQuery_Click(object sender, EventArgs e)
        {
            CPResponse response = null;
            try
            {
                // SEND COMMAND
#if CPP

#else
                response = new CPResponse(bridge.Printer.GetEFTCardInfo(nmrPaymentAmount.Value));
#endif

                if (response.ErrorCode == 0)
                {
                    bridge.Log(String.Format(FormMessage.CC_ID + "      :{0}", response.GetNextParam()));
                    bridge.Log(String.Format(FormMessage.CC_NAME + "     :{0}", response.GetNextParam()));
                    bridge.Log(String.Format(FormMessage.DISCOUNT_ACTIVE + ":{0}", response.GetNextParam()));

                    string cardNum = response.GetNextParam();
                    bridge.Log(String.Format(FormMessage.CARD_NUMBER + "    :{0}", cardNum));
                    bridge.Log(String.Format("Holder Name:{0}", response.GetNextParam()));

                    txtCardNumber.Text = cardNum.Substring(0, 6);
                }

            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void btnEFTAuthorization_Click(object sender, EventArgs e)
        {
            try
            {
                // SEND COMMAND
                CPResponse response = new CPResponse(bridge.Printer.GetEFTAuthorisation(nmrEFTAmount.Value, (int)nmrInstallment.Value, txtCardNumber.Text));

                if (response.ErrorCode == 0)
                {
                    bridge.Log(String.Format("Aratoplam      :{0}", response.GetNextParam()));
                    bridge.Log(String.Format("Provizyon kodu :{0}", response.GetNextParam()));
                    bridge.Log(String.Format("Ödeme Toplamı  :{0}", response.GetNextParam()));
                    bridge.Log(String.Format("Taksit sayısı  :{0}", response.GetNextParam()));
                    bridge.Log(String.Format("ACQUIRER ID    :{0}", response.GetNextParam()));
                    bridge.Log(String.Format("BIN            :{0}", response.GetNextParam()));
                    bridge.Log(String.Format("ISSUERER ID    :{0}", response.GetNextParam()));
                    
                }

            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void btnStartInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                // Serial 
                string tckn_vkn = txtTCKN_VKN.Text;
                // Amount
                decimal amount = 0;

                CPResponse response = new CPResponse(bridge.Printer.PrintDocumentHeader(tckn_vkn, amount, cbxInvTypes.SelectedIndex+1));
                if (response.ErrorCode == 0)
                {
                    bridge.Log(FormMessage.DOCUMENT_ID + "  :" + response.GetNextParam());
                }
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void btnPaidDoc_Click(object sender, EventArgs e)
        {
            try
            {
                int docType = 6; ;

                switch (comboBoxPaidDocuments.SelectedIndex)
                {
                    case 0:
                        docType = 6; // AVANS
                        break;
                    case 1:
                        docType = 4; // YEMEK
                        break;
                }
                // Serial 
                string tckn_vkn = "";
                // Amount
                decimal amount = nmrInvoiceTotal.Value;

                CPResponse response = new CPResponse(bridge.Printer.PrintDocumentHeader(tckn_vkn, amount, docType));
                if (response.ErrorCode == 0)
                {
                    bridge.Log(FormMessage.DOCUMENT_ID + "  :" + response.GetNextParam());
                }
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void btnStartParkDoc_Click(object sender, EventArgs e)
        {
            try
            {
                CPResponse response = new CPResponse(bridge.Printer.PrintParkDocument(txtPlate.Text, dtParkDate.Value));
                if (response.ErrorCode == 0)
                {
                    bridge.Log(FormMessage.DOCUMENT_ID + "  :" + response.GetNextParam());
                }
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void cbxSaveAndSale_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSaveAndSale.Checked)
            {
                bridge.Log(FormMessage.SAVE_AND_SALE_INFO);
            }

            pnlExtraPlufields.Enabled = cbxSaveAndSale.Checked;
        }

        private void checkBoxForPrice_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxForPrice.Checked)
            {
                nmrPrice.Enabled = true;
                lblAmount.Enabled = true;
            }
            else
            {
                nmrPrice.Enabled = false;
                lblAmount.Enabled = false;
            }
        }

        private void checkBoxWeighable_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxWeighable.Checked)
                lblWeighable.Enabled = true;
            else
                lblWeighable.Enabled = false;         
        }

    }
}
