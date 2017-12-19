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
   class mod_system
  {
      #region "Global Variables"
      public static bool DEV_MODE = true;
	public static bool PROTOTYPE = false;
	public static bool ADS_ESKIE = false;

    public static bool isAddBus = false;

	public static bool ADS_SHOW = false;
    public static System.DateTime CurrentDate = DateAndTime.Now;

    public static User ORuser = new User();
    public static int UserID = ORuser.ID;
	
	static internal bool isAuthorized = false;

	public static string backupPath = ".";
       
	static internal int dailyID = 1;
	static internal string DBVERSION = "";
      #endregion

      #region "Functions"
    static internal object DigitOnly(System.Windows.Forms.KeyPressEventArgs e, bool isWhole = false)
    {
        Console.WriteLine("char: " + e.KeyChar + " -" + char.IsDigit(e.KeyChar));
        if (e.KeyChar != ControlChars.Back)
        {
            if (isWhole)
            {
                e.Handled = !(char.IsDigit(e.KeyChar));
            }
            else
            {
                e.Handled = !(char.IsDigit(e.KeyChar));
            }

        }

        return !(char.IsDigit(e.KeyChar));
    }

    static internal bool checkNumeric(TextBox txt)
    {
        if (Information.IsNumeric(txt.Text))
        {
            return true;
        }

        return false;
    }

    static internal string DreadKnight(string str, string special = null)
    {
        str = str.Replace("'", "''");
        str = str.Replace("\"", "\"\"");

        if (special != null)
        {
            str = str.Replace(special, "");
        }

        return str;
    }

    static internal bool isEnter(KeyPressEventArgs e)
    {
        if (Strings.Asc(e.KeyChar) == 13)
        {
            return true;
        }
        return false;
    }

       //public static void LoadCurrentDate()
       //{
       //    string mysql = "SELECT * FROM TBLDAILY WHERE Status = '1'";
       //    DataSet ds = Database.LoadSQL(mysql, "TBLDAILY");

       //    if (ds.Tables[0].Rows.Count == 1)
       //    {
       //        CurrentDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["CurrentDate"]);
       //        frmMain.dateSet = true;
       //    }
       //    else
       //    {
       //        frmMain.dateSet = false;
       //    }
       //}

       public static void OpenDate()
       {
           DialogResult result = MessageBox.Show("Are you sure to set this date?", "Confirmation", MessageBoxButtons.YesNo);
           if (result == DialogResult.No)
           {
               return;
           }

           string tmpcur;
           CurrentDate = Convert.ToDateTime(mod_system.CurrentDate.ToShortDateString());
           tmpcur = CurrentDate.ToString("yyyy-MM-dd");

           string mysql = "SELECT * FROM TBLDAILY WHERE currentDate = '" + tmpcur + "'";
           DataSet ds = Database.LoadSQL(mysql, "TBLDAILY");

           if (ds.Tables[0].Rows.Count == 1) 
           {
               if (Convert.ToInt32(ds.Tables[0].Rows[0]["status"]) == 0)
               {
                   MessageBox.Show("You cannot select to open a previous date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
               else
               {
                   MessageBox.Show("Error in openning date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
               return;
           }


           DataRow dsNewRow = null;
           dsNewRow = ds.Tables[0].NewRow();
           var _with2 = dsNewRow;
           _with2["CurrentDate"] = CurrentDate.ToShortDateString();
           _with2["Status"] = 1;
           ds.Tables[0].Rows.Add(dsNewRow);
           Database.SaveEntry(ds);

           Console.WriteLine("successfully open.");
         //  frmMain.dateSet = true;
           return;
       }

       public static void CloseDate()
       {
           string mysql = "SELECT * FROM TBLDAILY ";
           mysql += string.Format(" WHERE currentDate = '{0}'", CurrentDate.ToString("yyyy-MM-dd"));
           DataSet ds = Database.LoadSQL(mysql, "TBLDAILY");

           if (ds.Tables[0].Rows.Count == 1)
           {
               {
                   var _with2 = ds.Tables["TBLDAILY"].Rows[0];
                   _with2["Status"] = 0;
                   Database.SaveEntry(ds, false);
               }
               MessageBox.Show("Date has been closed. Thank you. . .", "Closing", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
           else
           {
               MessageBox.Show("Error in closing date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }


       static internal int GetCurrentAge(System.DateTime dob)
       {
           int age = 0;
           age = DateAndTime.Today.Year - dob.Year;
           if ((dob > DateAndTime.Today.AddYears(-age)))
               age -= 1;
           return age;
       }

       static internal bool isSetDate()
       {
           string mysql = "SELECT * FROM TBLDAILY WHERE STATUS = '1'";
           DataSet ds = Database.LoadSQL(mysql, "TBLDAILY");

           if (ds.Tables[0].Rows.Count > 0)
           {
               return true;
           }

           return false;
       }

       static internal System.DateTime GetFirstDate(System.DateTime curDate)
       {
           dynamic firstDay = DateAndTime.DateSerial(curDate.Year, curDate.Month, 1);
           return firstDay;
       }

       static internal System.DateTime GetLastDate(System.DateTime curDate)
       {
           DateTime original = curDate;
           // The date you want to get the last day of the month for
           DateTime lastOfMonth = original.Date.AddDays(-(original.Day - 1)).AddMonths(1).AddDays(-1);

           return lastOfMonth;
       }

      #endregion
  }
}
