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

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void print_Click(object sender, EventArgs e)
        {

        }
    }
}
