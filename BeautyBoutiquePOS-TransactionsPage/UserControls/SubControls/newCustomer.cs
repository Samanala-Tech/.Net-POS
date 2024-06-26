﻿using MySql.Data.MySqlClient;
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
    public partial class newCustomer : Form
    {
        public Customers customersForm1;

        public newCustomer(Customers customersForm)
        {
            InitializeComponent();
            this.customersForm1 = customersForm;
        }

        private void newCustomer_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string nic = textBoxNIC.Text;
            string name = textBoxName.Text;
            double age = Convert.ToDouble(textBoxAge.Text);
            string address = textBoxAddress.Text;
            string contact = textBoxContact.Text;
            string email = textBoxEmail.Text;
            string career = textBoxCareer.Text;

            string query = "INSERT INTO customers (nic, name, age, address, contact, email, Career) VALUES (@NIC, @Name, @Age, @Address, @Contact, @Email, @Career)";

            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.GetConnectionString()))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NIC", nic);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Age", age);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Contact", contact);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Career", career);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer saved successfully.");    
                            customersForm1.LoadCustomers();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to save data.");
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

    }
}
