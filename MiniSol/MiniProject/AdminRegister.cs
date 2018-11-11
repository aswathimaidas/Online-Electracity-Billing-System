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
    public partial class AdminRegister : Form
    {
        // public static string SetValueForText1 = "";
        private MySqlConnection connection;
        private MySqlCommand cc;
        private string server;
        private string database;
        private string uid;
        private string password;
        public string Amount;
        public string consumer_id;
        public string consumer_name;
        public string unit;
        string user_name;


        // private static long val = 1000000000;

        //private string usname;
        // private string pass;

        // private string name;
        // private string email;
        // private string phno;
        // private string address;
        public AdminRegister()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void BillPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void AdminRegister_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            viewcustgrid vc = new viewcustgrid();
            vc.Show(this);
            server = "localhost";
            database = "ELECTRICITY";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + "; SslMode=none;";
            //MessageBox.Show(connectionString);
            connection = new MySqlConnection(connectionString);
            string query = "SELECT CONSUMER_ID,USER_NAME,PASS,NAME,PH_NO ,ADDRESS,EMAIL,STATUS from Register";
            
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    vc.dataGridView1.DataSource = ds.Tables[0];
                }
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            unit = textBox3.Text;
            consumer_id = textBox1.Text;
            consumer_name = textBox2.Text;
            Amount = textBox4.Text;

            // email = textBox5.Text;
            String Error_Message = "";
           // int flag = 0;
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
                // String create = "create table Bill(CONSUMER_ID int PRIMARY KEY,CONSUMER_NAME varchar(30), AMOUNT double)";
                //cc = new MySqlCommand(create, connection);
                //cc.ExecuteNonQuery();

                /* if (textBox1.Text == "")
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
                 }*/
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
                        int val = int.Parse(dt.Rows[rowcount-1][0].ToString());
                        MessageBox.Show(val.ToString());

                        if (rowcount >= 1)
                        {

                            String insert = "insert into Bill(CONSUMER_ID,CONSUMER_NAME,AMOUNT)values('" + consumer_id + "','" + consumer_name + "','" + Amount + "')";
                            cc = new MySqlCommand(insert, connection);
                            cc.ExecuteNonQuery();
                            MessageBox.Show("REGISTERED");

                            textBox1.Text = "";
                            textBox2.Text = "";
                            // textBox7.Text = "";
                            //textBox6.Text = "";
                            textBox4.Text = "";
                            textBox3.Text = "";
                            //textBox5.Text = "";
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

        private void button3_Click(object sender, EventArgs e)
        {
            server = "localhost";
            database = "ELECTRICITY";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + "; SslMode=none;";
            //MessageBox.Show(connectionString);
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "select CONSUMER_ID,NAME from Register";
                // where CONSUMER_ID'" + textBox1.Text + "'";
                MySqlCommand cc = new MySqlCommand(query, connection);
                MySqlDataAdapter md = new MySqlDataAdapter(cc);
                DataTable dt = new DataTable();
                md.Fill(dt);
                int rowcount = dt.Rows.Count;
                int colcount = dt.Columns.Count;
                int num1 = 0;

                while (num1 < rowcount)
                {
                    if (textBox1.Text == dt.Rows[num1][0].ToString())
                    {
                        textBox2.Text = dt.Rows[num1][1].ToString();
                    }
                    num1++;
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int units = int.Parse(textBox3.Text);
            double total_bill;
            if (units <= 50)

                total_bill = units * 2.5;

            else if (units <= 100)

                total_bill = units * 3;

            else if (units <= 200)

                total_bill = units * 3.5;

            else if (units <= 300)

                total_bill = units * 4;

            else if (units <= 400)

                total_bill = units * 4.5;

            else if (units <= 500)

                total_bill = units * 4.75;

            else total_bill = units * 5;
            textBox4.Text = total_bill.ToString();

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show(this);
        }


    


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
   
}

