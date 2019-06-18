using BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderManagement : IOrder_Interface
    {
        DataTable Order_table = new DataTable();
        SQL sqlObj = new SQL();

        public OrderManagement()
        {
            sqlObj.set_con_String("Server=AMIN-TAHSEEN\\SQLEXPRESS;Database=ISD;User Id=sa;Password=ameen123;");
            sqlObj.connect_DB();
            Order_table.Columns.Add("Order ID", typeof(int));
            Order_table.Columns.Add("Customer ID", typeof(int));
            Order_table.Columns.Add("Food Item ID", typeof(int));
            Order_table.Columns.Add("Item Quantity", typeof(int));
        }
        public void Create(int customer_id, int item_id, int quantity)
        {
            Order ord = new Order(customer_id,item_id,quantity);
            sqlObj.openDB();
            sqlObj.set_NonQuery("INSERT INTO Orders VALUES(" + ord.Customer_id + "," + ord.item_id + "," + ord.Food_quantity + ")");
            sqlObj.closeDB();
        }

        public void Delete(int Oid)
        {
            sqlObj.openDB();
            sqlObj.set_NonQuery("DELETE FROM Orders WHERE Order_ID="+Oid+"");
            sqlObj.closeDB();
        }

        public void DeleteByCustomer(int cid)
        {
            sqlObj.openDB();
            sqlObj.set_NonQuery("DELETE FROM Orders WHERE Customer_ID=" + cid + "");
            sqlObj.closeDB();
        }
        public object Read()
        {
            Order_table.Clear();
            try
            {
                string sql = "SELECT * FROM Orders;";
                SqlConnection con1;
                con1 = sqlObj.Get_Con();
                SqlCommand cmd = new SqlCommand(sql, con1);
                sqlObj.openDB();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int oid = Convert.ToInt32(rdr[0]);
                    int cid = Convert.ToInt32(rdr[1]);
                    int itid = Convert.ToInt32(rdr[2]);
                    int quant = Convert.ToInt32(rdr[3]);
                    Order_table.Rows.Add(oid, cid, itid, quant);
                }
            }
            catch (Exception er)
            {

            }
            sqlObj.closeDB();
            return (object)Order_table;
        }

        public void Update(int Oid, int customer_id, int item_id, int quantity)
        {
            sqlObj.openDB();
            sqlObj.set_NonQuery("UPDATE Orders Set Item_ID="+item_id+",Quantity="+quantity+",Customer_ID="+customer_id+" WHERE Order_ID="+Oid+"");
            sqlObj.closeDB();
        }
        public object GetCustomer_Order(int cust_id)
        {
            Order_table.Clear();
            try
            {
                string sql = "SELECT * FROM Orders WHERE Customer_ID="+cust_id+"";
                SqlConnection con1;
                con1 = sqlObj.Get_Con();
                SqlCommand cmd = new SqlCommand(sql, con1);
                sqlObj.openDB();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int oid = Convert.ToInt32(rdr[0]);
                    int cid = Convert.ToInt32(rdr[1]);
                    int itid = Convert.ToInt32(rdr[2]);
                    int quant = Convert.ToInt32(rdr[3]);
                    Order_table.Rows.Add(oid, cid, itid, quant);
                }
            }
            catch (Exception er)
            {

            }
            sqlObj.closeDB();
            return (object)Order_table;
        }
    }
}
