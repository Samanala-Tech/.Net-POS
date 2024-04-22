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

    }
}
