using BAL;
using ISD_LAB_PROJECT.Database_Entity_Class;
using ISD_LAB_PROJECT.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISD_LAB_PROJECT.Management_Class
{
    public class StudentManagement:IStudent_Interface
    {
        
        DataTable student_data = new DataTable();
        SqlConnection con = new SqlConnection("Server=AMIN-TAHSEEN\\SQLEXPRESS;Database=ISD_LAB;User Id=sa;Password=ameen123;");
        SqlCommand cmd;

        public StudentManagement()
        {

            student_data.Columns.Add("Student ID", typeof(int));
            student_data.Columns.Add("Student Name", typeof(string));
            student_data.Columns.Add("Student Batch", typeof(string));
            student_data.Columns.Add("Student Address", typeof(string));
            student_data.Columns.Add("Student Phone No.", typeof(string));
            student_data.Columns.Add("Student Father Name", typeof(string));
            student_data.Columns.Add("Student Image", typeof(byte[]));
        }
        public void Create(string name, string batch, string addr, string pno, string fname, byte[] img)
        {
            Student std = new Student(name, batch, addr, pno, fname, img);
            cmd = new SqlCommand("INSERT INTO Student VALUES('" + std.Std_name + "','" + std.Std_Batch + "','" + std.Std_Address + "','" + std.Std_PhoneNo + "','" + std.Std_Fname + "',@img)",con);
            con.Open();
            cmd.Parameters.AddWithValue("@img", std.Std_Pic);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(int sid)
        {
            cmd = new SqlCommand("DELETE FROM Student WHERE Student_ID="+sid+"", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public object Read()
        {
            student_data.Clear();
            try
            {
                string sql = "SELECT * FROM Student;";
                con.Open();
                cmd = new SqlCommand(sql, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int sid=Convert.ToInt32(rdr[0]);
                    string sname = rdr[1].ToString();
                    string sbatch = rdr[2].ToString();
                    string saddr = rdr[3].ToString();
                    string sphone = rdr[4].ToString();
                    string sfname = rdr[5].ToString();
                    byte[] simg = (byte[])rdr[6];
                    student_data.Rows.Add(sid,sname,sbatch,saddr,sphone,sfname,simg);
                }
                con.Close();
            }
            catch (Exception er)
            {
               
            }
            return (Object)student_data;
        }

        public void Update(int sid, string name, string batch, string addr, string pno, string fname, byte[] img)
        {
            cmd = new SqlCommand("UPDATE Student SET Student_Name='"+name+"',Student_Batch='"+batch+"',Student_Address='"+addr+"',Student_PhoneNo='"+pno+"',Student_FatherName='"+fname+"',Student_Image=@imge WHERE Student_ID="+sid+"", con);
            con.Open();
            cmd.Parameters.AddWithValue("@imge", img);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
