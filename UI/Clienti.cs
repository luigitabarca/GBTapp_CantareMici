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
    public partial class Clienti : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        public Clienti()
        {
            InitializeComponent();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        }

        ClientiBLL a = new ClientiBLL();
        ClientiDAL dal = new ClientiDAL();


        public void Clear()
        {
            textBoxClient.Text = "";
            textBoxAdresaC.Text = "";
            textBoxCifC.Text = "";
       
        }

        public bool isEmplty()
        {
            bool isempty = false;
            if (textBoxClient.Text == "" || textBoxAdresaC.Text == "" || textBoxCifC.Text == "" )
                isempty = true;
            return isempty;
        }

        private void Autovehicule_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select(con);
            dataGridViewClienti.DataSource = dt;
            dataGridViewClienti.Columns["ID_client"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isempty = isEmplty();
            if (isempty == false)
            {
                a.ID_client = textBoxCifC.Text + textBoxAdresaC.Text; ;
                a.Nume=  textBoxClient.Text ;
                a.Adresa= textBoxAdresaC.Text;
                a.Cod_fiscal=  textBoxCifC.Text ;
                

                bool success = dal.Insert(a,con);

                if (success == true)
                {
                    MessageBox.Show("Client adaugat cu succes ");

                    DataTable dt = dal.Select(con);
                    dataGridViewClienti.DataSource = dt;

                    Clear();
                }
            }
            else
            {
                MessageBox.Show("Completati toate campurile");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool isempty = isEmplty();
            if (isempty == false)
            {
                a.ID_client =  textBoxCifC.Text + textBoxAdresaC.Text; ;
                a.Nume = textBoxClient.Text;
                a.Adresa = textBoxAdresaC.Text;
                a.Cod_fiscal = textBoxCifC.Text;
               
                bool success = dal.Update(a, con);

                if (success == true)
                {
                    MessageBox.Show("Client modificat cu succes ");

                    DataTable dt = dal.Select(con);
                    dataGridViewClienti.DataSource = dt;

                    Clear();
                }
                else
                {

                MessageBox.Show("Clientul nu poate fi modificat de aceea va fi adaugata o intrare noua cu aceste date ");
                bool success1 = dal.Insert(a, con);
                if (success1 == true)
                    {
                        MessageBox.Show("Client adaugat cu succes ");

                        DataTable dt = dal.Select(con);
                        dataGridViewClienti.DataSource = dt;

                        Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Completati toate campurile");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            a.ID_client = idClient;

            bool success = dal.Delete(a,con);

            if (success == true)
            {
                MessageBox.Show("Stergerea s-a facut cu succes");

                DataTable dt = dal.Select(con);
                dataGridViewClienti.DataSource = dt;

                Clear();


            }
            else
            {
                MessageBox.Show("Clientul este continut de un raport si nu poate fi sters. stergeti rapoartele care contin produsele mai intai ");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private string idClient;

        

        private void dataGridViewAutovehicule_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int RowIndex = e.RowIndex;
            idClient = dataGridViewClienti.Rows[RowIndex].Cells[0].Value.ToString();
            textBoxClient.Text = dataGridViewClienti.Rows[RowIndex].Cells[1].Value.ToString();
            textBoxAdresaC.Text = dataGridViewClienti.Rows[RowIndex].Cells[2].Value.ToString();
            textBoxCifC.Text = dataGridViewClienti.Rows[RowIndex].Cells[3].Value.ToString();
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            MyGlobals.isOpen = false;
        }
    }
}
