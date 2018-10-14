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
    public partial class frmCategory : Form
    {
        MySqlConnection conn = new MySqlConnection("server = localhost; uid = root; pwd=;database= db_dialysis");
        String category_id = "";
        public frmCategory()
        {
            InitializeComponent();
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            conn.Open();
            String sql = "SELECT category_id AS id, category FROM tbl_category";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvCategory.DataSource = dt;
            conn.Close();
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dgvCategory.Rows[i];
                category_id = row.Cells[0].Value.ToString();
                txtCategory.Text = row.Cells[1].Value.ToString();
                btnUpdate.Enabled = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (category_id != "")
            {
                conn.Open();
                String category = convertQuotes(txtCategory.Text);
                String sql2 = "SELECT category_id FROM tbl_category WHERE category = '" + category + "' AND category_id != '"+category_id+"'";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                MySqlDataReader dr = cmd2.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("This category already exist");
                    conn.Close();
                }
                else
                {
                    conn.Close();
                    conn.Open();
                    String sql = "UPDATE tbl_category SET category = '"+category+"' WHERE category_id = '"+category_id+"'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Update successful");
                    refresh(sender,e);
                }    
            }
            else {
                MessageBox.Show("Please select category");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String category = convertQuotes(txtCategory.Text);
            if(category != ""){
                conn.Open();
                String sql2 = "SELECT category_id FROM tbl_category WHERE category = '"+category+"'";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                MySqlDataReader dr = cmd2.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("This category already exist");
                    conn.Close();
                }else{
                    conn.Close();
                    conn.Open();
                    String sql = "INSERT INTO tbl_category (category) VALUES ('"+category+"')";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Add successful");
                    refresh(sender, e);
                }
            }else{
                MessageBox.Show("Textbox is empty");
            }      
        }
        public string convertQuotes(string str)
        {
            return str.Replace("'", "''");
        }

        private void refresh(object sender, EventArgs e)
        {
            dgvCategory.Refresh();
            frmCategory_Load(sender, e);
            category_id = "";
            btnUpdate.Enabled = false;
            txtCategory.Clear();
        }
    }
}
