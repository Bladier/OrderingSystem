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
    class User
    {
        string tblUser = "tbluser";
        string mysql = string.Empty;
        #region "Properties"
        

        private int _id;
        public virtual int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _Firstname;
        public virtual string Firstname
        {
            get { return _Firstname; }
            set { _Firstname = value; }
        }

        private string _MiddleName;
        public virtual string MiddleName
        {
            get { return _MiddleName; }
            set { _MiddleName = value; }
        }


        private string _Lastname;
        public virtual string Lastname
        {
            get { return _Lastname; }
            set { _Lastname = value; }
        }

        private string _Username;
        public virtual string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        private string _UserPass;
        public virtual string UserPass
        {
            get { return _UserPass; }
            set { _UserPass = value; }
        }

        private string _UserType;
        public virtual string UserType
        {
            get { return _UserType; }
            set { _UserType = value; }
        }

        private bool _Status;
        public virtual bool Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        #endregion

        #region "Functions"

        public void LoadQueue(int id)
        {
            string mySql = string.Format("SELECT * FROM " + tblUser + " WHERE ID = {0}", id);
            DataSet ds = Database.LoadSQL(mySql, tblUser);

            if (ds.Tables[0].Rows.Count != 1)
            {
                MessageBox.Show("Unable load User", "Error",
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
            _id = Convert.ToInt32(_with3["ID"]);
            _Firstname = _with3["Firstname"].ToString();
            _MiddleName = _with3["MiddleName"].ToString();
            _Lastname = _with3["LastName"].ToString();
            _Username = _with3["Username"].ToString();
            _UserPass = _with3["Userpass"].ToString();
            _UserType = _with3["UserType"].ToString();

            string tmpqty = _with3["Status"].ToString();
            if (tmpqty == "1")
            {
                _Status = true;
            }
            else
            {
                _Status = false;
            }
        }

            public void SaveUser(string Username)
            {
                mysql = "SELECT * FROM " + tblUser + " WHERE ID = " + _id;
                DataSet ds = Database.LoadSQL(mysql,tblUser);

                if (ds.Tables[0].Rows.Count == 0)
                { 

                }
            }

        #endregion
        }
    }
