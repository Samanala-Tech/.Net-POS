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
            //comboBox1.Items.AddRange(customers.ToArray());


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


    }
}
