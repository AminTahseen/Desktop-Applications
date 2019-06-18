using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISD_Project.User_Interface
{
    public partial class CreateOrder : Form
    {
        OrderManagement Order = new OrderManagement();
        SQL sqlObj = new SQL();
        public CreateOrder()
        {
            InitializeComponent();
        }
      
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cid = Convert.ToInt32(custID.Text);
            int itemID = Convert.ToInt32(item_ID.Text);
            int quantity = Convert.ToInt32(quant.Text);
            try
            {
                Order.Create(cid, itemID, quantity);
                lblmsg.Text = "Item ID-" + itemID + " Has Been Ordered !";
                lblmsg.ForeColor = System.Drawing.Color.ForestGreen;
            }
            catch (Exception er)
            {
                lblmsg.Text = "Error " + er.Message.ToString();
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
          
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
