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
using BCrypt.Net;

namespace Laundry
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=DESKTOP-Dlan\\SQLEXPRESS;Initial Catalog=db_laundry;Integrated Security=True";

        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter dataadapter;
        DataSet dataset;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pass_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void login_Click(object sender, EventArgs e)
        {
            string namaPengguna = username.Text;
            string kataSandi = pass.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT password FROM Admin WHERE username = @username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", namaPengguna);

                string hashedPassword = (string)command.ExecuteScalar();

                if (hashedPassword != null && BCrypt.Net.BCrypt.Verify(kataSandi, hashedPassword))
                {
                    MessageBox.Show("Login berhasil!");
                    // Add code to grant access to your application here.
                }
                else
                {
                    MessageBox.Show("Login gagal. Coba lagi.");
                }
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

