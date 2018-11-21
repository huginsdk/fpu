using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hugin.Common;

namespace FP300Service
{
    public partial class ServiceSEIForm : Form
    {
        private static Service service = null;

        public ServiceSEIForm()
        {
            InitializeComponent();

            SetLanguageOptions();
            service = null;
        }

        public static Service CurrentService
        {
            get { return service; }
        }

        private void SetLanguageOptions()
        {
            this.labelServiceDefinition.Text = FormMessage.SERVICE_DEFINITION;
            this.labelServiceGrossWages.Text = FormMessage.GROSS_WAGES;
            this.labelServiceVATRate.Text = FormMessage.VAT_RATE;
            this.labelStoppageOther.Text = FormMessage.STOPPAGE_OTHER;
            this.labelServiceStoppageRate.Text = FormMessage.STOPPAGE_RATE;
            this.buttonAdd.Text = FormMessage.ADD;
            this.buttonClear.Text = FormMessage.CLEAR;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            service = new Service();

            service.Definition = textBoxServiceDefinition.Text;
            service.GrossWages = numericUpDownGrossWages.Value;
            service.StoppageRate = (int)numericUpDownStoppageRate.Value;
            service.VATRate = (int)numericUpDownVATRate.Value;
            service.StoppageOtherRate = (int)numericUpDownStoppageOther.Value;

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            service = null;
            textBoxServiceDefinition.Clear();
            numericUpDownGrossWages.Refresh();
            numericUpDownStoppageRate.Refresh();
            numericUpDownVATRate.Refresh();
            numericUpDownStoppageOther.Refresh();
        }
    }
}
