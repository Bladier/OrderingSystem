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
    public partial class frmMain2 : Form
    {
        public frmMain2()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmTransaction frmtrans = new frmTransaction();
            frmtrans.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSetBus f = new frmSetBus();
            f.Show();
        }
    }
}
