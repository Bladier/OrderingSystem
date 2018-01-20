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
    class Venuemngt
    {
        private string MainTable = "venuetbl";

        #region "Properties"
        private int _ID;
        public virtual int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _VenueName;
        public string VenueName
        {
            get { return _VenueName; }
            set { _VenueName = value; }
        }

        private int _Capacity;
        public int Capacity
        {
            get { return _Capacity; }
            set { _Capacity = value; }
        }

        private double _Rate;
        public double Rate
        {
            get { return _Rate; }
            set { _Rate = value; }
        }
        #endregion

        #region "Functions
        public void loadvenue(int id)
        {
            string mySql = string.Format("SELECT * FROM " + MainTable + " WHERE ID = {0}", id);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count != 1)
            {
                MessageBox.Show("Unable load venue information", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                LoadByRow(dr);
            }
        }

        public void savevenue()
        {
            string mySql = "Select top 1 * From " + MainTable + "";
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            DataRow dsNewRow = null;
            dsNewRow = ds.Tables[0].NewRow();
            var _with2 = dsNewRow;
            _with2["description"] = _VenueName;
            _with2["rate"] = _Rate;
            _with2["capacity"] = _Capacity;
            ds.Tables[0].Rows.Add(dsNewRow);
            Database.SaveEntry(ds);
        }


        public void LoadByRow(DataRow dr)
        {
            DataSet ds = new DataSet();
            var _with3 = dr;
            _ID = Convert.ToInt32(_with3["ID"]);
            _VenueName = _with3["description"].ToString();
            _Rate = Convert.ToDouble(_with3["rate"].ToString());
            _Capacity =Convert.ToInt32(_with3["capacity"].ToString());
          
        }

        public void Update()
        {
            string mySql = string.Format("SELECT * FROM {0} WHERE ID = {1}", MainTable, _ID);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count == 1)
            {
                var _with2 = ds.Tables[MainTable].Rows[0];
                _with2["description"] = _VenueName;
                _with2["rate"] = _Rate;
                _with2["capacity"] = _Capacity;
                Database.SaveEntry(ds, false);
            }
            else
            {
                DataRow dsNewRow = null;
                dsNewRow = ds.Tables[0].NewRow();
                var _with2 = dsNewRow;
                _with2["description"] = _VenueName;
                _with2["rate"] = _Rate;
                _with2["capacity"] = _Capacity;
                ds.Tables[0].Rows.Add(dsNewRow);
                Database.SaveEntry(ds);
            }
        }

        public int GetLastID()
        {
            string mySql = string.Format("SELECT top 1 * FROM {0} Order by ID desc", MainTable);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            return Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);

        }
        #endregion
    }
}
