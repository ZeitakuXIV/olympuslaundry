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
    public partial class Form2 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter dataadapter;
        DataSet dataset;
        string sql = @"Data Source=DESKTOP-DLAN\SQLEXPRESS;Initial Catalog=db_laundry;integrated Security=true"
            , paket;
        bool express;
        int harga;
        IdGenerator G = new IdGenerator();
        void koneksi()
        {
            connection = new SqlConnection(sql);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = G.idGenerator(sql, "Cucian", "C", "id");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            paket = "Cuci Baju & setrika";
            harga = 22000;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Assuming sql is your connection string
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-DLAN\SQLEXPRESS;Initial Catalog=db_laundry;integrated Security=true"))
            {
                // SQL query with parameterized values
                string query = "INSERT INTO Cucian (id, berat, mode, is_express, total_harga, is_done, nama_customer, tgl_masuk) VALUES (@Value1, @Value2, @mode, @is_express, @total, @is_done, @nama_customer, GETDATE())";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        // Add parameters with proper data types
                        command.Parameters.AddWithValue("@Value1", int.Parse(textBox1.Text));
                        command.Parameters.AddWithValue("@Value2", int.Parse(textBox2.Text));
                        command.Parameters.AddWithValue("@mode", paket); // Assuming paket is a string variable
                        command.Parameters.AddWithValue("@is_express", express); // Assuming express is a string variable
                        command.Parameters.AddWithValue("@total", int.Parse(textBox2.Text) * harga);
                        command.Parameters.AddWithValue("@is_done", false);
                        command.Parameters.AddWithValue("@nama_customer", textBox3.Text);


                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Data berhasil diinput");
                        this.Hide();
                        Form3 tampil = new Form3();
                        tampil.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                } // Dispose of the command
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            paket = "Cuci Baju";
            harga = 15000;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            paket = "Setrika";
            harga = 10000;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            express = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            express = true;
        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
