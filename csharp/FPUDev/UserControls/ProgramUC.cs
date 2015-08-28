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
        private DataGridViewTextBoxColumn clmnPLUNo;
        private DataGridViewTextBoxColumn clmnPLUName;
        private DataGridViewTextBoxColumn clmnPLUDeptNo;
        private DataGridViewTextBoxColumn clmnPLUPrice;
        private DataGridViewTextBoxColumn clmnPLUBarcode;
        private DataGridViewTextBoxColumn clmnPLUSubCat;
        private DataGridViewCheckBoxColumn clmnPLUWeighable;
        private DataGridViewCheckBoxColumn clmnPLUSelected;
        private DataGridViewCheckBoxColumn clmnPOSelect;
        public ProgramUC()
            : base()
        {
            InitializeComponent();


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
            this.lblDefineCredit = new System.Windows.Forms.Label();
            this.btnSaveCredits = new System.Windows.Forms.Button();
            this.btnGetCredits = new System.Windows.Forms.Button();
            this.dgvCredits = new System.Windows.Forms.DataGridView();
            this.clmnIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnCreditName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            this.tbcProgram.SuspendLayout();
            this.tbpDepTax.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepDefine)).BeginInit();
            this.tbpPLU.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPLUDefine)).BeginInit();
            this.tbpCredit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCredits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainCategory)).BeginInit();
            this.tbpCashier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashier)).BeginInit();
            this.tbpProgramOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrmOption)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcProgram
            // 
            this.tbcProgram.Controls.Add(this.tbpDepTax);
            this.tbcProgram.Controls.Add(this.tbpPLU);
            this.tbcProgram.Controls.Add(this.tbpCredit);
            this.tbcProgram.Controls.Add(this.tbpCashier);
            this.tbcProgram.Controls.Add(this.tbpProgramOption);
            this.tbcProgram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcProgram.Location = new System.Drawing.Point(0, 0);
            this.tbcProgram.Name = "tbcProgram";
            this.tbcProgram.SelectedIndex = 0;
            this.tbcProgram.Size = new System.Drawing.Size(788, 526);
            this.tbcProgram.TabIndex = 0;
            // 
            // tbpDepTax
            // 
            this.tbpDepTax.Controls.Add(this.lblDepartment);
            this.tbpDepTax.Controls.Add(this.btnSaveDepartment);
            this.tbpDepTax.Controls.Add(this.btnGetDepartment);
            this.tbpDepTax.Controls.Add(this.dgvDepDefine);
            this.tbpDepTax.Location = new System.Drawing.Point(4, 25);
            this.tbpDepTax.Name = "tbpDepTax";
            this.tbpDepTax.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDepTax.Size = new System.Drawing.Size(780, 497);
            this.tbpDepTax.TabIndex = 1;
            this.tbpDepTax.Text = "Kısım";
            this.tbpDepTax.UseVisualStyleBackColor = true;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDepartment.Location = new System.Drawing.Point(6, 8);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(177, 18);
            this.lblDepartment.TabIndex = 11;
            this.lblDepartment.Text = "Departman Tanımlama";
            // 
            // btnSaveDepartment
            // 
            this.btnSaveDepartment.Location = new System.Drawing.Point(124, 318);
            this.btnSaveDepartment.Name = "btnSaveDepartment";
            this.btnSaveDepartment.Size = new System.Drawing.Size(99, 47);
            this.btnSaveDepartment.TabIndex = 9;
            this.btnSaveDepartment.Text = "Departman Kaydet";
            this.btnSaveDepartment.UseVisualStyleBackColor = true;
            this.btnSaveDepartment.Click += new System.EventHandler(this.btnSaveDepartment_Click);
            // 
            // btnGetDepartment
            // 
            this.btnGetDepartment.Location = new System.Drawing.Point(9, 318);
            this.btnGetDepartment.Name = "btnGetDepartment";
            this.btnGetDepartment.Size = new System.Drawing.Size(99, 47);
            this.btnGetDepartment.TabIndex = 8;
            this.btnGetDepartment.Text = "Departman Getir";
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
            this.dgvDepDefine.Location = new System.Drawing.Point(9, 30);
            this.dgvDepDefine.Name = "dgvDepDefine";
            this.dgvDepDefine.RowHeadersVisible = false;
            this.dgvDepDefine.RowTemplate.Height = 24;
            this.dgvDepDefine.Size = new System.Drawing.Size(577, 282);
            this.dgvDepDefine.TabIndex = 7;
            // 
            // clmnDeptNo
            // 
            this.clmnDeptNo.HeaderText = "Kısım No";
            this.clmnDeptNo.MaxInputLength = 2;
            this.clmnDeptNo.Name = "clmnDeptNo";
            this.clmnDeptNo.ReadOnly = true;
            this.clmnDeptNo.Width = 50;
            // 
            // clmnDeptName
            // 
            this.clmnDeptName.HeaderText = "Kısım Adı";
            this.clmnDeptName.MaxInputLength = 18;
            this.clmnDeptName.Name = "clmnDeptName";
            // 
            // clmnDeptVatId
            // 
            this.clmnDeptVatId.HeaderText = "Kdv No";
            this.clmnDeptVatId.MaxInputLength = 1;
            this.clmnDeptVatId.Name = "clmnDeptVatId";
            this.clmnDeptVatId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnDeptVatId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmnDeptVatId.Width = 50;
            // 
            // clmnDeptPrice
            // 
            this.clmnDeptPrice.HeaderText = "Tutar";
            this.clmnDeptPrice.Name = "clmnDeptPrice";
            this.clmnDeptPrice.Width = 80;
            // 
            // clmnDeptWeighable
            // 
            this.clmnDeptWeighable.HeaderText = "Tartıla bilir";
            this.clmnDeptWeighable.Name = "clmnDeptWeighable";
            this.clmnDeptWeighable.Width = 50;
            // 
            // clmnSelectDepartment
            // 
            this.clmnSelectDepartment.HeaderText = "İşle?";
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
            this.tbpPLU.Location = new System.Drawing.Point(4, 25);
            this.tbpPLU.Name = "tbpPLU";
            this.tbpPLU.Padding = new System.Windows.Forms.Padding(3);
            this.tbpPLU.Size = new System.Drawing.Size(780, 497);
            this.tbpPLU.TabIndex = 3;
            this.tbpPLU.Text = "PLU";
            this.tbpPLU.UseVisualStyleBackColor = true;
            // 
            // lblInfoPLU
            // 
            this.lblInfoPLU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoPLU.AutoSize = true;
            this.lblInfoPLU.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblInfoPLU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoPLU.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblInfoPLU.Location = new System.Drawing.Point(761, 269);
            this.lblInfoPLU.Name = "lblInfoPLU";
            this.lblInfoPLU.Size = new System.Drawing.Size(16, 18);
            this.lblInfoPLU.TabIndex = 20;
            this.lblInfoPLU.Text = "?";
            this.lblInfoPLU.Click += new System.EventHandler(this.lblInfoPLU_Click);
            // 
            // txtPluAddress
            // 
            this.txtPluAddress.AccessibleDescription = "";
            this.txtPluAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPluAddress.Location = new System.Drawing.Point(606, 269);
            this.txtPluAddress.Name = "txtPluAddress";
            this.txtPluAddress.Size = new System.Drawing.Size(154, 22);
            this.txtPluAddress.TabIndex = 19;
            this.txtPluAddress.Tag = "Birden fazla PLU getirmek için PLU no aralarına virgül koyunuz. Aralık okumak içi" +
                "n iki değer arasına çizgi \'-\' koyunuz.";
            this.txtPluAddress.Text = "1-10";
            // 
            // lblPLUStart
            // 
            this.lblPLUStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPLUStart.AutoSize = true;
            this.lblPLUStart.Location = new System.Drawing.Point(603, 249);
            this.lblPLUStart.Name = "lblPLUStart";
            this.lblPLUStart.Size = new System.Drawing.Size(61, 17);
            this.lblPLUStart.TabIndex = 18;
            this.lblPLUStart.Text = "PLU No:";
            // 
            // lblDepDefine
            // 
            this.lblDepDefine.AutoSize = true;
            this.lblDepDefine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDepDefine.Location = new System.Drawing.Point(6, 8);
            this.lblDepDefine.Name = "lblDepDefine";
            this.lblDepDefine.Size = new System.Drawing.Size(177, 18);
            this.lblDepDefine.TabIndex = 15;
            this.lblDepDefine.Text = "Departman Tanımlama";
            // 
            // btnSavePLU
            // 
            this.btnSavePLU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSavePLU.Location = new System.Drawing.Point(649, 374);
            this.btnSavePLU.Name = "btnSavePLU";
            this.btnSavePLU.Size = new System.Drawing.Size(114, 47);
            this.btnSavePLU.TabIndex = 14;
            this.btnSavePLU.Text = "PLU Kaydet";
            this.btnSavePLU.UseVisualStyleBackColor = true;
            this.btnSavePLU.Click += new System.EventHandler(this.btnSavePLU_Click);
            // 
            // btnGetPLU
            // 
            this.btnGetPLU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetPLU.Location = new System.Drawing.Point(649, 309);
            this.btnGetPLU.Name = "btnGetPLU";
            this.btnGetPLU.Size = new System.Drawing.Size(114, 47);
            this.btnGetPLU.TabIndex = 13;
            this.btnGetPLU.Text = "PLU Getir";
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
            this.dgvPLUDefine.Location = new System.Drawing.Point(6, 30);
            this.dgvPLUDefine.Name = "dgvPLUDefine";
            this.dgvPLUDefine.RowHeadersVisible = false;
            this.dgvPLUDefine.RowTemplate.Height = 24;
            this.dgvPLUDefine.Size = new System.Drawing.Size(591, 461);
            this.dgvPLUDefine.TabIndex = 12;
            // 
            // clmnPLUNo
            // 
            this.clmnPLUNo.HeaderText = "PLU No";
            this.clmnPLUNo.MaxInputLength = 2;
            this.clmnPLUNo.Name = "clmnPLUNo";
            this.clmnPLUNo.ReadOnly = true;
            this.clmnPLUNo.Width = 50;
            // 
            // clmnPLUName
            // 
            this.clmnPLUName.HeaderText = "Ürün Adı";
            this.clmnPLUName.MaxInputLength = 20;
            this.clmnPLUName.Name = "clmnPLUName";
            this.clmnPLUName.Width = 150;
            // 
            // clmnPLUDeptNo
            // 
            this.clmnPLUDeptNo.HeaderText = "Kısım No";
            this.clmnPLUDeptNo.MaxInputLength = 1;
            this.clmnPLUDeptNo.Name = "clmnPLUDeptNo";
            this.clmnPLUDeptNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnPLUDeptNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmnPLUDeptNo.Width = 50;
            // 
            // clmnPLUPrice
            // 
            this.clmnPLUPrice.HeaderText = "Fiyat";
            this.clmnPLUPrice.Name = "clmnPLUPrice";
            this.clmnPLUPrice.Width = 80;
            // 
            // clmnPLUBarcode
            // 
            this.clmnPLUBarcode.HeaderText = "Barkod";
            this.clmnPLUBarcode.MaxInputLength = 20;
            this.clmnPLUBarcode.Name = "clmnPLUBarcode";
            this.clmnPLUBarcode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnPLUBarcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmnPLUSubCat
            // 
            this.clmnPLUSubCat.HeaderText = "Alt Kateg.";
            this.clmnPLUSubCat.Name = "clmnPLUSubCat";
            this.clmnPLUSubCat.Width = 50;
            // 
            // clmnPLUWeighable
            // 
            this.clmnPLUWeighable.HeaderText = "Tartıla bilir";
            this.clmnPLUWeighable.Name = "clmnPLUWeighable";
            this.clmnPLUWeighable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnPLUWeighable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmnPLUWeighable.Width = 50;
            // 
            // clmnPLUSelected
            // 
            this.clmnPLUSelected.HeaderText = "İşle?";
            this.clmnPLUSelected.Name = "clmnPLUSelected";
            this.clmnPLUSelected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnPLUSelected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmnPLUSelected.Width = 50;
            // 
            // tbpCredit
            // 
            this.tbpCredit.Controls.Add(this.lblDefineCredit);
            this.tbpCredit.Controls.Add(this.btnSaveCredits);
            this.tbpCredit.Controls.Add(this.btnGetCredits);
            this.tbpCredit.Controls.Add(this.dgvCredits);
            this.tbpCredit.Location = new System.Drawing.Point(4, 25);
            this.tbpCredit.Name = "tbpCredit";
            this.tbpCredit.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCredit.Size = new System.Drawing.Size(780, 497);
            this.tbpCredit.TabIndex = 2;
            this.tbpCredit.Text = "Kredi";
            this.tbpCredit.UseVisualStyleBackColor = true;
            // 
            // lblDefineCredit
            // 
            this.lblDefineCredit.AutoSize = true;
            this.lblDefineCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDefineCredit.Location = new System.Drawing.Point(6, 8);
            this.lblDefineCredit.Name = "lblDefineCredit";
            this.lblDefineCredit.Size = new System.Drawing.Size(134, 18);
            this.lblDefineCredit.TabIndex = 16;
            this.lblDefineCredit.Text = "Kredi Tanımlama";
            // 
            // btnSaveCredits
            // 
            this.btnSaveCredits.Location = new System.Drawing.Point(159, 315);
            this.btnSaveCredits.Name = "btnSaveCredits";
            this.btnSaveCredits.Size = new System.Drawing.Size(132, 38);
            this.btnSaveCredits.TabIndex = 3;
            this.btnSaveCredits.Text = "Kredi Kaydet";
            this.btnSaveCredits.UseVisualStyleBackColor = true;
            this.btnSaveCredits.Click += new System.EventHandler(this.btnSaveCredits_Click);
            // 
            // btnGetCredits
            // 
            this.btnGetCredits.Location = new System.Drawing.Point(6, 315);
            this.btnGetCredits.Name = "btnGetCredits";
            this.btnGetCredits.Size = new System.Drawing.Size(132, 38);
            this.btnGetCredits.TabIndex = 2;
            this.btnGetCredits.Text = "Kredi Getir";
            this.btnGetCredits.UseVisualStyleBackColor = true;
            this.btnGetCredits.Click += new System.EventHandler(this.btnGetCredits_Click);
            // 
            // dgvCredits
            // 
            this.dgvCredits.AllowUserToAddRows = false;
            this.dgvCredits.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCredits.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCredits.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCredits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCredits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnIndex,
            this.clmnCreditName,
            this.clmnSelected});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCredits.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCredits.Location = new System.Drawing.Point(6, 30);
            this.dgvCredits.Name = "dgvCredits";
            this.dgvCredits.RowHeadersVisible = false;
            this.dgvCredits.RowTemplate.Height = 24;
            this.dgvCredits.Size = new System.Drawing.Size(372, 279);
            this.dgvCredits.TabIndex = 0;
            // 
            // clmnIndex
            // 
            this.clmnIndex.HeaderText = "No";
            this.clmnIndex.MaxInputLength = 2;
            this.clmnIndex.Name = "clmnIndex";
            this.clmnIndex.ReadOnly = true;
            this.clmnIndex.Width = 50;
            // 
            // clmnCreditName
            // 
            this.clmnCreditName.HeaderText = "Kredi Adı";
            this.clmnCreditName.MaxInputLength = 16;
            this.clmnCreditName.Name = "clmnCreditName";
            this.clmnCreditName.Width = 200;
            // 
            // clmnSelected
            // 
            this.clmnSelected.HeaderText = "İşle?";
            this.clmnSelected.Name = "clmnSelected";
            this.clmnSelected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnSelected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // lblSubCategory
            // 
            this.lblSubCategory.AutoSize = true;
            this.lblSubCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSubCategory.Location = new System.Drawing.Point(352, 8);
            this.lblSubCategory.Name = "lblSubCategory";
            this.lblSubCategory.Size = new System.Drawing.Size(115, 18);
            this.lblSubCategory.TabIndex = 19;
            this.lblSubCategory.Text = "Alt Ürün grubu";
            // 
            // lblMainGrup
            // 
            this.lblMainGrup.AutoSize = true;
            this.lblMainGrup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMainGrup.Location = new System.Drawing.Point(6, 8);
            this.lblMainGrup.Name = "lblMainGrup";
            this.lblMainGrup.Size = new System.Drawing.Size(124, 18);
            this.lblMainGrup.TabIndex = 18;
            this.lblMainGrup.Text = "Ana Ürün grubu";
            // 
            // btnSaveSubcategory
            // 
            this.btnSaveSubcategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveSubcategory.Location = new System.Drawing.Point(503, 422);
            this.btnSaveSubcategory.Name = "btnSaveSubcategory";
            this.btnSaveSubcategory.Size = new System.Drawing.Size(135, 38);
            this.btnSaveSubcategory.TabIndex = 17;
            this.btnSaveSubcategory.Text = "Alt Grup Kaydet";
            this.btnSaveSubcategory.UseVisualStyleBackColor = true;
            this.btnSaveSubcategory.Click += new System.EventHandler(this.btnSaveSubcategory_Click);
            // 
            // btnGetSubcategory
            // 
            this.btnGetSubcategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGetSubcategory.Location = new System.Drawing.Point(355, 422);
            this.btnGetSubcategory.Name = "btnGetSubcategory";
            this.btnGetSubcategory.Size = new System.Drawing.Size(125, 38);
            this.btnGetSubcategory.TabIndex = 16;
            this.btnGetSubcategory.Text = "Alt Grup Getir";
            this.btnGetSubcategory.UseVisualStyleBackColor = true;
            this.btnGetSubcategory.Click += new System.EventHandler(this.btnGetSubcategory_Click);
            // 
            // dgvSubCategory
            // 
            this.dgvSubCategory.AllowUserToAddRows = false;
            this.dgvSubCategory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvSubCategory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
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
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSubCategory.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvSubCategory.Location = new System.Drawing.Point(355, 30);
            this.dgvSubCategory.Name = "dgvSubCategory";
            this.dgvSubCategory.RowHeadersVisible = false;
            this.dgvSubCategory.RowTemplate.Height = 24;
            this.dgvSubCategory.Size = new System.Drawing.Size(419, 387);
            this.dgvSubCategory.TabIndex = 15;
            // 
            // clmnSubcatNo
            // 
            this.clmnSubcatNo.HeaderText = "No";
            this.clmnSubcatNo.MaxInputLength = 2;
            this.clmnSubcatNo.Name = "clmnSubcatNo";
            this.clmnSubcatNo.ReadOnly = true;
            this.clmnSubcatNo.Width = 50;
            // 
            // clmnSubcatName
            // 
            this.clmnSubcatName.HeaderText = "Grup Adı";
            this.clmnSubcatName.MaxInputLength = 20;
            this.clmnSubcatName.Name = "clmnSubcatName";
            this.clmnSubcatName.Width = 150;
            // 
            // clmnSubcatMainNo
            // 
            this.clmnSubcatMainNo.HeaderText = "Ana Grup";
            this.clmnSubcatMainNo.MaxInputLength = 2;
            this.clmnSubcatMainNo.Name = "clmnSubcatMainNo";
            this.clmnSubcatMainNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnSubcatMainNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmnSubcatSelect
            // 
            this.clmnSubcatSelect.HeaderText = "İşle?";
            this.clmnSubcatSelect.Name = "clmnSubcatSelect";
            this.clmnSubcatSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnSubcatSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmnSubcatSelect.Width = 50;
            // 
            // btnSaveMainCategory
            // 
            this.btnSaveMainCategory.Location = new System.Drawing.Point(150, 422);
            this.btnSaveMainCategory.Name = "btnSaveMainCategory";
            this.btnSaveMainCategory.Size = new System.Drawing.Size(132, 35);
            this.btnSaveMainCategory.TabIndex = 14;
            this.btnSaveMainCategory.Text = "Ana Grup Kaydet";
            this.btnSaveMainCategory.UseVisualStyleBackColor = true;
            this.btnSaveMainCategory.Click += new System.EventHandler(this.btnSaveMainCategory_Click);
            // 
            // btnGetMainCategory
            // 
            this.btnGetMainCategory.Location = new System.Drawing.Point(3, 422);
            this.btnGetMainCategory.Name = "btnGetMainCategory";
            this.btnGetMainCategory.Size = new System.Drawing.Size(129, 35);
            this.btnGetMainCategory.TabIndex = 13;
            this.btnGetMainCategory.Text = "Ana Grup Getir";
            this.btnGetMainCategory.UseVisualStyleBackColor = true;
            this.btnGetMainCategory.Click += new System.EventHandler(this.btnGetMainCategory_Click);
            // 
            // dgvMainCategory
            // 
            this.dgvMainCategory.AllowUserToAddRows = false;
            this.dgvMainCategory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMainCategory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvMainCategory.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvMainCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMainCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnMainGrupNo,
            this.clmnMainGrupName,
            this.clmnMainGrupSelect});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMainCategory.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvMainCategory.Location = new System.Drawing.Point(6, 30);
            this.dgvMainCategory.Name = "dgvMainCategory";
            this.dgvMainCategory.RowHeadersVisible = false;
            this.dgvMainCategory.RowTemplate.Height = 24;
            this.dgvMainCategory.Size = new System.Drawing.Size(303, 386);
            this.dgvMainCategory.TabIndex = 12;
            // 
            // clmnMainGrupNo
            // 
            this.clmnMainGrupNo.HeaderText = "No";
            this.clmnMainGrupNo.MaxInputLength = 1;
            this.clmnMainGrupNo.Name = "clmnMainGrupNo";
            this.clmnMainGrupNo.ReadOnly = true;
            this.clmnMainGrupNo.Width = 50;
            // 
            // clmnMainGrupName
            // 
            this.clmnMainGrupName.HeaderText = "Grup Adı";
            this.clmnMainGrupName.MaxInputLength = 20;
            this.clmnMainGrupName.Name = "clmnMainGrupName";
            this.clmnMainGrupName.Width = 150;
            // 
            // clmnMainGrupSelect
            // 
            this.clmnMainGrupSelect.HeaderText = "İşle?";
            this.clmnMainGrupSelect.Name = "clmnMainGrupSelect";
            this.clmnMainGrupSelect.Width = 60;
            // 
            // tbpCashier
            // 
            this.tbpCashier.Controls.Add(this.lblCashier);
            this.tbpCashier.Controls.Add(this.btnSaveCashier);
            this.tbpCashier.Controls.Add(this.btnGetCashier);
            this.tbpCashier.Controls.Add(this.dgvCashier);
            this.tbpCashier.Location = new System.Drawing.Point(4, 25);
            this.tbpCashier.Name = "tbpCashier";
            this.tbpCashier.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCashier.Size = new System.Drawing.Size(780, 497);
            this.tbpCashier.TabIndex = 5;
            this.tbpCashier.Text = "Kasiyer";
            this.tbpCashier.UseVisualStyleBackColor = true;
            // 
            // lblCashier
            // 
            this.lblCashier.AutoSize = true;
            this.lblCashier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCashier.Location = new System.Drawing.Point(6, 8);
            this.lblCashier.Name = "lblCashier";
            this.lblCashier.Size = new System.Drawing.Size(118, 18);
            this.lblCashier.TabIndex = 22;
            this.lblCashier.Text = "Kasiyer Listesi";
            // 
            // btnSaveCashier
            // 
            this.btnSaveCashier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveCashier.Location = new System.Drawing.Point(153, 441);
            this.btnSaveCashier.Name = "btnSaveCashier";
            this.btnSaveCashier.Size = new System.Drawing.Size(120, 47);
            this.btnSaveCashier.TabIndex = 21;
            this.btnSaveCashier.Text = "Kasiyer Kaydet";
            this.btnSaveCashier.UseVisualStyleBackColor = true;
            this.btnSaveCashier.Click += new System.EventHandler(this.btnSaveCashier_Click);
            // 
            // btnGetCashier
            // 
            this.btnGetCashier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGetCashier.Location = new System.Drawing.Point(6, 441);
            this.btnGetCashier.Name = "btnGetCashier";
            this.btnGetCashier.Size = new System.Drawing.Size(120, 47);
            this.btnGetCashier.TabIndex = 20;
            this.btnGetCashier.Text = "Kasiyer Getir";
            this.btnGetCashier.UseVisualStyleBackColor = true;
            this.btnGetCashier.Click += new System.EventHandler(this.btnGetCashier_Click);
            // 
            // dgvCashier
            // 
            this.dgvCashier.AllowUserToAddRows = false;
            this.dgvCashier.AllowUserToDeleteRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCashier.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvCashier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvCashier.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCashier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCashier.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnCashierIndex,
            this.clmnCashierName,
            this.clmnCashierPassword,
            this.clmnCashierSelect});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCashier.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvCashier.Location = new System.Drawing.Point(6, 30);
            this.dgvCashier.Name = "dgvCashier";
            this.dgvCashier.RowHeadersVisible = false;
            this.dgvCashier.RowTemplate.Height = 24;
            this.dgvCashier.Size = new System.Drawing.Size(516, 405);
            this.dgvCashier.TabIndex = 19;
            // 
            // clmnCashierIndex
            // 
            this.clmnCashierIndex.HeaderText = "No";
            this.clmnCashierIndex.MaxInputLength = 1;
            this.clmnCashierIndex.Name = "clmnCashierIndex";
            this.clmnCashierIndex.ReadOnly = true;
            this.clmnCashierIndex.Width = 50;
            // 
            // clmnCashierName
            // 
            this.clmnCashierName.HeaderText = "Kasiyer Adı";
            this.clmnCashierName.MaxInputLength = 15;
            this.clmnCashierName.Name = "clmnCashierName";
            this.clmnCashierName.Width = 150;
            // 
            // clmnCashierPassword
            // 
            this.clmnCashierPassword.HeaderText = "Şifre";
            this.clmnCashierPassword.MaxInputLength = 6;
            this.clmnCashierPassword.Name = "clmnCashierPassword";
            // 
            // clmnCashierSelect
            // 
            this.clmnCashierSelect.HeaderText = "İşle?";
            this.clmnCashierSelect.Name = "clmnCashierSelect";
            this.clmnCashierSelect.Width = 50;
            // 
            // tbpProgramOption
            // 
            this.tbpProgramOption.Controls.Add(this.lblProgramOption);
            this.tbpProgramOption.Controls.Add(this.btnSavePrmOption);
            this.tbpProgramOption.Controls.Add(this.btnGetPrmOption);
            this.tbpProgramOption.Controls.Add(this.dgvPrmOption);
            this.tbpProgramOption.Location = new System.Drawing.Point(4, 25);
            this.tbpProgramOption.Name = "tbpProgramOption";
            this.tbpProgramOption.Padding = new System.Windows.Forms.Padding(3);
            this.tbpProgramOption.Size = new System.Drawing.Size(780, 497);
            this.tbpProgramOption.TabIndex = 6;
            this.tbpProgramOption.Text = "Program Ayarları";
            this.tbpProgramOption.UseVisualStyleBackColor = true;
            // 
            // lblProgramOption
            // 
            this.lblProgramOption.AutoSize = true;
            this.lblProgramOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblProgramOption.Location = new System.Drawing.Point(6, 8);
            this.lblProgramOption.Name = "lblProgramOption";
            this.lblProgramOption.Size = new System.Drawing.Size(134, 18);
            this.lblProgramOption.TabIndex = 26;
            this.lblProgramOption.Text = "Program Ayarları";
            // 
            // btnSavePrmOption
            // 
            this.btnSavePrmOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSavePrmOption.Location = new System.Drawing.Point(147, 431);
            this.btnSavePrmOption.Name = "btnSavePrmOption";
            this.btnSavePrmOption.Size = new System.Drawing.Size(120, 47);
            this.btnSavePrmOption.TabIndex = 25;
            this.btnSavePrmOption.Text = "Ayarları Kaydet";
            this.btnSavePrmOption.UseVisualStyleBackColor = true;
            this.btnSavePrmOption.Click += new System.EventHandler(this.btnSavePrmOption_Click);
            // 
            // btnGetPrmOption
            // 
            this.btnGetPrmOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGetPrmOption.Location = new System.Drawing.Point(6, 431);
            this.btnGetPrmOption.Name = "btnGetPrmOption";
            this.btnGetPrmOption.Size = new System.Drawing.Size(120, 47);
            this.btnGetPrmOption.TabIndex = 24;
            this.btnGetPrmOption.Text = "Ayarları Getir";
            this.btnGetPrmOption.UseVisualStyleBackColor = true;
            this.btnGetPrmOption.Click += new System.EventHandler(this.btnGetPrmOption_Click);
            // 
            // dgvPrmOption
            // 
            this.dgvPrmOption.AllowUserToAddRows = false;
            this.dgvPrmOption.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPrmOption.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
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
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPrmOption.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvPrmOption.Location = new System.Drawing.Point(6, 30);
            this.dgvPrmOption.Name = "dgvPrmOption";
            this.dgvPrmOption.RowHeadersVisible = false;
            this.dgvPrmOption.RowTemplate.Height = 24;
            this.dgvPrmOption.Size = new System.Drawing.Size(480, 384);
            this.dgvPrmOption.TabIndex = 23;
            // 
            // clmnPONo
            // 
            this.clmnPONo.HeaderText = "No";
            this.clmnPONo.MaxInputLength = 1;
            this.clmnPONo.Name = "clmnPONo";
            this.clmnPONo.ReadOnly = true;
            this.clmnPONo.Width = 50;
            // 
            // clmnPOName
            // 
            this.clmnPOName.HeaderText = "Parametre Adı";
            this.clmnPOName.MaxInputLength = 20;
            this.clmnPOName.Name = "clmnPOName";
            this.clmnPOName.Width = 250;
            // 
            // clmnPOValue
            // 
            this.clmnPOValue.HeaderText = "Değer";
            this.clmnPOValue.MaxInputLength = 20;
            this.clmnPOValue.Name = "clmnPOValue";
            // 
            // clmnPOSelect
            // 
            this.clmnPOSelect.HeaderText = "İşle?";
            this.clmnPOSelect.Name = "clmnPOSelect";
            this.clmnPOSelect.Width = 50;
            // 
            // ProgramUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbcProgram);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvCredits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainCategory)).EndInit();
            this.tbpCashier.ResumeLayout(false);
            this.tbpCashier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashier)).EndInit();
            this.tbpProgramOption.ResumeLayout(false);
            this.tbpProgramOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrmOption)).EndInit();
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

                    System.Threading.Thread.Sleep(ProgramConfig.SLEEP_TIMEOUT);
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
                    bridge.Log("Hata: Timeout Hatası");
                }
                catch
                {
                    bridge.Log("Hata: Hata oluştu");
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

                        System.Threading.Thread.Sleep(ProgramConfig.SLEEP_TIMEOUT);
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
                    bridge.Log("Hata: Timeout Hatası");
                }
                catch
                {
                    bridge.Log("Hata: Hata oluştu");
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
                    System.Threading.Thread.Sleep(ProgramConfig.SLEEP_TIMEOUT);
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
                    bridge.Log("Hata: Timeout Hatası");
                }
                catch
                {
                    bridge.Log("Hata: Hata oluştu");
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

                        System.Threading.Thread.Sleep(ProgramConfig.SLEEP_TIMEOUT);
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
                        bridge.Log("Hata: Timeout Hatası");
                    }
                    catch
                    {
                        bridge.Log("Hata: Hata oluştu");
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
                            System.Threading.Thread.Sleep(ProgramConfig.SLEEP_TIMEOUT);
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
                        System.Threading.Thread.Sleep(200);
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
                bridge.Log("Hata: Urun okunamadı. " + ex.Message);
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


                        System.Threading.Thread.Sleep(ProgramConfig.SLEEP_TIMEOUT);
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

                            bridge.Log(String.Format("Ürün Adı:{0,-20} Dep.No: {1,2} Fiyat: {2:#0.00} Tartılabilir:{3} Barkod: {4,-20} AltKate.:{5}",
                                p.Name,
                                p.Department,
                                p.Price,
                                p.Weighable == 1 ? "E" : "H",
                                p.Barcode,
                                p.SubCategory));
                        }
                    }
                }
                catch (Exception ex)
                {
                    bridge.Log("Hata: Urun kayıt edilemedi. " + ex.Message);
                }
            }

        }

        private void lblInfoPLU_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Birden fazla PLU getirmek için PLU no aralarına virgül koyunuz.\n" +
                            "Örnek: 1,5,7 \n" +
                            "Aralık okumak için iki değer arasına çizgi '-' koyunuz.\n" +
                            "Örnek: 1-20");
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

                    System.Threading.Thread.Sleep(ProgramConfig.SLEEP_TIMEOUT);
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
                    bridge.Log("Hata: Ana ürün grubu kayıt edilmedi. ");
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

                        System.Threading.Thread.Sleep(ProgramConfig.SLEEP_TIMEOUT);
                        CPResponse response = new CPResponse(bridge.Printer.SetMainCategory(i, name));

                        if (response.ErrorCode == 0)
                        {
                            int mcCatNo = i + 1;
                            string mcName = response.GetNextParam();
                            bridge.Log(String.Format("Grup No: {0} Grup Adı:{1} ",
                                mcCatNo,
                                mcName));
                        }
                    }
                }
                catch (System.Exception)
                {
                    bridge.Log("Hata: Ana ürün grubu alınamadı. ");
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

                    System.Threading.Thread.Sleep(ProgramConfig.SLEEP_TIMEOUT);
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
                    bridge.Log("Hata: Alt ürün grubu kayıt edilmedi. ");
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

                        System.Threading.Thread.Sleep(ProgramConfig.SLEEP_TIMEOUT);
                        CPResponse response = new CPResponse(bridge.Printer.SetSubCategory(i, name, mainCatId));

                        if (response.ErrorCode == 0)
                        {
                            int scCatNo = i + 1;
                            string scName = response.GetNextParam();
                            string scMainCatNo = response.GetNextParam();
                            bridge.Log(String.Format("Grup No: {0} Grup Adı:{1,20} Alt Grup: {2}",
                                scCatNo,
                                scName,
                                scMainCatNo));
                        }
                    }
                }
                catch (System.Exception)
                {
                    bridge.Log("Hata: Alt ürün grubu kayıt edilmedi. ");
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
                    System.Threading.Thread.Sleep(ProgramConfig.SLEEP_TIMEOUT);
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
                    bridge.Log("Hata: İşlem gerçekleştirilmedi. ");
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

                        System.Threading.Thread.Sleep(ProgramConfig.SLEEP_TIMEOUT);
                        CPResponse response = new CPResponse(bridge.Printer.SaveCashier(i, name, password));

                        if (response.ErrorCode == 0)
                        {
                            Cashier c = new Cashier();
                            c.Id = i + 1;
                            c.Name = response.GetNextParam();
                            bridge.Log(String.Format("Kasiyer Id: {0} Kasiyer Adı:{1}",
                                c.Id,
                                c.Name
                                ));
                        }
                    }
                }
                catch (System.Exception)
                {
                    bridge.Log("Hata: İşlem gerçekleştirilmedi ");
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
                    System.Threading.Thread.Sleep(ProgramConfig.SLEEP_TIMEOUT);
                    CPResponse response = new CPResponse(bridge.Printer.GetProgramOptions(i));

                    if (response.ErrorCode == 0)
                    {
                        int index = dgvPrmOption.Rows.Add();
                        dgvPrmOption.Rows[index].Cells[clmnPONo.Index].Value = i + 1;
                        dgvPrmOption.Rows[index].Cells[clmnPOName.Index].Value = names[i];
                        dgvPrmOption.Rows[index].Cells[clmnPOValue.Index].Value = response.GetNextParam();
                    }
                }
                catch (System.Exception)
                {
                    bridge.Log("Hata: İşlem gerçekleştirilmedi. ");
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
                        int name = (int)(dgvPrmOption.Rows[i].Cells[clmnPONo.Index].Value);

                        //Prop Value
                        String value = (String)dgvPrmOption.Rows[i].Cells[clmnPOValue.Index].Value;
                        switch ((Settings)i)
                        {
                            case Settings.RECEIPT_LIMIT:
                                String[] spltValue = value.Split(new char[] { ',' });
                                value = String.Format("{0}{1}", spltValue[0], spltValue[1].PadRight(3, '0'));
                                break;
                        }

                        System.Threading.Thread.Sleep(ProgramConfig.SLEEP_TIMEOUT);
                        CPResponse response = new CPResponse(bridge.Printer.SaveProgramOptions(name, value));

                        if (response.ErrorCode == 0)
                        {
                            
                            bridge.Log(String.Format("Program No: {0} Değer:{1}",
                                i + 1,
                                response.GetNextParam()
                                ));
                        }
                    }
                }
                catch (System.Exception)
                {
                    bridge.Log("Hata: İşlem gerçekleştirilmedi. ");
                }
            }
        }

        #endregion PROGRAM_OPTION

    }
    public enum Settings
    {
        RECEIPT_LIMIT
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
