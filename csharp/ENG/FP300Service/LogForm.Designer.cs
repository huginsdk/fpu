namespace FP300Service
{
    partial class LogForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.cbxOnTop = new System.Windows.Forms.CheckBox();
            this.cbxLockScrool = new System.Windows.Forms.CheckBox();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.cbxLockScrool);
            this.pnlHeader.Controls.Add(this.cbxOnTop);
            this.pnlHeader.Location = new System.Drawing.Point(12, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(321, 42);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.Location = new System.Drawing.Point(12, 51);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(408, 336);
            this.pnlMain.TabIndex = 1;
            // 
            // cbxOnTop
            // 
            this.cbxOnTop.AutoSize = true;
            this.cbxOnTop.Location = new System.Drawing.Point(19, 9);
            this.cbxOnTop.Name = "cbxOnTop";
            this.cbxOnTop.Size = new System.Drawing.Size(167, 21);
            this.cbxOnTop.TabIndex = 0;
            this.cbxOnTop.Text = "Her Zaman Üst\'de kal";
            this.cbxOnTop.UseVisualStyleBackColor = true;
            this.cbxOnTop.CheckedChanged += new System.EventHandler(this.cbxOnTop_CheckedChanged);
            // 
            // cbxLockScrool
            // 
            this.cbxLockScrool.AutoSize = true;
            this.cbxLockScrool.Location = new System.Drawing.Point(192, 9);
            this.cbxLockScrool.Name = "cbxLockScrool";
            this.cbxLockScrool.Size = new System.Drawing.Size(104, 21);
            this.cbxLockScrool.TabIndex = 1;
            this.cbxLockScrool.Text = "Liste Kaydır";
            this.cbxLockScrool.UseVisualStyleBackColor = true;
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 399);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Name = "LogForm";
            this.Text = "İletişim Log Gösterici";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.CheckBox cbxLockScrool;
        private System.Windows.Forms.CheckBox cbxOnTop;
        private System.Windows.Forms.Panel pnlMain;

    }
}