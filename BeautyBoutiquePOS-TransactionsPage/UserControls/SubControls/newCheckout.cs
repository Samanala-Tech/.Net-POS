using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace BeautyBoutiquePOS_TransactionsPage.UserControls.SubControls
{

    public partial class newCheckout : Form
    {
        public newCheckout()
        {

            
            InitializeComponent();

            dataGridView1.Columns.Add("ProductNameColumn", "Product Name");
            dataGridView1.Columns.Add("QuantityColumn", "Quantity");
            dataGridView1.Columns.Add("TotalPriceColumn", "Total Price");
        }

        private void newCheckout_Load(object sender, EventArgs e)
        {
            LoadDataIntoComboBox(comboBox1, "customers", "name");
            LoadDataIntoComboBox(comboBox2, "products", "name");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadDataIntoComboBox(ComboBox comboBox, string tableName, string columnName)
        {
            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.GetConnectionString()))
            {
                string query = $"SELECT {columnName} FROM {tableName}";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {

                            comboBox.Items.Clear();

                            while (reader.Read())
                            {
                                comboBox.Items.Add(reader[columnName].ToString());
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string productName = comboBox2.SelectedItem.ToString();
            int quantity = Convert.ToInt32(txtQuantity.Text);

            decimal totalPrice = CalculateTotalPrice(productName, quantity);

            
            dataGridView1.Rows.Add(productName, quantity, totalPrice);

            CalculateTotalBalance();
        }

        private decimal CalculateTotalPrice(string productName, int quantity)
        {
            decimal price = 0;

            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.GetConnectionString()))
            {
                string query = $"SELECT price FROM products WHERE name = '{productName}'";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            price = Convert.ToDecimal(result);
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }

            return price * quantity;
        }

        private void CalculateTotalBalance()
        {
            decimal totalBalance = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Check if the cell value is not null and is convertible to decimal
                if (row.Cells["TotalPriceColumn"].Value != null && decimal.TryParse(row.Cells["TotalPriceColumn"].Value.ToString(), out decimal totalPrice))
                {
                    totalBalance += totalPrice;
                }
            }

            balanceText.Text = totalBalance.ToString();
        }

    }
}
