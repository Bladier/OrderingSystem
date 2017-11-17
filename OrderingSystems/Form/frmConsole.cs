using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace OrderingSystems
{
    public partial class frmConsole : Form
    {
        MenuItem tmpMenu;
        Maintenance tmpMaintenance;
        public frmConsole()
        {
            InitializeComponent();
        }

        private void frmConsole_Load(object sender, EventArgs e)
        {
            LoadMenu();
            LoadCategory();
            LoadMaintenance();

            foreach (string tmpPrinterName in PrinterSettings.InstalledPrinters)
            {
                cboOrderNum.Items.Add(tmpPrinterName);
                cboReciept.Items.Add(tmpPrinterName);
            }
        }

        private void LoadCategory()
        {
            string mysql = "Select distinct(MenuName) From tblMenu";
            DataSet ds = Database.LoadSQL(mysql, "tblMenu");

            cboCategory.Items.Clear();
            foreach (DataRow  dr in ds.Tables[0].Rows )
            {
                cboCategory.Items.Add(dr[0].ToString());
            }
        }

        private void LoadMenu()
        {
            string mysql = "Select * From tblMenu";
            DataSet ds = Database.LoadSQL(mysql, "tblMenu");

            lvMenu.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                AddMenuItem(dr);   
            }
        }

        private void LoadMaintenance()
        {
            string mysql = "Select * From tblMaintenance";
            DataSet ds = Database.LoadSQL(mysql, "tblMaintenance");

            lvMaintenance.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                AddMaintenanceItem(dr);
            }
        }

        private void AddMenuItem(DataRow dr)
        {
            ListViewItem lv = lvMenu.Items.Add(dr["ID"].ToString());
            lv.SubItems.Add(dr["MenuName"].ToString());
            lv.SubItems.Add(dr["MenuType"].ToString());
            lv.SubItems.Add(dr["MenuSize"].ToString());
            lv.SubItems.Add(dr["Price"].ToString());
            string tmpStatus = dr["Status"].ToString();
            if (tmpStatus =="1")
            {
                lv.SubItems.Add("Active");
            }
            else 
            {
                lv.SubItems.Add("In Active");
            }
            
        }

        private void AddMaintenanceItem(DataRow dr)
        {
            ListViewItem lv = lvMaintenance.Items.Add(dr["ID"].ToString());
            lv.SubItems.Add(dr["M_Key"].ToString());
            lv.SubItems.Add(dr["M_Value"].ToString());
            lv.SubItems.Add(dr["Remarks"].ToString());
        }

        private void lvMenu_DoubleClick(object sender, EventArgs e)
        {
            if (lvMenu.SelectedItems.Count == 0) { return; }
            int idx = Convert.ToInt32(lvMenu.FocusedItem.Text.ToString());

            tmpMenu = new MenuItem();
            tmpMenu.ID = idx;
            tmpMenu.LoadMenuItem();

            cboCategory.Text = tmpMenu.MenuName;
            txtName.Text = tmpMenu.MenuType;
            txtSize.Text = tmpMenu.MenuSize;
            txtPrice.Text = Convert.ToString(tmpMenu.Price);
            if (tmpMenu.Status == "1")
            {
                cboStatusMenu.Text = "Active";
            }
            else
            {
                cboStatusMenu.Text = "In Active";
            }
            cboCategory.Enabled = false;
            txtName.Enabled = false;
            txtSize.Enabled = false;
            btnSaveMenu.Text = "&Update";
        
        }

        private void btnSaveMenu_Click(object sender, EventArgs e)
        {
            if (btnSaveMenu.Text == "&Update")
            {
                tmpMenu.Price = Convert.ToDouble(txtPrice.Text);
                if (cboStatusMenu.Text == "Active")
                {
                    tmpMenu.Status = "1";
                }
                else
                {
                    tmpMenu.Status = "0";
                }
                tmpMenu.SaveMenu();
            }
            else
            {
                if (isValidMenu() == false) { return; }

                tmpMenu = new MenuItem();
                tmpMenu.MenuName = cboCategory.Text;
                tmpMenu.MenuType = txtName.Text;
                tmpMenu.MenuSize = txtSize.Text;
                tmpMenu.Price = Convert.ToDouble(txtPrice.Text);
                if (cboStatusMenu.Text == "Active")
                {
                    tmpMenu.Status = "1";
                }
                else
                {
                    tmpMenu.Status = "0";
                }
                tmpMenu.SaveMenu();
            }

            MessageBox.Show("Data Save");
            LoadMenu();
        }

        private bool isValidMenu()
        {
            if (cboCategory.Text == "") { return false; }
            if (txtName.Text == "") { return false; }
            if (txtPrice.Text == "") { return false; }

            return true ;
        }

        private bool isValidMaintenance()
        {
            if (txtKey.Text == "") { return false; }
            if (txtValue.Text == "") { return false; }

            return true;
        }


        private void lvMaintenance_DoubleClick(object sender, EventArgs e)
        {
            if (lvMaintenance.SelectedItems.Count == 0) { return; }
            int idx = Convert.ToInt32(lvMaintenance.FocusedItem.Text.ToString());


            tmpMaintenance = new Maintenance();
            
            tmpMaintenance.ID = idx;
            tmpMaintenance.LoadMaintenance();

            txtKey.Text = tmpMaintenance.MaintenanceKey;
            txtValue.Text = tmpMaintenance.MaintenanceValue;
            txtRemarks.Text = tmpMaintenance.Remarks ;

            txtKey.Enabled = false;
            btnSaveMaintenance.Text = "&Update";
        }

        private void btnSaveMaintenance_Click(object sender, EventArgs e)
        {
            if (btnSaveMaintenance.Text == "&Update")
            {
                tmpMaintenance.MaintenanceValue = txtValue.Text;
                tmpMaintenance.Remarks = txtRemarks.Text;
                tmpMaintenance.SaveMaintenance();

            }
            else 
            {
                if (isValidMaintenance() == false) { return; }
                tmpMaintenance = new Maintenance();
                var with = tmpMaintenance;
                with.MaintenanceKey = txtKey.Text;
                with.MaintenanceValue = txtValue.Text;
                with.Remarks = txtRemarks.Text;
                with.SaveMaintenance();
            }
            MessageBox.Show("Data Save");
            LoadMaintenance();
        }

        private void btnSavePrinter_Click(object sender, EventArgs e)
        {
            tmpMaintenance = new Maintenance();
            var with = tmpMaintenance;
            with.UpdateOption("PrinterOrder",cboOrderNum.Text);
            with.UpdateOption("PrinterReciept",cboReciept.Text);

            MessageBox.Show("Printer Set","Information");
        }

    }
}
