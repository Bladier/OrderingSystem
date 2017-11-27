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
    public partial class frmPassengerList : Form
    {
        public frmPassengerList()
        {
            InitializeComponent();
        }

        private void frmPassengerList_Load(object sender, EventArgs e)
        {
            txtsearch.Text = frmTransaction.passCardNum;
            if (txtsearch.Text == "")
            {
                LoadPassenger();
            }
            else
            {
                btnSearch.PerformClick();
            }
        }

        private void LoadPassenger(string mysql = "SELECT * FROM TBLPASSENGER ORDER BY PASSID ASC LIMIT 20")
        {
            
            DataSet ds = Database.LoadSQL(mysql, "tblPassenger");
            if (ds.Tables[0].Rows.Count == 0) { lvPassList.Items.Clear(); return; }

            lvPassList.Items.Clear();
            foreach (DataRow itm in ds.Tables[0].Rows)
            {
                passenger ps = new passenger();
                ps.Loadpass(Convert.ToInt32(itm["PassID"]));
                Addpassenger(ps);
            }
        }

        private void Addpassenger(passenger pass)
        {
            ListViewItem lv = lvPassList.Items.Add(pass.RFIDnum.ToString());
            lv.SubItems.Add(pass.Lname + "," + pass.Fname);
            lv.SubItems.Add(pass.FullAddress);
            lv.SubItems.Add(pass.PassType);
            lv.SubItems.Add(pass.ContactNum.ToString());
            lv.Tag = pass.ID;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text == "") { LoadPassenger(); return; }

            string mysql = "SELECT * FROM TBLPASSENGER WHERE RFIDNUM LIKE '%" + txtsearch.Text + "%' OR ";
            mysql += " Fname like '%" + txtsearch.Text + "%' OR lname like '%" + txtsearch.Text + "%'";

            LoadPassenger(mysql);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (lvPassList.SelectedItems.Count == 0) { return; }
            int idx = Convert.ToInt32(lvPassList.SelectedItems[0].Tag);

            passenger ps = new passenger();
            ps.Loadpass(idx);

            if (Application.OpenForms["Form1"] != null)
            {
                (Application.OpenForms["Form1"] as Form1).addPass(ps);
            }
            else
            {
                Form1 frm = new Form1();
                frm.Show();
                frm.addPass(ps);
            }
           // this.Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }

        private void lvPassList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void btnSelect_Click(object sender, EventArgs e)
        //{
        //    if (lvPassList.SelectedItems.Count == 0) { return; }
        //    int idx = Convert.ToInt32(lvPassList.SelectedItems[0].Tag);

        //    passenger pass = new passenger();
        //    pass.Loadpass(idx);

        //    if (Application.OpenForms["frmTransaction"] != null)
        //    {
        //        (Application.OpenForms["frmTransaction"] as frmTransaction).addbus(pass);
        //    }
        //    else
        //    {
        //        frmTransaction frm = new frmTransaction();
        //        frm.Show();
        //        frm.addbus(pass);
        //    }
        //    this.Close();
        //}

        private void btnView_Click_1(object sender, EventArgs e)
        {
            if (lvPassList.SelectedItems.Count == 0) { return; }
            int idx = Convert.ToInt32(lvPassList.SelectedItems[0].Tag);

            passenger ps = new passenger();
            ps.Loadpass(idx);

            if (Application.OpenForms["Form1"] != null)
            {
                (Application.OpenForms["Form1"] as Form1).addPass(ps);
            }
            else
            {
                Form1 frm = new Form1();
                frm.Show();
                frm.addPass(ps);
            }
         //   this.Close();
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            if (txtsearch.Text == "") { LoadPassenger(); return; }

            string mysql = "SELECT * FROM TBLPASSENGER WHERE RFIDNUM LIKE '%" + txtsearch.Text + "%' OR ";
            mysql += " Fname like '%" + txtsearch.Text + "%' OR lname like '%" + txtsearch.Text + "%'";

            LoadPassenger(mysql);
        }

        private void lvPassList_DoubleClick(object sender, EventArgs e)
        {
            btnView.PerformClick();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (lvPassList.SelectedItems.Count == 0) { return; }
            int idx = Convert.ToInt32(lvPassList.SelectedItems[0].Tag);

            passenger ps = new passenger();
            ps.Loadpass(idx);

            if (Application.OpenForms["Form1"] != null)
            {
                (Application.OpenForms["Form1"] as Form1).isRenew = true;
                (Application.OpenForms["Form1"] as Form1).addPass(ps);
            }
            else
            {
                Form1 frm = new Form1();
                frm.Show();
                frm.isRenew = true;
                frm.addPass(ps);
            }
        }

        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e)) { btnSearch.PerformClick(); }
        }

        private void lvPassList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e)) { btnView.PerformClick(); }
        }

       
       
    }
}
