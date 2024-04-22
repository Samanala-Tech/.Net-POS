using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeautyBoutiquePOS_TransactionsPage.UserControls.SubControls
{
    public partial class product : Form
    {
        DataTable dataTable1;
        DataView dataView1;

        public product()
        {
            InitializeComponent();

            UpdateDataGridView();
            CustomizeDataGridView();
        }


        public void UpdateDataGridView()
        {
            string query = "SELECT * FROM products";

            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.GetConnectionString()))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        DataTable dataTable = new DataTable();

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }

                        productGridView.DataSource = dataTable;
                        dataTable1 = dataTable;
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }

        }

        private void CustomizeDataGridView()
        {

            productGridView.BorderStyle = BorderStyle.None;
            productGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            productGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            productGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            productGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            productGridView.BackgroundColor = Color.White;

            productGridView.EnableHeadersVisualStyles = false;
            productGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            productGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            productGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            productGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            productGridView.RowTemplate.Height = 40;


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string filter = textProduct.Text;
            if (!string.IsNullOrEmpty(filter))
            {
                DataView dv = new DataView(dataTable1);
                dv.RowFilter = string.Format("name LIKE '%{0}%'", filter);
                productGridView.DataSource = dv;
                dataView1 = dv;
            }
            else
            {
                productGridView.DataSource = dataTable1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Filtered Results:");
            foreach (DataRowView rowView in dataView1)
            {
                DataRow row = rowView.Row;
                foreach (var item in row.ItemArray)
                {
                    Console.Write(item + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
