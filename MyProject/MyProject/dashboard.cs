using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject
{
    public partial class dashboard : Form
    {
        String id;                                 //Variabe declare
        public dashboard(String id1)
        {
            InitializeComponent();
            MySqlConnection connection = new MySqlConnection("server=localhost; database=user; username=root; password = "); //setting up a profile to establish connection between c# and mysql
            connection.Open();                                     
            MySqlCommand com = connection.CreateCommand();
            com.CommandText = "Select id,First_Name,Last_Name,User_Type,Email,Password from registration where id= '" + id1 + "' ";
            MySqlDataReader reader = com.ExecuteReader();               //read the data in database
            String firstname = "";
            String lastname = "";
            String type = "";
            String email = "";
            String password = "";



            while (reader.Read())
            {
                id = reader["id"].ToString();                                //set the value of database 
                firstname = reader["First_Name"].ToString();
                lastname = reader["Last_Name"].ToString();
                type = reader["User_Type"].ToString();
                email = reader["Email"].ToString();
                password = reader["Password"].ToString();


            }
            label20.Text = firstname;                                         //fill the value in the textbox
            label21.Text = lastname;
            label22.Text = type;
            label23.Text = email;
            label24.Text = password;



        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;                            //to hide the button
            button2.Visible = true;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            label24.Visible = false;



        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; database=user; username=root; password = "); //setting up a profile to establish connection between c# and mysql
            connection.Open();                                                          //to open the connection 
            MySqlCommand com = connection.CreateCommand();

            com.CommandText = "UPDATE registration set First_Name = '" + textBox5.Text + "',Last_Name='" + textBox6.Text + "',User_Type='" + textBox7.Text + "',Email='" + textBox8.Text + "',Password='" + textBox9.Text + "'  WHERE id = '" + this.id + "'";           //update the value in databse
            MySqlDataReader reader = com.ExecuteReader();
            String firstname = "";
            String lastname = "";
            String type = "";
            String email = "";
            String password = "";
            while (reader.Read())
            {
                id = reader["id"].ToString();                         //set the value of database 
                firstname = reader["First_Name"].ToString();
                lastname = reader["Last_Name"].ToString();
                type = reader["User_Type"].ToString();
                email = reader["Email"].ToString();
                password = reader["Password"].ToString();
                MessageBox.Show("data updated");


            }
            label5.Text = firstname;                                         //fill the value in the textbox
            label6.Text = lastname;
            label7.Text = type;
            label8.Text = email;
            label9.Text = password;                                        //fill the value in the textbox



        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dashboard_Load(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; database=user; username=root; password = "); //setting up a profile to establish connection between c# and mysql
            connection.Open();



            MemoryStream mm = new MemoryStream();                        //to convert the byte of variable
            textBox26.Image.Save(mm, textBox26.Image.RawFormat);
            byte[] bg = mm.ToArray();
            String qry = "insert into bug(Project,Author_Name,Code_Line,Method,Class,Source_File,Image)"    //insert thye value in the databse
                + "values(@textBox20,@textBox21,@textBox22,@textBox23,@textBox24,@textBox25,@textBox26)";


            MySqlCommand cmd = new MySqlCommand(qry, connection);
            cmd.Parameters.AddWithValue("@textBox20", textBox20.Text);
            cmd.Parameters.AddWithValue("@textBox21", textBox21.Text);
            cmd.Parameters.AddWithValue("@textBox22", textBox22.Text);
            cmd.Parameters.AddWithValue("@textBox23", textBox23.Text);
            cmd.Parameters.AddWithValue("@textBox24", textBox24.Text);
            cmd.Parameters.AddWithValue("@textBox25", textBox25.Text);
            cmd.Parameters.AddWithValue("@textBox26", bg);


            if (cmd.ExecuteNonQuery() == 1)                                 //executing the query either there is value or not
            { 
                MessageBox.Show("inserted");
            }
            else
            {
                MessageBox.Show("not inserted");
            }
            connection.Close();                                                        //to close the mysql connection
        } 




        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();                        //open the file to upload image

                open.Filter = "Choose Image(*.jpg; *.png; *." + "gif)|*.jpg; *.png; *.gif";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    textBox26.Image = Image.FromFile(open.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox26_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
