using System;
using System.Data;
using System.Windows.Forms;

namespace projekat_2026_StefanAndrejevic
{
    /// <summary>
    /// Dijalog koji prikazuje dostupne artikle i omogucava korisniku da odabere
    /// artikal i kolicinu za dodavanje na racun.
    /// </summary>
    public class DodajArtikalNaRacunDialog : Form
    {
        public int OdabraniArtikalId  { get; private set; } = -1;
        public int OdabranaKolicina   { get; private set; } = 1;

        private ComboBox cboxArtikal;
        private NumericUpDown numKolicina;
        private Label lblDostupno;
        private DataTable artikli;

        public DodajArtikalNaRacunDialog(DataTable artikliTable)
        {
            this.artikli = artikliTable;
            Text = "Dodaj artikal na racun";
            Size = new System.Drawing.Size(320, 200);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false; MinimizeBox = false;

            var lbl1 = new Label { Text = "Artikal:", Location = new System.Drawing.Point(12, 18), AutoSize = true };
            cboxArtikal = new ComboBox
            {
                Location = new System.Drawing.Point(90, 15),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DataSource = new System.Data.DataView(artikliTable),
                ValueMember = "id",
                DisplayMember = "naziv"
            };
            cboxArtikal.SelectedIndexChanged += (s, e) => AzurirajDostupno();

            var lbl2 = new Label { Text = "Kolicina:", Location = new System.Drawing.Point(12, 53), AutoSize = true };
            numKolicina = new NumericUpDown
            {
                Location = new System.Drawing.Point(90, 50),
                Width = 80,
                Minimum = 1,
                Value = 1
            };

            lblDostupno = new Label
            {
                Location = new System.Drawing.Point(180, 53),
                AutoSize = true,
                ForeColor = System.Drawing.Color.Gray
            };

            var lbl3 = new Label { Text = "Cena:", Location = new System.Drawing.Point(12, 88), AutoSize = true };
            var txtCena = new Label { Name = "lblCenaInfo", Location = new System.Drawing.Point(90, 88), AutoSize = true };

            var btnOk = new Button
            {
                Text = "Dodaj", DialogResult = DialogResult.OK,
                Location = new System.Drawing.Point(90, 120), Width = 90
            };
            btnOk.Click += (s, e) =>
            {
                if (cboxArtikal.SelectedValue == null) { DialogResult = DialogResult.None; return; }
                OdabraniArtikalId = Convert.ToInt32(cboxArtikal.SelectedValue);
                OdabranaKolicina  = (int)numKolicina.Value;
            };

            var btnCancel = new Button
            {
                Text = "Otkazivanje", DialogResult = DialogResult.Cancel,
                Location = new System.Drawing.Point(190, 120), Width = 100
            };

            AcceptButton = btnOk; CancelButton = btnCancel;
            Controls.AddRange(new Control[] { lbl1, cboxArtikal, lbl2, numKolicina, lblDostupno, btnOk, btnCancel });

            AzurirajDostupno();
        }

        private void AzurirajDostupno()
        {
            if (cboxArtikal.SelectedItem == null) return;
            DataRowView row = cboxArtikal.SelectedItem as DataRowView;
            if (row == null) return;
            int dostupno = Convert.ToInt32(row["kolicina"]);
            lblDostupno.Text = $"(max: {dostupno})";
            numKolicina.Maximum = dostupno;
            if (numKolicina.Value > dostupno) numKolicina.Value = dostupno;
        }
    }
}
