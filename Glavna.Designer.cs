namespace projekat_2026_StefanAndrejevic
{
    partial class Glavna
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.BtnRezervisi = new System.Windows.Forms.Button();
            this.BtnMojeRezervacije = new System.Windows.Forms.Button();
            this.BtnLogOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnRezervisi
            // 
            this.BtnRezervisi.Location = new System.Drawing.Point(77, 145);
            this.BtnRezervisi.Name = "BtnRezervisi";
            this.BtnRezervisi.Size = new System.Drawing.Size(150, 47);
            this.BtnRezervisi.TabIndex = 0;
            this.BtnRezervisi.Text = "Napravi rezervaciju";
            this.BtnRezervisi.UseVisualStyleBackColor = true;
            this.BtnRezervisi.Click += new System.EventHandler(this.BtnRezervisi_Click);
            // 
            // BtnMojeRezervacije
            // 
            this.BtnMojeRezervacije.Location = new System.Drawing.Point(307, 145);
            this.BtnMojeRezervacije.Name = "BtnMojeRezervacije";
            this.BtnMojeRezervacije.Size = new System.Drawing.Size(150, 47);
            this.BtnMojeRezervacije.TabIndex = 1;
            this.BtnMojeRezervacije.Text = "Moji racuni";
            this.BtnMojeRezervacije.UseVisualStyleBackColor = true;
            this.BtnMojeRezervacije.Click += new System.EventHandler(this.BtnMojiRacuni_Click);
            // 
            // BtnLogOut
            // 
            this.BtnLogOut.BackColor = System.Drawing.Color.LightCoral;
            this.BtnLogOut.Location = new System.Drawing.Point(12, 12);
            this.BtnLogOut.Name = "BtnLogOut";
            this.BtnLogOut.Size = new System.Drawing.Size(75, 23);
            this.BtnLogOut.TabIndex = 2;
            this.BtnLogOut.Text = "Log out";
            this.BtnLogOut.UseVisualStyleBackColor = false;
            this.BtnLogOut.Click += new System.EventHandler(this.BtnLogOut_Click);
            // 
            // Glavna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 259);
            this.Controls.Add(this.BtnLogOut);
            this.Controls.Add(this.BtnMojeRezervacije);
            this.Controls.Add(this.BtnRezervisi);
            this.Name = "Glavna";
            this.Text = "Igraonica";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Glavna_FormClosed);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button BtnRezervisi;
        private System.Windows.Forms.Button BtnMojeRezervacije;
        private System.Windows.Forms.Button BtnLogOut;
    }
}
