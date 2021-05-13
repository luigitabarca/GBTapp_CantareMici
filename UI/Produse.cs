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
    public partial class Produse : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        public Produse()
        {
            InitializeComponent();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        }

        ProduseBLL a = new ProduseBLL();
        ProduseDAL dal = new ProduseDAL();


        public void Clear()
        {
            textBoxProdus.Text = "";
            textBoxCodP.Text = "";
            textBoxDataExp.Text = "";
            textBoxLot.Text = "";
            textBoxTipProdus.Text = "";
        }

        public bool isEmplty()
        {
            bool isempty = false;
            if (textBoxProdus.Text == "" || textBoxCodP.Text == "" || textBoxDataExp.Text == "" || textBoxLot.Text == "" || textBoxTipProdus.Text == "")
                isempty = true;
            return isempty;
        }

        private void Autovehicule_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select(con);
            dataGridViewProduse.DataSource = dt;
            dataGridViewProduse.Columns["ID_produs"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isempty = isEmplty();
            if (isempty == false)
            {
                a.ID_produs = textBoxTipProdus.Text + textBoxLot.Text;
                a.Cod = textBoxCodP.Text;
                a.Nume = textBoxTipProdus.Text;
                a.Natura = textBoxProdus.Text;
                a.Lot = textBoxLot.Text;
                a.DataExpirare = textBoxDataExp.Text;

                bool success = dal.Insert(a, con);

                if (success == true)
                {
                    MessageBox.Show("Produs adaugat cu succes ");

                    DataTable dt = dal.Select(con);
                    dataGridViewProduse.DataSource = dt;

                    Clear();
                }
                else
                {
                    MessageBox.Show("Nu se poate adauga produsul specificat incercati din nou alt tip de produs");
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
                a.ID_produs = textBoxTipProdus.Text + textBoxLot.Text;
                a.Cod = textBoxCodP.Text;
                a.Nume = textBoxTipProdus.Text;
                a.Natura = textBoxProdus.Text;
                a.Lot = textBoxLot.Text;
                a.DataExpirare = textBoxDataExp.Text;

                bool success = dal.Update(a, con);

                if (success == true)
                {
                    MessageBox.Show("Produs modificat cu succes ");

                    DataTable dt = dal.Select(con);
                    dataGridViewProduse.DataSource = dt;

                    Clear();
                }
                else
                {
                    MessageBox.Show("Nu se poate face modificarea ");
                }
            }
            else
            {
                MessageBox.Show("Completati toate campurile");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            a.ID_produs = idProdus;

            bool success = dal.Delete(a,con);

            if (success == true)
            {
                MessageBox.Show("Stergerea s-a facut cu succes");

                DataTable dt = dal.Select(con);
                dataGridViewProduse.DataSource = dt;

                Clear();


            }
            else
            {
                MessageBox.Show("Produsul este continut de un raport si nu poate fi sters. stergeti rapoartele care contin produsele mai intai ");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public string  idProdus;
        private void dataGridViewAutovehicule_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int RowIndex = e.RowIndex;
           idProdus= dataGridViewProduse.Rows[RowIndex].Cells[0].Value.ToString();
            textBoxCodP.Text=dataGridViewProduse.Rows[RowIndex].Cells[1].Value.ToString(); 
            textBoxProdus.Text = dataGridViewProduse.Rows[RowIndex].Cells[2].Value.ToString();
            textBoxTipProdus.Text = dataGridViewProduse.Rows[RowIndex].Cells[5].Value.ToString();
            textBoxLot.Text = dataGridViewProduse.Rows[RowIndex].Cells[4].Value.ToString();
            textBoxDataExp.Text = dataGridViewProduse.Rows[RowIndex].Cells[3].Value.ToString();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            MyGlobals.isOpen = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBoxLot_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBoxDataExp_KeyPress(object sender, KeyPressEventArgs e)
        {

            
        }
    }
}
