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
    class addcitys
    {
        private string MainTable = "citytbl";

        #region "Properties"
        private int _ID;
        public virtual int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _city;
        public virtual string city
        {
            get { return _city; }
            set { _city = value; }
        }
        #endregion

        #region "Functions"
        public void loadcity(int id)
        {
            string mySql = string.Format("SELECT * FROM " + MainTable + " WHERE ID = {0}", id);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Unable load city", "Notification",
    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                LoadByRow(dr);
            }
        }

        public void savecity()
        {
            string mySql = "Select * From " + MainTable + "";
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            DataRow dsNewRow = null;
            dsNewRow = ds.Tables[0].NewRow();
            var _with2 = dsNewRow;
            _with2["city"] = _city;
       
            ds.Tables[0].Rows.Add(dsNewRow);
            Database.SaveEntry(ds);
        }

        public void LoadByRow(DataRow dr)
        {
            DataSet ds = new DataSet();
            var _with3 = dr;
            _ID = Convert.ToInt32(_with3["ID"]);
            _city = _with3["city"].ToString();
        }

        public void updatecity()
        {
            string mySql = string.Format("SELECT * FROM {0} WHERE ID = {1}", MainTable, _ID);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count == 1)
            {
                var _with2 = ds.Tables[MainTable].Rows[0];
                _with2["city"] = _city;
           
                Database.SaveEntry(ds, false);
            }
            else
            {
                DataRow dsNewRow = null;
                dsNewRow = ds.Tables[0].NewRow();
                var _with2 = dsNewRow;
                _with2["city"] = _city;
                ds.Tables[0].Rows.Add(dsNewRow);
                Database.SaveEntry(ds);
            }
        }


        public int getlastCIty()
        {
            string mySql = string.Format("SELECT top 1 * FROM {0} order by ID desc", MainTable);
            DataSet ds = Database.LoadSQL(mySql, MainTable);
            return Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
        }
        #endregion
    }
}
