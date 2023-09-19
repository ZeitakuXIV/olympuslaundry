using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laundry
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter dataadapter;
        DataSet dataset;
        string sql;

        void koneksi()
        {
            sql = @"Data Source=DESKTOP-Dlan\SQLEXPRESS;Initial Catalog=db_laundry;integrated Security=true";
            connection = new SqlConnection(sql);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void print_Click(object sender, EventArgs e) { }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void tambahcucian_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {

        }
    }
}
