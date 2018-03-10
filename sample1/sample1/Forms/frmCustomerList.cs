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
    public partial class frmCustomerList : Form
    {
        public  bool isResevation = false;
        public  bool isbooking = false;
        public bool isFromCustomerForm = false;
        public frmCustomerList()
        {
            InitializeComponent();
        }

        private void frmPassengerList_Load(object sender, EventArgs e)
        {
            if (txtsearch.Text == "")
            {
                LoadCustomer();
            }
            else
            {
                btnSearch.PerformClick();
            }

            if (isFromCustomerForm) { btnSelect.Visible = false; }
        }

        private void LoadCustomer(string mysql = "SELECT top 20 * FROM customertbl ORDER BY ID ASC")
        {

            DataSet ds = Database.LoadSQL(mysql, "customertbl");
            if (ds.Tables[0].Rows.Count == 0) { lvPassList.Items.Clear(); return; }

            lvPassList.Items.Clear();
            foreach (DataRow itm in ds.Tables[0].Rows)
            {
                Customer cus = new Customer();
                cus.LoadCust(Convert.ToInt32(itm["ID"]));
                addcut(cus);
            }
        }

        private void addcut(Customer cus)
        {
            ListViewItem lv = lvPassList.Items.Add(cus.fullname);
            lv.SubItems.Add(cus.fulladdress);
            lv.SubItems.Add(cus.ContactNum);
            lv.SubItems.Add(cus.birthday.ToShortDateString());
         
            lv.Tag = cus.ID;

        }

   
        private void btnadd_Click(object sender, EventArgs e)
        {
            
            if (Application.OpenForms["frmCustomer"] != null)
            {
                if (isbooking)
                {
                    (Application.OpenForms["frmCustomer"] as frmCustomer).isBooking = true;
                }
                if (isResevation)
                {
                    (Application.OpenForms["frmCustomer"] as frmCustomer).isReservation = true;
                }

            }
            else
            {
                frmCustomer frm = new frmCustomer();
                if (isbooking)
                {
                    frm.isBooking = true;
                }
                if (isResevation)
                {
                    frm.isReservation = true;
                }
             
                frm.Show();
            }
            this.Close();
          
        }

        private void lvPassList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void btnSelect_Click(object sender, EventArgs e)
        //{
        //    if (lvPassList.SelectedItems.Count == 0) { return; }
        //    int idx = Convert.ToInt32(lvPassList.SelectedItems[0].Tag);

        //    passenger pass = new passenger();
        //    pass.Loadpass(idx);

        //    if (Application.OpenForms["frmTransaction"] != null)
        //    {
        //        (Application.OpenForms["frmTransaction"] as frmTransaction).addbus(pass);
        //    }
        //    else
        //    {
        //        frmTransaction frm = new frmTransaction();
        //        frm.Show();
        //        frm.addbus(pass);
        //    }
        //    this.Close();
        //}

        private void btnView_Click_1(object sender, EventArgs e)
        {
            if (lvPassList.SelectedItems.Count == 0) { return; }
            int idx = Convert.ToInt32(lvPassList.SelectedItems[0].Tag);

            Customer cust = new Customer();
            cust.LoadCust(idx);

            if (isbooking)
            {
                if (Application.OpenForms["frmCustomer"] != null)
                {
                    (Application.OpenForms["frmCustomer"] as frmCustomer).isBooking=true;
                    (Application.OpenForms["frmCustomer"] as frmCustomer).loadcustomer(cust, true);
                    (Application.OpenForms["frmCustomer"] as frmCustomer).TopMost = true;
                }
                else
                {
                    frmCustomer frm = new frmCustomer();
                    frm.loadcustomer(cust, true);
                    frm.isBooking = true;
                    frm.TopMost = true;
                   frm.Show();
                   // mod_system.LoadForm(frm);
                }
          
            }
            if (isResevation)
            {
                if (Application.OpenForms["frmCustomer"] != null)
                {
                    (Application.OpenForms["frmCustomer"] as frmCustomer).isReservation = true;
                    (Application.OpenForms["frmCustomer"] as frmCustomer).loadcustomer(cust, true);
                    (Application.OpenForms["frmCustomer"] as frmCustomer).TopMost = true;
                }
                else
                {
                    frmCustomer frm = new frmCustomer();
                    frm.loadcustomer(cust, true);
                    frm.isReservation = true;
                    frm.TopMost = true;
                    frm.Show();

                }
            }

            if (Application.OpenForms["frmCustomer"] != null)
            {
                (Application.OpenForms["frmCustomer"] as frmCustomer).loadcustomer(cust, true);
                (Application.OpenForms["frmCustomer"] as frmCustomer).TopMost = true;
            }
            else
            {
                frmCustomer frm = new frmCustomer();
                frm.loadcustomer(cust, true);
         
               // frm.Show();
                 mod_system.LoadForm(frm);
            }

           this.Close();
      
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            if (txtsearch.Text == "") { LoadCustomer(); return; }
            string str =txtsearch.Text;
            string[] strWords = str.Split(new char[] { ' ' });
            string name = null;

            string mysql = "SELECT * FROM customertbl WHERE ";
            foreach (string name_loopVariable in strWords)
            {
                name = name_loopVariable;
                mysql += " (FirstName + ' ' + MiddleName + ' ' + LastName) LIKE UPPER('%" + name + "%') OR ";
                if (object.ReferenceEquals(name, strWords.Last()))
                {
                    mysql += " (FirstName + ' ' + MiddleName + ' ' + LastName) LIKE UPPER('%" + name + "%')";
                    break;
                }
            }
            LoadCustomer(mysql);
        }

        private void lvPassList_DoubleClick(object sender, EventArgs e)
        {
            if (isbooking)
            {
                btnSelect.PerformClick();
                this.Close();
                return;
            }

            if (isResevation)
            {
                btnSelect.PerformClick();
                this.Close();
                return;
            }

            if (btnView.Visible)
            {
                btnView.PerformClick();
                this.Close();
                return;
            }
            else
            {
                btnSelect.PerformClick();
                this.Close();
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e)) { btnSearch.PerformClick(); }
        }

        private void lvPassList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e)) 
            {
                if (btnView.Visible)
                {
                    btnView.PerformClick();
                }
                else
                {
                    btnSelect.PerformClick();
                }
              
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (txtsearch.Text == "") { LoadCustomer(); }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lvPassList.SelectedItems.Count == 0) { return; }
            int idx = Convert.ToInt32(lvPassList.SelectedItems[0].Tag);

            Customer cust = new Customer();
            cust.LoadCust(idx);

            if (isbooking)
            {
                if (Application.OpenForms["frmBookingV2"] != null)
                {

                    (Application.OpenForms["frmBookingV2"] as frmBookingV2).loadcustomer(cust);

                }
                else
                {
                    frmBookingV2 frm = new frmBookingV2();
                    frm.loadcustomer(cust);
                    frm.Show();
              
                }
            }
            else
            {

                if (Application.OpenForms["frmreservation2"] != null)
                {

                    (Application.OpenForms["frmreservation2"] as frmreservation2).loadcustomer(cust);

                }
                else
                {
                    frmreservation2 frm = new frmreservation2();
                    frm.Show();
                    frm.loadcustomer(cust);

                }
            }
           
           this.Close();
      
        }

        }
    }

