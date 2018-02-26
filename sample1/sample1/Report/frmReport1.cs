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
    public partial class frmReport1 : Form
    {
        public frmReport1()
        {
            InitializeComponent();
        }

        private void frmReport1_Load(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            ScheduleReport();
        }

        private void ScheduleReport()
        {
            System.DateTime st = mod_system.GetFirstDate(monCal.SelectionStart);
            System.DateTime en = mod_system.GetLastDate(monCal.SelectionStart);

            string mysql = " select t.ID,v.Description,c.FirstName + ' ' + c.MiddleName + ' ' + c.LastName as Fullname,";
            mysql += "c.Street + ' ' + b.barangay + ' ,' + ci.city + ' ,' + c.province as Address,";
            mysql += "t.transdate,t.startDate,t.EndDate,t.status,t.total,t.balance,t.rate,t.Mod,";
            mysql += "t.transactionNum,p.status as PayMent_Status,p.payment,p.transdate,t.comments ";
            mysql += "from transactiontbl t ";
            mysql += "inner join venuetbl v on v.ID = t.venueID ";
            mysql += "inner join customertbl c on c.ID=t.customerID ";
            mysql += "inner join barangaytbl b on b.ID=c.barangayID ";
            mysql += "inner join citytbl ci on ci.ID=b.cityID ";
            mysql += "inner join paymenttbl p on p.resID =t.ID where ";
            mysql += string.Format(" p.status = 1 and t.status <> 'Cancel' and t.EndDate between '{0}' and '{1}'", st, en);


            Dictionary<string, string> rptPara = new Dictionary<string, string>();

            frmReport frm = new frmReport();

            frm.ReportInit(mysql, "dsSchedules", @"Report\rptSchedules.rdlc");
            frm.Show();

        }
    }
}
