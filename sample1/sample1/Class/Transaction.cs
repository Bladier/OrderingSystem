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
    class transaction
    {
        DateTime tmpStartTime;
        DateTime tmpTime;
        int maxi;
        private string MainTable = "transactiontbl";

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

        private int _TransactionNum;
        public virtual int TransactionNum
        {
            get { return _TransactionNum; }
            set { _TransactionNum = value; }
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

        private double _Rate;
        public double Rate
        {
            get { return _Rate; }
            set { _Rate = value; }
        }


        private string _mod;
        public string mod
        {
            get { return _mod; }
            set { _mod = value; }
        }
        #endregion

        #region "Functions
        public void loadTrans(int id)
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

        public void saveTrans()
        {
            string mySql = "Select top 1 * From " + MainTable + "";
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            DataRow dsNewRow = null;
            dsNewRow = ds.Tables[0].NewRow();
            var _with2 = dsNewRow;
            _with2["TransactionNum"] = _TransactionNum;
            _with2["venueID"] = _venueID;
            _with2["customerID"] = _CusID;
            _with2["TransDate"] = _Transdate;
            _with2["StartDate"] = _StartDate;
            _with2["EndDate"] = _EndDate;
            _with2["Status"] = _status;
            _with2["Total"] = _Total;
            _with2["Balance"] = _Balance;
            _with2["Rate"] = _Rate;
            _with2["MOD"] = _mod;
            _with2["TransactionnUm"] = _TransactionNum;
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
            //   _ForfeitDate = Convert.ToDateTime(_with3["ForfeitDate"]);
            _Balance = Convert.ToDouble(_with3["Balance"]);
            _Rate = Convert.ToDouble(_with3["Rate"]);
            _mod = _with3["MOD"].ToString();
            _TransactionNum = Convert.ToInt32(_with3["TransactionnUm"]);
        }

        public void UpdateTrans()
        {
            string mySql = string.Format("SELECT * FROM {0} WHERE ID = {1}", MainTable, _ID);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count == 1)
            {
                var _with2 = ds.Tables[MainTable].Rows[0];
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
                // _with2["ForfeitDate"] = _ForfeitDate;
                _with2["Balance"] = _Balance;
                _with2["Rate"] = _Rate;
                _with2["MOD"] = _mod;
                _with2["TransactionnUm"] = _TransactionNum;
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

        public void CheckOut()
        {
            string mySql = string.Format("SELECT * FROM {0} where ID =" + _ID + "", MainTable);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            var _with2 = ds.Tables[MainTable].Rows[0];
            _with2["Status"] = _status;
            Database.SaveEntry(ds, false);
        }


        public bool isHasReserved_or_Booked(DateTime Res_startDate)
        {
            string tmpDate = Res_startDate.ToString("yyyy-MM-dd") + " " + Convert.ToString(Res_startDate.ToShortTimeString());

            string mySql = string.Format("SELECT  * FROM {0}", MainTable);
            mySql += " WHere (status = 'Booked' or status ='Reserved')";

            DataSet ds = Database.LoadSQL(mySql, MainTable);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DateTime tmpDates = Convert.ToDateTime(Convert.ToDateTime(dr["EndDate"]).ToShortDateString());
                DateTime tmpStartDate = Convert.ToDateTime(Res_startDate.ToShortDateString());

                tmpStartTime = Convert.ToDateTime(Res_startDate.ToShortTimeString());
                tmpTime = Convert.ToDateTime(Convert.ToDateTime(dr["EndDate"]).ToShortTimeString());

                DateTime d1 = Convert.ToDateTime(Convert.ToDateTime(dr["StartDate"]));
                DateTime d2 = Convert.ToDateTime(Convert.ToDateTime(dr["EndDate"]));

                TimeSpan t = d2 - d1;
                double NrOfDays = Math.Round(t.TotalDays) + 1;


                if (NrOfDays > 2)
                {
                    for (int i = 0; i < NrOfDays; i++)
                    {
                        Console.WriteLine(i);
                        maxi = i;
                    }
                }

                if (NrOfDays > 1)
                {
                    for (int i = 0; i < NrOfDays; i++)
                    {
                        if (i == 0)
                        {
                            if (tmpStartDate == Convert.ToDateTime(d1.ToShortDateString()))
                            {
                                    return true;
                            }
                            continue;
                        }

                        if (i == maxi)
                        {
                            continue;
                        }

                        d1 = d1.AddDays(i);

                        if (tmpStartDate == Convert.ToDateTime(d1.ToShortDateString()))
                        {
                            return true;
                        }
                        d1 = Convert.ToDateTime(Convert.ToDateTime(dr["StartDate"]));
                    }
                }


                if (tmpStartDate == tmpDates)
                {
                   
                    if (tmpTime >= tmpStartTime)
                    {
                        return true;
                    }
                }

            }
            return false;


        #endregion
        }
    }
    
}
