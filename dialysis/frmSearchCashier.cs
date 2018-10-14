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
    public partial class frmSearchCashier : Form
    {
        MySqlConnection conn = new MySqlConnection("server = localhost; uid = root; pwd=;database= db_dialysis");
        public static string inventory_id = "";
        public static string inventory_name = "";
        public static string amount = "0.00";
        public static string consumable = "";
        public frmSearchCashier()
        {
            InitializeComponent();
        }

        private void frmSearchCashier_Load(object sender, EventArgs e)
        {
            conn.Open();
            String search = convertQuotes(frmCashier.search);
            String sql = "SELECT inventory_id AS id, inventory, price, is_consumable FROM tbl_inventory WHERE inventory LIKE '%" + search + "%' AND is_available = 1";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvInventory.DataSource = dt;
            conn.Close();
        }
        public string convertQuotes(string str)
        {
            return str.Replace("'", "''");
        }

        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dgvInventory.Rows[i];
                inventory_id = row.Cells[0].Value.ToString();
                inventory_name = row.Cells[1].Value.ToString();
                amount = row.Cells[2].Value.ToString();
                consumable = row.Cells[3].Value.ToString();
                this.Hide();
                frmCashier frm = new frmCashier();
                frm.btnFetch.PerformClick();
            }
        }
    }
}
