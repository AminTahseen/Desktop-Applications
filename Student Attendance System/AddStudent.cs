using ISD_LAB_PROJECT.Management_Class;
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

namespace ISD_LAB_PROJECT.User_Interfaces
{
    public partial class AddStudent : Form
    {
        StudentManagement sm = new StudentManagement();
        OpenFileDialog op = new OpenFileDialog();

        public AddStudent()
        {
            InitializeComponent();
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
                string img = op.FileName;
                FileStream fs = new FileStream(img, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);

                string name = textBox1.Text;
                string batch = textBox2.Text;
                string addr = textBox3.Text;
                string pno = textBox4.Text;
                string fname = textBox5.Text;

                Byte[] simg = br.ReadBytes((int)fs.Length);
                try
                {
                    sm.Create(name, batch, addr, pno, fname, simg);
                    MessageBox.Show("Inserted !");
                valerror.Text = "-";
                    clear();
                }
                catch (Exception er)
                {
                    valerror.Text = er.Message.ToString();
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
        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            pictureBox1.Image = Image.FromFile("C:/Users/LAPTOP POINT/Desktop/cars/img.png");
        }
    }
}
