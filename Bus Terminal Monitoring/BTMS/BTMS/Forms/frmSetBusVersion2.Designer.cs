namespace BTMS
{
    partial class frmSetBusVersion2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetBusVersion2));
            this.label1 = new System.Windows.Forms.Label();
            this.cboBusType = new System.Windows.Forms.ComboBox();
            this.cboBusNo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTO = new System.Windows.Forms.TextBox();
            this.txtDriver = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCondoctor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnAuthorization = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAvailableSeat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "BusType";
            // 
            // cboBusType
            // 
            this.cboBusType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBusType.FormattingEnabled = true;
            this.cboBusType.Location = new System.Drawing.Point(79, 30);
            this.cboBusType.Name = "cboBusType";
            this.cboBusType.Size = new System.Drawing.Size(208, 21);
            this.cboBusType.TabIndex = 1;
            this.cboBusType.SelectedIndexChanged += new System.EventHandler(this.cboBusType_SelectedIndexChanged);
            // 
            // cboBusNo
            // 
            this.cboBusNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBusNo.FormattingEnabled = true;
            this.cboBusNo.Location = new System.Drawing.Point(79, 66);
            this.cboBusNo.Name = "cboBusNo";
            this.cboBusNo.Size = new System.Drawing.Size(208, 21);
            this.cboBusNo.TabIndex = 3;
            this.cboBusNo.SelectedIndexChanged += new System.EventHandler(this.cboBusNo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bus No.";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(79, 102);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.ReadOnly = true;
            this.txtFrom.Size = new System.Drawing.Size(208, 20);
            this.txtFrom.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "From";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "TO";
            // 
            // txtTO
            // 
            this.txtTO.Location = new System.Drawing.Point(79, 137);
            this.txtTO.Name = "txtTO";
            this.txtTO.ReadOnly = true;
            this.txtTO.Size = new System.Drawing.Size(208, 20);
            this.txtTO.TabIndex = 6;
            // 
            // txtDriver
            // 
            this.txtDriver.Location = new System.Drawing.Point(367, 64);
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.ReadOnly = true;
            this.txtDriver.Size = new System.Drawing.Size(199, 20);
            this.txtDriver.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(305, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Driver";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(305, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Condoctor";
            // 
            // txtCondoctor
            // 
            this.txtCondoctor.Location = new System.Drawing.Point(367, 101);
            this.txtCondoctor.Name = "txtCondoctor";
            this.txtCondoctor.ReadOnly = true;
            this.txtCondoctor.Size = new System.Drawing.Size(199, 20);
            this.txtCondoctor.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(307, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Rate";
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(367, 28);
            this.txtRate.Name = "txtRate";
            this.txtRate.ReadOnly = true;
            this.txtRate.Size = new System.Drawing.Size(199, 20);
            this.txtRate.TabIndex = 12;
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(470, 171);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(96, 25);
            this.btnSet.TabIndex = 14;
            this.btnSet.Text = "&Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnAuthorization
            // 
            this.btnAuthorization.Location = new System.Drawing.Point(367, 172);
            this.btnAuthorization.Name = "btnAuthorization";
            this.btnAuthorization.Size = new System.Drawing.Size(97, 23);
            this.btnAuthorization.TabIndex = 15;
            this.btnAuthorization.Text = "&Verify";
            this.btnAuthorization.UseVisualStyleBackColor = true;
            this.btnAuthorization.Click += new System.EventHandler(this.btnAuthorization_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(306, 144);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Seats";
            // 
            // txtAvailableSeat
            // 
            this.txtAvailableSeat.Location = new System.Drawing.Point(367, 141);
            this.txtAvailableSeat.Name = "txtAvailableSeat";
            this.txtAvailableSeat.ReadOnly = true;
            this.txtAvailableSeat.Size = new System.Drawing.Size(199, 20);
            this.txtAvailableSeat.TabIndex = 16;
            // 
            // frmSetBusVersion2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 204);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtAvailableSeat);
            this.Controls.Add(this.btnAuthorization);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCondoctor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDriver);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTO);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.cboBusNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboBusType);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSetBusVersion2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Bus";
            this.Load += new System.EventHandler(this.frmSetBusVersion2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboBusType;
        private System.Windows.Forms.ComboBox cboBusNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTO;
        private System.Windows.Forms.TextBox txtDriver;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCondoctor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Button btnSet;
        internal System.Windows.Forms.Button btnAuthorization;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAvailableSeat;
    }
}