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

namespace OrderingSystems
{
	static class DB
	{

        public static MySqlConnection con;
        public static MySqlConnection ReaderCon;
        //Final
        static internal string dbName = "IH@CYOU.FDB";
        static internal string fbUser = "SYSDBA";
        static internal string fbPass = "masterkey";
        static internal DataSet fbDataSet = new DataSet();

        static internal string conStr = string.Empty;
     
        //verification if the database is connected.
        private static string[] language = { "Connection error failed." };
        /// <summary>
        /// This method shows the connection string of a database.
        /// Also here we open the database.
        /// </summary>
        /// <remarks></remarks>
        public static void dbOpen()
        {
            conStr =  ("Server=localhost;Database=ih@ckyou;UID=root;Password=");

            con = new MySqlConnection(conStr);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                con.Dispose();
                MessageBox.Show(language[0] + ex.Message.ToString());
                return;
            }
        }


        public static void dbClose()
        {
            con.Close();
        }

        static internal bool isReady()
        {
            bool ready = false;
            try
            {
                dbOpen();
                ready = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERROR] " + ex.Message.ToString());
                return false;
            }

            return ready;
        }

        static internal bool SaveEntry(DataSet dsEntry, bool isNew = true)
        {
            if (dsEntry == null)
            {
                return false;
            }

            dbOpen();

            MySqlDataAdapter da = null;
            DataSet ds = new DataSet();
            string mySql = null;
            string fillData = null;
            ds = dsEntry;

            //Save all tables in the dataset
            foreach (DataTable dsTable in dsEntry.Tables)
            {
                fillData = dsTable.TableName;
                mySql = "SELECT * FROM " + fillData;
                if (!isNew)
                {
                    string colName = dsTable.Columns[0].ColumnName;
                    int idx =Convert.ToInt32(dsTable.Rows[0][0]);
                     mySql += string.Format(" WHERE {0} = {1}", colName, idx);
                    Console.WriteLine("ModifySQL: " + mySql);
                }

                da = new MySqlDataAdapter(mySql, con);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                //Required in Saving/Update to Database
                da.Update(ds, fillData);
            }

            dbClose();
            return true;
        }


        static internal void SQLCommand(string sql)
        {
           // conStr = "DRIVER=Firebird/InterBase(r) driver;User=" + fbUser + ";Password=" + fbPass + ";Database=" + dbName + ";";
            conStr = "SERVER=localhost;" +
                            "DATABASE=IH@CYOU;" +
                            "UID=root;" +
                            "PASSWORD=;";
            con = new MySqlConnection(conStr);

            MySqlCommand cmd = null;
            cmd = new MySqlCommand(sql, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Dispose();
                return;
            }

            System.Threading.Thread.Sleep(1000);
        }



        static internal DataSet LoadSQL(string mySql, string tblName = "QuickSQL")
        {
            dbOpen();
            //open the database.

            MySqlDataAdapter da = null;
            DataSet ds = new DataSet();
            string fillData = tblName;
            try
            {
                da = new MySqlDataAdapter(mySql, con);
                da.Fill(ds, fillData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(">>>>>" + mySql);
                MessageBox.Show(ex.ToString());
                ds = null;
            }

            dbClose();

            return ds;
        }



	}
}

