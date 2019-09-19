using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Hugin.POS.CompactPrinter.FP300;



namespace FP300Service.UserControls
{
    public class ProgramUC : TestUC
    {
        private static TestUC programForm = null;
        private static IBridge bridge = null;

        #region initialize
        private TabControl tbcProgram;
        private TabPage tbpDepTax;
        private TabPage tbpCredit;
        private DataGridView dgvCredits;
        private Button btnSaveCredits;
        private Button btnGetCredits;
        private DataGridViewTextBoxColumn clmnIndex;
        private DataGridViewTextBoxColumn clmnCreditName;
        private DataGridViewCheckBoxColumn clmnSelected;
        private Button btnGetDepartment;
        private Button btnSaveDepartment;
        private DataGridView dgvDepDefine;
        private Label lblDepartment;
        private TabPage tbpPLU;
        private Label lblPLUDefine;
        private Button btnSavePLU;
        private Button btnGetPLU;
        private DataGridView dgvPLUDefine;
        private Label lblPLUStart;
        private TextBox txtPluAddress;
        private Label lblInfoPLU;
        private TabPage tbpCategory;
        private Label lblMainGrup;
        private Button btnSaveMainCategory;
        private Button btnGetMainCategory;
        private DataGridView dgvMainCategory;
        private TabPage tbpCashier;
        private Label lblCashier;
        private Button btnSaveCashier;
        private Button btnGetCashier;
        private DataGridView dgvCashier;
        private DataGridViewTextBoxColumn clmnCashierIndex;
        private DataGridViewTextBoxColumn clmnCashierName;
        private DataGridViewTextBoxColumn clmnCashierPassword;
        private DataGridViewCheckBoxColumn clmnCashierSelect;
        private DataGridViewTextBoxColumn clmnMainGrupNo;
        private DataGridViewTextBoxColumn clmnMainGrupName;
        private DataGridViewCheckBoxColumn clmnMainGrupSelect;
        private TabPage tbpProgramOption;
        private Label lblProgramOption;
        private Button btnSavePrmOption;
        private Button btnGetPrmOption;
        private DataGridView dgvPrmOption;
        private Label lblDefineCredit;
        private DataGridViewTextBoxColumn clmnPONo;
        private DataGridViewTextBoxColumn clmnPOName;
        private DataGridViewTextBoxColumn clmnPOValue;
        private Label label1;
        private Button btnSaveFcurrency;
        private Button btnGetFCurrency;
        private DataGridView dgvFCurrency;
        private DataGridViewTextBoxColumn clmnFCurrId;
        private DataGridViewTextBoxColumn clmnFCurrName;
        private DataGridViewTextBoxColumn clmnFCurrRate;
        private DataGridViewCheckBoxColumn clmnFCurrSelected;
        private TabPage tbpBitmapLogo;
        private PictureBox pbxLogo;
        private Button btnSendBitmap;
        private Button btnBrowseBmp;
        private Label lblLogoHeight;
        private Label lblLogoWidth;
        private Label lblPreviewLogo;
        private TabPage tbpNetwork;
        private TextBox txtGateway;
        private TextBox txtSubnet;
        private TextBox txtIp;
        private Label lblGateway;
        private Label lblSubnet;
        private Label lblTsmIp;
        private Button btnSaveNetwork;
        private Label label2;
        private CheckBox chkGateway;
        private CheckBox chkSubnet;
        private CheckBox chkIp;
        private DataGridViewCheckBoxColumn clmnPOSelect;

        private TabPage tabSRVLogo;
        private Button btnSaveLogo;
        private Button btnGetLogo;

        private TabPage tabSRVVAT;
        private Label lblVAT;
        private Button btnSaveVat;
        private Button btnGetVat;
        private DataGridView dgvVATDefine;
        private DataGridViewTextBoxColumn clmnVatGroupNum;
        private DataGridViewTextBoxColumn clmnVatRate;
        private TableLayoutPanel tableLayoutPanelTabDepartment;
        private TableLayoutPanel tableLayoutPanelDptButtons;
        private TableLayoutPanel tableLayoutPanelTabPLU;
        private TableLayoutPanel tableLayoutPanelPLUButtons;
        private DataGridViewTextBoxColumn clmnPLUNo;
        private DataGridViewTextBoxColumn clmnPLUName;
        private DataGridViewTextBoxColumn clmnPLUDeptNo;
        private DataGridViewTextBoxColumn clmnPLUPrice;
        private DataGridViewTextBoxColumn clmnPLUBarcode;
        private DataGridViewTextBoxColumn clmnPLUSubCat;
        private DataGridViewCheckBoxColumn clmnPLUWeighable;
        private DataGridViewCheckBoxColumn clmnPLUSelected;
        private TableLayoutPanel tableLayoutPanelTabCredit;
        private TableLayoutPanel tableLayoutPanelCreditButtons;
        private TableLayoutPanel tableLayoutPanelFCurrencyButtons;
        private TableLayoutPanel tableLayoutPanelTabCategory;
        private TableLayoutPanel tableLayoutPanelMainGrBttns;
        private TableLayoutPanel tableLayoutPanelTabCashier;
        private TableLayoutPanel tableLayoutPanelCashierBttns;
        private TableLayoutPanel tableLayoutPanelProgOpt;
        private TableLayoutPanel tableLayoutPanelProgOptBttns;
        private TableLayoutPanel tableLayoutPanelVAT;
        private TableLayoutPanel tableLayoutPanelVATBttns;
        private DataGridViewTextBoxColumn clmnDeptNo;
        private DataGridViewTextBoxColumn clmnDeptName;
        private DataGridViewTextBoxColumn clmnDeptVatId;
        private DataGridViewTextBoxColumn clmnDeptPrice;
        private DataGridViewTextBoxColumn clmnDeptLimit;
        private DataGridViewCheckBoxColumn clmnDeptWeighable;
        private DataGridViewCheckBoxColumn clmnSelectDepartment;
        private TabPage tabPageSendProduct;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lblProductFile;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox textBoxProductFilePath;
        private Button btnBrowseProductFile;
        private TableLayoutPanel tableLayoutPanel4;
        private Label labelTotalLineValue;
        private Label labelTotalLine;
        private TableLayoutPanel tableLayoutPanel5;
        private Button btnSendProducts;
        private TableLayoutPanel tableLayoutPanel6;
        private ProgressBar progressBarSendProd;
        private Label labelUnderProgressBar;
        private Label labelElapsedTime;
        private TabPage tabPageEndOfReceiptNote;
        private TableLayoutPanel tableLayoutPanel7;
        private TableLayoutPanel tableLayoutPanel8;
        private TextBox textBoxEORLine6;
        private TextBox textBoxEORLine5;
        private TextBox textBoxEORLine4;
        private TextBox textBoxEORLine3;
        private TextBox textBoxEORLine2;
        private Label labelEORLine1;
        private Label labelEORLine2;
        private Label labelEORLine3;
        private Label labelEORLine4;
        private Label labelEORLine5;
        private Label labelEORLine6;
        private CheckBox checkBoxEORLine1;
        private CheckBox checkBoxEORLine2;
        private CheckBox checkBoxEORLine3;
        private CheckBox checkBoxEORLine4;
        private CheckBox checkBoxEORLine5;
        private CheckBox checkBoxEORLine6;
        private TextBox textBoxEORLine1;
        private TableLayoutPanel tableLayoutPanel9;
        private TableLayoutPanel tableLayoutPanel10;
        private Button buttonEORGet;
        private Button buttonEORSet;
        private CheckBox checkBoxForGibLogo;
        private DataGridViewCheckBoxColumn clmnSelectedVat; 

        public ProgramUC()
            : base()
        {
            InitializeComponent();
            checkBoxForGibLogo.Checked = false;

            SetLanguageOption();

            if (bridge.Printer != null)
            {
                bridge.Printer.OnFileSendingProgress += new OnFileSendingProgressHandler(Printer_OnFileSendingProgress);
            }

            // Credit Table
            for (int i = 0; i < ProgramConfig.MAX_CREDIT_COUNT; i++)
            {
                if (dgvCredits.Rows.Count <= i)
                {
                    dgvCredits.Rows.Add();
                }
            }

            // Department Table
            for (int i = 0; i < ProgramConfig.MAX_DEPARTMENT_COUNT; i++)
            {
                if (dgvDepDefine.Rows.Count <= i)
                {
                    dgvDepDefine.Rows.Add();
                }
                dgvDepDefine.Rows[i].Cells[clmnDeptNo.Index].Value = i + 1;
            }

            // LOGO PAGE
            for (int i = 0; i < ProgramConfig.LENGTH_OF_LOGO_LINES; i++)
            {
                // label
                Label lblLogo = new Label();
                lblLogo.Parent = tabSRVLogo;
                lblLogo.AutoSize = false;
                lblLogo.Size = new System.Drawing.Size(100, 25);
                lblLogo.Location = new Point(50, (i * lblLogo.Size.Height) + 35);
                lblLogo.Name = "lblLogo" + i;
                lblLogo.Text = String.Format("{1} {0} :", (i + 1), FormMessage.LOGO_LINE);


                // text box
                TextBox txtLogo = new TextBox();
                txtLogo.Parent = tabSRVLogo;
                txtLogo.AutoSize = false;
                txtLogo.Size = new System.Drawing.Size(350, 20);
                txtLogo.Location = new Point(lblLogo.Location.X + lblLogo.Size.Width, lblLogo.Location.Y);
                txtLogo.MaxLength = ProgramConfig.LOGO_LINE_LENGTH;
                txtLogo.Name = "txtLogo" + i;
                txtLogo.Tag = i;
                txtLogo.TextChanged += new EventHandler(txtLogo_TextChanged);
                txtLogo.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));

                // check box
                CheckBox chkLogo = new CheckBox();
                chkLogo.Parent = tabSRVLogo;
                chkLogo.Location = new Point(txtLogo.Location.X + txtLogo.Size.Width + 3, txtLogo.Location.Y);
                chkLogo.Name = "chkLogo" + i;
                chkLogo.Text = FormMessage.SAVE_AS;
                chkLogo.Checked = true;
                chkLogo.CheckedChanged += new EventHandler(chkLogo_CheckedChanged);
            }

