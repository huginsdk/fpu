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
    public partial class CustomerForm : Form
    {
        private static Customer customer = null;

        public CustomerForm()
        {
            InitializeComponent();

            SetLanguageOptions();
            customer = null;
        }

        public static Customer CurrentCustomer
        {
            get { return customer; }
        }

        private void SetLanguageOptions()
        {
            this.labelCustomerName.Text = FormMessage.CUSTOMER_NAME;
            this.labelCustomerTaxOffice.Text = FormMessage.TAX_OFFICE;
            this.labelCustomerAddress1.Text = FormMessage.ADDRESS_LINE + " 1";
            this.labelCustomerAddress2.Text = FormMessage.ADDRESS_LINE + " 2";
            this.labelCustomerAddress3.Text = FormMessage.ADDRESS_LINE + " 3";
            this.labelCustomerAddress4.Text = FormMessage.ADDRESS_LINE + " 4";
            this.labelCustomerAddress5.Text = FormMessage.ADDRESS_LINE + " 5";
            this.labelCustomerLabel.Text = FormMessage.LABEL;
            this.buttonAdd.Text = FormMessage.ADD;
            this.buttonClear.Text = FormMessage.CLEAR;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            customer = new Customer();
            customer.TCKN_VKN = textBoxCustomerTCKNVKN.Text;
            customer.Name = textBoxCustomerName.Text;
            customer.Label = textBoxCustomerLabel.Text;
            customer.TaxOffice = textBoxCustomerTaxOffice.Text;

            if (customer.AddressList == null)
                customer.AddressList = new List<string>();

            customer.AddressList.Add(textBoxCustomerAddress1.Text);
            customer.AddressList.Add(textBoxCustomerAddress2.Text);
            customer.AddressList.Add(textBoxCustomerAddress3.Text);
            customer.AddressList.Add(textBoxCustomerAddress4.Text);
            customer.AddressList.Add(textBoxCustomerAddress5.Text);

            for(int i = customer.AddressList.Count; i>0;i--)
            {
                int currIndex = i - 1;
                if(customer.AddressList[currIndex].Length == 0)
                {
                    customer.AddressList.RemoveAt(currIndex);
                }
                else
                {
                    break;
                }
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            customer = null;
            textBoxCustomerAddress1.Clear();
            textBoxCustomerAddress2.Clear();
            textBoxCustomerAddress3.Clear();
            textBoxCustomerAddress4.Clear();
            textBoxCustomerAddress5.Clear();
            textBoxCustomerName.Clear();
            textBoxCustomerTaxOffice.Clear();
            textBoxCustomerTCKNVKN.Clear();
        }
    }
}
