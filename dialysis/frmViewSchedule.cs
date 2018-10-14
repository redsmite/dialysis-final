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
    public partial class frmViewSchedule : Form
    {
        MySqlConnection conn = new MySqlConnection("server = localhost; uid = root; pwd=;database= db_dialysis");
        String schedule_id = "";
        public frmViewSchedule()
        {
            InitializeComponent();
        }

        private void frmViewSchedule_Load(object sender, EventArgs e)
        {
            conn.Open();
            DateTime today = DateTime.Today;
            String date = today.ToString("yyyy-MM-dd");
            String sql = "SELECT schedule_id AS id, CONCAT(lastname,', ',firstname) AS name, scheduled_date, scheduled_time, is_attended AS attended FROM tbl_schedule AS t1 LEFT JOIN tbl_patient AS t2 ON t1.patient_id = t2.patient_id WHERE scheduled_date = '" + date + "' AND scheduled_time = '"+cboTime.Text+"'";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvSchedule.DataSource = dt;
            conn.Close();
            cboTime.Text = "8am - 12pm";
        }
        public string convertQuotes(string str)
        {
            return str.Replace("'", "''");
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            conn.Open();
            DateTime datepick = dtpDate.Value.Date;
            String date = datepick.ToString("yyyy-MM-dd");
            String search = convertQuotes(txtSearch.Text);
            String sql = "SELECT schedule_id AS id, CONCAT(lastname,', ',firstname) AS name, scheduled_date, scheduled_time, is_attended AS attended FROM tbl_schedule AS t1 LEFT JOIN tbl_patient AS t2 ON t1.patient_id = t2.patient_id WHERE scheduled_date = '" + date + "' AND lastname LIKE '%" + search + "%' AND scheduled_time = '"+cboTime.Text+"'";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvSchedule.DataSource = dt;
            conn.Close();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            conn.Open();
            DateTime datepick = dtpDate.Value.Date;
            String date = datepick.ToString("yyyy-MM-dd");
            String search = convertQuotes(txtSearch.Text);
            String sql = "SELECT schedule_id AS id, CONCAT(lastname,', ',firstname) AS name, scheduled_date, scheduled_time, is_attended AS attended FROM tbl_schedule AS t1 LEFT JOIN tbl_patient AS t2 ON t1.patient_id = t2.patient_id WHERE scheduled_date = '" + date + "' AND lastname LIKE '%" + search + "%' AND scheduled_time = '" + cboTime.Text + "'";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvSchedule.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (schedule_id != "")
            {
                DialogResult dialogResult = MessageBox.Show("Is the schedule attended?", "Schedule", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    conn.Open();
                    String sql = "UPDATE tbl_schedule SET is_attended = 1 WHERE schedule_id = '" + schedule_id + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    dgvSchedule.Refresh();
                    frmViewSchedule_Load(sender, e);
                    MessageBox.Show("Update Successful");
                    btnAttend.Enabled = false;
                }
                else if (dialogResult == DialogResult.No)
                {
                    conn.Open();
                    String sql = "UPDATE tbl_schedule SET is_attended = 0 WHERE schedule_id = '" + schedule_id + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    dgvSchedule.Refresh();
                    frmViewSchedule_Load(sender, e);
                    MessageBox.Show("Update Successful");
                    btnAttend.Enabled = false;
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
                btnAttend.Enabled = true;
            }
        }

        private void cboTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            DateTime datepick = dtpDate.Value.Date;
            String date = datepick.ToString("yyyy-MM-dd");
            String search = convertQuotes(txtSearch.Text);
            String sql = "SELECT schedule_id AS id, CONCAT(lastname,', ',firstname) AS name, scheduled_date, scheduled_time, is_attended AS attended FROM tbl_schedule AS t1 LEFT JOIN tbl_patient AS t2 ON t1.patient_id = t2.patient_id WHERE scheduled_date = '" + date + "' AND lastname LIKE '%" + search + "%' AND scheduled_time = '" + cboTime.Text + "'";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvSchedule.DataSource = dt;
            conn.Close();
        }
    }
}
