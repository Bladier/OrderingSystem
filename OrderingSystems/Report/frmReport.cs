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

namespace OrderingSystems.Report
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
        }

        public void ReportInit(string mySql, string dsName, string rptUrl, Dictionary<string, string> addPara = null, bool hasUser = true)
        {
            try
            {
                DataSet ds = Database.LoadSQL(mySql, dsName);
                if (ds == null)
                    return;

                Console.WriteLine("SQL: " + mySql);
                Console.WriteLine("Max: " + ds.Tables[dsName].Rows.Count);
                Console.WriteLine("Report is Existing? " + System.IO.File.Exists(Application.StartupPath + "\\" + rptUrl));
                var _with2 = rv_display;
                _with2.ProcessingMode = ProcessingMode.Local;
                _with2.LocalReport.ReportPath = rptUrl;
                _with2.LocalReport.DataSources.Clear();

                _with2.LocalReport.DataSources.Add(new ReportDataSource(dsName, ds.Tables[dsName]));

                //if (hasUser)
                //{
                //    ReportParameter myPara = new ReportParameter();
                //    myPara.Name = "txtUsername";
                //    if (mod_system.SystemUser.USERNAME == null)
                //        mod_system.SystemUser.USERNAME = "Sample Eskie";
                //    myPara.Values.Add(mod_system.SystemUser.USERNAME);
                //    _with2.LocalReport.SetParameters(new ReportParameter[] { myPara });
                //}

                if ((addPara != null))
                {
                    foreach (KeyValuePair<string, string> nPara_loopVariable in addPara)
                    {
                        var nPara = nPara_loopVariable;
                        ReportParameter tmpPara = new ReportParameter();
                        tmpPara.Name = nPara.Key;
                        tmpPara.Values.Add(nPara.Value);
                        _with2.LocalReport.SetParameters(new ReportParameter[] { tmpPara });
                    }
                }

                _with2.RefreshReport();
            }
            catch (Exception ex)
            {
                // Interaction.MsgBox(ex.ToString(), MsgBoxStyle.Critical, "REPORT GENERATE ERROR");
                // Log_Report("REPORT - " + ex.ToString());
            }
        }
    }
}
