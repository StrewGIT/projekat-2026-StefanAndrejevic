namespace projekat_2026_StefanAndrejevic
{
    partial class CalendarPopUp
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
            this.BtnIzaberiMesto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Calendar
            // 
            this.Calendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Calendar.Location = new System.Drawing.Point(18, 2);
            this.Calendar.Name = "Calendar";
            this.Calendar.TabIndex = 0;
            // 
            // BtnIzaberiMesto
            // 
            this.BtnIzaberiMesto.Location = new System.Drawing.Point(18, 164);
            this.BtnIzaberiMesto.Name = "BtnIzaberiMesto";
            this.BtnIzaberiMesto.Size = new System.Drawing.Size(199, 34);
            this.BtnIzaberiMesto.TabIndex = 1;
            this.BtnIzaberiMesto.Text = "Izaberi mesto";
            this.BtnIzaberiMesto.UseVisualStyleBackColor = true;
            this.BtnIzaberiMesto.Click += new System.EventHandler(this.BtnIzaberiMesto_Click);
            // 
            // CalendarPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 202);
            this.Controls.Add(this.BtnIzaberiMesto);
            this.Controls.Add(this.Calendar);
            this.Name = "CalendarPopUp";
            this.Text = "CalendarPopUp";
            this.Load += new System.EventHandler(this.CalendarPopUp_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar Calendar;
        private System.Windows.Forms.Button BtnIzaberiMesto;
    }
}