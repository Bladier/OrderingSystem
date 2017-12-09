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
    class passenger
    {

        private string MainTable = "tblpassenger";

        #region "Properties"
        private int _ID;
        public virtual int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private UInt32 _RFIDnum;
        public virtual UInt32 RFIDnum
        {
            get { return _RFIDnum; }
            set { _RFIDnum = value; }
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


        private string _Street;
        public string Street
        {
            get { return _Street; }
            set { _Street = value; }
        }


        private string _Brgy;
        public string Brgy
        {
            get { return _Brgy; }
            set { _Brgy = value; }
        }

        private string _City;
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        private string _Province;
        public string Province
        {
            get { return _Province; }
            set { _Province = value; }
        }

        private UInt64 _ContactNum;
        public UInt64 ContactNum
        {
            get { return _ContactNum; }
            set { _ContactNum = value; }
        }

        private string _PassType;
        public string PassType
        {
            get { return _PassType; }
            set { _PassType = value; }

        }

        private string _IdType;
        public string IdType
        {
            get { return _IdType; }
            set { _IdType = value; }

        }

        private string _IDNum;
        public string IDNum
        {
            get { return _IDNum; }
            set { _IDNum = value; }

        }

        private string _FullAddress;
        public string FullAddress
        {
            get { return _FullAddress; }
            set { _FullAddress = value; }
        }

        private DateTime _CardExp;
        public DateTime CardExp
        {
            get { return _CardExp; }
            set { _CardExp = value; }
        }

        private int _PinCode;
        public int Pincode
        {
            get { return _PinCode; }
            set { _PinCode = value; }
        }
        #endregion

        #region "Functions and Procedures"
        public void Loadpass(int id)
        {
            string mySql = string.Format("SELECT * FROM " + MainTable + " WHERE PAssID = {0}", id);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count != 1)
            {
                MessageBox.Show("Unable load client", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                LoadByRow(dr);
            }
        }

        public void Savepassenger()
        {
            string mySql = "Select * From " + MainTable + " Limit 1";
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            DataRow dsNewRow = null;
            dsNewRow = ds.Tables[0].NewRow();
            var _with2 = dsNewRow;
            _with2["RFIDNum"] = _RFIDnum;
            _with2["Fname"] = _Fname;
            _with2["mname"] = _Mname;
            _with2["lname"] = _Lname;
            _with2["bday"] = _BDay;
            _with2["phone"] = _ContactNum;
            _with2["passType"] = _PassType;
            _with2["Street"] = _Street;
            _with2["Brgy"] = _Brgy;
            _with2["City"] = _City;
            _with2["province"] = _Province;
            _with2["IDType"] = _IdType;
            _with2["IDNumber"] = _IDNum;
            _with2["CardExpiration"] = _CardExp;
            _with2["PinCode"] = _PinCode;
            ds.Tables[0].Rows.Add(dsNewRow);
            Database.SaveEntry(ds);
        }


        public void LoadByRow(DataRow dr)
        {
            DataSet ds = new DataSet();
            var _with3 = dr;
            _ID = Convert.ToInt32(_with3["PassID"]);
            _RFIDnum = Convert.ToUInt32(_with3["RFIDNum"]);
            _Fname = _with3["Fname"].ToString();
            _Mname = _with3["Mname"].ToString();
            _Lname = _with3["Lname"].ToString();
            _BDay = Convert.ToDateTime(_with3["bday"]);
            _ContactNum = Convert.ToUInt64(_with3["Phone"]);
            _PassType = _with3["PassType"].ToString();
            _Street = _with3["Street"].ToString();
            _Brgy = _with3["Brgy"].ToString();
            _City = _with3["City"].ToString();
            _Province = _with3["Province"].ToString();
            _IdType = _with3["IDType"].ToString();
            _IDNum = _with3["IDNumber"].ToString();
            _CardExp = Convert.ToDateTime(_with3["CardExpiration"]);
            _FullAddress = _Street + " " + _Brgy + ", " + _City + ", " + _Province;
            _PinCode = Convert.ToInt32(_with3["PinCode"]);
        }


        public void Update()
        {
            string mySql = string.Format("SELECT * FROM {0} WHERE PASSID = {1}", MainTable, _ID);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count == 1)
            {
                var _with2 = ds.Tables[MainTable].Rows[0];
                _with2["RFIDNum"] = _RFIDnum;
                _with2["Fname"] = _Fname;
                _with2["mname"] = _Mname;
                _with2["lname"] = _Lname;
                _with2["bday"] = _BDay;
                _with2["phone"] = _ContactNum;
                _with2["passType"] = _PassType;
                _with2["Street"] = _Street;
                _with2["Brgy"] = _Brgy;
                _with2["City"] = _City;
                _with2["province"] = _Province;
                _with2["IDType"] = _IdType;
                _with2["IDNumber"] = _IDNum;
                _with2["CardExpiration"] = _CardExp;
                _with2["PinCode"] = _PinCode;
                Database.SaveEntry(ds, false);
            }
            else
            {
                DataRow dsNewRow = null;
                dsNewRow = ds.Tables[0].NewRow();
                var _with2 = dsNewRow;
                _with2["RFIDNum"] = _RFIDnum;
                _with2["Fname"] = _Fname;
                _with2["mname"] = _Mname;
                _with2["lname"] = _Lname;
                _with2["bday"] = _BDay;
                _with2["phone"] = _ContactNum;
                _with2["passType"] = _PassType;
                _with2["Street"] = _Street;
                _with2["Brgy"] = _BDay;
                _with2["City"] = _City;
                _with2["province"] = _Province;
                _with2["IDType"] = _IdType;
                _with2["IDNumber"] = _IDNum;
                _with2["CardExpiration"] = _CardExp;
                _with2["PinCode"] = _PinCode;
                ds.Tables[0].Rows.Add(dsNewRow);
                Database.SaveEntry(ds);
            }
        }

        public void LoadpassbyCard(string cardnum)
        {
            string mySql = string.Format("SELECT * FROM " + MainTable + " WHERE RFIDNUM = '{0}'", cardnum);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count != 1)
            {
                MessageBox.Show("Unable load client", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                LoadByRow(dr);
            }
        }

        public bool IsCardNumExists(string cardNum)
        {
            string mySql = "SELECT * from tblPassenger ";
            mySql += string.Format(" WHERE RFIDNUM = '{0}'",cardNum);
            DataSet ds = null;

            ds = Database.LoadSQL(mySql);
            if (ds.Tables[0].Rows.Count > 0)
                return false;

            return true;
        }

        public bool isPassengerExists(string f,string m,string l,DateTime b)
        {
           
            string tmpcur = b.ToString("yyyy-MM-dd");
            string mySql = "SELECT * from tblPassenger where fname = '" + f + "'";
            if (m != "")
            {
                mySql += " and mname ='" + m + "'";
            }
            mySql += " and lname ='" + l + "' and bday ='" + tmpcur + "'";


            DataSet ds = null;

            ds = Database.LoadSQL(mySql);
            if (ds.Tables[0].Rows.Count > 0)
                return false;

            return true;
        }

    }
      #endregion

    }
