using BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class FoodItemManagement : IFoodItem_Interface
    {
        OpenFileDialog op = new OpenFileDialog();
        DataTable Item_table = new DataTable();
        SQL sqlObj = new SQL();

        public FoodItemManagement()
        {
            sqlObj.set_con_String("Server=AMIN-TAHSEEN\\SQLEXPRESS;Database=ISD;User Id=sa;Password=ameen123;");
            sqlObj.connect_DB();
            Item_table.Columns.Add("Food Item ID", typeof(int));
            Item_table.Columns.Add("Food Item Name", typeof(string));
            Item_table.Columns.Add("Food Item Serve", typeof(int));
            Item_table.Columns.Add("Food Item Price", typeof(decimal));
            Item_table.Columns.Add("Food Item Image", typeof(byte[]));
        }
        public void Create(string item_name, int serve, decimal price, byte[] img)
        {
            Food_Item item = new Food_Item(item_name, serve, price, img);
            SqlConnection con1 = sqlObj.Get_Con();
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("INSERT INTO Food_Items Values('" + item.Food_Name + "'," + item.Food_Serving + "," + item.Food_Price + ", @img)", con1);
            cmd1.Parameters.AddWithValue("@img", img);
            cmd1.ExecuteNonQuery();
            con1.Close();
        }

        public void Delete(int id)
        {
            sqlObj.openDB();
            sqlObj.set_NonQuery("DELETE FROM Food_Items WHERE Item_ID="+id+"");
            sqlObj.closeDB();
        }
        public void DeleteByName(string name)
        {
            sqlObj.openDB();
            sqlObj.set_NonQuery("DELETE FROM Food_Items WHERE Item_Name='" + name + "'");
            sqlObj.closeDB();
        }
        public object Read()
        {
            Item_table.Clear();
            try
            {
                string sql = "SELECT * FROM Food_Items";
                SqlConnection con1;
                con1 = sqlObj.Get_Con();
                SqlCommand cmd = new SqlCommand(sql, con1);
                sqlObj.openDB();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int item_id = Convert.ToInt32(rdr[0]);
                    string item_name = rdr[1].ToString();
                    int item_serve = Convert.ToInt32(rdr[2]);
                    decimal item_price = Convert.ToDecimal(rdr[3]);
                    byte[] item_img = (byte[])rdr[4];
                    Item_table.Rows.Add(item_id,item_name, item_serve, item_price, item_img);
                }
            }
            catch (Exception er)
            {

            }
            sqlObj.closeDB();
            return (object)Item_table;

        }

        public void Update(int id, string item_name, int serve, decimal price, byte[] img)
        {
            SqlConnection con1 = sqlObj.Get_Con();
            con1.Open();
            Food_Item i = new Food_Item(item_name, serve, price, img);
            SqlCommand cmd1 = new SqlCommand("UPDATE Food_Items SET Item_Name='"+i.Food_Name+"',Item_Serve="+i.Food_Serving+",Item_Price="+i.Food_Price+",Item_Image=@img WHERE Item_ID="+id+"", con1);
            cmd1.Parameters.AddWithValue("@img",i.Food_image);
            cmd1.ExecuteNonQuery();
            con1.Close();
        }
        public object GetByName(string item_nm) {
            Item_table.Clear();
            try
            {
                string sql = "SELECT * FROM Food_Items WHERE Item_Name='"+item_nm+"'";
                SqlConnection con1;
                con1 = sqlObj.Get_Con();
                SqlCommand cmd = new SqlCommand(sql, con1);
                sqlObj.openDB();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int item_id = Convert.ToInt32(rdr[0]);
                    string item_name = rdr[1].ToString();
                    int item_serve = Convert.ToInt32(rdr[2]);
                    decimal item_price = Convert.ToDecimal(rdr[3]);
                    byte[] item_img = (byte[])rdr[4];
                    Item_table.Rows.Add(item_id, item_name, item_serve, item_price, item_img);
                }
            }
            catch (Exception er)
            {

            }
            sqlObj.closeDB();
            return (object)Item_table;
        }
    }
}
