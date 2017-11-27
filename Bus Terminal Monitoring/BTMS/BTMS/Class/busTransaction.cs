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

        private DateTime _transdate;
        public DateTime Transdate
        {
            get { return _transdate; }
            set { _transdate = value; }
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
            _transdate = Convert.ToDateTime(_with3["transdate"]);

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
            _with2["TransDate"] = _transdate;
            ds.Tables[0].Rows.Add(dsNewRow);
            Database.SaveEntry(ds);
        }


        public bool iShasbusTrans()
        {
            string mySql = "Select * From " + MainTable + " where Status = 'W'";
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count > 0)
            {
                LoadByRow(ds.Tables[0].Rows[0]);
                return true;
            }

            return false;
        }

        public void DeductSeat(int deduct)
        {
            string mySql = "Select * From " + MainTable + " where busID = "+ _Bus.ID + " and status ='W'";
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            var _with2 = ds.Tables[MainTable].Rows[0];
            int tmpAvailSeat = Convert.ToInt32(ds.Tables[0].Rows[0]["AvailableSeat"]);
            tmpAvailSeat = tmpAvailSeat - deduct;

            _with2["AvailableSeat"] = tmpAvailSeat;
            Database.SaveEntry(ds, false);
        }

        public void ConfirmBusTravel()
        {
            string mySql = "Select * From " + MainTable + " where ID = " + _ID + " and status ='W'";
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            var _with2 = ds.Tables[MainTable].Rows[0];
       
            _with2["Status"] = "T";
            Database.SaveEntry(ds, false);
        }

        public void VoidTransction()
        {
            string mySql = "Select * From " + MainTable + " where ID = " + _ID + "";
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            var _with2 = ds.Tables[MainTable].Rows[0];

            _with2["Status"] = "C";
            Database.SaveEntry(ds, false);
        }
        #endregion
    }
}
