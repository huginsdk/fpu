using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace FP300Service
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
            //CommLoggerUC commLogger = CommLoggerUC.Instance();
            //cbxLockScrool.Checked = commLogger.ScroolOn;
            //commLogger.Parent = pnlMain;
            //commLogger.Dock = DockStyle.Fill;
            //commLogger.LogOn = true;
        }

        private void cbxOnTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = cbxOnTop.Checked;
        }
    }
}
