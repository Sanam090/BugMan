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
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyProject
{
    /// <summary>
    /// 
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// sql connection
        /// data reading
        /// condition applied
        /// visibility to show the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button1_Click(object sender, EventArgs e)
        {
          
           
            MySqlConnection connection = new MySqlConnection("server=localhost; database=user; username=root; password = "); //setting up a profile to establish connection between c# and mysql
            connection.Open();
            MySqlCommand com = connection.CreateCommand();
            com.CommandText = "Select id,First_Name,Last_Name,User_Type,Email,Password from registration where Email= '" + textBox1.Text + "' and Password ='"+textBox2.Text + "' ";    //selecting the value from database
            MySqlDataReader reader = com.ExecuteReader();              //to read the value from database
            String id= "";
           
            String type = "";

            while (reader.Read())
            {
                type = reader["User_Type"].ToString();
                id = reader["id"].ToString();

            }
            if (type.Equals("Admin"))
            {
                board d = new board(id);
                d.Show();
                Visible = false;
            }
            else if (type.Equals("programer"))
            {
                board d = new board(id);
                d.Show();
                Visible = false;
            }
            else
            {
                board d = new board(id);
                d.Show();
                Visible = false;
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {


                IWebDriver driver = new ChromeDriver();
                // Launch the ToolsQA WebSite
                driver.Url = ("https://github.com/Sanam090/BugMan.git");

                // Type Name in the FirstName text box      
                //driver.FindElement(By.Name("firstname")).SendKeys("Lakshay");
                driver.FindElement(By.Id("login_field")).SendKeys("davidvilla.sanam@gmail.com");

                //Type LastName in the LastName text box
                driver.FindElement(By.Id("password")).SendKeys("asdfghjkl12345");

                // Click on the Submit button
                driver.FindElement(By.Name("commit")).Click();
            }
            catch (Exception ex)
            {

            }
            

        }
    }
}
