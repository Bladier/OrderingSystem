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
namespace OrderingSystems

{
    class ClientOrder
    {
        string tblOrder = "tblbillorder";
        string mysql = String.Empty;

        #region "Properties"

        private int _id;
        public virtual int ID
        {
            get { return _id; }
            set { _id = value; }
        }


        private int _QID;
        public virtual int QID
        {
            get { return _QID; }
            set { _QID = value; }
        }

        private bool _status;
        public virtual bool status
        {
            get { return _status; }
            set { _status = value; }
        }

        private double _Cash;
        public virtual double Cash
        {
            get { return _Cash; }
            set { _Cash = value; }
        }

        private double _AmountDue;
        public virtual double AmountDue
        {
            get { return _AmountDue; }
            set { _AmountDue = value; }
        }

        
        private double _Change;
        public virtual double Change
        {
            get { return _Change; }
            set { _Change = value; }
        }

        
        private int _Encoder;
        public virtual int Encoder
        {
            get { return _Encoder; }
            set { _Encoder = value; }
        }

           
        private System.DateTime _DocDate;
        public virtual System.DateTime DocDate
        {
            get { return _DocDate; }
            set { _DocDate = value; }
        }

        private DataSet _Bill_ds;
        public virtual DataSet Bill_ds
        {
            get { return _Bill_ds; }
            set { _Bill_ds = value; }
        }

#endregion

        #region "Functions and Procedures"

        public void loadBillByID(int idx)
        {
            mysql = "SELECT * FROM " + tblOrder + " WHERE ID = " + idx;
            _Bill_ds = Database.LoadSQL(mysql, tblOrder);

            if (_Bill_ds.Tables[0].Rows.Count == 0)
            {
                return;
            }

            LoadByRow(_Bill_ds.Tables[0].Rows[0]);
        }

        public void LoadByRow(DataRow dr)
        {
            DataSet ds = new DataSet();
            var _with3 = dr;
            _id =Convert.ToInt32(_with3["ID"]);
            _QID = Convert.ToInt32(_with3["QueueID"]);
          
            string st = _with3["Status"].ToString();
            if (st== "1")
            { _status =true;}
            else
            {_status =false;}

            _Cash =Convert.ToDouble(_with3["Cash"]);
            _AmountDue = Convert.ToDouble(_with3["AmountDue"]);
            _Change = Convert.ToDouble(_with3["Change"]);
            _Encoder = Convert.ToInt32(_with3["EncodedBy"]);
            _DocDate = Convert.ToDateTime(_with3["DocDate"]);
       
            }
        
            
        internal void savebill()
        {
            mysql = "SELECT * FROM " + tblOrder + " LIMIT 0";
            DataSet ds = Database.LoadSQL(mysql, tblOrder);

            DataRow dsnewRow = null;
            dsnewRow = ds.Tables[0].NewRow();
            var with = dsnewRow;

            with["QueueID"] = _QID;
            if (_status == true)
            { with["Status"] = 1; }
            else { with["Status"] = 0; }

            with["Cash"] = _Cash;
            with["AmountDue"] = _AmountDue;
            with["Change"] = _Change;
            with["EncodedBy"] = mod_system.ORuser.ID;
            with["DocDate"] = _DocDate;

            ds.Tables[0].Rows.Add(dsnewRow);
            Database.SaveEntry(ds);
        }

       
        #endregion
    }
}
