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
    class busManagement
    {
        
        private string MainTable = "tblBus";

        #region "Properties"
        private int _ID;
        public virtual int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _BusType;
        public string BusType
        {
            get { return _BusType; }
            set { _BusType = value; }
        }

        private string _NumSeat;
        public string NumSeat
        {
            get { return _NumSeat; }
            set { _NumSeat = value; }
        }

        private string _PlateNumber;
        public string PlateNumber
        {
            get { return _PlateNumber; }
            set { _PlateNumber = value; }
        }

        private int _Driver;
        public int Driver
        {
            get { return _Driver; }
            set { _Driver = value; }
        }

        private int _Condoctor;
        public int Condoctor
        {
            get { return _Condoctor; }
            set { _Condoctor = value; }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string _BusNo;
        public string BusNo
        {
            get { return _BusNo; }
            set { _BusNo = value; }
        }

        private bool _isadded;
        public bool isadded
        {
            get { return _isadded; }
            set { _isadded = value; }
        }

        #endregion

        #region "Functions
        public void Loadbusmngt(int id)
        {
            string mySql = string.Format("SELECT * FROM " + MainTable + " WHERE busID = {0}", id);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count != 1)
            {
                MessageBox.Show("Unable load bus information", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                LoadByRow(dr);
            }
        }

        public void SaveBusmngt()
        {
            string mySql = "Select * From " + MainTable + " Limit 1";
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            DataRow dsNewRow = null;
            dsNewRow = ds.Tables[0].NewRow();
            var _with2 = dsNewRow;
            _with2["Type"] = _BusType;
            _with2["Seat"] = _NumSeat;
            _with2["Plateno"] = _PlateNumber;
            _with2["driverno"] = _Driver;
            _with2["CondoctorID"] = _Condoctor;
            _with2["Status"] = _status;
            _with2["Busno"] = _BusNo;
            ds.Tables[0].Rows.Add(dsNewRow);
            Database.SaveEntry(ds);
        }


        public void LoadByRow(DataRow dr)
        {
            DataSet ds = new DataSet();
            var _with3 = dr;
            _ID = Convert.ToInt32(_with3["busID"]);
            _BusType = _with3["Type"].ToString();
            _NumSeat = _with3["seat"].ToString();
            _PlateNumber = _with3["plateno"].ToString();
            _Driver = Convert.ToInt32(_with3["driverno"]);
            _status = _with3["status"].ToString();
            _Condoctor = Convert.ToInt32(_with3["CondoctorID"]);
            _BusNo = _with3["Busno"].ToString();
        }

        public void UpdateBusMngnt()
        {
            string mySql = string.Format("SELECT * FROM {0} WHERE busID = {1}", MainTable, _ID);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count == 1)
            {
                var _with2 = ds.Tables[MainTable].Rows[0];

                Console.WriteLine(Convert.ToInt32(_with2["Driverno"]) + " " + _Driver);
                if(Convert.ToInt32(_with2["Driverno"]) != _Driver)
                {
                    buspersonnel bpUnassigned = new buspersonnel();
                    bpUnassigned.ID = Convert.ToInt32(_with2["driverno"]);
                    bpUnassigned.UnAssingedPersonnel();

                    buspersonnel bpAssigned = new buspersonnel();
                    bpAssigned.ID = _Driver;
                    bpAssigned.AssingedPersonnel();
                }

                _with2["Type"] = _BusType;
                _with2["Seat"] = _NumSeat;
                _with2["Plateno"] = _PlateNumber;
                _with2["driverno"] = _Driver;
                _with2["Status"] = _status;
                _with2["CondoctorID"] = _Condoctor;
                _with2["Busno"] = _BusNo;
                Database.SaveEntry(ds, false);
            }
            else
            {
                DataRow dsNewRow = null;
                dsNewRow = ds.Tables[0].NewRow();
                var _with2 = dsNewRow;
                _with2["Type"] = _BusType;
                _with2["Seat"] = _NumSeat;
                _with2["Plateno"] = _PlateNumber;
                _with2["driverno"] = _Driver;
                _with2["Status"] = _status;
                _with2["CondoctorID"] = _Condoctor;
                _with2["Busno"] = _BusNo;
                ds.Tables[0].Rows.Add(dsNewRow);
                Database.SaveEntry(ds);
            }
        }

        public void IsBusAdded()
        {
            string mySql = string.Format("SELECT * FROM {0} WHERE busNO = {1}", MainTable, _BusNo);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count > 0)
            {
                _isadded = true;
            }
            else
            {
                _isadded = false;
            }
        }
           
        #endregion
            
    }
}
