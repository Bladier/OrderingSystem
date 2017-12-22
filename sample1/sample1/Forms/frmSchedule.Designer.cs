namespace sample1
{
    partial class frmSchedule
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
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // monCal
            // 
            this.monCal.AccessibleRole = System.Windows.Forms.AccessibleRole.Sound;
            this.monCal.BackColor = System.Drawing.Color.DarkOrange;
            this.monCal.FirstDayOfWeek = System.Windows.Forms.Day.Sunday;
            this.monCal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monCal.ForeColor = System.Drawing.Color.Black;
            this.monCal.Location = new System.Drawing.Point(8, 6);
            this.monCal.Name = "monCal";
            this.monCal.ShowWeekNumbers = true;
            this.monCal.TabIndex = 0;
            this.monCal.TitleBackColor = System.Drawing.Color.White;
            this.monCal.TitleForeColor = System.Drawing.Color.Black;
            this.monCal.TrailingForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.monCal.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(94, 200);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 235);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.monCal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule";
            this.Load += new System.EventHandler(this.frmSchedule_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monCal;
        private System.Windows.Forms.Button btnOk;
    }
}