using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        DataTable dataTable1;
        public Checkout()
        {
            InitializeComponent();

            CustomizeDataGridView();
            RoundCorners(panel1, 10);



            UpdateDataGridView();

            button1.Paint += Rounded;
        }

        public void UpdateDataGridView()
        {
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
                        dataTable1 = dataTable;
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
            newCheckout checkoutForm = new newCheckout(this,0);
            checkoutForm.ShowDialog();
        }

        private void CustomizeDataGridView()
        {

            checkoutGridView.BorderStyle = BorderStyle.None;
            checkoutGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            checkoutGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            checkoutGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            checkoutGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            checkoutGridView.BackgroundColor = Color.White;

            checkoutGridView.EnableHeadersVisualStyles = false;
            checkoutGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            checkoutGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            checkoutGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            checkoutGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            checkoutGridView.RowTemplate.Height = 40;

            checkoutGridView.ReadOnly = true;


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string filter = richTextBox1.Text;
            if (!string.IsNullOrEmpty(filter))
            {
                DataView dv = new DataView(dataTable1);
                dv.RowFilter = string.Format("customer LIKE '%{0}%'", filter);
                checkoutGridView.DataSource = dv;
            }
            else
            {
                checkoutGridView.DataSource = dataTable1; 
            }
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

                private void RoundCorners(Control control, int cornerRadius)
                {
           
                    GraphicsPath path = new GraphicsPath();

                    int width = control.Width;
                    int height = control.Height;
                    int radius = cornerRadius;

                    Rectangle arcRectTopLeft = new Rectangle(0, 0, radius * 2, radius * 2);
                    Rectangle arcRectTopRight = new Rectangle(width - radius * 2, 0, radius * 2, radius * 2);
                    Rectangle arcRectBottomLeft = new Rectangle(0, height - radius * 2, radius * 2, radius * 2);
                    Rectangle arcRectBottomRight = new Rectangle(width - radius * 2, height - radius * 2, radius * 2, radius * 2);

                    path.AddArc(arcRectTopLeft, 180, 90);
                    path.AddArc(arcRectTopRight, 270, 90);
                    path.AddArc(arcRectBottomRight, 0, 90);
                    path.AddArc(arcRectBottomLeft, 90, 90);

                    path.CloseFigure();
                    control.Region = new Region(path);
                }
    }
}
