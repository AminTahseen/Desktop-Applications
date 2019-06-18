using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class LoginManagement
   {
        private SqlConnection con;
        private SqlCommand cmd;
        public LoginManagement()
        {
            con = new SqlConnection("Server=AMIN-TAHSEEN\\SQLEXPRESS;Database=ISD;User Id=sa;Password=ameen123;");
        }
        public Boolean Check_Authentication(string username, string pass)
        {
            bool status = false;
            cmd = new SqlCommand("SELECT * FROM LOGIN WHERE username='" + username + "'AND passw='" + pass + "'",con);
            con.Open();
            SqlDataReader rdr=  cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    status = true;
                }
            }
            else {
                status = false;
            }
            con.Close();
            return status;
        }
   }
}
