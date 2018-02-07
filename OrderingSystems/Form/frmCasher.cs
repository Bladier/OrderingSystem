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
using Microsoft.Reporting.WinForms;

namespace OrderingSystems
{
    public partial class frmCasher : Form
    {
        internal string OrderNumber="";
       

        internal bool isView = false;
        string AddQTY;
        protected double Total_Amount = 0.0;
        int tmpQID = 0;
        public bool isNew=false;

        Maintenance tmpMaintenance = new Maintenance();
        private string Printer;
        private string IsPrint;

        public frmCasher()
        {
            InitializeComponent();
        }

        private void frmCasher_Load(object sender, EventArgs e)
        {
            if (isView) { return; }
            
            LoadQueues();
            if (LVQueue.Items.Count == 0) { return; }
            LVQueue.Items[0].Selected = true;
            LVQueue.Select();
            ViewOrder();
        }

        private void ReViewOrder(bool st =true)
        {
            LVQueue.Enabled = st;
            btnAdd.Enabled = st;
            btnPrint.Enabled = st;
            btnRemove.Enabled = st;
            btnVoid.Enabled = st;
            lvListOrder.Enabled = st;
            txtCash.Enabled = st;

            LVQueue.Items.Clear();
        }

        private void LoadQueues()
        {
            string mysql = "SELECT * FROM TBLQUEUE WHERE STATUS = 'P' ORDER BY ID ASC " ;
            DataSet ds = Database.LoadSQL(mysql, "TBLQUEUE");

            LVQueue.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string output = String.Format("ODR#0000{0}", dr[1].ToString());
                ListViewItem lv = LVQueue.Items.Add(output);
                lv.Tag = dr[0].ToString();

                Application.DoEvents();
            }

        }

        private void LVQueue_MouseClick(object sender, MouseEventArgs e)
        {
            lvListOrder.Items.Clear();
            if (LVQueue.SelectedIndices[0] == 0) 
            { 
                ViewOrder();
                LVQueue.Items[0].Selected = true;
                LVQueue.Select();
            }

        }

        private void ViewOrder()
        {

            string mysql = "SELECT * FROM tblQueueInfo WHERE QueueID = " + LVQueue.SelectedItems[0].Tag + " and status ='1' ORDER BY ID ASC";
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
                lv.SubItems.Add(dr[0].ToString());

                double calc = Convert.ToDouble(ds1.Tables[0].Rows[0]["Price"]) * Convert.ToDouble(dr[3].ToString());
                lv.Tag = Convert.ToInt32(dr["ID"]);
                Total_Amount += calc;
                Application.DoEvents();
                
            }
            tmpQID = Convert.ToInt32(LVQueue.SelectedItems[0].Tag);
            lblAmountDue.Text = string.Format("{0:#,##0.00}", Total_Amount);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadQueues();
            ReViewOrder();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Cancel?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            ReViewOrder();
            ClearField();
            lvListOrder.Items.Clear();
            LoadQueues();

            if (LVQueue.Items.Count == 0) { return; }
            LVQueue.Items[0].Selected = true;
            LVQueue.Select();
            ViewOrder();
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
                string mysql = "SELECT * FROM tblQueueInfo WHERE ID = " + lvListOrder.SelectedItems[0].Tag + " and status =1";
                DataSet ds = Database.LoadSQL(mysql, "tblQueueInfo");

                var with = ds.Tables[0].Rows[0];
                with["Status"] = 0;
                Database.SaveEntry(ds, false);

