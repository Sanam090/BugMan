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

namespace MyProject

{
    /// <summary>
    /// 
    /// </summary>
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void register_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// sql connection
        /// method called
        /// hiding form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; database=user; username=root; password = "); //setting up a profile to establish connection between c# and mysql
            connection.Open();                                    //to open the connection between mysql and program
          
                String qry = "insert into registration(First_Name,Last_Name,User_Type,Email,Password) values" +                //Insert the value from textbox to database
                    "('" + textBox2.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "', '" + textBox5.Text + "')";
                MySqlCommand cmd = new MySqlCommand(qry, connection);                   
                try
                {
                    if (cmd.ExecuteNonQuery() == 1)                            //executing the query either there is value or not
                    {
                        MessageBox.Show("Succesfull! You can Login");
                    }
                    else
                    {
                        MessageBox.Show("not nserted");                    //dialoge box 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                connection.Close();                                            //close the connection
            this.Hide();                                                       //to hide the recent form
            Form1 fm = new Form1();                                            //make the object
            fm.Show();                                                         //to show the form of given class
            



            }
        
    }
}
