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
    public partial class frmSearchPatient : Form
    {
        MySqlConnection conn = new MySqlConnection("server = localhost; uid = root; pwd=;database= db_dialysis");
        public static String patient_id = "";
        public static String patient_name = "";
        public frmSearchPatient()
        {
            InitializeComponent();
        }

        private void frmSearchPatient_Load(object sender, EventArgs e)
        {
            conn.Open();
            String search = convertQuotes(frmSchedule.patient_name);
            String sql = "SELECT patient_id AS id, CONCAT(lastname,', ',firstname) AS name FROM tbl_patient WHERE (lastname LIKE '%"+search+"%' OR firstname LIKE '%"+search+"%') AND is_complete = 1 AND is_dead = 0";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvPatient.DataSource = dt;
            conn.Close();
        }
        public string convertQuotes(string str)
        {
            return str.Replace("'", "''");
        }

        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dgvPatient.Rows[i];
                patient_id = row.Cells[0].Value.ToString();
                patient_name = row.Cells[1].Value.ToString();
                this.Hide();
            }
        }
    }
}
