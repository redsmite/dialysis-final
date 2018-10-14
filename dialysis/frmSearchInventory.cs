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
    public partial class frmSearchInventory : Form
    {
        MySqlConnection conn = new MySqlConnection("server = localhost; uid = root; pwd=;database= db_dialysis");
        public static String inventory_id = "";
        public static String inventory_name = "";
        public frmSearchInventory()
        {
            InitializeComponent();
        }

        private void frmSearchInventory_Load(object sender, EventArgs e)
        {
            conn.Open();
            String search = convertQuotes(frmAdjustment.search_inv);
            String sql = "SELECT inventory_id AS id, inventory FROM tbl_inventory WHERE inventory LIKE '%"+search+"%' AND is_available = 1";
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
                this.Hide();
            }
        }
    }
}
