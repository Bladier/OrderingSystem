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

  
        string tmpQty ;
        public frmClient()
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
           
            MenuItem tmpMenu = new MenuItem();
            tmpMenu.ID = idx;
            tmpMenu.LoadMenuItem();
            tmpMenu.Qty = Convert.ToInt32(tmpQty);
            AddItemOrder(tmpMenu);

        }

        private void lvDisplay_SelectedIndexChanged(object sender, EventArgs e)
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


        }

        private void btnOrder_Click(object sender, EventArgs e)
        {

        }

    }
}
