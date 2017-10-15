using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace OrderingSystems
{
    public partial class frmCasher : Form
    {
        protected double Total_Amount = 0.0;
        int tmpQID = 0;
        public bool isNew=false;
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
            string mysql = "SELECT * FROM tblQueueInfo WHERE QueueID = " + LVQueue.SelectedItems[0].Tag + " and status =1";
            DataSet ds = Database.LoadSQL(mysql, "tblQueueInfo");

            lvListOrder.Items.Clear(); Total_Amount = 0.0;
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

                Total_Amount += Convert.ToDouble(ds1.Tables[0].Rows[0]["Price"]);
                Application.DoEvents();
                
            }
            tmpQID = Convert.ToInt32(LVQueue.SelectedItems[0].Tag);
            lblAmountDue.Text = string.Format("{0:#,##0.00}", Total_Amount);
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
                //if new order
                if (isNew) { lvListOrder.SelectedItems[0].Remove(); isNew = false; ReCalCulate(); return; }

                //Old order
                string mysql = "SELECT * FROM tblQueueInfo WHERE ID = " + lvListOrder.SelectedItems[0].Tag;
                DataSet ds = Database.LoadSQL(mysql, "tblQueueInfo");

                var with = ds.Tables[0].Rows[0];
                with["Status"] = 0;
                Database.SaveEntry(ds, false);

                lvListOrder.SelectedItems[0].Remove();
<<<<<<< HEAD:OrderingSystems/frmCasher.cs
                ReCalCulate();
            } 
               
            }
        }


        internal void AddMenuItem(User mItem)
    {
        //double tprice;
        //int tQty;
        //    int i;
        //    for (i = 0; i <= lvListOrder.Items.Count - 1; i++) {
        //    if (lvListOrder.Items[i].Text == mItem.MenuName) {
        //        ListViewItem lv = lvListOrder.Items[i];
        //        if (lv.SubItems[1].Text == mItem.MenuType) {
        //            if (lv.SubItems[2].Text == mItem.MenuSize)
        //            {
        //                tprice =Convert.ToDouble(lv.SubItems[3].Text);
        //                tQty = Convert.ToInt32(lv.SubItems[4].Text);
        //                tprice = tprice + mItem.Price;
        //                tQty = tQty + mItem.Qty;
        //                lv.SubItems[3].Text = tprice.ToString();
        //                lv.SubItems[4].Text = tQty.ToString() ;
        //                return;
        //            }
        //        }
        //    }


            //}
            ListViewItem lv1 = lvListOrder.Items.Add(mItem.MenuName);

            lv1.SubItems.Add(mItem.MenuType);
            lv1.SubItems.Add(mItem.MenuSize);
            lv1.SubItems.Add(mItem.Price.ToString());
            lv1.SubItems.Add(mItem.Qty.ToString());

            QueueLines ql = new QueueLines();
            lv1.Tag = ql.LoadLastID();
       
    }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tmpQID == 0) { Interaction.MsgBox("Please select client Order Number.", Constants.vbCritical, "Tagging Order"); return; }

            Form frm  = new frmProductList(tmpQID);
            frm.Show();
        }
        Application.DoEvents();
        lv1.Tag = mItem.ID;
        
    }

        private void txtCash_Leave(object sender, EventArgs e)
        {
            if (txtCash.Text != "")
            { CalcChange(); }
        }

        private void CalcChange()
        {
            if (lvListOrder.Items.Count == 0) { return; }

            double tmpchange = Convert.ToDouble(txtCash.Text) - Convert.ToDouble(lblAmountDue.Text);
            lblChange.Text = string.Format("{0:#,##0.00}", tmpchange);
        }

        private void ReCalCulate()
        {

            int i = 0;
            for (i = 0; i <= lvListOrder.Items.Count - 1; i++)
            {
                Total_Amount += Convert.ToDouble(lvListOrder.Items[i].SubItems[3].Text);
            }
            lblAmountDue.Text = string.Format("{0:#,##0.00}", Total_Amount);

            if (txtCash.Text != "")
            { CalcChange(); }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

    }
}
