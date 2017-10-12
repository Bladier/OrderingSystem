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
using MySql.Data.MySqlClient;

namespace OSys.Class
{
    class User
    {

        //private string fillData = "tbl_Gamit";
        //private string mySql = string.Empty;

        //#region "Properties"
        //private int _userID;
        //public int UserID
        //{
        //    get { return _userID; }
        //    set { _userID = value; }
        //}

        //private string _userName;
        //public string UserName
        //{
        //    get { return _userName; }
        //    set { _userName = value; }
        //}

        //private string _password;
        //public string Password
        //{
        //    get { return _password; }
        //    set { _password = value; }
        //}

        //private string _fullName;
        //public string FullName

        //{
        //    get { return _fullName; }
        //    set { _fullName = value; }
        //}

        //private int _UserStatus;
        //public int UserStatus
        //{
        //    get { return _UserStatus; }
        //    set { _UserStatus = value; }
        //}

        //private string _UserType;
        //public string UserType
        //{
        //    get { return _UserType; }
        //    set { _UserType = value; }
        //}

        //private System.DateTime _lastLogin;
        //public System.DateTime LastLogin
        //{
        //    get { return _lastLogin; }
        //    set { _lastLogin = value; }
        //}
        //#endregion

        //#region "Procedures and Functions"
        //public void CreateAdministrator(string pass = "admin2017")
        //{
        //    mySql = "SELECT * FROM " + fillData;
        //    string user = null;
        //    string fullname = null;
        //    DataSet ds = null;
        //    user = "Admin";
        //    fullname = "Hero Nino Lara";


        //    mySql += string.Format(" WHERE Username = '{0}'", user);

        //    Console.WriteLine("Create SQL: " + mySql);

        //    ds = LoadSQL(mySql, fillData);
        //    if (ds.Tables[fillData].Rows.Count > 0)
        //        return;

        //    DataRow dsNewRow = null;
        //    dsNewRow = ds.Tables[fillData].NewRow();
        //    var _with1 = dsNewRow;
        //    _with1.Item("Username") = user;
        //    _with1.Item("UserPass") = DeathCodez.Security.Encrypt(pass);
        //    _with1.Item("Fullname") = fullname;
        //    _with1.Item("privilege") = "PDuNxp8S9q0=";
        //    ds.Tables[fillData].Rows.Add(dsNewRow);
        //    database.SaveEntry(ds, true);
        //}

        ///// <summary>
        ///// For Adding Priviledge
        ///// </summary>
        ///// <remarks></remarks>
        

        //public void LoadUserByRow(DataRow dr)
        //{
        //    //On Error Resume Next

        //    var _with2 = dr;
        //    _userID = _with2.Item("UserID");
        //    _userName = _with2.Item("UserName");
        //    _password = _with2.Item("UserPass");
        //    _fullName = _with2.Item("FullName");
        //    _privilege = _with2.Item("Privilege");
        //    if (!Information.IsDBNull(_with2.Item("LastLogin")))
        //        _lastLogin = _with2.Item("LastLogin");
        //    getPrivilege();
        //}

        //public void SaveUser(bool isNew = true, string NewPassword = "")
        //{
        //    mySql = "SELECT * FROM " + fillData;
        //    if (!isNew)
        //        mySql += " WHERE UserID = " + _userID;

        //    DataSet ds = LoadSQL(mySql, fillData);
        //    if (isNew)
        //    {
        //        DataRow dsNewRow = null;
        //        dsNewRow = ds.Tables[fillData].NewRow();
        //        var _with3 = dsNewRow;
        //        _with3.Item("Username") = _userName;
        //        _with3.Item("UserPass") = DeathCodez.Security.Encrypt(_password);
        //        _with3.Item("FullName") = _fullName;
        //        _with3.Item("Privilege") = _privilege;
        //        //.Item("LastLogin") = _lastLogin 'First Login no Last Login
        //        _with3.Item("EncoderID") = _encoderID;
        //        _with3.Item("SystemInfo") = DateAndTime.Now.Date;
        //        _with3.Item("STATUS") = _UserStatus;
        //        ds.Tables[fillData].Rows.Add(dsNewRow);
        //    }
        //    else
        //    {
        //        var _with4 = ds.Tables[0].Rows[0];
        //        _with4.Item("Username") = _userName;
        //        if (!string.IsNullOrEmpty(NewPassword))
        //        {
        //            _with4.Item("UserPass") = DeathCodez.Security.Encrypt(_password);
        //        }
        //        _with4.Item("FullName") = _fullName;
        //        _with4.Item("Privilege") = _privilege;
        //    }

        //    database.SaveEntry(ds, isNew);
        //    Console.WriteLine(_userName + " saved.");
        //}

        //public void LoadUser(int id)
        //{
        //    mySql = "SELECT * FROM " + fillData + " WHERE UserID = " + id;
        //    DataSet ds = LoadSQL(mySql);
        //    if (ds.Tables[0].Rows.Count == 0)
        //        return;


        //    LoadUserByRow(ds.Tables[0].Rows[0]);
        //    Console.WriteLine(string.Format("[ComputerUser] UserID {0} - {1} Loaded", _userID, _userName));
        //}

        //public bool LoginUser(string user, string password)
        //{
        //    mySql = "SELECT UserID, LOWER(Username) FROM " + fillData;
        //    mySql += Constants.vbCrLf + string.Format(" WHERE LOWER(Username) = LOWER('{0}') AND UserPass = '{1}' AND STATUS <> '0'", user, DeathCodez.Security.Encrypt(password));
        //    DataSet ds = null;

        //    ds = LoadSQL(mySql);
        //    if (ds.Tables[0].Rows.Count == 0)
        //        return false;

        //    LoadUser(ds.Tables[0].Rows[0]["UserID"]);

        //    return true;
        //}

        //public void UpdateLogin()
        //{
        //    mySql = "SELECT * FROM " + fillData + " WHERE UserID = " + _userID;
        //    DataSet ds = LoadSQL(mySql, fillData);
        //    ds.Tables[0].Rows[0]["LastLogin"] = DateAndTime.Now;
        //    database.SaveEntry(ds, false);
        //    Console.WriteLine("Login Saved");
        //}

        //public void ChangePassword()
        //{
        //    string mySql = "SELECT * FROM tbl_Gamit WHERE USERID = " + mod_system.POSuser.UserID;
        //    DataSet ds = LoadSQL(mySql, fillData);

        //    ds.Tables[fillData].Rows[0]["USERPASS"] = DeathCodez.Security.Encrypt(_password);
        //    SaveEntry(ds, false);
        //}

        //public void DeleteUser(bool Status)
        //{
        //    string mySql = "SELECT * FROM tbl_Gamit WHERE USERID = " + _userID;
        //    DataSet ds = LoadSQL(mySql, fillData);
        //    if (Status == true)
        //    {
        //        ds.Tables[fillData].Rows[0]["STATUS"] = "1";
        //    }
        //    else
        //    {
        //        ds.Tables[fillData].Rows[0]["STATUS"] = "0";
        //    }
        //    SaveEntry(ds, false);
        //    // End If
        //}

        //#endregion
    }
}
