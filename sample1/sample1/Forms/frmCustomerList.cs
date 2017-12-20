﻿using System;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text == "") { LoadCustomer(); return; }

            if (txtsearch.Text == "") { LoadCustomer(); return; }
            string str = txtsearch.Text;
            string[] strWords = str.Split(new char[] { ' ' });
            string name = null;

            string mysql = "SELECT * FROM customer WHERE ";
            foreach (string name_loopVariable in strWords)
            {
                name = name_loopVariable;
                mysql += " CONCAT(firstname, ',', lastname) LIKE UPPER('%" + name + "%') or ";
                if (object.ReferenceEquals(name, strWords.Last()))
                {
                    mysql += " CONCAT(firstname, ',', lastname) LIKE UPPER('%" + name + "%') ";
                    break;
                }
                //mysql += " CONCAT(Fname, ' ' , Mname, ' ' , Lname) Like '%" + txtsearch.Text + "%'";
            }
            LoadCustomer(mysql);
        }

      

        private void btnadd_Click(object sender, EventArgs e)
        {
            frmCustomer frm = new frmCustomer();
            frm.Show();
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

            if (Application.OpenForms["frmCustomer"] != null)
            {
        
                (Application.OpenForms["frmCustomer"] as frmCustomer).loadcustomer(cust,true);
              
            }
            else
            {
                frmCustomer frm = new frmCustomer();
                frm.Show();
                frm.loadcustomer(cust, true);
              
            }
           // this.Close();
      
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
                mysql += " CONCAT(firstname, ',', Lastname) LIKE UPPER('%" + name + "%') OR ";
                if (object.ReferenceEquals(name, strWords.Last()))
                {
                    mysql += " CONCAT(firstname, ',', Lastname) LIKE UPPER('%" + name + "%') )";
                    break;
                }
            }
            LoadCustomer(mysql);
        }

        private void lvPassList_DoubleClick(object sender, EventArgs e)
        {
            btnView.PerformClick();
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
            if (mod_system.isEnter(e)) { btnView.PerformClick(); }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (txtsearch.Text == "") { LoadCustomer(); }
        }

        }
    }

