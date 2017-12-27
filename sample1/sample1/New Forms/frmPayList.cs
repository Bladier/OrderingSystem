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
    public partial class frmPayList : Form
    {
        double totalPayment=0;
        public frmPayList()
        {
            InitializeComponent();
        }

        private void frmPayList_Load(object sender, EventArgs e)
        {
            
        }

        internal void loadtrans(transaction tr)
        {
            Customer cus = new Customer();
            cus.LoadCust(tr.CusID);
            txtName.Text = cus.fullname;
            txtAddres.Text = cus.fulladdress;
            txtContactNumber.Text = cus.ContactNum;
            txtVenUe.Text = getVenue(tr.venueID);
            txtTotalDue.Text = tr.Total.ToString();
            txtBalance.Text = tr.Balance.ToString();

            string mysql = "select * from paymenttbl where transactionnum = " + tr.TransactionNum +"";
            DataSet ds = Database.LoadSQL(mysql,"paymenttbl");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                bill bl = new bill();
                bl.loadbill(Convert.ToInt32(dr["ID"]));
                addPaymentList(bl);
            }

            lblTotalPayment.Text = totalPayment.ToString();
        }

        private string getVenue(int ID)
        {
            string mysql = "SELECT * FROM venuetbl WHERE ID ='" + ID + "'";
            DataSet ds = Database.LoadSQL(mysql, "venuetbl");

            return ds.Tables[0].Rows[0]["description"].ToString();
        }

        private void addPaymentList(bill bl)
        {
            ListViewItem lv = lvPaymentList.Items.Add(Convert.ToDateTime(bl.tranSDate).ToShortDateString());
            lv.SubItems.Add(bl.Payment.ToString());
            totalPayment += bl.Payment;
        }
    }
}
