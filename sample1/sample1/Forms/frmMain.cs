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
        public frmMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmreservation2 frm = new frmreservation2();
            mod_system.LoadForm(frm);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmBooking frm = new frmBooking();
            mod_system.LoadForm(frm);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmTransactionList frm = new frmTransactionList();
            mod_system.LoadForm(frm);
        }
    }
}
