namespace RPAQuiz.features.sign_in.views
{
    partial class SignIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignIn));
            this.LblTitle = new System.Windows.Forms.Label();
            this.LblUsername = new System.Windows.Forms.Label();
            this.LblPassword = new System.Windows.Forms.Label();
            this.TxtUsername = new System.Windows.Forms.TextBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.BtnSignIn = new System.Windows.Forms.Button();
            this.CboLanguage = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // LblTitle
            // 
            resources.ApplyResources(this.LblTitle, "LblTitle");
            this.LblTitle.Name = "LblTitle";
            // 
            // LblUsername
            // 
            resources.ApplyResources(this.LblUsername, "LblUsername");
            this.LblUsername.Name = "LblUsername";
            // 
            // LblPassword
            // 
            resources.ApplyResources(this.LblPassword, "LblPassword");
            this.LblPassword.Name = "LblPassword";
            // 
            // TxtUsername
            // 
            this.TxtUsername.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.TxtUsername, "TxtUsername");
            this.TxtUsername.Name = "TxtUsername";
            // 
            // TxtPassword
            // 
            this.TxtPassword.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.TxtPassword, "TxtPassword");
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.UseSystemPasswordChar = true;
            this.TxtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPassword_KeyDown);
            // 
            // BtnSignIn
            // 
            resources.ApplyResources(this.BtnSignIn, "BtnSignIn");
            this.BtnSignIn.Name = "BtnSignIn";
            this.BtnSignIn.UseVisualStyleBackColor = true;
            this.BtnSignIn.Click += new System.EventHandler(this.BtnSignIn_Click);
            // 
            // CboLanguage
            // 
            this.CboLanguage.FormattingEnabled = true;
            this.CboLanguage.Items.AddRange(new object[] {
            resources.GetString("CboLanguage.Items"),
            resources.GetString("CboLanguage.Items1")});
            resources.ApplyResources(this.CboLanguage, "CboLanguage");
            this.CboLanguage.Name = "CboLanguage";
            this.CboLanguage.DropDownClosed += new System.EventHandler(this.CboLanguage_DropDownClosed);
            // 
            // SignIn
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CboLanguage);
            this.Controls.Add(this.BtnSignIn);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.TxtUsername);
            this.Controls.Add(this.LblPassword);
            this.Controls.Add(this.LblUsername);
            this.Controls.Add(this.LblTitle);
            this.Name = "SignIn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SignIn_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.Label LblUsername;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.TextBox TxtUsername;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Button BtnSignIn;
        private System.Windows.Forms.ComboBox CboLanguage;
    }
}