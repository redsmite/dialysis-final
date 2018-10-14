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
    public partial class frmDailySalesSummary : Form
    {
        MySqlConnection conn = new MySqlConnection("server = localhost; uid = root; pwd=;database= db_dialysis");
        public frmDailySalesSummary()
        {
            InitializeComponent();
        }

        private void frmDailySalesSummary_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            String date = today.ToString("yyyy-MM-dd");
            conn.Open();
            String sql = "SELECT payment_method, SUM(subtotal) AS total FROM tbl_sales AS t1 LEFT JOIN tbl_payment AS t2 ON t1.payment_id = t2.payment_id WHERE datecommit = '"+date+"' GROUP BY t1.payment_id";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvPayment.DataSource = dt;
            conn.Close();

            conn.Open();
            String sql2 = "SELECT inventory, SUM(t1.quantity) AS quantity, SUM(subtotal) AS total FROM tbl_sales AS t1 LEFT JOIN tbl_inventory AS t2 ON t1.inventory_id = t2.inventory_id WHERE datecommit = '" + date + "' GROUP BY t1.inventory_id";
            MySqlDataAdapter da2 = new MySqlDataAdapter(sql2, conn);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dgvInventory.DataSource = dt2;
            conn.Close();

            conn.Open();
            String sql3 = "SELECT sum(subtotal) AS total FROM tbl_sales WHERE datecommit = '"+date+"' GROUP BY datecommit";
            String total = "";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
            MySqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                total = dr3.GetString("total");
            }
            lblPaymentTotal.Text = total;
            lblInventoryTotal.Text = total;
            conn.Close();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime datepick = dtpDate.Value.Date;
            String date = datepick.ToString("yyyy-MM-dd");
            conn.Open();
            String sql = "SELECT payment_method, SUM(subtotal) AS total FROM tbl_sales AS t1 LEFT JOIN tbl_payment AS t2 ON t1.payment_id = t2.payment_id WHERE datecommit = '" + date + "' GROUP BY t1.payment_id";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvPayment.DataSource = dt;
            conn.Close();

            conn.Open();
            String sql2 = "SELECT inventory, SUM(t1.quantity) AS quantity, SUM(subtotal) AS total FROM tbl_sales AS t1 LEFT JOIN tbl_inventory AS t2 ON t1.inventory_id = t2.inventory_id WHERE datecommit = '" + date + "' GROUP BY t1.inventory_id";
            MySqlDataAdapter da2 = new MySqlDataAdapter(sql2, conn);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dgvInventory.DataSource = dt2;
            conn.Close();

            conn.Open();
            String sql3 = "SELECT sum(subtotal) AS total FROM tbl_sales WHERE datecommit = '" + date + "' GROUP BY datecommit";
            String total = "";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
            MySqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                total = dr3.GetString("total");
            }
            lblPaymentTotal.Text = total;
            lblInventoryTotal.Text = total;
            conn.Close();
        }
    }
}
