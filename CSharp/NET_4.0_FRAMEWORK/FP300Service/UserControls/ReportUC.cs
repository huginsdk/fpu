using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
#if SINGLE_DLL
using Hugin.CompactPrinterFPU;
#elif CPP

#else
using Hugin.POS.CompactPrinter.FP300;
#endif


namespace FP300Service.UserControls
{
    public class ReportUC : TestUC
    {

        private static IBridge bridge = null;
        private static TestUC saleForm = null;
        private TabControl tbcReports;
        private TabPage tabXReports;
        private TabPage tabZReports;
        private RichTextBox txtResult;
        private Button btnPrintNonFiscReport;
        private RadioButton rbtnSystemInfoRprt;
        private RadioButton rbtPluRprt;
        private RadioButton rbtnXReport;
        private CheckBox cbxHard;
        private CheckBox cbxSoft;
        private RadioButton rbtnZReport;
        private Button btnPrintZReport;
        private GroupBox grpPrintArea;
        private NumericUpDown nmrPLUFirst;
        private Label lblFirstPlu;
        private NumericUpDown nmrPLULast;
        private Label lblPLULast;
        private TabPage tabEJSingle;
        private DateTimePicker dtEJSingDocTime;
        private DateTimePicker dtEJSingDocDate;
        private Label lblEJSingDocTime;
        private Label lblEJSingDocDate;
        private NumericUpDown nmrEJSingDocNo;
        private Label lblEJSingDocNo;
        private NumericUpDown nmrEJSingDocZNo;
        private Label lblEJSingDocZNo;
        private RadioButton rbtnEJDocCopyDate;
        private RadioButton rbtnEJDocCopyZandDocId;
        private TabPage tabEJPeriyot;
        private DateTimePicker dtEJPerFirstTime;
        private DateTimePicker dtEJPerFirstDate;
        private Label lblEJPerFistTime;
        private Label lblEJPerFirstZDt;
        private NumericUpDown nmrEJPerFirstDoc;
        private Label lblEJPerFirstDoc;
        private NumericUpDown nmrEJPerFirstZ;
        private Label lblEJPerFirstZ;
        private RadioButton rbtnEJPerByDate;
        private RadioButton rbtnEJPerByNo;
        private Button btnPrintEJPerReport;
        private RadioButton rbtnEJDetail;
        private DateTimePicker dtEJPerLastTime;
        private DateTimePicker dtEJPerLastDate;
        private Label lblEJPerLastTime;
        private Label lblEJPerLastDt;
        private NumericUpDown nmrEJPerLastDoc;
        private Label lblEJPerLastDoc;
        private NumericUpDown nmrEJPerLastZ;
        private Label lblEJPerLastZ;
        private NumericUpDown nmrEJZCopyZNo;
        private Label lblZCopyZno;
        private RadioButton rbtnZCopy;
        private DateTimePicker dtDailyDate;
        private Label lblEJPerDailyDate;
        private RadioButton rbtnEJPerByDaily;
        private RadioButton rbtnReceiptTotalReport;
        private TableLayoutPanel tableLayoutPanelReportUC;
        private TableLayoutPanel tableLayoutPanelReportUCLeftSide;
        private RadioButton rbtnEndDay;
        private Label lblAmountReturnDocZ;
        private Label lblCountReturnDocZ;
        private NumericUpDown numerAmountReturnDocZ;
        private NumericUpDown numerCountReturnDocZ;
        private CheckBox cbxAffectDrawerZ;
        private TabPage tabFMReports;
        private Button btnPrintFMReport;
        private CheckBox cbxFFZZDetailed;
        private CheckBox cbxFFDateDetailed;
        private DateTimePicker dtZZLastDate;
        private DateTimePicker dtZZFirstDate;
        private Label lblZZLastDate;
        private Label lblZZFirstDate;
        private NumericUpDown nmrFFZFirst;
        private Label lblFFZLast;
        private NumericUpDown nmrFFZLast;
        private Label lblFFZFirst;
        private RadioButton rbtnFiscDateReport;
        private RadioButton rbtnFiscZZReport;
        private CheckBox cbxAffectDrawerX;
        private NumericUpDown numerAmountReturnDocX;
        private NumericUpDown numerCountReturnDocX;
        private Label lblAmountReturnDocX;
        private Label lblCountReturnDocX;
        private Button btnReportContentX;
        private Button btnReportContentZ;
        private Button btnReportContentFM;
        private TabPage tabOtherDoc;
        private Button btnPrintODReport;
        private Label lblODocType;
        private ComboBox cbxOtherDocType;
        private DateTimePicker dtODPerLastDate;
        private Label lblODPerLastDt;
        private DateTimePicker dtODPerFirstDate;
        private Label lblODPerFirstDt;
        private RadioButton rBtnODocPeriodic;
        private RadioButton rBtnODocDaily;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnPrintEJSingReport;

        internal static TestUC Instance(IBridge iBridge)
        {
            if (saleForm == null)
            {
                bridge = iBridge;
                saleForm = new ReportUC();
            }

            return saleForm;
        }
#if !CPP
        void Printer_OnReportLine(object sender, OnReportLineEventArgs e)
        {
            AddReportLine(e.Line);     
        }
#endif

        private delegate void AddReportLineDelegate(string line);
        private void AddReportLine(string line)
        {
            if (txtResult.InvokeRequired)
            {
                txtResult.Invoke(new AddReportLineDelegate(AddReportLine), line);
            }
            else
            {
                txtResult.AppendText(line + Environment.NewLine);
                txtResult.ScrollToCaret();
            }
        }

        public ReportUC()
            :base()            
        {
            InitializeComponent();

            SetLanguageOption();

            cbxOtherDocType.Items.AddRange(Common.OtherDocTypes);
            cbxOtherDocType.SelectedIndex = 0;

#if !CPP
            if (bridge.Connection != null)
            {
                bridge.Printer.OnReportLine += new OnReportLineHandler(Printer_OnReportLine);
            }
#endif
#if EJ_READER
            tbcReports.Dock = DockStyle.Fill;
#endif
        }

