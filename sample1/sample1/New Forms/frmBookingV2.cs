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
    public partial class frmBookingV2 : Form
    {
        string address;
        public bool isView = false;
        int custID;
        int venudID;
        transaction tmptrans;
        Customer tmpcus;
        public frmBookingV2()
        {
            InitializeComponent();
        }

        private void frmBookingV2_Load(object sender, EventArgs e)
        {
            if (isView) { return; }
            txtTransactionNum.Text = string.Format("00000{0}", GetTransNum());
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
            if (cboVenue.Text == "") { return; }
            txtRate.Clear();
            string mySql = "SELECT * from venuetbl where description='" + cboVenue.Text + "'";
            DataSet ds = Database.LoadSQL(mySql);
            venudID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);

            string mySql1 = "SELECT * from timelaptbl where venueID=" + venudID + "";
            DataSet ds1 = Database.LoadSQL(mySql1);

            if (ds1.Tables[0].Rows.Count == 0) { return; }

            cboTime.Items.Clear();
            foreach (DataRow dr in ds1.Tables[0].Rows)
            {
              cboTime.Items.Add(dr["Time_Laps"].ToString());
            }
        }

        private void cboTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTime.Text == "") { return; }
            txtRate.Clear();
            string mySql = "SELECT * from timelaptbl where time_laps='" + cboTime.Text + "' and venueID =" + venudID;
            DataSet ds = Database.LoadSQL(mySql);

            if (ds.Tables[0].Rows.Count == 0) { return; }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                txtRate.Text = dr["Rate"].ToString();
                lblTotal.Text = dr["Rate"].ToString(); 
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmCustomer"] != null)
            {

            }
            else
            {
                frmCustomerList frm = new frmCustomerList();
                frm.isbooking = true;

                frm.ShowDialog();
            }
        }

        private void btnSearchServices_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmAdditionalServices"] != null)
            {

            }
            else
            {
                frmAdditionalServices frm = new frmAdditionalServices(txtSearchservices.Text);
                frm.ShowDialog();

            }
        }

        public void loadservices(int servicesid)
        {

            string mysql = "select * from addservicestbl where id = " + servicesid + "";
            DataSet ds = Database.LoadSQL(mysql, "addservicestbl");
            if (ds.Tables[0].Rows.Count == 0)
            {
                return;
            }

            foreach (ListViewItem lv1 in lvAdditionalServices.Items)
            {
                if (lv1.Text == ds.Tables[0].Rows[0]["description"].ToString())
                {
                    MessageBox.Show("Already added in the list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            ListViewItem lv = lvAdditionalServices.Items.Add(ds.Tables[0].Rows[0]["description"].ToString());
            lv.SubItems.Add(ds.Tables[0].Rows[0]["fee"].ToString());

            lv.Tag = ds.Tables[0].Rows[0]["id"].ToString();

            Calculate();
        }


        private void Calculate()
        {
            if (cboVenue.Text == "") { return; }
            if (isView) { return; }
    
            if (txtPayment.Text != "")
            {
                lblBalance.Text = (Convert.ToDouble(lblTotal.Text) - Convert.ToDouble(txtPayment.Text)).ToString();
            }

            if (rbInstallment.Checked)
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
                    lblPaidAtleast.Text = "0.00";
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

            double addservices = 0;
            foreach (ListViewItem lv in lvAdditionalServices.Items)
            {
                addservices += Convert.ToDouble(lv.SubItems[1].Text);
            }

            lblTotal.Text = (addservices + Convert.ToDouble(lblTotal.Text)).ToString();
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

        internal void loadcustomer(Customer cus)
        {
            custID = cus.ID;
            txtCustomer.Text = cus.fullname;
            txtAddress.Text = cus.fulladdress;
            txtContactNum.Text = cus.ContactNum;
            tmpcus = cus;
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
                //UpdateTrans();
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
            res.Transdate = Convert.ToDateTime(mod_system.CurrentDate.ToShortDateString());

            //res.StartDate = Convert.ToDateTime(dtStartDate.Text);
            //res.EndDate = Convert.ToDateTime(dtEndDate.Text);
            res.Status = "Booked";
            res.Total = Convert.ToDouble(lblTotal.Text);
            res.Balance = Convert.ToDouble(lblBalance.Text);
            res.Rate = Convert.ToDouble(txtRate.Text);

            if (rbCash.Checked)
            { res.mod = "Full Payment"; }
            if (rbInstallment.Checked)
            { res.mod = "Installment"; }
            res.TransactionNum = Convert.ToInt32(txtTransactionNum.Text);
            res.comments = txtcomments.Text;
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

            bl.tranSDate = Convert.ToDateTime(mod_system.CurrentDate.ToShortDateString());
            bl.TransNum = Convert.ToInt32(txtTransactionNum.Text);
            bl.saveBill();

            foreach (ListViewItem lv in lvAdditionalServices.Items)
            {
                addServices aser = new addServices();
                aser.servicesID = Convert.ToInt32(lv.Tag);
                aser.transNum = Convert.ToInt32(txtTransactionNum.Text);
                aser.status = 1;

                aser.saveTservices();
            }


            int transNum = Convert.ToInt32(txtTransactionNum.Text) + 1;
            mod_system.UpdateOptions("TransactionNum", transNum.ToString());

            printtransaction(bl.resID);
            MessageBox.Show("Transaction Posted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
        }

        private bool isValid()
        {
            if (isView)
            {
                if (tmptrans.Balance != 0.0)
                {
                    if (txtPayment.Text == "") { txtPayment.Focus(); return false; }
                    if (Convert.ToDouble(txtPayment.Text) > Convert.ToDouble(tmptrans.Balance))
                    {
                        MessageBox.Show("The balance is: " + tmptrans.Balance + " only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPayment.Clear();
                        return false;
                    }
                }
                if (tmptrans.Status == "CheckOut")
                {
                    MessageBox.Show("This transaction already check out.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            else
            {
               
                if (txtCustomer.Text == "") { txtCustomer.Focus(); return false; }
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

                if (txtcomments.Text == "")
                {
                    MessageBox.Show("Please enter comments below", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtcomments.Focus();
                    return false;
                }


                //transaction tr = new transaction();
                //if (tr.isHasReserved_or_Booked(Convert.ToDateTime(dtStartDate.Text)))
                //{
                //    MessageBox.Show("Selected date is already booked by another client.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return false;
                //}

            }

            return true;
        }

        #region "Print"
        private void printtransaction(int idx)
        {

            Dictionary<string, string> subReportSQL = new Dictionary<string, string>();
            Dictionary<string, string> rptSQL = new Dictionary<string, string>();

            string filldata = "dsReceipt";
            string mysql = " select t.ID,v.Description,c.FirstName + ' ' + c.MiddleName + ' ' + c.LastName as Fullname,";
            mysql += "c.Street + ' ' + b.barangay + ' ,' + ci.city + ' ,' + c.province as Address,";
            mysql += "t.transdate,t.startDate,t.EndDate,t.status,t.total,t.balance,t.rate,t.Mod,";
            mysql += "t.transactionNum,p.status as PayMent_Status,p.payment,p.transdate,t.comments ";
            mysql += "from transactiontbl t ";
            mysql += "inner join venuetbl v on v.ID = t.venueID ";
            mysql += "inner join customertbl c on c.ID=t.customerID ";
            mysql += "inner join barangaytbl b on b.ID=c.barangayID ";
            mysql += "inner join citytbl ci on ci.ID=b.cityID ";
            mysql += "inner join paymenttbl p on p.resID =t.ID ";
            mysql += " where t.ID = " + idx;
            rptSQL.Add(filldata, mysql);

            DataSet ds = Database.LoadSQL(mysql, "transactiontbl");

            Dictionary<string, string> rptPara = new Dictionary<string, string>();
            rptPara.Add("txtUsername", mod_system.ORuser.Username.ToString());

            string mysql1 = "select tl.id,tl.servicesID,tl.transactionNum,tl.status,ad.description,ad.fee from tbltransAddServices tl";
            mysql1 += " INNER JOIN ADDservicestbl ad on ad.id = tl.servicesID where tl.status =1 and tl.transactionNum=" + ds.Tables[0].Rows[0]["transactionNum"];
            filldata = "dsAddservices";
            subReportSQL.Add(filldata, mysql1);

     
            frmReport frm = new frmReport();
            frm.MultiDbSetReport(rptSQL, @"Report\rptReceipt.rdlc", rptPara, true, subReportSQL);
            frm.Show();

        }
     
        #endregion


        private void ClearFields()
        {
            txtTransactionNum.Clear();
            txtTransactionNum.Text = string.Format("00000{0}", GetTransNum());
            custID = 0;
            txtContactNum.Clear();
            txtAddress.Clear();
            txtContactNum.Clear();

            cboVenue.SelectedItem = null;

            txtRate.Clear();
            lblBalance.Text = "0.00";
            lblPaidAtleast.Text = "0.00";
            lblTotal.Text = "0.00";
            isView = false;
            txtPayment.Enabled = true;
            btnPost.Text = "&Post";
            disAbledFields();
            txtCustomer.Clear();
            cboVenue.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVenue.Items.AddRange(GetDistinct("Description"));

            tmptrans = null;
            tmptrans = null;
            rbCash.Checked = true;
            lvAdditionalServices.Items.Clear();
        }

        private void disAbledFields(bool st = true)
        {
            btnSearch.Enabled = st;

            cboVenue.Enabled = st;
        
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
       
        }
    }


}
