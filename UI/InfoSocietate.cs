using GBTapp_CantareMici.BLL;
using GBTapp_CantareMici.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GBTapp_CantareMici.UI
{
    public partial class InfoSocietate : Form
    {

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();

        public InfoSocietate()
        {
            InitializeComponent();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        }

        SocietateBLL s = new SocietateBLL();
        SocietateDAL sdal = new SocietateDAL();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool success1 = sdal.Count(con);
            bool success = false;
            s.Societate = textBoxSocietate.Text;
            s.Adresa = textBoxAdresa.Text;
            s.Cod_fiscal = textBoxCif.Text;
            s.NrRegCom = textBoxNrOrd.Text;
            s.Cont = textBoxCont.Text;
            s.Banca = textBoxBanca.Text;
            s.Punct_lucru = textBoxPunctLucru.Text;

            
           
                 success = sdal.Delete(s, con);
           
            
            
                 success = sdal.Insert(s, con);
            
          



            

            if (success == true)
            {
                MessageBox.Show("Datele au fost salvate");

                //show on datagridview
              
            }
            else
            {
                MessageBox.Show("Datele exista");
            }
            con.Close();
        }

        private void InfoSocietate_Load(object sender, EventArgs e)
        {
            bool success = sdal.Count( con);
            if (success == true)
            {
                DataTable dt = sdal.Select(con);

                textBoxSocietate.Text = dt.Rows[0].ItemArray[0].ToString();
                textBoxAdresa.Text = dt.Rows[0].ItemArray[1].ToString();
                textBoxCif.Text = dt.Rows[0].ItemArray[2].ToString();
                textBoxNrOrd.Text = dt.Rows[0].ItemArray[3].ToString();
                textBoxCont.Text = dt.Rows[0].ItemArray[4].ToString();
                textBoxBanca.Text = dt.Rows[0].ItemArray[5].ToString();
                textBoxPunctLucru.Text = dt.Rows[0].ItemArray[6].ToString();

            }
            else
            {
                MessageBox.Show("introduceti date societate");
            }
            con.Close();
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MyGlobals.isOpen = false;
            this.Close();
        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // InfoSocietate
        //    // 
        //    this.ClientSize = new System.Drawing.Size(284, 261);
        //    this.Name = "InfoSocietate";
        //    this.Load += new System.EventHandler(this.InfoSocietate_Load_1);
        //    this.ResumeLayout(false);

        //}

        private void InfoSocietate_Load_1(object sender, EventArgs e)
        {

        }
    }
}
