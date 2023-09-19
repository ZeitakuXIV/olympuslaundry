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
    public partial class Form3 : Form
    {

        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter dataadapter;
        SqlDataReader dr;
        DataSet dataset;

        string sql = @"Data Source=DESKTOP-DLAN\SQLEXPRESS;Initial Catalog=db_laundry;integrated Security=true";

        public Form3()
        {
            InitializeComponent();
            waiting();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public void waiting()
        {
            connection = new SqlConnection(sql);
            dataGridView1.Rows.Clear();
            command = new SqlCommand("SELECT * FROM Cucian where id like '%" + txtSearch.Text + "%'", connection);
            connection.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
