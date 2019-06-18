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
    public partial class FindCustomer : Form
    {
        SQL sq = new SQL();
        CustomerManagement CM = new CustomerManagement();

        public FindCustomer()
        {
            sq.set_con_String("Server=AMIN-TAHSEEN\\SQLEXPRESS;Database=ISD;User Id=sa;Password=ameen123;");
            sq.connect_DB();
            InitializeComponent();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FindCustomer_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(searched.Text);
                string sql = "SELECT * FROM Customer WHERE Customer_ID="+id;
                SqlConnection con1;
                con1 = sq.Get_Con();
                SqlCommand cmd = new SqlCommand(sql, con1);
                sq.openDB();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        int cid = Convert.ToInt32(rdr[0]);
                        string cname = rdr[1].ToString();
                        string pno = rdr[2].ToString();
                        findID.Text = Convert.ToString(cid);
                        findname.Text = cname;
                        findcontact.Text = pno;
                        msg.Text = "Customer ID "+cid+" Found !";
                    }
                }
                else {
                    clear();
                    msg.Text = "Customer ID " + id + " Does Not Exist !";
                }
                sq.closeDB();
            }
            catch (Exception er)
            {
                msg.Text = "Error Occured !";
            }
            sq.closeDB();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(findID.Text);
            try
            {
                CM.Delete(id);
                clear();
                msg.Text = "";
            }
            catch (Exception er) {
                msg.Text = "Erro Cannot Find ID "+id;
            }
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            int search = Convert.ToInt32(searched.Text);
            string name = findname.Text;
            string cont = findcontact.Text;
            try
            {
                CM.Update(search, name, cont);
                clear();
                msg.Text = "Updated !";
            }
            catch (Exception er)
            {
                msg.Text = er.Message.ToString();
            }
        }
        private void clear()
        {
            findID.Text = "";
            findcontact.Text = "";
            findname.Text = "";
            searched.Text = "";
        }
    }
}
