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
    public partial class frmDailyDetails : Form
    {
        MySqlConnection conn = new MySqlConnection("server = localhost; uid = root; pwd=;database= db_dialysis");
        public frmDailyDetails()
        {
            InitializeComponent();
        }

        private void frmDailyDetails_Load(object sender, EventArgs e)
        {
            lblName.Text = frmDailyReport.patient_name;
            lblSchedule.Text = frmDailyReport.schedule;
            lblPayment.Text = frmDailyReport.payment_method;
            lblTotal.Text = frmDailyReport.total;

            conn.Open();
            String sql = "SELECT inventory, t1.quantity, subtotal FROM tbl_sales AS t1 LEFT JOIN tbl_inventory AS t2 ON t1.inventory_id = t2.inventory_id WHERE schedule_id = '" + frmDailyReport.schedule_id + "' GROUP BY t1.inventory_id";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvDetails.DataSource = dt;
            conn.Close();
        }
    }
}
