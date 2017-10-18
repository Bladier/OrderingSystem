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
    public partial class frmAutorize : Form
    {
        public frmAutorize()
        {
            InitializeComponent();
        }

        private void frmAutorize_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { txtPassword.Focus(); }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnLogin.PerformClick(); }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "") { txtUsername.Focus(); return; }
            if (txtPassword.Text == "") { txtPassword.Focus(); return; }

            User u = new User();

            string un = txtUsername.Text;
            string up = txtPassword.Text;

            if (!u.LoginUser(un,up))
            {
                Interaction.MsgBox("Invalid Username and password", MsgBoxStyle.Critical);
                return;
            }

            if (u.Userrule != "Admin") { return; }

            frmOrderHistory frm = new frmOrderHistory();
            frm.Show();
            this.Close();
        }
    }
}
