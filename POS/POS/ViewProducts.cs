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
    public partial class ViewProducts : Form
    {
        private string server = "localhost";
        private string uid = "root";
        private string password = "";
        private string database = "hardware";
        private DataTable dataTable;
 
        public ViewProducts()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            MainMenu Obj = new MainMenu();
            Obj.Show();
            this.Close();
        }
        
        private void ViewProducts_Load(object sender, EventArgs e)
        {
         
            try
            {
                string conString = "server=" + server + ";uid=" + uid + ";pwd=" + password + ";database=" + database;
                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    con.Open();

                    string query = "SELECT * FROM product";
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

   


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        int Key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            labelprint.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox1.SelectedItem = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

            if(textBox1.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conString = "server=" + server + ";uid=" + uid + ";pwd=" + password + ";database=" + database;
            MySqlCommand cmd;
            MySqlDataAdapter adapt;
            MySqlConnection con = new MySqlConnection(conString);

            if (textBox1.Text != "" && comboBox1.Text != "" && textBox4.Text != "" && textBox3.Text != "")
            {
                cmd = new MySqlCommand("update hardware.product set name=@name, category=@category, price=@price, quantity=@quan where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", labelprint.Text);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@category", comboBox1.Text);
                cmd.Parameters.AddWithValue("@price", textBox4.Text);
                cmd.Parameters.AddWithValue("@quan", textBox3.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Successfully Updated", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
               
            }
            else
            {
                MessageBox.Show("Select the record you want to Update", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string conString = "server=" + server + ";uid=" + uid + ";pwd=" + password + ";database=" + database;
            MySqlCommand cmd;
            MySqlDataAdapter adapt;
            MySqlConnection con = new MySqlConnection(conString);

            if (textBox1.Text != "" && comboBox1.Text != "" && textBox4.Text != "" && textBox3.Text != "")
            {
                cmd = new MySqlCommand("delete from hardware.product where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", labelprint.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Successfully Deleted", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Select the record you want to Delete", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
  
}
