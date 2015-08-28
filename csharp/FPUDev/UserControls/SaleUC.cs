using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


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
        private GroupBox gbxAdjustment;
        private RadioButton rbtnFee;
        private RadioButton rbtnDiscount;
        private GroupBox gbxPayment;
        private GroupBox gbxSale;
        private NumericUpDown nmrPrice;
        private Label lblQuantity;
        private NumericUpDown nmrQuantity;
        private Label lblPlu;
        private NumericUpDown nmrPlu;
        private GroupBox gbxCustMsg;
        private TextBox txtRemarkLine;
        private Button btnRemark;
        private Label lblRemark;
        private NumericUpDown nmrPaymentAmount;
        private NumericUpDown nmrAdjAmount;
        private Label lblPayIndx;
        private ComboBox cbxSubPayments;
        private Button btnStartReceipt;


        private static TestUC saleForm = null;
        private static IBridge bridge = null;
        private Label lblFCurrValue;
        private TextBox txtRcptBarcode;
        private Button btnRcptBarcode;
        private Label lblBarkod;
        private CheckBox cbxInvoice;
        private GroupBox gbxInvoice;
        private Label lblNFTotal;
        private NumericUpDown nmrInvoiceTotal;
        private DateTimePicker dtInvoiceDate;
        private Label lblInvoiceDate;
        private TextBox txtInvoiceNum;
        private Label lblInvSerial;
        private Button btnOpenDrawer;
        private CheckBox cbxWithPrice;
        private Button btnRefreshCredit;


        public SaleUC()
            : base()
        {
            InitializeComponent();

            cbxPaymentType.Items.AddRange(Common.Payments);
            cbxPaymentType.SelectedIndex = 0;

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
                    bridge.Log("Hata: Timeout Hatası");
                }
                catch
                {
                    bridge.Log("Hata: Hata oluştu");
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
            {
                if (MainForm.Credits[0] == null)
                {
                    RefreshCredits();
                }

                if (MainForm.Currencies[0] == null)
                {
                    RefreshCurrencyList();
                }
            }
            catch (System.Exception ex)
            {
            	
            }
            base.OnParentChanged(e);
        }
        private void InitializeComponent()
        {
            this.gbxSale = new System.Windows.Forms.GroupBox();
            this.nmrPrice = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.nmrQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblPlu = new System.Windows.Forms.Label();
            this.nmrPlu = new System.Windows.Forms.NumericUpDown();
            this.btnSale = new System.Windows.Forms.Button();
            this.gbxInvoice = new System.Windows.Forms.GroupBox();
            this.txtInvoiceNum = new System.Windows.Forms.TextBox();
            this.lblInvSerial = new System.Windows.Forms.Label();
            this.dtInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.lblInvoiceDate = new System.Windows.Forms.Label();
            this.lblNFTotal = new System.Windows.Forms.Label();
            this.nmrInvoiceTotal = new System.Windows.Forms.NumericUpDown();
            this.gbxAdjustment = new System.Windows.Forms.GroupBox();
            this.nmrAdjAmount = new System.Windows.Forms.NumericUpDown();
            this.rbtnFee = new System.Windows.Forms.RadioButton();
            this.rbtnDiscount = new System.Windows.Forms.RadioButton();
            this.cbxPerc = new System.Windows.Forms.CheckBox();
            this.btnAdjust = new System.Windows.Forms.Button();
            this.lblAdjAmount = new System.Windows.Forms.Label();
            this.cbxInvoice = new System.Windows.Forms.CheckBox();
            this.gbxCustMsg = new System.Windows.Forms.GroupBox();
            this.txtRcptBarcode = new System.Windows.Forms.TextBox();
            this.btnRcptBarcode = new System.Windows.Forms.Button();
            this.lblBarkod = new System.Windows.Forms.Label();
            this.txtRemarkLine = new System.Windows.Forms.TextBox();
            this.btnRemark = new System.Windows.Forms.Button();
            this.lblRemark = new System.Windows.Forms.Label();
            this.gbxPayment = new System.Windows.Forms.GroupBox();
            this.lblFCurrValue = new System.Windows.Forms.Label();
            this.btnRefreshCredit = new System.Windows.Forms.Button();
            this.lblPayIndx = new System.Windows.Forms.Label();
            this.cbxSubPayments = new System.Windows.Forms.ComboBox();
            this.nmrPaymentAmount = new System.Windows.Forms.NumericUpDown();
            this.btnPayment = new System.Windows.Forms.Button();
            this.lblPayType = new System.Windows.Forms.Label();
            this.lblPayAmount = new System.Windows.Forms.Label();
            this.cbxPaymentType = new System.Windows.Forms.ComboBox();
            this.btnSubtotal = new System.Windows.Forms.Button();
            this.btnVoidReceipt = new System.Windows.Forms.Button();
            this.btnCloseReceipt = new System.Windows.Forms.Button();
            this.btnStartReceipt = new System.Windows.Forms.Button();
            this.btnOpenDrawer = new System.Windows.Forms.Button();
            this.cbxWithPrice = new System.Windows.Forms.CheckBox();
            this.gbxSale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPlu)).BeginInit();
            this.gbxInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrInvoiceTotal)).BeginInit();
            this.gbxAdjustment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrAdjAmount)).BeginInit();
            this.gbxCustMsg.SuspendLayout();
            this.gbxPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPaymentAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxSale
            // 
            this.gbxSale.Controls.Add(this.cbxWithPrice);
            this.gbxSale.Controls.Add(this.nmrPrice);
            this.gbxSale.Controls.Add(this.lblQuantity);
            this.gbxSale.Controls.Add(this.nmrQuantity);
            this.gbxSale.Controls.Add(this.lblPlu);
            this.gbxSale.Controls.Add(this.nmrPlu);
            this.gbxSale.Controls.Add(this.btnSale);
            this.gbxSale.Location = new System.Drawing.Point(30, 61);
            this.gbxSale.Margin = new System.Windows.Forms.Padding(2);
            this.gbxSale.Name = "gbxSale";
            this.gbxSale.Padding = new System.Windows.Forms.Padding(2);
            this.gbxSale.Size = new System.Drawing.Size(399, 60);
            this.gbxSale.TabIndex = 17;
            this.gbxSale.TabStop = false;
            this.gbxSale.Text = "Satış";
            // 
            // nmrPrice
            // 
            this.nmrPrice.DecimalPlaces = 2;
            this.nmrPrice.Location = new System.Drawing.Point(330, 37);
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
            this.lblQuantity.Location = new System.Drawing.Point(240, 20);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(39, 13);
            this.lblQuantity.TabIndex = 16;
            this.lblQuantity.Text = "Miktar:";
            // 
            // nmrQuantity
            // 
            this.nmrQuantity.DecimalPlaces = 3;
            this.nmrQuantity.Location = new System.Drawing.Point(242, 37);
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
            this.lblPlu.Location = new System.Drawing.Point(165, 20);
            this.lblPlu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlu.Name = "lblPlu";
            this.lblPlu.Size = new System.Drawing.Size(31, 13);
            this.lblPlu.TabIndex = 14;
            this.lblPlu.Text = "PLU:";
            // 
            // nmrPlu
            // 
            this.nmrPlu.Location = new System.Drawing.Point(167, 37);
            this.nmrPlu.Margin = new System.Windows.Forms.Padding(2);
            this.nmrPlu.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.nmrPlu.Minimum = new decimal(new int[] {
            1,
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
            this.btnSale.Text = "&Satış Yap";
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Click += new System.EventHandler(this.btnSaleSample_Click);
            // 
            // gbxInvoice
            // 
            this.gbxInvoice.Controls.Add(this.txtInvoiceNum);
            this.gbxInvoice.Controls.Add(this.lblInvSerial);
            this.gbxInvoice.Controls.Add(this.dtInvoiceDate);
            this.gbxInvoice.Controls.Add(this.lblInvoiceDate);
            this.gbxInvoice.Controls.Add(this.lblNFTotal);
            this.gbxInvoice.Controls.Add(this.nmrInvoiceTotal);
            this.gbxInvoice.Location = new System.Drawing.Point(30, 46);
            this.gbxInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.gbxInvoice.Name = "gbxInvoice";
            this.gbxInvoice.Padding = new System.Windows.Forms.Padding(2);
            this.gbxInvoice.Size = new System.Drawing.Size(328, 142);
            this.gbxInvoice.TabIndex = 21;
            this.gbxInvoice.TabStop = false;
            this.gbxInvoice.Visible = false;
            // 
            // txtInvoiceNum
            // 
            this.txtInvoiceNum.Location = new System.Drawing.Point(88, 75);
            this.txtInvoiceNum.Margin = new System.Windows.Forms.Padding(2);
            this.txtInvoiceNum.MaxLength = 45;
            this.txtInvoiceNum.Name = "txtInvoiceNum";
            this.txtInvoiceNum.Size = new System.Drawing.Size(226, 20);
            this.txtInvoiceNum.TabIndex = 26;
            // 
            // lblInvSerial
            // 
            this.lblInvSerial.AutoSize = true;
            this.lblInvSerial.Location = new System.Drawing.Point(4, 79);
            this.lblInvSerial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInvSerial.Name = "lblInvSerial";
            this.lblInvSerial.Size = new System.Drawing.Size(75, 13);
            this.lblInvSerial.TabIndex = 25;
            this.lblInvSerial.Text = "Fatura Seri No";
            // 
            // dtInvoiceDate
            // 
            this.dtInvoiceDate.CustomFormat = "dd-MM-yyyy";
            this.dtInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInvoiceDate.Location = new System.Drawing.Point(88, 11);
            this.dtInvoiceDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtInvoiceDate.Name = "dtInvoiceDate";
            this.dtInvoiceDate.Size = new System.Drawing.Size(95, 20);
            this.dtInvoiceDate.TabIndex = 24;
            // 
            // lblInvoiceDate
            // 
            this.lblInvoiceDate.AutoSize = true;
            this.lblInvoiceDate.Location = new System.Drawing.Point(4, 15);
            this.lblInvoiceDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInvoiceDate.Name = "lblInvoiceDate";
            this.lblInvoiceDate.Size = new System.Drawing.Size(72, 13);
            this.lblInvoiceDate.TabIndex = 23;
            this.lblInvoiceDate.Text = "Fatura Tarihi :";
            // 
            // lblNFTotal
            // 
            this.lblNFTotal.AutoSize = true;
            this.lblNFTotal.Location = new System.Drawing.Point(4, 50);
            this.lblNFTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNFTotal.Name = "lblNFTotal";
            this.lblNFTotal.Size = new System.Drawing.Size(80, 13);
            this.lblNFTotal.TabIndex = 10;
            this.lblNFTotal.Text = "Belge Toplamı :";
            // 
            // nmrInvoiceTotal
            // 
            this.nmrInvoiceTotal.DecimalPlaces = 2;
            this.nmrInvoiceTotal.Location = new System.Drawing.Point(122, 46);
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
            // 
            // gbxAdjustment
            // 
            this.gbxAdjustment.Controls.Add(this.nmrAdjAmount);
            this.gbxAdjustment.Controls.Add(this.rbtnFee);
            this.gbxAdjustment.Controls.Add(this.rbtnDiscount);
            this.gbxAdjustment.Controls.Add(this.cbxPerc);
            this.gbxAdjustment.Controls.Add(this.btnAdjust);
            this.gbxAdjustment.Controls.Add(this.lblAdjAmount);
            this.gbxAdjustment.Location = new System.Drawing.Point(30, 140);
            this.gbxAdjustment.Margin = new System.Windows.Forms.Padding(2);
            this.gbxAdjustment.Name = "gbxAdjustment";
            this.gbxAdjustment.Padding = new System.Windows.Forms.Padding(2);
            this.gbxAdjustment.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbxAdjustment.Size = new System.Drawing.Size(400, 63);
            this.gbxAdjustment.TabIndex = 15;
            this.gbxAdjustment.TabStop = false;
            this.gbxAdjustment.Text = "İndirim/Artırım";
            // 
            // nmrAdjAmount
            // 
            this.nmrAdjAmount.DecimalPlaces = 2;
            this.nmrAdjAmount.Location = new System.Drawing.Point(154, 31);
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
            this.rbtnFee.Location = new System.Drawing.Point(344, 41);
            this.rbtnFee.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnFee.Name = "rbtnFee";
            this.rbtnFee.Size = new System.Drawing.Size(53, 17);
            this.rbtnFee.TabIndex = 16;
            this.rbtnFee.Text = "Artırım";
            this.rbtnFee.UseVisualStyleBackColor = true;
            // 
            // rbtnDiscount
            // 
            this.rbtnDiscount.AutoSize = true;
            this.rbtnDiscount.Checked = true;
            this.rbtnDiscount.Location = new System.Drawing.Point(344, 17);
            this.rbtnDiscount.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnDiscount.Name = "rbtnDiscount";
            this.rbtnDiscount.Size = new System.Drawing.Size(55, 17);
            this.rbtnDiscount.TabIndex = 15;
            this.rbtnDiscount.TabStop = true;
            this.rbtnDiscount.Text = "İndirim";
            this.rbtnDiscount.UseVisualStyleBackColor = true;
            // 
            // cbxPerc
            // 
            this.cbxPerc.AutoSize = true;
            this.cbxPerc.Location = new System.Drawing.Point(247, 31);
            this.cbxPerc.Margin = new System.Windows.Forms.Padding(2);
            this.cbxPerc.Name = "cbxPerc";
            this.cbxPerc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbxPerc.Size = new System.Drawing.Size(70, 17);
            this.cbxPerc.TabIndex = 14;
            this.cbxPerc.Text = "Yüzde(%)";
            this.cbxPerc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxPerc.UseVisualStyleBackColor = true;
            this.cbxPerc.CheckedChanged += new System.EventHandler(this.cbxPerc_CheckedChanged);
            // 
            // btnAdjust
            // 
            this.btnAdjust.Location = new System.Drawing.Point(4, 21);
            this.btnAdjust.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdjust.Name = "btnAdjust";
            this.btnAdjust.Size = new System.Drawing.Size(110, 35);
            this.btnAdjust.TabIndex = 11;
            this.btnAdjust.Text = "İnd/Art &Uygula";
            this.btnAdjust.UseVisualStyleBackColor = true;
            this.btnAdjust.Click += new System.EventHandler(this.btnAdjust_Click);
            // 
            // lblAdjAmount
            // 
            this.lblAdjAmount.AutoSize = true;
            this.lblAdjAmount.Location = new System.Drawing.Point(141, 14);
            this.lblAdjAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAdjAmount.Name = "lblAdjAmount";
            this.lblAdjAmount.Size = new System.Drawing.Size(74, 13);
            this.lblAdjAmount.TabIndex = 13;
            this.lblAdjAmount.Text = "İnd/Art Miktarı";
            // 
            // cbxInvoice
            // 
            this.cbxInvoice.AutoSize = true;
            this.cbxInvoice.Location = new System.Drawing.Point(170, 16);
            this.cbxInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.cbxInvoice.Name = "cbxInvoice";
            this.cbxInvoice.Size = new System.Drawing.Size(56, 17);
            this.cbxInvoice.TabIndex = 20;
            this.cbxInvoice.Text = "Fatura";
            this.cbxInvoice.UseVisualStyleBackColor = true;
            this.cbxInvoice.CheckedChanged += new System.EventHandler(this.cbxInvoice_CheckedChanged);
            // 
            // gbxCustMsg
            // 
            this.gbxCustMsg.Controls.Add(this.txtRcptBarcode);
            this.gbxCustMsg.Controls.Add(this.btnRcptBarcode);
            this.gbxCustMsg.Controls.Add(this.lblBarkod);
            this.gbxCustMsg.Controls.Add(this.txtRemarkLine);
            this.gbxCustMsg.Controls.Add(this.btnRemark);
            this.gbxCustMsg.Controls.Add(this.lblRemark);
            this.gbxCustMsg.Location = new System.Drawing.Point(30, 322);
            this.gbxCustMsg.Margin = new System.Windows.Forms.Padding(2);
            this.gbxCustMsg.Name = "gbxCustMsg";
            this.gbxCustMsg.Padding = new System.Windows.Forms.Padding(2);
            this.gbxCustMsg.Size = new System.Drawing.Size(400, 90);
            this.gbxCustMsg.TabIndex = 17;
            this.gbxCustMsg.TabStop = false;
            this.gbxCustMsg.Text = "Açıklama Satırı";
            // 
            // txtRcptBarcode
            // 
            this.txtRcptBarcode.Location = new System.Drawing.Point(151, 67);
            this.txtRcptBarcode.Margin = new System.Windows.Forms.Padding(2);
            this.txtRcptBarcode.MaxLength = 25;
            this.txtRcptBarcode.Name = "txtRcptBarcode";
            this.txtRcptBarcode.Size = new System.Drawing.Size(226, 20);
            this.txtRcptBarcode.TabIndex = 12;
            // 
            // btnRcptBarcode
            // 
            this.btnRcptBarcode.Location = new System.Drawing.Point(4, 63);
            this.btnRcptBarcode.Margin = new System.Windows.Forms.Padding(2);
            this.btnRcptBarcode.Name = "btnRcptBarcode";
            this.btnRcptBarcode.Size = new System.Drawing.Size(110, 23);
            this.btnRcptBarcode.TabIndex = 10;
            this.btnRcptBarcode.Text = "Fiş Barkodu";
            this.btnRcptBarcode.UseVisualStyleBackColor = true;
            this.btnRcptBarcode.Click += new System.EventHandler(this.btnRcptBarcode_Click);
            // 
            // lblBarkod
            // 
            this.lblBarkod.AutoSize = true;
            this.lblBarkod.Location = new System.Drawing.Point(150, 51);
            this.lblBarkod.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBarkod.Name = "lblBarkod";
            this.lblBarkod.Size = new System.Drawing.Size(41, 13);
            this.lblBarkod.TabIndex = 11;
            this.lblBarkod.Text = "Barkod";
            // 
            // txtRemarkLine
            // 
            this.txtRemarkLine.Location = new System.Drawing.Point(151, 31);
            this.txtRemarkLine.Margin = new System.Windows.Forms.Padding(2);
            this.txtRemarkLine.MaxLength = 45;
            this.txtRemarkLine.Name = "txtRemarkLine";
            this.txtRemarkLine.Size = new System.Drawing.Size(226, 20);
            this.txtRemarkLine.TabIndex = 9;
            // 
            // btnRemark
            // 
            this.btnRemark.Location = new System.Drawing.Point(4, 29);
            this.btnRemark.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemark.Name = "btnRemark";
            this.btnRemark.Size = new System.Drawing.Size(110, 23);
            this.btnRemark.TabIndex = 6;
            this.btnRemark.Text = "Açıklama &Yaz";
            this.btnRemark.UseVisualStyleBackColor = true;
            this.btnRemark.Click += new System.EventHandler(this.btnRemark_Click);
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(150, 15);
            this.lblRemark.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(50, 13);
            this.lblRemark.TabIndex = 8;
            this.lblRemark.Text = "Açıklama";
            // 
            // gbxPayment
            // 
            this.gbxPayment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxPayment.Controls.Add(this.lblFCurrValue);
            this.gbxPayment.Controls.Add(this.btnRefreshCredit);
            this.gbxPayment.Controls.Add(this.lblPayIndx);
            this.gbxPayment.Controls.Add(this.cbxSubPayments);
            this.gbxPayment.Controls.Add(this.nmrPaymentAmount);
            this.gbxPayment.Controls.Add(this.btnPayment);
            this.gbxPayment.Controls.Add(this.lblPayType);
            this.gbxPayment.Controls.Add(this.lblPayAmount);
            this.gbxPayment.Controls.Add(this.cbxPaymentType);
            this.gbxPayment.Location = new System.Drawing.Point(30, 222);
            this.gbxPayment.Margin = new System.Windows.Forms.Padding(2);
            this.gbxPayment.Name = "gbxPayment";
            this.gbxPayment.Padding = new System.Windows.Forms.Padding(2);
            this.gbxPayment.Size = new System.Drawing.Size(436, 79);
            this.gbxPayment.TabIndex = 16;
            this.gbxPayment.TabStop = false;
            this.gbxPayment.Text = "Ödeme";
            // 
            // lblFCurrValue
            // 
            this.lblFCurrValue.AutoSize = true;
            this.lblFCurrValue.Location = new System.Drawing.Point(150, 58);
            this.lblFCurrValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFCurrValue.Name = "lblFCurrValue";
            this.lblFCurrValue.Size = new System.Drawing.Size(0, 13);
            this.lblFCurrValue.TabIndex = 20;
            // 
            // btnRefreshCredit
            // 
            this.btnRefreshCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshCredit.Image = global::FP300Service.Properties.Resources.refresh;
            this.btnRefreshCredit.Location = new System.Drawing.Point(396, 24);
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
            this.lblPayIndx.Location = new System.Drawing.Point(290, 15);
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
            this.cbxSubPayments.Location = new System.Drawing.Point(283, 34);
            this.cbxSubPayments.Margin = new System.Windows.Forms.Padding(2);
            this.cbxSubPayments.Name = "cbxSubPayments";
            this.cbxSubPayments.Size = new System.Drawing.Size(109, 21);
            this.cbxSubPayments.TabIndex = 17;
            this.cbxSubPayments.SelectedIndexChanged += new System.EventHandler(this.cbxSubPayments_SelectedIndexChanged);
            // 
            // nmrPaymentAmount
            // 
            this.nmrPaymentAmount.DecimalPlaces = 2;
            this.nmrPaymentAmount.Location = new System.Drawing.Point(128, 34);
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
            this.btnPayment.Location = new System.Drawing.Point(4, 17);
            this.btnPayment.Margin = new System.Windows.Forms.Padding(2);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(110, 35);
            this.btnPayment.TabIndex = 6;
            this.btnPayment.Text = "&Ödeme";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // lblPayType
            // 
            this.lblPayType.AutoSize = true;
            this.lblPayType.Location = new System.Drawing.Point(204, 15);
            this.lblPayType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPayType.Name = "lblPayType";
            this.lblPayType.Size = new System.Drawing.Size(61, 13);
            this.lblPayType.TabIndex = 10;
            this.lblPayType.Text = "Ödeme Tipi";
            // 
            // lblPayAmount
            // 
            this.lblPayAmount.AutoSize = true;
            this.lblPayAmount.Location = new System.Drawing.Point(125, 15);
            this.lblPayAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPayAmount.Name = "lblPayAmount";
            this.lblPayAmount.Size = new System.Drawing.Size(75, 13);
            this.lblPayAmount.TabIndex = 8;
            this.lblPayAmount.Text = "Ödeme Miktarı";
            // 
            // cbxPaymentType
            // 
            this.cbxPaymentType.FormattingEnabled = true;
            this.cbxPaymentType.Location = new System.Drawing.Point(207, 34);
            this.cbxPaymentType.Margin = new System.Windows.Forms.Padding(2);
            this.cbxPaymentType.Name = "cbxPaymentType";
            this.cbxPaymentType.Size = new System.Drawing.Size(70, 21);
            this.cbxPaymentType.TabIndex = 9;
            this.cbxPaymentType.SelectedIndexChanged += new System.EventHandler(this.cbxPaymentType_SelectedIndexChanged);
            // 
            // btnSubtotal
            // 
            this.btnSubtotal.Location = new System.Drawing.Point(469, 209);
            this.btnSubtotal.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubtotal.Name = "btnSubtotal";
            this.btnSubtotal.Size = new System.Drawing.Size(110, 35);
            this.btnSubtotal.TabIndex = 5;
            this.btnSubtotal.Text = "&Aratoplam";
            this.btnSubtotal.UseVisualStyleBackColor = true;
            this.btnSubtotal.Click += new System.EventHandler(this.btnSubtotal_Click);
            // 
            // btnVoidReceipt
            // 
            this.btnVoidReceipt.Location = new System.Drawing.Point(470, 288);
            this.btnVoidReceipt.Margin = new System.Windows.Forms.Padding(2);
            this.btnVoidReceipt.Name = "btnVoidReceipt";
            this.btnVoidReceipt.Size = new System.Drawing.Size(110, 35);
            this.btnVoidReceipt.TabIndex = 4;
            this.btnVoidReceipt.Text = "Belge İ&ptal";
            this.btnVoidReceipt.UseVisualStyleBackColor = true;
            this.btnVoidReceipt.Click += new System.EventHandler(this.btnVoidReceipt_Click);
            // 
            // btnCloseReceipt
            // 
            this.btnCloseReceipt.Location = new System.Drawing.Point(470, 248);
            this.btnCloseReceipt.Margin = new System.Windows.Forms.Padding(2);
            this.btnCloseReceipt.Name = "btnCloseReceipt";
            this.btnCloseReceipt.Size = new System.Drawing.Size(110, 35);
            this.btnCloseReceipt.TabIndex = 3;
            this.btnCloseReceipt.Text = "Belge &Kapat";
            this.btnCloseReceipt.UseVisualStyleBackColor = true;
            this.btnCloseReceipt.Click += new System.EventHandler(this.btnCloseReceipt_Click);
            // 
            // btnStartReceipt
            // 
            this.btnStartReceipt.Location = new System.Drawing.Point(30, 5);
            this.btnStartReceipt.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartReceipt.Name = "btnStartReceipt";
            this.btnStartReceipt.Size = new System.Drawing.Size(110, 37);
            this.btnStartReceipt.TabIndex = 1;
            this.btnStartReceipt.Text = "&Belge Başlat";
            this.btnStartReceipt.UseVisualStyleBackColor = true;
            this.btnStartReceipt.Click += new System.EventHandler(this.btnStartReceipt_Click);
            // 
            // btnOpenDrawer
            // 
            this.btnOpenDrawer.Location = new System.Drawing.Point(470, 327);
            this.btnOpenDrawer.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenDrawer.Name = "btnOpenDrawer";
            this.btnOpenDrawer.Size = new System.Drawing.Size(110, 30);
            this.btnOpenDrawer.TabIndex = 22;
            this.btnOpenDrawer.Text = "&Çekmece Aç";
            this.btnOpenDrawer.UseVisualStyleBackColor = true;
            this.btnOpenDrawer.Click += new System.EventHandler(this.btnOpenDrawer_Click);
            // 
            // cbxWithPrice
            // 
            this.cbxWithPrice.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxWithPrice.Checked = true;
            this.cbxWithPrice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxWithPrice.Location = new System.Drawing.Point(330, 16);
            this.cbxWithPrice.Margin = new System.Windows.Forms.Padding(2);
            this.cbxWithPrice.Name = "cbxWithPrice";
            this.cbxWithPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbxWithPrice.Size = new System.Drawing.Size(61, 17);
            this.cbxWithPrice.TabIndex = 21;
            this.cbxWithPrice.Text = "Fiyat";
            this.cbxWithPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxWithPrice.UseVisualStyleBackColor = true;
            // 
            // SaleUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOpenDrawer);
            this.Controls.Add(this.gbxSale);
            this.Controls.Add(this.gbxInvoice);
            this.Controls.Add(this.cbxInvoice);
            this.Controls.Add(this.gbxCustMsg);
            this.Controls.Add(this.gbxPayment);
            this.Controls.Add(this.gbxAdjustment);
            this.Controls.Add(this.btnSubtotal);
            this.Controls.Add(this.btnVoidReceipt);
            this.Controls.Add(this.btnCloseReceipt);
            this.Controls.Add(this.btnStartReceipt);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SaleUC";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbxSale.ResumeLayout(false);
            this.gbxSale.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPlu)).EndInit();
            this.gbxInvoice.ResumeLayout(false);
            this.gbxInvoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrInvoiceTotal)).EndInit();
            this.gbxAdjustment.ResumeLayout(false);
            this.gbxAdjustment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrAdjAmount)).EndInit();
            this.gbxCustMsg.ResumeLayout(false);
            this.gbxCustMsg.PerformLayout();
            this.gbxPayment.ResumeLayout(false);
            this.gbxPayment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPaymentAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnStartReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                CPResponse response;

                if (cbxInvoice.Checked) // Checking for doc is invoice or receipt
                {
                    // Serial 
                    string serial = txtInvoiceNum.Text;

                    // Amount
                    decimal amount = nmrInvoiceTotal.Value;

                    // Date
                    DateTime date = dtInvoiceDate.Value;

                    response = new CPResponse(bridge.Printer.PrintDocumentHeader(serial, amount, date));

                }
                else
                {
                    response = new CPResponse(bridge.Printer.PrintDocumentHeader());
                }

                if (response.ErrorCode == 0)
                {
                    bridge.Log("Fiş No: " + response.GetNextParam());
                }
            }
            catch (System.Exception ex)
            {
                bridge.Log("Hata: Fiş başlatma başarısız.");
            }
        }

        private void btnSaleSample_Click(object sender, EventArgs e)
        {
            int pluNo = (int)nmrPlu.Value;
            Decimal quantity = nmrQuantity.Value;
            Decimal price = Decimal.MinusOne;

            if (cbxWithPrice.Checked)
            {
                price = nmrPrice.Value;
            }
            try
            {
                CPResponse response = new CPResponse(bridge.Printer.PrintItem(pluNo, quantity, price, null, -1));

                if (response.ErrorCode == 0)
                {
                    bridge.Log(String.Format("Aratoplam: {0}", response.GetNextParam()));
                }
            }
            catch
            {
                bridge.Log("Hata: Satış yapılamadı.");
            }
        }

        private void btnCloseReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                bridge.Connection.FPUTimeout = ProgramConfig.FPU_RPRT_TIMEOUT;

                CPResponse response = new CPResponse(bridge.Printer.CloseReceipt());
                
                if (response.ErrorCode == 0)
                {
                     bridge.Log("Fiş No: " + response.GetNextParam());
                }
            }
            catch
            {
                bridge.Log("Hata: Satış yapılamadı.");
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
                    bridge.Log("İptal Fiş No: " + response.GetNextParam());
                }
            }
            catch (System.Exception ex)
            {
                bridge.Log("Hata: Fiş iptal başarısız.");
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
                CPResponse response = new CPResponse(bridge.Printer.PrintSubtotal());

                if (response.ErrorCode == 0)
                {
                    bridge.Log(String.Format("Aratoplam: {0}", response.GetNextParam()));

                    bridge.Log(String.Format("Ödeme Toplamı: {0}", response.GetNextParam()));
                }
            }
            catch (System.Exception ex)
            {
                bridge.Log("Hata: İşlem başarısız.");
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                int index = -1;

                //PAYMENT TYPE
                int paymentType = cbxPaymentType.SelectedIndex;

                //IF PAYMENT IS FOREIGN CURRENCY OR CREDIT
                if (cbxPaymentType.Text == "Döviz" || cbxPaymentType.Text == "Kredi")
                {
                    //Index
                    index = cbxSubPayments.SelectedIndex;
                }

                //PAYMENT AMOUNT
                decimal amount = nmrPaymentAmount.Value;

                // SEND COMMAND
                CPResponse response = new CPResponse(bridge.Printer.PrintPayment(paymentType, index, amount));

                if (response.ErrorCode == 0)
                {
                    bridge.Log(String.Format("Aratoplam: {0}", response.GetNextParam()));
                    
                    bridge.Log(String.Format("Ödeme Toplamı: {0}", response.GetNextParam()));                       
                }
            }
            catch (System.Exception ex)
            {
                bridge.Log("Hata: Ödeme başarısız.");
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
                    bridge.Log(String.Format("Aratoplam: {0:#0.00}", response.GetNextParam()));
                }
            }
            catch (System.Exception ex)
            {
                bridge.Log("Hata: İşlem başarısız.");
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
                CPResponse response = new CPResponse(bridge.Printer.PrintRemarkLine(line));
            }
            catch (System.Exception ex)
            {
                bridge.Log("Hata: İşlem başarısız.");
            }
        }

        private void cbxPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRefreshCredit.Visible = false;
            lblFCurrValue.Visible = false;

            switch (cbxPaymentType.Text)
            {
                case "Döviz":
                    RefreshCurrencyList();
                        lblPayIndx.Visible = true;
                        cbxSubPayments.Visible = true;
                        lblFCurrValue.Visible = true;
                    break;
                case "Kredi":
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
            lblPayIndx.Text = "Dövizler";
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
                bridge.Log("Krediler alınıyor.");
                creditCount = LoadCreditData();
                bridge.Log("Krediler yüklendi.");
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
                    lblPayIndx.Text = "Krediler";
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
                    bridge.Log("Kredi alma başarısız.");
                }
            }


            return creditCount;
        }

        private void nmrPaymentAmount_ValueChanged(object sender, EventArgs e)
        {
            if (cbxPaymentType.Text == "Döviz")
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
            if (cbxPaymentType.Text == "Döviz")
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
                bridge.Log("Hata: İşlem başarısız.");
            }
        }

        private void cbxInvoice_CheckedChanged(object sender, EventArgs e)
        {
            gbxAdjustment.Visible = !cbxInvoice.Checked;
            gbxSale.Visible = !cbxInvoice.Checked;
            gbxCustMsg.Visible = !cbxInvoice.Checked;
            btnSubtotal.Visible = !cbxInvoice.Checked;
            gbxInvoice.Visible = cbxInvoice.Checked;
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
                bridge.Log("Hata: İşlem başarısız.");
            }
        }

    }
}
