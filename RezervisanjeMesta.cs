using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        int datum;
        Form ParentForm;

        public RezervisanjeMesta(int KorisnikId, int datum)
        {
            InitializeComponent();
            this.datum = datum;
            this.KorisnikId = KorisnikId;
        }
        public RezervisanjeMesta(int KorisnikId, int datum, Form ParentForm)
        {
            InitializeComponent();
            this.datum = datum;
            this.KorisnikId = KorisnikId;
            this.ParentForm = ParentForm;
        }

        private void RezervisanjeMesta_FormClosed(object sender, FormClosedEventArgs e)
        {
            ParentForm?.Show();
        }

        private void RezervisanjeMesta_Load(object sender, EventArgs e)
        {
            PopulateCboxTipMesta();
            PopulateCboxTermin();
            RefreshBrojMesta();
            IzracunajCenu();
        }

        private void PopulateCboxTipMesta()
        {
            SqlConnection veza = Connection.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter(
                "SELECT * FROM ViewTipoviMesta WHERE radni_dan=" + datum.ToString() + " ORDER BY id", veza);
            DataTable table = new DataTable();
            adapter.Fill(table);
            CBoxTipMesta.DataSource = table;
            CBoxTipMesta.ValueMember = "id";
            CBoxTipMesta.DisplayMember = "naziv";
        }

        private void PopulateCboxTermin()
        {
            SqlConnection veza = Connection.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter(
                "Select * from ViewTermini where radni_dan = " + datum.ToString(), veza);
            DataTable table = new DataTable();
            adapter.Fill(table);
            CBoxTermin.DataSource = table;
            CBoxTermin.ValueMember = "termin_pocetak";
            CBoxTermin.DisplayMember = "Termin";
        }

        private void RefreshBrojMesta()
        {
            SqlConnection veza = Connection.Connect();
            SqlCommand cmd = new SqlCommand("Broj_Slobodnih_Mesta", veza);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@radnidan", datum);
            cmd.Parameters.AddWithValue("@pocetak", CBoxTermin.SelectedValue);
            cmd.Parameters.AddWithValue("@tip_mesta", CBoxTipMesta.SelectedValue);
            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            try
            {
                veza.Open();
                cmd.ExecuteNonQuery();
                int result = (int)returnParameter.Value;
                veza.Close();
                TBoxSlobodnaMesta.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sql error:" + ex.Message);
                veza.Close();
            }
        }

        private void IzracunajCenu()
        {
            SqlConnection veza = Connection.Connect();
            SqlCommand cmd = new SqlCommand(
                "Select top 1 cena from TipMesta where id=" + CBoxTipMesta.SelectedValue, veza);
            veza.Open();
            try
            {
                int result = (int)cmd.ExecuteScalar();
                veza.Close();
                TBoxCena.Text = (result * NumKolicina.Value).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sql error:" + ex.Message);
                veza.Close();
            }
        }

        private void CBoxTipMesta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RefreshBrojMesta();
            IzracunajCenu();
            NumKolicina_ValueChanged(sender, e);
        }

        private void CBoxTermin_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RefreshBrojMesta();
            NumKolicina_ValueChanged(sender, e);
        }

        private void NumKolicina_ValueChanged(object sender, EventArgs e)
        {
            IzracunajCenu();
            if (NumKolicina.Value > int.Parse(TBoxSlobodnaMesta.Text))
                NumKolicina.Value = int.Parse(TBoxSlobodnaMesta.Text);
        }


        private void BtnRezervisi_Click(object sender, EventArgs e)
        {
            SqlConnection veza = Connection.Connect();
            SqlCommand cmd = new SqlCommand("Rezervisi_Vise_Mesta_Tipa", veza);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@korisnik", KorisnikId);
            cmd.Parameters.AddWithValue("@radnidan", datum);
            cmd.Parameters.AddWithValue("@pocetak", CBoxTermin.SelectedValue);
            cmd.Parameters.AddWithValue("@tip_mesta", CBoxTipMesta.SelectedValue);
            cmd.Parameters.AddWithValue("@kolicina", (int)NumKolicina.Value);
            var ret = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            ret.Direction = ParameterDirection.ReturnValue;

            int rezervacijaId = -1;
            try
            {
                veza.Open();
                cmd.ExecuteNonQuery();
                int result = (int)ret.Value;
                if (result != 1)
                {
                    veza.Close();
                    MessageBox.Show("Nije uspelo rezervisanje mesta. Pokusajte ponovo.");
                    return;
                }
                veza.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sql error:" + ex.Message);
                veza.Close();
                return;
            }

            List<int> rezervacijeIds = new List<int>();
            SqlConnection v2 = Connection.Connect();
            try
            {
                string sql = @"
                    SELECT TOP(@kol) r.id 
                    FROM Rezervacija r
                    JOIN Mesto m ON r.mesto = m.id
                    WHERE r.korisnik = @korisnik
                      AND r.radni_dan = @radnidan
                      AND r.termin_pocetak = @pocetak
                      AND m.tip = @tip
                    ORDER BY r.id DESC";
                SqlCommand qCmd = new SqlCommand(sql, v2);
                qCmd.Parameters.AddWithValue("@kol", (int)NumKolicina.Value);
                qCmd.Parameters.AddWithValue("@korisnik", KorisnikId);
                qCmd.Parameters.AddWithValue("@radnidan", datum);
                qCmd.Parameters.AddWithValue("@pocetak", CBoxTermin.SelectedValue);
                qCmd.Parameters.AddWithValue("@tip", CBoxTipMesta.SelectedValue);
                v2.Open();
                SqlDataReader reader = qCmd.ExecuteReader();
                while (reader.Read())
                    rezervacijeIds.Add(reader.GetInt32(0));
                reader.Close();
                v2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska pri dohvatanju rezervacija: " + ex.Message);
                v2.Close();
                return;
            }

            if (rezervacijeIds.Count == 0)
            {
                MessageBox.Show("Rezervacije su napavljene ali racun nije kreiran - rezervacije nisu pronadjene.");
                ParentForm?.Show();
                this.Close();
                return;
            }

            int racunId = -1;
            SqlConnection v3 = Connection.Connect();
            try
            {
                v3.Open();

                SqlCommand insRacun = new SqlCommand(
                    "INSERT INTO Racun(korisnik) VALUES (@k); SELECT SCOPE_IDENTITY();", v3);
                insRacun.Parameters.AddWithValue("@k", KorisnikId);
                racunId = Convert.ToInt32(insRacun.ExecuteScalar());

                foreach (int rId in rezervacijeIds)
                {
                    SqlCommand insRez = new SqlCommand(
                        "INSERT INTO Racun_Rezervacija(racun, rezervacija) VALUES (@r, @rez)", v3);
                    insRez.Parameters.AddWithValue("@r", racunId);
                    insRez.Parameters.AddWithValue("@rez", rId);
                    insRez.ExecuteNonQuery();
                }
                v3.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska pri kreiranju racuna: " + ex.Message);
                v3.Close();
                return;
            }

            MessageBox.Show($"Uspesno ste rezervisali {rezervacijeIds.Count} mesto(a).\nRacun #{racunId} je kreiran.");
            ParentForm?.Show();
            this.Close();
        }
    }
}
