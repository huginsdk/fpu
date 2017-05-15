using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FP300Service
{
    public class InputBox : Form
    {
        private Label lblText;
        private TextBox txtInput;
        private Button btnOK;
        public string input = "";

        public InputBox(String caption)
        {
            InitializeComponent();
            lblText.Text = caption;
        }

        public InputBox(String caption, int maxLen)
            : this(caption)
        {
            txtInput.MaxLength = maxLen;
        }

        private void InitializeComponent()
        {
            this.lblText = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(12, 18);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(83, 17);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "Sayı Giriniz:";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(64, 54);
            this.txtInput.MaxLength = 50;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(304, 22);
            this.txtInput.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(230, 94);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(138, 35);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Tamam";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // InputBox
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 156);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Giriş Yapınız";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            input = txtInput.Text;
            this.Close();
        }
    
    }
}
