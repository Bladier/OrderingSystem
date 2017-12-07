namespace BTMS
{
    partial class frmPersonnelRegistration
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbinActive = new System.Windows.Forms.RadioButton();
            this.rbactive = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBday = new System.Windows.Forms.DateTimePicker();
            this.cboPosition = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtHired = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtHired);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.rbinActive);
            this.groupBox1.Controls.Add(this.rbactive);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtBday);
            this.groupBox1.Controls.Add(this.cboPosition);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtFname);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtLname);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(417, 266);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rbinActive
            // 
            this.rbinActive.AutoSize = true;
            this.rbinActive.Location = new System.Drawing.Point(170, 221);
            this.rbinActive.Name = "rbinActive";
            this.rbinActive.Size = new System.Drawing.Size(66, 19);
            this.rbinActive.TabIndex = 6;
            this.rbinActive.TabStop = true;
            this.rbinActive.Text = "Inactive";
            this.rbinActive.UseVisualStyleBackColor = true;
            // 
            // rbactive
            // 
            this.rbactive.AutoSize = true;
            this.rbactive.Checked = true;
            this.rbactive.Location = new System.Drawing.Point(94, 222);
            this.rbactive.Name = "rbactive";
            this.rbactive.Size = new System.Drawing.Size(56, 19);
            this.rbactive.TabIndex = 5;
            this.rbactive.TabStop = true;
            this.rbactive.Text = "Active";
            this.rbactive.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 222);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 154);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Position";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtBday
            // 
            this.txtBday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtBday.Location = new System.Drawing.Point(94, 126);
            this.txtBday.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBday.Name = "txtBday";
            this.txtBday.Size = new System.Drawing.Size(311, 21);
            this.txtBday.TabIndex = 3;
            this.txtBday.ValueChanged += new System.EventHandler(this.txtBday_ValueChanged);
            // 
            // cboPosition
            // 
            this.cboPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPosition.FormattingEnabled = true;
            this.cboPosition.Items.AddRange(new object[] {
            "Driver",
            "Condoctor",
            "Inspector"});
            this.cboPosition.Location = new System.Drawing.Point(94, 152);
            this.cboPosition.Margin = new System.Windows.Forms.Padding(4);
            this.cboPosition.Name = "cboPosition";
            this.cboPosition.Size = new System.Drawing.Size(309, 23);
            this.cboPosition.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 127);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Birth Date";
            // 
            // txtFname
            // 
            this.txtFname.Location = new System.Drawing.Point(94, 29);
            this.txtFname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(311, 21);
            this.txtFname.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "FirstName";
            // 
            // txtLname
            // 
            this.txtLname.Location = new System.Drawing.Point(94, 94);
            this.txtLname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(311, 21);
            this.txtLname.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "lastName";
            // 
            // txtMname
            // 
            this.txtMname.Location = new System.Drawing.Point(94, 61);
            this.txtMname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMname.Name = "txtMname";
            this.txtMname.Size = new System.Drawing.Size(311, 21);
            this.txtMname.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "MiddleName";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(353, 286);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 26);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(270, 286);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 26);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtHired
            // 
            this.dtHired.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHired.Location = new System.Drawing.Point(92, 184);
            this.dtHired.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtHired.Name = "dtHired";
            this.dtHired.Size = new System.Drawing.Size(311, 21);
            this.dtHired.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 187);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "Date Hired";
            // 
            // frmPersonnelRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 340);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPersonnelRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personnel Registration";
            this.Load += new System.EventHandler(this.frmPersonnelRegistration_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtBday;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboPosition;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbinActive;
        private System.Windows.Forms.RadioButton rbactive;
        private System.Windows.Forms.DateTimePicker dtHired;
        private System.Windows.Forms.Label label7;
    }
}