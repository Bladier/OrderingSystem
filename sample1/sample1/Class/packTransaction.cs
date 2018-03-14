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
    class packTransaction
    {
        private string MainTable = "tblpackageTransaction";

        #region "Properties"
        private int _ID;
        public virtual int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _transactionNo;
        public int transactionNo
        {
            get { return _transactionNo; }
            set { _transactionNo = value; }
        }

        private int _packagedetailsID;
        public int packagedetailsID
        {
            get { return _packagedetailsID; }
            set { _packagedetailsID = value; }
        }

        private int _packageID;
        public int packageID
        {
            get { return _packageID; }
            set { _packageID = value; }
        }
        #endregion

        #region "Functions
        public void loadpackTrans(int id)
        {
            string mySql = string.Format("SELECT * FROM " + MainTable + " WHERE ID = {0}", id);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count != 1)
            {
                MessageBox.Show("Unable load package information information", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                LoadByRow(dr);
            }
        }

        public void saveptrans()
        {
            string mySql = "Select top 1 * From " + MainTable + "";
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            DataRow dsNewRow = null;
            dsNewRow = ds.Tables[0].NewRow();
            var _with2 = dsNewRow;
            _with2["transactionNo"] = _transactionNo;
            _with2["packagedetailsID"] = _packagedetailsID;
     
            ds.Tables[0].Rows.Add(dsNewRow);
            Database.SaveEntry(ds);
        }


        public void LoadByRow(DataRow dr)
        {
            DataSet ds = new DataSet();
            var _with3 = dr;
            _ID = Convert.ToInt32(_with3["ID"]);
            _transactionNo = Convert.ToInt32(_with3["transactionNo"]);
            _packagedetailsID = Convert.ToInt32(_with3["packagedetailsID"]);
       
          
        }

        public void Update()
        {
            string mySql = string.Format("SELECT * FROM {0} WHERE ID = {1}", MainTable, _ID);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count == 1)
            {
                var _with2 = ds.Tables[MainTable].Rows[0];
                _with2["transactionNo"] = _transactionNo;
                _with2["packagedetailsID"] = _packagedetailsID;
            
                Database.SaveEntry(ds, false);
            }
            else
            {
                DataRow dsNewRow = null;
                dsNewRow = ds.Tables[0].NewRow();
                var _with2 = dsNewRow;
                _with2["transactionNo"] = _transactionNo;
                _with2["packagedetailsID"] = _packagedetailsID;
           
                ds.Tables[0].Rows.Add(dsNewRow);
                Database.SaveEntry(ds);
            }
        }

     
        #endregion
    }
}
