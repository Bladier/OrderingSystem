using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace OrderingSystems
{
    public partial class frmUserManagement : Form
    {
        bool isUpdate = false;
        public frmUserManagement()
        {
            InitializeComponent();
        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            LoadUser();
        }

        private void LoadUser(string mysql = "SELECT * FROM TBLUSER WHERE STATUS <> 0")
        {
            DataSet ds = Database.LoadSQL(mysql, "TBLUSER");
            if (ds.Tables[0].Rows.Count==0){lvUser.Items.Clear();return;}

            lvUser.Items.Clear();
            foreach (DataRow itm in ds.Tables[0].Rows)
            {
                string fname = itm["FIRSTNAME"].ToString();
                string mname = itm["MIDDLENAME"].ToString();
                string lname = itm["LASTNAME"].ToString();
                  ListViewItem lv = lvUser.Items.Add(fname + " " + mname + " " + lname);
                  lv.Tag = itm["ID"];
            }
        }

        private void lvUser_DoubleClick(object sender, EventArgs e)
        {
            if (lvUser.SelectedItems.Count == 0) { return; }
            int idx =Convert.ToInt32(lvUser.SelectedItems[0].Tag);

            User us = new User();
            us.Loaduser(idx);

            populateUser(us);

            disabledTextfields();

            btnSave.Text = "&Edit";
        }

        private void populateUser(User u)
        {
            if (u.userpass == null) { return; }

            txtFname.Text = u.firstname;
            txtMname.Text = u.MidName;
            txtLname.Text = u.Lastname;
            txtUsername.Text = u.Username;
            cboUserTYpe.Text = u.Userrule;

            isUpdate = true;
        }

        private void disabledTextfields(bool st = false)
        {
            txtFname.Enabled = st;
            txtMname.Enabled = st;
            txtLname.Enabled = st;
            txtUsername.Enabled = st;
            cboUserTYpe.Enabled = st;
            txtuserPass.Enabled = st;
            txtConfirm.Enabled = st;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "&Edit")
            {
                disabledTextfields(true);
                btnSave.Text = "&Update";
                return;
            }
            if (btnSave.Text == "&Update")
            {
                UpdateUser();
                return;
            }

            if (btnSave.Text == "&Save")
            {
                saveUser();
                return;
            }

        }

        private void saveUser()
        {

            User us = new User();
            if (!isValid(us)) { return; }

            DialogResult result = MessageBox.Show("Do you want to save this user?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            us.firstname = txtFname.Text;
            us.MidName = txtMname.Text;
            us.Lastname = txtLname.Text;
            us.Username = txtUsername.Text;
            us.userpass = txtuserPass.Text;
            us.Userrule = cboUserTYpe.Text;
            us.SaveUser();


            MessageBox.Show("Successfully saved.", "Confirmation", MessageBoxButtons.OK);
            clearfield();

        }

        private void UpdateUser()
        {
            User us = new User();
            if (!isValid(us)) { return; }

            DialogResult result = MessageBox.Show("Do you want to update this user?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            us.ID = Convert.ToInt32(lvUser.SelectedItems[0].Tag);
            us.firstname = txtFname.Text;
            us.MidName = txtMname.Text;
            us.Lastname = txtLname.Text;
            us.Username = txtUsername.Text;
            us.userpass = txtuserPass.Text;
            us.Userrule = cboUserTYpe.Text;
            us.SaveUser(false, txtuserPass.Text);


            MessageBox.Show("Successfully updated.", "Confirmation", MessageBoxButtons.OK);
            clearfield();

        }

        private void clearfield()
        {
            txtFname.Clear();
            txtMname.Clear();
            txtLname.Clear();
            txtUsername.Clear();
            txtuserPass.Clear();
            txtConfirm.Clear();
            cboUserTYpe.SelectedItem = null;
            btnSave.Text = "&Save";
            LoadUser();
        }

        private bool isValid(User u)
        {
            if (txtFname.Text == "") { txtFname.Focus(); return false; }
            if (txtLname.Text == "") { txtLname.Focus(); return false; }
            if (txtUsername.Text == "") { txtUsername.Focus(); return false; }

            if (isUpdate)
            {
                if (txtuserPass.Text != "")
                {
                    if (txtConfirm.Text == "")
                    {
                        txtConfirm.Focus(); return false;
                    }
                }

                if (txtuserPass.Text != txtConfirm.Text)
                {
                    MessageBox.Show("Password not matched!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                if (txtuserPass.Text == "") { txtuserPass.Focus(); return false; }
                if (txtConfirm.Text == "")
                {
                    txtConfirm.Focus();
                    return false;
                }

                if (txtuserPass.Text != txtConfirm.Text)
                {
                    MessageBox.Show("Password not matched!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }


                User us = new User();
                if (us.IsUserNameExists(txtUsername.Text))
                {
                    MessageBox.Show("UserName already exists. Try unique username!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                User userex = new User();
                if (userex.ifUserIxists(txtFname.Text, txtMname.Text, txtLname.Text))
                {
                    MessageBox.Show("This user already exists, Please check in the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

           
            if (cboUserTYpe.Text == "") { cboUserTYpe.Focus(); return false; }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
