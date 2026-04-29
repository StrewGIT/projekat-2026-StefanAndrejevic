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
    public partial class RezervisanjeMesta : Form
    {
        int KorisnikId;
        DateTime datum;
        public RezervisanjeMesta(int KorisnikId,DateTime datum)
        {
            InitializeComponent();
            this.datum = datum;
            this.KorisnikId = KorisnikId;
        }

        private void RezervisanjeMesta_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
