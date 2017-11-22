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
    public partial class Form1 :Form
    {
        int pID;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "&Modify")
            {
                btnSave.Text = "&Update";
                Disbled(true);
                return;
            }
            if (btnSave.Text == "&Save")
            {
                sp();
            }
            else
            {
                updatePass();
            }
        }

        private void sp()
        {
            if (txtFname.Text == "")
            {
                txtFname.Focus();
                return;
            }
            if (txtLname.Text == "")
            {
                txtLname.Focus();
                return;
            }
            if (cboPassTyp.Text == "")
            {
                cboPassTyp.Focus();
                return;
            }

            if (cboPassTyp.Text == "Senior")
            {
                if (txtIDNum.Text == "")
                {
                    txtIDNum.Focus();
                    return;
                }
            }

            if (cboPassTyp.Text == "Student")
            {
                if (txtIDNum.Text == "")
                {
                    txtIDNum.Focus();
                    return;
                }
            }

            if (cboStreet.Text == "")
            {
                cboStreet.Focus();
                return;
            }

            if (cboBrgy.Text == "")
            {
                cboBrgy.Focus();
                return;
            }

            if (cboCity.Text == "")
            {
                cboCity.Focus();
                return;
            }

            if (cboProvince.Text == "")
            {
                cboProvince.Focus();
                return;
            }

            if (txtCardNum.Text == "") { txtCardNum.Focus(); return; }
            if (txtCardNum.Text.Length != 10) { MessageBox.Show("Invalid card number.", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error); return; }

            passenger savepass = new passenger();
            if (!savepass.IsCardNumExists(txtCardNum.Text))
            {
                 MessageBox.Show("Card Number Already Exists.", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error); return; 
            }

            DialogResult result = MessageBox.Show("Do you want to save this client?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            savepass.RFIDnum = Convert.ToUInt32(txtCardNum.Text);
            savepass.Fname = txtFname.Text;
            savepass.Mname = txtMname.Text;
            savepass.Lname = txtLname.Text;
            savepass.BDay = Convert.ToDateTime(txtBday.Text);
            savepass.ContactNum = Convert.ToUInt64(txtContactNum.Text);
            savepass.PassType = cboPassTyp.Text;
            savepass.Street = cboStreet.Text;
            savepass.Brgy = cboBrgy.Text;
            savepass.City = cboCity.Text;
            savepass.Province = cboProvince.Text;
            savepass.IdType = txtIDType.Text;
            savepass.IDNum = txtIDNum.Text;
            savepass.CardExp = Convert.ToDateTime(txtCardExpiration.Text);

            savepass.Savepassenger();

            MessageBox.Show("Successfully saved.", "Confirmation", MessageBoxButtons.OK);
            clearfield();
        }


        private void updatePass()
        {
            if (txtFname.Text == "")
            {
                txtFname.Focus();
                return;
            }
            if (txtLname.Text == "")
            {
                txtLname.Focus();
                return;
            }
            if (cboPassTyp.Text == "")
            {
                cboPassTyp.Focus();
                return;
            }

            if (cboPassTyp.Text == "Senior")
            {
                if (txtIDNum.Text == "")
                {
                    txtIDNum.Focus();
                    return;
                }
            }

            if (cboPassTyp.Text == "Student")
            {
                if (txtIDNum.Text == "")
                {
                    txtIDNum.Focus();
                    return;
                }
            }

            if (cboStreet.Text == "")
            {
                cboStreet.Focus();
                return;
            }

            if (cboBrgy.Text == "")
            {
                cboBrgy.Focus();
                return;
            }

            if (cboCity.Text == "")
            {
                cboCity.Focus();
                return;
            }

            if (cboProvince.Text == "")
            {
                cboProvince.Focus();
                return;
            }

            if (txtCardNum.Text == "") { txtCardNum.Focus(); return; }

            DialogResult result = MessageBox.Show("Do you want to Update this client?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            passenger savepass = new passenger();

            savepass.ID = pID;
            savepass.RFIDnum = Convert.ToUInt32(txtCardNum.Text);
            savepass.Fname = txtFname.Text;
            savepass.Mname = txtMname.Text;
            savepass.Lname = txtLname.Text;
            savepass.BDay = Convert.ToDateTime(txtBday.Text);
            savepass.ContactNum = Convert.ToUInt64(txtContactNum.Text);
            savepass.PassType = cboPassTyp.Text;
            savepass.Street = cboStreet.Text;
            savepass.Brgy = cboBrgy.Text;
            savepass.City = cboCity.Text;
            savepass.Province = cboProvince.Text;
            savepass.IdType = txtIDType.Text;
            savepass.IDNum = txtIDNum.Text;
            savepass.CardExp = Convert.ToDateTime(txtCardExpiration.Text);

            savepass.Update();

            MessageBox.Show("Successfully Updated.", "Confirmation", MessageBoxButtons.OK);
            clearfield();
        }

        private void clearfield()
        {
            txtFname.Text="";
            txtMname.Text="";
            txtLname.Text="";
            txtBday.Value = DateAndTime.Now;
            txtContactNum.Text = "";
            cboBrgy.Text = "";
            cboStreet.Text = "";
            cboCity.Text = "";
            cboProvince.Text = "";
            txtCardNum.Text = "";
            txtIDNum.Text = "";
            txtIDType.Text = "";
            cboPassTyp.Focus();
            btnSave.Text = "&Update";
            pID = 0;
        }

      
        private void cboPassTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPassTyp.Text == "Student")
            {
                  txtIDType.Text ="Student";
                  return;
            }

             if (cboPassTyp.Text == "Senior")
            {
                  txtIDType.Text ="Senior";
                  return;
            }

             if (cboPassTyp.Text == "Regular") { txtIDType.Clear(); txtIDNum.Clear(); } 

            }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtContactNum.Clear();
        }

        private void txtCardNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            mod_system.DigitOnly(e);
        }

        private void txtContactNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            mod_system.DigitOnly(e);
        }

        internal void addPass(passenger ps)
        {
            pID = ps.ID;
            txtFname.Text = ps.Fname;
            txtMname.Text = ps.Mname;
            txtLname.Text = ps.Lname;
            txtBday.Text = Convert.ToDateTime(ps.BDay).ToShortDateString(); 
            txtContactNum.Text = ps.ContactNum.ToString();
            cboStreet.Text = ps.Street;
            cboBrgy.Text = ps.Brgy;
            cboCity.Text = ps.City;
            cboProvince.Text = ps.Province;
            cboPassTyp.Text = ps.PassType;
            txtIDType.Text = ps.IdType;
            txtIDNum.Text = ps.IDNum.ToString();
            txtCardNum.Text = ps.RFIDnum.ToString();

            Disbled();
            btnSave.Text = "&Modify";
        }

        internal void Disbled(bool st = false)
        {
            txtFname.Enabled = st;
            txtMname.Enabled = st;
            txtLname.Enabled = st;
            txtBday.Enabled = st;
            txtContactNum.Enabled = st;
            cboStreet.Enabled = st;
            cboBrgy.Enabled = st;
            cboCity.Enabled = st;
            cboProvince.Enabled = st;
            cboPassTyp.Enabled = st;
            txtIDNum.Enabled = st;
            txtIDType.Enabled = st;
            txtCardNum.Enabled = st;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to cancel?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtMname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtLname_TextChanged(object sender, EventArgs e)
        {

        }

        }

    }

