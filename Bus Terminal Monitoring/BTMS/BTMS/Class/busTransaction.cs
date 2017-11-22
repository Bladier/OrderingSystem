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
    class busTransaction
    {

         private string MainTable = "tblBusTransaction";

        #region "Properties"
        private int _ID;
        public virtual int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

          private busManagement _Bus;
        public busManagement Bus
        {
            get { return _Bus; }
            set { _Bus = value; }
        }

        private int _AvailableSeat;
        public int AvailableSeat
        {
            get { return _AvailableSeat; }
            set { _AvailableSeat = value; }
        }

        private string _Status;
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        #endregion

        #region "Functions and Procedures"
        public void LoadTrans(int id)
        {
            string mySql = string.Format("SELECT * FROM " + MainTable + " WHERE ID = {0}", id);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count != 1)
            {
                MessageBox.Show("Unable load bus Transaction", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

            busManagement tmpbus = new busManagement();
            tmpbus.Loadbusmngt(Convert.ToInt32(_with3["busID"]));
            _Bus = tmpbus;
            _AvailableSeat = Convert.ToInt32(_with3["AvailableSeat"]);

            _Status = _with3["Status"].ToString();
        }


        public void SavebusTrans()
        {
            string mySql = "Select * From " + MainTable + " Limit 1";
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            DataRow dsNewRow = null;
            dsNewRow = ds.Tables[0].NewRow();
            var _with2 = dsNewRow;
            _with2["BusID"] = _Bus.ID;
            _with2["AvailableSeat"] = _AvailableSeat;
            _with2["Status"] = _Status;
            ds.Tables[0].Rows.Add(dsNewRow);
            Database.SaveEntry(ds);
        }


        public bool iShasbusTrans()
        {
            string mySql = "Select * From " + MainTable + " where Status = 'T'";
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}
