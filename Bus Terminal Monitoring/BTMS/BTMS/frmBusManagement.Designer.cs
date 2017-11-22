namespace BTMS
{
    partial class frmBusManagement
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
            this.label6 = new System.Windows.Forms.Label();
            this.cboBusType = new System.Windows.Forms.ComboBox();
            this.txtNumSeats = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPlateNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDriver = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.btnsearchCondoctor = new System.Windows.Forms.Button();
            this.txtCondoctor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBusNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 53);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "BusType";
            // 
            // cboBusType
            // 
            this.cboBusType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBusType.FormattingEnabled = true;
            this.cboBusType.Items.AddRange(new object[] {
            "Aircon",
            "Exclusive"});
            this.cboBusType.Location = new System.Drawing.Point(145, 45);
            this.cboBusType.Margin = new System.Windows.Forms.Padding(5);
            this.cboBusType.Name = "cboBusType";
            this.cboBusType.Size = new System.Drawing.Size(406, 24);
            this.cboBusType.TabIndex = 14;
            // 
            // txtNumSeats
            // 
            this.txtNumSeats.Location = new System.Drawing.Point(146, 128);
            this.txtNumSeats.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtNumSeats.Name = "txtNumSeats";
            this.txtNumSeats.Size = new System.Drawing.Size(406, 22);
            this.txtNumSeats.TabIndex = 16;
            this.txtNumSeats.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumSeats_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 129);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Number of Seats";
            // 
            // txtPlateNumber
            // 
            this.txtPlateNumber.Location = new System.Drawing.Point(146, 172);
            this.txtPlateNumber.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtPlateNumber.Name = "txtPlateNumber";
            this.txtPlateNumber.Size = new System.Drawing.Size(406, 22);
            this.txtPlateNumber.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 175);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Plate Number";
            // 
            // txtDriver
            // 
            this.txtDriver.Location = new System.Drawing.Point(146, 215);
            this.txtDriver.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.Size = new System.Drawing.Size(321, 22);
            this.txtDriver.TabIndex = 20;
            this.txtDriver.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDriver_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 217);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Driver";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(392, 335);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 33);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(477, 335);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 33);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(477, 213);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 24);
            this.btnSearch.TabIndex = 25;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 299);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "Status";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "For Travel",
            "Arrived",
            "Unavailable"});
            this.cboStatus.Location = new System.Drawing.Point(146, 291);
            this.cboStatus.Margin = new System.Windows.Forms.Padding(5);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(406, 24);
            this.cboStatus.TabIndex = 26;
            // 
            // btnsearchCondoctor
            // 
            this.btnsearchCondoctor.Location = new System.Drawing.Point(477, 247);
            this.btnsearchCondoctor.Name = "btnsearchCondoctor";
            this.btnsearchCondoctor.Size = new System.Drawing.Size(75, 24);
            this.btnsearchCondoctor.TabIndex = 30;
            this.btnsearchCondoctor.Text = "&Search";
            this.btnsearchCondoctor.UseVisualStyleBackColor = true;
            this.btnsearchCondoctor.Click += new System.EventHandler(this.btnsearchCondoctor_Click);
            // 
            // txtCondoctor
            // 
            this.txtCondoctor.Location = new System.Drawing.Point(146, 249);
            this.txtCondoctor.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtCondoctor.Name = "txtCondoctor";
            this.txtCondoctor.Size = new System.Drawing.Size(321, 22);
            this.txtCondoctor.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 251);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "Condoctor";
            // 
            // txtBusNo
            // 
            this.txtBusNo.Location = new System.Drawing.Point(146, 94);
            this.txtBusNo.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtBusNo.Name = "txtBusNo";
            this.txtBusNo.Size = new System.Drawing.Size(406, 22);
            this.txtBusNo.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 95);
            this.label7.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 16);
            this.label7.TabIndex = 32;
            this.label7.Text = "Bus No.";
            // 
            // frmBusManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 383);
            this.Controls.Add(this.txtBusNo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnsearchCondoctor);
            this.Controls.Add(this.txtCondoctor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDriver);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPlateNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumSeats);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboBusType);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBusManagement";
            this.Text = "Bus Management";
            this.Load += new System.EventHandler(this.frmBusManagement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboBusType;
        private System.Windows.Forms.TextBox txtNumSeats;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPlateNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDriver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Button btnsearchCondoctor;
        private System.Windows.Forms.TextBox txtCondoctor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBusNo;
        private System.Windows.Forms.Label label7;
    }
}