        private void SetLanguageOption()
        {
            this.lblEJPerLastDoc.Text = FormMessage.LAST_DOC_ID;
            this.lblEJPerLastZ.Text = FormMessage.LAST_Z_ID;
            this.lblEJPerFistTime.Text = FormMessage.FIRST_HOUR;
            this.lblEJPerFirstZDt.Text = FormMessage.FIRST_DATE;
            this.lblEJPerFirstDoc.Text = FormMessage.FIRST_DOC_ID;
            this.lblEJPerFirstZ.Text = FormMessage.FIRST_Z_ID;
            this.rbtnEJPerByDate.Text = FormMessage.EJ_PERIODIC_REPORT_DATE_TIME;
            this.rbtnEJPerByNo.Text = FormMessage.EJ_PERIODIC_REPORT_ZID_DOCID;
            this.rbtnEJPerByDaily.Text = FormMessage.EJ_PERIODIC_DAILY;
            this.btnPrintEJPerReport.Text = FormMessage.GET_REPORT;
            this.cbxSoft.Text = FormMessage.CONTEXT;
            this.cbxHard.Text = FormMessage.PRINT;
            this.tabXReports.Text = FormMessage.X_REPORTS;
            this.rbtnReceiptTotalReport.Text = FormMessage.RECEIPT_TOTAL_REPORT;
            this.lblPLULast.Text = FormMessage.LAST_PLU;
            this.lblFirstPlu.Text = FormMessage.FIRST_PLU;
            this.rbtnSystemInfoRprt.Text = FormMessage.SYSTEM_INFO_REPORT;
            this.rbtPluRprt.Text = FormMessage.PLU_REPORT;
            this.rbtnXReport.Text = FormMessage.X_REPORT;
            this.btnPrintNonFiscReport.Text = FormMessage.GET_REPORT;
            this.tabZReports.Text = FormMessage.Z_REPORTS;
            this.cbxFFZZDetailed.Text = FormMessage.Z_DETAILED;
            this.cbxFFDateDetailed.Text = FormMessage.DATE_DETAILED;
            this.lblZZLastDate.Text = FormMessage.LAST_Z_DATE;
            this.lblZZFirstDate.Text = FormMessage.FIRST_Z_DATE;
            this.lblFFZLast.Text = FormMessage.LAST_Z_ID;
            this.lblFFZFirst.Text = FormMessage.FIRST_Z_ID;
            this.rbtnFiscDateReport.Text = FormMessage.FM_REPORT_DATE;
            this.rbtnFiscZZReport.Text = FormMessage.FM_REPORT_ZZ;
            this.rbtnZReport.Text = FormMessage.Z_REPORT;
            this.rbtnEndDay.Text = FormMessage.END_DAY_REPORT;
            this.btnPrintZReport.Text = FormMessage.GET_REPORT;
            this.tabEJSingle.Text = FormMessage.EJ_SINGLE_REPORT;
            this.lblZCopyZno.Text = FormMessage.Z_ID;
            this.rbtnZCopy.Text = FormMessage.Z_COPY;
            this.rbtnEJDetail.Text = FormMessage.EJ_DETAIL_REPORT;
            this.rbtnEJDocCopyDate.Text = FormMessage.EJ_SINGLE_REPORT_DATE_TIME;
            this.rbtnEJDocCopyZandDocId.Text = FormMessage.EJ_SINGLE_REPORT_ZID_DOCID;
            this.btnPrintEJSingReport.Text = FormMessage.GET_REPORT;
            this.tabEJPeriyot.Text = FormMessage.EJ_PERIODIC;
            this.lblEJPerLastTime.Text = FormMessage.LAST_HOUR;
            this.lblEJPerLastDt.Text = FormMessage.LAST_DATE;
            this.lblEJSingDocZNo.Text = FormMessage.Z_ID;
            this.lblEJSingDocNo.Text = FormMessage.DOCUMENT_ID;
            this.lblEJSingDocTime.Text = FormMessage.TIME;
            this.lblEJSingDocDate.Text = FormMessage.DATE;

            this.lblAmountReturnDocX.Text = FormMessage.RETURN_AMOUNT;
            this.lblCountReturnDocX.Text = FormMessage.RETURN_COUNT;
            this.cbxAffectDrawerX.Text = FormMessage.RETURN_AFFECT_DRAWER;

            this.lblAmountReturnDocZ.Text = FormMessage.RETURN_AMOUNT;
            this.lblCountReturnDocZ.Text = FormMessage.RETURN_COUNT;
            this.cbxAffectDrawerZ.Text = FormMessage.RETURN_AFFECT_DRAWER;
            this.btnPrintFMReport.Text = FormMessage.GET_REPORT;
            this.btnReportContentX.Text = FormMessage.REPORT_CONTENT;
            this.btnReportContentZ.Text = FormMessage.REPORT_CONTENT;
            this.btnReportContentFM.Text = FormMessage.REPORT_CONTENT;

            this.btnPrintODReport.Text = FormMessage.GET_REPORT;
            this.lblODocType.Text = FormMessage.OTHER_DOC_TYPE;
            this.rBtnODocDaily.Text = FormMessage.DAILY_OTHER_DOC_REPORT;
            this.rBtnODocPeriodic.Text = FormMessage.PERIODIC_OTHER_DOC_REPORT;
            this.lblODPerFirstDt.Text = FormMessage.FIRST_DATE;
            this.lblODPerLastDt.Text = FormMessage.LAST_DATE;
            this.tabOtherDoc.Text = FormMessage.OTHER_DOC;
        }
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpPrintArea = new System.Windows.Forms.GroupBox();
            this.cbxSoft = new System.Windows.Forms.CheckBox();
            this.cbxHard = new System.Windows.Forms.CheckBox();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.tbcReports = new System.Windows.Forms.TabControl();
            this.tabXReports = new System.Windows.Forms.TabPage();
            this.btnReportContentX = new System.Windows.Forms.Button();
            this.cbxAffectDrawerX = new System.Windows.Forms.CheckBox();
            this.numerAmountReturnDocX = new System.Windows.Forms.NumericUpDown();
            this.numerCountReturnDocX = new System.Windows.Forms.NumericUpDown();
            this.lblAmountReturnDocX = new System.Windows.Forms.Label();
            this.lblCountReturnDocX = new System.Windows.Forms.Label();
            this.rbtnReceiptTotalReport = new System.Windows.Forms.RadioButton();
            this.nmrPLULast = new System.Windows.Forms.NumericUpDown();
            this.lblPLULast = new System.Windows.Forms.Label();
            this.nmrPLUFirst = new System.Windows.Forms.NumericUpDown();
            this.lblFirstPlu = new System.Windows.Forms.Label();
            this.rbtnSystemInfoRprt = new System.Windows.Forms.RadioButton();
            this.rbtPluRprt = new System.Windows.Forms.RadioButton();
            this.rbtnXReport = new System.Windows.Forms.RadioButton();
            this.btnPrintNonFiscReport = new System.Windows.Forms.Button();
            this.tabZReports = new System.Windows.Forms.TabPage();
            this.btnReportContentZ = new System.Windows.Forms.Button();
            this.cbxAffectDrawerZ = new System.Windows.Forms.CheckBox();
            this.numerAmountReturnDocZ = new System.Windows.Forms.NumericUpDown();
            this.numerCountReturnDocZ = new System.Windows.Forms.NumericUpDown();
            this.lblAmountReturnDocZ = new System.Windows.Forms.Label();
            this.lblCountReturnDocZ = new System.Windows.Forms.Label();
            this.rbtnEndDay = new System.Windows.Forms.RadioButton();
            this.rbtnZReport = new System.Windows.Forms.RadioButton();
            this.btnPrintZReport = new System.Windows.Forms.Button();
            this.tabFMReports = new System.Windows.Forms.TabPage();
            this.btnReportContentFM = new System.Windows.Forms.Button();
            this.btnPrintFMReport = new System.Windows.Forms.Button();
            this.cbxFFZZDetailed = new System.Windows.Forms.CheckBox();
            this.cbxFFDateDetailed = new System.Windows.Forms.CheckBox();
            this.dtZZLastDate = new System.Windows.Forms.DateTimePicker();
            this.dtZZFirstDate = new System.Windows.Forms.DateTimePicker();
            this.lblZZLastDate = new System.Windows.Forms.Label();
            this.lblZZFirstDate = new System.Windows.Forms.Label();
            this.nmrFFZFirst = new System.Windows.Forms.NumericUpDown();
            this.lblFFZLast = new System.Windows.Forms.Label();
            this.nmrFFZLast = new System.Windows.Forms.NumericUpDown();
            this.lblFFZFirst = new System.Windows.Forms.Label();
            this.rbtnFiscDateReport = new System.Windows.Forms.RadioButton();
            this.rbtnFiscZZReport = new System.Windows.Forms.RadioButton();
            this.tabEJSingle = new System.Windows.Forms.TabPage();
            this.nmrEJZCopyZNo = new System.Windows.Forms.NumericUpDown();
            this.lblZCopyZno = new System.Windows.Forms.Label();
            this.rbtnZCopy = new System.Windows.Forms.RadioButton();
            this.rbtnEJDetail = new System.Windows.Forms.RadioButton();
            this.dtEJSingDocTime = new System.Windows.Forms.DateTimePicker();
            this.dtEJSingDocDate = new System.Windows.Forms.DateTimePicker();
            this.lblEJSingDocTime = new System.Windows.Forms.Label();
            this.lblEJSingDocDate = new System.Windows.Forms.Label();
            this.nmrEJSingDocNo = new System.Windows.Forms.NumericUpDown();
            this.lblEJSingDocNo = new System.Windows.Forms.Label();
            this.nmrEJSingDocZNo = new System.Windows.Forms.NumericUpDown();
            this.lblEJSingDocZNo = new System.Windows.Forms.Label();
            this.rbtnEJDocCopyDate = new System.Windows.Forms.RadioButton();
            this.rbtnEJDocCopyZandDocId = new System.Windows.Forms.RadioButton();
            this.btnPrintEJSingReport = new System.Windows.Forms.Button();
            this.tabEJPeriyot = new System.Windows.Forms.TabPage();
            this.dtDailyDate = new System.Windows.Forms.DateTimePicker();
            this.lblEJPerDailyDate = new System.Windows.Forms.Label();
            this.rbtnEJPerByDaily = new System.Windows.Forms.RadioButton();
            this.dtEJPerLastTime = new System.Windows.Forms.DateTimePicker();
            this.dtEJPerLastDate = new System.Windows.Forms.DateTimePicker();
            this.lblEJPerLastTime = new System.Windows.Forms.Label();
            this.lblEJPerLastDt = new System.Windows.Forms.Label();
            this.nmrEJPerLastDoc = new System.Windows.Forms.NumericUpDown();
            this.lblEJPerLastDoc = new System.Windows.Forms.Label();
            this.nmrEJPerLastZ = new System.Windows.Forms.NumericUpDown();
            this.lblEJPerLastZ = new System.Windows.Forms.Label();
            this.dtEJPerFirstTime = new System.Windows.Forms.DateTimePicker();
            this.dtEJPerFirstDate = new System.Windows.Forms.DateTimePicker();
            this.lblEJPerFistTime = new System.Windows.Forms.Label();
            this.lblEJPerFirstZDt = new System.Windows.Forms.Label();
            this.nmrEJPerFirstDoc = new System.Windows.Forms.NumericUpDown();
            this.lblEJPerFirstDoc = new System.Windows.Forms.Label();
            this.nmrEJPerFirstZ = new System.Windows.Forms.NumericUpDown();
            this.lblEJPerFirstZ = new System.Windows.Forms.Label();
            this.rbtnEJPerByDate = new System.Windows.Forms.RadioButton();
            this.rbtnEJPerByNo = new System.Windows.Forms.RadioButton();
            this.btnPrintEJPerReport = new System.Windows.Forms.Button();
            this.tabOtherDoc = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblODocType = new System.Windows.Forms.Label();
            this.cbxOtherDocType = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblODPerFirstDt = new System.Windows.Forms.Label();
            this.dtODPerLastDate = new System.Windows.Forms.DateTimePicker();
            this.dtODPerFirstDate = new System.Windows.Forms.DateTimePicker();
            this.lblODPerLastDt = new System.Windows.Forms.Label();
            this.rBtnODocPeriodic = new System.Windows.Forms.RadioButton();
            this.rBtnODocDaily = new System.Windows.Forms.RadioButton();
            this.btnPrintODReport = new System.Windows.Forms.Button();
            this.tableLayoutPanelReportUC = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelReportUCLeftSide = new System.Windows.Forms.TableLayoutPanel();
            this.grpPrintArea.SuspendLayout();
            this.tbcReports.SuspendLayout();
            this.tabXReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numerAmountReturnDocX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numerCountReturnDocX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPLULast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPLUFirst)).BeginInit();
            this.tabZReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numerAmountReturnDocZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numerCountReturnDocZ)).BeginInit();
            this.tabFMReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrFFZFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrFFZLast)).BeginInit();
            this.tabEJSingle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrEJZCopyZNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrEJSingDocNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrEJSingDocZNo)).BeginInit();
            this.tabEJPeriyot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrEJPerLastDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrEJPerLastZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrEJPerFirstDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrEJPerFirstZ)).BeginInit();
            this.tabOtherDoc.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelReportUC.SuspendLayout();
            this.tableLayoutPanelReportUCLeftSide.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPrintArea
            // 
            this.grpPrintArea.Controls.Add(this.cbxSoft);
            this.grpPrintArea.Controls.Add(this.cbxHard);
            this.grpPrintArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPrintArea.Location = new System.Drawing.Point(2, 2);
            this.grpPrintArea.Margin = new System.Windows.Forms.Padding(2);
            this.grpPrintArea.Name = "grpPrintArea";
            this.grpPrintArea.Padding = new System.Windows.Forms.Padding(2);
            this.grpPrintArea.Size = new System.Drawing.Size(285, 38);
            this.grpPrintArea.TabIndex = 2;
            this.grpPrintArea.TabStop = false;
            // 
            // cbxSoft
            // 
            this.cbxSoft.AutoSize = true;
            this.cbxSoft.Checked = true;
            this.cbxSoft.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxSoft.Location = new System.Drawing.Point(12, 12);
            this.cbxSoft.Margin = new System.Windows.Forms.Padding(2);
            this.cbxSoft.Name = "cbxSoft";
            this.cbxSoft.Size = new System.Drawing.Size(61, 17);
            this.cbxSoft.TabIndex = 3;
            this.cbxSoft.Text = "İÇERİK";
            this.cbxSoft.UseVisualStyleBackColor = true;
            // 
            // cbxHard
            // 
            this.cbxHard.AutoSize = true;
            this.cbxHard.Checked = true;
            this.cbxHard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxHard.Location = new System.Drawing.Point(76, 12);
            this.cbxHard.Margin = new System.Windows.Forms.Padding(2);
            this.cbxHard.Name = "cbxHard";
            this.cbxHard.Size = new System.Drawing.Size(59, 17);
            this.cbxHard.TabIndex = 4;
            this.cbxHard.Text = "PRINT";
            this.cbxHard.UseVisualStyleBackColor = true;
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtResult.Location = new System.Drawing.Point(297, 2);
            this.txtResult.Margin = new System.Windows.Forms.Padding(2);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(292, 423);
            this.txtResult.TabIndex = 1;
            this.txtResult.Text = "";
            // 
            // tbcReports
            // 
            this.tbcReports.Controls.Add(this.tabXReports);
            this.tbcReports.Controls.Add(this.tabZReports);
            this.tbcReports.Controls.Add(this.tabFMReports);
            this.tbcReports.Controls.Add(this.tabEJSingle);
            this.tbcReports.Controls.Add(this.tabEJPeriyot);
            this.tbcReports.Controls.Add(this.tabOtherDoc);
            this.tbcReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcReports.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbcReports.Location = new System.Drawing.Point(2, 44);
            this.tbcReports.Margin = new System.Windows.Forms.Padding(2);
            this.tbcReports.Multiline = true;
            this.tbcReports.Name = "tbcReports";
            this.tbcReports.SelectedIndex = 0;
            this.tbcReports.Size = new System.Drawing.Size(285, 375);
            this.tbcReports.TabIndex = 0;
            // 
            // tabXReports
            // 
            this.tabXReports.Controls.Add(this.btnReportContentX);
            this.tabXReports.Controls.Add(this.cbxAffectDrawerX);
            this.tabXReports.Controls.Add(this.numerAmountReturnDocX);
            this.tabXReports.Controls.Add(this.numerCountReturnDocX);
            this.tabXReports.Controls.Add(this.lblAmountReturnDocX);
            this.tabXReports.Controls.Add(this.lblCountReturnDocX);
            this.tabXReports.Controls.Add(this.rbtnReceiptTotalReport);
            this.tabXReports.Controls.Add(this.nmrPLULast);
            this.tabXReports.Controls.Add(this.lblPLULast);
            this.tabXReports.Controls.Add(this.nmrPLUFirst);
            this.tabXReports.Controls.Add(this.lblFirstPlu);
            this.tabXReports.Controls.Add(this.rbtnSystemInfoRprt);
            this.tabXReports.Controls.Add(this.rbtPluRprt);
            this.tabXReports.Controls.Add(this.rbtnXReport);
            this.tabXReports.Controls.Add(this.btnPrintNonFiscReport);
            this.tabXReports.Location = new System.Drawing.Point(4, 38);
            this.tabXReports.Margin = new System.Windows.Forms.Padding(2);
            this.tabXReports.Name = "tabXReports";
            this.tabXReports.Padding = new System.Windows.Forms.Padding(2);
            this.tabXReports.Size = new System.Drawing.Size(277, 333);
            this.tabXReports.TabIndex = 0;
            this.tabXReports.Text = "X REPORTS";
            this.tabXReports.UseVisualStyleBackColor = true;
            // 
            // btnReportContentX
            // 
            this.btnReportContentX.Location = new System.Drawing.Point(144, 272);
            this.btnReportContentX.Margin = new System.Windows.Forms.Padding(2);
            this.btnReportContentX.Name = "btnReportContentX";
            this.btnReportContentX.Size = new System.Drawing.Size(125, 52);
            this.btnReportContentX.TabIndex = 37;
            this.btnReportContentX.Text = "CONTENT";
            this.btnReportContentX.UseVisualStyleBackColor = true;
            this.btnReportContentX.Click += new System.EventHandler(this.btnReportContent_Click);
            // 
            // cbxAffectDrawerX
            // 
            this.cbxAffectDrawerX.AutoSize = true;
            this.cbxAffectDrawerX.Location = new System.Drawing.Point(145, 88);
            this.cbxAffectDrawerX.Name = "cbxAffectDrawerX";
            this.cbxAffectDrawerX.Size = new System.Drawing.Size(92, 18);
            this.cbxAffectDrawerX.TabIndex = 36;
            this.cbxAffectDrawerX.Text = "Affect Drawer";
            this.cbxAffectDrawerX.UseVisualStyleBackColor = true;
            // 
            // numerAmountReturnDocX
            // 
            this.numerAmountReturnDocX.DecimalPlaces = 2;
            this.numerAmountReturnDocX.Location = new System.Drawing.Point(144, 60);
            this.numerAmountReturnDocX.Name = "numerAmountReturnDocX";
            this.numerAmountReturnDocX.Size = new System.Drawing.Size(80, 19);
            this.numerAmountReturnDocX.TabIndex = 35;
            this.numerAmountReturnDocX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numerCountReturnDocX
            // 
            this.numerCountReturnDocX.Location = new System.Drawing.Point(171, 37);
            this.numerCountReturnDocX.Name = "numerCountReturnDocX";
            this.numerCountReturnDocX.Size = new System.Drawing.Size(53, 19);
            this.numerCountReturnDocX.TabIndex = 34;
            this.numerCountReturnDocX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAmountReturnDocX
            // 
            this.lblAmountReturnDocX.AutoSize = true;
            this.lblAmountReturnDocX.Location = new System.Drawing.Point(25, 60);
            this.lblAmountReturnDocX.Name = "lblAmountReturnDocX";
            this.lblAmountReturnDocX.Size = new System.Drawing.Size(108, 14);
            this.lblAmountReturnDocX.TabIndex = 33;
            this.lblAmountReturnDocX.Text = "AMOUNT RETURN:";
            // 
            // lblCountReturnDocX
            // 
            this.lblCountReturnDocX.AutoSize = true;
            this.lblCountReturnDocX.Location = new System.Drawing.Point(25, 37);
            this.lblCountReturnDocX.Name = "lblCountReturnDocX";
            this.lblCountReturnDocX.Size = new System.Drawing.Size(97, 14);
            this.lblCountReturnDocX.TabIndex = 32;
            this.lblCountReturnDocX.Text = "COUNT RETURN:";
            // 
            // rbtnReceiptTotalReport
            // 
            this.rbtnReceiptTotalReport.AutoSize = true;
            this.rbtnReceiptTotalReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnReceiptTotalReport.Location = new System.Drawing.Point(16, 237);
            this.rbtnReceiptTotalReport.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnReceiptTotalReport.Name = "rbtnReceiptTotalReport";
            this.rbtnReceiptTotalReport.Size = new System.Drawing.Size(185, 17);
            this.rbtnReceiptTotalReport.TabIndex = 12;
            this.rbtnReceiptTotalReport.Text = "RECEIPTS TOTAL REPORT";
            this.rbtnReceiptTotalReport.UseVisualStyleBackColor = true;
            // 
            // nmrPLULast
            // 
            this.nmrPLULast.Location = new System.Drawing.Point(118, 161);
            this.nmrPLULast.Margin = new System.Windows.Forms.Padding(2);
            this.nmrPLULast.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nmrPLULast.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrPLULast.Name = "nmrPLULast";
            this.nmrPLULast.Size = new System.Drawing.Size(68, 19);
            this.nmrPLULast.TabIndex = 11;
            this.nmrPLULast.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrPLULast.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPLULast
            // 
            this.lblPLULast.AutoSize = true;
            this.lblPLULast.Location = new System.Drawing.Point(32, 162);
            this.lblPLULast.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPLULast.Name = "lblPLULast";
            this.lblPLULast.Size = new System.Drawing.Size(66, 14);
            this.lblPLULast.TabIndex = 10;
            this.lblPLULast.Text = "LAST PLU :";
            // 
            // nmrPLUFirst
            // 
            this.nmrPLUFirst.Location = new System.Drawing.Point(118, 136);
            this.nmrPLUFirst.Margin = new System.Windows.Forms.Padding(2);
            this.nmrPLUFirst.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nmrPLUFirst.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrPLUFirst.Name = "nmrPLUFirst";
            this.nmrPLUFirst.Size = new System.Drawing.Size(68, 19);
            this.nmrPLUFirst.TabIndex = 9;
            this.nmrPLUFirst.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrPLUFirst.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblFirstPlu
            // 
            this.lblFirstPlu.AutoSize = true;
            this.lblFirstPlu.Location = new System.Drawing.Point(32, 137);
            this.lblFirstPlu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFirstPlu.Name = "lblFirstPlu";
            this.lblFirstPlu.Size = new System.Drawing.Size(68, 14);
            this.lblFirstPlu.TabIndex = 8;
            this.lblFirstPlu.Text = "FIRST PLU :";
            // 
            // rbtnSystemInfoRprt
            // 
            this.rbtnSystemInfoRprt.AutoSize = true;
            this.rbtnSystemInfoRprt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnSystemInfoRprt.Location = new System.Drawing.Point(16, 200);
            this.rbtnSystemInfoRprt.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnSystemInfoRprt.Name = "rbtnSystemInfoRprt";
            this.rbtnSystemInfoRprt.Size = new System.Drawing.Size(163, 17);
            this.rbtnSystemInfoRprt.TabIndex = 7;
            this.rbtnSystemInfoRprt.Text = "SYSTEM INFO REPORT";
            this.rbtnSystemInfoRprt.UseVisualStyleBackColor = true;
            // 
            // rbtPluRprt
            // 
            this.rbtPluRprt.AutoSize = true;
            this.rbtPluRprt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtPluRprt.Location = new System.Drawing.Point(16, 111);
            this.rbtPluRprt.Margin = new System.Windows.Forms.Padding(2);
            this.rbtPluRprt.Name = "rbtPluRprt";
            this.rbtPluRprt.Size = new System.Drawing.Size(104, 17);
            this.rbtPluRprt.TabIndex = 6;
            this.rbtPluRprt.Text = "PLU REPORT";
            this.rbtPluRprt.UseVisualStyleBackColor = true;
            // 
            // rbtnXReport
            // 
            this.rbtnXReport.AutoSize = true;
            this.rbtnXReport.Checked = true;
            this.rbtnXReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnXReport.Location = new System.Drawing.Point(16, 16);
            this.rbtnXReport.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnXReport.Name = "rbtnXReport";
            this.rbtnXReport.Size = new System.Drawing.Size(88, 17);
            this.rbtnXReport.TabIndex = 5;
            this.rbtnXReport.TabStop = true;
            this.rbtnXReport.Text = "X REPORT";
            this.rbtnXReport.UseVisualStyleBackColor = true;
            // 
            // btnPrintNonFiscReport
            // 
            this.btnPrintNonFiscReport.Location = new System.Drawing.Point(9, 272);
            this.btnPrintNonFiscReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrintNonFiscReport.Name = "btnPrintNonFiscReport";
            this.btnPrintNonFiscReport.Size = new System.Drawing.Size(125, 52);
            this.btnPrintNonFiscReport.TabIndex = 0;
            this.btnPrintNonFiscReport.Text = "GET REPORT";
            this.btnPrintNonFiscReport.UseVisualStyleBackColor = true;
            this.btnPrintNonFiscReport.Click += new System.EventHandler(this.btnXReports_Click);
            // 
            // tabZReports
            // 
            this.tabZReports.Controls.Add(this.btnReportContentZ);
            this.tabZReports.Controls.Add(this.cbxAffectDrawerZ);
            this.tabZReports.Controls.Add(this.numerAmountReturnDocZ);
            this.tabZReports.Controls.Add(this.numerCountReturnDocZ);
            this.tabZReports.Controls.Add(this.lblAmountReturnDocZ);
            this.tabZReports.Controls.Add(this.lblCountReturnDocZ);
            this.tabZReports.Controls.Add(this.rbtnEndDay);
            this.tabZReports.Controls.Add(this.rbtnZReport);
            this.tabZReports.Controls.Add(this.btnPrintZReport);
            this.tabZReports.Location = new System.Drawing.Point(4, 38);
            this.tabZReports.Margin = new System.Windows.Forms.Padding(2);
            this.tabZReports.Name = "tabZReports";
            this.tabZReports.Padding = new System.Windows.Forms.Padding(2);
            this.tabZReports.Size = new System.Drawing.Size(277, 333);
            this.tabZReports.TabIndex = 1;
            this.tabZReports.Text = "Z REPORTS";
            this.tabZReports.UseVisualStyleBackColor = true;
            // 
            // btnReportContentZ
            // 
            this.btnReportContentZ.Location = new System.Drawing.Point(144, 272);
            this.btnReportContentZ.Margin = new System.Windows.Forms.Padding(2);
            this.btnReportContentZ.Name = "btnReportContentZ";
            this.btnReportContentZ.Size = new System.Drawing.Size(125, 52);
            this.btnReportContentZ.TabIndex = 32;
            this.btnReportContentZ.Text = "CONTENT";
            this.btnReportContentZ.UseVisualStyleBackColor = true;
            this.btnReportContentZ.Click += new System.EventHandler(this.btnReportContent_Click);
            // 
            // cbxAffectDrawerZ
            // 
            this.cbxAffectDrawerZ.AutoSize = true;
            this.cbxAffectDrawerZ.Location = new System.Drawing.Point(137, 97);
            this.cbxAffectDrawerZ.Name = "cbxAffectDrawerZ";
            this.cbxAffectDrawerZ.Size = new System.Drawing.Size(92, 18);
            this.cbxAffectDrawerZ.TabIndex = 31;
            this.cbxAffectDrawerZ.Text = "Affect Drawer";
            this.cbxAffectDrawerZ.UseVisualStyleBackColor = true;
            // 
            // numerAmountReturnDocZ
            // 
            this.numerAmountReturnDocZ.DecimalPlaces = 2;
            this.numerAmountReturnDocZ.Location = new System.Drawing.Point(136, 66);
            this.numerAmountReturnDocZ.Name = "numerAmountReturnDocZ";
            this.numerAmountReturnDocZ.Size = new System.Drawing.Size(80, 19);
            this.numerAmountReturnDocZ.TabIndex = 30;
            this.numerAmountReturnDocZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numerCountReturnDocZ
            // 
            this.numerCountReturnDocZ.Location = new System.Drawing.Point(163, 44);
            this.numerCountReturnDocZ.Name = "numerCountReturnDocZ";
            this.numerCountReturnDocZ.Size = new System.Drawing.Size(53, 19);
            this.numerCountReturnDocZ.TabIndex = 29;
            this.numerCountReturnDocZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAmountReturnDocZ
            // 
            this.lblAmountReturnDocZ.AutoSize = true;
            this.lblAmountReturnDocZ.Location = new System.Drawing.Point(17, 66);
            this.lblAmountReturnDocZ.Name = "lblAmountReturnDocZ";
            this.lblAmountReturnDocZ.Size = new System.Drawing.Size(108, 14);
            this.lblAmountReturnDocZ.TabIndex = 28;
            this.lblAmountReturnDocZ.Text = "AMOUNT RETURN:";
            // 
            // lblCountReturnDocZ
            // 
            this.lblCountReturnDocZ.AutoSize = true;
            this.lblCountReturnDocZ.Location = new System.Drawing.Point(17, 44);
            this.lblCountReturnDocZ.Name = "lblCountReturnDocZ";
            this.lblCountReturnDocZ.Size = new System.Drawing.Size(97, 14);
            this.lblCountReturnDocZ.TabIndex = 27;
            this.lblCountReturnDocZ.Text = "COUNT RETURN:";
            // 
            // rbtnEndDay
            // 
            this.rbtnEndDay.AutoSize = true;
            this.rbtnEndDay.Checked = true;
            this.rbtnEndDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnEndDay.Location = new System.Drawing.Point(16, 151);
            this.rbtnEndDay.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnEndDay.Name = "rbtnEndDay";
            this.rbtnEndDay.Size = new System.Drawing.Size(135, 17);
            this.rbtnEndDay.TabIndex = 26;
            this.rbtnEndDay.TabStop = true;
            this.rbtnEndDay.Text = "END DAY REPORT";
            this.rbtnEndDay.UseVisualStyleBackColor = true;
            // 
            // rbtnZReport
            // 
            this.rbtnZReport.AutoSize = true;
            this.rbtnZReport.Checked = true;
            this.rbtnZReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnZReport.Location = new System.Drawing.Point(16, 16);
            this.rbtnZReport.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnZReport.Name = "rbtnZReport";
            this.rbtnZReport.Size = new System.Drawing.Size(88, 17);
            this.rbtnZReport.TabIndex = 11;
            this.rbtnZReport.TabStop = true;
            this.rbtnZReport.Text = "Z REPORT";
            this.rbtnZReport.UseVisualStyleBackColor = true;
            // 
            // btnPrintZReport
            // 
            this.btnPrintZReport.Location = new System.Drawing.Point(9, 272);
            this.btnPrintZReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrintZReport.Name = "btnPrintZReport";
            this.btnPrintZReport.Size = new System.Drawing.Size(125, 52);
            this.btnPrintZReport.TabIndex = 8;
            this.btnPrintZReport.Text = "GET REPORT";
            this.btnPrintZReport.UseVisualStyleBackColor = true;
            this.btnPrintZReport.Click += new System.EventHandler(this.btnPrintZReports_Click);
            // 
            // tabFMReports
            // 
            this.tabFMReports.Controls.Add(this.btnReportContentFM);
            this.tabFMReports.Controls.Add(this.btnPrintFMReport);
            this.tabFMReports.Controls.Add(this.cbxFFZZDetailed);
            this.tabFMReports.Controls.Add(this.cbxFFDateDetailed);
            this.tabFMReports.Controls.Add(this.dtZZLastDate);
            this.tabFMReports.Controls.Add(this.dtZZFirstDate);
            this.tabFMReports.Controls.Add(this.lblZZLastDate);
            this.tabFMReports.Controls.Add(this.lblZZFirstDate);
            this.tabFMReports.Controls.Add(this.nmrFFZFirst);
            this.tabFMReports.Controls.Add(this.lblFFZLast);
            this.tabFMReports.Controls.Add(this.nmrFFZLast);
            this.tabFMReports.Controls.Add(this.lblFFZFirst);
            this.tabFMReports.Controls.Add(this.rbtnFiscDateReport);
            this.tabFMReports.Controls.Add(this.rbtnFiscZZReport);
            this.tabFMReports.Location = new System.Drawing.Point(4, 38);
            this.tabFMReports.Margin = new System.Windows.Forms.Padding(2);
            this.tabFMReports.Name = "tabFMReports";
            this.tabFMReports.Padding = new System.Windows.Forms.Padding(2);
            this.tabFMReports.Size = new System.Drawing.Size(277, 333);
            this.tabFMReports.TabIndex = 4;
            this.tabFMReports.Text = "FM REPORTS";
            this.tabFMReports.UseVisualStyleBackColor = true;
            // 
            // btnReportContentFM
            // 
            this.btnReportContentFM.Location = new System.Drawing.Point(144, 272);
            this.btnReportContentFM.Margin = new System.Windows.Forms.Padding(2);
            this.btnReportContentFM.Name = "btnReportContentFM";
            this.btnReportContentFM.Size = new System.Drawing.Size(125, 52);
            this.btnReportContentFM.TabIndex = 39;
            this.btnReportContentFM.Text = "CONTENT";
            this.btnReportContentFM.UseVisualStyleBackColor = true;
            this.btnReportContentFM.Click += new System.EventHandler(this.btnReportContent_Click);
            // 
            // btnPrintFMReport
            // 
            this.btnPrintFMReport.Location = new System.Drawing.Point(9, 272);
            this.btnPrintFMReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrintFMReport.Name = "btnPrintFMReport";
            this.btnPrintFMReport.Size = new System.Drawing.Size(125, 52);
            this.btnPrintFMReport.TabIndex = 38;
            this.btnPrintFMReport.Text = "GET REPORT";
            this.btnPrintFMReport.UseVisualStyleBackColor = true;
            this.btnPrintFMReport.Click += new System.EventHandler(this.btnPrintFMReport_Click);
            // 
            // cbxFFZZDetailed
            // 
            this.cbxFFZZDetailed.AutoSize = true;
            this.cbxFFZZDetailed.Location = new System.Drawing.Point(111, 107);
            this.cbxFFZZDetailed.Margin = new System.Windows.Forms.Padding(2);
            this.cbxFFZZDetailed.Name = "cbxFFZZDetailed";
            this.cbxFFZZDetailed.Size = new System.Drawing.Size(92, 18);
            this.cbxFFZZDetailed.TabIndex = 37;
            this.cbxFFZZDetailed.Text = "Z DETAILED";
            this.cbxFFZZDetailed.UseVisualStyleBackColor = true;
            // 
            // cbxFFDateDetailed
            // 
            this.cbxFFDateDetailed.AutoSize = true;
            this.cbxFFDateDetailed.Location = new System.Drawing.Point(108, 212);
            this.cbxFFDateDetailed.Margin = new System.Windows.Forms.Padding(2);
            this.cbxFFDateDetailed.Name = "cbxFFDateDetailed";
            this.cbxFFDateDetailed.Size = new System.Drawing.Size(115, 18);
            this.cbxFFDateDetailed.TabIndex = 36;
            this.cbxFFDateDetailed.Text = "DATE DETAILED";
            this.cbxFFDateDetailed.UseVisualStyleBackColor = true;
            // 
            // dtZZLastDate
            // 
            this.dtZZLastDate.CustomFormat = "dd-MM-yyyy";
            this.dtZZLastDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtZZLastDate.Location = new System.Drawing.Point(108, 188);
            this.dtZZLastDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtZZLastDate.Name = "dtZZLastDate";
            this.dtZZLastDate.Size = new System.Drawing.Size(95, 19);
            this.dtZZLastDate.TabIndex = 35;
            // 
            // dtZZFirstDate
            // 
            this.dtZZFirstDate.CustomFormat = "dd-MM-yyyy";
            this.dtZZFirstDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtZZFirstDate.Location = new System.Drawing.Point(108, 164);
            this.dtZZFirstDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtZZFirstDate.Name = "dtZZFirstDate";
            this.dtZZFirstDate.Size = new System.Drawing.Size(95, 19);
            this.dtZZFirstDate.TabIndex = 34;
            // 
            // lblZZLastDate
            // 
            this.lblZZLastDate.AutoSize = true;
            this.lblZZLastDate.Location = new System.Drawing.Point(25, 194);
            this.lblZZLastDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblZZLastDate.Name = "lblZZLastDate";
            this.lblZZLastDate.Size = new System.Drawing.Size(68, 14);
            this.lblZZLastDate.TabIndex = 33;
            this.lblZZLastDate.Text = "Son Z Tarih :";
            // 
            // lblZZFirstDate
            // 
            this.lblZZFirstDate.AutoSize = true;
            this.lblZZFirstDate.Location = new System.Drawing.Point(25, 164);
            this.lblZZFirstDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblZZFirstDate.Name = "lblZZFirstDate";
            this.lblZZFirstDate.Size = new System.Drawing.Size(86, 14);
            this.lblZZFirstDate.TabIndex = 32;
            this.lblZZFirstDate.Text = "FIRST Z DATE :";
            // 
            // nmrFFZFirst
            // 
            this.nmrFFZFirst.Location = new System.Drawing.Point(111, 60);
            this.nmrFFZFirst.Margin = new System.Windows.Forms.Padding(2);
            this.nmrFFZFirst.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.nmrFFZFirst.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrFFZFirst.Name = "nmrFFZFirst";
            this.nmrFFZFirst.Size = new System.Drawing.Size(68, 19);
            this.nmrFFZFirst.TabIndex = 31;
            this.nmrFFZFirst.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrFFZFirst.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblFFZLast
            // 
            this.lblFFZLast.AutoSize = true;
            this.lblFFZLast.Location = new System.Drawing.Point(25, 86);
            this.lblFFZLast.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFFZLast.Name = "lblFFZLast";
            this.lblFFZLast.Size = new System.Drawing.Size(66, 14);
            this.lblFFZLast.TabIndex = 30;
            this.lblFFZLast.Text = "LAST Z ID :";
            // 
            // nmrFFZLast
            // 
            this.nmrFFZLast.Location = new System.Drawing.Point(111, 84);
            this.nmrFFZLast.Margin = new System.Windows.Forms.Padding(2);
            this.nmrFFZLast.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.nmrFFZLast.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrFFZLast.Name = "nmrFFZLast";
            this.nmrFFZLast.Size = new System.Drawing.Size(68, 19);
            this.nmrFFZLast.TabIndex = 29;
            this.nmrFFZLast.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrFFZLast.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblFFZFirst
            // 
            this.lblFFZFirst.AutoSize = true;
            this.lblFFZFirst.Location = new System.Drawing.Point(25, 62);
            this.lblFFZFirst.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFFZFirst.Name = "lblFFZFirst";
            this.lblFFZFirst.Size = new System.Drawing.Size(68, 14);
            this.lblFFZFirst.TabIndex = 28;
            this.lblFFZFirst.Text = "FIRST Z ID :";
            // 
            // rbtnFiscDateReport
            // 
            this.rbtnFiscDateReport.AutoSize = true;
            this.rbtnFiscDateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnFiscDateReport.Location = new System.Drawing.Point(9, 142);
            this.rbtnFiscDateReport.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnFiscDateReport.Name = "rbtnFiscDateReport";
            this.rbtnFiscDateReport.Size = new System.Drawing.Size(221, 17);
            this.rbtnFiscDateReport.TabIndex = 27;
            this.rbtnFiscDateReport.Text = "FISCAL MEMORY REPORT(DATE)";
            this.rbtnFiscDateReport.UseVisualStyleBackColor = true;
            // 
            // rbtnFiscZZReport
            // 
            this.rbtnFiscZZReport.AutoSize = true;
            this.rbtnFiscZZReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnFiscZZReport.Location = new System.Drawing.Point(9, 40);
            this.rbtnFiscZZReport.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnFiscZZReport.Name = "rbtnFiscZZReport";
            this.rbtnFiscZZReport.Size = new System.Drawing.Size(208, 17);
            this.rbtnFiscZZReport.TabIndex = 26;
            this.rbtnFiscZZReport.Text = "FISCAL MEMORY REPORT(Z-Z)";
            this.rbtnFiscZZReport.UseVisualStyleBackColor = true;
            // 
            // tabEJSingle
            // 
            this.tabEJSingle.Controls.Add(this.nmrEJZCopyZNo);
            this.tabEJSingle.Controls.Add(this.lblZCopyZno);
            this.tabEJSingle.Controls.Add(this.rbtnZCopy);
            this.tabEJSingle.Controls.Add(this.rbtnEJDetail);
            this.tabEJSingle.Controls.Add(this.dtEJSingDocTime);
            this.tabEJSingle.Controls.Add(this.dtEJSingDocDate);
            this.tabEJSingle.Controls.Add(this.lblEJSingDocTime);
            this.tabEJSingle.Controls.Add(this.lblEJSingDocDate);
            this.tabEJSingle.Controls.Add(this.nmrEJSingDocNo);
            this.tabEJSingle.Controls.Add(this.lblEJSingDocNo);
            this.tabEJSingle.Controls.Add(this.nmrEJSingDocZNo);
            this.tabEJSingle.Controls.Add(this.lblEJSingDocZNo);
            this.tabEJSingle.Controls.Add(this.rbtnEJDocCopyDate);
            this.tabEJSingle.Controls.Add(this.rbtnEJDocCopyZandDocId);
            this.tabEJSingle.Controls.Add(this.btnPrintEJSingReport);
            this.tabEJSingle.Location = new System.Drawing.Point(4, 38);
            this.tabEJSingle.Margin = new System.Windows.Forms.Padding(2);
            this.tabEJSingle.Name = "tabEJSingle";
            this.tabEJSingle.Padding = new System.Windows.Forms.Padding(2);
            this.tabEJSingle.Size = new System.Drawing.Size(277, 333);
            this.tabEJSingle.TabIndex = 2;
            this.tabEJSingle.Text = "EJ SINGLE REPORT";
            this.tabEJSingle.UseVisualStyleBackColor = true;
            // 
            // nmrEJZCopyZNo
            // 
            this.nmrEJZCopyZNo.Location = new System.Drawing.Point(118, 78);
            this.nmrEJZCopyZNo.Margin = new System.Windows.Forms.Padding(2);
            this.nmrEJZCopyZNo.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.nmrEJZCopyZNo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrEJZCopyZNo.Name = "nmrEJZCopyZNo";
            this.nmrEJZCopyZNo.Size = new System.Drawing.Size(68, 19);
            this.nmrEJZCopyZNo.TabIndex = 41;
            this.nmrEJZCopyZNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrEJZCopyZNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblZCopyZno
            // 
            this.lblZCopyZno.AutoSize = true;
            this.lblZCopyZno.Location = new System.Drawing.Point(32, 80);
            this.lblZCopyZno.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblZCopyZno.Name = "lblZCopyZno";
            this.lblZCopyZno.Size = new System.Drawing.Size(32, 14);
            this.lblZCopyZno.TabIndex = 40;
            this.lblZCopyZno.Text = "Z Id :";
            // 
            // rbtnZCopy
            // 
            this.rbtnZCopy.AutoSize = true;
            this.rbtnZCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnZCopy.Location = new System.Drawing.Point(16, 53);
            this.rbtnZCopy.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnZCopy.Name = "rbtnZCopy";
            this.rbtnZCopy.Size = new System.Drawing.Size(70, 17);
            this.rbtnZCopy.TabIndex = 39;
            this.rbtnZCopy.Text = "Z COPY";
            this.rbtnZCopy.UseVisualStyleBackColor = true;
            // 
            // rbtnEJDetail
            // 
            this.rbtnEJDetail.AutoSize = true;
            this.rbtnEJDetail.Checked = true;
            this.rbtnEJDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnEJDetail.Location = new System.Drawing.Point(16, 16);
            this.rbtnEJDetail.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnEJDetail.Name = "rbtnEJDetail";
            this.rbtnEJDetail.Size = new System.Drawing.Size(142, 17);
            this.rbtnEJDetail.TabIndex = 38;
            this.rbtnEJDetail.TabStop = true;
            this.rbtnEJDetail.Text = "EJ DETAIL REPORT";
            this.rbtnEJDetail.UseVisualStyleBackColor = true;
            // 
            // dtEJSingDocTime
            // 
            this.dtEJSingDocTime.CustomFormat = "HH:mm";
            this.dtEJSingDocTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEJSingDocTime.Location = new System.Drawing.Point(115, 240);
            this.dtEJSingDocTime.Margin = new System.Windows.Forms.Padding(2);
            this.dtEJSingDocTime.Name = "dtEJSingDocTime";
            this.dtEJSingDocTime.ShowUpDown = true;
            this.dtEJSingDocTime.Size = new System.Drawing.Size(95, 19);
            this.dtEJSingDocTime.TabIndex = 35;
            // 
            // dtEJSingDocDate
            // 
            this.dtEJSingDocDate.CustomFormat = "dd-MM-yyyy";
            this.dtEJSingDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEJSingDocDate.Location = new System.Drawing.Point(115, 216);
            this.dtEJSingDocDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtEJSingDocDate.Name = "dtEJSingDocDate";
            this.dtEJSingDocDate.Size = new System.Drawing.Size(95, 19);
            this.dtEJSingDocDate.TabIndex = 34;
            // 
            // lblEJSingDocTime
            // 
            this.lblEJSingDocTime.AutoSize = true;
            this.lblEJSingDocTime.Location = new System.Drawing.Point(32, 245);
            this.lblEJSingDocTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEJSingDocTime.Name = "lblEJSingDocTime";
            this.lblEJSingDocTime.Size = new System.Drawing.Size(38, 14);
            this.lblEJSingDocTime.TabIndex = 33;
            this.lblEJSingDocTime.Text = "Time :";
            // 
            // lblEJSingDocDate
            // 
            this.lblEJSingDocDate.AutoSize = true;
            this.lblEJSingDocDate.Location = new System.Drawing.Point(32, 216);
            this.lblEJSingDocDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEJSingDocDate.Name = "lblEJSingDocDate";
            this.lblEJSingDocDate.Size = new System.Drawing.Size(35, 14);
            this.lblEJSingDocDate.TabIndex = 32;
            this.lblEJSingDocDate.Text = "Date :";
            // 
            // nmrEJSingDocNo
            // 
            this.nmrEJSingDocNo.Location = new System.Drawing.Point(118, 161);
            this.nmrEJSingDocNo.Margin = new System.Windows.Forms.Padding(2);
            this.nmrEJSingDocNo.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nmrEJSingDocNo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrEJSingDocNo.Name = "nmrEJSingDocNo";
            this.nmrEJSingDocNo.Size = new System.Drawing.Size(68, 19);
            this.nmrEJSingDocNo.TabIndex = 31;
            this.nmrEJSingDocNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrEJSingDocNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblEJSingDocNo
            // 
            this.lblEJSingDocNo.AutoSize = true;
            this.lblEJSingDocNo.Location = new System.Drawing.Point(32, 162);
            this.lblEJSingDocNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEJSingDocNo.Name = "lblEJSingDocNo";
            this.lblEJSingDocNo.Size = new System.Drawing.Size(73, 14);
            this.lblEJSingDocNo.TabIndex = 30;
            this.lblEJSingDocNo.Text = "Document Id :";
            // 
            // nmrEJSingDocZNo
            // 
            this.nmrEJSingDocZNo.Location = new System.Drawing.Point(118, 136);
            this.nmrEJSingDocZNo.Margin = new System.Windows.Forms.Padding(2);
            this.nmrEJSingDocZNo.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.nmrEJSingDocZNo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrEJSingDocZNo.Name = "nmrEJSingDocZNo";
            this.nmrEJSingDocZNo.Size = new System.Drawing.Size(68, 19);
            this.nmrEJSingDocZNo.TabIndex = 29;
            this.nmrEJSingDocZNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrEJSingDocZNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblEJSingDocZNo
            // 
            this.lblEJSingDocZNo.AutoSize = true;
            this.lblEJSingDocZNo.Location = new System.Drawing.Point(32, 138);
            this.lblEJSingDocZNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEJSingDocZNo.Name = "lblEJSingDocZNo";
            this.lblEJSingDocZNo.Size = new System.Drawing.Size(32, 14);
            this.lblEJSingDocZNo.TabIndex = 28;
            this.lblEJSingDocZNo.Text = "Z Id :";
            // 
            // rbtnEJDocCopyDate
            // 
            this.rbtnEJDocCopyDate.AutoSize = true;
            this.rbtnEJDocCopyDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnEJDocCopyDate.Location = new System.Drawing.Point(16, 193);
            this.rbtnEJDocCopyDate.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnEJDocCopyDate.Name = "rbtnEJDocCopyDate";
            this.rbtnEJDocCopyDate.Size = new System.Drawing.Size(220, 17);
            this.rbtnEJDocCopyDate.TabIndex = 27;
            this.rbtnEJDocCopyDate.Text = "EJ SINGLE REPORT(DATE/TIME)";
            this.rbtnEJDocCopyDate.UseVisualStyleBackColor = true;
            // 
            // rbtnEJDocCopyZandDocId
            // 
            this.rbtnEJDocCopyZandDocId.AutoSize = true;
            this.rbtnEJDocCopyZandDocId.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnEJDocCopyZandDocId.Location = new System.Drawing.Point(16, 111);
            this.rbtnEJDocCopyZandDocId.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnEJDocCopyZandDocId.Name = "rbtnEJDocCopyZandDocId";
            this.rbtnEJDocCopyZandDocId.Size = new System.Drawing.Size(225, 17);
            this.rbtnEJDocCopyZandDocId.TabIndex = 26;
            this.rbtnEJDocCopyZandDocId.Text = "EJ SINGLE REPORT(Z ID/DOC ID)";
            this.rbtnEJDocCopyZandDocId.UseVisualStyleBackColor = true;
            // 
            // btnPrintEJSingReport
            // 
            this.btnPrintEJSingReport.Location = new System.Drawing.Point(35, 275);
            this.btnPrintEJSingReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrintEJSingReport.Name = "btnPrintEJSingReport";
            this.btnPrintEJSingReport.Size = new System.Drawing.Size(175, 54);
            this.btnPrintEJSingReport.TabIndex = 24;
            this.btnPrintEJSingReport.Text = "GET REPORT";
            this.btnPrintEJSingReport.UseVisualStyleBackColor = true;
            this.btnPrintEJSingReport.Click += new System.EventHandler(this.btnPrintEJReport_Click);
            // 
            // tabEJPeriyot
            // 
            this.tabEJPeriyot.Controls.Add(this.dtDailyDate);
            this.tabEJPeriyot.Controls.Add(this.lblEJPerDailyDate);
            this.tabEJPeriyot.Controls.Add(this.rbtnEJPerByDaily);
            this.tabEJPeriyot.Controls.Add(this.dtEJPerLastTime);
            this.tabEJPeriyot.Controls.Add(this.dtEJPerLastDate);
            this.tabEJPeriyot.Controls.Add(this.lblEJPerLastTime);
            this.tabEJPeriyot.Controls.Add(this.lblEJPerLastDt);
            this.tabEJPeriyot.Controls.Add(this.nmrEJPerLastDoc);
            this.tabEJPeriyot.Controls.Add(this.lblEJPerLastDoc);
            this.tabEJPeriyot.Controls.Add(this.nmrEJPerLastZ);
            this.tabEJPeriyot.Controls.Add(this.lblEJPerLastZ);
            this.tabEJPeriyot.Controls.Add(this.dtEJPerFirstTime);
            this.tabEJPeriyot.Controls.Add(this.dtEJPerFirstDate);
            this.tabEJPeriyot.Controls.Add(this.lblEJPerFistTime);
            this.tabEJPeriyot.Controls.Add(this.lblEJPerFirstZDt);
            this.tabEJPeriyot.Controls.Add(this.nmrEJPerFirstDoc);
            this.tabEJPeriyot.Controls.Add(this.lblEJPerFirstDoc);
            this.tabEJPeriyot.Controls.Add(this.nmrEJPerFirstZ);
            this.tabEJPeriyot.Controls.Add(this.lblEJPerFirstZ);
            this.tabEJPeriyot.Controls.Add(this.rbtnEJPerByDate);
            this.tabEJPeriyot.Controls.Add(this.rbtnEJPerByNo);
            this.tabEJPeriyot.Controls.Add(this.btnPrintEJPerReport);
            this.tabEJPeriyot.Location = new System.Drawing.Point(4, 38);
            this.tabEJPeriyot.Margin = new System.Windows.Forms.Padding(2);
            this.tabEJPeriyot.Name = "tabEJPeriyot";
            this.tabEJPeriyot.Padding = new System.Windows.Forms.Padding(2);
            this.tabEJPeriyot.Size = new System.Drawing.Size(277, 333);
            this.tabEJPeriyot.TabIndex = 3;
            this.tabEJPeriyot.Text = "EJ PERIODIC";
            this.tabEJPeriyot.UseVisualStyleBackColor = true;
            // 
            // dtDailyDate
            // 
            this.dtDailyDate.CustomFormat = "dd-MM-yyyy";
            this.dtDailyDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDailyDate.Location = new System.Drawing.Point(115, 276);
            this.dtDailyDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtDailyDate.Name = "dtDailyDate";
            this.dtDailyDate.Size = new System.Drawing.Size(95, 19);
            this.dtDailyDate.TabIndex = 58;
            // 
            // lblEJPerDailyDate
            // 
            this.lblEJPerDailyDate.AutoSize = true;
            this.lblEJPerDailyDate.Location = new System.Drawing.Point(32, 276);
            this.lblEJPerDailyDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEJPerDailyDate.Name = "lblEJPerDailyDate";
            this.lblEJPerDailyDate.Size = new System.Drawing.Size(35, 14);
            this.lblEJPerDailyDate.TabIndex = 57;
            this.lblEJPerDailyDate.Text = "Date :";
            // 
            // rbtnEJPerByDaily
            // 
            this.rbtnEJPerByDaily.AutoSize = true;
            this.rbtnEJPerByDaily.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnEJPerByDaily.Location = new System.Drawing.Point(16, 253);
            this.rbtnEJPerByDaily.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnEJPerByDaily.Name = "rbtnEJPerByDaily";
            this.rbtnEJPerByDaily.Size = new System.Drawing.Size(150, 17);
            this.rbtnEJPerByDaily.TabIndex = 56;
            this.rbtnEJPerByDaily.Text = "EJ PERIODIC (DAILY)";
            this.rbtnEJPerByDaily.UseVisualStyleBackColor = true;
            // 
            // dtEJPerLastTime
            // 
            this.dtEJPerLastTime.CustomFormat = "HH:mm";
            this.dtEJPerLastTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEJPerLastTime.Location = new System.Drawing.Point(115, 230);
            this.dtEJPerLastTime.Margin = new System.Windows.Forms.Padding(2);
            this.dtEJPerLastTime.Name = "dtEJPerLastTime";
            this.dtEJPerLastTime.ShowUpDown = true;
            this.dtEJPerLastTime.Size = new System.Drawing.Size(95, 19);
            this.dtEJPerLastTime.TabIndex = 55;
            // 
            // dtEJPerLastDate
            // 
            this.dtEJPerLastDate.CustomFormat = "dd-MM-yyyy";
            this.dtEJPerLastDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEJPerLastDate.Location = new System.Drawing.Point(115, 209);
            this.dtEJPerLastDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtEJPerLastDate.Name = "dtEJPerLastDate";
            this.dtEJPerLastDate.Size = new System.Drawing.Size(95, 19);
            this.dtEJPerLastDate.TabIndex = 54;
            // 
            // lblEJPerLastTime
            // 
            this.lblEJPerLastTime.AutoSize = true;
            this.lblEJPerLastTime.Location = new System.Drawing.Point(32, 235);
            this.lblEJPerLastTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEJPerLastTime.Name = "lblEJPerLastTime";
            this.lblEJPerLastTime.Size = new System.Drawing.Size(75, 14);
            this.lblEJPerLastTime.TabIndex = 53;
            this.lblEJPerLastTime.Text = "LAST HOUR :";
            // 
            // lblEJPerLastDt
            // 
            this.lblEJPerLastDt.AutoSize = true;
            this.lblEJPerLastDt.Location = new System.Drawing.Point(32, 209);
            this.lblEJPerLastDt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEJPerLastDt.Name = "lblEJPerLastDt";
            this.lblEJPerLastDt.Size = new System.Drawing.Size(74, 14);
            this.lblEJPerLastDt.TabIndex = 52;
            this.lblEJPerLastDt.Text = "LAST DATE :";
            // 
            // nmrEJPerLastDoc
            // 
            this.nmrEJPerLastDoc.Location = new System.Drawing.Point(118, 110);
            this.nmrEJPerLastDoc.Margin = new System.Windows.Forms.Padding(2);
            this.nmrEJPerLastDoc.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nmrEJPerLastDoc.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrEJPerLastDoc.Name = "nmrEJPerLastDoc";
            this.nmrEJPerLastDoc.Size = new System.Drawing.Size(68, 19);
            this.nmrEJPerLastDoc.TabIndex = 51;
            this.nmrEJPerLastDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrEJPerLastDoc.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblEJPerLastDoc
            // 
            this.lblEJPerLastDoc.AutoSize = true;
            this.lblEJPerLastDoc.Location = new System.Drawing.Point(32, 111);
            this.lblEJPerLastDoc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEJPerLastDoc.Name = "lblEJPerLastDoc";
            this.lblEJPerLastDoc.Size = new System.Drawing.Size(82, 14);
            this.lblEJPerLastDoc.TabIndex = 50;
            this.lblEJPerLastDoc.Text = "LAST DOC ID :";
            // 
            // nmrEJPerLastZ
            // 
            this.nmrEJPerLastZ.Location = new System.Drawing.Point(118, 89);
            this.nmrEJPerLastZ.Margin = new System.Windows.Forms.Padding(2);
            this.nmrEJPerLastZ.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.nmrEJPerLastZ.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrEJPerLastZ.Name = "nmrEJPerLastZ";
            this.nmrEJPerLastZ.Size = new System.Drawing.Size(68, 19);
            this.nmrEJPerLastZ.TabIndex = 49;
            this.nmrEJPerLastZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrEJPerLastZ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblEJPerLastZ
            // 
            this.lblEJPerLastZ.AutoSize = true;
            this.lblEJPerLastZ.Location = new System.Drawing.Point(32, 90);
            this.lblEJPerLastZ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEJPerLastZ.Name = "lblEJPerLastZ";
            this.lblEJPerLastZ.Size = new System.Drawing.Size(66, 14);
            this.lblEJPerLastZ.TabIndex = 48;
            this.lblEJPerLastZ.Text = "LAST Z ID :";
            // 
            // dtEJPerFirstTime
            // 
            this.dtEJPerFirstTime.CustomFormat = "HH:mm";
            this.dtEJPerFirstTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEJPerFirstTime.Location = new System.Drawing.Point(115, 175);
            this.dtEJPerFirstTime.Margin = new System.Windows.Forms.Padding(2);
            this.dtEJPerFirstTime.Name = "dtEJPerFirstTime";
            this.dtEJPerFirstTime.ShowUpDown = true;
            this.dtEJPerFirstTime.Size = new System.Drawing.Size(95, 19);
            this.dtEJPerFirstTime.TabIndex = 47;
            // 
            // dtEJPerFirstDate
            // 
            this.dtEJPerFirstDate.CustomFormat = "dd-MM-yyyy";
            this.dtEJPerFirstDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEJPerFirstDate.Location = new System.Drawing.Point(115, 154);
            this.dtEJPerFirstDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtEJPerFirstDate.Name = "dtEJPerFirstDate";
            this.dtEJPerFirstDate.Size = new System.Drawing.Size(95, 19);
            this.dtEJPerFirstDate.TabIndex = 46;
            // 
            // lblEJPerFistTime
            // 
            this.lblEJPerFistTime.AutoSize = true;
            this.lblEJPerFistTime.Location = new System.Drawing.Point(32, 180);
            this.lblEJPerFistTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEJPerFistTime.Name = "lblEJPerFistTime";
            this.lblEJPerFistTime.Size = new System.Drawing.Size(77, 14);
            this.lblEJPerFistTime.TabIndex = 45;
            this.lblEJPerFistTime.Text = "FIRST HOUR :";
            // 
            // lblEJPerFirstZDt
            // 
            this.lblEJPerFirstZDt.AutoSize = true;
            this.lblEJPerFirstZDt.Location = new System.Drawing.Point(32, 154);
            this.lblEJPerFirstZDt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEJPerFirstZDt.Name = "lblEJPerFirstZDt";
            this.lblEJPerFirstZDt.Size = new System.Drawing.Size(76, 14);
            this.lblEJPerFirstZDt.TabIndex = 44;
            this.lblEJPerFirstZDt.Text = "FIRST DATE :";
            // 
            // nmrEJPerFirstDoc
            // 
            this.nmrEJPerFirstDoc.Location = new System.Drawing.Point(118, 62);
            this.nmrEJPerFirstDoc.Margin = new System.Windows.Forms.Padding(2);
            this.nmrEJPerFirstDoc.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nmrEJPerFirstDoc.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrEJPerFirstDoc.Name = "nmrEJPerFirstDoc";
            this.nmrEJPerFirstDoc.Size = new System.Drawing.Size(68, 19);
            this.nmrEJPerFirstDoc.TabIndex = 43;
            this.nmrEJPerFirstDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrEJPerFirstDoc.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblEJPerFirstDoc
            // 
            this.lblEJPerFirstDoc.AutoSize = true;
            this.lblEJPerFirstDoc.Location = new System.Drawing.Point(32, 63);
            this.lblEJPerFirstDoc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEJPerFirstDoc.Name = "lblEJPerFirstDoc";
            this.lblEJPerFirstDoc.Size = new System.Drawing.Size(84, 14);
            this.lblEJPerFirstDoc.TabIndex = 42;
            this.lblEJPerFirstDoc.Text = "FIRST DOC ID :";
            // 
            // nmrEJPerFirstZ
            // 
            this.nmrEJPerFirstZ.Location = new System.Drawing.Point(118, 41);
            this.nmrEJPerFirstZ.Margin = new System.Windows.Forms.Padding(2);
            this.nmrEJPerFirstZ.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.nmrEJPerFirstZ.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrEJPerFirstZ.Name = "nmrEJPerFirstZ";
            this.nmrEJPerFirstZ.Size = new System.Drawing.Size(68, 19);
            this.nmrEJPerFirstZ.TabIndex = 41;
            this.nmrEJPerFirstZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrEJPerFirstZ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblEJPerFirstZ
            // 
            this.lblEJPerFirstZ.AutoSize = true;
            this.lblEJPerFirstZ.Location = new System.Drawing.Point(32, 43);
            this.lblEJPerFirstZ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEJPerFirstZ.Name = "lblEJPerFirstZ";
            this.lblEJPerFirstZ.Size = new System.Drawing.Size(68, 14);
            this.lblEJPerFirstZ.TabIndex = 40;
            this.lblEJPerFirstZ.Text = "FIRST Z ID :";
            // 
            // rbtnEJPerByDate
            // 
            this.rbtnEJPerByDate.AutoSize = true;
            this.rbtnEJPerByDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnEJPerByDate.Location = new System.Drawing.Point(16, 131);
            this.rbtnEJPerByDate.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnEJPerByDate.Name = "rbtnEJPerByDate";
            this.rbtnEJPerByDate.Size = new System.Drawing.Size(220, 17);
            this.rbtnEJPerByDate.TabIndex = 39;
            this.rbtnEJPerByDate.Text = "EJ SINGLE REPORT(DATE/TIME)";
            this.rbtnEJPerByDate.UseVisualStyleBackColor = true;
            // 
            // rbtnEJPerByNo
            // 
            this.rbtnEJPerByNo.AutoSize = true;
            this.rbtnEJPerByNo.Checked = true;
            this.rbtnEJPerByNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnEJPerByNo.Location = new System.Drawing.Point(16, 16);
            this.rbtnEJPerByNo.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnEJPerByNo.Name = "rbtnEJPerByNo";
            this.rbtnEJPerByNo.Size = new System.Drawing.Size(225, 17);
            this.rbtnEJPerByNo.TabIndex = 38;
            this.rbtnEJPerByNo.TabStop = true;
            this.rbtnEJPerByNo.Text = "EJ SINGLE REPORT(Z ID/DOC ID)";
            this.rbtnEJPerByNo.UseVisualStyleBackColor = true;
            // 
            // btnPrintEJPerReport
            // 
            this.btnPrintEJPerReport.Location = new System.Drawing.Point(47, 298);
            this.btnPrintEJPerReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrintEJPerReport.Name = "btnPrintEJPerReport";
            this.btnPrintEJPerReport.Size = new System.Drawing.Size(153, 33);
            this.btnPrintEJPerReport.TabIndex = 36;
            this.btnPrintEJPerReport.Text = "GET REPORT";
            this.btnPrintEJPerReport.UseVisualStyleBackColor = true;
            this.btnPrintEJPerReport.Click += new System.EventHandler(this.btnPrintEJPerReport_Click);
            // 
            // tabOtherDoc
            // 
            this.tabOtherDoc.Controls.Add(this.tableLayoutPanel2);
            this.tabOtherDoc.Controls.Add(this.tableLayoutPanel1);
            this.tabOtherDoc.Controls.Add(this.rBtnODocPeriodic);
            this.tabOtherDoc.Controls.Add(this.rBtnODocDaily);
            this.tabOtherDoc.Controls.Add(this.btnPrintODReport);
            this.tabOtherDoc.Location = new System.Drawing.Point(4, 38);
            this.tabOtherDoc.Name = "tabOtherDoc";
            this.tabOtherDoc.Padding = new System.Windows.Forms.Padding(3);
            this.tabOtherDoc.Size = new System.Drawing.Size(277, 333);
            this.tabOtherDoc.TabIndex = 5;
            this.tabOtherDoc.Text = "OTHER DOC";
            this.tabOtherDoc.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.5283F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.4717F));
            this.tableLayoutPanel2.Controls.Add(this.lblODocType, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbxOtherDocType, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(265, 33);
            this.tableLayoutPanel2.TabIndex = 60;
            // 
            // lblODocType
            // 
            this.lblODocType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblODocType.AutoSize = true;
            this.lblODocType.Location = new System.Drawing.Point(6, 9);
            this.lblODocType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblODocType.Name = "lblODocType";
            this.lblODocType.Size = new System.Drawing.Size(104, 14);
            this.lblODocType.TabIndex = 36;
            this.lblODocType.Text = "OTHER DOC TYPE";
            // 
            // cbxOtherDocType
            // 
            this.cbxOtherDocType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxOtherDocType.FormattingEnabled = true;
            this.cbxOtherDocType.Location = new System.Drawing.Point(119, 6);
            this.cbxOtherDocType.Margin = new System.Windows.Forms.Padding(2);
            this.cbxOtherDocType.Name = "cbxOtherDocType";
            this.cbxOtherDocType.Size = new System.Drawing.Size(144, 20);
            this.cbxOtherDocType.TabIndex = 35;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblODPerFirstDt, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtODPerLastDate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtODPerFirstDate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblODPerLastDt, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(36, 137);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.95833F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.04167F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 53);
            this.tableLayoutPanel1.TabIndex = 59;
            // 
            // lblODPerFirstDt
            // 
            this.lblODPerFirstDt.AutoSize = true;
            this.lblODPerFirstDt.Location = new System.Drawing.Point(2, 0);
            this.lblODPerFirstDt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblODPerFirstDt.Name = "lblODPerFirstDt";
            this.lblODPerFirstDt.Size = new System.Drawing.Size(76, 14);
            this.lblODPerFirstDt.TabIndex = 55;
            this.lblODPerFirstDt.Text = "FIRST DATE :";
            // 
            // dtODPerLastDate
            // 
            this.dtODPerLastDate.CustomFormat = "dd-MM-yyyy";
            this.dtODPerLastDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtODPerLastDate.Location = new System.Drawing.Point(102, 27);
            this.dtODPerLastDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtODPerLastDate.Name = "dtODPerLastDate";
            this.dtODPerLastDate.Size = new System.Drawing.Size(95, 19);
            this.dtODPerLastDate.TabIndex = 58;
            // 
            // dtODPerFirstDate
            // 
            this.dtODPerFirstDate.CustomFormat = "dd-MM-yyyy";
            this.dtODPerFirstDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtODPerFirstDate.Location = new System.Drawing.Point(102, 2);
            this.dtODPerFirstDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtODPerFirstDate.Name = "dtODPerFirstDate";
            this.dtODPerFirstDate.Size = new System.Drawing.Size(95, 19);
            this.dtODPerFirstDate.TabIndex = 56;
            // 
            // lblODPerLastDt
            // 
            this.lblODPerLastDt.AutoSize = true;
            this.lblODPerLastDt.Location = new System.Drawing.Point(2, 25);
            this.lblODPerLastDt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblODPerLastDt.Name = "lblODPerLastDt";
            this.lblODPerLastDt.Size = new System.Drawing.Size(74, 14);
            this.lblODPerLastDt.TabIndex = 57;
            this.lblODPerLastDt.Text = "LAST DATE :";
            // 
            // rBtnODocPeriodic
            // 
            this.rBtnODocPeriodic.AutoSize = true;
            this.rBtnODocPeriodic.Checked = true;
            this.rBtnODocPeriodic.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rBtnODocPeriodic.Location = new System.Drawing.Point(20, 104);
            this.rBtnODocPeriodic.Margin = new System.Windows.Forms.Padding(2);
            this.rBtnODocPeriodic.Name = "rBtnODocPeriodic";
            this.rBtnODocPeriodic.Size = new System.Drawing.Size(216, 17);
            this.rBtnODocPeriodic.TabIndex = 38;
            this.rBtnODocPeriodic.TabStop = true;
            this.rBtnODocPeriodic.Text = "PERIODIC OTHER DOC REPORT";
            this.rBtnODocPeriodic.UseVisualStyleBackColor = true;
            // 
            // rBtnODocDaily
            // 
            this.rBtnODocDaily.AutoSize = true;
            this.rBtnODocDaily.Checked = true;
            this.rBtnODocDaily.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rBtnODocDaily.Location = new System.Drawing.Point(20, 57);
            this.rBtnODocDaily.Margin = new System.Windows.Forms.Padding(2);
            this.rBtnODocDaily.Name = "rBtnODocDaily";
            this.rBtnODocDaily.Size = new System.Drawing.Size(193, 17);
            this.rBtnODocDaily.TabIndex = 37;
            this.rBtnODocDaily.TabStop = true;
            this.rBtnODocDaily.Text = "DAILY OTHER DOC REPORT";
            this.rBtnODocDaily.UseVisualStyleBackColor = true;
            // 
            // btnPrintODReport
            // 
            this.btnPrintODReport.Location = new System.Drawing.Point(72, 263);
            this.btnPrintODReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrintODReport.Name = "btnPrintODReport";
            this.btnPrintODReport.Size = new System.Drawing.Size(125, 52);
            this.btnPrintODReport.TabIndex = 33;
            this.btnPrintODReport.Text = "GET REPORT";
            this.btnPrintODReport.UseVisualStyleBackColor = true;
            this.btnPrintODReport.Click += new System.EventHandler(this.btnPrintODocPerReport_Click);
            // 
            // tableLayoutPanelReportUC
            // 
            this.tableLayoutPanelReportUC.ColumnCount = 2;
            this.tableLayoutPanelReportUC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelReportUC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelReportUC.Controls.Add(this.txtResult, 1, 0);
            this.tableLayoutPanelReportUC.Controls.Add(this.tableLayoutPanelReportUCLeftSide, 0, 0);
            this.tableLayoutPanelReportUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelReportUC.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelReportUC.Name = "tableLayoutPanelReportUC";
            this.tableLayoutPanelReportUC.RowCount = 1;
            this.tableLayoutPanelReportUC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelReportUC.Size = new System.Drawing.Size(591, 427);
            this.tableLayoutPanelReportUC.TabIndex = 3;
            // 
            // tableLayoutPanelReportUCLeftSide
            // 
            this.tableLayoutPanelReportUCLeftSide.ColumnCount = 1;
            this.tableLayoutPanelReportUCLeftSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelReportUCLeftSide.Controls.Add(this.grpPrintArea, 0, 0);
            this.tableLayoutPanelReportUCLeftSide.Controls.Add(this.tbcReports, 0, 1);
            this.tableLayoutPanelReportUCLeftSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelReportUCLeftSide.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelReportUCLeftSide.Name = "tableLayoutPanelReportUCLeftSide";
            this.tableLayoutPanelReportUCLeftSide.RowCount = 2;
            this.tableLayoutPanelReportUCLeftSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelReportUCLeftSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanelReportUCLeftSide.Size = new System.Drawing.Size(289, 421);
            this.tableLayoutPanelReportUCLeftSide.TabIndex = 2;
            // 
            // ReportUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelReportUC);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ReportUC";
            this.grpPrintArea.ResumeLayout(false);
            this.grpPrintArea.PerformLayout();
            this.tbcReports.ResumeLayout(false);
            this.tabXReports.ResumeLayout(false);
            this.tabXReports.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numerAmountReturnDocX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numerCountReturnDocX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPLULast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPLUFirst)).EndInit();
            this.tabZReports.ResumeLayout(false);
            this.tabZReports.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numerAmountReturnDocZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numerCountReturnDocZ)).EndInit();
            this.tabFMReports.ResumeLayout(false);
            this.tabFMReports.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrFFZFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrFFZLast)).EndInit();
            this.tabEJSingle.ResumeLayout(false);
            this.tabEJSingle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrEJZCopyZNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrEJSingDocNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrEJSingDocZNo)).EndInit();
            this.tabEJPeriyot.ResumeLayout(false);
            this.tabEJPeriyot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrEJPerLastDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrEJPerLastZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrEJPerFirstDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrEJPerFirstZ)).EndInit();
            this.tabOtherDoc.ResumeLayout(false);
            this.tabOtherDoc.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanelReportUC.ResumeLayout(false);
            this.tableLayoutPanelReportUCLeftSide.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void btnXReports_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
            int copy = GetPrintTarget();
            CPResponse response = null;

            try
            {
                if (rbtnXReport.Checked)
                {
                    if (numerCountReturnDocX.Value == 0)
                    {
                        response = new CPResponse(bridge.Printer.PrintXReport(copy));
                    }
                    else
                    {
                        int count = (int)numerCountReturnDocX.Value;
                        decimal amount = numerAmountReturnDocX.Value;

                        response = new CPResponse(
                            bridge.Printer.PrintXReport(count,
                                                        amount,
                                                        cbxAffectDrawerX.Checked));
                    }
                }
                else if (rbtPluRprt.Checked)
                {
                    //FIRST PLU NO
                    int firstPLU = (int)nmrPLUFirst.Value;

                    //LAST PLU NO
                    int lastPLU = (int)nmrPLULast.Value;

                    response = new CPResponse(bridge.Printer.PrintXPluReport(firstPLU, lastPLU, copy));
                }
                else if (rbtnSystemInfoRprt.Checked)
                {
                    response = new CPResponse(bridge.Printer.PrintSystemInfoReport(copy));
                }
                else if (rbtnReceiptTotalReport.Checked)
                {
                    response = new CPResponse(bridge.Printer.PrintReceiptTotalReport(copy));
                }

                if(response != null)
                {
                    String reportContent = response.GetParamByIndex(3);
                    if (!String.IsNullOrEmpty(reportContent))
                    {
                        txtResult.Text = reportContent;
                    }
                }
            }
            catch(Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }

        }


        private void btnPrintZReports_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
            int copy = GetPrintTarget();
            CPResponse response = null;

            System.Threading.Thread reportThread;

            try
            {
                if (btnPrintZReport.Text == FormMessage.GET_REPORT)
                {
                    if (rbtnZReport.Checked)
                    {
                        if (numerCountReturnDocZ.Value == Decimal.Zero)
                        {
                            response = new CPResponse(bridge.Printer.PrintZReport(GetPrintTarget()));
                        }
                        else
                        {
                            int count = (int)numerCountReturnDocZ.Value;
                            decimal amount = numerAmountReturnDocZ.Value;

                            response = new CPResponse(
                                bridge.Printer.PrintZReport(count, 
                                                            amount, 
                                                            cbxAffectDrawerZ.Checked));
                        }
                    }
                    else if (rbtnEndDay.Checked)
                    {
                        response = new CPResponse(bridge.Printer.PrintEndDayReport());
                    }
                }
                else
                {
                    InterruptReport();
                }

                if (response != null)
                {
                    String reportContent = response.GetParamByIndex(3);
                    if (!String.IsNullOrEmpty(reportContent))
                    {
                        txtResult.Text = reportContent;
                    }
                }
            }
            catch (Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }

        }

        private void btnPrintEJReport_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
            int copy = GetPrintTarget();
            CPResponse response;

            System.Threading.Thread reportThread;

            try
            {
                if (btnPrintEJSingReport.Text == FormMessage.GET_REPORT)
                {
                    if (rbtnEJDetail.Checked)
                    {
                        response = new CPResponse(bridge.Printer.PrintEJDetail(copy));
                    }
                    else if (rbtnZCopy.Checked)
                    {
                        reportThread = new System.Threading.Thread(delegate()
                        {
                            SetControlText(btnPrintEJSingReport, FormMessage.INTERRUPT_PROCESS);
                            response = new CPResponse(bridge.Printer.PrintEJPeriodic((int)nmrEJZCopyZNo.Value, 0, (int)nmrEJZCopyZNo.Value, 0, copy));
                            SetControlText(btnPrintEJSingReport, FormMessage.GET_REPORT);
                        });
                        reportThread.Start();
                    }
                    else if (rbtnEJDocCopyZandDocId.Checked)
                    {
                        reportThread = new System.Threading.Thread(delegate()
                        {
                            SetControlText(btnPrintEJSingReport, FormMessage.INTERRUPT_PROCESS);
                            response = new CPResponse(bridge.Printer.PrintEJPeriodic((int)nmrEJSingDocZNo.Value,
                                                                                   (int)nmrEJSingDocNo.Value,
                                                                                   (int)nmrEJSingDocZNo.Value,
                                                                                   (int)nmrEJSingDocNo.Value,
                                                                                    copy));
                            SetControlText(btnPrintEJSingReport, FormMessage.GET_REPORT);
                        });
                        reportThread.Start();
                    }
                    else if (rbtnEJDocCopyDate.Checked)
                    {
                        //Receipt Date
                        DateTime date = dtEJSingDocDate.Value;

                        DateTime time = dtEJSingDocTime.Value;

                        DateTime comp = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0, 0);

                        reportThread = new System.Threading.Thread(delegate()
                        {
                            SetControlText(btnPrintEJSingReport, FormMessage.INTERRUPT_PROCESS);
                            response = new CPResponse(bridge.Printer.PrintEJPeriodic(comp, copy));
                            SetControlText(btnPrintEJSingReport, FormMessage.GET_REPORT);
                        });
                        reportThread.Start();
                    }
                }
                else
                {
                    InterruptReport();
                }
            }
            catch (Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
        }
      
        private int GetPrintTarget()
        {
            int copy = 0;
#if !EJ_READER
            if (cbxSoft.Checked)
            {
                copy += 1;
            }
            if (cbxHard.Checked)
            {
                copy += 2;
            }
#endif
            if (copy == 0)
            {
                copy = 1;
            }

            return copy;
        }

        private void btnPrintODocPerReport_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
            CPResponse response;

            System.Threading.Thread reportThread;

            try
            {
                //OTHER DOC TYPE
                int oDocType = cbxOtherDocType.SelectedIndex;

                if (btnPrintODReport.Text == FormMessage.GET_REPORT)
                {
                    btnPrintODReport.Text = FormMessage.INTERRUPT_PROCESS;

                    if(rBtnODocDaily.Checked)
                    {
                        reportThread = new System.Threading.Thread(delegate ()
                        {
                            SetControlText(btnPrintODReport, FormMessage.INTERRUPT_PROCESS);
                            response = new CPResponse(bridge.Printer.PrintODocPeriodic(oDocType));
                            SetControlText(btnPrintODReport, FormMessage.GET_REPORT);
                        });
                        reportThread.Start();
                    }
                    else if(rBtnODocPeriodic.Checked)
                    {
                        //First Date
                        DateTime firstDate = dtODPerFirstDate.Value;
                        //Last Date
                        DateTime lastDate = dtODPerLastDate.Value;

                        reportThread = new System.Threading.Thread(delegate ()
                        {
                            SetControlText(btnPrintODReport, FormMessage.INTERRUPT_PROCESS);
                            response = new CPResponse(bridge.Printer.PrintODocPeriodic(firstDate, lastDate, oDocType));
                            SetControlText(btnPrintODReport, FormMessage.GET_REPORT);
                        });
                        reportThread.Start();
                    }
                }
                else
                {
                    InterruptReport();
                }
            }
            catch (Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
        }

        private void btnPrintEJPerReport_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
            int copy = GetPrintTarget();
            CPResponse response;

            System.Threading.Thread reportThread;

            try
            {
                if (btnPrintEJPerReport.Text == FormMessage.GET_REPORT)
                {
                    btnPrintEJPerReport.Text = FormMessage.INTERRUPT_PROCESS;

                    if (rbtnEJPerByNo.Checked)
                    {
                        reportThread = new System.Threading.Thread(delegate ()
                        {
                            SetControlText(btnPrintEJPerReport, FormMessage.INTERRUPT_PROCESS);
                            response = new CPResponse(bridge.Printer.PrintEJPeriodic((int)nmrEJPerFirstZ.Value, (int)nmrEJPerFirstDoc.Value,
                                         (int)nmrEJPerLastZ.Value, (int)nmrEJPerLastDoc.Value,
                                             copy));
                            SetControlText(btnPrintEJPerReport, FormMessage.GET_REPORT);
                        });
                        reportThread.Start();                       
                    }
                    else if (rbtnEJPerByDate.Checked)
                    {
                        //First Date
                        DateTime date = dtEJPerFirstDate.Value;
                        DateTime time = dtEJPerFirstTime.Value;
                        DateTime firstDate = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);

                        //Last Date
                        date = dtEJPerLastDate.Value;
                        time = dtEJPerLastTime.Value;
                        DateTime lastDate = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);

                        reportThread = new System.Threading.Thread(delegate ()
                        {
                            SetControlText(btnPrintEJPerReport, FormMessage.INTERRUPT_PROCESS);
                            response = new CPResponse(bridge.Printer.PrintEJPeriodic(firstDate, lastDate, copy));
                            SetControlText(btnPrintEJPerReport, FormMessage.GET_REPORT);
                        });
                        reportThread.Start();
                    }
                    else if (rbtnEJPerByDaily.Checked)
                    {
                        DateTime date = dtDailyDate.Value;

                        DateTime startDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
                        DateTime endDate = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);

                        reportThread = new System.Threading.Thread(delegate ()
                        {
                            SetControlText(btnPrintEJPerReport, FormMessage.INTERRUPT_PROCESS);
                            response = new CPResponse(bridge.Printer.PrintEJPeriodic(startDate, endDate, copy));
                            SetControlText(btnPrintEJPerReport, FormMessage.GET_REPORT);
                        });
                        reportThread.Start();                
                    }
                }
                else
                {
                    InterruptReport();
                }
            }
            catch (Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
        }

        private void InterruptReport()
        {
            CPResponse response = null;

            try
            {
                response = new CPResponse(bridge.Printer.InterruptReport());
            }
            catch(Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }
        }

        private delegate void SetControlTextDelegate(Control control, string text);
        private void SetControlText(Control control, string text)
        {
            if(control.InvokeRequired)
            {
                control.Invoke(new SetControlTextDelegate(SetControlText), control, text);
            }
            else
            {
                control.Text = text;
            }
        }

        private void btnPrintFMReport_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
            int copy = GetPrintTarget();
            CPResponse response = null;

            System.Threading.Thread reportThread;

            try
            {
                if (btnPrintFMReport.Text == FormMessage.GET_REPORT)
                {
                    if (rbtnFiscZZReport.Checked)
                    {
                        //FIRST Z NO
                        int firstZ = (int)nmrFFZFirst.Value;

                        //LAST Z NO
                        int lastZ = (int)nmrFFZLast.Value;

                        bool detail = false;
                        if (cbxFFZZDetailed.Checked)
                        {
                            detail = true;
                        }

                        //reportThread = new System.Threading.Thread(delegate ()
                        {
                            SetControlText(btnPrintFMReport, FormMessage.INTERRUPT_PROCESS);
                            response = new CPResponse(bridge.Printer.PrintPeriodicZZReport(firstZ, lastZ, copy, detail));
                            SetControlText(btnPrintFMReport, FormMessage.GET_REPORT);
                        }//);
                        //reportThread.Start();
                    }
                    else if (rbtnFiscDateReport.Checked)
                    {
                        //FIRST Z DATE
                        DateTime firstZDate = dtZZFirstDate.Value;

                        //LAST Z DATE
                        DateTime lastZDate = dtZZLastDate.Value;

                        bool detail = false;
                        if (cbxFFDateDetailed.Checked)
                        {
                            detail = true;
                        }

                        //reportThread = new System.Threading.Thread(delegate ()
                        {
                            SetControlText(btnPrintFMReport, FormMessage.INTERRUPT_PROCESS);
                            response = new CPResponse(bridge.Printer.PrintPeriodicDateReport(firstZDate, lastZDate, copy, detail));
                            SetControlText(btnPrintFMReport, FormMessage.GET_REPORT);
                        }//);
                        //reportThread.Start();
                    }

                    if (response != null)
                    {
                        String reportContent = response.GetParamByIndex(3);
                        if (!String.IsNullOrEmpty(reportContent))
                        {
                            txtResult.Text = reportContent;
                        }
                    }
                }
                else
                {
                    InterruptReport();
                }
            }
            catch (Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }

        }

        private void btnReportContent_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
            CPResponse response = null;

            try
            {
                response = new CPResponse(bridge.Printer.GetReportContent());

                if (response != null)
                {
                    String reportContent = response.GetParamByIndex(3);
                    if (!String.IsNullOrEmpty(reportContent))
                    {
                        txtResult.Text = reportContent;
                    }
                }
            }
            catch (Exception ex)
            {
                bridge.Log(FormMessage.OPERATION_FAILS + ": " + ex.Message);
            }

        }
    }
}
