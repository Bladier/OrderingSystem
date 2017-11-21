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
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnBusManagement_Click(object sender, EventArgs e)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmPassengerList"] != null)
            {
                // (Application.OpenForms["frmPersonnelList"] as frmPersonnelList;
            }
            else
            {
                frmPassengerList frm = new frmPassengerList();
                frm.Show();
            }
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmTransaction"] != null)
            {
               
            }
            else
            {
                frmTransaction frm = new frmTransaction();
                frm.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmPersonnelList"] != null)
            {
               
            }
            else
            {
                frmPersonnelList frm = new frmPersonnelList();
                frm.Show();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
