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
            txtBusno.Clear(); txtDest.Clear(); txtFrom.Clear(); txtRate.Clear(); txtBusno.Focus(); txtSearch.Clear();
            loadbus();
        }
        private void lvbusroute_DoubleClick(object sender, EventArgs e)
        {
            int busID = Convert.ToInt32(lvbusroute.SelectedItems[0].Tag);
            busRoute br = new busRoute();
            br.LoadbusRoute(busID);

            busManagement bm = new busManagement();
            bm.Loadbusmngt(busID);
            txtSearch.Text = bm.BusNo;

            if (br.From == null)
            {
                goto gohere;
            }

            txtFrom.Text = br.From;
            txtDest.Text = br.Dest;
            txtRate.Text = br.Rate.ToString();
            routeID = br.ID;

gohere:
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
            txtBusno.Clear(); txtDest.Clear(); txtFrom.Clear(); txtRate.Clear(); txtBusno.Focus(); txtSearch.Clear();
            loadbus();
        }
    
       

        private void frmSettings_Load(object sender, EventArgs e)
        {
            loadbus();
            busType();
        }

        private void busType()
        {
            string mysql = "SELECT * FROM TBLBUSTYPE ORDER BY ID ASC";
            DataSet ds = Database.LoadSQL(mysql, "TblbusType");
            if (ds.Tables[0].Rows.Count == 0)
            {
                return;
            }
            lvBusType.Items.Clear();
            foreach (DataRow itm in ds.Tables[0].Rows)
            {
                ListViewItem lv = lvBusType.Items.Add(itm["BusType"].ToString());
                lv.Tag = itm["ID"];
            }

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddBusType_Click(object sender, EventArgs e)
        {
            if (txtAddBusType.Text == "") { txtAddBusType.Focus(); return; }

            if (btnAddBusType.Text == "&Add")
            {

                DialogResult result = MessageBox.Show("Do you want to save it?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }

                string mySql = "Select * From " + "tblbusType";
                DataSet ds = Database.LoadSQL(mySql, "tblbusType");
                DataRow dsNewRow = null;
                dsNewRow = ds.Tables[0].NewRow();
                var _with2 = dsNewRow;
                _with2["BusType"] = txtAddBusType.Text;
                ds.Tables[0].Rows.Add(dsNewRow);
                Database.SaveEntry(ds);
                goto gohere;
            }
            else
            {
                DialogResult result = MessageBox.Show("Do you want to update it?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }

                string mySql = "Select * From " + "tblbusType" + " where ID ='" + Convert.ToInt32(lvBusType.SelectedItems[0].Tag) + "'";
                DataSet ds = Database.LoadSQL(mySql, "tblbusType");

                if (ds.Tables[0].Rows.Count == 1)
                {
                    var _with2 = ds.Tables["tblbusType"].Rows[0];
                    _with2["BusType"] = txtAddBusType.Text;

                    Database.SaveEntry(ds, false);
                }
                else
                {
                    DataRow dsNewRow = null;
                    dsNewRow = ds.Tables[0].NewRow();
                    var _with2 = dsNewRow;
                    _with2["BusType"] = txtAddBusType.Text;
                    ds.Tables[0].Rows.Add(dsNewRow);
                    Database.SaveEntry(ds);

                }
            }
gohere:
            if (btnAddBusType.Text == "&Add")
            {
                MessageBox.Show("Successfully added.", "add", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Successfully updated.", "Update", MessageBoxButtons.OK);

            }
            txtAddBusType.Clear();
            busType();
        }

        private void btnCancelAddbusType_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvBusType_DoubleClick(object sender, EventArgs e)
        {
            if (lvBusType.SelectedItems.Count == 0)
            {
                return;
            }
            txtAddBusType.Text = lvBusType.SelectedItems[0].Text;
            btnAddBusType.Text = "&Update";
        }

      
    }
}
