﻿
namespace GADJIT_WIN_ASW
{
    partial class UnlockWorkerPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnlockWorkerPanel));
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonLogin = new System.Windows.Forms.Button();
            this.LogoutButton = new GADJIT_WIN_ASW.CircularPicture();
            this.TextBoxPassWord = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.LogoutButton)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 23);
            this.label2.TabIndex = 27;
            this.label2.Text = "Mot de passe";
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.BackColor = System.Drawing.Color.Teal;
            this.ButtonLogin.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.ButtonLogin.FlatAppearance.BorderSize = 0;
            this.ButtonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLogin.ForeColor = System.Drawing.Color.White;
            this.ButtonLogin.Location = new System.Drawing.Point(17, 133);
            this.ButtonLogin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Size = new System.Drawing.Size(104, 28);
            this.ButtonLogin.TabIndex = 26;
            this.ButtonLogin.Text = "RECONNECTER";
            this.ButtonLogin.UseVisualStyleBackColor = false;
            this.ButtonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // LogoutButton
            // 
            this.LogoutButton.Image = global::GADJIT_WIN_ASW.Properties.Resources.logout_rounded_left_48px;
            this.LogoutButton.Location = new System.Drawing.Point(112, 1);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(36, 37);
            this.LogoutButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoutButton.TabIndex = 25;
            this.LogoutButton.TabStop = false;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // TextBoxPassWord
            // 
            this.TextBoxPassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxPassWord.Location = new System.Drawing.Point(17, 93);
            this.TextBoxPassWord.Name = "TextBoxPassWord";
            this.TextBoxPassWord.PasswordChar = '*';
            this.TextBoxPassWord.Size = new System.Drawing.Size(104, 22);
            this.TextBoxPassWord.TabIndex = 24;
            // 
            // UnlockWorkerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(149, 189);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ButtonLogin);
            this.Controls.Add(this.LogoutButton);
            this.Controls.Add(this.TextBoxPassWord);
            this.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UnlockWorkerPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UnlockWorkerPanel";
            ((System.ComponentModel.ISupportInitialize)(this.LogoutButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonLogin;
        private CircularPicture LogoutButton;
        private System.Windows.Forms.TextBox TextBoxPassWord;
    }
}