
namespace GADJIT_WIN_ASW
{
    partial class UnlockAdminPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnlockAdminPanel));
            this.ButtonLogin = new System.Windows.Forms.Button();
            this.TextBoxPassWord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PictureBoxLogOut = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogOut)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.BackColor = System.Drawing.Color.Goldenrod;
            this.ButtonLogin.FlatAppearance.BorderSize = 0;
            this.ButtonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLogin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLogin.ForeColor = System.Drawing.Color.White;
            this.ButtonLogin.Location = new System.Drawing.Point(36, 143);
            this.ButtonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Size = new System.Drawing.Size(130, 41);
            this.ButtonLogin.TabIndex = 14;
            this.ButtonLogin.Text = "Reconnecter";
            this.ButtonLogin.UseVisualStyleBackColor = false;
            this.ButtonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // TextBoxPassWord
            // 
            this.TextBoxPassWord.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TextBoxPassWord.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxPassWord.Location = new System.Drawing.Point(36, 101);
            this.TextBoxPassWord.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxPassWord.Name = "TextBoxPassWord";
            this.TextBoxPassWord.PasswordChar = '*';
            this.TextBoxPassWord.Size = new System.Drawing.Size(130, 23);
            this.TextBoxPassWord.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Mot de passe";
            // 
            // PictureBoxLogOut
            // 
            this.PictureBoxLogOut.BackColor = System.Drawing.Color.Goldenrod;
            this.PictureBoxLogOut.Image = global::GADJIT_WIN_ASW.Properties.Resources.logout;
            this.PictureBoxLogOut.Location = new System.Drawing.Point(159, 12);
            this.PictureBoxLogOut.Name = "PictureBoxLogOut";
            this.PictureBoxLogOut.Size = new System.Drawing.Size(30, 30);
            this.PictureBoxLogOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxLogOut.TabIndex = 21;
            this.PictureBoxLogOut.TabStop = false;
            this.PictureBoxLogOut.Click += new System.EventHandler(this.PictureBoxLogOut_Click);
            // 
            // UnlockAdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(205, 223);
            this.Controls.Add(this.PictureBoxLogOut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBoxPassWord);
            this.Controls.Add(this.ButtonLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UnlockAdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UnlockConfirmation";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ButtonLogin;
        private System.Windows.Forms.TextBox TextBoxPassWord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox PictureBoxLogOut;
    }
}