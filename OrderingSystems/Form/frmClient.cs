using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace OrderingSystems
{
    public partial class frmClient : Form
    {
        string tmpQty ;
        public frmClient()
        {
            InitializeComponent();
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
             lv.Tag = dr["ID"].ToString();
        }

        private void AddItemOrder(User tmpItem)
        {
            ListViewItem lv = lvOrderList.Items.Add(tmpItem.MenuName);
            lv.SubItems.Add(tmpItem.MenuType);
            lv.SubItems.Add(tmpItem.MenuSize);
            double tmpPrice = Convert.ToDouble(tmpItem.Price.ToString());
            lv.SubItems.Add(tmpItem.Price.ToString());
            lv.SubItems.Add(tmpItem.Qty.ToString());
            lv.Tag = tmpItem.ID ;
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

            int idx = Convert.ToInt32(lvDisplay.FocusedItem.Tag.ToString());
            bool retNum = false;
            
            while (retNum == false)
            {
                tmpQty = Interaction.InputBox("Enter Qty", "Order", "");
                if (tmpQty == "") { return; }
                if (tmpQty == "0") { return; }
                if (Convert.ToInt32(tmpQty) < 0) { return; }
                retNum = Information.IsNumeric(tmpQty);
                
            }
           
            User tmpMenu = new User();
            tmpMenu.ID = idx;
            tmpMenu.LoadMenuItem();
            tmpMenu.Qty = Convert.ToInt32(tmpQty);
            AddItemOrder(tmpMenu);
        }

        private void btnClearOrder_Click(object sender, EventArgs e)
        {
            lvOrderList.Items.Clear();
        }

        private void lvOrderList_KeyDown(object sender, KeyEventArgs e)
        {
            if (lvOrderList.SelectedItems.Count == 0) { return; }
            int idx = lvOrderList.FocusedItem.Index;
            if (e.KeyCode == Keys.Delete)
            {
                DialogResult DeleteResult = MessageBox.Show("Do you want to delete this?", "Information", MessageBoxButtons.YesNo);
                if (DeleteResult == DialogResult.No) { return; }

                lvOrderList.Items[idx].Remove();
            }
           
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {

        }

    }
}
