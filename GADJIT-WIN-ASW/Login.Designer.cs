﻿
namespace GADJIT_WIN_ASW
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
            this.LabelHelp = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonLogin = new System.Windows.Forms.Button();
            this.TextBoxPassWord = new System.Windows.Forms.TextBox();
            this.TextBoxEMail = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.PictureBoxExit = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelHelp
            // 
            this.LabelHelp.AutoSize = true;
            this.LabelHelp.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelHelp.Location = new System.Drawing.Point(13, 469);
            this.LabelHelp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelHelp.Name = "LabelHelp";
            this.LabelHelp.Size = new System.Drawing.Size(70, 23);
            this.LabelHelp.TabIndex = 14;
            this.LabelHelp.Text = "Aide ?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 293);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 23);
            this.label2.TabIndex = 19;
            this.label2.Text = "Mot de passe :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(122, 227);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Email :";
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.BackColor = System.Drawing.Color.Goldenrod;
            this.ButtonLogin.FlatAppearance.BorderSize = 0;
            this.ButtonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLogin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLogin.ForeColor = System.Drawing.Color.White;
            this.ButtonLogin.Location = new System.Drawing.Point(392, 372);
            this.ButtonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Size = new System.Drawing.Size(168, 50);
            this.ButtonLogin.TabIndex = 13;
            this.ButtonLogin.Text = "CONNECTER";
            this.ButtonLogin.UseVisualStyleBackColor = false;
            this.ButtonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // TextBoxPassWord
            // 
            this.TextBoxPassWord.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TextBoxPassWord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxPassWord.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxPassWord.Location = new System.Drawing.Point(201, 287);
            this.TextBoxPassWord.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxPassWord.MaxLength = 16;
            this.TextBoxPassWord.Multiline = true;
            this.TextBoxPassWord.Name = "TextBoxPassWord";
            this.TextBoxPassWord.PasswordChar = '*';
            this.TextBoxPassWord.Size = new System.Drawing.Size(359, 29);
            this.TextBoxPassWord.TabIndex = 12;
            this.TextBoxPassWord.TextChanged += new System.EventHandler(this.TextBoxPassWord_TextChanged);
            // 
            // TextBoxEMail
            // 
            this.TextBoxEMail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TextBoxEMail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxEMail.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxEMail.Location = new System.Drawing.Point(201, 221);
            this.TextBoxEMail.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxEMail.Multiline = true;
            this.TextBoxEMail.Name = "TextBoxEMail";
            this.TextBoxEMail.Size = new System.Drawing.Size(359, 29);
            this.TextBoxEMail.TabIndex = 11;
            this.TextBoxEMail.TextChanged += new System.EventHandler(this.TextBoxEMail_TextChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::GADJIT_WIN_ASW.Properties.Resources.namewithstyle;
            this.pictureBox3.Location = new System.Drawing.Point(53, 23);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(477, 123);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 17;
            this.pictureBox3.TabStop = false;
            // 
            // PictureBoxExit
            // 
            this.PictureBoxExit.Image = global::GADJIT_WIN_ASW.Properties.Resources.shutdown_60px;
            this.PictureBoxExit.Location = new System.Drawing.Point(986, -1);
            this.PictureBoxExit.Margin = new System.Windows.Forms.Padding(4);
            this.PictureBoxExit.Name = "PictureBoxExit";
            this.PictureBoxExit.Size = new System.Drawing.Size(42, 41);
            this.PictureBoxExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxExit.TabIndex = 16;
            this.PictureBoxExit.TabStop = false;
            this.PictureBoxExit.Click += new System.EventHandler(this.PictureBoxExit_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GADJIT_WIN_ASW.Properties.Resources.logowithphone;
            this.pictureBox2.Location = new System.Drawing.Point(588, -1);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(440, 493);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1026, 492);
            this.Controls.Add(this.LabelHelp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.PictureBoxExit);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ButtonLogin);
            this.Controls.Add(this.TextBoxPassWord);
            this.Controls.Add(this.TextBoxEMail);
            this.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelHelp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox PictureBoxExit;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button ButtonLogin;
        private System.Windows.Forms.TextBox TextBoxPassWord;
        public System.Windows.Forms.TextBox TextBoxEMail;
    }
}