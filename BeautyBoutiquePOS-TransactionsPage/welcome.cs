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

namespace BeautyBoutiquePOS_TransactionsPage
{
    public partial class welcome : Form
    {
        public welcome()
        {
            InitializeComponent();


            loginBtn.Paint += Rounded;
            signupBtn.Paint += Rounded;



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
            signup signupForm = new signup();
            signupForm.Show();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            login loginFOrm = new login();
            loginFOrm.Show();
        }
    }
}
