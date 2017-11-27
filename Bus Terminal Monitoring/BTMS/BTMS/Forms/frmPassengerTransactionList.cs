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
    public partial class frmPassengerTransactionList : Form
    {
        public DateTime datetoday;
        DataSet ds;
        string curdate;
        public frmPassengerTransactionList()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text == "") { LoadbusList(); return; }

            string mysql = "SELECT * FROM passengerTransaction WHERE RFIDNUM LIKE '%" + txtsearch.Text + "%' ";
            mysql += "  and status <>'0' and TransDate = '" + curdate + "'";
            ds.Clear();
            ds = Database.LoadSQL(mysql, "passengerTransaction");

            if (ds.Tables[0].Rows.Count == 0) { lvpasslist.Items.Clear(); return; }
            lvpasslist.Items.Clear();
            foreach (DataRow itm in ds.Tables[0].Rows)
            {
                DateTime d = Convert.ToDateTime(itm["TransDate"]);
                ListViewItem lv = lvpasslist.Items.Add(d.ToString("yyyy-MM-dd"));
                lv.SubItems.Add(itm["RFIDNUM"].ToString());
                lv.SubItems.Add(itm["Fname"] + " " + itm["lname"]);
                lv.SubItems.Add(itm["Busno"].ToString());
                lv.SubItems.Add(itm["From"] + "-" + itm["Destination"]);

                lv.Tag = itm["ID"];
            }
        }

        private void LoadbusList()
        {
            string mysql = "SELECT * FROM passengerTransaction where status <> '0' and TransDate = '" + curdate + "'";
            mysql += "  ORDER BY ID ASC LIMIT 40";
         
           ds = Database.LoadSQL(mysql, "passengerTransaction");
            if (ds.Tables[0].Rows.Count == 0) { lvpasslist.Items.Clear(); return; }

            lvpasslist.Items.Clear();
            foreach (DataRow itm in ds.Tables[0].Rows)
            {
                DateTime d = Convert.ToDateTime(itm["TransDate"]);
                ListViewItem lv = lvpasslist.Items.Add(d.ToString("yyyy-MM-dd"));
                lv.SubItems.Add(itm["RFIDNUM"].ToString());
                lv.SubItems.Add(itm["Fname"] + " " + itm["lname"]);
                lv.SubItems.Add(itm["Busno"].ToString());
                lv.SubItems.Add(itm["From"] + "-" + itm["Destination"]);
                lv.SubItems.Add(itm["CreditID"].ToString());
                lv.SubItems.Add(itm["Rate"].ToString());
                lv.Tag = itm["ID"];
            }
        }

        private void frmPassengerTransactionList_Load(object sender, EventArgs e)
        {
            datetoday = Convert.ToDateTime(mod_system.CurrentDate.ToShortDateString());
         curdate = datetoday.ToString("yyyy-MM-dd");

            LoadbusList();
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (lvpasslist.SelectedItems.Count == 0) { return; }

            DialogResult result = MessageBox.Show("Do you want to void this ?", "Voiding", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
          
            Transaction t = new Transaction();
            t.LoadTrans(Convert.ToInt32(lvpasslist.SelectedItems[0].Tag));
            t.VoidTrans();

            Credit c = new Credit();
            c.LoadCredit(t.Client.ID);
            double fare = Convert.ToDouble(t.TransRate);
            c.Refund(fare);

            MessageBox.Show("Bus transaction successfully voided.", "Voiding", MessageBoxButtons.OK);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
