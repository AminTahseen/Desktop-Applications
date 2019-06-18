using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
namespace ISD_Project.User_Interface
{
    public partial class AddTable : Form
    {
        RestaurantTableManagement rtm = new RestaurantTableManagement();
        public AddTable()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int noOfSeats = Convert.ToInt32(seats.Text);
                rtm.Create(noOfSeats);
                lbMessage.Text = "New Table Added To Restaurant !";
                clear();
            }
            catch (Exception ER) {
                lbMessage.Text = ER.Message.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                rtm.Delete(id);
                lbMessage.Text = "Table Removed !";
                clear();
            }
            catch (Exception ER)
            {
                lbMessage.Text = ER.Message.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          table_grid.DataSource=rtm.Read();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                int noOfSeats = Convert.ToInt32(seats.Text);
                rtm.Update(id,noOfSeats);
                lbMessage.Text = "Restaurant Table Updated !";
                clear();
            }
            catch (Exception ER)
            {
                lbMessage.Text = ER.Message.ToString();
            }
        }

        private void table_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var id=table_grid.Rows[e.RowIndex].Cells[0].Value;
            textBox1.Text = id.ToString();
        }

        private void clear() {
            textBox1.Text = "";
            seats.Text = "";
        }
    
    }
}
