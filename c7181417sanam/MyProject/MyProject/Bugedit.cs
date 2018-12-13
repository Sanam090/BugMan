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
    public partial class Bugedit : Form
    {
        String id = "";
        public Bugedit(String a,String b,String c,String d,String e,String f,String g)
        {
            InitializeComponent();
            textBox20.Text = b;
            textBox21.Text = c;
            textBox22.Text = d;
            textBox23.Text = e;
            textBox24.Text = f;
            textBox25.Text = g;
            id = a;


        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; database=user; username=root; password = "); //setting up a profile to establish connection between c# and mysql
            connection.Open();



            MemoryStream mm = new MemoryStream();                        //to convert the byte of variable
 
            byte[] bg = mm.ToArray();
            String qry = "UPDATE bug set Project =@textBox20,Author_Name=@textBox21,Code_Line=@textBox22,Method=@textBox23,Class=@textBox24,Source_File=@textBox25 where id=" + id;
           

            MySqlCommand cmd = new MySqlCommand(qry, connection);
            cmd.Parameters.AddWithValue("@textBox20", textBox20.Text);
            cmd.Parameters.AddWithValue("@textBox21", textBox21.Text);
            cmd.Parameters.AddWithValue("@textBox22", textBox22.Text);
            cmd.Parameters.AddWithValue("@textBox23", textBox23.Text);
            cmd.Parameters.AddWithValue("@textBox24", textBox24.Text);
            cmd.Parameters.AddWithValue("@textBox25", textBox25.Text);


            if (cmd.ExecuteNonQuery() == 1)                                 //executing the query either there is value or not
            {
                MessageBox.Show("inserted");
            }
            else
            {
                MessageBox.Show("not inserted");
            }
            
            connection.Close();
            this.Close();
        }
    }
}
