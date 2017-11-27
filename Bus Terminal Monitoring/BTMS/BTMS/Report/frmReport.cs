using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace BTMS
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
    }
}
