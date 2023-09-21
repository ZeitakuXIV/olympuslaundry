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

        private void label1_Click_1(object sender, EventArgs e)
        {
        
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e){}
        private void pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
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
            string kataSandi = password.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT password FROM Admin WHERE username = @username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", namaPengguna);

                string hashedPassword = (string)command.ExecuteScalar();

                if (hashedPassword != null && BCrypt.Net.BCrypt.Verify(kataSandi, hashedPassword))
                {
                    Form5 dashboard = new Form5();
                    dashboard.Show();
                    MessageBox.Show("Login berhasil!");
                    this.Hide();

                    // Add code to grant access to your application here.
                }
                else
                {
                    MessageBox.Show("Login gagal. Coba lagi.");
                }
            }
        }
        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void login_Click(object sender, EventArgs e)
        {
            
        }
        private bool IsValidLogin(string username, string password)
        {
            // Lakukan validasi login di sini, seperti memeriksa ke database atau sumber autentikasi lainnya
            // Jika login valid, kembalikan true, jika tidak, kembalikan false
            // Contoh sederhana:
            return (username == "admin" && password == "password");
        }

        private void reset_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void reset_Click_1(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}

