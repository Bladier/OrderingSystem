namespace OrderingSystems
{
    partial class frmConsole
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cboStatusMenu = new System.Windows.Forms.ComboBox();
            this.btnSaveMenu = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lvMenu = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSaveMaintenance = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.lvMaintenance = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cboReciept = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboOrderNum = new System.Windows.Forms.ComboBox();
            this.btnSavePrinter = new System.Windows.Forms.Button();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(829, 425);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtQty);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.cboStatusMenu);
            this.tabPage1.Controls.Add(this.btnSaveMenu);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.cboCategory);
            this.tabPage1.Controls.Add(this.txtPrice);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtSize);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lvMenu);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(821, 399);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Menu Item";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cboStatusMenu
            // 
            this.cboStatusMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatusMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatusMenu.FormattingEnabled = true;
            this.cboStatusMenu.Items.AddRange(new object[] {
            "Active",
            "In Active"});
            this.cboStatusMenu.Location = new System.Drawing.Point(543, 60);
            this.cboStatusMenu.Name = "cboStatusMenu";
            this.cboStatusMenu.Size = new System.Drawing.Size(174, 28);
            this.cboStatusMenu.TabIndex = 13;
            // 
            // btnSaveMenu
            // 
            this.btnSaveMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveMenu.Location = new System.Drawing.Point(723, 35);
            this.btnSaveMenu.Name = "btnSaveMenu";
            this.btnSaveMenu.Size = new System.Drawing.Size(92, 50);
            this.btnSaveMenu.TabIndex = 12;
            this.btnSaveMenu.Text = "&Save";
            this.btnSaveMenu.UseVisualStyleBackColor = true;
            this.btnSaveMenu.Click += new System.EventHandler(this.btnSaveMenu_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(598, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Status";
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(107, 19);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(212, 28);
            this.cboCategory.TabIndex = 10;
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(385, 62);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(152, 26);
            this.txtPrice.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(329, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Price";
            // 
            // txtSize
            // 
            this.txtSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSize.Location = new System.Drawing.Point(385, 19);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(152, 26);
            this.txtSize.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(329, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Size";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(107, 62);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(212, 26);
            this.txtName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Category";
            // 
            // lvMenu
            // 
            this.lvMenu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvMenu.FullRowSelect = true;
            this.lvMenu.GridLines = true;
            this.lvMenu.Location = new System.Drawing.Point(6, 148);
            this.lvMenu.Name = "lvMenu";
            this.lvMenu.Size = new System.Drawing.Size(809, 245);
            this.lvMenu.TabIndex = 0;
            this.lvMenu.UseCompatibleStateImageBehavior = false;
            this.lvMenu.View = System.Windows.Forms.View.Details;
            this.lvMenu.DoubleClick += new System.EventHandler(this.lvMenu_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 38;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Category";
            this.columnHeader2.Width = 209;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 240;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Size";
            this.columnHeader4.Width = 124;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Price";
            this.columnHeader5.Width = 108;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Status";
            this.columnHeader6.Width = 92;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnSaveMaintenance);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtRemarks);
            this.tabPage2.Controls.Add(this.txtValue);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtKey);
            this.tabPage2.Controls.Add(this.lvMaintenance);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(821, 399);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Maintenance";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSaveMaintenance
            // 
            this.btnSaveMaintenance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveMaintenance.Location = new System.Drawing.Point(709, 31);
            this.btnSaveMaintenance.Name = "btnSaveMaintenance";
            this.btnSaveMaintenance.Size = new System.Drawing.Size(106, 62);
            this.btnSaveMaintenance.TabIndex = 7;
            this.btnSaveMaintenance.Text = "S&ave";
            this.btnSaveMaintenance.UseVisualStyleBackColor = true;
            this.btnSaveMaintenance.Click += new System.EventHandler(this.btnSaveMaintenance_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(296, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(375, 26);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(328, 76);
            this.txtRemarks.TabIndex = 5;
            // 
            // txtValue
            // 
            this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.Location = new System.Drawing.Point(84, 76);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(192, 26);
            this.txtValue.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 20);
            this.label7.TabIndex = 3;
            this.label7.Text = "Value";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Key";
            // 
            // txtKey
            // 
            this.txtKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKey.Location = new System.Drawing.Point(84, 26);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(192, 26);
            this.txtKey.TabIndex = 1;
            // 
            // lvMaintenance
            // 
            this.lvMaintenance.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lvMaintenance.FullRowSelect = true;
            this.lvMaintenance.GridLines = true;
            this.lvMaintenance.Location = new System.Drawing.Point(6, 118);
            this.lvMaintenance.Name = "lvMaintenance";
            this.lvMaintenance.Size = new System.Drawing.Size(809, 275);
            this.lvMaintenance.TabIndex = 0;
            this.lvMaintenance.UseCompatibleStateImageBehavior = false;
            this.lvMaintenance.View = System.Windows.Forms.View.Details;
            this.lvMaintenance.DoubleClick += new System.EventHandler(this.lvMaintenance_DoubleClick);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "ID";
            this.columnHeader7.Width = 44;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Key";
            this.columnHeader8.Width = 231;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Value";
            this.columnHeader9.Width = 315;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Remarks";
            this.columnHeader10.Width = 218;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cboReciept);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.cboOrderNum);
            this.tabPage3.Controls.Add(this.btnSavePrinter);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(821, 399);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Printer";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cboReciept
            // 
            this.cboReciept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReciept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReciept.FormattingEnabled = true;
            this.cboReciept.Location = new System.Drawing.Point(145, 99);
            this.cboReciept.Name = "cboReciept";
            this.cboReciept.Size = new System.Drawing.Size(218, 28);
            this.cboReciept.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 20);
            this.label10.TabIndex = 3;
            this.label10.Text = "Reciept";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "Order Number";
            // 
            // cboOrderNum
            // 
            this.cboOrderNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrderNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOrderNum.FormattingEnabled = true;
            this.cboOrderNum.Location = new System.Drawing.Point(145, 32);
            this.cboOrderNum.Name = "cboOrderNum";
            this.cboOrderNum.Size = new System.Drawing.Size(218, 28);
            this.cboOrderNum.TabIndex = 1;
            // 
            // btnSavePrinter
            // 
            this.btnSavePrinter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePrinter.Location = new System.Drawing.Point(411, 54);
            this.btnSavePrinter.Name = "btnSavePrinter";
            this.btnSavePrinter.Size = new System.Drawing.Size(124, 53);
            this.btnSavePrinter.TabIndex = 0;
            this.btnSavePrinter.Text = "&Save";
            this.btnSavePrinter.UseVisualStyleBackColor = true;
            this.btnSavePrinter.Click += new System.EventHandler(this.btnSavePrinter_Click);
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(107, 94);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(83, 26);
            this.txtQty.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 20);
            this.label11.TabIndex = 14;
            this.label11.Text = "Quantity";
            // 
            // frmConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 449);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmConsole";
            this.Text = "Form Console";
            this.Load += new System.EventHandler(this.frmConsole_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView lvMenu;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSaveMenu;
        private System.Windows.Forms.ComboBox cboStatusMenu;
        private System.Windows.Forms.ListView lvMaintenance;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button btnSaveMaintenance;
        private System.Windows.Forms.ComboBox cboReciept;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboOrderNum;
        private System.Windows.Forms.Button btnSavePrinter;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label11;
    }
}