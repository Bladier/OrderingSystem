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
            //SelectionRange range = new SelectionRange(DateTime.Now,
            //                                DateTime.Now.AddDays(6.0));
            //monthCalendar1.SelectionRange = range;
           
          
        }


        private void LoadTransaction()
        {
            string mysql ="SELECT * FROM RESERVATIONTBL";
            DataSet ds = Database.LoadSQL(mysql, "RESERVATIONTBL");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                monthCalendar1.AddBoldedDate(DateTime.Parse(Convert.ToDateTime(dr["EndDate"]).ToShortDateString()));
                
                monthCalendar1.UpdateBoldedDates();
             
       
            }

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.TitleBackColor = Color.Red;
        }
    }
}
