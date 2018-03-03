using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace sample1
{
    public partial class frmReport : Form
    {
        Dictionary<string, string> subReportPassing;

        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {

           
        }

        internal void ReportInit(string mySql, string dsName, string rptUrl, Dictionary<string, string> addPara = null, bool hasUser = true)
        {
            try
            {
                DataSet ds = Database.LoadSQL(mySql, dsName);
                if (ds == null)
                    return;
                var _with2 = rv_display;
                _with2.ProcessingMode = ProcessingMode.Local;
                _with2.LocalReport.ReportPath = rptUrl;
                _with2.LocalReport.DataSources.Clear();

                _with2.LocalReport.DataSources.Add(new ReportDataSource(dsName, ds.Tables[dsName]));

                if (hasUser)
                {
                    ReportParameter myPara = new ReportParameter();
                    myPara.Name = "txtUsername";
                    if (mod_system.ORuser.Username == null)
                    {
                        mod_system.ORuser.Username = "Atcheche";
                    }
                    myPara.Values.Add(mod_system.ORuser.Username);
                    _with2.LocalReport.SetParameters(new ReportParameter[] { myPara });
                }

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
                MessageBox.Show(ex.Message.ToString());
            }
        }

        internal void MultiDbSetReport(Dictionary<string, string> mySql, string rptUrl, Dictionary<string, string> addPara = null, bool hasUser = true, Dictionary<string, string> subReport = null)
        {
            string dsName = null;
            DataSet ds = null;
            string cmd = null;
            if ((subReport != null))
                subReportPassing = subReport;

            var _with1 = rv_display;
            _with1.ProcessingMode = ProcessingMode.Local;
            _with1.LocalReport.ReportPath = rptUrl;
            _with1.LocalReport.DataSources.Clear();

            foreach (KeyValuePair<string, string> el_loopVariable in mySql)
            {
           
                dsName = el_loopVariable.Key;
                cmd = el_loopVariable.Value;
                Console.WriteLine(string.Format("{0}: {1}", dsName, cmd));

                ds =Database.LoadSQL(cmd, dsName);
                ReportDataSource rDS = new ReportDataSource();
                rDS = new ReportDataSource(dsName, ds.Tables[dsName]);
                _with1.LocalReport.DataSources.Add(rDS);
            }

            ReportParameter myPara = new ReportParameter();
            myPara.Name = "txtUsername";
            if (mod_system.ORuser.Username == null)
            {
                mod_system.ORuser.Username = "Atcheche";
            }
            myPara.Values.Add(mod_system.ORuser.Username);
            _with1.LocalReport.SetParameters(new ReportParameter[] { myPara });

            if ((addPara != null))
            {
                foreach (KeyValuePair<string, string> nPara_loopVariable in addPara)
                {
                    var nPara = nPara_loopVariable;
                    ReportParameter tmpPara = new ReportParameter();
                    tmpPara.Name = nPara.Key;
                    tmpPara.Values.Add(nPara.Value);
                    _with1.LocalReport.SetParameters(new ReportParameter[] { tmpPara });
                }
            }

            if ((subReport != null))
            {
                _with1.LocalReport.SubreportProcessing += SubReportLoader;
            }

            _with1.RefreshReport();
        }

        private void SubReportLoader(object sender, SubreportProcessingEventArgs e)
        {
            string dsName = null;
            DataSet ds = null;

            foreach (KeyValuePair<string, string> el_loopVariable in subReportPassing)
            {
                dsName = el_loopVariable.Key;
                ds = Database.LoadSQL(el_loopVariable.Value, dsName);
                e.DataSources.Add(new ReportDataSource(dsName, ds.Tables[dsName]));
            }
        }
    }
}
