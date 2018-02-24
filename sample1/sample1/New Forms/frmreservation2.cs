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
    public partial class frmreservation2 : Form
    {
        string address;
        public bool isView = false;
        int custID;
        int venudID;
        transaction tmpres;
        Customer tmpcus;
        public frmreservation2()
        {
            InitializeComponent();
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            if (btnPost.Text == "&Post")
            {
                SaveTrans();
                return;
            }
            if (btnPost.Text == "&Edit")
            {
          
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

            transaction trans = new transaction();
            trans.venueID = venudID;
            trans.CusID = custID;
            trans.Transdate = Convert.ToDateTime(mod_system.CurrentDate.ToShortDateString());
            //trans.Transdate = Convert.ToDateTime(mod_system.CurrentDate.ToShortDateString());
            trans.StartDate = Convert.ToDateTime(dtStartDate.Text);
            trans.EndDate = Convert.ToDateTime(dtEndDate.Text);
            trans.Status = "Reserved";

            trans.Total = Convert.ToDouble(lblTotal.Text);
            trans.Balance = Convert.ToDouble(lblBalance.Text);
            trans.Rate = Convert.ToDouble(txtRate.Text);

            if (rbCash.Checked)
            { trans.mod = "Full Payment"; }
            if (rbInstallment.Checked)
            { trans.mod = "Installment"; }
            trans.TransactionNum = Convert.ToInt32(txtTransactionNum.Text);
            trans.comments = txtcomments.Text;
            trans.saveTrans();

            reservation res = new reservation();
            res.venueID = venudID;
            res.CusID = custID;
            res.Transdate = Convert.ToDateTime(mod_system.CurrentDate.ToShortDateString());
           // res.Transdate = Convert.ToDateTime(mod_system.CurrentDate.ToShortDateString());
            res.StartDate = Convert.ToDateTime(dtStartDate.Text);
            res.EndDate = Convert.ToDateTime(dtEndDate.Text);

            res.Status = "Reserved";
            res.ForfeitDate = Convert.ToDateTime(res.StartDate.AddDays(5));
          
            res.Total = Convert.ToDouble(lblTotal.Text);
            res.Balance = Convert.ToDouble(lblBalance.Text);
            res.Rate = Convert.ToDouble(txtRate.Text);

            if (rbCash.Checked)
            { res.mod = "Full Payment"; }
            if (rbInstallment.Checked)
            { res.mod = "Installment"; }

            res.TransactionNum = Convert.ToInt32(txtTransactionNum.Text);
            res.saveRes();

            bill bl = new bill();
            bl.resID = trans.GetLastID();

            if (rbCash.Checked)
            {
                bl.Payment = Convert.ToDouble(lblTotal.Text);
            }
            if (rbInstallment.Checked)
            {
                bl.Payment = Convert.ToDouble(txtPayment.Text);
            }

            bl.tranSDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            bl.TransNum =Convert.ToInt32(txtTransactionNum.Text);
            bl.saveBill();

            int transNum = Convert.ToInt32(txtTransactionNum.Text) + 1;
            mod_system.UpdateOptions("TransactionNum", transNum.ToString());
            printtransaction(bl.resID);
            MessageBox.Show("Transaction Posted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
        }

        private void UpdateTrans()
        {
            if (!isValid()) { return; }

            transaction trans = new transaction();

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

            trans.ID = tmpres.ID;
            trans.Status = "Booked";
            trans.Balance = Convert.ToDouble(lblBalance.Text);
            trans.UpdateTrans();

            reservation res = new reservation();
            res.TransactionNum = Convert.ToInt32(txtTransactionNum.Text);
            res.Status = "Confirmed";
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

            bl.tranSDate = Convert.ToDateTime(mod_system.CurrentDate.ToShortDateString());
            bl.TransNum = Convert.ToInt32(txtTransactionNum.Text);
            bl.saveBill();

            printtransaction(bl.resID);
            MessageBox.Show("Transaction updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
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


                //reservation rs = new reservation();
                //if (rs.isHasReserved(Convert.ToDateTime(dtStartDate.Text)))
                //{
                //    MessageBox.Show("Selected date is already reserved by another client.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return false;
                //}

                transaction tr = new transaction();
                if (tr.isHasReserved_or_Booked(Convert.ToDateTime(dtStartDate.Text)))
                {
                    MessageBox.Show("Selected date is already booked by another client.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                transaction tr1 = new transaction();
                if (tr1.isHasReserved_or_Booked(Convert.ToDateTime(dtEndDate.Text)))
                {
                    MessageBox.Show("Selected date is already booked by another client.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                transaction tr2 = new transaction();
                if (tr2.isExists(Convert.ToDateTime(dtStartDate.Text)))
                {
                    MessageBox.Show("Selected date is already booked by another client.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

            }

            return true;
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
            if (isView) 
            {
                
                return;
            }

            DateTime d1 = Convert.ToDateTime(dtStartDate.Text);
            DateTime d2 = Convert.ToDateTime(dtEndDate.Text).AddDays(1);

            TimeSpan t = d2 - d1;
            double NrOfDays = Math.Round(t.TotalDays);

            if (NrOfDays >= 2)
            {
                NrOfDays = NrOfDays - 1;

                if (d2.ToString("tt") == "AM")
                {
                    NrOfDays = NrOfDays + 0.5;
                }
                else
                {
                    NrOfDays = NrOfDays + 1;
                }

            }

            else
            {
                if (d2.ToString("tt") == "AM")
                {
                    NrOfDays = NrOfDays / 2;
                }
            }
            /////////////////
                //TimeSpan TS = d2 - d1;
                //int hour = TS.Hours;
                //int mins = TS.Minutes;

                //if (hour <= 4)
                //{
                //    if (mins == 0)
                //    {
                //        NrOfDays = NrOfDays / 2;
                //    } 
                //}
              
         ////////////////////
             
            txtNoOfDays.Text = NrOfDays.ToString();
            NrOfDays = Convert.ToDouble(txtRate.Text) * NrOfDays;
            lblTotal.Text = NrOfDays.ToString();


            if (txtPayment.Text != "")
            {
                lblBalance.Text = (Convert.ToDouble(lblTotal.Text) - Convert.ToDouble(txtPayment.Text)).ToString();
            }

            if (cboVenue.Text != "")
            {
                txtPayment.Enabled = true;
                if (txtRate.Text == "") { return; }

                if (rbInstallment.Checked)
                {
                    double paidAtleast = Convert.ToDouble(lblTotal.Text) * 0.5;
                    lblPaidAtleast.Text = paidAtleast.ToString();
                }
                else
                {
                    lblPaidAtleast.Text ="0.00";
                }
               
                lblBalance.Text = Convert.ToDouble(lblTotal.Text).ToString();
            }

            if (rbCash.Checked)
            {
                lblPaidAtleast.Text = "00.0";
                txtPayment.Enabled = false;
                lblBalance.Text = "00.0";
                txtPayment.Text = "";

            }
        }

        private void frmreservation2_Load(object sender, EventArgs e)
        {
            if (isView) {  return; }
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

        private void dtEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (cboVenue.Text == "") { return; }
            Calculate();
        }

        private void btnAvailability_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmSchedule"] != null)
            {

            }
            else
            {
                frmSchedule frm = new frmSchedule();
                frm.ShowDialog();
            }
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

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            if (isView)
            {
                if (txtPayment.Text == "")
                {
                    lblBalance.Text = tmpres.Balance.ToString();
                    return;
                }
                else
                {
                    lblBalance.Text = Convert.ToDouble(GetBalance(tmpres.TransactionNum) - Convert.ToDouble(txtPayment.Text)).ToString();
                    return;
                }
                
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
            string mysql = "SELECT * FROM reservationtbl WHERE transactionNUm = " + idx;
            DataSet ds = Database.LoadSQL(mysql, "reservationtbl");

            return Convert.ToDouble(ds.Tables[0].Rows[0]["Balance"]);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["frmCustomer"] != null)
            {

            }
            else
            {
                frmCustomerList frm = new frmCustomerList();
                frm.isResevation = true;

                frm.ShowDialog();
               
            }
        }

        internal void loadcustomer(Customer cus)
        {
            custID = cus.ID;
            txtCustomer.Text = cus.fullname;
            txtAddress.Text = cus.fulladdress;
            txtContactNum.Text = cus.ContactNum;
            tmpcus = cus;
        }

        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (isView)
            {
                return;
            }
            if (cboVenue.Text == "") { return; }
            Calculate();
        }


        internal void loadtrans(transaction tr, bool isViewTrans = true)
        {
            if (isViewTrans)
            {
                isView = true;
            }

            txtTransactionNum.Text = string.Format("00000{0}", tr.TransactionNum);

            cboVenue.DropDownStyle = ComboBoxStyle.DropDown;

            Customer cus = new Customer();
            cus.LoadCust(tr.CusID);
            txtCustomer.Text = cus.fullname;
            txtAddress.Text = cus.fulladdress;
            txtContactNum.Text = cus.ContactNum;
            cboVenue.Text = getVenue(tr.venueID);
            dtStartDate.Text = tr.StartDate.ToString("MMMM, dd yyyy hh:mm tt");
            dtEndDate.Text = tr.EndDate.ToString("MMMM, dd yyyy hh:mm tt"); 
 
            DateTime d1 = Convert.ToDateTime(tr.StartDate);
            DateTime d2 = Convert.ToDateTime(tr.EndDate).AddDays(1);

            TimeSpan t = d2 - d1;
            double NrOfDays = Math.Round(t.TotalDays);

            TimeSpan TS = d2 - d1;
            int hour = TS.Hours;
            int mins = TS.Minutes;

            if (hour <= 4)
            {
                if (mins == 0)
                {
                    NrOfDays = NrOfDays / 2;
                }
            }

            txtNoOfDays.Text = NrOfDays.ToString();
            txtRate.Text = tr.Rate.ToString();
            lblTotal.Text = tr.Total.ToString();

            if (tr.mod == "Full Payment")
            {
                rbCash.Checked = true;
            }
            if (tr.mod == "Installment")
            {
                rbInstallment.Checked = true;
            }

            lblBalance.Text = tr.Balance.ToString();

            tmpres = tr;

            if (tmpres.Balance == 0.0)
            {
                txtPayment.Enabled = false;
            }

            disAbledFields(false);
        }

        private void disAbledFields(bool st = true)
        {
            btnSearch.Enabled = st;
       
            cboVenue.Enabled = st;
            dtStartDate.Enabled = st;
            dtEndDate.Enabled = st;
            rbCash.Enabled = st;
            rbInstallment.Enabled = st;

            if (rbInstallment.Checked)
            {
                txtPayment.Enabled = true;
            }
            else
            {
                txtPayment.Enabled = false;
            }

            btnPost.Text = "&Edit";
            btnAvailability.Enabled = st;
        }

        private string getVenue(int idx)
        {
            string mysql = "SELECT * FROM VENUETBL WHERE ID =" + idx + "";
            DataSet ds = Database.LoadSQL(mysql, "VENUETBL");
            Console.WriteLine(ds.Tables[0].Rows[0]["Description"].ToString());
            return ds.Tables[0].Rows[0]["Description"].ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        
         private void ClearFields()
         {
             txtTransactionNum.Clear();
             txtTransactionNum.Text = string.Format("00000{0}", GetTransNum());
             custID = 0;
             txtContactNum.Clear();
             txtAddress.Clear();
             txtContactNum.Clear();
      
             cboVenue.SelectedItem = null;

             dtStartDate.Text = DateTime.Now.ToString("MMMM, dd yyyy hh:mm tt");
             dtEndDate.Text = DateTime.Now.ToString("MMMM, dd yyyy hh:mm tt");

             txtNoOfDays.Clear();
             txtRate.Clear();
             lblBalance.Text = "0.00";
             lblPaidAtleast.Text = "0.00";
             lblTotal.Text = "0.00";
             isView = false;
             tmpres = null;
             rbCash.Checked = true;

             cboVenue.Items.Clear();
             cboVenue.Items.AddRange(GetDistinct("Description"));
         }

         private void btnCancel_Click(object sender, EventArgs e)
         {
             ClearFields();
             disAbledFields();
             txtCustomer.Clear();
             cboVenue.DropDownStyle = ComboBoxStyle.DropDownList;
             btnPost.Text = "&Post";
         }


         #region "Print"
         private void printtransaction(int idx)
         {

             string mysql = " select t.ID,v.Description,c.FirstName + ' ' + c.MiddleName + ' ' + c.LastName as Fullname,";
             mysql += "c.Street + ' ' + b.barangay + ' ,' + ci.city + ' ,' + c.province as Address,";
             mysql += "t.transdate,t.startDate,t.EndDate,t.status,t.total,t.balance,t.rate,t.Mod,";
             mysql += "t.transactionNum,p.status as PayMent_Status,p.payment,p.transdate ";
             mysql += "from transactiontbl t ";
             mysql += "inner join venuetbl v on v.ID = t.venueID ";
             mysql += "inner join customertbl c on c.ID=t.customerID ";
             mysql += "inner join barangaytbl b on b.ID=c.barangayID ";
             mysql += "inner join citytbl ci on ci.ID=b.cityID ";
             mysql += "inner join paymenttbl p on p.resID =t.ID ";
             mysql += " where t.ID = " + idx;

             Dictionary<string, string> rptPara = new Dictionary<string, string>();

             frmReport frm = new frmReport();
             frm.ReportInit(mysql, "dsReceipt", @"Report\rptReceipt.rdlc");
             frm.Show();

         }
         #endregion

         private void txtPayment_KeyPress(object sender, KeyPressEventArgs e)
         {
             mod_system.DigitOnly(e);
         }

         private void numExtend_ValueChanged(object sender, EventArgs e)
         {
             if (txtNoOfDays.Text == "") { return; }
             DateTime d1 = Convert.ToDateTime(tmpres.StartDate);
             DateTime d2 = Convert.ToDateTime(tmpres.EndDate).AddDays(1);

             TimeSpan t = d2 - d1;
             double NrOfDays = Math.Round(t.TotalDays);

             if (numExtend.Value <= 0)
             {
                 txtNoOfDays.Text = NrOfDays.ToString();
                 return;
             }

          
             int extend = Convert.ToInt32(numExtend.Value);

             extend = extend + Convert.ToInt32(NrOfDays);
             txtNoOfDays.Text = extend.ToString();
         }

    }
}
