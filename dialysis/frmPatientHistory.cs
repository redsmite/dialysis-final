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
    public partial class frmPatientHistory : Form
    {
        MySqlConnection conn = new MySqlConnection("server = localhost; uid = root; pwd=;database= db_dialysis");
        public static String schedule_id = "";
        public static String schedule = "";
        public static String total = "";
        public static String payment_method = "";
        public frmPatientHistory()
        {
            InitializeComponent();
        }

        private void frmPatientHistory_Load(object sender, EventArgs e)
        {
            lblName.Text = frmPatient.patient_name;
            conn.Open();
            String sql = "SELECT t1.schedule_id AS id,CONCAT(lastname,', ',firstname) AS name, scheduled_date, scheduled_time, is_attended AS attended, is_paid AS paid, SUM(t3.subtotal) AS total_paid, payment_method FROM tbl_schedule AS t1 LEFT JOIN tbl_patient AS t2 ON t1.patient_id = t2.patient_id LEFT JOIN tbl_sales AS t3 ON t1.schedule_id = t3.schedule_id LEFT JOIN tbl_payment AS t4 ON t3.payment_id = t4.payment_id  WHERE t1.patient_id = '" +frmPatient.patient_id+ "' GROUP BY t1.schedule_id ORDER BY t1.schedule_id DESC";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvHistory.DataSource = dt;
            conn.Close();
        }

        private void dgvHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dgvHistory.Rows[i];
                schedule_id = row.Cells[0].Value.ToString();
                schedule = row.Cells[2].Value.ToString();
                schedule = schedule.Replace("12:00:00 AM"," ");
                schedule += "("+ row.Cells[3].Value.ToString()+ ")";
                total = row.Cells[6].Value.ToString();
                payment_method = row.Cells[7].Value.ToString();
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if(schedule_id != ""){
                frmDetails frm = new frmDetails();
                frm.Show();
            }else{
                MessageBox.Show("Please select schedule");
            }
        }
    }
}
