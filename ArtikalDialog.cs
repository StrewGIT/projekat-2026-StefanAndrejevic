using System;
using System.Windows.Forms;

namespace projekat_2026_StefanAndrejevic
{
    /// <summary>
    /// Jednostavan dijalog za unos/izmenu artikla (naziv, kolicina, cena).
    /// </summary>
    public class ArtikalDialog : Form
    {
        public string NazivValue   => txtNaziv.Text.Trim();
        public string KolicinaValue => txtKolicina.Text.Trim();
        public string CenaValue    => txtCena.Text.Trim();

        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.TextBox txtKolicina;
        private System.Windows.Forms.TextBox txtCena;

        public ArtikalDialog(string title, string naziv, string kolicina, string cena)
        {
            Text = title;
            Size = new System.Drawing.Size(280, 200);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false; MinimizeBox = false;

            var lbl1 = new Label { Text = "Naziv:", Location = new System.Drawing.Point(12, 15), AutoSize = true };
            txtNaziv = new TextBox { Location = new System.Drawing.Point(90, 12), Width = 160, Text = naziv };

            var lbl2 = new Label { Text = "Kolicina:", Location = new System.Drawing.Point(12, 50), AutoSize = true };
            txtKolicina = new TextBox { Location = new System.Drawing.Point(90, 47), Width = 80, Text = kolicina };

            var lbl3 = new Label { Text = "Cena (RSD):", Location = new System.Drawing.Point(12, 85), AutoSize = true };
            txtCena = new TextBox { Location = new System.Drawing.Point(90, 82), Width = 80, Text = cena };

            var btnOk = new Button
            {
                Text = "OK", DialogResult = DialogResult.OK,
                Location = new System.Drawing.Point(90, 120), Width = 75
            };
            var btnCancel = new Button
            {
                Text = "Otkazivanje", DialogResult = DialogResult.Cancel,
                Location = new System.Drawing.Point(175, 120), Width = 75
            };

            AcceptButton = btnOk;
            CancelButton = btnCancel;
            Controls.AddRange(new Control[] { lbl1, txtNaziv, lbl2, txtKolicina, lbl3, txtCena, btnOk, btnCancel });
        }
    }
}
