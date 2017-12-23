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
            panel1.Controls.Clear();
            frmreservation2 frm = new frmreservation2();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.panel1.Controls.Add(frm);
            frm.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frmBooking frm = new frmBooking();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.panel1.Controls.Add(frm);
            frm.Show();
        }
    }
}
