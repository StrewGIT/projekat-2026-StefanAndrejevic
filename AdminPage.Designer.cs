namespace projekat_2026_StefanAndrejevic
{
    partial class AdminPage
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
            ((System.ComponentModel.ISupportInitialize)(this.DGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Calendar
            // 
            this.Calendar.Location = new System.Drawing.Point(53, 40);
            this.Calendar.Name = "Calendar";
            this.Calendar.TabIndex = 0;
            // 
            // BtnDodajRadniDan
            // 
            this.BtnDodajRadniDan.Location = new System.Drawing.Point(53, 310);
            this.BtnDodajRadniDan.Name = "BtnDodajRadniDan";
            this.BtnDodajRadniDan.Size = new System.Drawing.Size(199, 34);
            this.BtnDodajRadniDan.TabIndex = 1;
            this.BtnDodajRadniDan.Text = "Dodaj radni dan i generisi termine";
            this.BtnDodajRadniDan.UseVisualStyleBackColor = true;
            this.BtnDodajRadniDan.Click += new System.EventHandler(this.BtnDodajRadniDan_Click);
            // 
            // DTimePocetak
            // 
            this.DTimePocetak.Location = new System.Drawing.Point(53, 230);
            this.DTimePocetak.Name = "DTimePocetak";
            this.DTimePocetak.Size = new System.Drawing.Size(92, 20);
            this.DTimePocetak.TabIndex = 2;
            // 
            // DTimeKraj
            // 
            this.DTimeKraj.Location = new System.Drawing.Point(160, 230);
            this.DTimeKraj.Name = "DTimeKraj";
            this.DTimeKraj.Size = new System.Drawing.Size(92, 20);
            this.DTimeKraj.TabIndex = 3;
            // 
            // LblDatum
            // 
            this.LblDatum.AutoSize = true;
            this.LblDatum.Location = new System.Drawing.Point(134, 18);
            this.LblDatum.Name = "LblDatum";
            this.LblDatum.Size = new System.Drawing.Size(38, 13);
            this.LblDatum.TabIndex = 4;
            this.LblDatum.Text = "Datum";
            // 
            // LblPocetak
            // 
            this.LblPocetak.AutoSize = true;
            this.LblPocetak.Location = new System.Drawing.Point(55, 211);
            this.LblPocetak.Name = "LblPocetak";
            this.LblPocetak.Size = new System.Drawing.Size(84, 13);
            this.LblPocetak.TabIndex = 5;
            this.LblPocetak.Text = "Vreme otvaranja";
            // 
            // LblKraj
            // 
            this.LblKraj.AutoSize = true;
            this.LblKraj.Location = new System.Drawing.Point(160, 211);
            this.LblKraj.Name = "LblKraj";
            this.LblKraj.Size = new System.Drawing.Size(89, 13);
            this.LblKraj.TabIndex = 6;
            this.LblKraj.Text = "Vreme zatvaranja";
            // 
            // LblTrajanje
            // 
            this.LblTrajanje.AutoSize = true;
            this.LblTrajanje.Location = new System.Drawing.Point(91, 264);
            this.LblTrajanje.Name = "LblTrajanje";
            this.LblTrajanje.Size = new System.Drawing.Size(117, 13);
            this.LblTrajanje.TabIndex = 7;
            this.LblTrajanje.Text = "Trajanje jednog termina";
            // 
            // DTimeTrajanje
            // 
            this.DTimeTrajanje.Location = new System.Drawing.Point(104, 284);
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
            this.DGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGridView.Size = new System.Drawing.Size(339, 162);
            this.DGridView.TabIndex = 9;
            // 
            // LblMesta
            // 
            this.LblMesta.AutoSize = true;
            this.LblMesta.Location = new System.Drawing.Point(540, 18);
            this.LblMesta.Name = "LblMesta";
            this.LblMesta.Size = new System.Drawing.Size(36, 13);
            this.LblMesta.TabIndex = 10;
            this.LblMesta.Text = "Mesta";
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
            // 
            // AdminPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.Text = "AdminPage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminPage_FormClosed);
            this.Load += new System.EventHandler(this.AdminPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGridView)).EndInit();
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
    }
}