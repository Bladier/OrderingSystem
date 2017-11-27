using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BTMS
{
    public partial class frmPersonnelList : Form
    {
        public frmPersonnelList()
        {
            //txtsearch.Text = driver;
            //if (driver != "") { txtsearch.Text = driver; }
            InitializeComponent();
        }

        private void frmPersonnelList_Load(object sender, EventArgs e)
        {
            txtsearch.Text = frmBusManagement.drivers;
            if (txtsearch.Text == "")
            {
                LoadPassenger();
            }
            else
            {
                btnSearch.PerformClick();
            }
        }

        private void lvPassList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadPassenger(string mysql = "SELECT * FROM tblbusperson ORDER BY personID ASC LIMIT 20")
        {

            DataSet ds = Database.LoadSQL(mysql, "tblbusperson");
            if (ds.Tables[0].Rows.Count == 0) { lvPassList.Items.Clear(); return; }

            lvPassList.Items.Clear();
            foreach (DataRow itm in ds.Tables[0].Rows)
            {
                buspersonnel ps = new buspersonnel();
                ps.Loadpersonnel(Convert.ToInt32(itm["personID"]));
                Addpassenger(ps);
            }
        }

        private void Addpassenger(buspersonnel bp)
        {
            ListViewItem lv = lvPassList.Items.Add(bp.Lname + "," + bp.Fname);
            lv.SubItems.Add(bp.BDay.ToShortDateString());
            lv.SubItems.Add(bp.Position);

            lv.Tag = bp.ID;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text == "") { LoadPassenger(); return; }

            string mysql = "SELECT * FROM tblbusperson WHERE FiName LIKE '%" + txtsearch.Text + "%' OR ";
            mysql += " LaName like '%" + txtsearch.Text + "%' or Position Like '%" + txtsearch.Text + "%'";

            LoadPassenger(mysql);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (lvPassList.SelectedItems.Count == 0) { return; }
            int idx = Convert.ToInt32(lvPassList.SelectedItems[0].Tag);

            buspersonnel bp = new buspersonnel();
            bp.Loadpersonnel(idx);

            if (Application.OpenForms["frmPersonnelRegistration"] != null)
            {
                (Application.OpenForms["frmPersonnelRegistration"] as frmPersonnelRegistration).addPass(bp);
            }
            else
            {
                frmPersonnelRegistration frm = new frmPersonnelRegistration();
                frm.Show();
                frm.addPass(bp);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            frmPersonnelRegistration frm = new frmPersonnelRegistration();
            frm.Show();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lvPassList.SelectedItems.Count == 0) { return; }
            int idx = Convert.ToInt32(lvPassList.SelectedItems[0].Tag);

            buspersonnel bp = new buspersonnel();
            bp.Loadpersonnel(idx);

            if (Application.OpenForms["frmBusManagement"] != null)
            {
                (Application.OpenForms["frmBusManagement"] as frmBusManagement).addDriver(bp);
            }
            else
            {
                frmBusManagement frm = new frmBusManagement();
                frm.Show();
                frm.addDriver(bp);
            }
            this.Close();
        }

        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e)) ;
            {
                btnSearch.PerformClick();
            }

        }

        private void lvPassList_DoubleClick(object sender, EventArgs e)
        {
            btnSelect.PerformClick();
        }

        private void lvPassList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e)){btnSelect.PerformClick();}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
