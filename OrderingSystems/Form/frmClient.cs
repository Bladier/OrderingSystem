using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.Reporting.WinForms;

namespace OrderingSystems
{
    public partial class frmClient : Form
    {
        string tmpQty ;
        Queue QueOrder;
        public frmClient()
        {
            InitializeComponent();
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            ClearText();
        }

        private void ClearText()
        {
            lvDisplay.Items.Clear();
            lvOrderList.Items.Clear();
        }

        private void AddItemDisplay(DataRow dr)
        {
            ListViewItem lv = lvDisplay.Items.Add(dr["MenuType"].ToString());
             lv.SubItems.Add(dr["MenuSize"].ToString());
             lv.SubItems.Add(dr["Price"].ToString());
             lv.Tag = dr["ID"].ToString();
        }

        private void AddItemOrder(MenuItem tmpItem)
        {
            ListViewItem lv = lvOrderList.Items.Add(tmpItem.MenuName);
            lv.SubItems.Add(tmpItem.MenuType);
            lv.SubItems.Add(tmpItem.MenuSize);
            double tmpPrice = Convert.ToDouble(tmpItem.Price.ToString());
            lv.SubItems.Add(tmpItem.Price.ToString());
            lv.SubItems.Add(tmpItem.Qty.ToString());
            lv.Tag = tmpItem.ID ;
        }

        private void btnSoftDrink_Click(object sender, EventArgs e)
        {
            string mysql = "Select * From tblMenu Where MenuName = 'Softdrinks'";
            DataSet ds =Database.LoadSQL(mysql, "tblMenu");

            lvDisplay.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                AddItemDisplay(dr);
            }

        }

