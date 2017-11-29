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

        private passenger tmpPassenger;
        private busManagement tmpBus;
        private busTransaction tmpBusTrans;

        int counter = 0;
        public frmTransaction()
        {
            InitializeComponent();
        }

        private void frmTransaction_Load(object sender, EventArgs e)
        {
            txtCardNum.Focus();
         
            string mysql  ="SELECT * FROM TBLBUSTRANSACTION WHERE STATUS ='W'";
            DataSet ds = Database.LoadSQL(mysql, "TBLBUSTRANSACTION");
            if (ds.Tables[0].Rows.Count == 0) { return; }

            busTransaction bt = new busTransaction();
            bt.LoadTrans( Convert.ToInt16(ds.Tables[0].Rows[0]["ID"]));
            tmpBusTrans = bt;
                        
            busManagement buslist = new busManagement();
            buslist.Loadbusmngt(Convert.ToInt16(ds.Tables[0].Rows[0]["BUSID"]));
            addbus(buslist);
        }


        internal void addbus(busManagement bm)
        {
            txtbusNo.Text = bm.BusNo;
            txtPlateNum.Text = bm.PlateNumber;
            txtBusType.Text = bm.BusType;

            buspersonnel bp = new buspersonnel();
            bp.Loadpersonnel(bm.Driver);
         

            txtDriver.Text = bp.Fname + " " + bp.Lname;

            buspersonnel bpCondoctor = new buspersonnel();
            bpCondoctor.Loadpersonnel(bm.Condoctor);
            txtCondoctor.Text = bpCondoctor.Fname + " " + bpCondoctor.Lname;

           tmpBus = bm;
            busRoute br = new busRoute();
            br.LoadbusRoute(bm.ID);
            txtFrom.Text = br.From;
            txtTo.Text = br.Dest;
            txtRate.Text = br.Rate.ToString();

            ///calc();
        }

        internal void addbus(passenger pas)
        {
            txtCardNum.Text = pas.RFIDnum.ToString();
            //txtPassenger.Text = pas.Fname + " " + pas.Lname;
            //txtContactnum.Text = pas.ContactNum.ToString();
            //txtAddress.Text = pas.FullAddress;
            //txtPassType.Text = pas.PassType;

            tmpPassenger = pas;
            calc();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (Application.OpenForms["frmBusList"] != null)
        //    {
        //         plateNum = txtPlateNum.Text;
        //        (Application.OpenForms["frmBusList"] as frmBusList).Show();
        //    }
        //    else
        //    {
        //        plateNum = txtPlateNum.Text;
        //        frmBusList frm = new frmBusList();
        //        frm.Show();
        //    }
        //}

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            mod_system.DigitOnly(e);
        }

        private void calc()
        {
            if (txtBusType.Text == "") { return; }

            if (tmpPassenger.PassType == "") { return; }
          
            if (tmpPassenger.PassType == "Senior")
            {
                double discount = 0.06;
                discount = Convert.ToDouble(txtRate.Text) * discount;
                lblDiscount.Text = discount.ToString();
                discount = Convert.ToDouble(txtRate.Text) - discount;
                lblAmountDue.Text = discount.ToString();
            }


            if (tmpPassenger.PassType == "Student")
            {
                double discount = 0.06;
                discount = Convert.ToDouble(txtRate.Text) * discount;
                lblDiscount.Text = discount.ToString();
                discount = Convert.ToDouble(txtRate.Text) - discount;
                lblAmountDue.Text = discount.ToString();
            }

            if (tmpPassenger.PassType == "Regular")
            {
                lblAmountDue.Text = txtRate.Text;
            }
        }

        //private void btnCancel_Click(object sender, EventArgs e)
        //{
        //    clearfield();
        //}

        private void clearfield()
        {
            txtCardNum.Clear();
            //txtPassenger.Clear();
            //txtContactnum.Clear();
            //txtAddress.Clear();
            //txtPassType.Clear();
           
            lblAmountDue.Text = "0.00";
            
            lblDiscount.Text = "0.00";
            txtCardNum.Focus();
           
        }

        private void SaveTransaction()
        {
            if (txtPlateNum.Text == "") { txtPlateNum.Focus(); return; }
            if (txtCardNum.Text == "") { txtCardNum.Focus(); return; }
            if (txtCardNum.Text.Length != 10)
            {
                label15.Text = "Invalid Card Number. Error";
                return;
            }

            Transaction trans = new Transaction();

            trans.BusTransID = tmpBusTrans;
            if (trans.IsTag(tmpPassenger.ID))
            {
                label14.Text = "You Are already Tag in this bus!";
                clearfield();
                return;
            }

            trans.TransDate = Convert.ToDateTime(mod_system.CurrentDate.ToString("yyyy-MM-dd"));
            trans.Client = tmpPassenger;
            trans.Bus = tmpBus;
            trans.TransRate = Convert.ToDouble(lblAmountDue.Text);
            trans.TransDiscount = Convert.ToDouble(lblDiscount.Text);
            trans.Remarks = "";
       
            trans.SaveTrans();


            Credit cr = new Credit();
            cr.UpdateCredit(Convert.ToDouble(lblAmountDue.Text), tmpPassenger.ID);

            busTransaction bt = new busTransaction();
            bt.Bus = tmpBus;
            bt.ID = tmpBusTrans.ID;
            bt.DeductSeat(1);

            label14.Visible = true;
            label14.Text= "You are successfully tag in this bus";

            clearfield();
        }

        private void searchCardNum()
        {
            string mysql = "SELECT * FROM TBLPASSENGER WHERE RFIDNUM = '" + txtCardNum.Text  + "'";
            DataSet ds = Database.LoadSQL(mysql, "TBLPASSENGER");

            if (ds.Tables[0].Rows.Count == 0)
            {
                label14.Text = "This card number is not registered!";
                //txtCardNum.Clear();
                //txtPassenger.Clear();
                //txtContactnum.Clear();
                //txtAddress.Clear();
                //txtPassType.Clear();
                return;
            }
            passenger ps = new passenger();
            ps.Loadpass(Convert.ToInt32(ds.Tables[0].Rows[0]["PassID"]));
            addbus(ps);

            Credit cd = new Credit();
            cd.LoadCredit(ps.ID);

            if (txtRate.Text == "") { return; }
            if (tmpPassenger.PassType == "Senior")
            {
                double discount = 0.06;
                discount = Convert.ToDouble(txtRate.Text) * discount;
                lblDiscount.Text = discount.ToString();
                discount = Convert.ToDouble(txtRate.Text) - discount;
                lblAmountDue.Text = discount.ToString();
            }

            if (tmpPassenger.PassType == "Student")
            {
                double discount = 0.06;
                discount = Convert.ToDouble(txtRate.Text) * discount;
                lblDiscount.Text = discount.ToString();
                discount = Convert.ToDouble(txtRate.Text) - discount;
                lblAmountDue.Text = discount.ToString();
            }
            if (tmpPassenger.PassType == "Regular")
            {
                lblAmountDue.Text = txtRate.Text;
            }
        }

        private void txtCardNum_Leave(object sender, EventArgs e)
        {
            if (txtCardNum.Text == "") { return; }
            if (txtCardNum.Text.Length != 10) { return; }
            searchCardNum();
            System.Threading.Thread.Sleep(1000);
            SaveTransaction();

        }

        private void txtCardNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            mod_system.DigitOnly(e);
            {
            if (txtCardNum.Text == "") { return; }
            if (txtCardNum.Text.Length != 10) { return; }
            searchCardNum();
            }
          
        }

        private void txtCardNum_TextChanged(object sender, EventArgs e)
        {
            if (txtCardNum.Text == "") {return; }
            if (txtCardNum.Text.Length != 10) { return; }
            searchCardNum();
            System.Threading.Thread.Sleep(1000);
            SaveTransaction();
        }

        private void tmpTimer_Tick(object sender, EventArgs e)
        {
            lblDate.Text = Convert.ToString(mod_system.CurrentDate.ToLongDateString());
        }
    }
}
