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
    public partial class frmBusListTransaction : Form
    {
        string busStatus;
   
        public frmBusListTransaction()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text == "") { LoadbusList(); return; }

            string mysql = "SELECT * FROM tblbus WHERE PlateNo LIKE '%" + txtsearch.Text + "%' OR ";
            mysql += " Type like '%" + txtsearch.Text + "%' OR BusNo like '%" + txtsearch.Text + "%' and status <>'C'";

            LoadbusList(mysql);
        }


        private void LoadbusList(string mysql = "SELECT * FROM buslisttransaction where status <> 'C' ORDER BY ID ASC LIMIT 20")
        {

            DataSet ds = Database.LoadSQL(mysql, "tblbus");
            if (ds.Tables[0].Rows.Count == 0) { lvbusList.Items.Clear(); return; }

            lvbusList.Items.Clear();
            foreach (DataRow itm in ds.Tables[0].Rows)
            {
                ListViewItem lv = lvbusList.Items.Add(itm["Busno"].ToString());
                lv.SubItems.Add(itm["Type"].ToString());
                int seat = Convert.ToInt32(itm["Seat"]);
                int availSeat = Convert.ToInt32(itm["AvailableSeat"]);
                int CountPass = seat - availSeat;
                lv.SubItems.Add(CountPass.ToString());
                lv.SubItems.Add(itm["PlateNo"].ToString());

              
                if (itm["Status"].ToString()=="W")
                {
                    busStatus = "Waiting";
                }
                  if (itm["Status"].ToString()=="C")
                  {
                      busStatus = "Cance;";
                  }
                  if (itm["Status"].ToString()=="T")
                  {
                      busStatus = "Traveled";
                  }

                  lv.SubItems.Add(busStatus.ToString());

                  buspersonnel Driver = new buspersonnel();
                  Driver.Loadpersonnel(Convert.ToInt32(itm["DriverNo"]));
                  lv.SubItems.Add(Driver.Fname + " " + Driver.Lname);

                  buspersonnel Con = new buspersonnel();
                  Con.Loadpersonnel(Convert.ToInt32(itm["CondoctorID"]));
                  lv.SubItems.Add(Con.Fname + " " + Con.Lname);

                  lv.Tag = itm["ID"];//Tag to bus transaction
            }
        }

        private void frmBusListTransaction_Load(object sender, EventArgs e)
        {
            LoadbusList();
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (lvbusList.SelectedItems.Count == 0) { return; }

            DialogResult result = MessageBox.Show("Do you want to void this ?", "Voiding", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            busTransaction bt = new busTransaction();
            bt.ID = Convert.ToInt32(lvbusList.SelectedItems[0].Tag);
            bt.VoidTransction();

            string mysql="SELECT * FROM tbltransaction WHERE BusTransID = " + bt.ID +" and status <> 0";
           DataSet ds =Database.LoadSQL(mysql,"tbltransaction");

           foreach (DataRow itm in ds.Tables[0].Rows)
           {
               Transaction t = new Transaction();
               t.ID = Convert.ToInt32(itm["ID"]);
               t.VoidTrans();

               Credit c = new Credit();
               c.PID =Convert.ToInt32(itm["PassID"]);
               c.Refund(Convert.ToDouble(itm["Rate"]));
           }

           MessageBox.Show("Bus transaction successfully voided.","Voiding",MessageBoxButtons.OK);
           this.Close();
        }

        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e)) { btnSearch.PerformClick(); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
