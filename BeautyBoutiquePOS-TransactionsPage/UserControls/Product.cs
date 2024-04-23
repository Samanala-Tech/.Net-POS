using BeautyBoutiquePOS_TransactionsPage.UserControls.SubControls;
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

namespace BeautyBoutiquePOS_TransactionsPage.UserControls
{
    public partial class Product : UserControl
    {
        public Product()
        {
            InitializeComponent();
            LoadProductData();
            CustomizeDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newProduct newProductForm = new newProduct(this);
            newProductForm.ShowDialog();   

        }

             public void LoadProductData()
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

                        dataGridViewProducts.DataSource = dataTable;
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
            dataGridViewProducts.BorderStyle = BorderStyle.None;
            dataGridViewProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridViewProducts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewProducts.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridViewProducts.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridViewProducts.BackgroundColor = Color.White;

            dataGridViewProducts.EnableHeadersVisualStyles = false;
            dataGridViewProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridViewProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewProducts.RowTemplate.Height = 40;
        }

    }
}
