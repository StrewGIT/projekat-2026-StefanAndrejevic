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
    public partial class CalendarPopUp : Form
    {
        int KorisnikId;
        public Form ParentForm { get; set; }
        public CalendarPopUp(int KorisnikId)
        {
            InitializeComponent();
            this.KorisnikId = KorisnikId;
        }

        private void BtnIzaberiMesto_Click(object sender, EventArgs e)
        {
            this.ParentForm.Hide();
            RezervisanjeMesta rezervisanje_mesta = new RezervisanjeMesta(KorisnikId, Calendar.SelectionStart);
            rezervisanje_mesta.Show();
            this.Close();
        }

        private void CalendarPopUp_Load(object sender, EventArgs e)
        {
            Calendar.TodayDate = DateTime.Now;
            Calendar.MaxDate = Calendar.TodayDate + new System.TimeSpan(10,0,0,0);
            Calendar.MinDate = Calendar.TodayDate;
        }
    }
}
