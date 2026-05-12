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
        int KorisnikId;
        public AdminPage(int KorisnikId)
        {
            InitializeComponent();
            this.KorisnikId = KorisnikId;
        }

        private void AdminPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
            UpdateKaAplikaciji();
        }
        private string GetSqlDatum(DateTime datum)
        {
            return Calendar.SelectionStart.Year.ToString() + "-" + Calendar.SelectionStart.Month.ToString() + "-" + Calendar.SelectionStart.Day.ToString();
        }
        private void InsertRadniDan()
        {
            
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
                {
                    MessageBox.Show("Vec postoje rezervacije za izabrani dan.");
                }
                else
                {
                    MessageBox.Show("Termini su uspesno generisani.");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sql error:" + ex.Message);
                veza.Close();
                return;
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
                {
                    MessageBox.Show("Izabrani radni dan je vec ranije unet.");
                }
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
                return;
            }
        }
        private void UpdateKaAplikaciji()
        {
            adapter = new SqlDataAdapter("SELECT * FROM viewBrojMestaPoTipu", Connection.Connect());
            tabela = new DataTable();
            adapter.Fill(tabela);
            DGridView.DataSource = tabela;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Da li ste sigurni da zelite da obrisete ovaj red?\nSvi zakazani termini sa ovim tipom mesta ce biti obrisani!!!","Potvrdi brisanje",MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                SqlConnection veza = Connection.Connect();
                SqlCommand cmd = new SqlCommand("Brisanje_TipaMesta", veza);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", DGridView.CurrentRow.Cells["id"].Value.ToString());
                try
                {
                    veza.Open();
                    cmd.ExecuteNonQuery();
                    UpdateKaAplikaciji();
                    veza.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sql error:" + ex.Message);
                    veza.Close();
                    return;
                }
            }
            else
            {
                // If 'No', do something here.
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
