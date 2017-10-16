using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OrderingSystems
{
    public partial class frmConsole : Form
    {
        MenuItem tmpMenu;
        public frmConsole()
        {
            InitializeComponent();
        }

        private void frmConsole_Load(object sender, EventArgs e)
        {
            LoadMenu();
            LoadCategory();
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
            if (isValid() == false) { return; }
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

        private bool isValid()
        {
            if (cboCategory.Text == "") { return false; }
            if (txtName.Text == "") { return false; }
            if (txtPrice.Text == "") { return false; }

            return true ;
        }

    }
}
