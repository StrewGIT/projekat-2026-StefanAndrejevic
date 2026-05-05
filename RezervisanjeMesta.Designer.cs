namespace projekat_2026_StefanAndrejevic
{
    partial class RezervisanjeMesta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CBoxTipMesta = new System.Windows.Forms.ComboBox();
            this.TBoxSlobodnaMesta = new System.Windows.Forms.TextBox();
            this.BtnRezervisi = new System.Windows.Forms.Button();
            this.CBoxTermin = new System.Windows.Forms.ComboBox();
            this.NumKolicina = new System.Windows.Forms.NumericUpDown();
            this.TBoxCena = new System.Windows.Forms.TextBox();
            this.LblTip = new System.Windows.Forms.Label();
            this.LblTermin = new System.Windows.Forms.Label();
            this.LblKolicina = new System.Windows.Forms.Label();
            this.LblSlobodnaMesta = new System.Windows.Forms.Label();
            this.LblCena = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumKolicina)).BeginInit();
            this.SuspendLayout();
            // 
            // CBoxTipMesta
            // 
            this.CBoxTipMesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBoxTipMesta.FormattingEnabled = true;
            this.CBoxTipMesta.Location = new System.Drawing.Point(60, 152);
            this.CBoxTipMesta.Name = "CBoxTipMesta";
            this.CBoxTipMesta.Size = new System.Drawing.Size(121, 28);
            this.CBoxTipMesta.TabIndex = 0;
            this.CBoxTipMesta.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // TBoxSlobodnaMesta
            // 
            this.TBoxSlobodnaMesta.Enabled = false;
            this.TBoxSlobodnaMesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBoxSlobodnaMesta.Location = new System.Drawing.Point(628, 153);
            this.TBoxSlobodnaMesta.Name = "TBoxSlobodnaMesta";
            this.TBoxSlobodnaMesta.Size = new System.Drawing.Size(100, 26);
            this.TBoxSlobodnaMesta.TabIndex = 3;
            // 
            // BtnRezervisi
            // 
            this.BtnRezervisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRezervisi.Location = new System.Drawing.Point(292, 264);
            this.BtnRezervisi.Name = "BtnRezervisi";
            this.BtnRezervisi.Size = new System.Drawing.Size(203, 37);
            this.BtnRezervisi.TabIndex = 4;
            this.BtnRezervisi.Text = "Rezervisi";
            this.BtnRezervisi.UseVisualStyleBackColor = true;
            // 
            // CBoxTermin
            // 
            this.CBoxTermin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBoxTermin.FormattingEnabled = true;
            this.CBoxTermin.Location = new System.Drawing.Point(250, 152);
            this.CBoxTermin.Name = "CBoxTermin";
            this.CBoxTermin.Size = new System.Drawing.Size(121, 28);
            this.CBoxTermin.TabIndex = 5;
            this.CBoxTermin.SelectedIndexChanged += new System.EventHandler(this.CBoxTermin_SelectedIndexChanged);
            // 
            // NumKolicina
            // 
            this.NumKolicina.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumKolicina.Location = new System.Drawing.Point(436, 153);
            this.NumKolicina.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumKolicina.Name = "NumKolicina";
            this.NumKolicina.Size = new System.Drawing.Size(120, 26);
            this.NumKolicina.TabIndex = 6;
            this.NumKolicina.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TBoxCena
            // 
            this.TBoxCena.Enabled = false;
            this.TBoxCena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBoxCena.Location = new System.Drawing.Point(292, 226);
            this.TBoxCena.Name = "TBoxCena";
            this.TBoxCena.Size = new System.Drawing.Size(203, 26);
            this.TBoxCena.TabIndex = 7;
            // 
            // LblTip
            // 
            this.LblTip.AutoSize = true;
            this.LblTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTip.Location = new System.Drawing.Point(56, 116);
            this.LblTip.Name = "LblTip";
            this.LblTip.Size = new System.Drawing.Size(109, 20);
            this.LblTip.TabIndex = 8;
            this.LblTip.Text = "Tip rezervacije";
            // 
            // LblTermin
            // 
            this.LblTermin.AutoSize = true;
            this.LblTermin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTermin.Location = new System.Drawing.Point(246, 116);
            this.LblTermin.Name = "LblTermin";
            this.LblTermin.Size = new System.Drawing.Size(57, 20);
            this.LblTermin.TabIndex = 9;
            this.LblTermin.Text = "Termin";
            // 
            // LblKolicina
            // 
            this.LblKolicina.AutoSize = true;
            this.LblKolicina.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblKolicina.Location = new System.Drawing.Point(399, 116);
            this.LblKolicina.Name = "LblKolicina";
            this.LblKolicina.Size = new System.Drawing.Size(185, 20);
            this.LblKolicina.TabIndex = 10;
            this.LblKolicina.Text = "Broj mesta za rezervaciju";
            // 
            // LblSlobodnaMesta
            // 
            this.LblSlobodnaMesta.AutoSize = true;
            this.LblSlobodnaMesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSlobodnaMesta.Location = new System.Drawing.Point(599, 116);
            this.LblSlobodnaMesta.Name = "LblSlobodnaMesta";
            this.LblSlobodnaMesta.Size = new System.Drawing.Size(157, 20);
            this.LblSlobodnaMesta.TabIndex = 11;
            this.LblSlobodnaMesta.Text = "Broj slobodnih mesta";
            // 
            // LblCena
            // 
            this.LblCena.AutoSize = true;
            this.LblCena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCena.Location = new System.Drawing.Point(231, 229);
            this.LblCena.Name = "LblCena";
            this.LblCena.Size = new System.Drawing.Size(55, 20);
            this.LblCena.TabIndex = 12;
            this.LblCena.Text = "Cena: ";
            // 
            // RezervisanjeMesta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LblCena);
            this.Controls.Add(this.LblSlobodnaMesta);
            this.Controls.Add(this.LblKolicina);
            this.Controls.Add(this.LblTermin);
            this.Controls.Add(this.LblTip);
            this.Controls.Add(this.TBoxCena);
            this.Controls.Add(this.NumKolicina);
            this.Controls.Add(this.CBoxTermin);
            this.Controls.Add(this.BtnRezervisi);
            this.Controls.Add(this.TBoxSlobodnaMesta);
            this.Controls.Add(this.CBoxTipMesta);
            this.Name = "RezervisanjeMesta";
            this.Text = "RezervisanjeMesta";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RezervisanjeMesta_FormClosed);
            this.Load += new System.EventHandler(this.RezervisanjeMesta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumKolicina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBoxTipMesta;
        private System.Windows.Forms.TextBox TBoxSlobodnaMesta;
        private System.Windows.Forms.Button BtnRezervisi;
        private System.Windows.Forms.ComboBox CBoxTermin;
        private System.Windows.Forms.NumericUpDown NumKolicina;
        private System.Windows.Forms.TextBox TBoxCena;
        private System.Windows.Forms.Label LblTip;
        private System.Windows.Forms.Label LblTermin;
        private System.Windows.Forms.Label LblKolicina;
        private System.Windows.Forms.Label LblSlobodnaMesta;
        private System.Windows.Forms.Label LblCena;
    }
}