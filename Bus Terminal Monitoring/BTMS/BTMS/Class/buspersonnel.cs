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
    class buspersonnel
    {
        private string MainTable = "tblbusperson";

        #region "Properties"
        private int _ID;
        public virtual int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _Fname;
        public string Fname
        {
            get { return _Fname; }
            set { _Fname = value; }
        }


        private string _Mname;
        public string Mname
        {
            get { return _Mname; }
            set { _Mname = value; }
        }

        private string _Lname;
        public string Lname
        {
            get { return _Lname; }
            set { _Lname = value; }
        }

        private DateTime _BDay;
        public DateTime BDay
        {
            get { return _BDay; }
            set { _BDay = value; }
        }

        private string _Position;
        public string Position
        {
            get { return _Position; }
            set { _Position = value; }
        }

        private bool _status;
        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private bool _IsAssigned;
        public bool IsAssigned
        {
            get { return _IsAssigned; }
            set { _IsAssigned = value; }
        }

        private DateTime _DateHired;
        public DateTime DateHired
        {
            get { return _DateHired; }
            set { _DateHired = value; }
        }
        #endregion

        #region "Functions
        public void Loadpersonnel(int id)
        {
            string mySql = string.Format("SELECT * FROM " + MainTable + " WHERE personid = {0}", id);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count != 1)
            {
                MessageBox.Show("Unable load personnel", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                LoadByRow(dr);
            }
        }

        public void Savepersonnel()
        {
            string mySql = "Select * From " + MainTable + " Limit 1";
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            DataRow dsNewRow = null;
            dsNewRow = ds.Tables[0].NewRow();
            var _with2 = dsNewRow;
            _with2["Finame"] = _Fname;
            _with2["miname"] = _Mname;
            _with2["laname"] = _Lname;
            _with2["bday"] = _BDay;
            _with2["Position"] = _Position;
            _with2["IsAssigned"] = 0;
            _with2["DateHired"] = _DateHired;
            ds.Tables[0].Rows.Add(dsNewRow);
            Database.SaveEntry(ds);
        }


        public void LoadByRow(DataRow dr)
        {
            DataSet ds = new DataSet();
            var _with3 = dr;
            _ID = Convert.ToInt32(_with3["Personid"]);
            _Fname = _with3["Finame"].ToString();
            _Mname = _with3["Miname"].ToString();
            _Lname = _with3["Laname"].ToString();
            _BDay = Convert.ToDateTime(_with3["bday"]);

            _Position = _with3["Position"].ToString();

            if (Convert.ToInt32(_with3["Status"]) == 1)
            { _status = true;}
            else{_status = false; }

            if (Convert.ToInt32(_with3["IsAssigned"]) == 1)
            { _IsAssigned = true;}
            else { _IsAssigned = false; }
        }

        public void Updatepersonnel()
        {
            string mySql = string.Format("SELECT * FROM {0} WHERE Personid = {1}", MainTable, _ID);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count == 1)
            {
                var _with2 = ds.Tables[MainTable].Rows[0];
                _with2["Finame"] = _Fname;
                _with2["miname"] = _Mname;
                _with2["laname"] = _Lname;
                _with2["bday"] = _BDay;
                _with2["Position"] = _Position;

                if (_status)
                {
                    _with2["status"] =1;
                }
                else
                {
                    _with2["status"] = 0;
                }
                _with2["DateHired"] = _DateHired;
                Database.SaveEntry(ds, false);
            }
            else
            {
                DataRow dsNewRow = null;
                dsNewRow = ds.Tables[0].NewRow();
                var _with2 = dsNewRow;
                _with2["Finame"] = _Fname;
                _with2["miname"] = _Mname;
                _with2["laname"] = _Lname;
                _with2["bday"] = _BDay;
                _with2["Position"] = _Position;
                _with2["DateHired"] = _DateHired;

                ds.Tables[0].Rows.Add(dsNewRow);
                Database.SaveEntry(ds);
            }
        }
            
        public void AssingedPersonnel()
        {
            string mySql = string.Format("SELECT * FROM {0} WHERE Personid = {1}", MainTable, _ID);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            var _with2 = ds.Tables[MainTable].Rows[0];
            _with2["IsAssigned"] = 1;
            Database.SaveEntry(ds, false);
        }

        public void UnAssingedPersonnel()
        {
            string mySql = string.Format("SELECT * FROM {0} WHERE Personid = {1}", MainTable, _ID);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            var _with2 = ds.Tables[MainTable].Rows[0];
            _with2["IsAssigned"] = 0;
            Database.SaveEntry(ds, false);
        }

        public void loadLastSave()
        {
            string mySql = string.Format("SELECT * FROM {0} ORDER BY PERSONID DESC LIMIT 1", MainTable);
            DataSet ds = Database.LoadSQL(mySql, MainTable);


            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                LoadByRow(dr);
            }
        }
        #endregion
    } 
    
}
