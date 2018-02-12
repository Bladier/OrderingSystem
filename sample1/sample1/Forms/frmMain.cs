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
    public partial class frmMain : Form
    {
        public static bool dateSet;

        public frmMain()
        {
            InitializeComponent();
        }

        internal void NotYetLogin(bool st = false)
        {
            toolStripButton1.Enabled = st;
            toolStripButton2.Enabled = st;
            toolStripButton3.Enabled = st;
            toolStripButton4.Enabled = st;
            openDateToolStripMenuItem.Enabled = st;
            userManagementToolStripMenuItem.Enabled = st;
            venueManagementToolStripMenuItem.Enabled = st;

            if (st)
            {
                toolStripButton5.Text = "&Logout";
            }
            else
            {
                toolStripButton5.Text = "&Login";
                toolStripLabel1.Text = "No, User";
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //if (!dateSet)
            //{
            //    MessageBox.Show("Date was not set yet.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            //}
            //if (Application.OpenForms["frmreservation2"] != null)
            //{

            //}
            //else
            //{
                frmreservation2 frm = new frmreservation2();
                mod_system.LoadForm(frm);
         //   }
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //if (!dateSet)
            //{
            //    MessageBox.Show("Date was not set yet.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            //}
            //if (Application.OpenForms["frmBooking"] != null)
            //{

            //}


            //else
            //{
                frmBooking frm = new frmBooking();
                mod_system.LoadForm(frm);
           // }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //if (!dateSet)
            //{
            //    MessageBox.Show("Date was not set yet.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            //}
            //if (Application.OpenForms["frmTransactionList"] != null)
            //{

            //}
            //else
            //{
                frmTransactionList frm = new frmTransactionList();
                mod_system.LoadForm(frm);
          //  }
          
        }

        private void openDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
             frmSetDate frm = new frmSetDate();
              mod_system.LoadForm(frm);
        }

    

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //if (!dateSet)
            //{
            //    MessageBox.Show("Date was not set yet.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            //}
            //if (Application.OpenForms["frmCustomerList"] != null)
            //{

            //}
            //else
            //{
                frmCustomerList frm = new frmCustomerList();
                frm.isFromCustomerForm = true;
                mod_system.LoadForm(frm);
          //  }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (mod_system.ORuser.Username == null)
            {
                NotYetLogin();
            }
            else
            {
                NotYetLogin(true);
               
            }
            toolStripButton5.PerformClick();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (  toolStripButton5.Text == "&Logout")
            {
                DialogResult result = MessageBox.Show("Do you really want to LOGOUT?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
            }

            dateSet = false;
            mod_system.ORuser = null;
            NotYetLogin();
            frmLogin lg = new frmLogin();
            mod_system.LoadForm(lg);
        }

        private void tmpTimer_Tick(object sender, EventArgs e)
        {
            //if (dateSet)
            //{
            //    tsDateset.Text = mod_system.CurrentDate.ToShortDateString() + " " + DateTime.Now.ToString("T");
            //    openDateToolStripMenuItem.Text = "&Close Date";
            //    mod_system.CheckExpiry();
            //}
            //else
            //{
            //    tsDateset.Text = "Date not set";
            //    openDateToolStripMenuItem.Text = "&Open Date";
            //}
        }

        private void dailySalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (!dateSet)
            //{
            //    MessageBox.Show("Date was not set yet.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            //}
            //if (Application.OpenForms["frmQeuryDate"] != null)
            //{

            //}
            //else
            //{
                frmQeuryDate frm = new frmQeuryDate();
                mod_system.LoadForm(frm);
           // }
        }

        internal void CheckDateStatus()
        {
            mod_system.LoadCurrentDate();
        }

        private void monthlySalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //if (!dateSet)
            //{
            //    MessageBox.Show("Date was not set yet.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            //}
            //if (Application.OpenForms["frmQeuryDate"] != null)
            //{
            //    (Application.OpenForms["frmQeuryDate"] as frmQeuryDate).isMonthly = true;
            //}
            //else
            //{
                frmQeuryDate frm = new frmQeuryDate();
                frm.isMonthly = true;
                mod_system.LoadForm(frm);
           // }
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //    if (!dateSet)
        //    {
        //        MessageBox.Show("Date was not set yet.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
        //    }
        //    if (Application.OpenForms["frmreservation2"] != null)
        //    {

        //    }
        //    else
        //    {
                frmUserManagement frm = new frmUserManagement();
                mod_system.LoadForm(frm);
           // }
           
        }

        private void venueManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //    if (!dateSet)
        //    {
        //        MessageBox.Show("Date was not set yet.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
        //    }
        //    if (Application.OpenForms["frmreservation2"] != null)
        //    {

        //    }
        //    else
        //    {
                frmVenueManagement frm = new frmVenueManagement();
                mod_system.LoadForm(frm);
           // }
        }

        private void schedulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (!dateSet)
            //{
            //    MessageBox.Show("Date was not set yet.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            //}
            //if (Application.OpenForms["frmreservation2"] != null)
            //{

            //}
            //else
            //{
                frmReport1 frm = new frmReport1();
                mod_system.LoadForm(frm);
           // }
        }
    }
}
