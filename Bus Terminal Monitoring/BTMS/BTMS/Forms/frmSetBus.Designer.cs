namespace BTMS
{
    partial class frmSetBus
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
            this.txtBusNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAvailableSeat = new System.Windows.Forms.TextBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnAuthorization = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDriver = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCondoctor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(255, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(32, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "...";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBusNo
            // 
            this.txtBusNo.Location = new System.Drawing.Point(75, 26);
            this.txtBusNo.Name = "txtBusNo";
            this.txtBusNo.ReadOnly = true;
            this.txtBusNo.Size = new System.Drawing.Size(174, 20);
            this.txtBusNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bus No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Seats";
            // 
            // txtAvailableSeat
            // 
            this.txtAvailableSeat.Location = new System.Drawing.Point(75, 58);
            this.txtAvailableSeat.Name = "txtAvailableSeat";
            this.txtAvailableSeat.ReadOnly = true;
            this.txtAvailableSeat.Size = new System.Drawing.Size(212, 20);
            this.txtAvailableSeat.TabIndex = 3;
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(212, 147);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 5;
            this.btnSet.Text = "&Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnAuthorization
            // 
            this.btnAuthorization.Location = new System.Drawing.Point(17, 145);
            this.btnAuthorization.Name = "btnAuthorization";
            this.btnAuthorization.Size = new System.Drawing.Size(75, 23);
            this.btnAuthorization.TabIndex = 6;
            this.btnAuthorization.Text = "&Verify";
            this.btnAuthorization.UseVisualStyleBackColor = true;
            this.btnAuthorization.Click += new System.EventHandler(this.btnAuthorization_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 87);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Driver";
            // 
            // txtDriver
            // 
            this.txtDriver.Location = new System.Drawing.Point(75, 86);
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.ReadOnly = true;
            this.txtDriver.Size = new System.Drawing.Size(212, 20);
            this.txtDriver.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 116);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Condoctor";
            // 
            // txtCondoctor
            // 
            this.txtCondoctor.Location = new System.Drawing.Point(75, 115);
            this.txtCondoctor.Name = "txtCondoctor";
            this.txtCondoctor.ReadOnly = true;
            this.txtCondoctor.Size = new System.Drawing.Size(212, 20);
            this.txtCondoctor.TabIndex = 9;
            // 
            // frmSetBus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 180);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCondoctor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDriver);
            this.Controls.Add(this.btnAuthorization);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAvailableSeat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBusNo);
            this.Controls.Add(this.btnSearch);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSetBus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Set Bus";
            this.Load += new System.EventHandler(this.frmSetBus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtBusNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAvailableSeat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDriver;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCondoctor;
        internal System.Windows.Forms.Button btnSet;
        internal System.Windows.Forms.Button btnAuthorization;
    }
}