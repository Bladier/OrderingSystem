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

        private void setBusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmMain.dateSet)
            {
                MessageBox.Show("Not able to open this module Yet.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }

            if (Application.OpenForms["frmSetBus"] != null)
            {
                // (Application.OpenForms["frmPersonnelList"] as frmPersonnelList;
            }
            else
            {
                frmSetBus frm = new frmSetBus();
                frm.Show();
            }
        }

        private void transactionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!frmMain.dateSet)
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

        private void busConfirmationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!frmMain.dateSet)
            {
                MessageBox.Show("Not able to open this module Yet.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }

            if (Application.OpenForms["frmSetBus"] != null)
            {
                // (Application.OpenForms["frmPersonnelList"] as frmPersonnelList;
            }
            else
            {
                frmConfirmation frm = new frmConfirmation();
                frm.Show();
            }
            
        }

        private void busListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmMain.dateSet)
            {
                MessageBox.Show("Not able to open this module Yet.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }

            if (Application.OpenForms["frmSetBus"] != null)
            {
                // (Application.OpenForms["frmPersonnelList"] as frmPersonnelList;
            }
            else
            {
                frmBusListTransaction frm = new frmBusListTransaction();
                frm.Show();
            }
          
        }

        private void passengerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmMain.dateSet)
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

    }
}
