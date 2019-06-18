using System;
using DAL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ISD_Project;
using ISD_Project.User_Interface;

namespace BAL
{
    public partial class main : Form
    {

        CustomerManagement cm = new CustomerManagement();
        FoodItemManagement fim = new FoodItemManagement();
        OrderManagement orm = new OrderManagement();
        ReserveTableManagement rtm = new ReserveTableManagement();
        SQL sqlObj = new SQL();
        DataTable Bill = new DataTable();
        float TotalBill = 0;
        int getAmount = 0;

        public main()
        {
            InitializeComponent();
            sqlObj.set_con_String("Server=AMIN-TAHSEEN\\SQLEXPRESS;Database=ISD;User Id=sa;Password=ameen123;");
            sqlObj.connect_DB();
            Bill.Columns.Add("Customer ID", typeof(int));
            Bill.Columns.Add("Food Item Name", typeof(string));
            Bill.Columns.Add("Food Item Price", typeof(decimal));
            Bill.Columns.Add("Food Item Quantity", typeof(int));

        }



        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            homebtn.BackColor = Color.FromArgb(255, 232, 65, 24);
            custbtn.BackColor = Color.FromArgb(255, 30, 55, 153);
            menubtn.BackColor = Color.FromArgb(255, 232, 65, 24);
            ordrbtn.BackColor = Color.FromArgb(255, 232, 65, 24);
            dineinbtn.BackColor = Color.FromArgb(255, 232, 65, 24);
            totalbillbtn.BackColor = Color.FromArgb(255, 232, 65, 24);
        }



        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            homebtn.BackColor = Color.FromArgb(255, 232, 65, 24);
            custbtn.BackColor = Color.FromArgb(255, 232, 65, 24);
            menubtn.BackColor = Color.FromArgb(255, 30, 55, 153);
            ordrbtn.BackColor = Color.FromArgb(255, 232, 65, 24);
            dineinbtn.BackColor = Color.FromArgb(255, 232, 65, 24);
            totalbillbtn.BackColor = Color.FromArgb(255, 232, 65, 24);

        }

        private void button8_Click_2(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cm.Read();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

       


    
        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
            homebtn.BackColor = Color.FromArgb(255, 232, 65, 24);
            custbtn.BackColor = Color.FromArgb(255, 232, 65, 24);
            menubtn.BackColor = Color.FromArgb(255, 232, 65, 24);
            ordrbtn.BackColor = Color.FromArgb(255, 30, 55, 153);
            dineinbtn.BackColor = Color.FromArgb(255, 232, 65, 24);
            totalbillbtn.BackColor = Color.FromArgb(255, 232, 65, 24);
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            AddCustomer ad = new AddCustomer();
            ad.ShowDialog();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            ISD_Project.FindCustomer fc = new ISD_Project.FindCustomer();
            fc.ShowDialog();
        }

   
        private void button15_Click(object sender, EventArgs e)
        {
            EditOrderDetails eod = new EditOrderDetails();
            eod.ShowDialog();
            CLEAR();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            menu_data_grid.DataSource = fim.Read();
            DataGridViewImageColumn cell = (DataGridViewImageColumn)menu_data_grid.Columns[4];
            cell.ImageLayout = DataGridViewImageCellLayout.Stretch;


        }


        private void menu_data_grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var item_id = menu_data_grid.Rows[e.RowIndex].Cells[0].Value;
                var item_name = menu_data_grid.Rows[e.RowIndex].Cells[1].Value;
                byte[] image = (byte[])menu_data_grid.Rows[e.RowIndex].Cells[4].Value;

                ISD_Project.User_Interface.CreateOrder cd = new ISD_Project.User_Interface.CreateOrder();
                cd.item_ID.Text = item_id.ToString();
                cd.itemName.Text = item_name.ToString();
                MemoryStream ms = new MemoryStream(image);
                cd.pictureBox1.Image = Image.FromStream(ms);
                cd.ShowDialog();
            }
            catch (Exception ER) {
                CLEAR();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemName.Text == "")
                {
                    MessageBox.Show("Enter Item Name Please !");
                }
                else
                {
                    string item_name = itemName.Text;
                    menu_data_grid.DataSource = fim.GetByName(item_name);
                    DataGridViewImageColumn cell = (DataGridViewImageColumn)menu_data_grid.Columns[4];
                    cell.ImageLayout = DataGridViewImageCellLayout.Stretch;
                }
            }
            catch (Exception ER) {
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            order_grid.DataSource = orm.Read();
            CLEAR();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox9.Text == "")
                {
                    MessageBox.Show("Enter ID Please !");
                }
                else
                {
                    int search_Cust_ID = Convert.ToInt32(textBox9.Text);
                    order_grid.DataSource = orm.GetCustomer_Order(search_Cust_ID);
                    CLEAR();
                }
            }
            catch (Exception er) {

            }
        }

        private void order_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var cust_id = order_grid.Rows[e.RowIndex].Cells[1].Value;
                var itemid = order_grid.Rows[e.RowIndex].Cells[2].Value;

                item_id.Text = Convert.ToString(itemid);
                cid.Text = cust_id.ToString();

                int SCid = Convert.ToInt32(item_id.Text);
                int C_id = Convert.ToInt32(cid.Text);

                GET_ITEM_ByID(SCid);
                GetCust_ByID(C_id);
            }
            catch (Exception er) {
                CLEAR();
            }

        }

       
        private void GET_ITEM_ByID(int SCid)
        {
            try
            {
                string sql = "SELECT Item_Name,Item_Serve,Item_Price,Item_Image FROM Food_Items WHERE Item_ID=" + SCid + "";
                SqlConnection con1;
                con1 = sqlObj.Get_Con();
                SqlCommand cmd = new SqlCommand(sql, con1);
                sqlObj.openDB();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    string it_name = rdr[0].ToString();
                    int it_serve = Convert.ToInt32(rdr[1]);
                    decimal it_price = Convert.ToDecimal(rdr[2]);
                    byte[] it_img = (byte[])rdr[3];
                    //Set to Textbox
                    item_name.Text = it_name;
                    item_serve.Text = it_serve.ToString();
                    item_price.Text = it_price.ToString();
                    MemoryStream ms = new MemoryStream(it_img);
                    item_img.Image = Image.FromStream(ms);
                }
            }
            catch (Exception er)
            {
                CLEAR();
            }
            sqlObj.closeDB();
        }
        private void GetCust_ByID(int cid)
        {
            try
            {
                string sql = "SELECT Customer_Name,Customer_Contact FROM Customer WHERE Customer_ID=" + cid + "";
                SqlConnection con1;
                con1 = sqlObj.Get_Con();
                SqlCommand cmd = new SqlCommand(sql, con1);
                sqlObj.openDB();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    string c_name = rdr[0].ToString();
                    string c_cont = rdr[1].ToString();

                    //Set to Textbox
                    cname.Text = c_name;
                    ccont.Text = c_cont;


                }
            }
            catch (Exception er)
            {
                CLEAR();
            }
            sqlObj.closeDB();
        }
        private void CLEAR()
        {
            textBox9.Text = "";
            cid.Text = "";
            cname.Text = "";
            ccont.Text = "";
            item_id.Text = "";
            item_name.Text = "";
            item_serve.Text = "";
            item_price.Text = "";
            cnamet.Text = "";
            ccontt.Text = "";
            tnoofseats.Text = "";
            tidt.Text = "";
            cidt.Text = "";
            checkTid.Text = "";
            item_img.Image = Image.FromFile("C:/Users/LAPTOP POINT/Desktop/cars/food_icon.png");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your Order Is Getting Ready !");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            homebtn.BackColor = Color.FromArgb(255, 30, 55, 153);
            custbtn.BackColor = Color.FromArgb(255, 232, 65, 24);
            menubtn.BackColor = Color.FromArgb(255, 232, 65, 24);
            ordrbtn.BackColor = Color.FromArgb(255, 232, 65, 24);
            dineinbtn.BackColor = Color.FromArgb(255, 232, 65, 24);
            totalbillbtn.BackColor = Color.FromArgb(255, 232, 65, 24);

        }

        private void button16_Click(object sender, EventArgs e)
        {
           SelectTable ST = new SelectTable();
            ST.ShowDialog();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            reserve_grid.DataSource = rtm.Read();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
            homebtn.BackColor = Color.FromArgb(255, 232, 65, 24);
            custbtn.BackColor = Color.FromArgb(255, 232, 65, 24);
            menubtn.BackColor = Color.FromArgb(255, 232, 65, 24);
            ordrbtn.BackColor = Color.FromArgb(255, 232, 65, 24);
            dineinbtn.BackColor = Color.FromArgb(255, 30, 55, 153);
            totalbillbtn.BackColor = Color.FromArgb(255, 232, 65, 24);

        }

        private void reserve_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var cust_id = reserve_grid.Rows[e.RowIndex].Cells[1].Value;
                var table_id = reserve_grid.Rows[e.RowIndex].Cells[2].Value;

                tidt.Text = table_id.ToString();
                cidt.Text = cust_id.ToString();

                int cid = Convert.ToInt32(cidt.Text);
                int tid = Convert.ToInt32(tidt.Text);
                GetReserve_ByCustID(cid);
                GetTableData(tid);
            }
            catch (Exception er) {
                CLEAR();
            }
        }
        private void GetTableData(int tid) {
            try
            {
                string sql = "SELECT * FROM rest_tables WHERE Table_ID="+tid+";";
                SqlConnection con1;
                con1 = sqlObj.Get_Con();
                SqlCommand cmd = new SqlCommand(sql, con1);
                sqlObj.openDB();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int t_id = Convert.ToInt32(rdr[0]);
                    int no_ofseats = Convert.ToInt32(rdr[1]);

                    tidt.Text = t_id.ToString();
                    tnoofseats.Text = no_ofseats.ToString();
                }
            }
            catch (Exception er)
            {
                CLEAR();
            }
            sqlObj.closeDB();
        }
        private void GetReserve_ByCustID(int cid)
        {
            try
            {
                string sql = "SELECT Customer_Name,Customer_Contact FROM Customer WHERE Customer_ID=" + cid + "";
                SqlConnection con1;
                con1 = sqlObj.Get_Con();
                SqlCommand cmd = new SqlCommand(sql, con1);
                sqlObj.openDB();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    string c_name = rdr[0].ToString();
                    string c_cont = rdr[1].ToString();

                    //Set to Textbox
                    cnamet.Text = c_name;
                    ccontt.Text = c_cont;


                }
            }
            catch (Exception er)
            {
                CLEAR();
            }
            sqlObj.closeDB();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                int td = Convert.ToInt32(checkTid.Text);
                reserve_grid.DataSource = rtm.GetByTableID(td);
            }
            catch (Exception er) {
            }
        }

        private void totalbillbtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage6;
            homebtn.BackColor = Color.FromArgb(255, 232, 65, 24);
            custbtn.BackColor = Color.FromArgb(255, 232, 65, 24);
            menubtn.BackColor = Color.FromArgb(255, 232, 65, 24);
            ordrbtn.BackColor = Color.FromArgb(255, 232, 65, 24);
            dineinbtn.BackColor = Color.FromArgb(255, 232, 65, 24);
            totalbillbtn.BackColor = Color.FromArgb(255, 30, 55, 153);
        }

        private void button22_Click(object sender, EventArgs e)
        {
          
            Bill.Clear();
            try
            {
                int CID = Convert.ToInt32(bcust_id.Text);
                string sql = "SELECT Customer_ID,Food_Items.Item_Name,Item_Price,Quantity FROM Food_Items JOIN Orders ON Food_Items.Item_ID = Orders.Item_ID WHERE Customer_ID = "+CID+"; ";
                SqlConnection con1;
                con1 = sqlObj.Get_Con();
                SqlCommand cmd = new SqlCommand(sql, con1);
                sqlObj.openDB();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int cid = Convert.ToInt32(rdr[0]);
                    string itname = rdr[1].ToString();
                    decimal itprice = Convert.ToDecimal(rdr[2]);
                    int itquant = Convert.ToInt32(rdr[3]);
                   Bill.Rows.Add(cid,itname,itprice,itquant);
                }
            }
            catch (Exception er)
            {

            }
            sqlObj.closeDB();
            data_bill.DataSource = Bill;
        }

        private void data_bill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void data_bill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var itprice = data_bill.Rows[e.RowIndex].Cells[2].Value;
            var itquant = data_bill.Rows[e.RowIndex].Cells[3].Value;

            it_price.Text = itprice.ToString();
            it_quant.Text = itquant.ToString();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                int itprice = Convert.ToInt32(it_price.Text);
                int iquant = Convert.ToInt32(it_quant.Text);

                getAmount = itprice * iquant;
                TotalBill += getAmount;
                textBox1.Text = TotalBill.ToString();
            }
            catch (Exception er) {

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox5.Text = bcust_id.Text;
            billTXT.Text="Rs. "+TotalBill+" /PKR";

        }

        private void button24_Click(object sender, EventArgs e)
        {
            data_bill.DataSource = orm.Read();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            try
            {

                int cid = Convert.ToInt32(bcust_id.Text);
                TotalBill = 0;
                orm.DeleteByCustomer(cid);
                rtm.DeleteByCustomer(cid);
                cm.Delete(cid);
                MessageBox.Show("Customer ID-"+cid+" Checked Out !");
            }
            catch (Exception err) {
                MessageBox.Show(err.Message.ToString());
            }
            clear();
        }
        private void clear()
        {
            bcust_id.Text = "";
            textBox5.Text = "";
            billTXT.Text = "";
            it_price.Text = "";
            it_quant.Text = "";
            textBox1.Text = "";
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 log = new Form1();
            log.ShowDialog();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            EditReservationDetails erd = new EditReservationDetails();
            erd.ShowDialog();
        }
    }
}

