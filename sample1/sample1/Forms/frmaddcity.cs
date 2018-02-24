using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sample1
{
    public partial class frmaddcity : Form
    {
        int idx = 0;
        public frmaddcity()
        {
            InitializeComponent();
        }

        private void frmaddcity_Load(object sender, EventArgs e)
        {
            cboCity.Items.AddRange(GetDistinct("City"));
        }

        private void LoadCity(int idx)
        {
            string mysql = "select * from barangaytbl where cityID ="+idx;
            DataSet ds = Database.LoadSQL(mysql, "barangaytbl");

            lvBarangay.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListViewItem lv = lvBarangay.Items.Add(dr["barangay"].ToString());
                lv.Tag = dr["ID"].ToString();
            }
        }


        private string[] GetDistinct(string col)
        {
            string mySql = "SELECT DISTINCT " + col + " FROM citytbl WHERE " + col + " <> ''";
            DataSet ds = Database.LoadSQL(mySql);

            int MaxCount = ds.Tables[0].Rows.Count;
            string[] str = new string[MaxCount];
            string tmpStr;

            for (int cnt = 0; cnt <= MaxCount - 1; cnt++)
            {
                tmpStr = ds.Tables[0].Rows[cnt][col].ToString();
                str[cnt] = tmpStr;
            }

            return str;
        }

        private void cboCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCity.Text == "") { return; }
            loadbyrowCity();

        }

        private void loadbyrowCity()
        {
            string mysql = "select * from citytbl where city ='" + cboCity.Text + "'";
            DataSet ds = Database.LoadSQL(mysql, "citytbl");

            idx = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
            LoadCity(idx);
        }

        private void lvBarangay_DoubleClick(object sender, EventArgs e)
        {
            if (lvBarangay.SelectedItems.Count == 0) { return; }

            txtbarangay.Text = lvBarangay.SelectedItems[0].Text;
            btnadd.Text = "&-";
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txtbarangay.Text == "") { return; }

            if (btnadd.Text == "&-")
            {
                lvBarangay.SelectedItems[0].Text = txtbarangay.Text;
            }
            else
            {
                ListViewItem lv = lvBarangay.Items.Add(txtbarangay.Text);
            }

            txtbarangay.Clear();
            btnadd.Text = "&+";
        }
    }
}
