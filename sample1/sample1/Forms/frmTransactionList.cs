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
            LoadExpiry();
        }

        private void LoadTransaction(string mysql = "select top 50 * from Transactiontbl where status = 'Booked' and status <> 'Cancel' and status <> 'Expired' order by transdate desc")
        {
            DataSet ds = Database.LoadSQL(mysql, "Transactiontbl");
            if (ds.Tables[0].Rows.Count == 0) { lvTransList.Items.Clear(); return; }

            lvTransList.Items.Clear();
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
                lv.SubItems.Add(string.Format("0000{0}",dr["TransactionNum"].ToString()));

                lv.Tag = dr["ID"];
            }
        }

        private string getFullName(int ID)
        {
            string mysql = "SELECT * FROM CUSTOMERTBL WHERE ID ='" + ID + "'";
            DataSet ds = Database.LoadSQL(mysql, "Customertbl");

            return ds.Tables[0].Rows[0]["firstname"] + " " + ds.Tables[0].Rows[0]["Lastname"];
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


            //reservation res = new reservation();
            //res.loadbyTransNum(rs.TransactionNum);


            if (rs.Status == "Expired")
            {
                MessageBox.Show("This transaction is already expired you cannot select it.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //if (res.Status == "CheckOut")
            //{
            //    MessageBox.Show("This transaction is already CHECKOUT you cannot select it.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            frmBooking frm = new frmBooking();
            if (Application.OpenForms["frmBooking"] != null)
            {
                (Application.OpenForms["frmBooking"] as frmBooking).loadtrans(rs);
            }
            else
            {
            
            //  frm.Show();
                frm.isView = true;
                frm.loadtrans(rs);
            }

     
           mod_system.LoadForm(frm);
        }


        private void LoadReservation(string mysql = "select top 50 * from Transactiontbl where status = 'Reserved' and status <> 'Expired' and status <> 'Cancel' order by transdate desc")
        {
            DataSet ds = Database.LoadSQL(mysql, "Transactiontbl");
            if (ds.Tables[0].Rows.Count == 0) { lvReserved.Items.Clear(); return; }

            lvReserved.Items.Clear();
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
                lv.SubItems.Add(dr["TransactionNum"].ToString());

                lv.Tag = dr["ID"];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lvReserved.SelectedItems.Count == 0) { return; }

            int idx = Convert.ToInt32(lvReserved.SelectedItems[0].Tag);

            transaction tr = new transaction();
            tr.loadTrans(idx);

            
            //reservation res = new reservation();
            //res.loadbyTransNum(tr.TransactionNum);

            //if (res.Status == "Expired")
            //{
            //    MessageBox.Show("This transaction is already expired you cannot select it.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            frmreservation2 frm = new frmreservation2();
            if (Application.OpenForms["frmreservation2"] != null)
            {
                (Application.OpenForms["frmreservation2"] as frmreservation2).isView=true;
                (Application.OpenForms["frmreservation2"] as frmreservation2).loadtrans(tr);
            }
            else
            {
                frm.isView = true;
                frm.loadtrans(tr);
               // frm.Show();
            }

            mod_system.LoadForm(frm);
        }

        private void lvTransList_DockChanged(object sender, EventArgs e)
        {

        }

        private void lvTransList_DoubleClick(object sender, EventArgs e)
        {
            btnSelect.PerformClick();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (lvTransList.SelectedItems.Count == 0) { return; }

            int idx = Convert.ToInt32(lvTransList.SelectedItems[0].Tag);

            transaction rs = new transaction();
            rs.loadTrans(idx);

            if (Application.OpenForms["frmPayList"] != null)
            {
                (Application.OpenForms["frmPayList"] as frmPayList).loadtrans(rs);
            }

            {
                frmPayList frm = new frmPayList();
                frm.loadtrans(rs);
                frm.ShowDialog(); ;
            
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "") { LoadTransaction(); return; }

            string secured_str = txtSearch.Text;
		    secured_str = mod_system.DreadKnight(secured_str);
            string str = txtSearch.Text;
            string[] strWords = str.Split(new char[] { ' ' });
            string name = null;

            string mysql= " SELECT t.*,FirstName + ' ' + MiddleName + ' ' + LastName as Fullname ";
                 mysql += " from transactiontbl t";
                 mysql += " inner join customertbl c on c.ID = t.customerID where";
           foreach (string name_loopVariable in strWords)
            {
                name = name_loopVariable;
                mysql += " (UPPER(FirstName + ' ' + MiddleName + ' ' + LastName) LIKE UPPER('%" + name + "%') OR ";
                if (object.ReferenceEquals(name, strWords.Last()))
                {
                    mysql += " UPPER(FirstName + ' ' + MiddleName + ' ' + LastName) LIKE UPPER('%" + name + "%')) ";
                    break;
                }
            }
            
           mysql += " OR (TransactionNum like '%" + txtSearch.Text + "%' ) and (status <> 'Cancel' or status <> 'Reserved')";

           LoadTransaction(mysql);
              
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtsearch2.Text == "") { LoadReservation(); return; }

            string secured_str = txtsearch2.Text;
            secured_str = mod_system.DreadKnight(secured_str);
            string str = txtsearch2.Text;
            string[] strWords = str.Split(new char[] { ' ' });
            string name = null;

            string mysql = " SELECT t.*,FirstName + ' ' + MiddleName + ' ' + LastName as Fullname ";
            mysql += " from transactiontbl t";
            mysql += " inner join customertbl c on c.ID = t.customerID where";
            foreach (string name_loopVariable in strWords)
            {
                name = name_loopVariable;
                mysql += " (UPPER(FirstName + ' ' + MiddleName + ' ' + LastName) LIKE UPPER('%" + name + "%') OR ";
                if (object.ReferenceEquals(name, strWords.Last()))
                {
                    mysql += " UPPER(FirstName + ' ' + MiddleName + ' ' + LastName) LIKE UPPER('%" + name + "%')) ";
                    break;
                }
            }

            mysql += "OR (TransactionNum like '%" + txtSearch.Text + "%' ) and (status ='Reserved') ";

            LoadReservation(mysql);
        }

        private void bntViewReserved_Click(object sender, EventArgs e)
        {
            if (lvReserved.SelectedItems.Count == 0) { return; }

            int idx = Convert.ToInt32(lvReserved.SelectedItems[0].Tag);

            transaction rs = new transaction();
            rs.loadTrans(idx);

            if (Application.OpenForms["frmPayList"] != null)
            {
                (Application.OpenForms["frmPayList"] as frmPayList).loadtrans(rs);
            }

            {
                frmPayList frm = new frmPayList();
                frm.loadtrans(rs);
                frm.ShowDialog(); ;

            }
        }

        private void btnVoidReserved_Click(object sender, EventArgs e)
        {
            if (lvReserved.SelectedItems.Count == 0) { return; }
            
          
            transaction tr = new transaction();
            int idx = Convert.ToInt32(lvReserved.SelectedItems[0].Tag);
            tr.loadTrans(idx);

            //reservation checkexpired = new reservation();
            //checkexpired.loadbyTransNum(tr.TransactionNum);

            if (tr.Status == "Expired")
            {
                MessageBox.Show("This transaction is already expired you cannot void it.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult result = MessageBox.Show("Do you want void this transaction?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            tr.Voidtransaction(idx);

            bill bl = new bill();
            bl.VoidPayMent(idx);

            reservation res = new reservation();
            res.VoidReservation(tr.TransactionNum);

            MessageBox.Show("Transaction sucessully voided.?", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadReservation();
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (lvTransList.SelectedItems.Count == 0) { return; }

            transaction tr = new transaction();
            int idx = Convert.ToInt32(lvTransList.SelectedItems[0].Tag);
            tr.loadTrans(idx);

            reservation checkexpired = new reservation();
            checkexpired.loadbyTransNum(tr.TransactionNum);

            if (checkexpired.Status == "Expired")
            {
                MessageBox.Show("This transaction is already expired you cannot void it.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult result = MessageBox.Show("Do you want void this transaction?", "Confirmation", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            tr.Voidtransaction(idx);

            bill bl = new bill();
            bl.VoidPayMent(idx);

           MessageBox.Show("Transaction sucessully voided.?", "Confirmation", MessageBoxButtons.OK,MessageBoxIcon.Information);
           LoadTransaction();
        }

        private void txtsearch2_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e))
            {
                btnSearch.PerformClick();
            }
        }

        private void txtsearch2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e))
            {
                button3.PerformClick();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvTransList.SelectedItems.Count == 0) { return; }
            printtransaction(Convert.ToInt32(lvTransList.SelectedItems[0].Tag));
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

        #region "Load Expiry"
        private void LoadExpiry(string mysql = "select * from reservationtbl where status = 'Expired' order by transdate desc")
        {
            DataSet ds = Database.LoadSQL(mysql, "reservationtbl");
            if (ds.Tables[0].Rows.Count == 0) { lvExpired.Items.Clear(); return; }

            lvExpired.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int cusID = Convert.ToInt32(dr["customerID"]);
                int vID = Convert.ToInt32(dr["venueID"]);
                ListViewItem lv = lvExpired.Items.Add(Convert.ToDateTime(dr["TransDate"].ToString()).ToShortDateString());
                lv.SubItems.Add(getFullName(cusID));
                lv.SubItems.Add(getVenue(vID));
                lv.SubItems.Add(dr["Total"].ToString());
                lv.SubItems.Add(Convert.ToDateTime(dr["StartDate"]).ToShortDateString());
                lv.SubItems.Add(Convert.ToDateTime(dr["EndDate"]).ToShortDateString());
                lv.SubItems.Add(dr["Status"].ToString());
                lv.SubItems.Add(string.Format("0000{0}", dr["TransactionNum"].ToString()));

                lv.Tag = dr["ID"];
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (txtsearchExpiry.Text == "") { LoadExpiry(); return; }

            string secured_str = txtsearchExpiry.Text;
            secured_str = mod_system.DreadKnight(secured_str);
            string str = txtsearch2.Text;
            string[] strWords = str.Split(new char[] { ' ' });
            string name = null;

            string mysql = " SELECT t.*,FirstName + ' ' + MiddleName + ' ' + LastName as Fullname ";
            mysql += " from reservationtbl t";
            mysql += " inner join customertbl c on c.ID = t.customerID where";
            foreach (string name_loopVariable in strWords)
            {
                name = name_loopVariable;
                mysql += " (FirstName + ' ' + MiddleName + ' ' + LastName LIKE UPPER('%" + name + "%') OR ";
                if (object.ReferenceEquals(name, strWords.Last()))
                {
                    mysql += " FirstName + ' ' + MiddleName + ' ' + LastName LIKE UPPER('%" + name + "%') ";
                    break;
                }
            }

            mysql += "OR TransactionNum like '%" + txtSearch.Text + "%' ) and (status ='Expired')";

            LoadExpiry(mysql);
        }
        #endregion

        private void txtsearchExpiry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e))
            {
                button5.PerformClick();
            }

        }

        private void lvReserved_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }

    }
