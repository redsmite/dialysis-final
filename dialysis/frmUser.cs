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
    public partial class frmUser : Form
    {
        String user_id = "";
        MySqlConnection conn = new MySqlConnection("server = localhost; uid = root; pwd=;database= db_dialysis");
        public frmUser()
        {
            InitializeComponent();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            conn.Open();
            String sql = "SELECT user_id AS id, lastname, firstname, username,usertype FROM tbl_user AS t1 LEFT JOIN tbl_usertype AS t2 ON t1.usertype_id = t2.usertype_id";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvUser.DataSource = dt;
            conn.Close();
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dgvUser.Rows[i];
                user_id = row.Cells[0].Value.ToString();
                txtUser.Text = row.Cells[3].Value.ToString();
                txtLast.Text = row.Cells[1].Value.ToString();
                txtFirst.Text = row.Cells[2].Value.ToString();
                btnUpdate.Enabled = true;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            String search = convertQuotes(txtSearch.Text);
            conn.Open();
            String sql = "SELECT user_id AS id, lastname, firstname, username,usertype FROM tbl_user AS t1 LEFT JOIN tbl_usertype AS t2 ON t1.usertype_id = t2.usertype_id WHERE lastname LIKE '%"+search+"%'";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvUser.DataSource = dt;
            conn.Close();
        }
        public string convertQuotes(string str)
        {

            return str.Replace("'", "''");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String user = convertQuotes(txtUser.Text);
            String last = convertQuotes(txtLast.Text);
            String first = convertQuotes(txtFirst.Text);
            if (user != "" && last != "" && first != "")
            {
                conn.Open();
                String sql2 = "SELECT user_id FROM tbl_user WHERE username = '"+user+"'";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                MySqlDataReader dr = cmd2.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("Username already exist");
                    conn.Close();
                }
                else {
                    conn.Close();
                    conn.Open();
                    String sql = "INSERT INTO tbl_user (username, password, lastname, firstname,usertype_id) VALUES ('" + user + "','md5(password)','" + last + "','" + first + "',2)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Add successful");
                    btnRefresh_Click(sender, e);
                }
                conn.Close();
            }
            else {
                MessageBox.Show("Please fill all the textboxes");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String user = convertQuotes(txtUser.Text);
            String last = convertQuotes(txtLast.Text);
            String first = convertQuotes(txtFirst.Text);
            if (user != "" && last != "" && first != "")
            {
                conn.Open();
                String sql2 = "SELECT user_id FROM tbl_user WHERE username = '" + user + "' AND user_id != '"+user_id+"'";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                MySqlDataReader dr = cmd2.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("Username already exist");
                    conn.Close();
                }
                else
                {
                    conn.Close();
                    conn.Open();
                    String sql = "UPDATE tbl_user SET username = '" + user + "', lastname = '" + last + "', firstname = '" + first + "' WHERE user_id = '" + user_id + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Update successful");
                    btnRefresh_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Please fill all the textboxes");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvUser.Refresh();
            frmUser_Load(sender, e);
            txtFirst.Clear();
            txtLast.Clear();
            txtUser.Clear();
            txtSearch.Clear();
            btnUpdate.Enabled = false;
            user_id = "";
        }
    }
}
