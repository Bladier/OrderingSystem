using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace BTMS
{
    public partial class frmBusManagement : Form
    {
        int driverID;
        int condoctorID;
        int busmgtID;
        string BusType;
        public static string drivers = "";
        public static bool isDriver;
        public static bool isCondoctor;

        public frmBusManagement()
        {
            InitializeComponent();
        }

        private void frmBusManagement_Load(object sender, EventArgs e)
        {
            cboBusType.Items.AddRange(GetDistinct("BusType"));
        }

        private string[] GetDistinct(string col)
        {
            string mySql = "SELECT DISTINCT " + col + " FROM tblbusType WHERE " + col + " <> ''";
            DataSet ds = Database.LoadSQL(mySql);

            int MaxCount = ds.Tables[0].Rows.Count;
            string[] str = new string[MaxCount];
            for (int cnt = 0; cnt <= MaxCount - 1; cnt++)
            {
                string tmpStr = ds.Tables[0].Rows[cnt]["BusType"].ToString();
                str[cnt]= tmpStr;
            }

            return str;
        }

        internal void Disbled(bool st = false)
        {
            txtPlateNumber.Enabled = st;
            txtNumSeats.Enabled = st;
            txtDriver.Enabled = st;
            cboBusType.Enabled = st;
            txtCondoctor.Enabled = st;
            txtBusNo.Enabled = st;
            rbAvailable.Enabled = st;
            rbUnavailable.Enabled = st;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "&Modify")
            {
                btnSave.Text = "&Update";
                Disbled(true);
                return;
            }
            if (btnSave.Text == "&Save")
            {
                savebusinfo();
            }
            else
            {
                Updatebusinfo();
            }
        }

        private void savebusinfo()
        {
            if (cboBusType.Text == "")
            {
                cboBusType.Focus();
                return;
            }
            if (txtNumSeats.Text == "")
            {
                txtNumSeats.Focus();
                return;
            }
            if (txtPlateNumber.Text == "") { txtPlateNumber.Focus(); return; }
            if (txtDriver.Text == "") { txtDriver.Focus(); return; }
            if (txtCondoctor.Text == "") { txtCondoctor.Focus(); return; }
            if (txtBusNo.Text == "") { txtBusNo.Focus(); return; }

            busManagement busmngt = new busManagement();
            busmngt.BusNo = txtBusNo.Text;
            busmngt.IsBusAdded();
            if (busmngt.isadded)
            {
                MessageBox.Show("Bus number already exists.", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Do you want to save this?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            busManagement bm = new busManagement();
            bm.BusType = cboBusType.Text;
            bm.NumSeat = txtNumSeats.Text;
            bm.PlateNumber = txtPlateNumber.Text;
            if (rbAvailable.Checked)
            {
                bm.Status = "Available";
            }

            if (rbUnavailable.Checked)
            {
                bm.Status = "UnAvailable";
            }
      
            bm.Driver = driverID;
            bm.Condoctor = condoctorID;
            bm.BusNo = txtBusNo.Text;
            bm.SaveBusmngt();

            MessageBox.Show("Successfully saved.", "Confirmation", MessageBoxButtons.OK);
            clearfield();
        }

        private void Updatebusinfo()
        {
            if (cboBusType.Text == "")
            {
                cboBusType.Focus();
                return;
            }
            if (txtNumSeats.Text == "")
            {
                txtNumSeats.Focus();
                return;
            }
            if (txtPlateNumber.Text == "") { txtPlateNumber.Focus(); return; }
            if (txtDriver.Text == "") { txtDriver.Focus(); return; }
            if (txtCondoctor.Text == "") { txtCondoctor.Focus(); return; }
            if (txtBusNo.Text == "") { txtBusNo.Focus(); return; }
            

            DialogResult result = MessageBox.Show("Do you want to update this?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            busManagement bm = new busManagement();
            bm.ID = busmgtID;
            bm.BusType = cboBusType.Text;
            bm.NumSeat = txtNumSeats.Text;
            bm.PlateNumber = txtPlateNumber.Text;
            if (rbAvailable.Checked)
            {
                bm.Status = "Available";
            }

            if (rbUnavailable.Checked)
            {
                bm.Status = "UnAvailable";
            }
            bm.Driver = driverID;
            bm.Condoctor = condoctorID;
            bm.BusNo = txtBusNo.Text;
            bm.UpdateBusMngnt();

            MessageBox.Show("Successfully updated.", "Confirmation", MessageBoxButtons.OK);
            clearfield();
        }

        private void clearfield()
        {
            cboBusType.Text = "";
            txtDriver.Clear();
            txtNumSeats.Clear();
            txtPlateNumber.Clear();
            busmgtID = 0;
            txtCondoctor.Clear();
            condoctorID = 0;
            txtBusNo.Clear();
            cboBusType.SelectedItem = null;
            mod_system.isAddBus = false;
        }

        internal void addbus(busManagement bm)
        {
            busmgtID = bm.ID;
            cboBusType.Text = bm.BusType;
            txtNumSeats.Text = bm.NumSeat;
            txtPlateNumber.Text = bm.PlateNumber;
            if (bm.Status == "Available")
            {
                rbAvailable.Checked = true;
            }
            if (bm.Status == "UnAvailable")
            {
                rbUnavailable.Checked= true;
            }

            buspersonnel bpDriver = new buspersonnel();
            bpDriver.Loadpersonnel(bm.Driver);
            txtBusNo.Text = bm.BusNo;

            txtDriver.Text = bpDriver.Fname + " " + bpDriver.Lname;

            buspersonnel bpCon = new buspersonnel();
            bpCon.Loadpersonnel(bm.Condoctor);

            txtCondoctor.Text = bpCon.Fname + " " + bpCon.Lname;

            condoctorID = bm.Condoctor;
            driverID = bm.Driver;

            Disbled();
            btnSave.Text = "&Modify";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            mod_system.isAddBus = true;
            if (Application.OpenForms["frmPersonnelList"] != null)
            {
                // (Application.OpenForms["frmPersonnelList"] as frmPersonnelList;
            }
            else
            {
                isDriver = true;
                isCondoctor = false;
                drivers = txtDriver.Text;
                frmPersonnelList frm = new frmPersonnelList();
                frm.isInspector = true;
                frm.Show();
            }
        }

        private void txtNumSeats_KeyPress(object sender, KeyPressEventArgs e)
        {
            mod_system.DigitOnly(e);
        }

        internal void addDriver(buspersonnel bp)
        {
            if (bp.Position=="Driver")
            {
             driverID = bp.ID;
            txtDriver.Text = bp.Fname + " " + bp.Lname;
            }

            if (bp.Position == "Condoctor")
            {
                condoctorID = bp.ID;
                txtCondoctor.Text = bp.Fname + " " + bp.Lname;
            }
        }

        private void txtDriver_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e))
            {
                btnSearch.PerformClick();
            }

        }

        private void btnsearchCondoctor_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmPersonnelList"] != null)
            {
                // (Application.OpenForms["frmPersonnelList"] as frmPersonnelList;
            }
            else
            {
                isCondoctor = true;
                isDriver = false;
                drivers = txtCondoctor.Text;
                frmPersonnelList frm = new frmPersonnelList();
                frm.isInspector = true;
                frm.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BusType = Interaction.InputBox("Enter Bus Type", "Bus Type", "");

            string mySql = "Select * From " + "tblbusType" + " where BusType ='" + BusType + "'";
            DataSet ds = Database.LoadSQL(mySql, "tblbusType");

            if (ds.Tables[0].Rows.Count == 1)
            {
                MessageBox.Show("Bus Type Already Exists.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (BusType == "")
            { return; }

            DialogResult result = MessageBox.Show("Do you want to save it?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            DataRow dsNewRow = null;
            dsNewRow = ds.Tables[0].NewRow();
            var _with2 = dsNewRow;
            _with2["BusType"] = BusType;
            ds.Tables[0].Rows.Add(dsNewRow);
            Database.SaveEntry(ds);
            cboBusType.Items.Add(BusType);
            cboBusType.Text = BusType;
        }
    }

}