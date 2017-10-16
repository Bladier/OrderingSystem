using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data;
namespace OrderingSystems
{
    class Mod
    {
        public bool isEnter(KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13) 
            {
                return true;
            }

            return false;
        }

        public string GetOption(string str)
        {
            string mysql = "Select * From tblMaintenance Where M_Key = '"+ str +"'";
            DataSet ds = Database.LoadSQL(mysql, "tblMaintenance");

            return ds.Tables[0].Rows[0]["M_Value"].ToString();
        }
    }
}
