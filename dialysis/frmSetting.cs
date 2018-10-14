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
    public partial class frmSetting : Form
    {
        MySqlConnection conn = new MySqlConnection("server = localhost; uid = root; pwd=;database= db_dialysis");
        public frmSetting()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String verify = convertQuotes(txtVerify.Text);
            String sql = "SELECT user_id FROM tbl_user WHERE  password = md5('" + verify + "') AND user_id = '"+frmLogin.user_id+"'";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    groupBox1.Enabled = true;
                    txtVerify.Enabled = false;
                    button2.Enabled = false;
                    txtUsername.Text = frmLogin.username;
                }
                conn.Close();
            }
            else {
                MessageBox.Show("Wrong Password");
            }
            conn.Close();
        }
        public string convertQuotes(string str)
        {

            return str.Replace("'", "''");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = convertQuotes(txtUsername.Text);
            String password = convertQuotes(txtPassword.Text);
            String confirm = convertQuotes(txtConfirm.Text);

            if (username != "" || password != "" || confirm != "")
            {
                if (password == confirm)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure?", "Account Setting", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        conn.Open();
                        String sql = "UPDATE tbl_user SET username = '" + username + "', password = md5('" + password + "') WHERE user_id = '" + frmLogin.user_id + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Update successful");
                        this.Hide();
                    }
                }
                else {
                    MessageBox.Show("Password doesn't match");
                }
            }
            else {
                MessageBox.Show("Please fill all the textbox");
            }
        }
    }
}
