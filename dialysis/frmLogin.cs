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
    public partial class frmLogin : Form
    {
        public static String user_id = "";
        public static String username = "";
        public static String usertype = "";
        MySqlConnection conn = new MySqlConnection("server = localhost; uid = root; pwd=;database= db_dialysis");
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
        }

        private void txtLogin_Click(object sender, EventArgs e)
        {
            String user = convertQuotes(txtUsername.Text);
            String password = convertQuotes(txtPassword.Text);
            if(user != "" || password != ""){
            String sql = "SELECT user_id,username,usertype_id FROM tbl_user WHERE username ='" + user + "' AND password = md5('" + password + "')";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    MessageBox.Show("Welcome " + dr.GetString(1));
                    user_id = dr.GetString(0);
                    username = dr.GetString(1);
                    usertype = dr.GetString(2);
                    frmLanding frm = new frmLanding();
                    frm.Show();
                    this.Hide();
                }
                conn.Close();
            }
            else {
                MessageBox.Show("Invalid username and password"); 
                conn.Close();
            }
            conn.Close();
            }else{
                MessageBox.Show("Please enter username and password");
            }
        }
        public string convertQuotes(string str)
        {

            return str.Replace("'", "''");

        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLogin_Click(sender, e);
            }
        }
    }
}
