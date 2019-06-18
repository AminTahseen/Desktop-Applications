using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using BAL;
namespace DAL
{
    public class RestaurantTableManagement : IRestaurantTable_Interface
    {
        DataTable RestaurantTables_table = new DataTable();
        SQL sqlObj = new SQL();

        public RestaurantTableManagement() {
          sqlObj.set_con_String("Server=AMIN-TAHSEEN\\SQLEXPRESS;Database=ISD;User Id=sa;Password=ameen123;");
          sqlObj.connect_DB();
          RestaurantTables_table.Columns.Add("Table ID", typeof(int));
          RestaurantTables_table.Columns.Add("Number Of Seats", typeof(int));
        }
        public void Create(int No_Of_Seats)
        {
            Resturant_Table rt = new Resturant_Table(No_Of_Seats);
            sqlObj.openDB();
            sqlObj.set_NonQuery("INSERT INTO rest_tables VALUES(" +rt.No_Of_Seat+")");
            sqlObj.closeDB();
        }

        public void Delete(int T_ID)
        {
            sqlObj.openDB();
            sqlObj.set_NonQuery("DELETE FROM rest_tables WHERE Table_ID="+T_ID+"");
            sqlObj.closeDB();
        }

        public object Read()
        {
            RestaurantTables_table.Clear();
            try
            {
                string sql = "SELECT * FROM rest_tables;";
                SqlConnection con1;
                con1 = sqlObj.Get_Con();
                SqlCommand cmd = new SqlCommand(sql, con1);
                sqlObj.openDB();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int tid = Convert.ToInt32(rdr[0]);
                    int no_ofseats = Convert.ToInt32(rdr[1]);
                  
                    RestaurantTables_table.Rows.Add(tid, no_ofseats);
                }
            }
            catch (Exception er)
            {

            }
            sqlObj.closeDB();
            return (object)RestaurantTables_table;
        }

        public void Update(int Table_ID, int No_Of_Seats)
        {
            sqlObj.openDB();
            sqlObj.set_NonQuery("UPDATE rest_tables SET No_Of_Seats=" + No_Of_Seats +" WHERE Table_ID=" + Table_ID + "");
            sqlObj.closeDB();
        }
    }
}
