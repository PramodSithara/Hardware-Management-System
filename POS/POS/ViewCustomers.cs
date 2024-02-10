using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace POS
{
    public partial class ViewCustomers : Form
    {
        private string server = "localhost";
        private string uid = "root";
        private string password = "";
        private string database = "hardware";
        private DataTable dataTable;

        public ViewCustomers()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            MainMenu Obj = new MainMenu();
            Obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void ViewCustomers_Load(object sender, EventArgs e)
        {
            try
            {
                string conString = "server=" + server + ";uid=" + uid + ";pwd=" + password + ";database=" + database;
                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    con.Open();

                    string query = "SELECT * FROM customers";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        int Key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {/*
            if (dataGridView1.SelectedRows.Count > 0 && e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

                if (textBox1.Text == "")
                {
                    Key = 0;
                }
                else
                {
                    Key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                }
            }*/
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dataTable != null)
            {
                DataView dv = dataTable.DefaultView;
                dv.RowFilter = "name LIKE '%" + textBox1.Text + "%'";
                dataGridView1.DataSource = dv;
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


    }
}
