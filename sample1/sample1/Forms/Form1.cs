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
    public partial class frmReservation : Form
    {
        string address;
       public bool isView;
        int custID;
        int venudID;
        public frmReservation()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string mysql = "SELECT * FROM CUSTOMERTBL WHERE FIRSTNAME ='" + txtCustomer.Text + "'";
            DataSet ds = Database.LoadSQL(mysql, "CUSTOMERTBL");

            if (ds.Tables[0].Rows.Count == 0) { return; }
            txtCustomer.Clear();
            custID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            txtCustomer.Text = ds.Tables[0].Rows[0]["firstname"].ToString() + " " + ds.Tables[0].Rows[0]["Lastname"].ToString();
            txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();

        }

        private void dtEndDate_Load(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            cboVenue.Items.AddRange(GetDistinct("Description"));
            if (rbCash.Checked)
            {
                lblPaidAtleast.Text = "00.0";
                txtPayment.Enabled = false;
                       lblStatus.Visible = true;
            }
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
            string mySql = "SELECT * from venuetbl where description ='" + cboVenue.Text +"'";
            DataSet ds = Database.LoadSQL(mySql);

            double rate = Convert.ToDouble(ds.Tables[0].Rows[0]["rate"]);
            venudID = Convert.ToInt32((ds.Tables[0].Rows[0]["ID"]));
            txtRate.Text =rate.ToString();
            Calculate();
        }

        private void rbInstallment_CheckedChanged(object sender, EventArgs e)
        {
            txtPayment.Enabled = true;
            if (txtRate.Text == "") { return; }

            double paidAtleast =  Convert.ToDouble(lblTotal.Text) * 0.5;
            lblPaidAtleast.Text = paidAtleast.ToString();
            lblBalance.Text = Convert.ToDouble(lblTotal.Text).ToString();
        }

        private void txtPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            mod_system.DigitOnly(e);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            DateTime d1 = Convert.ToDateTime(dtStartDate.Text);
            DateTime d2 = Convert.ToDateTime(dtEndDate.Text).AddDays(1);

            TimeSpan t = d2 - d1;
            double NrOfDays = t.TotalDays;
            NrOfDays = Convert.ToDouble(txtRate.Text) * NrOfDays;
            lblTotal.Text = NrOfDays.ToString();

            if (txtPayment.Text != "")
            {
                lblBalance.Text = (Convert.ToDouble(lblTotal.Text) - Convert.ToDouble(txtPayment.Text)).ToString();
            }
           
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            if (!isValid()) { return; }


            DialogResult result = MessageBox.Show("Do you want to post this transaction?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            reservation res = new reservation();
            res.venueID = venudID;
            res.CusID = custID;
            res.Transdate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            res.StartDate = Convert.ToDateTime(dtStartDate.Text);
            res.EndDate = Convert.ToDateTime(dtEndDate.Text);

            if (rbBoking.Checked)
            {
                res.Status = "Booked";
            }

            if (rbReservation.Checked)
            {
                res.Status = "Reserved";
            }
            if (rbReservation.Checked)
            {
                res.ForfeitDate = Convert.ToDateTime(DateTime.Now.AddDays(5));
            }
            else
            {
                res.ForfeitDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            }
            res.Total = Convert.ToDouble(lblTotal.Text);
            res.Balance = Convert.ToDouble(lblBalance.Text);
            res.Rate = Convert.ToDouble(txtRate.Text);

            if (rbCash.Checked)
            { res.mod = "Full Payment";}
            if (rbInstallment.Checked)
            { res.mod = "Installment"; }

            res.saveRes();

            bill bl = new bill();
            bl.resID = res.GetLastID();

            if (rbCash.Checked)
            {
                bl.Payment = Convert.ToDouble(lblTotal.Text);
            }
            if (rbInstallment.Checked)
            {
                bl.Payment = Convert.ToDouble(txtPayment.Text);
            }

            bl.tranSDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            bl.saveBill();
            MessageBox.Show("Transaction Posted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }

        private bool isValid()
        {

            bool isDatetimeStart_equal_dateTimeEnd = System.DateTime.Equals(Convert.ToDateTime(dtEndDate.Text), Convert.ToDateTime(dtStartDate.Text));

            if (isDatetimeStart_equal_dateTimeEnd)
            {
                MessageBox.Show("TIME START must not equal to TIME END.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int result = DateTime.Compare(Convert.ToDateTime(dtEndDate.Text).Date, Convert.ToDateTime(dtStartDate.Text).Date);

            if (txtCustomer.Text == "") { txtCustomer.Focus(); return false; }

            if (Convert.ToDateTime(dtStartDate.Text).Date > Convert.ToDateTime(dtEndDate.Text).Date)
            {
                MessageBox.Show("DATE TIME START must be greater than DATE TIME END.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (rbInstallment.Checked)
            {
                if (txtPayment.Text == "") { txtPayment.Focus(); return false; }
                if (Convert.ToDouble(txtPayment.Text) < Convert.ToDouble(lblPaidAtleast.Text))
                {
                    MessageBox.Show("You must pay atleast " + Convert.ToDouble(lblPaidAtleast.Text) + " .", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                if (Convert.ToDouble(txtPayment.Text) >= Convert.ToDouble(lblTotal.Text))
                {
                    MessageBox.Show("Select full payment to fully paid this transaction.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
          
            reservation rs = new reservation();
            if (rs.isHasReserved_or_Booked(Convert.ToDateTime(dtStartDate.Text)))
            {
                MessageBox.Show("This date has already reserved or booked by another client.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
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

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            if (rbInstallment.Checked)
            {
                if (txtPayment.Text == "") { return; }
                lblBalance.Text = (Convert.ToDouble(lblTotal.Text) - Convert.ToDouble(txtPayment.Text)).ToString();
            }
        }


        internal void loadtrans(reservation rs)
        {
          
            if (rs.Status == "CheckOut")
            {
                lblStatus.Visible = true;
            }

            if (rs.Status == "Booked")
            {
                rbBoking.Checked = false;
                lblStatus.Visible = false;
            }
            if (rs.Status == "Reserved")
            {
                rbReservation.Checked = false;
                lblStatus.Visible = false;
            }

            cboVenue.Text = getVenue(rs.venueID);

            txtCustomer.Text = GetFullName(rs.CusID);
            txtAddress.Text = address;
            dtStartDate.Text = rs.StartDate.ToString();
            dtEndDate.Text = rs.EndDate.ToString();
            txtRate.Text = rs.Rate.ToString();
            if (rs.mod == "Full Payment")
            {
                rbCash.Checked = true;
            }
            if (rs.mod == "Installment")
            {
                rbCash.Checked = true;
            }

            lblBalance.Text = rs.Balance.ToString();
            lblTotal.Text = rs.Total.ToString();
        }

        private string GetFullName(int idx)
        {
            string mysql = "select * from customertbl where ID = " + idx + "";
            DataSet ds = Database.LoadSQL(mysql, "customertbl");

            address = ds.Tables[0].Rows[0]["address"].ToString();
            return ds.Tables[0].Rows[0]["Firstname"].ToString() + " " + ds.Tables[0].Rows[0]["Lastname"].ToString();
        }

        private string getVenue(int idx)
        {
            string mysql = "SELECT * FROM VENUETBL WHERE ID =" + idx + "";
            DataSet ds = Database.LoadSQL(mysql, "VENUETBL");
            return ds.Tables[0].Rows[0]["Description"].ToString();
        }

    }
}
