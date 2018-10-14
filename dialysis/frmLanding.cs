using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dialysis
{
    public partial class frmLanding : Form
    {
        public frmLanding()
        {
            InitializeComponent();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin.user_id = "";
            frmLogin.username = "";
            frmLogin.usertype = "";
            frmLogin frm = new frmLogin();
            frm.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLanding_Load(object sender, EventArgs e)
        {
            if (frmLogin.usertype == "1") {
                manageUserToolStripMenuItem.Enabled = true;
                inventoryToolStripMenuItem.Enabled = true;
                salesToolStripMenuItem.Enabled = true;
            }
        }

        private void accountSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            frmSetting Form = new frmSetting();
            Form.MdiParent = this;
            Form.Show();
        }

        private void manageUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            frmUser Form = new frmUser();
            Form.MdiParent = this;
            Form.Show();
        }

        private void patientInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            frmPatient Form = new frmPatient();
            Form.MdiParent = this;
            Form.Show();
        }

        private void addScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            frmSchedule Form = new frmSchedule();
            Form.MdiParent = this;
            Form.Show();
        }

        private void viewScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            frmViewSchedule Form = new frmViewSchedule();
            Form.MdiParent = this;
            Form.Show();
        }

        private void itemCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            frmCategory Form = new frmCategory();
            Form.MdiParent = this;
            Form.Show();
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            frmInventory Form = new frmInventory();
            Form.MdiParent = this;
            Form.Show();
        }

        private void paymentMethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            frmPayment Form = new frmPayment();
            Form.MdiParent = this;
            Form.Show();
        }

        private void paymentAdjustmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            frmAdjustment Form = new frmAdjustment();
            Form.MdiParent = this;
            Form.Show();
        }

        private void dailyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            frmDailyReport Form = new frmDailyReport();
            Form.MdiParent = this;
            Form.Show();
        }

        private void dailySalesSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            frmDailySalesSummary Form = new frmDailySalesSummary();
            Form.MdiParent = this;
            Form.Show();
        }

        private void weeklySalesSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            frmWeekly Form = new frmWeekly();
            Form.MdiParent = this;
            Form.Show();
        }

        private void monthlySalesSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            frmMonthly Form = new frmMonthly();
            Form.MdiParent = this;
            Form.Show();
        }

        private void yearlySalesSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            frmYearly Form = new frmYearly();
            Form.MdiParent = this;
            Form.Show();
        }
    }
}
