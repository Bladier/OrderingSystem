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
        }

        private void LoadTransaction(string mysql = "select top 50 * from reservationtbl")
        {
            DataSet ds = Database.LoadSQL(mysql, "reservationtbl");
            if (ds.Tables[0].Rows.Count == 0) { return; }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int cusID = Convert.ToInt32(dr["customerID"]);
                int vID = Convert.ToInt32(dr["venueID"]);
                ListViewItem lv = lvTransList.Items.Add(dr["TransDate"].ToString());
                lv.SubItems.Add(getFullName(cusID));
                lv.SubItems.Add(getVenue(vID));
                lv.SubItems.Add(dr["Total"].ToString());
                lv.SubItems.Add(Convert.ToDateTime(dr["StartDate"]).ToShortDateString());
                lv.SubItems.Add(Convert.ToDateTime(dr["EndDate"]).ToShortDateString());

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

            if (Application.OpenForms["frmSettings"] != null)
            {
                (Application.OpenForms["frmSettings"] as frmReservation).loadtrans(rs);
            }

            {
                frmReservation frm = new frmReservation();
                frm.Show();
                frm.isView = true;
                frm.loadtrans(rs);
            }


        }
    }
    }
