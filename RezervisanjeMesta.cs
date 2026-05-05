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
        public RezervisanjeMesta(int KorisnikId,int datum)
        {
            InitializeComponent();
            this.datum = datum;
            this.KorisnikId = KorisnikId;
        }

        private void RezervisanjeMesta_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshBrojMesta();
        }

        private void RezervisanjeMesta_Load(object sender, EventArgs e)
        {
            PopulateCboxTipMesta();
            PopulateCboxTermin();
            RefreshBrojMesta();
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

                veza.Open();
                cmd.ExecuteNonQuery();
                int result = (int)returnParameter.Value;
                veza.Close();
            TBoxSlobodnaMesta.Text = result.ToString();
        }

        private void CBoxTermin_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshBrojMesta();
        }
    }
}
