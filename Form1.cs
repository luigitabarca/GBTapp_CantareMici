using GBTapp_CantareMici.DAL;
using GBTapp_CantareMici.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.SqlClient;
using System.Configuration;



namespace GBTapp_CantareMici
{
    public partial class Form1 : Form
    {
        public System.IO.Ports.SerialPort sport;
        public string greutateGlobala = "0";
        SqlConnection con = new SqlConnection();

        FurnizoriBLL f = new FurnizoriBLL();
        FurnizoriDAL fdal = new FurnizoriDAL();



        public Form1()
        {
            InitializeComponent();

            con.ConnectionString = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        }

        public string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }




        public void serialport_connect(String port, int baudrate, Parity parity, int databits, StopBits stopbits)
        {
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();

            sport = new System.IO.Ports.SerialPort(
            port, baudrate, parity, databits, stopbits);
            sport.Handshake = Handshake.RequestToSend;

            


            try
            {
                sport.Open();
                
                sport.DataReceived += new SerialDataReceivedEventHandler(sport_DataReceived);
            }
            catch (Exception ex) { MessageBox.Show("Portul selectat pentru primirea informatiei de la cantar nu este conectat, Veti putea face doar cantariri manuale", "Eroare"); }


        }

        private void sport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            TextBox.CheckForIllegalCrossThreadCalls = false;

            #region displ1 substing
            string gr = sport.ReadLine();
            string greg = gr.Substring(2, 11);
            string g = RemoveWhitespace(greg);
            
            
            
            
            textBoxGreutateSenzor.Text = g;
            
            greutateGlobala = textBoxGreutateSenzor.Text;
            
            #endregion
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxFurnizor_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Furnizori WHERE Nume = '" + textBoxFurnizor.Text + "' ";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader NrReader;

            try
            {
                con.Open();
                NrReader = cmd.ExecuteReader();

                while (NrReader.Read())
                {
                    string sAdresa = NrReader.GetString(3).ToString();
                    string sCod_fiscal = NrReader.GetString(2).ToString();
                    textBoxAdresaF.Text = sAdresa;
                    textBoxCifF.Text = sCod_fiscal; 
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

        private void textBoxClient_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Clienti WHERE Nume = '" + textBoxClient.Text + "' "; 
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader NrReader;
            try
            {
                con.Open();
                NrReader = cmd.ExecuteReader();

                while (NrReader.Read())
                {
                    string sAdresa = NrReader.GetString(3).ToString();
                    string sCod_fiscal = NrReader.GetString(2).ToString();
                    textBoxAdresaC.Text = sAdresa;
                    textBoxCifC.Text = sCod_fiscal;
                    


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

        private void textBoxTipProdus_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Produse WHERE Nume = '" + textBoxTipProdus.Text + "' ";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader NrReader;

            try
            {
                con.Open();
                NrReader = cmd.ExecuteReader();

                while (NrReader.Read())
                {
                    string sCod_produs = NrReader.GetString(3).ToString();
                    string sLot = NrReader.GetString(4).ToString();
                    string sData = NrReader.GetString(5).ToString();
                    string sNatura = NrReader.GetString(2).ToString();
                    textBoxProdus.Text = sNatura;
                    textBoxCodP.Text = sCod_produs;
                    textBoxLot.Text = sLot;
                    textBoxDataExp.Text = sData;
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

        private void buttonPreluareGreutate_Click(object sender, EventArgs e)
        {
            if (textBoxGreutateSenzor.Text != "\n ")
            {
                bool isNumber = int.TryParse(textBoxGreutateSenzor.Text, out int valoare);
                // MessageBox.Show("nu are sfarsitiu");

                if (isNumber && valoare > 0)
                {
                    //MessageBox.Show("nu e numar mai mare ca 0");
                    if (textBoxGreutateTara.Text == "" )
                    {
                        textBoxGreutateTara.Text = greutateGlobala;
                    }
                    else
                    {
                        textBoxGreutateBrut.Text = greutateGlobala;
                        float greutateNeta = Math.Abs(float.Parse(textBoxGreutateBrut.Text) - float.Parse(textBoxGreutateTara.Text));
                        textBoxGreutateNet.Text = greutateNeta.ToString();
                    }
                }
            }
        }

        #region AutocompleteSourceText
        //autocomplete furnizori
        private void autocompleteFurnizori()
        {
            string sql = "SELECT Nume FROM Furnizori";

            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection FurnizoriColection = new AutoCompleteStringCollection();

            while (dr.Read())
            {
                FurnizoriColection.Add(dr.GetString(0));
            }

            textBoxFurnizor.AutoCompleteCustomSource = FurnizoriColection;
            con.Close();
        }

        //autocomplete clienti 
        private void autocompleteClienti()
        {
            string sql = "SELECT Nume FROM Clienti";

            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection ClientiColection = new AutoCompleteStringCollection();

            while (dr.Read())
            {
                ClientiColection.Add(dr.GetString(0));
            }

            textBoxClient.AutoCompleteCustomSource = ClientiColection;
            con.Close();
        }

        //autocomplete produse 
        private void autocompleteProduse()
        {
            string sql = "SELECT Nume FROM Produse";

            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection ProduseColection = new AutoCompleteStringCollection();

            while (dr.Read())
            {
                ProduseColection.Add(dr.GetString(0));
            }

            textBoxTipProdus.AutoCompleteCustomSource = ProduseColection;
            con.Close();
        }


        #endregion

        private void textBoxTaraIndrodusa_TextChanged(object sender, EventArgs e)
        {
            textBoxGreutateTara.Text = textBoxTaraIndrodusa.Text;
        }

        private void button_inchidere_Click(object sender, EventArgs e)
        {
            
            this.Close();
            Application.Exit();
        }

        private void button_minimizare_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void buttonPrintTicet_Click(object sender, EventArgs e)
        {
            #region Adaugare Furnizor
            {
                string sqlf = "SELECT COUNT(*) FROM Furnizori WHERE Nume = '" + textBoxCifF.Text + "' ";

                SqlCommand cmdf = new SqlCommand(sqlf, con);
                con.Open();

                int valoaref = Convert.ToInt32(cmdf.ExecuteScalar());
                con.Close();

                if (valoaref == 0)
                {
                    f.Nume = textBoxFurnizor.Text;
                    f.Adresa = textBoxAdresaF.Text;
                    f.Cod_fiscal = textBoxCifF.Text;
                    
                    bool success1 = fdal.Insert(f, con);
                    if (success1 == true)
                    {
                        MessageBox.Show("Furnizorul  a fost adaugat");
                        autocompleteFurnizori();
                    }
                    else
                    {
                        MessageBox.Show("Nu s a putut adauga furnizor");
                    }


                }
            }
            #endregion
        }
    }
}
