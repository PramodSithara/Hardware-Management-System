﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace POS
{
    public partial class AddCustomers : Form
    {
        string server = "localhost";
        string uid = "root";
        string password = "";
        string database = "hardware";

        public AddCustomers()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conString = "server=" + server + ";uid=" + uid + ";pwd=" + password + ";database=" + database;
            MySqlConnection con = new MySqlConnection(conString);

            try
            {
                con.Open();

                string postdata = "INSERT INTO customers (name, address, phone) VALUES (@Name, @address, @phone)";

                MySqlCommand cmd = new MySqlCommand(postdata, con);
                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@address", textBox2.Text);
                cmd.Parameters.AddWithValue("@phone", textBox4.Text);

                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Successfully Added Customers.");
                }
                else
                {
                    MessageBox.Show("Failed to add Customers.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
        }

        private void AddCustomers_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
        }
    }
}
