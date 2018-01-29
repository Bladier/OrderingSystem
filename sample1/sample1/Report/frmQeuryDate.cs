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
    public partial class frmQeuryDate : Form
    {
        internal bool isMonthly = false;
        
        public frmQeuryDate()
        {
            InitializeComponent();
        }


        private void DailySales()
        {
            DateTime d = Convert.ToDateTime(monCal.SelectionStart.ToShortDateString());
            string datestring = d.ToString("yyyy-MM-dd");


            string mysql = " select t.ID,v.Description,c.FirstName + ' ' + c.MiddleName + ' ' + c.LastName as Fullname,";
            mysql += "c.Street + ' ' + b.barangay + ' ,' + ci.city + ' ,' + c.province as Address,";
            mysql += "t.transdate,t.startDate,t.EndDate,t.status,t.total,t.balance,t.rate,t.Mod,";
            mysql += "t.transactionNum,p.status as PayMent_Status,p.payment,p.transdate ";
            mysql += "from transactiontbl t ";
            mysql += "inner join venuetbl v on v.ID = t.venueID ";
            mysql += "inner join customertbl c on c.ID=t.customerID ";
            mysql += "inner join barangaytbl b on b.ID=c.barangayID ";
            mysql += "inner join citytbl ci on ci.ID=b.cityID ";
            mysql += "inner join paymenttbl p on p.resID =t.ID where ";
            mysql += string.Format(" p.status = 1 and t.status <> 'Cancel' and t.transdate= '{0}'", datestring);

            Dictionary<string, string> rptPara = new Dictionary<string, string>();

            frmReport frm = new frmReport();
            rptPara.Add("txtDate", "Date: " + monCal.SelectionStart.ToString("MMM dd, yyyy"));
            rptPara.Add("IsDaily", "Daily Sales Report");
 
            frm.ReportInit(mysql, "dsSales", @"Report\rptSalesReport.rdlc", rptPara);
            frm.Show();

        }

        private void MonthlySales()
        {
            DateTime start = Convert.ToDateTime(mod_system.GetFirstDate(monCal.SelectionStart));
            DateTime end = Convert.ToDateTime(mod_system.GetLastDate(monCal.SelectionEnd));
            string datestring1 = start.ToString("yyyy-MM-dd");
            string datestring2= end.ToString("yyyy-MM-dd");

            string mysql = " select t.ID,v.Description,c.FirstName + ' ' + c.MiddleName + ' ' + c.LastName as Fullname,";
            mysql += "c.Street + ' ' + b.barangay + ' ,' + ci.city + ' ,' + c.province as Address,";
            mysql += "t.transdate,t.startDate,t.EndDate,t.status,t.total,t.balance,t.rate,t.Mod,";
            mysql += "t.transactionNum,p.status as PayMent_Status,p.payment,p.transdate ";
            mysql += "from transactiontbl t ";
            mysql += "inner join venuetbl v on v.ID = t.venueID ";
            mysql += "inner join customertbl c on c.ID=t.customerID ";
            mysql += "inner join barangaytbl b on b.ID=c.barangayID ";
            mysql += "inner join citytbl ci on ci.ID=b.cityID ";
            mysql += "inner join paymenttbl p on p.resID =t.ID where ";
            mysql += string.Format(" p.status = 1 and t.status <> 'Cancel' and t.transdate between '{0}' and '{1}'", datestring1, datestring2);

            Dictionary<string, string> rptPara = new Dictionary<string, string>();

            frmReport frm = new frmReport();
            rptPara.Add("txtDate", "For the month of : " + mod_system.GetFirstDate(monCal.SelectionStart).ToString("MMM , yyyy"));
            rptPara.Add("IsDaily", "Monthly Sales Report");

            frm.ReportInit(mysql, "dsSales", @"Report\rptSalesReport.rdlc", rptPara);
            frm.Show();

        }
     
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (isMonthly)
            {
                MonthlySales();
            }
            else
            {
                DailySales();
            }
          
        }


    }
}
