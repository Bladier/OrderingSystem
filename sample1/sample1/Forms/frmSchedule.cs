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
    public partial class frmSchedule : Form
    {
        public frmSchedule()
        {
            InitializeComponent();
        }

        private void frmSchedule_Load(object sender, EventArgs e)
        {
            LoadTransaction();
        }


        private void LoadTransaction()
        {
            System.DateTime st =mod_system.GetFirstDate(monCal.SelectionStart);
            System.DateTime en = mod_system.GetLastDate(monCal.SelectionStart);

            string mysql1 = "SELECT * FROM transactiontbl where enddate Between '" + st + "'and '" + en + "' and (status = 'Reserved' OR status = 'Booked')";
            DataSet ds1 = Database.LoadSQL(mysql1, "transactiontbl");

            if (ds1.Tables[0].Rows.Count == 0) { return; }
            lvSchedule.Items.Clear();
            foreach (DataRow dr in ds1.Tables[0].Rows)
            {

                DateTime d1 = Convert.ToDateTime(Convert.ToDateTime(dr["StartDate"]));
                DateTime d2 = Convert.ToDateTime(Convert.ToDateTime(dr["EndDate"]));

                TimeSpan t = d2 - d1;
                double NrOfDays = Math.Round(t.TotalDays) + 1;


                if (NrOfDays >= 2)
                {
                    for (int i = 0; i < NrOfDays; i++)
                    {
                        d1 = d1.AddDays(i);

                        monCal.AddBoldedDate(DateTime.Parse(Convert.ToDateTime(d1).ToShortDateString()));
                        monCal.UpdateBoldedDates();

                        d1 = Convert.ToDateTime(Convert.ToDateTime(dr["StartDate"]));

                    }
                }
                else

                {
                    monCal.AddBoldedDate(DateTime.Parse(Convert.ToDateTime(d1).ToShortDateString()));
                    monCal.UpdateBoldedDates();
                }

                transaction tr = new transaction();
                tr.loadTrans(Convert.ToInt32(dr["ID"]));
                AddSchedule(tr);
            }

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            LoadTransaction();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void monCal_MouseHover(object sender, EventArgs e)
        {

        }

        private void AddSchedule(transaction tr)
        {
            Customer cs = new Customer();
            cs.LoadCust(tr.CusID);
            ListViewItem lv = lvSchedule.Items.Add(cs.fullname);
            lv.SubItems.Add(tr.StartDate.ToShortDateString() + " - " + tr.EndDate.ToShortDateString());
            lv.SubItems.Add(tr.Status);
        }

        private void btnPrint_Click(object sender, EventArgs e)
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
            mysql += "t.transactionNum,p.status as PayMent_Status,p.payment,p.transdate ";
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
