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

namespace BeautyBoutiquePOS_TransactionsPage
{
    public partial class newCategorie : Form
    {
        categories catForm = Application.OpenForms.OfType<categories>().FirstOrDefault();

        public newCategorie(object[] rowData,string method)
        {
            

            InitializeComponent();

            if (method == "edit")
            {
                idText.Text = rowData[0].ToString();
                nameText.Text = rowData[1].ToString();
                descText.Text = rowData[2].ToString();

                saveBtn.Text = "update";

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connectionString = DatabaseConnection.GetConnectionString();

            MySqlConnection connection = new MySqlConnection(connectionString);

            if (saveBtn.Text == "update")
            {
                string updateQuery = "UPDATE categories SET name = @Column1, description = @Column2 WHERE id = @PrimaryKeyValue";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
                    {
                        // Replace placeholders with actual column names and primary key value
                        cmd.Parameters.AddWithValue("@Column1", nameText.Text); // Assuming the first column is being updated
                        cmd.Parameters.AddWithValue("@Column2", descText.Text); // Assuming the second column is being updated
                        cmd.Parameters.AddWithValue("@PrimaryKeyValue", idText.Text); // Assuming the primary key value is known

                        connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        MessageBox.Show($"{rowsAffected} row(s) update successfully.");

                        
                        if (catForm != null)
                        {
                        catForm.LoadDataToDataGridView();
                        }
                            this.Close();
                        
                }
                
            } else
            {
                string id = idText.Text;
                string name = nameText.Text;
                string desc = descText.Text;
                try
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO categories (name, description) VALUES (@value1, @value2)";
                    MySqlCommand cmd = new MySqlCommand(insertQuery, connection);

                    cmd.Parameters.AddWithValue("@value1", name);
                    cmd.Parameters.AddWithValue("@value2", desc);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (catForm != null)
                    {
                        catForm.LoadDataToDataGridView();
                    }


                    MessageBox.Show($"{rowsAffected} row(s) inserted successfully.");

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Data inserted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("No rows were inserted.");
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {

            string connectionString = DatabaseConnection.GetConnectionString(); ;

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                // Open the connection
                connection.Open();

                // Connection successful, you can now execute SQL queries, etc.
                Console.WriteLine("Connected to MySQL database!");

                string sql = "select * from categories";
                MySqlCommand command = new MySqlCommand(sql, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader["Name"].ToString();
                        string description = reader["description"].ToString();
                        Console.WriteLine(name);
                        Console.WriteLine(description);
                    }
                }

                // Close the connection when done
                connection.Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
