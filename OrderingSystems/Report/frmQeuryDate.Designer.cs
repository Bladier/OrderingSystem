namespace OrderingSystems
{
    partial class frmQeuryDate
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
            this.monCal = new System.Windows.Forms.MonthCalendar();
            this.rbDaily = new System.Windows.Forms.RadioButton();
            this.rbMonthly = new System.Windows.Forms.RadioButton();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.cboReportType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // monCal
            // 
            this.monCal.Location = new System.Drawing.Point(110, 18);
            this.monCal.Name = "monCal";
            this.monCal.TabIndex = 0;
            // 
            // rbDaily
            // 
            this.rbDaily.AutoSize = true;
            this.rbDaily.Checked = true;
            this.rbDaily.Location = new System.Drawing.Point(29, 96);
            this.rbDaily.Name = "rbDaily";
            this.rbDaily.Size = new System.Drawing.Size(48, 17);
            this.rbDaily.TabIndex = 0;
            this.rbDaily.TabStop = true;
            this.rbDaily.Text = "Daily";
            this.rbDaily.UseVisualStyleBackColor = true;
            this.rbDaily.CheckedChanged += new System.EventHandler(this.rbDaily_CheckedChanged);
            // 
            // rbMonthly
            // 
            this.rbMonthly.AutoSize = true;
            this.rbMonthly.Location = new System.Drawing.Point(29, 132);
            this.rbMonthly.Name = "rbMonthly";
            this.rbMonthly.Size = new System.Drawing.Size(62, 17);
            this.rbMonthly.TabIndex = 1;
            this.rbMonthly.Text = "Monthly";
            this.rbMonthly.UseVisualStyleBackColor = true;
            this.rbMonthly.CheckedChanged += new System.EventHandler(this.rbMonthly_CheckedChanged);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(110, 219);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(227, 31);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "&Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // cboReportType
            // 
            this.cboReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReportType.FormattingEnabled = true;
            this.cboReportType.Location = new System.Drawing.Point(110, 192);
            this.cboReportType.Name = "cboReportType";
            this.cboReportType.Size = new System.Drawing.Size(227, 21);
            this.cboReportType.TabIndex = 2;
            // 
            // frmQeuryDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 262);
            this.Controls.Add(this.cboReportType);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.rbMonthly);
            this.Controls.Add(this.rbDaily);
            this.Controls.Add(this.monCal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmQeuryDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.frmQeuryDate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monCal;
        private System.Windows.Forms.RadioButton rbDaily;
        private System.Windows.Forms.RadioButton rbMonthly;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ComboBox cboReportType;
    }
}