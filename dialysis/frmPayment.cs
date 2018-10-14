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
    public partial class frmPayment : Form
    {
        MySqlConnection conn = new MySqlConnection("server = localhost; uid = root; pwd=;database= db_dialysis");
        String payment_id = "";
        public frmPayment()
        {
            InitializeComponent();
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            conn.Open();
            String sql = "SELECT payment_id AS id, payment_method FROM tbl_payment";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvPayment.DataSource = dt;
            conn.Close();
        }

        private void dgvPayment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dgvPayment.Rows[i];
                payment_id = row.Cells[0].Value.ToString();
                txtPayment.Text = row.Cells[1].Value.ToString();
                btnUpdate.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String payment = convertQuotes(txtPayment.Text);
            if(payment != ""){
                conn.Open();
                String sql = "SELECT payment_id FROM tbl_payment WHERE payment_method = '"+payment+"'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("This payment method already exist");
                    conn.Close();
                }
                else {
                    conn.Close();
                    conn.Open();
                    String sql2 = "INSERT INTO tbl_payment (payment_method) VALUES ('"+payment+"')";
                    MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Add successful");
                    refresh(sender, e);
                }
            }else{
                MessageBox.Show("The textbox is empty");
            }
        }
        public string convertQuotes(string str)
        {
            return str.Replace("'", "''");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String payment = convertQuotes(txtPayment.Text);
            if (payment != "")
            {
                conn.Open();
                String sql = "SELECT payment_id FROM tbl_payment WHERE payment_method = '" + payment + "' AND payment_id != '"+payment_id+"'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("This payment method already exist");
                    conn.Close();
                }
                else
                {
                    conn.Close();
                    conn.Open();
                    String sql2 = "UPDATE tbl_payment SET payment_method = '"+payment+"' WHERE payment_id = '"+payment_id+"'";
                    MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Update successful");
                    refresh(sender, e);
                }
            }
            else
            {
                MessageBox.Show("The textbox is empty");
            }
        }
        private void refresh(object sender, EventArgs e) {
            txtPayment.Clear();
            dgvPayment.Refresh();
            frmPayment_Load(sender, e);
            payment_id = "";
            btnUpdate.Enabled = false;
        }
    }
}
