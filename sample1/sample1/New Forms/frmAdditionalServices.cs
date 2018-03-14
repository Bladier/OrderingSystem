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
    public partial class frmAdditionalServices : Form
    {
        public string str = "";
        public bool isBooking;
        public frmAdditionalServices(string st,bool isBook=true)
        {
            InitializeComponent();
            str = st;
            isBooking = isBook;
        }

        private void frmAdditionalServices_Load(object sender, EventArgs e)
        {
            txtSearch.Text = str;
            if (txtSearch.Text!="")
            {
                string mysql = "select * from addservicestbl where status<>0  and description like '%" + txtSearch.Text + "%'";
               loadservices(mysql);
            }
            else
            {
                loadservices();
            }
  
        }

        private void loadservices(string mysql ="select * from addservicestbl where status<>0")
        {
            DataSet ds = Database.LoadSQL(mysql,"addservicestbl");
            if (ds.Tables[0].Rows.Count==0)
            {
               lvServices.Items.Clear(); return;
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListViewItem lv =lvServices.Items.Add(dr["description"].ToString());
                lv.SubItems.Add(dr["fee"].ToString());

                lv.Tag = dr["id"].ToString();
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e))
            {
                btnSearch.PerformClick();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                string mysql = "select * from addservicestbl where status<>0  and description like '%" + txtSearch.Text + "%'";
                loadservices(mysql);
            }
            else
            {
                loadservices();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lvServices.SelectedItems.Count == 0)
            {
                return;
            }

            if (isBooking)
            {
                if (Application.OpenForms["frmbookingv2"] != null)
                {
                    (Application.OpenForms["frmbookingv2"] as frmbookingv2).loadservices(Convert.ToInt32(lvServices.SelectedItems[0].Tag));
                    this.Close();
                }
                else
                {
                    frmbookingv2 frm = new frmbookingv2();
                    frm.ShowDialog();

                }
            }
            else
            {
                if (Application.OpenForms["frmReservationV2"] != null)
                {
                    (Application.OpenForms["frmReservationV2"] as frmReservationV2).loadservices(Convert.ToInt32(lvServices.SelectedItems[0].Tag));
                    this.Close();
                }
                else
                {
                    frmReservationV2 frm = new frmReservationV2();
                    frm.ShowDialog();

                }
            }

           
        }
    }
}
