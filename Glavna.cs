using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekat_2026_StefanAndrejevic
{
    public partial class Glavna : Form
    {
        int KorisnikId;
        public Glavna(int KorisnikId)
        {
            InitializeComponent();
            this.KorisnikId = KorisnikId;
        }


        private void Glavna_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BtnRezervisi_Click(object sender, EventArgs e)
        {
            CalendarPopUp calendar = new CalendarPopUp(KorisnikId);
            calendar.ParentForm = this;
            calendar.ShowDialog();
        }
    }
}
