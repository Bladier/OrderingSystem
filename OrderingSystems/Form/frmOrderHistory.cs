using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
namespace OrderingSystems
{
    public partial class frmOrderHistory : Form
    {
        public frmOrderHistory()
        {
            InitializeComponent();
        }

        private void frmOrderHistory_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            LoadOrder();
           LoadWholeOder();
        }

        #region "Void Per Item"
        private void LoadOrder(string mysql = "SELECT * FROM customer_order where QStatus ='S' ORDER BY ID DESC LIMIT 20")
    {
            DataSet ds = Database.LoadSQL(mysql, "customer_order");

            lvOrderHist.Items.Clear();
            foreach (DataRow itm in ds.Tables[0].Rows)
            {
                string output = String.Format("ODR#0000{0}", itm["OrderNum"].ToString());
                ListViewItem lv = lvOrderHist.Items.Add(output);
                lv.SubItems.Add(itm["MenuName"].ToString());
                lv.SubItems.Add(itm["MenuType"].ToString());
                lv.SubItems.Add(itm["MenuSize"].ToString());
                lv.SubItems.Add(itm["Price"].ToString());
                lv.SubItems.Add(itm["QTY"].ToString());

                lv.Tag = Convert.ToInt32(itm["QIID"]);
            }
    }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                LoadOrder();
            }
            else
            {
                string mysql = "SELECT * FROM customer_order WHERE ORDERNUM = '" + txtSearch.Text + "'";
                LoadOrder(mysql);
            }
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {

            if (lvOrderHist.SelectedItems.Count == 0) { return; }
            if (MessageBox.Show("Do you want to void this?", "Void", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
     
            QueueLines qi = new QueueLines();
            qi.voidOrder(Convert.ToInt32(lvOrderHist.SelectedItems[0].Tag));
            MessageBox.Show("Successfully voided.", "Void", MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            LoadOrder();
        }
        #endregion

        #region "Void Whole Order"
        private void LoadWholeOder(string mysql = "SELECT ID,ORDERNUM FROM tblqueue where Status = 'S' ORDER BY ID DESC LIMIT 20")
        {
            DataSet ds = Database.LoadSQL(mysql, "tblqueue");

            int x = 0;
            bool hasLoaded = false;
            lvOrderNum.Items.Clear();
            foreach (DataRow itm in ds.Tables[0].Rows)
            {
                x++;
                string output = String.Format("ODR#0000{0}", itm["OrderNum"].ToString());

                if (x == 1)
                {
                    ListViewItem lv = lvOrderNum.Items.Add(output);
                    lv.Tag = Convert.ToInt32(itm["ID"]);
                }
                else
                {
                int i;
                for (i = 0; i <= lvOrderNum.Items.Count - 1; i++)
               {
                    string orderNm = lvOrderNum.Items[i].SubItems[0].Text;
                    if (output == orderNm)
                    { hasLoaded = true; }
                }

                if (hasLoaded)
                {
                    goto NextLineTodo;
                }
                else
                {
                    ListViewItem lv = lvOrderNum.Items.Add(output);
                    lv.Tag = Convert.ToInt32(itm["ID"]);
                }

               }
            NextLineTodo: ;
                hasLoaded = false; 
            }
        }

        private void lvOrderNum_Click(object sender, EventArgs e)
        {
            if (lvOrderNum.SelectedItems.Count == 0) { return; }
            ViewOrder();
        }

        private void ViewOrder()
        {
            string mysql = "SELECT * FROM tblQueueInfo WHERE QueueID = " + lvOrderNum.SelectedItems[0].Tag + " and status ='1' ORDER BY ID ASC";
            DataSet ds = Database.LoadSQL(mysql, "tblQueueInfo");

            lvWholeOrder.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                string mysql1 = "SELECT * FROM tblMenu WHERE ID = " + dr[0].ToString();
                DataSet ds1 = Database.LoadSQL(mysql1, "tblMenu");

                string Name = ds1.Tables[0].Rows[0]["MenuName"].ToString();
                string Desc = ds1.Tables[0].Rows[0]["MenuType"].ToString();
                string Size = ds1.Tables[0].Rows[0]["MenuSize"].ToString();

                ListViewItem lv = lvWholeOrder.Items.Add(Name);
                lv.SubItems.Add(Desc);
                lv.SubItems.Add(Size);
                lv.SubItems.Add(ds1.Tables[0].Rows[0]["Price"].ToString());
                lv.SubItems.Add(dr[3].ToString());
                lv.SubItems.Add(dr[0].ToString());

                lv.Tag = Convert.ToInt32(dr["ID"]);
                Application.DoEvents();
            }
        }

        private void btnVoidWO_Click(object sender, EventArgs e)
        {
            if (lvOrderNum.SelectedItems.Count == 0)
            {
                return;
            }

            int idx = Convert.ToInt32(lvOrderNum.SelectedItems[0].Tag);

            ClientOrder cl = new ClientOrder();
            cl.Void_ClientOrder(idx);

            Queue q = new Queue();
            q.Void_Oueue(idx);

            int i;
            for (i = 0; i <= lvOrderNum.Items.Count - 1; i++)
            {
                QueueLines ql = new QueueLines();
                ql.voidOrder(Convert.ToInt32(lvOrderNum.Items[i].Tag));
            }

            MessageBox.Show("Successfully voided.", "Void", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            LoadWholeOder();
            lvWholeOrder.Items.Clear();
        }
        #endregion

        private void btnSearchWO_Click(object sender, EventArgs e)
        {
            if (txtSearchWholeOrder.Text == "")
            {
                LoadOrder();
            }
            else
            {
                string mysql = "SELECT * FROM tblqueue WHERE ORDERNUM = '" + txtSearchWholeOrder.Text + "'";
                LoadWholeOder(mysql);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnSearch.PerformClick(); }
        }

        private void txtSearchWholeOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnSearchWO.PerformClick(); }
        }

       


     
    }
}
