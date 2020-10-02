using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;


namespace FP300Service.UserControls
{
    public enum AdjustmentType : sbyte
    {
        Fee,
        PercentFee,
        Discount,
        PercentDiscount
    }

    public enum SubOperationType
    {
        SATIS = 1,
        YBELGE = 10,
        TAKSITLI_SATIS = 04,
        VADE_FARKLI_SATIS = 03,
        PUANLI_SATIS = 16,
        E_IADE = 20,
        KISMI_IADE = 22,
        KONTOR_SATIS = 13,
        PUAN_SORGU = 14,
        KK_BORC_ODEME = 05,
        PREPAID_NAKIT_YUKLEME = 29,
        PREPAID_KARTLI_YUKLEME = 30,
        CASHBACK = 12
    }
    
    public enum InfoReceiptPaymentType
    {
        CASH = 1,
        CREDIT,
        CHECK,
        EFT_POS,
        FOREIGN_CURRENCY,
        FOODCARD
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
        private TabPage tabPageCrrAccountCollctn;
        private TableLayoutPanel tableLayoutPanel18;
        private Button btnPrintCurrAccHeader;
        private TableLayoutPanel tableLayoutPanel19;
        private NumericUpDown numericUpDownCrrAccAmount;
        private TextBox textBoxCrrAccDocSerial;
        private TextBox textBoxCrrAccCustName;
        private TextBox textBoxCrrAccTcknVkn;
        private Label labelCrrAccTcknVkn;
        private Label labelCrrAccCustName;
        private Label labelCrrAccSerial;
        private Label labelCrrAccAmount;
        private Label labelCrrAccDate;
        private DateTimePicker dateTimePickerCrrAccDate;
        private NumericUpDown numericUpDownRefundAmount;
        private Label labelRefundAmount;
        private TabPage tabPageEDocument;
        private Label labelEDocumentDocType;
        private ComboBox comboBoxEDocumentDocTypes;
        private Button buttonPrintEDocumentSample;
        private TabPage tabPageDataTest;
        private Button buttonSendTestData;
        private Button buttonLoadInvoiceFile;
        private Label labelInvoiceLinePath;
        private TabPage tabPageStoppage;
        private TableLayoutPanel tableLayoutPanel25;
        private Button buttonStoppage;
        private TableLayoutPanel tableLayoutPanel26;
        private Label labelStoppageAmount;
        private NumericUpDown numericUpDownStoppageAmount;
        private TabPage tabPageReturnDoc;
        private TableLayoutPanel tableLayoutPanel27;
        private Button buttonStartReturnDoc;
        private TableLayoutPanel tableLayoutPanel28;
        private TableLayoutPanel tableLayoutPanel29;
        private DateTimePicker dateTimePickerRetDoc;
        private Label labelRetDocDT;
        private TableLayoutPanel tableLayoutPanel30;
        private TextBox textBoxRetDocSerial;
        private Label labelRetDocSerial;
        private TableLayoutPanel tableLayoutPanel31;
        private TextBox textBoxRetDocORderNo;
        private Label labelRetDocOrderNo;
        private Button buttonAddCustomerRetDoc;
        private TabPage tabSlipExternal;
        private GroupBox gbxSlipContent;
        private GroupBox gbxSlipType;
        private RadioButton rbtnSlipTypeError;
        private RadioButton rbtnSlipTypeMerchant;
        private RadioButton rbtnSlipTypeCustomer;
        private Button btnSendSlip;
        private TextBox txtSlipLines;
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

            comboBoxEDocumentDocTypes.Items.AddRange(Common.EDocumentTypes);
            comboBoxEDocumentDocTypes.SelectedIndex = 0;

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
            this.btnPrintCurrAccHeader.Text = FormMessage.START_DOCUMENT;
            this.labelCrrAccAmount.Text = FormMessage.AMOUNT;
            this.labelCrrAccCustName.Text = FormMessage.CUSTOMER_NAME;
            this.labelCrrAccSerial.Text = FormMessage.DOCUMENT_SERIAL;
            this.tabPageCrrAccountCollctn.Text = FormMessage.CURRENT_ACCOUNT_COLLECTION_DOC;
            this.labelCrrAccDate.Text = FormMessage.DATE;
            this.buttonPrintEDocumentSample.Text = FormMessage.PRINT_EDOCUMENT_SAMPLE;
            this.labelEDocumentDocType.Text = FormMessage.DOCUMENT_TYPE;
            this.tabPageStoppage.Text = FormMessage.STOPPAGE;
            this.labelStoppageAmount.Text = FormMessage.AMOUNT;
            this.buttonStoppage.Text = FormMessage.SEND_STOPPAGE;
            this.tabPageReturnDoc.Text = FormMessage.RETURN_DOCUMENT;
            this.buttonStartReturnDoc.Text = FormMessage.START_DOCUMENT;
            this.labelRetDocSerial.Text = FormMessage.DOCUMENT_SERIAL;
            this.labelRetDocOrderNo.Text = FormMessage.DOCUMENT_ORDER_NO;
            this.labelRetDocDT.Text = FormMessage.DATE;
            this.buttonAddCustomerRetDoc.Text = FormMessage.ADD_CUSTOMER;
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
            catch { }

