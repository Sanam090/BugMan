using ICSharpCode.TextEditor.Document;
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
    /// <summary>
    /// calling method
    /// sql connection
    /// image upload
    /// </summary>
    public partial class board : Form
    {
        String id;                                 //Variabe declare
        public board(String id1)
        {
            InitializeComponent();
            string dirc = Application.StartupPath;
            FileSyntaxModeProvider fsmp;
            if (Directory.Exists(dirc))
            {

                fsmp = new FileSyntaxModeProvider(dirc);
                HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmp);
                textEditorControl1.SetHighlighting("C/C++");

            }


            get_bugitem();
            get_useritem();
            get_solutionitem();
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

            if (type.Equals("programer"))
            {
                // Removes all the tabs: tabControl1.TabPages.Clear(); 
                dash.TabPages.RemoveByKey("tabPage5");
                dash.TabPages.RemoveByKey("tabPage3");
                dash.TabPages.RemoveByKey("tabPage7");// Removes all the tabs: tabControl1.TabPages.Clear();
            }
            else if (type.Equals("Admin"))
            {
                dash.TabPages.RemoveByKey("tabPage2"); //removing solution
                dash.TabPages.RemoveByKey("tabPage3");
                dash.TabPages.RemoveByKey("tabPage6");
            }
            else
            {
                dash.TabPages.RemoveByKey("tabPage5");
                dash.TabPages.RemoveByKey("tabPage6"); //removing solution
            }
            connection.Close();


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
        /// <summary>
        /// sql connection
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

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



            }
            MessageBox.Show("data updated");
            board dj = new board(id);
            dj.Show();
            this.Hide();

            textBox5.Text = firstname;                                         //fill the value in the textbox
            textBox6.Text = lastname;
            textBox7.Text = type;
            textBox8.Text = email;
            textBox9.Text = password;

            //fill the value in the textbox



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
        /// <summary>
        /// sql connection
        /// data variables converting to byte
        /// image uploading
        /// data inserting
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

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



        /// <summary>
        /// opening file 
        /// choosing image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// sql connection
        /// storing data
        /// </summary>
        private void get_bugitem()
        {
            List<string> product_items = new List<string>();

            MySqlConnection connection = new MySqlConnection("server=localhost; database=user; username=root; password = "); //setting up a profile to establish connection between c# and mysql
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from bug";
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            MySqlDataReader reader = command.ExecuteReader();
            listView1.Items.Clear();
            while (reader.Read())
            {
                // product_items.Add(reader["Id"].ToString());
                ListViewItem plvi = new ListViewItem(reader["id"].ToString());
                plvi.SubItems.Add(reader["Project"].ToString());
                plvi.SubItems.Add(reader["Author_Name"].ToString());
                plvi.SubItems.Add(reader["Code_Line"].ToString());
                plvi.SubItems.Add(reader["Method"].ToString());
                plvi.SubItems.Add(reader["Class"].ToString());
                plvi.SubItems.Add(reader["Source_File"].ToString());

                listView1.Items.Add(plvi);
            }



        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListViewItem item = listView1.SelectedItems[0];
            //fill the text boxes

            Bugedit bg = new Bugedit(item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text, item.SubItems[4].Text, item.SubItems[5].Text, item.SubItems[6].Text);

            bg.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            get_bugitem();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void get_useritem()
        {
            List<string> product_items = new List<string>();

            MySqlConnection connection = new MySqlConnection("server=localhost; database=user; username=root; password = "); //setting up a profile to establish connection between c# and mysql
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from registration";
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            MySqlDataReader reader = command.ExecuteReader();
            listView3.Items.Clear();
            while (reader.Read())
            {
                // product_items.Add(reader["Id"].ToString());
                ListViewItem plvi = new ListViewItem(reader["id"].ToString());
                plvi.SubItems.Add(reader["First_Name"].ToString());
                plvi.SubItems.Add(reader["Last_Name"].ToString());
                plvi.SubItems.Add(reader["User_Type"].ToString());
                plvi.SubItems.Add(reader["Email"].ToString());
                plvi.SubItems.Add(reader["Password"].ToString());

                listView3.Items.Add(plvi);
            }
        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
            List<string> product_items = new List<string>();

            MySqlConnection connection = new MySqlConnection("server=localhost; database=user; username=root; password = "); //setting up a profile to establish connection between c# and mysql
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from bug where Project like '" + textBox1.Text + "%'";
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            MySqlDataReader reader = command.ExecuteReader();
            listView1.Items.Clear();
            while (reader.Read())
            {
                // product_items.Add(reader["Id"].ToString());
                ListViewItem plvi = new ListViewItem(reader["id"].ToString());
                plvi.SubItems.Add(reader["Project"].ToString());
                plvi.SubItems.Add(reader["Author_Name"].ToString());
                plvi.SubItems.Add(reader["Code_Line"].ToString());
                plvi.SubItems.Add(reader["Method"].ToString());
                plvi.SubItems.Add(reader["Class"].ToString());
                plvi.SubItems.Add(reader["Source_File"].ToString());

                listView1.Items.Add(plvi);
            }
        }

        private void textEditorControl1_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; database=user; username=root; password = "); //setting up a profile to establish connection between c# and mysql
            connection.Open();                                    //to open the connection between mysql and program

            String qry = "insert into Solution(Author_Name,Answer) values" +                //Insert the value from textbox to database
                "('"+textBox2.Text+"','"+textEditorControl1.Text+"')";
            MySqlCommand cmd = new MySqlCommand(qry, connection);
            try
            {
                if (cmd.ExecuteNonQuery() == 1)                            //executing the query either there is value or not
                {
                    MessageBox.Show("Succesfull saved");
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
                                                                  //to hide the recent form
           


        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void get_solutionitem()
        {
            List<string> product_items = new List<string>();

            MySqlConnection connection = new MySqlConnection("server=localhost; database=user; username=root; password = "); //setting up a profile to establish connection between c# and mysql
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from solution";
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            MySqlDataReader reader = command.ExecuteReader();
            listView4.Items.Clear();
            while (reader.Read())
            {
                // product_items.Add(reader["Id"].ToString());
                ListViewItem plvi = new ListViewItem(reader["id"].ToString());
                plvi.SubItems.Add(reader["Author_Name"].ToString());
                plvi.SubItems.Add(reader["Answer"].ToString());
               

                listView4.Items.Add(plvi);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            MessageBox.Show("Are you sure");
            f.Show();
                }
    }
    
}