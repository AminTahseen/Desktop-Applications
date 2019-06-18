using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ISD_LAB_PROJECT.Management_Class
{
    public class AttendanceManagement : BAL.IAttendance_Interface
    {
        DataTable Attendance_data = new DataTable();
        SqlConnection con = new SqlConnection("Server=AMIN-TAHSEEN\\SQLEXPRESS;Database=ISD_LAB;User Id=sa;Password=ameen123;");
        SqlCommand cmd;

        public AttendanceManagement()
        {
            Attendance_data.Columns.Add("Attendance ID", typeof(int));
            Attendance_data.Columns.Add("Student ID", typeof(int));
            Attendance_data.Columns.Add("Attendance Status", typeof(string));
            Attendance_data.Columns.Add("Attendance Date", typeof(DateTime));
        }
        public void Create(int sid, string ac, DateTime ad)
        {
            BAL.Attendance at = new BAL.Attendance(sid,ac,ad);
            cmd = new SqlCommand("INSERT INTO Student_Attend VALUES(" +at.student_id+ ",'" + at.Attendance_check + "','" +at.attendance_date+ "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
      
        }

        public void Delete(int aid)
        {
            cmd = new SqlCommand("DELETE FROM Student_Attend WHERE Attendance_ID="+aid+"", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public object Read()
        {
            Attendance_data.Clear();
            try
            {
                string sql = "SELECT * FROM Student_Attend;";
                con.Open();
                cmd = new SqlCommand(sql, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int aid = Convert.ToInt32(rdr[0]);
                    int sid = Convert.ToInt32(rdr[1]);
                    string s_status = rdr[2].ToString();
                    DateTime adate = Convert.ToDateTime(rdr[3]);
                    Attendance_data.Rows.Add(aid,sid,s_status,adate);
                }
                con.Close();
            }
            catch (Exception er)
            {

            }
            return (Object)Attendance_data;
        }

        public void Update(int aid, int sid, string ac, DateTime ad)
        {
            cmd = new SqlCommand("UPDATE Student_Attend SET Student_id="+sid+",Attendance_Check='"+ac+"',Attendance_Date='"+ad+"' WHERE Attendance_ID=" + aid + "", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
