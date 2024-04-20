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

namespace BeautyBoutiquePOS_TransactionsPage.UserControlls
{
    public partial class Checkout : UserControl
    {
        public Checkout()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newCheckout checkout = new newCheckout();
            checkout.ShowDialog();
        }
    }
}
