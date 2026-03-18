namespace projekat_2026_StefanAndrejevic
{
    partial class Login
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
            this.LblEmail = new System.Windows.Forms.Label();
            this.LblPass = new System.Windows.Forms.Label();
            this.TBoxEmail = new System.Windows.Forms.TextBox();
            this.TBoxPass = new System.Windows.Forms.TextBox();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblEmail
            // 
            this.LblEmail.AutoSize = true;
            this.LblEmail.Location = new System.Drawing.Point(41, 42);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(36, 13);
            this.LblEmail.TabIndex = 0;
            this.LblEmail.Text = "E-Mail";
            // 
            // LblPass
            // 
            this.LblPass.AutoSize = true;
            this.LblPass.Location = new System.Drawing.Point(41, 113);
            this.LblPass.Name = "LblPass";
            this.LblPass.Size = new System.Drawing.Size(53, 13);
            this.LblPass.TabIndex = 1;
            this.LblPass.Text = "Password";
            // 
            // TBoxEmail
            // 
            this.TBoxEmail.Location = new System.Drawing.Point(123, 42);
            this.TBoxEmail.Name = "TBoxEmail";
            this.TBoxEmail.Size = new System.Drawing.Size(100, 20);
            this.TBoxEmail.TabIndex = 2;
            // 
            // TBoxPass
            // 
            this.TBoxPass.Location = new System.Drawing.Point(123, 113);
            this.TBoxPass.Name = "TBoxPass";
            this.TBoxPass.Size = new System.Drawing.Size(100, 20);
            this.TBoxPass.TabIndex = 3;
            // 
            // BtnLogin
            // 
            this.BtnLogin.Location = new System.Drawing.Point(71, 185);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(107, 28);
            this.BtnLogin.TabIndex = 4;
            this.BtnLogin.Text = "Log in";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 287);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.TBoxPass);
            this.Controls.Add(this.TBoxEmail);
            this.Controls.Add(this.LblPass);
            this.Controls.Add(this.LblEmail);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.Label LblPass;
        private System.Windows.Forms.TextBox TBoxEmail;
        private System.Windows.Forms.TextBox TBoxPass;
        private System.Windows.Forms.Button BtnLogin;
    }
}

