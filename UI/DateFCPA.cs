using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GBTapp_CantareMici.UI
{
    public partial class DateFCPA : Form
    {
        public DateFCPA()
        {
            InitializeComponent();
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            Produse f = new Produse();
            f.TopMost = true;
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clienti f = new Clienti();
            f.TopMost = true;
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Furnizori f = new Furnizori();
            f.TopMost = true;
            f.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MyGlobals.isOpen = false;

            this.Close();
        }
    }
}
