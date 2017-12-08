using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace BTMS
{
    public partial class frmLoading : Form
    {
        int passID;
        string credits;
        public frmLoading()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtCardNum.Text == "") { return; }

            bool retNum = false;

            while (retNum == false)
            {
                credits = Interaction.InputBox("Enter amount", "Amount", "");
                if (credits == "") { return; }
                if (credits == "0") { return; }
                retNum = Information.IsNumeric(credits);

                if (retNum == true)
                {
                    if (Convert.ToDouble(credits) < 0) { return; }
                }

                double tmpcredit = Convert.ToDouble(credits);
                if (tmpcredit < 200)
                {
                    MessageBox.Show("The MINIMUM load is 200.?", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }

          bool isCardValid=false;
          while (isCardValid == false)
          {
              string confirmation = Interaction.InputBox("Enter Card Number", "Confirmation", "");

              if (confirmation == "") { isCardValid = false; }
              if (confirmation.Length != 10)
              {
                  isCardValid = false;
                  goto Gohere;
              }
              if (confirmation != txtCardNum.Text)
              {
                  isCardValid = false;
                  goto Gohere;
              }
              isCardValid = true;
          }
    Gohere:
          if (!isCardValid)
          {
              MessageBox.Show("Invalid card number, Please try again.", "Confirmation failed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              return;
          }
            
            DialogResult result = MessageBox.Show("Are you sure about this?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            Credit c = new Credit();
            c.PID = passID;
            c.Refund(Convert.ToDouble(credits));

            loadhistory lh = new loadhistory();
            lh.PID = passID;
            lh.PassMoneyAdd = Convert.ToDouble(credits);
            lh.SaveLoadHist();

            MessageBox.Show("Successfully loaded.", "Information", MessageBoxButtons.OK);
            search();
        }

        private void txtCardNum_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            if (txtCardNum.Text == "") { txtCredit.Clear(); txtname.Clear(); return; }
            if (txtCardNum.Text.Length != 10) { return; }

            string mysql = "SELECT * FROM tblpassenger WHERE RFIDNUM = '" + txtCardNum.Text + "'";
            DataSet ds = Database.LoadSQL(mysql, "tblpassenger");

            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Card number found.", "Search", MessageBoxButtons.OK);
                return;
            }

            passenger p = new passenger();
            p.LoadpassbyCard(txtCardNum.Text);
            txtname.Text = p.Fname + " " + p.Lname;
            passID = p.ID;

            Credit c = new Credit();

            if (!c.LoginUser(p.ID))
            {
                txtCredit.Text = "0";
                return;
            }

            c.LoadCredit(p.ID);
            txtCredit.Text = c.passMoney.ToString();

            LoadHistory(p.ID);

        }

        private void txtCardNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            mod_system.DigitOnly(e);
        }

        private void LoadHistory(int PID)
        {
            string mysql = "SELECT * FROM TBLLOADHISTORY WHERE PASSID ='" + PID + "' and status <> 0 ORDER BY LOAdDATE DESC";
            DataSet ds = Database.LoadSQL(mysql, "TBLLOADHISTORY");

            if (ds.Tables[0].Rows.Count == 0) { lvloadHist.Items.Clear(); return; }
            lvloadHist.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListViewItem lv = lvloadHist.Items.Add(txtname.Text);
                lv.SubItems.Add(Convert.ToDateTime(dr["Loaddate"].ToString()).ToShortDateString());
                lv.SubItems.Add(dr["loadcredit"].ToString());
                lv.SubItems.Add(dr["PASSID"].ToString());
                lv.Tag = dr["ID"];
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do want to cancel?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            passID = 0;
             credits = "";
             lvloadHist.Items.Clear();
             txtname.Clear();
             txtCardNum.Clear();
             txtCredit.Clear();

        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (lvloadHist.SelectedItems.Count == 0)
            {
                return;
            }

            DialogResult result = MessageBox.Show("Do you want to void this payment?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            //Void status will be 0
            loadhistory lh = new loadhistory();
            double tmploadCredit = Convert.ToDouble(lvloadHist.SelectedItems[0].SubItems[2].Text);
            int ID =Convert.ToInt32(lvloadHist.SelectedItems[0].Tag);
            int passenger = Convert.ToInt32(lvloadHist.SelectedItems[0].SubItems[3].Text);

            lh.UpdateLoadHistory(tmploadCredit, ID);

            //Deduct to credits
            Credit c = new Credit();
            c.UpdateCredit(tmploadCredit,passenger);

            MessageBox.Show("Successfully Voided", "Voiding", MessageBoxButtons.OK);
            LoadHistory(passenger);
        }
    }
}
