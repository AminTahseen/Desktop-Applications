using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISD_Project
{
    public partial class EditOrderDetails : Form
    {
        OrderManagement orm = new OrderManagement();
        SQL sqlObj = new SQL();
        public EditOrderDetails()
        {
            sqlObj.set_con_String("Server=AMIN-TAHSEEN\\SQLEXPRESS;Database=ISD;User Id=sa;Password=ameen123;");
            sqlObj.connect_DB();
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int OID = Convert.ToInt32(textBox8.Text);
            int cid=Convert.ToInt32(textBox1.Text);
            int it_id= Convert.ToInt32(textBox6.Text);
            int quan= Convert.ToInt32(textBox2.Text) ;
            try
            {
                orm.Update(OID,cid, it_id, quan);
                label3.Text = "Order Updated !";
                clear();
            }
            catch (Exception er) {
                label3.Text = er.Message.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int cid = Convert.ToInt32(textBox1.Text);
            try
            {
                orm.Delete(cid);
                label3.Text = "Order Deleted !";
                clear();
            }
            catch (Exception er) {
                label3.Text = er.Message.ToString() ;
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int o_id = Convert.ToInt32(textBox7.Text);
                string sql = "SELECT * FROM Orders WHERE Order_ID=" + o_id + "";
                SqlConnection con1;
                con1 = sqlObj.Get_Con();
                SqlCommand cmd = new SqlCommand(sql, con1);
                sqlObj.openDB();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int oid = Convert.ToInt32(rdr[0]);
                    int cstid = Convert.ToInt32(rdr[1]);
                    int itid = Convert.ToInt32(rdr[2]);
                    int quant = Convert.ToInt32(rdr[3]);

                    textBox8.Text = oid.ToString();
                    textBox1.Text = cstid.ToString();
                    textBox6.Text = itid.ToString();
                    textBox2.Text = quant.ToString();
                    label3.Text = "Order Founded !";
                }
            }
            catch (Exception er)
            {

            }
            sqlObj.closeDB();
        }
        private void clear() {
            textBox8.Text = "";
            textBox1.Text = "";
            textBox6.Text = "";
            textBox2.Text = "";
            textBox7.Text= "";
        }
    }
}
