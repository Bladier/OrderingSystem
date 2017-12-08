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
    public partial class frmAutorization : Form
    {
        public static bool IsAuthorize=false;
         int i = 0;

        public frmAutorization()
        {
            InitializeComponent();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e))
            {
                authorization();
            }
        }

        private void authorization()
        {
            if (txtUsername.Text == "") { txtUsername.Focus(); }
            if (txtPassword.Text == "") { txtPassword.Focus(); }

            string username = txtUsername.Text;

            string userpass = mod_system.DreadKnight(txtPassword.Text);

            User loginUser = new User();
            if (!loginUser.LoginUser(username, userpass))
            {
                i++;
                if (i >= 3)
                {
                    Interaction.MsgBox("You have reached the MAXIMUM attemps. This is a recording.", MsgBoxStyle.Critical);
                    this.Close();
                    return;
                }
                Interaction.MsgBox("Invalid Username and password", MsgBoxStyle.Critical);
                txtPassword.Clear(); txtPassword.Focus();
                return;
            }

     
            if (loginUser.Userrule == "Inspector")
            {
                IsAuthorize = true;
            }
            if (loginUser.Userrule == "Admin")
            {
                IsAuthorize = true;
         
            }
            isAuthorizedPerson();
            this.Close();
        }

        private void frmAutorization_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        public bool isAuthorizedPerson()
        {
            if (IsAuthorize)
            {
                if (Application.OpenForms["frmSetBusVersion2"] != null)
                {
                    (Application.OpenForms["frmSetBusVersion2"] as frmSetBusVersion2).btnAuthorization.Text = "Verified";
                }
                return true;
            }
            return false;
        }
       

    }
}
