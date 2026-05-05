using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


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
        string SqlDatum(DateTime datum)
        {
            return datum.Year.ToString() + "-" + datum.Month.ToString() + "-" + datum.Day.ToString();
        }
        int GetId(string datum)
        {
            string sql = "select top 1 id from RadniDan where datum = '"+datum+"'";
            SqlConnection connection = Connection.Connect();
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            try
            {
                int result = (int)command.ExecuteScalar();
                MessageBox.Show(result.ToString());
                return result;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Datum koji ste izabrali je neradan dan.");
                return -1;
                connection.Close();
            }
            
            
            
        }
        private void BtnIzaberiMesto_Click(object sender, EventArgs e)
        {
            this.ParentForm.Hide();
            RezervisanjeMesta rezervisanje_mesta = new RezervisanjeMesta(KorisnikId, GetId(SqlDatum(Calendar.SelectionStart)));
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
