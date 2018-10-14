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
    public partial class frmRequirements : Form
    {
        String clinic = "";
        String hemo = "";
        String lab = "";
        String xray = "";
        String hepa = "";
        String dia = "";
        MySqlConnection conn = new MySqlConnection("server = localhost; uid = root; pwd=;database= db_dialysis");
        public frmRequirements()
        {
            InitializeComponent();
        }

        private void frmRequirements_Load(object sender, EventArgs e)
        {
            lblPatient.Text = frmPatient.patient_name;
            conn.Open();
            String sql = "SELECT clinic_abstract, hemoglobin_order, latest_lab, latest_chest_xray, hepatitis_profile, dialysis_logsheet, storage_code FROM tbl_patient WHERE patient_id = '"+frmPatient.patient_id+"'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                clinic = dr.GetString("clinic_abstract");
                hemo = dr.GetString("hemoglobin_order");
                lab = dr.GetString("latest_lab");
                xray = dr.GetString("latest_chest_xray");
                hepa = dr.GetString("hepatitis_profile");
                dia = dr.GetString("dialysis_logsheet");
                txtStorage.Text = dr.GetString("storage_code");
                if (clinic == "True")
                {
                    chkClinic.Checked = true;
                }
                else {
                    chkClinic.Checked = false;
                }
                if (hemo == "True")
                {
                    chkHemo.Checked = true;
                }
                else {
                    chkHemo.Checked = false;
                }
                if (lab == "True")
                {
                    chkLab.Checked = true;
                }
                else {
                    chkLab.Checked = false;
                }
                if (xray == "True")
                {
                    chkXray.Checked = true;
                }
                else {
                    chkXray.Checked = false;
                }
                if (hepa == "True")
                {
                    chkHepa.Checked = true;
                }
                else {
                    chkHepa.Checked = false;
                }
                if (dia == "True")
                {
                    chkDia.Checked = true;
                }
                else {
                    chkDia.Checked = false;
                }
            }
            conn.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (chkClinic.Checked == true)
            {
                clinic = "1";
            }
            else {
                clinic = "0";
            }
            if (chkHemo.Checked == true)
            {
                hemo = "1";
            }
            else {
                hemo = "0";
            }
            if (chkLab.Checked == true)
            {
                lab = "1";
            }
            else {
                lab = "0";
            }
            if (chkXray.Checked == true)
            {
                xray = "1";
            }
            else {
                xray = "0";
            }
            if (chkHepa.Checked == true)
            {
                hepa = "1";
            }
            else {
                hepa = "0";
            }
            if (chkDia.Checked == true)
            {
                dia = "1";
            }
            else {
                dia = "0";
            }
            String storage = convertQuotes(txtStorage.Text);
            conn.Open();
            String sql = "UPDATE tbl_patient SET clinic_abstract = '"+clinic+"', hemoglobin_order = '"+hemo+"', latest_lab = '"+lab+"', latest_chest_xray = '"+xray+"', hepatitis_profile = '"+hepa+"', dialysis_logsheet = '"+dia+"', storage_code = '"+storage+"' WHERE patient_id = '"+frmPatient.patient_id+"'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            if (clinic == "1" && hemo == "1" && lab == "1" && xray == "1" && hepa == "1" && dia == "1" && storage != "")
            {
                conn.Open();
                String sql2 = "UPDATE tbl_patient SET is_complete = 1 WHERE patient_id = '" + frmPatient.patient_id + "'";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                cmd2.ExecuteNonQuery();
                conn.Close();
            }
            else {
                conn.Open();
                String sql2 = "UPDATE tbl_patient SET is_complete = 0 WHERE patient_id = '" + frmPatient.patient_id + "'";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                cmd2.ExecuteNonQuery();
                conn.Close();
            }
            MessageBox.Show("Update Successful");
            this.Hide();

        }
        public string convertQuotes(string str)
        {
            return str.Replace("'", "''");
        }
    }
}
