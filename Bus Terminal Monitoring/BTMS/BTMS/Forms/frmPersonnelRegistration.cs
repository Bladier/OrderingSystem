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
    public partial class frmPersonnelRegistration : Form
    {
        int age;
        int personnelID;
        public frmPersonnelRegistration()
        {
            InitializeComponent();
        }

        private void frmPersonnelRegistration_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Close?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            this.Close();
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
                savepersonnel();
            }
            else
            {
                UPdatepersonnel();
            }
        }

        private void savepersonnel()
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
            if (cboPosition.Text == "") { cboPosition.Focus(); return; }

            if (age < 18)
            {
                MessageBox.Show("Age below 18 is not allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }


            DialogResult result = MessageBox.Show("Do you want to save this personnel?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            buspersonnel bp = new buspersonnel();
            bp.Fname = txtFname.Text;
            bp.Mname = txtMname.Text;
            bp.Lname = txtLname.Text;
            bp.BDay =Convert.ToDateTime(txtBday.Text);
            bp.Position = cboPosition.Text;



            bp.Savepersonnel();

            MessageBox.Show("Successfully saved.", "Confirmation", MessageBoxButtons.OK);
            clearfield();
        }

        private void UPdatepersonnel()
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
            if (cboPosition.Text == "") { cboPosition.Focus(); return; }

            DialogResult result = MessageBox.Show("Do you want to Update this personnel?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            buspersonnel bp = new buspersonnel();
            bp.ID = personnelID;
            bp.Fname = txtFname.Text;
            bp.Mname = txtMname.Text;
            bp.Lname = txtLname.Text;
            bp.BDay = Convert.ToDateTime(txtBday.Text);
            bp.Position = cboPosition.Text;

            if (rbactive.Checked)
            {
                bp.Status = true;
            }
            if (rbinActive.Checked)
            {
                bp.Status = false;
            }

            bp.Updatepersonnel();

            MessageBox.Show("Successfully updated.", "Confirmation", MessageBoxButtons.OK);
            clearfield();
        }


        private void clearfield()
        {
            txtFname.Clear();
            txtMname.Clear();
            txtLname.Clear();
            txtBday.Text = mod_system.CurrentDate.ToShortDateString();
            cboPosition.Text = "";
            personnelID = 0;
        }

        internal void addPass(buspersonnel bp)
        {
            personnelID = bp.ID;
            txtFname.Text = bp.Fname;
            txtMname.Text = bp.Mname;
            txtLname.Text = bp.Lname;
            txtBday.Text = Convert.ToDateTime(bp.BDay).ToShortDateString();
            cboPosition.Text = bp.Position;


            if (bp.Status)
            {
                rbactive.Checked = true;
            }
            else
            {
                rbinActive.Checked = true;
            }

            Disbled();
            btnSave.Text = "&Modify";
        }

        internal void Disbled(bool st = false)
        {
            txtFname.Enabled = st;
            txtMname.Enabled = st;
            txtLname.Enabled = st;
            txtBday.Enabled = st;
            cboPosition.Enabled = st;
            rbactive.Enabled = st;
            rbinActive.Enabled = st;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtBday_ValueChanged(object sender, EventArgs e)
        {
            age = Convert.ToInt32(mod_system.GetCurrentAge(txtBday.Value));
        }
    }
}
