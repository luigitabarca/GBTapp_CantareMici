using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Forms;
using iText.IO.Font;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using GBTapp_CantareMici.DAL;
using GBTapp_CantareMici.BLL;
using GBTapp_CantareMici.UI;
using GBTapp_CantareMici.FCN;

namespace GBTapp_CantareMici.FCN
{
    class PdfFile
    {
        SqlConnection con = new SqlConnection();
        

        public string DetinatorCantar { get; set; }
        public string CodInstalatie { get; set; }
        public string TipCantarire { get; set; }
        public string ClasaDePrecizie { get; set; }
        public string PunctDeIncarcare { get; set; }
        public string NrTichet { get; set; }
        public string DataTichet { get; set; }
        public string DenumireFurnizor { get; set; }
        public string CifFurnizor { get; set; }
        public string AdresaFurnizor { get; set; }
        public string DenumireClient { get; set; }
        public string CifClient { get; set; }
        public string AdresaClient { get; set; }
        public string NaturaProdus { get; set; }
        public string DenumireProdus { get; set; }
        public string CodProdus { get; set; }
        public string LotProdus { get; set; }
        public string DataExpirariiProdus { get; set; }
        public string GreutateTara { get; set; }
        public string GreutateBrut { get; set; }
        public string GreutateNeta { get; set; }


        public void CreazaBonPdf()
        {

            String DEST = Path.GetFullPath("bon-printat.pdf");
            String src = Path.GetFullPath("Bon_cantar_mic.pdf");

            FileInfo file = new FileInfo(DEST);
            file.Directory.Create();

            PdfFont font = PdfFontFactory.CreateFont(FontConstants.TIMES_ROMAN);
            //test modificare pdf

            PdfDocument pdfDoc = new PdfDocument(new PdfReader(src), new PdfWriter(DEST));
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
            form.SetGenerateAppearance(true);
            // form.FlattenFields();
            #region bon1

            //
            //sectiune header 
            form.GetField("DetinatorCantar").SetValue(DetinatorCantar, font, 10);
            form.GetField("CodInstalatie").SetValue(CodInstalatie, font, 10);
            form.GetField("TipCantarire").SetValue(TipCantarire, font, 10);
            form.GetField("ClasaDePrecizie").SetValue(ClasaDePrecizie, font, 10);
            form.GetField("PunctDeIncarcare").SetValue(PunctDeIncarcare, font, 10);
            form.GetField("NrTichet").SetValue(NrTichet, font, 12);
            form.GetField("DataTichet").SetValue(DataTichet, font, 12);
            //
            //sectiune furnizori
            form.GetField("DenumireFurnizor").SetValue(DenumireFurnizor, font, 12);
            form.GetField("CifFurnizor").SetValue(CifFurnizor, font, 12);
            form.GetField("AdresaFurnizor").SetValue(AdresaFurnizor, font, 12);
            //
            //sectiune clienti
            form.GetField("DenumireClient").SetValue(DenumireClient, font, 12);
            form.GetField("CifClient").SetValue(CifClient, font, 12);
            form.GetField("AdresaClient").SetValue(AdresaClient, font, 12);
            //
            // sectiune produs
            form.GetField("NaturaProdus").SetValue(NaturaProdus, font, 12);
            form.GetField("DenumireProdus").SetValue(DenumireProdus, font, 12);
            form.GetField("CodProdus").SetValue(CodProdus, font, 12);
            form.GetField("LotProdus").SetValue(LotProdus, font, 12);
            form.GetField("DataExpirariiProdus").SetValue(DataExpirariiProdus, font, 12);
            //
            // sectiune greutate
            form.GetField("GreutateTara").SetValue(GreutateTara, font, 12);
            form.GetField("GreutateBrut").SetValue(GreutateBrut, font, 12);
            form.GetField("GreutateNeta").SetValue(GreutateNeta, font, 12);

            #endregion

            #region bon2

            //
            //sectiune header 
            form.GetField("DetinatorCantar1").SetValue(DetinatorCantar, font, 10);
            form.GetField("CodInstalatie1").SetValue(CodInstalatie, font, 10);
            form.GetField("TipCantarire1").SetValue(TipCantarire, font, 10);
            form.GetField("ClasaDePrecizie1").SetValue(ClasaDePrecizie, font, 10);
            form.GetField("PunctDeIncarcare1").SetValue(PunctDeIncarcare, font, 10);
            form.GetField("NrTichet1").SetValue(NrTichet, font, 12);
            form.GetField("DataTichet1").SetValue(DataTichet, font, 12);
            //
            //sectiune furnizori
            form.GetField("DenumireFurnizor1").SetValue(DenumireFurnizor, font, 12);
            form.GetField("CifFurnizor1").SetValue(CifFurnizor, font, 12);
            form.GetField("AdresaFurnizor1").SetValue(AdresaFurnizor, font, 12);
            //
            //sectiune clienti
            form.GetField("DenumireClient1").SetValue(DenumireClient, font, 12);
            form.GetField("CifClient1").SetValue(CifClient, font, 12);
            form.GetField("AdresaClient1").SetValue(AdresaClient, font, 12);
            //
            // sectiune produs
            form.GetField("NaturaProdus1").SetValue(NaturaProdus, font, 12);
            form.GetField("DenumireProdus1").SetValue(DenumireProdus, font, 12);
            form.GetField("CodProdus1").SetValue(CodProdus, font, 12);
            form.GetField("LotProdus1").SetValue(LotProdus, font, 12);
            form.GetField("DataExpirariiProdus1").SetValue(DataExpirariiProdus, font, 12);
            //
            // sectiune greutate
            form.GetField("GreutateTara1").SetValue(GreutateTara, font, 12);
            form.GetField("GreutateBrut1").SetValue(GreutateBrut, font, 12);
            form.GetField("GreutateNeta1").SetValue(GreutateNeta, font, 12);

            #endregion

            form.FlattenFields();
            pdfDoc.Close();
            System.Diagnostics.Process.Start(DEST);
        }

        public void IncarcaHeader()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            //punct incarcare
            string sql1 = "SELECT Punct_lucru, Societate FROM Societati";

            SqlCommand cmd1 = new SqlCommand(sql1, con);


            SqlDataReader NrReader1;
            try
            {
                con.Open();
                NrReader1 = cmd1.ExecuteReader();
                {
                    NrReader1.Read();
                    PunctDeIncarcare = NrReader1.GetString(0).ToString();
                    DetinatorCantar = NrReader1.GetString(1).ToString();  
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }

            //date metrologice
            string sql = "SELECT * FROM Metrologie";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader NrReader;
            try
            {
                con.Open();
                NrReader = cmd.ExecuteReader();
                {
                    NrReader.Read();
                    CodInstalatie = NrReader.GetString(1).ToString();
                    ClasaDePrecizie = NrReader.GetString(3).ToString();
                    TipCantarire = NrReader.GetString(4).ToString();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
        }
        







    }
}
