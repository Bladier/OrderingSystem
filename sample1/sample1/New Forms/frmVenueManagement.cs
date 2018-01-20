using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sample1
{
    public partial class frmVenueManagement : Form
    {
        public frmVenueManagement()
        {
            InitializeComponent();
        }

        private void frmVenueManagement_Load(object sender, EventArgs e)
        {
            Loadvenue();
        }

        private void Loadvenue(string mysql = "SELECT * FROM venuetbl")
        {
            DataSet ds = Database.LoadSQL(mysql, "venuetbl");
            if (ds.Tables[0].Rows.Count == 0) { lvvenue.Items.Clear(); return; }

            lvvenue.Items.Clear();
            foreach (DataRow itm in ds.Tables[0].Rows)
            {
                string desc = itm["description"].ToString();
                string rate = itm["rate"].ToString();
                string cap = itm["capacity"].ToString();
                ListViewItem lv = lvvenue.Items.Add(desc);
                lv.SubItems.Add(rate.ToString());
                lv.SubItems.Add(cap);
                lv.Tag = itm["ID"];
            }
        }

        private bool isExists()
        {
            string mysql = "SELECT * FROM venuetbl where Upper(description) =Upper('" + txtdesc.Text + "')";
               DataSet ds = Database.LoadSQL(mysql, "venuetbl");
            if (ds.Tables[0].Rows.Count > 0) {  return true; }

            return false;
        }

        private void lvvenue_DoubleClick(object sender, EventArgs e)
        {
            if (lvvenue.SelectedItems.Count == 0) { return; }
            Venuemngt  v = new Venuemngt();
            v.loadvenue(Convert.ToInt32(lvvenue.SelectedItems[0].Tag));

            txtdesc.Text = v.VenueName;
            txtrate.Text = v.Rate.ToString();
            txtcap.Text = v.Capacity.ToString();

            txtcap.Enabled = false;
            txtdesc.Enabled = false;
            txtrate.Enabled = false;
            btnSave.Text = "&Edit";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "&Edit")
            {
                txtcap.Enabled = true;
                txtdesc.Enabled = true;
                txtrate.Enabled = true;
                btnSave.Text = "&Update";
                return;
            }
            if (btnSave.Text == "&Update")
            {
                Update();
                return;
            }

            if (btnSave.Text == "&Save")
            {
                savevenue();
                return;
            }

        }

        private void savevenue()
        {

            Venuemngt us = new Venuemngt();

            if (isExists())
            {
                MessageBox.Show("Venue already exists?", "Confirmation", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Do you want to save this venue?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            us.VenueName = txtdesc.Text;
            us.Rate = Convert.ToDouble(txtrate.Text);
            us.Capacity = Convert.ToInt32(txtcap.Text);
          
            us.savevenue();


            MessageBox.Show("Successfully saved.", "Confirmation", MessageBoxButtons.OK);
            clearfield();

        }

        private void Update()
        {
            Venuemngt us = new Venuemngt();
      

            DialogResult result = MessageBox.Show("Do you want to update this venue?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            us.ID = Convert.ToInt32(lvvenue.SelectedItems[0].Tag);
            us.VenueName = txtdesc.Text;
            us.Rate = Convert.ToDouble(txtrate.Text);
            us.Capacity = Convert.ToInt32(txtcap.Text);

            us.Update();
            MessageBox.Show("Successfully updated.", "Confirmation", MessageBoxButtons.OK);
            clearfield();

        }

        private void clearfield()
        {
            txtcap.Clear();
              txtdesc.Clear();
              txtrate.Clear();
            btnSave.Text = "&Save";
            Loadvenue();
        }

        private void txtrate_KeyPress(object sender, KeyPressEventArgs e)
        {
            mod_system.DigitOnly(e);

        }

        private void txtcap_KeyPress(object sender, KeyPressEventArgs e)
        {
            mod_system.DigitOnly(e);
        }
    }
}
