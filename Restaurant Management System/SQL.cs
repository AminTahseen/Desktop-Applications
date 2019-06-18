using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class SQL
    {
        private string connection;
        private SqlConnection con;
        private SqlCommand cmd;

        public void set_con_String(string con_str)
        {
            connection = con_str;
        }
        public void connect_DB()
        {
            con = new SqlConnection(connection);
        }
        public void openDB()
        {
            con.Open();
        }
        public void set_NonQuery(string quer)
        {
            string query = quer;
           cmd=new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }
        public void closeDB() // close database
        {
            con.Close();
        }
        public SqlConnection Get_Con() 
        {
            return con;
        }
      
    }
}
