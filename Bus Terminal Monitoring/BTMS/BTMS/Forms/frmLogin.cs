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

namespace BTMS
{
    public partial class frmLogin : Form
    {
        int i = 0;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "") { txtusername.Focus(); }
            if (txtPassword.Text == "") { txtPassword.Focus(); }

            string username = txtusername.Text;
         
            string userpass = mod_system.DreadKnight(txtPassword.Text);
            
            User loginUser =new User();
            if (!loginUser.LoginUser(username, userpass)) {
		    i++;
			if (i >= 3) {
				Interaction.MsgBox("You have reached the MAXIMUM logins. This is a recording.", MsgBoxStyle.Critical);
				System.Environment.Exit(0);
			}
			Interaction.MsgBox("Invalid Username and password", MsgBoxStyle.Critical);
            txtPassword.Clear(); txtPassword.Focus();
			return;
		}

		// Success!
		mod_system.ORuser = loginUser;
		mod_system.UserID = mod_system.ORuser.ID;
		Interaction.MsgBox("Welcome " + mod_system.ORuser.Username + " " + mod_system.ORuser.Lastname);

        if (loginUser.Userrule == "Inspector")
        {

            frmMain2 frm1 = new frmMain2();
            frm1.Show();
            txtPassword.Clear();
            txtusername.Clear();
            i = 0;
            this.Hide();
            return;
        }

         frmMain frm = new frmMain();
         frm.Show();
          
        txtPassword.Clear();
        txtusername.Clear();
        i = 0;
        this.Hide();
	}

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtusername.Focus();
        }

        private void txtusername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOkay.PerformClick();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
            
        }

    }