            // VAT Table
            for (int i = 0; i < ProgramConfig.MAX_VAT_RATE_COUNT; i++)
            {
                if (dgvVATDefine.Rows.Count <= i)
                {
                    dgvVATDefine.Rows.Add();
                }
            }
        }

        private void SetLanguageOption()
        {
            this.btnSaveMainCategory.Text = FormMessage.SAVE_MAIN_CATEGORY;
            this.btnGetMainCategory.Text = FormMessage.GET_MAIN_CATEGORY;
            this.tbpCashier.Text = FormMessage.CASHIER;
            this.lblCashier.Text = FormMessage.CASHIER_LIST;
            this.btnSaveCashier.Text = FormMessage.SAVE_CASHIER;
            this.btnGetCashier.Text = FormMessage.GET_CASHIER;
            this.tbpProgramOption.Text = FormMessage.PROGRAM_OPTIONS;
            this.lblProgramOption.Text = FormMessage.PROGRAM_OPTIONS;
            this.btnSavePrmOption.Text = FormMessage.SAVE_PROG_OPTIONS;
            this.btnGetPrmOption.Text = FormMessage.GET_PROG_OPTIONS;
            this.tbpBitmapLogo.Text = FormMessage.GRAPHIC_LOGO;
            this.lblLogoHeight.Text = "Yükseklik 120px";
            this.lblLogoWidth.Text = "<-- Genişlik 570px -->";
            this.lblPreviewLogo.Text = FormMessage.PREVIEW;
            this.btnSendBitmap.Text = FormMessage.SAVE_LOGO;
            this.btnBrowseBmp.Text = FormMessage.BROWSE_BITMAP;
            this.tbpNetwork.Text = FormMessage.NETWORK_SETTINGS;
            this.label2.Text = FormMessage.AUTOMATIC_IP_MESSSAGE;
            this.txtSubnet.Text = "255.255.255.0";
            this.lblGateway.Text = "Gateway :";
            this.lblSubnet.Text = "Subnet :";
            this.lblTsmIp.Text = "IP :";
            this.btnSaveNetwork.Text = FormMessage.SAVE;
            this.tabSRVLogo.Text = FormMessage.LOGO;
            this.btnSaveLogo.Text = FormMessage.SAVE_LOGO;
            this.btnGetLogo.Text = FormMessage.GET_LOGO;
            this.tabSRVVAT.Text = FormMessage.VAT;
            this.lblVAT.Text = FormMessage.DEFINE_VAT;
            this.btnSaveVat.Text = FormMessage.SAVE_VAT;
            this.btnGetVat.Text = FormMessage.GET_VAT;
            this.tbpDepTax.Text = FormMessage.DEPARTMENT;
            this.lblDepartment.Text = FormMessage.DEPARTMENT_DEFINITION;
            this.btnSaveDepartment.Text = FormMessage.SAVE_DEPARTMENT;
            this.btnGetDepartment.Text = FormMessage.GET_DEPARTMENT;
            this.tbpPLU.Text = FormMessage.PLU;
            this.lblInfoPLU.Text = "?";
            this.lblPLUStart.Text = FormMessage.PLU_ID;
            this.lblPLUDefine.Text = FormMessage.PLU_DEFINITION;
            this.btnSavePLU.Text = FormMessage.SAVE_PLU;
            this.btnGetPLU.Text = FormMessage.GET_PLU;
            this.tbpCredit.Text = FormMessage.CREDIT;
            this.label1.Text = FormMessage.CURRENCY_DEFINITION;
            this.btnSaveFcurrency.Text = FormMessage.SAVE_F_CURRENCY;
            this.btnGetFCurrency.Text = FormMessage.GET_F_CURRENCY;
            this.lblDefineCredit.Text = FormMessage.CREDIT_DEFINITION;
            this.btnSaveCredits.Text = FormMessage.SAVE_CREDIT;
            this.btnGetCredits.Text = FormMessage.GET_CREDIT;
            this.tbpCategory.Text = FormMessage.CATEGORY;
            this.lblMainGrup.Text = FormMessage.MAIN_GROUP;
            this.clmnMainGrupNo.HeaderText = FormMessage.MAIN_CAT_ID;
            this.clmnMainGrupName.HeaderText = FormMessage.MAIN_CAT_NAME;
            this.clmnMainGrupSelect.HeaderText = FormMessage.COMMIT;
            this.clmnCashierIndex.HeaderText = FormMessage.CASHIER_ID;
            this.clmnCashierName.HeaderText = FormMessage.CASHIER_NAME;
            this.clmnCashierPassword.HeaderText = FormMessage.CASHIER_PWD;
            this.clmnCashierSelect.HeaderText = FormMessage.COMMIT;
            this.clmnPONo.HeaderText = FormMessage.PROG_OPT_ID;
            this.clmnPOName.HeaderText = FormMessage.PROG_OPT_NAME;
            this.clmnPOValue.HeaderText = FormMessage.PROG_OPT_VALUE;
            this.clmnPOSelect.HeaderText = FormMessage.COMMIT;
            this.clmnVatGroupNum.HeaderText = FormMessage.VAT_ID;
            this.clmnVatRate.HeaderText = FormMessage.VAT_RATE;
            this.clmnSelectedVat.HeaderText = FormMessage.COMMIT;
            this.clmnDeptNo.HeaderText = FormMessage.DEPARTMENT_ID;
            this.clmnDeptName.HeaderText = FormMessage.DEPARTMENT_NAME;
            this.clmnDeptVatId.HeaderText = FormMessage.VAT_GROUP_ID;
            this.clmnDeptPrice.HeaderText = FormMessage.PRICE;
            this.clmnDeptWeighable.HeaderText = FormMessage.WEIGHABLE;
            this.clmnSelectDepartment.HeaderText = FormMessage.COMMIT;
            this.clmnPLUNo.HeaderText = FormMessage.PLU_ID;
            this.clmnPLUName.HeaderText = FormMessage.PLU_NAME;
            this.clmnPLUDeptNo.HeaderText = FormMessage.DEPARTMENT_ID;
            this.clmnPLUPrice.HeaderText = FormMessage.PRICE;
            this.clmnPLUBarcode.HeaderText = FormMessage.BARCODE;
            this.clmnPLUSubCat.HeaderText = FormMessage.SUB_CATEGORY;
            this.clmnPLUWeighable.HeaderText = FormMessage.WEIGHABLE;
            this.clmnPLUSelected.HeaderText = FormMessage.COMMIT;
            this.clmnFCurrId.HeaderText = FormMessage.F_CURRENCY_ID;
            this.clmnFCurrName.HeaderText = FormMessage.F_CURRENCY_CODE_NAME;
            this.clmnFCurrRate.HeaderText = FormMessage.EXCHANGE_RATE;
            this.clmnFCurrSelected.HeaderText = FormMessage.COMMIT;
            this.clmnIndex.HeaderText = FormMessage.CREDIT_INDEX;
            this.clmnCreditName.HeaderText = FormMessage.CREDIT_NAME;
            this.clmnSelected.HeaderText = FormMessage.COMMIT;

            this.tabPageEndOfReceiptNote.Text = FormMessage.END_OF_RECEIPT_NOTE;
            this.labelEORLine1.Text = FormMessage.LINE + " 1:";
            this.labelEORLine2.Text = FormMessage.LINE + " 2:";
            this.labelEORLine3.Text = FormMessage.LINE + " 3:";
            this.labelEORLine4.Text = FormMessage.LINE + " 4:";
            this.labelEORLine5.Text = FormMessage.LINE + " 5:";
            this.labelEORLine6.Text = FormMessage.LINE + " 6:";
            this.checkBoxEORLine1.Text = FormMessage.SAVE;
            this.checkBoxEORLine2.Text = FormMessage.SAVE;
            this.checkBoxEORLine3.Text = FormMessage.SAVE;
            this.checkBoxEORLine4.Text = FormMessage.SAVE;
            this.checkBoxEORLine5.Text = FormMessage.SAVE;
            this.checkBoxEORLine6.Text = FormMessage.SAVE;
            this.buttonEORGet.Text = FormMessage.GET;
            this.buttonEORSet.Text = FormMessage.SET;
        }

        internal static TestUC Instance(IBridge iBridge)
        {
            if (programForm == null)
            {
                bridge = iBridge;
                programForm = new ProgramUC();
            }
            return programForm;
        }
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbcProgram = new System.Windows.Forms.TabControl();
            this.tbpDepTax = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelTabDepartment = new System.Windows.Forms.TableLayoutPanel();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.dgvDepDefine = new System.Windows.Forms.DataGridView();
            this.clmnDeptNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDeptVatId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDeptPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDeptLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDeptWeighable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmnSelectDepartment = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanelDptButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnSaveDepartment = new System.Windows.Forms.Button();
            this.btnGetDepartment = new System.Windows.Forms.Button();
            this.tbpPLU = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelTabPLU = new System.Windows.Forms.TableLayoutPanel();
            this.lblPLUDefine = new System.Windows.Forms.Label();
            this.dgvPLUDefine = new System.Windows.Forms.DataGridView();
            this.clmnPLUNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPLUName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPLUDeptNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPLUPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPLUBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPLUSubCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPLUWeighable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmnPLUSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanelPLUButtons = new System.Windows.Forms.TableLayoutPanel();
            this.lblPLUStart = new System.Windows.Forms.Label();
            this.txtPluAddress = new System.Windows.Forms.TextBox();
            this.btnSavePLU = new System.Windows.Forms.Button();
            this.btnGetPLU = new System.Windows.Forms.Button();
            this.lblInfoPLU = new System.Windows.Forms.Label();
            this.tbpCredit = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelTabCredit = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDefineCredit = new System.Windows.Forms.Label();
            this.dgvFCurrency = new System.Windows.Forms.DataGridView();
            this.clmnFCurrId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnFCurrName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnFCurrRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnFCurrSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvCredits = new System.Windows.Forms.DataGridView();
            this.clmnIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnCreditName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanelCreditButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnGetCredits = new System.Windows.Forms.Button();
            this.btnSaveCredits = new System.Windows.Forms.Button();
            this.tableLayoutPanelFCurrencyButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnGetFCurrency = new System.Windows.Forms.Button();
            this.btnSaveFcurrency = new System.Windows.Forms.Button();
            this.tbpCategory = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelTabCategory = new System.Windows.Forms.TableLayoutPanel();
            this.lblMainGrup = new System.Windows.Forms.Label();
            this.dgvMainCategory = new System.Windows.Forms.DataGridView();
            this.clmnMainGrupNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnMainGrupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnMainGrupSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanelMainGrBttns = new System.Windows.Forms.TableLayoutPanel();
            this.btnGetMainCategory = new System.Windows.Forms.Button();
            this.btnSaveMainCategory = new System.Windows.Forms.Button();
            this.tbpCashier = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelTabCashier = new System.Windows.Forms.TableLayoutPanel();
            this.lblCashier = new System.Windows.Forms.Label();
            this.dgvCashier = new System.Windows.Forms.DataGridView();
            this.clmnCashierIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnCashierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnCashierPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnCashierSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanelCashierBttns = new System.Windows.Forms.TableLayoutPanel();
            this.btnGetCashier = new System.Windows.Forms.Button();
            this.btnSaveCashier = new System.Windows.Forms.Button();
            this.tbpProgramOption = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelProgOpt = new System.Windows.Forms.TableLayoutPanel();
            this.lblProgramOption = new System.Windows.Forms.Label();
            this.dgvPrmOption = new System.Windows.Forms.DataGridView();
            this.clmnPONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPOName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPOValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPOSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanelProgOptBttns = new System.Windows.Forms.TableLayoutPanel();
            this.btnGetPrmOption = new System.Windows.Forms.Button();
            this.btnSavePrmOption = new System.Windows.Forms.Button();
            this.tbpBitmapLogo = new System.Windows.Forms.TabPage();
            this.checkBoxForGibLogo = new System.Windows.Forms.CheckBox();
            this.lblLogoHeight = new System.Windows.Forms.Label();
            this.lblLogoWidth = new System.Windows.Forms.Label();
            this.lblPreviewLogo = new System.Windows.Forms.Label();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.btnSendBitmap = new System.Windows.Forms.Button();
            this.btnBrowseBmp = new System.Windows.Forms.Button();
            this.tbpNetwork = new System.Windows.Forms.TabPage();
            this.chkGateway = new System.Windows.Forms.CheckBox();
            this.chkSubnet = new System.Windows.Forms.CheckBox();
            this.chkIp = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGateway = new System.Windows.Forms.TextBox();
            this.txtSubnet = new System.Windows.Forms.TextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.lblGateway = new System.Windows.Forms.Label();
            this.lblSubnet = new System.Windows.Forms.Label();
            this.lblTsmIp = new System.Windows.Forms.Label();
            this.btnSaveNetwork = new System.Windows.Forms.Button();
            this.tabSRVLogo = new System.Windows.Forms.TabPage();
            this.btnSaveLogo = new System.Windows.Forms.Button();
            this.btnGetLogo = new System.Windows.Forms.Button();
            this.tabSRVVAT = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelVAT = new System.Windows.Forms.TableLayoutPanel();
            this.lblVAT = new System.Windows.Forms.Label();
            this.dgvVATDefine = new System.Windows.Forms.DataGridView();
            this.clmnVatGroupNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnVatRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnSelectedVat = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanelVATBttns = new System.Windows.Forms.TableLayoutPanel();
            this.btnGetVat = new System.Windows.Forms.Button();
            this.btnSaveVat = new System.Windows.Forms.Button();
            this.tabPageSendProduct = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblProductFile = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxProductFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowseProductFile = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTotalLineValue = new System.Windows.Forms.Label();
            this.labelTotalLine = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSendProducts = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.progressBarSendProd = new System.Windows.Forms.ProgressBar();
            this.labelUnderProgressBar = new System.Windows.Forms.Label();
            this.labelElapsedTime = new System.Windows.Forms.Label();
            this.tabPageEndOfReceiptNote = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxEORLine6 = new System.Windows.Forms.TextBox();
            this.textBoxEORLine5 = new System.Windows.Forms.TextBox();
            this.textBoxEORLine4 = new System.Windows.Forms.TextBox();
            this.textBoxEORLine3 = new System.Windows.Forms.TextBox();
            this.textBoxEORLine2 = new System.Windows.Forms.TextBox();
            this.labelEORLine1 = new System.Windows.Forms.Label();
            this.labelEORLine2 = new System.Windows.Forms.Label();
            this.labelEORLine3 = new System.Windows.Forms.Label();
            this.labelEORLine4 = new System.Windows.Forms.Label();
            this.labelEORLine5 = new System.Windows.Forms.Label();
            this.labelEORLine6 = new System.Windows.Forms.Label();
            this.checkBoxEORLine1 = new System.Windows.Forms.CheckBox();
            this.checkBoxEORLine2 = new System.Windows.Forms.CheckBox();
            this.checkBoxEORLine3 = new System.Windows.Forms.CheckBox();
            this.checkBoxEORLine4 = new System.Windows.Forms.CheckBox();
            this.checkBoxEORLine5 = new System.Windows.Forms.CheckBox();
            this.checkBoxEORLine6 = new System.Windows.Forms.CheckBox();
            this.textBoxEORLine1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonEORGet = new System.Windows.Forms.Button();
            this.buttonEORSet = new System.Windows.Forms.Button();
            this.tbcProgram.SuspendLayout();
            this.tbpDepTax.SuspendLayout();
            this.tableLayoutPanelTabDepartment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepDefine)).BeginInit();
            this.tableLayoutPanelDptButtons.SuspendLayout();
            this.tbpPLU.SuspendLayout();
            this.tableLayoutPanelTabPLU.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPLUDefine)).BeginInit();
            this.tableLayoutPanelPLUButtons.SuspendLayout();
            this.tbpCredit.SuspendLayout();
            this.tableLayoutPanelTabCredit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCredits)).BeginInit();
            this.tableLayoutPanelCreditButtons.SuspendLayout();
            this.tableLayoutPanelFCurrencyButtons.SuspendLayout();
            this.tbpCategory.SuspendLayout();
            this.tableLayoutPanelTabCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainCategory)).BeginInit();
            this.tableLayoutPanelMainGrBttns.SuspendLayout();
            this.tbpCashier.SuspendLayout();
            this.tableLayoutPanelTabCashier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashier)).BeginInit();
            this.tableLayoutPanelCashierBttns.SuspendLayout();
            this.tbpProgramOption.SuspendLayout();
            this.tableLayoutPanelProgOpt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrmOption)).BeginInit();
            this.tableLayoutPanelProgOptBttns.SuspendLayout();
            this.tbpBitmapLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.tbpNetwork.SuspendLayout();
            this.tabSRVLogo.SuspendLayout();
            this.tabSRVVAT.SuspendLayout();
            this.tableLayoutPanelVAT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVATDefine)).BeginInit();
            this.tableLayoutPanelVATBttns.SuspendLayout();
            this.tabPageSendProduct.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tabPageEndOfReceiptNote.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcProgram
            // 
            this.tbcProgram.Controls.Add(this.tbpDepTax);
            this.tbcProgram.Controls.Add(this.tbpPLU);
            this.tbcProgram.Controls.Add(this.tbpCredit);
            this.tbcProgram.Controls.Add(this.tbpCategory);
            this.tbcProgram.Controls.Add(this.tbpCashier);
            this.tbcProgram.Controls.Add(this.tbpProgramOption);
            this.tbcProgram.Controls.Add(this.tbpBitmapLogo);
            this.tbcProgram.Controls.Add(this.tbpNetwork);
            this.tbcProgram.Controls.Add(this.tabSRVLogo);
            this.tbcProgram.Controls.Add(this.tabSRVVAT);
            this.tbcProgram.Controls.Add(this.tabPageSendProduct);
            this.tbcProgram.Controls.Add(this.tabPageEndOfReceiptNote);
            this.tbcProgram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcProgram.Location = new System.Drawing.Point(0, 0);
            this.tbcProgram.Margin = new System.Windows.Forms.Padding(2);
            this.tbcProgram.Name = "tbcProgram";
            this.tbcProgram.SelectedIndex = 0;
            this.tbcProgram.Size = new System.Drawing.Size(591, 427);
            this.tbcProgram.TabIndex = 0;
            // 
            // tbpDepTax
            // 
            this.tbpDepTax.Controls.Add(this.tableLayoutPanelTabDepartment);
            this.tbpDepTax.Location = new System.Drawing.Point(4, 22);
            this.tbpDepTax.Margin = new System.Windows.Forms.Padding(2);
            this.tbpDepTax.Name = "tbpDepTax";
            this.tbpDepTax.Padding = new System.Windows.Forms.Padding(2);
            this.tbpDepTax.Size = new System.Drawing.Size(583, 401);
            this.tbpDepTax.TabIndex = 1;
            this.tbpDepTax.Text = "DEPARTMENT";
            this.tbpDepTax.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelTabDepartment
            // 
            this.tableLayoutPanelTabDepartment.ColumnCount = 3;
            this.tableLayoutPanelTabDepartment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanelTabDepartment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanelTabDepartment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanelTabDepartment.Controls.Add(this.lblDepartment, 1, 0);
            this.tableLayoutPanelTabDepartment.Controls.Add(this.dgvDepDefine, 1, 1);
            this.tableLayoutPanelTabDepartment.Controls.Add(this.tableLayoutPanelDptButtons, 1, 2);
            this.tableLayoutPanelTabDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTabDepartment.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanelTabDepartment.Name = "tableLayoutPanelTabDepartment";
            this.tableLayoutPanelTabDepartment.RowCount = 3;
            this.tableLayoutPanelTabDepartment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelTabDepartment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanelTabDepartment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelTabDepartment.Size = new System.Drawing.Size(579, 397);
            this.tableLayoutPanelTabDepartment.TabIndex = 12;
            // 
            // lblDepartment
            // 
            this.lblDepartment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDepartment.Location = new System.Drawing.Point(198, 22);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(181, 15);
            this.lblDepartment.TabIndex = 11;
            this.lblDepartment.Text = "DEPARTMENT DEFINITION";
            // 
            // dgvDepDefine
            // 
            this.dgvDepDefine.AllowUserToAddRows = false;
            this.dgvDepDefine.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDepDefine.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDepDefine.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepDefine.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDepDefine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDepDefine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepDefine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnDeptNo,
            this.clmnDeptName,
            this.clmnDeptVatId,
            this.clmnDeptPrice,
            this.clmnDeptLimit,
            this.clmnDeptWeighable,
            this.clmnSelectDepartment});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDepDefine.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDepDefine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDepDefine.Location = new System.Drawing.Point(30, 61);
            this.dgvDepDefine.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDepDefine.Name = "dgvDepDefine";
            this.dgvDepDefine.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDepDefine.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDepDefine.RowTemplate.Height = 24;
            this.dgvDepDefine.Size = new System.Drawing.Size(517, 273);
            this.dgvDepDefine.TabIndex = 7;
            // 
            // clmnDeptNo
            // 
            this.clmnDeptNo.FillWeight = 95.02538F;
            this.clmnDeptNo.HeaderText = "DEP. ID";
            this.clmnDeptNo.MaxInputLength = 2;
            this.clmnDeptNo.Name = "clmnDeptNo";
            this.clmnDeptNo.ReadOnly = true;
            // 
            // clmnDeptName
            // 
            this.clmnDeptName.FillWeight = 95.02538F;
            this.clmnDeptName.HeaderText = "DEP. NAME";
            this.clmnDeptName.MaxInputLength = 18;
            this.clmnDeptName.Name = "clmnDeptName";
            // 
            // clmnDeptVatId
            // 
            this.clmnDeptVatId.FillWeight = 95.02538F;
            this.clmnDeptVatId.HeaderText = "VAT GROUP ID";
            this.clmnDeptVatId.MaxInputLength = 1;
            this.clmnDeptVatId.Name = "clmnDeptVatId";
            this.clmnDeptVatId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnDeptVatId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmnDeptPrice
            // 
            this.clmnDeptPrice.FillWeight = 95.02538F;
            this.clmnDeptPrice.HeaderText = "PRICE";
            this.clmnDeptPrice.Name = "clmnDeptPrice";
            // 
            // clmnDeptLimit
            // 
            this.clmnDeptLimit.HeaderText = "LIMIT";
            this.clmnDeptLimit.Name = "clmnDeptLimit";
            // 
            // clmnDeptWeighable
            // 
            this.clmnDeptWeighable.FillWeight = 124.8731F;
            this.clmnDeptWeighable.HeaderText = "WEIGHABLE";
            this.clmnDeptWeighable.Name = "clmnDeptWeighable";
            // 
            // clmnSelectDepartment
            // 
            this.clmnSelectDepartment.FillWeight = 95.02538F;
            this.clmnSelectDepartment.HeaderText = "COMMIT?";
            this.clmnSelectDepartment.Name = "clmnSelectDepartment";
            this.clmnSelectDepartment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnSelectDepartment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tableLayoutPanelDptButtons
            // 
            this.tableLayoutPanelDptButtons.ColumnCount = 5;
            this.tableLayoutPanelDptButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelDptButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelDptButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelDptButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelDptButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelDptButtons.Controls.Add(this.btnSaveDepartment, 3, 0);
            this.tableLayoutPanelDptButtons.Controls.Add(this.btnGetDepartment, 1, 0);
            this.tableLayoutPanelDptButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDptButtons.Location = new System.Drawing.Point(31, 339);
            this.tableLayoutPanelDptButtons.Name = "tableLayoutPanelDptButtons";
            this.tableLayoutPanelDptButtons.RowCount = 1;
            this.tableLayoutPanelDptButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDptButtons.Size = new System.Drawing.Size(515, 55);
            this.tableLayoutPanelDptButtons.TabIndex = 12;
            // 
            // btnSaveDepartment
            // 
            this.btnSaveDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveDepartment.Location = new System.Drawing.Point(311, 2);
            this.btnSaveDepartment.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveDepartment.Name = "btnSaveDepartment";
            this.btnSaveDepartment.Size = new System.Drawing.Size(99, 51);
            this.btnSaveDepartment.TabIndex = 9;
            this.btnSaveDepartment.Text = "SAVE DEPARTMENT";
            this.btnSaveDepartment.UseVisualStyleBackColor = true;
            this.btnSaveDepartment.Click += new System.EventHandler(this.btnSaveDepartment_Click);
            // 
            // btnGetDepartment
            // 
            this.btnGetDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetDepartment.Location = new System.Drawing.Point(105, 2);
            this.btnGetDepartment.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetDepartment.Name = "btnGetDepartment";
            this.btnGetDepartment.Size = new System.Drawing.Size(99, 51);
            this.btnGetDepartment.TabIndex = 8;
            this.btnGetDepartment.Text = "GET DEPARTMENT";
            this.btnGetDepartment.UseVisualStyleBackColor = true;
            this.btnGetDepartment.Click += new System.EventHandler(this.btnGetDepartment_Click);
            // 
            // tbpPLU
            // 
            this.tbpPLU.Controls.Add(this.tableLayoutPanelTabPLU);
            this.tbpPLU.Controls.Add(this.lblInfoPLU);
            this.tbpPLU.Location = new System.Drawing.Point(4, 22);
            this.tbpPLU.Margin = new System.Windows.Forms.Padding(2);
            this.tbpPLU.Name = "tbpPLU";
            this.tbpPLU.Padding = new System.Windows.Forms.Padding(2);
            this.tbpPLU.Size = new System.Drawing.Size(583, 401);
            this.tbpPLU.TabIndex = 3;
            this.tbpPLU.Text = "PLU";
            this.tbpPLU.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelTabPLU
            // 
            this.tableLayoutPanelTabPLU.ColumnCount = 2;
            this.tableLayoutPanelTabPLU.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.48359F));
            this.tableLayoutPanelTabPLU.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.51641F));
            this.tableLayoutPanelTabPLU.Controls.Add(this.lblPLUDefine, 0, 0);
            this.tableLayoutPanelTabPLU.Controls.Add(this.dgvPLUDefine, 0, 1);
            this.tableLayoutPanelTabPLU.Controls.Add(this.tableLayoutPanelPLUButtons, 1, 1);
            this.tableLayoutPanelTabPLU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTabPLU.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanelTabPLU.Name = "tableLayoutPanelTabPLU";
            this.tableLayoutPanelTabPLU.RowCount = 2;
            this.tableLayoutPanelTabPLU.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.571789F));
            this.tableLayoutPanelTabPLU.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.42822F));
            this.tableLayoutPanelTabPLU.Size = new System.Drawing.Size(579, 397);
            this.tableLayoutPanelTabPLU.TabIndex = 21;
            // 
            // lblPLUDefine
            // 
            this.lblPLUDefine.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPLUDefine.AutoSize = true;
            this.lblPLUDefine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPLUDefine.Location = new System.Drawing.Point(175, 11);
            this.lblPLUDefine.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPLUDefine.Name = "lblPLUDefine";
            this.lblPLUDefine.Size = new System.Drawing.Size(115, 15);
            this.lblPLUDefine.TabIndex = 15;
            this.lblPLUDefine.Text = "PLU DEFINITION";
            // 
            // dgvPLUDefine
            // 
            this.dgvPLUDefine.AllowUserToAddRows = false;
            this.dgvPLUDefine.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPLUDefine.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPLUDefine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPLUDefine.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvPLUDefine.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPLUDefine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPLUDefine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPLUDefine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnPLUNo,
            this.clmnPLUName,
            this.clmnPLUDeptNo,
            this.clmnPLUPrice,
            this.clmnPLUBarcode,
            this.clmnPLUSubCat,
            this.clmnPLUWeighable,
            this.clmnPLUSelected});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPLUDefine.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPLUDefine.Location = new System.Drawing.Point(2, 39);
            this.dgvPLUDefine.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPLUDefine.Name = "dgvPLUDefine";
            this.dgvPLUDefine.RowHeadersVisible = false;
            this.dgvPLUDefine.RowTemplate.Height = 24;
            this.dgvPLUDefine.Size = new System.Drawing.Size(461, 356);
            this.dgvPLUDefine.TabIndex = 12;
            // 
            // clmnPLUNo
            // 
            this.clmnPLUNo.FillWeight = 406.0915F;
            this.clmnPLUNo.HeaderText = "PLU ID";
            this.clmnPLUNo.MaxInputLength = 2;
            this.clmnPLUNo.Name = "clmnPLUNo";
            this.clmnPLUNo.ReadOnly = true;
            this.clmnPLUNo.Width = 62;
            // 
            // clmnPLUName
            // 
            this.clmnPLUName.FillWeight = 63.10845F;
            this.clmnPLUName.HeaderText = "PLU NAME";
            this.clmnPLUName.MaxInputLength = 20;
            this.clmnPLUName.Name = "clmnPLUName";
            this.clmnPLUName.Width = 80;
            // 
            // clmnPLUDeptNo
            // 
            this.clmnPLUDeptNo.FillWeight = 8.485368F;
            this.clmnPLUDeptNo.HeaderText = "DEP. ID";
            this.clmnPLUDeptNo.MaxInputLength = 1;
            this.clmnPLUDeptNo.Name = "clmnPLUDeptNo";
            this.clmnPLUDeptNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnPLUDeptNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmnPLUDeptNo.Width = 47;
            // 
            // clmnPLUPrice
            // 
            this.clmnPLUPrice.FillWeight = 36.12524F;
            this.clmnPLUPrice.HeaderText = "PRICE";
            this.clmnPLUPrice.Name = "clmnPLUPrice";
            this.clmnPLUPrice.Width = 64;
            // 
            // clmnPLUBarcode
            // 
            this.clmnPLUBarcode.FillWeight = 177.0817F;
            this.clmnPLUBarcode.HeaderText = "BARCODE";
            this.clmnPLUBarcode.MaxInputLength = 20;
            this.clmnPLUBarcode.Name = "clmnPLUBarcode";
            this.clmnPLUBarcode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnPLUBarcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmnPLUBarcode.Width = 65;
            // 
            // clmnPLUSubCat
            // 
            this.clmnPLUSubCat.FillWeight = 32.70451F;
            this.clmnPLUSubCat.HeaderText = "SUB CATEGORY";
            this.clmnPLUSubCat.Name = "clmnPLUSubCat";
            this.clmnPLUSubCat.Width = 106;
            // 
            // clmnPLUWeighable
            // 
            this.clmnPLUWeighable.FillWeight = 36.24078F;
            this.clmnPLUWeighable.HeaderText = "WEIGHABLE";
            this.clmnPLUWeighable.Name = "clmnPLUWeighable";
            this.clmnPLUWeighable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnPLUWeighable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmnPLUWeighable.Width = 96;
            // 
            // clmnPLUSelected
            // 
            this.clmnPLUSelected.FillWeight = 40.16258F;
            this.clmnPLUSelected.HeaderText = "COMMIT?";
            this.clmnPLUSelected.Name = "clmnPLUSelected";
            this.clmnPLUSelected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnPLUSelected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmnPLUSelected.Width = 81;
            // 
            // tableLayoutPanelPLUButtons
            // 
            this.tableLayoutPanelPLUButtons.ColumnCount = 1;
            this.tableLayoutPanelPLUButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPLUButtons.Controls.Add(this.lblPLUStart, 0, 0);
            this.tableLayoutPanelPLUButtons.Controls.Add(this.txtPluAddress, 0, 1);
            this.tableLayoutPanelPLUButtons.Controls.Add(this.btnSavePLU, 0, 3);
            this.tableLayoutPanelPLUButtons.Controls.Add(this.btnGetPLU, 0, 2);
            this.tableLayoutPanelPLUButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPLUButtons.Location = new System.Drawing.Point(468, 40);
            this.tableLayoutPanelPLUButtons.Name = "tableLayoutPanelPLUButtons";
            this.tableLayoutPanelPLUButtons.RowCount = 4;
            this.tableLayoutPanelPLUButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelPLUButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelPLUButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelPLUButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelPLUButtons.Size = new System.Drawing.Size(108, 354);
            this.tableLayoutPanelPLUButtons.TabIndex = 16;
            // 
            // lblPLUStart
            // 
            this.lblPLUStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblPLUStart.AutoSize = true;
            this.lblPLUStart.Location = new System.Drawing.Point(31, 75);
            this.lblPLUStart.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPLUStart.Name = "lblPLUStart";
            this.lblPLUStart.Size = new System.Drawing.Size(45, 13);
            this.lblPLUStart.TabIndex = 18;
            this.lblPLUStart.Text = "PLU ID:";
            // 
            // txtPluAddress
            // 
            this.txtPluAddress.AccessibleDescription = "";
            this.txtPluAddress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPluAddress.Location = new System.Drawing.Point(2, 90);
            this.txtPluAddress.Margin = new System.Windows.Forms.Padding(2);
            this.txtPluAddress.Name = "txtPluAddress";
            this.txtPluAddress.Size = new System.Drawing.Size(104, 20);
            this.txtPluAddress.TabIndex = 19;
            this.txtPluAddress.Tag = "Enter comma to between PLUs to call more than one PLU. For calling range put  \'-\'" +
    " between two values.";
            this.txtPluAddress.Text = "1-10";
            // 
            // btnSavePLU
            // 
            this.btnSavePLU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSavePLU.Location = new System.Drawing.Point(2, 266);
            this.btnSavePLU.Margin = new System.Windows.Forms.Padding(2);
            this.btnSavePLU.Name = "btnSavePLU";
            this.btnSavePLU.Size = new System.Drawing.Size(104, 86);
            this.btnSavePLU.TabIndex = 14;
            this.btnSavePLU.Text = "SAVE PLU";
            this.btnSavePLU.UseVisualStyleBackColor = true;
            this.btnSavePLU.Click += new System.EventHandler(this.btnSavePLU_Click);
            // 
            // btnGetPLU
            // 
            this.btnGetPLU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetPLU.Location = new System.Drawing.Point(2, 178);
            this.btnGetPLU.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetPLU.Name = "btnGetPLU";
            this.btnGetPLU.Size = new System.Drawing.Size(104, 84);
            this.btnGetPLU.TabIndex = 13;
            this.btnGetPLU.Text = "GET PLU";
            this.btnGetPLU.UseVisualStyleBackColor = true;
            this.btnGetPLU.Click += new System.EventHandler(this.btnGetPLU_Click);
            // 
            // lblInfoPLU
            // 
            this.lblInfoPLU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoPLU.AutoSize = true;
            this.lblInfoPLU.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblInfoPLU.Font = new System.Drawing.Font("Cooper Black", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoPLU.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblInfoPLU.Location = new System.Drawing.Point(571, 219);
            this.lblInfoPLU.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInfoPLU.Name = "lblInfoPLU";
            this.lblInfoPLU.Size = new System.Drawing.Size(13, 14);
            this.lblInfoPLU.TabIndex = 20;
            this.lblInfoPLU.Text = "?";
            this.lblInfoPLU.Click += new System.EventHandler(this.lblInfoPLU_Click);
            // 
            // tbpCredit
            // 
            this.tbpCredit.Controls.Add(this.tableLayoutPanelTabCredit);
            this.tbpCredit.Location = new System.Drawing.Point(4, 22);
            this.tbpCredit.Margin = new System.Windows.Forms.Padding(2);
            this.tbpCredit.Name = "tbpCredit";
            this.tbpCredit.Padding = new System.Windows.Forms.Padding(2);
            this.tbpCredit.Size = new System.Drawing.Size(583, 401);
            this.tbpCredit.TabIndex = 2;
            this.tbpCredit.Text = "CREDIT";
            this.tbpCredit.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelTabCredit
            // 
            this.tableLayoutPanelTabCredit.ColumnCount = 2;
            this.tableLayoutPanelTabCredit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTabCredit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTabCredit.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelTabCredit.Controls.Add(this.lblDefineCredit, 1, 0);
            this.tableLayoutPanelTabCredit.Controls.Add(this.dgvFCurrency, 0, 1);
            this.tableLayoutPanelTabCredit.Controls.Add(this.dgvCredits, 1, 1);
            this.tableLayoutPanelTabCredit.Controls.Add(this.tableLayoutPanelCreditButtons, 1, 2);
            this.tableLayoutPanelTabCredit.Controls.Add(this.tableLayoutPanelFCurrencyButtons, 0, 2);
            this.tableLayoutPanelTabCredit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTabCredit.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanelTabCredit.Name = "tableLayoutPanelTabCredit";
            this.tableLayoutPanelTabCredit.RowCount = 3;
            this.tableLayoutPanelTabCredit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.2426F));
            this.tableLayoutPanelTabCredit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.75739F));
            this.tableLayoutPanelTabCredit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanelTabCredit.Size = new System.Drawing.Size(579, 397);
            this.tableLayoutPanelTabCredit.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(57, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "F.CURRENCY DEFINITION";
            // 
            // lblDefineCredit
            // 
            this.lblDefineCredit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDefineCredit.AutoSize = true;
            this.lblDefineCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDefineCredit.Location = new System.Drawing.Point(365, 11);
            this.lblDefineCredit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDefineCredit.Name = "lblDefineCredit";
            this.lblDefineCredit.Size = new System.Drawing.Size(138, 15);
            this.lblDefineCredit.TabIndex = 16;
            this.lblDefineCredit.Text = "CREDIT DEFINITION";
            // 
            // dgvFCurrency
            // 
            this.dgvFCurrency.AllowUserToAddRows = false;
            this.dgvFCurrency.AllowUserToDeleteRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvFCurrency.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvFCurrency.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFCurrency.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvFCurrency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFCurrency.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnFCurrId,
            this.clmnFCurrName,
            this.clmnFCurrRate,
            this.clmnFCurrSelected});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFCurrency.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvFCurrency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFCurrency.Location = new System.Drawing.Point(2, 40);
            this.dgvFCurrency.Margin = new System.Windows.Forms.Padding(2);
            this.dgvFCurrency.Name = "dgvFCurrency";
            this.dgvFCurrency.RowHeadersVisible = false;
            this.dgvFCurrency.RowTemplate.Height = 24;
            this.dgvFCurrency.Size = new System.Drawing.Size(285, 296);
            this.dgvFCurrency.TabIndex = 17;
            // 
            // clmnFCurrId
            // 
            this.clmnFCurrId.HeaderText = "F.CURRENCY ID";
            this.clmnFCurrId.MaxInputLength = 2;
            this.clmnFCurrId.Name = "clmnFCurrId";
            this.clmnFCurrId.ReadOnly = true;
            // 
            // clmnFCurrName
            // 
            this.clmnFCurrName.HeaderText = "F.CURRENCY CODE";
            this.clmnFCurrName.MaxInputLength = 15;
            this.clmnFCurrName.Name = "clmnFCurrName";
            // 
            // clmnFCurrRate
            // 
            this.clmnFCurrRate.HeaderText = "EXC RATE";
            this.clmnFCurrRate.Name = "clmnFCurrRate";
            // 
            // clmnFCurrSelected
            // 
            this.clmnFCurrSelected.HeaderText = "COMMIT?";
            this.clmnFCurrSelected.Name = "clmnFCurrSelected";
            this.clmnFCurrSelected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnFCurrSelected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgvCredits
            // 
            this.dgvCredits.AllowUserToAddRows = false;
            this.dgvCredits.AllowUserToDeleteRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCredits.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvCredits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCredits.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCredits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCredits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnIndex,
            this.clmnCreditName,
            this.clmnSelected});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCredits.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvCredits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCredits.Location = new System.Drawing.Point(291, 40);
            this.dgvCredits.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCredits.Name = "dgvCredits";
            this.dgvCredits.RowHeadersVisible = false;
            this.dgvCredits.RowTemplate.Height = 24;
            this.dgvCredits.Size = new System.Drawing.Size(286, 296);
            this.dgvCredits.TabIndex = 0;
            // 
            // clmnIndex
            // 
            this.clmnIndex.HeaderText = "CREDIT ID";
            this.clmnIndex.MaxInputLength = 2;
            this.clmnIndex.Name = "clmnIndex";
            this.clmnIndex.ReadOnly = true;
            // 
            // clmnCreditName
            // 
            this.clmnCreditName.HeaderText = "CREDIT NAME";
            this.clmnCreditName.MaxInputLength = 16;
            this.clmnCreditName.Name = "clmnCreditName";
            // 
            // clmnSelected
            // 
            this.clmnSelected.HeaderText = "COMMIT?";
            this.clmnSelected.Name = "clmnSelected";
            this.clmnSelected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnSelected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tableLayoutPanelCreditButtons
            // 
            this.tableLayoutPanelCreditButtons.ColumnCount = 5;
            this.tableLayoutPanelCreditButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.26761F));
            this.tableLayoutPanelCreditButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.56338F));
            this.tableLayoutPanelCreditButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.450705F));
            this.tableLayoutPanelCreditButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.09859F));
            this.tableLayoutPanelCreditButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.26761F));
            this.tableLayoutPanelCreditButtons.Controls.Add(this.btnGetCredits, 1, 0);
            this.tableLayoutPanelCreditButtons.Controls.Add(this.btnSaveCredits, 3, 0);
            this.tableLayoutPanelCreditButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCreditButtons.Location = new System.Drawing.Point(292, 341);
            this.tableLayoutPanelCreditButtons.Name = "tableLayoutPanelCreditButtons";
            this.tableLayoutPanelCreditButtons.RowCount = 1;
            this.tableLayoutPanelCreditButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCreditButtons.Size = new System.Drawing.Size(284, 53);
            this.tableLayoutPanelCreditButtons.TabIndex = 22;
            // 
            // btnGetCredits
            // 
            this.btnGetCredits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetCredits.Location = new System.Drawing.Point(34, 2);
            this.btnGetCredits.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetCredits.Name = "btnGetCredits";
            this.btnGetCredits.Size = new System.Drawing.Size(97, 49);
            this.btnGetCredits.TabIndex = 2;
            this.btnGetCredits.Text = "GET CREDIT";
            this.btnGetCredits.UseVisualStyleBackColor = true;
            this.btnGetCredits.Click += new System.EventHandler(this.btnGetCredits_Click);
            // 
            // btnSaveCredits
            // 
            this.btnSaveCredits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveCredits.Location = new System.Drawing.Point(159, 2);
            this.btnSaveCredits.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveCredits.Name = "btnSaveCredits";
            this.btnSaveCredits.Size = new System.Drawing.Size(90, 49);
            this.btnSaveCredits.TabIndex = 3;
            this.btnSaveCredits.Text = "SAVE CREDIT";
            this.btnSaveCredits.UseVisualStyleBackColor = true;
            this.btnSaveCredits.Click += new System.EventHandler(this.btnSaveCredits_Click);
            // 
            // tableLayoutPanelFCurrencyButtons
            // 
            this.tableLayoutPanelFCurrencyButtons.ColumnCount = 5;
            this.tableLayoutPanelFCurrencyButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.067138F));
            this.tableLayoutPanelFCurrencyButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.10247F));
            this.tableLayoutPanelFCurrencyButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.893993F));
            this.tableLayoutPanelFCurrencyButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.0424F));
            this.tableLayoutPanelFCurrencyButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.540636F));
            this.tableLayoutPanelFCurrencyButtons.Controls.Add(this.btnGetFCurrency, 1, 0);
            this.tableLayoutPanelFCurrencyButtons.Controls.Add(this.btnSaveFcurrency, 3, 0);
            this.tableLayoutPanelFCurrencyButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFCurrencyButtons.Location = new System.Drawing.Point(3, 341);
            this.tableLayoutPanelFCurrencyButtons.Name = "tableLayoutPanelFCurrencyButtons";
            this.tableLayoutPanelFCurrencyButtons.RowCount = 1;
            this.tableLayoutPanelFCurrencyButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelFCurrencyButtons.Size = new System.Drawing.Size(283, 53);
            this.tableLayoutPanelFCurrencyButtons.TabIndex = 23;
            // 
            // btnGetFCurrency
            // 
            this.btnGetFCurrency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetFCurrency.Location = new System.Drawing.Point(22, 2);
            this.btnGetFCurrency.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetFCurrency.Name = "btnGetFCurrency";
            this.btnGetFCurrency.Size = new System.Drawing.Size(101, 49);
            this.btnGetFCurrency.TabIndex = 18;
            this.btnGetFCurrency.Text = "GET F.CURRENCY";
            this.btnGetFCurrency.UseVisualStyleBackColor = true;
            this.btnGetFCurrency.Click += new System.EventHandler(this.btnGetFCurrency_Click);
            // 
            // btnSaveFcurrency
            // 
            this.btnSaveFcurrency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveFcurrency.Location = new System.Drawing.Point(155, 2);
            this.btnSaveFcurrency.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveFcurrency.Name = "btnSaveFcurrency";
            this.btnSaveFcurrency.Size = new System.Drawing.Size(98, 49);
            this.btnSaveFcurrency.TabIndex = 19;
            this.btnSaveFcurrency.Text = "SAVE F.CURRENCY";
            this.btnSaveFcurrency.UseVisualStyleBackColor = true;
            this.btnSaveFcurrency.Click += new System.EventHandler(this.btnSaveFcurrency_Click);
            // 
            // tbpCategory
            // 
            this.tbpCategory.Controls.Add(this.tableLayoutPanelTabCategory);
            this.tbpCategory.Location = new System.Drawing.Point(4, 22);
            this.tbpCategory.Margin = new System.Windows.Forms.Padding(2);
            this.tbpCategory.Name = "tbpCategory";
            this.tbpCategory.Padding = new System.Windows.Forms.Padding(2);
            this.tbpCategory.Size = new System.Drawing.Size(583, 401);
            this.tbpCategory.TabIndex = 4;
            this.tbpCategory.Text = "CATEGORY";
            this.tbpCategory.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelTabCategory
            // 
            this.tableLayoutPanelTabCategory.ColumnCount = 3;
            this.tableLayoutPanelTabCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelTabCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelTabCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelTabCategory.Controls.Add(this.lblMainGrup, 1, 0);
            this.tableLayoutPanelTabCategory.Controls.Add(this.dgvMainCategory, 1, 1);
            this.tableLayoutPanelTabCategory.Controls.Add(this.tableLayoutPanelMainGrBttns, 1, 2);
            this.tableLayoutPanelTabCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTabCategory.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanelTabCategory.Name = "tableLayoutPanelTabCategory";
            this.tableLayoutPanelTabCategory.RowCount = 3;
            this.tableLayoutPanelTabCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.63637F));
            this.tableLayoutPanelTabCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.24242F));
            this.tableLayoutPanelTabCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.12121F));
            this.tableLayoutPanelTabCategory.Size = new System.Drawing.Size(579, 397);
            this.tableLayoutPanelTabCategory.TabIndex = 20;
            // 
            // lblMainGrup
            // 
            this.lblMainGrup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMainGrup.AutoSize = true;
            this.lblMainGrup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMainGrup.Location = new System.Drawing.Point(241, 19);
            this.lblMainGrup.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMainGrup.Name = "lblMainGrup";
            this.lblMainGrup.Size = new System.Drawing.Size(94, 15);
            this.lblMainGrup.TabIndex = 18;
            this.lblMainGrup.Text = "MAIN GROUP";
            // 
            // dgvMainCategory
            // 
            this.dgvMainCategory.AllowUserToAddRows = false;
            this.dgvMainCategory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMainCategory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvMainCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMainCategory.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvMainCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMainCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnMainGrupNo,
            this.clmnMainGrupName,
            this.clmnMainGrupSelect});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMainCategory.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvMainCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMainCategory.Location = new System.Drawing.Point(117, 56);
            this.dgvMainCategory.Margin = new System.Windows.Forms.Padding(2);
            this.dgvMainCategory.Name = "dgvMainCategory";
            this.dgvMainCategory.RowHeadersVisible = false;
            this.dgvMainCategory.RowTemplate.Height = 24;
            this.dgvMainCategory.Size = new System.Drawing.Size(343, 290);
            this.dgvMainCategory.TabIndex = 12;
            // 
            // clmnMainGrupNo
            // 
            this.clmnMainGrupNo.HeaderText = "MAIN CAT. ID";
            this.clmnMainGrupNo.MaxInputLength = 1;
            this.clmnMainGrupNo.Name = "clmnMainGrupNo";
            this.clmnMainGrupNo.ReadOnly = true;
            // 
            // clmnMainGrupName
            // 
            this.clmnMainGrupName.HeaderText = "MAIN CAT. NAME";
            this.clmnMainGrupName.MaxInputLength = 20;
            this.clmnMainGrupName.Name = "clmnMainGrupName";
            // 
            // clmnMainGrupSelect
            // 
            this.clmnMainGrupSelect.HeaderText = "COMMIT?";
            this.clmnMainGrupSelect.Name = "clmnMainGrupSelect";
            // 
            // tableLayoutPanelMainGrBttns
            // 
            this.tableLayoutPanelMainGrBttns.ColumnCount = 5;
            this.tableLayoutPanelMainGrBttns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanelMainGrBttns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelMainGrBttns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanelMainGrBttns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelMainGrBttns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanelMainGrBttns.Controls.Add(this.btnGetMainCategory, 1, 0);
            this.tableLayoutPanelMainGrBttns.Controls.Add(this.btnSaveMainCategory, 3, 0);
            this.tableLayoutPanelMainGrBttns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMainGrBttns.Location = new System.Drawing.Point(118, 351);
            this.tableLayoutPanelMainGrBttns.Name = "tableLayoutPanelMainGrBttns";
            this.tableLayoutPanelMainGrBttns.RowCount = 1;
            this.tableLayoutPanelMainGrBttns.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMainGrBttns.Size = new System.Drawing.Size(341, 43);
            this.tableLayoutPanelMainGrBttns.TabIndex = 20;
            // 
            // btnGetMainCategory
            // 
            this.btnGetMainCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetMainCategory.Location = new System.Drawing.Point(25, 2);
            this.btnGetMainCategory.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetMainCategory.Name = "btnGetMainCategory";
            this.btnGetMainCategory.Size = new System.Drawing.Size(132, 39);
            this.btnGetMainCategory.TabIndex = 13;
            this.btnGetMainCategory.Text = "GET MAIN CAT.";
            this.btnGetMainCategory.UseVisualStyleBackColor = true;
            this.btnGetMainCategory.Click += new System.EventHandler(this.btnGetMainCategory_Click);
            // 
            // btnSaveMainCategory
            // 
            this.btnSaveMainCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveMainCategory.Location = new System.Drawing.Point(181, 2);
            this.btnSaveMainCategory.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveMainCategory.Name = "btnSaveMainCategory";
            this.btnSaveMainCategory.Size = new System.Drawing.Size(132, 39);
            this.btnSaveMainCategory.TabIndex = 14;
            this.btnSaveMainCategory.Text = "SAVE MAIN CAT.";
            this.btnSaveMainCategory.UseVisualStyleBackColor = true;
            this.btnSaveMainCategory.Click += new System.EventHandler(this.btnSaveMainCategory_Click);
            // 
            // tbpCashier
            // 
            this.tbpCashier.Controls.Add(this.tableLayoutPanelTabCashier);
            this.tbpCashier.Location = new System.Drawing.Point(4, 22);
            this.tbpCashier.Margin = new System.Windows.Forms.Padding(2);
            this.tbpCashier.Name = "tbpCashier";
            this.tbpCashier.Padding = new System.Windows.Forms.Padding(2);
            this.tbpCashier.Size = new System.Drawing.Size(583, 401);
            this.tbpCashier.TabIndex = 5;
            this.tbpCashier.Text = "CASHIER";
            this.tbpCashier.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelTabCashier
            // 
            this.tableLayoutPanelTabCashier.ColumnCount = 3;
            this.tableLayoutPanelTabCashier.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelTabCashier.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanelTabCashier.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelTabCashier.Controls.Add(this.lblCashier, 1, 0);
            this.tableLayoutPanelTabCashier.Controls.Add(this.dgvCashier, 1, 1);
            this.tableLayoutPanelTabCashier.Controls.Add(this.tableLayoutPanelCashierBttns, 1, 2);
            this.tableLayoutPanelTabCashier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTabCashier.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanelTabCashier.Name = "tableLayoutPanelTabCashier";
            this.tableLayoutPanelTabCashier.RowCount = 3;
            this.tableLayoutPanelTabCashier.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.83123F));
            this.tableLayoutPanelTabCashier.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.56675F));
            this.tableLayoutPanelTabCashier.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.8539F));
            this.tableLayoutPanelTabCashier.Size = new System.Drawing.Size(579, 397);
            this.tableLayoutPanelTabCashier.TabIndex = 23;
            // 
            // lblCashier
            // 
            this.lblCashier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCashier.AutoSize = true;
            this.lblCashier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCashier.Location = new System.Drawing.Point(239, 13);
            this.lblCashier.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCashier.Name = "lblCashier";
            this.lblCashier.Size = new System.Drawing.Size(99, 15);
            this.lblCashier.TabIndex = 22;
            this.lblCashier.Text = "CASHIER LIST";
            // 
            // dgvCashier
            // 
            this.dgvCashier.AllowUserToAddRows = false;
            this.dgvCashier.AllowUserToDeleteRows = false;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCashier.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvCashier.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCashier.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCashier.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvCashier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCashier.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnCashierIndex,
            this.clmnCashierName,
            this.clmnCashierPassword,
            this.clmnCashierSelect});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCashier.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgvCashier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCashier.Location = new System.Drawing.Point(59, 44);
            this.dgvCashier.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCashier.Name = "dgvCashier";
            this.dgvCashier.RowHeadersVisible = false;
            this.dgvCashier.RowTemplate.Height = 24;
            this.dgvCashier.Size = new System.Drawing.Size(459, 295);
            this.dgvCashier.TabIndex = 19;
            // 
            // clmnCashierIndex
            // 
            this.clmnCashierIndex.HeaderText = "CASHIER ID";
            this.clmnCashierIndex.MaxInputLength = 1;
            this.clmnCashierIndex.Name = "clmnCashierIndex";
            this.clmnCashierIndex.ReadOnly = true;
            // 
            // clmnCashierName
            // 
            this.clmnCashierName.HeaderText = "CASHIER NAME";
            this.clmnCashierName.MaxInputLength = 15;
            this.clmnCashierName.Name = "clmnCashierName";
            // 
            // clmnCashierPassword
            // 
            this.clmnCashierPassword.HeaderText = "CASHIER PWD";
            this.clmnCashierPassword.MaxInputLength = 6;
            this.clmnCashierPassword.Name = "clmnCashierPassword";
            // 
            // clmnCashierSelect
            // 
            this.clmnCashierSelect.HeaderText = "COMMIT?";
            this.clmnCashierSelect.Name = "clmnCashierSelect";
            // 
            // tableLayoutPanelCashierBttns
            // 
            this.tableLayoutPanelCashierBttns.ColumnCount = 5;
            this.tableLayoutPanelCashierBttns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanelCashierBttns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelCashierBttns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanelCashierBttns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelCashierBttns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanelCashierBttns.Controls.Add(this.btnGetCashier, 1, 0);
            this.tableLayoutPanelCashierBttns.Controls.Add(this.btnSaveCashier, 3, 0);
            this.tableLayoutPanelCashierBttns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCashierBttns.Location = new System.Drawing.Point(60, 344);
            this.tableLayoutPanelCashierBttns.Name = "tableLayoutPanelCashierBttns";
            this.tableLayoutPanelCashierBttns.RowCount = 1;
            this.tableLayoutPanelCashierBttns.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCashierBttns.Size = new System.Drawing.Size(457, 50);
            this.tableLayoutPanelCashierBttns.TabIndex = 23;
            // 
            // btnGetCashier
            // 
            this.btnGetCashier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetCashier.Location = new System.Drawing.Point(33, 2);
            this.btnGetCashier.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetCashier.Name = "btnGetCashier";
            this.btnGetCashier.Size = new System.Drawing.Size(178, 46);
            this.btnGetCashier.TabIndex = 20;
            this.btnGetCashier.Text = "GET CASHIER";
            this.btnGetCashier.UseVisualStyleBackColor = true;
            this.btnGetCashier.Click += new System.EventHandler(this.btnGetCashier_Click);
            // 
            // btnSaveCashier
            // 
            this.btnSaveCashier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveCashier.Location = new System.Drawing.Point(242, 2);
            this.btnSaveCashier.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveCashier.Name = "btnSaveCashier";
            this.btnSaveCashier.Size = new System.Drawing.Size(178, 46);
            this.btnSaveCashier.TabIndex = 21;
            this.btnSaveCashier.Text = "SAVE CASHIER";
            this.btnSaveCashier.UseVisualStyleBackColor = true;
            this.btnSaveCashier.Click += new System.EventHandler(this.btnSaveCashier_Click);
            // 
            // tbpProgramOption
            // 
            this.tbpProgramOption.Controls.Add(this.tableLayoutPanelProgOpt);
            this.tbpProgramOption.Location = new System.Drawing.Point(4, 22);
            this.tbpProgramOption.Margin = new System.Windows.Forms.Padding(2);
            this.tbpProgramOption.Name = "tbpProgramOption";
            this.tbpProgramOption.Padding = new System.Windows.Forms.Padding(2);
            this.tbpProgramOption.Size = new System.Drawing.Size(583, 401);
            this.tbpProgramOption.TabIndex = 6;
            this.tbpProgramOption.Text = "PROGRAM OPTIONS";
            this.tbpProgramOption.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelProgOpt
            // 
            this.tableLayoutPanelProgOpt.ColumnCount = 3;
            this.tableLayoutPanelProgOpt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelProgOpt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanelProgOpt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelProgOpt.Controls.Add(this.lblProgramOption, 1, 0);
            this.tableLayoutPanelProgOpt.Controls.Add(this.dgvPrmOption, 1, 1);
            this.tableLayoutPanelProgOpt.Controls.Add(this.tableLayoutPanelProgOptBttns, 1, 2);
            this.tableLayoutPanelProgOpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelProgOpt.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanelProgOpt.Name = "tableLayoutPanelProgOpt";
            this.tableLayoutPanelProgOpt.RowCount = 3;
            this.tableLayoutPanelProgOpt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.5869F));
            this.tableLayoutPanelProgOpt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.3073F));
            this.tableLayoutPanelProgOpt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.35768F));
            this.tableLayoutPanelProgOpt.Size = new System.Drawing.Size(579, 397);
            this.tableLayoutPanelProgOpt.TabIndex = 27;
            // 
            // lblProgramOption
            // 
            this.lblProgramOption.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblProgramOption.AutoSize = true;
            this.lblProgramOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblProgramOption.Location = new System.Drawing.Point(218, 15);
            this.lblProgramOption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProgramOption.Name = "lblProgramOption";
            this.lblProgramOption.Size = new System.Drawing.Size(140, 15);
            this.lblProgramOption.TabIndex = 26;
            this.lblProgramOption.Text = "PROGRAM OPTIONS";
            // 
            // dgvPrmOption
            // 
            this.dgvPrmOption.AllowUserToAddRows = false;
            this.dgvPrmOption.AllowUserToDeleteRows = false;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPrmOption.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvPrmOption.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrmOption.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrmOption.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvPrmOption.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrmOption.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnPONo,
            this.clmnPOName,
            this.clmnPOValue,
            this.clmnPOSelect});
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPrmOption.DefaultCellStyle = dataGridViewCellStyle19;
            this.dgvPrmOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrmOption.Location = new System.Drawing.Point(59, 47);
            this.dgvPrmOption.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPrmOption.Name = "dgvPrmOption";
            this.dgvPrmOption.RowHeadersVisible = false;
            this.dgvPrmOption.RowTemplate.Height = 24;
            this.dgvPrmOption.Size = new System.Drawing.Size(459, 290);
            this.dgvPrmOption.TabIndex = 23;
            // 
            // clmnPONo
            // 
            this.clmnPONo.HeaderText = "ID";
            this.clmnPONo.MaxInputLength = 1;
            this.clmnPONo.Name = "clmnPONo";
            this.clmnPONo.ReadOnly = true;
            // 
            // clmnPOName
            // 
            this.clmnPOName.HeaderText = "NAME";
            this.clmnPOName.MaxInputLength = 20;
            this.clmnPOName.Name = "clmnPOName";
            // 
            // clmnPOValue
            // 
            this.clmnPOValue.HeaderText = "VALUE";
            this.clmnPOValue.MaxInputLength = 20;
            this.clmnPOValue.Name = "clmnPOValue";
            // 
            // clmnPOSelect
            // 
            this.clmnPOSelect.HeaderText = "COMMIT?";
            this.clmnPOSelect.Name = "clmnPOSelect";
            // 
            // tableLayoutPanelProgOptBttns
            // 
            this.tableLayoutPanelProgOptBttns.ColumnCount = 5;
            this.tableLayoutPanelProgOptBttns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanelProgOptBttns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelProgOptBttns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanelProgOptBttns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelProgOptBttns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanelProgOptBttns.Controls.Add(this.btnGetPrmOption, 1, 0);
            this.tableLayoutPanelProgOptBttns.Controls.Add(this.btnSavePrmOption, 3, 0);
            this.tableLayoutPanelProgOptBttns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelProgOptBttns.Location = new System.Drawing.Point(60, 342);
            this.tableLayoutPanelProgOptBttns.Name = "tableLayoutPanelProgOptBttns";
            this.tableLayoutPanelProgOptBttns.RowCount = 1;
            this.tableLayoutPanelProgOptBttns.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProgOptBttns.Size = new System.Drawing.Size(457, 52);
            this.tableLayoutPanelProgOptBttns.TabIndex = 27;
            // 
            // btnGetPrmOption
            // 
            this.btnGetPrmOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetPrmOption.Location = new System.Drawing.Point(33, 2);
            this.btnGetPrmOption.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetPrmOption.Name = "btnGetPrmOption";
            this.btnGetPrmOption.Size = new System.Drawing.Size(178, 48);
            this.btnGetPrmOption.TabIndex = 24;
            this.btnGetPrmOption.Text = "GET PROG. OPTIONS";
            this.btnGetPrmOption.UseVisualStyleBackColor = true;
            this.btnGetPrmOption.Click += new System.EventHandler(this.btnGetPrmOption_Click);
            // 
            // btnSavePrmOption
            // 
            this.btnSavePrmOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSavePrmOption.Location = new System.Drawing.Point(242, 2);
            this.btnSavePrmOption.Margin = new System.Windows.Forms.Padding(2);
            this.btnSavePrmOption.Name = "btnSavePrmOption";
            this.btnSavePrmOption.Size = new System.Drawing.Size(178, 48);
            this.btnSavePrmOption.TabIndex = 25;
            this.btnSavePrmOption.Text = "SAVE PROG. OPTIONS";
            this.btnSavePrmOption.UseVisualStyleBackColor = true;
            this.btnSavePrmOption.Click += new System.EventHandler(this.btnSavePrmOption_Click);
            // 
            // tbpBitmapLogo
            // 
            this.tbpBitmapLogo.Controls.Add(this.checkBoxForGibLogo);
            this.tbpBitmapLogo.Controls.Add(this.lblLogoHeight);
            this.tbpBitmapLogo.Controls.Add(this.lblLogoWidth);
            this.tbpBitmapLogo.Controls.Add(this.lblPreviewLogo);
            this.tbpBitmapLogo.Controls.Add(this.pbxLogo);
            this.tbpBitmapLogo.Controls.Add(this.btnSendBitmap);
            this.tbpBitmapLogo.Controls.Add(this.btnBrowseBmp);
            this.tbpBitmapLogo.Location = new System.Drawing.Point(4, 22);
            this.tbpBitmapLogo.Margin = new System.Windows.Forms.Padding(2);
            this.tbpBitmapLogo.Name = "tbpBitmapLogo";
            this.tbpBitmapLogo.Padding = new System.Windows.Forms.Padding(2);
            this.tbpBitmapLogo.Size = new System.Drawing.Size(583, 401);
            this.tbpBitmapLogo.TabIndex = 7;
            this.tbpBitmapLogo.Text = "GRAPHIC LOGO";
            this.tbpBitmapLogo.UseVisualStyleBackColor = true;
            // 
            // checkBoxForGibLogo
            // 
            this.checkBoxForGibLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxForGibLogo.AutoSize = true;
            this.checkBoxForGibLogo.Location = new System.Drawing.Point(388, 256);
            this.checkBoxForGibLogo.Name = "checkBoxForGibLogo";
            this.checkBoxForGibLogo.Size = new System.Drawing.Size(77, 17);
            this.checkBoxForGibLogo.TabIndex = 24;
            this.checkBoxForGibLogo.Text = "GIB LOGO";
            this.checkBoxForGibLogo.UseVisualStyleBackColor = true;
            // 
            // lblLogoHeight
            // 
            this.lblLogoHeight.AutoSize = true;
            this.lblLogoHeight.Location = new System.Drawing.Point(494, 218);
            this.lblLogoHeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLogoHeight.Name = "lblLogoHeight";
            this.lblLogoHeight.Size = new System.Drawing.Size(85, 13);
            this.lblLogoHeight.TabIndex = 23;
            this.lblLogoHeight.Text = "Yükseklik 120px";
            // 
            // lblLogoWidth
            // 
            this.lblLogoWidth.AutoSize = true;
            this.lblLogoWidth.Location = new System.Drawing.Point(189, 218);
            this.lblLogoWidth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLogoWidth.Name = "lblLogoWidth";
            this.lblLogoWidth.Size = new System.Drawing.Size(106, 13);
            this.lblLogoWidth.TabIndex = 22;
            this.lblLogoWidth.Text = "<-- Genişlik 570px -->";
            // 
            // lblPreviewLogo
            // 
            this.lblPreviewLogo.AutoSize = true;
            this.lblPreviewLogo.Location = new System.Drawing.Point(4, 71);
            this.lblPreviewLogo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPreviewLogo.Name = "lblPreviewLogo";
            this.lblPreviewLogo.Size = new System.Drawing.Size(57, 13);
            this.lblPreviewLogo.TabIndex = 21;
            this.lblPreviewLogo.Text = "PREVIEW";
            // 
            // pbxLogo
            // 
            this.pbxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbxLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxLogo.Location = new System.Drawing.Point(4, 86);
            this.pbxLogo.Margin = new System.Windows.Forms.Padding(2);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(570, 120);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxLogo.TabIndex = 20;
            this.pbxLogo.TabStop = false;
            // 
            // btnSendBitmap
            // 
            this.btnSendBitmap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSendBitmap.Location = new System.Drawing.Point(258, 248);
            this.btnSendBitmap.Margin = new System.Windows.Forms.Padding(2);
            this.btnSendBitmap.Name = "btnSendBitmap";
            this.btnSendBitmap.Size = new System.Drawing.Size(101, 31);
            this.btnSendBitmap.TabIndex = 19;
            this.btnSendBitmap.Text = "SAVE LOGO";
            this.btnSendBitmap.UseVisualStyleBackColor = true;
            this.btnSendBitmap.Click += new System.EventHandler(this.btnSendBitmap_Click);
            // 
            // btnBrowseBmp
            // 
            this.btnBrowseBmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBrowseBmp.Location = new System.Drawing.Point(129, 248);
            this.btnBrowseBmp.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrowseBmp.Name = "btnBrowseBmp";
            this.btnBrowseBmp.Size = new System.Drawing.Size(94, 31);
            this.btnBrowseBmp.TabIndex = 18;
            this.btnBrowseBmp.Text = "BROWSE BITMAP";
            this.btnBrowseBmp.UseVisualStyleBackColor = true;
            this.btnBrowseBmp.Click += new System.EventHandler(this.btnBrowseBmp_Click);
            // 
            // tbpNetwork
            // 
            this.tbpNetwork.Controls.Add(this.chkGateway);
            this.tbpNetwork.Controls.Add(this.chkSubnet);
            this.tbpNetwork.Controls.Add(this.chkIp);
            this.tbpNetwork.Controls.Add(this.label2);
            this.tbpNetwork.Controls.Add(this.txtGateway);
            this.tbpNetwork.Controls.Add(this.txtSubnet);
            this.tbpNetwork.Controls.Add(this.txtIp);
            this.tbpNetwork.Controls.Add(this.lblGateway);
            this.tbpNetwork.Controls.Add(this.lblSubnet);
            this.tbpNetwork.Controls.Add(this.lblTsmIp);
            this.tbpNetwork.Controls.Add(this.btnSaveNetwork);
            this.tbpNetwork.Location = new System.Drawing.Point(4, 22);
            this.tbpNetwork.Margin = new System.Windows.Forms.Padding(2);
            this.tbpNetwork.Name = "tbpNetwork";
            this.tbpNetwork.Padding = new System.Windows.Forms.Padding(2);
            this.tbpNetwork.Size = new System.Drawing.Size(583, 401);
            this.tbpNetwork.TabIndex = 8;
            this.tbpNetwork.Text = "NETWORK SETTINGS";
            this.tbpNetwork.UseVisualStyleBackColor = true;
            // 
            // chkGateway
            // 
            this.chkGateway.AutoSize = true;
            this.chkGateway.Checked = true;
            this.chkGateway.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGateway.Location = new System.Drawing.Point(208, 92);
            this.chkGateway.Margin = new System.Windows.Forms.Padding(2);
            this.chkGateway.Name = "chkGateway";
            this.chkGateway.Size = new System.Drawing.Size(15, 14);
            this.chkGateway.TabIndex = 33;
            this.chkGateway.UseVisualStyleBackColor = true;
            this.chkGateway.CheckedChanged += new System.EventHandler(this.chkIp_CheckedChanged);
            // 
            // chkSubnet
            // 
            this.chkSubnet.AutoSize = true;
            this.chkSubnet.Checked = true;
            this.chkSubnet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSubnet.Location = new System.Drawing.Point(208, 67);
            this.chkSubnet.Margin = new System.Windows.Forms.Padding(2);
            this.chkSubnet.Name = "chkSubnet";
            this.chkSubnet.Size = new System.Drawing.Size(15, 14);
            this.chkSubnet.TabIndex = 32;
            this.chkSubnet.UseVisualStyleBackColor = true;
            this.chkSubnet.CheckedChanged += new System.EventHandler(this.chkIp_CheckedChanged);
            // 
            // chkIp
            // 
            this.chkIp.AutoSize = true;
            this.chkIp.Checked = true;
            this.chkIp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIp.Location = new System.Drawing.Point(208, 40);
            this.chkIp.Margin = new System.Windows.Forms.Padding(2);
            this.chkIp.Name = "chkIp";
            this.chkIp.Size = new System.Drawing.Size(15, 14);
            this.chkIp.TabIndex = 31;
            this.chkIp.UseVisualStyleBackColor = true;
            this.chkIp.CheckedChanged += new System.EventHandler(this.chkIp_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "* Blank field for dynamic IP";
            // 
            // txtGateway
            // 
            this.txtGateway.Location = new System.Drawing.Point(99, 89);
            this.txtGateway.Margin = new System.Windows.Forms.Padding(2);
            this.txtGateway.Name = "txtGateway";
            this.txtGateway.Size = new System.Drawing.Size(105, 20);
            this.txtGateway.TabIndex = 29;
            // 
            // txtSubnet
            // 
            this.txtSubnet.Location = new System.Drawing.Point(99, 62);
            this.txtSubnet.Margin = new System.Windows.Forms.Padding(2);
            this.txtSubnet.Name = "txtSubnet";
            this.txtSubnet.Size = new System.Drawing.Size(105, 20);
            this.txtSubnet.TabIndex = 28;
            this.txtSubnet.Text = "255.255.255.0";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(99, 36);
            this.txtIp.Margin = new System.Windows.Forms.Padding(2);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(105, 20);
            this.txtIp.TabIndex = 27;
            // 
            // lblGateway
            // 
            this.lblGateway.AutoSize = true;
            this.lblGateway.Location = new System.Drawing.Point(25, 91);
            this.lblGateway.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGateway.Name = "lblGateway";
            this.lblGateway.Size = new System.Drawing.Size(55, 13);
            this.lblGateway.TabIndex = 26;
            this.lblGateway.Text = "Gateway :";
            // 
            // lblSubnet
            // 
            this.lblSubnet.AutoSize = true;
            this.lblSubnet.Location = new System.Drawing.Point(25, 66);
            this.lblSubnet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubnet.Name = "lblSubnet";
            this.lblSubnet.Size = new System.Drawing.Size(47, 13);
            this.lblSubnet.TabIndex = 24;
            this.lblSubnet.Text = "Subnet :";
            // 
            // lblTsmIp
            // 
            this.lblTsmIp.AutoSize = true;
            this.lblTsmIp.Location = new System.Drawing.Point(25, 40);
            this.lblTsmIp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTsmIp.Name = "lblTsmIp";
            this.lblTsmIp.Size = new System.Drawing.Size(23, 13);
            this.lblTsmIp.TabIndex = 22;
            this.lblTsmIp.Text = "IP :";
            // 
            // btnSaveNetwork
            // 
            this.btnSaveNetwork.Location = new System.Drawing.Point(93, 133);
            this.btnSaveNetwork.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveNetwork.Name = "btnSaveNetwork";
            this.btnSaveNetwork.Size = new System.Drawing.Size(110, 30);
            this.btnSaveNetwork.TabIndex = 20;
            this.btnSaveNetwork.Text = "Kaydet";
            this.btnSaveNetwork.UseVisualStyleBackColor = true;
            this.btnSaveNetwork.Click += new System.EventHandler(this.btnSaveNetwork_Click);
            // 
            // tabSRVLogo
            // 
            this.tabSRVLogo.Controls.Add(this.btnSaveLogo);
            this.tabSRVLogo.Controls.Add(this.btnGetLogo);
            this.tabSRVLogo.Location = new System.Drawing.Point(4, 22);
            this.tabSRVLogo.Margin = new System.Windows.Forms.Padding(2);
            this.tabSRVLogo.Name = "tabSRVLogo";
            this.tabSRVLogo.Padding = new System.Windows.Forms.Padding(2);
            this.tabSRVLogo.Size = new System.Drawing.Size(583, 401);
            this.tabSRVLogo.TabIndex = 1;
            this.tabSRVLogo.Text = "LOGO";
            this.tabSRVLogo.UseVisualStyleBackColor = true;
            // 
            // btnSaveLogo
            // 
            this.btnSaveLogo.Location = new System.Drawing.Point(123, 201);
            this.btnSaveLogo.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveLogo.Name = "btnSaveLogo";
            this.btnSaveLogo.Size = new System.Drawing.Size(99, 31);
            this.btnSaveLogo.TabIndex = 3;
            this.btnSaveLogo.Text = "SAVE LOGO";
            this.btnSaveLogo.UseVisualStyleBackColor = true;
            this.btnSaveLogo.Click += new System.EventHandler(this.btnSaveLogo_Click);
            // 
            // btnGetLogo
            // 
            this.btnGetLogo.Location = new System.Drawing.Point(8, 201);
            this.btnGetLogo.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetLogo.Name = "btnGetLogo";
            this.btnGetLogo.Size = new System.Drawing.Size(99, 31);
            this.btnGetLogo.TabIndex = 2;
            this.btnGetLogo.Text = "GET LOGO";
            this.btnGetLogo.UseVisualStyleBackColor = true;
            this.btnGetLogo.Click += new System.EventHandler(this.btnGetLogo_Click);
            // 
            // tabSRVVAT
            // 
            this.tabSRVVAT.Controls.Add(this.tableLayoutPanelVAT);
            this.tabSRVVAT.Location = new System.Drawing.Point(4, 22);
            this.tabSRVVAT.Margin = new System.Windows.Forms.Padding(2);
            this.tabSRVVAT.Name = "tabSRVVAT";
            this.tabSRVVAT.Padding = new System.Windows.Forms.Padding(2);
            this.tabSRVVAT.Size = new System.Drawing.Size(583, 401);
            this.tabSRVVAT.TabIndex = 2;
            this.tabSRVVAT.Text = "VAT";
            this.tabSRVVAT.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelVAT
            // 
            this.tableLayoutPanelVAT.ColumnCount = 3;
            this.tableLayoutPanelVAT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelVAT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanelVAT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelVAT.Controls.Add(this.lblVAT, 1, 0);
            this.tableLayoutPanelVAT.Controls.Add(this.dgvVATDefine, 1, 1);
            this.tableLayoutPanelVAT.Controls.Add(this.tableLayoutPanelVATBttns, 1, 2);
            this.tableLayoutPanelVAT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelVAT.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanelVAT.Name = "tableLayoutPanelVAT";
            this.tableLayoutPanelVAT.RowCount = 3;
            this.tableLayoutPanelVAT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.33501F));
            this.tableLayoutPanelVAT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.5592F));
            this.tableLayoutPanelVAT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.8539F));
            this.tableLayoutPanelVAT.Size = new System.Drawing.Size(579, 397);
            this.tableLayoutPanelVAT.TabIndex = 19;
            // 
            // lblVAT
            // 
            this.lblVAT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVAT.AutoSize = true;
            this.lblVAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblVAT.Location = new System.Drawing.Point(226, 15);
            this.lblVAT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVAT.Name = "lblVAT";
            this.lblVAT.Size = new System.Drawing.Size(124, 15);
            this.lblVAT.TabIndex = 18;
            this.lblVAT.Text = "DEFINE VAT RATE";
            // 
            // dgvVATDefine
            // 
            this.dgvVATDefine.AllowUserToAddRows = false;
            this.dgvVATDefine.AllowUserToDeleteRows = false;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVATDefine.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvVATDefine.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVATDefine.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVATDefine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvVATDefine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVATDefine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnVatGroupNum,
            this.clmnVatRate,
            this.clmnSelectedVat});
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVATDefine.DefaultCellStyle = dataGridViewCellStyle22;
            this.dgvVATDefine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVATDefine.Location = new System.Drawing.Point(59, 47);
            this.dgvVATDefine.Margin = new System.Windows.Forms.Padding(2);
            this.dgvVATDefine.Name = "dgvVATDefine";
            this.dgvVATDefine.RowHeadersVisible = false;
            this.dgvVATDefine.RowTemplate.Height = 24;
            this.dgvVATDefine.Size = new System.Drawing.Size(459, 292);
            this.dgvVATDefine.TabIndex = 15;
            // 
            // clmnVatGroupNum
            // 
            this.clmnVatGroupNum.HeaderText = "VAT ID";
            this.clmnVatGroupNum.MaxInputLength = 1;
            this.clmnVatGroupNum.Name = "clmnVatGroupNum";
            this.clmnVatGroupNum.ReadOnly = true;
            // 
            // clmnVatRate
            // 
            this.clmnVatRate.HeaderText = "VAT RATE (%)";
            this.clmnVatRate.MaxInputLength = 3;
            this.clmnVatRate.Name = "clmnVatRate";
            // 
            // clmnSelectedVat
            // 
            this.clmnSelectedVat.HeaderText = "COMMIT?";
            this.clmnSelectedVat.Name = "clmnSelectedVat";
            // 
            // tableLayoutPanelVATBttns
            // 
            this.tableLayoutPanelVATBttns.ColumnCount = 5;
            this.tableLayoutPanelVATBttns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanelVATBttns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelVATBttns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanelVATBttns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelVATBttns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanelVATBttns.Controls.Add(this.btnGetVat, 1, 0);
            this.tableLayoutPanelVATBttns.Controls.Add(this.btnSaveVat, 3, 0);
            this.tableLayoutPanelVATBttns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelVATBttns.Location = new System.Drawing.Point(60, 344);
            this.tableLayoutPanelVATBttns.Name = "tableLayoutPanelVATBttns";
            this.tableLayoutPanelVATBttns.RowCount = 1;
            this.tableLayoutPanelVATBttns.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelVATBttns.Size = new System.Drawing.Size(457, 50);
            this.tableLayoutPanelVATBttns.TabIndex = 19;
            // 
            // btnGetVat
            // 
            this.btnGetVat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetVat.Location = new System.Drawing.Point(33, 2);
            this.btnGetVat.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetVat.Name = "btnGetVat";
            this.btnGetVat.Size = new System.Drawing.Size(178, 46);
            this.btnGetVat.TabIndex = 16;
            this.btnGetVat.Text = "GET VAT";
            this.btnGetVat.UseVisualStyleBackColor = true;
            this.btnGetVat.Click += new System.EventHandler(this.btnGetVat_Click);
            // 
            // btnSaveVat
            // 
            this.btnSaveVat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveVat.Location = new System.Drawing.Point(242, 2);
            this.btnSaveVat.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveVat.Name = "btnSaveVat";
            this.btnSaveVat.Size = new System.Drawing.Size(178, 46);
            this.btnSaveVat.TabIndex = 17;
            this.btnSaveVat.Text = "SAVE VAT";
            this.btnSaveVat.UseVisualStyleBackColor = true;
            this.btnSaveVat.Click += new System.EventHandler(this.btnSaveVat_Click);
            // 
            // tabPageSendProduct
            // 
            this.tabPageSendProduct.Controls.Add(this.tableLayoutPanel1);
            this.tabPageSendProduct.Location = new System.Drawing.Point(4, 22);
            this.tabPageSendProduct.Name = "tabPageSendProduct";
            this.tabPageSendProduct.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSendProduct.Size = new System.Drawing.Size(583, 401);
            this.tabPageSendProduct.TabIndex = 10;
            this.tabPageSendProduct.Text = "SEND PRODUCT";
            this.tabPageSendProduct.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(577, 395);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lblProductFile, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel6, 0, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(60, 62);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.07407F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.259259F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.22222F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.40741F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.77778F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.74074F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(455, 270);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblProductFile
            // 
            this.lblProductFile.AutoSize = true;
            this.lblProductFile.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblProductFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblProductFile.Location = new System.Drawing.Point(2, 46);
            this.lblProductFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProductFile.Name = "lblProductFile";
            this.lblProductFile.Size = new System.Drawing.Size(451, 15);
            this.lblProductFile.TabIndex = 27;
            this.lblProductFile.Text = "PRODUCT FILE :";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.textBoxProductFilePath, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnBrowseProductFile, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 64);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(449, 26);
            this.tableLayoutPanel3.TabIndex = 28;
            // 
            // textBoxProductFilePath
            // 
            this.textBoxProductFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxProductFilePath.Location = new System.Drawing.Point(3, 3);
            this.textBoxProductFilePath.Multiline = true;
            this.textBoxProductFilePath.Name = "textBoxProductFilePath";
            this.textBoxProductFilePath.Size = new System.Drawing.Size(353, 20);
            this.textBoxProductFilePath.TabIndex = 0;
            // 
            // btnBrowseProductFile
            // 
            this.btnBrowseProductFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBrowseProductFile.Location = new System.Drawing.Point(362, 3);
            this.btnBrowseProductFile.Name = "btnBrowseProductFile";
            this.btnBrowseProductFile.Size = new System.Drawing.Size(84, 20);
            this.btnBrowseProductFile.TabIndex = 1;
            this.btnBrowseProductFile.Text = "BROWSE";
            this.btnBrowseProductFile.UseVisualStyleBackColor = true;
            this.btnBrowseProductFile.Click += new System.EventHandler(this.btnBrowseProductFile_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel4.Controls.Add(this.labelTotalLineValue, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelTotalLine, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 96);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(449, 40);
            this.tableLayoutPanel4.TabIndex = 29;
            // 
            // labelTotalLineValue
            // 
            this.labelTotalLineValue.AutoSize = true;
            this.labelTotalLineValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTotalLineValue.Location = new System.Drawing.Point(114, 0);
            this.labelTotalLineValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTotalLineValue.Name = "labelTotalLineValue";
            this.labelTotalLineValue.Size = new System.Drawing.Size(39, 15);
            this.labelTotalLineValue.TabIndex = 29;
            this.labelTotalLineValue.Text = "0000";
            // 
            // labelTotalLine
            // 
            this.labelTotalLine.AutoSize = true;
            this.labelTotalLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTotalLine.Location = new System.Drawing.Point(2, 0);
            this.labelTotalLine.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTotalLine.Name = "labelTotalLine";
            this.labelTotalLine.Size = new System.Drawing.Size(92, 15);
            this.labelTotalLine.TabIndex = 28;
            this.labelTotalLine.Text = "TOTAL LINE :";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel5.Controls.Add(this.btnSendProducts, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 142);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(449, 41);
            this.tableLayoutPanel5.TabIndex = 30;
            // 
            // btnSendProducts
            // 
            this.btnSendProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSendProducts.Location = new System.Drawing.Point(182, 3);
            this.btnSendProducts.Name = "btnSendProducts";
            this.btnSendProducts.Size = new System.Drawing.Size(83, 35);
            this.btnSendProducts.TabIndex = 0;
            this.btnSendProducts.Text = "SEND";
            this.btnSendProducts.UseVisualStyleBackColor = true;
            this.btnSendProducts.Click += new System.EventHandler(this.btnSendProducts_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.Controls.Add(this.progressBarSendProd, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.labelUnderProgressBar, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.labelElapsedTime, 2, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 189);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(449, 78);
            this.tableLayoutPanel6.TabIndex = 31;
            // 
            // progressBarSendProd
            // 
            this.progressBarSendProd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBarSendProd.Location = new System.Drawing.Point(92, 18);
            this.progressBarSendProd.Name = "progressBarSendProd";
            this.progressBarSendProd.Size = new System.Drawing.Size(263, 40);
            this.progressBarSendProd.TabIndex = 0;
            // 
            // labelUnderProgressBar
            // 
            this.labelUnderProgressBar.AutoSize = true;
            this.labelUnderProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUnderProgressBar.Location = new System.Drawing.Point(92, 61);
            this.labelUnderProgressBar.Name = "labelUnderProgressBar";
            this.labelUnderProgressBar.Size = new System.Drawing.Size(263, 17);
            this.labelUnderProgressBar.TabIndex = 1;
            // 
            // labelElapsedTime
            // 
            this.labelElapsedTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelElapsedTime.AutoSize = true;
            this.labelElapsedTime.Location = new System.Drawing.Point(403, 31);
            this.labelElapsedTime.Name = "labelElapsedTime";
            this.labelElapsedTime.Size = new System.Drawing.Size(0, 13);
            this.labelElapsedTime.TabIndex = 2;
            // 
            // tabPageEndOfReceiptNote
            // 
            this.tabPageEndOfReceiptNote.Controls.Add(this.tableLayoutPanel7);
            this.tabPageEndOfReceiptNote.Location = new System.Drawing.Point(4, 22);
            this.tabPageEndOfReceiptNote.Name = "tabPageEndOfReceiptNote";
            this.tabPageEndOfReceiptNote.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEndOfReceiptNote.Size = new System.Drawing.Size(583, 401);
            this.tabPageEndOfReceiptNote.TabIndex = 11;
            this.tabPageEndOfReceiptNote.Text = "END OF RECEIPT NOTE";
            this.tabPageEndOfReceiptNote.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 1, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(577, 395);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel8.Controls.Add(this.textBoxEORLine6, 1, 5);
            this.tableLayoutPanel8.Controls.Add(this.textBoxEORLine5, 1, 4);
            this.tableLayoutPanel8.Controls.Add(this.textBoxEORLine4, 1, 3);
            this.tableLayoutPanel8.Controls.Add(this.textBoxEORLine3, 1, 2);
            this.tableLayoutPanel8.Controls.Add(this.textBoxEORLine2, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.labelEORLine1, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.labelEORLine2, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.labelEORLine3, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.labelEORLine4, 0, 3);
            this.tableLayoutPanel8.Controls.Add(this.labelEORLine5, 0, 4);
            this.tableLayoutPanel8.Controls.Add(this.labelEORLine6, 0, 5);
            this.tableLayoutPanel8.Controls.Add(this.checkBoxEORLine1, 2, 0);
            this.tableLayoutPanel8.Controls.Add(this.checkBoxEORLine2, 2, 1);
            this.tableLayoutPanel8.Controls.Add(this.checkBoxEORLine3, 2, 2);
            this.tableLayoutPanel8.Controls.Add(this.checkBoxEORLine4, 2, 3);
            this.tableLayoutPanel8.Controls.Add(this.checkBoxEORLine5, 2, 4);
            this.tableLayoutPanel8.Controls.Add(this.checkBoxEORLine6, 2, 5);
            this.tableLayoutPanel8.Controls.Add(this.textBoxEORLine1, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel9, 1, 7);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(31, 22);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 8;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(513, 349);
            this.tableLayoutPanel8.TabIndex = 0;
            // 
            // textBoxEORLine6
            // 
            this.textBoxEORLine6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxEORLine6.Location = new System.Drawing.Point(85, 177);
            this.textBoxEORLine6.Name = "textBoxEORLine6";
            this.textBoxEORLine6.Size = new System.Drawing.Size(341, 20);
            this.textBoxEORLine6.TabIndex = 17;
            // 
            // textBoxEORLine5
            // 
            this.textBoxEORLine5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxEORLine5.Location = new System.Drawing.Point(85, 143);
            this.textBoxEORLine5.Name = "textBoxEORLine5";
            this.textBoxEORLine5.Size = new System.Drawing.Size(341, 20);
            this.textBoxEORLine5.TabIndex = 16;
            // 
            // textBoxEORLine4
            // 
            this.textBoxEORLine4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxEORLine4.Location = new System.Drawing.Point(85, 109);
            this.textBoxEORLine4.Name = "textBoxEORLine4";
            this.textBoxEORLine4.Size = new System.Drawing.Size(341, 20);
            this.textBoxEORLine4.TabIndex = 15;
            // 
            // textBoxEORLine3
            // 
            this.textBoxEORLine3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxEORLine3.Location = new System.Drawing.Point(85, 75);
            this.textBoxEORLine3.Name = "textBoxEORLine3";
            this.textBoxEORLine3.Size = new System.Drawing.Size(341, 20);
            this.textBoxEORLine3.TabIndex = 14;
            // 
            // textBoxEORLine2
            // 
            this.textBoxEORLine2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxEORLine2.Location = new System.Drawing.Point(85, 41);
            this.textBoxEORLine2.Name = "textBoxEORLine2";
            this.textBoxEORLine2.Size = new System.Drawing.Size(341, 20);
            this.textBoxEORLine2.TabIndex = 13;
            // 
            // labelEORLine1
            // 
            this.labelEORLine1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEORLine1.AutoSize = true;
            this.labelEORLine1.Location = new System.Drawing.Point(18, 10);
            this.labelEORLine1.Name = "labelEORLine1";
            this.labelEORLine1.Size = new System.Drawing.Size(39, 13);
            this.labelEORLine1.TabIndex = 0;
            this.labelEORLine1.Text = "Line 1:";
            // 
            // labelEORLine2
            // 
            this.labelEORLine2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEORLine2.AutoSize = true;
            this.labelEORLine2.Location = new System.Drawing.Point(18, 44);
            this.labelEORLine2.Name = "labelEORLine2";
            this.labelEORLine2.Size = new System.Drawing.Size(39, 13);
            this.labelEORLine2.TabIndex = 1;
            this.labelEORLine2.Text = "Line 2:";
            // 
            // labelEORLine3
            // 
            this.labelEORLine3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEORLine3.AutoSize = true;
            this.labelEORLine3.Location = new System.Drawing.Point(18, 78);
            this.labelEORLine3.Name = "labelEORLine3";
            this.labelEORLine3.Size = new System.Drawing.Size(39, 13);
            this.labelEORLine3.TabIndex = 2;
            this.labelEORLine3.Text = "Line 3:";
            // 
            // labelEORLine4
            // 
            this.labelEORLine4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEORLine4.AutoSize = true;
            this.labelEORLine4.Location = new System.Drawing.Point(18, 112);
            this.labelEORLine4.Name = "labelEORLine4";
            this.labelEORLine4.Size = new System.Drawing.Size(39, 13);
            this.labelEORLine4.TabIndex = 3;
            this.labelEORLine4.Text = "Line 4:";
            // 
            // labelEORLine5
            // 
            this.labelEORLine5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEORLine5.AutoSize = true;
            this.labelEORLine5.Location = new System.Drawing.Point(18, 146);
            this.labelEORLine5.Name = "labelEORLine5";
            this.labelEORLine5.Size = new System.Drawing.Size(39, 13);
            this.labelEORLine5.TabIndex = 4;
            this.labelEORLine5.Text = "Line 5:";
            // 
            // labelEORLine6
            // 
            this.labelEORLine6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEORLine6.AutoSize = true;
            this.labelEORLine6.Location = new System.Drawing.Point(18, 180);
            this.labelEORLine6.Name = "labelEORLine6";
            this.labelEORLine6.Size = new System.Drawing.Size(39, 13);
            this.labelEORLine6.TabIndex = 5;
            this.labelEORLine6.Text = "Line 6:";
            // 
            // checkBoxEORLine1
            // 
            this.checkBoxEORLine1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxEORLine1.AutoSize = true;
            this.checkBoxEORLine1.Location = new System.Drawing.Point(439, 8);
            this.checkBoxEORLine1.Name = "checkBoxEORLine1";
            this.checkBoxEORLine1.Size = new System.Drawing.Size(69, 17);
            this.checkBoxEORLine1.TabIndex = 6;
            this.checkBoxEORLine1.Text = "KAYDET";
            this.checkBoxEORLine1.UseVisualStyleBackColor = true;
            // 
            // checkBoxEORLine2
            // 
            this.checkBoxEORLine2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxEORLine2.AutoSize = true;
            this.checkBoxEORLine2.Location = new System.Drawing.Point(439, 42);
            this.checkBoxEORLine2.Name = "checkBoxEORLine2";
            this.checkBoxEORLine2.Size = new System.Drawing.Size(69, 17);
            this.checkBoxEORLine2.TabIndex = 7;
            this.checkBoxEORLine2.Text = "KAYDET";
            this.checkBoxEORLine2.UseVisualStyleBackColor = true;
            // 
            // checkBoxEORLine3
            // 
            this.checkBoxEORLine3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxEORLine3.AutoSize = true;
            this.checkBoxEORLine3.Location = new System.Drawing.Point(439, 76);
            this.checkBoxEORLine3.Name = "checkBoxEORLine3";
            this.checkBoxEORLine3.Size = new System.Drawing.Size(69, 17);
            this.checkBoxEORLine3.TabIndex = 8;
            this.checkBoxEORLine3.Text = "KAYDET";
            this.checkBoxEORLine3.UseVisualStyleBackColor = true;
            // 
            // checkBoxEORLine4
            // 
            this.checkBoxEORLine4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxEORLine4.AutoSize = true;
            this.checkBoxEORLine4.Location = new System.Drawing.Point(439, 110);
            this.checkBoxEORLine4.Name = "checkBoxEORLine4";
            this.checkBoxEORLine4.Size = new System.Drawing.Size(69, 17);
            this.checkBoxEORLine4.TabIndex = 9;
            this.checkBoxEORLine4.Text = "KAYDET";
            this.checkBoxEORLine4.UseVisualStyleBackColor = true;
            // 
            // checkBoxEORLine5
            // 
            this.checkBoxEORLine5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxEORLine5.AutoSize = true;
            this.checkBoxEORLine5.Location = new System.Drawing.Point(439, 144);
            this.checkBoxEORLine5.Name = "checkBoxEORLine5";
            this.checkBoxEORLine5.Size = new System.Drawing.Size(69, 17);
            this.checkBoxEORLine5.TabIndex = 10;
            this.checkBoxEORLine5.Text = "KAYDET";
            this.checkBoxEORLine5.UseVisualStyleBackColor = true;
            // 
            // checkBoxEORLine6
            // 
            this.checkBoxEORLine6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxEORLine6.AutoSize = true;
            this.checkBoxEORLine6.Location = new System.Drawing.Point(439, 178);
            this.checkBoxEORLine6.Name = "checkBoxEORLine6";
            this.checkBoxEORLine6.Size = new System.Drawing.Size(69, 17);
            this.checkBoxEORLine6.TabIndex = 11;
            this.checkBoxEORLine6.Text = "KAYDET";
            this.checkBoxEORLine6.UseVisualStyleBackColor = true;
            // 
            // textBoxEORLine1
            // 
            this.textBoxEORLine1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxEORLine1.Location = new System.Drawing.Point(85, 7);
            this.textBoxEORLine1.Name = "textBoxEORLine1";
            this.textBoxEORLine1.Size = new System.Drawing.Size(341, 20);
            this.textBoxEORLine1.TabIndex = 12;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 3;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel10, 1, 1);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(79, 241);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 3;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(353, 105);
            this.tableLayoutPanel9.TabIndex = 18;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 3;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel10.Controls.Add(this.buttonEORGet, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.buttonEORSet, 2, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(38, 13);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(276, 78);
            this.tableLayoutPanel10.TabIndex = 0;
            // 
            // buttonEORGet
            // 
            this.buttonEORGet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEORGet.Location = new System.Drawing.Point(3, 3);
            this.buttonEORGet.Name = "buttonEORGet";
            this.buttonEORGet.Size = new System.Drawing.Size(104, 72);
            this.buttonEORGet.TabIndex = 0;
            this.buttonEORGet.Text = "GET";
            this.buttonEORGet.UseVisualStyleBackColor = true;
            this.buttonEORGet.Click += new System.EventHandler(this.buttonEORGet_Click);
            // 
            // buttonEORSet
            // 
            this.buttonEORSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEORSet.Location = new System.Drawing.Point(168, 3);
            this.buttonEORSet.Name = "buttonEORSet";
            this.buttonEORSet.Size = new System.Drawing.Size(105, 72);
            this.buttonEORSet.TabIndex = 1;
            this.buttonEORSet.Text = "SET";
            this.buttonEORSet.UseVisualStyleBackColor = true;
            this.buttonEORSet.Click += new System.EventHandler(this.buttonEORSet_Click);
            // 
            // ProgramUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbcProgram);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProgramUC";
            this.tbcProgram.ResumeLayout(false);
            this.tbpDepTax.ResumeLayout(false);
            this.tableLayoutPanelTabDepartment.ResumeLayout(false);
            this.tableLayoutPanelTabDepartment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepDefine)).EndInit();
            this.tableLayoutPanelDptButtons.ResumeLayout(false);
            this.tbpPLU.ResumeLayout(false);
            this.tbpPLU.PerformLayout();
            this.tableLayoutPanelTabPLU.ResumeLayout(false);
            this.tableLayoutPanelTabPLU.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPLUDefine)).EndInit();
            this.tableLayoutPanelPLUButtons.ResumeLayout(false);
            this.tableLayoutPanelPLUButtons.PerformLayout();
            this.tbpCredit.ResumeLayout(false);
            this.tableLayoutPanelTabCredit.ResumeLayout(false);
            this.tableLayoutPanelTabCredit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCredits)).EndInit();
            this.tableLayoutPanelCreditButtons.ResumeLayout(false);
            this.tableLayoutPanelFCurrencyButtons.ResumeLayout(false);
            this.tbpCategory.ResumeLayout(false);
            this.tableLayoutPanelTabCategory.ResumeLayout(false);
            this.tableLayoutPanelTabCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainCategory)).EndInit();
            this.tableLayoutPanelMainGrBttns.ResumeLayout(false);
            this.tbpCashier.ResumeLayout(false);
            this.tableLayoutPanelTabCashier.ResumeLayout(false);
            this.tableLayoutPanelTabCashier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashier)).EndInit();
            this.tableLayoutPanelCashierBttns.ResumeLayout(false);
            this.tbpProgramOption.ResumeLayout(false);
            this.tableLayoutPanelProgOpt.ResumeLayout(false);
            this.tableLayoutPanelProgOpt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrmOption)).EndInit();
            this.tableLayoutPanelProgOptBttns.ResumeLayout(false);
            this.tbpBitmapLogo.ResumeLayout(false);
            this.tbpBitmapLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.tbpNetwork.ResumeLayout(false);
            this.tbpNetwork.PerformLayout();
            this.tabSRVLogo.ResumeLayout(false);
            this.tabSRVVAT.ResumeLayout(false);
            this.tableLayoutPanelVAT.ResumeLayout(false);
            this.tableLayoutPanelVAT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVATDefine)).EndInit();
            this.tableLayoutPanelVATBttns.ResumeLayout(false);
            this.tabPageSendProduct.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tabPageEndOfReceiptNote.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region COMMON

        private Control GetControlByName(string name)
        {
            return this.Controls.Find(name, true)[0];
        }

        #endregion COMMON

        #region CREDITS
        private void btnGetCredits_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ProgramConfig.MAX_CREDIT_COUNT; i++)
            {
                try
                {
                    dgvCredits.Rows[i].Cells[clmnIndex.Index].Value = i + 1;

                    CPResponse response = new CPResponse(bridge.Printer.GetCreditInfo(i));

                    if (response.ErrorCode == 0)
                    {
                        string paramVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(paramVal))
                        {
                            String name = paramVal;
                            dgvCredits.Rows[i].Cells[clmnCreditName.Name].Value = (name);
                            MainForm.SetCredit(i, name);
                        }
                    }
                    else
                        dgvCredits.Rows[i].Cells[clmnCreditName.Name].Value = "";
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
        }

        private void btnSaveCredits_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ProgramConfig.MAX_CREDIT_COUNT; i++)
            {
                try
                {
                    DataGridViewCheckBoxCell selectedCell = (DataGridViewCheckBoxCell)dgvCredits.Rows[i].Cells[clmnSelected.Name];
                    if (selectedCell.Value != null && (bool)selectedCell.Value == true)
                    {
                        String name = dgvCredits.Rows[i].Cells[clmnCreditName.Index].Value.ToString();

                        CPResponse response = new CPResponse(bridge.Printer.SetCreditInfo(i, name));

                        if (response.ErrorCode == 0)
                        {
                            string paramVal = response.GetNextParam();
                            if (!String.IsNullOrEmpty(paramVal))
                            {
                                dgvCredits.Rows[i].Cells[clmnCreditName.Name].Value = paramVal;
                            }                         
                        }
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

        }
        #endregion CREDIT

        #region DEPARTMENT
        private void btnGetDepartment_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ProgramConfig.MAX_DEPARTMENT_COUNT; i++)
            {
                try
                {
                    CPResponse response = new CPResponse(bridge.Printer.GetDepartment(i+1));


                    if (response.ErrorCode != 0)
                    {
                        return;
                    }

                    // Department Name
                    string paramVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(paramVal))
                    {
                        dgvDepDefine.Rows[i].Cells[clmnDeptName.Index].Value = paramVal;
                    }
                    // Vat Group
                    paramVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(paramVal))
                    {
                        dgvDepDefine.Rows[i].Cells[clmnDeptVatId.Index].Value = paramVal;
                    }
                    // Price
                    paramVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(paramVal))
                    {
                        dgvDepDefine.Rows[i].Cells[clmnDeptPrice.Index].Value = paramVal;
                    }
                    // Weighable
                    paramVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(paramVal))
                    {
                        DataGridViewCheckBoxCell weighableCell =
                            (DataGridViewCheckBoxCell)dgvDepDefine.Rows[i].Cells[clmnDeptWeighable.Index];
                        weighableCell.Value = int.Parse(paramVal) == 1 ? true : false;
                    }
                    // Limit
                    paramVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(paramVal))
                    {
                        dgvDepDefine.Rows[i].Cells[clmnDeptLimit.Index].Value = paramVal;
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
        }

        private void btnSaveDepartment_Click(object sender, EventArgs e)
        {
            DataGridViewCheckBoxCell selectedCell;
            for (int i = 0; i < ProgramConfig.MAX_DEPARTMENT_COUNT; i++)
            {
                selectedCell = (DataGridViewCheckBoxCell)dgvDepDefine.Rows[i].Cells[clmnSelectDepartment.Index];
                if (selectedCell.Value != null && (bool)selectedCell.Value == true)
                {

                    try
                    {
                        //DEPARTMENT NO
                        int deptNo = Convert.ToInt32(dgvDepDefine.Rows[i].Cells[clmnDeptNo.Index].Value);

                        //DEPT NAME
                        String deptName = (String)dgvDepDefine.Rows[i].Cells[clmnDeptName.Index].Value;

                        //VAT GROUP
                        int vatGrpNo = Convert.ToInt32(dgvDepDefine.Rows[i].Cells[clmnDeptVatId.Index].Value);

                        //PRICE
                        decimal price = Convert.ToDecimal(dgvDepDefine.Rows[i].Cells[clmnDeptPrice.Index].Value);

                        // LIMIT
                        decimal limit = Convert.ToDecimal(dgvDepDefine.Rows[i].Cells[clmnDeptLimit.Index].Value);

                        //WEIGHABLE
                        selectedCell = (DataGridViewCheckBoxCell)dgvDepDefine.Rows[i].Cells[clmnDeptWeighable.Index];
                        int weighable = 0;
                        if (selectedCell.Value != null && ((bool)selectedCell.Value))
                        {
                            weighable = 1;
                        }

                        // Send Department Command
                        CPResponse response = new CPResponse(bridge.Printer.SetDepartment(deptNo, deptName,
                                                                vatGrpNo, price, weighable, limit));

                        if (response.ErrorCode != 0)
                        {
                            return;
                        }

                        // Department Name
                        string paramVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(paramVal))
                        {
                            dgvDepDefine.Rows[i].Cells[clmnDeptName.Index].Value = paramVal;
                        }
                        // Vat Group
                        paramVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(paramVal))
                        {
                            dgvDepDefine.Rows[i].Cells[clmnDeptVatId.Index].Value = paramVal;
                        }
                        // Price
                        paramVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(paramVal))
                        {
                            dgvDepDefine.Rows[i].Cells[clmnDeptPrice.Index].Value = paramVal;
                        }
                        // Weighable
                        paramVal = response.GetNextParam();
                        if (!String.IsNullOrEmpty(paramVal))
                        {
                            DataGridViewCheckBoxCell weighableCell =
                                (DataGridViewCheckBoxCell)dgvDepDefine.Rows[i].Cells[clmnDeptWeighable.Index];
                            weighableCell.Value = int.Parse(paramVal) == 1 ? true : false;
                        }
                        // Limit
                        paramVal = response.GetNextParam();
                        if(!String.IsNullOrEmpty(paramVal))
                        {
                            dgvDepDefine.Rows[i].Cells[clmnDeptLimit.Index].Value = paramVal;
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
            }
        }
        #endregion DEPARTMENT

        #region PRODUCT
        private void btnGetPLU_Click(object sender, EventArgs e)
        {
            Product p = null;
            try
            {
                dgvPLUDefine.Rows.Clear();

                CPResponse response = null;
                string[] splittedValues = txtPluAddress.Text.Split(new char[] { ',' });
                foreach (String value in splittedValues)
                {
                    if (value.Contains("-"))
                    {
                        string[] spltRange = value.Split(new char[] { '-' });
                        int first = int.Parse(spltRange[0]);
                        int end = int.Parse(spltRange[1]);

                        for (int i = first; i <= end; i++)
                        {
                            response = new CPResponse(bridge.Printer.GetProduct(i));

                            if (response.ErrorCode == 0)
                            {
                                p = new Product();
                                p.PluNo = i;
                                p.Name = response.GetNextParam();
                                p.Department = int.Parse(response.GetNextParam());
                                p.Price = decimal.Parse(response.GetNextParam());
                                p.Weighable = int.Parse(response.GetNextParam());
                                p.Barcode = response.GetNextParam();
                                p.SubCategory = int.Parse(response.GetNextParam());

                                AddPLURow(p);
                            }
                        }
                    }
                    else
                    {
                        response = new CPResponse(bridge.Printer.GetProduct(int.Parse(value)));

                        if (response.ErrorCode == 0)
                        {
                            p = new Product();
                            p.PluNo = Convert.ToInt32(value);
                            p.Name = response.GetNextParam();
                            p.Department = int.Parse(response.GetNextParam());
                            p.Price = decimal.Parse(response.GetNextParam());
                            p.Weighable = int.Parse(response.GetNextParam());
                            p.Barcode = response.GetNextParam();
                            p.SubCategory = int.Parse(response.GetNextParam());

                            AddPLURow(p);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                bridge.Log(FormMessage.PRODUCT_COULD_NOT_BE_READ + " " + ex.Message);
            }
        }

        private void AddPLURow(Product p)
        {
            if (dgvPLUDefine.Rows.Count % 10 == 0)
            {
                Application.DoEvents();
            }

            int index = dgvPLUDefine.Rows.Add();
            dgvPLUDefine.Rows[index].Cells[clmnPLUNo.Index].Value = p.PluNo;
            dgvPLUDefine.Rows[index].Cells[clmnPLUName.Index].Value = p.Name;
            dgvPLUDefine.Rows[index].Cells[clmnPLUDeptNo.Index].Value = p.Department;
            dgvPLUDefine.Rows[index].Cells[clmnPLUPrice.Index].Value = p.Price.ToString("#0.00");
            ((DataGridViewCheckBoxCell)dgvPLUDefine.Rows[index].Cells[clmnPLUWeighable.Index]).Value = (bool)(p.Weighable == 1);
            dgvPLUDefine.Rows[index].Cells[clmnPLUBarcode.Index].Value = p.Barcode;
            dgvPLUDefine.Rows[index].Cells[clmnPLUSubCat.Index].Value = p.SubCategory;
        }

        private void btnSavePLU_Click(object sender, EventArgs e)
        {
            DataGridViewCheckBoxCell selectedCell;
            for (int i = 0; i < dgvPLUDefine.Rows.Count; i++)
            {
                try
                {
                    selectedCell = (DataGridViewCheckBoxCell)dgvPLUDefine.Rows[i].Cells[clmnPLUSelected.Index];
                    if (selectedCell.Value != null && (bool)selectedCell.Value == true)
                    {
                        List<byte> bytes = new List<byte>();
                        //PRODUCT ID 
                        int pluNo = Convert.ToInt32(dgvPLUDefine.Rows[i].Cells[clmnPLUNo.Index].Value);

                        //NAME
                        String pluName = (String)dgvPLUDefine.Rows[i].Cells[clmnPLUName.Index].Value;

                        //DEPT ID
                        int deptId = Convert.ToInt32(dgvPLUDefine.Rows[i].Cells[clmnPLUDeptNo.Index].Value);

                        //PRICE
                        decimal price = Convert.ToDecimal(dgvPLUDefine.Rows[i].Cells[clmnPLUPrice.Index].Value);

                        //WEIGHABLE
                        selectedCell = (DataGridViewCheckBoxCell)dgvPLUDefine.Rows[i].Cells[clmnPLUWeighable.Index];
                        int weighable = 0;
                        if (selectedCell.Value != null && ((bool)selectedCell.Value))
                        {
                            weighable = 1;
                        }

                        //BARCODE
                        String barcode = (String)dgvPLUDefine.Rows[i].Cells[clmnPLUBarcode.Index].Value;

                        //SUB CAT ID
                        int subCatId = Convert.ToInt32(dgvPLUDefine.Rows[i].Cells[clmnPLUSubCat.Index].Value);


                        // Send Department Command
                        CPResponse response = new CPResponse(bridge.Printer.SaveProduct(pluNo, pluName, deptId, 
                                                    price, weighable, barcode, subCatId));

                        if (response.ErrorCode == 0)
                        {
                            Product p = new Product();
                            p.Name = response.GetNextParam();
                            p.Department = int.Parse(response.GetNextParam());
                            p.Price = decimal.Parse(response.GetNextParam());
                            p.Weighable = int.Parse(response.GetNextParam());
                            p.Barcode = response.GetNextParam();
                            p.SubCategory = int.Parse(response.GetNextParam());

                            bridge.Log(String.Format("{6}:{0,-20} {7}: {1,2} {8}: {2:#0.00} {9}:{3} {10}: {4,-20} {11}:{5}",
                                p.Name,
                                p.Department,
                                p.Price,
                                p.Weighable == 1 ? "E" : "H",
                                p.Barcode,
                                p.SubCategory,
                                FormMessage.PLU_NAME,
                                FormMessage.DEPARTMENT_ID,
                                FormMessage.PRICE,
                                FormMessage.WEIGHABLE,
                                FormMessage.BARCODE,
                                FormMessage.SUB_CATEGORY));
                        }
                    }
                }
                catch (Exception ex)
                {
                    bridge.Log(FormMessage.PRODUCT_COULD_NOT_BE_SAVED + " " + ex.Message);
                }
            }

        }

        private void lblInfoPLU_Click(object sender, EventArgs e)
        {
            MessageBox.Show(FormMessage.INFO_PLU_CLICK_1 + "\n" +
                            FormMessage.INFO_PLU_CLICK_2 + "\n" +
                            FormMessage.INFO_PLU_CLICK_3 + "\n" +
                            FormMessage.INFO_PLU_CLICK_4);
        }
        #endregion PRODUCT

        #region MAIN_CATEGORY
        private void btnGetMainCategory_Click(object sender, EventArgs e)
        {
            dgvMainCategory.Rows.Clear();
            for (int i = 0; i < ProgramConfig.MAX_MAIN_CATEGORY_COUNT; i++)
            {
                try
                {
                    if (i % 5 == 0)
                    {
                        Application.DoEvents();
                    }

                    CPResponse response = new CPResponse(bridge.Printer.GetMainCategory(i));

                    if (response.ErrorCode == 0)
                    {
                        int mainCatId = int.Parse(response.GetNextParam());
                        int index = dgvMainCategory.Rows.Add();
                        dgvMainCategory.Rows[index].Cells[clmnMainGrupNo.Index].Value = mainCatId + 1;
                        dgvMainCategory.Rows[index].Cells[clmnMainGrupName.Index].Value = response.GetNextParam();
                    }
                }
                catch (System.Exception)
                {
                    bridge.Log(FormMessage.MAIN_CATEGORY_NOT_SAVED);
                }
            }
        }
        private void btnSaveMainCategory_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ProgramConfig.MAX_MAIN_CATEGORY_COUNT; i++)
            {
                try
                {
                    DataGridViewCheckBoxCell selected = (DataGridViewCheckBoxCell)dgvMainCategory.Rows[i].Cells[clmnMainGrupSelect.Index];
                    if (selected.Value != null && (bool)selected.Value == true)
                    {                      
                        //NAME
                        String name = (String)dgvMainCategory.Rows[i].Cells[clmnMainGrupName.Index].Value;

                        CPResponse response = new CPResponse(bridge.Printer.SetMainCategory(i, name));

                        if (response.ErrorCode == 0)
                        {
                            int mcCatNo = i + 1;
                            string mcName = response.GetNextParam();
                            bridge.Log(String.Format("{2}: {0} {3}:{1} ",
                                mcCatNo,
                                mcName,
                                FormMessage.GROUP_ID,
                                FormMessage.GROUP_NAME));
                        }
                    }
                }
                catch (System.Exception)
                {
                    bridge.Log(FormMessage.MAIN_CAT_NOT_GET);
                }
            }
        }

        #endregion MAIN_CATEGORY

        #region CASHIER
        private void btnGetCashier_Click(object sender, EventArgs e)
        {
            dgvCashier.Rows.Clear();
            for (int i = 0; i < ProgramConfig.MAX_CASHIER_COUNT; i++)
            {
                try
                {
                    CPResponse response = new CPResponse(bridge.Printer.GetCashier(i+1));

                    if (response.ErrorCode == 0)
                    {
                        Cashier c = new Cashier();
                        c.Name = response.GetNextParam();
                        int index = dgvCashier.Rows.Add();
                        dgvCashier.Rows[index].Cells[clmnCashierIndex.Index].Value = i + 1;
                        dgvCashier.Rows[index].Cells[clmnCashierName.Index].Value = c.Name;
                        dgvCashier.Rows[index].Cells[clmnCashierPassword.Index].Value = c.Password;
                    }
                }
                catch (System.Exception)
                {
                    bridge.Log(FormMessage.OPERATION_FAILS);
                }
            }

        }

        private void btnSaveCashier_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ProgramConfig.MAX_CASHIER_COUNT; i++)
            {
                try
                {
                    DataGridViewCheckBoxCell selected = (DataGridViewCheckBoxCell)dgvCashier.Rows[i].Cells[clmnCashierSelect.Index];
                    if (selected.Value != null && (bool)selected.Value == true)
                    {
                        //NAME
                        String name = (String)dgvCashier.Rows[i].Cells[clmnCashierName.Index].Value;

                        //PASSWORD
                        string password = string.Empty;
                        if (!String.IsNullOrEmpty((string)dgvCashier.Rows[i].Cells[clmnCashierPassword.Index].Value))
                        {
                            password = Convert.ToInt32(dgvCashier.Rows[i].Cells[clmnCashierPassword.Index].Value).ToString();
                        }

                        CPResponse response = new CPResponse(bridge.Printer.SaveCashier(i+1, name, password));

                        if (response.ErrorCode == 0)
                        {
                            Cashier c = new Cashier();
                            c.Id = i + 1;
                            c.Name = response.GetNextParam();
                            bridge.Log(String.Format("{2}: {0} {3}:{1}",
                                c.Id,
                                c.Name,
                                FormMessage.CASHIER_ID,
                                FormMessage.CASHIER_NAME
                                ));
                        }
                    }
                }
                catch (System.Exception)
                {
                    bridge.Log(FormMessage.OPERATION_FAILS);
                }
            }

        }

        #endregion CASHIER

        #region PROGRAM_OPTION
        private void btnGetPrmOption_Click(object sender, EventArgs e)
        {
            string[] names = Enum.GetNames(typeof(Settings));

            dgvPrmOption.Rows.Clear();
            for (int i = 0; i < names.Length; i++)
            {
                try
                {
                    CPResponse response = new CPResponse(bridge.Printer.GetProgramOptions(i));

                    if (response.ErrorCode == 0)
                    {
                        int index = dgvPrmOption.Rows.Add();
                        dgvPrmOption.Rows[index].Cells[clmnPONo.Index].Value = i+1;
                        dgvPrmOption.Rows[index].Cells[clmnPOName.Index].Value = names[i];
                        dgvPrmOption.Rows[index].Cells[clmnPOValue.Index].Value = response.GetNextParam();
                    }
                }
                catch (System.Exception)
                {
                    bridge.Log(FormMessage.OPERATION_FAILS);
                }
            }
        }

        private void btnSavePrmOption_Click(object sender, EventArgs e)
        {
            string[] names = Enum.GetNames(typeof(Settings));

            for (int i = 0; i < names.Length; i++)
            {
                try
                {
                    DataGridViewCheckBoxCell selected = (DataGridViewCheckBoxCell)dgvPrmOption.Rows[i].Cells[clmnPOSelect.Index];
                    if (selected.Value != null && (bool)selected.Value == true)
                    {
                        //Prop No
                        int name = (int)(dgvPrmOption.Rows[i].Cells[clmnPONo.Index].Value)-1;

                        //Prop Value
                        String value = (String)dgvPrmOption.Rows[i].Cells[clmnPOValue.Index].Value;
                        //switch ((Settings)i)
                        //{
                        //    case Settings.RECEIPT_LIMIT:
                        //        String[] spltValue = value.Split(new char[] { ',' });                   
                        //        value = String.Format("{0}{1}", spltValue[0], spltValue[1].PadRight(3, '0'));
                        //        break;
                        //}

                        CPResponse response = new CPResponse(bridge.Printer.SaveProgramOptions(name, value));

                        if (response.ErrorCode == 0)
                        {
                            
                            bridge.Log(String.Format("{2}: {0} {3}:{1}",
                                i + 1,
                                response.GetNextParam(),
                                FormMessage.PROG_OPT_ID,
                                FormMessage.PROG_OPT_VALUE
                                ));
                        }
                    }
                }
                catch (System.Exception)
                {
                    bridge.Log(FormMessage.OPERATION_FAILS);
                }
            }
        }

        #endregion PROGRAM_OPTION

        #region FCURRENCY
        private void btnGetFCurrency_Click(object sender, EventArgs e)
        {
            dgvFCurrency.Rows.Clear();
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
                        int index = dgvFCurrency.Rows.Add();
                        dgvFCurrency.Rows[index].Cells[clmnFCurrId.Name].Value = curr.ID + 1;
                        dgvFCurrency.Rows[index].Cells[clmnFCurrName.Name].Value = curr.Name;
                        dgvFCurrency.Rows[index].Cells[clmnFCurrRate.Name].Value = curr.Rate;
                        MainForm.SetCurrency(curr.ID, curr);
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
        }

        private void btnSaveFcurrency_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ProgramConfig.MAX_FCURRENCY_COUNT; i++)
            {
                try
                {
                    DataGridViewCheckBoxCell selectedCell = (DataGridViewCheckBoxCell)dgvFCurrency.Rows[i].Cells[clmnFCurrSelected.Name];
                    if (selectedCell.Value != null && (bool)selectedCell.Value == true)
                    {
                        //NAME
                        String name = dgvFCurrency.Rows[i].Cells[clmnFCurrName.Index].Value.ToString();

                        //PRICE
                        decimal price = Convert.ToDecimal(dgvFCurrency.Rows[i].Cells[clmnFCurrRate.Index].Value);

                        // Send command
                        CPResponse response = new CPResponse(bridge.Printer.SetCurrencyInfo(i, name, price));

                        if (response.ErrorCode == 0)
                        {
                            FCurrency curr = new FCurrency();
                            curr.ID = i;
                            curr.Name = response.GetNextParam();
                            curr.Rate = decimal.Parse(response.GetNextParam());
                            MainForm.SetCurrency(curr.ID, curr);
                        }
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
        }

        #endregion

        #region Bitmap Logo
        string lastLogoPath = "";
        private void btnBrowseBmp_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Bitmap (*.bmp)|*.bmp|JPEG(*.jpeg)|*.jpeg|PNG(*.png)|*.png|JPG (*.jpg)|*.jpg|GIF (*.gif)|*.gif";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Lütfen resim dosyası seçiniz";
            dialog.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pbxLogo.Image = Image.FromFile(dialog.FileName);
                lastLogoPath = dialog.FileName;
            }
        }

        private void btnSendBitmap_Click(object sender, EventArgs e)
        {
            int index = 0;

            if (checkBoxForGibLogo.Checked)
                index = ProgramConfig.GIB_LOGO_NO;

            bridge.Log(FormMessage.SAVE_BITMAP_MESSAGE);
            try
            {
                CPResponse response = new CPResponse(bridge.Printer.LoadGraphicLogo(pbxLogo.Image, index));
            }
            catch (Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
        }

        #endregion

        #region NETWORK
        private void btnSaveNetwork_Click(object sender, EventArgs e)
        {

            string ip = String.Empty;
            string subnet = String.Empty;
            string gateway = String.Empty;

            try
            {
                if (txtIp.Text == String.Empty)
                {
                    ip = String.Empty;
                }
                else
                {
                    if (chkIp.Checked)
                    {
                        // IP Address
                        ip = txtIp.Text;                    
                    }
                    if (chkSubnet.Checked)
                    {
                        // Subnet
                        subnet = txtSubnet.Text;
                    }
                    if (chkGateway.Checked)
                    {
                        // Gateway
                        gateway = txtGateway.Text;
                    }
                }
                CPResponse response = new CPResponse(bridge.Printer.SaveNetworkSettings(ip, subnet, gateway));

            }
            catch (Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
        }

        private void chkIp_CheckedChanged(object sender, EventArgs e)
        {
            txtIp.Enabled = chkIp.Checked;
            txtSubnet.Enabled = chkSubnet.Checked;
            txtGateway.Enabled = chkGateway.Checked;
        }
        #endregion

        #region LOGO

        void chkLogo_CheckedChanged(object sender, EventArgs e)
        {
            ((CheckBox)sender).Text = ((CheckBox)sender).Checked ? "Seçme" : "Seç";
        }

        void txtLogo_TextChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(((TextBox)sender).Tag);

            Control[] c = tabSRVLogo.Controls.Find("chkLogo" + index, true);
            if (c != null && c.Length > 0)
            {
                ((CheckBox)c[0]).Checked = true;
            }
        }

        private void btnGetLogo_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < ProgramConfig.LENGTH_OF_LOGO_LINES; i++)
            {
                try
                {
                    if (IsSelected("chkLogo" + i))
                    {
                        CPResponse response = new CPResponse(bridge.Printer.GetLogo(i));

                        if (response.ErrorCode == 0)
                        {
                            TextBox txtLogo = (TextBox)GetControlByName("txtLogo" + i);
                            txtLogo.Text = response.GetNextParam();
                        }

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
        }

        private bool IsSelected(string checkBox)
        {
            Control[] c = tabSRVLogo.Controls.Find(checkBox, true);
            return ((CheckBox)c[0]).Checked;
        }

        private void btnSaveLogo_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < ProgramConfig.LENGTH_OF_LOGO_LINES; i++)
                {
                    if (IsSelected("chkLogo" + i))
                    {
                        //logo
                        TextBox txtLogo = (TextBox)GetControlByName("txtLogo" + i);

                        if (i == 6)
                        {
                            // Check length
                            if(txtLogo.Text.Length > 11)
                            {
                                MessageBox.Show("Last logo line length must be max 11!");
                                return;
                            }

                            // last logo line have to be numeric
                            if (!CheckInputIsNumeric(txtLogo.Text))
                            {
                                MessageBox.Show("Last logo line have to be numeric!");
                                return;
                            }
                        }

                        CPResponse response = new CPResponse(bridge.Printer.SetLogo(i, txtLogo.Text));

                        if (response.ErrorCode == 0)
                        {
                            bridge.Log(FormMessage.OPERATION_SUCCESSFULL);
                        }
                    }
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

        private bool CheckInputIsNumeric(string input)
        {
            int n;

            foreach(char c in input)
            {
                if (!int.TryParse(c.ToString(), out n))
                    return false;
            }
            return true;
        }
        #endregion LOGO

        #region VAT

        private List<int> dtVat = new List<int>();

        private void btnGetVat_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ProgramConfig.MAX_VAT_RATE_COUNT; i++)
            {
                try
                {
                    dgvVATDefine.Rows[i].Cells[clmnVatGroupNum.Index].Value = i + 1;

                    CPResponse response = new CPResponse(bridge.Printer.GetVATRate(i));

                    System.Threading.Thread.Sleep(200);
                    //ParseServiceResponse(response);

                    if (response.ErrorCode == 0)
                    {
                        dgvVATDefine.Rows[i].Cells[clmnVatRate.Index].Value = response.GetNextParam();
                        dtVat.Add(i + 1);
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
        }

        private void btnSaveVat_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ProgramConfig.MAX_VAT_RATE_COUNT; i++)
            {
                try
                {
                    DataGridViewCheckBoxCell selectedCell = (DataGridViewCheckBoxCell)dgvVATDefine.Rows[i].Cells[clmnSelectedVat.Index];
                    if (selectedCell.Value != null && (bool)selectedCell.Value == true)
                    {
                        //VAT RATE 
                        int vatRate = Convert.ToInt32(dgvVATDefine.Rows[i].Cells[clmnVatRate.Index].Value);

                        CPResponse response = new CPResponse(bridge.Printer.SetVATRate(i, vatRate));
                        System.Threading.Thread.Sleep(200);
                        ParseVATResponse(response);

                        if (response.ErrorCode == 0)
                        {
                            dgvVATDefine.Rows[i].Cells[clmnVatRate.Index].Value = response.GetNextParam();
                        }
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
        }

        private void ParseVATResponse(CPResponse response)
        {
            try
            {
                if (response.ErrorCode == 0)
                {
                    string retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        bridge.Log(String.Format("{1} : {0}", retVal, FormMessage.DATE));
                    }

                    retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        bridge.Log(String.Format("{1} : {0}", retVal, FormMessage.TIME));
                    }

                    retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        bridge.Log(String.Format("{1} : {0}", retVal, FormMessage.NOTE));
                    }

                    retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        bridge.Log(String.Format("{1} : {0}", retVal, FormMessage.QUANTITY));
                    }

                    retVal = response.GetNextParam();
                    if (!String.IsNullOrEmpty(retVal))
                    {
                        bridge.Log(FormMessage.DOCUMENT_ID + ": " + retVal);
                    }

                    //retVal = response.GetNextParam();
                    //if (!String.IsNullOrEmpty(retVal))
                    //{
                    //    bridge.Log("Kod: " + retVal);

                    //    retVal = response.GetNextParam();
                    //    if (!String.IsNullOrEmpty(retVal))
                    //    {
                    //        lblOrderNum.Text = String.Format("{0}", retVal);
                    //    }
                    //}

                }
            }
            catch (Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
        }
        #endregion VAT

        #region END OF RECEIPT NOTE


        private void buttonEORGet_Click(object sender, EventArgs e)
        {
            for(int i = 1; i<=6; i++)
            {
                try
                {
                    CPResponse response = new CPResponse(bridge.Printer.GetEndOfReceiptNote(i));

                    if(response.ErrorCode == 0)
                    {
                        TextBox txtBx = ((TextBox)(GetControlByName("textBoxEORLine" + i)));
                        txtBx.Text = response.GetNextParam();
                    }
                }
                catch(Exception ex)
                {
                    bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
                }
            }
        }

        private void buttonEORSet_Click(object sender, EventArgs e)
        {
            for(int i = 1; i<=6 ; i++)
            {
                if(((CheckBox)(tabPageEndOfReceiptNote.Controls.Find("checkBoxEORLine" + i, true)[0])).Checked)
                {
                    TextBox txtBx = ((TextBox)(GetControlByName("textBoxEORLine" + i)));
                    string line = txtBx.Text;

                    try
                    {
                        CPResponse response = new CPResponse(bridge.Printer.SetEndOfReceiptNote(i, line));

                        if(response.ErrorCode == 0)
                        {
                            txtBx.Text = response.GetNextParam();
                        }
                    }
                    catch(Exception ex)
                    {
                        bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
                    }
                }
            }
        }

        #endregion

        private static List<String> productLineList;
        private void btnBrowseProductFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "All Files (*.*)|*.*";
            fileDialog.FilterIndex = 1;
            fileDialog.Multiselect = false;

            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxProductFilePath.Text = fileDialog.FileName;

                string[] lines = System.IO.File.ReadAllLines(fileDialog.FileName);
                labelTotalLineValue.Text = lines.Length.ToString();
                productLineList = new List<string>(lines);
            }
        }

        private void btnSendProducts_Click(object sender, EventArgs eet)
        {
            try
            {
                TimerLabel tl = new TimerLabel(ref labelElapsedTime);
                tl.StartClock();

                BackgroundWorker bgw = new BackgroundWorker();
                bgw.DoWork += (s, e) =>
                {
                    // time consuming function
                    CPResponse response = new CPResponse(bridge.Printer.SendMultipleProduct(productLineList.ToArray()));
                };

                bgw.RunWorkerCompleted += (s, e) =>
                {
                    tl.StopClock();
                };

                bgw.RunWorkerAsync();
                
            }
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + " : " + ex.Message);
            }
        }

        static bool secondStage = false;
        private void Printer_OnFileSendingProgress(object sender, OnFileSendingProgressEventArgs e)
        {
            int progRate = int.Parse(e.Data);
            if (progRate > 100)
                progRate = 100;
            if (secondStage)
                TextProgresBarLabel("Product DB Sending to ECR..");
            else
                TextProgresBarLabel("Product DB Creating...");
            SetProgressBar(progRate);

            if (progRate == 100)
            {
                if (!secondStage)
                {
                    TextProgresBarLabel("Product DB Created");
                    secondStage = true;
                }
                else
                {
                    TextProgresBarLabel("Product DB sent successfully!");
                    secondStage = false;
                }
            }
        }

        private delegate void SetProgressBarDelegate(int rate);
        private void SetProgressBar(int rate)
        {
            if(progressBarSendProd.InvokeRequired)
            {
                progressBarSendProd.Invoke(new SetProgressBarDelegate(SetProgressBar), rate);
            }
            else
            {
                progressBarSendProd.Value = rate;
            }
        }

        private delegate void TextProgresBarLabelDelegate(string text);
        private void TextProgresBarLabel(string text)
        {
            if(labelUnderProgressBar.InvokeRequired)
            {
                labelUnderProgressBar.Invoke(new TextProgresBarLabelDelegate(TextProgresBarLabel), text);
            }
            else
            {
                labelUnderProgressBar.Text = text;
            }
        }
    }
    public enum Settings
    {
        CUTTER,
        PAY_WITH_EFT,
        RECEIPT_LIMIT,
        GRAPHIC_LOGO,
        RECEIPT_BARCODE,
        EFT_MANAGEMENT_ON_POS
    }
    public class ProgramOption
    {
        public int No = 0;
        public string Value = "";
    }
    public class Cashier
    {
        public int Id = 0;
        public string Name = "";
        public string Password = "";
    }
    public class SubCategory
    {
        public int CatNo = 0;
        public int MainCatNo = 0;
        public string Name = "";
    }
    public class MainCategory
    {
        public int CatNo = 0;
        public string Name = "";
    }
    public class Product
    {
        public int PluNo = 0;
        public string Barcode = "";
        public string Name = "";
        public decimal Price = 0.00m;
        public int Department = 0;
        public int Weighable = 0;
        public int SubCategory = 0;
    }

    internal class TimerLabel
    {
        Label label;
        internal TimerLabel(ref Label l)
        {
            label = l;
        }
        internal void StartClock()
        {
            Timer t = new Timer();
            t.Interval = 1000;
            t.Enabled = true;
            t.Tag = label;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }

        int i;
        bool stop;
        void t_Tick(object sender, EventArgs e)
        {
            if (stop)
            {
                ((Timer)sender).Stop();
                return;
            }

            ((Label)((Timer)sender).Tag).Text = String.Format("Elapsed Time : {0} second(s)",(++i).ToString());
        }

        internal void StopClock()
        {
            i = 0;
            stop = true;
        }
    }
}
