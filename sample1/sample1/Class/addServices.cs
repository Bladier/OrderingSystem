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
    class addServices
    {
        private string MainTable = "tbltransAddservices";

        #region "Properties"
        private int _ID;
        public virtual int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _servicesID;
        public virtual int servicesID
        {
            get { return _servicesID; }
            set { _servicesID = value; }
        }

        private int _transNum;
        public virtual int transNum
        {
            get { return _transNum; }
            set { _transNum = value; }
        }


        private int _status;
        public virtual int status
        {
            get { return _status; }
            set { _status = value; }
        }

        #endregion

        #region "Functions"
        public void loadservices(int id)
        {
            string mySql = string.Format("SELECT * FROM " + MainTable + " WHERE ID = {0}", id);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Unable load services", "Notification",
    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                LoadByRow(dr);
            }
        }

        public void saveTservices()
        {
            string mySql = "Select * From " + MainTable + "";
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            DataRow dsNewRow = null;
            dsNewRow = ds.Tables[0].NewRow();
            var _with2 = dsNewRow;
            _with2["servicesID"] = _servicesID;
            _with2["transactionNum"] = _transNum;
            _with2["status"] = _status;

            ds.Tables[0].Rows.Add(dsNewRow);
            Database.SaveEntry(ds);
        }

        public void LoadByRow(DataRow dr)
        {
            DataSet ds = new DataSet();
            var _with3 = dr;
            _ID = Convert.ToInt32(_with3["ID"]);
            _servicesID = Convert.ToInt32(_with3["servicesID"]);
            _transNum = Convert.ToInt32(_with3["transactionNum"]);
            _status = Convert.ToInt32(_with3["status"]);
        }

        public void voidServices(int transNum)
        {
            string mySql = string.Format("SELECT * FROM {0} WHERE transactionNum = {1}", MainTable, transNum);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count == 1)
            {
                var _with2 = ds.Tables[MainTable].Rows[0];
                _with2["status"] = 0;
                Database.SaveEntry(ds, false);
            }
        }
        //public void updateBarangay()
        //{
        //    string mySql = string.Format("SELECT * FROM {0} WHERE ID = {1}", MainTable, _ID);
        //    DataSet ds = Database.LoadSQL(mySql, MainTable);

        //    if (ds.Tables[0].Rows.Count == 1)
        //    {
        //        var _with2 = ds.Tables[MainTable].Rows[0];
        //        _with2["barangay"] = _barangay;
        //        _with2["cityID"] = _cityID;
        //        Database.SaveEntry(ds, false);
        //    }
        //    else
        //    {
        //        DataRow dsNewRow = null;
        //        dsNewRow = ds.Tables[0].NewRow();
        //        var _with2 = dsNewRow;
        //        _with2["barangay"] = _barangay;
        //        _with2["cityID"] = _cityID;
        //        ds.Tables[0].Rows.Add(dsNewRow);
        //        Database.SaveEntry(ds);
        //    }
        //}

        #endregion
    }
}
