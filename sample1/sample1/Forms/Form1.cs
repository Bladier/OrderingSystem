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
        public bool isView=false;
        int custID;
        int venudID;
        transaction tmpres;
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
            dtStartDate.Text = DateTime.Now.ToString("MMMM, dd yyyy hh:mm tt");
            dtEndDate.Text = DateTime.Now.ToString("MMMM, dd yyyy hh:mm tt");

            //if (rbCash.Checked)
            //{
            //    lblPaidAtleast.Text = "00.0";
            //    lblStatus.Visible = true;
            //}

            lblStatus.Visible = false;
            cboVenue.Items.AddRange(GetDistinct("Description"));
          
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

        private void txtPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            mod_system.DigitOnly(e);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (cboVenue.Text == "") { return; }
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

        private void btnPost_Click(object sender, EventArgs e)
        {
          if (btnPost.Text =="&Post")
          {
              SaveTrans();
              return;
          }
          if (btnPost.Text == "&Edit")
          {
              if (tmpres.Balance != 0.0)
              {
                  rbBoking.Enabled = true;
                  rbReservation.Enabled = true;
                  txtPayment.Enabled = true;
              }

              btnPost.Text = "&Update";
              groupBox1.Enabled = true;
              return;
          }
          if (btnPost.Text == "&Update")
          {
              UpdateTrans();
          }

        }

        private void SaveTrans()
        {
            if (!isValid()) { return; }


            DialogResult result = MessageBox.Show("Do you want to post this transaction?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            transaction res = new transaction();
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

            //if (rbReservation.Checked)
            //{
            //    res.ForfeitDate = Convert.ToDateTime(DateTime.Now.AddDays(5));
            //}
            //else
            //{
            //    res.ForfeitDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //}

            res.Total = Convert.ToDouble(lblTotal.Text);
            res.Balance = Convert.ToDouble(lblBalance.Text);
            res.Rate = Convert.ToDouble(txtRate.Text);

            if (rbCash.Checked)
            { res.mod = "Full Payment"; }
            if (rbInstallment.Checked)
            { res.mod = "Installment"; }

            res.saveTrans();

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


        private void UpdateTrans()
        {
            if (!isValid()){ return; }

            transaction res = new transaction();

            //if (tmpres.Balance == 0.0)
            //{
            //    DialogResult result = MessageBox.Show("This transaction is ready for checkOut. Do you want to continue?", "Confirmation", MessageBoxButtons.YesNo);
            //    if (result == DialogResult.No)
            //    {
            //        return;
            //    }

            //    res.ID = tmpres.ID;
            //    res.Status = "CheckOut";
            //    res.CheckOut();
            //    return;
            //}

            DialogResult result1 = MessageBox.Show("Do you want to update this transaction?", "Confirmation", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.No)
            {
                return;
            }

            res.ID = tmpres.ID;
            if (rbBoking.Checked)
            {
                res.Status = "Booked";
            }

            if (rbReservation.Checked)
            {
                res.Status = "Reserved";
            }
            
            res.Balance = Convert.ToDouble(lblBalance.Text);
            res.UpdateTrans();

            bill bl = new bill();
            bl.resID = tmpres.ID;

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

            MessageBox.Show("Transaction updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private bool isValid()
        {
            if (isView)
            {
                if (tmpres.Balance != 0.0)
                {
                    if (txtPayment.Text == "") { txtPayment.Focus(); return false; }
                    if (Convert.ToDouble(txtPayment.Text) > Convert.ToDouble(tmpres.Balance))
                    {
                        MessageBox.Show("The balance is: " + tmpres.Balance + " only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPayment.Clear(); 
                        return false;
                    }
                }
                if (txtPayment.Text == "") { txtPayment.Focus(); return false; }
              
            }
            else
            {
                if (cboVenue.Text == "") { return false; }
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

                transaction rs = new transaction();
                if (rs.isHasReserved_or_Booked(Convert.ToDateTime(dtStartDate.Text)))
                {
                    MessageBox.Show("This date has already reserved or booked by another client.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
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
            if (isView)
            {
                if (txtPayment.Text == "") 
                {
                    lblBalance.Text = tmpres.Balance.ToString();
                    return; }

                lblBalance.Text = Convert.ToDouble(GetBalance(tmpres.ID)- Convert.ToDouble(txtPayment.Text)).ToString();
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


        internal void loadtrans(transaction rs)
        {
            lblStatus.Visible = true;
            if (rs.Balance == 0.0)
            {
                rbBoking.Enabled = false;
                rbBoking.Checked = false;
                rbReservation.Checked = false;
                if (rs.Status == "CheckOut")
                {
                    lblStatus.Visible = true;
                    lblStatus.Text = "CheckOut";
                }

                if (rs.Status == "Booked")
                {
                    rbBoking.Text = "Booked";
                    lblStatus.Text = "Booked";
                    rbBoking.Checked = true;
                }
                if (rs.Status == "Reserved")
                {
                    rbReservation.Text = "Reserved";
                    rbReservation.Checked = true;
                    lblStatus.Text = "Reserved";
                }

            }
            else
            {
                if (rs.Status == "CheckOut")
                {
                    lblStatus.Visible = true;
                    lblStatus.Text = "CheckOut";
                }

                if (rs.Status == "Booked")
                {
                    rbBoking.Text = "Booked";
                    lblStatus.Text = "Booked";
                    rbBoking.Checked = true;
                }
                if (rs.Status == "Reserved")
                {
                    rbReservation.Text = "Reserved";
                    rbReservation.Checked = true;
                    lblStatus.Text = "Reserved";
                }
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
              rbInstallment.Checked = true;
            }

            lblBalance.Text = rs.Balance.ToString();
            lblTotal.Text = rs.Total.ToString();

            tmpres = rs;
            DisAbledFields();
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

        private void DisAbledFields(bool st = false)
        {
            rbBoking.Enabled = st;
            rbReservation.Enabled = st;
            cboVenue.Enabled = st;
            txtCustomer.Enabled = false;
            txtAddress.Enabled = false;
            dtStartDate.Enabled = false;
            dtEndDate.Enabled = false;
            btnSearch.Enabled = st;
            groupBox1.Enabled = st;
            rbInstallment.Enabled = st;
            rbCash.Enabled = st;

            btnPost.Text = "&Edit";
        }

        private double GetBalance(int idx)
        {
            string mysql = "SELECT * FROM reservationtbl WHERE id = " + idx;
            DataSet ds = Database.LoadSQL(mysql, "reservationtbl");

            return Convert.ToDouble(ds.Tables[0].Rows[0]["Balance"]);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnAvailability_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmSchedule"] != null)
            {
              
            }

            {
                frmSchedule frm = new frmSchedule();
                frm.Show();
            }
        }

       
    }
}
