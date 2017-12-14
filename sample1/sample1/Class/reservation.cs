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
    class revervation
    {
        private string MainTable = "reservationtbl";

        #region "Properties"
        private int _ID;
        public virtual int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

           private int _venueID;
        public virtual int venueID
        {
            get { return _venueID; }
            set { _venueID = value; }
        }


        private int _CusID;
        public virtual int CusID
        {
            get { return _CusID; }
            set { _CusID = value; }
        }


        private DateTime _Transdate;
        public DateTime Transdate
        {
            get { return _Transdate; }
            set { _Transdate = value; }
        }

        private DateTime _StartDate;
        public DateTime StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }

        private DateTime _EndDate;
        public DateTime EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private double _Total;
        public double Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private DateTime _ForfeitDate;
        public DateTime ForfeitDate
        {
            get { return _ForfeitDate; }
            set { _ForfeitDate = value; }
        }

        private double _Balance;
        public double Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }
        #endregion

        #region "Functions
        public void Loadpersonnel(int id)
        {
            string mySql = string.Format("SELECT * FROM " + MainTable + " WHERE ID = {0}", id);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count != 1)
            {
                MessageBox.Show("Unable load information", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                LoadByRow(dr);
            }
        }

        public void saveRes()
        {
            string mySql = "Select top 1 * From " + MainTable + "";
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            DataRow dsNewRow = null;
            dsNewRow = ds.Tables[0].NewRow();
            var _with2 = dsNewRow;
            _with2["venueID"] = _venueID;
            _with2["customerID"] = _CusID;
            _with2["TransDate"] = _Transdate;
            _with2["StartDate"] = _StartDate;
            _with2["EndDate"] = _EndDate;
            _with2["Status"] = _status;
            _with2["Total"] = _Total;
            _with2["ForfeitDate"] = _ForfeitDate;
            _with2["Balance"] = _Balance;
        
            ds.Tables[0].Rows.Add(dsNewRow);
            Database.SaveEntry(ds);
        }


        public void LoadByRow(DataRow dr)
        {
            DataSet ds = new DataSet();
            var _with3 = dr;
            _ID = Convert.ToInt32(_with3["ID"]);
            _venueID = Convert.ToInt32(_with3["venueID"]);
            _CusID = Convert.ToInt32(_with3["customerID"]);
            _Transdate = Convert.ToDateTime(_with3["TransDate"]);
            _StartDate = Convert.ToDateTime(_with3["StartDate"]);
            _EndDate = Convert.ToDateTime(_with3["EndDate"]);
            _status = _with3["Status"].ToString();
            _Total = Convert.ToDouble(_with3["Total"]);
            _ForfeitDate = Convert.ToDateTime(_with3["ForfeitDate"]);
            _Balance = Convert.ToDouble(_with3["Balance"]);
   
        }

        public void Updatepersonnel()
        {
            string mySql = string.Format("SELECT * FROM {0} WHERE Personid = {1}", MainTable, _ID);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count == 1)
            {
                var _with2 = ds.Tables[MainTable].Rows[0];
                _with2["venueID"] = _venueID;
                _with2["customerID"] = _CusID;
                _with2["TransDate"] = _Transdate;
                _with2["StartDate"] = _StartDate;
                _with2["EndDate"] = _EndDate;
                _with2["Status"] = _status;
                _with2["Total"] = _Total;
                _with2["ForfeitDate"] = _ForfeitDate;
                _with2["Balance"] = _Balance;
                Database.SaveEntry(ds, false);
            }
            else
            {
                DataRow dsNewRow = null;
                dsNewRow = ds.Tables[0].NewRow();
                var _with2 = dsNewRow;
                _with2["venueID"] = _venueID;
                _with2["customerID"] = _CusID;
                _with2["TransDate"] = _Transdate;
                _with2["StartDate"] = _StartDate;
                _with2["EndDate"] = _EndDate;
                _with2["Status"] = _status;
                _with2["Total"] = _Total;
                _with2["ForfeitDate"] = _ForfeitDate;
                _with2["Balance"] = _Balance;

                ds.Tables[0].Rows.Add(dsNewRow);
                Database.SaveEntry(ds);
            }
        }
        public int GetLastID()
        {
            string mySql = string.Format("SELECT TOP 1 * FROM {0} ORDER BY ID DESC", MainTable);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);

        }

        public bool isHasReserved_or_Booked(DateTime Res_startDate)
        {
            string tmpDate = Res_startDate.ToString("yyyy-MM-dd") + " " + Convert.ToString(Res_startDate.ToShortTimeString());
            
            string mySql = string.Format("SELECT  * FROM {0}", MainTable);
            mySql += " where (EndDate >= '" + tmpDate + "')";
            mySql += " and (status = 'Booked' or status ='Reserved')";

            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }

            return false;
        }
        #endregion
    } 
    
}
