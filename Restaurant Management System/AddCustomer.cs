using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISD_Project
{
    public partial class AddCustomer : Form
    {
        CustomerManagement CM = new CustomerManagement();
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CM.Create(cname.Text,ccontact.Text);
                lbMessage.Text = "Inserted !";
            }
            catch (Exception er)
            {
                lbMessage.Text = er.Message.ToString();
            }
        }
    }
}
