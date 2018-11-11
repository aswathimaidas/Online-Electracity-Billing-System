using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProject
{
   
    public partial class AdminLogin : Form
    {
        private string usname;
        private string paswd;
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // String Error_Message = "";
            usname = textBox1.Text;
            paswd = textBox2.Text;
            if (textBox1.Text =="admin" && textBox2.Text == "admin123")
            {
                AdminRegister ar = new AdminRegister();
                ar.Show(this);
                textBox1.Text = " ";
                textBox2.Text = " ";
            }
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("ERROR!!WRONG USERNAME OR PASSWORD");
            }
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "username required");
                //flag = 1;
                textBox1.Text = "";

                textBox1.Focus();
            }

            if (textBox2.Text == "")
            {
                errorProvider2.SetError(textBox2, "password required");
                //flag = 1;
                textBox1.Text = "";
                textBox2.Focus();
            }
        }
    }
}
