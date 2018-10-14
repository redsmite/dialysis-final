namespace dialysis
{
    partial class frmLanding
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentMethodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentAdjustmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailySalesSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weeklySalesSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlySalesSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yearlySalesSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.patientToolStripMenuItem,
            this.scheduleToolStripMenuItem,
            this.inventoryToolStripMenuItem,
            this.salesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1062, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountSettingToolStripMenuItem,
            this.manageUserToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // accountSettingToolStripMenuItem
            // 
            this.accountSettingToolStripMenuItem.Name = "accountSettingToolStripMenuItem";
            this.accountSettingToolStripMenuItem.Size = new System.Drawing.Size(183, 24);
            this.accountSettingToolStripMenuItem.Text = "Account Setting";
            this.accountSettingToolStripMenuItem.Click += new System.EventHandler(this.accountSettingToolStripMenuItem_Click);
            // 
            // manageUserToolStripMenuItem
            // 
            this.manageUserToolStripMenuItem.Enabled = false;
            this.manageUserToolStripMenuItem.Name = "manageUserToolStripMenuItem";
            this.manageUserToolStripMenuItem.Size = new System.Drawing.Size(183, 24);
            this.manageUserToolStripMenuItem.Text = "Manage User";
            this.manageUserToolStripMenuItem.Click += new System.EventHandler(this.manageUserToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(183, 24);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(183, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // patientToolStripMenuItem
            // 
            this.patientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patientInfoToolStripMenuItem});
            this.patientToolStripMenuItem.Name = "patientToolStripMenuItem";
            this.patientToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.patientToolStripMenuItem.Text = "Patient";
            // 
            // patientInfoToolStripMenuItem
            // 
            this.patientInfoToolStripMenuItem.Name = "patientInfoToolStripMenuItem";
            this.patientInfoToolStripMenuItem.Size = new System.Drawing.Size(154, 24);
            this.patientInfoToolStripMenuItem.Text = "Patient Info";
            this.patientInfoToolStripMenuItem.Click += new System.EventHandler(this.patientInfoToolStripMenuItem_Click);
            // 
            // scheduleToolStripMenuItem
            // 
            this.scheduleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addScheduleToolStripMenuItem,
            this.viewScheduleToolStripMenuItem});
            this.scheduleToolStripMenuItem.Name = "scheduleToolStripMenuItem";
            this.scheduleToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.scheduleToolStripMenuItem.Text = "Schedule";
            // 
            // addScheduleToolStripMenuItem
            // 
            this.addScheduleToolStripMenuItem.Name = "addScheduleToolStripMenuItem";
            this.addScheduleToolStripMenuItem.Size = new System.Drawing.Size(174, 24);
            this.addScheduleToolStripMenuItem.Text = "Add Schedule";
            this.addScheduleToolStripMenuItem.Click += new System.EventHandler(this.addScheduleToolStripMenuItem_Click);
            // 
            // viewScheduleToolStripMenuItem
            // 
            this.viewScheduleToolStripMenuItem.Name = "viewScheduleToolStripMenuItem";
            this.viewScheduleToolStripMenuItem.Size = new System.Drawing.Size(174, 24);
            this.viewScheduleToolStripMenuItem.Text = "View Schedule";
            this.viewScheduleToolStripMenuItem.Click += new System.EventHandler(this.viewScheduleToolStripMenuItem_Click);
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemsToolStripMenuItem,
            this.itemCategoryToolStripMenuItem,
            this.paymentMethodToolStripMenuItem,
            this.paymentAdjustmentToolStripMenuItem});
            this.inventoryToolStripMenuItem.Enabled = false;
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.inventoryToolStripMenuItem.Text = "Inventory";
            // 
            // itemsToolStripMenuItem
            // 
            this.itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            this.itemsToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
            this.itemsToolStripMenuItem.Text = "Inventory";
            this.itemsToolStripMenuItem.Click += new System.EventHandler(this.itemsToolStripMenuItem_Click);
            // 
            // itemCategoryToolStripMenuItem
            // 
            this.itemCategoryToolStripMenuItem.Name = "itemCategoryToolStripMenuItem";
            this.itemCategoryToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
            this.itemCategoryToolStripMenuItem.Text = "Category";
            this.itemCategoryToolStripMenuItem.Click += new System.EventHandler(this.itemCategoryToolStripMenuItem_Click);
            // 
            // paymentMethodToolStripMenuItem
            // 
            this.paymentMethodToolStripMenuItem.Name = "paymentMethodToolStripMenuItem";
            this.paymentMethodToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
            this.paymentMethodToolStripMenuItem.Text = "Payment Method";
            this.paymentMethodToolStripMenuItem.Click += new System.EventHandler(this.paymentMethodToolStripMenuItem_Click);
            // 
            // paymentAdjustmentToolStripMenuItem
            // 
            this.paymentAdjustmentToolStripMenuItem.Name = "paymentAdjustmentToolStripMenuItem";
            this.paymentAdjustmentToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
            this.paymentAdjustmentToolStripMenuItem.Text = "Payment Adjustment";
            this.paymentAdjustmentToolStripMenuItem.Click += new System.EventHandler(this.paymentAdjustmentToolStripMenuItem_Click);
            // 
            // salesToolStripMenuItem
            // 
            this.salesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dailyReportToolStripMenuItem,
            this.dailySalesSummaryToolStripMenuItem,
            this.weeklySalesSummaryToolStripMenuItem,
            this.monthlySalesSummaryToolStripMenuItem,
            this.yearlySalesSummaryToolStripMenuItem});
            this.salesToolStripMenuItem.Enabled = false;
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.salesToolStripMenuItem.Text = "Sales";
            // 
            // dailyReportToolStripMenuItem
            // 
            this.dailyReportToolStripMenuItem.Name = "dailyReportToolStripMenuItem";
            this.dailyReportToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.dailyReportToolStripMenuItem.Text = "Daily Report";
            this.dailyReportToolStripMenuItem.Click += new System.EventHandler(this.dailyReportToolStripMenuItem_Click);
            // 
            // dailySalesSummaryToolStripMenuItem
            // 
            this.dailySalesSummaryToolStripMenuItem.Name = "dailySalesSummaryToolStripMenuItem";
            this.dailySalesSummaryToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.dailySalesSummaryToolStripMenuItem.Text = "Daily Sales Summary";
            this.dailySalesSummaryToolStripMenuItem.Click += new System.EventHandler(this.dailySalesSummaryToolStripMenuItem_Click);
            // 
            // weeklySalesSummaryToolStripMenuItem
            // 
            this.weeklySalesSummaryToolStripMenuItem.Name = "weeklySalesSummaryToolStripMenuItem";
            this.weeklySalesSummaryToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.weeklySalesSummaryToolStripMenuItem.Text = "Weekly Sales Summary";
            this.weeklySalesSummaryToolStripMenuItem.Click += new System.EventHandler(this.weeklySalesSummaryToolStripMenuItem_Click);
            // 
            // monthlySalesSummaryToolStripMenuItem
            // 
            this.monthlySalesSummaryToolStripMenuItem.Name = "monthlySalesSummaryToolStripMenuItem";
            this.monthlySalesSummaryToolStripMenuItem.Size = new System.Drawing.Size(236, 24);
            this.monthlySalesSummaryToolStripMenuItem.Text = "Monthly Sales Summary";
            this.monthlySalesSummaryToolStripMenuItem.Click += new System.EventHandler(this.monthlySalesSummaryToolStripMenuItem_Click);
            // 
            // yearlySalesSummaryToolStripMenuItem
            // 
            this.yearlySalesSummaryToolStripMenuItem.Name = "yearlySalesSummaryToolStripMenuItem";
            this.yearlySalesSummaryToolStripMenuItem.Size = new System.Drawing.Size(236, 24);
            this.yearlySalesSummaryToolStripMenuItem.Text = "Yearly Sales Summary";
            this.yearlySalesSummaryToolStripMenuItem.Click += new System.EventHandler(this.yearlySalesSummaryToolStripMenuItem_Click);
            // 
            // frmLanding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 653);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmLanding";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eastern Marikina Dialysis Center - Landing Form";
            this.Load += new System.EventHandler(this.frmLanding_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentMethodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentAdjustmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailyReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailySalesSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weeklySalesSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthlySalesSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yearlySalesSummaryToolStripMenuItem;
    }
}