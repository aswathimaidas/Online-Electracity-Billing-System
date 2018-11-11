using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Globalization;

namespace MiniProject
{
    
   
    public partial class Form3 : Form
    {
        private MySqlConnection connection;
        private MySqlCommand cc;
        private string server;
        private string database;
        private string uid;
        private string password;

        private string usname;
        private string paswd;
        private string cpass;
        private string name;
        private string email;
        private string phno;
        private string addr;

        int id = 1000000000;
        
        public Form3()
        {
            InitializeComponent();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("logout");
            Form1 f1 = new Form1();
            f1.Show(this);
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hai");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            usname = textBox1.Text;
            paswd = textBox2.Text;
            cpass = textBox7.Text;
            name = textBox6.Text;
            phno = textBox4.Text;
            addr = textBox3.Text;
            email = textBox5.Text;
            String Error_Message = "";
            int flag = 0;
            Regex expr = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            Regex exp = new Regex(@"(?<!\d)\d{10}(?!\d)");
            server = "localhost";
            database = "ELECTRICITY";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + "; SslMode=none;";
            MessageBox.Show(connectionString);
            connection = new MySqlConnection(connectionString);




            try
            {
                connection.Open();
                //MessageBox.Show("Connected...");
                /*String create = "create table Register(CONSUMER_ID int PRIMARY KEY,USER_NAME varchar(30), PASS varchar(30),CONFIRM_PASSWORD varchar(20),  NAME varchar(50),PH_NO long, ADDRESS varchar(50),EMAIL varchar(20)) ";
                cc = new MySqlCommand(create, connection);
                cc.ExecuteNonQuery();*/

                if (textBox1.Text == "")
                {
                    Error_Message = " USERNAME REQUIRED..!! ";
                    flag = 1;
                    textBox1.Text = "";

                    textBox1.Focus();
                }

                if (textBox2.Text == "")
                {
                    Error_Message = " PASSWORD REQUIRED..!! ";
                    flag = 1;
                    textBox1.Text = "";
                    textBox2.Focus();
                }

                if (!exp.IsMatch(phno))
                {
                    Error_Message += "\n INVALID CONTACT NUMBER ";
                    textBox4.Text = "";
                    errorProvider1.SetError(textBox4, "contact number required");
                    if (flag == 0)
                    {
                        textBox4.Focus();
                        flag = 1;
                    }
                }

                if (!expr.IsMatch(email))
                {
                    Error_Message += "\n INVALID EMAIL ";
                    textBox5.Text = "";
                    errorProvider2.SetError(textBox5, "email id required");
                    if (flag == 0)
                    {
                        textBox5.Focus();
                        flag = 1;
                    }
                }
                if (paswd != cpass)
                {
                    Error_Message += "\n INCORRECT PASSWORD  ";
                    textBox7.Text = "";
                    errorProvider1.SetError(textBox7, "Password required");
                    if (flag == 0)
                    {
                        textBox7.Focus();
                        flag = 1;
                    }
                }
                if (Error_Message == "")
                {
                    String Select = "select CONSUMER_ID from Register";
                    cc = new MySqlCommand(Select, connection);
                    
                    
                    MySqlDataAdapter da = new MySqlDataAdapter(cc);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                                        
                    int rowcount = dt.Rows.Count;
                    int colcount = dt.Columns.Count;
                    int num1 = 0;
                    MessageBox.Show(rowcount.ToString());

                    if (num1 < rowcount)
                    {
                        int val = int.Parse(dt.Rows[rowcount - 1][0].ToString());
                        MessageBox.Show(val.ToString());

                        if (rowcount >=1 )
                        {
                           
                            String insert = "insert into Register(CONSUMER_ID,USER_NAME,PASS,CONFIRM_PASSWORD,NAME,PH_NO ,ADDRESS,EMAIL)values('" + (val + 1) + "','" + usname + "','" + paswd + "','" + cpass + "','" + name + "','" + phno + "','" + addr + "','" + email + "')";
                            cc = new MySqlCommand(insert, connection);
                            cc.ExecuteNonQuery();
                            MessageBox.Show("REGISTERED");

                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox7.Text = "";
                            textBox6.Text = "";
                            textBox4.Text = "";
                            textBox3.Text = "";
                            textBox5.Text = "";
                        }
                    }
                   
                }
                else
                    MessageBox.Show(Error_Message);
            

            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                MessageBox.Show(ex.ToString());

                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }

            }
           
               

            


        }

                    
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show(this);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}