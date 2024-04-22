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
    public partial class Customers : UserControl
    {
        public Customers()
        {
            InitializeComponent();
            LoadCustomers();
            CustomizeDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newCustomer customerForm = new newCustomer(this);
            customerForm.ShowDialog();
           
        }

        public void LoadCustomers()
        {
            string query = "SELECT * FROM customers";

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

                        customerGridView.DataSource = dataTable;
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
            customerGridView.BorderStyle = BorderStyle.None;
            customerGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            customerGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            customerGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            customerGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            customerGridView.BackgroundColor = Color.White;

            customerGridView.EnableHeadersVisualStyles = false;
            customerGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            customerGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            customerGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            customerGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            customerGridView.RowTemplate.Height = 40;
        }


    }
}