                lvListOrder.SelectedItems[0].Remove();
                ReCalCulate();
            } 
               
            }


         internal void AddMenuItem(MenuItem mItem)
         {
             if (isView)
             {
                 ReViewOrder(false);
                ListViewItem lv=LVQueue.Items.Add(OrderNumber);
             }


             double tprice;
             int tQty;
             int i;

             if (!isView)
             {
                 for (i = 0; i <= lvListOrder.Items.Count - 1; i++)
                 {
                     if (lvListOrder.Items[i].Text == mItem.MenuName)
                     {
                         ListViewItem lv = lvListOrder.Items[i];
                         if (lv.SubItems[1].Text == mItem.MenuType)
                         {
                             if (lv.SubItems[2].Text == mItem.MenuSize)
                             {
                                 tprice = Convert.ToDouble(lv.SubItems[3].Text);
                                 tQty = Convert.ToInt32(lv.SubItems[4].Text);
                                 tprice = tprice + mItem.Price;
                                 tQty = tQty + mItem.Qty;
                                 lv.SubItems[3].Text = tprice.ToString();
                                 lv.SubItems[4].Text = tQty.ToString();
                                 return;
                             }
                         }
                     }
                 }
             }

             ListViewItem lv1 = lvListOrder.Items.Add(mItem.MenuName);

             lv1.SubItems.Add(mItem.MenuType);
             lv1.SubItems.Add(mItem.MenuSize);
             lv1.SubItems.Add(mItem.Price.ToString());
             lv1.SubItems.Add(mItem.Qty.ToString());
             lv1.SubItems.Add(mItem.ID.ToString());

             //QueueLines ql = new QueueLines();
             //lv1.Tag = ql.LoadLastID();
             ReCalCulate();

             isView = false;
             OrderNumber = "";
          }
     
      

        private void CalcChange()
        {
            if (lvListOrder.Items.Count == 0) { return; }

            double tmpchange = Convert.ToDouble(txtCash.Text) - Convert.ToDouble(lblAmountDue.Text);
            lblChange.Text = string.Format("{0:#,##0.00}", tmpchange);
        }

   
        private void ReCalCulate()
        {
            Total_Amount = 0.0;
            int i = 0;
            for (i = 0; i <= lvListOrder.Items.Count - 1; i++)
            {
                Total_Amount += Convert.ToDouble(lvListOrder.Items[i].SubItems[3].Text);
            }
            lblAmountDue.Text = string.Format("{0:#,##0.00}", Total_Amount);

            if (txtCash.Text != "")
            { CalcChange(); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (LVQueue.Items.Count == 0) { return; }
            frmProductList frm = new frmProductList();
            frm.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvListOrder.Items.Count ==0) 
            {MessageBox.Show("Nothing to POST!", "Posting",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
            return ;
            }

            if (txtCash.Text == "") { txtCash.Focus(); return; }
            if (Convert.ToDouble(txtCash.Text) < Convert.ToDouble(lblAmountDue.Text))
            {
                MessageBox.Show("Cash: {" + txtCash.Text + "} must not less than to Amount Due: {" + lblAmountDue.Text + "}", "Cash",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error); return;
            }


            ClientOrder co = new ClientOrder();
                    var with = co;
                    with.QID = tmpQID;
                    with.status = true;
                    with.Cash = Convert.ToDouble(txtCash.Text);
                    with.AmountDue = Convert.ToDouble(lblAmountDue.Text);
                    with.Change = Convert.ToDouble(lblChange.Text);
                    with.DocDate = Convert.ToDateTime(System.DateTime.Now);
                    with.savebill();

              Queue q = new Queue();
                    q.Set_Served(with.QID);

              //int i;
              //for (i = 0; i <= lvListOrder.Items.Count - 1; i++)
              //      {

              //          QueueLines ql = new QueueLines();
              //          var _with = ql;
              //          _with.QueueID = tmpQID;
              //          _with.MenuID = Convert.ToInt32(lvListOrder.Items[i].SubItems[5].Text);
              //          _with.QTY = Convert.ToDouble(lvListOrder.Items[i].SubItems[4].Text);
              //          _with.Price = Convert.ToDouble(lvListOrder.Items[i].SubItems[3].Text);
              //          _with.SaveInfo();
              //      }

              PrintOR(tmpQID);
            MessageBox.Show("Order POSTED", "Post",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                    ClearField();
                frmCasher_Load(sender, e);
            }
         
       
        private void txtCash_Leave(object sender, EventArgs e)
        {
            if (txtCash.Text != "")
            { CalcChange(); }
        }

        private void LVQueue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ViewOrder();
            }
        }

        private void PrintOR(int queueID)
        {
            System.Threading.Thread.Sleep(2000);
            // Check if able to print
            Printer = tmpMaintenance.GetValue("PrinterReciept");
            IsPrint = tmpMaintenance.GetValue("IsRecieptPrint");
            if (!canPrint(Printer))
            { return; }

            else
            {
                string mysql = "SELECT * FROM customer_order WHERE menuID = " + queueID + " and QIStatus =1";

                DataSet ds = null;
                string fillData = "TBLQUEUE";
                ds = Database.LoadSQL(mysql, fillData);

                string OrderNum = String.Format("ORDER # 0000{0}", ds.Tables[0].Rows[0]["ORDERNUM"].ToString());
                DateTime DocDate = Convert.ToDateTime(System.DateTime.Now);

                // Declare AutoPrint
                Reporting autoPrint = null;
                LocalReport report = new LocalReport();
                autoPrint = new Reporting();

                // Initialize Auto Print
                report.ReportPath = @"Report\rptReciept.rdlc";
                report.DataSources.Add(new ReportDataSource(fillData, ds.Tables[fillData]));

                // Assign Parameters
                Dictionary<string, string> dic = new Dictionary<string, string>();

                dic.Add("txtUsername", mod_system.ORuser.Username);

                // Importer Parameters
                if ((dic != null))
                {
                    foreach (KeyValuePair<string, string> param in dic)
                    {
                        var nPara = param;
                        ReportParameter tmpPara = new ReportParameter();
                        tmpPara.Name = nPara.Key;
                        tmpPara.Values.Add(nPara.Value);
                        report.SetParameters(new ReportParameter[] { tmpPara });
                        Console.WriteLine(string.Format("{0}: {1}", nPara.Key, nPara.Value));
                    }
                }

                if (IsPrint == "YES")
                {
                    frmReport frm = new frmReport();
                    frm.ReportInit(mysql, "dsORPRINT", @"Report\rptReciept.rdlc", dic);
                    frm.Show();
                }
                else
                {
                    // Executing Auto Print
                    autoPrint.Export(report);
                    autoPrint.m_currentPageIndex = 0;
                    autoPrint.Print(Printer);
                }
            }
        }

        private bool canPrint(string printerName)
        {
            try
            {
                System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
                printDocument.PrinterSettings.PrinterName = printerName;
                return printDocument.PrinterSettings.IsValid;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        #region "Clear"
        private void ClearField()
        {
            txtCash.Clear();
            lblAmountDue.Text = "0.00";
            lblChange.Text = "0.00";

        }
        #endregion

        private void lvListOrder_DoubleClick(object sender, EventArgs e)
        {
            UpdateOrder();
        }

        private void UpdateOrder()
        {
            int lv_item = lvListOrder.SelectedIndices[0];

            bool retNum = false;

            while (retNum == false)
            {
                AddQTY = Interaction.InputBox("Enter Qty", "Order", "");
                if (AddQTY == "") { return; }
                if (AddQTY == "0") { return; }
                if (AddQTY.Contains(".")) { return; }
                retNum = Information.IsNumeric(AddQTY);

                if (retNum == true)
                {
                    if (Convert.ToInt32(AddQTY) < 0) { return; }
                }
            }

            int NewQty = Convert.ToInt32(lvListOrder.Items[lv_item].SubItems[4].Text) + Convert.ToInt32(AddQTY);
            double oldPrice = Convert.ToDouble(lvListOrder.Items[lv_item].SubItems[3].Text) * Convert.ToInt32(NewQty);

            lvListOrder.Items[lv_item].SubItems[4].Text = Convert.ToString(NewQty);
            lvListOrder.Items[lv_item].SubItems[3].Text = Convert.ToString(oldPrice);
            ReCalCulate();
        }

        private void lvListOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { UpdateOrder(); }
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (mod_system.ORuser.Userrule == "Admin")
            {
                frmOrderHistory frm1 = new frmOrderHistory();
                frm1.Show();
                return;
            }

            frmAutorize frm = new frmAutorize();
            frm.ShowDialog();
        }

        private void txtCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnPrint.PerformClick(); }

        }

        private void btnTransList_Click(object sender, EventArgs e)
        {
            lvListOrder.Items.Clear();
            LVQueue.Items.Clear();
            ReViewOrder();
            ClearField();
            frmTransactionList frm = new frmTransactionList();
            frm.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Close?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            if (Application.OpenForms["frmCasher"] != null)
            {
                (Application.OpenForms["frmCasher"] as frmCasher).Show();
            }
            this.Close();
        }

        private void btnCancelTransaction_Click(object sender, EventArgs e)
        {
            if (LVQueue.SelectedItems.Count == 0) { return; }


            DialogResult result = MessageBox.Show("Do you want to cancel this transaction?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            int i =Convert.ToInt32(LVQueue.SelectedItems[0].Tag);
            Queue q = new Queue();
            q.Set_Cancel(i);

            MessageBox.Show("Transaction successfully cancelled", "Cancel",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
            ClearField();
            frmCasher_Load(sender, e);
        }

   

        /////////////////Break////////////////////

        }
    
    }

