namespace projekat_2026_StefanAndrejevic
{
    partial class Glavna
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
            this.BtnRezervisi = new System.Windows.Forms.Button();
            this.BtnMojeRezervacije = new System.Windows.Forms.Button();
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
            this.BtnMojeRezervacije.Text = "Moje rezervacije";
            this.BtnMojeRezervacije.UseVisualStyleBackColor = true;
            // 
            // Glavna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 259);
            this.Controls.Add(this.BtnMojeRezervacije);
            this.Controls.Add(this.BtnRezervisi);
            this.Name = "Glavna";
            this.Text = "Glavna";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Glavna_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnRezervisi;
        private System.Windows.Forms.Button BtnMojeRezervacije;
    }
}