namespace sample1
{
    partial class frmSetDate
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCurrent = new System.Windows.Forms.DateTimePicker();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(355, 43);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "&Set Date";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date";
            // 
            // txtCurrent
            // 
            this.txtCurrent.CustomFormat = "MMM/dd/yyyy";
            this.txtCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrent.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtCurrent.Location = new System.Drawing.Point(62, 46);
            this.txtCurrent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.Size = new System.Drawing.Size(284, 21);
            this.txtCurrent.TabIndex = 2;
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel2.Controls.Add(this.label14);
            this.Panel2.Location = new System.Drawing.Point(12, 3);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(443, 36);
            this.Panel2.TabIndex = 35;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(162, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(132, 24);
            this.label14.TabIndex = 0;
            this.label14.Text = "Date Settings";
            // 
            // frmSetDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 82);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.txtCurrent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximumSize = new System.Drawing.Size(483, 116);
            this.MinimumSize = new System.Drawing.Size(483, 116);
            this.Name = "frmSetDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Date";
            this.Load += new System.EventHandler(this.frmSetDate_Load);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtCurrent;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label label14;
    }
}