using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BTMS
{
    public partial class frmSetBusVersion2 : Form
    {
        public static bool isAuthorized;
        bool isTraveling = false;
        public static string BusNo = "";
        private busManagement tmpBus;
        public frmSetBusVersion2()
        {
            InitializeComponent();
        }

       
        private string[] GetDistinct(string col)
        {
            string mySql = "SELECT DISTINCT " + col + " FROM tblbusType WHERE " + col + " <> ''";
            DataSet ds = Database.LoadSQL(mySql,"tblbusType");

            int MaxCount = ds.Tables[0].Rows.Count;
            string[] str = new string[MaxCount];
            for (int cnt = 0; cnt <= MaxCount - 1; cnt++)
            {
                string tmpStr = ds.Tables[0].Rows[cnt]["BusType"].ToString();
                str[cnt]= tmpStr;
            }

            return str;
        }

        private string[] GetBusNo(string col)
        {

            string mySql = "SELECT * FROM tblbus WHERE type ='" + cboBusType.Text + "'";
            DataSet ds = Database.LoadSQL(mySql,"tblbus");
           
            int MaxCount = ds.Tables[0].Rows.Count;
            string[] str = new string[MaxCount];
            for (int cnt = 0; cnt <= MaxCount - 1; cnt++)
            {
                string tmpStr = ds.Tables[0].Rows[cnt]["Busno"].ToString();
                str[cnt] = tmpStr;
            }

            return str;
        }

        private void frmSetBusVersion2_Load(object sender, EventArgs e)
        {
            cboBusType.Items.AddRange(GetDistinct("BusType"));
        }

        private void cboBusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBusType.Text == "")
            {
                return;
            }
            cboBusNo.Items.Clear();
            cboBusNo.Items.AddRange(GetBusNo(cboBusType.Text));
            clearFields();
        }

        private void cboBusNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBusNo.Text == "") { return; }
            string mysql = "select * from tblbus where busno ='" + cboBusNo.Text +"'";
            DataSet ds = Database.LoadSQL(mysql, "tblbus");

            int busid=Convert.ToInt32(ds.Tables[0].Rows[0]["busID"]);
            int driverId =Convert.ToInt32(ds.Tables[0].Rows[0]["driverno"]);
            int condoctorID = Convert.ToInt32(ds.Tables[0].Rows[0]["CondoctorID"]);

            busRoute br = new busRoute();
            br.LoadbusRoute(busid);
            txtFrom.Text = br.From;
            txtTO.Text=br.Dest;
            txtRate.Text=br.Rate.ToString();

            buspersonnel d =new buspersonnel();
            d.Loadpersonnel(driverId);

            txtDriver.Text = d.Fname + " " + d.Lname;

            buspersonnel c = new buspersonnel();
            c.Loadpersonnel(condoctorID);

            txtCondoctor.Text = c.Fname + " " + c.Lname;

            busManagement bm = new busManagement();
            bm.Loadbusmngt(busid);

            txtAvailableSeat.Text = bm.NumSeat;
            tmpBus = bm;
            IsTravel();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (cboBusType.Text == "") { cboBusType.Focus(); return; }
            if (cboBusNo.Text == "") { cboBusNo.Focus(); return; }

            frmAutorization frm = new frmAutorization();

            if (!frm.isAuthorizedPerson())
            {
                MessageBox.Show("Not verified, Please verify the authorized person.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            busTransaction bustrans = new busTransaction();
            if (bustrans.iShasbusTrans())
            {
                busManagement bm = new busManagement();
                bm.Loadbusmngt(tmpBus.ID);

                MessageBox.Show("Can't set multiple bus, this bus is already waiting", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IsTravel())
            {
                MessageBox.Show("This bus is now traveling, you can't set it now wait until it's arrived", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bustrans.Bus = tmpBus;
            bustrans.AvailableSeat = Convert.ToInt32(txtAvailableSeat.Text);
            bustrans.Status = "W";
            bustrans.Transdate = Convert.ToDateTime(mod_system.CurrentDate.ToShortDateString());
            bustrans.SavebusTrans();

            MessageBox.Show("Successfully setted.", "Confirmation", MessageBoxButtons.OK);
       
            cboBusType.SelectedItem = null;
            cboBusNo.Items.Clear();
            clearFields();
            this.Close();

        }
        private void clearFields()
        {
            txtCondoctor.Clear();
            txtDriver.Clear();
            txtRate.Clear();
            txtFrom.Clear();
            txtTO.Clear();
        }

        internal void addbus(busManagement bm)
        {
            tmpBus = bm;
            IsTravel();
        }

        public bool IsTravel()
        {
            string tmpdate = "";
            tmpdate = mod_system.CurrentDate.ToString("yyyy-MM-dd");

            string mysql = "select * from tblbusTransaction where busID = '" + tmpBus.ID + "' and status ='T' and transDate ='" + tmpdate + "'";
            DataSet ds = Database.LoadSQL(mysql, "tblbusTransaction");
            if (ds.Tables[0].Rows.Count == 0)
            {
                isTraveling = false;
                return false;

            }
            isTraveling = true;
            return true;
        }

        private void btnAuthorization_Click(object sender, EventArgs e)
        {
            frmAutorization frm = new frmAutorization();
            frm.Show();
        }

    }
}
