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

            CustomizeDataGridView();
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

        private void CustomizeDataGridView()
        {
            // Change DataGridView appearance
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Adjust column widths
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Adjust row heights
            dataGridView1.RowTemplate.Height = 40;


        }

    }
}
