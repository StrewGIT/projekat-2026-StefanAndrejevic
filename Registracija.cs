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
    public partial class Registracija : Form
    {
        public Registracija()
        {
            InitializeComponent();
        }

        private void BtnRegistracija_Click(object sender, EventArgs e)
        {
            if(TboxPass.Text == TboxPassOpet.Text)
            {
                SqlConnection veza = Connection.Connect();
                string provera = "select count(*) from korisnik where email ='"+TboxEmail.Text+"'";
                SqlCommand komanda =new SqlCommand(provera, veza);
                veza.Open();
                int ima = (int)komanda.ExecuteScalar();
                veza.Close();
                if (ima > 0)
                {
                    MessageBox.Show("Uneti E-mail je vec vezan za postojeci nalog.");
                }
                else
                {
                    string naredba = "insert into korisnik values('" + TboxEmail.Text + "','" + TboxPass.Text + "',0)";
                    SqlCommand uradi = new SqlCommand(naredba, veza);
                    veza.Open();
                    uradi.ExecuteNonQuery();
                    veza.Close();
                    MessageBox.Show("Nalog je uspesno kreiran");
                    this.Close();
                }
            }
            else { MessageBox.Show("Lozinke moraju biti iste."); }
        }
    }
}
