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
namespace MiniProject
{
    public partial class Form2 : Form
    {
        MySqlConnection connection;
        MySqlCommand cc;
        private string server;
        private string database;
        private string uid;
        private string password;
        public static string getid = "";
        //public static string getamnt = "";


        public Form2()
        {
            InitializeComponent();
        }

        /*private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show(textBox1, "Password required!");
            }
           
        }*/
        private void button1_Click(object sender, EventArgs e)
        {
            server = "localhost";
            database = "ELECTRICITY";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASS=" + password + ";SslMode=none;";
            //MessageBox.Show(connectionString);
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                String Select = "select USER_NAME,PASS,CONSUMER_ID from Register";
               
                //  String Select = "select USER_NAME,PASS,CONSUMER_ID from Register";
                // String query ="select CONSUMER_ID from Register";
                cc = new MySqlCommand(Select,connection);
                MySqlDataAdapter da = new MySqlDataAdapter(cc);
                DataTable dt = new DataTable();
                da.Fill(dt);
                int rowcount = dt.Rows.Count;
                int colcount= dt.Columns.Count;
                int num1= 0;
                



                while (num1 < rowcount)
                {
                    if (textBox2.Text == dt.Rows[num1][0].ToString() && textBox1.Text == dt.Rows[num1][1].ToString())
                    {
                        String SelectId = "SELECT CONSUMER_ID FROM REGISTER";

                        cc = new MySqlCommand(SelectId, connection);
                        da = new MySqlDataAdapter(cc);
                        dt = new DataTable();
                        da.Fill(dt);
                        getid = dt.Rows[num1][0].ToString();
                    


                   
                       
                        Form4 f4 = new Form4();
                        f4.Show();
                        this.Visible = false;
                    }

                   
                    
                   
                    num1++;

                }


            } 

            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }   
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show(this);
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "password required");
               
                textBox1.Text = "";

                textBox1.Focus();
            }
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}