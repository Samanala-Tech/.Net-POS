using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeautyBoutiquePOS_TransactionsPage.UserControls.SubControls
{
    public partial class newCheckout : Form
    {
        public newCheckout()
        {
            InitializeComponent();
        }

        private void newCheckout_Load(object sender, EventArgs e)
        {
            List<string> items = new List<string> { "Item 1", "Item 2", "Item 3" };
            comboBox1.Items.AddRange(items.ToArray());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
