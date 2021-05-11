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


namespace GBTapp_CantareMici
{
    public partial class Form1 : Form
    {
        public System.IO.Ports.SerialPort sport;
        public string greutateGlobala = "0";


        public Form1()
        {
            InitializeComponent();
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
    }
}
