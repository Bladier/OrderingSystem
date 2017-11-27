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
    public partial class frmSettings : Form
    {
        int routeID;
        int bID;
        public static string BusNo;
        public frmSettings()
        {
            InitializeComponent();
        }

        internal void addbus(busManagement bm)
        {
            txtSearch.Text = bm.BusNo;
            bID = bm.ID;
        }

        private void searchbus()
        {
            string mysql = "SELECT * FROM tblbus WHERE busno = '" + txtBusno.Text + "' or plateno like '%" + txtBusno.Text + "%'";
            loadbus(mysql);
        }
        private void loadbus(string mysql = "SELECT * FROM tblbus")
        {
            DataSet ds = Database.LoadSQL(mysql, "tblbus");

            if (ds.Tables[0].Rows.Count == 0)
            {
                //MessageBox.Show("Card number found.", "Search", MessageBoxButtons.OK);
                lvbusroute.Items.Clear();
                return;
            }

            lvbusroute.Items.Clear();
            foreach (DataRow itm in ds.Tables[0].Rows)
            {
                busManagement bm = new busManagement();
                bm.Loadbusmngt(Convert.ToInt32(itm["busID"]));
                ListViewItem lv = lvbusroute.Items.Add(bm.BusNo.ToString());

                busRoute br = new busRoute();
                br.LoadbusRoute(Convert.ToInt32(itm["busID"]));

                lv.SubItems.Add(br.From.ToString());
                lv.SubItems.Add(br.Dest.ToString());
                lv.SubItems.Add(br.Rate.ToString());
                lv.Tag = itm["BusID"];
            }
        }

      
        private void txtBusno_TextChanged_1(object sender, EventArgs e)
        {
            searchbus();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (btnUpdate.Text == "&Add")
            {
                AddBusRoute();
            }
            if (btnUpdate.Text == "&Update")
            {
                updaterate();
            }
            btnUpdate.Text = "&Add";
        }

        private void AddBusRoute()
        {
            if (txtRate.Text == "") { txtRate.Focus(); return; }
            if (txtFrom.Text == "") { txtFrom.Focus(); return; }
            if (txtDest.Text == "") { txtDest.Focus(); return; }

              busRoute b = new busRoute();
              b.BusID = bID;
              if (b.isBusHasRoute())
              {
                  MessageBox.Show("This bus has already routed?", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  return;
              }

            DialogResult result = MessageBox.Show("Do you want to add this?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
          
            b.Rate = Convert.ToDouble(txtRate.Text);
            b.From = txtFrom.Text;
            b.Dest = txtDest.Text;
            b.BusID = bID;
            b.Updateroute();

            MessageBox.Show("Successfully added.", "Add", MessageBoxButtons.OK);
            txtBusno.Clear(); txtDest.Clear(); txtFrom.Clear(); txtRate.Clear(); txtBusno.Focus();
            loadbus();
        }
        private void lvbusroute_DoubleClick(object sender, EventArgs e)
        {
            int busID = Convert.ToInt32(lvbusroute.SelectedItems[0].Tag);
            busRoute br = new busRoute();
            br.LoadbusRoute(busID);
            txtFrom.Text = br.From;
            txtDest.Text = br.Dest;
            txtRate.Text = br.Rate.ToString();
            routeID = br.ID;
            bID = busID;
            btnUpdate.Text = "&Update";
        }

        private void updaterate()
        {
            if (txtRate.Text == "") { txtRate.Focus(); return; }
            if (txtFrom.Text == "") { txtFrom.Focus(); return; }
            if (txtDest.Text == "") { txtDest.Focus(); return; }

            DialogResult result = MessageBox.Show("Do you want to Update?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            busRoute b = new busRoute();
            b.Rate = Convert.ToDouble(txtRate.Text);
            b.ID = routeID;
            b.From = txtFrom.Text;
            b.Dest = txtDest.Text;
            b.BusID = bID;
            b.Updateroute();

            MessageBox.Show("Successfully updated.", "Update", MessageBoxButtons.OK);
            txtBusno.Clear(); txtDest.Clear(); txtFrom.Clear(); txtRate.Clear(); txtBusno.Focus();
            loadbus();
        }
    
       

        private void frmSettings_Load(object sender, EventArgs e)
        {
            loadbus();
        }

        private void btnsearchbus_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmBusList"] != null)
            {
                BusNo = txtSearch.Text;
                (Application.OpenForms["frmBusList"] as frmBusList).Show();
            }
            else
            {
                BusNo = txtSearch.Text;
                frmBusList frm = new frmBusList();
                frm.Show();
                frm.isAddBusRoute = true;
            }
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            mod_system.DigitOnly(e);
        }

      
    }
}
