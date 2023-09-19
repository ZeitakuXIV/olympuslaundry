﻿using System;
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
        public Form2()
        {
            InitializeComponent();
        }

        

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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            paket = "Cuci Baju";
            harga = 15000;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            paket = "Cuci Baju & setrika";
            harga = 22000;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            paket = "Setrika";
            harga = 10000;
        }

        private void express1_CheckedChanged(object sender, EventArgs e)
        {
            express = true;
        }

        private void express2_CheckedChanged(object sender, EventArgs e)
        {
            express = false;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void submit_Click(object sender, EventArgs e)
        {
            // Assuming sql is your connection string
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-DLAN\SQLEXPRESS;Initial Catalog=db_laundry;integrated Security=true"))
            {
                // SQL query with parameterized values
                string query = "INSERT INTO Cucian (id, berat, mode, is_express, total_harga, is_done) VALUES (@Value1, @Value2, @mode, @is_express, @total, @is_done)";

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

        private void label5_Click_1(object sender, EventArgs e)
        {

        }
    }
}
