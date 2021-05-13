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
    public partial class InfoMetrologic : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();

        public InfoMetrologic()
        {
            InitializeComponent();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        }
        MetrologieBLL m = new MetrologieBLL();
        MetrologieDAL mdal = new MetrologieDAL();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool success = false;
            m.NrCantar = textBoxSerieIndicator.Text;
            m.Serie_indicator = textBoxSerieIndicator.Text;
            m.Buletin_metrologic = textBoxBuletin.Text;
            m.Clasa_precizie = textBoxClasaPrecizie.Text;
            m.Tip_cantarire = textBoxTipCantarire.Text;
            m.Tip_cantar = comboBox1.Text;


            success = mdal.Delete(m, con);
             success = mdal.Insert(m, con);

                if (success == true)
                {
                    MessageBox.Show("Datele au fost salvate");

                    
                   
                }
                else
                {
                    MessageBox.Show("Datele existente");
                }
                con.Close();
               
            
        }

        private void InfoMetrologic_Load(object sender, EventArgs e)
        {

            



            string sql = "SELECT * FROM Metrologie";

                SqlCommand cmd = new SqlCommand(sql, con);


                SqlDataReader NrReader;
                try
                {
                    con.Open();
                    NrReader = cmd.ExecuteReader();

                    // while (NrReader.Read())
                    {
                        NrReader.Read();
                        string sNrCantar = NrReader.GetString(0).ToString();
                        string sSerie_indicator = NrReader.GetString(1).ToString();
                        string sBuletin_metrologic = NrReader.GetString(2).ToString();
                    string sClasa_precizie = NrReader.GetString(3).ToString();
                    string sTip_cantarire = NrReader.GetString(4).ToString();
                    string sTip_cantar = NrReader.GetString(6).ToString();

                   // textBoxNrCantar.Text = sNrCantar;
                    textBoxSerieIndicator.Text = sSerie_indicator;
                    textBoxBuletin.Text = sBuletin_metrologic;
                    textBoxClasaPrecizie.Text = sClasa_precizie;
                    textBoxTipCantarire.Text = sTip_cantarire;
                    comboBox1.Text = sTip_cantar;
                   

                }
                }
                catch (Exception ex)
                {


                    MessageBox.Show(ex.Message);

                }
                finally
                {
                    con.Close();

                }
               
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
        //    // InfoMetrologic
        //    // 
        //    this.ClientSize = new System.Drawing.Size(284, 261);
        //    this.Name = "InfoMetrologic";
        //    this.Load += new System.EventHandler(this.InfoMetrologic_Load_1);
        //    this.ResumeLayout(false);

        //}

        private void InfoMetrologic_Load_1(object sender, EventArgs e)
        {

        }
    }
}
