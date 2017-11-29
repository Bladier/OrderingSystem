namespace BTMS
{
    partial class frmMain2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain2));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.setBusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.busListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.busConfirmationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passengerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.transactionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(625, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // transactionToolStripMenuItem
            // 
            this.transactionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transactionToolStripMenuItem1,
            this.setBusToolStripMenuItem,
            this.busListToolStripMenuItem,
            this.busConfirmationToolStripMenuItem,
            this.passengerToolStripMenuItem});
            this.transactionToolStripMenuItem.Name = "transactionToolStripMenuItem";
            this.transactionToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.transactionToolStripMenuItem.Text = "&Module";
            // 
            // transactionToolStripMenuItem1
            // 
            this.transactionToolStripMenuItem1.Name = "transactionToolStripMenuItem1";
            this.transactionToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.transactionToolStripMenuItem1.Text = "&Transaction";
            this.transactionToolStripMenuItem1.Click += new System.EventHandler(this.transactionToolStripMenuItem1_Click);
            // 
            // setBusToolStripMenuItem
            // 
            this.setBusToolStripMenuItem.Name = "setBusToolStripMenuItem";
            this.setBusToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.setBusToolStripMenuItem.Text = "&Set Bus";
            this.setBusToolStripMenuItem.Click += new System.EventHandler(this.setBusToolStripMenuItem_Click);
            // 
            // busListToolStripMenuItem
            // 
            this.busListToolStripMenuItem.Name = "busListToolStripMenuItem";
            this.busListToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.busListToolStripMenuItem.Text = "&Bus List";
            this.busListToolStripMenuItem.Click += new System.EventHandler(this.busListToolStripMenuItem_Click);
            // 
            // busConfirmationToolStripMenuItem
            // 
            this.busConfirmationToolStripMenuItem.Name = "busConfirmationToolStripMenuItem";
            this.busConfirmationToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.busConfirmationToolStripMenuItem.Text = "&B&us Confirmation";
            this.busConfirmationToolStripMenuItem.Click += new System.EventHandler(this.busConfirmationToolStripMenuItem_Click);
            // 
            // passengerToolStripMenuItem
            // 
            this.passengerToolStripMenuItem.Name = "passengerToolStripMenuItem";
            this.passengerToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.passengerToolStripMenuItem.Text = "&Passenger";
            this.passengerToolStripMenuItem.Click += new System.EventHandler(this.passengerToolStripMenuItem_Click);
            // 
            // frmMain2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(625, 374);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BUS PAYMENT CARD TECHNOLOGY SYSTEM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem setBusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem busListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem busConfirmationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem passengerToolStripMenuItem;
    }
}