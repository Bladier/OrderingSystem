using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OrderingSystems
{
    public partial class frmSample : Form
    {
        public frmSample()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mysql = "Select * From tblMenu";
            string rpt_Path = "Report\rpt_Menu.rdlc";
            //if (Application.OpenForms["frmReport"] != null)
            //{
            //    (Application.OpenForms["frmReport"] as frmReport).ReportInit(mysql,"dsMenuItem",rpt_Path);
            //    (Application.OpenForms["frmReport"] as frmReport).Show();
            //}

            frmReport tmp = new frmReport();
            tmp.ReportInit(mysql, "dsMenuItem", rpt_Path);
            tmp.Show();
        }
    }
}
