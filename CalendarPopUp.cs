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
                object value = command.ExecuteScalar();

                if (value == null || value == DBNull.Value)
                {
                    MessageBox.Show("Datum koji ste izabrali je neradan dan.");
                    return -1;
                }

                int result = Convert.ToInt32(value);
                return result;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
                connection.Close();
            }
            
            
            
        }
        private void BtnIzaberiMesto_Click(object sender, EventArgs e)
        {
            
            int datumId = GetId(SqlDatum(Calendar.SelectionStart));
            if(datumId == -1)
            {
                return;
            }
            RezervisanjeMesta rezervisanje_mesta = new RezervisanjeMesta(KorisnikId, datumId,ParentForm);
            rezervisanje_mesta.Show();
            this.ParentForm.Hide();
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
