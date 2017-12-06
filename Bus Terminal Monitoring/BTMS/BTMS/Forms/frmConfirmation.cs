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
    public partial class frmConfirmation : Form
    {
        string st;
        int busTransID;
        public frmConfirmation()
        {
            InitializeComponent();
        }

        private void frmConfirmation_Load(object sender, EventArgs e)
        {
            LoadbusList();
        }

        private void LoadbusList(string mysql = "SELECT * FROM buslisttransaction where status = 'W'")
        {
            
            DataSet ds = Database.LoadSQL(mysql, "tblbus");
            if (ds.Tables[0].Rows.Count == 0) { return; }

            DataRow dr = ds.Tables[0].Rows[0];
            var with = dr;

            busTransID = Convert.ToInt32(with["ID"]);
            txtbusNo.Text = with["Busno"].ToString();
            txtBusType.Text = with["Type"].ToString();

            buspersonnel dri = new buspersonnel();
            dri.Loadpersonnel(Convert.ToInt32(with["Driverno"]));
            txtDriver.Text = dri.Fname + " " + dri.Lname;
            buspersonnel con = new buspersonnel();
            con.Loadpersonnel(Convert.ToInt32(with["CondoctorID"]));
            txtCondoctor.Text = con.Fname + " " + con.Lname;

            busRoute br = new busRoute();
            br.LoadbusRoute(Convert.ToInt32(with["busID"]));
            txtFrom.Text = br.From;
            txtTo.Text = br.Dest;

            int seat = Convert.ToInt32(with["Seat"]);
            int availSeat = Convert.ToInt32(with["AvailableSeat"]);
            int CountPass = seat - availSeat;
           txtpassenger.Text= CountPass.ToString();

           if (with["Status"].ToString() == "W")
           {
              rbwaiting.Checked = true;
           }
           if (with["Status"].ToString() == "T")
           {
               rbTraveling.Checked = true;
           }
           if (with["Status"].ToString() == "A")
           {
               rbArrived.Checked = true;
           }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtbusNo.Text == "") { txtbusNo.Focus(); return; }
            if (txtBusType.Text == "") { txtBusType.Focus(); return; }
            if (txtDriver.Text == "") { txtDriver.Focus(); return; }
            if (txtFrom.Text == "") { txtFrom.Focus(); return; }
            if (txtTo.Text == "") { txtTo.Focus(); return; }


            if (rbTraveling.Checked==false)
            {
                if (rbArrived.Checked == false)
                {
                    MessageBox.Show("Please select Travel or Arrived status to confirm?", "Notification", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (rbArrived.Checked == false)
            {
                if (rbTraveling.Checked == false)
                {
                    MessageBox.Show("Please select Travel or Arrived status to confirm?", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            DialogResult result = MessageBox.Show("Do you want to proceed ?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            if (rbTraveling.Checked)
            {
                st="T";
            }
            if (rbArrived.Checked)
            {
                st = "A";
            }
            busTransaction bt = new busTransaction();
            bt.ID = busTransID;
            bt.Status = st;
            bt.ConfirmBusTravel();

            MessageBox.Show("Transaction successfully saved.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            txtbusNo.Clear(); txtBusType.Clear(); txtDriver.Clear(); txtFrom.Clear();
            txtCondoctor.Clear(); txtTo.Clear(); txtpassenger.Clear();
            rbArrived.Checked = false; rbTraveling.Checked = false; rbwaiting.Checked = false;

            string mysql = "SELECT * from buslisttransaction WHERE BUSNO ='" + txtSearch.Text + "' and status ='T'";
            DataSet ds = Database.LoadSQL(mysql, "TBLBUS");
            if (ds.Tables[0].Rows.Count == 0)
            { return; }

            DataRow dr = ds.Tables[0].Rows[0];
            var with = dr;


            busTransID = Convert.ToInt32(with["ID"]);
            txtbusNo.Text = with["Busno"].ToString();
            txtBusType.Text = with["Type"].ToString();

            buspersonnel dri = new buspersonnel();
            dri.Loadpersonnel(Convert.ToInt32(with["Driverno"]));
            txtDriver.Text = dri.Fname + " " + dri.Lname;
            buspersonnel con = new buspersonnel();
            con.Loadpersonnel(Convert.ToInt32(with["CondoctorID"]));
            txtCondoctor.Text = con.Fname + " " + con.Lname;

            busRoute br = new busRoute();
            br.LoadbusRoute(Convert.ToInt32(with["busID"]));
            txtFrom.Text = br.From;
            txtTo.Text = br.Dest;

            int seat = Convert.ToInt32(with["Seat"]);
            int availSeat = Convert.ToInt32(with["AvailableSeat"]);
            int CountPass = seat - availSeat;
            txtpassenger.Text = CountPass.ToString();

            if (with["Status"].ToString() == "T")
            {
                rbTraveling.Checked = true;
            }
            if (with["Status"].ToString() == "A")
            {
                rbArrived.Checked = true;
            }

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e))
            {
                btnSearch.PerformClick();
            }
        }

    }
}
