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
    public partial class SelectTable : Form
    {
        RestaurantTableManagement rtm = new RestaurantTableManagement();
        ReserveTableManagement rvtm = new ReserveTableManagement();
        public SelectTable()
        {
            InitializeComponent();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            table_grid.DataSource = rtm.Read();
        }

        private void table_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var table_id = table_grid.Rows[e.RowIndex].Cells[0].Value;
            tid.Text = table_id.ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int t_id = Convert.ToInt32(tid.Text);
            int c_id = Convert.ToInt32(cid.Text);
            try
            {
                rvtm.Create(c_id, t_id);
                ermsg.Text = "Table Reserved For Customer ID " + c_id+" !";
            }
            catch (Exception er) {
                ermsg.Text = er.Message.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
