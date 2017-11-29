using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BTMS
{
    public partial class frmMain : Form
    {
        public static bool isAdmin;
        public static bool dateSet;
        public frmMain()
        {
            InitializeComponent();
        }

        internal void notYetLogin(bool st = true)
        {
           

        }

       
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void tmpTimer_Tick(object sender, EventArgs e)
        {
            if (dateSet)
            {
                tsDateset.Text = mod_system.CurrentDate.ToShortDateString() + " " + DateTime.Now.ToString("T");
                dateSetToolStripMenuItem.Text = "&Date closing";
            }
            else
            {
                tsDateset.Text = "Date not set";
                dateSetToolStripMenuItem.Text = "&Date setting";
            }
        }
        internal void CheckDateStatus()
        {
            mod_system.LoadCurrentDate();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
         
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (mod_system.ORuser.Username == null)
            {
                notYetLogin();
            }
            else
            {
                notYetLogin(false);
            }
        }


        private void dateSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmSetDate"] != null)
            {
             
            }
            else
            {
                frmSetDate frm = new frmSetDate();
                frm.Show();
            }
        }

        private void busManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!dateSet)
            {
                MessageBox.Show("Not able to open this module Yet.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }

            isAdmin = true;
            if (Application.OpenForms["frmBusList"] != null)
            {
                // (Application.OpenForms["frmPersonnelList"] as frmPersonnelList;
            }
            else
            {
                frmBusList frm = new frmBusList();
                frm.Show();
            }
        }

        private void clientManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!dateSet)
            {
                MessageBox.Show("Not able to open this module Yet.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }

            if (Application.OpenForms["frmPassengerList"] != null)
            {

            }
            else
            {
                frmPassengerList frm = new frmPassengerList();
                frm.Show();
            }
        }

        //private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (!dateSet)
        //    {
        //        MessageBox.Show("Not able to open this module Yet.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
        //    }
        //    if (Application.OpenForms["frmTransaction"] != null)
        //    {

        //    }
        //    else
        //    {
        //        frmTransaction frm = new frmTransaction();
        //        frm.Show();
        //    }
        //}

        private void busPersonnelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!dateSet)
            {
                MessageBox.Show("Not able to open this module Yet.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }
            if (Application.OpenForms["frmPersonnelList"] != null)
            {

            }
            else
            {
                frmPersonnelList frm = new frmPersonnelList();
                frm.Show();
            }
        }

        private void loadingAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!dateSet)
            {
                MessageBox.Show("Not able to open this module Yet.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }
            if (Application.OpenForms["frmLoading"] != null)
            {

            }
            else
            {
                frmLoading frm = new frmLoading();
                frm.Show();
            }
        }

        private void maintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!dateSet)
            {
                MessageBox.Show("Not able to open this module Yet.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }

            if (Application.OpenForms["frmSettings"] != null)
            {

            }
            else
            {
                frmSettings frm = new frmSettings();
                frm.Show();
            }
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!dateSet)
            {
                MessageBox.Show("Not able to open this module Yet.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }
            if (Application.OpenForms["frmQeuryDate"] != null)
            {

            }
            else
            {
                frmQeuryDate frm = new frmQeuryDate();
                frm.Show();
            }
          
        }

       
    }
}
