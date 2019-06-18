using ISD_LAB_PROJECT.Management_Class;
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

namespace ISD_LAB_PROJECT.User_Interfaces
{
    public partial class EditAttendance : Form
    {
        SqlConnection con = new SqlConnection("Server=AMIN-TAHSEEN\\SQLEXPRESS;Database=ISD_LAB;User Id=sa;Password=ameen123;");
        SqlCommand cmd;
        AttendanceManagement am = new AttendanceManagement();
        public EditAttendance()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void sbatch_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
         DialogResult dr = MessageBox.Show("Are You Sure ?", "Delete Record", MessageBoxButtons.YesNoCancel,
         MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                int id = Convert.ToInt32(aid.Text);
                try
                {
                    am.Delete(id);
                    MessageBox.Show("Deleted !");
                    clear();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message.ToString());
                }
            }
         
        }
        private void clear()
        {
            sid.Text = "";
            aid.Text = "";
            comboBox1.Text = "Attendance";

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are You Sure ?", "Update Record", MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
            
            int a_id = Convert.ToInt32(aid.Text);
            int s_id = Convert.ToInt32(sid.Text);
            string stat = comboBox1.Text;
            DateTime date = Convert.ToDateTime(dateTimePicker1.Text);
            try
            {
                am.Update(a_id, s_id, stat, date);
                MessageBox.Show("Updated !");
                clear();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message.ToString());
            }
        }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(sid.Text);
            try
            {
                DateTime date = Convert.ToDateTime(dateTimePicker1.Text);
                string sql = "SELECT Attendance_ID,Attendance_Check,Attendance_Date FROM Student_Attend WHERE Student_ID=" + id + "";
                con.Open();
                cmd = new SqlCommand(sql, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int a_id = Convert.ToInt32(rdr[0]);
                    string s_status = rdr[1].ToString();
                    DateTime adate = Convert.ToDateTime(rdr[2]);

                    aid.Text = a_id.ToString();
                    comboBox1.Text = s_status;
                    dateTimePicker1.Text = adate.ToString();
                }
               
                con.Close();
            
            }

            catch (Exception er)
            {

            }
        }
    }
 }

