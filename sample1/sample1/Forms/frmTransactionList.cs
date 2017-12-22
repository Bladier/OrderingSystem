using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sample1
{
    public partial class frmTransactionList : Form
    {
        public frmTransactionList()
        {
            InitializeComponent();
        }

        private void frmTransactionList_Load(object sender, EventArgs e)
        {
            LoadTransaction();
            LoadReservation();
        }

        private void LoadTransaction(string mysql = "select top 50 * from Transactiontbl where status = 'Booked' and status <> 'Cancel' order by transdate desc")
        {
            DataSet ds = Database.LoadSQL(mysql, "Transactiontbl");
            if (ds.Tables[0].Rows.Count == 0) { return; }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int cusID = Convert.ToInt32(dr["customerID"]);
                int vID = Convert.ToInt32(dr["venueID"]);
                ListViewItem lv = lvTransList.Items.Add(Convert.ToDateTime(dr["TransDate"].ToString()).ToShortDateString());
                lv.SubItems.Add(getFullName(cusID));
                lv.SubItems.Add(getVenue(vID));
                lv.SubItems.Add(dr["Total"].ToString());
                lv.SubItems.Add(Convert.ToDateTime(dr["StartDate"]).ToShortDateString());
                lv.SubItems.Add(Convert.ToDateTime(dr["EndDate"]).ToShortDateString());
                lv.SubItems.Add(dr["Status"].ToString());

                lv.Tag = dr["ID"];
            }
        }

        private string getFullName(int ID)
        {
            string mysql = "SELECT * FROM CUSTOMERTBL WHERE ID ='" + ID + "'";
            DataSet ds = Database.LoadSQL(mysql, "Customertbl");

            return ds.Tables[0].Rows[0]["firstname"] + " " + ds.Tables[0].Rows[0]["firstname"];
        }

        private string getVenue(int ID)
        {
            string mysql = "SELECT * FROM venuetbl WHERE ID ='" + ID + "'";
            DataSet ds = Database.LoadSQL(mysql, "venuetbl");

            return ds.Tables[0].Rows[0]["description"].ToString();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lvTransList.SelectedItems.Count == 0) { return; }

            int idx = Convert.ToInt32(lvTransList.SelectedItems[0].Tag);

            transaction rs = new transaction();
            rs.loadTrans(idx);

            if (Application.OpenForms["frmBooking"] != null)
            {
                (Application.OpenForms["frmBooking"] as frmBooking).loadtrans(rs);
            }

            {
                frmBooking frm = new frmBooking();
                frm.Show();
                frm.isView = true;
                frm.loadtrans(rs);
            }
        }


        private void LoadReservation(string mysql = "select top 50 * from Transactiontbl where status = 'Reserved' and status <> 'Cancel' order by transdate desc")
        {
            DataSet ds = Database.LoadSQL(mysql, "Transactiontbl");
            if (ds.Tables[0].Rows.Count == 0) { return; }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int cusID = Convert.ToInt32(dr["customerID"]);
                int vID = Convert.ToInt32(dr["venueID"]);
                ListViewItem lv = lvReserved.Items.Add(Convert.ToDateTime(dr["TransDate"].ToString()).ToShortDateString());
                lv.SubItems.Add(getFullName(cusID));
                lv.SubItems.Add(getVenue(vID));
                lv.SubItems.Add(dr["Total"].ToString());
                lv.SubItems.Add(Convert.ToDateTime(dr["StartDate"]).ToShortDateString());
                lv.SubItems.Add(Convert.ToDateTime(dr["EndDate"]).ToShortDateString());
                lv.SubItems.Add(dr["Status"].ToString());

                lv.Tag = dr["ID"];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

  
    }
    }
