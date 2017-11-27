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
    public partial class frmBusManagement : Form
    {
        int driverID;
        int condoctorID;
        int busmgtID;
        public static string drivers = "";
        public static bool isDriver;
        public static bool isCondoctor;

        public frmBusManagement()
        {
            InitializeComponent();
        }

        private void frmBusManagement_Load(object sender, EventArgs e)
        {

        }

        internal void Disbled(bool st = false)
        {
            txtPlateNumber.Enabled = st;
            txtNumSeats.Enabled = st;
            txtDriver.Enabled = st;
            cboBusType.Enabled = st;
            txtCondoctor.Enabled = st;
            txtBusNo.Enabled = st;
            cboStatus.Enabled = st;
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
            if (cboStatus.Text == "") { cboStatus.Focus(); return; }
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

            bm.Status = cboStatus.Text;
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
            if (cboStatus.Text == "") { cboStatus.Focus(); return; }
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
            bm.Status = cboStatus.Text;
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
        }

        internal void addbus(busManagement bm)
        {
            busmgtID = bm.ID;
            cboBusType.Text = bm.BusType;
            txtNumSeats.Text = bm.NumSeat;
            txtPlateNumber.Text = bm.PlateNumber;
            cboStatus.Text = bm.Status;

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
            if (Application.OpenForms["frmPersonnelList"] != null)
            {
                // (Application.OpenForms["frmPersonnelList"] as frmPersonnelList;
            }
            else
            {
                isDriver = true;
                drivers = txtDriver.Text;
                frmPersonnelList frm = new frmPersonnelList();
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
                drivers = txtCondoctor.Text;
                frmPersonnelList frm = new frmPersonnelList();
                frm.Show();
            }
        }
    }

}