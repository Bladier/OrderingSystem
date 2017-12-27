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
        }

        private void LoadTransaction(string mysql = "select top 50 * from Transactiontbl where status = 'Booked' and status <> 'Cancel' order by transdate desc")
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


        private void LoadReservation(string mysql = "select top 50 * from Transactiontbl where status = 'Reserved' order by transdate desc")
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

                lv.Tag = dr["ID"];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lvReserved.SelectedItems.Count == 0) { return; }

            int idx = Convert.ToInt32(lvReserved.SelectedItems[0].Tag);

            transaction tr = new transaction();
            tr.loadTrans(idx);

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
                mysql += " ((FirstName + ' ' + MiddleName + ' ' + LastName) LIKE UPPER('%" + name + "%') OR ";
                if (object.ReferenceEquals(name, strWords.Last()))
                {
                    mysql += " (FirstName + ' ' + MiddleName + ' ' + LastName) LIKE UPPER('%" + name + "%')) ";
                    break;
                }
            }
            
           mysql += " and status = 'Booked' or status = 'CheckOut'";

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
                mysql += " ((FirstName + ' ' + MiddleName + ' ' + LastName) LIKE UPPER('%" + name + "%') OR ";
                if (object.ReferenceEquals(name, strWords.Last()))
                {
                    mysql += " (FirstName + ' ' + MiddleName + ' ' + LastName) LIKE UPPER('%" + name + "%')) ";
                    break;
                }
            }

            mysql += " and status = 'Reserved'";

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
            
            DialogResult result = MessageBox.Show("Do you want void this transaction?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            transaction tr = new transaction();
            int idx = Convert.ToInt32(lvReserved.SelectedItems[0].Tag);
            tr.loadTrans(idx);

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

            DialogResult result = MessageBox.Show("Do you want void this transaction?", "Confirmation", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            transaction tr = new transaction();
            int idx = Convert.ToInt32(lvTransList.SelectedItems[0].Tag);

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
    }

    }
