using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OrderingSystems.Module
{
    public partial class frmProductList : Form
    {
        public frmProductList()
        {
            InitializeComponent();
        }

        private void frmProductList_Load(object sender, EventArgs e)
        {

        }

        private void LoadMenu(string mysql = "SELECT * FROM TBLMENU WHERE STATUS = 1 ORDER BY ID ASC")
        {
            DataSet ds = Database.LoadSQL(mysql, "tblMenu");

        }

       
       // privte void addMenu(
     
    }
}
