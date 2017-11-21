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

            bm.SaveBusmngt();

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
            driverID = bp.ID;
            txtDriver.Text = bp.Fname + " " + bp.Lname;
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
                drivers = txtCondoctor.Text;
                frmPersonnelList frm = new frmPersonnelList();
                frm.Show();
            }
        }
    }

}