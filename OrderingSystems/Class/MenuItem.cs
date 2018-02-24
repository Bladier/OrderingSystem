using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.Reporting.WinForms;

namespace OrderingSystems
{
    class MenuItem
    {
        #region Properties
        private int _id;
        public virtual int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _menuName;
        public virtual string MenuName
        {
            get { return _menuName; }
            set { _menuName = value; }
        }

        private string _menuType;
        public virtual string MenuType
        {
            get { return _menuType; }
            set { _menuType = value; }
        }

        private string _menuSize;
        public virtual string MenuSize
        {
            get { return _menuSize; }
            set { _menuSize = value; }
        }

        private double _price;
        public virtual double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private string _status;
        public virtual string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private int _qty;
        public virtual int Qty
        {
            get { return _qty; }
            set { _qty = value; }
        }

        private int _PQTY;
        public virtual int PQTY
        {
            get { return _PQTY; }
            set { _PQTY = value; }
        }
        #endregion

        #region Procedures
        internal void LoadMenuItem()
        {
            string mysql = "Select * From tblMenu Where ID = " + _id;
            DataSet ds = Database.LoadSQL(mysql, "tblMenu");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                LoadbyRows(dr);
            }
        }

        public bool Hasqty(int inputQTY)
        {
            string mysql = "Select * From tblMenu Where ID = " + _id;
            DataSet ds = Database.LoadSQL(mysql, "tblMenu");

            if (ds.Tables[0].Rows.Count > 0)
            {
                int q = Convert.ToInt32(ds.Tables[0].Rows[0]["QTY"]);

                if (q == 0)
                {
                    MessageBox.Show("Not enough stocks.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                if (q < inputQTY)
                {
                    MessageBox.Show("Not enough stocks.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                return true;
            }
            return true;
        }

        public void LoadbyRows(DataRow dr)
        {
            _id = Convert.ToInt32(dr["ID"]);
            _menuName = dr["MenuName"].ToString();
            _menuType = dr["MenuType"].ToString();
            _menuSize = dr["MenuSize"].ToString();
            _price = Convert.ToDouble(dr["Price"]);
            _status = dr["Status"].ToString();
            _qty = Convert.ToInt32(dr["qty"]);
           

        }


            internal void SaveMenu()
            {
                string mysql = "Select * From tblMenu Where ID =" + _id;
                DataSet ds = Database.LoadSQL(mysql, "tblMenu");

            if (ds.Tables[0].Rows.Count == 0)
            {
                DataRow dsNewRow = null;
                dsNewRow = ds.Tables[0].NewRow();
                var with = dsNewRow;
                with["MenuName"] = _menuName;
                with["MenuType"] = _menuType;
                with["MenuSize"] = _menuSize;
                with["Price"] = _price;
                with["Status"] = _status;
                with["qty"] = _PQTY;
                ds.Tables[0].Rows.Add(dsNewRow);
                Database.SaveEntry(ds, true);
            }
            else
            {
                var with = ds.Tables[0].Rows[0];
                with["MenuName"] = _menuName;
                with["MenuType"] = _menuType;
                with["MenuSize"] = _menuSize;
                with["Price"] = _price;
                with["Status"] = _status;

                int _q = Convert.ToInt32(ds.Tables[0].Rows[0]["qty"]);

                _q = _q + _PQTY;
                with["qty"] = _q;
                Database.SaveEntry(ds, false);
            }
        }

            public void deduct(int inputQTY,int idx)
            {
                string mysql = "Select * From tblMenu Where ID = " + idx;
                DataSet ds = Database.LoadSQL(mysql, "tblMenu");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int q = Convert.ToInt32(ds.Tables[0].Rows[0]["qty"]);

                    q = q - inputQTY;
                    var with = ds.Tables[0].Rows[0];
                    with["qty"] = q;
                    Database.SaveEntry(ds, false);

                }

            }

        #endregion
    }
}
