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

namespace BeautyBoutiquePOS_TransactionsPage
{
    public partial class categories1 : Form
    {

        DataTable dataTable1;

        public categories1()
        {
            InitializeComponent();

            CustomizeDataGridView();
        }

        private void categories_Load(object sender, EventArgs e)
        {
            LoadDataToDataGridView();
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.HeaderText = "Edit";
            editButtonColumn.Text = "Edit";
            editButtonColumn.Name = "EditButton";
            editButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(editButtonColumn);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.HeaderText = "Delete";
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.Name = "DeleteButton";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(deleteButtonColumn);
        }


        public void LoadDataToDataGridView()
        {
            string connectionString = DatabaseConnection.GetConnectionString();

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                string sql = "select * from categories";
                MySqlCommand command = new MySqlCommand(sql, connection);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                    dataTable1 = dataTable;

                    dataGridView1.CellContentClick += dataGridView1_CellContentClick;
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object[] rowData = new object[2];
            newCategorie f2 = new newCategorie(rowData,"add");
            f2.Show();
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



      


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string filter = richTextBox1.Text;
            if (!string.IsNullOrEmpty(filter))
            {
                DataView dv = new DataView(dataTable1);
                dv.RowFilter = string.Format("name LIKE '%{0}%' OR description LIKE '%{0}%'", filter);
                dataGridView1.DataSource = dv;
            }
            else
            {
                dataGridView1.DataSource = dataTable1; // Reset to original data when filter is empty
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Check if the edit button is clicked
                if (e.ColumnIndex == dataGridView1.Columns["EditButton"].Index)
                {
                    // Print the index of the clicked row
                    Console.WriteLine("Edit button clicked for row index: " + e.RowIndex);
                    // Print the data of the clicked row
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    Console.WriteLine("Edit button clicked for row data:");
                    Console.WriteLine(row.Cells[0].Value);
                    Console.WriteLine(row.Cells[1].Value);
                    Console.WriteLine(row.Cells[2].Value);

                    object[] rowData = new object[3];

                    for (int i = 0; i < 3; i++)
                    {
                        rowData[i] = row.Cells[i].Value;
                    }

                    newCategorie f2 = new newCategorie(rowData,"edit");
                    f2.Show();
                }
                // Check if the delete button is clicked
                else if (e.ColumnIndex == dataGridView1.Columns["DeleteButton"].Index)
                {
                    // Print the index of the clicked row
                    Console.WriteLine("Delete button clicked for row index: " + e.RowIndex);
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    Console.WriteLine(row.Cells[0].Value);

                    object primaryKeyValue = dataGridView1.Rows[e.RowIndex].Cells["id"].Value;

                    if (primaryKeyValue != null && int.TryParse(primaryKeyValue.ToString(), out int primaryKeyInt))
                    {
                        DeleteRowFromDatabase(primaryKeyInt);

                        // Refresh DataGridView after deletion
                        LoadDataToDataGridView();
                    }
                    else
                    {
                        //MessageBox.Show("Invalid primary key value.");
                    }
                }
            }
        }

        private void DeleteRowFromDatabase(int primaryKeyValue)
        {
            string connectionString = DatabaseConnection.GetConnectionString();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Construct the DELETE SQL query using the primary key or unique identifier
                    string query = "DELETE FROM categories WHERE id = @PrimaryKeyValue";
                    // Replace YourTableName with the actual table name, and PrimaryKeyColumn with the actual primary key column name

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@PrimaryKeyValue", primaryKeyValue);

                    // Execute the DELETE query
                    cmd.ExecuteNonQuery();
                    LoadDataToDataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
