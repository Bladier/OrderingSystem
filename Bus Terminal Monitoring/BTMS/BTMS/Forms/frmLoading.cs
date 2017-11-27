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
            }
            
            DialogResult result = MessageBox.Show("Are you sure about this?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            Credit c = new Credit();
            c.PID = passID;
            c.Refund(Convert.ToDouble(credits));
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

            Credit c = new Credit();
            c.LoadCredit(p.ID);
            txtCredit.Text = c.passMoney.ToString();
            passID = p.ID;
        }

        private void txtCardNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            mod_system.DigitOnly(e);
        }
    }
}
