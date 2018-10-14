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
    public partial class frmPatient : Form
    {
        public static String patient_id = "";
        public static String patient_name = "";
        MySqlConnection conn = new MySqlConnection("server = localhost; uid = root; pwd=;database= db_dialysis");
        public frmPatient()
        {
            InitializeComponent();
        }

        private void frmPatient_Load(object sender, EventArgs e)
        {
            conn.Open();
            String sql = "SELECT patient_id AS id, lastname, firstname, gender, birthday, civil_status, religion, phone, contact, address, is_complete AS complete, is_dead AS dead FROM tbl_patient AS t1 LEFT JOIN tbl_gender AS t2 ON t1.gender_id = t2.gender_id LEFT JOIN tbl_civil_status AS t3 ON t1.civil_status_id = t3.civil_status_id ORDER BY patient_id DESC";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvPatient.DataSource = dt;
            conn.Close();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            String search = convertQuotes(txtSearch.Text);
            conn.Open();
            String sql = "SELECT patient_id AS id, lastname, firstname, gender, birthday, civil_status, religion, phone, contact, address, is_complete AS complete, is_dead AS dead FROM tbl_patient AS t1 LEFT JOIN tbl_gender AS t2 ON t1.gender_id = t2.gender_id LEFT JOIN tbl_civil_status AS t3 ON t1.civil_status_id = t3.civil_status_id WHERE lastname LIKE '%" + search + "%' ORDER BY patient_id DESC";
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String first = convertQuotes(txtFirst.Text);
            String last = convertQuotes(txtLast.Text);
            String gender = ""; 
            String birthday = dtpBirthdate.Value.Date.ToString("yyyy-MM-dd");
            String civil_status = cboCivilStatus.Text;
            String religion = convertQuotes(txtReligion.Text);
            String phone = txtPhone.Text;
            String contact = txtContact.Text;
            String address = convertQuotes(txtAddress.Text);

            if(rdoMale.Checked == true){
                gender = "1";
            }else if(rdoFemale.Checked == true){
                gender = "2";
            }

            if(civil_status == "Single"){
                civil_status = "1";
            }else if(civil_status == "Married"){
                civil_status = "2";
            }else if(civil_status == "Widowed"){
                civil_status = "3";
            }else if(civil_status == "Divorced"){
                civil_status = "4";
            }

            if (first != "" && last != "" && religion != "" && phone != "" && contact != "" && address != "")
            {
                conn.Open();
                String sql = "SELECT patient_id FROM tbl_patient WHERE lastname = '"+last+"' AND firstname = '"+first+"' AND birthday = '"+birthday+"'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("This patient already exists"); 
                    conn.Close();
                }
                else {
                    conn.Close();
                    conn.Open();
                    String sql2 = "INSERT INTO tbl_patient (lastname, firstname, gender_id, birthday, civil_status_id, religion, phone, contact, address) VALUES ('"+last+"','"+first+"','"+gender+"','"+birthday+"','"+civil_status+"','"+religion+"','"+phone+"','"+contact+"','"+address+"')";
                    MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Add Successful");
                    btnRefresh_Click(sender, e);
                 }
                conn.Close();
            }
            else {
                MessageBox.Show("Please fill all the fields");
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dgvPatient.Rows[i];
                patient_id = row.Cells[0].Value.ToString();
                txtLast.Text = row.Cells[1].Value.ToString();
                txtFirst.Text = row.Cells[2].Value.ToString();
                patient_name = row.Cells[1].Value.ToString() + ", " + row.Cells[2].Value.ToString(); ;
                if (row.Cells[3].Value.ToString() == "male") {
                    rdoMale.Checked = true;
                }else{
                    rdoFemale.Checked = true;
                }
                dtpBirthdate.Value = Convert.ToDateTime(row.Cells[4].Value);
                String civil_status = row.Cells[5].Value.ToString();
                if(civil_status == "single")
                {
                    cboCivilStatus.Text = "Single";

                }else if(civil_status == "married")
                {
                    cboCivilStatus.Text = "Married";

                }
                else if (civil_status == "widowed")
                {
                    cboCivilStatus.Text = "Widowed";

                }
                else if (civil_status == "divorced")
                {
                    cboCivilStatus.Text = "Divorced";
                }
                txtReligion.Text = row.Cells[6].Value.ToString();
                txtPhone.Text = row.Cells[7].Value.ToString();
                txtContact.Text = row.Cells[8].Value.ToString();
                txtAddress.Text = row.Cells[9].Value.ToString();
                btnUpdate.Enabled = true;
                btnReq.Enabled = true;
                btnHistory.Enabled = true;
                btnDead.Enabled = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String first = convertQuotes(txtFirst.Text);
            String last = convertQuotes(txtLast.Text);
            String gender = "";
            String birthday = dtpBirthdate.Value.Date.ToString("yyyy-MM-dd");
            String civil_status = cboCivilStatus.Text;
            String religion = convertQuotes(txtReligion.Text);
            String phone = txtPhone.Text;
            String contact = txtContact.Text;
            String address = convertQuotes(txtAddress.Text);

            if (rdoMale.Checked == true)
            {
                gender = "1";
            }
            else if (rdoFemale.Checked == true)
            {
                gender = "2";
            }

            if (civil_status == "Single")
            {
                civil_status = "1";
            }
            else if (civil_status == "Married")
            {
                civil_status = "2";
            }
            else if (civil_status == "Widowed")
            {
                civil_status = "3";
            }
            else if (civil_status == "Divorced")
            {
                civil_status = "4";
            }

            if (first != "" && last != "" && religion != "" && phone != "" && contact != "" && address != "")
            {
                conn.Open();
                String sql = "SELECT patient_id FROM tbl_patient WHERE lastname = '" + last + "' AND firstname = '" + first + "' AND birthday = '" + birthday + "' AND patient_id != '" + patient_id + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("This patient already exists");
                    conn.Close();
                }
                else
                {
                    conn.Close();
                    conn.Open();
                    String sql2 = "UPDATE tbl_patient SET lastname = '"+last+"', firstname = '"+first+"', gender_id = '"+gender+"', birthday = '"+birthday+"', civil_status_id = '"+civil_status+"', religion = '"+religion+"', phone = '"+phone+"', contact = '"+contact+"', address = '"+address+"' WHERE patient_id = '"+patient_id+"'";
                    MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Update Successful");
                    btnRefresh_Click(sender,e);
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("Please fill all the fields");
            }
        }

        private void btnReq_Click(object sender, EventArgs e)
        {
            if (patient_id == "")
            {
                MessageBox.Show("Please select patient");
            }
            else {
                frmRequirements frm = new frmRequirements();
                frm.Show();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvPatient.Refresh();
            frmPatient_Load(sender, e);
            txtLast.Clear();
            txtFirst.Clear();
            txtReligion.Clear();
            txtPhone.Clear();
            txtContact.Clear();
            txtAddress.Clear();
            txtSearch.Clear();
            patient_id = "";
            btnReq.Enabled = false;
            btnUpdate.Enabled = false;
            btnHistory.Enabled = false;
            btnDead.Enabled = false;
        }

        private void btnDead_Click(object sender, EventArgs e)
        {
            if(patient_id != ""){
                 DialogResult dialogResult = MessageBox.Show("Is this patient dead?", "Update", MessageBoxButtons.YesNo);
                 if (dialogResult == DialogResult.Yes)
                 {
                    conn.Open();
                    String sql = "UPDATE tbl_patient SET is_dead = 1 WHERE patient_id = '" + patient_id + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Update Successful");
                    frmPatient_Load(sender, e);
                 }
                 else {
                     conn.Open();
                     String sql = "UPDATE tbl_patient SET is_dead = 0 WHERE patient_id = '" + patient_id + "'";
                     MySqlCommand cmd = new MySqlCommand(sql, conn);
                     cmd.ExecuteNonQuery();
                     conn.Close();
                     MessageBox.Show("Update Successful");
                     frmPatient_Load(sender, e);
                 }
         
            }else{
                MessageBox.Show("Please select patient");
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (patient_id != "")
            {
                frmPatientHistory frm = new frmPatientHistory();
                frm.Show();
            }
            else {
                MessageBox.Show("Please select schedule");
            }
        }
    }
}
