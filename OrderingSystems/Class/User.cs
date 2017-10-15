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
<<<<<<< HEAD
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace OrderingSystems
{
  public  class User
    {
        #region Properties


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

        private string _Username;
        public virtual string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        private string _userpass;
        public virtual string userpass
        {
            get { return _userpass; }
            set { _userpass = value; }
        }

        private string _firstname;
        public virtual string firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        private string _Midname;
        public virtual string MidName
        {
            get { return _Midname; }
            set { _Midname = value; }
        }

        private string _Lastname;
        public virtual string Lastname
        {
            get { return _Lastname; }
            set { _Lastname = value; }

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
>>>>>>> origin/Casher
        }

        private bool _Status;
        public virtual bool Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private string _UserRule;
        public virtual string Userrule
        {
            get { return _UserRule; }
            set { _UserRule = value; }
        }
        #endregion

        #region"Functions and Variable"
        internal void Loaduser(int id)
        {
            string mysql = "SELECT * FROM TBLUSER WHERE ID =" + id;
                DataSet ds = Database.LoadSQL(mysql,"tblUser");
                
            if (ds.Tables[0].Rows.Count==0)
            {
                MessageBox.Show("Unable to load user.");
                return;
            }

            foreach (DataRow u in ds.Tables[0].Rows)
            {
                LoadUserbyRow(u);

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


        public void LoadUserbyRow(DataRow dr)
        {
            var with = dr;
            _id = Convert.ToInt32(with["ID"]);
            _Username = with["Username"].ToString();
            _userpass = with["Userpass"].ToString();
            _firstname = with["Firstname"].ToString();
            _Midname = with["Middlename"].ToString();
            _Lastname = with["Lastname"].ToString();
            int st = Convert.ToInt32(with["Status"]);
            if (st == 1)
            { _Status =true;}
            else
            { _Status = false;}
            _UserRule = with["UserType"].ToString();
        }

        public void SaveUser(bool isNew = true, string NewPassword = "")
        {
            string mySql = "SELECT * FROM " + " tblUser";
            if (!isNew)
                mySql += " WHERE UserID = " + _id;

            DataSet ds = Database.LoadSQL(mySql, "tblUser");
            if (isNew)
            {
                DataRow dsNewRow = null;
                dsNewRow = ds.Tables["tblUser"].NewRow();
                var _with3 = dsNewRow;
                _with3["Username"] = _Username;
                _with3["Userpass"] = _userpass;
                _with3["Firstname"] = _firstname;
                _with3["Middlename"] = _Midname;
                _with3["Lastname"] = _Lastname;
                _with3["UserType"] = _UserRule;
                ds.Tables["tblUser"].Rows.Add(dsNewRow);
            }
            else
            {
                var _with4 = ds.Tables[0].Rows[0];
                _with4["Username"] = _Username;
                if (!string.IsNullOrEmpty(NewPassword))
                {
                    _with4["UserPass"] = DeathCodez.Security.Encrypt(_userpass);
                }
                _with4["Firstname"] = _firstname;
                _with4["MiddleName"]=_Midname;
                _with4["Lastname"] = _Lastname;
                if (_Status == true) { _with4["status"] = 1; }
                else { _with4["status"] = 1; }
            }

            Database.SaveEntry(ds, isNew);
            Console.WriteLine(_Username + " saved.");
        }

        public bool LoginUser(string user, string password)
        {
           string mySql = "SELECT ID, LOWER(Username) FROM " + " tblUser";
            mySql += Constants.vbCrLf + string.Format(" WHERE LOWER(Username) = LOWER('{0}') AND UserPass = '{1}' AND STATUS <> '0'", user, DeathCodez.Security.Encrypt(password));
            DataSet ds = null;

            ds = Database.LoadSQL(mySql);
            if (ds.Tables[0].Rows.Count == 0)
                return false;
                
            int tmpID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
            Loaduser(tmpID);

            return true;
        }

        public void ChangePassword()
        {
            string mySql = "SELECT * FROM tblUser WHERE ID = " + _id;
            DataSet ds = Database.LoadSQL(mySql, "tblUser");

            ds.Tables["tblUser"].Rows[0]["USERPASS"] = DeathCodez.Security.Encrypt(_userpass);
            Database.SaveEntry(ds, false);
        }

        public void DeleteUser(bool Status)
        {
            string mySql = "SELECT * FROM tblUser WHERE ID = " + _id;
            DataSet ds = Database.LoadSQL(mySql, "tbluser");
            if (Status == true)
            {
                ds.Tables["tblUser"].Rows[0]["STATUS"] = "1";
            }
            else
            {
                ds.Tables["tblUser"].Rows[0]["STATUS"] = "0";
            }
            Database.SaveEntry(ds, false);
            // End If
        }
        #endregion

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
