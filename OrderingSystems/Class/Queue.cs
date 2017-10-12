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

namespace OrderingSystems.Class
{
    class Queue
    {

        private string MainTable = "tblqueue";

        private string SubTable = "tblqueueinfo";
        #region "Properties"
        private int _ID;
        public virtual int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _OrderNum;
        public string OrderNum
        {
            get { return _OrderNum; }
            set { _OrderNum = value; }
        }


        private System.DateTime OrderDate;
        public System.DateTime _OrderDate
        {
            get { return _OrderDate; }
            set { _OrderDate = value; }
        }

        private bool _Status;
        public bool Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private double _intRate;
        public double InterestRate
        {
            get { return _intRate; }
            set { _intRate = value; }
        }


        private QueueCol _QueueColl;
        public QueueCol QueueColl
        {
            get { return _QueueColl; }
            set { _QueueColl = value; }
        }

        #endregion

        #region "Functions and Procedures"
        public void LoadQueue(int id)
        {
            string mySql = string.Format("SELECT * FROM " + MainTable + " WHERE ID = {0}", id);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count != 1)
            {
                MessageBox.Show("Unable load Order", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            foreach (DataRow dr  in ds.Tables[0].Rows)
            {
                LoadByRow(dr);
            }

            mySql = string.Format("SELECT * FROM {0} WHERE QUEUEID = {1} ORDER BY ID", SubTable, _ID);
            ds.Clear();
            ds = Database.LoadSQL(mySql, SubTable);

            _QueueColl = new QueueCol();
            foreach (DataRow dr in ds.Tables[SubTable].Rows)
            {
                QueueLines tmpqueulines = new QueueLines();
                tmpqueulines.LoadByRow(dr);

                _QueueColl.Add(tmpqueulines);
            }
        }

        //    public void Save_ItemClass()
        //    {
        //        string mySql = string.Format("SELECT * FROM tblItem WHERE ItemClass = '%{0}%'", _itemClassName);
        //        DataSet ds = LoadSQL(mySql, MainTable);

        //        if (ds.Tables[0].Rows.Count == 1)
        //        {
        //            Interaction.MsgBox("Class already existed", MsgBoxStyle.Critical);
        //            return;
        //        }

        //        DataRow dsNewRow = null;
        //        dsNewRow = ds.Tables[0].NewRow();
        //        var _with2 = dsNewRow;
        //        _with2.Item("ItemClass") = _itemClassName;
        //        _with2.Item("ItemCategory") = _category;
        //        _with2.Item("Description") = _desc;
        //        _with2.Item("isRenew") = (_isRenew ? 1 : 0);
        //        _with2.Item("onHold") = (_onHold ? 1 : 0);
        //        _with2.Item("Print_Layout") = _printLayout;
        //        _with2.Item("Renewal_Cnt") = _Count;
        //        _with2.Item("Created_At") = DateAndTime.Now;

        //        _with2.Item("Scheme_ID") = _interestScheme.SchemeID;

        //        ds.Tables[0].Rows.Add(dsNewRow);
        //        database.SaveEntry(ds);


        //        mySql = "SELECT * FROM tblItem ORDER BY ItemID DESC ROWS 1";
        //        ds = LoadSQL(mySql, MainTable);
        //        _itemID = ds.Tables[MainTable].Rows[0]["ItemID"];

        //        foreach (ItemSpecs ItemSpec in ItemSpecifications)
        //        {
        //            ItemSpec.ItemID = _itemID;
        //            ItemSpec.SaveSpecs();
        //        }
        //    }

        public void LoadByRow(DataRow dr)
        {
            DataSet ds = new DataSet();
            var _with3 = dr;
            _ID =Convert.ToInt32(_with3["ID"]);
            _OrderNum = _with3["OrderNum"].ToString();
            _OrderDate = Convert.ToDateTime(_with3["Date"]);

             string tmpqty = _with3["Status"].ToString();
            if (tmpqty =="1")
            {
                _Status =true;
            }
            else
            {
                _Status =false;
            }
         
            }
        }

        //    public void Update()
        //    {
        //        string mySql = string.Format("SELECT * FROM {0} WHERE ItemID = {1}", MainTable, _itemID);
        //        DataSet ds = LoadSQL(mySql, MainTable);

        //        if (ds.Tables[0].Rows.Count != 1)
        //        {
        //            Interaction.MsgBox("Unable to update record", MsgBoxStyle.Critical);
        //            return;
        //        }

        //        var _with4 = ds.Tables[MainTable].Rows[0];
        //        //.Item("ItemClass") = _itemClassName
        //        _with4.Item("ItemCategory") = _category;
        //        _with4.Item("Description") = _desc;
        //        _with4.Item("isRenew") = _isRenew ? 1 : 0;
        //        _with4.Item("onHold") = _onHold ? 1 : 0;
        //        _with4.Item("Print_Layout") = _printLayout;
        //        _with4.Item("Renewal_Cnt") = _Count;
        //        _with4.Item("Updated_At") = DateAndTime.Now;

        //        _with4.Item("Scheme_ID") = _interestScheme.SchemeID;

        //        database.SaveEntry(ds, false);
        //    }

        //    public float LASTITEMID()
        //    {
        //        string mySql = "SELECT * FROM TBLItem ORDER BY ItemID DESC";
        //        DataSet ds = LoadSQL(mySql);

        //        if (ds.Tables[0].Rows.Count == 0)
        //        {
        //            return 0;
        //        }
        //        return ds.Tables[0].Rows[0]["ItemID"];
        //    }
      #endregion

    }
