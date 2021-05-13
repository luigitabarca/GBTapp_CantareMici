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
using GBTapp_CantareMici.DAL;
using GBTapp_CantareMici.BLL;
using System.Configuration;

namespace GBTapp_CantareMici.UI
{
    public partial class SerialPort : Form
    {

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();

        public SerialPort()
        {
            InitializeComponent();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            cmdClose.Enabled = false;
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames())
            {
                txtPort.Items.Add(s);
            }
        }

        PortBLL p = new PortBLL();
        PortDAL pdal = new PortDAL();

        public System.IO.Ports.SerialPort sport;

        public void serialport_connect(String port, int baudrate, Parity parity, int databits, StopBits stopbits)
        {

            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();

            sport = new System.IO.Ports.SerialPort(
            port, baudrate, parity, databits, stopbits);
            try
            {
                sport.Open();
                cmdClose.Enabled = true;
                cmdConnect.Enabled = false;
                txtReceive.AppendText("[" + dtn + "] " + "Connected\n");
                sport.DataReceived += new SerialDataReceivedEventHandler(sport_DataReceived);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error"); }
        }

        private void sport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();

            
            

                sport.DtrEnable = true;
                sport.RtsEnable = true;

                int bytes = sport.BytesToRead;
                byte[] buffer = new byte[bytes];
                byte[] buffer1 = new byte[bytes];
                sport.Read(buffer, 0, bytes);



                if (bytes >= 22)
                {


                    //Buffer.BlockCopy(buffer, 1, buffer1, 0, 11);
                    string g = System.Text.Encoding.ASCII.GetString(buffer);

                    txtReceive.AppendText("[" + dtn + "] " + "Received: " + g + "\n");

                }
                 TextBox.CheckForIllegalCrossThreadCalls = false;
                //txtReceive.AppendText("[" + dtn + "] " + "Received: " + g + "\n");
            
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {
            String port = txtPort.Text;
            int baudrate = Convert.ToInt32(cmbbaudrate.Text);
            Parity parity = (Parity)Enum.Parse(typeof(Parity), cmbparity.Text);
            int databits = Convert.ToInt32(cmbdatabits.Text);
            StopBits stopbits = (StopBits)Enum.Parse(typeof(StopBits), cmbstopbits.Text);

            serialport_connect(port, baudrate, parity, databits, stopbits);

            DataTable dt;
           
            dt = pdal.Select(con);
            string port_existent = "";
            if (dt.Rows.Count > 0)
            {
                 port_existent = dt.Rows[0].ItemArray[0].ToString();
            }
            p.Port= txtPort.Text;
            p.Baudrate = cmbbaudrate.Text;
            p.Parity = cmbparity.Text;
            p.Databits = cmbdatabits.Text;
            p.Stopbits = cmbstopbits.Text;
            
                bool success3 = pdal.Delete(p, con);
                bool success2 = pdal.Insert(p, con);
                if (success2 == true)
                {
                    MessageBox.Show("Date salvate");

                }
                else
                {
                    MessageBox.Show("Nu s a putut salva date comunicare");
                }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();
            String data = txtDatatoSend.Text;
            sport.Write(data);
            txtReceive.AppendText("[" + dtn + "] " + "Sent: " + data + "\n");
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();

            if (sport.IsOpen)
            {
                sport.Close();
                cmdClose.Enabled = false;
                cmdConnect.Enabled = true;
                txtReceive.AppendText("[" + dtn + "] " + "Disconnected\n");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MyGlobals.isOpen = false;
            this.Close();
        }

        private void SerialPort_Load(object sender, EventArgs e)
        {

        }











        /*
                private void button1_Click(object sender, EventArgs e)
                {
                    String port = txtPort.Text;
                    int baudrate = Convert.ToInt32(cmbbaudrate.Text);
                    Parity parity = (Parity)Enum.Parse(typeof(Parity), cmbparity.Text);
                    int databits = Convert.ToInt32(cmbdatabits.Text);
                    StopBits stopbits = (StopBits)Enum.Parse(typeof(StopBits), cmbstopbits.Text);

                    serialport_connect(port, baudrate, parity, databits, stopbits);
                }
                */
    }
}
