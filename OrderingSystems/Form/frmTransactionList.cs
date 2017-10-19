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
    public partial class frmTransactionList : Form
    {
        Maintenance tmpMaintenance = new Maintenance();
        private string Printer;
        private string IsPrint;
        public frmTransactionList()
        {
            InitializeComponent();
        }

        private void frmTransactionList_Load(object sender, EventArgs e)
        {
            LoadWholeOder();
        }

        private void LoadWholeOder(string mysql = "SELECT * FROM customer_order where BOStatus = '1' ORDER BY ID DESC LIMIT 20")
        {
            DataSet ds = Database.LoadSQL(mysql, "tblqueue");
            if (ds.Tables[0].Rows.Count == 0) { return; }

            int x = 0;
            bool hasLoaded = false;
            lvTransactionList.Items.Clear();
            foreach (DataRow itm in ds.Tables[0].Rows)
            {
                x++;
                string output = String.Format("ODR#0000{0}", itm["OrderNum"].ToString());

                if (x == 1)
                {
                    ListViewItem lv = lvTransactionList.Items.Add(output);

                    lv.SubItems.Add(itm["DOCDATE"].ToString());
                    lv.SubItems.Add(itm["Cash"].ToString());
                    lv.SubItems.Add(itm["Change"].ToString());
                    lv.SubItems.Add(itm["AmountDue"].ToString());

                    lv.Tag = Convert.ToInt32(itm["QUEUEID"]);
                    lv.Tag = Convert.ToInt32(itm["ID"]);
                }
                else
                {
                    int i;
                    for (i = 0; i <= lvTransactionList.Items.Count - 1; i++)
                    {
                        string orderNm = lvTransactionList.Items[i].SubItems[0].Text;
                        if (output == orderNm)
                        { hasLoaded = true; }
                    }

                    if (hasLoaded)
                    {
                        goto NextLineTodo;
                    }
                    else
                    {
                        ListViewItem lv = lvTransactionList.Items.Add(output);
                        lv.SubItems.Add(itm["DOCDATE"].ToString());
                        lv.SubItems.Add(itm["Cash"].ToString());
                        lv.SubItems.Add(itm["Change"].ToString());
                        lv.SubItems.Add(itm["AmountDue"].ToString());

                        lv.Tag = Convert.ToInt32(itm["QUEUEID"]);
                    }

                }
            NextLineTodo: ;
                hasLoaded = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            if (lvTransactionList.SelectedItems.Count ==0){return;}

            PrintOR(Convert.ToInt32(lvTransactionList.SelectedItems[0].Tag));
        }
        private void PrintOR(int queueID)
        {
            System.Threading.Thread.Sleep(2000);
            // Check if able to print

            Printer = tmpMaintenance.GetValue("PrinterReciept");
            IsPrint = tmpMaintenance.GetValue("IsRecieptPrint");
           if (!canPrint(Printer)) { return; }

            string mysql = "SELECT * FROM customer_order WHERE QUEUEID = " + queueID + " and QIStatus =1";

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

        private void btnView_Click(object sender, EventArgs e)
        {
            if (lvTransactionList.SelectedItems.Count == 0) { return; }

            int idx = Convert.ToInt32(lvTransactionList.SelectedItems[0].Tag);
            Queue q = new Queue();

            q.LoadQueue(idx);

            (Application.OpenForms["frmCasher"] as frmCasher).isView = true;
            (Application.OpenForms["frmCasher"] as frmCasher).OrderNumber = lvTransactionList.SelectedItems[0].Text;
  
            foreach (QueueLines orders in q.QueueColl)
            {
                MenuItem smenu = new MenuItem();

                smenu.ID = orders.MenuID;
                smenu.LoadMenuItem();

                if (Application.OpenForms["frmCasher"] != null)
                {
                    (Application.OpenForms["frmCasher"] as frmCasher).AddMenuItem(smenu);
                  
                }
            }

           this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "") { LoadWholeOder(); }
            string mysql = "SELECT * FROM customer_order where ORDERNUM like '%" + txtSearch.Text + "%' and BOStatus = '1' ORDER BY ID ASC";
            LoadWholeOder(mysql);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnSearch.PerformClick(); }
        }

    }
}
