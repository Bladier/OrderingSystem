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


namespace BTMS
{
    public partial class frmSetDate : Form
    {
        public frmSetDate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (frmMain.dateSet)
            {
                DialogResult result1= MessageBox.Show("Do you really want to close this date?", "Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result1 == DialogResult.No)
                {
                    return;
                }

                mod_system.CloseDate();
                frmMain.dateSet = false;

                if (frmMain.dateSet)
                {
                    button1.Text = "&Close Date";
                    this.Text = "Closing";
                }
                else
                {
                    button1.Text = "&Set Date";
                    this.Text = "Openning";
                }

                return;
            }

            DateTime cur = Convert.ToDateTime(txtCurrent.Value.ToString("MMM d, yyyy"));
            DialogResult result = MessageBox.Show("TODAY IS: " + cur.ToShortDateString(), "Date setting", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.No)
            {
                return;
            }

            string realtime = txtCurrent.Value.ToShortDateString();
        
            if (realtime != mod_system.CurrentDate.ToShortDateString()) 
            {
                DialogResult result2=  MessageBox.Show("It seems  SYSTEM DATE and CURRENT DATE didn't match." + " Are you sure about this?","Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result2 == DialogResult.No)
                {
                    return;
                }
            }

            mod_system.CurrentDate = txtCurrent.Value;
            mod_system.OpenDate();
         
            if (frmMain.dateSet)
            {
                button1.Text = "&Close Date";
                this.Text = "Closing";
            }
            else
            {
                button1.Text = "&Set Date";
                this.Text = "Openning";
            }
        }

        private void frmSetDate_Load(object sender, EventArgs e)
        {
            if (frmMain.dateSet)
            {
                button1.Text = "&Close Date";
                this.Text = "Closing";
            }
            else
            {
                button1.Text = "&Set Date";
                this.Text = "Openning";
            }
        }
    }
}
