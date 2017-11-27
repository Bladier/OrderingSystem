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
    public partial class frmBusList : Form
    {
        public bool isAddBusRoute;
        public frmBusList()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text == "") { LoadbusList(); return; }

            string mysql = "SELECT * FROM tblbus WHERE PlateNo LIKE '%" + txtsearch.Text + "%' OR ";
            mysql += " Type like '%" + txtsearch.Text + "%' OR BusNo like '%" + txtsearch.Text + "%' and status <>'UnAvailable'";

            LoadbusList(mysql);
        }

        private void frmBusList_Load(object sender, EventArgs e)
        {
            if (isAddBusRoute)
            {
                txtsearch.Text = frmSettings.BusNo;
            }
            else
            {
                txtsearch.Text = frmTransaction.plateNum;
            }
           

            if (txtsearch.Text == "")
            {
                LoadbusList();
            }
            else
            {
                btnSearch.PerformClick();
            }
        }

        private void LoadbusList(string mysql = "SELECT * FROM tblbus where status <> 'UnAvailable' ORDER BY BusID ASC LIMIT 20")
        {

            DataSet ds = Database.LoadSQL(mysql, "tblbus");
            if (ds.Tables[0].Rows.Count == 0) { lvbusList.Items.Clear(); return; }

            lvbusList.Items.Clear();
            foreach (DataRow itm in ds.Tables[0].Rows)
            {
                busManagement pm = new busManagement();
                pm.Loadbusmngt(Convert.ToInt32(itm["BusID"]));
                Addbuses(pm);
            }
        }

        private void Addbuses(busManagement bm)
        {
            ListViewItem lv = lvbusList.Items.Add(bm.BusType);
            lv.SubItems.Add(bm.NumSeat);
            lv.SubItems.Add(bm.PlateNumber);
            lv.SubItems.Add(bm.Status);
            lv.Tag = bm.ID;

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (lvbusList.SelectedItems.Count == 0) { return; }
            int idx = Convert.ToInt32(lvbusList.SelectedItems[0].Tag);

            busManagement bm = new busManagement();
            bm.Loadbusmngt(idx);

            if (Application.OpenForms["frmBusManagement"] != null)
            {
                (Application.OpenForms["frmBusManagement"] as frmBusManagement).addbus(bm);
            }
            else
            {
                frmBusManagement frm = new frmBusManagement();
                frm.Show();
                frm.addbus(bm);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            frmBusManagement frm = new frmBusManagement();
            frm.Show();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lvbusList.SelectedItems.Count == 0) { return; }
            int idx = Convert.ToInt32(lvbusList.SelectedItems[0].Tag);

            busManagement bp = new busManagement();
            bp.Loadbusmngt(idx);
            if (bp.Status == "UnAvailable")
            {
                MessageBox.Show("This is not available or is being repair.", "Notificatin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (isAddBusRoute)
            {
                if (Application.OpenForms["frmSettings"] != null)
                {
                    (Application.OpenForms["frmSettings"] as frmSettings).addbus(bp);
                }
                else
                {
                    frmSettings frm = new frmSettings();
                    frm.Show();
                    frm.addbus(bp);
                }
                goto goHere;
            }

            if (Application.OpenForms["frmSetBus"] != null)
            {
                (Application.OpenForms["frmSetBus"] as frmSetBus).addbus(bp);
            }
            else
            {
                frmSetBus frm = new frmSetBus();
                frm.Show();
                frm.addbus(bp);
            }
            goHere:
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvbusList_DoubleClick(object sender, EventArgs e)
        {
            btnSelect.PerformClick();
        }

        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e)) { btnSearch.PerformClick(); }
        }

        private void lvbusList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e)) { btnSelect.PerformClick(); }
        }
    }
}
