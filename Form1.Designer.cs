namespace SEM
{
    partial class Form1
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
            this.txtPasswordLogin = new MetroFramework.Controls.MetroTextBox();
            this.txtUsernameLogin = new MetroFramework.Controls.MetroTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLogin = new MetroFramework.Controls.MetroButton();
            this.btnToRegister = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPasswordLogin
            // 
            this.txtPasswordLogin.Lines = new string[0];
            this.txtPasswordLogin.Location = new System.Drawing.Point(140, 84);
            this.txtPasswordLogin.MaxLength = 32767;
            this.txtPasswordLogin.Name = "txtPasswordLogin";
            this.txtPasswordLogin.PasswordChar = '●';
            this.txtPasswordLogin.WaterMark = "Password";
            this.txtPasswordLogin.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPasswordLogin.SelectedText = "";
            this.txtPasswordLogin.Size = new System.Drawing.Size(122, 23);
            this.txtPasswordLogin.TabIndex = 7;
            this.txtPasswordLogin.UseSelectable = true;
            this.txtPasswordLogin.UseSystemPasswordChar = true;
            // 
            // txtUsernameLogin
            // 
            this.txtUsernameLogin.Lines = new string[0];
            this.txtUsernameLogin.Location = new System.Drawing.Point(141, 46);
            this.txtUsernameLogin.MaxLength = 32767;
            this.txtUsernameLogin.Name = "txtUsernameLogin";
            this.txtUsernameLogin.PasswordChar = '\0';
            this.txtUsernameLogin.WaterMark = "Username";
            this.txtUsernameLogin.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUsernameLogin.SelectedText = "";
            this.txtUsernameLogin.Size = new System.Drawing.Size(122, 23);
            this.txtUsernameLogin.TabIndex = 6;
            this.txtUsernameLogin.UseSelectable = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SEM.Properties.Resources.sem3;
            this.pictureBox1.Location = new System.Drawing.Point(-13, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogin.Location = new System.Drawing.Point(140, 131);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(54, 23);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseCustomBackColor = true;
            this.btnLogin.UseCustomForeColor = true;
            this.btnLogin.UseSelectable = true;
            this.btnLogin.UseStyleColors = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click_1);
            // 
            // btnToRegister
            // 
            this.btnToRegister.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnToRegister.Location = new System.Drawing.Point(201, 130);
            this.btnToRegister.Name = "btnToRegister";
            this.btnToRegister.Size = new System.Drawing.Size(62, 23);
            this.btnToRegister.TabIndex = 10;
            this.btnToRegister.Text = "Register";
            this.btnToRegister.UseCustomBackColor = true;
            this.btnToRegister.UseCustomForeColor = true;
            this.btnToRegister.UseSelectable = true;
            this.btnToRegister.UseStyleColors = true;
            this.btnToRegister.Click += new System.EventHandler(this.btnToRegister_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 189);
            this.Controls.Add(this.btnToRegister);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPasswordLogin);
            this.Controls.Add(this.txtUsernameLogin);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtPasswordLogin;
        private MetroFramework.Controls.MetroTextBox txtUsernameLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroButton btnLogin;
        private MetroFramework.Controls.MetroButton btnToRegister;

    }
}

