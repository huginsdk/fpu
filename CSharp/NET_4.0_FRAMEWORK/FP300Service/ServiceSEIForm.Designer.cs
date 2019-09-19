namespace FP300Service
{
    partial class ServiceSEIForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownBrutAmount = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWageRate = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownVATRate = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStoppageRate = new System.Windows.Forms.NumericUpDown();
            this.labelServiceDefinition = new System.Windows.Forms.Label();
            this.labelServiceBrutAmount = new System.Windows.Forms.Label();
            this.textBoxServiceDefinition = new System.Windows.Forms.TextBox();
            this.labelWageRate = new System.Windows.Forms.Label();
            this.labelServiceVATRate = new System.Windows.Forms.Label();
            this.labelServiceStoppageRate = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBrutAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWageRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVATRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStoppageRate)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(358, 238);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.numericUpDownBrutAmount, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.numericUpDownWageRate, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.numericUpDownVATRate, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.numericUpDownStoppageRate, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelServiceDefinition, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelServiceBrutAmount, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBoxServiceDefinition, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelWageRate, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.labelServiceVATRate, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.labelServiceStoppageRate, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(352, 184);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // numericUpDownGrossWages
            // 
            this.numericUpDownBrutAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownBrutAmount.DecimalPlaces = 2;
            this.numericUpDownBrutAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.numericUpDownBrutAmount.Location = new System.Drawing.Point(182, 41);
            this.numericUpDownBrutAmount.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownBrutAmount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownBrutAmount.Name = "numericUpDownGrossWages";
            this.numericUpDownBrutAmount.Size = new System.Drawing.Size(164, 26);
            this.numericUpDownBrutAmount.TabIndex = 20;
            this.numericUpDownBrutAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownBrutAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownStoppageOther
            // 
            this.numericUpDownWageRate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownWageRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.numericUpDownWageRate.Location = new System.Drawing.Point(237, 151);
            this.numericUpDownWageRate.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownWageRate.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDownWageRate.Name = "numericUpDownStoppageOther";
            this.numericUpDownWageRate.Size = new System.Drawing.Size(54, 26);
            this.numericUpDownWageRate.TabIndex = 10;
            this.numericUpDownWageRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDownVATRate
            // 
            this.numericUpDownVATRate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownVATRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.numericUpDownVATRate.Location = new System.Drawing.Point(237, 113);
            this.numericUpDownVATRate.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownVATRate.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDownVATRate.Name = "numericUpDownVATRate";
            this.numericUpDownVATRate.Size = new System.Drawing.Size(54, 26);
            this.numericUpDownVATRate.TabIndex = 9;
            this.numericUpDownVATRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDownStoppageRate
            // 
            this.numericUpDownStoppageRate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownStoppageRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.numericUpDownStoppageRate.Location = new System.Drawing.Point(237, 77);
            this.numericUpDownStoppageRate.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownStoppageRate.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDownStoppageRate.Name = "numericUpDownStoppageRate";
            this.numericUpDownStoppageRate.Size = new System.Drawing.Size(54, 26);
            this.numericUpDownStoppageRate.TabIndex = 5;
            this.numericUpDownStoppageRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelServiceDefinition
            // 
            this.labelServiceDefinition.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelServiceDefinition.AutoSize = true;
            this.labelServiceDefinition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelServiceDefinition.Location = new System.Drawing.Point(38, 8);
            this.labelServiceDefinition.Name = "labelServiceDefinition";
            this.labelServiceDefinition.Size = new System.Drawing.Size(100, 20);
            this.labelServiceDefinition.TabIndex = 0;
            this.labelServiceDefinition.Text = "DEFINITION";
            // 
            // labelServiceGrossWages
            // 
            this.labelServiceBrutAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelServiceBrutAmount.AutoSize = true;
            this.labelServiceBrutAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelServiceBrutAmount.Location = new System.Drawing.Point(21, 44);
            this.labelServiceBrutAmount.Name = "labelServiceGrossWages";
            this.labelServiceBrutAmount.Size = new System.Drawing.Size(133, 20);
            this.labelServiceBrutAmount.TabIndex = 1;
            this.labelServiceBrutAmount.Text = "GROSS WAGES";
            // 
            // textBoxServiceDefinition
            // 
            this.textBoxServiceDefinition.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxServiceDefinition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxServiceDefinition.Location = new System.Drawing.Point(182, 5);
            this.textBoxServiceDefinition.Name = "textBoxServiceDefinition";
            this.textBoxServiceDefinition.Size = new System.Drawing.Size(164, 26);
            this.textBoxServiceDefinition.TabIndex = 4;
            // 
            // labelStoppageOther
            // 
            this.labelWageRate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelWageRate.AutoSize = true;
            this.labelWageRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelWageRate.Location = new System.Drawing.Point(10, 154);
            this.labelWageRate.Name = "labelStoppageOther";
            this.labelWageRate.Size = new System.Drawing.Size(156, 20);
            this.labelWageRate.TabIndex = 3;
            this.labelWageRate.Text = "STOPPAGE OTHER";
            // 
            // labelServiceVATRate
            // 
            this.labelServiceVATRate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelServiceVATRate.AutoSize = true;
            this.labelServiceVATRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelServiceVATRate.Location = new System.Drawing.Point(44, 116);
            this.labelServiceVATRate.Name = "labelServiceVATRate";
            this.labelServiceVATRate.Size = new System.Drawing.Size(87, 20);
            this.labelServiceVATRate.TabIndex = 2;
            this.labelServiceVATRate.Text = "VAT RATE";
            // 
            // labelServiceStoppageRate
            // 
            this.labelServiceStoppageRate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelServiceStoppageRate.AutoSize = true;
            this.labelServiceStoppageRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelServiceStoppageRate.Location = new System.Drawing.Point(16, 80);
            this.labelServiceStoppageRate.Name = "labelServiceStoppageRate";
            this.labelServiceStoppageRate.Size = new System.Drawing.Size(143, 20);
            this.labelServiceStoppageRate.TabIndex = 8;
            this.labelServiceStoppageRate.Text = "STOPPAGE RATE";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.Controls.Add(this.buttonAdd, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonClear, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 193);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(352, 42);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAdd.Location = new System.Drawing.Point(38, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(82, 36);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "ADD";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClear.Location = new System.Drawing.Point(231, 3);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(82, 36);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "CLEAR";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // ServiceSEIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 238);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ServiceSEIForm";
            this.ShowIcon = false;
            this.Text = "Service";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBrutAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWageRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVATRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStoppageRate)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelServiceDefinition;
        private System.Windows.Forms.Label labelServiceBrutAmount;
        private System.Windows.Forms.Label labelServiceVATRate;
        private System.Windows.Forms.Label labelWageRate;
        private System.Windows.Forms.TextBox textBoxServiceDefinition;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label labelServiceStoppageRate;
        private System.Windows.Forms.NumericUpDown numericUpDownWageRate;
        private System.Windows.Forms.NumericUpDown numericUpDownVATRate;
        private System.Windows.Forms.NumericUpDown numericUpDownStoppageRate;
        private System.Windows.Forms.NumericUpDown numericUpDownBrutAmount;
    }
}