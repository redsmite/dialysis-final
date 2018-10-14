using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace dialysis
{
    public partial class frmCashier : Form
    {
        MySqlConnection conn = new MySqlConnection("server = localhost; uid = root; pwd=;database= db_dialysis");
        String payment_id = "1";
        String summary_id = "";
        public static String search = "";
        int inv_quantity = 0;
        public frmCashier()
        {
            InitializeComponent();
        }

        private void frmCashier_Load(object sender, EventArgs e)
        {
            conn.Open();
            String sql = "TRUNCATE tbl_summary";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            
            conn.Open();
            String sql2 = "SELECT payment_id, payment_method FROM tbl_payment";
            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
            MySqlDataReader dr = cmd2.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            cboPayment.DataSource = table;
            cboPayment.DisplayMember = "payment_method";
            cboPayment.ValueMember = "payment_id";
            conn.Close();
            refresh_dgv();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void cboPayment_DropDownClosed(object sender, EventArgs e)
        {
            payment_id = cboPayment.SelectedValue.ToString();
            gpbCashier.Enabled = true;
            cboPayment.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search = txtInventory.Text;
            frmSearchCashier frm = new frmSearchCashier();
            frm.Show();
            btnSearch.Enabled = false;
            btnFetch.Enabled = true;
            btnAdd.Enabled = false;
            txtQuantity.Enabled = false;
        }

        public void btnFetch_Click(object sender, EventArgs e)
        {
            conn.Open();
            String sql = "SELECT price FROM tbl_adjustment WHERE inventory_id = '"+frmSearchCashier.inventory_id+"' AND payment_id = '"+payment_id+"'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lblAmount.Text = dr.GetString(0);
                }
            }
            else {
                lblAmount.Text = frmSearchCashier.amount;
            }
            txtInventory.Text = frmSearchCashier.inventory_name;
            conn.Close();

            if (frmSearchCashier.consumable == "False")
            {
                lblSubtotal.Text = lblAmount.Text;
                txtQuantity.Text = "1";
                txtQuantity.Enabled = false;
            }
            else {
                txtQuantity.Enabled = true;
            }
            btnAdd.Enabled = true;
            btnSearch.Enabled = true;
            btnFetch.Enabled = false;
        }

        private void txtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            double dqty = 0;
            double damt = 0;
            double sub = 0;

            if(frmSearchCashier.inventory_id != "" && txtQuantity.Text != ""){
                dqty = Convert.ToDouble(txtQuantity.Text);
                damt = Convert.ToDouble(lblAmount.Text);
                sub = dqty * damt;
                lblSubtotal.Text = Convert.ToString(sub);
                btnAdd.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (frmSearchCashier.inventory_id != "" && txtQuantity.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Add", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (frmSearchCashier.consumable == "True")
                    {
                        conn.Open();
                        int quantity = 0;
                        String sql = "SELECT quantity FROM tbl_inventory WHERE inventory_id = '" + frmSearchCashier.inventory_id + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            inv_quantity = dr.GetInt32("quantity");
                        }
                        conn.Close();
                        quantity = Convert.ToInt32(txtQuantity.Text);
                        int subtract = inv_quantity - quantity;
                        if (subtract < 0)
                        {
                            MessageBox.Show("Out of stock \n Remaining stock: " + inv_quantity);
                        }
                        else
                        {
                            conn.Open();
                            String sql2 = "UPDATE tbl_inventory SET quantity = '" + subtract + "' WHERE inventory_id = '" + frmSearchCashier.inventory_id + "'";
                            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                            cmd2.ExecuteNonQuery();
                            conn.Close();

                            conn.Open();
                            String log = "Change quantity to " + subtract;
                            String sql3 = "INSERT INTO tbl_changelog (inventory_id, date_commit, log) VALUES ('" + frmSearchCashier.inventory_id + "',NOW(),'" + log + "')";
                            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
                            cmd3.ExecuteNonQuery();
                            conn.Close();
                            add_to_cart();
                            btnAdd.Enabled = false;
                        }
                    }
                    else
                    {
                        add_to_cart();
                        btnAdd.Enabled = false;
                    }
                }
            }
            else {
                MessageBox.Show("Please fill up all the necessary fields");
            }
        }
        private void add_to_cart() {
            conn.Open();
            String sql2 = "INSERT INTO tbl_summary (schedule_id, inventory_id, quantity, subtotal) VALUES ('" + frmSchedule.schedule_id + "','"+frmSearchCashier.inventory_id+"','"+txtQuantity.Text+"','" + lblSubtotal.Text + "')";
            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
            cmd2.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Add successful");
            frmSearchCashier.inventory_id = "";
            frmSearchCashier.inventory_name = "";
            frmSearchCashier.consumable = "";
            lblAmount.Text = "0.00";
            lblSubtotal.Text = "0.00";
            txtQuantity.Clear();
            txtInventory.Clear();
            refresh_dgv();
            btnCheckout.Enabled = true;
        }
        private void refresh_dgv() {
            dgvSummary.Refresh();
            conn.Open();
            String sql3 = "SELECT summary_id AS id, inventory, t1.quantity, subtotal FROM tbl_summary AS t1 LEFT JOIN tbl_inventory AS t2 ON t1.inventory_id = t2.inventory_id WHERE schedule_id = '" + frmSchedule.schedule_id + "'";
            MySqlDataAdapter da = new MySqlDataAdapter(sql3, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvSummary.DataSource = dt;
            conn.Close();
            conn.Open();
            String sql = "SELECT sum(subtotal) AS total FROM tbl_summary WHERE schedule_id = '"+frmSchedule.schedule_id+"' GROUP BY schedule_id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblTotal.Text = dr.GetString("total");
            }
            conn.Close();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (lblTotal.Text != "0.00")
            {
                String values = "";
                String schedule = "";
                String inventory = "";
                String quantity = "";
                String subtotal = "";
                conn.Close();
                conn.Open();
                String sql = "SELECT schedule_id, inventory_id, quantity, subtotal FROM tbl_summary WHERE schedule_id = '" + frmSchedule.schedule_id + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    schedule = dr.GetString("schedule_id");
                    inventory = dr.GetString("inventory_id");
                    quantity = dr.GetString("quantity");
                    subtotal = dr.GetString("subtotal");
                    values += "('" + schedule + "','" + inventory + "','" + quantity + "','" + subtotal + "','"+ payment_id +"', NOW()),";
                }
                values = values.TrimEnd(',');
                conn.Close();
                conn.Open();
                String sql3 = "INSERT INTO tbl_sales (schedule_id, inventory_id, quantity, subtotal, payment_id, datecommit) VALUES "+values+"";
                MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
                cmd3.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                String sql4 = "UPDATE tbl_schedule SET is_paid = 1 WHERE schedule_id = '"+schedule+"'";
                MySqlCommand cmd4 = new MySqlCommand(sql4, conn);
                cmd4.ExecuteNonQuery();
                conn.Close();
                refresh_dgv();
                MessageBox.Show("Payment successful");
                this.Hide();
            }
            else {
                MessageBox.Show("Empty table");
                conn.Close();
            }
        }

        private void dgvSummary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dgvSummary.Rows[i];
                summary_id = row.Cells[0].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("C:/Users/" + Environment.UserName + "/Desktop/" + txtInventory.Text + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf", FileMode.Create));
            doc.Open();

            //iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance("title.png");
            //doc.Add(PNG);
            Paragraph paragraph = new Paragraph("Official Receipt");
            Paragraph paragraph2 = new Paragraph("Date: " + DateTime.Now.ToString("MMMM dd, yyyy"));
            Paragraph paragraph3 = new Paragraph(System.Environment.NewLine);
            doc.Add(paragraph);
            doc.Add(paragraph2);
            doc.Add(paragraph3);
            /*
            List list = new List(List.UNORDERED);
            list.IndentationLeft = 30f;
            list.Add(new ListItem("One"));
            list.Add("Two");
            list.Add("Three");
            list.Add("Four");
            list.Add("Five");
            doc.Add(list);

            PdfPTable table = new PdfPTable(3);
            table.AddCell("Col 1 Row 1");
            table.AddCell("Col 2 Row 1");
            table.AddCell("Col 3 Row 1");
            table.AddCell("Col 1 Row 2");
            table.AddCell("Col 2 Row 2");
            table.AddCell("Col 3 Row 2");

            doc.Add(table);*/

            PdfPTable table = new PdfPTable(dgvSummary.Columns.Count);

            for (int j = 0; j < dgvSummary.Columns.Count; j++)
            {
                table.AddCell(new Phrase(dgvSummary.Columns[j].HeaderText));
            }
            table.HeaderRows = 1;

            for (int i = 0; i < dgvSummary.Rows.Count; i++)
            {
                for (int k = 0; k < dgvSummary.Columns.Count; k++)
                    if (dgvSummary[k, i].Value != null)
                    {
                        table.AddCell(new Phrase(dgvSummary[k, i].Value.ToString()));
                    }
            }
            doc.Add(table);
            doc.Close();
            MessageBox.Show("A pdf file is created \nLocation: C:/Users/" + Environment.UserName + "/Desktop ", "PDF created", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
