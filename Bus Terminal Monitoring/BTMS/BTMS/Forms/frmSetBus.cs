﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BTMS
{
    public partial class frmSetBus : Form
    {
        public static string BusNo = "";
        private busManagement tmpBus;
        public frmSetBus()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmBusList"] != null)
            {
                BusNo = txtBusNo.Text;
                (Application.OpenForms["frmBusList"] as frmBusList).Show();
            }
            else
            {
                BusNo = txtBusNo.Text;
                frmBusList frm = new frmBusList();
                frm.Show();
            }
        }

        internal void addbus(busManagement bm)
        {
           txtBusNo.Text = bm.BusNo;
           txtAvailableSeat.Text = bm.NumSeat;
            tmpBus = bm;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            savebusTrans();
            
        }
        private void savebusTrans()
        {
            if (txtBusNo.Text == "") { txtBusNo.Focus(); return; }

            busTransaction bustrans = new busTransaction();
            if (bustrans.iShasbusTrans())
            {
                busManagement bm = new busManagement();
                bm.Loadbusmngt(tmpBus.ID);

                MessageBox.Show("Can't set multiple bus, Because Bus # " + bm.BusNo + " was setted first.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Do you want to set this?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

          
            bustrans.Bus = tmpBus;
            bustrans.AvailableSeat =Convert.ToInt32(txtAvailableSeat.Text);
            bustrans.Status = "W";
            bustrans.Transdate =Convert.ToDateTime(mod_system.CurrentDate.ToShortDateString());
            bustrans.SavebusTrans();

            MessageBox.Show("Successfully saved.", "Confirmation", MessageBoxButtons.OK);
            txtAvailableSeat.Clear();
            txtBusNo.Clear();
            this.Close();
        }

        private void frmSetBus_Load(object sender, EventArgs e)
        {

        }
    }
}