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
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace BTMS
{
    class loadhistory
    {
        private string MainTable = "tblloadhistory";

        #region "Properties"
        private int _ID;
        public virtual int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _PID;
        public int PID
        {
            get { return _PID; }
            set { _PID = value; }
        }

        private double _LoadCredit;
        public double PassMoneyAdd
        {
            get { return _LoadCredit; }
            set { _LoadCredit = value; }
        }

        private DateTime _loadDate;
        public DateTime LoadDate
        {
            get { return _loadDate; }
            set { _loadDate = value; }
        }

        private bool _status;
        public bool status
        {
            get { return _status; }
            set { _status = value; }
        }
#endregion

        #region "Functions"
        public void LoadCredit(int id)
        {
            string mySql = string.Format("SELECT * FROM " + MainTable + " WHERE passID = {0}", id);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count != 1)
            {
                Console.WriteLine("Unable load load history", "Error");
                return;
            }
        
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                LoadByRow(dr);
            }
        }

        public void SaveLoadHist()
        {
            string mySql = "Select * From " + MainTable + " Limit 1";
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            DataRow dsNewRow = null;
            dsNewRow = ds.Tables[0].NewRow();
            var _with2 = dsNewRow;
            _with2["PassID"] = _PID;
            _with2["loadcredit"] = _LoadCredit;
            _with2["loaddate"] = mod_system.CurrentDate.ToShortDateString();
            _with2["Status"] = "1";
            ds.Tables[0].Rows.Add(dsNewRow);
            Database.SaveEntry(ds);
        }


        public void LoadByRow(DataRow dr)
        {
            DataSet ds = new DataSet();
            var _with3 = dr;
            _ID = Convert.ToInt32(_with3["ID"]);
            _PID = Convert.ToInt32(_with3["PassID"]);
            _LoadCredit = Convert.ToDouble(_with3["loadcredit"]);
            _loadDate = Convert.ToDateTime(_with3["loaddate"]);

            if (_with3["Status"].ToString() == "1")
            {
                _status = true;
            }
            else { _status = false; }


        }

        public void UpdateLoadHistory(double load = 0, int idx = 0)
        {
            string mySql = string.Format("SELECT * FROM {0} WHERE ID = {1}", MainTable, idx);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count == 1)
            {
                var _with2 = ds.Tables[MainTable].Rows[0];
                _with2["Status"] = "0"; 
                Database.SaveEntry(ds, false);
            }
            else
            {
                DataRow dsNewRow = null;
                dsNewRow = ds.Tables[0].NewRow();
                var _with2 = dsNewRow;
                _with2["PassID"] = _PID;
                _with2["loadcredit"] = _LoadCredit;
                _with2["loaddate"] = _loadDate;
                _with2["Status"] = "1";
                ds.Tables[0].Rows.Add(dsNewRow);
                Database.SaveEntry(ds);
            }
        }

        public int LoadLastID()
        {
            string mySql = string.Format("SELECT * FROM {0} ORDER BY ID DESC LIMIT 1", MainTable);
            DataSet ds = Database.LoadSQL(mySql, MainTable);
            int idx = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);

            return idx;
        }
        #endregion

    }
}
