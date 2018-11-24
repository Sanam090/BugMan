using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
           
            MySqlConnection connection = new MySqlConnection("server=localhost; database=user; username=root; password = "); //setting up a profile to establish connection between c# and mysql
            connection.Open();
            MySqlCommand com = connection.CreateCommand();
            com.CommandText = "Select id,First_Name,Last_Name,User_Type,Email,Password from registration where Email= '" + textBox1.Text + "' and Password ='"+textBox2.Text + "' ";    //selecting the value from database
            MySqlDataReader reader = com.ExecuteReader();              //to read the value from database
            String id= "";
            String email = "";
            String password = "";
            while (reader.Read())
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                  

                }
                else if(textBox1.Text == "sanam" || textBox2.Text == "")
                {
                    email = reader["Email"].ToString();                //set the database value 
                    id = reader["id"].ToString();
                    password = reader["Password"].ToString();
                   
                    MessageBox.Show("Login Succesfull");
                    this.Hide();
                    dashboard bg = new dashboard(id);                  //object created of dashbaord class
                    bg.Show();                                              //show the next class
                }
            }
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();                         //hide the form onclick
            register rg = new register();          //create the object of register class
            rg.Show();                              //show the register class
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
