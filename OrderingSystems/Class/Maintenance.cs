using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace OrderingSystems
{
    class Maintenance
    {
        #region Properties
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _Mkey;
        public string MaintenanceKey
        {
            get { return _Mkey; }
            set { _Mkey = value; }
        }

        private string _MValue;
        public string MaintenanceValue
        {
            get { return _MValue; }
            set { _MValue = value; }
        }

        private string _remarks;
        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }
        #endregion

        #region Procedures
        internal void SaveMaintenance()
        {
            string mysql = "Select * From tblMaintenance Where ID = "+ _id ;
            DataSet ds = Database.LoadSQL(mysql, "tblMaintenance");

            if (ds.Tables[0].Rows.Count == 0)
            {
                DataRow dsNewRow = null;
                dsNewRow = ds.Tables[0].NewRow();
                var with = dsNewRow;
                with["M_Key"] = _Mkey;
                with["M_Value"] = _MValue ;
                with["Remarks"] = _remarks ;
                ds.Tables[0].Rows.Add(dsNewRow);
                Database.SaveEntry(ds, true);

            }
            else
            {
                var with = ds.Tables[0].Rows[0];
                with["M_Key"] = _Mkey;
                with["M_Value"] = _MValue;
                with["Remarks"] = _remarks;
                Database.SaveEntry(ds, false);
            }
        }

        internal void LoadMaintenance()
        {
            string mysql = "Select * From tblMaintenance Where ID = " + _id ;
            DataSet ds = Database.LoadSQL(mysql, "tblMaintenance");

            foreach (DataRow dr in ds.Tables[0].Rows )
            {
                LoadByRows(dr);
            }
            
        }

        private void LoadByRows(DataRow dr)
        {
            _id = Convert.ToInt32(dr["ID"].ToString());
            _Mkey = dr["M_Key"].ToString();
            _MValue = dr["M_Value"].ToString();
            _remarks = dr["Remarks"].ToString();
 
        }

        internal string GetValue(string key)
        {
            string mysql = "Select * From tblMaintenance Where M_Key = '" + key +"'";
            DataSet ds = Database.LoadSQL(mysql, "tblMaintenance");

            return ds.Tables[0].Rows[0]["M_Value"].ToString();
        }

        internal void UpdateOption(string key, string val)
        {
            string mysql = "Select * From tblMaintenance Where M_Key = '"+ key +"'";
            DataSet ds = Database.LoadSQL(mysql, "tblMaintenance");

            var with = ds.Tables[0].Rows[0];
            with["M_Value"] = val;
            Database.SaveEntry(ds, false);
        }

        #endregion
    }
}
