namespace sample1
{
    partial class frmaddcity
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
            this.cboCity = new System.Windows.Forms.ComboBox();
            this.lvBarangay = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSave = new System.Windows.Forms.Button();
            this.txtbarangay = new System.Windows.Forms.TextBox();
            this.btnadd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboCity
            // 
            this.cboCity.FormattingEnabled = true;
            this.cboCity.Location = new System.Drawing.Point(12, 30);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(163, 21);
            this.cboCity.TabIndex = 0;
            this.cboCity.SelectedIndexChanged += new System.EventHandler(this.cboCity_SelectedIndexChanged);
            // 
            // lvBarangay
            // 
            this.lvBarangay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvBarangay.FullRowSelect = true;
            this.lvBarangay.Location = new System.Drawing.Point(181, 69);
            this.lvBarangay.Name = "lvBarangay";
            this.lvBarangay.Size = new System.Drawing.Size(313, 147);
            this.lvBarangay.TabIndex = 1;
            this.lvBarangay.UseCompatibleStateImageBehavior = false;
            this.lvBarangay.View = System.Windows.Forms.View.Details;
            this.lvBarangay.DoubleClick += new System.EventHandler(this.lvBarangay_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Barangay";
            this.columnHeader1.Width = 297;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(419, 222);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtbarangay
            // 
            this.txtbarangay.Location = new System.Drawing.Point(181, 31);
            this.txtbarangay.Name = "txtbarangay";
            this.txtbarangay.Size = new System.Drawing.Size(280, 20);
            this.txtbarangay.TabIndex = 3;
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(467, 30);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(27, 23);
            this.btnadd.TabIndex = 4;
            this.btnadd.Text = "+";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "City";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(15, 222);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmaddcity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 249);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.txtbarangay);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lvBarangay);
            this.Controls.Add(this.cboCity);
            this.Name = "frmaddcity";
            this.Text = "Add City";
            this.Load += new System.EventHandler(this.frmaddcity_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCity;
        private System.Windows.Forms.ListView lvBarangay;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtbarangay;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
    }
}