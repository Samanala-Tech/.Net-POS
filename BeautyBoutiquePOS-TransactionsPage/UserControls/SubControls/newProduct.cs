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
    public partial class newProduct : Form
    {
        public Product productForm;

        public newProduct(Product product)
        {
            this.productForm = product;
            InitializeComponent();

            txtCategory.Items.AddRange(new string[] { "Electronics", "Clothing", "Books", "Beauty", "Home Decor" });

        }

        private void AddProductToDatabase()
        {

            string name = txtProductName.Text;
            string description = txtDescription.Text;
            double qty = 0;
            double discount = Convert.ToDouble(txtDiscount.Text);
            float price = float.Parse(txtPrice.Text);
            string category = txtCategory.SelectedItem.ToString();


            string query = "INSERT INTO products (name, description, qty, discount, price, category) VALUES (@Name, @Description, @Qty, @Discount, @Price, @Category)";

            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.GetConnectionString()))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Qty", qty);
                    command.Parameters.AddWithValue("@Discount", discount);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Category", category);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product added successfully.");
                            this.productForm.LoadProductData();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add product.");
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AddProductToDatabase();
        }
    }
}
