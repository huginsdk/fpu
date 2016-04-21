using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;



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
        private DataGridViewTextBoxColumn clmnDeptNo;
        private DataGridViewTextBoxColumn clmnDeptName;
        private DataGridViewTextBoxColumn clmnDeptVatId;
        private DataGridViewTextBoxColumn clmnDeptPrice;
        private DataGridViewCheckBoxColumn clmnDeptWeighable;
        private DataGridViewCheckBoxColumn clmnSelectDepartment;
        private TabPage tbpPLU;
        private Label lblDepDefine;
        private Button btnSavePLU;
        private Button btnGetPLU;
        private DataGridView dgvPLUDefine;
        private Label lblPLUStart;
        private TextBox txtPluAddress;
        private Label lblInfoPLU;
        private TabPage tbpCategory;
        private Label lblSubCategory;
        private Label lblMainGrup;
        private Button btnSaveSubcategory;
        private Button btnGetSubcategory;
        private DataGridView dgvSubCategory;
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
        private DataGridViewTextBoxColumn clmnSubcatNo;
        private DataGridViewTextBoxColumn clmnSubcatName;
        private DataGridViewTextBoxColumn clmnSubcatMainNo;
        private DataGridViewCheckBoxColumn clmnSubcatSelect;
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
        private DataGridViewTextBoxColumn clmnPLUNo;
        private DataGridViewTextBoxColumn clmnPLUName;
        private DataGridViewTextBoxColumn clmnPLUDeptNo;
        private DataGridViewTextBoxColumn clmnPLUPrice;
        private DataGridViewTextBoxColumn clmnPLUBarcode;
        private DataGridViewTextBoxColumn clmnPLUSubCat;
        private DataGridViewCheckBoxColumn clmnPLUWeighable;
        private DataGridViewCheckBoxColumn clmnPLUSelected;
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
        private TabPage tabCCList;
        private Label lblBINGroup;
        private Button btnSaveCardList;
        private DataGridView dgvCardInfoList;
        private DataGridViewTextBoxColumn clmnCCID;
        private DataGridViewTextBoxColumn clmnCCName;
        private DataGridViewTextBoxColumn clmnBIN;
        private DataGridViewCheckBoxColumn clmnCardInfoSelect;
        private Button btnOpenCVS;
        private DataGridViewCheckBoxColumn clmnSelectedVat; 

        public ProgramUC()
            : base()
        {
            InitializeComponent();

            SetLanguageOption();

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
            this.tabCCList.Text = FormMessage.CC_LIST;
            this.btnOpenCVS.Text = FormMessage.OPEN_CSV;
            this.lblBINGroup.Text = FormMessage.BIN_LIST;
            this.btnSaveCardList.Text = FormMessage.SAVE_CARD_LIST;
            this.tbpDepTax.Text = FormMessage.DEPARTMENT;
            this.lblDepartment.Text = FormMessage.DEPARTMENT_DEFINITION;
            this.btnSaveDepartment.Text = FormMessage.SAVE_DEPARTMENT;
            this.btnGetDepartment.Text = FormMessage.GET_DEPARTMENT;
            this.tbpPLU.Text = FormMessage.PLU;
            this.lblInfoPLU.Text = "?";
            this.lblPLUStart.Text = FormMessage.PLU_ID;
            this.lblDepDefine.Text = FormMessage.DEPARTMENT_DEFINITION;
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
            this.lblSubCategory.Text = FormMessage.SUB_CATEGORY;
            this.lblMainGrup.Text = FormMessage.MAIN_GROUP;
            this.btnSaveSubcategory.Text = FormMessage.SAVE_SUB_CATEGORY;
            this.btnGetSubcategory.Text = FormMessage.GET_SUB_CATEGORY; 
        
            this.clmnSubcatNo.HeaderText = FormMessage.SUBCATEGORY_ID;
            this.clmnSubcatName.HeaderText = FormMessage.SUBCAT_NAME;
            this.clmnSubcatMainNo.HeaderText = FormMessage.MAIN_GROUP;
            this.clmnSubcatSelect.HeaderText = FormMessage.COMMIT;
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
            this.clmnCCID.HeaderText = FormMessage.CC_ID;
            this.clmnCCName.HeaderText = FormMessage.CC_NAME;
            this.clmnBIN.HeaderText = FormMessage.BIN;
            this.clmnCardInfoSelect.HeaderText = FormMessage.COMMIT;
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
        }

        internal static TestUC Instance(IBridge iBridge)
        {
            if (programForm == null)
            {
                programForm = new ProgramUC();
                bridge = iBridge;
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
            this.tbcProgram = new System.Windows.Forms.TabControl();
            this.tbpDepTax = new System.Windows.Forms.TabPage();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.btnSaveDepartment = new System.Windows.Forms.Button();
            this.btnGetDepartment = new System.Windows.Forms.Button();
            this.dgvDepDefine = new System.Windows.Forms.DataGridView();
            this.clmnDeptNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDeptVatId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDeptPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDeptWeighable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmnSelectDepartment = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbpPLU = new System.Windows.Forms.TabPage();
            this.lblInfoPLU = new System.Windows.Forms.Label();
            this.txtPluAddress = new System.Windows.Forms.TextBox();
            this.lblPLUStart = new System.Windows.Forms.Label();
            this.lblDepDefine = new System.Windows.Forms.Label();
            this.btnSavePLU = new System.Windows.Forms.Button();
            this.btnGetPLU = new System.Windows.Forms.Button();
            this.dgvPLUDefine = new System.Windows.Forms.DataGridView();
            this.clmnPLUNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPLUName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPLUDeptNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPLUPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPLUBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPLUSubCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPLUWeighable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmnPLUSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbpCredit = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveFcurrency = new System.Windows.Forms.Button();
            this.btnGetFCurrency = new System.Windows.Forms.Button();
            this.dgvFCurrency = new System.Windows.Forms.DataGridView();
            this.clmnFCurrId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnFCurrName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnFCurrRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnFCurrSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblDefineCredit = new System.Windows.Forms.Label();
            this.btnSaveCredits = new System.Windows.Forms.Button();
            this.btnGetCredits = new System.Windows.Forms.Button();
            this.dgvCredits = new System.Windows.Forms.DataGridView();
            this.clmnIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnCreditName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbpCategory = new System.Windows.Forms.TabPage();
            this.lblSubCategory = new System.Windows.Forms.Label();
            this.lblMainGrup = new System.Windows.Forms.Label();
            this.btnSaveSubcategory = new System.Windows.Forms.Button();
            this.btnGetSubcategory = new System.Windows.Forms.Button();
            this.dgvSubCategory = new System.Windows.Forms.DataGridView();
            this.clmnSubcatNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnSubcatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnSubcatMainNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnSubcatSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnSaveMainCategory = new System.Windows.Forms.Button();
            this.btnGetMainCategory = new System.Windows.Forms.Button();
            this.dgvMainCategory = new System.Windows.Forms.DataGridView();
            this.clmnMainGrupNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnMainGrupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnMainGrupSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbpCashier = new System.Windows.Forms.TabPage();
            this.lblCashier = new System.Windows.Forms.Label();
            this.btnSaveCashier = new System.Windows.Forms.Button();
            this.btnGetCashier = new System.Windows.Forms.Button();
            this.dgvCashier = new System.Windows.Forms.DataGridView();
            this.clmnCashierIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnCashierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnCashierPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnCashierSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbpProgramOption = new System.Windows.Forms.TabPage();
            this.lblProgramOption = new System.Windows.Forms.Label();
            this.btnSavePrmOption = new System.Windows.Forms.Button();
            this.btnGetPrmOption = new System.Windows.Forms.Button();
            this.dgvPrmOption = new System.Windows.Forms.DataGridView();
            this.clmnPONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPOName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPOValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPOSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbpBitmapLogo = new System.Windows.Forms.TabPage();
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
            this.lblVAT = new System.Windows.Forms.Label();
            this.btnSaveVat = new System.Windows.Forms.Button();
            this.btnGetVat = new System.Windows.Forms.Button();
            this.dgvVATDefine = new System.Windows.Forms.DataGridView();
            this.clmnVatGroupNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnVatRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnSelectedVat = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabCCList = new System.Windows.Forms.TabPage();
            this.btnOpenCVS = new System.Windows.Forms.Button();
            this.lblBINGroup = new System.Windows.Forms.Label();
            this.btnSaveCardList = new System.Windows.Forms.Button();
            this.dgvCardInfoList = new System.Windows.Forms.DataGridView();
            this.clmnCCID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnCCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnBIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnCardInfoSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbcProgram.SuspendLayout();
            this.tbpDepTax.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepDefine)).BeginInit();
            this.tbpPLU.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPLUDefine)).BeginInit();
            this.tbpCredit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCredits)).BeginInit();
            this.tbpCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainCategory)).BeginInit();
            this.tbpCashier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashier)).BeginInit();
            this.tbpProgramOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrmOption)).BeginInit();
            this.tbpBitmapLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.tbpNetwork.SuspendLayout();
            this.tabSRVLogo.SuspendLayout();
            this.tabSRVVAT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVATDefine)).BeginInit();
            this.tabCCList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardInfoList)).BeginInit();
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
            this.tbcProgram.Controls.Add(this.tabCCList);
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
            this.tbpDepTax.Controls.Add(this.lblDepartment);
            this.tbpDepTax.Controls.Add(this.btnSaveDepartment);
            this.tbpDepTax.Controls.Add(this.btnGetDepartment);
            this.tbpDepTax.Controls.Add(this.dgvDepDefine);
            this.tbpDepTax.Location = new System.Drawing.Point(4, 22);
            this.tbpDepTax.Margin = new System.Windows.Forms.Padding(2);
            this.tbpDepTax.Name = "tbpDepTax";
            this.tbpDepTax.Padding = new System.Windows.Forms.Padding(2);
            this.tbpDepTax.Size = new System.Drawing.Size(583, 401);
            this.tbpDepTax.TabIndex = 1;
            this.tbpDepTax.Text = "DEPARTMENT";
            this.tbpDepTax.UseVisualStyleBackColor = true;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDepartment.Location = new System.Drawing.Point(4, 6);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(181, 15);
            this.lblDepartment.TabIndex = 11;
            this.lblDepartment.Text = "DEPARTMENT DEFINITION";
            // 
            // btnSaveDepartment
            // 
            this.btnSaveDepartment.Location = new System.Drawing.Point(126, 258);
            this.btnSaveDepartment.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveDepartment.Name = "btnSaveDepartment";
            this.btnSaveDepartment.Size = new System.Drawing.Size(102, 38);
            this.btnSaveDepartment.TabIndex = 9;
            this.btnSaveDepartment.Text = "SAVE DEPARTMENT";
            this.btnSaveDepartment.UseVisualStyleBackColor = true;
            this.btnSaveDepartment.Click += new System.EventHandler(this.btnSaveDepartment_Click);
            // 
            // btnGetDepartment
            // 
            this.btnGetDepartment.Location = new System.Drawing.Point(7, 258);
            this.btnGetDepartment.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetDepartment.Name = "btnGetDepartment";
            this.btnGetDepartment.Size = new System.Drawing.Size(93, 38);
            this.btnGetDepartment.TabIndex = 8;
            this.btnGetDepartment.Text = "GET DEPARTMENT";
            this.btnGetDepartment.UseVisualStyleBackColor = true;
            this.btnGetDepartment.Click += new System.EventHandler(this.btnGetDepartment_Click);
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
            this.dgvDepDefine.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDepDefine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepDefine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnDeptNo,
            this.clmnDeptName,
            this.clmnDeptVatId,
            this.clmnDeptPrice,
            this.clmnDeptWeighable,
            this.clmnSelectDepartment});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDepDefine.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDepDefine.Location = new System.Drawing.Point(7, 24);
            this.dgvDepDefine.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDepDefine.Name = "dgvDepDefine";
            this.dgvDepDefine.RowHeadersVisible = false;
            this.dgvDepDefine.RowTemplate.Height = 24;
            this.dgvDepDefine.Size = new System.Drawing.Size(433, 229);
            this.dgvDepDefine.TabIndex = 7;
            // 
            // clmnDeptNo
            // 
            this.clmnDeptNo.HeaderText = "DEP. ID";
            this.clmnDeptNo.MaxInputLength = 2;
            this.clmnDeptNo.Name = "clmnDeptNo";
            this.clmnDeptNo.ReadOnly = true;
            this.clmnDeptNo.Width = 50;
            // 
            // clmnDeptName
            // 
            this.clmnDeptName.HeaderText = "DEP. NAME";
            this.clmnDeptName.MaxInputLength = 18;
            this.clmnDeptName.Name = "clmnDeptName";
            // 
            // clmnDeptVatId
            // 
            this.clmnDeptVatId.HeaderText = "VAT GROUP ID";
            this.clmnDeptVatId.MaxInputLength = 1;
            this.clmnDeptVatId.Name = "clmnDeptVatId";
            this.clmnDeptVatId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnDeptVatId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmnDeptVatId.Width = 50;
            // 
            // clmnDeptPrice
            // 
            this.clmnDeptPrice.HeaderText = "PRICE";
            this.clmnDeptPrice.Name = "clmnDeptPrice";
            this.clmnDeptPrice.Width = 80;
            // 
            // clmnDeptWeighable
            // 
            this.clmnDeptWeighable.HeaderText = "WEIGHABLE";
            this.clmnDeptWeighable.Name = "clmnDeptWeighable";
            this.clmnDeptWeighable.Width = 50;
            // 
            // clmnSelectDepartment
            // 
            this.clmnSelectDepartment.HeaderText = "COMMIT?";
            this.clmnSelectDepartment.Name = "clmnSelectDepartment";
            this.clmnSelectDepartment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnSelectDepartment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmnSelectDepartment.Width = 50;
            // 
            // tbpPLU
            // 
            this.tbpPLU.Controls.Add(this.lblInfoPLU);
            this.tbpPLU.Controls.Add(this.txtPluAddress);
            this.tbpPLU.Controls.Add(this.lblPLUStart);
            this.tbpPLU.Controls.Add(this.lblDepDefine);
            this.tbpPLU.Controls.Add(this.btnSavePLU);
            this.tbpPLU.Controls.Add(this.btnGetPLU);
            this.tbpPLU.Controls.Add(this.dgvPLUDefine);
            this.tbpPLU.Location = new System.Drawing.Point(4, 22);
            this.tbpPLU.Margin = new System.Windows.Forms.Padding(2);
            this.tbpPLU.Name = "tbpPLU";
            this.tbpPLU.Padding = new System.Windows.Forms.Padding(2);
            this.tbpPLU.Size = new System.Drawing.Size(583, 401);
            this.tbpPLU.TabIndex = 3;
            this.tbpPLU.Text = "PLU";
            this.tbpPLU.UseVisualStyleBackColor = true;
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
            // txtPluAddress
            // 
            this.txtPluAddress.AccessibleDescription = "";
            this.txtPluAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPluAddress.Location = new System.Drawing.Point(454, 219);
            this.txtPluAddress.Margin = new System.Windows.Forms.Padding(2);
            this.txtPluAddress.Name = "txtPluAddress";
            this.txtPluAddress.Size = new System.Drawing.Size(116, 20);
            this.txtPluAddress.TabIndex = 19;
            this.txtPluAddress.Tag = "Enter comma to between PLUs to call more than one PLU. For calling range put  \'-\'" +
                " between two values.";
            this.txtPluAddress.Text = "1-10";
            // 
            // lblPLUStart
            // 
            this.lblPLUStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPLUStart.AutoSize = true;
            this.lblPLUStart.Location = new System.Drawing.Point(452, 202);
            this.lblPLUStart.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPLUStart.Name = "lblPLUStart";
            this.lblPLUStart.Size = new System.Drawing.Size(45, 13);
            this.lblPLUStart.TabIndex = 18;
            this.lblPLUStart.Text = "PLU ID:";
            // 
            // lblDepDefine
            // 
            this.lblDepDefine.AutoSize = true;
            this.lblDepDefine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDepDefine.Location = new System.Drawing.Point(4, 6);
            this.lblDepDefine.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDepDefine.Name = "lblDepDefine";
            this.lblDepDefine.Size = new System.Drawing.Size(181, 15);
            this.lblDepDefine.TabIndex = 15;
            this.lblDepDefine.Text = "DEPARTMENT DEFINITION";
            // 
            // btnSavePLU
            // 
            this.btnSavePLU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSavePLU.Location = new System.Drawing.Point(487, 304);
            this.btnSavePLU.Margin = new System.Windows.Forms.Padding(2);
            this.btnSavePLU.Name = "btnSavePLU";
            this.btnSavePLU.Size = new System.Drawing.Size(86, 38);
            this.btnSavePLU.TabIndex = 14;
            this.btnSavePLU.Text = "SAVE PLU";
            this.btnSavePLU.UseVisualStyleBackColor = true;
            this.btnSavePLU.Click += new System.EventHandler(this.btnSavePLU_Click);
            // 
            // btnGetPLU
            // 
            this.btnGetPLU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetPLU.Location = new System.Drawing.Point(487, 251);
            this.btnGetPLU.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetPLU.Name = "btnGetPLU";
            this.btnGetPLU.Size = new System.Drawing.Size(86, 38);
            this.btnGetPLU.TabIndex = 13;
            this.btnGetPLU.Text = "GET PLU";
            this.btnGetPLU.UseVisualStyleBackColor = true;
            this.btnGetPLU.Click += new System.EventHandler(this.btnGetPLU_Click);
            // 
            // dgvPLUDefine
            // 
            this.dgvPLUDefine.AllowUserToAddRows = false;
            this.dgvPLUDefine.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPLUDefine.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPLUDefine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPLUDefine.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPLUDefine.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPLUDefine.Location = new System.Drawing.Point(4, 24);
            this.dgvPLUDefine.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPLUDefine.Name = "dgvPLUDefine";
            this.dgvPLUDefine.RowHeadersVisible = false;
            this.dgvPLUDefine.RowTemplate.Height = 24;
            this.dgvPLUDefine.Size = new System.Drawing.Size(443, 375);
            this.dgvPLUDefine.TabIndex = 12;
            // 
            // clmnPLUNo
            // 
            this.clmnPLUNo.HeaderText = "PLU ID";
            this.clmnPLUNo.MaxInputLength = 2;
            this.clmnPLUNo.Name = "clmnPLUNo";
            this.clmnPLUNo.ReadOnly = true;
            this.clmnPLUNo.Width = 50;
            // 
            // clmnPLUName
            // 
            this.clmnPLUName.HeaderText = "PLU NAME";
            this.clmnPLUName.MaxInputLength = 20;
            this.clmnPLUName.Name = "clmnPLUName";
            this.clmnPLUName.Width = 150;
            // 
            // clmnPLUDeptNo
            // 
            this.clmnPLUDeptNo.HeaderText = "DEP. ID";
            this.clmnPLUDeptNo.MaxInputLength = 1;
            this.clmnPLUDeptNo.Name = "clmnPLUDeptNo";
            this.clmnPLUDeptNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnPLUDeptNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmnPLUDeptNo.Width = 50;
            // 
            // clmnPLUPrice
            // 
            this.clmnPLUPrice.HeaderText = "PRICE";
            this.clmnPLUPrice.Name = "clmnPLUPrice";
            this.clmnPLUPrice.Width = 80;
            // 
            // clmnPLUBarcode
            // 
            this.clmnPLUBarcode.HeaderText = "BARCODE";
            this.clmnPLUBarcode.MaxInputLength = 20;
            this.clmnPLUBarcode.Name = "clmnPLUBarcode";
            this.clmnPLUBarcode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnPLUBarcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmnPLUSubCat
            // 
            this.clmnPLUSubCat.HeaderText = "SUB CATEGORY";
            this.clmnPLUSubCat.Name = "clmnPLUSubCat";
            this.clmnPLUSubCat.Width = 50;
            // 
            // clmnPLUWeighable
            // 
            this.clmnPLUWeighable.HeaderText = "WEIGHABLE";
            this.clmnPLUWeighable.Name = "clmnPLUWeighable";
            this.clmnPLUWeighable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnPLUWeighable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmnPLUWeighable.Width = 50;
            // 
            // clmnPLUSelected
            // 
            this.clmnPLUSelected.HeaderText = "COMMIT?";
            this.clmnPLUSelected.Name = "clmnPLUSelected";
            this.clmnPLUSelected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnPLUSelected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmnPLUSelected.Width = 50;
            // 
            // tbpCredit
            // 
            this.tbpCredit.Controls.Add(this.label1);
            this.tbpCredit.Controls.Add(this.btnSaveFcurrency);
            this.tbpCredit.Controls.Add(this.btnGetFCurrency);
            this.tbpCredit.Controls.Add(this.dgvFCurrency);
            this.tbpCredit.Controls.Add(this.lblDefineCredit);
            this.tbpCredit.Controls.Add(this.btnSaveCredits);
            this.tbpCredit.Controls.Add(this.btnGetCredits);
            this.tbpCredit.Controls.Add(this.dgvCredits);
            this.tbpCredit.Location = new System.Drawing.Point(4, 22);
            this.tbpCredit.Margin = new System.Windows.Forms.Padding(2);
            this.tbpCredit.Name = "tbpCredit";
            this.tbpCredit.Padding = new System.Windows.Forms.Padding(2);
            this.tbpCredit.Size = new System.Drawing.Size(583, 401);
            this.tbpCredit.TabIndex = 2;
            this.tbpCredit.Text = "CREDIT";
            this.tbpCredit.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(295, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "F.CURRENCY DEFINITION";
            // 
            // btnSaveFcurrency
            // 
            this.btnSaveFcurrency.Location = new System.Drawing.Point(410, 256);
            this.btnSaveFcurrency.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveFcurrency.Name = "btnSaveFcurrency";
            this.btnSaveFcurrency.Size = new System.Drawing.Size(99, 31);
            this.btnSaveFcurrency.TabIndex = 19;
            this.btnSaveFcurrency.Text = "SAVE F.CURRENCY";
            this.btnSaveFcurrency.UseVisualStyleBackColor = true;
            this.btnSaveFcurrency.Click += new System.EventHandler(this.btnSaveFcurrency_Click);
            // 
            // btnGetFCurrency
            // 
            this.btnGetFCurrency.Location = new System.Drawing.Point(295, 256);
            this.btnGetFCurrency.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetFCurrency.Name = "btnGetFCurrency";
            this.btnGetFCurrency.Size = new System.Drawing.Size(99, 31);
            this.btnGetFCurrency.TabIndex = 18;
            this.btnGetFCurrency.Text = "GET F.CURRENCY";
            this.btnGetFCurrency.UseVisualStyleBackColor = true;
            this.btnGetFCurrency.Click += new System.EventHandler(this.btnGetFCurrency_Click);
            // 
            // dgvFCurrency
            // 
            this.dgvFCurrency.AllowUserToAddRows = false;
            this.dgvFCurrency.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvFCurrency.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvFCurrency.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvFCurrency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFCurrency.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnFCurrId,
            this.clmnFCurrName,
            this.clmnFCurrRate,
            this.clmnFCurrSelected});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFCurrency.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvFCurrency.Location = new System.Drawing.Point(295, 24);
            this.dgvFCurrency.Margin = new System.Windows.Forms.Padding(2);
            this.dgvFCurrency.Name = "dgvFCurrency";
            this.dgvFCurrency.RowHeadersVisible = false;
            this.dgvFCurrency.RowTemplate.Height = 24;
            this.dgvFCurrency.Size = new System.Drawing.Size(279, 227);
            this.dgvFCurrency.TabIndex = 17;
            // 
            // clmnFCurrId
            // 
            this.clmnFCurrId.HeaderText = "F.CURRENCY ID";
            this.clmnFCurrId.MaxInputLength = 2;
            this.clmnFCurrId.Name = "clmnFCurrId";
            this.clmnFCurrId.ReadOnly = true;
            this.clmnFCurrId.Width = 50;
            // 
            // clmnFCurrName
            // 
            this.clmnFCurrName.HeaderText = "F.CURRENCY CODE";
            this.clmnFCurrName.MaxInputLength = 15;
            this.clmnFCurrName.Name = "clmnFCurrName";
            this.clmnFCurrName.Width = 120;
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
            // lblDefineCredit
            // 
            this.lblDefineCredit.AutoSize = true;
            this.lblDefineCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDefineCredit.Location = new System.Drawing.Point(4, 6);
            this.lblDefineCredit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDefineCredit.Name = "lblDefineCredit";
            this.lblDefineCredit.Size = new System.Drawing.Size(138, 15);
            this.lblDefineCredit.TabIndex = 16;
            this.lblDefineCredit.Text = "CREDIT DEFINITION";
            // 
            // btnSaveCredits
            // 
            this.btnSaveCredits.Location = new System.Drawing.Point(119, 256);
            this.btnSaveCredits.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveCredits.Name = "btnSaveCredits";
            this.btnSaveCredits.Size = new System.Drawing.Size(99, 31);
            this.btnSaveCredits.TabIndex = 3;
            this.btnSaveCredits.Text = "SAVE CREDIT";
            this.btnSaveCredits.UseVisualStyleBackColor = true;
            this.btnSaveCredits.Click += new System.EventHandler(this.btnSaveCredits_Click);
            // 
            // btnGetCredits
            // 
            this.btnGetCredits.Location = new System.Drawing.Point(4, 256);
            this.btnGetCredits.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetCredits.Name = "btnGetCredits";
            this.btnGetCredits.Size = new System.Drawing.Size(99, 31);
            this.btnGetCredits.TabIndex = 2;
            this.btnGetCredits.Text = "GET CREDIT";
            this.btnGetCredits.UseVisualStyleBackColor = true;
            this.btnGetCredits.Click += new System.EventHandler(this.btnGetCredits_Click);
            // 
            // dgvCredits
            // 
            this.dgvCredits.AllowUserToAddRows = false;
            this.dgvCredits.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCredits.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCredits.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCredits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCredits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnIndex,
            this.clmnCreditName,
            this.clmnSelected});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCredits.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCredits.Location = new System.Drawing.Point(4, 24);
            this.dgvCredits.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCredits.Name = "dgvCredits";
            this.dgvCredits.RowHeadersVisible = false;
            this.dgvCredits.RowTemplate.Height = 24;
            this.dgvCredits.Size = new System.Drawing.Size(279, 227);
            this.dgvCredits.TabIndex = 0;
            // 
            // clmnIndex
            // 
            this.clmnIndex.HeaderText = "CREDIT ID";
            this.clmnIndex.MaxInputLength = 2;
            this.clmnIndex.Name = "clmnIndex";
            this.clmnIndex.ReadOnly = true;
            this.clmnIndex.Width = 50;
            // 
            // clmnCreditName
            // 
            this.clmnCreditName.HeaderText = "CREDIT NAME";
            this.clmnCreditName.MaxInputLength = 16;
            this.clmnCreditName.Name = "clmnCreditName";
            this.clmnCreditName.Width = 200;
            // 
            // clmnSelected
            // 
            this.clmnSelected.HeaderText = "COMMIT?";
            this.clmnSelected.Name = "clmnSelected";
            this.clmnSelected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnSelected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tbpCategory
            // 
            this.tbpCategory.Controls.Add(this.lblSubCategory);
            this.tbpCategory.Controls.Add(this.lblMainGrup);
            this.tbpCategory.Controls.Add(this.btnSaveSubcategory);
            this.tbpCategory.Controls.Add(this.btnGetSubcategory);
            this.tbpCategory.Controls.Add(this.dgvSubCategory);
            this.tbpCategory.Controls.Add(this.btnSaveMainCategory);
            this.tbpCategory.Controls.Add(this.btnGetMainCategory);
            this.tbpCategory.Controls.Add(this.dgvMainCategory);
            this.tbpCategory.Location = new System.Drawing.Point(4, 22);
            this.tbpCategory.Margin = new System.Windows.Forms.Padding(2);
            this.tbpCategory.Name = "tbpCategory";
            this.tbpCategory.Padding = new System.Windows.Forms.Padding(2);
            this.tbpCategory.Size = new System.Drawing.Size(583, 401);
            this.tbpCategory.TabIndex = 4;
            this.tbpCategory.Text = "CATEGORY";
            this.tbpCategory.UseVisualStyleBackColor = true;
            // 
            // lblSubCategory
            // 
            this.lblSubCategory.AutoSize = true;
            this.lblSubCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSubCategory.Location = new System.Drawing.Point(264, 6);
            this.lblSubCategory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubCategory.Name = "lblSubCategory";
            this.lblSubCategory.Size = new System.Drawing.Size(111, 15);
            this.lblSubCategory.TabIndex = 19;
            this.lblSubCategory.Text = "SUB CATEGORY";
            // 
            // lblMainGrup
            // 
            this.lblMainGrup.AutoSize = true;
            this.lblMainGrup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMainGrup.Location = new System.Drawing.Point(4, 6);
            this.lblMainGrup.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMainGrup.Name = "lblMainGrup";
            this.lblMainGrup.Size = new System.Drawing.Size(94, 15);
            this.lblMainGrup.TabIndex = 18;
            this.lblMainGrup.Text = "MAIN GROUP";
            // 
            // btnSaveSubcategory
            // 
            this.btnSaveSubcategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveSubcategory.Location = new System.Drawing.Point(377, 343);
            this.btnSaveSubcategory.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveSubcategory.Name = "btnSaveSubcategory";
            this.btnSaveSubcategory.Size = new System.Drawing.Size(101, 43);
            this.btnSaveSubcategory.TabIndex = 17;
            this.btnSaveSubcategory.Text = "SAVE SUBCATEGORY";
            this.btnSaveSubcategory.UseVisualStyleBackColor = true;
            this.btnSaveSubcategory.Click += new System.EventHandler(this.btnSaveSubcategory_Click);
            // 
            // btnGetSubcategory
            // 
            this.btnGetSubcategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGetSubcategory.Location = new System.Drawing.Point(266, 343);
            this.btnGetSubcategory.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetSubcategory.Name = "btnGetSubcategory";
            this.btnGetSubcategory.Size = new System.Drawing.Size(94, 43);
            this.btnGetSubcategory.TabIndex = 16;
            this.btnGetSubcategory.Text = "GET SUBCATEGORY";
            this.btnGetSubcategory.UseVisualStyleBackColor = true;
            this.btnGetSubcategory.Click += new System.EventHandler(this.btnGetSubcategory_Click);
            // 
            // dgvSubCategory
            // 
            this.dgvSubCategory.AllowUserToAddRows = false;
            this.dgvSubCategory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvSubCategory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvSubCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSubCategory.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvSubCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnSubcatNo,
            this.clmnSubcatName,
            this.clmnSubcatMainNo,
            this.clmnSubcatSelect});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSubCategory.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvSubCategory.Location = new System.Drawing.Point(266, 24);
            this.dgvSubCategory.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSubCategory.Name = "dgvSubCategory";
            this.dgvSubCategory.RowHeadersVisible = false;
            this.dgvSubCategory.RowTemplate.Height = 24;
            this.dgvSubCategory.Size = new System.Drawing.Size(314, 314);
            this.dgvSubCategory.TabIndex = 15;
            // 
            // clmnSubcatNo
            // 
            this.clmnSubcatNo.HeaderText = "SUBCATEGORY ID";
            this.clmnSubcatNo.MaxInputLength = 2;
            this.clmnSubcatNo.Name = "clmnSubcatNo";
            this.clmnSubcatNo.ReadOnly = true;
            this.clmnSubcatNo.Width = 50;
            // 
            // clmnSubcatName
            // 
            this.clmnSubcatName.HeaderText = "SUBCATEGORY NAME";
            this.clmnSubcatName.MaxInputLength = 20;
            this.clmnSubcatName.Name = "clmnSubcatName";
            this.clmnSubcatName.Width = 150;
            // 
            // clmnSubcatMainNo
            // 
            this.clmnSubcatMainNo.HeaderText = "MAIN GROUP";
            this.clmnSubcatMainNo.MaxInputLength = 2;
            this.clmnSubcatMainNo.Name = "clmnSubcatMainNo";
            this.clmnSubcatMainNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnSubcatMainNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmnSubcatSelect
            // 
            this.clmnSubcatSelect.HeaderText = "COMMIT?";
            this.clmnSubcatSelect.Name = "clmnSubcatSelect";
            this.clmnSubcatSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnSubcatSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmnSubcatSelect.Width = 50;
            // 
            // btnSaveMainCategory
            // 
            this.btnSaveMainCategory.Location = new System.Drawing.Point(112, 343);
            this.btnSaveMainCategory.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveMainCategory.Name = "btnSaveMainCategory";
            this.btnSaveMainCategory.Size = new System.Drawing.Size(99, 43);
            this.btnSaveMainCategory.TabIndex = 14;
            this.btnSaveMainCategory.Text = "SAVE MAIN CAT.";
            this.btnSaveMainCategory.UseVisualStyleBackColor = true;
            this.btnSaveMainCategory.Click += new System.EventHandler(this.btnSaveMainCategory_Click);
            // 
            // btnGetMainCategory
            // 
            this.btnGetMainCategory.Location = new System.Drawing.Point(2, 343);
            this.btnGetMainCategory.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetMainCategory.Name = "btnGetMainCategory";
            this.btnGetMainCategory.Size = new System.Drawing.Size(97, 43);
            this.btnGetMainCategory.TabIndex = 13;
            this.btnGetMainCategory.Text = "GET MAIN CAT.";
            this.btnGetMainCategory.UseVisualStyleBackColor = true;
            this.btnGetMainCategory.Click += new System.EventHandler(this.btnGetMainCategory_Click);
            // 
            // dgvMainCategory
            // 
            this.dgvMainCategory.AllowUserToAddRows = false;
            this.dgvMainCategory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMainCategory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvMainCategory.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvMainCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMainCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnMainGrupNo,
            this.clmnMainGrupName,
            this.clmnMainGrupSelect});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMainCategory.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvMainCategory.Location = new System.Drawing.Point(4, 24);
            this.dgvMainCategory.Margin = new System.Windows.Forms.Padding(2);
            this.dgvMainCategory.Name = "dgvMainCategory";
            this.dgvMainCategory.RowHeadersVisible = false;
            this.dgvMainCategory.RowTemplate.Height = 24;
            this.dgvMainCategory.Size = new System.Drawing.Size(227, 314);
            this.dgvMainCategory.TabIndex = 12;
            // 
            // clmnMainGrupNo
            // 
            this.clmnMainGrupNo.HeaderText = "MAIN CAT. ID";
            this.clmnMainGrupNo.MaxInputLength = 1;
            this.clmnMainGrupNo.Name = "clmnMainGrupNo";
            this.clmnMainGrupNo.ReadOnly = true;
            this.clmnMainGrupNo.Width = 50;
            // 
            // clmnMainGrupName
            // 
            this.clmnMainGrupName.HeaderText = "MAIN CAT. NAME";
            this.clmnMainGrupName.MaxInputLength = 20;
            this.clmnMainGrupName.Name = "clmnMainGrupName";
            this.clmnMainGrupName.Width = 150;
            // 
            // clmnMainGrupSelect
            // 
            this.clmnMainGrupSelect.HeaderText = "COMMIT?";
            this.clmnMainGrupSelect.Name = "clmnMainGrupSelect";
            this.clmnMainGrupSelect.Width = 60;
            // 
            // tbpCashier
            // 
            this.tbpCashier.Controls.Add(this.lblCashier);
            this.tbpCashier.Controls.Add(this.btnSaveCashier);
            this.tbpCashier.Controls.Add(this.btnGetCashier);
            this.tbpCashier.Controls.Add(this.dgvCashier);
            this.tbpCashier.Location = new System.Drawing.Point(4, 22);
            this.tbpCashier.Margin = new System.Windows.Forms.Padding(2);
            this.tbpCashier.Name = "tbpCashier";
            this.tbpCashier.Padding = new System.Windows.Forms.Padding(2);
            this.tbpCashier.Size = new System.Drawing.Size(583, 401);
            this.tbpCashier.TabIndex = 5;
            this.tbpCashier.Text = "CASHIER";
            this.tbpCashier.UseVisualStyleBackColor = true;
            // 
            // lblCashier
            // 
            this.lblCashier.AutoSize = true;
            this.lblCashier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCashier.Location = new System.Drawing.Point(4, 6);
            this.lblCashier.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCashier.Name = "lblCashier";
            this.lblCashier.Size = new System.Drawing.Size(99, 15);
            this.lblCashier.TabIndex = 22;
            this.lblCashier.Text = "CASHIER LIST";
            // 
            // btnSaveCashier
            // 
            this.btnSaveCashier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveCashier.Location = new System.Drawing.Point(115, 358);
            this.btnSaveCashier.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveCashier.Name = "btnSaveCashier";
            this.btnSaveCashier.Size = new System.Drawing.Size(90, 38);
            this.btnSaveCashier.TabIndex = 21;
            this.btnSaveCashier.Text = "SAVE CASHIER";
            this.btnSaveCashier.UseVisualStyleBackColor = true;
            this.btnSaveCashier.Click += new System.EventHandler(this.btnSaveCashier_Click);
            // 
            // btnGetCashier
            // 
            this.btnGetCashier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGetCashier.Location = new System.Drawing.Point(4, 358);
            this.btnGetCashier.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetCashier.Name = "btnGetCashier";
            this.btnGetCashier.Size = new System.Drawing.Size(90, 38);
            this.btnGetCashier.TabIndex = 20;
            this.btnGetCashier.Text = "GET CASHIER";
            this.btnGetCashier.UseVisualStyleBackColor = true;
            this.btnGetCashier.Click += new System.EventHandler(this.btnGetCashier_Click);
            // 
            // dgvCashier
            // 
            this.dgvCashier.AllowUserToAddRows = false;
            this.dgvCashier.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCashier.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvCashier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvCashier.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCashier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCashier.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnCashierIndex,
            this.clmnCashierName,
            this.clmnCashierPassword,
            this.clmnCashierSelect});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCashier.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvCashier.Location = new System.Drawing.Point(4, 24);
            this.dgvCashier.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCashier.Name = "dgvCashier";
            this.dgvCashier.RowHeadersVisible = false;
            this.dgvCashier.RowTemplate.Height = 24;
            this.dgvCashier.Size = new System.Drawing.Size(387, 329);
            this.dgvCashier.TabIndex = 19;
            // 
            // clmnCashierIndex
            // 
            this.clmnCashierIndex.HeaderText = "CASHIER ID";
            this.clmnCashierIndex.MaxInputLength = 1;
            this.clmnCashierIndex.Name = "clmnCashierIndex";
            this.clmnCashierIndex.ReadOnly = true;
            this.clmnCashierIndex.Width = 50;
            // 
            // clmnCashierName
            // 
            this.clmnCashierName.HeaderText = "CASHIER NAME";
            this.clmnCashierName.MaxInputLength = 15;
            this.clmnCashierName.Name = "clmnCashierName";
            this.clmnCashierName.Width = 150;
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
            this.clmnCashierSelect.Width = 50;
            // 
            // tbpProgramOption
            // 
            this.tbpProgramOption.Controls.Add(this.lblProgramOption);
            this.tbpProgramOption.Controls.Add(this.btnSavePrmOption);
            this.tbpProgramOption.Controls.Add(this.btnGetPrmOption);
            this.tbpProgramOption.Controls.Add(this.dgvPrmOption);
            this.tbpProgramOption.Location = new System.Drawing.Point(4, 22);
            this.tbpProgramOption.Margin = new System.Windows.Forms.Padding(2);
            this.tbpProgramOption.Name = "tbpProgramOption";
            this.tbpProgramOption.Padding = new System.Windows.Forms.Padding(2);
            this.tbpProgramOption.Size = new System.Drawing.Size(583, 401);
            this.tbpProgramOption.TabIndex = 6;
            this.tbpProgramOption.Text = "PROGRAM OPTIONS";
            this.tbpProgramOption.UseVisualStyleBackColor = true;
            // 
            // lblProgramOption
            // 
            this.lblProgramOption.AutoSize = true;
            this.lblProgramOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblProgramOption.Location = new System.Drawing.Point(4, 6);
            this.lblProgramOption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProgramOption.Name = "lblProgramOption";
            this.lblProgramOption.Size = new System.Drawing.Size(140, 15);
            this.lblProgramOption.TabIndex = 26;
            this.lblProgramOption.Text = "PROGRAM OPTIONS";
            // 
            // btnSavePrmOption
            // 
            this.btnSavePrmOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSavePrmOption.Location = new System.Drawing.Point(110, 350);
            this.btnSavePrmOption.Margin = new System.Windows.Forms.Padding(2);
            this.btnSavePrmOption.Name = "btnSavePrmOption";
            this.btnSavePrmOption.Size = new System.Drawing.Size(90, 38);
            this.btnSavePrmOption.TabIndex = 25;
            this.btnSavePrmOption.Text = "SAVE PROG. OPTIONS";
            this.btnSavePrmOption.UseVisualStyleBackColor = true;
            this.btnSavePrmOption.Click += new System.EventHandler(this.btnSavePrmOption_Click);
            // 
            // btnGetPrmOption
            // 
            this.btnGetPrmOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGetPrmOption.Location = new System.Drawing.Point(4, 350);
            this.btnGetPrmOption.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetPrmOption.Name = "btnGetPrmOption";
            this.btnGetPrmOption.Size = new System.Drawing.Size(90, 38);
            this.btnGetPrmOption.TabIndex = 24;
            this.btnGetPrmOption.Text = "GET PROG. OPTIONS";
            this.btnGetPrmOption.UseVisualStyleBackColor = true;
            this.btnGetPrmOption.Click += new System.EventHandler(this.btnGetPrmOption_Click);
            // 
            // dgvPrmOption
            // 
            this.dgvPrmOption.AllowUserToAddRows = false;
            this.dgvPrmOption.AllowUserToDeleteRows = false;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPrmOption.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvPrmOption.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPrmOption.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPrmOption.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrmOption.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnPONo,
            this.clmnPOName,
            this.clmnPOValue,
            this.clmnPOSelect});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPrmOption.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgvPrmOption.Location = new System.Drawing.Point(4, 24);
            this.dgvPrmOption.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPrmOption.Name = "dgvPrmOption";
            this.dgvPrmOption.RowHeadersVisible = false;
            this.dgvPrmOption.RowTemplate.Height = 24;
            this.dgvPrmOption.Size = new System.Drawing.Size(360, 312);
            this.dgvPrmOption.TabIndex = 23;
            // 
            // clmnPONo
            // 
            this.clmnPONo.HeaderText = "ID";
            this.clmnPONo.MaxInputLength = 1;
            this.clmnPONo.Name = "clmnPONo";
            this.clmnPONo.ReadOnly = true;
            this.clmnPONo.Width = 50;
            // 
            // clmnPOName
            // 
            this.clmnPOName.HeaderText = "NAME";
            this.clmnPOName.MaxInputLength = 20;
            this.clmnPOName.Name = "clmnPOName";
            this.clmnPOName.Width = 250;
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
            this.clmnPOSelect.Width = 50;
            // 
            // tbpBitmapLogo
            // 
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
            this.btnSendBitmap.Location = new System.Drawing.Point(331, 248);
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
            this.btnBrowseBmp.Location = new System.Drawing.Point(220, 248);
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
            this.tabSRVVAT.Controls.Add(this.lblVAT);
            this.tabSRVVAT.Controls.Add(this.btnSaveVat);
            this.tabSRVVAT.Controls.Add(this.btnGetVat);
            this.tabSRVVAT.Controls.Add(this.dgvVATDefine);
            this.tabSRVVAT.Location = new System.Drawing.Point(4, 22);
            this.tabSRVVAT.Margin = new System.Windows.Forms.Padding(2);
            this.tabSRVVAT.Name = "tabSRVVAT";
            this.tabSRVVAT.Padding = new System.Windows.Forms.Padding(2);
            this.tabSRVVAT.Size = new System.Drawing.Size(583, 401);
            this.tabSRVVAT.TabIndex = 2;
            this.tabSRVVAT.Text = "VAT";
            this.tabSRVVAT.UseVisualStyleBackColor = true;
            // 
            // lblVAT
            // 
            this.lblVAT.AutoSize = true;
            this.lblVAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblVAT.Location = new System.Drawing.Point(11, 11);
            this.lblVAT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVAT.Name = "lblVAT";
            this.lblVAT.Size = new System.Drawing.Size(124, 15);
            this.lblVAT.TabIndex = 18;
            this.lblVAT.Text = "DEFINE VAT RATE";
            // 
            // btnSaveVat
            // 
            this.btnSaveVat.Location = new System.Drawing.Point(99, 262);
            this.btnSaveVat.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveVat.Name = "btnSaveVat";
            this.btnSaveVat.Size = new System.Drawing.Size(74, 38);
            this.btnSaveVat.TabIndex = 17;
            this.btnSaveVat.Text = "SAVE VAT";
            this.btnSaveVat.UseVisualStyleBackColor = true;
            this.btnSaveVat.Click += new System.EventHandler(this.btnSaveVat_Click);
            // 
            // btnGetVat
            // 
            this.btnGetVat.Location = new System.Drawing.Point(11, 262);
            this.btnGetVat.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetVat.Name = "btnGetVat";
            this.btnGetVat.Size = new System.Drawing.Size(74, 38);
            this.btnGetVat.TabIndex = 16;
            this.btnGetVat.Text = "GET VAT";
            this.btnGetVat.UseVisualStyleBackColor = true;
            this.btnGetVat.Click += new System.EventHandler(this.btnGetVat_Click);
            // 
            // dgvVATDefine
            // 
            this.dgvVATDefine.AllowUserToAddRows = false;
            this.dgvVATDefine.AllowUserToDeleteRows = false;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVATDefine.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvVATDefine.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvVATDefine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVATDefine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnVatGroupNum,
            this.clmnVatRate,
            this.clmnSelectedVat});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVATDefine.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvVATDefine.Location = new System.Drawing.Point(11, 28);
            this.dgvVATDefine.Margin = new System.Windows.Forms.Padding(2);
            this.dgvVATDefine.Name = "dgvVATDefine";
            this.dgvVATDefine.RowHeadersVisible = false;
            this.dgvVATDefine.RowTemplate.Height = 24;
            this.dgvVATDefine.Size = new System.Drawing.Size(214, 229);
            this.dgvVATDefine.TabIndex = 15;
            // 
            // clmnVatGroupNum
            // 
            this.clmnVatGroupNum.HeaderText = "VAT ID";
            this.clmnVatGroupNum.MaxInputLength = 1;
            this.clmnVatGroupNum.Name = "clmnVatGroupNum";
            this.clmnVatGroupNum.ReadOnly = true;
            this.clmnVatGroupNum.Width = 50;
            // 
            // clmnVatRate
            // 
            this.clmnVatRate.HeaderText = "VAT RATE (%)";
            this.clmnVatRate.MaxInputLength = 2;
            this.clmnVatRate.Name = "clmnVatRate";
            // 
            // clmnSelectedVat
            // 
            this.clmnSelectedVat.HeaderText = "COMMIT?";
            this.clmnSelectedVat.Name = "clmnSelectedVat";
            this.clmnSelectedVat.Width = 60;
            // 
            // tabCCList
            // 
            this.tabCCList.Controls.Add(this.btnOpenCVS);
            this.tabCCList.Controls.Add(this.lblBINGroup);
            this.tabCCList.Controls.Add(this.btnSaveCardList);
            this.tabCCList.Controls.Add(this.dgvCardInfoList);
            this.tabCCList.Location = new System.Drawing.Point(4, 22);
            this.tabCCList.Margin = new System.Windows.Forms.Padding(2);
            this.tabCCList.Name = "tabCCList";
            this.tabCCList.Padding = new System.Windows.Forms.Padding(2);
            this.tabCCList.Size = new System.Drawing.Size(583, 401);
            this.tabCCList.TabIndex = 9;
            this.tabCCList.Text = "CC LIST";
            this.tabCCList.UseVisualStyleBackColor = true;
            // 
            // btnOpenCVS
            // 
            this.btnOpenCVS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenCVS.Location = new System.Drawing.Point(16, 418);
            this.btnOpenCVS.Name = "btnOpenCVS";
            this.btnOpenCVS.Size = new System.Drawing.Size(175, 38);
            this.btnOpenCVS.TabIndex = 23;
            this.btnOpenCVS.Text = "OPEN .CSV";
            this.btnOpenCVS.UseVisualStyleBackColor = true;
            this.btnOpenCVS.Click += new System.EventHandler(this.btnOpenCVS_Click);
            // 
            // lblBINGroup
            // 
            this.lblBINGroup.AutoSize = true;
            this.lblBINGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBINGroup.Location = new System.Drawing.Point(4, 2);
            this.lblBINGroup.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBINGroup.Name = "lblBINGroup";
            this.lblBINGroup.Size = new System.Drawing.Size(63, 15);
            this.lblBINGroup.TabIndex = 22;
            this.lblBINGroup.Text = "BIN LIST";
            // 
            // btnSaveCardList
            // 
            this.btnSaveCardList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveCardList.Location = new System.Drawing.Point(118, 339);
            this.btnSaveCardList.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveCardList.Name = "btnSaveCardList";
            this.btnSaveCardList.Size = new System.Drawing.Size(101, 31);
            this.btnSaveCardList.TabIndex = 21;
            this.btnSaveCardList.Text = "SAVE CARD LIST";
            this.btnSaveCardList.UseVisualStyleBackColor = true;
            this.btnSaveCardList.Click += new System.EventHandler(this.btnSaveCardList_Click);
            // 
            // dgvCardInfoList
            // 
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCardInfoList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvCardInfoList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCardInfoList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCardInfoList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCardInfoList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnCCID,
            this.clmnCCName,
            this.clmnBIN,
            this.clmnCardInfoSelect});
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCardInfoList.DefaultCellStyle = dataGridViewCellStyle20;
            this.dgvCardInfoList.Location = new System.Drawing.Point(7, 20);
            this.dgvCardInfoList.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCardInfoList.Name = "dgvCardInfoList";
            this.dgvCardInfoList.RowHeadersVisible = false;
            this.dgvCardInfoList.RowTemplate.Height = 24;
            this.dgvCardInfoList.Size = new System.Drawing.Size(314, 314);
            this.dgvCardInfoList.TabIndex = 20;
            // 
            // clmnCCID
            // 
            this.clmnCCID.HeaderText = "CC ID";
            this.clmnCCID.MaxInputLength = 8;
            this.clmnCCID.Name = "clmnCCID";
            this.clmnCCID.Width = 50;
            // 
            // clmnCCName
            // 
            this.clmnCCName.HeaderText = "CC NAME";
            this.clmnCCName.MaxInputLength = 20;
            this.clmnCCName.Name = "clmnCCName";
            this.clmnCCName.Width = 150;
            // 
            // clmnBIN
            // 
            this.clmnBIN.HeaderText = "BIN";
            this.clmnBIN.MaxInputLength = 8;
            this.clmnBIN.Name = "clmnBIN";
            this.clmnBIN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnBIN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmnCardInfoSelect
            // 
            this.clmnCardInfoSelect.HeaderText = "COMMIT?";
            this.clmnCardInfoSelect.Name = "clmnCardInfoSelect";
            this.clmnCardInfoSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnCardInfoSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmnCardInfoSelect.Width = 50;
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
            this.tbpDepTax.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepDefine)).EndInit();
            this.tbpPLU.ResumeLayout(false);
            this.tbpPLU.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPLUDefine)).EndInit();
            this.tbpCredit.ResumeLayout(false);
            this.tbpCredit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCredits)).EndInit();
            this.tbpCategory.ResumeLayout(false);
            this.tbpCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainCategory)).EndInit();
            this.tbpCashier.ResumeLayout(false);
            this.tbpCashier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashier)).EndInit();
            this.tbpProgramOption.ResumeLayout(false);
            this.tbpProgramOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrmOption)).EndInit();
            this.tbpBitmapLogo.ResumeLayout(false);
            this.tbpBitmapLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.tbpNetwork.ResumeLayout(false);
            this.tbpNetwork.PerformLayout();
            this.tabSRVLogo.ResumeLayout(false);
            this.tabSRVVAT.ResumeLayout(false);
            this.tabSRVVAT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVATDefine)).EndInit();
            this.tabCCList.ResumeLayout(false);
            this.tabCCList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardInfoList)).EndInit();
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

                        //WEIGHABLE
                        selectedCell = (DataGridViewCheckBoxCell)dgvDepDefine.Rows[i].Cells[clmnDeptWeighable.Index];
                        int weighable = 0;
                        if (selectedCell.Value != null && ((bool)selectedCell.Value))
                        {
                            weighable = 1;
                        }

                        // Send Department Command
                        CPResponse response = new CPResponse(bridge.Printer.SetDepartment(deptNo, deptName,
                                                                vatGrpNo, price, weighable));

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

        #region SUBCATEGORY

        private void btnGetSubcategory_Click(object sender, EventArgs e)
        {
            dgvSubCategory.Rows.Clear();
            for (int i = 0; i < ProgramConfig.MAX_SUB_CAT_COUNT; i++)
            {
                try
                {
                    if (dgvSubCategory.Rows.Count % 10 == 0)
                    {
                        Application.DoEvents();
                    }

                    CPResponse response = new CPResponse(bridge.Printer.GetSubCategory(i));

                    if (response.ErrorCode == 0)
                    {
                        int index = dgvSubCategory.Rows.Add();
                        dgvSubCategory.Rows[index].Cells[clmnSubcatNo.Index].Value = i + 1;
                        dgvSubCategory.Rows[index].Cells[clmnSubcatName.Index].Value = response.GetNextParam();
                        dgvSubCategory.Rows[index].Cells[clmnSubcatMainNo.Index].Value = response.GetNextParam();
                    }
                }
                catch (System.Exception)
                {
                    bridge.Log(FormMessage.SUBCAT_NOT_GET);
                }
            }
        }

        private void btnSaveSubcategory_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvSubCategory.Rows.Count; i++)
            {
                try
                {
                    DataGridViewCheckBoxCell selected = (DataGridViewCheckBoxCell)dgvSubCategory.Rows[i].Cells[clmnSubcatSelect.Index];
                    if (selected.Value != null && (bool)selected.Value == true)
                    {
                        //NAME
                        String name = (String)dgvSubCategory.Rows[i].Cells[clmnSubcatName.Index].Value;

                        //MAIN CAT ID
                        int mainCatId = Convert.ToInt32(dgvSubCategory.Rows[i].Cells[clmnSubcatMainNo.Index].Value);

                        CPResponse response = new CPResponse(bridge.Printer.SetSubCategory(i, name, mainCatId));

                        if (response.ErrorCode == 0)
                        {
                            int scCatNo = i + 1;
                            string scName = response.GetNextParam();
                            string scMainCatNo = response.GetNextParam();
                            bridge.Log(String.Format("{3}: {0} {4}:{1,20} {5}: {2}",
                                scCatNo,
                                scName,
                                scMainCatNo,
                                FormMessage.GROUP_ID,
                                FormMessage.GROUP_NAME,
                                FormMessage.MAIN_CAT_ID));
                        }
                    }
                }
                catch (System.Exception)
                {
                    bridge.Log(FormMessage.SUBCAT_NOT_SAVE);
                }
            }
        }

        #endregion SUBCATEGORY

        #region CASHIER
        private void btnGetCashier_Click(object sender, EventArgs e)
        {
            dgvCashier.Rows.Clear();
            for (int i = 0; i < ProgramConfig.MAX_CASHIER_COUNT; i++)
            {
                try
                {
                    CPResponse response = new CPResponse(bridge.Printer.GetCashier(i));

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

                        CPResponse response = new CPResponse(bridge.Printer.SaveCashier(i, name, password));

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
            try
            {
#if CPP 

#else
                CPResponse response = new CPResponse(bridge.Printer.LoadGraphicLogo(pbxLogo.Image));
#endif
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
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
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
            catch (System.Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS);
            }
        }
        #endregion VAT

        private void btnSaveCardList_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> cardInfoList = new List<string>();
                for (int i = 0; i < dgvCardInfoList.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell selected = (DataGridViewCheckBoxCell)dgvCardInfoList.Rows[i].Cells[clmnCardInfoSelect.Index];
                    if (selected.Value != null && (bool)selected.Value == true)
                    {
                        //CCID
                        int ccid = Convert.ToInt32(dgvCardInfoList.Rows[i].Cells[clmnCCID.Index].Value);

                        //BIN
                        int bin = Convert.ToInt32(dgvCardInfoList.Rows[i].Cells[clmnBIN.Index].Value);

                        string ccname = (string)dgvCardInfoList.Rows[i].Cells[clmnCCName.Index].Value;

                        cardInfoList.Add(String.Format("{0}|{1:D}|{2:D}", ccid, ccname, bin));
                    }
                }
#if CPP

#else
                CPResponse response = new CPResponse(bridge.Printer.SaveCardInfoList(cardInfoList.ToArray()));
#endif
                
            }
            catch (System.Exception)
            {
                bridge.Log(FormMessage.SUBCAT_NOT_SAVE);
            }
        }

        private void btnOpenCVS_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofp = new OpenFileDialog();

                if (ofp.ShowDialog() == DialogResult.OK)
                {
                    if (!String.IsNullOrEmpty(ofp.FileName))
                    {
                        string[] lines = System.IO.File.ReadAllLines(ofp.FileName);
                        int rowIndex = 0;

                        foreach (string line in lines)
                        {
                            string[] splitted = line.Split(new char[] { ',' });

                            if (splitted.Length>2)
                            {
                                rowIndex = dgvCardInfoList.Rows.Add();

                                dgvCardInfoList.Rows[rowIndex].Cells[clmnCCID.Index].Value = splitted[0];
                                dgvCardInfoList.Rows[rowIndex].Cells[clmnCCName.Index].Value = splitted[1];
                                dgvCardInfoList.Rows[rowIndex].Cells[clmnBIN.Index].Value = splitted[2];
                                dgvCardInfoList.Rows[rowIndex].Cells[clmnCardInfoSelect.Index].Value = true;
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                bridge.Log(ex.Message);
            }
        }


    }
    public enum Settings
    {
        CUTTER,
        PAY_WITH_EFT,
        RECEIPT_LIMIT,
        GRAPHIC_LOGO,
        RECEIPT_BARCODE
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
}
