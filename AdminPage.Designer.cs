namespace projekat_2026_StefanAndrejevic
{
    partial class AdminPage
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
            this.Calendar = new System.Windows.Forms.MonthCalendar();
            this.BtnDodajRadniDan = new System.Windows.Forms.Button();
            this.DTimePocetak = new System.Windows.Forms.DateTimePicker();
            this.DTimeKraj = new System.Windows.Forms.DateTimePicker();
            this.LblDatum = new System.Windows.Forms.Label();
            this.LblPocetak = new System.Windows.Forms.Label();
            this.LblKraj = new System.Windows.Forms.Label();
            this.LblTrajanje = new System.Windows.Forms.Label();
            this.DTimeTrajanje = new System.Windows.Forms.DateTimePicker();
            this.DGridView = new System.Windows.Forms.DataGridView();
            this.LblMesta = new System.Windows.Forms.Label();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnInsert = new System.Windows.Forms.Button();
            this.BtnDodajArtikal = new System.Windows.Forms.Button();
            this.BtnPromeniArtikal = new System.Windows.Forms.Button();
            this.BtnObrisiArtikal = new System.Windows.Forms.Button();
            this.LblArtikli = new System.Windows.Forms.Label();
            this.DGridArtikli = new System.Windows.Forms.DataGridView();
            this.BtnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGridArtikli)).BeginInit();
            this.SuspendLayout();
            // 
            // Calendar
            // 
            this.Calendar.Location = new System.Drawing.Point(59, 129);
            this.Calendar.Name = "Calendar";
            this.Calendar.TabIndex = 0;
            // 
            // BtnDodajRadniDan
            // 
            this.BtnDodajRadniDan.BackColor = System.Drawing.Color.PaleGreen;
            this.BtnDodajRadniDan.Location = new System.Drawing.Point(59, 399);
            this.BtnDodajRadniDan.Name = "BtnDodajRadniDan";
            this.BtnDodajRadniDan.Size = new System.Drawing.Size(199, 34);
            this.BtnDodajRadniDan.TabIndex = 1;
            this.BtnDodajRadniDan.Text = "Dodaj radni dan i generisi termine";
            this.BtnDodajRadniDan.UseVisualStyleBackColor = false;
            this.BtnDodajRadniDan.Click += new System.EventHandler(this.BtnDodajRadniDan_Click);
            // 
            // DTimePocetak
            // 
            this.DTimePocetak.Location = new System.Drawing.Point(59, 319);
            this.DTimePocetak.Name = "DTimePocetak";
            this.DTimePocetak.Size = new System.Drawing.Size(92, 20);
            this.DTimePocetak.TabIndex = 2;
            // 
            // DTimeKraj
            // 
            this.DTimeKraj.Location = new System.Drawing.Point(166, 319);
            this.DTimeKraj.Name = "DTimeKraj";
            this.DTimeKraj.Size = new System.Drawing.Size(92, 20);
            this.DTimeKraj.TabIndex = 3;
            // 
            // LblDatum
            // 
            this.LblDatum.AutoSize = true;
            this.LblDatum.Location = new System.Drawing.Point(140, 107);
            this.LblDatum.Name = "LblDatum";
            this.LblDatum.Size = new System.Drawing.Size(38, 13);
            this.LblDatum.TabIndex = 4;
            this.LblDatum.Text = "Datum";
            // 
            // LblPocetak
            // 
            this.LblPocetak.AutoSize = true;
            this.LblPocetak.Location = new System.Drawing.Point(61, 300);
            this.LblPocetak.Name = "LblPocetak";
            this.LblPocetak.Size = new System.Drawing.Size(84, 13);
            this.LblPocetak.TabIndex = 5;
            this.LblPocetak.Text = "Vreme otvaranja";
            // 
            // LblKraj
            // 
            this.LblKraj.AutoSize = true;
            this.LblKraj.Location = new System.Drawing.Point(166, 300);
            this.LblKraj.Name = "LblKraj";
            this.LblKraj.Size = new System.Drawing.Size(89, 13);
            this.LblKraj.TabIndex = 6;
            this.LblKraj.Text = "Vreme zatvaranja";
            // 
            // LblTrajanje
            // 
            this.LblTrajanje.AutoSize = true;
            this.LblTrajanje.Location = new System.Drawing.Point(97, 353);
            this.LblTrajanje.Name = "LblTrajanje";
            this.LblTrajanje.Size = new System.Drawing.Size(117, 13);
            this.LblTrajanje.TabIndex = 7;
            this.LblTrajanje.Text = "Trajanje jednog termina";
            // 
            // DTimeTrajanje
            // 
            this.DTimeTrajanje.Location = new System.Drawing.Point(110, 373);
            this.DTimeTrajanje.Name = "DTimeTrajanje";
            this.DTimeTrajanje.Size = new System.Drawing.Size(92, 20);
            this.DTimeTrajanje.TabIndex = 8;
            // 
            // DGridView
            // 
            this.DGridView.AllowUserToAddRows = false;
            this.DGridView.AllowUserToDeleteRows = false;
            this.DGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGridView.Location = new System.Drawing.Point(380, 40);
            this.DGridView.MultiSelect = false;
            this.DGridView.Name = "DGridView";
            this.DGridView.ReadOnly = true;
            this.DGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGridView.Size = new System.Drawing.Size(339, 162);
            this.DGridView.TabIndex = 9;
            // 
            // LblMesta
            // 
            this.LblMesta.AutoSize = true;
            this.LblMesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.LblMesta.Location = new System.Drawing.Point(520, 18);
            this.LblMesta.Name = "LblMesta";
            this.LblMesta.Size = new System.Drawing.Size(88, 15);
            this.LblMesta.TabIndex = 10;
            this.LblMesta.Text = "Tipovi Mesta";
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.LightCoral;
            this.BtnDelete.Location = new System.Drawing.Point(380, 211);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(103, 35);
            this.BtnDelete.TabIndex = 11;
            this.BtnDelete.Text = "Obrisi red";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.BackColor = System.Drawing.Color.Khaki;
            this.BtnUpdate.Location = new System.Drawing.Point(489, 211);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(124, 35);
            this.BtnUpdate.TabIndex = 12;
            this.BtnUpdate.Text = "Promeni red";
            this.BtnUpdate.UseVisualStyleBackColor = false;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnInsert
            // 
            this.BtnInsert.BackColor = System.Drawing.Color.PaleGreen;
            this.BtnInsert.Location = new System.Drawing.Point(619, 211);
            this.BtnInsert.Name = "BtnInsert";
            this.BtnInsert.Size = new System.Drawing.Size(100, 35);
            this.BtnInsert.TabIndex = 13;
            this.BtnInsert.Text = "Dodaj novi red";
            this.BtnInsert.UseVisualStyleBackColor = false;
            this.BtnInsert.Click += new System.EventHandler(this.BtnInsert_Click);
            // 
            // BtnDodajArtikal
            // 
            this.BtnDodajArtikal.BackColor = System.Drawing.Color.PaleGreen;
            this.BtnDodajArtikal.Location = new System.Drawing.Point(619, 453);
            this.BtnDodajArtikal.Name = "BtnDodajArtikal";
            this.BtnDodajArtikal.Size = new System.Drawing.Size(100, 35);
            this.BtnDodajArtikal.TabIndex = 18;
            this.BtnDodajArtikal.Text = "Dodaj artikal";
            this.BtnDodajArtikal.UseVisualStyleBackColor = false;
            this.BtnDodajArtikal.Click += new System.EventHandler(this.BtnDodajArtikal_Click);
            // 
            // BtnPromeniArtikal
            // 
            this.BtnPromeniArtikal.BackColor = System.Drawing.Color.Khaki;
            this.BtnPromeniArtikal.Location = new System.Drawing.Point(489, 453);
            this.BtnPromeniArtikal.Name = "BtnPromeniArtikal";
            this.BtnPromeniArtikal.Size = new System.Drawing.Size(124, 35);
            this.BtnPromeniArtikal.TabIndex = 17;
            this.BtnPromeniArtikal.Text = "Promeni artikal";
            this.BtnPromeniArtikal.UseVisualStyleBackColor = false;
            this.BtnPromeniArtikal.Click += new System.EventHandler(this.BtnPromeniArtikal_Click);
            // 
            // BtnObrisiArtikal
            // 
            this.BtnObrisiArtikal.BackColor = System.Drawing.Color.LightCoral;
            this.BtnObrisiArtikal.Location = new System.Drawing.Point(380, 453);
            this.BtnObrisiArtikal.Name = "BtnObrisiArtikal";
            this.BtnObrisiArtikal.Size = new System.Drawing.Size(103, 35);
            this.BtnObrisiArtikal.TabIndex = 16;
            this.BtnObrisiArtikal.Text = "Obrisi artikal";
            this.BtnObrisiArtikal.UseVisualStyleBackColor = false;
            this.BtnObrisiArtikal.Click += new System.EventHandler(this.BtnObrisiArtikal_Click);
            // 
            // LblArtikli
            // 
            this.LblArtikli.AutoSize = true;
            this.LblArtikli.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.LblArtikli.Location = new System.Drawing.Point(520, 260);
            this.LblArtikli.Name = "LblArtikli";
            this.LblArtikli.Size = new System.Drawing.Size(43, 15);
            this.LblArtikli.TabIndex = 15;
            this.LblArtikli.Text = "Artikli";
            // 
            // DGridArtikli
            // 
            this.DGridArtikli.AllowUserToAddRows = false;
            this.DGridArtikli.AllowUserToDeleteRows = false;
            this.DGridArtikli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGridArtikli.Location = new System.Drawing.Point(380, 282);
            this.DGridArtikli.MultiSelect = false;
            this.DGridArtikli.Name = "DGridArtikli";
            this.DGridArtikli.ReadOnly = true;
            this.DGridArtikli.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGridArtikli.Size = new System.Drawing.Size(339, 162);
            this.DGridArtikli.TabIndex = 14;
            // 
            // BtnLogout
            // 
            this.BtnLogout.BackColor = System.Drawing.Color.LightCoral;
            this.BtnLogout.Location = new System.Drawing.Point(23, 18);
            this.BtnLogout.Name = "BtnLogout";
            this.BtnLogout.Size = new System.Drawing.Size(63, 27);
            this.BtnLogout.TabIndex = 19;
            this.BtnLogout.Text = "Log out";
            this.BtnLogout.UseVisualStyleBackColor = false;
            this.BtnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // AdminPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 510);
            this.Controls.Add(this.BtnLogout);
            this.Controls.Add(this.BtnDodajArtikal);
            this.Controls.Add(this.BtnPromeniArtikal);
            this.Controls.Add(this.BtnObrisiArtikal);
            this.Controls.Add(this.LblArtikli);
            this.Controls.Add(this.DGridArtikli);
            this.Controls.Add(this.BtnInsert);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.LblMesta);
            this.Controls.Add(this.DGridView);
            this.Controls.Add(this.DTimeTrajanje);
            this.Controls.Add(this.LblTrajanje);
            this.Controls.Add(this.LblKraj);
            this.Controls.Add(this.LblPocetak);
            this.Controls.Add(this.LblDatum);
            this.Controls.Add(this.DTimeKraj);
            this.Controls.Add(this.DTimePocetak);
            this.Controls.Add(this.BtnDodajRadniDan);
            this.Controls.Add(this.Calendar);
            this.Name = "AdminPage";
            this.Text = "Admin Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminPage_FormClosing);
            this.Load += new System.EventHandler(this.AdminPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGridArtikli)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar Calendar;
        private System.Windows.Forms.Button BtnDodajRadniDan;
        private System.Windows.Forms.DateTimePicker DTimePocetak;
        private System.Windows.Forms.DateTimePicker DTimeKraj;
        private System.Windows.Forms.Label LblDatum;
        private System.Windows.Forms.Label LblPocetak;
        private System.Windows.Forms.Label LblKraj;
        private System.Windows.Forms.Label LblTrajanje;
        private System.Windows.Forms.DateTimePicker DTimeTrajanje;
        private System.Windows.Forms.DataGridView DGridView;
        private System.Windows.Forms.Label LblMesta;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Button BtnInsert;
        private System.Windows.Forms.Button BtnDodajArtikal;
        private System.Windows.Forms.Button BtnPromeniArtikal;
        private System.Windows.Forms.Button BtnObrisiArtikal;
        private System.Windows.Forms.Label LblArtikli;
        private System.Windows.Forms.DataGridView DGridArtikli;
        private System.Windows.Forms.Button BtnLogout;
    }
}
