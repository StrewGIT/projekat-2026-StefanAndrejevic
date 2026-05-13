namespace projekat_2026_StefanAndrejevic
{
    partial class MojiRacuni
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.DGridRacuni          = new System.Windows.Forms.DataGridView();
            this.DGridArtikliRacuna   = new System.Windows.Forms.DataGridView();
            this.BtnOtkazi            = new System.Windows.Forms.Button();
            this.BtnDodajArtikal      = new System.Windows.Forms.Button();
            this.BtnOsvezi            = new System.Windows.Forms.Button();
            this.LblRacuni            = new System.Windows.Forms.Label();
            this.LblArtikli           = new System.Windows.Forms.Label();
            this.LblOdabraniRacun     = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.DGridRacuni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGridArtikliRacuna)).BeginInit();
            this.SuspendLayout();

            // LblRacuni
            this.LblRacuni.AutoSize = true;
            this.LblRacuni.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.LblRacuni.Location = new System.Drawing.Point(12, 9);
            this.LblRacuni.Text = "Moji racuni";

            // DGridRacuni
            this.DGridRacuni.AllowUserToAddRows = false;
            this.DGridRacuni.AllowUserToDeleteRows = false;
            this.DGridRacuni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGridRacuni.Location = new System.Drawing.Point(12, 30);
            this.DGridRacuni.MultiSelect = false;
            this.DGridRacuni.Name = "DGridRacuni";
            this.DGridRacuni.ReadOnly = true;
            this.DGridRacuni.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGridRacuni.Size = new System.Drawing.Size(760, 200);
            this.DGridRacuni.TabIndex = 0;
            this.DGridRacuni.SelectionChanged += new System.EventHandler(this.DGridRacuni_SelectionChanged);

            // LblOdabraniRacun
            this.LblOdabraniRacun.AutoSize = true;
            this.LblOdabraniRacun.Location = new System.Drawing.Point(12, 240);
            this.LblOdabraniRacun.Text = "Nije odabran nijedan racun";

            // LblArtikli
            this.LblArtikli.AutoSize = true;
            this.LblArtikli.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.LblArtikli.Location = new System.Drawing.Point(12, 260);
            this.LblArtikli.Text = "Artikli na racunu";

            // DGridArtikliRacuna
            this.DGridArtikliRacuna.AllowUserToAddRows = false;
            this.DGridArtikliRacuna.AllowUserToDeleteRows = false;
            this.DGridArtikliRacuna.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGridArtikliRacuna.Location = new System.Drawing.Point(12, 285);
            this.DGridArtikliRacuna.MultiSelect = false;
            this.DGridArtikliRacuna.Name = "DGridArtikliRacuna";
            this.DGridArtikliRacuna.ReadOnly = true;
            this.DGridArtikliRacuna.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGridArtikliRacuna.Size = new System.Drawing.Size(760, 150);
            this.DGridArtikliRacuna.TabIndex = 1;

            // BtnOtkazi
            this.BtnOtkazi.BackColor = System.Drawing.Color.LightCoral;
            this.BtnOtkazi.Location = new System.Drawing.Point(12, 450);
            this.BtnOtkazi.Name = "BtnOtkazi";
            this.BtnOtkazi.Size = new System.Drawing.Size(160, 36);
            this.BtnOtkazi.TabIndex = 2;
            this.BtnOtkazi.Text = "Otkazi racun";
            this.BtnOtkazi.UseVisualStyleBackColor = false;
            this.BtnOtkazi.Enabled = false;
            this.BtnOtkazi.Click += new System.EventHandler(this.BtnOtkazi_Click);

            // BtnDodajArtikal
            this.BtnDodajArtikal.BackColor = System.Drawing.Color.PaleGreen;
            this.BtnDodajArtikal.Location = new System.Drawing.Point(185, 450);
            this.BtnDodajArtikal.Name = "BtnDodajArtikal";
            this.BtnDodajArtikal.Size = new System.Drawing.Size(180, 36);
            this.BtnDodajArtikal.TabIndex = 3;
            this.BtnDodajArtikal.Text = "Dodaj artikal na racun";
            this.BtnDodajArtikal.UseVisualStyleBackColor = false;
            this.BtnDodajArtikal.Enabled = false;
            this.BtnDodajArtikal.Click += new System.EventHandler(this.BtnDodajArtikal_Click);

            // BtnOsvezi
            this.BtnOsvezi.Location = new System.Drawing.Point(620, 450);
            this.BtnOsvezi.Name = "BtnOsvezi";
            this.BtnOsvezi.Size = new System.Drawing.Size(150, 36);
            this.BtnOsvezi.TabIndex = 4;
            this.BtnOsvezi.Text = "Osvezi";
            this.BtnOsvezi.UseVisualStyleBackColor = true;
            this.BtnOsvezi.Click += new System.EventHandler(this.BtnOsvezi_Click);

            // MojiRacuni Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 505);
            this.Controls.Add(this.LblRacuni);
            this.Controls.Add(this.DGridRacuni);
            this.Controls.Add(this.LblOdabraniRacun);
            this.Controls.Add(this.LblArtikli);
            this.Controls.Add(this.DGridArtikliRacuna);
            this.Controls.Add(this.BtnOtkazi);
            this.Controls.Add(this.BtnDodajArtikal);
            this.Controls.Add(this.BtnOsvezi);
            this.Name = "MojiRacuni";
            this.Text = "Moji Racuni";
            this.Load += new System.EventHandler(this.MojiRacuni_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGridRacuni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGridArtikliRacuna)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.DataGridView DGridRacuni;
        private System.Windows.Forms.DataGridView DGridArtikliRacuna;
        private System.Windows.Forms.Button BtnOtkazi;
        private System.Windows.Forms.Button BtnDodajArtikal;
        private System.Windows.Forms.Button BtnOsvezi;
        private System.Windows.Forms.Label LblRacuni;
        private System.Windows.Forms.Label LblArtikli;
        private System.Windows.Forms.Label LblOdabraniRacun;
    }
}
