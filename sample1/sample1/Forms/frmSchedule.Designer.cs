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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackColor = System.Drawing.Color.LightGray;
            this.monthCalendar1.BoldedDates = new System.DateTime[] {
        new System.DateTime(2017, 12, 18, 16, 35, 46, 0)};
            this.monthCalendar1.FirstDayOfWeek = System.Windows.Forms.Day.Sunday;
            this.monthCalendar1.ForeColor = System.Drawing.Color.DarkRed;
            this.monthCalendar1.Location = new System.Drawing.Point(31, 40);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.ShowTodayCircle = false;
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.TitleBackColor = System.Drawing.Color.Red;
            this.monthCalendar1.TitleForeColor = System.Drawing.Color.Red;
            this.monthCalendar1.TrailingForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // frmSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 414);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "frmSchedule";
            this.Text = "frmSchedule";
            this.Load += new System.EventHandler(this.frmSchedule_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}