namespace SEM
{
    partial class Form6
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtAllowance = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.datefrom = new MetroFramework.Controls.MetroDateTime();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(24, 44);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(198, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Enter your allowance for the day";
            // 
            // txtAllowance
            // 
            this.txtAllowance.Lines = new string[0];
            this.txtAllowance.Location = new System.Drawing.Point(64, 76);
            this.txtAllowance.MaxLength = 32767;
            this.txtAllowance.Name = "txtAllowance";
            this.txtAllowance.PasswordChar = '\0';
            this.txtAllowance.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAllowance.SelectedText = "";
            this.txtAllowance.Size = new System.Drawing.Size(124, 23);
            this.txtAllowance.TabIndex = 1;
            this.txtAllowance.UseSelectable = true;
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.metroButton1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.metroButton1.Location = new System.Drawing.Point(98, 124);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(49, 23);
            this.metroButton1.TabIndex = 2;
            this.metroButton1.Text = "OK";
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseCustomForeColor = true;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.UseStyleColors = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // datefrom
            // 
            this.datefrom.Location = new System.Drawing.Point(3, 8);
            this.datefrom.MinimumSize = new System.Drawing.Size(0, 29);
            this.datefrom.Name = "datefrom";
            this.datefrom.Size = new System.Drawing.Size(209, 29);
            this.datefrom.TabIndex = 3;
            this.datefrom.Visible = false;
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 160);
            this.Controls.Add(this.datefrom);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.txtAllowance);
            this.Controls.Add(this.metroLabel1);
            this.Name = "Form6";
            this.TransparencyKey = System.Drawing.SystemColors.Desktop;
            this.Load += new System.EventHandler(this.Form6_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtAllowance;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroDateTime datefrom;
    }
}