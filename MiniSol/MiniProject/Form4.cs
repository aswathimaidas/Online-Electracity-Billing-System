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

    public partial class Form4 : Form
    {
        MySqlConnection connection;
        MySqlCommand cc;
        private string server;
        private string database;
        private string uid;
        private string password;
        public string electricalsection;
       private string billno;
        private string consumerno;
        private double amount;
        public Form4()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show(this);
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            electricalsection = comboBox1.Text;
            billno = textBox1.Text;
            consumerno = textBox2.Text;

              amount =double.Parse(textBox4.Text);

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
                MessageBox.Show("Connected...");
                //String create = "create table PaymentDetails(electricalsection varchar(30), billno , consumerno long, amount double) ";
                // cc = new MySqlCommand(create, connection);
                //cc.ExecuteNonQuery();


                if (!exp.IsMatch(billno))
                {
                    Error_Message += "\n INVALID BILL NUMBER ";
                    textBox1.Text = "";
                    errorProvider1.SetError(textBox1, "bill number required");
                    if (flag == 0)
                    {
                        textBox1.Focus();
                        flag = 1;
                    }
                }
                if (!exp.IsMatch(consumerno))
                {
                    Error_Message += "\n INVALID CONSUMER NUMBER ";
                    textBox2.Text = "";
                    errorProvider2.SetError(textBox2, "consumer number required");
                    if (flag == 0)
                    {
                        textBox2.Focus();
                        flag = 1;
                    }
                }

                if (Error_Message == "")
                {
                   

                            String insert = "insert into PaymentDetails(electricalsection,billno,consumerno,amount)values('" + electricalsection + "','" +billno+ "','" + consumerno + "','" + amount + "')";
                            cc = new MySqlCommand(insert, connection);
                            cc.ExecuteNonQuery();
                            MessageBox.Show("deatails entered successfully");
                           textBox1.Text = "";
                            textBox2.Text = "";
                       
                   
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
            /*Form7 f7 = new Form7();
            f7.Show();*/






        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox2.Text = Form2.getid;
           

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           


        }
   




    private void textBox2_TextChanged(object sender, EventArgs e)
    {


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

                string query = "select CONSUMER_ID,AMOUNT from Bill";
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
                    if (textBox2.Text == dt.Rows[num1][0].ToString())
                    {
                        textBox4.Text = dt.Rows[num1][1].ToString();
                    }
                    num1++;
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }



        }
    }
    }
