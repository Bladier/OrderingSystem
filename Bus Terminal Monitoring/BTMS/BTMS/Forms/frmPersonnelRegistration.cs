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
            cboStreet.Items.AddRange(GetDistinct("Street"));
            cboBrgy.Items.AddRange(GetDistinct("Brgy"));
            cboCity.Items.AddRange(GetDistinct("City"));
            cboProvince.Items.AddRange(GetDistinct("Province"));
        }
        private string[] GetDistinct(string col)
        {
            string mySql = "SELECT DISTINCT " + col + " FROM tblbusperson WHERE " + col + " <> ''";
            DataSet ds = Database.LoadSQL(mySql);

            int MaxCount = ds.Tables[0].Rows.Count;
            string[] str = new string[MaxCount];
            for (int cnt = 0; cnt <= MaxCount - 1; cnt++)
            {
                string tmpStr = ds.Tables[0].Rows[cnt][col].ToString();
                str[cnt] = tmpStr;
            }

            return str;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
          
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
           
            if (rbactive.Checked)
            {
                bp.Status = true;
            }
            else
            {
                bp.Status = false;
            }

            bp.DateHired = Convert.ToDateTime(dtHired.Text);
            bp.ContactNum = Convert.ToUInt64(txtContactNo.Text);
            bp.Street = cboStreet.Text;
            bp.Brgy = cboBrgy.Text;
            bp.City = cboCity.Text;
            bp.Province = cboProvince.Text;
            bp.Savepersonnel();

      
            MessageBox.Show("Successfully saved.", "Confirmation", MessageBoxButtons.OK);
            clearfield();

            if (mod_system.isAddBus)
            {
                bp.loadLastSave();
                if (Application.OpenForms["frmBusManagement"] != null)
                {
                    (Application.OpenForms["frmBusManagement"] as frmBusManagement).addDriver(bp);
                }
                else
                {
                    frmBusManagement frm = new frmBusManagement();
                    frm.Show();
                    frm.addDriver(bp);
                }
                this.Close();
            }
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
            bp.DateHired = Convert.ToDateTime(dtHired.Text);
            bp.ContactNum = Convert.ToUInt64(txtContactNo.Text);
            bp.Street = cboStreet.Text;
            bp.Brgy = cboBrgy.Text;
            bp.City = cboCity.Text;
            bp.Province = cboProvince.Text;

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
            cboPosition.SelectedItem = null;
            personnelID = 0;
            dtHired.Text = mod_system.CurrentDate.ToShortDateString();
            txtContactNo.Clear();
            cboStreet.SelectedItem = null;
            cboBrgy.SelectedItem = null;
            cboCity.SelectedItem = null;
            cboProvince.SelectedItem = null;

            cboCity.Items.Clear();
            cboStreet.Items.Clear();
            cboProvince.Items.Clear();
            cboBrgy.Items.Clear();

            cboStreet.Items.AddRange(GetDistinct("Street"));
            cboBrgy.Items.AddRange(GetDistinct("Brgy"));
            cboCity.Items.AddRange(GetDistinct("City"));
            cboProvince.Items.AddRange(GetDistinct("Province"));
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

            dtHired.Text = Convert.ToDateTime(bp.DateHired).ToShortDateString();
            txtContactNo.Text = bp.ContactNum.ToString();
            cboStreet.Text = bp.Street;
            cboBrgy.Text = bp.Brgy;
            cboCity.Text = bp.City;
            cboProvince.Text = bp.Province;

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
            dtHired.Enabled = st;
            txtContactNo.Enabled = st;
            cboStreet.Enabled = st;
            cboBrgy.Enabled = st;
            cboCity.Enabled = st;
            cboProvince.Enabled = st;
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
