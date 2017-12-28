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

            string mysql1 = "SELECT * FROM transactiontbl where enddate Between '" + st + "'and '" + en + "' and (status <> 'Cancel' OR status = 'Expired')";
            DataSet ds1 = Database.LoadSQL(mysql1, "transactiontbl");

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
    }
}
