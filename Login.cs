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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            //Stefan Andrejevic
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if ((TBoxEmail.Text == "") && (TBoxEmail.Text == "")) MessageBox.Show("Morate uneti email i lozinku!");
            else if (TBoxEmail.Text == "") MessageBox.Show("Morate uneti email!");
            else if(TBoxPass.Text == "") MessageBox.Show("Morate uneti lozinku!");
            else
            {
                SqlConnection veza = Connection.Connect();
                DataTable podaci = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM korisnik WHERE email='"+TBoxEmail.Text+"'",veza);
                adapter.Fill(podaci);
                int count = podaci.Rows.Count;
                if (count == 0) MessageBox.Show("Uneti email nije validan.");
                else
                {
                    if (podaci.Rows[0]["pass"].ToString() == TBoxPass.Text) {
                        MessageBox.Show("Uspesno ste se ulogovali.");

                    }
                    else {MessageBox.Show("Uneli ste pogresnu lozinku.");}
                }
            }
        }

        private void TBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
