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
            frmConsole frm = new frmConsole();
            frm.Show();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            
        }
    }
}
