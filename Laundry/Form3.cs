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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }
        public void DeleteRecord()
        {
            using (SqlConnection connection = new SqlConnection(sql))
            {
                connection.Open();

                // Create the delete command to remove records based on ID
                string deleteQuery = "DELETE FROM Cucian WHERE id = @id";

                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                {
                    // Provide the ID parameter value
                    deleteCommand.Parameters.AddWithValue("@id", label6.Text);

                    // Execute the delete command
                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    // Check if any records were deleted
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data berhasil dihapus");
                    }
                    else
                    {
                        MessageBox.Show("Deletion failed. No rows were deleted.");
                    }
                }

                waiting(); // Refresh the data after deletion
            }
        }
        public void FlagRecordAsTrue()
        {
            using (SqlConnection connection = new SqlConnection(sql))
            {
                connection.Open();

                // Create the update command to set a column to true
                string updateQuery = "UPDATE Cucian SET is_done = 1, tgl_selesai = GETDATE() WHERE id = @id";

                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    // Provide the ID parameter value
                    updateCommand.Parameters.AddWithValue("@id", label6.Text);

                    // Execute the update command
                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    // Check if the update was successful
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data berhasil diupdate");
                    }
                    else
                    {
                        MessageBox.Show("Flagging failed. No rows were updated.");
                    }
                }
                waiting();
            }
        }
        public void waiting()
        {
            connection = new SqlConnection(sql);
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear(); // Clear existing columns
            command = new SqlCommand("SELECT * FROM Cucian where id like '%" + textBox1.Text + "%' AND is_done = 0", connection);
            connection.Open();
            dr = command.ExecuteReader();
            // Get the column names from the database
            DataTable schemaTable = dr.GetSchemaTable();
            foreach (DataRow row in schemaTable.Rows)
            {
                string columnName = row["ColumnName"].ToString();
                dataGridView1.Columns.Add(columnName, columnName); // Add columns to the DataGridView
            }

            while (dr.Read())
            {
                List<string> rowData = new List<string>();
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    rowData.Add(dr[i].ToString());
                }
                dataGridView1.Rows.Add(rowData.ToArray());
            }

            dr.Close();
            connection.Close();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            waiting();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            label6.Text = row.Cells[0].Value.ToString(); //id
            label10.Text = row.Cells[6].Value.ToString(); //nama
            label7.Text = row.Cells[2].Value.ToString(); //berat
            label8.Text = row.Cells[1].Value.ToString(); //express
            label9.Text = row.Cells[5].Value.ToString(); //mode
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FlagRecordAsTrue();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            waiting();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteRecord();
        }
    }
}
