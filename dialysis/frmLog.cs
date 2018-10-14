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
    public partial class frmLog : Form
    {
        MySqlConnection conn = new MySqlConnection("server = localhost; uid = root; pwd=;database= db_dialysis");
        public frmLog()
        {
            InitializeComponent();
        }

        private void frmLog_Load(object sender, EventArgs e)
        {
            lblName.Text = frmInventory.inventory_name;
            conn.Open();
            String sql = "SELECT log, date_commit FROM tbl_changelog WHERE inventory_id = '"+frmInventory.inventory_id+"' ORDER BY log_id DESC";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvLog.DataSource = dt;
            conn.Close();
        }
    }
}
