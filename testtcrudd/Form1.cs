using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testtcrudd
{
    public partial class Form1 : Form
    {
        public Form1()

        {

            InitializeComponent();
            

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            SqlConnection connection = new SqlConnection("Server=DESKTOP-KHPHNGJ\\SQLEXPRESS; Database=register; Integrated Security = True; Encrypt=False");
            connection.Open();
            SqlCommand cmd = new SqlCommand("insert into [dbo].[Table] values (@Id,@Name,@Age)", connection);
            cmd.Parameters.AddWithValue("@Id",int.Parse(textBox1.Text));
             cmd.Parameters.AddWithValue("@Name",textBox2.Text);
             cmd.Parameters.AddWithValue("@Age",double.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            SqlCommand command = new SqlCommand("Select * From [dbo].[Table] ", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
           
            MessageBox.Show("Successfully Saved");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-KHPHNGJ\\SQLEXPRESS; Database=register; Integrated Security = True; Encrypt=False");
            connection.Open();
            SqlCommand cmd = new SqlCommand("Update [dbo].[Table] set Name=@Name, Age=@Age where Id=@Id  ", connection);
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Age", double.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            SqlCommand command = new SqlCommand("Select * From [dbo].[Table] ", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
            MessageBox.Show("Successfully Updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-KHPHNGJ\\SQLEXPRESS; Database=register; Integrated Security = True; Encrypt=False");
            connection.Open();
            SqlCommand cmd = new SqlCommand("Delete [dbo].[Table] where Id=@Id", connection);
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            SqlCommand command = new SqlCommand("Select * From [dbo].[Table] ", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
            MessageBox.Show("Successfully Deleted");
        }

     

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
