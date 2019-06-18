using ISD_LAB_PROJECT.Management_Class;
using ISD_LAB_PROJECT.User_Interfaces;
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

namespace ISD_LAB_PROJECT
{
    public partial class Form1 : Form
    {
        string status;
        StudentManagement sm = new StudentManagement();
        AttendanceManagement am = new AttendanceManagement();
        DataTable student_data = new DataTable();
        DataTable Attendance_data = new DataTable();
        SqlConnection con = new SqlConnection("Server=AMIN-TAHSEEN\\SQLEXPRESS;Database=ISD_LAB;User Id=sa;Password=ameen123;");
        SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
            student_data.Columns.Add("Student ID", typeof(int));
            student_data.Columns.Add("Student Name", typeof(string));
            student_data.Columns.Add("Student Batch", typeof(string));
            student_data.Columns.Add("Student Address", typeof(string));
            student_data.Columns.Add("Student Phone No.", typeof(string));
            student_data.Columns.Add("Student Father Name", typeof(string));
            student_data.Columns.Add("Student Image", typeof(byte[]));

            Attendance_data.Columns.Add("Attendance ID", typeof(int));
            Attendance_data.Columns.Add("Student ID", typeof(int));
            Attendance_data.Columns.Add("Attendance Status", typeof(string));
            Attendance_data.Columns.Add("Attendance Date", typeof(DateTime));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddStudent ad = new AddStudent();
            ad.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EditStudent ed = new EditStudent();
            ed.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            title.Text = "Manage Student Data";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            title.Text = "Take Student Attendance";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            title.Text = "Manage Student Attendance";

        }

        private void button5_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = sm.Read();
            DataGridViewImageColumn cell = (DataGridViewImageColumn)dataGridView1.Columns[6];
            cell.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            student_data.Clear();
            try
            {
                string sql = "SELECT * FROM Student WHERE Student_ID="+id+";";
                con.Open();
                cmd = new SqlCommand(sql, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int sid = Convert.ToInt32(rdr[0]);
                    string sname = rdr[1].ToString();
                    string sbatch = rdr[2].ToString();
                    string saddr = rdr[3].ToString();
                    string sphone = rdr[4].ToString();
                    string sfname = rdr[5].ToString();
                    byte[] simg = (byte[])rdr[6];
                    student_data.Rows.Add(sid, sname, sbatch, saddr, sphone, sfname, simg);
                }
                con.Close();
            }
            catch (Exception er)
            {

            }
            dataGridView1.DataSource = student_data;
            textBox1.Text = "Student ID";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = sm.Read();
            DataGridViewImageColumn cell = (DataGridViewImageColumn)dataGridView3.Columns[6];
            cell.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var student_id = dataGridView3.Rows[e.RowIndex].Cells[0].Value;
            textBox3.Text = student_id.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int sid = Convert.ToInt32(textBox3.Text);
            string stat = status;
            DateTime date = Convert.ToDateTime(dateTimePicker1.Text);
            try
            {
                am.Create(sid, stat, date);
                MessageBox.Show("Student ID" + sid + " Attendance Marked !");
            }
            catch (Exception er) {
                MessageBox.Show(er.Message.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            status = comboBox1.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = am.Read();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            EditAttendance ed = new EditAttendance();
            ed.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        { 
            Attendance_data.Clear();
            try
            {
                DateTime date = Convert.ToDateTime(dateTimePicker2.Text);
                string sql = "SELECT * FROM Student_Attend WHERE Attendance_Date='"+date+"'";
                con.Open();
                cmd = new SqlCommand(sql, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int aid = Convert.ToInt32(rdr[0]);
                    int sid = Convert.ToInt32(rdr[1]);
                    string s_status = rdr[2].ToString();
                    DateTime adate = Convert.ToDateTime(rdr[3]);
                    Attendance_data.Rows.Add(aid, sid, s_status, adate);
                }
                con.Close();
                dataGridView2.DataSource = Attendance_data;
            }
            
            catch (Exception er)
            {

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void sbatch_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows[e.RowIndex].Cells[1].Value == null)
            {
                textBox2.Text = "";
                txtnm.Text = "";
                txtbt.Text = "";
            }
            else
            { 
            var student_id = dataGridView2.Rows[e.RowIndex].Cells[1].Value;
            textBox2.Text = student_id.ToString();
            int id = Convert.ToInt32(textBox2.Text);

            try
            {
                string sql = "SELECT Student_Name,Student_Batch FROM Student WHERE Student_ID=" + id + ";";
                con.Open();
                cmd = new SqlCommand(sql, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string sname = rdr[0].ToString();
                    string sbatch = rdr[1].ToString();
                    txtnm.Text = sname;
                    txtbt.Text = sbatch;
                }
                con.Close();
            }
            catch (Exception er)
            {

            }
        }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
         DialogResult dr = MessageBox.Show("Are You Sure ?", "Delete All Records", MessageBoxButtons.YesNoCancel,
          MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                cmd = new SqlCommand("DELETE FROM Student_Attend", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("All Attendance Record Have Been Deleted !");
                dataGridView2.DataSource = null;
            }
           
        }

        private void button15_Click(object sender, EventArgs e)
        {
            String batch = txtb.Text;
            student_data.Clear();
            try
            {
                string sql = "SELECT * FROM Student WHERE Student_Batch='" + batch + "';";
                con.Open();
                cmd = new SqlCommand(sql, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int sid = Convert.ToInt32(rdr[0]);
                    string sname = rdr[1].ToString();
                    string sbatch = rdr[2].ToString();
                    string saddr = rdr[3].ToString();
                    string sphone = rdr[4].ToString();
                    string sfname = rdr[5].ToString();
                    byte[] simg = (byte[])rdr[6];
                    student_data.Rows.Add(sid, sname, sbatch, saddr, sphone, sfname, simg);
                }
                con.Close();
            }
            catch (Exception er)
            {

            }
            dataGridView3.DataSource = student_data;
            txtb.Text = "";
            DataGridViewImageColumn cell = (DataGridViewImageColumn)dataGridView3.Columns[6];
            cell.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
    }
}
