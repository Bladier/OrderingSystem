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

        private double _price;
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        #endregion


        #region "Functions"

        internal void LoadLines()
        {
            string mysql = "Select * From tblqueueinfo Where QueueID = " + _QueueID ;
            DataSet ds = Database.LoadSQL(mysql, "tblqueueinfo");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                LoadByRow(dr);
            }
        }


        public void LoadByRow(DataRow dr)
        {
            DataSet ds = new DataSet();
            var _with3 = dr;

            _ID = Convert.ToInt32(_with3["ID"]);
            _QueueID = Convert.ToInt32(_with3["QUEUEID"]);
            _MenuID = Convert.ToInt32(_with3["MenuID"]);
            _QTY = Convert.ToDouble(_with3["QTY"]);

            _price = Convert.ToDouble(_with3["Price"]);
            

            string tmpqty = _with3["Status"].ToString();
            if (tmpqty == "1")
            {
                _Status = true;
            }
            else
            {
                _Status = false;
            }
        }

        public void SaveInfo()
        {
           string mysql = "SELECT * FROM tblQueueInfo limit 0";
           DataSet ds = Database.LoadSQL(mysql, "tblQueueInfo");

            DataRow dsNewRow = null;
            dsNewRow = ds.Tables[0].NewRow();
            var _with2 = dsNewRow;
            _with2["QueueID"] = _QueueID ;
            _with2["MenuID"] = _MenuID ;
            _with2["Qty"] = _QTY ;
            _with2["Price"] = _price;
            _with2["Status"] = 1;
            ds.Tables[0].Rows.Add(dsNewRow);
            Database.SaveEntry(ds);
        }
        

        public int LoadLastID()
        {
            System.Threading.Thread.Sleep(1000);
            string mySql = "SELECT * FROM tblQueueInfo ORDER BY ID DESC LIMIT 1";
            DataSet ds = Database.LoadSQL(mySql, SubTable);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return 0;
            }
            return Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
        }
        #endregion
    }

}
