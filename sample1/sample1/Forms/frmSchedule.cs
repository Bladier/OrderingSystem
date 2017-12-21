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

            string mysql = "SELECT * FROM RESERVATIONTBL where enddate Between '" + st + "'and '" + en + "' and status <> 'Cancel'";
            DataSet ds = Database.LoadSQL(mysql, "RESERVATIONTBL");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                monCal.AddBoldedDate(DateTime.Parse(Convert.ToDateTime(dr["EndDate"]).ToShortDateString()));
                monCal.UpdateBoldedDates();
            }

            string mysql1 = "SELECT * FROM transactiontbl where enddate Between '" + st + "'and '" + en + "' and status <> 'Cancel'";
            DataSet ds1 = Database.LoadSQL(mysql1, "transactiontbl");

            foreach (DataRow dr in ds1.Tables[0].Rows)
            {
                monCal.AddBoldedDate(DateTime.Parse(Convert.ToDateTime(dr["EndDate"]).ToShortDateString()));
                monCal.UpdateBoldedDates();

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
