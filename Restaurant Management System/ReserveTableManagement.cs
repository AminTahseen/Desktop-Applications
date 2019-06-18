using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class ReserveTableManagement : IReserveTable_Interface
    {
        DataTable ReserveTable_table = new DataTable();
        SQL sqlObj = new SQL();

        public ReserveTableManagement() {
            sqlObj.set_con_String("Server=AMIN-TAHSEEN\\SQLEXPRESS;Database=ISD;User Id=sa;Password=ameen123;");
            sqlObj.connect_DB();
            ReserveTable_table.Columns.Add("Reservation ID", typeof(int));
            ReserveTable_table.Columns.Add("Customer ID", typeof(int));
            ReserveTable_table.Columns.Add("Table ID", typeof(int));
        }
        public void Create(int customer_id, int table_id)
        {
            ReserveTable rt = new ReserveTable(customer_id, table_id);
            sqlObj.openDB();
            sqlObj.set_NonQuery("INSERT INTO Reserve_Table VALUES(" + rt.Customer_id + ","+rt.Table_id+")");
            sqlObj.closeDB();
        }

        public void Delete(int rid)
        {
            sqlObj.openDB();
            sqlObj.set_NonQuery("DELETE FROM Reserve_Table WHERE Reserve_ID="+rid+"");
            sqlObj.closeDB();
        }
        public void DeleteByCustomer(int cid)
        {
            sqlObj.openDB();
            sqlObj.set_NonQuery("DELETE FROM Reserve_Table WHERE Customer_ID=" + cid + "");
            sqlObj.closeDB();
        }

        public object Read()
        {
            ReserveTable_table.Clear();
            try
            {
                string sql = "SELECT * FROM Reserve_Table;";
                SqlConnection con1;
                con1 = sqlObj.Get_Con();
                SqlCommand cmd = new SqlCommand(sql, con1);
                sqlObj.openDB();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int rid = Convert.ToInt32(rdr[0]);
                    int cid= Convert.ToInt32(rdr[1]);
                    int tid = Convert.ToInt32(rdr[2]);
                    ReserveTable_table.Rows.Add(rid, cid, tid);
                }
            }
            catch (Exception er)
            {

            }
            sqlObj.closeDB();
            return (object)ReserveTable_table;
        }

        public void Update(int rid, int customer_id, int table_id)
        {
            sqlObj.openDB();
            sqlObj.set_NonQuery("UPDATE Reserve_Table SET Customer_ID="+customer_id+",Table_ID="+table_id+" WHERE Reserve_ID="+rid+"");
            sqlObj.closeDB();

        }
        public object GetByTableID(int tid)
        {
            ReserveTable_table.Clear();
            try
            {
                string sql = "SELECT * FROM Reserve_Table WHERE Table_ID="+tid+";";
                SqlConnection con1;
                con1 = sqlObj.Get_Con();
                SqlCommand cmd = new SqlCommand(sql, con1);
                sqlObj.openDB();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int rid = Convert.ToInt32(rdr[0]);
                    int cid = Convert.ToInt32(rdr[1]);
                    int t_id = Convert.ToInt32(rdr[2]);
                    ReserveTable_table.Rows.Add(rid, cid, t_id);
                }
            }
            catch (Exception er)
            {

            }
            sqlObj.closeDB();
            return (object)ReserveTable_table;
        }

    }
}
