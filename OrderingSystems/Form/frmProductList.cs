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
    public partial class frmProductList : Form
    {
        int Qidx;
        public frmProductList(int qID)
        {
            Qidx = qID;
            InitializeComponent();
        }

        private void frmProductList_Load(object sender, EventArgs e)
        {
            LoadMenu();
        }

        private void LoadMenu(string mysql = "SELECT * FROM TBLMENU WHERE STATUS = 1 ORDER BY ID ASC")
        {
            DataSet ds = Database.LoadSQL(mysql, "tblMenu");

            lvmenu.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                
                MenuItem selectedmenu = new MenuItem();
                selectedmenu.LoadbyRows(dr);
                addMenu(selectedmenu);
            }
        }

       
        private void addMenu(MenuItem mitem)
        {
            if (mitem.MenuName == "")
            {
                return;
            }
            ListViewItem lvitm = lvmenu.Items.Add(mitem.MenuName.ToString());
            lvitm.SubItems.Add(mitem.MenuType.ToString());
            lvitm.SubItems.Add(mitem.MenuSize.ToString());
            lvitm.SubItems.Add(mitem.Price.ToString());

            lvitm.Tag = mitem.ID;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lvmenu.SelectedItems.Count == 0) { return; }

            int idx = Convert.ToInt32(lvmenu.SelectedItems[0].Tag);
            MenuItem sMenu = new MenuItem();
            sMenu.ID = idx;
            string tmpQty;

             tmpQty = Microsoft.VisualBasic.Interaction.InputBox("Quantity", "Enter Quantity", "0");

          //Saving to queue info
             //QueueLines ql = new QueueLines();
             //var with = ql;
             //with.QueueID = Qidx;
             //with.MenuID = sMenu.ID;
             //with.QTY = Convert.ToDouble(tmpQty);
             //with.saveQLines();

                    
            sMenu.Qty = Convert.ToInt32(tmpQty);
            sMenu.LoadMenuItem();

            if (Application.OpenForms["frmCasher"] != null)
            {
                (Application.OpenForms["frmCasher"] as frmCasher).AddMenuItem(sMenu);
                (Application.OpenForms["frmCasher"] as frmCasher).isNew=true;
            }

            this.Close();
        }

        private void lvmenu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e))
            {
                btnSelect.PerformClick();
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e)) {btnSearch.PerformClick();}
        }
    }
}
