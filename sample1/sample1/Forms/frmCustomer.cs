using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;


namespace sample1
{
    public partial class frmCustomer : Form
    {
        public bool isReservation = false;
        public bool isBooking = false;

        public static bool isView = false;
        int age;
        int CustomerID;
        int BID;
        Customer tmpcust;
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmPersonnelRegistration_Load(object sender, EventArgs e)
        {
            cboCity.Items.AddRange(GetDistinct("City"));
            cboStreet.Items.AddRange(GetStreet("Street"));
            cboProvince.Items.AddRange(GetProvince("Province"));
       
        }
        private string[] GetDistinct(string col)
        {
            string mySql = "SELECT DISTINCT " + col + " FROM citytbl WHERE " + col + " <> ''";
            DataSet ds = Database.LoadSQL(mySql);

            int MaxCount = ds.Tables[0].Rows.Count;
            string[] str = new string[MaxCount];
            string tmpStr ;
    
            for (int cnt = 0; cnt <= MaxCount - 1; cnt++)
            {
                 tmpStr = ds.Tables[0].Rows[cnt][col].ToString();
                 str[cnt] = tmpStr;
            }
         
            return str;
        }

        private string[] GetStreet(string col)
        {
            string mySql = "SELECT DISTINCT " + col + " FROM customertbl WHERE " + col + " <> ''";
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

        private string[] GetProvince(string col)
        {
            string mySql = "SELECT DISTINCT " + col + " FROM customertbl WHERE " + col + " <> ''";
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
                saveCustomer();
            }
            else
            {
                UPdateCustomer();
            }
        }

        private void saveCustomer()
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

