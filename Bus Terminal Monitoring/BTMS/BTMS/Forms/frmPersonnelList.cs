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

        private void LoadPassenger()
        {
            string mysql = "SELECT * FROM tblbusperson WHERE ISASSIGNED <> 1 ";
               if (frmBusManagement.isDriver)
                 {
                     mysql += " and Position ='Driver'";
                 }

                 if (frmBusManagement.isCondoctor)
                 {
                     mysql += " and Position ='Condoctor'";
                 }
                 mysql += " ORDER BY personID ASC LIMIT 40";

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
            string secured_str = txtsearch.Text;
		    secured_str = mod_system.DreadKnight(secured_str);
		    string str = txtsearch.Text;
            string[] strWords = str.Split(new char[] { ' ' });
            string name = null;

            string mysql = "SELECT * FROM TBLBUSPERSON WHERE POSITION LIKE '%" + txtsearch.Text + "%' OR (";
                 foreach (string name_loopVariable in strWords)
            {
                name = name_loopVariable;
                mysql += " CONCAT(FINAME, ',', LANAME) LIKE UPPER('%" + name + "%') OR ";
                if (object.ReferenceEquals(name, strWords.Last()))
                {
                    mysql += " CONCAT(FINAME, ',', LANAME) LIKE UPPER('%" + name + "%')) ";
                    break;
                }
            }

                 if (frmBusManagement.isDriver)
                 {
                     mysql += " and Position ='Driver'";
                 }

                 if (frmBusManagement.isCondoctor)
                 {
                     mysql += " and Position ='Condoctor'";
                 }

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

            if (bp.Position == "Driver")
            {
                if (bp.IsAssigned)
                {
                    MessageBox.Show("This driver was already assigned.", "Notification",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (bp.Position == "Condoctor")
            {
                if (bp.IsAssigned)
                {
                    MessageBox.Show("This condoctor was already assigned.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

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
