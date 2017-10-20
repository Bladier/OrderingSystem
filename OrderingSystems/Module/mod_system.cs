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
   class mod_system
  {
      #region "Global Variables"
      public static bool DEV_MODE = true;
	public static bool PROTOTYPE = false;
	public static bool ADS_ESKIE = false;

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
