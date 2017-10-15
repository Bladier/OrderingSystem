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
            LoadQueues();

        }

        private void LoadQueues()
        {
            string mysql = "SELECT * FROM TBLQUEUE WHERE STATUS = 1" ;
            DataSet ds = Database.LoadSQL(mysql, "TBLQUEUE");

            LVQueue.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string output = String.Format("ORDER # 0000{0}", dr[1].ToString());
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
            DataSet ds = Database.LoadSQL(mysql, "tblQueueInfo");

            lvListOrder.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                string mysql1 = "SELECT * FROM tblMenu WHERE ID = " + dr[0].ToString();
                DataSet ds1 = Database.LoadSQL(mysql1, "tblMenu");

                string Name = ds1.Tables[0].Rows[0]["MenuName"].ToString();
                string Desc = ds1.Tables[0].Rows[0]["MenuType"].ToString();
                string Size = ds1.Tables[0].Rows[0]["MenuSize"].ToString();
           
                ListViewItem lv = lvListOrder.Items.Add(Name);
                lv.SubItems.Add(Desc);
                lv.SubItems.Add(Size);
                lv.SubItems.Add(ds1.Tables[0].Rows[0]["Price"].ToString());
                lv.SubItems.Add(dr[3].ToString());

                lv.Tag = Convert.ToInt32(dr["ID"]);

                Application.DoEvents();
            }

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadQueues();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lvListOrder.SelectedItems.Count == 0) { return; }

            DialogResult result = MessageBox.Show("Do you want to remove this item?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                string mysql = "SELECT * FROM tblQueueInfo WHERE ID = " + lvListOrder.SelectedItems[0].Tag;
                DataSet ds = Database.LoadSQL(mysql, "tblQueueInfo");

                var with = ds.Tables[0].Rows[0];
                with["Status"] = 0;
                Database.SaveEntry(ds, false);

                lvListOrder.SelectedItems[0].Remove();
               
            }
        }


        internal void AddMenuItem(User mItem)
    {

        ListViewItem lv1 = lvListOrder.Items.Add(mItem.MenuName);

        lv1.SubItems.Add(mItem.MenuType);
        lv1.SubItems.Add(mItem.MenuSize);
        lv1.SubItems.Add(mItem.Price.ToString());
        lv1.SubItems.Add(mItem.Qty.ToString());

        Application.DoEvents();
        lv1.Tag = mItem.ID;
        
    }
         

        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form frm  = new frmProductList();
            frm.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

       
       
        ////private void button1_Click(object sender, EventArgs e)
        ////{
        ////    string input = Microsoft.VisualBasic.Interaction.InputBox("Title", "Prompt", "Default", 0, 0);
        ////}
       

     

    }
}
