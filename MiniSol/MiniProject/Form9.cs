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
    public partial class Form9 : Form
    {

        /*private MySqlConnection connection;
        private MySqlCommand cc;
        private string server;
        private string database;
        private string uid;
        private string password;

        private string accountholdername;
        private int accountno;
        public int valid;*/
        
        public Form9()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          /* accountholdername = textBox1.Text;
           accountno = int.Parse(textBox2.Text);
            
           int valid = int.Parse(dateTimePicker1.CustomFormat);
           dateTimePicker1.Format = DateTimePickerFormat.Custom;
             //Display the date as "Mon 27 Feb 2012".  
           dateTimePicker1.CustomFormat = "dd-MM-yy";


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
                String create = "create table banksbii(accountholdername varchar(30),accountno integer, valid date) ";
                 cc = new MySqlCommand(create, connection);
                cc.ExecuteNonQuery();

                String insert = "insert into banksbi(accountholdername,accountno,valid)values('" + accountholdername + "','" +accountno + "','" + valid + "')";
                cc = new MySqlCommand(insert, connection);
                cc.ExecuteNonQuery();

               string query = "INSERT INTO Rough (FIRSTNAME) VALUES('Amrita')";
                MySqlCommand cmdInsert = new MySqlCommand(query, connection);
                cmdInsert.ExecuteNonQuery();



                //Execute command
                // cmd.ExecuteNonQuery();

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

            }*/
         

        }

    

    private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Text = dateTimePicker1.Value.ToShortDateString();



           int valid = int.Parse(dateTimePicker1.CustomFormat);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            // Display the date as "Mon 27 Feb 2012".  
           dateTimePicker1.CustomFormat = "dd-MM-yy";

        }
    }
}

