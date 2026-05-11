using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekat_2026_StefanAndrejevic
{
    public partial class AdminPage : Form
    {
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
        }
        private string GetSqlDatum(DateTime datum)
        {
            return Calendar.SelectionStart.Year.ToString() + "-" + Calendar.SelectionStart.Month.ToString() + "-" + Calendar.SelectionStart.Day.ToString();
        }
        private void InsertRadniDan()
        {
            
        }

        private void BtnDodajRadniDan_Click(object sender, EventArgs e)
        {
            SqlConnection veza = Connection.Connect();
            SqlCommand cmd = new SqlCommand("Unos_RadnogDana", veza);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@datum", GetSqlDatum(Calendar.SelectionStart));
            cmd.Parameters.AddWithValue("@pocetak", DTimePocetak.Value);
            cmd.Parameters.AddWithValue("@kraj", DTimeKraj.Value);
            cmd.Parameters.AddWithValue("@duzina", DTimeTrajanje.Value);
            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            try
            {
                veza.Open();
                cmd.ExecuteNonQuery();
                int result = (int)returnParameter.Value;
                veza.Close();
                if(result == 1)
                {
                    MessageBox.Show("Izabrani radni dan je vec ranije unet.");
                }
                else
                {
                    MessageBox.Show("Radni dan je uspesno unet.");
                }
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