            base.OnParentChanged(e);
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaleUC));
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
            this.tabPageCrrAccountCollctn = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPrintCurrAccHeader = new System.Windows.Forms.Button();
            this.tableLayoutPanel19 = new System.Windows.Forms.TableLayoutPanel();
            this.labelCrrAccDate = new System.Windows.Forms.Label();
            this.numericUpDownCrrAccAmount = new System.Windows.Forms.NumericUpDown();
            this.textBoxCrrAccDocSerial = new System.Windows.Forms.TextBox();
            this.textBoxCrrAccCustName = new System.Windows.Forms.TextBox();
            this.textBoxCrrAccTcknVkn = new System.Windows.Forms.TextBox();
            this.labelCrrAccTcknVkn = new System.Windows.Forms.Label();
            this.labelCrrAccCustName = new System.Windows.Forms.Label();
            this.labelCrrAccSerial = new System.Windows.Forms.Label();
            this.labelCrrAccAmount = new System.Windows.Forms.Label();
            this.dateTimePickerCrrAccDate = new System.Windows.Forms.DateTimePicker();
            this.tabPageEDocument = new System.Windows.Forms.TabPage();
            this.buttonLoadInvoiceFile = new System.Windows.Forms.Button();
            this.labelInvoiceLinePath = new System.Windows.Forms.Label();
            this.labelEDocumentDocType = new System.Windows.Forms.Label();
            this.comboBoxEDocumentDocTypes = new System.Windows.Forms.ComboBox();
            this.buttonPrintEDocumentSample = new System.Windows.Forms.Button();
            this.tabPageDataTest = new System.Windows.Forms.TabPage();
            this.buttonSendTestData = new System.Windows.Forms.Button();
            this.tabPageReturnDoc = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel27 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonStartReturnDoc = new System.Windows.Forms.Button();
            this.tableLayoutPanel28 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel29 = new System.Windows.Forms.TableLayoutPanel();
            this.dateTimePickerRetDoc = new System.Windows.Forms.DateTimePicker();
            this.labelRetDocDT = new System.Windows.Forms.Label();
            this.tableLayoutPanel30 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxRetDocSerial = new System.Windows.Forms.TextBox();
            this.labelRetDocSerial = new System.Windows.Forms.Label();
            this.tableLayoutPanel31 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxRetDocORderNo = new System.Windows.Forms.TextBox();
            this.labelRetDocOrderNo = new System.Windows.Forms.Label();
            this.buttonAddCustomerRetDoc = new System.Windows.Forms.Button();
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
            this.tabPageStoppage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel25 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonStoppage = new System.Windows.Forms.Button();
            this.tableLayoutPanel26 = new System.Windows.Forms.TableLayoutPanel();
            this.labelStoppageAmount = new System.Windows.Forms.Label();
            this.numericUpDownStoppageAmount = new System.Windows.Forms.NumericUpDown();
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
            this.numericUpDownRefundAmount = new System.Windows.Forms.NumericUpDown();
            this.labelRefundAmount = new System.Windows.Forms.Label();
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
            this.tabSlipExternal = new System.Windows.Forms.TabPage();
            this.gbxSlipContent = new System.Windows.Forms.GroupBox();
            this.txtSlipLines = new System.Windows.Forms.TextBox();
            this.gbxSlipType = new System.Windows.Forms.GroupBox();
            this.rbtnSlipTypeError = new System.Windows.Forms.RadioButton();
            this.rbtnSlipTypeMerchant = new System.Windows.Forms.RadioButton();
            this.rbtnSlipTypeCustomer = new System.Windows.Forms.RadioButton();
            this.btnSendSlip = new System.Windows.Forms.Button();
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
            this.tabPageCrrAccountCollctn.SuspendLayout();
            this.tableLayoutPanel18.SuspendLayout();
            this.tableLayoutPanel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCrrAccAmount)).BeginInit();
            this.tabPageEDocument.SuspendLayout();
            this.tabPageDataTest.SuspendLayout();
            this.tabPageReturnDoc.SuspendLayout();
            this.tableLayoutPanel27.SuspendLayout();
            this.tableLayoutPanel28.SuspendLayout();
            this.tableLayoutPanel29.SuspendLayout();
            this.tableLayoutPanel30.SuspendLayout();
            this.tableLayoutPanel31.SuspendLayout();
            this.tbcFooter.SuspendLayout();
            this.tbpNotes.SuspendLayout();
            this.tbpExtra.SuspendLayout();
            this.tabPageBarcode.SuspendLayout();
            this.tableLayoutPanel16.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            this.tabPageStoppage.SuspendLayout();
            this.tableLayoutPanel25.SuspendLayout();
            this.tableLayoutPanel26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStoppageAmount)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefundAmount)).BeginInit();
            this.tabPageBankList.SuspendLayout();
            this.tabPageEftSlipCopy.SuspendLayout();
            this.tabSlipExternal.SuspendLayout();
            this.gbxSlipContent.SuspendLayout();
            this.gbxSlipType.SuspendLayout();
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
            this.tbcStartDoc.Controls.Add(this.tabPageCrrAccountCollctn);
            this.tbcStartDoc.Controls.Add(this.tabPageEDocument);
            this.tbcStartDoc.Controls.Add(this.tabPageDataTest);
            this.tbcStartDoc.Controls.Add(this.tabPageReturnDoc);
            this.tbcStartDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcStartDoc.Location = new System.Drawing.Point(2, 1);
            this.tbcStartDoc.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbcStartDoc.Name = "tbcStartDoc";
            this.tbcStartDoc.SelectedIndex = 0;
            this.tbcStartDoc.Size = new System.Drawing.Size(469, 128);
            this.tbcStartDoc.TabIndex = 30;
            // 
            // tbStrtRcpt
            // 
            this.tbStrtRcpt.Controls.Add(this.tableLayoutPanel5);
            this.tbStrtRcpt.Location = new System.Drawing.Point(4, 22);
            this.tbStrtRcpt.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbStrtRcpt.Name = "tbStrtRcpt";
            this.tbStrtRcpt.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbStrtRcpt.Size = new System.Drawing.Size(461, 102);
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
            this.tableLayoutPanel5.Location = new System.Drawing.Point(2, 1);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(457, 100);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // btnStartReceipt
            // 
            this.btnStartReceipt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStartReceipt.Location = new System.Drawing.Point(173, 31);
            this.btnStartReceipt.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnStartReceipt.Name = "btnStartReceipt";
            this.btnStartReceipt.Size = new System.Drawing.Size(110, 38);
            this.btnStartReceipt.TabIndex = 1;
            this.btnStartReceipt.Text = "START DOCUMENT";
            this.btnStartReceipt.UseVisualStyleBackColor = true;
            this.btnStartReceipt.Click += new System.EventHandler(this.btnStartReceipt_Click);
            // 
            // tbStrtInvoice
            // 
            this.tbStrtInvoice.Controls.Add(this.tableLayoutPanel10);
            this.tbStrtInvoice.Location = new System.Drawing.Point(4, 22);
            this.tbStrtInvoice.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbStrtInvoice.Name = "tbStrtInvoice";
            this.tbStrtInvoice.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbStrtInvoice.Size = new System.Drawing.Size(461, 102);
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
            this.tableLayoutPanel10.Location = new System.Drawing.Point(2, 1);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(457, 100);
            this.tableLayoutPanel10.TabIndex = 33;
            // 
            // btnStartInvoice
            // 
            this.btnStartInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartInvoice.Location = new System.Drawing.Point(2, 1);
            this.btnStartInvoice.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnStartInvoice.Name = "btnStartInvoice";
            this.btnStartInvoice.Size = new System.Drawing.Size(91, 98);
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
            this.tableLayoutPanel11.Size = new System.Drawing.Size(356, 94);
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
            this.tableLayoutPanel12.Size = new System.Drawing.Size(350, 41);
            this.tableLayoutPanel12.TabIndex = 0;
            // 
            // lblDocTypeInv
            // 
            this.lblDocTypeInv.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDocTypeInv.AutoSize = true;
            this.lblDocTypeInv.Location = new System.Drawing.Point(12, 7);
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
            this.cbxInvTypes.Location = new System.Drawing.Point(85, 10);
            this.cbxInvTypes.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cbxInvTypes.Name = "cbxInvTypes";
            this.cbxInvTypes.Size = new System.Drawing.Size(87, 21);
            this.cbxInvTypes.TabIndex = 27;
            // 
            // lblInvSerial
            // 
            this.lblInvSerial.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInvSerial.AutoSize = true;
            this.lblInvSerial.Location = new System.Drawing.Point(183, 14);
            this.lblInvSerial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInvSerial.Name = "lblInvSerial";
            this.lblInvSerial.Size = new System.Drawing.Size(69, 13);
            this.lblInvSerial.TabIndex = 25;
            this.lblInvSerial.Text = "TCKN / VKN";
            // 
            // txtTCKN_VKN
            // 
            this.txtTCKN_VKN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTCKN_VKN.Location = new System.Drawing.Point(263, 10);
            this.txtTCKN_VKN.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.tableLayoutPanel13.Location = new System.Drawing.Point(3, 50);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 1;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(350, 41);
            this.tableLayoutPanel13.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 14);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Issue Date:";
            // 
            // dateTimePickerInvoiceIssueDate
            // 
            this.dateTimePickerInvoiceIssueDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePickerInvoiceIssueDate.Location = new System.Drawing.Point(85, 10);
            this.dateTimePickerInvoiceIssueDate.Name = "dateTimePickerInvoiceIssueDate";
            this.dateTimePickerInvoiceIssueDate.Size = new System.Drawing.Size(86, 20);
            this.dateTimePickerInvoiceIssueDate.TabIndex = 32;
            // 
            // txtboxInvoiceSerialNo
            // 
            this.txtboxInvoiceSerialNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtboxInvoiceSerialNo.Location = new System.Drawing.Point(263, 10);
            this.txtboxInvoiceSerialNo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.label7.Location = new System.Drawing.Point(180, 14);
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
            this.tabAdvance.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tabAdvance.Name = "tabAdvance";
            this.tabAdvance.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tabAdvance.Size = new System.Drawing.Size(461, 102);
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
            this.tableLayoutPanel14.Location = new System.Drawing.Point(2, 1);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 1;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(457, 100);
            this.tableLayoutPanel14.TabIndex = 25;
            // 
            // btnPaidDoc
            // 
            this.btnPaidDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPaidDoc.Location = new System.Drawing.Point(2, 1);
            this.btnPaidDoc.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnPaidDoc.Name = "btnPaidDoc";
            this.btnPaidDoc.Size = new System.Drawing.Size(99, 98);
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
            this.tableLayoutPanel15.Size = new System.Drawing.Size(348, 94);
            this.tableLayoutPanel15.TabIndex = 4;
            // 
            // labelAdvanceTCKN
            // 
            this.labelAdvanceTCKN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAdvanceTCKN.AutoSize = true;
            this.labelAdvanceTCKN.Location = new System.Drawing.Point(44, 9);
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
            this.nmrAdvanceAmount.Location = new System.Drawing.Point(164, 68);
            this.nmrAdvanceAmount.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.txtboxAdvanceName.Location = new System.Drawing.Point(164, 36);
            this.txtboxAdvanceName.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtboxAdvanceName.MaxLength = 15;
            this.txtboxAdvanceName.Name = "txtboxAdvanceName";
            this.txtboxAdvanceName.Size = new System.Drawing.Size(146, 20);
            this.txtboxAdvanceName.TabIndex = 23;
            // 
            // txtboxAdvanceTCKN
            // 
            this.txtboxAdvanceTCKN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtboxAdvanceTCKN.Location = new System.Drawing.Point(165, 5);
            this.txtboxAdvanceTCKN.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtboxAdvanceTCKN.MaxLength = 11;
            this.txtboxAdvanceTCKN.Name = "txtboxAdvanceTCKN";
            this.txtboxAdvanceTCKN.Size = new System.Drawing.Size(144, 20);
            this.txtboxAdvanceTCKN.TabIndex = 24;
            // 
            // labelAdvanceName
            // 
            this.labelAdvanceName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAdvanceName.AutoSize = true;
            this.labelAdvanceName.Location = new System.Drawing.Point(43, 40);
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
            this.lblNFTotal.Location = new System.Drawing.Point(35, 71);
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
            this.tbpStartParking.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbpStartParking.Name = "tbpStartParking";
            this.tbpStartParking.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbpStartParking.Size = new System.Drawing.Size(461, 102);
            this.tbpStartParking.TabIndex = 3;
            this.tbpStartParking.Text = "OTOPARK";
            this.tbpStartParking.UseVisualStyleBackColor = true;
            // 
            // dtParkTime
            // 
            this.dtParkTime.CustomFormat = "HH:mm";
            this.dtParkTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtParkTime.Location = new System.Drawing.Point(341, 44);
            this.dtParkTime.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dtParkTime.Name = "dtParkTime";
            this.dtParkTime.ShowUpDown = true;
            this.dtParkTime.Size = new System.Drawing.Size(56, 20);
            this.dtParkTime.TabIndex = 37;
            // 
            // btnStartParkDoc
            // 
            this.btnStartParkDoc.Location = new System.Drawing.Point(2, 4);
            this.btnStartParkDoc.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnStartParkDoc.Name = "btnStartParkDoc";
            this.btnStartParkDoc.Size = new System.Drawing.Size(110, 38);
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
            this.dtParkDate.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.txtPlate.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.tabPageFood.Size = new System.Drawing.Size(461, 102);
            this.tabPageFood.TabIndex = 4;
            this.tabPageFood.Text = "FOOD";
            this.tabPageFood.UseVisualStyleBackColor = true;
            // 
            // buttonStartFoodDoc
            // 
            this.buttonStartFoodDoc.Location = new System.Drawing.Point(28, 20);
            this.buttonStartFoodDoc.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonStartFoodDoc.Name = "buttonStartFoodDoc";
            this.buttonStartFoodDoc.Size = new System.Drawing.Size(110, 38);
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
            this.tabPageCollection.Size = new System.Drawing.Size(461, 102);
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
            this.dateTimePickerCllctionInvDate.Location = new System.Drawing.Point(254, 76);
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
            this.numericUpDownComission.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.textBoxInstutionName.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.textBoxSubscriberNo.Location = new System.Drawing.Point(143, 77);
            this.textBoxSubscriberNo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.numericUpDownCllctnAmount.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.textBoxCllctnSerial.Location = new System.Drawing.Point(20, 77);
            this.textBoxCllctnSerial.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.buttonStartCllctnDoc.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonStartCllctnDoc.Name = "buttonStartCllctnDoc";
            this.buttonStartCllctnDoc.Size = new System.Drawing.Size(110, 38);
            this.buttonStartCllctnDoc.TabIndex = 5;
            this.buttonStartCllctnDoc.Text = "START DOCUMENT";
            this.buttonStartCllctnDoc.UseVisualStyleBackColor = true;
            this.buttonStartCllctnDoc.Click += new System.EventHandler(this.buttonStartCllctnDoc_Click);
            // 
            // tabPageCrrAccountCollctn
            // 
            this.tabPageCrrAccountCollctn.Controls.Add(this.tableLayoutPanel18);
            this.tabPageCrrAccountCollctn.Location = new System.Drawing.Point(4, 22);
            this.tabPageCrrAccountCollctn.Name = "tabPageCrrAccountCollctn";
            this.tabPageCrrAccountCollctn.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCrrAccountCollctn.Size = new System.Drawing.Size(461, 102);
            this.tabPageCrrAccountCollctn.TabIndex = 6;
            this.tabPageCrrAccountCollctn.Text = "CUURENT ACCOUNT COLLECTION DOC";
            this.tabPageCrrAccountCollctn.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel18
            // 
            this.tableLayoutPanel18.ColumnCount = 2;
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 353F));
            this.tableLayoutPanel18.Controls.Add(this.btnPrintCurrAccHeader, 0, 0);
            this.tableLayoutPanel18.Controls.Add(this.tableLayoutPanel19, 1, 0);
            this.tableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel18.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            this.tableLayoutPanel18.RowCount = 1;
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel18.Size = new System.Drawing.Size(455, 96);
            this.tableLayoutPanel18.TabIndex = 0;
            // 
            // btnPrintCurrAccHeader
            // 
            this.btnPrintCurrAccHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrintCurrAccHeader.Location = new System.Drawing.Point(3, 3);
            this.btnPrintCurrAccHeader.Name = "btnPrintCurrAccHeader";
            this.btnPrintCurrAccHeader.Size = new System.Drawing.Size(96, 90);
            this.btnPrintCurrAccHeader.TabIndex = 0;
            this.btnPrintCurrAccHeader.Text = "START DOCUMENT";
            this.btnPrintCurrAccHeader.UseVisualStyleBackColor = true;
            this.btnPrintCurrAccHeader.Click += new System.EventHandler(this.btnPrintCurrAccHeader_Click);
            // 
            // tableLayoutPanel19
            // 
            this.tableLayoutPanel19.ColumnCount = 2;
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel19.Controls.Add(this.labelCrrAccDate, 0, 4);
            this.tableLayoutPanel19.Controls.Add(this.numericUpDownCrrAccAmount, 1, 3);
            this.tableLayoutPanel19.Controls.Add(this.textBoxCrrAccDocSerial, 1, 2);
            this.tableLayoutPanel19.Controls.Add(this.textBoxCrrAccCustName, 1, 1);
            this.tableLayoutPanel19.Controls.Add(this.textBoxCrrAccTcknVkn, 1, 0);
            this.tableLayoutPanel19.Controls.Add(this.labelCrrAccTcknVkn, 0, 0);
            this.tableLayoutPanel19.Controls.Add(this.labelCrrAccCustName, 0, 1);
            this.tableLayoutPanel19.Controls.Add(this.labelCrrAccSerial, 0, 2);
            this.tableLayoutPanel19.Controls.Add(this.labelCrrAccAmount, 0, 3);
            this.tableLayoutPanel19.Controls.Add(this.dateTimePickerCrrAccDate, 1, 4);
            this.tableLayoutPanel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel19.Location = new System.Drawing.Point(105, 3);
            this.tableLayoutPanel19.Name = "tableLayoutPanel19";
            this.tableLayoutPanel19.RowCount = 5;
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel19.Size = new System.Drawing.Size(347, 90);
            this.tableLayoutPanel19.TabIndex = 1;
            // 
            // labelCrrAccDate
            // 
            this.labelCrrAccDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCrrAccDate.AutoSize = true;
            this.labelCrrAccDate.Location = new System.Drawing.Point(68, 74);
            this.labelCrrAccDate.Name = "labelCrrAccDate";
            this.labelCrrAccDate.Size = new System.Drawing.Size(36, 13);
            this.labelCrrAccDate.TabIndex = 29;
            this.labelCrrAccDate.Text = "DATE";
            // 
            // numericUpDownCrrAccAmount
            // 
            this.numericUpDownCrrAccAmount.DecimalPlaces = 2;
            this.numericUpDownCrrAccAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownCrrAccAmount.Location = new System.Drawing.Point(175, 55);
            this.numericUpDownCrrAccAmount.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.numericUpDownCrrAccAmount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownCrrAccAmount.Name = "numericUpDownCrrAccAmount";
            this.numericUpDownCrrAccAmount.Size = new System.Drawing.Size(170, 20);
            this.numericUpDownCrrAccAmount.TabIndex = 28;
            this.numericUpDownCrrAccAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownCrrAccAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // textBoxCrrAccDocSerial
            // 
            this.textBoxCrrAccDocSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCrrAccDocSerial.Location = new System.Drawing.Point(175, 37);
            this.textBoxCrrAccDocSerial.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBoxCrrAccDocSerial.MaxLength = 48;
            this.textBoxCrrAccDocSerial.Name = "textBoxCrrAccDocSerial";
            this.textBoxCrrAccDocSerial.Size = new System.Drawing.Size(170, 20);
            this.textBoxCrrAccDocSerial.TabIndex = 27;
            // 
            // textBoxCrrAccCustName
            // 
            this.textBoxCrrAccCustName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCrrAccCustName.Location = new System.Drawing.Point(175, 19);
            this.textBoxCrrAccCustName.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBoxCrrAccCustName.MaxLength = 48;
            this.textBoxCrrAccCustName.Name = "textBoxCrrAccCustName";
            this.textBoxCrrAccCustName.Size = new System.Drawing.Size(170, 20);
            this.textBoxCrrAccCustName.TabIndex = 26;
            // 
            // textBoxCrrAccTcknVkn
            // 
            this.textBoxCrrAccTcknVkn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCrrAccTcknVkn.Location = new System.Drawing.Point(175, 1);
            this.textBoxCrrAccTcknVkn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBoxCrrAccTcknVkn.MaxLength = 11;
            this.textBoxCrrAccTcknVkn.Name = "textBoxCrrAccTcknVkn";
            this.textBoxCrrAccTcknVkn.Size = new System.Drawing.Size(170, 20);
            this.textBoxCrrAccTcknVkn.TabIndex = 25;
            // 
            // labelCrrAccTcknVkn
            // 
            this.labelCrrAccTcknVkn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCrrAccTcknVkn.AutoSize = true;
            this.labelCrrAccTcknVkn.Location = new System.Drawing.Point(55, 2);
            this.labelCrrAccTcknVkn.Name = "labelCrrAccTcknVkn";
            this.labelCrrAccTcknVkn.Size = new System.Drawing.Size(63, 13);
            this.labelCrrAccTcknVkn.TabIndex = 0;
            this.labelCrrAccTcknVkn.Text = "TCKN/VKN";
            // 
            // labelCrrAccCustName
            // 
            this.labelCrrAccCustName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCrrAccCustName.AutoSize = true;
            this.labelCrrAccCustName.Location = new System.Drawing.Point(35, 20);
            this.labelCrrAccCustName.Name = "labelCrrAccCustName";
            this.labelCrrAccCustName.Size = new System.Drawing.Size(102, 13);
            this.labelCrrAccCustName.TabIndex = 1;
            this.labelCrrAccCustName.Text = "CUSTOMER NAME";
            // 
            // labelCrrAccSerial
            // 
            this.labelCrrAccSerial.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCrrAccSerial.AutoSize = true;
            this.labelCrrAccSerial.Location = new System.Drawing.Point(64, 38);
            this.labelCrrAccSerial.Name = "labelCrrAccSerial";
            this.labelCrrAccSerial.Size = new System.Drawing.Size(45, 13);
            this.labelCrrAccSerial.TabIndex = 2;
            this.labelCrrAccSerial.Text = "SERIAL";
            // 
            // labelCrrAccAmount
            // 
            this.labelCrrAccAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCrrAccAmount.AutoSize = true;
            this.labelCrrAccAmount.Location = new System.Drawing.Point(59, 56);
            this.labelCrrAccAmount.Name = "labelCrrAccAmount";
            this.labelCrrAccAmount.Size = new System.Drawing.Size(54, 13);
            this.labelCrrAccAmount.TabIndex = 3;
            this.labelCrrAccAmount.Text = "AMOUNT";
            // 
            // dateTimePickerCrrAccDate
            // 
            this.dateTimePickerCrrAccDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePickerCrrAccDate.Location = new System.Drawing.Point(176, 75);
            this.dateTimePickerCrrAccDate.Name = "dateTimePickerCrrAccDate";
            this.dateTimePickerCrrAccDate.Size = new System.Drawing.Size(168, 20);
            this.dateTimePickerCrrAccDate.TabIndex = 43;
            // 
            // tabPageEDocument
            // 
            this.tabPageEDocument.Controls.Add(this.buttonLoadInvoiceFile);
            this.tabPageEDocument.Controls.Add(this.labelInvoiceLinePath);
            this.tabPageEDocument.Controls.Add(this.labelEDocumentDocType);
            this.tabPageEDocument.Controls.Add(this.comboBoxEDocumentDocTypes);
            this.tabPageEDocument.Controls.Add(this.buttonPrintEDocumentSample);
            this.tabPageEDocument.Location = new System.Drawing.Point(4, 22);
            this.tabPageEDocument.Name = "tabPageEDocument";
            this.tabPageEDocument.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEDocument.Size = new System.Drawing.Size(461, 102);
            this.tabPageEDocument.TabIndex = 7;
            this.tabPageEDocument.Text = "E-BELGE";
            this.tabPageEDocument.UseVisualStyleBackColor = true;
            // 
            // buttonLoadInvoiceFile
            // 
            this.buttonLoadInvoiceFile.Location = new System.Drawing.Point(191, 49);
            this.buttonLoadInvoiceFile.Name = "buttonLoadInvoiceFile";
            this.buttonLoadInvoiceFile.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadInvoiceFile.TabIndex = 13;
            this.buttonLoadInvoiceFile.Text = "LOAD FILE";
            this.buttonLoadInvoiceFile.UseVisualStyleBackColor = true;
            this.buttonLoadInvoiceFile.Click += new System.EventHandler(this.buttonLoadInvoiceFile_Click);
            // 
            // labelInvoiceLinePath
            // 
            this.labelInvoiceLinePath.AutoSize = true;
            this.labelInvoiceLinePath.Location = new System.Drawing.Point(188, 77);
            this.labelInvoiceLinePath.Name = "labelInvoiceLinePath";
            this.labelInvoiceLinePath.Size = new System.Drawing.Size(0, 13);
            this.labelInvoiceLinePath.TabIndex = 12;
            // 
            // labelEDocumentDocType
            // 
            this.labelEDocumentDocType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEDocumentDocType.AutoSize = true;
            this.labelEDocumentDocType.Location = new System.Drawing.Point(187, 27);
            this.labelEDocumentDocType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEDocumentDocType.Name = "labelEDocumentDocType";
            this.labelEDocumentDocType.Size = new System.Drawing.Size(68, 13);
            this.labelEDocumentDocType.TabIndex = 11;
            this.labelEDocumentDocType.Text = "BELGE TİPİ:";
            // 
            // comboBoxEDocumentDocTypes
            // 
            this.comboBoxEDocumentDocTypes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxEDocumentDocTypes.FormattingEnabled = true;
            this.comboBoxEDocumentDocTypes.Location = new System.Drawing.Point(281, 24);
            this.comboBoxEDocumentDocTypes.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.comboBoxEDocumentDocTypes.Name = "comboBoxEDocumentDocTypes";
            this.comboBoxEDocumentDocTypes.Size = new System.Drawing.Size(99, 21);
            this.comboBoxEDocumentDocTypes.TabIndex = 10;
            // 
            // buttonPrintEDocumentSample
            // 
            this.buttonPrintEDocumentSample.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPrintEDocumentSample.Location = new System.Drawing.Point(51, 24);
            this.buttonPrintEDocumentSample.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonPrintEDocumentSample.Name = "buttonPrintEDocumentSample";
            this.buttonPrintEDocumentSample.Size = new System.Drawing.Size(110, 52);
            this.buttonPrintEDocumentSample.TabIndex = 2;
            this.buttonPrintEDocumentSample.Text = "PRINT E-DOCUMENT SAMPLE";
            this.buttonPrintEDocumentSample.UseVisualStyleBackColor = true;
            this.buttonPrintEDocumentSample.Click += new System.EventHandler(this.buttonPrintEDocumentSample_Click);
            // 
            // tabPageDataTest
            // 
            this.tabPageDataTest.Controls.Add(this.buttonSendTestData);
            this.tabPageDataTest.Location = new System.Drawing.Point(4, 22);
            this.tabPageDataTest.Name = "tabPageDataTest";
            this.tabPageDataTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDataTest.Size = new System.Drawing.Size(461, 102);
            this.tabPageDataTest.TabIndex = 8;
            this.tabPageDataTest.Text = "DATA TEST";
            this.tabPageDataTest.UseVisualStyleBackColor = true;
            // 
            // buttonSendTestData
            // 
            this.buttonSendTestData.Location = new System.Drawing.Point(37, 32);
            this.buttonSendTestData.Name = "buttonSendTestData";
            this.buttonSendTestData.Size = new System.Drawing.Size(113, 40);
            this.buttonSendTestData.TabIndex = 0;
            this.buttonSendTestData.Text = "SEND TEST DATA";
            this.buttonSendTestData.UseVisualStyleBackColor = true;
            this.buttonSendTestData.Click += new System.EventHandler(this.buttonSendTestData_Click);
            // 
            // tabPageReturnDoc
            // 
            this.tabPageReturnDoc.Controls.Add(this.tableLayoutPanel27);
            this.tabPageReturnDoc.Location = new System.Drawing.Point(4, 22);
            this.tabPageReturnDoc.Name = "tabPageReturnDoc";
            this.tabPageReturnDoc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReturnDoc.Size = new System.Drawing.Size(461, 102);
            this.tabPageReturnDoc.TabIndex = 10;
            this.tabPageReturnDoc.Text = "RETURN DOC";
            this.tabPageReturnDoc.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel27
            // 
            this.tableLayoutPanel27.ColumnCount = 2;
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel27.Controls.Add(this.buttonStartReturnDoc, 0, 0);
            this.tableLayoutPanel27.Controls.Add(this.tableLayoutPanel28, 1, 0);
            this.tableLayoutPanel27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel27.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel27.Name = "tableLayoutPanel27";
            this.tableLayoutPanel27.RowCount = 1;
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel27.Size = new System.Drawing.Size(455, 96);
            this.tableLayoutPanel27.TabIndex = 1;
            // 
            // buttonStartReturnDoc
            // 
            this.buttonStartReturnDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonStartReturnDoc.Location = new System.Drawing.Point(3, 3);
            this.buttonStartReturnDoc.Name = "buttonStartReturnDoc";
            this.buttonStartReturnDoc.Size = new System.Drawing.Size(85, 90);
            this.buttonStartReturnDoc.TabIndex = 0;
            this.buttonStartReturnDoc.Text = "START DOCUMENT";
            this.buttonStartReturnDoc.UseVisualStyleBackColor = true;
            this.buttonStartReturnDoc.Click += new System.EventHandler(this.buttonStartReturnDoc_Click);
            // 
            // tableLayoutPanel28
            // 
            this.tableLayoutPanel28.ColumnCount = 2;
            this.tableLayoutPanel28.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel28.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel28.Controls.Add(this.tableLayoutPanel29, 0, 1);
            this.tableLayoutPanel28.Controls.Add(this.tableLayoutPanel30, 0, 0);
            this.tableLayoutPanel28.Controls.Add(this.tableLayoutPanel31, 1, 0);
            this.tableLayoutPanel28.Controls.Add(this.buttonAddCustomerRetDoc, 1, 1);
            this.tableLayoutPanel28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel28.Location = new System.Drawing.Point(94, 3);
            this.tableLayoutPanel28.Name = "tableLayoutPanel28";
            this.tableLayoutPanel28.RowCount = 2;
            this.tableLayoutPanel28.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel28.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel28.Size = new System.Drawing.Size(358, 90);
            this.tableLayoutPanel28.TabIndex = 1;
            // 
            // tableLayoutPanel29
            // 
            this.tableLayoutPanel29.ColumnCount = 1;
            this.tableLayoutPanel29.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel29.Controls.Add(this.dateTimePickerRetDoc, 0, 1);
            this.tableLayoutPanel29.Controls.Add(this.labelRetDocDT, 0, 0);
            this.tableLayoutPanel29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel29.Location = new System.Drawing.Point(3, 48);
            this.tableLayoutPanel29.Name = "tableLayoutPanel29";
            this.tableLayoutPanel29.RowCount = 2;
            this.tableLayoutPanel29.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel29.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel29.Size = new System.Drawing.Size(173, 39);
            this.tableLayoutPanel29.TabIndex = 0;
            // 
            // dateTimePickerRetDoc
            // 
            this.dateTimePickerRetDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePickerRetDoc.Location = new System.Drawing.Point(3, 22);
            this.dateTimePickerRetDoc.Name = "dateTimePickerRetDoc";
            this.dateTimePickerRetDoc.Size = new System.Drawing.Size(167, 20);
            this.dateTimePickerRetDoc.TabIndex = 44;
            // 
            // labelRetDocDT
            // 
            this.labelRetDocDT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRetDocDT.AutoSize = true;
            this.labelRetDocDT.Location = new System.Drawing.Point(68, 3);
            this.labelRetDocDT.Name = "labelRetDocDT";
            this.labelRetDocDT.Size = new System.Drawing.Size(36, 13);
            this.labelRetDocDT.TabIndex = 30;
            this.labelRetDocDT.Text = "DATE";
            // 
            // tableLayoutPanel30
            // 
            this.tableLayoutPanel30.ColumnCount = 1;
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel30.Controls.Add(this.textBoxRetDocSerial, 0, 1);
            this.tableLayoutPanel30.Controls.Add(this.labelRetDocSerial, 0, 0);
            this.tableLayoutPanel30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel30.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel30.Name = "tableLayoutPanel30";
            this.tableLayoutPanel30.RowCount = 2;
            this.tableLayoutPanel30.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel30.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel30.Size = new System.Drawing.Size(173, 39);
            this.tableLayoutPanel30.TabIndex = 1;
            // 
            // textBoxRetDocSerial
            // 
            this.textBoxRetDocSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxRetDocSerial.Location = new System.Drawing.Point(2, 20);
            this.textBoxRetDocSerial.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBoxRetDocSerial.MaxLength = 48;
            this.textBoxRetDocSerial.Name = "textBoxRetDocSerial";
            this.textBoxRetDocSerial.Size = new System.Drawing.Size(169, 20);
            this.textBoxRetDocSerial.TabIndex = 32;
            // 
            // labelRetDocSerial
            // 
            this.labelRetDocSerial.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRetDocSerial.AutoSize = true;
            this.labelRetDocSerial.Location = new System.Drawing.Point(64, 3);
            this.labelRetDocSerial.Name = "labelRetDocSerial";
            this.labelRetDocSerial.Size = new System.Drawing.Size(45, 13);
            this.labelRetDocSerial.TabIndex = 31;
            this.labelRetDocSerial.Text = "SERIAL";
            // 
            // tableLayoutPanel31
            // 
            this.tableLayoutPanel31.ColumnCount = 1;
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel31.Controls.Add(this.textBoxRetDocORderNo, 0, 1);
            this.tableLayoutPanel31.Controls.Add(this.labelRetDocOrderNo, 0, 0);
            this.tableLayoutPanel31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel31.Location = new System.Drawing.Point(182, 3);
            this.tableLayoutPanel31.Name = "tableLayoutPanel31";
            this.tableLayoutPanel31.RowCount = 2;
            this.tableLayoutPanel31.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel31.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel31.Size = new System.Drawing.Size(173, 39);
            this.tableLayoutPanel31.TabIndex = 0;
            // 
            // textBoxRetDocORderNo
            // 
            this.textBoxRetDocORderNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxRetDocORderNo.Location = new System.Drawing.Point(2, 20);
            this.textBoxRetDocORderNo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBoxRetDocORderNo.MaxLength = 48;
            this.textBoxRetDocORderNo.Name = "textBoxRetDocORderNo";
            this.textBoxRetDocORderNo.Size = new System.Drawing.Size(169, 20);
            this.textBoxRetDocORderNo.TabIndex = 33;
            // 
            // labelRetDocOrderNo
            // 
            this.labelRetDocOrderNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRetDocOrderNo.AutoSize = true;
            this.labelRetDocOrderNo.Location = new System.Drawing.Point(54, 3);
            this.labelRetDocOrderNo.Name = "labelRetDocOrderNo";
            this.labelRetDocOrderNo.Size = new System.Drawing.Size(65, 13);
            this.labelRetDocOrderNo.TabIndex = 32;
            this.labelRetDocOrderNo.Text = "ORDER NO";
            // 
            // buttonAddCustomerRetDoc
            // 
            this.buttonAddCustomerRetDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddCustomerRetDoc.Location = new System.Drawing.Point(182, 48);
            this.buttonAddCustomerRetDoc.Name = "buttonAddCustomerRetDoc";
            this.buttonAddCustomerRetDoc.Size = new System.Drawing.Size(173, 39);
            this.buttonAddCustomerRetDoc.TabIndex = 2;
            this.buttonAddCustomerRetDoc.Text = "ADD CUSTOMER";
            this.buttonAddCustomerRetDoc.UseVisualStyleBackColor = true;
            this.buttonAddCustomerRetDoc.Click += new System.EventHandler(this.buttonAddCustomerRetDoc_Click);
            // 
            // tbcFooter
            // 
            this.tbcFooter.Controls.Add(this.tbpNotes);
            this.tbcFooter.Controls.Add(this.tbpExtra);
            this.tbcFooter.Controls.Add(this.tabPageBarcode);
            this.tbcFooter.Controls.Add(this.tabPageStoppage);
            this.tbcFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcFooter.Location = new System.Drawing.Point(2, 391);
            this.tbcFooter.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbcFooter.Name = "tbcFooter";
            this.tbcFooter.SelectedIndex = 0;
            this.tbcFooter.Size = new System.Drawing.Size(469, 100);
            this.tbcFooter.TabIndex = 29;
            // 
            // tbpNotes
            // 
            this.tbpNotes.Controls.Add(this.btnRemark);
            this.tbpNotes.Controls.Add(this.txtRemarkLine);
            this.tbpNotes.Location = new System.Drawing.Point(4, 22);
            this.tbpNotes.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbpNotes.Name = "tbpNotes";
            this.tbpNotes.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbpNotes.Size = new System.Drawing.Size(461, 74);
            this.tbpNotes.TabIndex = 0;
            this.tbpNotes.Text = "FOOTER NOTES";
            this.tbpNotes.UseVisualStyleBackColor = true;
            // 
            // btnRemark
            // 
            this.btnRemark.Location = new System.Drawing.Point(8, 12);
            this.btnRemark.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.txtRemarkLine.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.tbpExtra.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbpExtra.Name = "tbpExtra";
            this.tbpExtra.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbpExtra.Size = new System.Drawing.Size(461, 74);
            this.tbpExtra.TabIndex = 1;
            this.tbpExtra.Text = "FOOTER NOTE EXTRA";
            this.tbpExtra.UseVisualStyleBackColor = true;
            // 
            // btnOpenDrawer
            // 
            this.btnOpenDrawer.Location = new System.Drawing.Point(4, 20);
            this.btnOpenDrawer.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.tabPageBarcode.Size = new System.Drawing.Size(461, 74);
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
            this.tableLayoutPanel16.Size = new System.Drawing.Size(455, 68);
            this.tableLayoutPanel16.TabIndex = 0;
            // 
            // btnRcptBarcode
            // 
            this.btnRcptBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRcptBarcode.Location = new System.Drawing.Point(2, 1);
            this.btnRcptBarcode.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnRcptBarcode.Name = "btnRcptBarcode";
            this.btnRcptBarcode.Size = new System.Drawing.Size(96, 66);
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
            this.tableLayoutPanel17.Size = new System.Drawing.Size(349, 62);
            this.tableLayoutPanel17.TabIndex = 25;
            // 
            // labelBarcode
            // 
            this.labelBarcode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelBarcode.AutoSize = true;
            this.labelBarcode.Location = new System.Drawing.Point(56, 40);
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
            this.labelBarcodeType.Location = new System.Drawing.Point(42, 9);
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
            this.comboBoxBarcodeTypes.Location = new System.Drawing.Point(200, 5);
            this.comboBoxBarcodeTypes.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.comboBoxBarcodeTypes.Name = "comboBoxBarcodeTypes";
            this.comboBoxBarcodeTypes.Size = new System.Drawing.Size(123, 21);
            this.comboBoxBarcodeTypes.TabIndex = 28;
            // 
            // txtRcptBarcode
            // 
            this.txtRcptBarcode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRcptBarcode.Location = new System.Drawing.Point(176, 36);
            this.txtRcptBarcode.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtRcptBarcode.MaxLength = 25;
            this.txtRcptBarcode.Name = "txtRcptBarcode";
            this.txtRcptBarcode.Size = new System.Drawing.Size(171, 20);
            this.txtRcptBarcode.TabIndex = 29;
            // 
            // tabPageStoppage
            // 
            this.tabPageStoppage.Controls.Add(this.tableLayoutPanel25);
            this.tabPageStoppage.Location = new System.Drawing.Point(4, 22);
            this.tabPageStoppage.Name = "tabPageStoppage";
            this.tabPageStoppage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStoppage.Size = new System.Drawing.Size(461, 74);
            this.tabPageStoppage.TabIndex = 3;
            this.tabPageStoppage.Text = "STOPPAGE";
            this.tabPageStoppage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel25
            // 
            this.tableLayoutPanel25.ColumnCount = 2;
            this.tableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel25.Controls.Add(this.buttonStoppage, 0, 0);
            this.tableLayoutPanel25.Controls.Add(this.tableLayoutPanel26, 1, 0);
            this.tableLayoutPanel25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel25.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel25.Name = "tableLayoutPanel25";
            this.tableLayoutPanel25.RowCount = 1;
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel25.Size = new System.Drawing.Size(455, 68);
            this.tableLayoutPanel25.TabIndex = 0;
            // 
            // buttonStoppage
            // 
            this.buttonStoppage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonStoppage.Location = new System.Drawing.Point(3, 3);
            this.buttonStoppage.Name = "buttonStoppage";
            this.buttonStoppage.Size = new System.Drawing.Size(85, 62);
            this.buttonStoppage.TabIndex = 0;
            this.buttonStoppage.Text = "SEND STOPPAGE";
            this.buttonStoppage.UseVisualStyleBackColor = true;
            this.buttonStoppage.Click += new System.EventHandler(this.buttonStoppage_Click);
            // 
            // tableLayoutPanel26
            // 
            this.tableLayoutPanel26.ColumnCount = 2;
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel26.Controls.Add(this.labelStoppageAmount, 0, 0);
            this.tableLayoutPanel26.Controls.Add(this.numericUpDownStoppageAmount, 1, 0);
            this.tableLayoutPanel26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel26.Location = new System.Drawing.Point(94, 3);
            this.tableLayoutPanel26.Name = "tableLayoutPanel26";
            this.tableLayoutPanel26.RowCount = 2;
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel26.Size = new System.Drawing.Size(358, 62);
            this.tableLayoutPanel26.TabIndex = 1;
            // 
            // labelStoppageAmount
            // 
            this.labelStoppageAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelStoppageAmount.AutoSize = true;
            this.labelStoppageAmount.Location = new System.Drawing.Point(62, 9);
            this.labelStoppageAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStoppageAmount.Name = "labelStoppageAmount";
            this.labelStoppageAmount.Size = new System.Drawing.Size(54, 13);
            this.labelStoppageAmount.TabIndex = 9;
            this.labelStoppageAmount.Text = "AMOUNT";
            // 
            // numericUpDownStoppageAmount
            // 
            this.numericUpDownStoppageAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownStoppageAmount.DecimalPlaces = 2;
            this.numericUpDownStoppageAmount.Location = new System.Drawing.Point(223, 5);
            this.numericUpDownStoppageAmount.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.numericUpDownStoppageAmount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownStoppageAmount.Name = "numericUpDownStoppageAmount";
            this.numericUpDownStoppageAmount.Size = new System.Drawing.Size(90, 20);
            this.numericUpDownStoppageAmount.TabIndex = 17;
            this.numericUpDownStoppageAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownStoppageAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tbcSale
            // 
            this.tbcSale.Controls.Add(this.tbpSale);
            this.tbcSale.Controls.Add(this.tbpVoidSale);
            this.tbcSale.Controls.Add(this.tbpAdj);
            this.tbcSale.Controls.Add(this.tpgSaleDept);
            this.tbcSale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcSale.Location = new System.Drawing.Point(2, 131);
            this.tbcSale.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbcSale.Name = "tbcSale";
            this.tbcSale.SelectedIndex = 0;
            this.tbcSale.Size = new System.Drawing.Size(469, 143);
            this.tbcSale.TabIndex = 28;
            // 
            // tbpSale
            // 
            this.tbpSale.Controls.Add(this.tableLayoutPanel1);
            this.tbpSale.Location = new System.Drawing.Point(4, 22);
            this.tbpSale.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbpSale.Name = "tbpSale";
            this.tbpSale.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbpSale.Size = new System.Drawing.Size(461, 117);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(457, 115);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(191, 109);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblPlu
            // 
            this.lblPlu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPlu.AutoSize = true;
            this.lblPlu.Location = new System.Drawing.Point(32, 11);
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
            this.nmrPlu.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.lblQuantity.Location = new System.Drawing.Point(15, 46);
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
            this.nmrQuantity.Location = new System.Drawing.Point(112, 42);
            this.nmrQuantity.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.nmrPrice.Location = new System.Drawing.Point(112, 79);
            this.nmrPrice.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 73);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(89, 33);
            this.tableLayoutPanel3.TabIndex = 20;
            // 
            // checkBoxForPrice
            // 
            this.checkBoxForPrice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxForPrice.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxForPrice.Location = new System.Drawing.Point(5, 8);
            this.checkBoxForPrice.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.lblAmount.Location = new System.Drawing.Point(38, 10);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(39, 13);
            this.lblAmount.TabIndex = 21;
            this.lblAmount.Text = "PRICE";
            // 
            // btnSale
            // 
            this.btnSale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSale.Location = new System.Drawing.Point(2, 1);
            this.btnSale.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(99, 113);
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
            this.tableLayoutPanel4.Size = new System.Drawing.Size(151, 109);
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
            this.pnlExtraPlufields.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnlExtraPlufields.Name = "pnlExtraPlufields";
            this.pnlExtraPlufields.Size = new System.Drawing.Size(147, 87);
            this.pnlExtraPlufields.TabIndex = 28;
            // 
            // lblWeighable
            // 
            this.lblWeighable.AutoSize = true;
            this.lblWeighable.Location = new System.Drawing.Point(68, 66);
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
            this.checkBoxWeighable.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(90, 20);
            this.txtName.TabIndex = 26;
            // 
            // lblDeptId
            // 
            this.lblDeptId.AutoSize = true;
            this.lblDeptId.Location = new System.Drawing.Point(4, 27);
            this.lblDeptId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeptId.Name = "lblDeptId";
            this.lblDeptId.Size = new System.Drawing.Size(46, 13);
            this.lblDeptId.TabIndex = 25;
            this.lblDeptId.Text = "DEP. ID";
            // 
            // nmrDept
            // 
            this.nmrDept.Location = new System.Drawing.Point(77, 23);
            this.nmrDept.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.cbxSaveAndSale.Location = new System.Drawing.Point(5, 3);
            this.cbxSaveAndSale.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cbxSaveAndSale.Name = "cbxSaveAndSale";
            this.cbxSaveAndSale.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbxSaveAndSale.Size = new System.Drawing.Size(140, 14);
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
            this.tbpVoidSale.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbpVoidSale.Name = "tbpVoidSale";
            this.tbpVoidSale.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbpVoidSale.Size = new System.Drawing.Size(461, 117);
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
            this.txtVoidDeptName.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.cbxVoidDept.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.lblVoidQtty.Location = new System.Drawing.Point(233, 40);
            this.lblVoidQtty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVoidQtty.Name = "lblVoidQtty";
            this.lblVoidQtty.Size = new System.Drawing.Size(94, 13);
            this.lblVoidQtty.TabIndex = 16;
            this.lblVoidQtty.Text = "VOID QUANTITY:";
            // 
            // btnVoidSale
            // 
            this.btnVoidSale.Location = new System.Drawing.Point(4, 25);
            this.btnVoidSale.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnVoidSale.Name = "btnVoidSale";
            this.btnVoidSale.Size = new System.Drawing.Size(110, 38);
            this.btnVoidSale.TabIndex = 2;
            this.btnVoidSale.Text = "VOID SALE";
            this.btnVoidSale.UseVisualStyleBackColor = true;
            this.btnVoidSale.Click += new System.EventHandler(this.btnVoidSale_Click);
            // 
            // nmrVoidQtty
            // 
            this.nmrVoidQtty.DecimalPlaces = 3;
            this.nmrVoidQtty.Location = new System.Drawing.Point(236, 58);
            this.nmrVoidQtty.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.nmrVoidPlu.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.lblVoidPlu.Location = new System.Drawing.Point(158, 40);
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
            this.tbpAdj.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbpAdj.Name = "tbpAdj";
            this.tbpAdj.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbpAdj.Size = new System.Drawing.Size(461, 117);
            this.tbpAdj.TabIndex = 2;
            this.tbpAdj.Text = "ADJUSTMENT";
            this.tbpAdj.UseVisualStyleBackColor = true;
            // 
            // nmrAdjAmount
            // 
            this.nmrAdjAmount.DecimalPlaces = 2;
            this.nmrAdjAmount.Location = new System.Drawing.Point(154, 36);
            this.nmrAdjAmount.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.btnAdjust.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.rbtnFee.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.rbtnDiscount.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.cbxPerc.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.tpgSaleDept.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tpgSaleDept.Name = "tpgSaleDept";
            this.tpgSaleDept.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tpgSaleDept.Size = new System.Drawing.Size(461, 117);
            this.tpgSaleDept.TabIndex = 3;
            this.tpgSaleDept.Text = "DEPT SALE";
            this.tpgSaleDept.UseVisualStyleBackColor = true;
            // 
            // cbxDeptSaleWeighable
            // 
            this.cbxDeptSaleWeighable.Location = new System.Drawing.Point(334, 45);
            this.cbxDeptSaleWeighable.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.btnSaleDept.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnSaleDept.Name = "btnSaleDept";
            this.btnSaleDept.Size = new System.Drawing.Size(110, 38);
            this.btnSaleDept.TabIndex = 30;
            this.btnSaleDept.Text = "SALE";
            this.btnSaleDept.UseVisualStyleBackColor = true;
            this.btnSaleDept.Click += new System.EventHandler(this.btnSaleDept_Click);
            // 
            // nmrDeptSalePrice
            // 
            this.nmrDeptSalePrice.DecimalPlaces = 2;
            this.nmrDeptSalePrice.Location = new System.Drawing.Point(184, 66);
            this.nmrDeptSalePrice.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.txtDeptSaleName.Location = new System.Drawing.Point(350, 14);
            this.txtDeptSaleName.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.nmrDeptSaleId.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.nmrDeptSaleQtty.Location = new System.Drawing.Point(185, 38);
            this.nmrDeptSaleQtty.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.tbcPayment.Controls.Add(this.tabSlipExternal);
            this.tbcPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcPayment.Location = new System.Drawing.Point(2, 276);
            this.tbcPayment.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbcPayment.Name = "tbcPayment";
            this.tbcPayment.SelectedIndex = 0;
            this.tbcPayment.Size = new System.Drawing.Size(469, 113);
            this.tbcPayment.TabIndex = 27;
            // 
            // tbpPay1
            // 
            this.tbpPay1.Controls.Add(this.tableLayoutPanel6);
            this.tbpPay1.Controls.Add(this.lblFCurrValue);
            this.tbpPay1.Controls.Add(this.lblPayIndx);
            this.tbpPay1.Location = new System.Drawing.Point(4, 22);
            this.tbpPay1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbpPay1.Name = "tbpPay1";
            this.tbpPay1.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbpPay1.Size = new System.Drawing.Size(461, 87);
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
            this.tableLayoutPanel6.Location = new System.Drawing.Point(2, 1);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(457, 85);
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
            this.tableLayoutPanel7.Size = new System.Drawing.Size(347, 79);
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
            this.tableLayoutPanel8.Size = new System.Drawing.Size(341, 33);
            this.tableLayoutPanel8.TabIndex = 0;
            // 
            // lblPayAmount
            // 
            this.lblPayAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPayAmount.AutoSize = true;
            this.lblPayAmount.Location = new System.Drawing.Point(30, 10);
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
            this.nmrPaymentAmount.Location = new System.Drawing.Point(210, 6);
            this.nmrPaymentAmount.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 42);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(341, 34);
            this.tableLayoutPanel9.TabIndex = 1;
            // 
            // lblPayType
            // 
            this.lblPayType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPayType.AutoSize = true;
            this.lblPayType.Location = new System.Drawing.Point(3, 10);
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
            this.cbxPaymentType.Location = new System.Drawing.Point(99, 6);
            this.cbxPaymentType.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cbxPaymentType.Name = "cbxPaymentType";
            this.cbxPaymentType.Size = new System.Drawing.Size(67, 21);
            this.cbxPaymentType.TabIndex = 9;
            this.cbxPaymentType.SelectedIndexChanged += new System.EventHandler(this.cbxPaymentType_SelectedIndexChanged);
            // 
            // btnRefreshCredit
            // 
            this.btnRefreshCredit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefreshCredit.Image = global::FP300Service.Properties.Resources.refresh;
            this.btnRefreshCredit.Location = new System.Drawing.Point(307, 3);
            this.btnRefreshCredit.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnRefreshCredit.Name = "btnRefreshCredit";
            this.btnRefreshCredit.Size = new System.Drawing.Size(30, 27);
            this.btnRefreshCredit.TabIndex = 19;
            this.btnRefreshCredit.UseVisualStyleBackColor = true;
            this.btnRefreshCredit.Visible = false;
            this.btnRefreshCredit.Click += new System.EventHandler(this.btnRefreshCredit_Click);
            // 
            // cbxSubPayments
            // 
            this.cbxSubPayments.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxSubPayments.FormattingEnabled = true;
            this.cbxSubPayments.Location = new System.Drawing.Point(170, 6);
            this.cbxSubPayments.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cbxSubPayments.Name = "cbxSubPayments";
            this.cbxSubPayments.Size = new System.Drawing.Size(131, 21);
            this.cbxSubPayments.TabIndex = 17;
            this.cbxSubPayments.SelectedIndexChanged += new System.EventHandler(this.cbxSubPayments_SelectedIndexChanged);
            // 
            // btnPayment
            // 
            this.btnPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPayment.Location = new System.Drawing.Point(2, 1);
            this.btnPayment.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(100, 83);
            this.btnPayment.TabIndex = 6;
            this.btnPayment.Text = "PAYMENT";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // lblFCurrValue
            // 
            this.lblFCurrValue.AutoSize = true;
            this.lblFCurrValue.Location = new System.Drawing.Point(151, 66);
            this.lblFCurrValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFCurrValue.Name = "lblFCurrValue";
            this.lblFCurrValue.Size = new System.Drawing.Size(0, 13);
            this.lblFCurrValue.TabIndex = 20;
            // 
            // lblPayIndx
            // 
            this.lblPayIndx.AutoSize = true;
            this.lblPayIndx.Location = new System.Drawing.Point(291, 25);
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
            this.tbpPayEFT.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbpPayEFT.Name = "tbpPayEFT";
            this.tbpPayEFT.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbpPayEFT.Size = new System.Drawing.Size(461, 87);
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
            this.nmrEFTAmount.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.nmrInstallment.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.txtCardNumber.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtCardNumber.MaxLength = 6;
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(68, 20);
            this.txtCardNumber.TabIndex = 22;
            // 
            // btnEFTAuthorization
            // 
            this.btnEFTAuthorization.Location = new System.Drawing.Point(4, 44);
            this.btnEFTAuthorization.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.btnCardQuery.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.chbSlipCopy.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.tbpVoidPay.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbpVoidPay.Name = "tbpVoidPay";
            this.tbpVoidPay.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbpVoidPay.Size = new System.Drawing.Size(461, 87);
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
            this.checkBoxVoidEft.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.panelVoidEFT.Location = new System.Drawing.Point(274, 1);
            this.panelVoidEFT.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.panelVoidEFT.Name = "panelVoidEFT";
            this.panelVoidEFT.Size = new System.Drawing.Size(182, 77);
            this.panelVoidEFT.TabIndex = 29;
            // 
            // txtStanNo
            // 
            this.txtStanNo.Location = new System.Drawing.Point(77, 47);
            this.txtStanNo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtStanNo.MaxLength = 15;
            this.txtStanNo.Name = "txtStanNo";
            this.txtStanNo.Size = new System.Drawing.Size(90, 20);
            this.txtStanNo.TabIndex = 27;
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.Location = new System.Drawing.Point(77, 25);
            this.txtBatchNo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtBatchNo.MaxLength = 15;
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.Size = new System.Drawing.Size(90, 20);
            this.txtBatchNo.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 51);
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
            this.txtAcquierId.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.btnVoidPayment.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.nmrVoidPayIndex.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.tabRefund.Controls.Add(this.numericUpDownRefundAmount);
            this.tabRefund.Controls.Add(this.labelRefundAmount);
            this.tabRefund.Controls.Add(this.txtAcquierIdRefund);
            this.tabRefund.Controls.Add(this.label6);
            this.tabRefund.Controls.Add(this.btnRefund);
            this.tabRefund.Location = new System.Drawing.Point(4, 22);
            this.tabRefund.Name = "tabRefund";
            this.tabRefund.Size = new System.Drawing.Size(461, 87);
            this.tabRefund.TabIndex = 3;
            this.tabRefund.Text = "EFT REFUND";
            this.tabRefund.UseVisualStyleBackColor = true;
            // 
            // numericUpDownRefundAmount
            // 
            this.numericUpDownRefundAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownRefundAmount.DecimalPlaces = 2;
            this.numericUpDownRefundAmount.Location = new System.Drawing.Point(268, 43);
            this.numericUpDownRefundAmount.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.numericUpDownRefundAmount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownRefundAmount.Name = "numericUpDownRefundAmount";
            this.numericUpDownRefundAmount.Size = new System.Drawing.Size(90, 20);
            this.numericUpDownRefundAmount.TabIndex = 27;
            this.numericUpDownRefundAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelRefundAmount
            // 
            this.labelRefundAmount.AutoSize = true;
            this.labelRefundAmount.Location = new System.Drawing.Point(149, 51);
            this.labelRefundAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRefundAmount.Name = "labelRefundAmount";
            this.labelRefundAmount.Size = new System.Drawing.Size(54, 13);
            this.labelRefundAmount.TabIndex = 26;
            this.labelRefundAmount.Text = "AMOUNT";
            // 
            // txtAcquierIdRefund
            // 
            this.txtAcquierIdRefund.Location = new System.Drawing.Point(267, 19);
            this.txtAcquierIdRefund.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtAcquierIdRefund.MaxLength = 15;
            this.txtAcquierIdRefund.Name = "txtAcquierIdRefund";
            this.txtAcquierIdRefund.Size = new System.Drawing.Size(90, 20);
            this.txtAcquierIdRefund.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(149, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "ACQUIER ID";
            // 
            // btnRefund
            // 
            this.btnRefund.Location = new System.Drawing.Point(15, 19);
            this.btnRefund.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(110, 38);
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
            this.tabPageBankList.Size = new System.Drawing.Size(461, 87);
            this.tabPageBankList.TabIndex = 4;
            this.tabPageBankList.Text = "BANK LIST";
            this.tabPageBankList.UseVisualStyleBackColor = true;
            // 
            // btnBankList
            // 
            this.btnBankList.Location = new System.Drawing.Point(24, 18);
            this.btnBankList.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnBankList.Name = "btnBankList";
            this.btnBankList.Size = new System.Drawing.Size(110, 38);
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
            this.tabPageEftSlipCopy.Size = new System.Drawing.Size(461, 87);
            this.tabPageEftSlipCopy.TabIndex = 5;
            this.tabPageEftSlipCopy.Text = "EFT SLIPCOPY";
            this.tabPageEftSlipCopy.UseVisualStyleBackColor = true;
            // 
            // checkBoxSlpCpyZnoRcptNo
            // 
            this.checkBoxSlpCpyZnoRcptNo.AutoSize = true;
            this.checkBoxSlpCpyZnoRcptNo.Location = new System.Drawing.Point(288, 13);
            this.checkBoxSlpCpyZnoRcptNo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.buttonGetEFTSlipCopy.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonGetEFTSlipCopy.Name = "buttonGetEFTSlipCopy";
            this.buttonGetEFTSlipCopy.Size = new System.Drawing.Size(89, 48);
            this.buttonGetEFTSlipCopy.TabIndex = 38;
            this.buttonGetEFTSlipCopy.Text = "GET SLIPCOPY";
            this.buttonGetEFTSlipCopy.UseVisualStyleBackColor = true;
            this.buttonGetEFTSlipCopy.Click += new System.EventHandler(this.buttonGetEFTSlipCopy_Click);
            // 
            // textBoxSlpCpyRcptNo
            // 
            this.textBoxSlpCpyRcptNo.Location = new System.Drawing.Point(360, 53);
            this.textBoxSlpCpyRcptNo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBoxSlpCpyRcptNo.MaxLength = 15;
            this.textBoxSlpCpyRcptNo.Name = "textBoxSlpCpyRcptNo";
            this.textBoxSlpCpyRcptNo.Size = new System.Drawing.Size(90, 20);
            this.textBoxSlpCpyRcptNo.TabIndex = 37;
            // 
            // textBoxSlpCpyZNo
            // 
            this.textBoxSlpCpyZNo.Location = new System.Drawing.Point(360, 31);
            this.textBoxSlpCpyZNo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.labelSlpCpyZNo.Location = new System.Drawing.Point(286, 38);
            this.labelSlpCpyZNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSlpCpyZNo.Name = "labelSlpCpyZNo";
            this.labelSlpCpyZNo.Size = new System.Drawing.Size(33, 13);
            this.labelSlpCpyZNo.TabIndex = 34;
            this.labelSlpCpyZNo.Text = "Z NO";
            // 
            // textBoxSlpCpyStanNo
            // 
            this.textBoxSlpCpyStanNo.Location = new System.Drawing.Point(175, 53);
            this.textBoxSlpCpyStanNo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBoxSlpCpyStanNo.MaxLength = 15;
            this.textBoxSlpCpyStanNo.Name = "textBoxSlpCpyStanNo";
            this.textBoxSlpCpyStanNo.Size = new System.Drawing.Size(90, 20);
            this.textBoxSlpCpyStanNo.TabIndex = 33;
            // 
            // textBoxSlpCpyBatchNo
            // 
            this.textBoxSlpCpyBatchNo.Location = new System.Drawing.Point(175, 31);
            this.textBoxSlpCpyBatchNo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.labelSlpCpyBatchNo.Location = new System.Drawing.Point(101, 38);
            this.labelSlpCpyBatchNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSlpCpyBatchNo.Name = "labelSlpCpyBatchNo";
            this.labelSlpCpyBatchNo.Size = new System.Drawing.Size(62, 13);
            this.labelSlpCpyBatchNo.TabIndex = 30;
            this.labelSlpCpyBatchNo.Text = "BATCH NO";
            // 
            // textBoxSlpCpyAcquirId
            // 
            this.textBoxSlpCpyAcquirId.Location = new System.Drawing.Point(175, 10);
            this.textBoxSlpCpyAcquirId.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            // tabSlipExternal
            // 
            this.tabSlipExternal.Controls.Add(this.gbxSlipContent);
            this.tabSlipExternal.Controls.Add(this.gbxSlipType);
            this.tabSlipExternal.Controls.Add(this.btnSendSlip);
            this.tabSlipExternal.Location = new System.Drawing.Point(4, 22);
            this.tabSlipExternal.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabSlipExternal.Name = "tabSlipExternal";
            this.tabSlipExternal.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabSlipExternal.Size = new System.Drawing.Size(461, 87);
            this.tabSlipExternal.TabIndex = 6;
            this.tabSlipExternal.Text = "EXTERNAL SLIP";
            this.tabSlipExternal.UseVisualStyleBackColor = true;
            // 
            // gbxSlipContent
            // 
            this.gbxSlipContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxSlipContent.Controls.Add(this.txtSlipLines);
            this.gbxSlipContent.Location = new System.Drawing.Point(241, 3);
            this.gbxSlipContent.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbxSlipContent.Name = "gbxSlipContent";
            this.gbxSlipContent.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbxSlipContent.Size = new System.Drawing.Size(217, 81);
            this.gbxSlipContent.TabIndex = 26;
            this.gbxSlipContent.TabStop = false;
            this.gbxSlipContent.Text = "Slip Lines";
            // 
            // txtSlipLines
            // 
            this.txtSlipLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSlipLines.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSlipLines.Location = new System.Drawing.Point(2, 16);
            this.txtSlipLines.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSlipLines.MaxLength = 2000;
            this.txtSlipLines.Multiline = true;
            this.txtSlipLines.Name = "txtSlipLines";
            this.txtSlipLines.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSlipLines.Size = new System.Drawing.Size(213, 62);
            this.txtSlipLines.TabIndex = 0;
            this.txtSlipLines.Text = resources.GetString("txtSlipLines.Text");
            this.txtSlipLines.WordWrap = false;
            // 
            // gbxSlipType
            // 
            this.gbxSlipType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbxSlipType.Controls.Add(this.rbtnSlipTypeError);
            this.gbxSlipType.Controls.Add(this.rbtnSlipTypeMerchant);
            this.gbxSlipType.Controls.Add(this.rbtnSlipTypeCustomer);
            this.gbxSlipType.Location = new System.Drawing.Point(128, 3);
            this.gbxSlipType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbxSlipType.Name = "gbxSlipType";
            this.gbxSlipType.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbxSlipType.Size = new System.Drawing.Size(109, 81);
            this.gbxSlipType.TabIndex = 25;
            this.gbxSlipType.TabStop = false;
            this.gbxSlipType.Text = "Select Slip Type";
            // 
            // rbtnSlipTypeError
            // 
            this.rbtnSlipTypeError.AutoSize = true;
            this.rbtnSlipTypeError.Location = new System.Drawing.Point(16, 58);
            this.rbtnSlipTypeError.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbtnSlipTypeError.Name = "rbtnSlipTypeError";
            this.rbtnSlipTypeError.Size = new System.Drawing.Size(50, 17);
            this.rbtnSlipTypeError.TabIndex = 2;
            this.rbtnSlipTypeError.TabStop = true;
            this.rbtnSlipTypeError.Text = "Error ";
            this.rbtnSlipTypeError.UseVisualStyleBackColor = true;
            // 
            // rbtnSlipTypeMerchant
            // 
            this.rbtnSlipTypeMerchant.AutoSize = true;
            this.rbtnSlipTypeMerchant.Location = new System.Drawing.Point(16, 40);
            this.rbtnSlipTypeMerchant.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbtnSlipTypeMerchant.Name = "rbtnSlipTypeMerchant";
            this.rbtnSlipTypeMerchant.Size = new System.Drawing.Size(70, 17);
            this.rbtnSlipTypeMerchant.TabIndex = 1;
            this.rbtnSlipTypeMerchant.Text = "Merchant";
            this.rbtnSlipTypeMerchant.UseVisualStyleBackColor = true;
            // 
            // rbtnSlipTypeCustomer
            // 
            this.rbtnSlipTypeCustomer.AutoSize = true;
            this.rbtnSlipTypeCustomer.Checked = true;
            this.rbtnSlipTypeCustomer.Location = new System.Drawing.Point(16, 19);
            this.rbtnSlipTypeCustomer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbtnSlipTypeCustomer.Name = "rbtnSlipTypeCustomer";
            this.rbtnSlipTypeCustomer.Size = new System.Drawing.Size(69, 17);
            this.rbtnSlipTypeCustomer.TabIndex = 0;
            this.rbtnSlipTypeCustomer.TabStop = true;
            this.rbtnSlipTypeCustomer.Text = "Customer";
            this.rbtnSlipTypeCustomer.UseVisualStyleBackColor = true;
            // 
            // btnSendSlip
            // 
            this.btnSendSlip.Location = new System.Drawing.Point(8, 22);
            this.btnSendSlip.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnSendSlip.Name = "btnSendSlip";
            this.btnSendSlip.Size = new System.Drawing.Size(110, 35);
            this.btnSendSlip.TabIndex = 24;
            this.btnSendSlip.Text = "SEND SLIP";
            this.btnSendSlip.UseVisualStyleBackColor = true;
            this.btnSendSlip.Click += new System.EventHandler(this.btnSendSlip_Click);
            // 
            // bntPrintJSONDoc
            // 
            this.bntPrintJSONDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bntPrintJSONDoc.Location = new System.Drawing.Point(2, 148);
            this.bntPrintJSONDoc.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.bntPrintJSONDoc.Name = "bntPrintJSONDoc";
            this.bntPrintJSONDoc.Size = new System.Drawing.Size(116, 47);
            this.bntPrintJSONDoc.TabIndex = 26;
            this.bntPrintJSONDoc.Text = "PRINT JSON";
            this.bntPrintJSONDoc.UseVisualStyleBackColor = true;
            this.bntPrintJSONDoc.Click += new System.EventHandler(this.bntPrintJSONDoc_Click);
            // 
            // btnCorrect
            // 
            this.btnCorrect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCorrect.Location = new System.Drawing.Point(2, 295);
            this.btnCorrect.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnCorrect.Name = "btnCorrect";
            this.btnCorrect.Size = new System.Drawing.Size(116, 47);
            this.btnCorrect.TabIndex = 19;
            this.btnCorrect.Text = "CORRECT";
            this.btnCorrect.UseVisualStyleBackColor = true;
            this.btnCorrect.Click += new System.EventHandler(this.btnCorrect_Click);
            // 
            // btnSubtotal
            // 
            this.btnSubtotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSubtotal.Location = new System.Drawing.Point(2, 246);
            this.btnSubtotal.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnSubtotal.Name = "btnSubtotal";
            this.btnSubtotal.Size = new System.Drawing.Size(116, 47);
            this.btnSubtotal.TabIndex = 5;
            this.btnSubtotal.Text = "SUBTOTAL";
            this.btnSubtotal.UseVisualStyleBackColor = true;
            this.btnSubtotal.Click += new System.EventHandler(this.btnSubtotal_Click);
            // 
            // btnVoidReceipt
            // 
            this.btnVoidReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVoidReceipt.Location = new System.Drawing.Point(2, 393);
            this.btnVoidReceipt.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnVoidReceipt.Name = "btnVoidReceipt";
            this.btnVoidReceipt.Size = new System.Drawing.Size(116, 47);
            this.btnVoidReceipt.TabIndex = 4;
            this.btnVoidReceipt.Text = "VOID DOCUMENT";
            this.btnVoidReceipt.UseVisualStyleBackColor = true;
            this.btnVoidReceipt.Click += new System.EventHandler(this.btnVoidReceipt_Click);
            // 
            // btnCloseReceipt
            // 
            this.btnCloseReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCloseReceipt.Location = new System.Drawing.Point(2, 344);
            this.btnCloseReceipt.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnCloseReceipt.Name = "btnCloseReceipt";
            this.btnCloseReceipt.Size = new System.Drawing.Size(116, 47);
            this.btnCloseReceipt.TabIndex = 3;
            this.btnCloseReceipt.Text = "CLOSE DOCUMENT";
            this.btnCloseReceipt.UseVisualStyleBackColor = true;
            this.btnCloseReceipt.Click += new System.EventHandler(this.btnCloseReceipt_Click);
            // 
            // btnRcptInfo
            // 
            this.btnRcptInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRcptInfo.Location = new System.Drawing.Point(2, 99);
            this.btnRcptInfo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnRcptInfo.Name = "btnRcptInfo";
            this.btnRcptInfo.Size = new System.Drawing.Size(116, 47);
            this.btnRcptInfo.TabIndex = 31;
            this.btnRcptInfo.Text = "RECEIPT INFO";
            this.btnRcptInfo.UseVisualStyleBackColor = true;
            this.btnRcptInfo.Click += new System.EventHandler(this.btnRcptInfo_Click);
            // 
            // buttonAutoPrintPLU
            // 
            this.buttonAutoPrintPLU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAutoPrintPLU.Location = new System.Drawing.Point(2, 50);
            this.buttonAutoPrintPLU.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonAutoPrintPLU.Name = "buttonAutoPrintPLU";
            this.buttonAutoPrintPLU.Size = new System.Drawing.Size(116, 47);
            this.buttonAutoPrintPLU.TabIndex = 32;
            this.buttonAutoPrintPLU.Text = "AUTO PRINT    JSON PLU";
            this.buttonAutoPrintPLU.UseVisualStyleBackColor = true;
            this.buttonAutoPrintPLU.Click += new System.EventHandler(this.buttonAutoPrint_Click);
            // 
            // btnJsonOnlyDept
            // 
            this.btnJsonOnlyDept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJsonOnlyDept.Location = new System.Drawing.Point(2, 197);
            this.btnJsonOnlyDept.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnJsonOnlyDept.Name = "btnJsonOnlyDept";
            this.btnJsonOnlyDept.Size = new System.Drawing.Size(116, 47);
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
            this.buttonPrintSalesDocument.Location = new System.Drawing.Point(2, 442);
            this.buttonPrintSalesDocument.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonPrintSalesDocument.Name = "buttonPrintSalesDocument";
            this.buttonPrintSalesDocument.Size = new System.Drawing.Size(116, 49);
            this.buttonPrintSalesDocument.TabIndex = 35;
            this.buttonPrintSalesDocument.Text = "PRINT SALE DOCUMENT";
            this.buttonPrintSalesDocument.UseVisualStyleBackColor = true;
            this.buttonPrintSalesDocument.Click += new System.EventHandler(this.buttonPrintSalesDocument_Click);
            // 
            // buttonAutoPrintDEPT
            // 
            this.buttonAutoPrintDEPT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAutoPrintDEPT.Location = new System.Drawing.Point(2, 1);
            this.buttonAutoPrintDEPT.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonAutoPrintDEPT.Name = "buttonAutoPrintDEPT";
            this.buttonAutoPrintDEPT.Size = new System.Drawing.Size(116, 47);
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
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.tabPageCrrAccountCollctn.ResumeLayout(false);
            this.tableLayoutPanel18.ResumeLayout(false);
            this.tableLayoutPanel19.ResumeLayout(false);
            this.tableLayoutPanel19.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCrrAccAmount)).EndInit();
            this.tabPageEDocument.ResumeLayout(false);
            this.tabPageEDocument.PerformLayout();
            this.tabPageDataTest.ResumeLayout(false);
            this.tabPageReturnDoc.ResumeLayout(false);
            this.tableLayoutPanel27.ResumeLayout(false);
            this.tableLayoutPanel28.ResumeLayout(false);
            this.tableLayoutPanel29.ResumeLayout(false);
            this.tableLayoutPanel29.PerformLayout();
            this.tableLayoutPanel30.ResumeLayout(false);
            this.tableLayoutPanel30.PerformLayout();
            this.tableLayoutPanel31.ResumeLayout(false);
            this.tableLayoutPanel31.PerformLayout();
            this.tbcFooter.ResumeLayout(false);
            this.tbpNotes.ResumeLayout(false);
            this.tbpNotes.PerformLayout();
            this.tbpExtra.ResumeLayout(false);
            this.tabPageBarcode.ResumeLayout(false);
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel17.ResumeLayout(false);
            this.tableLayoutPanel17.PerformLayout();
            this.tabPageStoppage.ResumeLayout(false);
            this.tableLayoutPanel25.ResumeLayout(false);
            this.tableLayoutPanel26.ResumeLayout(false);
            this.tableLayoutPanel26.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStoppageAmount)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefundAmount)).EndInit();
            this.tabPageBankList.ResumeLayout(false);
            this.tabPageEftSlipCopy.ResumeLayout(false);
            this.tabPageEftSlipCopy.PerformLayout();
            this.tabSlipExternal.ResumeLayout(false);
            this.gbxSlipContent.ResumeLayout(false);
            this.gbxSlipContent.PerformLayout();
            this.gbxSlipType.ResumeLayout(false);
            this.gbxSlipType.PerformLayout();
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
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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
            catch(Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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
            catch(Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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

                if(paymentType > 3)
                {
                    // I increase this, because 4 is reserved for EFTPOS
                    paymentType++;
                }
                //IF PAYMENT IS FOREIGN CURRENCY OR CREDIT
                if ((cbxPaymentType.Text == FormMessage.CURRENCY) || (cbxPaymentType.Text == FormMessage.CREDIT) || (cbxPaymentType.Text == FormMessage.FOODCARD))
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
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message); ;
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
                case FormMessage.FOODCARD:
                    int foodCardCount = 0;
                    btnRefreshCredit.Visible = true;
                    //if (MainForm.Credits[0] == null)
                    {
                        cbxSubPayments.Visible = false;
                        foodCardCount = RefreshFoodCards();
                    }
                    if (MainForm.Credits[0] != null || foodCardCount > 0)
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
            if (cbxPaymentType.SelectedIndex == 1)
            {
                RefreshCredits();
            }
            else if(cbxPaymentType.SelectedIndex == 4)
            {
                RefreshFoodCards();
            }
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
                catch
                {
                    bridge.Log(FormMessage.OPERATION_FAILS);
                }
            }


            return creditCount;
        }
        
        private int RefreshFoodCards()
        {
            cbxSubPayments.Items.Clear();
            bridge.Log(FormMessage.FOODCARDS_LOADED);
            return 0;
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
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
        }

        private void btnVoidPayment_Click(object sender, EventArgs e)
        {
            CPResponse response = null;
            try
            {
                if (checkBoxVoidEft.Checked)
                {
                    response = new CPResponse(bridge.Printer.VoidEFTPayment(int.Parse(txtAcquierId.Text), int.Parse(txtBatchNo.Text), int.Parse(txtStanNo.Text)));

                    if (response.ErrorCode == 0)
                    {
                        bridge.Log(String.Format(FormMessage.AMOUNT.PadRight(12, ' ') + ":{0}", response.GetNextParam()));
                        bridge.Log(String.Format(FormMessage.ACQUIER_ID.PadRight(12, ' ') + ":{0}", response.GetNextParam()));
                        bridge.Log(String.Format("ISSUER ID".PadRight(12, ' ') + ":{0}", response.GetNextParam()));
                        bridge.Log(String.Format("CARD BIN".PadRight(12, ' ') + ":{0}", response.GetNextParam()));
                    }
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
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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
                    string totalAmount = response.GetNextParam();
                    string provisionCode = response.GetNextParam();
                    string paidAmount = response.GetNextParam();
                    string installmentCount = response.GetNextParam();
                    string acquirerId = response.GetNextParam();
                    string bin = response.GetNextParam();
                    string issuerId = response.GetNextParam();
                    string subOprtType = response.GetNextParam();
                    string batch = response.GetNextParam();
                    string stan = response.GetNextParam();
                    string totalPaidAmount = response.GetNextParam();

                    bridge.Log(String.Format("İşlem Tutarı   :{0}", paidAmount));
                    bridge.Log(String.Format("Ödeme Toplamı  :{0}", totalPaidAmount));
                    bridge.Log(String.Format("Belge Tutarı   :{0}", totalAmount));
                    bridge.Log(String.Format("Taksit sayısı  :{0}", installmentCount));
                    bridge.Log(String.Format("Provizyon kodu :{0}", provisionCode));
                    bridge.Log(String.Format("ACQUIRER ID    :{0}", acquirerId));
                    bridge.Log(String.Format("BIN            :{0}", bin));
                    bridge.Log(String.Format("ISSUERER ID    :{0}", issuerId));
                    if(!String.IsNullOrEmpty(batch))
                        bridge.Log(String.Format("BATCH NO       :{0}", batch));
                    if(!String.IsNullOrEmpty(stan))
                        bridge.Log(String.Format("STAN NO        :{0}", stan));

                    if (subOprtType == null)
                    {
                        subOprtType = SubOperationType.SATIS.ToString();
                    }
                    else
                    {
                        subOprtType = Enum.GetName(typeof(SubOperationType), int.Parse(subOprtType));
                    }
                    bridge.Log(String.Format("Alt İşlem Tipi :{0}", subOprtType));

                }

            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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
                CPResponse response;

                if (numericUpDownRefundAmount.Value > 0)
                {
                    response = new CPResponse(bridge.Printer.RefundEFTPayment(int.Parse(txtAcquierIdRefund.Text), numericUpDownRefundAmount.Value));

                    if (response.ErrorCode == 0)
                    {
                        bridge.Log(String.Format(FormMessage.AMOUNT.PadRight(12, ' ') + ":{0}", response.GetNextParam()));
                        bridge.Log(String.Format(FormMessage.ACQUIER_ID.PadRight(12, ' ') + ":{0}", response.GetNextParam()));
                        bridge.Log(String.Format("ISSUER ID".PadRight(12, ' ') + ":{0}", response.GetNextParam()));
                        bridge.Log(String.Format("CARD BIN".PadRight(12, ' ') + ":{0}", response.GetNextParam()));
                    }
                }
                else
                    response = new CPResponse(bridge.Printer.RefundEFTPayment(int.Parse(txtAcquierIdRefund.Text)));
            }
            catch(Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
        }

        private void btnBankList_Click(object sender, EventArgs e)
        {
            CPResponse response = null;
            try
            {
                response = new CPResponse(bridge.Printer.GetBankListOnEFT());

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
                            string payType = response.GetNextParam();
                            payType = Enum.GetName(typeof(InfoReceiptPaymentType), int.Parse(payType));
                            bridge.Log(String.Format("PAY TYPE   : {0}", payType));
                            bridge.Log(String.Format("PAY INDEX  : {0}", response.GetNextParam()));
                            bridge.Log(String.Format("PAY AMOUNT : {0}", response.GetNextParam()));
                            bridge.Log(String.Format("PAY DETAIL : {0}", response.GetNextParam()));
                        }

                        int kdvCount = Convert.ToInt32(response.GetNextParam());
                        decimal vatTotalKdv = 0;
                        decimal total = 0;
                        string tempVal = "";
                        for (int i = 0; i < kdvCount; i++)
                        {
                            bridge.Log(String.Format("KDV RATE         : {0}", response.GetNextParam()));
                            tempVal = response.GetNextParam();
                            total += Convert.ToDecimal(tempVal);
                            bridge.Log(String.Format("KDV TOTAL AMOUNT : {0}", tempVal));
                            tempVal = response.GetNextParam();
                            vatTotalKdv += Convert.ToDecimal(tempVal);
                            bridge.Log(String.Format("KDV AMOUNT       : {0}", tempVal));
                        }

                        bridge.Log(String.Format("TOTAL  : {0}", total));
                        bridge.Log(String.Format("KDV : {0}", vatTotalKdv));

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
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
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

        static int GetZRepAt;
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

        private void btnPrintCurrAccHeader_Click(object sender, EventArgs e)
        {
            try
            {
                string tcknVkn = textBoxCrrAccTcknVkn.Text;
                string name = textBoxCrrAccCustName.Text;
                string serial = textBoxCrrAccDocSerial.Text;
                decimal amount = numericUpDownCrrAccAmount.Value;
                DateTime date = dateTimePickerCrrAccDate.Value;

                CPResponse response = new CPResponse(bridge.Printer.PrintCurrentAccountCollectionDocumentHeader(tcknVkn, name, serial, date, amount));
                if (response.ErrorCode == 0)
                {
                    bridge.Log(FormMessage.DOCUMENT_ID + "  :" + response.GetNextParam());
                }
            }
            catch(Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
            
        }

        private void buttonPrintEDocumentSample_Click(object sender, EventArgs e)
        {
            List<string> lineList = new List<string>();

            int docType = 3;
            try
            {
                switch(comboBoxEDocumentDocTypes.SelectedIndex)
                {
                    case 0:
                        docType = 1;
                        lineList = GetInvoiceSample();
                        break;
                    case 1:
                        docType = 3;
                        lineList = GetEDocumentSample();
                        break;
                    case 2:
                        docType = 2;
                        lineList = GetEDocumentSample();
                        break;
                    case 3:
                        docType = 9;
                        lineList = GetNoteOfExpensesSample();
                        break;
                    case 4:
                        docType = 10;
                        lineList = GetSelfEmplyomentInvoiceSample();
                        break;
                    case 5:
                        docType = 1;
                        lineList = GetInvoiceSample2();
                        break;
                }

                CPResponse response = new CPResponse(bridge.Printer.PrintEDocumentCopy(docType, lineList.ToArray()));

            }
            catch (Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
        }

        private List<string> GetEDocumentSample()
        {
            return new List<string>(new string[] {

            "Sayın,                       15-05-2017 00:00:00",
            "HUGIN ALICI                     HGN2017019800001",
            "VKN: 3333333337                            SATIS",
            "ŞİŞLİ / İSTANBUL                     TEMELFATURA",
            "V.D. : GALATA                7025680A-BC3C-4AB6-",
            "                               A37B-34A68B4C1B7C",
            "                                                ",
            "                                                ",
            "SLIM FIT KOT PANTOLON        %18      235,99 TRY",
            "        5 X 70,00                               ",
            "MAVI SATEN GÖMLEK            %08      350,00 TRY",
            "DERİ CEKET ERKEK             %01      700,00 TRY",
            "       10 X 15,00                               ",
            "HAKIKI DERİ KEMER            %18      150,00 TRY",
            "                                                ",
            "                                                ",
            "                           Toplam:  17029,24 TRY",
            "                          KDV %01:   1001,55 TRY",
            "                          KDV %08:    901,55 TRY",
            "      Vergiler Dahil Toplam Tutar:  18030,80 TRY",
            "                                                ",
            "                                                ",
            "------------------------------------------------",
            "* E-Arşiv İzni kapsamında elektronik ortamda    ",
            "iletilmiştir.                                   ",
            "* YALNIZ ONSEKİZBİNOTUZ TL SEKSEN KR'DiR        ",
            "* NAKİT  18030,80 TRY                           ",
            "* Gönderim Şekli: KAĞIT                         "

            });
        }

        private List<string> GetNoteOfExpensesSample()
        {
            return new List<string>(new string[] {

            "Sayın,                       29-03-2018 16:16:53",
            "HUGIN ALICI                   FP1100438500240127",
            "VKN: 3333333337                             IADE",
            "ŞİŞLİ / İSTANBUL                  GİDER PUSULASI",
            "T:02122525252                                   ",
            "F:02122525353                        MERSIS/EBIS",
            "V.D. : GALATA             1234567890754645254234",
            "                                                ",
            "                                                ",
            "                                                ",
            "SLIM FIT KOT PANTOLON        %18      235,99 TRY",
            "        5 X 70,00                               ",
            "MAVI SATEN GÖMLEK            %08      350,00 TRY",
            "DERİ CEKET ERKEK             %01      700,00 TRY",
            "       10 X 15,00                               ",
            "HAKIKI DERİ KEMER            %18      150,00 TRY",
            "                                                ",
            "                                                ",
            "                           Toplam:  17029,24 TRY",
            "                          KDV %01:   1001,55 TRY",
            "                          KDV %08:    901,55 TRY",
            "      Vergiler Dahil Toplam Tutar:  18030,80 TRY",
            "                                                ",
            "DÜZENLEYEN: SERDAR GÖKCEN                       ",
            "İMZA :                                          ",
            "                                                ",
            "------------------------------------------------",
            "* YALNIZ ONSEKİZBİNOTUZ TL SEKSEN KR'DiR        ",
            "* NAKİT  18030,80 TRY                           "

            });
        }

        private List<string> GetSelfEmplyomentInvoiceSample()
        {
            return new List<string>(new string[] {

            "Sayın,                       29-03-2018 16:16:53",
            "HUGIN ALICI                   FP1100438500240127",
            "VKN: 3333333337                            SATIS",
            "ŞİŞLİ / İSTANBUL          SERBEST MESLEK MAKBUZU",
            "T:02122525252                                   ",
            "F:02122525353                        MERSIS/EBIS",
            "V.D. : GALATA             1234567890754645254234",
            "                                                ",
            "                                                ",
            "                                                ",
            "SLIM FIT KOT PANTOLON        %18      235,99 TRY",
            "        5 X 70,00                               ",
            "MAVI SATEN GÖMLEK            %08      350,00 TRY",
            "DERİ CEKET ERKEK             %01      700,00 TRY",
            "       10 X 15,00                               ",
            "HAKIKI DERİ KEMER            %18      150,00 TRY",
            "                                                ",
            "                                                ",
            "                           Toplam:  17029,24 TRY",
            "                          KDV %01:   1001,55 TRY",
            "                          KDV %08:    901,55 TRY",
            "      Vergiler Dahil Toplam Tutar:  18030,80 TRY",
            "                                                ",
            "DÜZENLEYEN: SERDAR GÖKCEN                       ",
            "İMZA :                                          ",
            "                                                ",
            "------------------------------------------------",
            "* YALNIZ ONSEKİZBİNOTUZ TL SEKSEN KR'DiR        ",
            "* NAKİT  18030,80 TRY                           "

            });
        }

        private List<string> GetInvoiceSample()
        {
            return new List<string>(new string[] {

            "Sayın,                       29-03-2018 16:16:53",
            "HUGIN ALICI                             AA123456",
            "VKN: 3333333337                            SATIS",
            "ŞİŞLİ / İSTANBUL                          FATURA",
            "T:02122525252                                   ",
            "F:02122525353                        MERSIS/EBIS",
            "V.D. : GALATA             1234567890754645254234",
            "                                                ",
            "                                                ",
            "                                                ",
            "SLIM FIT KOT PANTOLON        %18      235,99 TRY",
            "        5 X 70,00                               ",
            "MAVI SATEN GÖMLEK            %08      350,00 TRY",
            "DERİ CEKET ERKEK             %01      700,00 TRY",
            "       10 X 15,00                               ",
            "HAKIKI DERİ KEMER            %18      150,00 TRY",
            "                                                ",
            "                                                ",
            "                           Toplam:  17029,24 TRY",
            "                          KDV %01:   1001,55 TRY",
            "                          KDV %08:    901,55 TRY",
            "      Vergiler Dahil Toplam Tutar:  18030,80 TRY",
            "                                                ",
            "DÜZENLEYEN: SERDAR GÖKCEN                       ",
            "İMZA :                                          ",
            "                                                ",
            "------------------------------------------------",
            "* YALNIZ ONSEKİZBİNOTUZ TL SEKSEN KR'DiR        ",
            "* NAKİT  18030,80 TRY                           "

            });
        }

        private List<string> GetInvoiceSample2()
        {
            return new List<string>(new string[] {

            "Sayın,                       29-03-2018 16:16:53",
            "HUGIN ALICI                             AA123456",
            "VKN: 3333333337                            SATIS",
            "ŞİŞLİ / İSTANBUL                          FATURA",
            "T:02122525252                                   ",
            "F:02122525353                        MERSIS/EBIS",
            "V.D. : GALATA             1234567890754645254234",
            "",
            "",
            "",
            "SLIM FIT KOT PANTOLON        %18      235,99 TRY",
            "        5 X 70,00                               ",
            "MAVI SATEN GÖMLEK            %08      350,00 TRY",
            "DERİ CEKET ERKEK             %01      700,00 TRY",
            "       10 X 15,00                               ",
            "HAKIKI DERİ KEMER            %18      150,00 TRY",
            "                                                ",
            "                                                ",
            "                           Toplam:  17029,24 TRY",
            "                          KDV %01:   1001,55 TRY",
            "                          KDV %08:    901,55 TRY",
            "      Vergiler Dahil Toplam Tutar:  18030,80 TRY",
            "                                                ",
            "DÜZENLEYEN: SERDAR GÖKCEN                       ",
            "İMZA :                                          ",
            "                                                ",
            "------------------------------------------------",
            "* YALNIZ ONSEKİZBİNOTUZ TL SEKSEN KR'DiR        ",
            "* NAKİT  18030,80 TRY                           "

            });
        }

        private void buttonSendTestData_Click(object sender, EventArgs e)
        {
            //string rawData = "DF-F0-01-01-03-DF-F0-03-02-10-60-DF-F0-04-02-48-50-DF-F0-18-14-49-53-50-41-4E-41-4B-20-4B-47-20-20-20-20-20-20-20-20-20-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-08-06-DF-F0-04-02-33-50-DF-F0-18-14-48-41-56-55-C7-20-4B-47-20-20-20-20-20-20-20-20-20-20-20-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-30-DF-F0-04-02-39-50-DF-F0-18-14-50-41-54-4C-49-43-41-4E-20-4B-45-4D-45-52-20-4B-47-20-20-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-54-DF-F0-04-02-39-50-DF-F0-18-14-42-DD-42-45-52-20-31-2E-4B-41-4C-DD-54-45-20-4B-47-20-20-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-11-06-DF-F0-04-02-84-50-DF-F0-18-14-C7-DD-4C-45-4B-20-4F-52-47-41-4E-DD-4B-20-4B-47-20-20-20-20-DF-F0-1F-01-01-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-13-86-DF-F0-04-03-01-09-00-DF-F0-18-14-4D-55-5A-20-DD-54-48-41-4C-20-4B-47-20-20-20-20-20-20-20-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-28-94-DF-F0-04-02-49-50-DF-F0-18-14-44-4F-4D-41-54-45-53-20-4B-47-20-20-20-20-20-20-20-20-20-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-25-00-DF-F0-18-14-46-41-4C-49-4D-20-53-41-4B-49-5A-20-35-58-35-20-4C-DD-20-4F-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-25-00-DF-F0-18-14-46-41-4C-49-4D-20-53-41-4B-49-5A-20-35-58-35-20-4C-DD-20-4B-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-03-01-42-50-DF-F0-18-14-59-55-4D-4F-DE-20-59-55-4D-55-DE-41-54-49-43-49-20-4C-41-56-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-04-08-DF-F0-04-02-68-50-DF-F0-18-14-4C-DD-4D-4F-4E-20-4B-47-20-20-20-20-20-20-20-20-20-20-20-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-24-24-DF-F0-04-02-59-50-DF-F0-18-14-45-4C-4D-41-20-59-2E-41-52-4A-41-4E-54-DD-4E-20-4B-47-20-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-25-22-DF-F0-04-02-19-50-DF-F0-18-14-50-41-54-41-54-45-53-20-4B-47-20-20-20-20-20-20-20-20-20-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-18-84-DF-F0-04-02-59-50-DF-F0-18-14-41-52-4D-55-54-20-53-41-4E-54-41-20-4B-47-20-20-20-20-20-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-02-17-50-DF-F0-18-14-43-4F-4F-4B-20-42-55-5A-44-4F-4C-41-42-49-20-50-4F-DE-45-54-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-03-09-00-DF-F0-18-14-59-55-44-55-4D-20-41-59-C7-DD-C7-45-4B-20-59-41-D0-49-20-35-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-02-52-50-DF-F0-18-14-53-43-4F-54-43-48-20-42-52-DD-54-45-20-4B-4C-41-53-DD-4B-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-21-62-DF-F0-04-02-19-50-DF-F0-18-14-53-4F-D0-41-4E-20-4B-47-20-20-20-20-20-20-20-20-20-20-20-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-02-42-50-DF-F0-18-14-44-4F-4D-45-53-54-4F-53-20-C7-41-4D-41-DE-49-52-20-53-55-59-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-02-85-00-DF-F0-18-14-44-41-4C-DD-4E-20-49-53-4C-41-4B-20-4D-45-4E-44-DD-4C-20-33-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-72-50-DF-F0-18-14-56-DD-4C-45-44-41-20-53-DC-4E-47-45-52-20-42-45-5A-20-33-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-02-72-50-DF-F0-18-14-46-41-DD-52-59-20-42-55-4C-41-DE-49-4B-20-44-45-54-45-52-4A-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-03-01-35-00-DF-F0-18-14-44-55-52-55-20-53-49-56-49-20-53-41-42-55-4E-20-47-4F-55-52-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-02-62-50-DF-F0-18-14-43-DD-46-20-4B-52-45-4D-20-55-4C-54-52-41-20-47-DC-C7-20-32-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-03-01-79-00-DF-F0-18-14-52-DD-4E-53-4F-20-4D-41-54-DD-4B-20-42-45-59-41-5A-20-47-DC-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-03-02-40-00-DF-F0-04-02-05-00-DF-F0-18-14-DC-4C-4B-45-52-20-43-41-46-45-20-43-52-4F-57-4E-20-4C-41-54-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-13-50-DF-F0-18-14-DC-4C-4B-45-52-20-4D-41-4B-41-52-4E-45-4B-53-20-44-4F-4D-41-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-02-DF-F0-03-02-10-00-DF-F0-04-03-01-39-50-DF-F0-18-14-48-45-4B-DD-4D-4F-D0-4C-55-20-55-4E-20-35-20-4B-47-20-20-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-13-50-DF-F0-18-14-DC-4C-4B-45-52-20-4D-41-4B-41-52-4E-45-4B-53-20-41-43-49-20-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-02-62-50-DF-F0-18-14-C7-41-59-4B-55-52-20-C7-41-59-20-52-DD-5A-45-20-54-55-52-DD-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-15-00-DF-F0-18-14-46-DD-4C-DD-5A-20-4D-41-4B-41-52-4E-41-20-42-55-52-47-55-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-15-00-DF-F0-18-14-46-DD-4C-DD-5A-20-4D-41-4B-41-52-4E-41-20-4B-41-4C-45-4D-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-17-50-DF-F0-18-14-41-4E-4B-41-52-41-20-4D-41-4B-41-52-4E-41-20-46-DD-59-4F-4E-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-01-89-50-DF-F0-18-14-53-45-C7-4B-DD-4E-20-50-DD-52-DD-4E-C7-20-42-41-4C-44-4F-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-40-00-DF-F0-18-14-47-DC-4E-45-DE-20-4E-DD-DE-41-53-54-41-20-38-30-30-20-47-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-17-50-DF-F0-18-14-41-4E-4B-41-52-41-20-4D-41-4B-41-52-4E-41-20-4D-DD-44-59-45-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-92-50-DF-F0-18-14-44-4F-D0-55-DE-20-C7-41-59-20-42-4C-41-43-4B-20-4C-41-42-45-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-16-50-DF-F0-18-14-4E-2E-41-4E-4B-41-52-41-20-DD-52-4D-DD-4B-20-35-30-30-20-47-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-01-05-00-DF-F0-18-14-53-45-C7-4B-DD-4E-20-4D-45-52-43-DD-4D-45-4B-20-4B-49-52-4D-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-15-00-DF-F0-18-14-46-DD-4C-DD-5A-20-4D-41-4B-41-52-4E-41-20-42-4F-4E-43-55-4B-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-32-50-DF-F0-18-14-42-DD-4C-4C-55-52-20-54-55-5A-20-DD-59-4F-54-4C-55-20-31-2E-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-17-50-DF-F0-18-14-41-4E-4B-41-52-41-20-4D-41-4B-41-52-4E-41-20-45-52-DD-DE-54-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-01-49-50-DF-F0-18-14-53-45-C7-4B-DD-4E-20-50-DD-52-DD-4E-C7-20-4F-53-4D-41-4E-43-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-17-50-DF-F0-18-14-41-4E-4B-41-52-41-20-4D-41-4B-41-52-4E-41-20-DE-45-48-52-DD-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-17-50-DF-F0-18-14-41-4E-4B-41-52-41-20-4D-41-4B-41-52-4E-41-20-4E-55-48-27-55-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-02-19-00-DF-F0-18-14-54-4F-52-4B-55-20-54-4F-5A-DE-45-4B-45-52-20-35-30-30-30-20-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-02-19-00-DF-F0-18-14-54-4F-52-4B-55-20-54-4F-5A-DE-45-4B-45-52-20-35-30-30-30-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-17-50-DF-F0-18-14-41-4E-4B-41-52-41-20-4D-41-4B-41-52-4E-41-20-53-50-41-47-45-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-15-00-DF-F0-18-14-46-DD-4C-DD-5A-20-4D-41-4B-41-52-4E-41-20-53-50-41-47-45-54-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-74-00-DF-F0-18-14-53-45-C7-4B-DD-4E-20-42-55-4C-47-55-52-20-50-DD-4C-41-56-4C-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-37-50-DF-F0-18-14-53-45-C7-4B-DD-4E-20-42-55-4C-47-55-52-20-50-DD-4C-41-56-4C-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-17-50-DF-F0-18-14-41-4E-4B-41-52-41-20-4D-41-4B-41-52-4E-41-20-DE-45-48-52-DD-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-01-22-50-DF-F0-18-14-53-45-C7-4B-DD-4E-20-4E-4F-48-55-54-20-4B-4F-C7-42-41-DE-49-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-32-50-DF-F0-18-14-42-DD-4C-4C-55-52-20-54-55-5A-20-DD-59-4F-54-4C-55-20-31-2E-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-82-50-DF-F0-18-14-53-45-C7-4B-DD-4E-20-4D-45-52-43-DD-4D-45-4B-20-59-45-DE-DD-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-03-01-75-00-DF-F0-18-14-53-4F-4C-4F-20-54-55-56-41-4C-45-54-20-4B-41-D0-49-44-49-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-02-35-00-DF-F0-18-14-4F-52-4B-DD-44-20-50-45-44-20-55-4C-54-52-41-20-45-58-54-52-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-03-02-02-50-DF-F0-18-14-46-DD-4E-DD-53-48-20-4D-41-4B-DD-4E-45-20-54-45-4D-DD-5A-4C-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-49-50-DF-F0-18-14-DC-4C-4B-45-52-20-C7-DD-4B-4F-4C-41-54-41-20-C7-4F-4B-4F-4E-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-02-99-00-DF-F0-18-14-45-4C-53-45-56-45-20-DE-41-4D-50-55-41-4E-20-4B-4F-35-20-35-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-03-03-29-00-DF-F0-18-14-46-41-DD-52-59-20-54-41-42-4C-45-54-20-50-4C-41-54-49-4E-55-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-99-50-DF-F0-18-14-4E-45-53-54-4C-45-20-47-45-56-52-45-4B-20-4E-45-53-46-DD-54-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-01-39-00-DF-F0-18-14-4E-45-53-54-4C-45-20-43-41-46-46-45-45-20-4D-41-54-45-20-50-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-02-99-00-DF-F0-18-14-46-DD-4E-DD-53-48-20-50-41-52-4C-41-54-49-43-49-20-34-30-30-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-29-50-DF-F0-18-14-DC-4C-4B-45-52-20-C7-DD-5A-DD-20-56-DD-C7-20-4B-52-41-4B-45-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-09-00-DF-F0-18-14-DC-4C-4B-45-52-20-C7-DD-4B-4F-4C-41-54-41-20-44-DD-44-4F-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-09-00-DF-F0-18-14-DC-4C-4B-45-52-20-C7-DD-4B-4F-4C-41-54-41-20-44-DD-44-4F-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-09-00-DF-F0-18-14-DC-4C-4B-45-52-20-C7-DD-4B-4F-4C-41-54-41-20-44-DD-44-4F-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-14-00-DF-F0-18-14-DC-4C-4B-45-52-20-4E-41-50-4F-4C-DD-54-45-4E-20-C7-DD-4B-4F-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-05-62-DF-F0-04-03-03-00-00-DF-F0-18-14-54-41-54-4C-49-20-42-41-4B-4C-41-56-41-20-20-20-20-20-20-20-DF-F0-1F-01-01-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-05-20-DF-F0-04-03-01-20-00-DF-F0-18-14-54-55-4C-55-4D-42-41-20-54-41-54-4C-49-53-49-20-4B-47-20-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-09-00-DF-F0-18-14-44-52-2E-4F-45-54-4B-45-52-20-C7-DD-4B-4F-4C-41-54-41-20-DD-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-32-50-DF-F0-18-14-45-54-DD-20-42-DD-53-4B-DC-56-DD-20-42-55-52-C7-41-4B-20-4B-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-02-40-DF-F0-04-03-01-02-50-DF-F0-18-14-41-44-41-4C-49-4C-41-52-20-4D-53-49-49-52-20-43-DD-50-53-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-02-54-DF-F0-04-02-95-00-DF-F0-18-14-41-44-41-4C-49-4C-41-52-20-4B-55-DE-20-4C-4F-4B-55-4D-55-20-DF-F0-1F-01-01-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-07-18-DF-F0-04-03-01-85-00-DF-F0-18-14-45-52-50-DD-4C-DD-C7-20-54-41-56-55-4B-20-4B-41-4E-41-54-20-DF-F0-1F-01-01-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-06-98-DF-F0-04-03-01-85-00-DF-F0-18-14-45-52-50-DD-4C-DD-C7-20-54-41-56-55-4B-20-4B-41-4E-41-54-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-35-00-DF-F0-18-14-45-54-DD-20-42-DD-53-4B-DC-56-DD-20-4E-45-47-52-4F-20-33-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-02-DF-F0-03-02-10-00-DF-F0-04-02-59-50-DF-F0-18-14-55-4E-4F-20-45-4B-4D-45-4B-20-42-DC-59-DC-4B-20-54-4F-53-54-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-03-01-45-00-DF-F0-18-14-48-45-41-44-26-53-48-4F-55-4C-44-45-52-53-20-DE-41-4D-50-55-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-47-50-DF-F0-18-14-DC-4C-4B-45-52-20-48-41-4C-4C-45-59-20-C7-DD-4B-4F-4C-41-54-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-32-50-DF-F0-18-14-45-54-DD-20-42-DD-53-4B-DC-56-DD-20-42-55-52-C7-41-4B-20-4B-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-25-00-DF-F0-18-14-45-54-DD-20-47-4F-46-52-45-54-20-48-4F-DE-42-45-DE-20-48-DD-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-09-00-DF-F0-18-14-DC-4C-4B-45-52-20-C7-DD-4B-4F-4C-41-54-41-20-44-DD-44-4F-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-37-50-DF-F0-18-14-45-54-DD-20-42-DD-53-4B-DC-56-DD-20-42-55-52-C7-41-4B-20-4B-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-39-50-DF-F0-18-14-45-54-DD-20-42-DD-53-4B-DC-56-DD-20-42-45-4E-DD-4D-4F-20-50-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-07-50-DF-F0-18-14-44-52-2E-4F-45-54-4B-45-52-20-4D-DD-4C-4B-53-48-41-4B-45-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-07-50-DF-F0-18-14-44-52-2E-4F-45-54-4B-45-52-20-4D-DD-4C-4B-53-48-41-4B-45-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-07-50-DF-F0-18-14-44-52-2E-4F-45-54-4B-45-52-20-4D-DD-4C-4B-53-48-41-4B-45-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-20-00-DF-F0-18-14-45-54-DD-20-C7-55-42-55-4B-20-43-52-41-58-20-44-41-48-41-20-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-03-82-DF-F0-04-03-01-39-00-DF-F0-18-14-4B-41-53-2D-4B-45-DE-20-4B-45-DE-20-50-45-59-4E-DD-52-DD-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-17-50-DF-F0-18-14-45-54-DD-20-47-4F-4E-47-20-42-41-4C-20-56-45-20-48-41-52-44-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-07-50-DF-F0-18-14-44-52-2E-4F-45-54-4B-45-52-20-4D-DD-4C-4B-53-48-41-4B-45-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-06-00-DF-F0-18-14-4E-45-53-43-41-46-45-20-32-53-DD-20-31-20-41-52-41-44-41-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-04-00-DF-F0-18-14-4E-45-53-43-41-46-45-20-43-4C-41-53-53-49-43-20-32-20-47-52-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-04-00-DF-F0-18-14-4E-45-53-43-41-46-45-20-47-4F-4C-44-20-32-20-47-52-20-20-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-04-00-DF-F0-18-14-4E-45-53-43-41-46-45-20-47-4F-4C-44-20-32-20-47-52-20-20-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-02-DF-F0-03-02-10-00-DF-F0-04-02-20-00-DF-F0-18-14-53-DD-4D-DD-54-20-45-4B-4D-45-4B-20-41-44-45-54-20-20-20-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-02-DF-F0-03-02-10-00-DF-F0-04-02-20-00-DF-F0-18-14-53-DD-4D-DD-54-20-45-4B-4D-45-4B-20-41-44-45-54-20-20-20-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-39-00-DF-F0-18-14-DC-4C-4B-45-52-20-50-52-4F-42-DD-53-20-50-52-4F-54-45-DD-4E-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-02-32-50-DF-F0-18-14-55-4E-DD-20-43-41-52-45-20-4B-55-4C-41-4B-20-C7-55-42-55-D0-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-69-00-DF-F0-18-14-59-D6-52-45-4C-20-4D-41-4B-41-52-4E-41-20-45-52-DD-DE-54-45-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-16-50-DF-F0-18-14-45-54-DD-4D-45-4B-20-4B-4C-41-53-DD-4B-20-48-41-5A-49-52-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-20-00-DF-F0-18-14-45-54-DD-20-4B-52-41-4B-45-52-20-42-41-4C-49-4B-20-4D-49-53-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-12-50-DF-F0-18-14-54-4F-52-4B-55-20-42-DD-53-4B-DC-56-DD-20-54-41-4D-20-C7-DD-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-09-00-DF-F0-18-14-44-52-2E-4F-45-54-4B-45-52-20-C7-DD-4B-4F-4C-41-54-41-20-DD-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-04-66-DF-F0-04-03-03-29-00-DF-F0-18-14-41-44-41-4C-49-4C-41-52-20-4B-4F-4B-54-45-59-4C-20-C7-45-52-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-40-00-DF-F0-18-14-DC-4C-4B-45-52-20-44-41-4D-4C-41-20-C7-DD-4B-4F-4C-41-54-41-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-02-DF-F0-03-02-10-00-DF-F0-04-02-40-00-DF-F0-18-14-45-4B-4D-45-4B-20-41-44-45-54-20-D6-5A-54-52-41-42-5A-4F-4E-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-35-00-DF-F0-18-14-DC-4C-4B-45-52-20-50-D6-54-DD-42-D6-52-20-4B-41-4B-41-4F-4C-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-59-00-DF-F0-18-14-50-41-50-41-D0-41-4E-20-41-59-20-C7-45-4B-DD-52-44-45-D0-DD-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-16-50-DF-F0-18-14-45-54-DD-4D-45-4B-20-4B-4C-41-53-DD-4B-20-48-41-5A-49-52-20-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-02-15-00-DF-F0-18-14-54-41-4D-45-4B-20-52-45-C7-45-4C-20-C7-DD-4C-45-4B-20-31-38-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-62-50-DF-F0-18-14-45-52-50-DD-4C-DD-C7-20-54-41-56-55-4B-20-44-D6-4E-45-52-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-09-00-DF-F0-18-14-44-52-2E-4F-45-54-4B-45-52-20-C7-DD-4B-4F-4C-41-54-41-20-DD-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-20-88-DF-F0-04-02-75-00-DF-F0-18-14-45-52-50-DD-4C-DD-C7-20-54-41-56-55-4B-20-42-DC-54-DC-4E-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-09-00-DF-F0-18-14-44-52-2E-4F-45-54-4B-45-52-20-C7-DD-4B-4F-4C-41-54-41-20-DD-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-04-00-DF-F0-18-14-4E-45-53-43-41-46-45-20-43-4C-41-53-53-49-43-20-32-20-47-52-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-08-04-DF-F0-04-03-01-42-50-DF-F0-18-14-45-52-50-DD-4C-DD-C7-20-54-41-56-55-4B-20-50-DD-52-5A-4F-4C-DF-F0-1F-01-01-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-01-49-00-DF-F0-18-14-DD-C7-DD-4D-20-50-45-59-4E-DD-52-20-42-45-59-41-5A-20-39-30-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-32-50-DF-F0-18-14-50-49-4E-41-52-20-41-C7-42-DD-54-DD-52-20-4D-41-43-41-52-20-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-08-36-DF-F0-04-03-01-42-50-DF-F0-18-14-45-52-50-DD-4C-DD-C7-20-54-41-56-55-4B-20-50-DD-52-5A-4F-4C-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-06-00-DF-F0-18-14-4E-45-53-43-41-46-45-20-32-53-DD-20-31-20-41-52-41-44-41-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-14-00-DF-F0-18-14-DC-4C-4B-45-52-20-C7-DD-4B-4F-4C-41-54-41-20-4E-41-50-4F-4C-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-89-50-DF-F0-18-14-DD-C7-DD-4D-20-59-4F-D0-55-52-54-20-32-32-35-30-20-47-20-20-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-15-86-DF-F0-04-03-02-15-00-DF-F0-18-14-5A-45-59-54-DD-4E-20-DD-52-DD-20-53-45-4C-45-20-4B-47-20-20-DF-F0-1F-01-01-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-01-54-50-DF-F0-18-14-50-49-4E-41-52-20-4C-41-42-4E-45-20-37-35-30-20-47-20-20-20-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-01-45-00-DF-F0-18-14-4B-49-4C-49-C7-4C-41-52-20-59-55-4D-55-52-54-41-20-33-30-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-16-00-DF-F0-18-14-50-49-4E-41-52-20-41-C7-42-DD-54-DD-52-20-48-DD-4E-44-DD-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-35-00-DF-F0-18-14-50-49-4E-41-52-20-4D-DD-4C-46-D6-59-20-35-30-30-20-47-52-20-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-05-26-DF-F0-04-03-01-69-00-DF-F0-18-14-5A-45-59-54-DD-4E-20-59-45-DE-DD-4C-20-4B-DC-C7-DC-4B-20-C7-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-02-DF-F0-03-02-10-50-DF-F0-04-02-75-00-DF-F0-18-14-DD-54-DD-4D-41-54-20-59-55-46-4B-41-20-4B-47-20-20-20-20-20-DF-F0-1F-01-01-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-05-48-DF-F0-04-03-05-15-00-DF-F0-18-14-44-41-4E-41-20-4B-41-53-41-50-20-53-55-43-55-4B-20-4B-47-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-59-00-DF-F0-18-14-45-52-50-DD-4C-DD-C7-20-53-41-4C-41-4D-20-50-DD-4C-DD-C7-20-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-01-49-00-DF-F0-18-14-41-2E-54-41-54-4C-49-43-49-20-54-41-48-DD-4E-2B-50-45-4B-4D-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-79-50-DF-F0-18-14-54-4F-52-4B-55-20-42-41-4E-41-44-41-20-4B-52-45-4D-20-C7-DD-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-01-39-00-DF-F0-18-14-54-4F-52-4B-55-20-42-41-4E-41-44-41-20-4B-52-45-4D-20-C7-DD-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-01-77-50-DF-F0-18-14-DE-41-48-DD-4E-20-53-55-43-55-4B-20-41-59-56-41-5A-20-54-41-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-58-DF-F0-04-03-04-25-00-DF-F0-18-14-44-41-4E-41-20-4B-49-59-4D-41-20-4B-47-20-20-20-20-20-20-20-DF-F0-1F-01-01-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-42-DF-F0-04-03-04-25-00-DF-F0-18-14-44-41-4E-41-20-4B-49-59-4D-41-20-4B-47-20-20-20-20-20-20-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-99-00-DF-F0-18-14-45-52-50-DD-4C-DD-C7-20-31-20-4B-47-20-4E-55-47-45-54-20-50-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-32-50-DF-F0-18-14-C7-45-52-45-5A-5A-41-20-C7-45-52-45-5A-4D-DD-58-20-31-30-37-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-02-99-00-DF-F0-18-14-41-4E-41-56-41-52-5A-41-20-42-41-4C-20-C7-DD-C7-45-4B-20-38-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-29-50-DF-F0-18-14-DD-C7-DD-4D-20-53-DC-54-20-59-41-52-49-4D-20-59-41-D0-4C-49-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-29-50-DF-F0-18-14-DD-C7-DD-4D-20-53-DC-54-20-59-41-52-49-4D-20-59-41-D0-4C-49-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-01-04-00-DF-F0-18-14-46-45-52-53-41-4E-20-4E-41-52-20-45-4B-DE-DD-4C-DD-20-53-4F-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-32-50-DF-F0-18-14-50-41-54-4F-53-20-41-43-49-20-42-41-48-41-52-41-54-4C-49-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-19-50-DF-F0-18-14-4B-4E-4F-52-52-20-C7-4F-52-42-41-20-4B-4C-41-53-DD-4B-20-DE-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-19-50-DF-F0-18-14-4B-4E-4F-52-52-20-C7-4F-52-42-41-20-4B-4C-41-53-DD-4B-20-DD-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-19-50-DF-F0-18-14-4B-4E-4F-52-52-20-C7-4F-52-42-41-20-4B-4C-41-53-DD-4B-20-4D-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-19-50-DF-F0-18-14-4B-4E-4F-52-52-20-C7-4F-52-42-41-20-4B-4C-41-53-DD-4B-20-45-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-52-50-DF-F0-18-14-50-49-4E-41-52-20-4D-41-4E-54-49-20-4B-41-59-53-45-52-DD-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-27-50-DF-F0-18-14-4B-41-56-41-4B-4C-49-44-45-52-45-20-4C-DD-4D-4F-4E-20-53-4F-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-64-00-DF-F0-18-14-DD-C7-DD-4D-20-53-DC-54-20-C7-DD-4B-4F-4C-41-54-41-4C-49-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-35-00-DF-F0-18-14-50-49-4E-41-52-20-4D-DD-4C-46-D6-59-20-35-30-30-20-47-52-20-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-01-79-50-DF-F0-18-14-45-4B-DD-43-DD-20-50-45-59-4E-DD-52-20-53-DC-5A-4D-45-20-38-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-01-25-00-DF-F0-18-14-DC-4C-4B-45-52-20-4B-45-54-C7-41-50-20-37-35-30-47-2B-4D-41-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-01-25-00-DF-F0-18-14-DC-4C-4B-45-52-20-42-DD-5A-DD-4D-20-4D-41-52-47-41-52-DD-4E-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-92-50-DF-F0-18-14-DE-41-4E-56-45-52-20-48-45-4C-56-41-20-C7-DD-4C-45-4B-2D-4B-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-01-02-50-DF-F0-18-14-4B-4F-53-4B-41-20-48-45-4C-56-41-20-4B-41-4B-41-4F-4C-55-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-55-00-DF-F0-18-14-42-45-52-52-41-4B-20-54-55-52-DE-55-20-53-41-4C-41-54-41-4C-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-79-50-DF-F0-18-14-41-2E-54-41-54-4C-49-43-49-20-48-45-4C-56-41-20-4B-41-4B-41-DF-F0-1F-01-00";
            string rawData = "DF-F0-01-01-03-DF-F0-03-02-10-60-DF-F0-04-02-48-50-DF-F0-18-14-49-53-50-41-4E-41-4B-20-4B-47-20-20-20-20-20-20-20-20-20-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-08-06-DF-F0-04-02-33-50-DF-F0-18-14-48-41-56-55-C7-20-4B-47-20-20-20-20-20-20-20-20-20-20-20-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-30-DF-F0-04-02-39-50-DF-F0-18-14-50-41-54-4C-49-43-41-4E-20-4B-45-4D-45-52-20-4B-47-20-20-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-54-DF-F0-04-02-39-50-DF-F0-18-14-42-DD-42-45-52-20-31-2E-4B-41-4C-DD-54-45-20-4B-47-20-20-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-11-06-DF-F0-04-02-84-50-DF-F0-18-14-C7-DD-4C-45-4B-20-4F-52-47-41-4E-DD-4B-20-4B-47-20-20-20-20-DF-F0-1F-01-01-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-13-86-DF-F0-04-03-01-09-00-DF-F0-18-14-4D-55-5A-20-DD-54-48-41-4C-20-4B-47-20-20-20-20-20-20-20-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-28-94-DF-F0-04-02-49-50-DF-F0-18-14-44-4F-4D-41-54-45-53-20-4B-47-20-20-20-20-20-20-20-20-20-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-25-00-DF-F0-18-14-46-41-4C-49-4D-20-53-41-4B-49-5A-20-35-58-35-20-4C-DD-20-4F-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-25-00-DF-F0-18-14-46-41-4C-49-4D-20-53-41-4B-49-5A-20-35-58-35-20-4C-DD-20-4B-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-03-01-42-50-DF-F0-18-14-59-55-4D-4F-DE-20-59-55-4D-55-DE-41-54-49-43-49-20-4C-41-56-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-04-08-DF-F0-04-02-68-50-DF-F0-18-14-4C-DD-4D-4F-4E-20-4B-47-20-20-20-20-20-20-20-20-20-20-20-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-24-24-DF-F0-04-02-59-50-DF-F0-18-14-45-4C-4D-41-20-59-2E-41-52-4A-41-4E-54-DD-4E-20-4B-47-20-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-25-22-DF-F0-04-02-19-50-DF-F0-18-14-50-41-54-41-54-45-53-20-4B-47-20-20-20-20-20-20-20-20-20-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-18-84-DF-F0-04-02-59-50-DF-F0-18-14-41-52-4D-55-54-20-53-41-4E-54-41-20-4B-47-20-20-20-20-20-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-02-17-50-DF-F0-18-14-43-4F-4F-4B-20-42-55-5A-44-4F-4C-41-42-49-20-50-4F-DE-45-54-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-03-09-00-DF-F0-18-14-59-55-44-55-4D-20-41-59-C7-DD-C7-45-4B-20-59-41-D0-49-20-35-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-02-52-50-DF-F0-18-14-53-43-4F-54-43-48-20-42-52-DD-54-45-20-4B-4C-41-53-DD-4B-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-21-62-DF-F0-04-02-19-50-DF-F0-18-14-53-4F-D0-41-4E-20-4B-47-20-20-20-20-20-20-20-20-20-20-20-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-02-42-50-DF-F0-18-14-44-4F-4D-45-53-54-4F-53-20-C7-41-4D-41-DE-49-52-20-53-55-59-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-02-85-00-DF-F0-18-14-44-41-4C-DD-4E-20-49-53-4C-41-4B-20-4D-45-4E-44-DD-4C-20-33-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-72-50-DF-F0-18-14-56-DD-4C-45-44-41-20-53-DC-4E-47-45-52-20-42-45-5A-20-33-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-02-72-50-DF-F0-18-14-46-41-DD-52-59-20-42-55-4C-41-DE-49-4B-20-44-45-54-45-52-4A-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-03-01-35-00-DF-F0-18-14-44-55-52-55-20-53-49-56-49-20-53-41-42-55-4E-20-47-4F-55-52-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-02-62-50-DF-F0-18-14-43-DD-46-20-4B-52-45-4D-20-55-4C-54-52-41-20-47-DC-C7-20-32-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-03-01-79-00-DF-F0-18-14-52-DD-4E-53-4F-20-4D-41-54-DD-4B-20-42-45-59-41-5A-20-47-DC-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-03-02-40-00-DF-F0-04-02-05-00-DF-F0-18-14-DC-4C-4B-45-52-20-43-41-46-45-20-43-52-4F-57-4E-20-4C-41-54-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-13-50-DF-F0-18-14-DC-4C-4B-45-52-20-4D-41-4B-41-52-4E-45-4B-53-20-44-4F-4D-41-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-02-DF-F0-03-02-10-00-DF-F0-04-03-01-39-50-DF-F0-18-14-48-45-4B-DD-4D-4F-D0-4C-55-20-55-4E-20-35-20-4B-47-20-20-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-13-50-DF-F0-18-14-DC-4C-4B-45-52-20-4D-41-4B-41-52-4E-45-4B-53-20-41-43-49-20-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-02-62-50-DF-F0-18-14-C7-41-59-4B-55-52-20-C7-41-59-20-52-DD-5A-45-20-54-55-52-DD-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-15-00-DF-F0-18-14-46-DD-4C-DD-5A-20-4D-41-4B-41-52-4E-41-20-42-55-52-47-55-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-15-00-DF-F0-18-14-46-DD-4C-DD-5A-20-4D-41-4B-41-52-4E-41-20-4B-41-4C-45-4D-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-17-50-DF-F0-18-14-41-4E-4B-41-52-41-20-4D-41-4B-41-52-4E-41-20-46-DD-59-4F-4E-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-01-89-50-DF-F0-18-14-53-45-C7-4B-DD-4E-20-50-DD-52-DD-4E-C7-20-42-41-4C-44-4F-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-40-00-DF-F0-18-14-47-DC-4E-45-DE-20-4E-DD-DE-41-53-54-41-20-38-30-30-20-47-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-17-50-DF-F0-18-14-41-4E-4B-41-52-41-20-4D-41-4B-41-52-4E-41-20-4D-DD-44-59-45-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-92-50-DF-F0-18-14-44-4F-D0-55-DE-20-C7-41-59-20-42-4C-41-43-4B-20-4C-41-42-45-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-16-50-DF-F0-18-14-4E-2E-41-4E-4B-41-52-41-20-DD-52-4D-DD-4B-20-35-30-30-20-47-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-01-05-00-DF-F0-18-14-53-45-C7-4B-DD-4E-20-4D-45-52-43-DD-4D-45-4B-20-4B-49-52-4D-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-15-00-DF-F0-18-14-46-DD-4C-DD-5A-20-4D-41-4B-41-52-4E-41-20-42-4F-4E-43-55-4B-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-32-50-DF-F0-18-14-42-DD-4C-4C-55-52-20-54-55-5A-20-DD-59-4F-54-4C-55-20-31-2E-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-17-50-DF-F0-18-14-41-4E-4B-41-52-41-20-4D-41-4B-41-52-4E-41-20-45-52-DD-DE-54-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-01-49-50-DF-F0-18-14-53-45-C7-4B-DD-4E-20-50-DD-52-DD-4E-C7-20-4F-53-4D-41-4E-43-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-17-50-DF-F0-18-14-41-4E-4B-41-52-41-20-4D-41-4B-41-52-4E-41-20-DE-45-48-52-DD-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-17-50-DF-F0-18-14-41-4E-4B-41-52-41-20-4D-41-4B-41-52-4E-41-20-4E-55-48-27-55-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-02-19-00-DF-F0-18-14-54-4F-52-4B-55-20-54-4F-5A-DE-45-4B-45-52-20-35-30-30-30-20-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-02-19-00-DF-F0-18-14-54-4F-52-4B-55-20-54-4F-5A-DE-45-4B-45-52-20-35-30-30-30-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-17-50-DF-F0-18-14-41-4E-4B-41-52-41-20-4D-41-4B-41-52-4E-41-20-53-50-41-47-45-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-15-00-DF-F0-18-14-46-DD-4C-DD-5A-20-4D-41-4B-41-52-4E-41-20-53-50-41-47-45-54-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-74-00-DF-F0-18-14-53-45-C7-4B-DD-4E-20-42-55-4C-47-55-52-20-50-DD-4C-41-56-4C-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-37-50-DF-F0-18-14-53-45-C7-4B-DD-4E-20-42-55-4C-47-55-52-20-50-DD-4C-41-56-4C-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-17-50-DF-F0-18-14-41-4E-4B-41-52-41-20-4D-41-4B-41-52-4E-41-20-DE-45-48-52-DD-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-01-22-50-DF-F0-18-14-53-45-C7-4B-DD-4E-20-4E-4F-48-55-54-20-4B-4F-C7-42-41-DE-49-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-32-50-DF-F0-18-14-42-DD-4C-4C-55-52-20-54-55-5A-20-DD-59-4F-54-4C-55-20-31-2E-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-82-50-DF-F0-18-14-53-45-C7-4B-DD-4E-20-4D-45-52-43-DD-4D-45-4B-20-59-45-DE-DD-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-03-01-75-00-DF-F0-18-14-53-4F-4C-4F-20-54-55-56-41-4C-45-54-20-4B-41-D0-49-44-49-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-02-35-00-DF-F0-18-14-4F-52-4B-DD-44-20-50-45-44-20-55-4C-54-52-41-20-45-58-54-52-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-03-02-02-50-DF-F0-18-14-46-DD-4E-DD-53-48-20-4D-41-4B-DD-4E-45-20-54-45-4D-DD-5A-4C-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-49-50-DF-F0-18-14-DC-4C-4B-45-52-20-C7-DD-4B-4F-4C-41-54-41-20-C7-4F-4B-4F-4E-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-02-99-00-DF-F0-18-14-45-4C-53-45-56-45-20-DE-41-4D-50-55-41-4E-20-4B-4F-35-20-35-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-03-03-29-00-DF-F0-18-14-46-41-DD-52-59-20-54-41-42-4C-45-54-20-50-4C-41-54-49-4E-55-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-99-50-DF-F0-18-14-4E-45-53-54-4C-45-20-47-45-56-52-45-4B-20-4E-45-53-46-DD-54-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-01-39-00-DF-F0-18-14-4E-45-53-54-4C-45-20-43-41-46-46-45-45-20-4D-41-54-45-20-50-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-02-99-00-DF-F0-18-14-46-DD-4E-DD-53-48-20-50-41-52-4C-41-54-49-43-49-20-34-30-30-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-29-50-DF-F0-18-14-DC-4C-4B-45-52-20-C7-DD-5A-DD-20-56-DD-C7-20-4B-52-41-4B-45-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-09-00-DF-F0-18-14-DC-4C-4B-45-52-20-C7-DD-4B-4F-4C-41-54-41-20-44-DD-44-4F-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-09-00-DF-F0-18-14-DC-4C-4B-45-52-20-C7-DD-4B-4F-4C-41-54-41-20-44-DD-44-4F-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-09-00-DF-F0-18-14-DC-4C-4B-45-52-20-C7-DD-4B-4F-4C-41-54-41-20-44-DD-44-4F-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-14-00-DF-F0-18-14-DC-4C-4B-45-52-20-4E-41-50-4F-4C-DD-54-45-4E-20-C7-DD-4B-4F-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-05-62-DF-F0-04-03-03-00-00-DF-F0-18-14-54-41-54-4C-49-20-42-41-4B-4C-41-56-41-20-20-20-20-20-20-20-DF-F0-1F-01-01-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-05-20-DF-F0-04-03-01-20-00-DF-F0-18-14-54-55-4C-55-4D-42-41-20-54-41-54-4C-49-53-49-20-4B-47-20-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-09-00-DF-F0-18-14-44-52-2E-4F-45-54-4B-45-52-20-C7-DD-4B-4F-4C-41-54-41-20-DD-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-32-50-DF-F0-18-14-45-54-DD-20-42-DD-53-4B-DC-56-DD-20-42-55-52-C7-41-4B-20-4B-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-02-40-DF-F0-04-03-01-02-50-DF-F0-18-14-41-44-41-4C-49-4C-41-52-20-4D-53-49-49-52-20-43-DD-50-53-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-02-54-DF-F0-04-02-95-00-DF-F0-18-14-41-44-41-4C-49-4C-41-52-20-4B-55-DE-20-4C-4F-4B-55-4D-55-20-DF-F0-1F-01-01-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-07-18-DF-F0-04-03-01-85-00-DF-F0-18-14-45-52-50-DD-4C-DD-C7-20-54-41-56-55-4B-20-4B-41-4E-41-54-20-DF-F0-1F-01-01-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-06-98-DF-F0-04-03-01-85-00-DF-F0-18-14-45-52-50-DD-4C-DD-C7-20-54-41-56-55-4B-20-4B-41-4E-41-54-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-35-00-DF-F0-18-14-45-54-DD-20-42-DD-53-4B-DC-56-DD-20-4E-45-47-52-4F-20-33-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-02-DF-F0-03-02-10-00-DF-F0-04-02-59-50-DF-F0-18-14-55-4E-4F-20-45-4B-4D-45-4B-20-42-DC-59-DC-4B-20-54-4F-53-54-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-03-01-45-00-DF-F0-18-14-48-45-41-44-26-53-48-4F-55-4C-44-45-52-53-20-DE-41-4D-50-55-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-47-50-DF-F0-18-14-DC-4C-4B-45-52-20-48-41-4C-4C-45-59-20-C7-DD-4B-4F-4C-41-54-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-32-50-DF-F0-18-14-45-54-DD-20-42-DD-53-4B-DC-56-DD-20-42-55-52-C7-41-4B-20-4B-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-25-00-DF-F0-18-14-45-54-DD-20-47-4F-46-52-45-54-20-48-4F-DE-42-45-DE-20-48-DD-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-09-00-DF-F0-18-14-DC-4C-4B-45-52-20-C7-DD-4B-4F-4C-41-54-41-20-44-DD-44-4F-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-37-50-DF-F0-18-14-45-54-DD-20-42-DD-53-4B-DC-56-DD-20-42-55-52-C7-41-4B-20-4B-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-39-50-DF-F0-18-14-45-54-DD-20-42-DD-53-4B-DC-56-DD-20-42-45-4E-DD-4D-4F-20-50-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-07-50-DF-F0-18-14-44-52-2E-4F-45-54-4B-45-52-20-4D-DD-4C-4B-53-48-41-4B-45-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-07-50-DF-F0-18-14-44-52-2E-4F-45-54-4B-45-52-20-4D-DD-4C-4B-53-48-41-4B-45-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-07-50-DF-F0-18-14-44-52-2E-4F-45-54-4B-45-52-20-4D-DD-4C-4B-53-48-41-4B-45-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-20-00-DF-F0-18-14-45-54-DD-20-C7-55-42-55-4B-20-43-52-41-58-20-44-41-48-41-20-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-03-82-DF-F0-04-03-01-39-00-DF-F0-18-14-4B-41-53-2D-4B-45-DE-20-4B-45-DE-20-50-45-59-4E-DD-52-DD-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-17-50-DF-F0-18-14-45-54-DD-20-47-4F-4E-47-20-42-41-4C-20-56-45-20-48-41-52-44-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-07-50-DF-F0-18-14-44-52-2E-4F-45-54-4B-45-52-20-4D-DD-4C-4B-53-48-41-4B-45-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-06-00-DF-F0-18-14-4E-45-53-43-41-46-45-20-32-53-DD-20-31-20-41-52-41-44-41-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-04-00-DF-F0-18-14-4E-45-53-43-41-46-45-20-43-4C-41-53-53-49-43-20-32-20-47-52-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-04-00-DF-F0-18-14-4E-45-53-43-41-46-45-20-47-4F-4C-44-20-32-20-47-52-20-20-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-04-00-DF-F0-18-14-4E-45-53-43-41-46-45-20-47-4F-4C-44-20-32-20-47-52-20-20-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-02-DF-F0-03-02-10-00-DF-F0-04-02-20-00-DF-F0-18-14-53-DD-4D-DD-54-20-45-4B-4D-45-4B-20-41-44-45-54-20-20-20-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-02-DF-F0-03-02-10-00-DF-F0-04-02-20-00-DF-F0-18-14-53-DD-4D-DD-54-20-45-4B-4D-45-4B-20-41-44-45-54-20-20-20-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-39-00-DF-F0-18-14-DC-4C-4B-45-52-20-50-52-4F-42-DD-53-20-50-52-4F-54-45-DD-4E-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-04-DF-F0-03-02-10-00-DF-F0-04-02-32-50-DF-F0-18-14-55-4E-DD-20-43-41-52-45-20-4B-55-4C-41-4B-20-C7-55-42-55-D0-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-69-00-DF-F0-18-14-59-D6-52-45-4C-20-4D-41-4B-41-52-4E-41-20-45-52-DD-DE-54-45-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-16-50-DF-F0-18-14-45-54-DD-4D-45-4B-20-4B-4C-41-53-DD-4B-20-48-41-5A-49-52-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-20-00-DF-F0-18-14-45-54-DD-20-4B-52-41-4B-45-52-20-42-41-4C-49-4B-20-4D-49-53-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-12-50-DF-F0-18-14-54-4F-52-4B-55-20-42-DD-53-4B-DC-56-DD-20-54-41-4D-20-C7-DD-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-09-00-DF-F0-18-14-44-52-2E-4F-45-54-4B-45-52-20-C7-DD-4B-4F-4C-41-54-41-20-DD-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-04-66-DF-F0-04-03-03-29-00-DF-F0-18-14-41-44-41-4C-49-4C-41-52-20-4B-4F-4B-54-45-59-4C-20-C7-45-52-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-40-00-DF-F0-18-14-DC-4C-4B-45-52-20-44-41-4D-4C-41-20-C7-DD-4B-4F-4C-41-54-41-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-02-DF-F0-03-02-10-00-DF-F0-04-02-40-00-DF-F0-18-14-45-4B-4D-45-4B-20-41-44-45-54-20-D6-5A-54-52-41-42-5A-4F-4E-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-35-00-DF-F0-18-14-DC-4C-4B-45-52-20-50-D6-54-DD-42-D6-52-20-4B-41-4B-41-4F-4C-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-59-00-DF-F0-18-14-50-41-50-41-D0-41-4E-20-41-59-20-C7-45-4B-DD-52-44-45-D0-DD-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-16-50-DF-F0-18-14-45-54-DD-4D-45-4B-20-4B-4C-41-53-DD-4B-20-48-41-5A-49-52-20-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-02-15-00-DF-F0-18-14-54-41-4D-45-4B-20-52-45-C7-45-4C-20-C7-DD-4C-45-4B-20-31-38-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-62-50-DF-F0-18-14-45-52-50-DD-4C-DD-C7-20-54-41-56-55-4B-20-44-D6-4E-45-52-20-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-09-00-DF-F0-18-14-44-52-2E-4F-45-54-4B-45-52-20-C7-DD-4B-4F-4C-41-54-41-20-DD-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-20-88-DF-F0-04-02-75-00-DF-F0-18-14-45-52-50-DD-4C-DD-C7-20-54-41-56-55-4B-20-42-DC-54-DC-4E-20-DF-F0-1F-01-01-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-09-00-DF-F0-18-14-44-52-2E-4F-45-54-4B-45-52-20-C7-DD-4B-4F-4C-41-54-41-20-DD-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-04-00-DF-F0-18-14-4E-45-53-43-41-46-45-20-43-4C-41-53-53-49-43-20-32-20-47-52-DF-F0-1F-01-00-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-08-04-DF-F0-04-03-01-42-50-DF-F0-18-14-45-52-50-DD-4C-DD-C7-20-54-41-56-55-4B-20-50-DD-52-5A-4F-4C-DF-F0-1F-01-01-DF-71-2F-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-03-01-49-00-DF-F0-18-14-DD-C7-DD-4D-20-50-45-59-4E-DD-52-20-42-45-59-41-5A-20-39-30-DF-F0-1F-01-00-DF-71-2E-DF-F0-01-01-03-DF-F0-03-02-10-00-DF-F0-04-02-32-50-DF-F0-18-14-50-49-4E-41-52-20-41-C7-42-DD-54-DD-52-20-4D-41-43-41-52-20-DF-F0-1F-01-00";

            try
            {
                string rmData = rawData.Replace("-", "").Trim();

                byte[] testData = StringToByteArray(rmData);
            
                CPResponse response = new CPResponse(bridge.Printer.PrintDocumentHeader(1, "12345678901", "AA123456", DateTime.Now));

                response = new CPResponse(bridge.Printer.SendTestData(testData));

            }
            catch(Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        private void buttonLoadInvoiceFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                string file = ofd.FileName;

                try
                {
                    string[] lines = File.ReadAllLines(file);

                    int docType = 3;
                    switch (comboBoxEDocumentDocTypes.SelectedIndex)
                    {
                        case 0:
                            docType = 1;
                            break;
                        case 1:
                            docType = 3;
                            break;
                        case 2:
                            docType = 2;
                            break;
                        case 3:
                            docType = 9;
                            break;
                        case 4:
                            docType = 10;
                            break;
                        case 5:
                            docType = 1;
                            break;
                    }

                    CPResponse response = new CPResponse(bridge.Printer.PrintEDocumentCopy(docType, lines));
                }
                catch(Exception ex)
                {
                    bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
                }
            }
        }

        private static Hugin.Common.Customer customer = null;

        private void buttonStoppage_Click(object sender, EventArgs e)
        {
            try
            {
                decimal amount = numericUpDownStoppageAmount.Value;

                CPResponse response = new CPResponse(bridge.Printer.PrintSubtotal(amount));

                if (response.ErrorCode == 0)
                {
                    bridge.Log(String.Format(FormMessage.SUBTOTAL.PadRight(12, ' ') + ":{0}", response.GetNextParam()));

                    bridge.Log(String.Format(FormMessage.PAID_TOTAL.PadRight(12, ' ') + ":{0}", response.GetNextParam()));
                }
            }
            catch (Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
        }

        private void buttonAddCustomerRetDoc_Click(object sender, EventArgs e)
        {
            customer = null;
            CustomerForm cf = new CustomerForm();
            try
            {
                if (cf.ShowDialog() == DialogResult.OK)
                {
                    customer = CustomerForm.CurrentCustomer;
                    this.buttonAddCustomerRetDoc.Text = FormMessage.UPDATE_CUSTOMER;
                }
            }
            catch (Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
                this.buttonAddCustomerRetDoc.Text = FormMessage.ADD_CUSTOMER;
            }
        }

        private void buttonStartReturnDoc_Click(object sender, EventArgs e)
        {
            try
            {
                string docSerial = textBoxRetDocSerial.Text;
                string docOrderNo = textBoxRetDocORderNo.Text;
                DateTime invoiceDT = dateTimePickerRetDoc.Value;

                CPResponse response = new CPResponse(bridge.Printer.PrintReturnDocumentHeader(invoiceDT, docSerial, docOrderNo, customer));

                if (response.ErrorCode == 0)
                {
                    string docNo = response.GetNextParam();
                    string ZNo = response.GetNextParam();

                    bridge.Log(String.Format("BELGE NO       :{0}", docNo));
                    bridge.Log(String.Format("Z NO           :{0}", ZNo));
                }


            }
            catch (Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
            finally
            {
                customer = null;
                this.buttonAddCustomerRetDoc.Text = FormMessage.ADD_CUSTOMER;
            }
        }

        private void btnSendSlip_Click(object sender, EventArgs e)
        {
            try
            {
                List<byte> bytes = new List<byte>();
                CPResponse response;
                int slipType = 1;

                if (rbtnSlipTypeMerchant.Checked)
                    slipType = 2;
                else if (rbtnSlipTypeError.Checked)
                    slipType = 3;

                response = new CPResponse(bridge.Printer.PrintSlip(slipType, txtSlipLines.Lines));
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
        }
    }
}
