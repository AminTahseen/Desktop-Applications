using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using DAL;

namespace ISD_Project.User_Interface
{
    public partial class EditReservationDetails : Form
    {
        SQL sqlObj = new SQL();
        ReserveTableManagement rtm = new ReserveTableManagement();
        public EditReservationDetails()
        {
            InitializeComponent();
            sqlObj.set_con_String("Server=AMIN-TAHSEEN\\SQLEXPRESS;Database=ISD;User Id=sa;Password=ameen123;");
            sqlObj.connect_DB();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int sc_id = Convert.ToInt32(s_cid.Text);
                string sql = "SELECT * FROM Reserve_Table WHERE Customer_ID=" + sc_id + "";
                SqlConnection con1;
                con1 = sqlObj.Get_Con();
                SqlCommand cmd = new SqlCommand(sql, con1);
                sqlObj.openDB();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int r_id = Convert.ToInt32(rdr[0]);
                    int c_id = Convert.ToInt32(rdr[1]);
                    int t_id = Convert.ToInt32(rdr[2]);

                    rid.Text = r_id.ToString();
                    cid.Text = c_id.ToString() ;
                    tid.Text = t_id.ToString();

                    label3.Text = "Reservation Founded !";
                }
            }
            catch (Exception er)
            {

            }
            sqlObj.closeDB();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int r_id = Convert.ToInt32(rid.Text);
                rtm.Delete(r_id);
                label3.Text = "Reservation Deleted !";
                Clear();
            }
            catch (Exception er) {
                label3.Text = er.Message.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int r_id = Convert.ToInt32(rid.Text);
                int c_id = Convert.ToInt32(cid.Text);
                int t_id = Convert.ToInt32(tid.Text);
                rtm.Update(r_id, c_id, t_id);
                label3.Text = "Reservation Updated !";
            }
            catch (Exception er) {
                label3.Text = er.Message.ToString();
            }
            Clear();
        }
        private void Clear() {
            rid.Text = "";
            cid.Text = "";
            tid.Text = "";
            s_cid.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
