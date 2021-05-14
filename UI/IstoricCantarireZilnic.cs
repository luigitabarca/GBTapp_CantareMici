using GBTapp_CantareMici.BLL;
using GBTapp_CantareMici.DAL;
using GBTapp_CantareMici.FCN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.Configuration;

namespace GBTapp_CantareMici.UI
{
    public partial class IstoricCantarireZilnic : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();




        public IstoricCantarireZilnic()
        {
            InitializeComponent();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        }

        RapoarteBLL r = new RapoarteBLL();
        RapoarteDAL rdal = new RapoarteDAL();
        PdfFile file = new PdfFile();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MyGlobals.isOpen = false;
            this.Hide();
        }

        private void IstoricCantarireZilnic_Load(object sender, EventArgs e)
        {




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string dataInceput = dateTimePickerStart.Value.AddDays(-1).ToString("yyyyMMdd");
            string dataSfarsit = dateTimePickerEnd.Value.AddDays(1).ToString("yyyy-MM-dd");



            ;

            //show on datagridview
            DataTable dt = rdal.IstoricSelect(con, dataInceput, dataSfarsit);
            dataGridViewIstoric.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RaportForm form = new RaportForm();
            form.datastart = dateTimePickerStart.Value.ToString("yyyyMMdd");
            form.datasfarsit = dateTimePickerEnd.Value.ToString("yyyyMMdd");
            form.TopMost = true;
            form.Show();
            this.Hide();

        }
        public static int raportId;
        public string textBoxNRAuto;
        public string textBoxCodP;
        public string textBoxCodC;
        public string textBoxCodF;
        public string textBoxGreutateInt;
        public string textBoxGreutateOut;
        public string dataInt;
        public string dataOut;
        public string textBoxNrDoc;
        public string comboBoxTipDocument;
        public string nrBon;
        public string Operat;
        public string Client;
        public string cAdresa;
        public string cCod_fiscal;
        public string cCont;
        public string cBanca;
        public string NrRegC;
        public string Produs;
        public string Cod_produs;
        public string Tip_produs;
        public string Furnizor;
        public string sAdresa;
        public string sCod_fiscal;
        public string sCont;
        public string sBanca;
        public string NrRegF;
        public string Remorca;
        public string Delegat;
        public string Buletin;
        public string Operator_id;
        public string NrInmatriculare;
        public string sSediu;
        public string cSediu;
        public string NrAxe;

        private void dataGridViewIstoric_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int RowIndex = e.RowIndex;
            raportId = int.Parse(dataGridViewIstoric.Rows[RowIndex].Cells[0].Value.ToString());
            DataTable dt = rdal.CustomSelect(con, raportId);
            
            
            textBoxCodP = dt.Rows[0].ItemArray[1].ToString();
            textBoxCodC = dt.Rows[0].ItemArray[2].ToString();
            textBoxCodF = dt.Rows[0].ItemArray[3].ToString();
            file.GreutateNeta = dt.Rows[0].ItemArray[4].ToString();
            file.DataTichet = dt.Rows[0].ItemArray[5].ToString();
            file.NrTichet = dt.Rows[0].ItemArray[6].ToString();

            //initializare campuri necompletate
            file.GreutateBrut = "-";
            file.GreutateTara = "-";
            
            //autocomplete produss
            #region Repopulare produse
            {
                string sql = "SELECT * FROM Produse WHERE ID_produs = '" + textBoxCodP + "' ";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader NrReader;

                try
                {
                    con.Open();
                    NrReader = cmd.ExecuteReader();
                    {
                        NrReader.Read();
                        file.DenumireProdus = NrReader.GetString(1).ToString();
                        file.NaturaProdus = NrReader.GetString(2).ToString();
                        file.CodProdus= NrReader.GetString(3).ToString();
                        file.LotProdus = NrReader.GetString(4).ToString();
                        file.DataExpirariiProdus = NrReader.GetString(5).ToString();
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
            #endregion


            //autocomplete furnizori
            #region Repopulare furnizori
            {

                string sql = "SELECT * FROM Furnizori WHERE ID_furnizor = '" + textBoxCodF + "' ";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader NrReader;
                try
                {
                    con.Open();
                    NrReader = cmd.ExecuteReader();
                    {
                        NrReader.Read();
                        file.DenumireFurnizor = NrReader.GetString(1).ToString();
                        file.AdresaFurnizor = NrReader.GetString(2).ToString();
                        file.CifFurnizor = NrReader.GetString(3).ToString();
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
            #endregion

            //autocomplete clienti
            #region Repopulare Clienti
            {
                string sql = "SELECT * FROM Clienti WHERE ID_client = '" + textBoxCodC + "' ";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader NrReader;
                try
                {
                    con.Open();
                    NrReader = cmd.ExecuteReader();
                    {
                        NrReader.Read();
                        file.DenumireClient = NrReader.GetString(1).ToString();
                        file.AdresaClient = NrReader.GetString(2).ToString();
                        file.CifClient = NrReader.GetString(3).ToString();
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
            #endregion

           


        }

        

        private void button3_Click(object sender, EventArgs e)
        {

            if (raportId != 0)
            {
                file.IncarcaHeader();
                file.CreazaBonPdf();
            }
            else
            {
                MessageBox.Show("Selectati o inregistrare pentru a fi printat documentul");
            }

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }
            else
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                TopMost = false;
            }
        }
    }
}