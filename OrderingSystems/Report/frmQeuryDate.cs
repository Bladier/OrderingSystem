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
    public partial class frmQeuryDate : Form
    {
        public frmQeuryDate()
        {
            InitializeComponent();
        }



        private void DailySales()
        {
            string fillData = "dsSalesDaily"; 
                        
            string mysql ="SELECT customer_order.ID,customer_order.ORDERNUM,customer_order.ORDERDATE, ";
                   mysql +="customer_order.QSTATUS,customer_order.QUEUEID,customer_order.MENUID, ";
                   mysql +="customer_order.QTY,customer_order.MENUNAME,customer_order.MENUTYPE, ";
                   mysql +="customer_order.MENUSIZE,customer_order.PRICE,customer_order.CASH, ";
                   mysql +="customer_order.AMOUNTDUE,customer_order.`CHANGE`, ";
                   mysql +="DATE_FORMAT(DOCDATE,'%m/%d/%Y')as 'DOCDATE', ";
                   mysql +="customer_order.QIID,customer_order.QIStatus,customer_order.BOStatus ";
                   mysql +="FROM customer_order ";
                   mysql += string.Format("where DATE_FORMAT(DOCDATE,'%m/%d/%Y')= '{0}'", monCal.SelectionStart.ToShortDateString());
                   mysql += " AND BOStatus = 1 AND QIStatus = 1";
            
            Dictionary<string, string> rptPara = new Dictionary<string, string>();
            rptPara.Add("txtDate", "Date: " + monCal.SelectionStart.ToString("MMM dd, yyyy"));
            rptPara.Add("IsDailyMonthly", "Daily Sales Report");

            frmReport frm = new frmReport();
            frm.ReportInit(mysql, fillData, @"Report\rptSalesReport.rdlc", rptPara);
            frm.Show();
        }

        private void MonthlySales()
        {
            dynamic stDay =mod_system.GetFirstDate(monCal.SelectionStart);
            dynamic laDay = mod_system.GetLastDate(monCal.SelectionEnd);
            string fillData = "dsSalesDaily";

            string mysql = "SELECT customer_order.ID,customer_order.ORDERNUM,customer_order.ORDERDATE, ";
            mysql += "customer_order.QSTATUS,customer_order.QUEUEID,customer_order.MENUID, ";
            mysql += "customer_order.QTY,customer_order.MENUNAME,customer_order.MENUTYPE, ";
            mysql += "customer_order.MENUSIZE,customer_order.PRICE,customer_order.CASH, ";
            mysql += "customer_order.AMOUNTDUE,customer_order.`CHANGE`, ";
            mysql += "DATE_FORMAT(DOCDATE,'%m/%d/%Y')as 'DOCDATE', ";
            mysql += "customer_order.QIID,customer_order.QIStatus,customer_order.BOStatus ";
            mysql += "FROM customer_order ";
            mysql += string.Format("where DATE_FORMAT(DOCDATE,'%m/%d/%Y') BETWEEN '" + stDay + "' AND '" + laDay + "'");
            mysql += " AND BOStatus = 1 AND QIStatus = 1";

            Dictionary<string, string> rptPara = new Dictionary<string, string>();
            rptPara.Add("txtDate", "FOR THE MONTH OF " + stDay.ToString("MMMM") + " " + stDay.Year);
            rptPara.Add("IsDailyMonthly", "Monthly Sales Report");

            frmReport frm = new frmReport();
            frm.ReportInit(mysql, fillData, @"Report\rptSalesReport.rdlc", rptPara);
            frm.Show();
        }


        private void rbDaily_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDaily.Checked)
            {
                cboReportType.Items.Clear();
                cboReportType.Items.Add("Daily Sales");
                cboReportType.Items.Add("Daily Void");
                cboReportType.Text = "Daily Sales";
            }
        }

        private void frmQeuryDate_Load(object sender, EventArgs e)
        {
            rbDaily_CheckedChanged(sender, e);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cboReportType.Text == "") { return; }
            if (cboReportType.Text=="Daily Sales")
            {
                DailySales();
            }
            if (cboReportType.Text == "Monthly Sales")
            {
                MonthlySales();
            }
        }

        private void rbMonthly_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMonthly.Checked)
            {
                cboReportType.Items.Clear();
                cboReportType.Items.Add("Monthly Sales");
                cboReportType.Items.Add("Monthly Void");
                cboReportType.Text = "Monthly Sales";
            }
        }

    }
}
