using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;

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
        string sql = @"Data Source=DESKTOP-DLAN\SQLEXPRESS;Initial Catalog=db_laundry;integrated Security=true";
        public int CountRecordsWithCurrentDate()
        {
            using (SqlConnection connection = new SqlConnection(sql))
            {
                connection.Open();

                // Create the SQL query to count records with the current date in the DateColumn
                string countQuery = "SELECT COUNT(*) FROM Cucian WHERE CONVERT(date, tgl_masuk) = CONVERT(date, GETDATE())";

                using (SqlCommand countCommand = new SqlCommand(countQuery, connection))
                {
                    int totalCount = (int)countCommand.ExecuteScalar();
                    return totalCount;
                }
            }
        }
        public int CountUndoneRecords()
        {
            using (SqlConnection connection = new SqlConnection(sql))
            {
                connection.Open();

                // Create the SQL query to count records with is_done = false
                string countQuery = "SELECT COUNT(*) FROM Cucian WHERE is_done = 0";

                using (SqlCommand countCommand = new SqlCommand(countQuery, connection))
                {
                    int totalCount = (int)countCommand.ExecuteScalar();
                    return totalCount;
                }
            }
        }
        public int CountFinishRecordsWithCurrentDate()
        {
            using (SqlConnection connection = new SqlConnection(sql))
            {
                connection.Open();

                // Create the SQL query to count records with the current date in the DateColumn
                string countQuery = "SELECT COUNT(*) FROM Cucian WHERE CONVERT(date, tgl_selesai) = CONVERT(date, GETDATE())";

                using (SqlCommand countCommand = new SqlCommand(countQuery, connection))
                {
                    int totalCount = (int)countCommand.ExecuteScalar();
                    return totalCount;
                }
            }
        }
        public int SumHargaForTodayCompletedRecords()
        {
            using (SqlConnection connection = new SqlConnection(sql))
            {
                connection.Open();

                // Create the SQL query to sum the harga column for today's completed records
                string sumQuery = "SELECT SUM(total_harga) FROM Cucian WHERE is_done = 1 AND CONVERT(date, tgl_selesai) = CONVERT(date, GETDATE())";

                using (SqlCommand sumCommand = new SqlCommand(sumQuery, connection))
                {
                    object result = sumCommand.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                    return 0; // Return 0 if there are no matching records
                }
            }
        }

        public void GenerateReport(string filePathRaw)
        {
            string currentdate = DateTime.Today.ToString("yyyy-MM-dd");
            string filePath = $"{filePathRaw}-{currentdate}.pdf";
            // Connection string for your database
            string connectionString = sql;

            // SQL query to retrieve all data from your table
            string query = "SELECT * FROM Cucian WHERE is_done = 1";

            // Create a new document
            Document doc = new Document();
            MessageBox.Show(filePath);
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            // Add a title
            Paragraph title = new Paragraph("Laporan Laundry");
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);

            // Add a date
            Paragraph date = new Paragraph("Date: " + DateTime.Now.ToShortDateString());
            doc.Add(date);

            // Add a separator
            doc.Add(new Chunk("\n"));

            // Create a table for the report data
            PdfPTable table = new PdfPTable(7); // Adjust the number of columns as needed

            // Add column headers
            table.AddCell("ID");
            table.AddCell("Nama Customer");
            table.AddCell("Berat");
            table.AddCell("Mode");
            table.AddCell("Total Harga");
            table.AddCell("Tanggal Masuk");
            table.AddCell("Tanggal Selesai");

            // Retrieve data from the database and populate the PDF table
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        table.AddCell(reader["id"].ToString());
                        table.AddCell(reader["nama_customer"].ToString());
                        table.AddCell(reader["berat"].ToString());
                        table.AddCell(reader["mode"].ToString());
                        table.AddCell(reader["total_harga"].ToString());
                        table.AddCell(reader["tgl_masuk"].ToString());
                        table.AddCell(reader["tgl_selesai"].ToString());
                    }
                }
            }

            doc.Add(table);

            // Close the document
            doc.Close();
            // Open the PDF file with the default PDF viewer
            Process.Start(filePath);
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

        private void Form5_Load(object sender, EventArgs e) {
            label6.Text = CountRecordsWithCurrentDate().ToString();
            label7.Text = CountUndoneRecords().ToString();
            label8.Text = CountFinishRecordsWithCurrentDate().ToString();
            label9.Text = SumHargaForTodayCompletedRecords().ToString();
        }
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

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            GenerateReport(@"Reports\laundryreport");
        }
    }
}
