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
using System.Data.SqlClient;



namespace sample1
{
	static class Database
	{
          public static SqlConnection con;
        public static SqlConnection ReaderCon;
        static internal string dbName = "rf";
        static internal string uid = "root";
        static internal string fbPass = "";
        static internal string server = "localhost";
        static internal DataSet fbDataSet = new DataSet();

        static internal string conStr = string.Empty;

     
     
        /// <summary>
        /// This method shows the connection string of a database.
        /// Also here we open the database.
        /// </summary>
        /// <remarks></remarks>
        public static void dbOpen()
        {
            conStr = "Data Source=MISGWAPOHON-PC;Initial Catalog=TH;Integrated Security=True";

            con = new SqlConnection(conStr);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                con.Dispose();
                return;
            }
        }

        /// <summary>
        /// This method is for closing after database was open here is the close.
        /// </summary>
        /// <remarks></remarks>
        public static void dbClose()
        {
            con.Close();
        }
        /// <summary>
        /// The database is ready to open.
        /// </summary>
        /// <returns>return false if the database is not ready.</returns>
        /// <remarks></remarks>
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

        /// <summary>
        /// Module 001
        /// Save the Dataset to the database
        /// </summary>
        /// <param name="dsEntry">Database with Table Name as Database Table Name</param>
        /// <returns>Boolean: Success Result</returns>
        /// <remarks></remarks>
        static internal bool SaveEntry(DataSet dsEntry, bool isNew = true)
        {

            if (dsEntry == null)
            {
                return false;
            }

            dbOpen();

            SqlDataAdapter da = null;
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
                    int idx = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    mySql += string.Format(" WHERE {0} = {1}", colName, idx);

                    Console.WriteLine("ModifySQL: " + mySql);
                }
                
                da = new SqlDataAdapter(mySql, con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                //Required in Saving/Update to Database
                da.Update(ds, fillData);
            }

            dbClose();
            return true;
        }
        
        static internal void SQLCommand(string sql)
        {
            conStr = "SERVER=" + server + ";" + "DATABASE=" +
         dbName + ";" + "UID=" + uid + ";" + "PASSWORD=" + fbPass + ";";
            con = new SqlConnection(conStr);

            SqlCommand cmd = null;
            cmd = new SqlCommand(sql, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                //Interaction.MsgBox(ex.ToString(), MsgBoxStyle.Critical);
                //Log_Report(string.Format("[{0}] - ", sql) + ex.ToString());
                con.Dispose();
                return;
            }

            System.Threading.Thread.Sleep(1000);
        }


        /// <summary>
        ///This function where the table load to dataset.
        /// </summary>
        /// <param name="mySql">mysql where the data pass by.</param>
        /// <param name="tblName">tblName here is a variable that hold the data.</param>
        /// <returns>return ds after reading the mysql data.</returns>
        /// <remarks></remarks>
        static internal DataSet LoadSQL(string mySql, string tblName = "QuickSQL")
        {
            dbOpen();
            //open the database.

            SqlDataAdapter da = null;
            DataSet ds = new DataSet();
            string fillData = tblName;
            try
            {
                da = new SqlDataAdapter(mySql, con);
                da.Fill(ds, fillData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(">>>>>" + mySql);
                // MessageBox.show(ex.ToString());
                // Log_Report("LoadSQL - " + ex.ToString());
                ds = null;
            }

            dbClose();

            return ds;
        }

        /// <summary>
        /// This function is the declaration of odbccommand and odbcdatareader.
        /// </summary>
        /// <param name="mySql">mysql where the data pass</param>
        /// <returns></returns>
        /// <remarks></remarks>
        static internal SqlDataReader LoadSQL_byDataReader(string mySql)
        {
            SqlCommand myCom = new SqlCommand(mySql, ReaderCon);
            SqlDataReader reader = myCom.ExecuteReader();
            
            return reader;
        }
        /// <summary>
        /// The conStr here a variable that hold the connectionstring of the database.
        /// </summary>
        /// <remarks></remarks>
        public static void dbReaderOpen()
        {
            conStr = "Data Source=MISGWAPOHON-PC;Initial Catalog=TH;Integrated Security=True";

            ReaderCon = new SqlConnection(conStr);
            try
            {
                ReaderCon.Open();
                //open the database.
            }
            catch (Exception ex)
            {
                ReaderCon.Dispose();
                MessageBox.Show(ex.Message);
                // Log_Report(ex.Message.ToString());
                return;
            }
        }
        /// <summary>
        /// close the database.
        /// </summary>
        /// <remarks></remarks>
        public static void dbReaderClose()
        {
            ReaderCon.Close();
        }

        
       
	}
}
