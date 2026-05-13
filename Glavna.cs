using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace projekat_2026_StefanAndrejevic
{
    public partial class Glavna : Form
    {
        int KorisnikId;
        private bool ExitApp = true;
        private Form parent;
        public Glavna(int KorisnikId,Form parent)
        {
            InitializeComponent();
            this.KorisnikId = KorisnikId;
            this.parent = parent;
        }

        private void Glavna_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                return;
            }
            if (ExitApp)
            {
                Application.Exit();
            }
            else
            {
                parent.Show();
            }
        }

        private void BtnRezervisi_Click(object sender, EventArgs e)
        {
            CalendarPopUp calendar = new CalendarPopUp(KorisnikId);
            calendar.ParentForm = this;
            calendar.ShowDialog();
        }

        private void BtnMojiRacuni_Click(object sender, EventArgs e)
        {
            MojiRacuni forma = new MojiRacuni(KorisnikId);
            forma.ShowDialog();
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            ExitApp = false;
            this.Close();
        }
    }
}
