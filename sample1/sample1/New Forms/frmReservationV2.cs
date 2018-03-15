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
    public partial class frmReservationV2 : Form
    {

        string address;
        public bool isView = false;
        int custID;
        int venudID;
        transaction tmpres;
        Customer tmpcus;
        int packageID;
        public frmReservationV2()
        {
            InitializeComponent();
        }

        private void frmReservationV2_Load(object sender, EventArgs e)
        {
            if (isView) { return; }
            txtTransactionNum.Text = string.Format("00000{0}", GetTransNum());

            cboVenue.Items.AddRange(GetDistinct("Description"));
            cboPackage.Items.AddRange(GetDistinctpakcage("PackageName"));
        }

        private string getVenue(int idx)
        {
            string mysql = "SELECT * FROM VENUETBL WHERE ID =" + idx + "";
            DataSet ds = Database.LoadSQL(mysql, "VENUETBL");
            Console.WriteLine(ds.Tables[0].Rows[0]["Description"].ToString());
            return ds.Tables[0].Rows[0]["Description"].ToString();
        }

        internal void loadtrans(transaction tr, bool isViewTrans = true)
        {
            if (isViewTrans)
            {
                isView = true;
            }

            txtTransactionNum.Text = string.Format("00000{0}", tr.TransactionNum);

            cboVenue.DropDownStyle = ComboBoxStyle.DropDown;
            cbotime.DropDownStyle = ComboBoxStyle.DropDown;
            cboPackage.DropDownStyle = ComboBoxStyle.DropDown;

            Customer cus = new Customer();
            cus.LoadCust(tr.CusID);
            txtCustomer.Text = cus.fullname;
            txtAddress.Text = cus.fulladdress;
            txtContactNum.Text = cus.ContactNum;
            cboVenue.Text = getVenue(tr.venueID);
            dtStartDate.Text = tr.StartDate.ToString("MMMM, dd yyyy hh:mm tt");
            // dtEndDate.Text = tr.EndDate.ToString("MMMM, dd yyyy hh:mm tt");

            //DateTime d1 = Convert.ToDateTime(tr.StartDate);
            //DateTime d2 = Convert.ToDateTime(tr.EndDate).AddDays(1);

            //TimeSpan t = d2 - d1;
            //double NrOfDays = Math.Round(t.TotalDays);

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

            //txtNoOfDays.Text = NrOfDays.ToString();
            txtRate.Text = tr.Rate.ToString();
            lblTotal.Text = tr.Total.ToString();
            txtcomments.Text = tr.comments;


            cboPackage.Text = getPackageName(tr.packageId);
            loadPackageTrans(tr.TransactionNum);


            if (tr.mod == "Full Payment")
            {
                rbCash.Checked = true;
            }
            if (tr.mod == "Installment")
            {
                rbInstallment.Checked = true;
            }

            lblBalance.Text = tr.Balance.ToString();
            loadtranservices(tr.TransactionNum);
            tmpres = tr;

            if (tmpres.Balance == 0.0)
            {
                txtPayment.Enabled = false;
            }

            disAbledFields(false);
        }

        private void loadPackageTrans(int transNum)
        {
            string mysql1 = "select * from tblpackageTransaction where transactionno=" + transNum + "";
            DataSet ds1 = Database.LoadSQL(mysql1, "tblpackageTransaction");

            foreach (DataRow dr in ds1.Tables[0].Rows)
            {

                string mysql = "select * from packageDetailstbl where id=" + dr["packageDetailsID"] + "";
                DataSet ds = Database.LoadSQL(mysql, "packageDetailstbl");

                ListViewItem lv = listView1.Items.Add(ds.Tables[0].Rows[0]["Description"].ToString());
                lv.Tag = ds.Tables[0].Rows[0]["id"].ToString();
            }
        }

        private string getPackageName(int packageIdx)
        {
            packageID = 0;

            string mysql1 = "select * from packagetbl where id=" + packageIdx + "";
            DataSet ds1 = Database.LoadSQL(mysql1, "packagetbl");

            return ds1.Tables[0].Rows[0]["PackageName"].ToString();
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

        private string[] GetDistinctpakcage(string col)
        {
            string mySql = "SELECT DISTINCT " + col + " FROM packagetbl WHERE " + col + " <> ''";
            DataSet ds = Database.LoadSQL(mySql, "packagetbl");

            int MaxCount = ds.Tables[0].Rows.Count;
            string[] str = new string[MaxCount];
            for (int cnt = 0; cnt <= MaxCount - 1; cnt++)
            {
                string tmpStr = ds.Tables[0].Rows[cnt]["packageName"].ToString();
                str[cnt] = tmpStr;
            }

            return str;
        }


        private int GetTransNum()
        {
            string mysql = "select * from maintenancetbl where Op_key ='TransactionNum'";
            DataSet ds = Database.LoadSQL(mysql, "maintenancetbl");

            return Convert.ToInt32(ds.Tables[0].Rows[0]["op_values"]);
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
            trans.EndDate = Convert.ToDateTime(dtStartDate.Text);
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
            trans.timelaps = cbotime.Text;
            trans.packageId = packageID;
            trans.saveTrans();

            reservation res = new reservation();
            res.venueID = venudID;
            res.CusID = custID;
            res.Transdate = Convert.ToDateTime(mod_system.CurrentDate.ToShortDateString());
            // res.Transdate = Convert.ToDateTime(mod_system.CurrentDate.ToShortDateString());
            res.StartDate = Convert.ToDateTime(dtStartDate.Text);
            res.EndDate = Convert.ToDateTime(dtStartDate.Text);

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

            if (listView1.Items.Count > 0)
            {
                foreach (ListViewItem lv in listView1.Items)
                {
                    packTransaction pt = new packTransaction();
                    pt.transactionNo = Convert.ToInt32(txtTransactionNum.Text);
                    pt.packagedetailsID = Convert.ToInt32(lv.Tag);
                    pt.saveptrans();
                }
            }


            int transNum = Convert.ToInt32(txtTransactionNum.Text) + 1;
            mod_system.UpdateOptions("TransactionNum", transNum.ToString());
            printtransaction(bl.resID);
            MessageBox.Show("Transaction Posted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
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

            dtStartDate.Text = DateTime.Now.ToString("MMMM, dd yyyy");
            //dtEndDate.Text = DateTime.Now.ToString("MMMM, dd yyyy hh:mm tt");

            //txtNoOfDays.Clear();
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
            cboPackage.Items.AddRange(GetDistinctpakcage("packageName"));
            cbotime.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPackage.DropDownStyle = ComboBoxStyle.DropDownList;
            isView = false;
            tmpres = null;
            rbCash.Checked = true;
            lvAdditionalServices.Items.Clear();
            listView1.Items.Clear();
            packageID = 0;
        }

        private void disAbledFields(bool st = true)
        {
            btnSearch.Enabled = st;

            cboVenue.Enabled = st;
            cbotime.Enabled = st;
            dtStartDate.Enabled = st;
            //dtEndDate.Enabled = st;
            rbCash.Enabled = st;
            rbInstallment.Enabled = st;
            txtRate.Enabled = st;

            lvAdditionalServices.Enabled = st;
            txtcomments.Enabled = st;
            if (rbInstallment.Checked)
            {
                txtPayment.Enabled = true;
            }
            else
            {
                txtPayment.Enabled = false;
            }

            btnPost.Text = "&Edit";
            //btnAvailability.Enabled = st;
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

        private void Calculate()
        {
            if (cboVenue.Text == "") { return; }
            if (isView) { return; }

            if (cboPackage.Text == "Normal")
            {
                listView1.Items.Clear();
                txtRate.Text = getRateNormalForvenue(cboVenue.Text);
            }
            else
            {
                txtRate.Text = getPackageRate(cboPackage.Text);
            }

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
                lblTotal.Text = txtRate.Text;
                lblBalance.Text = Convert.ToDouble(lblTotal.Text).ToString();
            }
            lblTotal.Text = txtRate.Text;

            if (rbCash.Checked)
            {
                lblPaidAtleast.Text = "00.0";
                txtPayment.Enabled = false;
                lblBalance.Text = "00.0";
                txtPayment.Text = "";

            }

            if (lvAdditionalServices.Items.Count == 0) { return; }
            double addservices = 0;
            foreach (ListViewItem lv in lvAdditionalServices.Items)
            {
                addservices += Convert.ToDouble(lv.SubItems[1].Text);
            }

            lblTotal.Text = (addservices + Convert.ToDouble(lblTotal.Text)).ToString();
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
            mysql += "t.transactionNum,p.status as PayMent_Status,p.payment,p.transdate,t.comments,t.timelaps ";
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

            //DataSet d1 = Database.LoadSQL(mysql1, "tbltransAddServices");
            //rptPara.Add("desc", d1.Tables[0].Rows[0]["description"].ToString());
            //rptPara.Add("fee", d1.Tables[0].Rows[0]["fee"].ToString());

            frmReport frm = new frmReport();
            frm.MultiDbSetReport(rptSQL, @"Report\rptReceipt.rdlc", rptPara, true, subReportSQL);
            frm.Show();

        }
        #endregion
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
                //bool isDatetimeStart_equal_dateTimeEnd = System.DateTime.Equals(Convert.ToDateTime(dtEndDate.Text), Convert.ToDateTime(dtStartDate.Text));

                //if (isDatetimeStart_equal_dateTimeEnd)
                //{
                //    MessageBox.Show("TIME START must not equal to TIME END.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return false;
                //}

                //int result = DateTime.Compare(Convert.ToDateTime(dtEndDate.Text).Date, Convert.ToDateTime(dtStartDate.Text).Date);

                //if (txtCustomer.Text == "") { txtCustomer.Focus(); return false; }

                //if (Convert.ToDateTime(dtStartDate.Text).Date > Convert.ToDateTime(dtEndDate.Text).Date)
                //{
                //    MessageBox.Show("DATE TIME START must be greater than DATE TIME END.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return false;
                //}

                if (rbInstallment.Checked)
                {
                    if (txtPayment.Text == "") { txtPayment.Focus(); return false; }
                    //if (Convert.ToDouble(txtPayment.Text) < Convert.ToDouble(lblPaidAtleast.Text))
                    //{
                    //    MessageBox.Show("You must pay atleast " + Convert.ToDouble(lblPaidAtleast.Text) + " .", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    return false;
                    //}

                    if (Convert.ToDouble(txtPayment.Text) >= Convert.ToDouble(lblTotal.Text))
                    {
                        MessageBox.Show("Select full payment to fully paid this transaction.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }

                if (txtcomments.Text == "")
                {
                    MessageBox.Show("Please enter comments below.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtcomments.Focus();
                    return false;
                }
                transaction tr = new transaction();
                if (!tr.ifNotAvailable(Convert.ToDateTime(dtStartDate.Text), cbotime.Text.ToString(), venudID))
                {
                    MessageBox.Show("Selected date is already booked by another client.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                //reservation rs = new reservation();
                //if (rs.isHasReserved(Convert.ToDateTime(dtStartDate.Text)))
                //{
                //    MessageBox.Show("Selected date is already reserved by another client.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return false;
                //}

                //transaction tr = new transaction();
                //if (tr.isHasReserved_or_Booked(Convert.ToDateTime(dtStartDate.Text)))
                //{
                //    MessageBox.Show("Selected date is already booked by another client.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return false;
                //}

                //transaction tr1 = new transaction();
                //if (tr1.isHasReserved_or_Booked(Convert.ToDateTime(dtEndDate.Text)))
                //{
                //    MessageBox.Show("Selected date is already booked by another client.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return false;
                //}

                //transaction tr2 = new transaction();
                //if (tr2.isExists(Convert.ToDateTime(dtStartDate.Text)))
                //{
                //    MessageBox.Show("Selected date is already booked by another client.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return false;
                //}

            }

            return true;
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

        private double GetBalance(int idx)
        {
            string mysql = "SELECT * FROM reservationtbl WHERE transactionNUm = " + idx;
            DataSet ds = Database.LoadSQL(mysql, "reservationtbl");

            return Convert.ToDouble(ds.Tables[0].Rows[0]["Balance"]);
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

        private void btnSearchServices_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmAdditionalServices"] != null)
            {

            }
            else
            {
                frmAdditionalServices frm = new frmAdditionalServices(txtSearchservices.Text, false);

                frm.ShowDialog();

            }
        }

        private void cboVenue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVenue.Text == "") { return; }
            string mySql = "SELECT * from venuetbl where description ='" + cboVenue.Text + "'";
            DataSet ds = Database.LoadSQL(mySql, "venuetbl");
            venudID = 0;
            venudID = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
            //    MessageBox.Show("", venudID.ToString());
            cbotime.Items.Clear();
            string mySql1 = "SELECT * from timetbl where venueId= " + venudID;
            DataSet ds1 = Database.LoadSQL(mySql1, "timetbl");
            foreach (DataRow dr in ds1.Tables[0].Rows)
            {
                cbotime.Items.Add(dr["time_laps"].ToString());
            }
        }

        private void cbotime_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mySql1 = "SELECT * from timetbl where time_laps= '" + cbotime.Text + "' and venueID =" + venudID;
            DataSet ds1 = Database.LoadSQL(mySql1, "timetbl");
            txtRate.Text = "";
            txtRate.Text = ds1.Tables[0].Rows[0]["rate"].ToString();
            Calculate();
        }


        private void loadtranservices(int transNum)
        {
            string mysql = "select * from tbltransAddservices where transactionNum =" + transNum;
            DataSet ds = Database.LoadSQL(mysql, "tbltransAddservices");
            if (ds.Tables[0].Rows.Count == 0)
            {
                return;
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string mysql1 = "select * from addservicestbl where id =" + dr["servicesID"];
                DataSet ds1 = Database.LoadSQL(mysql1, "addservicestbl");

                ListViewItem lv2 = lvAdditionalServices.Items.Add(ds1.Tables[0].Rows[0]["Description"].ToString());
                lv2.SubItems.Add(ds1.Tables[0].Rows[0]["Fee"].ToString());
                lv2.Tag = ds1.Tables[0].Rows[0]["id"].ToString();
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

        private void cboPackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPackage.Text == "") { return; }

            packageID = 0;
            string mysql1 = "select * from packagetbl where packageName='" + cboPackage.Text + "'";
            DataSet ds1 = Database.LoadSQL(mysql1, "packagetbl");
            packageID = Convert.ToInt32(ds1.Tables[0].Rows[0]["id"]);

            loadpackagesDetails();
            Calculate();
        }

        private void loadpackagesDetails()
        {
            string mysql1 = "select * from packagedetailstbl where packageID =" + packageID + " and  venueID =" + venudID;
            DataSet ds1 = Database.LoadSQL(mysql1, "packagedetailstbl");

            listView1.Items.Clear();
            foreach (DataRow dr in ds1.Tables[0].Rows)
            {
                ListViewItem lv = listView1.Items.Add(dr["Description"].ToString());
                lv.Tag = dr["id"].ToString();
            }
        }

        private string getPackageRate(string str)
        {
            if (cboPackage.Text == "") { return ""; }
            string mysql1 = "select * from packagetbl where packageName ='" + str + "'";
            DataSet ds1 = Database.LoadSQL(mysql1, "packagetbl");


            return ds1.Tables[0].Rows[0]["PackageRate"].ToString();
        }

        private string getRateNormalForvenue(string str)
        {

            string mysql1 = "select * from venuetbl where description ='" + str + "'";
            DataSet ds1 = Database.LoadSQL(mysql1, "venuetbl");


            return ds1.Tables[0].Rows[0]["Rate"].ToString();
        }

        private void cbotime_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Calculate();
        }

        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cboVenue_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboVenue.Text == "") { return; }
            string mySql = "SELECT * from venuetbl where description ='" + cboVenue.Text + "'";
            DataSet ds = Database.LoadSQL(mySql, "venuetbl");
            venudID = 0;
            venudID = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
            //    MessageBox.Show("", venudID.ToString());
            cbotime.Items.Clear();
            string mySql1 = "SELECT * from timetbl where venueId= " + venudID;
            DataSet ds1 = Database.LoadSQL(mySql1, "timetbl");
            foreach (DataRow dr in ds1.Tables[0].Rows)
            {
                cbotime.Items.Add(dr["time_laps"].ToString());
            }
            Calculate();
        }
    }
}
