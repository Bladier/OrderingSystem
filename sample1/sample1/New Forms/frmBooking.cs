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
    public partial class frmBooking : Form
    {
        string address;
        public bool isView = false;
        int custID;
        int venudID;
        reservation tmpres;
        public frmBooking()
        {
            InitializeComponent();
        }

        private void frmBooking_Load(object sender, EventArgs e)
        {
            txtTransactionNum.Text = string.Format("00000{0}", GetTransNum());

            dtStartDate.Text = DateTime.Now.ToString("MMMM, dd yyyy hh:mm tt");
            dtEndDate.Text = DateTime.Now.ToString("MMMM, dd yyyy hh:mm tt");

            cboVenue.Items.AddRange(GetDistinct("Description"));
        }

        private int GetTransNum()
        {
            string mysql = "select * from maintenancetbl where Op_key ='TransactionNum'";
            DataSet ds = Database.LoadSQL(mysql, "maintenancetbl");

            return Convert.ToInt32(ds.Tables[0].Rows[0]["op_values"]);
        }

        private string[] GetDistinct(string col)
        {
            string mySql = "SELECT DISTINCT " + col + " FROM venuetbl WHERE " + col + " <> ''";
            DataSet ds = Database.LoadSQL(mySql);

            int MaxCount = ds.Tables[0].Rows.Count;
            string[] str = new string[MaxCount];
            for (int cnt = 0; cnt <= MaxCount - 1; cnt++)
            {
                string tmpStr = ds.Tables[0].Rows[cnt]["description"].ToString();
                str[cnt] = tmpStr;
            }

            return str;
        }

        private void cboVenue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVenue.Text == "") { txtRate.Clear(); return; }
            txtRate.Clear();
            string mySql = "SELECT * from venuetbl where description ='" + cboVenue.Text + "'";
            DataSet ds = Database.LoadSQL(mySql);

            double rate = Convert.ToDouble(ds.Tables[0].Rows[0]["rate"]);
            venudID = Convert.ToInt32((ds.Tables[0].Rows[0]["ID"]));
            txtRate.Text = rate.ToString();
            Calculate();
        }


        private void Calculate()
        {
            DateTime d1 = Convert.ToDateTime(dtStartDate.Text);
            DateTime d2 = Convert.ToDateTime(dtEndDate.Text).AddDays(1);

            TimeSpan t = d2 - d1;
            double NrOfDays = Math.Round(t.TotalDays);

            txtNoOfDays.Text = NrOfDays.ToString();
            NrOfDays = Convert.ToDouble(txtRate.Text) * NrOfDays;
            lblTotal.Text = NrOfDays.ToString();


            if (txtPayment.Text != "")
            {
                lblBalance.Text = (Convert.ToDouble(lblTotal.Text) - Convert.ToDouble(txtPayment.Text)).ToString();
            }

        }

        private void dtEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (cboVenue.Text == "") { return; }
            Calculate();
        }

        private void btnAvailability_Click(object sender, EventArgs e)
        {

        }

        private void rbCash_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCash.Checked)
            {
                lblPaidAtleast.Text = "00.0";
                txtPayment.Enabled = false;
                lblBalance.Text = "00.0";
                txtPayment.Text = "";
            }
        }

        private void rbInstallment_CheckedChanged(object sender, EventArgs e)
        {
            if (isView)
            {

            }
            else
            {
                txtPayment.Enabled = true;
                if (txtRate.Text == "") { return; }

                double paidAtleast = Convert.ToDouble(lblTotal.Text) * 0.5;
                lblPaidAtleast.Text = paidAtleast.ToString();
                lblBalance.Text = Convert.ToDouble(lblTotal.Text).ToString();
            }
        }

        private void btnPost_Click(object sender, EventArgs e)
        {

        }

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            if (isView)
            {
                if (txtPayment.Text == "")
                {
                    lblBalance.Text = tmpres.Balance.ToString();
                    return;
                }

                lblBalance.Text = Convert.ToDouble(GetBalance(tmpres.ID) - Convert.ToDouble(txtPayment.Text)).ToString();
                return;
            }
            else
            {
                if (rbInstallment.Checked)
                {
                    if (txtPayment.Text == "") { return; }
                    lblBalance.Text = (Convert.ToDouble(lblTotal.Text) - Convert.ToDouble(txtPayment.Text)).ToString();
                }
            }

        }

        private double GetBalance(int idx)
        {
            string mysql = "SELECT * FROM reservationtbl WHERE id = " + idx;
            DataSet ds = Database.LoadSQL(mysql, "reservationtbl");

            return Convert.ToDouble(ds.Tables[0].Rows[0]["Balance"]);
        }
    }
}
