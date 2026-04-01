namespace projekat_2026_StefanAndrejevic
{
    partial class Registracija
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
            this.LblIme = new System.Windows.Forms.Label();
            this.LblPrezime = new System.Windows.Forms.Label();
            this.LblEmail = new System.Windows.Forms.Label();
            this.LblPass = new System.Windows.Forms.Label();
            this.BtnPassOpet = new System.Windows.Forms.Label();
            this.BtnRegistracija = new System.Windows.Forms.Button();
            this.TboxIme = new System.Windows.Forms.TextBox();
            this.TboxPrezime = new System.Windows.Forms.TextBox();
            this.TboxEmail = new System.Windows.Forms.TextBox();
            this.TboxPass = new System.Windows.Forms.TextBox();
            this.TboxPassOpet = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LblIme
            // 
            this.LblIme.AutoSize = true;
            this.LblIme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblIme.Location = new System.Drawing.Point(46, 39);
            this.LblIme.Name = "LblIme";
            this.LblIme.Size = new System.Drawing.Size(29, 16);
            this.LblIme.TabIndex = 0;
            this.LblIme.Text = "Ime";
            // 
            // LblPrezime
            // 
            this.LblPrezime.AutoSize = true;
            this.LblPrezime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPrezime.Location = new System.Drawing.Point(46, 93);
            this.LblPrezime.Name = "LblPrezime";
            this.LblPrezime.Size = new System.Drawing.Size(56, 16);
            this.LblPrezime.TabIndex = 1;
            this.LblPrezime.Text = "Prezime";
            // 
            // LblEmail
            // 
            this.LblEmail.AutoSize = true;
            this.LblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEmail.Location = new System.Drawing.Point(46, 147);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(45, 16);
            this.LblEmail.TabIndex = 2;
            this.LblEmail.Text = "E-mail";
            // 
            // LblPass
            // 
            this.LblPass.AutoSize = true;
            this.LblPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPass.Location = new System.Drawing.Point(46, 201);
            this.LblPass.Name = "LblPass";
            this.LblPass.Size = new System.Drawing.Size(34, 16);
            this.LblPass.TabIndex = 3;
            this.LblPass.Text = "Sifra";
            // 
            // BtnPassOpet
            // 
            this.BtnPassOpet.AutoSize = true;
            this.BtnPassOpet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPassOpet.Location = new System.Drawing.Point(46, 255);
            this.BtnPassOpet.Name = "BtnPassOpet";
            this.BtnPassOpet.Size = new System.Drawing.Size(83, 16);
            this.BtnPassOpet.TabIndex = 4;
            this.BtnPassOpet.Text = "Sifra ponovo";
            // 
            // BtnRegistracija
            // 
            this.BtnRegistracija.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistracija.Location = new System.Drawing.Point(96, 305);
            this.BtnRegistracija.Name = "BtnRegistracija";
            this.BtnRegistracija.Size = new System.Drawing.Size(143, 29);
            this.BtnRegistracija.TabIndex = 5;
            this.BtnRegistracija.Text = "Registruj se";
            this.BtnRegistracija.UseVisualStyleBackColor = true;
            this.BtnRegistracija.Click += new System.EventHandler(this.BtnRegistracija_Click);
            // 
            // TboxIme
            // 
            this.TboxIme.Location = new System.Drawing.Point(173, 39);
            this.TboxIme.Name = "TboxIme";
            this.TboxIme.Size = new System.Drawing.Size(142, 20);
            this.TboxIme.TabIndex = 6;
            // 
            // TboxPrezime
            // 
            this.TboxPrezime.Location = new System.Drawing.Point(173, 93);
            this.TboxPrezime.Name = "TboxPrezime";
            this.TboxPrezime.Size = new System.Drawing.Size(142, 20);
            this.TboxPrezime.TabIndex = 7;
            // 
            // TboxEmail
            // 
            this.TboxEmail.Location = new System.Drawing.Point(173, 147);
            this.TboxEmail.Name = "TboxEmail";
            this.TboxEmail.Size = new System.Drawing.Size(142, 20);
            this.TboxEmail.TabIndex = 8;
            // 
            // TboxPass
            // 
            this.TboxPass.Location = new System.Drawing.Point(173, 201);
            this.TboxPass.Name = "TboxPass";
            this.TboxPass.Size = new System.Drawing.Size(142, 20);
            this.TboxPass.TabIndex = 9;
            // 
            // TboxPassOpet
            // 
            this.TboxPassOpet.Location = new System.Drawing.Point(173, 255);
            this.TboxPassOpet.Name = "TboxPassOpet";
            this.TboxPassOpet.Size = new System.Drawing.Size(142, 20);
            this.TboxPassOpet.TabIndex = 10;
            // 
            // Registracija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 346);
            this.Controls.Add(this.TboxPassOpet);
            this.Controls.Add(this.TboxPass);
            this.Controls.Add(this.TboxEmail);
            this.Controls.Add(this.TboxPrezime);
            this.Controls.Add(this.TboxIme);
            this.Controls.Add(this.BtnRegistracija);
            this.Controls.Add(this.BtnPassOpet);
            this.Controls.Add(this.LblPass);
            this.Controls.Add(this.LblEmail);
            this.Controls.Add(this.LblPrezime);
            this.Controls.Add(this.LblIme);
            this.Name = "Registracija";
            this.Text = "Registracija";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblIme;
        private System.Windows.Forms.Label LblPrezime;
        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.Label LblPass;
        private System.Windows.Forms.Label BtnPassOpet;
        private System.Windows.Forms.Button BtnRegistracija;
        private System.Windows.Forms.TextBox TboxIme;
        private System.Windows.Forms.TextBox TboxPrezime;
        private System.Windows.Forms.TextBox TboxEmail;
        private System.Windows.Forms.TextBox TboxPass;
        private System.Windows.Forms.TextBox TboxPassOpet;
    }
}