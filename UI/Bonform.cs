using GBTapp_CantareMici.DAL;
using GBTapp_CantareMici.BLL;
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
    public partial class Bonform : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        public Bonform()
        {
            InitializeComponent();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        }
        
        BonuriBLL b = new BonuriBLL();
        BonuriDAL bdal = new BonuriDAL();
        
        private void button1_Click(object sender, EventArgs e)
        {
            b.Primul_bon =int.Parse( textBoxNrStart.Text);
            b.Bonuri_printate = 0;

            bool success2 = bdal.Insert(b, con);
           // bool success2 = bdal.Delete(b, con);
            if (success2 == true)
            {
                MessageBox.Show("Date salvate");

            }
            else
            {
                MessageBox.Show("Nu s a putut salva numarul Bonului");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            MyGlobals.isOpen = false;

            this.Close();
            
        }

        private void Bonform_Load(object sender, EventArgs e)
        {
            string sql = "SELECT Bonuri_printate FROM Bonuri ";
            // SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            // DataTable dt = new DataTable();
            // SqlDataAdapter adapter = new SqlDataAdapter();
            SqlDataReader NrReader;
            try
            {
                con.Open();
                NrReader = cmd.ExecuteReader();

                while (NrReader.Read())
                {
                    string sBonuri_printate = NrReader.GetDecimal(0).ToString();



                    labelBonuriPrintate.Text = sBonuri_printate;


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

        private void labelBonuriPrintate_Click(object sender, EventArgs e)
        {

        }

        
        

        private void Bonform_Load_1(object sender, EventArgs e)
        {

        }
    }
}
