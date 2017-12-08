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

      
        private void frmMain2_Load(object sender, EventArgs e)
        {
           
        }

     
        private void transactionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void busConfirmationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            
        }

        private void busListToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void passengerToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            if (!mod_system.isSetDate())
            {
                MessageBox.Show("Not able to open this module Yet.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }


            if (Application.OpenForms["frmSetBus"] != null)
            {
                // (Application.OpenForms["frmPersonnelList"] as frmPersonnelList;
            }
            else
            {
                frmTransaction frmtrans = new frmTransaction();
                frmtrans.Show();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
           
          
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            if (!mod_system.isSetDate())
            {
                MessageBox.Show("Not able to open this module Yet.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }

            if (Application.OpenForms["frmSetBus"] != null)
            {
                // (Application.OpenForms["frmPersonnelList"] as frmPersonnelList;
            }
            else
            {
                frmPassengerTransactionList frm = new frmPassengerTransactionList();
                frm.Show();
            }
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            if (!mod_system.isSetDate())
            {
                MessageBox.Show("Not able to open this module Yet.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }

            if (Application.OpenForms["frmSetBusVersion2"] != null)
            {
                // (Application.OpenForms["frmPersonnelList"] as frmPersonnelList;
            }
            else
            {
                frmSetBusVersion2 frm = new frmSetBusVersion2();
                frm.Show();
            }
        }   

    }
}
