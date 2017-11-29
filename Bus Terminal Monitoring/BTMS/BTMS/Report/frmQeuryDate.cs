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
    public partial class frmQeuryDate : Form
    {
        public frmQeuryDate()
        {
            InitializeComponent();
        }


        private void DailySales()
        {
            string fillData = "dsSales";

            string mysql = "SELECT * FROM BUS_SALES where transStatus <> 0";
            mysql += string.Format(" and DATE_FORMAT(TransDate,'%m/%d/%Y')= '{0}'", monCal.SelectionStart.ToShortDateString());
            
            Dictionary<string, string> rptPara = new Dictionary<string, string>();
         
            frmReport frm = new frmReport();
            rptPara.Add("txtDate", "Date: " + monCal.SelectionStart.ToString("MMM dd, yyyy"));
            frm.ReportInit(mysql, fillData, @"Report\rptSales.rdlc", rptPara);
            frm.Show();
        }

        private void BusPassCount()
        {
            string fillData = "dsPassCount";

            string mysql = "SELECT * FROM BUS_SALES where busTransStatus <> 'C'";
            mysql += string.Format(" and DATE_FORMAT(TransDate,'%m/%d/%Y')= '{0}'", MonCalbus.SelectionStart.ToShortDateString());

            Dictionary<string, string> rptPara = new Dictionary<string, string>();

            frmReport frm = new frmReport();
            rptPara.Add("txtDate", "Date: " + MonCalbus.SelectionStart.ToString("MMM dd, yyyy"));
            frm.ReportInit(mysql, fillData, @"Report\rptPassengerCount.rdlc", rptPara);
            frm.Show();
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            DailySales();
        }

        private void btnGenerateBus_Click(object sender, EventArgs e)
        {
            BusPassCount();
        }

    }
}
