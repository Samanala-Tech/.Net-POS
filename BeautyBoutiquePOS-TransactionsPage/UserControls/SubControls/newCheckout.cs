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
        }

        private void newCheckout_Load(object sender, EventArgs e)
        {
            List<string> customers = new List<string> { "Rajith", "Sanjaya", "Janith" };
            comboBox1.Items.AddRange(customers.ToArray());
                 
            MySqlConnection connection = new MySqlConnection(DatabaseConnection.GetConnectionString());

            try
                {
                    // Open the connection
                    connection.Open();
                    string query = "SELECT name FROM products";

                MySqlCommand command = new MySqlCommand(query, connection);

                // Create a MySqlDataReader object to read the data
                using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // Clear existing items in the ComboBox
                        comboBox2.Items.Clear();

                        // Read each row from the data reader
                        while (reader.Read())
                        {
                            // Add product name to the ComboBox
                            comboBox2.Items.Add(reader["name"].ToString());
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    // Handle any exceptions
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
