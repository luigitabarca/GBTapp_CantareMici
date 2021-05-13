using GBTapp_CantareMici.BLL;
using GBTapp_CantareMici.DAL;
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
            //textBoxNRAuto.Text = dt.Columns[1].toValue.ToString();
            textBoxNRAuto = dt.Rows[0].ItemArray[1].ToString();
            textBoxCodP = dt.Rows[0].ItemArray[2].ToString();
            textBoxCodC = dt.Rows[0].ItemArray[3].ToString();
            textBoxCodF = dt.Rows[0].ItemArray[4].ToString();
            textBoxGreutateInt = dt.Rows[0].ItemArray[5].ToString();
            textBoxGreutateOut = dt.Rows[0].ItemArray[6].ToString();
            dataInt = dt.Rows[0].ItemArray[7].ToString();
            dataOut = dt.Rows[0].ItemArray[8].ToString();
            textBoxNrDoc = dt.Rows[0].ItemArray[10].ToString();
            comboBoxTipDocument = dt.Rows[0].ItemArray[9].ToString();
            nrBon = dt.Rows[0].ItemArray[11].ToString();
            Operat = dt.Rows[0].ItemArray[12].ToString();
            Operator_id = dt.Rows[0].ItemArray[13].ToString();
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

                    // while (NrReader.Read())
                    {
                        NrReader.Read();
                        Produs = NrReader.GetString(2).ToString();
                        Cod_produs = NrReader.GetString(1).ToString();
                        Tip_produs = NrReader.GetString(5).ToString();




                        con.Close();


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

                    // while (NrReader.Read())
                    {
                        NrReader.Read();
                        Furnizor = NrReader.GetString(2).ToString();
                        sAdresa = NrReader.GetString(3).ToString();
                        sCod_fiscal = NrReader.GetString(4).ToString();
                        sCont = NrReader.GetString(5).ToString();
                        sBanca = NrReader.GetString(6).ToString();
                        NrRegF = NrReader.GetString(7).ToString();
                        sSediu= NrReader.GetString(8).ToString();


                        con.Close();

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

                    // while (NrReader.Read())
                    {
                        NrReader.Read();
                        Client = NrReader.GetString(2).ToString();
                        cAdresa = NrReader.GetString(3).ToString();
                        cCod_fiscal = NrReader.GetString(4).ToString();
                        cCont = NrReader.GetString(5).ToString();
                        cBanca = NrReader.GetString(6).ToString();
                        NrRegC = NrReader.GetString(7).ToString();
                        cSediu = NrReader.GetString(8).ToString();

                        con.Close();

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

            //autocomplete autovehicule
            #region Repopulare auto
            {

                string sql = "SELECT * FROM Autovehicule WHERE ID_auto = '" + textBoxNRAuto + "' ";

                SqlCommand cmd = new SqlCommand(sql, con);


                SqlDataReader NrReader;
                try
                {
                    con.Open();
                    NrReader = cmd.ExecuteReader();

                    // while (NrReader.Read())
                    {
                        NrReader.Read();
                        NrInmatriculare= NrReader.GetString(1).ToString();
                        Remorca = NrReader.GetString(2).ToString();
                        Delegat = NrReader.GetString(3).ToString();
                        Buletin = NrReader.GetString(4).ToString();
                        NrAxe = NrReader.GetString(5).ToString();



                        con.Close();

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

        //#region BonCantar

        //public void CreateBonPdf()
        //{
        //    String DEST = Path.GetFullPath("bon-printat.pdf");
        //    String src = Path.GetFullPath("Bon cantar-model.pdf");
            
        //    FileInfo file = new FileInfo(DEST);
        //    file.Directory.Create();

        //    PdfFont font = PdfFontFactory.CreateFont(FontConstants.TIMES_ROMAN);
        //    //test modificare pdf

        //    PdfDocument pdfDoc = new PdfDocument(new PdfReader(src), new PdfWriter(DEST));
        //    PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
        //    form.SetGenerateAppearance(true);
        //    // form.FlattenFields();

        //    //sectiune furnizori
        //    form.GetField("DataListare").SetValue(DateTime.Now.ToString("dd.MM.yyyy"), font, 12);
        //    form.GetField("DataEmiterii").SetValue(dataOut, font, 12);
        //    form.GetField("Furnizor").SetValue(Furnizor, font, 12);
        //    form.GetField("C.I.F").SetValue(sCod_fiscal, font, 12);
        //    form.GetField("SediuF").SetValue(sAdresa, font, 12);
        //    form.GetField("Nr.Reg.Com").SetValue(NrRegF, font, 12);
        //    form.GetField("NrTichet1").SetValue(nrBon, font, 12);
        //    form.GetField("NrTichet").SetValue(nrBon, font, 12);

        //    //autovehicul

        //    form.GetField("NrTractor").SetValue(NrInmatriculare, font, 12);
        //    form.GetField("NrRemorca").SetValue(Remorca, font, 12);
        //    form.GetField("Conducator").SetValue(Delegat, font, 12);
        //    form.GetField("SeriaNrCond").SetValue(Buletin, font, 12);
        //    form.GetField("Configuratie1").SetValue(NrAxe, font, 12);
        //    //operator
        //    form.GetField("SeriaNrOp").SetValue(Operator_id, font, 12);
        //    form.GetField("Operator").SetValue(Operat, font, 12);

        //    //produs
        //    form.GetField("Natura").SetValue(Produs, font, 12);
        //    form.GetField("CodP").SetValue(textBoxCodP, font, 12);
        //    form.GetField("Tip").SetValue(Tip_produs, font, 12);

        //    //client
        //    form.GetField("DenumireC").SetValue(Client, font, 12);
        //    form.GetField("C.I.F.C").SetValue(cCod_fiscal, font, 12);
        //    form.GetField("AdresaC").SetValue(cAdresa, font, 12);
        //    form.GetField("Nr.Reg.Com.C").SetValue(NrRegC, font, 12);






        //    #region Bon2

        //    //sectiune furnizori
        //    form.GetField("DataListare1").SetValue(DateTime.Now.ToString("dd.MM.yyyy"), font, 12);
        //    form.GetField("DataEmiterii1").SetValue(dataOut, font, 12);
        //    form.GetField("Furnizor1").SetValue(Furnizor, font, 12);
        //    form.GetField("C.I.F1").SetValue(sCod_fiscal, font, 12);
        //    form.GetField("SediuF1").SetValue(sAdresa, font, 12);
        //    form.GetField("Nr.Reg.Com1").SetValue(NrRegF, font, 12);
           

        //    //autovehicul

        //    form.GetField("NrTractor1").SetValue(NrInmatriculare, font, 12);
        //    form.GetField("NrRemorca1").SetValue(Remorca, font, 12);
        //    form.GetField("Conducator1").SetValue(Delegat, font, 12);
        //    form.GetField("SeriaNrCond1").SetValue(Buletin, font, 12);
        //    form.GetField("Configuratie1").SetValue(NrAxe, font, 12);
        //    //operator
        //    form.GetField("SeriaNrOp1").SetValue(Operator_id, font, 12);
        //    form.GetField("Operator1").SetValue(Operat, font, 12);

        //    //produs
        //    form.GetField("Natura1").SetValue(Produs, font, 12);
        //    form.GetField("CodP1").SetValue(textBoxCodP, font, 12);
        //    form.GetField("Tip1").SetValue(Tip_produs, font, 12);

        //    //client
        //    form.GetField("DenumireC1").SetValue(Client, font, 12);
        //    form.GetField("C.I.F.C1").SetValue(cCod_fiscal, font, 12);
        //    form.GetField("AdresaC1").SetValue(cAdresa, font, 12);
        //    form.GetField("Nr.Reg.Com.C1").SetValue(NrRegC, font, 12);

        //    #endregion

        //    string sql = "SELECT * FROM Metrologie";

        //    SqlCommand cmd = new SqlCommand(sql, con);


        //    SqlDataReader NrReader;
        //    try
        //    {
        //        con.Open();
        //        NrReader = cmd.ExecuteReader();

        //        // while (NrReader.Read())
        //        {
        //            NrReader.Read();
        //            string sNrCantar = NrReader.GetString(0).ToString();
        //            string sSerie_indicator = NrReader.GetString(1).ToString();
        //            string sBuletin_metrologic = NrReader.GetString(2).ToString();
        //            string sClasa_precizie = NrReader.GetString(3).ToString();
        //            string sTip_cantarire = NrReader.GetString(4).ToString();

        //            string sTip_cantar = NrReader.GetString(6).ToString();

        //            form.GetField("TipCantarire").SetValue(sTip_cantarire, font, 12);
        //            form.GetField("ClasaPrecizie").SetValue(sClasa_precizie, font, 12);
        //            form.GetField("CodInsta").SetValue(sNrCantar, font, 12);
        //            form.GetField("TipCantar").SetValue(sTip_cantar, font, 12);

        //            form.GetField("TipCantarire1").SetValue(sTip_cantarire, font, 12);
        //            form.GetField("ClasaPrecizie1").SetValue(sClasa_precizie, font, 12);
        //            form.GetField("CodInsta1").SetValue(sNrCantar, font, 12);
        //            form.GetField("TipCantar1").SetValue(sTip_cantar, font, 12);
        //        }
        //    }
        //    catch (Exception ex)
        //    {


        //        MessageBox.Show(ex.Message);

        //    }
        //    finally
        //    {
        //        con.Close();

        //    }


        //    //punct incarcare
        //    string sql1 = "SELECT Punct_lucru, Societate FROM Societati";

        //    SqlCommand cmd1 = new SqlCommand(sql1, con);


        //    SqlDataReader NrReader1;
        //    try
        //    {
        //        con.Open();
        //        NrReader1 = cmd1.ExecuteReader();

        //        // while (NrReader.Read())
        //        {
        //            NrReader1.Read();

        //            string sPunct_incarcare = NrReader1.GetString(0).ToString();
        //            string sSocietate = NrReader1.GetString(1).ToString();


        //            form.GetField("PunctIncarcare").SetValue(sPunct_incarcare, font, 12);
        //            form.GetField("TipCantar").SetValue(sSocietate, font, 12);
        //            form.GetField("TipCantar1").SetValue(sSocietate, font, 12);

        //            form.GetField("PunctIncarcare1").SetValue(sPunct_incarcare, font, 12);
        //        }
        //    }
        //    catch (Exception ex)
        //    {


        //        MessageBox.Show(ex.Message);

        //    }
        //    finally
        //    {
        //        con.Close();

        //    }

        //    decimal net = Math.Abs(decimal.Parse(textBoxGreutateInt) - decimal.Parse(textBoxGreutateOut));

        //    //cantarire
        //    form.GetField("Tara").SetValue(textBoxGreutateInt, font, 12);
        //    form.GetField("Brut").SetValue(textBoxGreutateOut, font, 12);
        //    form.GetField("Net").SetValue(net.ToString(), font, 12);
        //    form.GetField("dataIn").SetValue(dataInt, font, 12);
        //    form.GetField("dataOut").SetValue(dataOut, font, 12);

        //    //cantarire
        //    form.GetField("Tara1").SetValue(textBoxGreutateInt, font, 12);
        //    form.GetField("Brut1").SetValue(textBoxGreutateOut, font, 12);
        //    form.GetField("Net1").SetValue(net.ToString(), font, 12);
        //    form.GetField("dataIn1").SetValue(dataInt, font, 12);
        //    form.GetField("dataOut1").SetValue(dataOut, font, 12);
        //    form.FlattenFields();
        //    pdfDoc.Close();


        //    System.Diagnostics.Process.Start(DEST);
        //}

        //#endregion

        //#region AvizSiBon
        //public void CreateAvizPdf()
        //{
        //    String DEST = Path.GetFullPath("Aviz marfa.pdf");
        //    String src = Path.GetFullPath("Bon si Aviz-model.pdf");

            
        //    FileInfo file = new FileInfo(DEST);
        //    file.Directory.Create();

        //    PdfFont font = PdfFontFactory.CreateFont(FontConstants.TIMES_ROMAN);
        //    //test modificare pdf

        //    PdfDocument pdfDoc = new PdfDocument(new PdfReader(src), new PdfWriter(DEST));
        //    PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
        //    form.SetGenerateAppearance(true);
        //    // form.FlattenFields();

        //    //Data si nr aviz
        //    form.GetField("Data1").SetValue(dataOut, font, 12);
        //    form.GetField("NumarAviz1").SetValue(textBoxNrDoc, font, 12);

        //    //sectiune furnizori
        //    form.GetField("Furnizor1").SetValue(Furnizor, font, 10);
        //    form.GetField("CodFiscalF1").SetValue(sCod_fiscal, font, 10);
        //    form.GetField("SediuF1").SetValue(sAdresa, font, 10);
        //    form.GetField("PunctLucru1").SetValue(sAdresa, font, 10);
        //    form.GetField("CodIBANF1").SetValue(sCont, font, 10);
        //    form.GetField("BancaF1").SetValue(sBanca, font, 10);
        //    form.GetField("NrOrdF1").SetValue(NrRegF, font, 10);
        //    form.GetField("NrTichet").SetValue(nrBon, font, 12);
        //    //Date expeditie

        //    form.GetField("NrAuto1").SetValue(NrInmatriculare, font, 12);
        //    form.GetField("NumeDelegat1").SetValue(Delegat, font, 12);
        //    form.GetField("CiSeria1").SetValue(Buletin, font, 12);
        //    form.GetField("Data21").SetValue(dataOut, font, 12);

        //    //produs
        //    form.GetField("Produs1").SetValue(Produs, font, 12);


        //    //client
        //    form.GetField("Cumparator1").SetValue(Client, font, 10);
        //    form.GetField("CodFiscalC1").SetValue(cCod_fiscal, font, 10);
        //    form.GetField("SediuC1").SetValue(cAdresa, font, 10);
        //    form.GetField("ContIBANC1").SetValue(cCont, font, 10);
        //    form.GetField("BancaC1").SetValue(cBanca, font, 10);
        //    form.GetField("NrOrdC1").SetValue(NrRegC, font, 10);


        //    decimal net = Math.Abs(decimal.Parse(textBoxGreutateInt) - decimal.Parse(textBoxGreutateOut));

        //    //cantarire
        //    form.GetField("Tara1").SetValue(textBoxGreutateInt, font, 12);
        //    form.GetField("Brut1").SetValue(textBoxGreutateOut, font, 12);
        //    form.GetField("Net1").SetValue(net.ToString(), font, 12);
           
        //    //bonnn
        //    //sectiune furnizori
        //    form.GetField("DataListare").SetValue(DateTime.Now.ToString("dd.MM.yyyy"), font, 12);
        //    form.GetField("DataEmiterii").SetValue(dataOut, font, 12);
        //    form.GetField("Furnizor").SetValue(Furnizor, font, 12);
        //    form.GetField("C.I.F").SetValue(sCod_fiscal, font, 12);
        //    form.GetField("SediuF").SetValue(sAdresa, font, 12);
        //    form.GetField("Nr.Reg.Com").SetValue(NrRegF, font, 12);

        //    //autovehicul

        //    form.GetField("NrTractor").SetValue(NrInmatriculare, font, 12);
        //    form.GetField("NrRemorca").SetValue(Remorca, font, 12);
        //    form.GetField("Conducator").SetValue(Delegat, font, 12);
        //    form.GetField("SeriaNrCond").SetValue(Buletin, font, 12);
        //    form.GetField("Configuratie").SetValue(NrAxe, font, 12);

        //    //operator
        //    form.GetField("SeriaNrOp").SetValue(Operator_id, font, 12);
        //    form.GetField("Operator").SetValue(Operat, font, 12);

        //    //produs
        //    form.GetField("Natura").SetValue(Produs, font, 12);
        //    form.GetField("CodP").SetValue(textBoxCodP, font, 12);
        //    form.GetField("Tip").SetValue(Tip_produs, font, 12);

        //    //client
        //    form.GetField("DenumireC").SetValue(Client, font, 12);
        //    form.GetField("C.I.F.C").SetValue(cCod_fiscal, font, 12);
        //    form.GetField("AdresaC").SetValue(cAdresa, font, 12);
        //    form.GetField("Nr.Reg.Com.C").SetValue(NrRegC, font, 12);

        //    string sql = "SELECT * FROM Metrologie";

        //    SqlCommand cmd = new SqlCommand(sql, con);


        //    SqlDataReader NrReader;
        //    try
        //    {
        //        con.Open();
        //        NrReader = cmd.ExecuteReader();

        //        // while (NrReader.Read())
        //        {
        //            NrReader.Read();
        //            string sNrCantar = NrReader.GetString(0).ToString();
        //            string sSerie_indicator = NrReader.GetString(1).ToString();
        //            string sBuletin_metrologic = NrReader.GetString(2).ToString();
        //            string sClasa_precizie = NrReader.GetString(3).ToString();
        //            string sTip_cantarire = NrReader.GetString(4).ToString();

        //            string sTip_cantar = NrReader.GetString(6).ToString();

        //            form.GetField("TipCantarire").SetValue(sTip_cantarire, font, 12);
        //            form.GetField("ClasaPrecizie").SetValue(sClasa_precizie, font, 12);
        //            form.GetField("CodInsta").SetValue(sNrCantar, font, 12);
        //            form.GetField("TipCantar").SetValue(sTip_cantar, font, 12);



        //        }
        //    }
        //    catch (Exception ex)
        //    {


        //        MessageBox.Show(ex.Message);

        //    }
        //    finally
        //    {
        //        con.Close();

        //    }

        //    //punct incarcare
        //    string sql1 = "SELECT Punct_lucru, Societate FROM Societati";

        //    SqlCommand cmd1 = new SqlCommand(sql1, con);


        //    SqlDataReader NrReader1;
        //    try
        //    {
        //        con.Open();
        //        NrReader1 = cmd1.ExecuteReader();

        //        // while (NrReader.Read())
        //        {
        //            NrReader1.Read();

        //            string sPunct_incarcare = NrReader1.GetString(0).ToString();

        //            string sSocietate = NrReader1.GetString(1).ToString();


        //            form.GetField("PunctIncarcare").SetValue(sPunct_incarcare, font, 12);
        //            form.GetField("TipCantar").SetValue(sSocietate, font, 12);

                    



        //        }
        //    }
        //    catch (Exception ex)
        //    {


        //        MessageBox.Show(ex.Message);

        //    }
        //    finally
        //    {
        //        con.Close();

        //    }


        //    //cantarire
        //    form.GetField("Tara").SetValue(textBoxGreutateInt, font, 12);
        //    form.GetField("Brut").SetValue(textBoxGreutateOut, font, 12);
        //    form.GetField("Net").SetValue(net.ToString(), font, 12);
        //    form.GetField("dataIn").SetValue(dataInt, font, 12);
        //    form.GetField("dataOut").SetValue(dataOut, font, 12);

        //    form.FlattenFields();
        //    pdfDoc.Close();


        //    System.Diagnostics.Process.Start(DEST);
        //}
        //#endregion

        private void button3_Click(object sender, EventArgs e)
        {

            if (comboBoxTipDocument == "Aviz")
            {
               // CreateAvizPdf();
            }
            else
            if (comboBoxTipDocument == "Factura")
            {


               // CreateBonPdf();
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