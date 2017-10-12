namespace OrderingSystems
{
    partial class frmCasher
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
            System.Windows.Forms.ColumnHeader columnHeader1;
            this.panel1 = new System.Windows.Forms.Panel();
            this.LVQueue = new System.Windows.Forms.ListView();
            this.lvListOrder = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "CLIENT ORDERS";
            columnHeader1.Width = 431;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Blue;
            this.panel1.Controls.Add(this.lvListOrder);
            this.panel1.Controls.Add(this.LVQueue);
            this.panel1.Location = new System.Drawing.Point(26, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1205, 599);
            this.panel1.TabIndex = 1;
            // 
            // LVQueue
            // 
            this.LVQueue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1});
            this.LVQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LVQueue.FullRowSelect = true;
            this.LVQueue.GridLines = true;
            this.LVQueue.Location = new System.Drawing.Point(16, 3);
            this.LVQueue.Name = "LVQueue";
            this.LVQueue.Size = new System.Drawing.Size(435, 593);
            this.LVQueue.TabIndex = 0;
            this.LVQueue.UseCompatibleStateImageBehavior = false;
            this.LVQueue.View = System.Windows.Forms.View.Details;
            this.LVQueue.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LVQueue_MouseClick);
            // 
            // lvListOrder
            // 
            this.lvListOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvListOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvListOrder.FullRowSelect = true;
            this.lvListOrder.GridLines = true;
            this.lvListOrder.Location = new System.Drawing.Point(460, 195);
            this.lvListOrder.Name = "lvListOrder";
            this.lvListOrder.Size = new System.Drawing.Size(735, 368);
            this.lvListOrder.TabIndex = 1;
            this.lvListOrder.UseCompatibleStateImageBehavior = false;
            this.lvListOrder.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Mene Name";
            this.columnHeader2.Width = 178;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Menu Type";
            this.columnHeader3.Width = 168;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Size";
            this.columnHeader4.Width = 137;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Price";
            this.columnHeader5.Width = 158;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "QTY";
            // 
            // frmCasher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 623);
            this.Controls.Add(this.panel1);
            this.Name = "frmCasher";
            this.Text = "Casher";
            this.Load += new System.EventHandler(this.frmCasher_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView LVQueue;
        private System.Windows.Forms.ListView lvListOrder;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}