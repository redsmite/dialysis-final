using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace dialysis
{
    public partial class frmAdjustment : Form
    {
        MySqlConnection conn = new MySqlConnection("server = localhost; uid = root; pwd=;database= db_dialysis");
        String adjustment_id = "";
        public static String search_inv = "";
        public frmAdjustment()
        {
            InitializeComponent();
        }

        private void frmAdjustment_Load(object sender, EventArgs e)
        {
            conn.Open();
            String sql = "SELECT adjust_id AS id, inventory, payment_method, t1.price, t2.price AS original_price FROM tbl_adjustment AS t1 LEFT JOIN tbl_inventory AS t2 ON t1.inventory_id = t2.inventory_id LEFT JOIN tbl_payment AS t3 ON t1.payment_id = t3.payment_id";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvAdjustment.DataSource = dt;
            conn.Close();

            conn.Open();
            String sql2 = "SELECT payment_id, payment_method FROM tbl_payment";
            MySqlCommand cmd = new MySqlCommand(sql2, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            cboPayment.DataSource = table;
            cboPayment.DisplayMember = "payment_method";
            cboPayment.ValueMember = "payment_id";
            conn.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void dgvAdjustment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dgvAdjustment.Rows[i];
                adjustment_id = row.Cells[0].Value.ToString();
                txtPrice.Text = row.Cells[3].Value.ToString();
                btnAdd.Enabled = false;
                txtInventory.Enabled = false;
                btnSearch.Enabled = false;
                btnFetch.Enabled = false;
                cboPayment.Enabled = false;
                btnUpdate.Enabled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search_inv = txtInventory.Text;
            frmSearchInventory frm = new frmSearchInventory();
            frm.Show();
            btnFetch.Enabled = true;
            btnSearch.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtInventory.Text = frmSearchInventory.inventory_name;
            btnFetch.Enabled = false;
            btnSearch.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String price = txtPrice.Text;
            if (adjustment_id != "")
            {
                if (price != "")
                {
                    conn.Open();
                    String sql = "UPDATE tbl_adjustment SET price = '"+price+"' WHERE adjust_id = '" + adjustment_id + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close(); 
                    button2_Click(sender, e);
                    MessageBox.Show("Update successful");
                }
                else {
                    MessageBox.Show("Fill up the price textbox");
                }
            }
            else {
                MessageBox.Show("Please select adjustment");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String payment = cboPayment.SelectedValue.ToString();
            String price = txtPrice.Text;
            String inventory = frmSearchInventory.inventory_id;
            if (inventory != "" && payment != "" && price != "")
            {
                conn.Open();
                String sql = "SELECT adjust_id FROM tbl_adjustment WHERE payment_id = '"+payment+"' AND inventory_id = '"+inventory+"'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("This adjustment already exist");
                    conn.Close();
                }
                else {
                    conn.Close();
                    conn.Open();
                    String sql2 = "INSERT INTO tbl_adjustment (inventory_id, payment_id, price) VALUES ('"+inventory+"','"+payment+"','"+price+"')";
                    MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    button2_Click(sender, e);
                    MessageBox.Show("Add successful");
                }
            }
            else {
                MessageBox.Show("Please fill all the fields");
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            String search = convertQuotes(txtSearch.Text);
            conn.Open();
            String sql = "SELECT adjust_id AS id, inventory, payment_method, t1.price, t2.price AS original_price FROM tbl_adjustment AS t1 LEFT JOIN tbl_inventory AS t2 ON t1.inventory_id = t2.inventory_id LEFT JOIN tbl_payment AS t3 ON t1.payment_id = t3.payment_id WHERE inventory LIKE '%" + search + "%'";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvAdjustment.DataSource = dt;
            conn.Close();
        }
        public string convertQuotes(string str)
        {
            return str.Replace("'", "''");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvAdjustment.Refresh();
            btnAdd.Enabled = true;
            txtInventory.Enabled = true;
            btnSearch.Enabled = true;
            btnFetch.Enabled = true;
            cboPayment.Enabled = true;
            btnUpdate.Enabled = false;
            dgvAdjustment.Refresh();
            txtInventory.Clear();
            txtPrice.Clear();
            txtSearch.Clear();
            frmSearchInventory.inventory_id = "";
            frmSearchInventory.inventory_name = "";
            adjustment_id = "";
            frmAdjustment_Load(sender, e);
        }
    }
}
