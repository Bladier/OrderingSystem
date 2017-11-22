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
    class Credit
    {
        private string MainTable = "tblCredit";

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

        private double _Credit;
        public double passMoney
        {
            get { return _Credit; }
            set { _Credit = value; }
        }


        #endregion

        #region "Functions"
        public void LoadCredit(int id)
        {
            string mySql = string.Format("SELECT * FROM " + MainTable + " WHERE passID = {0}", id);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count != 1)
            {
                MessageBox.Show("Unable load credits", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                LoadByRow(dr);
            }
        }

        public void SaveCredit()
        {
            string mySql = "Select * From " + MainTable + " Limit 1";
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            DataRow dsNewRow = null;
            dsNewRow = ds.Tables[0].NewRow();
            var _with2 = dsNewRow;
            _with2["PassID"] = _PID;
            _with2["Credit"] = _Credit;
            ds.Tables[0].Rows.Add(dsNewRow);
            Database.SaveEntry(ds);
        }


        public void LoadByRow(DataRow dr)
        {
            DataSet ds = new DataSet();
            var _with3 = dr;
            _ID = Convert.ToInt32(_with3["ID"]);
            _PID = Convert.ToInt32(_with3["PassID"]);
            _Credit = Convert.ToDouble(_with3["Credit"]);
        }

        public void UpdateCredit(double fare=0,int passID=0)
        {
            string mySql = string.Format("SELECT * FROM {0} WHERE PassID = {1}", MainTable, passID);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count == 1)
            {
                var _with2 = ds.Tables[MainTable].Rows[0];
                double tmpCredit = Convert.ToDouble(ds.Tables[0].Rows[0]["Credit"]);
                tmpCredit = tmpCredit - fare;

                _with2["Credit"] = tmpCredit;
                Database.SaveEntry(ds, false);
            }
            else
            {
                DataRow dsNewRow = null;
                dsNewRow = ds.Tables[0].NewRow();
                var _with2 = dsNewRow;
                _with2["PassID"] = _PID;
                _with2["Credit"] = _Credit;
                ds.Tables[0].Rows.Add(dsNewRow);
                Database.SaveEntry(ds);
            }


        #endregion
        }
    }
}
