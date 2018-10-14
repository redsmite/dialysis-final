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
    public partial class frmSchedule : Form
    {
        MySqlConnection conn = new MySqlConnection("server = localhost; uid = root; pwd=;database= db_dialysis");
        public static String schedule_id = "";
        public static String patient_name = "";
        String attended = "";
        public frmSchedule()
        {
            InitializeComponent();
        }

        private void frmSchedule_Load(object sender, EventArgs e)
        {
            conn.Open();
            String sql = "SELECT schedule_id AS id, CONCAT(lastname,', ',firstname) AS name, scheduled_date, scheduled_time, is_attended AS attended FROM tbl_schedule AS t1 LEFT JOIN tbl_patient AS t2 ON t1.patient_id = t2.patient_id WHERE is_paid = 0 ORDER BY schedule_id DESC";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvSchedule.DataSource = dt;
            conn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {   
            String schedule = dtpSchedule.Value.Date.ToString("yyyy-MM-dd");
            String time = cboTime.Text;
            if (frmSearchPatient.patient_id == "" || time == ""){
                MessageBox.Show("Please select patient and schedule");
            }else{
                conn.Open();
                String sql = "INSERT INTO tbl_schedule (patient_id, scheduled_date, scheduled_time) VALUES ('" + frmSearchPatient.patient_id + "','" + schedule + "','" + time + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Add successful");
                button1_Click(sender, e);
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            String search = convertQuotes(txtSearch.Text);
            conn.Open();
            String sql = "SELECT schedule_id AS id, CONCAT(lastname,', ',firstname) AS name, scheduled_date, scheduled_time, is_attended AS attended FROM tbl_schedule AS t1 LEFT JOIN tbl_patient AS t2 ON t1.patient_id = t2.patient_id WHERE lastname LIKE '%" + search + "%' AND is_paid = 0 ORDER BY schedule_id DESC";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvSchedule.DataSource = dt;
            conn.Close();
        }
        public string convertQuotes(string str)
        {
            return str.Replace("'", "''");
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            patient_name = convertQuotes(txtPatient.Text);
            frmSearchPatient frm = new frmSearchPatient();
            frm.Show();
            btnFetch.Enabled = true;
            btnGo.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtPatient.Clear();
            frmSearchPatient.patient_id = "";
            frmSearchPatient.patient_name = "";
            attended = "";
            schedule_id = "";
            btnAttend.Enabled = false;
            btnPayment.Enabled = false;
            dgvSchedule.Refresh();
            frmSchedule_Load(sender, e);
            btnPayment.Enabled = false;
        }

        private void btnAttend_Click(object sender, EventArgs e)
        {
            if (schedule_id != "")
            {
                DialogResult dialogResult = MessageBox.Show("Is the schedule attended?", "Schedule", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    conn.Open();
                    String sql = "UPDATE tbl_schedule SET is_attended = 1 WHERE schedule_id = '"+schedule_id+"'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    button1_Click(sender, e);
                    MessageBox.Show("Update Successful");
                }
                else if (dialogResult == DialogResult.No)
                {
                    conn.Open();
                    String sql = "UPDATE tbl_schedule SET is_attended = 0 WHERE schedule_id = '" + schedule_id + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    dgvSchedule.Refresh();
                    frmSchedule_Load(sender, e);
                    MessageBox.Show("Update Successful");
                }
            }
            else {
                MessageBox.Show("Please select schedule");
            }
        }

        private void dgvSchedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dgvSchedule.Rows[i];
                schedule_id = row.Cells[0].Value.ToString();
                attended = row.Cells[4].Value.ToString();
                btnPayment.Enabled = true;
                btnAttend.Enabled = true;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            frmViewSchedule frm = new frmViewSchedule();
            frm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            txtPatient.Text = frmSearchPatient.patient_name;
            btnFetch.Enabled = false;
            btnGo.Enabled = true;
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (schedule_id != "")
            {
                if (attended == "True")
                {
                    frmCashier frm = new frmCashier();
                    frm.Show();
                    this.Hide();
                }
                else {
                    MessageBox.Show("This schedule is not attended");
                }
            }
            else {
                MessageBox.Show("Please select schedule");
            }
        }
    }
}
