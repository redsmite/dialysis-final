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
    public partial class frmDetails : Form
    {
        MySqlConnection conn = new MySqlConnection("server = localhost; uid = root; pwd=;database= db_dialysis");
        public frmDetails()
        {
            InitializeComponent();
        }

        private void frmDetails_Load(object sender, EventArgs e)
        {
            lblName.Text = frmPatient.patient_name;
            lblSchedule.Text = frmPatientHistory.schedule;
            lblPayment.Text = frmPatientHistory.payment_method;
            lblTotal.Text = frmPatientHistory.total;

            conn.Open();
            String sql = "SELECT inventory, t1.quantity, subtotal FROM tbl_sales AS t1 LEFT JOIN tbl_inventory AS t2 ON t1.inventory_id = t2.inventory_id WHERE schedule_id = '"+frmPatientHistory.schedule_id+"' GROUP BY t1.inventory_id";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvDetails.DataSource = dt;
            conn.Close();
        }
    }
}
