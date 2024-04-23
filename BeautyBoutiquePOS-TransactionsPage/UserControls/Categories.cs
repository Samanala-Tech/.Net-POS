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
    public partial class Categories : UserControl
    {
        public Categories()
        {
            InitializeComponent();
            CustomizeDataGridView();
            LoadCategories();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newCategory categoryForm = new newCategory(this);
            categoryForm.ShowDialog();
        }

        public void LoadCategories()
        {
            string query = "SELECT id, name, description FROM categories";


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


                        dataGridViewCategories.DataSource = dataTable;
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
            dataGridViewCategories.BorderStyle = BorderStyle.None;
            dataGridViewCategories.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridViewCategories.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCategories.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridViewCategories.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridViewCategories.BackgroundColor = Color.White;

            dataGridViewCategories.EnableHeadersVisualStyles = false;
            dataGridViewCategories.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCategories.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridViewCategories.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridViewCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewCategories.RowTemplate.Height = 40;
        }

    }
}
