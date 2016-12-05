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
        private Label lblNFTotal;
        private NumericUpDown nmrAdvanceAmount;
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
        private TabPage tabAdvance;
        private Button btnPaidDoc;
        private TabPage tbpStartParking;
        private Button btnStartParkDoc;
        private Label lblEFTAmount;
        private NumericUpDown nmrEFTAmount;
        private Label lblCardNum;
        private Label lblInstallment;
        private NumericUpDown nmrInstallment;
        private TextBox txtCardNumber;
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
        private Panel panelVoidEFT;
        private TextBox txtAcquierId;
        private Label lblAcquierId;
        private TextBox txtStanNo;
        private TextBox txtBatchNo;
        private Label label4;
        private Label label3;
        private Label label5;
        private CheckBox checkBoxVoidEft;
        private TabPage tabRefund;
        private TextBox txtAcquierIdRefund;
        private Label label6;
        private Button btnRefund;
        private TabPage tabPageBankList;
        private Button btnBankList;
        private Button btnRcptInfo;
        private Button buttonAutoPrintPLU;
        private TabPage tpgSaleDept;
        private Label lblDeptSalePrice;
        private Label lblDeptName;
        private Button btnSaleDept;
        private NumericUpDown nmrDeptSalePrice;
        private TextBox txtDeptSaleName;
        private Label lblDeptSaleId;
        private Label lblDeptSaleQtty;
        private NumericUpDown nmrDeptSaleId;
        private NumericUpDown nmrDeptSaleQtty;
        private CheckBox cbxDeptSaleWeighable;
        private Button btnJsonOnlyDept;
        private CheckBox cbxVoidDept;
        private Label lblVoidDeptName;
        private TextBox txtVoidDeptName;
        private DateTimePicker dateTimePickerInvoiceIssueDate;
        private TextBox txtboxInvoiceSerialNo;
        private Label label8;
        private Label label7;
        private TextBox txtboxAdvanceTCKN;
        private TextBox txtboxAdvanceName;
        private Label labelAdvanceTCKN;
        private Label labelAdvanceName;
        private TabPage tabPageFood;
        private Button buttonStartFoodDoc;
        private TabPage tabPageCollection;
        private Button buttonStartCllctnDoc;
        private TextBox textBoxCllctnSerial;
        private Label label9;
        private Label label10;
        private NumericUpDown numericUpDownCllctnAmount;
        private Label label11;
        private TextBox textBoxSubscriberNo;
        private CheckBox checkBoxComission;
        private Label label13;
        private NumericUpDown numericUpDownComission;
        private TextBox textBoxInstutionName;
        private Label label12;
        private TableLayoutPanel tableLayoutPanelSaleUc;
        private TableLayoutPanel tableLayoutPanelSaleUCLeft;
        private TableLayoutPanel tableLayoutPanelSaleUCRight;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel6;
        private TableLayoutPanel tableLayoutPanel7;
        private TableLayoutPanel tableLayoutPanel8;
        private TableLayoutPanel tableLayoutPanel9;
        private TableLayoutPanel tableLayoutPanel10;
        private TableLayoutPanel tableLayoutPanel11;
        private TableLayoutPanel tableLayoutPanel12;
        private TableLayoutPanel tableLayoutPanel13;
        private TableLayoutPanel tableLayoutPanel14;
        private TableLayoutPanel tableLayoutPanel15;
        private Label label14;
        private DateTimePicker dateTimePickerCllctionInvDate;
        private TabPage tabPageEftSlipCopy;
        private CheckBox checkBoxSlpCpyZnoRcptNo;
        private Button buttonGetEFTSlipCopy;
        private TextBox textBoxSlpCpyRcptNo;
        private TextBox textBoxSlpCpyZNo;
        private Label labelSlpCpyRcptNo;
        private Label labelSlpCpyZNo;
        private TextBox textBoxSlpCpyStanNo;
        private TextBox textBoxSlpCpyBatchNo;
        private Label labelSlpCpyStanNo;
        private Label labelSlpCpyBatchNo;
        private TextBox textBoxSlpCpyAcquirId;
        private Label label17;
        private Button buttonAutoPrintDEPT;
        private TabPage tabPageBarcode;
        private Button buttonPrintSalesDocument;
        private TableLayoutPanel tableLayoutPanel16;
        private Button btnRcptBarcode;
        private TableLayoutPanel tableLayoutPanel17;
        private Label labelBarcode;
        private Label labelBarcodeType;
        private ComboBox comboBoxBarcodeTypes;
        private TextBox txtRcptBarcode;
        private Timer timer1;
        private IContainer components;
        private Timer timer2;
        private Button btnRefreshCredit;


        public SaleUC()
            : base()
        {
            InitializeComponent();

            SetLanguageOption();

            cbxPaymentType.Items.AddRange(Common.Payments);
            cbxPaymentType.SelectedIndex = 0;

            cbxInvTypes.Items.AddRange(Common.InvDocTypes);
            cbxInvTypes.SelectedIndex = 0;

            comboBoxBarcodeTypes.Items.AddRange(Common.BarcodeTypes);
            comboBoxBarcodeTypes.SelectedIndex = 0;

            nmrPrice.Enabled = false;
            lblAmount.Enabled = false;
            checkBoxForPrice.Checked = false;
            panelVoidEFT.Enabled = false;

            numericUpDownComission.Enabled = false;

            labelSlpCpyZNo.Enabled = false;
            labelSlpCpyRcptNo.Enabled = false;
            textBoxSlpCpyZNo.Enabled = false;
            textBoxSlpCpyRcptNo.Enabled = false;
        }

        private void SetLanguageOption()
        {
            this.bntPrintJSONDoc.Text = FormMessage.PRINT_JSON;
            this.tbpPay1.Text = FormMessage.CASH_PAYMENTS;
            this.tbpPayEFT.Text = FormMessage.EFT_PAYMENT;
            this.lblEFTAmount.Text = FormMessage.PAYMENT_AMOUNT;
            this.lblCardNum.Text = FormMessage.CARD_NUMBER;
            this.lblInstallment.Text = FormMessage.INSTALLMENT;
            this.btnEFTAuthorization.Text = FormMessage.GET_EFT_PAYMENT;
            this.btnCardQuery.Text = FormMessage.CHECK_CARD;
            this.tbpVoidPay.Text = FormMessage.VOID_PAYMENT;
            this.label5.Text = FormMessage.VOID_EFT;
            this.label4.Text = FormMessage.STAN_NO;
            this.label3.Text = FormMessage.BATCH_NO;
            this.lblAcquierId.Text = FormMessage.ACQUIER_ID;
            this.tabRefund.Text = FormMessage.EFT_REFUND;
            this.label6.Text = FormMessage.ACQUIER_ID;
            this.btnRefund.Text = FormMessage.REFUND;
            this.tbpSale.Text = FormMessage.SALE;
            this.lblWeighable.Text = FormMessage.WEIGHABLE;
            this.lblName.Text = FormMessage.PLU_NAME;
            this.lblBarcode.Text = FormMessage.BARCODE;
            this.lblDeptId.Text = FormMessage.DEPARTMENT_ID;
            this.lblAmount.Text = FormMessage.PRICE;
            this.tbpVoidSale.Text = FormMessage.VOID_SALE;
            this.tbpAdj.Text = FormMessage.ADJUSTMENT;
            this.tbpNotes.Text = FormMessage.FOOTER_NOTES;
            this.tbpExtra.Text = FormMessage.FOOTER_NOTES_EXTRA;
            this.tbStrtRcpt.Text = FormMessage.RECEIPT;
            this.tbStrtInvoice.Text = FormMessage.INVOICE_TYPES;
            this.lblDocTypeInv.Text = FormMessage.DOCUMENT_TYPE;
            this.btnStartInvoice.Text = FormMessage.START_DOCUMENT;
            this.tabAdvance.Text = FormMessage.ADVANCE;
            this.btnPaidDoc.Text = FormMessage.START_DOCUMENT;
            this.tbpStartParking.Text = FormMessage.PARKING;
            this.btnStartParkDoc.Text = FormMessage.START_DOCUMENT;
            this.tabPageBankList.Text = FormMessage.BANK_LIST;
            this.btnBankList.Text = FormMessage.GET_BANK_LIST;
            this.cbxSaveAndSale.Text = FormMessage.SAVE_AND_SALE;
            this.lblQuantity.Text = FormMessage.QUANTITY;
            this.lblPlu.Text = FormMessage.PLU;
            this.btnSale.Text = FormMessage.SALE;
            this.label1.Text = FormMessage.ENTRY_TIME;
            this.lblPlate.Text = FormMessage.PLATE;
            this.lblInvSerial.Text = "TCKN / VKN";
            this.lblNFTotal.Text = FormMessage.DOC_TOTAL;
            this.btnRcptBarcode.Text = FormMessage.BARCODE;
            this.btnRemark.Text = FormMessage.REMARK;
            this.btnCorrect.Text = FormMessage.CORRECT;
            this.lblVoidQtty.Text = FormMessage.VOID_QUANTITY;
            this.lblVoidPlu.Text = FormMessage.PLU;
            this.btnVoidSale.Text = FormMessage.VOID_SALE;
            this.btnPayment.Text = FormMessage.PAYMENT;
            this.lblPayType.Text = FormMessage.PAYMENT_TYPE;
            this.lblPayAmount.Text = FormMessage.PAYMENT_AMOUNT;
            this.rbtnFee.Text = FormMessage.FEE;
            this.rbtnDiscount.Text = FormMessage.DISCOUNT;
            this.cbxPerc.Text = FormMessage.PERCENTAGE;
            this.btnAdjust.Text = FormMessage.ADJUST;
            this.lblAdjAmount.Text = FormMessage.ADJUSTMENT_AMOUNT;
            this.btnSubtotal.Text = FormMessage.SUBTOTAL;
            this.btnVoidReceipt.Text = FormMessage.VOID_DOCUMENT;
            this.btnCloseReceipt.Text = FormMessage.CLOSE_DOCUMENT;
            this.btnStartReceipt.Text = FormMessage.START_DOCUMENT;
            this.btnOpenDrawer.Text = FormMessage.OPEN_DRAWER;
            this.chbSlipCopy.Text = FormMessage.SLIP_COPY;
            this.btnVoidPayment.Text = FormMessage.VOID_PAYMENT;
            this.label2.Text = FormMessage.PAYMENT_INDEX;
            this.labelAdvanceTCKN.Text = FormMessage.TCKN;
            this.labelAdvanceName.Text = FormMessage.CUSTOMER_NAME;
            this.tabPageCollection.Text = FormMessage.COLLECTION_DOC;
            this.tabPageFood.Text = FormMessage.FOOD_DOC;
            this.buttonPrintSalesDocument.Text = FormMessage.PRINT_SALES_DOCUMENT;
            this.labelBarcodeType.Text = FormMessage.BARCODE_TYPE;
            this.labelBarcode.Text = FormMessage.BARCODE;
            
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
            this.components = new System.ComponentModel.Container();
            this.tbcStartDoc = new System.Windows.Forms.TabControl();
            this.tbStrtRcpt = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnStartReceipt = new System.Windows.Forms.Button();
            this.tbStrtInvoice = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.btnStartInvoice = new System.Windows.Forms.Button();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDocTypeInv = new System.Windows.Forms.Label();
            this.cbxInvTypes = new System.Windows.Forms.ComboBox();
            this.lblInvSerial = new System.Windows.Forms.Label();
            this.txtTCKN_VKN = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePickerInvoiceIssueDate = new System.Windows.Forms.DateTimePicker();
            this.txtboxInvoiceSerialNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabAdvance = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPaidDoc = new System.Windows.Forms.Button();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.labelAdvanceTCKN = new System.Windows.Forms.Label();
            this.nmrAdvanceAmount = new System.Windows.Forms.NumericUpDown();
            this.txtboxAdvanceName = new System.Windows.Forms.TextBox();
            this.txtboxAdvanceTCKN = new System.Windows.Forms.TextBox();
            this.labelAdvanceName = new System.Windows.Forms.Label();
            this.lblNFTotal = new System.Windows.Forms.Label();
            this.tbpStartParking = new System.Windows.Forms.TabPage();
            this.dtParkTime = new System.Windows.Forms.DateTimePicker();
            this.btnStartParkDoc = new System.Windows.Forms.Button();
            this.dtParkDate = new System.Windows.Forms.DateTimePicker();
            this.lblPlate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPlate = new System.Windows.Forms.TextBox();
            this.tabPageFood = new System.Windows.Forms.TabPage();
            this.buttonStartFoodDoc = new System.Windows.Forms.Button();
            this.tabPageCollection = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.dateTimePickerCllctionInvDate = new System.Windows.Forms.DateTimePicker();
            this.checkBoxComission = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpDownComission = new System.Windows.Forms.NumericUpDown();
            this.textBoxInstutionName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxSubscriberNo = new System.Windows.Forms.TextBox();
            this.numericUpDownCllctnAmount = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxCllctnSerial = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonStartCllctnDoc = new System.Windows.Forms.Button();
            this.tbcFooter = new System.Windows.Forms.TabControl();
            this.tbpNotes = new System.Windows.Forms.TabPage();
            this.btnRemark = new System.Windows.Forms.Button();
            this.txtRemarkLine = new System.Windows.Forms.TextBox();
            this.tbpExtra = new System.Windows.Forms.TabPage();
            this.btnOpenDrawer = new System.Windows.Forms.Button();
            this.tabPageBarcode = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRcptBarcode = new System.Windows.Forms.Button();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.labelBarcode = new System.Windows.Forms.Label();
            this.labelBarcodeType = new System.Windows.Forms.Label();
            this.comboBoxBarcodeTypes = new System.Windows.Forms.ComboBox();
            this.txtRcptBarcode = new System.Windows.Forms.TextBox();
            this.tbcSale = new System.Windows.Forms.TabControl();
            this.tbpSale = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPlu = new System.Windows.Forms.Label();
            this.nmrPlu = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.nmrQuantity = new System.Windows.Forms.NumericUpDown();
            this.nmrPrice = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxForPrice = new System.Windows.Forms.CheckBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.btnSale = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlExtraPlufields = new System.Windows.Forms.Panel();
            this.lblWeighable = new System.Windows.Forms.Label();
            this.checkBoxWeighable = new System.Windows.Forms.CheckBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDeptId = new System.Windows.Forms.Label();
            this.nmrDept = new System.Windows.Forms.NumericUpDown();
            this.cbxSaveAndSale = new System.Windows.Forms.CheckBox();
            this.tbpVoidSale = new System.Windows.Forms.TabPage();
            this.lblVoidDeptName = new System.Windows.Forms.Label();
            this.txtVoidDeptName = new System.Windows.Forms.TextBox();
            this.cbxVoidDept = new System.Windows.Forms.CheckBox();
            this.lblVoidQtty = new System.Windows.Forms.Label();
            this.btnVoidSale = new System.Windows.Forms.Button();
            this.nmrVoidQtty = new System.Windows.Forms.NumericUpDown();
            this.nmrVoidPlu = new System.Windows.Forms.NumericUpDown();
            this.lblVoidPlu = new System.Windows.Forms.Label();
            this.tbpAdj = new System.Windows.Forms.TabPage();
            this.nmrAdjAmount = new System.Windows.Forms.NumericUpDown();
            this.btnAdjust = new System.Windows.Forms.Button();
            this.rbtnFee = new System.Windows.Forms.RadioButton();
            this.lblAdjAmount = new System.Windows.Forms.Label();
            this.rbtnDiscount = new System.Windows.Forms.RadioButton();
            this.cbxPerc = new System.Windows.Forms.CheckBox();
            this.tpgSaleDept = new System.Windows.Forms.TabPage();
            this.cbxDeptSaleWeighable = new System.Windows.Forms.CheckBox();
            this.lblDeptSalePrice = new System.Windows.Forms.Label();
            this.lblDeptName = new System.Windows.Forms.Label();
            this.btnSaleDept = new System.Windows.Forms.Button();
            this.nmrDeptSalePrice = new System.Windows.Forms.NumericUpDown();
            this.txtDeptSaleName = new System.Windows.Forms.TextBox();
            this.lblDeptSaleId = new System.Windows.Forms.Label();
            this.lblDeptSaleQtty = new System.Windows.Forms.Label();
            this.nmrDeptSaleId = new System.Windows.Forms.NumericUpDown();
            this.nmrDeptSaleQtty = new System.Windows.Forms.NumericUpDown();
            this.tbcPayment = new System.Windows.Forms.TabControl();
            this.tbpPay1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPayAmount = new System.Windows.Forms.Label();
            this.nmrPaymentAmount = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPayType = new System.Windows.Forms.Label();
            this.cbxPaymentType = new System.Windows.Forms.ComboBox();
            this.btnRefreshCredit = new System.Windows.Forms.Button();
            this.cbxSubPayments = new System.Windows.Forms.ComboBox();
            this.btnPayment = new System.Windows.Forms.Button();
            this.lblFCurrValue = new System.Windows.Forms.Label();
            this.lblPayIndx = new System.Windows.Forms.Label();
            this.tbpPayEFT = new System.Windows.Forms.TabPage();
            this.lblEFTAmount = new System.Windows.Forms.Label();
            this.nmrEFTAmount = new System.Windows.Forms.NumericUpDown();
            this.lblCardNum = new System.Windows.Forms.Label();
            this.lblInstallment = new System.Windows.Forms.Label();
            this.nmrInstallment = new System.Windows.Forms.NumericUpDown();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.btnEFTAuthorization = new System.Windows.Forms.Button();
            this.btnCardQuery = new System.Windows.Forms.Button();
            this.chbSlipCopy = new System.Windows.Forms.CheckBox();
            this.tbpVoidPay = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxVoidEft = new System.Windows.Forms.CheckBox();
            this.panelVoidEFT = new System.Windows.Forms.Panel();
            this.txtStanNo = new System.Windows.Forms.TextBox();
            this.txtBatchNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAcquierId = new System.Windows.Forms.TextBox();
            this.lblAcquierId = new System.Windows.Forms.Label();
            this.btnVoidPayment = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nmrVoidPayIndex = new System.Windows.Forms.NumericUpDown();
            this.tabRefund = new System.Windows.Forms.TabPage();
            this.txtAcquierIdRefund = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRefund = new System.Windows.Forms.Button();
            this.tabPageBankList = new System.Windows.Forms.TabPage();
            this.btnBankList = new System.Windows.Forms.Button();
            this.tabPageEftSlipCopy = new System.Windows.Forms.TabPage();
            this.checkBoxSlpCpyZnoRcptNo = new System.Windows.Forms.CheckBox();
            this.buttonGetEFTSlipCopy = new System.Windows.Forms.Button();
            this.textBoxSlpCpyRcptNo = new System.Windows.Forms.TextBox();
            this.textBoxSlpCpyZNo = new System.Windows.Forms.TextBox();
            this.labelSlpCpyRcptNo = new System.Windows.Forms.Label();
            this.labelSlpCpyZNo = new System.Windows.Forms.Label();
            this.textBoxSlpCpyStanNo = new System.Windows.Forms.TextBox();
            this.textBoxSlpCpyBatchNo = new System.Windows.Forms.TextBox();
            this.labelSlpCpyStanNo = new System.Windows.Forms.Label();
            this.labelSlpCpyBatchNo = new System.Windows.Forms.Label();
            this.textBoxSlpCpyAcquirId = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.bntPrintJSONDoc = new System.Windows.Forms.Button();
            this.btnCorrect = new System.Windows.Forms.Button();
            this.btnSubtotal = new System.Windows.Forms.Button();
            this.btnVoidReceipt = new System.Windows.Forms.Button();
            this.btnCloseReceipt = new System.Windows.Forms.Button();
            this.btnRcptInfo = new System.Windows.Forms.Button();
            this.buttonAutoPrintPLU = new System.Windows.Forms.Button();
            this.btnJsonOnlyDept = new System.Windows.Forms.Button();
            this.tableLayoutPanelSaleUc = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelSaleUCLeft = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelSaleUCRight = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPrintSalesDocument = new System.Windows.Forms.Button();
            this.buttonAutoPrintDEPT = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tbcStartDoc.SuspendLayout();
            this.tbStrtRcpt.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tbStrtInvoice.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            this.tabAdvance.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrAdvanceAmount)).BeginInit();
            this.tbpStartParking.SuspendLayout();
            this.tabPageFood.SuspendLayout();
            this.tabPageCollection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownComission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCllctnAmount)).BeginInit();
            this.tbcFooter.SuspendLayout();
            this.tbpNotes.SuspendLayout();
            this.tbpExtra.SuspendLayout();
            this.tabPageBarcode.SuspendLayout();
            this.tableLayoutPanel16.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            this.tbcSale.SuspendLayout();
            this.tbpSale.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPlu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPrice)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.pnlExtraPlufields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrDept)).BeginInit();
            this.tbpVoidSale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrVoidQtty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrVoidPlu)).BeginInit();
            this.tbpAdj.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrAdjAmount)).BeginInit();
            this.tpgSaleDept.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrDeptSalePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrDeptSaleId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrDeptSaleQtty)).BeginInit();
            this.tbcPayment.SuspendLayout();
            this.tbpPay1.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPaymentAmount)).BeginInit();
            this.tableLayoutPanel9.SuspendLayout();
            this.tbpPayEFT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrEFTAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrInstallment)).BeginInit();
            this.tbpVoidPay.SuspendLayout();
            this.panelVoidEFT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrVoidPayIndex)).BeginInit();
            this.tabRefund.SuspendLayout();
            this.tabPageBankList.SuspendLayout();
            this.tabPageEftSlipCopy.SuspendLayout();
            this.tableLayoutPanelSaleUc.SuspendLayout();
            this.tableLayoutPanelSaleUCLeft.SuspendLayout();
            this.tableLayoutPanelSaleUCRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcStartDoc
            // 
            this.tbcStartDoc.Controls.Add(this.tbStrtRcpt);
            this.tbcStartDoc.Controls.Add(this.tbStrtInvoice);
            this.tbcStartDoc.Controls.Add(this.tabAdvance);
            this.tbcStartDoc.Controls.Add(this.tbpStartParking);
            this.tbcStartDoc.Controls.Add(this.tabPageFood);
            this.tbcStartDoc.Controls.Add(this.tabPageCollection);
            this.tbcStartDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcStartDoc.Location = new System.Drawing.Point(2, 2);
            this.tbcStartDoc.Margin = new System.Windows.Forms.Padding(2);
            this.tbcStartDoc.Name = "tbcStartDoc";
            this.tbcStartDoc.SelectedIndex = 0;
            this.tbcStartDoc.Size = new System.Drawing.Size(469, 126);
            this.tbcStartDoc.TabIndex = 30;
            // 
            // tbStrtRcpt
            // 
            this.tbStrtRcpt.Controls.Add(this.tableLayoutPanel5);
            this.tbStrtRcpt.Location = new System.Drawing.Point(4, 22);
            this.tbStrtRcpt.Margin = new System.Windows.Forms.Padding(2);
            this.tbStrtRcpt.Name = "tbStrtRcpt";
            this.tbStrtRcpt.Padding = new System.Windows.Forms.Padding(2);
            this.tbStrtRcpt.Size = new System.Drawing.Size(461, 100);
            this.tbStrtRcpt.TabIndex = 0;
            this.tbStrtRcpt.Text = "RECEIPT";
            this.tbStrtRcpt.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.btnStartReceipt, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(457, 96);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // btnStartReceipt
            // 
            this.btnStartReceipt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStartReceipt.Location = new System.Drawing.Point(173, 29);
            this.btnStartReceipt.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartReceipt.Name = "btnStartReceipt";
            this.btnStartReceipt.Size = new System.Drawing.Size(110, 37);
            this.btnStartReceipt.TabIndex = 1;
            this.btnStartReceipt.Text = "START DOCUMENT";
            this.btnStartReceipt.UseVisualStyleBackColor = true;
            this.btnStartReceipt.Click += new System.EventHandler(this.btnStartReceipt_Click);
            // 
            // tbStrtInvoice
            // 
            this.tbStrtInvoice.Controls.Add(this.tableLayoutPanel10);
            this.tbStrtInvoice.Location = new System.Drawing.Point(4, 22);
            this.tbStrtInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.tbStrtInvoice.Name = "tbStrtInvoice";
            this.tbStrtInvoice.Padding = new System.Windows.Forms.Padding(2);
            this.tbStrtInvoice.Size = new System.Drawing.Size(461, 100);
            this.tbStrtInvoice.TabIndex = 1;
            this.tbStrtInvoice.Text = "INVOICE TYPES";
            this.tbStrtInvoice.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79F));
            this.tableLayoutPanel10.Controls.Add(this.btnStartInvoice, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel11, 1, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(457, 96);
            this.tableLayoutPanel10.TabIndex = 33;
            // 
            // btnStartInvoice
            // 
            this.btnStartInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartInvoice.Location = new System.Drawing.Point(2, 2);
            this.btnStartInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartInvoice.Name = "btnStartInvoice";
            this.btnStartInvoice.Size = new System.Drawing.Size(91, 92);
            this.btnStartInvoice.TabIndex = 2;
            this.btnStartInvoice.Text = "START DOCUMENT";
            this.btnStartInvoice.UseVisualStyleBackColor = true;
            this.btnStartInvoice.Click += new System.EventHandler(this.btnStartInvoice_Click);
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 1;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Controls.Add(this.tableLayoutPanel12, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.tableLayoutPanel13, 0, 1);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(98, 3);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(356, 90);
            this.tableLayoutPanel11.TabIndex = 3;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 4;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.71428F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel12.Controls.Add(this.lblDocTypeInv, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.cbxInvTypes, 1, 0);
            this.tableLayoutPanel12.Controls.Add(this.lblInvSerial, 2, 0);
            this.tableLayoutPanel12.Controls.Add(this.txtTCKN_VKN, 3, 0);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 1;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(350, 39);
            this.tableLayoutPanel12.TabIndex = 0;
            // 
            // lblDocTypeInv
            // 
            this.lblDocTypeInv.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDocTypeInv.AutoSize = true;
            this.lblDocTypeInv.Location = new System.Drawing.Point(12, 6);
            this.lblDocTypeInv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDocTypeInv.Name = "lblDocTypeInv";
            this.lblDocTypeInv.Size = new System.Drawing.Size(59, 26);
            this.lblDocTypeInv.TabIndex = 28;
            this.lblDocTypeInv.Text = "Document Type";
            // 
            // cbxInvTypes
            // 
            this.cbxInvTypes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxInvTypes.FormattingEnabled = true;
            this.cbxInvTypes.Location = new System.Drawing.Point(85, 9);
            this.cbxInvTypes.Margin = new System.Windows.Forms.Padding(2);
            this.cbxInvTypes.Name = "cbxInvTypes";
            this.cbxInvTypes.Size = new System.Drawing.Size(87, 21);
            this.cbxInvTypes.TabIndex = 27;
            // 
            // lblInvSerial
            // 
            this.lblInvSerial.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInvSerial.AutoSize = true;
            this.lblInvSerial.Location = new System.Drawing.Point(183, 13);
            this.lblInvSerial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInvSerial.Name = "lblInvSerial";
            this.lblInvSerial.Size = new System.Drawing.Size(69, 13);
            this.lblInvSerial.TabIndex = 25;
            this.lblInvSerial.Text = "TCKN / VKN";
            // 
            // txtTCKN_VKN
            // 
            this.txtTCKN_VKN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTCKN_VKN.Location = new System.Drawing.Point(263, 9);
            this.txtTCKN_VKN.Margin = new System.Windows.Forms.Padding(2);
            this.txtTCKN_VKN.MaxLength = 11;
            this.txtTCKN_VKN.Name = "txtTCKN_VKN";
            this.txtTCKN_VKN.Size = new System.Drawing.Size(85, 20);
            this.txtTCKN_VKN.TabIndex = 26;
            this.txtTCKN_VKN.Text = "1234567890";
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 4;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.42857F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.28572F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel13.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.dateTimePickerInvoiceIssueDate, 1, 0);
            this.tableLayoutPanel13.Controls.Add(this.txtboxInvoiceSerialNo, 3, 0);
            this.tableLayoutPanel13.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(3, 48);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 1;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(350, 39);
            this.tableLayoutPanel13.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 13);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Issue Date:";
            // 
            // dateTimePickerInvoiceIssueDate
            // 
            this.dateTimePickerInvoiceIssueDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePickerInvoiceIssueDate.Location = new System.Drawing.Point(85, 9);
            this.dateTimePickerInvoiceIssueDate.Name = "dateTimePickerInvoiceIssueDate";
            this.dateTimePickerInvoiceIssueDate.Size = new System.Drawing.Size(86, 20);
            this.dateTimePickerInvoiceIssueDate.TabIndex = 32;
            // 
            // txtboxInvoiceSerialNo
            // 
            this.txtboxInvoiceSerialNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtboxInvoiceSerialNo.Location = new System.Drawing.Point(263, 9);
            this.txtboxInvoiceSerialNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtboxInvoiceSerialNo.MaxLength = 11;
            this.txtboxInvoiceSerialNo.Name = "txtboxInvoiceSerialNo";
            this.txtboxInvoiceSerialNo.Size = new System.Drawing.Size(85, 20);
            this.txtboxInvoiceSerialNo.TabIndex = 31;
            this.txtboxInvoiceSerialNo.Text = "HGN1234567";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(180, 13);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Invoice Serial:";
            // 
            // tabAdvance
            // 
            this.tabAdvance.Controls.Add(this.tableLayoutPanel14);
            this.tabAdvance.Location = new System.Drawing.Point(4, 22);
            this.tabAdvance.Margin = new System.Windows.Forms.Padding(2);
            this.tabAdvance.Name = "tabAdvance";
            this.tabAdvance.Padding = new System.Windows.Forms.Padding(2);
            this.tabAdvance.Size = new System.Drawing.Size(461, 100);
            this.tabAdvance.TabIndex = 2;
            this.tabAdvance.Text = "ADVANCE";
            this.tabAdvance.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 2;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.75711F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.24289F));
            this.tableLayoutPanel14.Controls.Add(this.btnPaidDoc, 0, 0);
            this.tableLayoutPanel14.Controls.Add(this.tableLayoutPanel15, 1, 0);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 1;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(457, 96);
            this.tableLayoutPanel14.TabIndex = 25;
            // 
            // btnPaidDoc
            // 
            this.btnPaidDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPaidDoc.Location = new System.Drawing.Point(2, 2);
            this.btnPaidDoc.Margin = new System.Windows.Forms.Padding(2);
            this.btnPaidDoc.Name = "btnPaidDoc";
            this.btnPaidDoc.Size = new System.Drawing.Size(99, 92);
            this.btnPaidDoc.TabIndex = 3;
            this.btnPaidDoc.Text = "START DOCUMENT";
            this.btnPaidDoc.UseVisualStyleBackColor = true;
            this.btnPaidDoc.Click += new System.EventHandler(this.btnPaidDoc_Click);
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 2;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.59942F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.40058F));
            this.tableLayoutPanel15.Controls.Add(this.labelAdvanceTCKN, 0, 0);
            this.tableLayoutPanel15.Controls.Add(this.nmrAdvanceAmount, 1, 2);
            this.tableLayoutPanel15.Controls.Add(this.txtboxAdvanceName, 1, 1);
            this.tableLayoutPanel15.Controls.Add(this.txtboxAdvanceTCKN, 1, 0);
            this.tableLayoutPanel15.Controls.Add(this.labelAdvanceName, 0, 1);
            this.tableLayoutPanel15.Controls.Add(this.lblNFTotal, 0, 2);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(106, 3);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 3;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(348, 90);
            this.tableLayoutPanel15.TabIndex = 4;
            // 
            // labelAdvanceTCKN
            // 
            this.labelAdvanceTCKN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAdvanceTCKN.AutoSize = true;
            this.labelAdvanceTCKN.Location = new System.Drawing.Point(44, 8);
            this.labelAdvanceTCKN.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAdvanceTCKN.Name = "labelAdvanceTCKN";
            this.labelAdvanceTCKN.Size = new System.Drawing.Size(39, 13);
            this.labelAdvanceTCKN.TabIndex = 12;
            this.labelAdvanceTCKN.Text = "TCKN:";
            // 
            // nmrAdvanceAmount
            // 
            this.nmrAdvanceAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nmrAdvanceAmount.DecimalPlaces = 2;
            this.nmrAdvanceAmount.Location = new System.Drawing.Point(164, 64);
            this.nmrAdvanceAmount.Margin = new System.Windows.Forms.Padding(2);
            this.nmrAdvanceAmount.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            131072});
            this.nmrAdvanceAmount.Name = "nmrAdvanceAmount";
            this.nmrAdvanceAmount.Size = new System.Drawing.Size(146, 20);
            this.nmrAdvanceAmount.TabIndex = 9;
            this.nmrAdvanceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrAdvanceAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtboxAdvanceName
            // 
            this.txtboxAdvanceName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtboxAdvanceName.Location = new System.Drawing.Point(164, 33);
            this.txtboxAdvanceName.Margin = new System.Windows.Forms.Padding(2);
            this.txtboxAdvanceName.MaxLength = 15;
            this.txtboxAdvanceName.Name = "txtboxAdvanceName";
            this.txtboxAdvanceName.Size = new System.Drawing.Size(146, 20);
            this.txtboxAdvanceName.TabIndex = 23;
            // 
            // txtboxAdvanceTCKN
            // 
            this.txtboxAdvanceTCKN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtboxAdvanceTCKN.Location = new System.Drawing.Point(165, 4);
            this.txtboxAdvanceTCKN.Margin = new System.Windows.Forms.Padding(2);
            this.txtboxAdvanceTCKN.MaxLength = 11;
            this.txtboxAdvanceTCKN.Name = "txtboxAdvanceTCKN";
            this.txtboxAdvanceTCKN.Size = new System.Drawing.Size(144, 20);
            this.txtboxAdvanceTCKN.TabIndex = 24;
            // 
            // labelAdvanceName
            // 
            this.labelAdvanceName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAdvanceName.AutoSize = true;
            this.labelAdvanceName.Location = new System.Drawing.Point(43, 37);
            this.labelAdvanceName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAdvanceName.Name = "labelAdvanceName";
            this.labelAdvanceName.Size = new System.Drawing.Size(41, 13);
            this.labelAdvanceName.TabIndex = 11;
            this.labelAdvanceName.Text = "NAME:";
            // 
            // lblNFTotal
            // 
            this.lblNFTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNFTotal.AutoSize = true;
            this.lblNFTotal.Location = new System.Drawing.Point(35, 67);
            this.lblNFTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNFTotal.Name = "lblNFTotal";
            this.lblNFTotal.Size = new System.Drawing.Size(57, 13);
            this.lblNFTotal.TabIndex = 10;
            this.lblNFTotal.Text = "AMOUNT:";
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
            this.tbpStartParking.Size = new System.Drawing.Size(461, 100);
            this.tbpStartParking.TabIndex = 3;
            this.tbpStartParking.Text = "OTOPARK";
            this.tbpStartParking.UseVisualStyleBackColor = true;
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
            // tabPageFood
            // 
            this.tabPageFood.Controls.Add(this.buttonStartFoodDoc);
            this.tabPageFood.Location = new System.Drawing.Point(4, 22);
            this.tabPageFood.Name = "tabPageFood";
            this.tabPageFood.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFood.Size = new System.Drawing.Size(461, 100);
            this.tabPageFood.TabIndex = 4;
            this.tabPageFood.Text = "FOOD";
            this.tabPageFood.UseVisualStyleBackColor = true;
            // 
            // buttonStartFoodDoc
            // 
            this.buttonStartFoodDoc.Location = new System.Drawing.Point(28, 20);
            this.buttonStartFoodDoc.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStartFoodDoc.Name = "buttonStartFoodDoc";
            this.buttonStartFoodDoc.Size = new System.Drawing.Size(110, 37);
            this.buttonStartFoodDoc.TabIndex = 5;
            this.buttonStartFoodDoc.Text = "START DOCUMENT";
            this.buttonStartFoodDoc.UseVisualStyleBackColor = true;
            this.buttonStartFoodDoc.Click += new System.EventHandler(this.buttonStartFoodDoc_Click);
            // 
            // tabPageCollection
            // 
            this.tabPageCollection.Controls.Add(this.label14);
            this.tabPageCollection.Controls.Add(this.dateTimePickerCllctionInvDate);
            this.tabPageCollection.Controls.Add(this.checkBoxComission);
            this.tabPageCollection.Controls.Add(this.label13);
            this.tabPageCollection.Controls.Add(this.numericUpDownComission);
            this.tabPageCollection.Controls.Add(this.textBoxInstutionName);
            this.tabPageCollection.Controls.Add(this.label12);
            this.tabPageCollection.Controls.Add(this.label11);
            this.tabPageCollection.Controls.Add(this.textBoxSubscriberNo);
            this.tabPageCollection.Controls.Add(this.numericUpDownCllctnAmount);
            this.tabPageCollection.Controls.Add(this.label10);
            this.tabPageCollection.Controls.Add(this.textBoxCllctnSerial);
            this.tabPageCollection.Controls.Add(this.label9);
            this.tabPageCollection.Controls.Add(this.buttonStartCllctnDoc);
            this.tabPageCollection.Location = new System.Drawing.Point(4, 22);
            this.tabPageCollection.Name = "tabPageCollection";
            this.tabPageCollection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCollection.Size = new System.Drawing.Size(461, 100);
            this.tabPageCollection.TabIndex = 5;
            this.tabPageCollection.Text = "COLLECTION INV";
            this.tabPageCollection.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(252, 58);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 13);
            this.label14.TabIndex = 43;
            this.label14.Text = "Fatura Tarihi";
            // 
            // dateTimePickerCllctionInvDate
            // 
            this.dateTimePickerCllctionInvDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePickerCllctionInvDate.Location = new System.Drawing.Point(255, 75);
            this.dateTimePickerCllctionInvDate.Name = "dateTimePickerCllctionInvDate";
            this.dateTimePickerCllctionInvDate.Size = new System.Drawing.Size(86, 20);
            this.dateTimePickerCllctionInvDate.TabIndex = 42;
            // 
            // checkBoxComission
            // 
            this.checkBoxComission.AutoSize = true;
            this.checkBoxComission.Location = new System.Drawing.Point(364, 58);
            this.checkBoxComission.Name = "checkBoxComission";
            this.checkBoxComission.Size = new System.Drawing.Size(15, 14);
            this.checkBoxComission.TabIndex = 41;
            this.checkBoxComission.UseVisualStyleBackColor = true;
            this.checkBoxComission.CheckStateChanged += new System.EventHandler(this.checkBox1_CheckStateChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(381, 58);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 40;
            this.label13.Text = "Komisyon:";
            // 
            // numericUpDownComission
            // 
            this.numericUpDownComission.DecimalPlaces = 2;
            this.numericUpDownComission.Location = new System.Drawing.Point(355, 75);
            this.numericUpDownComission.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownComission.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            131072});
            this.numericUpDownComission.Name = "numericUpDownComission";
            this.numericUpDownComission.Size = new System.Drawing.Size(91, 20);
            this.numericUpDownComission.TabIndex = 39;
            this.numericUpDownComission.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownComission.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // textBoxInstutionName
            // 
            this.textBoxInstutionName.Location = new System.Drawing.Point(147, 27);
            this.textBoxInstutionName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxInstutionName.MaxLength = 21;
            this.textBoxInstutionName.Name = "textBoxInstutionName";
            this.textBoxInstutionName.Size = new System.Drawing.Size(194, 20);
            this.textBoxInstutionName.TabIndex = 38;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(147, 10);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 37;
            this.label12.Text = "Kurum Adı:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(147, 60);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 36;
            this.label11.Text = "Abone No:";
            // 
            // textBoxSubscriberNo
            // 
            this.textBoxSubscriberNo.Location = new System.Drawing.Point(143, 76);
            this.textBoxSubscriberNo.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSubscriberNo.MaxLength = 11;
            this.textBoxSubscriberNo.Name = "textBoxSubscriberNo";
            this.textBoxSubscriberNo.Size = new System.Drawing.Size(91, 20);
            this.textBoxSubscriberNo.TabIndex = 35;
            this.textBoxSubscriberNo.Text = "123456789";
            // 
            // numericUpDownCllctnAmount
            // 
            this.numericUpDownCllctnAmount.DecimalPlaces = 2;
            this.numericUpDownCllctnAmount.Location = new System.Drawing.Point(355, 27);
            this.numericUpDownCllctnAmount.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownCllctnAmount.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            131072});
            this.numericUpDownCllctnAmount.Name = "numericUpDownCllctnAmount";
            this.numericUpDownCllctnAmount.Size = new System.Drawing.Size(91, 20);
            this.numericUpDownCllctnAmount.TabIndex = 34;
            this.numericUpDownCllctnAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownCllctnAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(361, 12);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Tutar:";
            // 
            // textBoxCllctnSerial
            // 
            this.textBoxCllctnSerial.Location = new System.Drawing.Point(20, 76);
            this.textBoxCllctnSerial.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCllctnSerial.MaxLength = 11;
            this.textBoxCllctnSerial.Name = "textBoxCllctnSerial";
            this.textBoxCllctnSerial.Size = new System.Drawing.Size(91, 20);
            this.textBoxCllctnSerial.TabIndex = 32;
            this.textBoxCllctnSerial.Text = "HGN1234567";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 60);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Invoice Serial:";
            // 
            // buttonStartCllctnDoc
            // 
            this.buttonStartCllctnDoc.Location = new System.Drawing.Point(8, 10);
            this.buttonStartCllctnDoc.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStartCllctnDoc.Name = "buttonStartCllctnDoc";
            this.buttonStartCllctnDoc.Size = new System.Drawing.Size(110, 37);
            this.buttonStartCllctnDoc.TabIndex = 5;
            this.buttonStartCllctnDoc.Text = "START DOCUMENT";
            this.buttonStartCllctnDoc.UseVisualStyleBackColor = true;
            this.buttonStartCllctnDoc.Click += new System.EventHandler(this.buttonStartCllctnDoc_Click);
            // 
            // tbcFooter
            // 
            this.tbcFooter.Controls.Add(this.tbpNotes);
            this.tbcFooter.Controls.Add(this.tbpExtra);
            this.tbcFooter.Controls.Add(this.tabPageBarcode);
            this.tbcFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcFooter.Location = new System.Drawing.Point(2, 392);
            this.tbcFooter.Margin = new System.Windows.Forms.Padding(2);
            this.tbcFooter.Name = "tbcFooter";
            this.tbcFooter.SelectedIndex = 0;
            this.tbcFooter.Size = new System.Drawing.Size(469, 98);
            this.tbcFooter.TabIndex = 29;
            // 
            // tbpNotes
            // 
            this.tbpNotes.Controls.Add(this.btnRemark);
            this.tbpNotes.Controls.Add(this.txtRemarkLine);
            this.tbpNotes.Location = new System.Drawing.Point(4, 22);
            this.tbpNotes.Margin = new System.Windows.Forms.Padding(2);
            this.tbpNotes.Name = "tbpNotes";
            this.tbpNotes.Padding = new System.Windows.Forms.Padding(2);
            this.tbpNotes.Size = new System.Drawing.Size(461, 72);
            this.tbpNotes.TabIndex = 0;
            this.tbpNotes.Text = "FOOTER NOTES";
            this.tbpNotes.UseVisualStyleBackColor = true;
            // 
            // btnRemark
            // 
            this.btnRemark.Location = new System.Drawing.Point(8, 12);
            this.btnRemark.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemark.Name = "btnRemark";
            this.btnRemark.Size = new System.Drawing.Size(110, 48);
            this.btnRemark.TabIndex = 6;
            this.btnRemark.Text = "REMARK";
            this.btnRemark.UseVisualStyleBackColor = true;
            this.btnRemark.Click += new System.EventHandler(this.btnRemark_Click);
            // 
            // txtRemarkLine
            // 
            this.txtRemarkLine.Location = new System.Drawing.Point(131, 4);
            this.txtRemarkLine.Margin = new System.Windows.Forms.Padding(2);
            this.txtRemarkLine.MaxLength = 45;
            this.txtRemarkLine.Multiline = true;
            this.txtRemarkLine.Name = "txtRemarkLine";
            this.txtRemarkLine.Size = new System.Drawing.Size(319, 64);
            this.txtRemarkLine.TabIndex = 9;
            // 
            // tbpExtra
            // 
            this.tbpExtra.Controls.Add(this.btnOpenDrawer);
            this.tbpExtra.Location = new System.Drawing.Point(4, 22);
            this.tbpExtra.Margin = new System.Windows.Forms.Padding(2);
            this.tbpExtra.Name = "tbpExtra";
            this.tbpExtra.Padding = new System.Windows.Forms.Padding(2);
            this.tbpExtra.Size = new System.Drawing.Size(461, 72);
            this.tbpExtra.TabIndex = 1;
            this.tbpExtra.Text = "FOOTER NOTE EXTRA";
            this.tbpExtra.UseVisualStyleBackColor = true;
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
            // tabPageBarcode
            // 
            this.tabPageBarcode.Controls.Add(this.tableLayoutPanel16);
            this.tabPageBarcode.Location = new System.Drawing.Point(4, 22);
            this.tabPageBarcode.Name = "tabPageBarcode";
            this.tabPageBarcode.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBarcode.Size = new System.Drawing.Size(461, 72);
            this.tabPageBarcode.TabIndex = 2;
            this.tabPageBarcode.Text = "BARCODE";
            this.tabPageBarcode.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.ColumnCount = 2;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78F));
            this.tableLayoutPanel16.Controls.Add(this.btnRcptBarcode, 0, 0);
            this.tableLayoutPanel16.Controls.Add(this.tableLayoutPanel17, 1, 0);
            this.tableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel16.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 1;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel16.Size = new System.Drawing.Size(455, 66);
            this.tableLayoutPanel16.TabIndex = 0;
            // 
            // btnRcptBarcode
            // 
            this.btnRcptBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRcptBarcode.Location = new System.Drawing.Point(2, 2);
            this.btnRcptBarcode.Margin = new System.Windows.Forms.Padding(2);
            this.btnRcptBarcode.Name = "btnRcptBarcode";
            this.btnRcptBarcode.Size = new System.Drawing.Size(96, 62);
            this.btnRcptBarcode.TabIndex = 24;
            this.btnRcptBarcode.Text = "PRINT BARCODE";
            this.btnRcptBarcode.UseVisualStyleBackColor = true;
            this.btnRcptBarcode.Click += new System.EventHandler(this.btnRcptBarcode_Click);
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.ColumnCount = 2;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel17.Controls.Add(this.labelBarcode, 0, 1);
            this.tableLayoutPanel17.Controls.Add(this.labelBarcodeType, 0, 0);
            this.tableLayoutPanel17.Controls.Add(this.comboBoxBarcodeTypes, 1, 0);
            this.tableLayoutPanel17.Controls.Add(this.txtRcptBarcode, 1, 1);
            this.tableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel17.Location = new System.Drawing.Point(103, 3);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 2;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel17.Size = new System.Drawing.Size(349, 60);
            this.tableLayoutPanel17.TabIndex = 25;
            // 
            // labelBarcode
            // 
            this.labelBarcode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelBarcode.AutoSize = true;
            this.labelBarcode.Location = new System.Drawing.Point(56, 38);
            this.labelBarcode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBarcode.Name = "labelBarcode";
            this.labelBarcode.Size = new System.Drawing.Size(62, 13);
            this.labelBarcode.TabIndex = 30;
            this.labelBarcode.Text = "BARCODE ";
            // 
            // labelBarcodeType
            // 
            this.labelBarcodeType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelBarcodeType.AutoSize = true;
            this.labelBarcodeType.Location = new System.Drawing.Point(42, 8);
            this.labelBarcodeType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBarcodeType.Name = "labelBarcodeType";
            this.labelBarcodeType.Size = new System.Drawing.Size(90, 13);
            this.labelBarcodeType.TabIndex = 27;
            this.labelBarcodeType.Text = "BARCODE TYPE";
            // 
            // comboBoxBarcodeTypes
            // 
            this.comboBoxBarcodeTypes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxBarcodeTypes.FormattingEnabled = true;
            this.comboBoxBarcodeTypes.Location = new System.Drawing.Point(200, 4);
            this.comboBoxBarcodeTypes.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxBarcodeTypes.Name = "comboBoxBarcodeTypes";
            this.comboBoxBarcodeTypes.Size = new System.Drawing.Size(123, 21);
            this.comboBoxBarcodeTypes.TabIndex = 28;
            // 
            // txtRcptBarcode
            // 
            this.txtRcptBarcode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRcptBarcode.Location = new System.Drawing.Point(176, 35);
            this.txtRcptBarcode.Margin = new System.Windows.Forms.Padding(2);
            this.txtRcptBarcode.MaxLength = 25;
            this.txtRcptBarcode.Name = "txtRcptBarcode";
            this.txtRcptBarcode.Size = new System.Drawing.Size(171, 20);
            this.txtRcptBarcode.TabIndex = 29;
            // 
            // tbcSale
            // 
            this.tbcSale.Controls.Add(this.tbpSale);
            this.tbcSale.Controls.Add(this.tbpVoidSale);
            this.tbcSale.Controls.Add(this.tbpAdj);
            this.tbcSale.Controls.Add(this.tpgSaleDept);
            this.tbcSale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcSale.Location = new System.Drawing.Point(2, 132);
            this.tbcSale.Margin = new System.Windows.Forms.Padding(2);
            this.tbcSale.Name = "tbcSale";
            this.tbcSale.SelectedIndex = 0;
            this.tbcSale.Size = new System.Drawing.Size(469, 141);
            this.tbcSale.TabIndex = 28;
            // 
            // tbpSale
            // 
            this.tbpSale.Controls.Add(this.tableLayoutPanel1);
            this.tbpSale.Location = new System.Drawing.Point(4, 22);
            this.tbpSale.Margin = new System.Windows.Forms.Padding(2);
            this.tbpSale.Name = "tbpSale";
            this.tbpSale.Padding = new System.Windows.Forms.Padding(2);
            this.tbpSale.Size = new System.Drawing.Size(461, 115);
            this.tbpSale.TabIndex = 0;
            this.tbpSale.Text = "SALE";
            this.tbpSale.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.53829F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.10722F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSale, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(457, 111);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lblPlu, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.nmrPlu, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblQuantity, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.nmrQuantity, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.nmrPrice, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(106, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(191, 105);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblPlu
            // 
            this.lblPlu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPlu.AutoSize = true;
            this.lblPlu.Location = new System.Drawing.Point(32, 10);
            this.lblPlu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlu.Name = "lblPlu";
            this.lblPlu.Size = new System.Drawing.Size(31, 13);
            this.lblPlu.TabIndex = 14;
            this.lblPlu.Text = "PLU:";
            // 
            // nmrPlu
            // 
            this.nmrPlu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nmrPlu.Location = new System.Drawing.Point(112, 7);
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
            // lblQuantity
            // 
            this.lblQuantity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(15, 44);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(65, 13);
            this.lblQuantity.TabIndex = 16;
            this.lblQuantity.Text = "QUANTITY:";
            // 
            // nmrQuantity
            // 
            this.nmrQuantity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nmrQuantity.DecimalPlaces = 3;
            this.nmrQuantity.Location = new System.Drawing.Point(112, 41);
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
            // nmrPrice
            // 
            this.nmrPrice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nmrPrice.DecimalPlaces = 2;
            this.nmrPrice.Location = new System.Drawing.Point(112, 76);
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
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.30303F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.69697F));
            this.tableLayoutPanel3.Controls.Add(this.checkBoxForPrice, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblAmount, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 71);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(89, 31);
            this.tableLayoutPanel3.TabIndex = 20;
            // 
            // checkBoxForPrice
            // 
            this.checkBoxForPrice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxForPrice.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxForPrice.Location = new System.Drawing.Point(5, 7);
            this.checkBoxForPrice.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxForPrice.Name = "checkBoxForPrice";
            this.checkBoxForPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxForPrice.Size = new System.Drawing.Size(15, 17);
            this.checkBoxForPrice.TabIndex = 29;
            this.checkBoxForPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxForPrice.UseVisualStyleBackColor = true;
            this.checkBoxForPrice.CheckedChanged += new System.EventHandler(this.checkBoxForPrice_CheckedChanged);
            // 
            // lblAmount
            // 
            this.lblAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(38, 9);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(39, 13);
            this.lblAmount.TabIndex = 21;
            this.lblAmount.Text = "PRICE";
            // 
            // btnSale
            // 
            this.btnSale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSale.Location = new System.Drawing.Point(2, 2);
            this.btnSale.Margin = new System.Windows.Forms.Padding(2);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(99, 107);
            this.btnSale.TabIndex = 2;
            this.btnSale.Text = "SALE";
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Click += new System.EventHandler(this.btnSaleSample_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.pnlExtraPlufields, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.cbxSaveAndSale, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(303, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(151, 105);
            this.tableLayoutPanel4.TabIndex = 3;
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
            this.pnlExtraPlufields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlExtraPlufields.Enabled = false;
            this.pnlExtraPlufields.Location = new System.Drawing.Point(2, 21);
            this.pnlExtraPlufields.Margin = new System.Windows.Forms.Padding(2);
            this.pnlExtraPlufields.Name = "pnlExtraPlufields";
            this.pnlExtraPlufields.Size = new System.Drawing.Size(147, 82);
            this.pnlExtraPlufields.TabIndex = 28;
            // 
            // lblWeighable
            // 
            this.lblWeighable.AutoSize = true;
            this.lblWeighable.Location = new System.Drawing.Point(68, 67);
            this.lblWeighable.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWeighable.Name = "lblWeighable";
            this.lblWeighable.Size = new System.Drawing.Size(71, 13);
            this.lblWeighable.TabIndex = 30;
            this.lblWeighable.Text = "WEIGHABLE";
            // 
            // checkBoxWeighable
            // 
            this.checkBoxWeighable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxWeighable.Location = new System.Drawing.Point(42, 65);
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
            // cbxSaveAndSale
            // 
            this.cbxSaveAndSale.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxSaveAndSale.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxSaveAndSale.Location = new System.Drawing.Point(5, 2);
            this.cbxSaveAndSale.Margin = new System.Windows.Forms.Padding(2);
            this.cbxSaveAndSale.Name = "cbxSaveAndSale";
            this.cbxSaveAndSale.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbxSaveAndSale.Size = new System.Drawing.Size(140, 15);
            this.cbxSaveAndSale.TabIndex = 20;
            this.cbxSaveAndSale.Text = "SAVE & SALE";
            this.cbxSaveAndSale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxSaveAndSale.UseVisualStyleBackColor = true;
            this.cbxSaveAndSale.CheckedChanged += new System.EventHandler(this.cbxSaveAndSale_CheckedChanged);
            // 
            // tbpVoidSale
            // 
            this.tbpVoidSale.Controls.Add(this.lblVoidDeptName);
            this.tbpVoidSale.Controls.Add(this.txtVoidDeptName);
            this.tbpVoidSale.Controls.Add(this.cbxVoidDept);
            this.tbpVoidSale.Controls.Add(this.lblVoidQtty);
            this.tbpVoidSale.Controls.Add(this.btnVoidSale);
            this.tbpVoidSale.Controls.Add(this.nmrVoidQtty);
            this.tbpVoidSale.Controls.Add(this.nmrVoidPlu);
            this.tbpVoidSale.Controls.Add(this.lblVoidPlu);
            this.tbpVoidSale.Location = new System.Drawing.Point(4, 22);
            this.tbpVoidSale.Margin = new System.Windows.Forms.Padding(2);
            this.tbpVoidSale.Name = "tbpVoidSale";
            this.tbpVoidSale.Padding = new System.Windows.Forms.Padding(2);
            this.tbpVoidSale.Size = new System.Drawing.Size(461, 115);
            this.tbpVoidSale.TabIndex = 1;
            this.tbpVoidSale.Text = "VOID SALE";
            this.tbpVoidSale.UseVisualStyleBackColor = true;
            // 
            // lblVoidDeptName
            // 
            this.lblVoidDeptName.AutoSize = true;
            this.lblVoidDeptName.Location = new System.Drawing.Point(337, 40);
            this.lblVoidDeptName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVoidDeptName.Name = "lblVoidDeptName";
            this.lblVoidDeptName.Size = new System.Drawing.Size(70, 13);
            this.lblVoidDeptName.TabIndex = 29;
            this.lblVoidDeptName.Text = "DEPT NAME";
            this.lblVoidDeptName.Visible = false;
            // 
            // txtVoidDeptName
            // 
            this.txtVoidDeptName.Location = new System.Drawing.Point(339, 58);
            this.txtVoidDeptName.Margin = new System.Windows.Forms.Padding(2);
            this.txtVoidDeptName.MaxLength = 20;
            this.txtVoidDeptName.Name = "txtVoidDeptName";
            this.txtVoidDeptName.Size = new System.Drawing.Size(104, 20);
            this.txtVoidDeptName.TabIndex = 28;
            this.txtVoidDeptName.Visible = false;
            // 
            // cbxVoidDept
            // 
            this.cbxVoidDept.AutoSize = true;
            this.cbxVoidDept.Location = new System.Drawing.Point(154, 16);
            this.cbxVoidDept.Margin = new System.Windows.Forms.Padding(2);
            this.cbxVoidDept.Name = "cbxVoidDept";
            this.cbxVoidDept.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbxVoidDept.Size = new System.Drawing.Size(105, 17);
            this.cbxVoidDept.TabIndex = 17;
            this.cbxVoidDept.Text = "Void Department";
            this.cbxVoidDept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxVoidDept.UseVisualStyleBackColor = true;
            this.cbxVoidDept.CheckedChanged += new System.EventHandler(this.cbxVoidDept_CheckedChanged);
            // 
            // lblVoidQtty
            // 
            this.lblVoidQtty.AutoSize = true;
            this.lblVoidQtty.Location = new System.Drawing.Point(233, 41);
            this.lblVoidQtty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVoidQtty.Name = "lblVoidQtty";
            this.lblVoidQtty.Size = new System.Drawing.Size(94, 13);
            this.lblVoidQtty.TabIndex = 16;
            this.lblVoidQtty.Text = "VOID QUANTITY:";
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
            // nmrVoidQtty
            // 
            this.nmrVoidQtty.DecimalPlaces = 3;
            this.nmrVoidQtty.Location = new System.Drawing.Point(236, 58);
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
            // nmrVoidPlu
            // 
            this.nmrVoidPlu.Location = new System.Drawing.Point(159, 58);
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
            // lblVoidPlu
            // 
            this.lblVoidPlu.AutoSize = true;
            this.lblVoidPlu.Location = new System.Drawing.Point(158, 41);
            this.lblVoidPlu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVoidPlu.Name = "lblVoidPlu";
            this.lblVoidPlu.Size = new System.Drawing.Size(31, 13);
            this.lblVoidPlu.TabIndex = 14;
            this.lblVoidPlu.Text = "PLU:";
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
            this.tbpAdj.Size = new System.Drawing.Size(461, 115);
            this.tbpAdj.TabIndex = 2;
            this.tbpAdj.Text = "ADJUSTMENT";
            this.tbpAdj.UseVisualStyleBackColor = true;
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
            // tpgSaleDept
            // 
            this.tpgSaleDept.Controls.Add(this.cbxDeptSaleWeighable);
            this.tpgSaleDept.Controls.Add(this.lblDeptSalePrice);
            this.tpgSaleDept.Controls.Add(this.lblDeptName);
            this.tpgSaleDept.Controls.Add(this.btnSaleDept);
            this.tpgSaleDept.Controls.Add(this.nmrDeptSalePrice);
            this.tpgSaleDept.Controls.Add(this.txtDeptSaleName);
            this.tpgSaleDept.Controls.Add(this.lblDeptSaleId);
            this.tpgSaleDept.Controls.Add(this.lblDeptSaleQtty);
            this.tpgSaleDept.Controls.Add(this.nmrDeptSaleId);
            this.tpgSaleDept.Controls.Add(this.nmrDeptSaleQtty);
            this.tpgSaleDept.Location = new System.Drawing.Point(4, 22);
            this.tpgSaleDept.Margin = new System.Windows.Forms.Padding(2);
            this.tpgSaleDept.Name = "tpgSaleDept";
            this.tpgSaleDept.Padding = new System.Windows.Forms.Padding(2);
            this.tpgSaleDept.Size = new System.Drawing.Size(461, 115);
            this.tpgSaleDept.TabIndex = 3;
            this.tpgSaleDept.Text = "DEPT SALE";
            this.tpgSaleDept.UseVisualStyleBackColor = true;
            // 
            // cbxDeptSaleWeighable
            // 
            this.cbxDeptSaleWeighable.Location = new System.Drawing.Point(334, 45);
            this.cbxDeptSaleWeighable.Margin = new System.Windows.Forms.Padding(2);
            this.cbxDeptSaleWeighable.Name = "cbxDeptSaleWeighable";
            this.cbxDeptSaleWeighable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbxDeptSaleWeighable.Size = new System.Drawing.Size(104, 17);
            this.cbxDeptSaleWeighable.TabIndex = 38;
            this.cbxDeptSaleWeighable.Text = "WEIGHABLE";
            this.cbxDeptSaleWeighable.UseVisualStyleBackColor = true;
            // 
            // lblDeptSalePrice
            // 
            this.lblDeptSalePrice.AutoSize = true;
            this.lblDeptSalePrice.Location = new System.Drawing.Point(140, 71);
            this.lblDeptSalePrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeptSalePrice.Name = "lblDeptSalePrice";
            this.lblDeptSalePrice.Size = new System.Drawing.Size(39, 13);
            this.lblDeptSalePrice.TabIndex = 37;
            this.lblDeptSalePrice.Text = "PRICE";
            // 
            // lblDeptName
            // 
            this.lblDeptName.AutoSize = true;
            this.lblDeptName.Location = new System.Drawing.Point(275, 18);
            this.lblDeptName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeptName.Name = "lblDeptName";
            this.lblDeptName.Size = new System.Drawing.Size(70, 13);
            this.lblDeptName.TabIndex = 27;
            this.lblDeptName.Text = "DEPT NAME";
            // 
            // btnSaleDept
            // 
            this.btnSaleDept.Location = new System.Drawing.Point(4, 20);
            this.btnSaleDept.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaleDept.Name = "btnSaleDept";
            this.btnSaleDept.Size = new System.Drawing.Size(110, 37);
            this.btnSaleDept.TabIndex = 30;
            this.btnSaleDept.Text = "SALE";
            this.btnSaleDept.UseVisualStyleBackColor = true;
            this.btnSaleDept.Click += new System.EventHandler(this.btnSaleDept_Click);
            // 
            // nmrDeptSalePrice
            // 
            this.nmrDeptSalePrice.DecimalPlaces = 2;
            this.nmrDeptSalePrice.Location = new System.Drawing.Point(184, 66);
            this.nmrDeptSalePrice.Margin = new System.Windows.Forms.Padding(2);
            this.nmrDeptSalePrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nmrDeptSalePrice.Name = "nmrDeptSalePrice";
            this.nmrDeptSalePrice.Size = new System.Drawing.Size(62, 20);
            this.nmrDeptSalePrice.TabIndex = 35;
            this.nmrDeptSalePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrDeptSalePrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtDeptSaleName
            // 
            this.txtDeptSaleName.Location = new System.Drawing.Point(350, 15);
            this.txtDeptSaleName.Margin = new System.Windows.Forms.Padding(2);
            this.txtDeptSaleName.MaxLength = 20;
            this.txtDeptSaleName.Name = "txtDeptSaleName";
            this.txtDeptSaleName.Size = new System.Drawing.Size(90, 20);
            this.txtDeptSaleName.TabIndex = 26;
            // 
            // lblDeptSaleId
            // 
            this.lblDeptSaleId.AutoSize = true;
            this.lblDeptSaleId.Location = new System.Drawing.Point(134, 17);
            this.lblDeptSaleId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeptSaleId.Name = "lblDeptSaleId";
            this.lblDeptSaleId.Size = new System.Drawing.Size(46, 13);
            this.lblDeptSaleId.TabIndex = 25;
            this.lblDeptSaleId.Text = "DEP. ID";
            // 
            // lblDeptSaleQtty
            // 
            this.lblDeptSaleQtty.AutoSize = true;
            this.lblDeptSaleQtty.Location = new System.Drawing.Point(118, 43);
            this.lblDeptSaleQtty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeptSaleQtty.Name = "lblDeptSaleQtty";
            this.lblDeptSaleQtty.Size = new System.Drawing.Size(65, 13);
            this.lblDeptSaleQtty.TabIndex = 34;
            this.lblDeptSaleQtty.Text = "QUANTITY:";
            // 
            // nmrDeptSaleId
            // 
            this.nmrDeptSaleId.Location = new System.Drawing.Point(185, 14);
            this.nmrDeptSaleId.Margin = new System.Windows.Forms.Padding(2);
            this.nmrDeptSaleId.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nmrDeptSaleId.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrDeptSaleId.Name = "nmrDeptSaleId";
            this.nmrDeptSaleId.Size = new System.Drawing.Size(62, 20);
            this.nmrDeptSaleId.TabIndex = 24;
            this.nmrDeptSaleId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrDeptSaleId.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nmrDeptSaleQtty
            // 
            this.nmrDeptSaleQtty.DecimalPlaces = 3;
            this.nmrDeptSaleQtty.Location = new System.Drawing.Point(185, 37);
            this.nmrDeptSaleQtty.Margin = new System.Windows.Forms.Padding(2);
            this.nmrDeptSaleQtty.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nmrDeptSaleQtty.Name = "nmrDeptSaleQtty";
            this.nmrDeptSaleQtty.Size = new System.Drawing.Size(62, 20);
            this.nmrDeptSaleQtty.TabIndex = 33;
            this.nmrDeptSaleQtty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrDeptSaleQtty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tbcPayment
            // 
            this.tbcPayment.Controls.Add(this.tbpPay1);
            this.tbcPayment.Controls.Add(this.tbpPayEFT);
            this.tbcPayment.Controls.Add(this.tbpVoidPay);
            this.tbcPayment.Controls.Add(this.tabRefund);
            this.tbcPayment.Controls.Add(this.tabPageBankList);
            this.tbcPayment.Controls.Add(this.tabPageEftSlipCopy);
            this.tbcPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcPayment.Location = new System.Drawing.Point(2, 277);
            this.tbcPayment.Margin = new System.Windows.Forms.Padding(2);
            this.tbcPayment.Name = "tbcPayment";
            this.tbcPayment.SelectedIndex = 0;
            this.tbcPayment.Size = new System.Drawing.Size(469, 111);
            this.tbcPayment.TabIndex = 27;
            // 
            // tbpPay1
            // 
            this.tbpPay1.Controls.Add(this.tableLayoutPanel6);
            this.tbpPay1.Controls.Add(this.lblFCurrValue);
            this.tbpPay1.Controls.Add(this.lblPayIndx);
            this.tbpPay1.Location = new System.Drawing.Point(4, 22);
            this.tbpPay1.Margin = new System.Windows.Forms.Padding(2);
            this.tbpPay1.Name = "tbpPay1";
            this.tbpPay1.Padding = new System.Windows.Forms.Padding(2);
            this.tbpPay1.Size = new System.Drawing.Size(461, 85);
            this.tbpPay1.TabIndex = 0;
            this.tbpPay1.Text = "CASH PAYMENTS";
            this.tbpPay1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.76423F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.23577F));
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnPayment, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(457, 81);
            this.tableLayoutPanel6.TabIndex = 21;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel9, 0, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(107, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(347, 75);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.lblPayAmount, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.nmrPaymentAmount, 1, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(341, 31);
            this.tableLayoutPanel8.TabIndex = 0;
            // 
            // lblPayAmount
            // 
            this.lblPayAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPayAmount.AutoSize = true;
            this.lblPayAmount.Location = new System.Drawing.Point(30, 9);
            this.lblPayAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPayAmount.Name = "lblPayAmount";
            this.lblPayAmount.Size = new System.Drawing.Size(109, 13);
            this.lblPayAmount.TabIndex = 8;
            this.lblPayAmount.Text = "PAYMENT AMOUNT";
            // 
            // nmrPaymentAmount
            // 
            this.nmrPaymentAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nmrPaymentAmount.DecimalPlaces = 2;
            this.nmrPaymentAmount.Location = new System.Drawing.Point(210, 5);
            this.nmrPaymentAmount.Margin = new System.Windows.Forms.Padding(2);
            this.nmrPaymentAmount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nmrPaymentAmount.Name = "nmrPaymentAmount";
            this.nmrPaymentAmount.Size = new System.Drawing.Size(90, 20);
            this.nmrPaymentAmount.TabIndex = 16;
            this.nmrPaymentAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrPaymentAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrPaymentAmount.ValueChanged += new System.EventHandler(this.nmrPaymentAmount_ValueChanged);
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 4;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.44575F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.82111F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.58944F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.85044F));
            this.tableLayoutPanel9.Controls.Add(this.lblPayType, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.cbxPaymentType, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.btnRefreshCredit, 3, 0);
            this.tableLayoutPanel9.Controls.Add(this.cbxSubPayments, 2, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 40);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(341, 32);
            this.tableLayoutPanel9.TabIndex = 1;
            // 
            // lblPayType
            // 
            this.lblPayType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPayType.AutoSize = true;
            this.lblPayType.Location = new System.Drawing.Point(3, 9);
            this.lblPayType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPayType.Name = "lblPayType";
            this.lblPayType.Size = new System.Drawing.Size(90, 13);
            this.lblPayType.TabIndex = 10;
            this.lblPayType.Text = "PAYMENT TYPE";
            // 
            // cbxPaymentType
            // 
            this.cbxPaymentType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxPaymentType.FormattingEnabled = true;
            this.cbxPaymentType.Location = new System.Drawing.Point(99, 5);
            this.cbxPaymentType.Margin = new System.Windows.Forms.Padding(2);
            this.cbxPaymentType.Name = "cbxPaymentType";
            this.cbxPaymentType.Size = new System.Drawing.Size(67, 21);
            this.cbxPaymentType.TabIndex = 9;
            this.cbxPaymentType.SelectedIndexChanged += new System.EventHandler(this.cbxPaymentType_SelectedIndexChanged);
            // 
            // btnRefreshCredit
            // 
            this.btnRefreshCredit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefreshCredit.Image = global::FP300Service.Properties.Resources.refresh;
            this.btnRefreshCredit.Location = new System.Drawing.Point(307, 2);
            this.btnRefreshCredit.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefreshCredit.Name = "btnRefreshCredit";
            this.btnRefreshCredit.Size = new System.Drawing.Size(30, 28);
            this.btnRefreshCredit.TabIndex = 19;
            this.btnRefreshCredit.UseVisualStyleBackColor = true;
            this.btnRefreshCredit.Visible = false;
            this.btnRefreshCredit.Click += new System.EventHandler(this.btnRefreshCredit_Click);
            // 
            // cbxSubPayments
            // 
            this.cbxSubPayments.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxSubPayments.FormattingEnabled = true;
            this.cbxSubPayments.Location = new System.Drawing.Point(170, 5);
            this.cbxSubPayments.Margin = new System.Windows.Forms.Padding(2);
            this.cbxSubPayments.Name = "cbxSubPayments";
            this.cbxSubPayments.Size = new System.Drawing.Size(131, 21);
            this.cbxSubPayments.TabIndex = 17;
            this.cbxSubPayments.SelectedIndexChanged += new System.EventHandler(this.cbxSubPayments_SelectedIndexChanged);
            // 
            // btnPayment
            // 
            this.btnPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPayment.Location = new System.Drawing.Point(2, 2);
            this.btnPayment.Margin = new System.Windows.Forms.Padding(2);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(100, 77);
            this.btnPayment.TabIndex = 6;
            this.btnPayment.Text = "PAYMENT";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
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
            // lblPayIndx
            // 
            this.lblPayIndx.AutoSize = true;
            this.lblPayIndx.Location = new System.Drawing.Point(291, 24);
            this.lblPayIndx.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPayIndx.Name = "lblPayIndx";
            this.lblPayIndx.Size = new System.Drawing.Size(0, 13);
            this.lblPayIndx.TabIndex = 18;
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
            this.tbpPayEFT.Size = new System.Drawing.Size(461, 85);
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
            // tbpVoidPay
            // 
            this.tbpVoidPay.Controls.Add(this.label5);
            this.tbpVoidPay.Controls.Add(this.checkBoxVoidEft);
            this.tbpVoidPay.Controls.Add(this.panelVoidEFT);
            this.tbpVoidPay.Controls.Add(this.btnVoidPayment);
            this.tbpVoidPay.Controls.Add(this.label2);
            this.tbpVoidPay.Controls.Add(this.nmrVoidPayIndex);
            this.tbpVoidPay.Location = new System.Drawing.Point(4, 22);
            this.tbpVoidPay.Margin = new System.Windows.Forms.Padding(2);
            this.tbpVoidPay.Name = "tbpVoidPay";
            this.tbpVoidPay.Padding = new System.Windows.Forms.Padding(2);
            this.tbpVoidPay.Size = new System.Drawing.Size(461, 85);
            this.tbpVoidPay.TabIndex = 2;
            this.tbpVoidPay.Text = "VOID PAYMENT";
            this.tbpVoidPay.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(180, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "VOID EFT";
            // 
            // checkBoxVoidEft
            // 
            this.checkBoxVoidEft.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxVoidEft.Location = new System.Drawing.Point(151, 8);
            this.checkBoxVoidEft.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxVoidEft.Name = "checkBoxVoidEft";
            this.checkBoxVoidEft.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxVoidEft.Size = new System.Drawing.Size(20, 17);
            this.checkBoxVoidEft.TabIndex = 30;
            this.checkBoxVoidEft.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxVoidEft.UseVisualStyleBackColor = true;
            this.checkBoxVoidEft.CheckedChanged += new System.EventHandler(this.checkBoxVoidEft_CheckedChanged);
            // 
            // panelVoidEFT
            // 
            this.panelVoidEFT.Controls.Add(this.txtStanNo);
            this.panelVoidEFT.Controls.Add(this.txtBatchNo);
            this.panelVoidEFT.Controls.Add(this.label4);
            this.panelVoidEFT.Controls.Add(this.label3);
            this.panelVoidEFT.Controls.Add(this.txtAcquierId);
            this.panelVoidEFT.Controls.Add(this.lblAcquierId);
            this.panelVoidEFT.Enabled = false;
            this.panelVoidEFT.Location = new System.Drawing.Point(274, 2);
            this.panelVoidEFT.Margin = new System.Windows.Forms.Padding(2);
            this.panelVoidEFT.Name = "panelVoidEFT";
            this.panelVoidEFT.Size = new System.Drawing.Size(182, 77);
            this.panelVoidEFT.TabIndex = 29;
            // 
            // txtStanNo
            // 
            this.txtStanNo.Location = new System.Drawing.Point(77, 47);
            this.txtStanNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtStanNo.MaxLength = 15;
            this.txtStanNo.Name = "txtStanNo";
            this.txtStanNo.Size = new System.Drawing.Size(90, 20);
            this.txtStanNo.TabIndex = 27;
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.Location = new System.Drawing.Point(77, 24);
            this.txtBatchNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtBatchNo.MaxLength = 15;
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.Size = new System.Drawing.Size(90, 20);
            this.txtBatchNo.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "STAN NO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "BATCH NO";
            // 
            // txtAcquierId
            // 
            this.txtAcquierId.Location = new System.Drawing.Point(77, 3);
            this.txtAcquierId.Margin = new System.Windows.Forms.Padding(2);
            this.txtAcquierId.MaxLength = 15;
            this.txtAcquierId.Name = "txtAcquierId";
            this.txtAcquierId.Size = new System.Drawing.Size(90, 20);
            this.txtAcquierId.TabIndex = 22;
            // 
            // lblAcquierId
            // 
            this.lblAcquierId.AutoSize = true;
            this.lblAcquierId.Location = new System.Drawing.Point(3, 6);
            this.lblAcquierId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAcquierId.Name = "lblAcquierId";
            this.lblAcquierId.Size = new System.Drawing.Size(69, 13);
            this.lblAcquierId.TabIndex = 23;
            this.lblAcquierId.Text = "ACQUIER ID";
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
            this.label2.Location = new System.Drawing.Point(118, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "PAYMENT INDEX:";
            // 
            // nmrVoidPayIndex
            // 
            this.nmrVoidPayIndex.Location = new System.Drawing.Point(220, 49);
            this.nmrVoidPayIndex.Margin = new System.Windows.Forms.Padding(2);
            this.nmrVoidPayIndex.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.nmrVoidPayIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrVoidPayIndex.Name = "nmrVoidPayIndex";
            this.nmrVoidPayIndex.Size = new System.Drawing.Size(40, 20);
            this.nmrVoidPayIndex.TabIndex = 24;
            this.nmrVoidPayIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrVoidPayIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tabRefund
            // 
            this.tabRefund.Controls.Add(this.txtAcquierIdRefund);
            this.tabRefund.Controls.Add(this.label6);
            this.tabRefund.Controls.Add(this.btnRefund);
            this.tabRefund.Location = new System.Drawing.Point(4, 22);
            this.tabRefund.Name = "tabRefund";
            this.tabRefund.Size = new System.Drawing.Size(461, 85);
            this.tabRefund.TabIndex = 3;
            this.tabRefund.Text = "EFT REFUND";
            this.tabRefund.UseVisualStyleBackColor = true;
            // 
            // txtAcquierIdRefund
            // 
            this.txtAcquierIdRefund.Location = new System.Drawing.Point(230, 30);
            this.txtAcquierIdRefund.Margin = new System.Windows.Forms.Padding(2);
            this.txtAcquierIdRefund.MaxLength = 15;
            this.txtAcquierIdRefund.Name = "txtAcquierIdRefund";
            this.txtAcquierIdRefund.Size = new System.Drawing.Size(90, 20);
            this.txtAcquierIdRefund.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(156, 33);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "ACQUIER ID";
            // 
            // btnRefund
            // 
            this.btnRefund.Location = new System.Drawing.Point(15, 19);
            this.btnRefund.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(110, 37);
            this.btnRefund.TabIndex = 3;
            this.btnRefund.Text = "REFUND";
            this.btnRefund.UseVisualStyleBackColor = true;
            this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);
            // 
            // tabPageBankList
            // 
            this.tabPageBankList.Controls.Add(this.btnBankList);
            this.tabPageBankList.Location = new System.Drawing.Point(4, 22);
            this.tabPageBankList.Name = "tabPageBankList";
            this.tabPageBankList.Size = new System.Drawing.Size(461, 85);
            this.tabPageBankList.TabIndex = 4;
            this.tabPageBankList.Text = "BANK LIST";
            this.tabPageBankList.UseVisualStyleBackColor = true;
            // 
            // btnBankList
            // 
            this.btnBankList.Location = new System.Drawing.Point(24, 18);
            this.btnBankList.Margin = new System.Windows.Forms.Padding(2);
            this.btnBankList.Name = "btnBankList";
            this.btnBankList.Size = new System.Drawing.Size(110, 37);
            this.btnBankList.TabIndex = 3;
            this.btnBankList.Text = "GET BANK LIST";
            this.btnBankList.UseVisualStyleBackColor = true;
            this.btnBankList.Click += new System.EventHandler(this.btnBankList_Click);
            // 
            // tabPageEftSlipCopy
            // 
            this.tabPageEftSlipCopy.Controls.Add(this.checkBoxSlpCpyZnoRcptNo);
            this.tabPageEftSlipCopy.Controls.Add(this.buttonGetEFTSlipCopy);
            this.tabPageEftSlipCopy.Controls.Add(this.textBoxSlpCpyRcptNo);
            this.tabPageEftSlipCopy.Controls.Add(this.textBoxSlpCpyZNo);
            this.tabPageEftSlipCopy.Controls.Add(this.labelSlpCpyRcptNo);
            this.tabPageEftSlipCopy.Controls.Add(this.labelSlpCpyZNo);
            this.tabPageEftSlipCopy.Controls.Add(this.textBoxSlpCpyStanNo);
            this.tabPageEftSlipCopy.Controls.Add(this.textBoxSlpCpyBatchNo);
            this.tabPageEftSlipCopy.Controls.Add(this.labelSlpCpyStanNo);
            this.tabPageEftSlipCopy.Controls.Add(this.labelSlpCpyBatchNo);
            this.tabPageEftSlipCopy.Controls.Add(this.textBoxSlpCpyAcquirId);
            this.tabPageEftSlipCopy.Controls.Add(this.label17);
            this.tabPageEftSlipCopy.Location = new System.Drawing.Point(4, 22);
            this.tabPageEftSlipCopy.Name = "tabPageEftSlipCopy";
            this.tabPageEftSlipCopy.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEftSlipCopy.Size = new System.Drawing.Size(461, 85);
            this.tabPageEftSlipCopy.TabIndex = 5;
            this.tabPageEftSlipCopy.Text = "EFT SLIPCOPY";
            this.tabPageEftSlipCopy.UseVisualStyleBackColor = true;
            // 
            // checkBoxSlpCpyZnoRcptNo
            // 
            this.checkBoxSlpCpyZnoRcptNo.AutoSize = true;
            this.checkBoxSlpCpyZnoRcptNo.Location = new System.Drawing.Point(288, 13);
            this.checkBoxSlpCpyZnoRcptNo.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxSlpCpyZnoRcptNo.Name = "checkBoxSlpCpyZnoRcptNo";
            this.checkBoxSlpCpyZnoRcptNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxSlpCpyZnoRcptNo.Size = new System.Drawing.Size(108, 17);
            this.checkBoxSlpCpyZnoRcptNo.TabIndex = 39;
            this.checkBoxSlpCpyZnoRcptNo.Text = "Z No-Fiş No ile Al";
            this.checkBoxSlpCpyZnoRcptNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxSlpCpyZnoRcptNo.UseVisualStyleBackColor = true;
            this.checkBoxSlpCpyZnoRcptNo.CheckStateChanged += new System.EventHandler(this.checkBoxSlpCpyZnoRcptNo_CheckStateChanged);
            // 
            // buttonGetEFTSlipCopy
            // 
            this.buttonGetEFTSlipCopy.Location = new System.Drawing.Point(5, 19);
            this.buttonGetEFTSlipCopy.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGetEFTSlipCopy.Name = "buttonGetEFTSlipCopy";
            this.buttonGetEFTSlipCopy.Size = new System.Drawing.Size(89, 48);
            this.buttonGetEFTSlipCopy.TabIndex = 38;
            this.buttonGetEFTSlipCopy.Text = "GET SLIPCOPY";
            this.buttonGetEFTSlipCopy.UseVisualStyleBackColor = true;
            this.buttonGetEFTSlipCopy.Click += new System.EventHandler(this.buttonGetEFTSlipCopy_Click);
            // 
            // textBoxSlpCpyRcptNo
            // 
            this.textBoxSlpCpyRcptNo.Location = new System.Drawing.Point(360, 54);
            this.textBoxSlpCpyRcptNo.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSlpCpyRcptNo.MaxLength = 15;
            this.textBoxSlpCpyRcptNo.Name = "textBoxSlpCpyRcptNo";
            this.textBoxSlpCpyRcptNo.Size = new System.Drawing.Size(90, 20);
            this.textBoxSlpCpyRcptNo.TabIndex = 37;
            // 
            // textBoxSlpCpyZNo
            // 
            this.textBoxSlpCpyZNo.Location = new System.Drawing.Point(360, 31);
            this.textBoxSlpCpyZNo.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSlpCpyZNo.MaxLength = 15;
            this.textBoxSlpCpyZNo.Name = "textBoxSlpCpyZNo";
            this.textBoxSlpCpyZNo.Size = new System.Drawing.Size(90, 20);
            this.textBoxSlpCpyZNo.TabIndex = 36;
            // 
            // labelSlpCpyRcptNo
            // 
            this.labelSlpCpyRcptNo.AutoSize = true;
            this.labelSlpCpyRcptNo.Location = new System.Drawing.Point(287, 57);
            this.labelSlpCpyRcptNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSlpCpyRcptNo.Name = "labelSlpCpyRcptNo";
            this.labelSlpCpyRcptNo.Size = new System.Drawing.Size(42, 13);
            this.labelSlpCpyRcptNo.TabIndex = 35;
            this.labelSlpCpyRcptNo.Text = "FİŞ NO";
            // 
            // labelSlpCpyZNo
            // 
            this.labelSlpCpyZNo.AutoSize = true;
            this.labelSlpCpyZNo.Location = new System.Drawing.Point(286, 37);
            this.labelSlpCpyZNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSlpCpyZNo.Name = "labelSlpCpyZNo";
            this.labelSlpCpyZNo.Size = new System.Drawing.Size(33, 13);
            this.labelSlpCpyZNo.TabIndex = 34;
            this.labelSlpCpyZNo.Text = "Z NO";
            // 
            // textBoxSlpCpyStanNo
            // 
            this.textBoxSlpCpyStanNo.Location = new System.Drawing.Point(175, 54);
            this.textBoxSlpCpyStanNo.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSlpCpyStanNo.MaxLength = 15;
            this.textBoxSlpCpyStanNo.Name = "textBoxSlpCpyStanNo";
            this.textBoxSlpCpyStanNo.Size = new System.Drawing.Size(90, 20);
            this.textBoxSlpCpyStanNo.TabIndex = 33;
            // 
            // textBoxSlpCpyBatchNo
            // 
            this.textBoxSlpCpyBatchNo.Location = new System.Drawing.Point(175, 31);
            this.textBoxSlpCpyBatchNo.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSlpCpyBatchNo.MaxLength = 15;
            this.textBoxSlpCpyBatchNo.Name = "textBoxSlpCpyBatchNo";
            this.textBoxSlpCpyBatchNo.Size = new System.Drawing.Size(90, 20);
            this.textBoxSlpCpyBatchNo.TabIndex = 32;
            // 
            // labelSlpCpyStanNo
            // 
            this.labelSlpCpyStanNo.AutoSize = true;
            this.labelSlpCpyStanNo.Location = new System.Drawing.Point(102, 57);
            this.labelSlpCpyStanNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSlpCpyStanNo.Name = "labelSlpCpyStanNo";
            this.labelSlpCpyStanNo.Size = new System.Drawing.Size(55, 13);
            this.labelSlpCpyStanNo.TabIndex = 31;
            this.labelSlpCpyStanNo.Text = "STAN NO";
            // 
            // labelSlpCpyBatchNo
            // 
            this.labelSlpCpyBatchNo.AutoSize = true;
            this.labelSlpCpyBatchNo.Location = new System.Drawing.Point(101, 37);
            this.labelSlpCpyBatchNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSlpCpyBatchNo.Name = "labelSlpCpyBatchNo";
            this.labelSlpCpyBatchNo.Size = new System.Drawing.Size(62, 13);
            this.labelSlpCpyBatchNo.TabIndex = 30;
            this.labelSlpCpyBatchNo.Text = "BATCH NO";
            // 
            // textBoxSlpCpyAcquirId
            // 
            this.textBoxSlpCpyAcquirId.Location = new System.Drawing.Point(175, 10);
            this.textBoxSlpCpyAcquirId.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSlpCpyAcquirId.MaxLength = 15;
            this.textBoxSlpCpyAcquirId.Name = "textBoxSlpCpyAcquirId";
            this.textBoxSlpCpyAcquirId.Size = new System.Drawing.Size(90, 20);
            this.textBoxSlpCpyAcquirId.TabIndex = 28;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(101, 13);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 13);
            this.label17.TabIndex = 29;
            this.label17.Text = "ACQUIER ID";
            // 
            // bntPrintJSONDoc
            // 
            this.bntPrintJSONDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bntPrintJSONDoc.Location = new System.Drawing.Point(2, 149);
            this.bntPrintJSONDoc.Margin = new System.Windows.Forms.Padding(2);
            this.bntPrintJSONDoc.Name = "bntPrintJSONDoc";
            this.bntPrintJSONDoc.Size = new System.Drawing.Size(116, 45);
            this.bntPrintJSONDoc.TabIndex = 26;
            this.bntPrintJSONDoc.Text = "PRINT JSON";
            this.bntPrintJSONDoc.UseVisualStyleBackColor = true;
            this.bntPrintJSONDoc.Click += new System.EventHandler(this.bntPrintJSONDoc_Click);
            // 
            // btnCorrect
            // 
            this.btnCorrect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCorrect.Location = new System.Drawing.Point(2, 296);
            this.btnCorrect.Margin = new System.Windows.Forms.Padding(2);
            this.btnCorrect.Name = "btnCorrect";
            this.btnCorrect.Size = new System.Drawing.Size(116, 45);
            this.btnCorrect.TabIndex = 19;
            this.btnCorrect.Text = "CORRECT";
            this.btnCorrect.UseVisualStyleBackColor = true;
            this.btnCorrect.Click += new System.EventHandler(this.btnCorrect_Click);
            // 
            // btnSubtotal
            // 
            this.btnSubtotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSubtotal.Location = new System.Drawing.Point(2, 247);
            this.btnSubtotal.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubtotal.Name = "btnSubtotal";
            this.btnSubtotal.Size = new System.Drawing.Size(116, 45);
            this.btnSubtotal.TabIndex = 5;
            this.btnSubtotal.Text = "SUBTOTAL";
            this.btnSubtotal.UseVisualStyleBackColor = true;
            this.btnSubtotal.Click += new System.EventHandler(this.btnSubtotal_Click);
            // 
            // btnVoidReceipt
            // 
            this.btnVoidReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVoidReceipt.Location = new System.Drawing.Point(2, 394);
            this.btnVoidReceipt.Margin = new System.Windows.Forms.Padding(2);
            this.btnVoidReceipt.Name = "btnVoidReceipt";
            this.btnVoidReceipt.Size = new System.Drawing.Size(116, 45);
            this.btnVoidReceipt.TabIndex = 4;
            this.btnVoidReceipt.Text = "VOID DOCUMENT";
            this.btnVoidReceipt.UseVisualStyleBackColor = true;
            this.btnVoidReceipt.Click += new System.EventHandler(this.btnVoidReceipt_Click);
            // 
            // btnCloseReceipt
            // 
            this.btnCloseReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCloseReceipt.Location = new System.Drawing.Point(2, 345);
            this.btnCloseReceipt.Margin = new System.Windows.Forms.Padding(2);
            this.btnCloseReceipt.Name = "btnCloseReceipt";
            this.btnCloseReceipt.Size = new System.Drawing.Size(116, 45);
            this.btnCloseReceipt.TabIndex = 3;
            this.btnCloseReceipt.Text = "CLOSE DOCUMENT";
            this.btnCloseReceipt.UseVisualStyleBackColor = true;
            this.btnCloseReceipt.Click += new System.EventHandler(this.btnCloseReceipt_Click);
            // 
            // btnRcptInfo
            // 
            this.btnRcptInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRcptInfo.Location = new System.Drawing.Point(2, 100);
            this.btnRcptInfo.Margin = new System.Windows.Forms.Padding(2);
            this.btnRcptInfo.Name = "btnRcptInfo";
            this.btnRcptInfo.Size = new System.Drawing.Size(116, 45);
            this.btnRcptInfo.TabIndex = 31;
            this.btnRcptInfo.Text = "RECEIPT INFO";
            this.btnRcptInfo.UseVisualStyleBackColor = true;
            this.btnRcptInfo.Click += new System.EventHandler(this.btnRcptInfo_Click);
            // 
            // buttonAutoPrintPLU
            // 
            this.buttonAutoPrintPLU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAutoPrintPLU.Location = new System.Drawing.Point(2, 51);
            this.buttonAutoPrintPLU.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAutoPrintPLU.Name = "buttonAutoPrintPLU";
            this.buttonAutoPrintPLU.Size = new System.Drawing.Size(116, 45);
            this.buttonAutoPrintPLU.TabIndex = 32;
            this.buttonAutoPrintPLU.Text = "AUTO PRINT    JSON PLU";
            this.buttonAutoPrintPLU.UseVisualStyleBackColor = true;
            this.buttonAutoPrintPLU.Click += new System.EventHandler(this.buttonAutoPrint_Click);
            // 
            // btnJsonOnlyDept
            // 
            this.btnJsonOnlyDept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJsonOnlyDept.Location = new System.Drawing.Point(2, 198);
            this.btnJsonOnlyDept.Margin = new System.Windows.Forms.Padding(2);
            this.btnJsonOnlyDept.Name = "btnJsonOnlyDept";
            this.btnJsonOnlyDept.Size = new System.Drawing.Size(116, 45);
            this.btnJsonOnlyDept.TabIndex = 33;
            this.btnJsonOnlyDept.Text = "PRINT JSON DEPT";
            this.btnJsonOnlyDept.UseVisualStyleBackColor = true;
            this.btnJsonOnlyDept.Click += new System.EventHandler(this.btnJsonOnlyDept_Click);
            // 
            // tableLayoutPanelSaleUc
            // 
            this.tableLayoutPanelSaleUc.ColumnCount = 2;
            this.tableLayoutPanelSaleUc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.33884F));
            this.tableLayoutPanelSaleUc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.66116F));
            this.tableLayoutPanelSaleUc.Controls.Add(this.tableLayoutPanelSaleUCLeft, 0, 0);
            this.tableLayoutPanelSaleUc.Controls.Add(this.tableLayoutPanelSaleUCRight, 1, 0);
            this.tableLayoutPanelSaleUc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSaleUc.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelSaleUc.Name = "tableLayoutPanelSaleUc";
            this.tableLayoutPanelSaleUc.RowCount = 1;
            this.tableLayoutPanelSaleUc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSaleUc.Size = new System.Drawing.Size(605, 498);
            this.tableLayoutPanelSaleUc.TabIndex = 34;
            // 
            // tableLayoutPanelSaleUCLeft
            // 
            this.tableLayoutPanelSaleUCLeft.ColumnCount = 1;
            this.tableLayoutPanelSaleUCLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSaleUCLeft.Controls.Add(this.tbcStartDoc, 0, 0);
            this.tableLayoutPanelSaleUCLeft.Controls.Add(this.tbcSale, 0, 1);
            this.tableLayoutPanelSaleUCLeft.Controls.Add(this.tbcPayment, 0, 2);
            this.tableLayoutPanelSaleUCLeft.Controls.Add(this.tbcFooter, 0, 3);
            this.tableLayoutPanelSaleUCLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSaleUCLeft.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelSaleUCLeft.Name = "tableLayoutPanelSaleUCLeft";
            this.tableLayoutPanelSaleUCLeft.RowCount = 4;
            this.tableLayoutPanelSaleUCLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.42276F));
            this.tableLayoutPanelSaleUCLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.47154F));
            this.tableLayoutPanelSaleUCLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.37398F));
            this.tableLayoutPanelSaleUCLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.3252F));
            this.tableLayoutPanelSaleUCLeft.Size = new System.Drawing.Size(473, 492);
            this.tableLayoutPanelSaleUCLeft.TabIndex = 0;
            // 
            // tableLayoutPanelSaleUCRight
            // 
            this.tableLayoutPanelSaleUCRight.ColumnCount = 1;
            this.tableLayoutPanelSaleUCRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSaleUCRight.Controls.Add(this.buttonPrintSalesDocument, 0, 9);
            this.tableLayoutPanelSaleUCRight.Controls.Add(this.buttonAutoPrintPLU, 0, 1);
            this.tableLayoutPanelSaleUCRight.Controls.Add(this.btnVoidReceipt, 0, 8);
            this.tableLayoutPanelSaleUCRight.Controls.Add(this.btnCorrect, 0, 6);
            this.tableLayoutPanelSaleUCRight.Controls.Add(this.btnCloseReceipt, 0, 7);
            this.tableLayoutPanelSaleUCRight.Controls.Add(this.btnJsonOnlyDept, 0, 4);
            this.tableLayoutPanelSaleUCRight.Controls.Add(this.btnSubtotal, 0, 5);
            this.tableLayoutPanelSaleUCRight.Controls.Add(this.btnRcptInfo, 0, 2);
            this.tableLayoutPanelSaleUCRight.Controls.Add(this.bntPrintJSONDoc, 0, 3);
            this.tableLayoutPanelSaleUCRight.Controls.Add(this.buttonAutoPrintDEPT, 0, 0);
            this.tableLayoutPanelSaleUCRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSaleUCRight.Location = new System.Drawing.Point(482, 3);
            this.tableLayoutPanelSaleUCRight.Name = "tableLayoutPanelSaleUCRight";
            this.tableLayoutPanelSaleUCRight.RowCount = 10;
            this.tableLayoutPanelSaleUCRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSaleUCRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSaleUCRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSaleUCRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSaleUCRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSaleUCRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSaleUCRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSaleUCRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSaleUCRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSaleUCRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSaleUCRight.Size = new System.Drawing.Size(120, 492);
            this.tableLayoutPanelSaleUCRight.TabIndex = 1;
            // 
            // buttonPrintSalesDocument
            // 
            this.buttonPrintSalesDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPrintSalesDocument.Location = new System.Drawing.Point(2, 443);
            this.buttonPrintSalesDocument.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPrintSalesDocument.Name = "buttonPrintSalesDocument";
            this.buttonPrintSalesDocument.Size = new System.Drawing.Size(116, 47);
            this.buttonPrintSalesDocument.TabIndex = 35;
            this.buttonPrintSalesDocument.Text = "PRINT SALE DOCUMENT";
            this.buttonPrintSalesDocument.UseVisualStyleBackColor = true;
            this.buttonPrintSalesDocument.Click += new System.EventHandler(this.buttonPrintSalesDocument_Click);
            // 
            // buttonAutoPrintDEPT
            // 
            this.buttonAutoPrintDEPT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAutoPrintDEPT.Location = new System.Drawing.Point(2, 2);
            this.buttonAutoPrintDEPT.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAutoPrintDEPT.Name = "buttonAutoPrintDEPT";
            this.buttonAutoPrintDEPT.Size = new System.Drawing.Size(116, 45);
            this.buttonAutoPrintDEPT.TabIndex = 34;
            this.buttonAutoPrintDEPT.Text = "AUTO PRINT    JSON DEPT";
            this.buttonAutoPrintDEPT.UseVisualStyleBackColor = true;
            this.buttonAutoPrintDEPT.Click += new System.EventHandler(this.buttonAutoPrintDEPT_Click);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // SaleUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelSaleUc);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SaleUC";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Size = new System.Drawing.Size(605, 498);
            this.tbcStartDoc.ResumeLayout(false);
            this.tbStrtRcpt.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tbStrtInvoice.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            this.tabAdvance.ResumeLayout(false);
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrAdvanceAmount)).EndInit();
            this.tbpStartParking.ResumeLayout(false);
            this.tbpStartParking.PerformLayout();
            this.tabPageFood.ResumeLayout(false);
            this.tabPageCollection.ResumeLayout(false);
            this.tabPageCollection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownComission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCllctnAmount)).EndInit();
            this.tbcFooter.ResumeLayout(false);
            this.tbpNotes.ResumeLayout(false);
            this.tbpNotes.PerformLayout();
            this.tbpExtra.ResumeLayout(false);
            this.tabPageBarcode.ResumeLayout(false);
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel17.ResumeLayout(false);
            this.tableLayoutPanel17.PerformLayout();
            this.tbcSale.ResumeLayout(false);
            this.tbpSale.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPlu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPrice)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.pnlExtraPlufields.ResumeLayout(false);
            this.pnlExtraPlufields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrDept)).EndInit();
            this.tbpVoidSale.ResumeLayout(false);
            this.tbpVoidSale.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrVoidQtty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrVoidPlu)).EndInit();
            this.tbpAdj.ResumeLayout(false);
            this.tbpAdj.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrAdjAmount)).EndInit();
            this.tpgSaleDept.ResumeLayout(false);
            this.tpgSaleDept.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrDeptSalePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrDeptSaleId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrDeptSaleQtty)).EndInit();
            this.tbcPayment.ResumeLayout(false);
            this.tbpPay1.ResumeLayout(false);
            this.tbpPay1.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPaymentAmount)).EndInit();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tbpPayEFT.ResumeLayout(false);
            this.tbpPayEFT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrEFTAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrInstallment)).EndInit();
            this.tbpVoidPay.ResumeLayout(false);
            this.tbpVoidPay.PerformLayout();
            this.panelVoidEFT.ResumeLayout(false);
            this.panelVoidEFT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrVoidPayIndex)).EndInit();
            this.tabRefund.ResumeLayout(false);
            this.tabRefund.PerformLayout();
            this.tabPageBankList.ResumeLayout(false);
            this.tabPageEftSlipCopy.ResumeLayout(false);
            this.tabPageEftSlipCopy.PerformLayout();
            this.tableLayoutPanelSaleUc.ResumeLayout(false);
            this.tableLayoutPanelSaleUCLeft.ResumeLayout(false);
            this.tableLayoutPanelSaleUCRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void btnStartReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                CPResponse response = new CPResponse(bridge.Printer.PrintDocumentHeader());
                if (response.ErrorCode == 0)
                {
                    bridge.Log(FormMessage.DOCUMENT_ID.PadRight(12, ' ') + ":" + response.GetNextParam());
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
                    response = new CPResponse(bridge.Printer.PrintItem(pluNo, quantity, price, FixTurkishUpperCase(txtName.Text), txtBarcode.Text, (int)nmrDept.Value, weighable));
                } 
                else
                {
                    response = new CPResponse(bridge.Printer.PrintItem(pluNo, quantity, price, null, null, -1, -1));
                }

                if (response.ErrorCode == 0)
                {
                    bridge.Log(String.Format(FormMessage.SUBTOTAL.PadRight(12, ' ') + ":{0}", response.GetNextParam()));
                }
            }
            catch
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private string FixTurkishUpperCase(string text)
        {
            // stack current culture
            System.Globalization.CultureInfo currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture;

            // Set Turkey culture
            System.Globalization.CultureInfo turkey = new System.Globalization.CultureInfo("tr-TR");
            System.Threading.Thread.CurrentThread.CurrentCulture = turkey;

            string cultured = text.ToUpper();

            // Pop old culture
            System.Threading.Thread.CurrentThread.CurrentCulture = currentCulture;

            return cultured;
        }

        private void btnCloseReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                CPResponse response = new CPResponse(bridge.Printer.CloseReceipt(chbSlipCopy.Checked));
                
                if (response.ErrorCode == 0)
                {
                    bridge.Log(FormMessage.DOCUMENT_ID.PadRight(12, ' ') + ":" + response.GetNextParam());
                }
            }
            catch
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void btnVoidReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                CPResponse response = new CPResponse(bridge.Printer.VoidReceipt());

                if (response.ErrorCode == 0)
                {
                    bridge.Log(FormMessage.VOIDED_DOC_ID.PadRight(12, ' ') + ":" + response.GetNextParam());
                }
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
        }

        private void btnSubtotal_Click(object sender, EventArgs e)
        {
            try
            {
                CPResponse response = new CPResponse(bridge.Printer.PrintSubtotal(false));

                if (response.ErrorCode == 0)
                {
                    bridge.Log(String.Format(FormMessage.SUBTOTAL.PadRight(12, ' ') + ":{0}", response.GetNextParam()));

                    bridge.Log(String.Format(FormMessage.PAID_TOTAL.PadRight(12, ' ') + ":{0}", response.GetNextParam()));
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
                    bridge.Log(String.Format(FormMessage.SUBTOTAL.PadRight(12, ' ') + ":{0}", response.GetNextParam()));

                    bridge.Log(String.Format(FormMessage.PAID_TOTAL.PadRight(12, ' ') + ":{0}", response.GetNextParam()));

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
                    bridge.Log(String.Format(FormMessage.SUBTOTAL.PadRight(12, ' ') + ":{0:#0.00}", response.GetNextParam()));
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
                    bridge.Log(String.Format("{1}:{0:#0.00}", response.GetNextParam(), FormMessage.SUBTOTAL.PadRight(12, ' ')));
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

                // SEND COMMAND
                CPResponse response = null;

                if (cbxVoidDept.Checked)
                {
                    if (String.IsNullOrEmpty(txtVoidDeptName.Text))
                    {
                        bridge.Log(FormMessage.FILL_DEPT_NAME);
                        return;
                    }
                    else
                        response = new CPResponse(bridge.Printer.VoidDepartment(pluNo, txtVoidDeptName.Text,quantity));
                } 
                else
                {
                    response = new CPResponse(bridge.Printer.Void(pluNo, quantity));
                }

                if (response.ErrorCode == 0)
                {
                    bridge.Log(String.Format("{1}:{0}", response.GetNextParam(), FormMessage.SUBTOTAL.PadRight(12, ' ')));
                }
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void btnRemark_Click(object sender, EventArgs e)
        {
            try
            {
                List<byte> bytes = new List<byte>();

                string[] remarkLines = txtRemarkLine.Lines;

                if (remarkLines.Length > 0)
                {
                    for (int i = 0; i < remarkLines.Length; i++)
                    {
                        remarkLines[i] = remarkLines[i].PadRight(ProgramConfig.LOGO_LINE_LENGTH - 3, ' ');
                    }

                    // SEND COMMAND
                    CPResponse response = new CPResponse(bridge.Printer.PrintRemarkLine(remarkLines));
                }
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
                cbxSubPayments.Items.Add(String.Format("{0}  {1}",MainForm.Currencies[i].Name , MainForm.Currencies[i].Rate));
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
                CPResponse response;

                //BARCODE
                string barcode = txtRcptBarcode.Text;

                if(comboBoxBarcodeTypes.SelectedIndex != 0)               
                    response = new CPResponse(bridge.Printer.PrintReceiptBarcode(comboBoxBarcodeTypes.SelectedIndex, barcode));
                else
                    response = new CPResponse(bridge.Printer.PrintReceiptBarcode(barcode));
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
            CPResponse response = null;
            try
            {
                if (checkBoxVoidEft.Checked)
                {
#if !CPP
                    response = new CPResponse(bridge.Printer.VoidEFTPayment(int.Parse(txtAcquierId.Text), int.Parse(txtBatchNo.Text), int.Parse(txtStanNo.Text)));
#endif
                }
                else
                {
                    // SEND COMMAND
                    response = new CPResponse(bridge.Printer.VoidPayment((int)nmrVoidPayIndex.Value - 1));
                }
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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

                CPResponse response = new CPResponse(bridge.Printer.PrintJSONDocument(jsonStr));
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
                    bridge.Log(String.Format(FormMessage.CC_ID.PadRight(12, ' ') + ":{0}", response.GetNextParam()));
                    bridge.Log(String.Format(FormMessage.CC_NAME.PadRight(12, ' ') + ":{0}", response.GetNextParam()));
                    bridge.Log(String.Format(FormMessage.DISCOUNT_ACTIVE.PadRight(12, ' ') + ":{0}", response.GetNextParam()));

                    string cardNum = response.GetNextParam();
                    bridge.Log(String.Format(FormMessage.CARD_NUMBER.PadRight(12, ' ') + ":{0}", cardNum));
                    bridge.Log(String.Format("Holder Name".PadRight(12, ' ') + ":{0}", response.GetNextParam()));

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
                    string totalAmount      = response.GetNextParam();
                    string provisionCode    = response.GetNextParam();
                    string paidAmount       = response.GetNextParam();
                    string installmentCount = response.GetNextParam();
                    string acquirerId       = response.GetNextParam();
                    string bin              = response.GetNextParam();
                    string issuerId         = response.GetNextParam();

                    bridge.Log(String.Format("İşlem Tutarı   :{0}", nmrEFTAmount.Value.ToString()));
                    bridge.Log(String.Format("Ödeme Toplamı  :{0}", paidAmount)); 
                    bridge.Log(String.Format("Belge Tutarı   :{0}", totalAmount));
                    bridge.Log(String.Format("Taksit sayısı  :{0}", installmentCount)); 
                    bridge.Log(String.Format("Provizyon kodu :{0}", provisionCode));                                                                                       
                    bridge.Log(String.Format("ACQUIRER ID    :{0}", acquirerId));
                    bridge.Log(String.Format("BIN            :{0}", bin));
                    bridge.Log(String.Format("ISSUERER ID    :{0}", issuerId));
                    
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
                // tckn vkn 
                string tckn_vkn = txtTCKN_VKN.Text;

                // serial
                string docSerial = txtboxInvoiceSerialNo.Text;

                // issue date
                DateTime issueDate = dateTimePickerInvoiceIssueDate.Value;


                CPResponse response = new CPResponse(bridge.Printer.PrintDocumentHeader(cbxInvTypes.SelectedIndex+1, tckn_vkn, docSerial, issueDate));
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
                // tckn 
                string tckn = txtboxAdvanceTCKN.Text;
                // name
                string name = txtboxAdvanceName.Text;
                // Amount
                decimal amount = nmrAdvanceAmount.Value;

                CPResponse response = new CPResponse(bridge.Printer.PrintAdvanceDocumentHeader(tckn, name, amount));
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
            DateTime entranceDT = new DateTime(dtParkDate.Value.Year,
                                                dtParkDate.Value.Month,
                                                dtParkDate.Value.Day,
                                                dtParkTime.Value.Hour,
                                                dtParkTime.Value.Minute,
                                                dtParkTime.Value.Second);
            try
            {
                CPResponse response = new CPResponse(bridge.Printer.PrintParkDocument(txtPlate.Text, entranceDT));
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

        private void checkBoxVoidEft_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxVoidEft.Checked)
                panelVoidEFT.Enabled = true;
            else
                panelVoidEFT.Enabled = false;
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            try
            {
#if !CPP
                CPResponse response = new CPResponse(bridge.Printer.RefundEFTPayment(int.Parse(txtAcquierIdRefund.Text)));
#endif
            }
            catch(Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void btnBankList_Click(object sender, EventArgs e)
        {
            CPResponse response = null;
            try
            {
#if !CPP
                response = new CPResponse(bridge.Printer.GetBankListOnEFT());
#endif

                if (response.ErrorCode == 0)
                {
                    int counter = 1;
                    bridge.Log(String.Format("** BANK INFO LIST **"));
                    while (response.CurrentParamIndex < response.ParamList.Count)
                    {
                        String bankInfo = response.GetNextParam();
                        string acquirID = bankInfo.Substring(0, 4);
                        string bankName = bankInfo.Substring(4);

                        bridge.Log(String.Format("BANK {0}", counter++));
                        bridge.Log(String.Format("ACQUIER ID : {0}", acquirID));
                        bridge.Log(String.Format("BANK NAME  : {0}", bankName));
                        bridge.Log(String.Format(""));
                    }
                }
            }
            catch (Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }


        }

        private void btnRcptInfo_Click(object sender, EventArgs e)
        {
            CPResponse response = null;
            try
            {
#if !CPP
                response = new CPResponse(bridge.Printer.GetSalesInfo());
#endif

                if (response.ErrorCode == 0)
                {
                    bridge.Log(String.Format("DOC NO    : {0}", response.GetNextParam()));
                    bridge.Log(String.Format("Z NO      : {0}", response.GetNextParam()));
                    bridge.Log(String.Format("DOC TYPE  : {0}", response.GetNextParam()));
                    bridge.Log(String.Format("DATE      : {0}", response.GetNextParam()));
                    bridge.Log(String.Format("TIME      : {0}", response.GetNextParam()));
                    bridge.Log(String.Format("SUB TOTAL : {0}", response.GetNextParam()));

                    try
                    {
                        int payCount = Convert.ToInt32(response.GetNextParam());
                        bridge.Log(String.Format("PAYMENT COUNT : {0}", payCount));
                        for (int i = 0; i < payCount; i++)
                        {
                            bridge.Log(String.Format("PAY TYPE   : {0}", response.GetNextParam()));
                            bridge.Log(String.Format("PAY INDEX  : {0}", response.GetNextParam()));
                            bridge.Log(String.Format("PAY AMOUNT : {0}", response.GetNextParam()));
                            bridge.Log(String.Format("PAY DETAIL : {0}", response.GetNextParam()));
                        }
                    }
                    catch
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }


        }

        private void btnSaleDept_Click(object sender, EventArgs e)
        {
            int weighable = cbxDeptSaleWeighable.Checked ? 1 : 0;
            

            try
            {
                CPResponse response = new CPResponse(bridge.Printer.PrintDepartment((int)nmrDeptSaleId.Value, 
                                                                                    nmrDeptSaleQtty.Value,
                                                                                    nmrDeptSalePrice.Value,
                                                                                    txtDeptSaleName.Text,
                                                                                    weighable));

                if (response.ErrorCode == 0)
                {
                    bridge.Log(String.Format(FormMessage.SUBTOTAL.PadRight(12, ' ') + ":{0}", response.GetNextParam()));
                }
            }
            catch
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }

        private void btnJsonOnlyDept_Click(object sender, EventArgs e)
        {
            string jsonFileName = System.Configuration.ConfigurationManager.AppSettings["JSONDocName"];
            string jsonStr = "";
            if (!File.Exists(jsonFileName))
            {
                bridge.Log(FormMessage.JSON_FILE_NOT_EXISTS);
                return;
            }

            try
            {
                jsonStr = File.ReadAllText(jsonFileName);

                CPResponse response = new CPResponse(bridge.Printer.PrintJSONDocumentDeptOnly(jsonStr));
            }
            catch (Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + " : " + ex.Message);
            }
        }

        private void cbxVoidDept_CheckedChanged(object sender, EventArgs e)
        {
            lblVoidDeptName.Visible = cbxVoidDept.Checked;
            txtVoidDeptName.Visible = cbxVoidDept.Checked;

            if (cbxVoidDept.Checked)
            {
                nmrVoidPlu.Maximum = 8;
                lblVoidPlu.Text = FormMessage.DEPT_ID;
            } 
            else
            {
                nmrVoidPlu.Maximum = 200000;
                lblVoidPlu.Text = FormMessage.PLU;
            }
        }

        private void buttonStartFoodDoc_Click(object sender, EventArgs e)
        {
            try
            {

                CPResponse response = new CPResponse(bridge.Printer.PrintFoodDocumentHeader());
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

        private void buttonStartCllctnDoc_Click(object sender, EventArgs e)
        {
            try
            {
                //invoice no
                string invoiceNo = textBoxCllctnSerial.Text;

                // amount
                decimal amount = numericUpDownCllctnAmount.Value;

                // subscriber no
                string subscriberNo = textBoxSubscriberNo.Text;

                // inst name
                string instutionName = textBoxInstutionName.Text;

                decimal comission = 0.0m;
                if (checkBoxComission.Checked)
                {
                    // comission amount
                    comission = numericUpDownComission.Value;
                }

                // Invoice Date
                DateTime invDate = dateTimePickerCllctionInvDate.Value;


                CPResponse response = new CPResponse(bridge.Printer.PrintCollectionDocumentHeader(invoiceNo, invDate, amount, subscriberNo, instutionName, comission));
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

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxComission.Checked)
            {
                numericUpDownComission.Enabled = true;
            }
            else
            {
                numericUpDownComission.Enabled = false;
            }
        }

        private void checkBoxSlpCpyZnoRcptNo_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxSlpCpyZnoRcptNo.Checked)
            {
                labelSlpCpyZNo.Enabled = true;
                labelSlpCpyRcptNo.Enabled = true;
                textBoxSlpCpyZNo.Enabled = true;
                textBoxSlpCpyRcptNo.Enabled = true;

                labelSlpCpyBatchNo.Enabled = false;
                labelSlpCpyStanNo.Enabled = false;
                textBoxSlpCpyBatchNo.Enabled = false;
                textBoxSlpCpyStanNo.Enabled = false;
            }
            else
            {
                labelSlpCpyZNo.Enabled = false;
                labelSlpCpyRcptNo.Enabled = false;
                textBoxSlpCpyZNo.Enabled = false;
                textBoxSlpCpyRcptNo.Enabled = false;

                labelSlpCpyBatchNo.Enabled = true;
                labelSlpCpyStanNo.Enabled = true;
                textBoxSlpCpyBatchNo.Enabled = true;
                textBoxSlpCpyStanNo.Enabled = true;
            }
        }

        private void buttonGetEFTSlipCopy_Click(object sender, EventArgs e)
        {
            int acquierId = 0;
            int zNo = 0;
            int rNo = 0;
            int bNo = 0;
            int sNo = 0;

            CPResponse response = null;
            try
            {
                acquierId = int.Parse(textBoxSlpCpyAcquirId.Text);

                if (checkBoxSlpCpyZnoRcptNo.Checked)
                {
                    zNo = int.Parse(textBoxSlpCpyZNo.Text);
                    rNo = int.Parse(textBoxSlpCpyRcptNo.Text);
                }
                else
                {
                    bNo = int.Parse(textBoxSlpCpyBatchNo.Text);
                    sNo = int.Parse(textBoxSlpCpyStanNo.Text);
                }

                response = new CPResponse(bridge.Printer.GetEFTSlipCopy(acquierId, bNo, sNo, zNo, rNo));

            }
            catch (Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + " : " + ex.Message);
            }
        }

        private delegate void buttonAutoPrintPLUDelegate(object sender, EventArgs e);
        private void buttonAutoPrint_Click(object sender, EventArgs e)
        {
            if (buttonAutoPrintPLU.InvokeRequired)
            {
                buttonAutoPrintPLU.Invoke(new buttonAutoPrintPLUDelegate(buttonAutoPrint_Click), sender, e);
            }
            else
            {
                try
                {
                    if (buttonAutoPrintPLU.Text == "AUTO PRINT    JSON PLU")
                    {
                        buttonAutoPrintPLU.Text = "STOP PRINT";
                        GetZRepAt = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["GetZReportAt"]);
                        docCounter = 1;

                        timer1.Tick += (object s, EventArgs a) => timer_Tick(s, a, false);
                        timer1.Interval = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["AutoPrintTimerInterval"]); // must be dividable by 1000
                        timer1.Start();


                        timer2.Interval = 1000;
                        wTime = timer1.Interval - timer2.Interval;
                        timer2.Start();
                    }
                    else
                    {
                        buttonAutoPrintPLU.Text = "AUTO PRINT    JSON PLU";
                        timer1.Tick -= (object s, EventArgs a) => timer_Tick(s, a, true);
                        timer1.Stop();
                        timer2.Stop();
                    }

                }
                catch (Exception ex)
                {
                    bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
                }
            }
        }

        static int wTime  = 0;
        private delegate void buttonAutoPrintDEPTClickDelegate(object sender, EventArgs e);
        private void buttonAutoPrintDEPT_Click(object sender, EventArgs e)
        {
            if (buttonAutoPrintDEPT.InvokeRequired)
            {
                buttonAutoPrintDEPT.Invoke(new buttonAutoPrintDEPTClickDelegate(buttonAutoPrintDEPT_Click), sender, e);
            }
            else
            {
                try
                {
                    if (buttonAutoPrintDEPT.Text == "AUTO PRINT    JSON DEPT")
                    {
                        buttonAutoPrintDEPT.Text = "STOP PRINT";
                        GetZRepAt = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["GetZReportAt"]);
                        docCounter = 1;

                        timer1.Tick += (object s, EventArgs a) => timer_Tick(s,a, true);
                        timer1.Interval = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["AutoPrintTimerInterval"]); // must be dividable by 1000 
                        timer1.Start();


                        timer2.Interval = 1000;
                        wTime = timer1.Interval - timer2.Interval;
                        timer2.Start();
                    }
                    else
                    {
                        buttonAutoPrintDEPT.Text = "AUTO PRINT    JSON DEPT";
                        timer1.Tick -= (object s, EventArgs a) => timer_Tick(s, a, true);
                        timer1.Stop();
                        timer2.Stop();
                    }

                }
                catch (Exception ex)
                {
                    bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
                }
            }
        }

        private void buttonPrintSalesDocument_Click(object sender, EventArgs e)
        {
            string jsonFileName = System.Configuration.ConfigurationManager.AppSettings["JSONDocName"];
            string jsonStr = "";
            if (!File.Exists(jsonFileName))
            {
                bridge.Log(FormMessage.JSON_FILE_NOT_EXISTS);
                return;
            }

            try
            {
                jsonStr = File.ReadAllText(jsonFileName);

                CPResponse response = new CPResponse(bridge.Printer.PrintSalesDocument(jsonStr));
            }
            catch (Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + " : " + ex.Message);
            }
        }

        static int GetZRepAt = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["GetZReportAt"]);
        static string jsonStr = String.Empty;
        static int docCounter = 1;
        private void timer_Tick(object sender, EventArgs e, bool isDeptSale)
        {
            if (String.IsNullOrEmpty(jsonStr))
            {
                string jsonFileName = System.Configuration.ConfigurationManager.AppSettings["JSONDocName"];
                if (!File.Exists(jsonFileName))
                {
                    bridge.Log(FormMessage.JSON_FILE_NOT_EXISTS);
                    return;
                }

                jsonStr = File.ReadAllText(jsonFileName);
            }

            try
            {
                bridge.Log(String.Format("AUTO PRINT DOC COUNTER: {0}", docCounter));
                CPResponse response = new CPResponse(bridge.Printer.PrintDocumentHeader());
                if (response.ErrorCode == 0)
                    if (isDeptSale)
                        response = new CPResponse(bridge.Printer.PrintJSONDocumentDeptOnly(jsonStr));
                    else
                        response = new CPResponse(bridge.Printer.PrintJSONDocument(jsonStr));
                else
                {
                    if (isDeptSale)
                        buttonAutoPrintDEPT.Text = "AUTO PRINT    JSON DEPT";
                    else
                        buttonAutoPrintPLU.Text = "AUTO PRINT    JSON PLU";
                }
                System.Threading.Thread.Sleep(500);

                if (docCounter % GetZRepAt == 0)
                {
                    bridge.Log(String.Format("AUTO PRINT: Z PRINTING... AT {0}", docCounter));
                    response = new CPResponse(bridge.Printer.PrintZReport());
                }

                docCounter++;
            }
            catch (Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
                if (isDeptSale)
                    buttonAutoPrintDEPT.Text = "AUTO PRINT    JSON DEPT";
                else
                    buttonAutoPrintPLU.Text = "AUTO PRINT    JSON PLU";
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            bridge.Log("Auto Print will start in " + wTime / 1000);
            wTime -= timer2.Interval;

            if (wTime <= 0)
                timer2.Enabled = false;
        }
    }
}
