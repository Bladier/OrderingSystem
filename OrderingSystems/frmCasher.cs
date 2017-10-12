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
    public partial class frmCasher : Form
    {
        public frmCasher()
        {
            InitializeComponent();
        }

        private void frmCasher_Load(object sender, EventArgs e)
        {
            LoadBorrowings();

        }

        private void LoadBorrowings()
        {
            string mysql = "SELECT * FROM TBLQUEUE WHERE STATUS = 1" ;
            DataSet ds = DB.LoadSQL(mysql, "TBLQUEUE");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string output = String.Format("#0000{0}", dr[1].ToString());
                ListViewItem lv = LVQueue.Items.Add(output);
                lv.Tag = dr[0].ToString();

                Application.DoEvents();
            }

        }

        private void LVQueue_MouseClick(object sender, MouseEventArgs e)
        {
            ViewOrder();
        }

        private void ViewOrder()
        {
            string mysql = "SELECT * FROM tblQueueInfo WHERE QueueID = " + LVQueue.SelectedItems[0].Tag;
            DataSet ds = DB.LoadSQL(mysql, "tblQueueInfo");

            lvListOrder.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                string mysql1 = "SELECT * FROM tblMenu WHERE ID = " + dr[0].ToString();
                DataSet ds1 = DB.LoadSQL(mysql1, "tblMenu");

                string Name = ds1.Tables[0].Rows[0][1].ToString();
                string Desc = ds1.Tables[0].Rows[0][2].ToString();
                string Size = ds1.Tables[0].Rows[0][3].ToString();

                ListViewItem lv = lvListOrder.Items.Add(Name);
                lv.SubItems.Add(Desc);
                lv.SubItems.Add(Size);
                lv.SubItems.Add(ds1.Tables[0].Rows[0][4].ToString());
                lv.SubItems.Add(dr[3].ToString());

                lv.Tag = Convert.ToInt32(ds1.Tables[0].Rows[0][0].ToString());

                Application.DoEvents();
            }

        }

    }
}
