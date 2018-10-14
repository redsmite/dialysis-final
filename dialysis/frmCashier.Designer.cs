namespace dialysis
{
    partial class frmCashier
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
            this.gpbCashier = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFetch = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtInventory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvSummary = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPayment = new System.Windows.Forms.ComboBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.gpbCashier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbCashier
            // 
            this.gpbCashier.Controls.Add(this.btnTest);
            this.gpbCashier.Controls.Add(this.lblTotal);
            this.gpbCashier.Controls.Add(this.label6);
            this.gpbCashier.Controls.Add(this.btnCheckout);
            this.gpbCashier.Controls.Add(this.btnAdd);
            this.gpbCashier.Controls.Add(this.lblSubtotal);
            this.gpbCashier.Controls.Add(this.label5);
            this.gpbCashier.Controls.Add(this.txtQuantity);
            this.gpbCashier.Controls.Add(this.label4);
            this.gpbCashier.Controls.Add(this.lblAmount);
            this.gpbCashier.Controls.Add(this.label3);
            this.gpbCashier.Controls.Add(this.btnFetch);
            this.gpbCashier.Controls.Add(this.btnSearch);
            this.gpbCashier.Controls.Add(this.txtInventory);
            this.gpbCashier.Controls.Add(this.label2);
            this.gpbCashier.Controls.Add(this.dgvSummary);
            this.gpbCashier.Enabled = false;
            this.gpbCashier.Location = new System.Drawing.Point(12, 43);
            this.gpbCashier.Name = "gpbCashier";
            this.gpbCashier.Size = new System.Drawing.Size(583, 354);
            this.gpbCashier.TabIndex = 0;
            this.gpbCashier.TabStop = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(426, 282);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(36, 17);
            this.lblTotal.TabIndex = 15;
            this.lblTotal.Text = "0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(346, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Total:";
            // 
            // btnCheckout
            // 
            this.btnCheckout.Enabled = false;
            this.btnCheckout.Location = new System.Drawing.Point(417, 311);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(75, 37);
            this.btnCheckout.TabIndex = 12;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(417, 231);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 31);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Location = new System.Drawing.Point(426, 202);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(36, 17);
            this.lblSubtotal.TabIndex = 10;
            this.lblSubtotal.Text = "0.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(346, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Subtotal:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(417, 164);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(160, 22);
            this.txtQuantity.TabIndex = 8;
            this.txtQuantity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQuantity_KeyUp);
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(346, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Quantity:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(426, 135);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(36, 17);
            this.lblAmount.TabIndex = 6;
            this.lblAmount.Text = "0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(346, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Amount:";
            // 
            // btnFetch
            // 
            this.btnFetch.Enabled = false;
            this.btnFetch.Location = new System.Drawing.Point(457, 81);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(75, 31);
            this.btnFetch.TabIndex = 4;
            this.btnFetch.Text = "Fetch";
            this.btnFetch.UseVisualStyleBackColor = true;
            this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(376, 81);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 31);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtInventory
            // 
            this.txtInventory.Location = new System.Drawing.Point(335, 53);
            this.txtInventory.Name = "txtInventory";
            this.txtInventory.Size = new System.Drawing.Size(242, 22);
            this.txtInventory.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(332, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Search Inventory:";
            // 
            // dgvSummary
            // 
            this.dgvSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSummary.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSummary.Location = new System.Drawing.Point(6, 21);
            this.dgvSummary.Name = "dgvSummary";
            this.dgvSummary.RowTemplate.Height = 24;
            this.dgvSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSummary.Size = new System.Drawing.Size(320, 327);
            this.dgvSummary.TabIndex = 0;
            this.dgvSummary.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSummary_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Payment Method:";
            // 
            // cboPayment
            // 
            this.cboPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPayment.FormattingEnabled = true;
            this.cboPayment.Location = new System.Drawing.Point(253, 20);
            this.cboPayment.Name = "cboPayment";
            this.cboPayment.Size = new System.Drawing.Size(178, 24);
            this.cboPayment.TabIndex = 0;
            this.cboPayment.DropDownClosed += new System.EventHandler(this.cboPayment_DropDownClosed);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(498, 265);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 51);
            this.btnTest.TabIndex = 16;
            this.btnTest.Text = "Test Receipt";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmCashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 404);
            this.Controls.Add(this.cboPayment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gpbCashier);
            this.Name = "frmCashier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cashier";
            this.Load += new System.EventHandler(this.frmCashier_Load);
            this.gpbCashier.ResumeLayout(false);
            this.gpbCashier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbCashier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPayment;
        private System.Windows.Forms.DataGridView dgvSummary;
        public System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtInventory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnTest;
    }
}