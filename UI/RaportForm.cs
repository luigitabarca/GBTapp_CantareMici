using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace GBTapp_CantareMici.UI
{
    public partial class RaportForm : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        public string datastart;
        public string datasfarsit;
        public RaportForm()
        {
            InitializeComponent();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RaportForm_Load(object sender, EventArgs e)
        {
            CrystalReport1 cr = new CrystalReport1();
            string sql = " SELECT * FROM RaportView WHERE DataTimpI BETWEEN '" + datastart + "'AND '" + datasfarsit + "'";

            

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);

            adapter.Fill(ds, "RaportView1");
            cr.SetDataSource(ds.Tables["RaportView1"]);
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            MyGlobals.isOpen = false;
        }
    }
}
