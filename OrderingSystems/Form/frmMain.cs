using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using MySql.Data.MySqlClient;


namespace OrderingSystems
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCasher_Click(object sender, EventArgs e)
        {
            frmCasher frm = new frmCasher();
            frm.Show();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {

            frmClient frm = new frmClient();
            frm.Show();
        }

        private void btnConsole_Click(object sender, EventArgs e)
        {
            if (mod_system.ORuser.Userrule == "Admin")
            {
                frmConsole frm = new frmConsole();
                frm.Show();
            }
            else
            {
                MessageBox.Show("You don't have access in this module!", "Verification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (mod_system.ORuser.Userrule == "Admin")
            {
                frmOrderHistory frm = new frmOrderHistory();
                frm.Show();
            }
            else
            {
                MessageBox.Show("You don't have access in this module!", "Verification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            DialogResult result = MessageBox.Show("Do you really want to LOGOUT?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            if (Application.OpenForms["frmLogin"] != null)
            {
                (Application.OpenForms["frmLogin"] as frmLogin).Show();
                mod_system.ORuser = null;
                this.Close();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmQeuryDate frm = new frmQeuryDate();
            frm.Show();
        }
    }
}