            Customer cus = new Customer();
            if (!cus.isCustomerExists(txtFname.Text, txtMname.Text, txtLname.Text, txtBday.Value))
            {
                MessageBox.Show("Customer already exists. Try to search in the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }


            DialogResult result = MessageBox.Show("Do you want to save this customer?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            cus.firstname = txtFname.Text;
            cus.middlename = txtMname.Text;
            cus.lastname = txtLname.Text;
            cus.birthday = Convert.ToDateTime(txtBday.Text);

            cus.ContactNum = txtContactNo.Text;
            cus.street = cboStreet.Text;
            cus.brgyID = BID;
            cus.province = cboProvince.Text;
            cus.saveCust();

            MessageBox.Show("Successfully saved.", "Confirmation", MessageBoxButtons.OK);
            clearfield();

            if (isBooking)
           {
                cus.LoadCust(cus.GetLastID());
                if (Application.OpenForms["frmBooking"] != null)
                {

                    (Application.OpenForms["frmBooking"] as frmBooking).loadcustomer(cus);
                    this.Close();
                }
                else
                {
                    frmBooking frm = new frmBooking();
                    frm.Show();
                    frm.loadcustomer(cus);
                    this.Close();
                }
            }

          
           if (isReservation)
           {
               cus.LoadCust(cus.GetLastID());
                if (Application.OpenForms["frmreservation2"] != null)
                {

                    (Application.OpenForms["frmreservation2"] as frmreservation2).loadcustomer(cus);
                    this.Close();

                }
            }
           if (isBooking)
           {
               cus.LoadCust(cus.GetLastID());
               frmreservation2 frm = new frmreservation2();
               frm.Show();
               frm.loadcustomer(cus);
               this.Close();
           }
          
        }

        private void UPdateCustomer()
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

            DialogResult result = MessageBox.Show("Do you want to Update this customer?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            Customer cus = new Customer();

            cus.ID = CustomerID;
            cus.firstname = txtFname.Text;
            cus.middlename = txtMname.Text;
            cus.lastname = txtLname.Text;
            cus.birthday = Convert.ToDateTime(txtBday.Text);

            cus.ContactNum = txtContactNo.Text;
            cus.street = cboStreet.Text;
            cus.brgyID = BID;
   
            cus.province = cboProvince.Text;
            cus.Update();
            
            MessageBox.Show("Successfully updated.", "Confirmation", MessageBoxButtons.OK);
          
            Customer tmpCustomer = new Customer();
            if (isReservation)
            {
                tmpCustomer.LoadCust(tmpcust.ID);
                if (Application.OpenForms["frmreservation2"] != null)
                {

                    (Application.OpenForms["frmreservation2"] as frmreservation2).loadcustomer(tmpCustomer);
                    this.Close();
                    return;
                }
                else
                {
                    tmpCustomer.LoadCust(tmpcust.ID);
                    frmBooking frm = new frmBooking();
                    frm.Show();
                    frm.loadcustomer(tmpCustomer);
                    this.Close();
                    return;
                }
            }

            if (isBooking)
            {
                tmpCustomer.LoadCust(tmpcust.ID);
                if (Application.OpenForms["frmBooking"] != null)
                {

                    (Application.OpenForms["frmBooking"] as frmBooking).loadcustomer(tmpCustomer);
                    this.Close();
                    return;
                }
                else
                {
                    tmpCustomer.LoadCust(tmpcust.ID);
                    frmBooking frm = new frmBooking();
                    frm.Show();
                    frm.loadcustomer(tmpCustomer);
                    this.Close();
                    return;
                }
            }
            clearfield();
        }


        private void clearfield()
        {
            cboCity.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBrgy.DropDownStyle = ComboBoxStyle.DropDownList;
            txtFname.Clear();
            txtMname.Clear();
            txtLname.Clear();
            txtBday.Text = mod_system.CurrentDate.ToShortDateString();
   
           CustomerID = 0;
       
            txtContactNo.Clear();
          
            cboCity.SelectedItem = null;
            cboStreet.Text = "";
            cboProvince.Text = "";
            cboStreet.Items.Clear();
            cboProvince.Items.Clear();
            cboBrgy.Items.Clear();
            
            cboStreet.Items.AddRange(GetStreet("Street"));
            cboProvince.Items.AddRange(GetProvince("Province"));
            cboCity.SelectedItem = null;
            cboProvince.SelectedItem = null;
           
          
        }

        internal void loadcustomer(Customer cus,bool view=false)
        {

            if (view)
            {
                isView = true;
            }

            CustomerID = cus.ID;
            txtFname.Text = cus.firstname;
            txtMname.Text = cus.middlename;
            txtLname.Text = cus.lastname;
            txtBday.Text = Convert.ToDateTime(cus.birthday).ToShortDateString();

            txtContactNo.Text = cus.ContactNum.ToString();
            cboStreet.Text = cus.street;

            cboCity.DropDownStyle = ComboBoxStyle.DropDown;
            cboCity.Text = cus.city;
            if (view)
            {
                cboBrgy.DropDownStyle = ComboBoxStyle.DropDown;
                cboBrgy.Text = cus.brgy;
            }
            BID = cus.brgyID;
        
            cboProvince.Text = cus.province;
            Disbled();
            btnSave.Text = "&Modify";
            tmpcust = cus;
         
        }

        internal void Disbled(bool st = false)
        {
            txtFname.Enabled = st;
            txtMname.Enabled = st;
            txtLname.Enabled = st;
            txtBday.Enabled = st;
            
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

        private void cboCity_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            if (cboCity.Text == "") { cboBrgy.Items.Clear(); return; }
            cboBrgy.Items.AddRange(GetDistinct(getcityID(cboCity.Text)));
        }

        private string[] GetDistinct(int idx)
        {
            string mySql = "SELECT * FROM barangaytbl WHERE " + " CityID = " + idx + "";
            DataSet ds = Database.LoadSQL(mySql);
      
            int MaxCount = ds.Tables[0].Rows.Count;
            string[] str = new string[MaxCount];
            for (int cnt = 0; cnt <= MaxCount - 1; cnt++)
            {
                string tmpStr = ds.Tables[0].Rows[cnt]["Barangay"].ToString();
                str[cnt] = tmpStr;
            }
         
            return str;
        }

        private int getcityID(string city)
        {
            string mySql = "SELECT * FROM Citytbl WHERE " + " city = '" + city + "'";
            DataSet ds = Database.LoadSQL(mySql);

            return Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
        }

        private void cboBrgy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBrgy.Text == "") { return; }
            string mysql = "select * from barangaytbl where barangay ='" +  cboBrgy.Text + "'";
            DataSet ds = Database.LoadSQL(mysql, "barangaytbl");
            BID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
        }

      
    }
}
