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
    public class CustomerManagement : ICustomer_Interface
    {
        DataTable Customer_table = new DataTable();
        SQL sqlObj = new SQL();

        public CustomerManagement()
        {
            sqlObj.set_con_String("Server=AMIN-TAHSEEN\\SQLEXPRESS;Database=ISD;User Id=sa;Password=ameen123;");
            sqlObj.connect_DB();
            Customer_table.Columns.Add("Customer ID", typeof(int));
            Customer_table.Columns.Add("Customer Name", typeof(string));
            Customer_table.Columns.Add("Customer Contact", typeof(string));
        }
        public void Create(string cust_name, string customer_pno)
        {
            Customer cs = new Customer(cust_name, customer_pno);
            sqlObj.openDB();
            sqlObj.set_NonQuery("INSERT INTO Customer VALUES('" + cust_name + "','" + customer_pno + "')");
            sqlObj.closeDB();
        }

        public void Delete(int cust_id)
        {
            sqlObj.openDB();
            sqlObj.set_NonQuery("DELETE FROM Customer WHERE Customer_ID="+cust_id+"");
            sqlObj.closeDB();
        }

        public object Read()
        {
            Customer_table.Clear();
            try
            {
                string sql = "SELECT * FROM Customer;";
                SqlConnection con1;
                con1 = sqlObj.Get_Con();
                SqlCommand cmd = new SqlCommand(sql, con1);
                sqlObj.openDB();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int cid = Convert.ToInt32(rdr[0]);
                    string cname = rdr[1].ToString();
                    string pno = rdr[2].ToString();
                    Customer_table.Rows.Add(cid, cname, pno);
                }
            }
            catch (Exception er)
            {
             
            }
            sqlObj.closeDB();
            return (object)Customer_table;
        }

        public void Update(int cid, string cname, string cpno)
        {
            sqlObj.openDB();
            sqlObj.set_NonQuery("UPDATE Customer SET Customer_Name='" + cname + "',Customer_Contact='" + cpno + "' WHERE Customer_ID=" + cid + "");
            sqlObj.closeDB();
        }
        public Customer FindCustomer(int id) {
            Customer c = null;
            return c;
        }
     
    }
}