        private void btnPizza_Click(object sender, EventArgs e)
        {
            string mysql = "Select * From tblMenu Where MenuName = 'Pizza'";
            DataSet ds = Database.LoadSQL(mysql, "tblMenu");

            lvDisplay.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                AddItemDisplay(dr);
            }
        }

        private void btnPasta_Click(object sender, EventArgs e)
        {
            string mysql = "Select * From tblMenu Where MenuName = 'Pasta'";
            DataSet ds = Database.LoadSQL(mysql, "tblMenu");

            lvDisplay.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                AddItemDisplay(dr);
            }
        }

        private void btnBurger_Click(object sender, EventArgs e)
        {
            string mysql = "Select * From tblMenu Where MenuName = 'Burger'";
            DataSet ds = Database.LoadSQL(mysql, "tblMenu");

            lvDisplay.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                AddItemDisplay(dr);
            }
        }

        private void btnHaloHalo_Click(object sender, EventArgs e)
        {
            string mysql = "Select * From tblMenu Where MenuName = 'Halo- Halo'";
            DataSet ds = Database.LoadSQL(mysql, "tblMenu");

            lvDisplay.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                AddItemDisplay(dr);
            }
        }

        private void btnPick_Click(object sender, EventArgs e)
        {
            if (lvDisplay.SelectedItems.Count < 1){return;}

            int idx = Convert.ToInt32(lvDisplay.FocusedItem.Tag.ToString());
            bool retNum = false;
            
            while (retNum == false)
            {
                tmpQty = Interaction.InputBox("Enter Qty", "Order", "");
                if (tmpQty == "") { return; }
                if (tmpQty == "0") { return; }
                if (tmpQty.Contains(".")) { return; }

                retNum = Information.IsNumeric(tmpQty);

                if (retNum == true)
                {
                    if (Convert.ToInt32(tmpQty) < 0) { return; }
                }
            }
           
            MenuItem tmpMenu = new MenuItem();
            tmpMenu.ID = idx;

            if (tmpMenu.Hasqty(Convert.ToInt32(tmpQty)))
            {
                tmpMenu.LoadMenuItem();
                tmpMenu.Qty = Convert.ToInt32(tmpQty);
                AddItemOrder(tmpMenu);
            }

        }

        private void btnClearOrder_Click(object sender, EventArgs e)
        {
            lvOrderList.Items.Clear();
        }

        private void lvOrderList_KeyDown(object sender, KeyEventArgs e)
        {
            if (lvOrderList.SelectedItems.Count == 0) { return; }
            int idx = lvOrderList.FocusedItem.Index;
            if (e.KeyCode == Keys.Delete)
            {
                DialogResult DeleteResult = MessageBox.Show("Do you want to delete this?", "Information", MessageBoxButtons.YesNo);
                if (DeleteResult == DialogResult.No) { return; }

                lvOrderList.Items[idx].Remove();
            }
           
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            QueOrder = new Queue();
            Maintenance tmpMain = new Maintenance();
            string tmpOrderNum = tmpMain.GetValue("ORDERNUM");

            var with = QueOrder;
            with.OrderNum = tmpOrderNum ; //Queue Number from table Maintenance
            with.OrderDate = DateTime.Now;
            //with.Status = true;
            with.SaveQueue();

            foreach (ListViewItem lv in lvOrderList.Items)
            {
                QueueLines tmpLines = new QueueLines();
                tmpLines.QueueID = QueOrder.GetLastID();
                tmpLines.MenuID = Convert.ToInt32(lv.Tag);
                tmpLines.QTY = Convert.ToDouble(lv.SubItems[4].Text.ToString());
                tmpLines.Price = Convert.ToDouble(lv.SubItems[3].Text.ToString());
                tmpLines.Status = true;
                tmpLines.SaveInfo();

                MenuItem mi = new MenuItem();
                mi.deduct(Convert.ToInt32(lv.SubItems[4].Text), tmpLines.MenuID);

            }
            MessageBox.Show("Order Post", "Information");

            int tmpNum = Convert.ToInt32(tmpOrderNum) + 1;
            string finalNum = Convert.ToString(tmpNum);
            tmpMain.UpdateOption("ORDERNUM", finalNum);

            lvDisplay.Items.Clear();
            lvOrderList.Items.Clear();

            string optPrint = tmpMain.GetValue("ORDERPRINT");
            //if (optPrint == "YES") 
            //{
                Reporting AutoPrint = new Reporting();
                string printerName = tmpMain.GetValue("PrinterOrder");
                //if (canPrint(printerName)==false) {return ;}
                LocalReport report = new LocalReport();
                String dsName = "dsOrderPrint";

                string mysql = "Select OrderNum From tblQueue Where ID = '" + QueOrder.GetLastID() +"'";
                DataSet ds = Database.LoadSQL(mysql,"tblQueue");

    
               
                report.ReportPath = @"Report\rpt_OrderPrint.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource(dsName, ds.Tables[0]));

                Dictionary<string, string> addParameters = new Dictionary<string, string>();

                if ((addParameters != null))
                {
                    foreach (KeyValuePair<string, string> nPara_loopVariable in addParameters)
                    {
                        var nPara = nPara_loopVariable;
                        ReportParameter tmpPara = new ReportParameter();
                        tmpPara.Name = nPara.Key;
                        tmpPara.Values.Add(nPara.Value);
                        report.SetParameters(new ReportParameter[] { tmpPara });
                    }
                }

                Dictionary<string, double> paperSize = new Dictionary<string,double>();
                paperSize.Add("width", 3.5);
                paperSize.Add("height", 2.5);


                if (optPrint == "YES")
                {
                    try
                    {
                        AutoPrint.Export(report, paperSize);
                        AutoPrint.m_currentPageIndex = 0;
                        AutoPrint.Print(printerName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "PRINT FAILED");
                    }
                }
                else
                {
                    frmReport frm = new frmReport();
                    frm.ReportInit(mysql, "dsOrderPrint", @"Report\rpt_OrderPrint.rdlc");
                    frm.Show();
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
            catch
            { return false; }
        }

        private void lvDisplay_DoubleClick(object sender, EventArgs e)
        {
            btnPick.PerformClick();
        }

        private void lvDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e))
            {
                btnPick.PerformClick();
            }

        }

    }
}
