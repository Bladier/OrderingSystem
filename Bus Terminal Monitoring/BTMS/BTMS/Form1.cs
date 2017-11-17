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
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
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

            DialogResult result = MessageBox.Show("Do you want to save this client?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
           passenger savepass = new passenger();
       
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

           savepass.Savepassenger();

           MessageBox.Show("Successfully saved.", "Confirmation", MessageBoxButtons.OK);
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

             if (cboPassTyp.Text == "Regular") { txtIDType.Clear(); } 

            }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        }

    }

