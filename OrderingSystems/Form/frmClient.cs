using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OrderingSystems
{
    public partial class frmCleint : Form
    {
        public frmCleint()
        {
            InitializeComponent();
        }

        private void btnClearOrder_Click(object sender, EventArgs e)
        {
            lvOrderList.Items.Clear();
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            ClearText();
        }

        private void ClearText()
        {
            lvDisplay.Items.Clear();
            lvOrderList.Items.Clear();
        }

        private void AddItemDisplay(DataRow dr)
        {
            ListViewItem lv = lvDisplay.Items.Add(dr["MenuType"].ToString());
             lv.SubItems.Add(dr["MenuSize"].ToString());
             lv.SubItems.Add(dr["Price"].ToString());
             lv.Tag = dr["MenuName"].ToString();
        }

        private void AddItemOrder(DataRow dr)
        {
            ListViewItem lv = lvOrderList.Items.Add(dr["MenuType"].ToString());
            lv.SubItems.Add(dr["MenuSize"].ToString());
            lv.SubItems.Add(dr["Price"].ToString());
            lv.Tag = dr["MenuName"].ToString();
        }

        private void btnSoftDrink_Click(object sender, EventArgs e)
        {
            string mysql = "Select * From tblMenu Where MenuName = 'Softdrinks'";
            DataSet ds =Database.LoadSQL(mysql, "tblMenu");

            lvDisplay.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                AddItemDisplay(dr);
            }

        }

        private void btnPizza_Click(object sender, EventArgs e)
        {
            string mysql = "Select * From tblMenu Where MenuName = 'Pizza'";
            DataSet ds = Database.LoadSQL(mysql, "tblMenu");

            lvDisplay.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                AddItemDisplay(dr);
            }
        }

        private void btnPasta_Click(object sender, EventArgs e)
        {
            string mysql = "Select * From tblMenu Where MenuName = 'Pasta'";
            DataSet ds = Database.LoadSQL(mysql, "tblMenu");

            lvDisplay.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                AddItemDisplay(dr);
            }
        }

        private void btnBurger_Click(object sender, EventArgs e)
        {
            string mysql = "Select * From tblMenu Where MenuName = 'Burger'";
            DataSet ds = Database.LoadSQL(mysql, "tblMenu");

            lvDisplay.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                AddItemDisplay(dr);
            }
        }

        private void btnHaloHalo_Click(object sender, EventArgs e)
        {
            string mysql = "Select * From tblMenu Where MenuName = 'Halo- Halo'";
            DataSet ds = Database.LoadSQL(mysql, "tblMenu");

            lvDisplay.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                AddItemDisplay(dr);
            }
        }

        private void btnPick_Click(object sender, EventArgs e)
        {
            if (lvDisplay.SelectedItems.Count < 1){return;}
           // MessageBox.Show( lvDisplay.FocusedItem.Text);


            if (lvDisplay.SelectedItems.Count < 1) { return; }

            int idx = Convert.ToInt32(lvDisplay.FocusedItem.Tag.ToString());

            string tmpQty = Microsoft.VisualBasic.Interaction.InputBox("Enter Qty", "Order", "");

            MenuItem tmpMenu = new MenuItem();
            tmpMenu.ID = idx;
            tmpMenu.LoadMenuItem();
            tmpMenu.Qty = 1;
            AddItemOrder(tmpMenu);
        }

        private void AddItemOrder(MenuItem tmpItem)
        {
            ListViewItem lv = lvOrderList.Items.Add(tmpItem.MenuName);
            lv.SubItems.Add(tmpItem.MenuType);
            lv.SubItems.Add(tmpItem.MenuSize);
            double tmpPrice = Convert.ToDouble(tmpItem.Price.ToString());
            lv.SubItems.Add(tmpItem.Price.ToString());
            lv.SubItems.Add(tmpItem.Qty.ToString());
            lv.Tag = tmpItem.ID;
        }
        private void lvDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
