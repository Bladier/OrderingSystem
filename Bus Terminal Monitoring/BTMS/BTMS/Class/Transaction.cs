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
    class Transaction
    {
        private string MainTable = "tblTransaction";
        #region "Properties"
        private int _ID;
        public virtual int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private DateTime _TransDate;
        public DateTime TransDate
        {
            get { return _TransDate; }
            set { _TransDate = value; }
        }

        private passenger _Client;
        public passenger Client
        {
            get { return _Client; }
            set { _Client = value; }
        }

        private busManagement _Bus;
        public busManagement Bus
        {
            get { return _Bus; }
            set { _Bus = value; }
        }

        private double _TransRate;
        public double TransRate
        {
            get { return _TransRate; }
            set { _TransRate = value; }
        }

        private double _TransDiscount;
        public double TransDiscount
        {
            get { return _TransDiscount; }
            set { _TransDiscount = value; }
        }

        private bool _status;
        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string _Remarks;
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }

        private busTransaction _BusTransID;
        public busTransaction BusTransID
        {
            get { return _BusTransID; }
            set { _BusTransID = value; }
        }
        #endregion

        #region "Functions and Procedures"
        public void LoadTrans(int id)
        {
            string mySql = string.Format("SELECT * FROM " + MainTable + " WHERE ID = {0}", id);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count != 1)
            {
                MessageBox.Show("Unable load Transaction", "Error",
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
            _TransDate = Convert.ToDateTime(_with3["TransDate"]);

            passenger tmpClient = new passenger();
            tmpClient.Loadpass(Convert.ToInt32(_with3["passID"]));
            _Client = tmpClient;

            busManagement tmpbus = new busManagement();
            tmpbus.Loadbusmngt(Convert.ToInt32(_with3["busID"]));
            _Bus = tmpbus;
            _TransRate = Convert.ToDouble(_with3["Rate"]);
            _TransDiscount = Convert.ToDouble(_with3["Discount"]);

            if (_with3["Status"].ToString() == "1")
            {
                _status = true;
            }
            else {_status =false;}

            _Remarks = _with3["Remarks"].ToString();

            busTransaction tmpnew = new busTransaction();
            tmpnew.LoadTrans(Convert.ToInt32(_with3["busTransID"]));
           _BusTransID = tmpnew;
        }


        public void SaveTrans()
        {
            string mySql = "Select * From " + MainTable + " Limit 1";
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            DataRow dsNewRow = null;
            dsNewRow = ds.Tables[0].NewRow();
            var _with2 = dsNewRow;
            _with2["TransDate"] = _TransDate;
            _with2["PassID"] = _Client.ID;
            _with2["BusID"] = _Bus.ID;
            _with2["Rate"] = _TransRate;
            _with2["Discount"] = _TransDiscount;
            _with2["Status"] = "1";
            _with2["Remarks"] = _Remarks;
            _with2["BusTransID"] = _BusTransID.ID;
            ds.Tables[0].Rows.Add(dsNewRow);
            Database.SaveEntry(ds);
        }

        public bool IsTag(int passID)
        {
            DateTime d = Convert.ToDateTime(mod_system.CurrentDate.ToShortDateString());
            string datestring = d.ToString("yyyy-MM-dd");

            string mySql = "Select * From " + MainTable + " where passID = '" + passID + "' and BusTransID= '" + _BusTransID.ID +"' and status = 1 and transDate ='" + datestring + "'";
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count == 0)
                return false;
            return true;
        }

        public void VoidTrans()
        {
            string mySql = "Select * From " + MainTable + " where ID = '" + _ID + "' ";
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            var _with2 = ds.Tables[MainTable].Rows[0];
          
            _with2["Status"] = 0;
            Database.SaveEntry(ds, false);
        }

        #endregion
    }
}
