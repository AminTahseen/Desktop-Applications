using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ISD_Project
{
    public partial class Add_Item : Form
    {
        OpenFileDialog op = new OpenFileDialog();
        FoodItemManagement fim = new FoodItemManagement();
        SQL sqlObj = new SQL();
        public Add_Item()
        {
            InitializeComponent();
            sqlObj.set_con_String("Server=AMIN-TAHSEEN\\SQLEXPRESS;Database=ISD;User Id=sa;Password=ameen123;");
            sqlObj.connect_DB();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            string Name = txtname.Text;
            int serve = Convert.ToInt32(txtServe.Text);
            decimal price = Convert.ToDecimal(txtprice.Text);
            string img = op.FileName;
            FileStream fs = new FileStream(img, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            Byte[] f_img = br.ReadBytes((int)fs.Length);
            
                fim.Create(Name, serve, price, f_img);
                lblMessage.Text="Item "+Name+" Has Been Added !";
                lblMessage.ForeColor = System.Drawing.Color.GreenYellow;
                
            }
            catch(Exception er)
            {
                lblMessage.Text = "Error "+er.Message.ToString();
                lblMessage.ForeColor = System.Drawing.Color.White;
            }
            clear();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            op.Filter = "Choose An Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (op.ShowDialog() == DialogResult.OK)
            {
                itemImage.Image = Image.FromFile(op.FileName);
                itemImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        public void clear() {
            txtname.Text = "";
            txtprice.Text = "";
            txtServe.Text = "";
           itemImage.Image = Image.FromFile("C:/Users/LAPTOP POINT/Desktop/cars/img.png");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtID.Text);
            string Name = txtname.Text;
            int serve = Convert.ToInt32(txtServe.Text);
            decimal price = Convert.ToDecimal(txtprice.Text);
            string img = op.FileName;
            FileStream fs = new FileStream(img, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            Byte[] f_img = br.ReadBytes((int)fs.Length);
            
                fim.Update(id, Name, serve, price, f_img);
                lblMessage.Text = "Item " + Name + " Has Been Updated !";
                lblMessage.ForeColor = System.Drawing.Color.GreenYellow;
            }
            catch (Exception er) {
                lblMessage.Text = "Error " + er.Message.ToString();
                lblMessage.ForeColor = System.Drawing.Color.White;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtID.Text;
                string sql = "SELECT Item_Name,Item_Serve,Item_Price,Item_Image FROM Food_Items WHERE Item_Name='" + name + "'";
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
                    txtname.Text = it_name;
                    txtServe.Text = it_serve.ToString();
                    txtprice.Text = it_price.ToString();
                    MemoryStream ms = new MemoryStream(it_img);
                    itemImage.Image = Image.FromStream(ms);
                }
            }
            catch (Exception er)
            {
           
            }
            sqlObj.closeDB();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string iname = txtname.Text;
                fim.DeleteByName(iname);
                lblMessage.Text = "Food Item Deleted !";
                lblMessage.ForeColor = System.Drawing.Color.GreenYellow;
            }
            catch (Exception er) {
                lblMessage.Text = er.Message.ToString();
                lblMessage.ForeColor = System.Drawing.Color.White;
            }
        }
    }
}
