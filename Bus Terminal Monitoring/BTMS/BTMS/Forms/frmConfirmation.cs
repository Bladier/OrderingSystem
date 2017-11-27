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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtbusNo.Text == "") { return; }
            if (txtBusType.Text == "") { return; }
            if (txtDriver.Text == "") { return; }

            DialogResult result = MessageBox.Show("Do you want to proceed ?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            busTransaction bt = new busTransaction();
            bt.ID = busTransID;
            bt.ConfirmBusTravel();

            MessageBox.Show("Transaction successfully saved.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Close();
        }

    }
}
