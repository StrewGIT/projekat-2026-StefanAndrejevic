using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace projekat_2026_StefanAndrejevic
{
    public partial class MojiRacuni : Form
    {
        private readonly int KorisnikId;
        private int OdabraniRacunId = -1;

        public MojiRacuni(int KorisnikId)
        {
            InitializeComponent();
            this.KorisnikId = KorisnikId;
        }

        private void MojiRacuni_Load(object sender, EventArgs e)
        {
            UcitajRacune();
            OnemoguciBtnDetalji();
            DGridRacuni.ClearSelection();
        }

        // Ucitavanje i prikaz racuna

        private void UcitajRacune()
        {
            SqlConnection veza = Connection.Connect();
            string sql = @"Select * from viewRacuni
                WHERE rdk = @k";

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, veza);
                adapter.SelectCommand.Parameters.AddWithValue("@k", KorisnikId);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DGridRacuni.DataSource = dt;

                if (DGridRacuni.Columns.Contains("Racun ID"))
                    DGridRacuni.Columns["Racun ID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska pri ucitavanju racuna: " + ex.Message);
            }
        }

        private void UcitajArtikleRacuna(int racunId)
        {
            SqlConnection veza = Connection.Connect();
            string sql = @"
                SELECT a.naziv AS [Artikal], ra.kolicina AS [Kolicina], a.cena AS [Cena po kom],
                       ra.kolicina * a.cena AS [Ukupno]
                FROM RacunArtikal ra
                JOIN Artikal a ON ra.artikal = a.id
                WHERE ra.racun = @racun";
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, veza);
                adapter.SelectCommand.Parameters.AddWithValue("@racun", racunId);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DGridArtikliRacuna.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska pri ucitavanju artikala: " + ex.Message);
            }
        }

        // Selekcija reda u gridu

        private void DGridRacuni_SelectionChanged(object sender, EventArgs e)
        {
            if (DGridRacuni.CurrentRow == null) { OnemoguciBtnDetalji(); return; }

            var cell = DGridRacuni.CurrentRow.Cells["Racun ID"];
            if (cell?.Value == null || cell.Value == DBNull.Value) { OnemoguciBtnDetalji(); return; }

            OdabraniRacunId = Convert.ToInt32(cell.Value);
            OmoguciBtnDetalji();
            UcitajArtikleRacuna(OdabraniRacunId);
            LblOdabraniRacun.Text = $"Odabrani racun: #{OdabraniRacunId}";
        }

        private void OnemoguciBtnDetalji()
        {
            BtnOtkazi.Enabled = false;
            BtnDodajArtikal.Enabled = false;
            LblOdabraniRacun.Text = "Nije odabran nijedan racun";
            DGridArtikliRacuna.DataSource = null;
        }

        private void OmoguciBtnDetalji()
        {
            BtnOtkazi.Enabled = true;
            BtnDodajArtikal.Enabled = true;
        }

        // Otkazivanje racuna

        private void BtnOtkazi_Click(object sender, EventArgs e)
        {
            if (OdabraniRacunId < 0) return;

            var confirm = MessageBox.Show(
                $"Da li ste sigurni da zelite da otkazete racun #{OdabraniRacunId}?\n" +
                "Rezervacije ce biti oslobodjene a artikli vraceni na zalihu.",
                "Potvrda otkazivanja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            SqlConnection veza = Connection.Connect();
            SqlCommand cmd = new SqlCommand("Otkazi_Racun", veza);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@racunId", OdabraniRacunId);
            var ret = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            ret.Direction = ParameterDirection.ReturnValue;
            try
            {
                veza.Open();
                cmd.ExecuteNonQuery();
                veza.Close();
                MessageBox.Show($"Racun #{OdabraniRacunId} je uspesno otkazan.");
                OdabraniRacunId = -1;
                OnemoguciBtnDetalji();
                UcitajRacune();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska pri otkazivanju: " + ex.Message);
                veza.Close();
            }
        }

        // Dodavanje artikla na racun

        private void BtnDodajArtikal_Click(object sender, EventArgs e)
        {
            if (OdabraniRacunId < 0) return;

            // Ucitaj dostupne artikle
            DataTable artikli = new DataTable();
            SqlConnection v = Connection.Connect();
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter(
                    "SELECT id, naziv, kolicina, cena FROM Artikal WHERE kolicina > 0 ORDER BY naziv", v);
                ad.Fill(artikli);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
                return;
            }

            if (artikli.Rows.Count == 0)
            {
                MessageBox.Show("Trenutno nema artikala na lageru.");
                return;
            }

            using (var dlg = new DodajArtikalNaRacunDialog(artikli))
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;

                SqlConnection veza = Connection.Connect();
                SqlCommand cmd = new SqlCommand("Dodaj_Artikal_Na_Racun", veza);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@racunId", OdabraniRacunId);
                cmd.Parameters.AddWithValue("@artikalId", dlg.OdabraniArtikalId);
                cmd.Parameters.AddWithValue("@kolicina", dlg.OdabranaKolicina);
                var ret = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                ret.Direction = ParameterDirection.ReturnValue;
                try
                {
                    veza.Open();
                    cmd.ExecuteNonQuery();
                    int result = (int)ret.Value;
                    veza.Close();

                    if (result == -1)
                        MessageBox.Show("Nema dovoljno artikala na lageru.");
                    else
                    {
                        MessageBox.Show("Artikal je uspesno dodat na racun.");
                        UcitajArtikleRacuna(OdabraniRacunId);
                        UcitajRacune();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greska: " + ex.Message);
                    veza.Close();
                }
            }
        }

        private void BtnOsvezi_Click(object sender, EventArgs e)
        {
            UcitajRacune();
            if (OdabraniRacunId > 0) UcitajArtikleRacuna(OdabraniRacunId);
        }
    }
}
