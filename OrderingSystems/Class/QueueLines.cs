using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;

namespace OrderingSystems.Class
{
    class QueueLines
    {
        private string SubTable = "tblqueueinfo";

        #region "Properties"
        private int _ID;
        public virtual int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _QueueID;
        public virtual int QueueID
        {
            get { return _QueueID; }
            set { _QueueID = value; }
        }

        private int _MenuID;
        public virtual int MenuID
        {
            get { return _MenuID; }
            set { _MenuID = value; }
        }

        private double _QTY;
        public double QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
        }

        private bool _Status;
        public bool Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        #endregion

        #region "Properties"
        public void LoadByRow(DataRow dr)
        {
            DataSet ds = new DataSet();
            var _with3 = dr;

            _ID = Convert.ToInt32(_with3["ID"]);
             _QueueID =Convert.ToInt32(_with3["QUEUEID"]);
            _MenuID =Convert.ToInt32(_with3["MenuID"]);
            _QTY = Convert.ToDouble(_with3["QTY"]);
            
            string tmpqty = _with3["Status"].ToString();
            if (tmpqty =="1")
            {
                _Status =true;
            }
            else
            {
                _Status =false;
            }
            }

        internal void SaveInfo()
        {
            string mysql = "Select * From tblQueueInfo Where QueueID = " + _QueueID ;
            DataSet ds = Database.LoadSQL(mysql, "tblQueueInfo");

            DataRow dsNewRow = null;
            dsNewRow = ds.Tables[0].NewRow();
            var _with2 = dsNewRow;
            _with2["QueueID"] = _QueueID ;
            _with2["MenuID"] = _MenuID ;
            _with2["Qty"] = _QTY ;
            _with2["Status"] = _Status;
            ds.Tables[0].Rows.Add(dsNewRow);
            Database.SaveEntry(ds);
        }
        }

        #endregion
    }
