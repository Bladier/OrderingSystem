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
            DateTime d = Convert.ToDateTime(monCal.SelectionStart.ToShortDateString());
            string datestring = d.ToString("yyyy-MM-dd");

            string mysql = "SELECT * FROM BUS_SALES where transStatus <> 0";
            mysql += string.Format(" and TransDate= '{0}'", datestring);
            
            Dictionary<string, string> rptPara = new Dictionary<string, string>();
         
            frmReport frm = new frmReport();
            rptPara.Add("txtDate", "Date: " + monCal.SelectionStart.ToString("MMM dd, yyyy"));
            frm.ReportInit(mysql, fillData, @"Report\rptSales.rdlc", rptPara);
            frm.Show();
        }

        private void BusPassCount()
        {
            string fillData = "dsPassCount";
            DateTime d = Convert.ToDateTime(monCal.SelectionStart.ToShortDateString());
            string datestring = d.ToString("yyyy-MM-dd");

            string mysql = "SELECT * FROM BUS_SALES where busTransStatus <> 'C'";
            mysql += string.Format(" and TransDate= '{0}'", datestring);

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
