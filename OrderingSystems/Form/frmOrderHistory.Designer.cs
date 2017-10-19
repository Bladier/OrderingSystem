namespace OrderingSystems
{
    partial class frmOrderHistory
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lvOrderHist = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnVoid = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvOrderNum = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvWholeOrder = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtSearchWholeOrder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVoidWO = new System.Windows.Forms.Button();
            this.btnSearchWO = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(791, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 47);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(68, 28);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(717, 22);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // lvOrderHist
            // 
            this.lvOrderHist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvOrderHist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvOrderHist.FullRowSelect = true;
            this.lvOrderHist.GridLines = true;
            this.lvOrderHist.Location = new System.Drawing.Point(14, 76);
            this.lvOrderHist.Name = "lvOrderHist";
            this.lvOrderHist.Size = new System.Drawing.Size(869, 246);
            this.lvOrderHist.TabIndex = 2;
            this.lvOrderHist.UseCompatibleStateImageBehavior = false;
            this.lvOrderHist.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Order #";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "MenuName";
            this.columnHeader1.Width = 170;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "MenuType";
            this.columnHeader2.Width = 288;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "MenuSize";
            this.columnHeader3.Width = 171;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Price";
            this.columnHeader4.Width = 99;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Price";
            this.columnHeader5.Width = 75;
            // 
            // btnVoid
            // 
            this.btnVoid.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoid.Location = new System.Drawing.Point(791, 328);
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.Size = new System.Drawing.Size(92, 51);
            this.btnVoid.TabIndex = 3;
            this.btnVoid.Text = "&Void";
            this.btnVoid.UseVisualStyleBackColor = true;
            this.btnVoid.Click += new System.EventHandler(this.btnVoid_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(897, 413);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtSearch);
            this.tabPage1.Controls.Add(this.btnVoid);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lvOrderHist);
            this.tabPage1.Controls.Add(this.btnSearch);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(889, 387);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Void Per Item";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvOrderNum);
            this.tabPage2.Controls.Add(this.lvWholeOrder);
            this.tabPage2.Controls.Add(this.txtSearchWholeOrder);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.btnVoidWO);
            this.tabPage2.Controls.Add(this.btnSearchWO);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(889, 387);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Void Whole Order";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvOrderNum
            // 
            this.lvOrderNum.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6});
            this.lvOrderNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvOrderNum.FullRowSelect = true;
            this.lvOrderNum.GridLines = true;
            this.lvOrderNum.Location = new System.Drawing.Point(8, 66);
            this.lvOrderNum.Name = "lvOrderNum";
            this.lvOrderNum.Size = new System.Drawing.Size(202, 256);
            this.lvOrderNum.TabIndex = 2;
            this.lvOrderNum.UseCompatibleStateImageBehavior = false;
            this.lvOrderNum.View = System.Windows.Forms.View.Details;
            this.lvOrderNum.Click += new System.EventHandler(this.lvOrderNum_Click);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Order #";
            this.columnHeader6.Width = 200;
            // 
            // lvWholeOrder
            // 
            this.lvWholeOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader12});
            this.lvWholeOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvWholeOrder.FullRowSelect = true;
            this.lvWholeOrder.GridLines = true;
            this.lvWholeOrder.Location = new System.Drawing.Point(216, 66);
            this.lvWholeOrder.Name = "lvWholeOrder";
            this.lvWholeOrder.Size = new System.Drawing.Size(661, 256);
            this.lvWholeOrder.TabIndex = 3;
            this.lvWholeOrder.UseCompatibleStateImageBehavior = false;
            this.lvWholeOrder.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "MenuName";
            this.columnHeader7.Width = 158;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "MenuType";
            this.columnHeader8.Width = 190;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "MenuSize";
            this.columnHeader9.Width = 170;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Price";
            this.columnHeader10.Width = 77;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "QTY";
            this.columnHeader12.Width = 93;
            // 
            // txtSearchWholeOrder
            // 
            this.txtSearchWholeOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchWholeOrder.Location = new System.Drawing.Point(62, 27);
            this.txtSearchWholeOrder.Name = "txtSearchWholeOrder";
            this.txtSearchWholeOrder.Size = new System.Drawing.Size(717, 22);
            this.txtSearchWholeOrder.TabIndex = 0;
            this.txtSearchWholeOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchWholeOrder_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Search";
            // 
            // btnVoidWO
            // 
            this.btnVoidWO.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoidWO.Location = new System.Drawing.Point(791, 328);
            this.btnVoidWO.Name = "btnVoidWO";
            this.btnVoidWO.Size = new System.Drawing.Size(92, 51);
            this.btnVoidWO.TabIndex = 4;
            this.btnVoidWO.Text = "&Void";
            this.btnVoidWO.UseVisualStyleBackColor = true;
            this.btnVoidWO.Click += new System.EventHandler(this.btnVoidWO_Click);
            // 
            // btnSearchWO
            // 
            this.btnSearchWO.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchWO.Location = new System.Drawing.Point(785, 13);
            this.btnSearchWO.Name = "btnSearchWO";
            this.btnSearchWO.Size = new System.Drawing.Size(92, 47);
            this.btnSearchWO.TabIndex = 1;
            this.btnSearchWO.Text = "&Search";
            this.btnSearchWO.UseVisualStyleBackColor = true;
            this.btnSearchWO.Click += new System.EventHandler(this.btnSearchWO_Click);
            // 
            // frmOrderHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 441);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmOrderHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order History";
            this.Load += new System.EventHandler(this.frmOrderHistory_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ListView lvOrderHist;
        private System.Windows.Forms.Button btnVoid;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnVoidWO;
        private System.Windows.Forms.Button btnSearchWO;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.TextBox txtSearchWholeOrder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvWholeOrder;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ListView lvOrderNum;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}