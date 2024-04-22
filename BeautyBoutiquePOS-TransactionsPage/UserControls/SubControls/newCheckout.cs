using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeautyBoutiquePOS_TransactionsPage.UserControlls;
using BeautyBoutiquePOS_TransactionsPage.UserControls.SubControls.Payment;
using MySql.Data.MySqlClient;

namespace BeautyBoutiquePOS_TransactionsPage.UserControls.SubControls
{

    public partial class newCheckout : Form
    {

        private Checkout checkoutForm;
        private List<object[]> filteredData;
        private decimal sum;
        private decimal netGross;

        Cash cashForm1 = new Cash(0);
        Card cardForm1 = new Card(0);



        public newCheckout(Checkout checkoutForm, decimal sum)
        {

            
            InitializeComponent();

            this.checkoutForm = checkoutForm;

            this.checkoutForm = checkoutForm;
            this.sum = sum;

            netammountText.Text = sum.ToString();

            //dataGridView1.Columns.Add("TotalPriceColumn", "Total");
            //dataGridView1.Columns.Add("DiscountPriceColumn", "Discount");
            //dataGridView1.Columns.Add("Discount%Column", "Discount %");
            //dataGridView1.Columns.Add("SubTotalColumn", "Sub Total");

            CustomizeDataGridView();
        }



        private void newCheckout_Load(object sender, EventArgs e)
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


        private void CustomizeDataGridView()
        {

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

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.RowTemplate.Height = 40;


        }


       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Rounded(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;
            using (GraphicsPath GraphPath = new GraphicsPath())
            {
                Rectangle Rect = button.ClientRectangle;
                Rect.Width--;
                Rect.Height--;

                GraphPath.AddArc(Rect.X, Rect.Y, 50, 50, 180, 90);
                GraphPath.AddArc(Rect.X + Rect.Width - 50, Rect.Y, 50, 50, 270, 90);
                GraphPath.AddArc(Rect.X + Rect.Width - 50, Rect.Y + Rect.Height - 50, 50, 50, 0, 90);
                GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - 50, 50, 50, 90, 90);
                GraphPath.CloseFigure();

                button.Region = new Region(GraphPath);
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            product productForm = new product();
            productForm.ShowDialog();
        }

        private void cashBtn_CheckedChanged(object sender, EventArgs e)
        {
            Cash cashForm = new Cash(netGross); 
            cashForm.ShowDialog();
            this.cashForm1 = cashForm;
        }

        private void cardBtn_CheckedChanged(object sender, EventArgs e)
        {
            Card cardForm = new Card(netGross);
            cardForm.ShowDialog();
            this.cardForm1 = cardForm; 
        }

        public void RefreshDataGrid()
        {
            string query = "SELECT * FROM productsLine";
            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.GetConnectionString()))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }

            CalculateNetGrossAmount();
        }


        private void CalculateNetGrossAmount()
        {
            decimal netGrossAmount = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["total"].Value != null && decimal.TryParse(row.Cells["total"].Value.ToString(), out decimal totalPrice))
                {
                    netGrossAmount += totalPrice;
                }
            }

            netammountText.Text = netGrossAmount.ToString();

            netGross = netGrossAmount;
        }

        private void DeleteAllProductsLineData()
        {
            string query = "DELETE FROM productsLine";

            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.GetConnectionString()))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("All data from productsLine table deleted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No data found in productsLine table.");
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textGross.Text = this.cashForm1.balance.ToString();
            DeleteAllProductsLineData();             
        }
    }
}
