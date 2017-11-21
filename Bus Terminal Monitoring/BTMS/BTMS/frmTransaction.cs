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
    public partial class frmTransaction : Form
    {
        public static string plateNum = "";
        public static string passCardNum = "";
        public static bool isTransaction = false;
        public frmTransaction()
        {
            InitializeComponent();
        }

        private void frmTransaction_Load(object sender, EventArgs e)
        {
            txtCardNum.Focus();
        }


        internal void addbus(busManagement bm)
        {
            txtPlateNum.Text = bm.PlateNumber;
            txtBusType.Text = bm.BusType;

            buspersonnel bp = new buspersonnel();
            bp.Loadpersonnel(bm.Driver);


            txtDriver.Text = bp.Fname + " " + bp.Lname;

            busRoute br = new busRoute();
            br.LoadbusRoute(bm.ID);
            txtFrom.Text = br.From;
            txtTo.Text = br.Dest;
            txtRate.Text = br.Rate.ToString();
        }

        internal void addbus(passenger pas)
        {
            txtCardNum.Text = pas.RFIDnum.ToString();
            txtPassenger.Text = pas.Fname + " " + pas.Lname;
            txtContactnum.Text = pas.ContactNum.ToString();
            txtAddress.Text = pas.FullAddress;
            txtPassType.Text = pas.PassType;

            calc();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmBusList"] != null)
            {
                 plateNum = txtPlateNum.Text;
                (Application.OpenForms["frmBusList"] as frmBusList).Show();
            }
            else
            {
                plateNum = txtPlateNum.Text;
                frmBusList frm = new frmBusList();
                frm.Show();
            }
        }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            mod_system.DigitOnly(e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["frmPassengerList"] != null)
            {
                isTransaction = true;
                passCardNum = txtCardNum.Text;
            }
            else
            {
                isTransaction = true;
                passCardNum = txtCardNum.Text;
                frmPassengerList frm = new frmPassengerList();
                frm.Show();
            }
        }

        private void txtPassType_TextChanged(object sender, EventArgs e)
        {
            calc();
        }

        private void calc()
        {
            if (txtPassType.Text== "") { return; }
            if (txtPassType.Text == "Senior")
            {
                double discount = 0.06;
                discount = Convert.ToDouble(txtRate.Text) * discount;
                lblDiscount.Text = discount.ToString();
                discount = Convert.ToDouble(txtRate.Text) - discount;
                lblAmountDue.Text = discount.ToString();
            }

            if (txtPassType.Text == "Student")
            {
                double discount = 0.06;
                discount = Convert.ToDouble(txtRate.Text) * discount;
                lblDiscount.Text = discount.ToString();
                discount = Convert.ToDouble(txtRate.Text) - discount;
                lblAmountDue.Text = discount.ToString();
            }

            if (txtPassType.Text == "Regular")
            {
                lblAmountDue.Text = txtRate.Text;
            }
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            double change = 0.0;
            if (txtCash.Text == "") {lblChange.Text ="0.00"; return; }
            change = Convert.ToDouble(txtCash.Text) - Convert.ToDouble(lblAmountDue.Text);
            lblChange.Text = change.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearfield();
        }

        private void clearfield()
        {
            txtPlateNum.Clear();
            txtBusType.Clear();
            txtFrom.Clear();
            txtTo.Clear();
            txtRate.Clear();

            txtCardNum.Clear();
            txtPassenger.Clear();
            txtContactnum.Clear();
            txtAddress.Clear();
            txtPassType.Clear();
            txtCash.Clear();
            lblAmountDue.Text = "0.00";
            lblChange.Text = "0.00";
            lblDiscount.Text = "0.00";
            txtCondoctor.Clear();
            txtDriver.Clear();
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            clearfield();
        }
    }
}
