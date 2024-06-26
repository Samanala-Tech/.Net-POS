﻿using MySql.Data.MySqlClient;
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

namespace BeautyBoutiquePOS_TransactionsPage.UserControls.SubControls
{
    public partial class newCategory : Form
    {
        private SqlConnection connection;
        private Categories Categories1;

        public newCategory(Categories categories)
        {
            this.Categories1 = categories;
            InitializeComponent();


            connection = new SqlConnection(DatabaseConnection.GetConnectionString());
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

            string categoryName = textBoxCategoryName.Text;
            string categoryDescription = textBoxCategoryDescription.Text;


            string query = "INSERT INTO categories (name, description) VALUES (@Name, @Description)";


            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.GetConnectionString()))
            {

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Name", categoryName);
                    command.Parameters.AddWithValue("@Description", categoryDescription);

                    try
                    {
                        connection.Open();


                        int rowsAffected = command.ExecuteNonQuery();


                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Category added successfully!");
                            this.Categories1.LoadCategories();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add category.");
                        }
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
