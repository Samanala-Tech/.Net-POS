using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BeautyBoutiquePOS_TransactionsPage.UserControls.SubControls;
using MySql.Data.MySqlClient;

namespace BeautyBoutiquePOS_TransactionsPage.UserControlls
{
    public partial class Checkout : UserControl
    {
        public Checkout()
        {
            InitializeComponent();

            UpdateDataGridView();
        }

        public void UpdateDataGridView()
        {
            MessageBox.Show("OK");
            string query = "SELECT * FROM checkout";

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

                        checkoutGridView.DataSource = dataTable;
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
            newCheckout checkoutForm = new newCheckout(this);
            checkoutForm.ShowDialog();
        }
    }
}
