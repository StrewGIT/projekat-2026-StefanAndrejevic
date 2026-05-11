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
        public RezervisanjeMesta(int KorisnikId,int datum)
        {
            InitializeComponent();
            this.datum = datum;
            this.KorisnikId = KorisnikId;
        }
        public RezervisanjeMesta(int KorisnikId, int datum,Form ParentForm)
        {
            InitializeComponent();
            this.datum = datum;
            this.KorisnikId = KorisnikId;
            this.ParentForm = ParentForm;
        }

        private void RezervisanjeMesta_FormClosed(object sender, FormClosedEventArgs e)
        {
            ParentForm.Show();
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
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM ViewTipoviMesta WHERE radni_dan="+datum.ToString()+ " ORDER BY id", veza);
            DataTable table = new DataTable();
            adapter.Fill(table);
            CBoxTipMesta.DataSource = table;
            CBoxTipMesta.ValueMember = "id";
            CBoxTipMesta.DisplayMember = "naziv";
            
        }
        private void PopulateCboxTermin()
        {
            SqlConnection veza = Connection.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from ViewTermini where radni_dan = "+datum.ToString(), veza);
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
                return;
            }
            
        }

        private void IzracunajCenu()
        {
            SqlConnection veza = Connection.Connect();
            SqlCommand cmd = new SqlCommand("Select top 1 cena from TipMesta where id=" + CBoxTipMesta.SelectedValue, veza);
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
            if(NumKolicina.Value > int.Parse(TBoxSlobodnaMesta.Text))
            {
                NumKolicina.Value = int.Parse(TBoxSlobodnaMesta.Text);
            }
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
            cmd.Parameters.AddWithValue("@kolicina", NumKolicina.Value);
            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            try
            {
                veza.Open();
                cmd.ExecuteNonQuery();
                int result = (int)returnParameter.Value;
                if(result!=1)
                {
                    MessageBox.Show("Nije uspelo rezervisanje mesta. Pokusajte ponovo.");
                }
                else
                {
                    MessageBox.Show("Uspesno ste rezervisali mesto.");
                    ParentForm.Show();
                    this.Close();
                }
                veza.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sql error:" + ex.Message);
                veza.Close();
                return;
            }
        }
    }
}
