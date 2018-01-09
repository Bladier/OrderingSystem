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
    public partial class frmExtend : Form
    {
        public frmExtend()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime start = new DateTime(2011, 3, 3, 0, 0, 0);
            DateTime earlyEnd = new DateTime(2011, 3, 3, 23, 59, 59);
            Console.WriteLine((earlyEnd - start).TotalSeconds); // prints 86399

            DateTime lateEnd = new DateTime(2011, 3, 4, 0, 0, 0);
            Console.WriteLine((lateEnd - start).TotalSeconds); // prints 86400
        }
    }
}
