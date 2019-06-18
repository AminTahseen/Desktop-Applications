using BAL;
using DAL;
using ISD_Project.User_Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISD_Project
{
    public partial class Form1 : Form
    {
        LoginManagement lg = new LoginManagement();
        public Form1()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                password.UseSystemPasswordChar = false;
            }
            else
            {
                password.UseSystemPasswordChar = true;

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            username.Text = "";
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            password.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string usernme = username.Text;
            string pass = password.Text;
            if (adlog.Checked)
            {
               bool status= lg.Check_Authentication(usernme, pass);
                if (status)
                {
                    this.Hide();
                    adminPanel ap = new adminPanel();
                    ap.ShowDialog();
                   
                }
                else {
                    sysmsg.Text = "Incorrect Username Or Password";
                }
            }
            else if (serlog.Checked)
            {
                bool status = lg.Check_Authentication(usernme,pass);
                if (status)
                {
                    this.Hide();
                    main mn = new main();
                    mn.ShowDialog();
                   
                }
                else
                {
                    sysmsg.Text = "Incorrect Username Or Password";
                }
            }
            else {
                sysmsg.Text = "Oops Login Failed !";
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void adlog_CheckedChanged(object sender, EventArgs e)
        {
            if (adlog.Checked)
            {
                username.Text = "Admin Username";
            }
        
            
        }

        private void serlog_CheckedChanged(object sender, EventArgs e)
        {
            if (serlog.Checked)
            {
                username.Text = "Server Username";
            }
        }
    }
}
