using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

namespace BeautyBoutiquePOS_TransactionsPage
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();

            
            btnLogin.Paint += Rounded;


            ApplyTextBoxStyles(textBox1);
            ApplyTextBoxStyles(textBox2);
                       
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


        private void ApplyTextBoxStyles(TextBox textBox)
        {

           

            // Define textbox's border color and width
            Color borderColor = Color.Gray;

            // Draw the textbox's border
            // Set background color
            textBox.BackColor = Color.LightGray;

            // Set border style
            textBox.BorderStyle = BorderStyle.FixedSingle;

            // Set font
            textBox.Font = new Font("Arial", 10, FontStyle.Bold);

            // Set text alignment
            textBox.TextAlign = HorizontalAlignment.Center;

            // Optionally, handle the Paint event to further customize appearance
            textBox.Paint += (sender, e) =>
            {
                // Draw custom border
                ControlPaint.DrawBorder(e.Graphics, textBox.ClientRectangle,
                                        Color.DarkGray, 1, ButtonBorderStyle.Solid,
                                        Color.DarkGray, 1, ButtonBorderStyle.Solid,
                                        Color.DarkGray, 1, ButtonBorderStyle.Solid,
                                        Color.DarkGray, 1, ButtonBorderStyle.Solid);
            };
        }

    }
}
