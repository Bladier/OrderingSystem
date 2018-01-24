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
        string pin;
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
              string promptValue = ShowDialog("Enter Pin Code", "Confirmation");

              if (promptValue == "") { isCardValid = false; }
              if (promptValue.Length != 4)
              {
                  isCardValid = false;
                  goto Gohere;
              }
              if (promptValue != pin)
              {
                  isCardValid = false;
                  goto Gohere;
              }
              isCardValid = true;
          }
    Gohere:
          if (!isCardValid)
          {
              MessageBox.Show("Invalid Pin.", "Confirmation failed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            PrintReceipt(Convert.ToDouble(credits));
            search();
        }

        private void PrintReceipt(double Payment)
        {
            loadhistory lh = new loadhistory();

            string mysql = "SELECT * FROM TBLLOADHISTORY WHERE ID ='" + lh.LoadLastID() + "'";
            DataSet ds = Database.LoadSQL(mysql, "TBLLOADHISTORY");

            int idx = Convert.ToInt32(ds.Tables[0].Rows[0]["PassID"]);

            passenger ps = new passenger();
            ps.Loadpass(idx);

            Dictionary<string, string> rptPara = new Dictionary<string, string>();

            string LastTree= ps.RFIDnum.ToString().Substring(7, 3);

            string LastSeven = ps.RFIDnum.ToString().Substring(0, 7);
            LastSeven = LastSeven.Replace(LastSeven, "*******");

            frmReport frm = new frmReport();
            rptPara.Add("txtCardNumber", LastSeven + "" + LastTree);
            rptPara.Add("txtName", ps.Fname + " " + ps.Lname);
            rptPara.Add("txtPayment", Payment.ToString());
            frm.ReportInit(mysql, "dsReceipt", @"Report\rpt_Receipt.rdlc", rptPara);
            frm.Show();

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
            pin = Convert.ToString(p.Pincode);

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

        public static string ShowDialog(string text, string caption)
        {
            Font font = new Font("Times New Roman", 12.0f,
                        FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
  
            Form prompt = new Form();
            prompt.Width = 273;
            prompt.Height = 103;

            prompt.MaximumSize = new Size(273, 103);
            prompt.MinimumSize = new Size(273, 103);
            prompt.MaximizeBox = false;
            prompt.MinimizeBox = false;
            prompt.Text = caption;
            TextBox inputBox = new TextBox() { Left = 12, Top = 10, Width = 239 };
            Button confirmation = new Button() { Text = "Confirm", Left = 176, Width = 75, Top = 40 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            
            prompt.Controls.Add(inputBox);
            inputBox.Font = font;
            inputBox.UseSystemPasswordChar = true;
            prompt.ShowDialog();
            inputBox.Focus();
            return (string)Convert.ToString(inputBox.Text);
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

            bool isCardValid = false;
            while (isCardValid == false)
            {
                string promptValue = ShowDialog("Enter Pin Code", "Confirmation");

                if (promptValue == "") { isCardValid = false; }
                if (promptValue.Length != 4)
                {
                    isCardValid = false;
                    goto Gohere;
                }
                if (promptValue != pin)
                {
                    isCardValid = false;
                    goto Gohere;
                }
                isCardValid = true;
            }
        Gohere:
            if (!isCardValid)
            {
                MessageBox.Show("Invalid Pin.", "Confirmation failed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void frmLoading_Load(object sender, EventArgs e)
        {

        }

   
    }
}
