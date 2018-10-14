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
    public partial class frmInventory : Form
    {
        MySqlConnection conn = new MySqlConnection("server = localhost; uid = root; pwd=;database= db_dialysis");
        public static String inventory_id = "";
        public static String inventory_name = "";
        String quantity2 = "";
        String price2 = "";
        public frmInventory()
        {
            InitializeComponent();
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            conn.Open();
            String sql = "SELECT inventory_id AS id, inventory, category, quantity, price, description, is_consumable AS consumable, is_available AS available FROM tbl_inventory AS t1 LEFT JOIN tbl_category AS t2 ON t1.category_id = t2.category_id";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvInventory.DataSource = dt;
            conn.Close();

            conn.Open();
            String sql2 = "SELECT category_id, category FROM tbl_category";
            MySqlCommand cmd = new MySqlCommand(sql2, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            cboCategory.DataSource = table;
            cboCategory.DisplayMember = "category";
            cboCategory.ValueMember = "category_id";
            conn.Close();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
        public string convertQuotes(string str)
        {
            return str.Replace("'", "''");
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            String inventory = convertQuotes(txtSearch.Text);
            conn.Open();
            String sql = "SELECT inventory_id AS id, inventory, category, quantity, price, description, is_consumable AS consumable, is_available AS available FROM tbl_inventory AS t1 LEFT JOIN tbl_category AS t2 ON t1.category_id = t2.category_id WHERE inventory LIKE '%"+inventory+"%'";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvInventory.DataSource = dt;
            conn.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvInventory.Refresh();
            frmInventory_Load(sender, e);
            txtInventory.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();
            txtDesc.Clear();
            txtSearch.Clear();
            btnUpdate.Enabled = false;
            btnLog.Enabled = false;
            inventory_id = "";
            inventory_name = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (inventory_id != "")
            {
                String inventory = convertQuotes(txtInventory.Text);
                String category = cboCategory.SelectedValue.ToString();
                String quantity = txtQuantity.Text;
                String price = txtPrice.Text;
                String description = txtDesc.Text;
                String consumable = "";
                String available = "";
                if (chkConsume.Checked == true)
                {
                    consumable = "1";
                }
                else
                {
                    consumable = "0";
                }

                if (chkAvailable.Checked == true)
                {
                    available = "1";
                }
                else
                {
                    available = "0";
                }
                if (inventory != "" && quantity != "" && price != "" && description != "")
                {
                    conn.Open();
                    String sql = "SELECT inventory_id FROM tbl_inventory WHERE inventory = '"+inventory+"' AND inventory_id != '"+inventory_id+"'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        MessageBox.Show("This inventory already exists");
                        conn.Close();
                    }
                    else
                    {
                        conn.Close();
                        conn.Open();
                        String sql3 = "SELECT quantity, price FROM tbl_inventory WHERE inventory_id = '"+inventory_id+"'";
                        MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
                        MySqlDataReader dr3 = cmd3.ExecuteReader();
                        while (dr3.Read())
                        {
                            quantity2 = dr3.GetString("quantity");
                            price2 = dr3.GetString("price");
                        }

                        conn.Close();
                        conn.Open();
                        String sql2 = "UPDATE tbl_inventory SET inventory = '"+inventory+"', category_id = '"+category+"', quantity = '"+quantity+"', price = '"+price+"', description = '"+description+"', is_consumable = '"+consumable+"', is_available = '"+available+"' WHERE inventory_id = '"+inventory_id+"'";
                        MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                        cmd2.ExecuteNonQuery();
                        conn.Close();

                        if (quantity != quantity2) {
                            conn.Open();
                            String log = "Change quantity to " + quantity;
                            String sql4 = "INSERT INTO tbl_changelog (inventory_id, date_commit, log) VALUES ('" + inventory_id + "',NOW(),'" + log + "')";
                            MySqlCommand cmd4 = new MySqlCommand(sql4, conn);
                            cmd4.ExecuteNonQuery();
                            conn.Close();
                        }
                        if (price != price2){
                            conn.Open();
                            String log = "Change price to  " + price;
                            String sql5 = "INSERT INTO tbl_changelog (inventory_id, date_commit, log) VALUES ('" + inventory_id + "',NOW(),'" + log + "')";
                            MySqlCommand cmd5 = new MySqlCommand(sql5, conn);
                            cmd5.ExecuteNonQuery();
                            conn.Close();
                        }
                        btnRefresh_Click(sender, e);
                        MessageBox.Show("Update successful");
                    }
                }
                else {
                    MessageBox.Show("Please fill all the textboxes");
                }

            }
            else {
                MessageBox.Show("Please select inventory");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (inventory_id != "")
            {
                frmLog frm = new frmLog();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Please select inventory");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String inventory = convertQuotes(txtInventory.Text);
            String category = cboCategory.SelectedValue.ToString();
            String quantity = txtQuantity.Text;
            String price = txtPrice.Text;
            String description = txtDesc.Text;
            String consumable = "";
            String available = "";
            if (chkConsume.Checked == true)
            {
                consumable = "1";
            }
            else {
                consumable = "0";
            }

            if(chkAvailable.Checked == true){
                available = "1";
            }else{
                available = "0";
            }

            if(inventory != "" && quantity != "" && price != "" && description != ""){
                conn.Open();
                String sql = "SELECT inventory_id FROM tbl_inventory WHERE inventory = '"+inventory+"'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("This inventory already exists");
                    conn.Close();
                }
                else {
                     conn.Close();
                     conn.Open();
                     String sql2 = "INSERT INTO tbl_inventory (inventory, category_id, quantity, price, description, is_consumable, is_available) VALUES ('"+inventory+"','"+category+"','"+quantity+"','"+price+"','"+description+"','"+consumable+"','"+available+"')";
                     MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                     cmd2.ExecuteNonQuery();
                     conn.Close();

                     conn.Open();
                     String max_id = ""; 
                     String sql3 = "SELECT max(inventory_id) AS max_id FROM tbl_inventory";
                     MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
                     MySqlDataReader dr3 = cmd3.ExecuteReader();
                     while (dr3.Read())
                     {
                         max_id = dr3.GetString("max_id");
                     }
                     conn.Close();

                     conn.Open();
                     String log = "Add "+inventory;
                     String sql4 = "INSERT INTO tbl_changelog (inventory_id, date_commit, log) VALUES ('" + max_id + "',NOW(),'"+log+"')";
                     MySqlCommand cmd4 = new MySqlCommand(sql4, conn);
                     cmd4.ExecuteNonQuery();
                     conn.Close();
                     MessageBox.Show("Add successful");
                     btnRefresh_Click(sender, e);
                }
            }else{
                MessageBox.Show("Please fill all the textboxes");
            }
        }

        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dgvInventory.Rows[i];
                inventory_id = row.Cells[0].Value.ToString();
                inventory_name = row.Cells[1].Value.ToString();
                txtInventory.Text = row.Cells[1].Value.ToString();
                cboCategory.Text = row.Cells[2].Value.ToString();
                txtQuantity.Text = row.Cells[3].Value.ToString();
                txtPrice.Text = row.Cells[4].Value.ToString();
                txtDesc.Text = row.Cells[5].Value.ToString();
                String consumable = row.Cells[6].Value.ToString();
                String available = row.Cells[7].Value.ToString();
                if (consumable == "True")
                {
                    chkConsume.Checked = true;
                }
                else {
                    chkConsume.Checked = false;
                }
                if (available == "True")
                {
                    chkAvailable.Checked = true;
                }
                else
                {
                    chkAvailable.Checked = false;
                }
                btnUpdate.Enabled = true;
                btnLog.Enabled = true;
            }
        }
    }
}
