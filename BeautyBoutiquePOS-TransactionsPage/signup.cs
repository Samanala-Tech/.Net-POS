using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BeautyBoutiquePOS_TransactionsPage
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();

            signupBtn.Paint += Rounded;
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void signupBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
