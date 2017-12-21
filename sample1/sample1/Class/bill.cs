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

namespace sample1
{
    class bill
    {
        private string MainTable = "paymenttbl";

        #region "Properties"
        private int _ID;
        public virtual int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _resID;
        public virtual int resID
        {
            get { return _resID; }
            set { _resID = value; }
        }

        private double _Payment;
        public double Payment
        {
            get { return _Payment; }
            set { _Payment = value; }
        }


        private DateTime _tranSDate;
        public DateTime tranSDate
        {
            get { return _tranSDate; }
            set { _tranSDate = value; }
        }

        private bool _status;
        public bool status
        {
            get { return _status; }
            set { _status = value; }
        }

        private int _TransNum;
        public int TransNum
        {
            get { return _TransNum; }
            set { _TransNum = value; }
        }


        #endregion

        #region "Functions"
        public void loadbill(int id)
        {
            string mySql = string.Format("SELECT * FROM " + MainTable + " WHERE resID = {0}", id);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count != 1)
            {
                MessageBox.Show("Unable load bills", "Notification",
    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                LoadByRow(dr);
            }
        }

        public void saveBill()
        {
            string mySql = "Select * From " + MainTable + "";
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            DataRow dsNewRow = null;
            dsNewRow = ds.Tables[0].NewRow();
            var _with2 = dsNewRow;
            _with2["resID"] = _resID;
            _with2["payment"] = _Payment;
            _with2["TransDate"] = _tranSDate;
             _with2["status"] = 1;
             _with2["TransactionNum"] = _TransNum;

            ds.Tables[0].Rows.Add(dsNewRow);
            Database.SaveEntry(ds);
        }

        public void LoadByRow(DataRow dr)
        {
            DataSet ds = new DataSet();
            var _with3 = dr;
            _ID = Convert.ToInt32(_with3["ID"]);
            _resID = Convert.ToInt32(_with3["ResID"]);
            _Payment = Convert.ToDouble(_with3["payment"]);
            _tranSDate = Convert.ToDateTime(_with3["TransDate"]);

            if (Convert.ToInt32(_with3["status"]) == 1)
            { _status = true; }
            else { _status = false; }
            _TransNum= Convert.ToInt32(_with3["TransactionNum"]);
        }

        public void updatebill()
        {
            string mySql = string.Format("SELECT * FROM {0} WHERE ID = {1}", MainTable, _ID);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count == 1)
            {
                var _with2 = ds.Tables[MainTable].Rows[0];
                _with2["resID"] = _resID;
                _with2["payment"] = _Payment;
                _with2["TransDate"] = _tranSDate;
                _with2["status"] = 1;
                _with2["TransactionNum"] = _TransNum;
                Database.SaveEntry(ds, false);
            }
            else
            {
                DataRow dsNewRow = null;
                dsNewRow = ds.Tables[0].NewRow();
                var _with2 = dsNewRow;
                _with2["resID"] = _resID;
                _with2["payment"] = _Payment;
                _with2["TransDate"] = _tranSDate;
                _with2["status"] = 1;
                _with2["TransactionNum"] = _TransNum;
                ds.Tables[0].Rows.Add(dsNewRow);
                Database.SaveEntry(ds);
            }
        }
           
        #endregion
        }
    }




