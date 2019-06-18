using ISD_LAB_PROJECT.Management_Class;
using System;
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

namespace ISD_LAB_PROJECT.User_Interfaces
{
 
    public partial class EditStudent : Form
    {
        SqlConnection con = new SqlConnection("Server=AMIN-TAHSEEN\\SQLEXPRESS;Database=ISD_LAB;User Id=sa;Password=ameen123;");
        SqlCommand cmd;
        StudentManagement sm = new StudentManagement();
        OpenFileDialog op = new OpenFileDialog();
        public EditStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string img = op.FileName;
            FileStream fs = new FileStream(img, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            int id = Convert.ToInt32(sid.Text);
            string name = sname.Text;
            string batch = sbatch.Text;
            string addr = saddr.Text;
            string pno = spno.Text;
            string fname = sfname.Text;
            Byte[] simg = br.ReadBytes((int)fs.Length);
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please Select Your Image !");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Are You Sure ?", "Update Record", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        sm.Update(id, name, batch, addr, pno, fname, simg);
                        MessageBox.Show("Updated !");
                        clear();
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message.ToString());
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            op.Filter = "Choose An Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (op.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(op.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           DialogResult dr = MessageBox.Show("Are You Sure ?", "Delete Record", MessageBoxButtons.YesNoCancel,
          MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                int id = Convert.ToInt32(sid.Text);
                try
                {
                    sm.Delete(id);
                    MessageBox.Show("Deleted !");
                    clear();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message.ToString());
                }
            }
            
        }
        private void clear()
        {
            sid.Text="";
            sname.Text="";
            sbatch.Text= "";
            saddr.Text= "";
            spno.Text= "";
            sfname.Text= "";
            pictureBox1.Image = Image.FromFile("C:/Users/LAPTOP POINT/Desktop/cars/img.png");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(sid.Text);
            try
            {
                string sql = "SELECT * FROM Student WHERE Student_ID="+id+";";
                con.Open();
                cmd = new SqlCommand(sql, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    sname.Text = rdr[1].ToString();
                    sbatch.Text = rdr[2].ToString();
                    saddr.Text = rdr[3].ToString();
                    spno.Text = rdr[4].ToString();
                    sfname.Text = rdr[5].ToString();
                    byte[] simg = (byte[])rdr[6];
                    MemoryStream memstr = new MemoryStream(simg);
                    pictureBox1.Image= Image.FromStream(memstr);
                }
                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message.ToString());
            }
        }
    }
}
