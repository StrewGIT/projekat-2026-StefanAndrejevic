using System;
using System.Windows.Forms;

namespace projekat_2026_StefanAndrejevic
{
    /// <summary>
    /// Dijalog za unos/izmenu tipa mesta (naziv, cena, broj mesta).
    /// KolicinaValue vraca uneseni broj mesta.
    /// </summary>
    public class TipMestaDialog : Form
    {
        public string NazivValue    => txtNaziv.Text.Trim();
        public string CenaValue     => txtCena.Text.Trim();
        public string KolicinaValue => txtKolicina.Text.Trim();

        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.TextBox txtCena;
        private System.Windows.Forms.TextBox txtKolicina;

        public TipMestaDialog(string title, string naziv, string cena, string kolicina = "0")
        {
            Text = title;
            Size = new System.Drawing.Size(260, 210);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false; MinimizeBox = false;

            var lbl1 = new Label { Text = "Naziv:", Location = new System.Drawing.Point(12, 15), AutoSize = true };
            txtNaziv = new TextBox { Location = new System.Drawing.Point(90, 12), Width = 145, Text = naziv };

            var lbl2 = new Label { Text = "Cena (RSD):", Location = new System.Drawing.Point(12, 50), AutoSize = true };
            txtCena = new TextBox { Location = new System.Drawing.Point(90, 47), Width = 80, Text = cena };

            var lbl3 = new Label { Text = "Broj mesta:", Location = new System.Drawing.Point(12, 85), AutoSize = true };
            txtKolicina = new TextBox { Location = new System.Drawing.Point(90, 82), Width = 80, Text = kolicina };

            var btnOk = new Button
            {
                Text = "OK", DialogResult = DialogResult.OK,
                Location = new System.Drawing.Point(90, 125), Width = 70
            };
            var btnCancel = new Button
            {
                Text = "Otkazivanje", DialogResult = DialogResult.Cancel,
                Location = new System.Drawing.Point(170, 125), Width = 75
            };

            AcceptButton = btnOk; CancelButton = btnCancel;
            Controls.AddRange(new Control[] { lbl1, txtNaziv, lbl2, txtCena, lbl3, txtKolicina, btnOk, btnCancel });
        }
    }
}
