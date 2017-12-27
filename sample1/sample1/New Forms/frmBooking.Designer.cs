namespace sample1
{
    partial class frmBooking
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.rbCash = new System.Windows.Forms.RadioButton();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rbInstallment = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.lblPaidAtleast = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtContactNum = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPost = new System.Windows.Forms.Button();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnAvailability = new System.Windows.Forms.Button();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboVenue = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNoOfDays = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTransactionNum = new System.Windows.Forms.TextBox();
            this.Panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(339, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(36, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = ". . .";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rbCash
            // 
            this.rbCash.AutoSize = true;
            this.rbCash.Checked = true;
            this.rbCash.Location = new System.Drawing.Point(111, 21);
            this.rbCash.Name = "rbCash";
            this.rbCash.Size = new System.Drawing.Size(85, 17);
            this.rbCash.TabIndex = 0;
            this.rbCash.TabStop = true;
            this.rbCash.Text = "Full Payment";
            this.rbCash.UseVisualStyleBackColor = true;
            this.rbCash.CheckedChanged += new System.EventHandler(this.rbCash_CheckedChanged);
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel2.Controls.Add(this.label14);
            this.Panel2.Location = new System.Drawing.Point(38, 15);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(697, 62);
            this.Panel2.TabIndex = 34;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(310, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 24);
            this.label14.TabIndex = 0;
            this.label14.Text = "Booking";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.rbCash);
            this.groupBox3.Controls.Add(this.rbInstallment);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lblPaidAtleast);
            this.groupBox3.Controls.Add(this.lblBalance);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtPayment);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(424, 302);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(316, 136);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Payments";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "PayMent Mode:";
            // 
            // rbInstallment
            // 
            this.rbInstallment.AutoSize = true;
            this.rbInstallment.Location = new System.Drawing.Point(203, 21);
            this.rbInstallment.Name = "rbInstallment";
            this.rbInstallment.Size = new System.Drawing.Size(75, 17);
            this.rbInstallment.TabIndex = 1;
            this.rbInstallment.Text = "Installment";
            this.rbInstallment.UseVisualStyleBackColor = true;
            this.rbInstallment.CheckedChanged += new System.EventHandler(this.rbInstallment_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Paid Atleast :";
            // 
            // lblPaidAtleast
            // 
            this.lblPaidAtleast.AutoSize = true;
            this.lblPaidAtleast.Location = new System.Drawing.Point(108, 50);
            this.lblPaidAtleast.Name = "lblPaidAtleast";
            this.lblPaidAtleast.Size = new System.Drawing.Size(28, 13);
            this.lblPaidAtleast.TabIndex = 18;
            this.lblPaidAtleast.Text = "00.0";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(108, 76);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(28, 13);
            this.lblBalance.TabIndex = 23;
            this.lblBalance.Text = "00.0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Balance :";
            // 
            // txtPayment
            // 
            this.txtPayment.Location = new System.Drawing.Point(111, 104);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(195, 20);
            this.txtPayment.TabIndex = 2;
            this.txtPayment.TextChanged += new System.EventHandler(this.txtPayment_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Enter Payment";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtContactNum);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.txtCustomer);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtAddress);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(38, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 152);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Client";
            // 
            // txtContactNum
            // 
            this.txtContactNum.Location = new System.Drawing.Point(78, 118);
            this.txtContactNum.Name = "txtContactNum";
            this.txtContactNum.ReadOnly = true;
            this.txtContactNum.Size = new System.Drawing.Size(295, 20);
            this.txtContactNum.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 120);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Contact #";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(78, 15);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(255, 20);
            this.txtCustomer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(76, 41);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(297, 71);
            this.txtAddress.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Address";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(663, 444);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(584, 444);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(75, 32);
            this.btnPost.TabIndex = 30;
            this.btnPost.Text = "&Post";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(86, 137);
            this.txtRate.Name = "txtRate";
            this.txtRate.ReadOnly = true;
            this.txtRate.Size = new System.Drawing.Size(113, 20);
            this.txtRate.TabIndex = 11;
            // 
            // dtStartDate
            // 
            this.dtStartDate.CustomFormat = "MMMM, dd yyyy hh:mm tt";
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartDate.Location = new System.Drawing.Point(85, 46);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(221, 20);
            this.dtStartDate.TabIndex = 1;
            this.dtStartDate.Value = new System.DateTime(2017, 12, 14, 14, 15, 2, 0);
            this.dtStartDate.ValueChanged += new System.EventHandler(this.dtStartDate_ValueChanged);
            // 
            // btnAvailability
            // 
            this.btnAvailability.Location = new System.Drawing.Point(503, 445);
            this.btnAvailability.Name = "btnAvailability";
            this.btnAvailability.Size = new System.Drawing.Size(75, 31);
            this.btnAvailability.TabIndex = 35;
            this.btnAvailability.Text = "&Availability";
            this.btnAvailability.UseVisualStyleBackColor = true;
            this.btnAvailability.Click += new System.EventHandler(this.btnAvailability_Click);
            // 
            // dtEndDate
            // 
            this.dtEndDate.CustomFormat = "MMMM, dd yyyy hh:mm tt";
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndDate.Location = new System.Drawing.Point(86, 79);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(221, 20);
            this.dtEndDate.TabIndex = 2;
            this.dtEndDate.Value = new System.DateTime(2017, 12, 14, 14, 15, 9, 0);
            this.dtEndDate.ValueChanged += new System.EventHandler(this.dtEndDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Start Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "End Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Rate";
            // 
            // cboVenue
            // 
            this.cboVenue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVenue.FormattingEnabled = true;
            this.cboVenue.Location = new System.Drawing.Point(84, 19);
            this.cboVenue.Name = "cboVenue";
            this.cboVenue.Size = new System.Drawing.Size(222, 21);
            this.cboVenue.TabIndex = 0;
            this.cboVenue.SelectedIndexChanged += new System.EventHandler(this.cboVenue_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtNoOfDays);
            this.groupBox1.Controls.Add(this.cboVenue);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtStartDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtEndDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtRate);
            this.groupBox1.Location = new System.Drawing.Point(425, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 204);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rate Info";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 111);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "No. of Days";
            // 
            // txtNoOfDays
            // 
            this.txtNoOfDays.Location = new System.Drawing.Point(86, 108);
            this.txtNoOfDays.Name = "txtNoOfDays";
            this.txtNoOfDays.ReadOnly = true;
            this.txtNoOfDays.Size = new System.Drawing.Size(113, 20);
            this.txtNoOfDays.TabIndex = 24;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(87, 171);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(28, 13);
            this.lblTotal.TabIndex = 21;
            this.lblTotal.Text = "00.0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 170);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Total ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Venue";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txtTransactionNum);
            this.groupBox4.Location = new System.Drawing.Point(38, 86);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(381, 45);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(15, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Transaction #";
            // 
            // txtTransactionNum
            // 
            this.txtTransactionNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransactionNum.ForeColor = System.Drawing.Color.Red;
            this.txtTransactionNum.Location = new System.Drawing.Point(94, 15);
            this.txtTransactionNum.Name = "txtTransactionNum";
            this.txtTransactionNum.ReadOnly = true;
            this.txtTransactionNum.Size = new System.Drawing.Size(149, 20);
            this.txtTransactionNum.TabIndex = 0;
            this.txtTransactionNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(769, 504);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.btnAvailability);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Booking";
            this.Load += new System.EventHandler(this.frmBooking_Load);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton rbCash;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbInstallment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblPaidAtleast;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPayment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Button btnAvailability;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboVenue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNoOfDays;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTransactionNum;
        private System.Windows.Forms.TextBox txtContactNum;
        private System.Windows.Forms.Label label15;
    }
}