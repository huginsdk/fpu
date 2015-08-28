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
    public class ReportUC : TestUC
    {

        private static IBridge bridge = null;
        private static TestUC saleForm = null;
        private TabControl tbcReports;
        private TabPage tabXReports;
        private TabPage tabZReports;
        private RichTextBox txtResult;
        private Button btnPrintNonFiscReport;
        private RadioButton rbtPluRprt;
        private RadioButton rbtnXReport;
        private CheckBox cbxHard;
        private CheckBox cbxSoft;
        private RadioButton rbtnFiscDateReport;
        private RadioButton rbtnFiscZZReport;
        private RadioButton rbtnZReport;
        private Button btnPrintZReport;
        private GroupBox grpPrintArea;
        private NumericUpDown nmrPLUFirst;
        private Label lblFirstPlu;
        private NumericUpDown nmrPLULast;
        private Label lblPLULast;
        private NumericUpDown nmrFFZFirst;
        private Label lblFFZLast;
        private NumericUpDown nmrFFZLast;
        private Label lblFFZFirst;
        private DateTimePicker dtZZLastDate;
        private DateTimePicker dtZZFirstDate;
        private Label lblZZLastDate;
        private Label lblZZFirstDate;
        private CheckBox cbxFFDateDetailed;
        private CheckBox cbxFFZZDetailed;
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

        void Printer_OnReportLine(object sender, OnReportLineEventArgs e)
        {
            AddReportLine(e.Line);     
        }

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

            if (bridge.Connection != null)
            {
                bridge.Printer.OnReportLine += new OnReportLineHandler(Printer_OnReportLine);
            }
#if EJ_READER
            tbcReports.Dock = DockStyle.Fill;
#endif
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
            this.nmrPLULast = new System.Windows.Forms.NumericUpDown();
            this.lblPLULast = new System.Windows.Forms.Label();
            this.nmrPLUFirst = new System.Windows.Forms.NumericUpDown();
            this.lblFirstPlu = new System.Windows.Forms.Label();
            this.rbtPluRprt = new System.Windows.Forms.RadioButton();
            this.rbtnXReport = new System.Windows.Forms.RadioButton();
            this.btnPrintNonFiscReport = new System.Windows.Forms.Button();
            this.tabZReports = new System.Windows.Forms.TabPage();
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
            this.rbtnZReport = new System.Windows.Forms.RadioButton();
            this.btnPrintZReport = new System.Windows.Forms.Button();
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
            this.grpPrintArea.SuspendLayout();
            this.tbcReports.SuspendLayout();
            this.tabXReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPLULast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPLUFirst)).BeginInit();
            this.tabZReports.SuspendLayout();
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
            this.SuspendLayout();
            // 
            // grpPrintArea
            // 
            this.grpPrintArea.Controls.Add(this.cbxSoft);
            this.grpPrintArea.Controls.Add(this.cbxHard);
            this.grpPrintArea.Location = new System.Drawing.Point(7, 9);
            this.grpPrintArea.Name = "grpPrintArea";
            this.grpPrintArea.Size = new System.Drawing.Size(318, 42);
            this.grpPrintArea.TabIndex = 2;
            this.grpPrintArea.TabStop = false;
            // 
            // cbxSoft
            // 
            this.cbxSoft.AutoSize = true;
            this.cbxSoft.Checked = true;
            this.cbxSoft.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxSoft.Location = new System.Drawing.Point(16, 15);
            this.cbxSoft.Name = "cbxSoft";
            this.cbxSoft.Size = new System.Drawing.Size(63, 21);
            this.cbxSoft.TabIndex = 3;
            this.cbxSoft.Text = "İçerik";
            this.cbxSoft.UseVisualStyleBackColor = true;
            // 
            // cbxHard
            // 
            this.cbxHard.AutoSize = true;
            this.cbxHard.Checked = true;
            this.cbxHard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxHard.Location = new System.Drawing.Point(102, 15);
            this.cbxHard.Name = "cbxHard";
            this.cbxHard.Size = new System.Drawing.Size(70, 21);
            this.cbxHard.TabIndex = 4;
            this.cbxHard.Text = "Yazdır";
            this.cbxHard.UseVisualStyleBackColor = true;
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtResult.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtResult.Location = new System.Drawing.Point(338, 0);
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(450, 526);
            this.txtResult.TabIndex = 1;
            this.txtResult.Text = "";
            // 
            // tbcReports
            // 
            this.tbcReports.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tbcReports.Controls.Add(this.tabXReports);
            this.tbcReports.Controls.Add(this.tabZReports);
            this.tbcReports.Controls.Add(this.tabEJSingle);
            this.tbcReports.Controls.Add(this.tabEJPeriyot);
            this.tbcReports.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbcReports.Location = new System.Drawing.Point(3, 55);
            this.tbcReports.Multiline = true;
            this.tbcReports.Name = "tbcReports";
            this.tbcReports.SelectedIndex = 0;
            this.tbcReports.Size = new System.Drawing.Size(326, 449);
            this.tbcReports.TabIndex = 0;
            // 
            // tabXReports
            // 
            this.tabXReports.Controls.Add(this.nmrPLULast);
            this.tabXReports.Controls.Add(this.lblPLULast);
            this.tabXReports.Controls.Add(this.nmrPLUFirst);
            this.tabXReports.Controls.Add(this.lblFirstPlu);
            this.tabXReports.Controls.Add(this.rbtPluRprt);
            this.tabXReports.Controls.Add(this.rbtnXReport);
            this.tabXReports.Controls.Add(this.btnPrintNonFiscReport);
            this.tabXReports.Location = new System.Drawing.Point(4, 24);
            this.tabXReports.Name = "tabXReports";
            this.tabXReports.Padding = new System.Windows.Forms.Padding(3);
            this.tabXReports.Size = new System.Drawing.Size(318, 421);
            this.tabXReports.TabIndex = 0;
            this.tabXReports.Text = "X Raporları";
            this.tabXReports.UseVisualStyleBackColor = true;
            // 
            // nmrPLULast
            // 
            this.nmrPLULast.Location = new System.Drawing.Point(157, 139);
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
            this.nmrPLULast.Size = new System.Drawing.Size(90, 22);
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
            this.lblPLULast.Location = new System.Drawing.Point(43, 141);
            this.lblPLULast.Name = "lblPLULast";
            this.lblPLULast.Size = new System.Drawing.Size(68, 16);
            this.lblPLULast.TabIndex = 10;
            this.lblPLULast.Text = "Bitiş PLU :";
            // 
            // nmrPLUFirst
            // 
            this.nmrPLUFirst.Location = new System.Drawing.Point(157, 109);
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
            this.nmrPLUFirst.Size = new System.Drawing.Size(90, 22);
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
            this.lblFirstPlu.Location = new System.Drawing.Point(43, 111);
            this.lblFirstPlu.Name = "lblFirstPlu";
            this.lblFirstPlu.Size = new System.Drawing.Size(96, 16);
            this.lblFirstPlu.TabIndex = 8;
            this.lblFirstPlu.Text = "Başlangıç PLU :";
            // 
            // rbtPluRprt
            // 
            this.rbtPluRprt.AutoSize = true;
            this.rbtPluRprt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtPluRprt.Location = new System.Drawing.Point(22, 79);
            this.rbtPluRprt.Name = "rbtPluRprt";
            this.rbtPluRprt.Size = new System.Drawing.Size(117, 21);
            this.rbtPluRprt.TabIndex = 6;
            this.rbtPluRprt.Text = "PLU Raporu";
            this.rbtPluRprt.UseVisualStyleBackColor = true;
            // 
            // rbtnXReport
            // 
            this.rbtnXReport.AutoSize = true;
            this.rbtnXReport.Checked = true;
            this.rbtnXReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnXReport.Location = new System.Drawing.Point(22, 20);
            this.rbtnXReport.Name = "rbtnXReport";
            this.rbtnXReport.Size = new System.Drawing.Size(97, 21);
            this.rbtnXReport.TabIndex = 5;
            this.rbtnXReport.TabStop = true;
            this.rbtnXReport.Text = "X Raporu";
            this.rbtnXReport.UseVisualStyleBackColor = true;
            // 
            // btnPrintNonFiscReport
            // 
            this.btnPrintNonFiscReport.Location = new System.Drawing.Point(174, 370);
            this.btnPrintNonFiscReport.Name = "btnPrintNonFiscReport";
            this.btnPrintNonFiscReport.Size = new System.Drawing.Size(114, 41);
            this.btnPrintNonFiscReport.TabIndex = 0;
            this.btnPrintNonFiscReport.Text = "Rapor Al";
            this.btnPrintNonFiscReport.UseVisualStyleBackColor = true;
            this.btnPrintNonFiscReport.Click += new System.EventHandler(this.btnXReports_Click);
            // 
            // tabZReports
            // 
            this.tabZReports.Controls.Add(this.cbxFFZZDetailed);
            this.tabZReports.Controls.Add(this.cbxFFDateDetailed);
            this.tabZReports.Controls.Add(this.dtZZLastDate);
            this.tabZReports.Controls.Add(this.dtZZFirstDate);
            this.tabZReports.Controls.Add(this.lblZZLastDate);
            this.tabZReports.Controls.Add(this.lblZZFirstDate);
            this.tabZReports.Controls.Add(this.nmrFFZFirst);
            this.tabZReports.Controls.Add(this.lblFFZLast);
            this.tabZReports.Controls.Add(this.nmrFFZLast);
            this.tabZReports.Controls.Add(this.lblFFZFirst);
            this.tabZReports.Controls.Add(this.rbtnFiscDateReport);
            this.tabZReports.Controls.Add(this.rbtnFiscZZReport);
            this.tabZReports.Controls.Add(this.rbtnZReport);
            this.tabZReports.Controls.Add(this.btnPrintZReport);
            this.tabZReports.Location = new System.Drawing.Point(4, 24);
            this.tabZReports.Name = "tabZReports";
            this.tabZReports.Padding = new System.Windows.Forms.Padding(3);
            this.tabZReports.Size = new System.Drawing.Size(318, 421);
            this.tabZReports.TabIndex = 1;
            this.tabZReports.Text = "Z Raporları";
            this.tabZReports.UseVisualStyleBackColor = true;
            // 
            // cbxFFZZDetailed
            // 
            this.cbxFFZZDetailed.AutoSize = true;
            this.cbxFFZZDetailed.Location = new System.Drawing.Point(200, 170);
            this.cbxFFZZDetailed.Name = "cbxFFZZDetailed";
            this.cbxFFZZDetailed.Size = new System.Drawing.Size(69, 20);
            this.cbxFFZZDetailed.TabIndex = 25;
            this.cbxFFZZDetailed.Text = "Detaylı";
            this.cbxFFZZDetailed.UseVisualStyleBackColor = true;
            // 
            // cbxFFDateDetailed
            // 
            this.cbxFFDateDetailed.AutoSize = true;
            this.cbxFFDateDetailed.Location = new System.Drawing.Point(200, 326);
            this.cbxFFDateDetailed.Name = "cbxFFDateDetailed";
            this.cbxFFDateDetailed.Size = new System.Drawing.Size(69, 20);
            this.cbxFFDateDetailed.TabIndex = 24;
            this.cbxFFDateDetailed.Text = "Detaylı";
            this.cbxFFDateDetailed.UseVisualStyleBackColor = true;
            // 
            // dtZZLastDate
            // 
            this.dtZZLastDate.CustomFormat = "dd-MM-yyyy";
            this.dtZZLastDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtZZLastDate.Location = new System.Drawing.Point(153, 296);
            this.dtZZLastDate.Name = "dtZZLastDate";
            this.dtZZLastDate.Size = new System.Drawing.Size(125, 22);
            this.dtZZLastDate.TabIndex = 23;
            // 
            // dtZZFirstDate
            // 
            this.dtZZFirstDate.CustomFormat = "dd-MM-yyyy";
            this.dtZZFirstDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtZZFirstDate.Location = new System.Drawing.Point(153, 266);
            this.dtZZFirstDate.Name = "dtZZFirstDate";
            this.dtZZFirstDate.Size = new System.Drawing.Size(125, 22);
            this.dtZZFirstDate.TabIndex = 22;
            // 
            // lblZZLastDate
            // 
            this.lblZZLastDate.AutoSize = true;
            this.lblZZLastDate.Location = new System.Drawing.Point(43, 302);
            this.lblZZLastDate.Name = "lblZZLastDate";
            this.lblZZLastDate.Size = new System.Drawing.Size(82, 16);
            this.lblZZLastDate.TabIndex = 20;
            this.lblZZLastDate.Text = "Son Z Tarih :";
            // 
            // lblZZFirstDate
            // 
            this.lblZZFirstDate.AutoSize = true;
            this.lblZZFirstDate.Location = new System.Drawing.Point(43, 266);
            this.lblZZFirstDate.Name = "lblZZFirstDate";
            this.lblZZFirstDate.Size = new System.Drawing.Size(75, 16);
            this.lblZZFirstDate.TabIndex = 18;
            this.lblZZFirstDate.Text = "İlk Z Tarih :";
            // 
            // nmrFFZFirst
            // 
            this.nmrFFZFirst.Location = new System.Drawing.Point(157, 109);
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
            this.nmrFFZFirst.Size = new System.Drawing.Size(90, 22);
            this.nmrFFZFirst.TabIndex = 17;
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
            this.lblFFZLast.Location = new System.Drawing.Point(43, 142);
            this.lblFFZLast.Name = "lblFFZLast";
            this.lblFFZLast.Size = new System.Drawing.Size(70, 16);
            this.lblFFZLast.TabIndex = 16;
            this.lblFFZLast.Text = "Son Z No :";
            // 
            // nmrFFZLast
            // 
            this.nmrFFZLast.Location = new System.Drawing.Point(157, 139);
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
            this.nmrFFZLast.Size = new System.Drawing.Size(90, 22);
            this.nmrFFZLast.TabIndex = 15;
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
            this.lblFFZFirst.Location = new System.Drawing.Point(43, 112);
            this.lblFFZFirst.Name = "lblFFZFirst";
            this.lblFFZFirst.Size = new System.Drawing.Size(63, 16);
            this.lblFFZFirst.TabIndex = 14;
            this.lblFFZFirst.Text = "İlk Z No :";
            // 
            // rbtnFiscDateReport
            // 
            this.rbtnFiscDateReport.AutoSize = true;
            this.rbtnFiscDateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnFiscDateReport.Location = new System.Drawing.Point(22, 237);
            this.rbtnFiscDateReport.Name = "rbtnFiscDateReport";
            this.rbtnFiscDateReport.Size = new System.Drawing.Size(215, 21);
            this.rbtnFiscDateReport.TabIndex = 13;
            this.rbtnFiscDateReport.Text = "Mali Bellek Raporu(Tarih)";
            this.rbtnFiscDateReport.UseVisualStyleBackColor = true;
            // 
            // rbtnFiscZZReport
            // 
            this.rbtnFiscZZReport.AutoSize = true;
            this.rbtnFiscZZReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnFiscZZReport.Location = new System.Drawing.Point(22, 79);
            this.rbtnFiscZZReport.Name = "rbtnFiscZZReport";
            this.rbtnFiscZZReport.Size = new System.Drawing.Size(197, 21);
            this.rbtnFiscZZReport.TabIndex = 12;
            this.rbtnFiscZZReport.Text = "Mali Bellek Raporu(ZZ)";
            this.rbtnFiscZZReport.UseVisualStyleBackColor = true;
            // 
            // rbtnZReport
            // 
            this.rbtnZReport.AutoSize = true;
            this.rbtnZReport.Checked = true;
            this.rbtnZReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnZReport.Location = new System.Drawing.Point(22, 20);
            this.rbtnZReport.Name = "rbtnZReport";
            this.rbtnZReport.Size = new System.Drawing.Size(97, 21);
            this.rbtnZReport.TabIndex = 11;
            this.rbtnZReport.TabStop = true;
            this.rbtnZReport.Text = "Z Raporu";
            this.rbtnZReport.UseVisualStyleBackColor = true;
            // 
            // btnPrintZReport
            // 
            this.btnPrintZReport.Location = new System.Drawing.Point(174, 370);
            this.btnPrintZReport.Name = "btnPrintZReport";
            this.btnPrintZReport.Size = new System.Drawing.Size(114, 41);
            this.btnPrintZReport.TabIndex = 8;
            this.btnPrintZReport.Text = "Rapor Al";
            this.btnPrintZReport.UseVisualStyleBackColor = true;
            this.btnPrintZReport.Click += new System.EventHandler(this.btnPrintZReports_Click);
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
            this.tabEJSingle.Location = new System.Drawing.Point(4, 24);
            this.tabEJSingle.Name = "tabEJSingle";
            this.tabEJSingle.Padding = new System.Windows.Forms.Padding(3);
            this.tabEJSingle.Size = new System.Drawing.Size(318, 421);
            this.tabEJSingle.TabIndex = 2;
            this.tabEJSingle.Text = "EKÜ Tek Belge";
            this.tabEJSingle.UseVisualStyleBackColor = true;
            // 
            // nmrEJZCopyZNo
            // 
            this.nmrEJZCopyZNo.Location = new System.Drawing.Point(157, 96);
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
            this.nmrEJZCopyZNo.Size = new System.Drawing.Size(90, 22);
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
            this.lblZCopyZno.Location = new System.Drawing.Point(43, 98);
            this.lblZCopyZno.Name = "lblZCopyZno";
            this.lblZCopyZno.Size = new System.Drawing.Size(44, 16);
            this.lblZCopyZno.TabIndex = 40;
            this.lblZCopyZno.Text = "Z No :";
            // 
            // rbtnZCopy
            // 
            this.rbtnZCopy.AutoSize = true;
            this.rbtnZCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnZCopy.Location = new System.Drawing.Point(22, 65);
            this.rbtnZCopy.Name = "rbtnZCopy";
            this.rbtnZCopy.Size = new System.Drawing.Size(101, 21);
            this.rbtnZCopy.TabIndex = 39;
            this.rbtnZCopy.Text = "Z Kopyası";
            this.rbtnZCopy.UseVisualStyleBackColor = true;
            // 
            // rbtnEJDetail
            // 
            this.rbtnEJDetail.AutoSize = true;
            this.rbtnEJDetail.Checked = true;
            this.rbtnEJDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnEJDetail.Location = new System.Drawing.Point(22, 20);
            this.rbtnEJDetail.Name = "rbtnEJDetail";
            this.rbtnEJDetail.Size = new System.Drawing.Size(161, 21);
            this.rbtnEJDetail.TabIndex = 38;
            this.rbtnEJDetail.TabStop = true;
            this.rbtnEJDetail.Text = "Ekü Detay Raporu";
            this.rbtnEJDetail.UseVisualStyleBackColor = true;
            // 
            // dtEJSingDocTime
            // 
            this.dtEJSingDocTime.CustomFormat = "HH:mm";
            this.dtEJSingDocTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEJSingDocTime.Location = new System.Drawing.Point(153, 296);
            this.dtEJSingDocTime.Name = "dtEJSingDocTime";
            this.dtEJSingDocTime.ShowUpDown = true;
            this.dtEJSingDocTime.Size = new System.Drawing.Size(125, 22);
            this.dtEJSingDocTime.TabIndex = 35;
            // 
            // dtEJSingDocDate
            // 
            this.dtEJSingDocDate.CustomFormat = "dd-MM-yyyy";
            this.dtEJSingDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEJSingDocDate.Location = new System.Drawing.Point(153, 266);
            this.dtEJSingDocDate.Name = "dtEJSingDocDate";
            this.dtEJSingDocDate.Size = new System.Drawing.Size(125, 22);
            this.dtEJSingDocDate.TabIndex = 34;
            // 
            // lblEJSingDocTime
            // 
            this.lblEJSingDocTime.AutoSize = true;
            this.lblEJSingDocTime.Location = new System.Drawing.Point(43, 302);
            this.lblEJSingDocTime.Name = "lblEJSingDocTime";
            this.lblEJSingDocTime.Size = new System.Drawing.Size(39, 16);
            this.lblEJSingDocTime.TabIndex = 33;
            this.lblEJSingDocTime.Text = "Saat :";
            // 
            // lblEJSingDocDate
            // 
            this.lblEJSingDocDate.AutoSize = true;
            this.lblEJSingDocDate.Location = new System.Drawing.Point(43, 266);
            this.lblEJSingDocDate.Name = "lblEJSingDocDate";
            this.lblEJSingDocDate.Size = new System.Drawing.Size(44, 16);
            this.lblEJSingDocDate.TabIndex = 32;
            this.lblEJSingDocDate.Text = "Tarih :";
            // 
            // nmrEJSingDocNo
            // 
            this.nmrEJSingDocNo.Location = new System.Drawing.Point(157, 198);
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
            this.nmrEJSingDocNo.Size = new System.Drawing.Size(90, 22);
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
            this.lblEJSingDocNo.Location = new System.Drawing.Point(43, 200);
            this.lblEJSingDocNo.Name = "lblEJSingDocNo";
            this.lblEJSingDocNo.Size = new System.Drawing.Size(53, 16);
            this.lblEJSingDocNo.TabIndex = 30;
            this.lblEJSingDocNo.Text = "Fiş No :";
            // 
            // nmrEJSingDocZNo
            // 
            this.nmrEJSingDocZNo.Location = new System.Drawing.Point(157, 168);
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
            this.nmrEJSingDocZNo.Size = new System.Drawing.Size(90, 22);
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
            this.lblEJSingDocZNo.Location = new System.Drawing.Point(43, 170);
            this.lblEJSingDocZNo.Name = "lblEJSingDocZNo";
            this.lblEJSingDocZNo.Size = new System.Drawing.Size(44, 16);
            this.lblEJSingDocZNo.TabIndex = 28;
            this.lblEJSingDocZNo.Text = "Z No :";
            // 
            // rbtnEJDocCopyDate
            // 
            this.rbtnEJDocCopyDate.AutoSize = true;
            this.rbtnEJDocCopyDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnEJDocCopyDate.Location = new System.Drawing.Point(22, 237);
            this.rbtnEJDocCopyDate.Name = "rbtnEJDocCopyDate";
            this.rbtnEJDocCopyDate.Size = new System.Drawing.Size(227, 21);
            this.rbtnEJDocCopyDate.TabIndex = 27;
            this.rbtnEJDocCopyDate.Text = "Ekü Tek Belge (Tarih/Saat)";
            this.rbtnEJDocCopyDate.UseVisualStyleBackColor = true;
            // 
            // rbtnEJDocCopyZandDocId
            // 
            this.rbtnEJDocCopyZandDocId.AutoSize = true;
            this.rbtnEJDocCopyZandDocId.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnEJDocCopyZandDocId.Location = new System.Drawing.Point(22, 137);
            this.rbtnEJDocCopyZandDocId.Name = "rbtnEJDocCopyZandDocId";
            this.rbtnEJDocCopyZandDocId.Size = new System.Drawing.Size(227, 21);
            this.rbtnEJDocCopyZandDocId.TabIndex = 26;
            this.rbtnEJDocCopyZandDocId.Text = "Ekü Tek Belge (ZNo/FişNo)";
            this.rbtnEJDocCopyZandDocId.UseVisualStyleBackColor = true;
            // 
            // btnPrintEJSingReport
            // 
            this.btnPrintEJSingReport.Location = new System.Drawing.Point(174, 370);
            this.btnPrintEJSingReport.Name = "btnPrintEJSingReport";
            this.btnPrintEJSingReport.Size = new System.Drawing.Size(114, 41);
            this.btnPrintEJSingReport.TabIndex = 24;
            this.btnPrintEJSingReport.Text = "Rapor Al";
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
            this.tabEJPeriyot.Location = new System.Drawing.Point(4, 24);
            this.tabEJPeriyot.Name = "tabEJPeriyot";
            this.tabEJPeriyot.Padding = new System.Windows.Forms.Padding(3);
            this.tabEJPeriyot.Size = new System.Drawing.Size(318, 421);
            this.tabEJPeriyot.TabIndex = 3;
            this.tabEJPeriyot.Text = "Ekü Periyodik";
            this.tabEJPeriyot.UseVisualStyleBackColor = true;
            // 
            // dtDailyDate
            // 
            this.dtDailyDate.CustomFormat = "dd-MM-yyyy";
            this.dtDailyDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDailyDate.Location = new System.Drawing.Point(153, 340);
            this.dtDailyDate.Name = "dtDailyDate";
            this.dtDailyDate.Size = new System.Drawing.Size(125, 22);
            this.dtDailyDate.TabIndex = 58;
            // 
            // lblEJPerDailyDate
            // 
            this.lblEJPerDailyDate.AutoSize = true;
            this.lblEJPerDailyDate.Location = new System.Drawing.Point(43, 340);
            this.lblEJPerDailyDate.Name = "lblEJPerDailyDate";
            this.lblEJPerDailyDate.Size = new System.Drawing.Size(44, 16);
            this.lblEJPerDailyDate.TabIndex = 57;
            this.lblEJPerDailyDate.Text = "Tarih :";
            // 
            // rbtnEJPerByDaily
            // 
            this.rbtnEJPerByDaily.AutoSize = true;
            this.rbtnEJPerByDaily.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnEJPerByDaily.Location = new System.Drawing.Point(22, 311);
            this.rbtnEJPerByDaily.Name = "rbtnEJPerByDaily";
            this.rbtnEJPerByDaily.Size = new System.Drawing.Size(196, 21);
            this.rbtnEJPerByDaily.TabIndex = 56;
            this.rbtnEJPerByDaily.Text = "Ekü Periyodik (Günlük)";
            this.rbtnEJPerByDaily.UseVisualStyleBackColor = true;
            // 
            // dtEJPerLastTime
            // 
            this.dtEJPerLastTime.CustomFormat = "HH:mm";
            this.dtEJPerLastTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEJPerLastTime.Location = new System.Drawing.Point(153, 283);
            this.dtEJPerLastTime.Name = "dtEJPerLastTime";
            this.dtEJPerLastTime.ShowUpDown = true;
            this.dtEJPerLastTime.Size = new System.Drawing.Size(125, 22);
            this.dtEJPerLastTime.TabIndex = 55;
            // 
            // dtEJPerLastDate
            // 
            this.dtEJPerLastDate.CustomFormat = "dd-MM-yyyy";
            this.dtEJPerLastDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEJPerLastDate.Location = new System.Drawing.Point(153, 257);
            this.dtEJPerLastDate.Name = "dtEJPerLastDate";
            this.dtEJPerLastDate.Size = new System.Drawing.Size(125, 22);
            this.dtEJPerLastDate.TabIndex = 54;
            // 
            // lblEJPerLastTime
            // 
            this.lblEJPerLastTime.AutoSize = true;
            this.lblEJPerLastTime.Location = new System.Drawing.Point(43, 289);
            this.lblEJPerLastTime.Name = "lblEJPerLastTime";
            this.lblEJPerLastTime.Size = new System.Drawing.Size(65, 16);
            this.lblEJPerLastTime.TabIndex = 53;
            this.lblEJPerLastTime.Text = "Son Saat :";
            // 
            // lblEJPerLastDt
            // 
            this.lblEJPerLastDt.AutoSize = true;
            this.lblEJPerLastDt.Location = new System.Drawing.Point(43, 257);
            this.lblEJPerLastDt.Name = "lblEJPerLastDt";
            this.lblEJPerLastDt.Size = new System.Drawing.Size(70, 16);
            this.lblEJPerLastDt.TabIndex = 52;
            this.lblEJPerLastDt.Text = "Son Tarih :";
            // 
            // nmrEJPerLastDoc
            // 
            this.nmrEJPerLastDoc.Location = new System.Drawing.Point(157, 135);
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
            this.nmrEJPerLastDoc.Size = new System.Drawing.Size(90, 22);
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
            this.lblEJPerLastDoc.Location = new System.Drawing.Point(43, 137);
            this.lblEJPerLastDoc.Name = "lblEJPerLastDoc";
            this.lblEJPerLastDoc.Size = new System.Drawing.Size(79, 16);
            this.lblEJPerLastDoc.TabIndex = 50;
            this.lblEJPerLastDoc.Text = "Son Fiş No :";
            // 
            // nmrEJPerLastZ
            // 
            this.nmrEJPerLastZ.Location = new System.Drawing.Point(157, 109);
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
            this.nmrEJPerLastZ.Size = new System.Drawing.Size(90, 22);
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
            this.lblEJPerLastZ.Location = new System.Drawing.Point(43, 111);
            this.lblEJPerLastZ.Name = "lblEJPerLastZ";
            this.lblEJPerLastZ.Size = new System.Drawing.Size(70, 16);
            this.lblEJPerLastZ.TabIndex = 48;
            this.lblEJPerLastZ.Text = "Son Z No :";
            // 
            // dtEJPerFirstTime
            // 
            this.dtEJPerFirstTime.CustomFormat = "HH:mm";
            this.dtEJPerFirstTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEJPerFirstTime.Location = new System.Drawing.Point(153, 215);
            this.dtEJPerFirstTime.Name = "dtEJPerFirstTime";
            this.dtEJPerFirstTime.ShowUpDown = true;
            this.dtEJPerFirstTime.Size = new System.Drawing.Size(125, 22);
            this.dtEJPerFirstTime.TabIndex = 47;
            // 
            // dtEJPerFirstDate
            // 
            this.dtEJPerFirstDate.CustomFormat = "dd-MM-yyyy";
            this.dtEJPerFirstDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEJPerFirstDate.Location = new System.Drawing.Point(153, 190);
            this.dtEJPerFirstDate.Name = "dtEJPerFirstDate";
            this.dtEJPerFirstDate.Size = new System.Drawing.Size(125, 22);
            this.dtEJPerFirstDate.TabIndex = 46;
            // 
            // lblEJPerFistTime
            // 
            this.lblEJPerFistTime.AutoSize = true;
            this.lblEJPerFistTime.Location = new System.Drawing.Point(43, 221);
            this.lblEJPerFistTime.Name = "lblEJPerFistTime";
            this.lblEJPerFistTime.Size = new System.Drawing.Size(58, 16);
            this.lblEJPerFistTime.TabIndex = 45;
            this.lblEJPerFistTime.Text = "İlk Saat :";
            // 
            // lblEJPerFirstZDt
            // 
            this.lblEJPerFirstZDt.AutoSize = true;
            this.lblEJPerFirstZDt.Location = new System.Drawing.Point(43, 190);
            this.lblEJPerFirstZDt.Name = "lblEJPerFirstZDt";
            this.lblEJPerFirstZDt.Size = new System.Drawing.Size(63, 16);
            this.lblEJPerFirstZDt.TabIndex = 44;
            this.lblEJPerFirstZDt.Text = "İlk Tarih :";
            // 
            // nmrEJPerFirstDoc
            // 
            this.nmrEJPerFirstDoc.Location = new System.Drawing.Point(157, 76);
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
            this.nmrEJPerFirstDoc.Size = new System.Drawing.Size(90, 22);
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
            this.lblEJPerFirstDoc.Location = new System.Drawing.Point(43, 78);
            this.lblEJPerFirstDoc.Name = "lblEJPerFirstDoc";
            this.lblEJPerFirstDoc.Size = new System.Drawing.Size(72, 16);
            this.lblEJPerFirstDoc.TabIndex = 42;
            this.lblEJPerFirstDoc.Text = "İlk Fiş No :";
            // 
            // nmrEJPerFirstZ
            // 
            this.nmrEJPerFirstZ.Location = new System.Drawing.Point(157, 51);
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
            this.nmrEJPerFirstZ.Size = new System.Drawing.Size(90, 22);
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
            this.lblEJPerFirstZ.Location = new System.Drawing.Point(43, 53);
            this.lblEJPerFirstZ.Name = "lblEJPerFirstZ";
            this.lblEJPerFirstZ.Size = new System.Drawing.Size(63, 16);
            this.lblEJPerFirstZ.TabIndex = 40;
            this.lblEJPerFirstZ.Text = "İlk Z No :";
            // 
            // rbtnEJPerByDate
            // 
            this.rbtnEJPerByDate.AutoSize = true;
            this.rbtnEJPerByDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnEJPerByDate.Location = new System.Drawing.Point(22, 161);
            this.rbtnEJPerByDate.Name = "rbtnEJPerByDate";
            this.rbtnEJPerByDate.Size = new System.Drawing.Size(221, 21);
            this.rbtnEJPerByDate.TabIndex = 39;
            this.rbtnEJPerByDate.Text = "Ekü Periyodik (Tarih/Saat)";
            this.rbtnEJPerByDate.UseVisualStyleBackColor = true;
            // 
            // rbtnEJPerByNo
            // 
            this.rbtnEJPerByNo.AutoSize = true;
            this.rbtnEJPerByNo.Checked = true;
            this.rbtnEJPerByNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnEJPerByNo.Location = new System.Drawing.Point(22, 20);
            this.rbtnEJPerByNo.Name = "rbtnEJPerByNo";
            this.rbtnEJPerByNo.Size = new System.Drawing.Size(221, 21);
            this.rbtnEJPerByNo.TabIndex = 38;
            this.rbtnEJPerByNo.TabStop = true;
            this.rbtnEJPerByNo.Text = "Ekü Periyodik (ZNo/FişNo)";
            this.rbtnEJPerByNo.UseVisualStyleBackColor = true;
            // 
            // btnPrintEJPerReport
            // 
            this.btnPrintEJPerReport.Location = new System.Drawing.Point(174, 370);
            this.btnPrintEJPerReport.Name = "btnPrintEJPerReport";
            this.btnPrintEJPerReport.Size = new System.Drawing.Size(114, 41);
            this.btnPrintEJPerReport.TabIndex = 36;
            this.btnPrintEJPerReport.Text = "Rapor Al";
            this.btnPrintEJPerReport.UseVisualStyleBackColor = true;
            this.btnPrintEJPerReport.Click += new System.EventHandler(this.btnPrintEJPerReport_Click);
            // 
            // ReportUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpPrintArea);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.tbcReports);
            this.Name = "ReportUC";
            this.grpPrintArea.ResumeLayout(false);
            this.grpPrintArea.PerformLayout();
            this.tbcReports.ResumeLayout(false);
            this.tabXReports.ResumeLayout(false);
            this.tabXReports.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPLULast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPLUFirst)).EndInit();
            this.tabZReports.ResumeLayout(false);
            this.tabZReports.PerformLayout();
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
            this.ResumeLayout(false);

        }

        private void btnXReports_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
            int copy = GetPrintTarget();
            CPResponse response;

            try
            {
                bridge.Connection.FPUTimeout = ProgramConfig.FPU_RPRT_TIMEOUT;
                if (rbtnXReport.Checked)
                {
                    response = new CPResponse(bridge.Printer.PrintXReport(copy));
                }
                else if (rbtPluRprt.Checked)
                {
                    //FIRST PLU NO
                    int firstPLU = (int)nmrPLUFirst.Value;

                    //LAST PLU NO
                    int lastPLU = (int)nmrPLULast.Value;

                    response = new CPResponse(bridge.Printer.PrintXPluReport(firstPLU, lastPLU, copy));
                }
            }
            catch(Exception ex)
            {
                bridge.Log("Hata: İşlem başarısız.");
            }
            finally
            {
                bridge.Connection.FPUTimeout = ProgramConfig.FPU_CMD_TIMEOUT;
            }

        }


        private void btnPrintZReports_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
            int copy = GetPrintTarget();
            CPResponse response;

            try
            {
                bridge.Connection.FPUTimeout = ProgramConfig.FPU_RPRT_TIMEOUT;
                if (rbtnZReport.Checked)
                {
                    response = new CPResponse(bridge.Printer.PrintZReport());
                }
                else if (rbtnFiscZZReport.Checked)
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

                    response = new CPResponse(bridge.Printer.PrintPeriodicZZReport(firstZ, lastZ, copy, detail));
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
                    response = new CPResponse(bridge.Printer.PrintPeriodicDateReport(firstZDate, lastZDate, copy, detail));
                }
            }
            catch (Exception ex)
            {
                bridge.Log("Hata: İşlem başarısız.");
            }
            finally
            {
                bridge.Connection.FPUTimeout = ProgramConfig.FPU_CMD_TIMEOUT;
            }
        }

        private void btnPrintEJReport_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
            int copy = GetPrintTarget();
            CPResponse response;

            try
            {
                bridge.Connection.FPUTimeout = ProgramConfig.FPU_RPRT_TIMEOUT;
                if (rbtnEJDetail.Checked)
                {
                    response = new CPResponse(bridge.Printer.PrintEJDetail(copy));
                }
                else if (rbtnZCopy.Checked)
                {
                    response = new CPResponse(bridge.Printer.PrintEJPeriodic((int)nmrEJZCopyZNo.Value, 0, (int)nmrEJZCopyZNo.Value, 0, copy));
                }
                else if (rbtnEJDocCopyZandDocId.Checked)
                {
                    response = new CPResponse(bridge.Printer.PrintEJPeriodic((int)nmrEJSingDocZNo.Value,
                                                                               (int)nmrEJSingDocNo.Value,
                                                                               (int)nmrEJSingDocZNo.Value, 
                                                                               (int)nmrEJSingDocNo.Value,
                                                                                copy));
                }
                else if (rbtnEJDocCopyDate.Checked)
                {
                    //Receipt Date
                    DateTime date = dtEJSingDocDate.Value;

                    response = new CPResponse(bridge.Printer.PrintEJPeriodic(date, copy));
                }
            }
            catch (Exception ex)
            {
                bridge.Log("Hata: İşlem başarısız.");
            }
            finally
            {
                bridge.Connection.FPUTimeout = ProgramConfig.FPU_CMD_TIMEOUT;
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

        private void btnPrintEJPerReport_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
            int copy = GetPrintTarget();
            CPResponse response;

           if (rbtnEJPerByNo.Checked)
            {
                response = new CPResponse(bridge.Printer.PrintEJPeriodic((int)nmrEJPerFirstZ.Value, (int)nmrEJPerFirstDoc.Value,
                                 (int)nmrEJPerLastZ.Value, (int)nmrEJPerLastDoc.Value,
                                     copy));
            }
            else if (rbtnEJPerByDate.Checked)
            {
                //First Date
                DateTime firstDate = dtEJPerFirstDate.Value;

                //Last Date
                DateTime lastDate = dtEJPerLastDate.Value;

                response = new CPResponse(bridge.Printer.PrintEJPeriodic(firstDate, lastDate, copy));
            }
            else if (rbtnEJPerByDaily.Checked)
           {
               DateTime date = dtDailyDate.Value;

               response = new CPResponse(bridge.Printer.PrintEJPeriodic(date, copy));
           }

        }

    }
}
