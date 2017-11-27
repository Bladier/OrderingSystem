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

        private void btnBuslistTrans_Click(object sender, EventArgs e)
        {
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

        private void btnTravel_Click(object sender, EventArgs e)
        {
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

        private void btnVoidpassTrans_Click(object sender, EventArgs e)
        {
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

        private void frmMain2_Load(object sender, EventArgs e)
        {
           
        }   

    }
}
