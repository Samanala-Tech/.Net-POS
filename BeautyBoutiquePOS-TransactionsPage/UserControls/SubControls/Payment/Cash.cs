﻿using BeautyBoutiquePOS_TransactionsPage.UserControlls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BeautyBoutiquePOS_TransactionsPage.UserControls.SubControls.Payment
{
    public partial class Cash : Form
    {

        public decimal Sum { get; private set; }
        public decimal balance = 0;
        public decimal ammount = 0;
        public Cash(decimal ammount)
        {
            InitializeComponent();

            lblRs.Text = ammount.ToString();
            this.ammount = ammount;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            text5000.Text = "";
            text1000.Text = "";
            text500.Text = "";
            text100.Text = "";
            text50.Text = "";
            text20.Text = "";


            label5000.Text = text5000.Text;
            label1000.Text = text1000.Text;
            label500.Text = text500.Text;
            label100.Text = text100.Text;
            label50.Text = text50.Text;
            label20.Text = text20.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label5000.Text = text5000.Text;
            label1000.Text = text1000.Text;
            label500.Text = text500.Text;
            label100.Text = text100.Text;
            label50.Text = text50.Text;
            label20.Text = text20.Text;

            decimal sum = 0;

            decimal value5000 = 0, value1000 = 0, value500 = 0, value100 = 0, value50 = 0, value20 = 0;

            if (!string.IsNullOrEmpty(text5000.Text) && decimal.TryParse(text5000.Text, out value5000))
            {
                sum += value5000 * 5000;
            }
            if (!string.IsNullOrEmpty(text1000.Text) && decimal.TryParse(text1000.Text, out value1000))
            {
                sum += value1000 * 1000;
            }
            if (!string.IsNullOrEmpty(text500.Text) && decimal.TryParse(text500.Text, out value500))
            {
                sum += value500 * 500;
            }
            if (!string.IsNullOrEmpty(text100.Text) && decimal.TryParse(text100.Text, out value100))
            {
                sum += value100 * 100;
            }
            if (!string.IsNullOrEmpty(text50.Text) && decimal.TryParse(text50.Text, out value50))
            {
                sum += value50 * 50;
            }
            if (!string.IsNullOrEmpty(text20.Text) && decimal.TryParse(text20.Text, out value20))
            {
                sum += value20 * 20;
            }

            if (sum == 0)
            {
                MessageBox.Show("No valid input found.");
            }
            else
            {
                balance = sum - ammount;
            }

            this.Close();
        }

    }
}
