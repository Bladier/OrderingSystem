using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BTMS.Class
{
    public partial class frmSetBus : Form
    {
        public static string BusNo = "";
        public frmSetBus()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                if (Application.OpenForms["frmBusList"] != null)
                {
                     BusNo = txtPlateNum.Text;
                    (Application.OpenForms["frmBusList"] as frmBusList).Show();
                }
                else
                {
                    BusNo = txtPlateNum.Text;
                    frmBusList frm = new frmBusList();
                    frm.Show();
        }
    }
}
