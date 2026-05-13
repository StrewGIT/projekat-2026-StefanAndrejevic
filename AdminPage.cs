using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekat_2026_StefanAndrejevic
{
    public partial class AdminPage : Form
    {
        DataTable tabela;
        SqlDataAdapter adapter;
        Form parent;
        DataTable tabelaArtikli;
        SqlDataAdapter adapterArtikli;
        private bool ExitApp = true;
        int KorisnikId;
        public AdminPage(int KorisnikId,Form parent)
        {
            InitializeComponent();
            this.KorisnikId = KorisnikId;
            this.parent = parent;
        }

        private void AdminPage_Load(object sender, EventArgs e)
        {
            Calendar.TodayDate = DateTime.Now;
            Calendar.MaxDate = Calendar.TodayDate + new System.TimeSpan(365, 0, 0, 0);
            Calendar.MinDate = Calendar.TodayDate;
            DTimePocetak.Format = DateTimePickerFormat.Custom;
            DTimePocetak.CustomFormat = "HH:mm";
            DTimePocetak.ShowUpDown = true;
            DTimeKraj.Format = DateTimePickerFormat.Custom;
            DTimeKraj.CustomFormat = "HH:mm";
            DTimeKraj.ShowUpDown = true;
            DTimeTrajanje.Format = DateTimePickerFormat.Custom;
            DTimeTrajanje.CustomFormat = "HH:mm";
            DTimeTrajanje.ShowUpDown = true;
            UpdateMesta();
            UpdateArtikli();
        }

        private string GetSqlDatum(DateTime datum)
        {
            return Calendar.SelectionStart.Year.ToString() + "-" + Calendar.SelectionStart.Month.ToString() + "-" + Calendar.SelectionStart.Day.ToString();
        }

        private void GenerisiTermine(int radniDan)
        {
            SqlConnection veza = Connection.Connect();
            SqlCommand cmd = new SqlCommand("generisi_termine_za_sva_mesta_u_danu", veza);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@radni_dan_id", radniDan);
            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            try
            {
                veza.Open();
                cmd.ExecuteNonQuery();
                int result = (int)returnParameter.Value;
                veza.Close();
                if (result == 1)
                    MessageBox.Show("Vec postoje rezervacije za izabrani dan.");
                else
                    MessageBox.Show("Termini su uspesno generisani.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sql error:" + ex.Message);
                veza.Close();
            }
        }

        private void BtnDodajRadniDan_Click(object sender, EventArgs e)
        {
            SqlConnection veza = Connection.Connect();
            SqlCommand cmd = new SqlCommand("Unos_RadnogDana", veza);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@datum", GetSqlDatum(Calendar.SelectionStart));
            cmd.Parameters.AddWithValue("@pocetak", DTimePocetak.Value.TimeOfDay);
            cmd.Parameters.AddWithValue("@kraj", DTimeKraj.Value.TimeOfDay);
            cmd.Parameters.AddWithValue("@duzina", DTimeTrajanje.Value.TimeOfDay);

            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            var newIdParameter = cmd.Parameters.Add("@newId", SqlDbType.Int);
            newIdParameter.Direction = ParameterDirection.Output;

            try
            {
                veza.Open();
                cmd.ExecuteNonQuery();
                int result = (int)returnParameter.Value;
                int newId = (int)newIdParameter.Value;
                veza.Close();

                if (result == -1)
                    MessageBox.Show("Izabrani radni dan je vec ranije unet.");
                else
                {
                    MessageBox.Show("Radni dan je uspesno unet. " + newId.ToString());
                    GenerisiTermine(newId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sql error:" + ex.Message);
                veza.Close();
            }
        }

        // MESTA (TipMesta) tabela

        private void UpdateMesta()
        {
            adapter = new SqlDataAdapter("SELECT * FROM viewBrojMestaPoTipu", Connection.Connect());
            tabela = new DataTable();
            adapter.Fill(tabela);
            DGridView.DataSource = tabela;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (DGridView.CurrentRow == null) return;
            var confirm = MessageBox.Show(
                "Da li ste sigurni da zelite da obrisete ovaj red?\nSvi zakazani termini sa ovim tipom mesta ce biti obrisani!!!",
                "Potvrdi brisanje", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            SqlConnection veza = Connection.Connect();
            SqlCommand cmd = new SqlCommand("Brisanje_TipaMesta", veza);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", DGridView.CurrentRow.Cells["id"].Value.ToString());
            try
            {
                veza.Open();
                cmd.ExecuteNonQuery();
                veza.Close();
                UpdateMesta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sql error:" + ex.Message);
                veza.Close();
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (DGridView.CurrentRow == null) return;

            int tipId       = Convert.ToInt32(DGridView.CurrentRow.Cells["id"].Value);
            string naziv    = DGridView.CurrentRow.Cells["naziv"].Value?.ToString();
            int trenutniBroj = Convert.ToInt32(DGridView.CurrentRow.Cells["broj_mesta"].Value);

            int trenutnaCena = 0;
            try
            {
                SqlConnection v = Connection.Connect();
                SqlCommand c = new SqlCommand("SELECT cena FROM TipMesta WHERE id=" + tipId, v);
                v.Open();
                var scalar = c.ExecuteScalar();
                if (scalar != null && scalar != DBNull.Value)
                    trenutnaCena = Convert.ToInt32(scalar);
                v.Close();
            }
            catch { }

            using (var dlg = new TipMestaDialog("Izmena tipa mesta", naziv, trenutnaCena.ToString(), trenutniBroj.ToString()))
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;

                if (!int.TryParse(dlg.CenaValue, out int novaCena))
                {
                    MessageBox.Show("Cena mora biti broj.");
                    return;
                }
                if (!int.TryParse(dlg.KolicinaValue, out int noviBroj) || noviBroj < 0)
                {
                    MessageBox.Show("Broj mesta mora biti nenegativan broj.");
                    return;
                }

                SqlConnection veza = Connection.Connect();
                try
                {
                    veza.Open();

                    SqlCommand cmdCena = new SqlCommand("Izmena_TipaMesta", veza);
                    cmdCena.CommandType = CommandType.StoredProcedure;
                    cmdCena.Parameters.AddWithValue("@id", tipId);
                    cmdCena.Parameters.AddWithValue("@cena", novaCena);
                    cmdCena.ExecuteNonQuery();

                    int razlika = noviBroj - trenutniBroj;

                    if (razlika > 0)
                    {
                        for (int i = 0; i < razlika; i++)
                        {
                            SqlCommand cmdDodaj = new SqlCommand("Unos_Mesta", veza);
                            cmdDodaj.CommandType = CommandType.StoredProcedure;
                            cmdDodaj.Parameters.AddWithValue("@tip", tipId);
                            cmdDodaj.ExecuteNonQuery();
                        }
                    }
                    else if (razlika < 0)
                    {
                        int brZaBrisanje = -razlika;
                        SqlCommand cmdNadji = new SqlCommand(
                            @"SELECT TOP(@br) m.id
                              FROM Mesto m
                              WHERE m.tip = @tip
                                AND NOT EXISTS (
                                    SELECT 1 FROM Rezervacija r
                                    WHERE r.mesto = m.id AND r.korisnik IS NOT NULL
                                )
                              ORDER BY m.id DESC",
                            veza);
                        cmdNadji.Parameters.AddWithValue("@br", brZaBrisanje);
                        cmdNadji.Parameters.AddWithValue("@tip", tipId);

                        List<int> zaObrisati = new List<int>();
                        using (SqlDataReader reader = cmdNadji.ExecuteReader())
                        {
                            while (reader.Read())
                                zaObrisati.Add(reader.GetInt32(0));
                        }

                        if (zaObrisati.Count < brZaBrisanje)
                        {
                            MessageBox.Show(
                                $"Moguce je obrisati samo {zaObrisati.Count} od {brZaBrisanje} mesta " +
                                $"jer ostala imaju aktivne rezervacije.");
                        }

                        foreach (int mestoId in zaObrisati)
                        {
                            SqlCommand cmdObrisi = new SqlCommand("Brisanje_Mesta", veza);
                            cmdObrisi.CommandType = CommandType.StoredProcedure;
                            cmdObrisi.Parameters.AddWithValue("@id", mestoId);
                            cmdObrisi.ExecuteNonQuery();
                        }
                    }

                    veza.Close();
                    UpdateMesta();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sql error:" + ex.Message);
                    veza.Close();
                }
            }
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            using (var dlg = new TipMestaDialog("Novi tip mesta", "", "", "0"))
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;

                if (!int.TryParse(dlg.CenaValue, out int cena))
                {
                    MessageBox.Show("Cena mora biti broj.");
                    return;
                }
                if (!int.TryParse(dlg.KolicinaValue, out int kolicina) || kolicina < 0)
                {
                    MessageBox.Show("Broj mesta mora biti nenegativan broj.");
                    return;
                }

                SqlConnection veza = Connection.Connect();
                try
                {
                    veza.Open();

                    SqlCommand cmdTip = new SqlCommand("Unos_TipaMesta", veza);
                    cmdTip.CommandType = CommandType.StoredProcedure;
                    cmdTip.Parameters.AddWithValue("@naziv", dlg.NazivValue);
                    cmdTip.Parameters.AddWithValue("@cena", cena);
                    var ret = cmdTip.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    ret.Direction = ParameterDirection.ReturnValue;
                    cmdTip.ExecuteNonQuery();

                    if ((int)ret.Value == 1)
                    {
                        veza.Close();
                        MessageBox.Show("Tip mesta sa tim nazivom vec postoji.");
                        return;
                    }

                    SqlCommand cmdId = new SqlCommand(
                        "SELECT TOP 1 id FROM TipMesta WHERE naziv = @naziv ORDER BY id DESC", veza);
                    cmdId.Parameters.AddWithValue("@naziv", dlg.NazivValue);
                    int noviTipId = Convert.ToInt32(cmdId.ExecuteScalar());

                    for (int i = 0; i < kolicina; i++)
                    {
                        SqlCommand cmdMesto = new SqlCommand("Unos_Mesta", veza);
                        cmdMesto.CommandType = CommandType.StoredProcedure;
                        cmdMesto.Parameters.AddWithValue("@tip", noviTipId);
                        cmdMesto.ExecuteNonQuery();
                    }

                    veza.Close();
                    UpdateMesta();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sql error:" + ex.Message);
                    veza.Close();
                }
            }
        }

        // ARTIKLI tabela

        private void UpdateArtikli()
        {
            adapterArtikli = new SqlDataAdapter("SELECT id, naziv, kolicina FROM Artikal", Connection.Connect());
            tabelaArtikli = new DataTable();
            adapterArtikli.Fill(tabelaArtikli);
            DGridArtikli.DataSource = tabelaArtikli;

            if (DGridArtikli.Columns.Contains("id"))
                DGridArtikli.Columns["id"].Visible = false;
        }

        private void BtnDodajArtikal_Click(object sender, EventArgs e)
        {
            using (var dlg = new ArtikalDialog("Dodaj artikal", "", "0", "0"))
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;

                if (!int.TryParse(dlg.KolicinaValue, out int kolicina) ||
                    !int.TryParse(dlg.CenaValue, out int cena))
                {
                    MessageBox.Show("Kolicina i cena moraju biti brojevi.");
                    return;
                }

                SqlConnection veza = Connection.Connect();
                SqlCommand cmd = new SqlCommand("Unos_Artikla", veza);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@naziv", dlg.NazivValue);
                cmd.Parameters.AddWithValue("@kolicina", kolicina);
                cmd.Parameters.AddWithValue("@cena", cena);
                var ret = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                ret.Direction = ParameterDirection.ReturnValue;
                try
                {
                    veza.Open();
                    cmd.ExecuteNonQuery();
                    veza.Close();
                    if ((int)ret.Value == 1)
                        MessageBox.Show("Artikal sa tim nazivom vec postoji.");
                    else
                        UpdateArtikli();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sql error:" + ex.Message);
                    veza.Close();
                }
            }
        }

        private void BtnPromeniArtikal_Click(object sender, EventArgs e)
        {
            if (DGridArtikli.CurrentRow == null) return;

            string idStr    = DGridArtikli.CurrentRow.Cells["id"].Value?.ToString();
            string naziv    = DGridArtikli.CurrentRow.Cells["naziv"].Value?.ToString();
            string kolicina = DGridArtikli.CurrentRow.Cells["kolicina"].Value?.ToString();

            int staraCena = 0;
            try
            {
                SqlConnection v = Connection.Connect();
                SqlCommand c = new SqlCommand("SELECT cena FROM Artikal WHERE id=" + idStr, v);
                v.Open();
                staraCena = (int)c.ExecuteScalar();
                v.Close();
            }
            catch { }

            using (var dlg = new ArtikalDialog("Izmena artikla", naziv, kolicina, staraCena.ToString()))
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;

                if (!int.TryParse(dlg.KolicinaValue, out int novaKolicina) ||
                    !int.TryParse(dlg.CenaValue, out int novaCena))
                {
                    MessageBox.Show("Kolicina i cena moraju biti brojevi.");
                    return;
                }

                SqlConnection veza = Connection.Connect();
                SqlCommand cmd = new SqlCommand("Izmena_Artikla", veza);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", int.Parse(idStr));
                cmd.Parameters.AddWithValue("@naziv", dlg.NazivValue);
                cmd.Parameters.AddWithValue("@kolicina", novaKolicina);
                cmd.Parameters.AddWithValue("@cena", novaCena);
                try
                {
                    veza.Open();
                    cmd.ExecuteNonQuery();
                    veza.Close();
                    UpdateArtikli();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sql error:" + ex.Message);
                    veza.Close();
                }
            }
        }

        private void BtnObrisiArtikal_Click(object sender, EventArgs e)
        {
            if (DGridArtikli.CurrentRow == null) return;

            string naziv = DGridArtikli.CurrentRow.Cells["naziv"].Value?.ToString();
            var confirm = MessageBox.Show(
                $"Da li ste sigurni da zelite da obrisete artikal '{naziv}'?",
                "Potvrdi brisanje", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            string idStr = DGridArtikli.CurrentRow.Cells["id"].Value?.ToString();
            SqlConnection veza = Connection.Connect();
            SqlCommand cmd = new SqlCommand("Brisanje_Artikla", veza);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", int.Parse(idStr));
            try
            {
                veza.Open();
                cmd.ExecuteNonQuery();
                veza.Close();
                UpdateArtikli();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sql error:" + ex.Message);
                veza.Close();
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            ExitApp = false;
            this.Close();
        }

        private void AdminPage_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
