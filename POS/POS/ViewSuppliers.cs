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
    public partial class ViewSuppliers : Form
    {
        private string server = "localhost";
        private string uid = "root";
        private string password = "";
        private string database = "hardware";
        private DataTable dataTable;

        public ViewSuppliers()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            MainMenu Obj = new MainMenu();
            Obj.Show();
            this.Hide();
        }

        private void ViewSuppliers_Load(object sender, EventArgs e)
        {
            try
            {
                string conString = "server=" + server + ";uid=" + uid + ";pwd=" + password + ";database=" + database;
                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    con.Open();

                    string query = "SELECT * FROM suppliers";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            // Create a DataTable to store the data
                            dataTable = new DataTable();

                            // Fill the DataTable with data from the database
                            adapter.Fill(dataTable);

                            // Set the DataTable as the DataSource for the DataGridView
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dataTable != null)
            {
                DataView dv = dataTable.DefaultView;
                dv.RowFilter = "Name LIKE '" + textBox1.Text + "%'";
                dataGridView1.DataSource = dv;
            }
        }
    }
}
