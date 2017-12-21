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
    class Customer
    {

        private string MainTable = "customertbl";

        #region "Properties"
        private int _ID;
        public virtual int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _firstname;
        public  string firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        private string _middlename;
        public string middlename
        {
            get { return _middlename; }
            set { _middlename = value; }
        }

        private string _lastname;
        public string lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }



        private DateTime _birthday;
        public DateTime birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        private DateTime _EndDate;
        public DateTime EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }

        private string _ContactNum;
        public string ContactNum
        {
            get { return _ContactNum; }
            set { _ContactNum = value; }
        }

        private int _brgyID;
        public virtual int brgyID
        {
            get { return _brgyID; }
            set { _brgyID = value; }
        }


        private string _street;
        public string street
        {
            get { return _street; }
            set { _street = value; }
        }


        private string _province;
        public string province
        {
            get { return _province; }
            set { _province = value; }
        }


        private string _fulladdress;
        public string fulladdress
        {
            get { return _fulladdress; }
            set { _fulladdress = value; }
        }


        private string _fullname;
        public string fullname
        {
            get { return _fullname; }
            set { _fullname = value; }
        }

        private string _brgy;
        public string brgy
        {
            get { return _brgy; }
            set { _brgy = value; }
        }

        private string _city;
        public string city
        {
            get { return _city; }
            set { _city = value; }
        }
        #endregion



        #region "Functions
        public void LoadCust(int id)
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

        public void saveCust()
        {
            string mySql = "Select top 1 * From " + MainTable + "";
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            DataRow dsNewRow = null;
            dsNewRow = ds.Tables[0].NewRow();
            var _with2 = dsNewRow;
            _with2["firstname"] = _firstname;
            _with2["middlename"] = _middlename;
            _with2["lastname"] = _lastname;
            _with2["birthday"] = _birthday;
            _with2["contactNum"] = _ContactNum;
            _with2["barangayID"] = _brgyID;
            _with2["Street"] = _street;
            _with2["Province"] = _province;
            ds.Tables[0].Rows.Add(dsNewRow);
            Database.SaveEntry(ds);
        }


        public void LoadByRow(DataRow dr)
        {
            DataSet ds = new DataSet();
            var _with3 = dr;
            _ID = Convert.ToInt32(_with3["ID"]);
            _firstname = _with3["firstname"].ToString();
            _middlename = _with3["middlename"].ToString();
            _lastname = _with3["lastname"].ToString();
            _birthday = Convert.ToDateTime(_with3["birthday"]);
            _ContactNum = _with3["contactNum"].ToString();
            _brgyID = Convert.ToInt32(_with3["barangayID"]);
            _street =_with3["Street"].ToString();
            _province = _with3["Province"].ToString();

            string mysqlBrgy = "select * from barangaytbl where ID = " + _brgyID ;
            DataSet dsbrgy = Database.LoadSQL(mysqlBrgy, "barangaytbl");

            string mysqlcity = "select * from citytbl where ID =" + dsbrgy.Tables[0].Rows[0]["cityID"];
            DataSet dscity = Database.LoadSQL(mysqlcity, "citytbl");

            _fulladdress =  _street + ", " + dsbrgy.Tables[0].Rows[0]["barangay"] + ", " + dscity.Tables[0].Rows[0]["City"] + ", " + _province;
            _fullname = _firstname + " " + middlename + " " + _lastname;
            _brgy = dsbrgy.Tables[0].Rows[0]["barangay"].ToString();
            _city = dscity.Tables[0].Rows[0]["City"].ToString();
        }

        public bool isCustomerExists(string f, string m, string l, DateTime b)
        {

            string tmpcur = b.ToString("yyyy-MM-dd");
            string mySql = "SELECT * from customertbl where firstname = '" + f + "'";
            if (m != "")
            {
                mySql += " and middlename ='" + m + "'";
            }
            mySql += " and lastname ='" + l + "' and birthday ='" + tmpcur + "'";


            DataSet ds = null;

            ds = Database.LoadSQL(mySql);
            if (ds.Tables[0].Rows.Count > 0)
                return false;

            return true;
        }

        public void Update()
        {
            string mySql = string.Format("SELECT * FROM {0} WHERE ID = {1}", MainTable, _ID);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            if (ds.Tables[0].Rows.Count == 1)
            {
                var _with2 = ds.Tables[MainTable].Rows[0];
                _with2["firstname"] = _firstname;
                _with2["middlename"] = _middlename;
                _with2["lastname"] = _lastname;
                _with2["birthday"] = _birthday;
                _with2["contactNum"] = _ContactNum;
                _with2["barangayID"] = _brgyID;
                _with2["Street"] = _street;
                _with2["Province"] = _province;
                Database.SaveEntry(ds, false);
            }
            else
            {
                DataRow dsNewRow = null;
                dsNewRow = ds.Tables[0].NewRow();
                var _with2 = dsNewRow;
                _with2["firstname"] = _firstname;
                _with2["middlename"] = _middlename;
                _with2["lastname"] = _lastname;
                _with2["birthday"] = _birthday;
                _with2["contactNum"] = _ContactNum;
                _with2["barangayID"] = _brgyID;
                _with2["Street"] = _street;
                _with2["Province"] = _province;
                ds.Tables[0].Rows.Add(dsNewRow);
                Database.SaveEntry(ds);
            }
        }

        public int GetLastID()
        {
            string mySql = string.Format("SELECT top 1 * FROM {0} Order by ID desc", MainTable);
            DataSet ds = Database.LoadSQL(mySql, MainTable);

            return Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                
        }
        #endregion
    }
}
