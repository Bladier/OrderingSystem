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
    class busRoute
    {
        private string MainTable = "tblroute";

        #region "Properties"
        private int _ID;
        public virtual int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _From;
        public string From
        {
            get { return _From; }
            set { _From = value; }
        }

        private string _Dest;
        public string Dest
        {
            get { return _Dest; }
            set { _Dest = value; }
        }


        private double _Rate;
        public double Rate
        {
            get { return _Rate; }
            set { _Rate = value; }
        }

        private int _BusID;
        public int BusID
        {
            get { return _BusID; }
            set { _BusID = value; }
        }
        #endregion

        #region "Functions"
        public void LoadbusRoute(int id)
        {
            string mySql = string.Format("SELECT * FROM " + MainTable + " WHERE busID = {0}", id);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count != 1)
            {
                MessageBox.Show("Unable load bus route", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                LoadByRow(dr);
            }
        }

        public void SaveBusRoute()
        {
            string mySql = "Select * From " + MainTable + " Limit 1";
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            DataRow dsNewRow = null;
            dsNewRow = ds.Tables[0].NewRow();
            var _with2 = dsNewRow;
            _with2["From"] = _From;
            _with2["Destination"] = _Dest;
            _with2["Rate"] = Convert.ToDouble(_Rate);
            _with2["BusID"] = Convert.ToInt32(_BusID);
            ds.Tables[0].Rows.Add(dsNewRow);
            Database.SaveEntry(ds);
        }


        public void LoadByRow(DataRow dr)
        {
            DataSet ds = new DataSet();
            var _with3 = dr;
            _ID = Convert.ToInt32(_with3["ID"]);
            _From = _with3["From"].ToString();
            _Dest = _with3["Destination"].ToString();
            _Rate = Convert.ToDouble(_with3["Rate"]);
            _BusID = Convert.ToInt32(_with3["BusID"]);

        }

        public void Updateroute()
        {
            string mySql = string.Format("SELECT * FROM {0} WHERE ID = {1}", MainTable, _ID);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count == 1)
            {
                var _with2 = ds.Tables[MainTable].Rows[0];
                _with2["From"] = _From;
                _with2["Destination"] = _Dest;
                _with2["Rate"] = Convert.ToDouble(_Rate);
                _with2["BusID"] = Convert.ToInt32(_BusID);
                Database.SaveEntry(ds, false);
            }
            else
            {
                DataRow dsNewRow = null;
                dsNewRow = ds.Tables[0].NewRow();
                var _with2 = dsNewRow;
                _with2["From"] = _From;
                _with2["Destination"] = _Dest;
                _with2["Rate"] = Convert.ToDouble(_Rate);
                _with2["BusID"] = Convert.ToInt32(_BusID);
                ds.Tables[0].Rows.Add(dsNewRow);
                Database.SaveEntry(ds);
            }
        }
            public bool isBusHasRoute()
            {
                string mySql = string.Format("SELECT * FROM {0} WHERE busID = {1}", MainTable, _BusID);
                DataSet ds = Database.LoadSQL(mySql, MainTable);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
        #endregion
        }
    }




