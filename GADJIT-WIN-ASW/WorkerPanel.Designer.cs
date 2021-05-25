
namespace GADJIT_WIN_ASW
{
    partial class WorkerPanel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ButtomGestionTicket = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LabelEmail = new System.Windows.Forms.Label();
            this.LabelFirstName = new System.Windows.Forms.Label();
            this.LabelLastName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LogoutButton = new GADJIT_WIN_ASW.CircularPicture();
            this.CircularProfilPicture = new GADJIT_WIN_ASW.CircularPicture();
            this.cirucularButton = new GADJIT_WIN_ASW.CirucularButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoutButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CircularProfilPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.LogoutButton);
            this.panel1.Controls.Add(this.ButtomGestionTicket);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 453);
            this.panel1.TabIndex = 1;
            // 
            // ButtomGestionTicket
            // 
            this.ButtomGestionTicket.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ButtomGestionTicket.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtomGestionTicket.FlatAppearance.BorderSize = 0;
            this.ButtomGestionTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtomGestionTicket.ForeColor = System.Drawing.Color.White;
            this.ButtomGestionTicket.Location = new System.Drawing.Point(0, 129);
            this.ButtomGestionTicket.Name = "ButtomGestionTicket";
            this.ButtomGestionTicket.Size = new System.Drawing.Size(250, 40);
            this.ButtomGestionTicket.TabIndex = 1;
            this.ButtomGestionTicket.Text = "Gestion Ticket";
            this.ButtomGestionTicket.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtomGestionTicket.UseCompatibleTextRendering = true;
            this.ButtomGestionTicket.UseVisualStyleBackColor = false;
            this.ButtomGestionTicket.Click += new System.EventHandler(this.ShowSubMenuButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.CircularProfilPicture);
            this.panel2.Controls.Add(this.cirucularButton);
            this.panel2.Controls.Add(this.LabelEmail);
            this.panel2.Controls.Add(this.LabelFirstName);
            this.panel2.Controls.Add(this.LabelLastName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 129);
            this.panel2.TabIndex = 0;
            // 
            // LabelEmail
            // 
            this.LabelEmail.AutoSize = true;
            this.LabelEmail.ForeColor = System.Drawing.Color.White;
            this.LabelEmail.Location = new System.Drawing.Point(3, 102);
            this.LabelEmail.Name = "LabelEmail";
            this.LabelEmail.Size = new System.Drawing.Size(95, 17);
            this.LabelEmail.TabIndex = 6;
            this.LabelEmail.Text = "Worker  Email";
            // 
            // LabelFirstName
            // 
            this.LabelFirstName.AutoSize = true;
            this.LabelFirstName.ForeColor = System.Drawing.Color.White;
            this.LabelFirstName.Location = new System.Drawing.Point(3, 76);
            this.LabelFirstName.Name = "LabelFirstName";
            this.LabelFirstName.Size = new System.Drawing.Size(124, 17);
            this.LabelFirstName.TabIndex = 5;
            this.LabelFirstName.Text = "Worker First Name";
            // 
            // LabelLastName
            // 
            this.LabelLastName.AutoSize = true;
            this.LabelLastName.ForeColor = System.Drawing.Color.White;
            this.LabelLastName.Location = new System.Drawing.Point(3, 46);
            this.LabelLastName.Name = "LabelLastName";
            this.LabelLastName.Size = new System.Drawing.Size(122, 17);
            this.LabelLastName.TabIndex = 4;
            this.LabelLastName.Text = "Worker Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(32, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 30);
            this.label1.TabIndex = 10;
            this.label1.Text = "Espace Employé";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GADJIT_WIN_ASW.Properties.Resources.lock_64px;
            this.pictureBox1.Location = new System.Drawing.Point(190, 105);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // LogoutButton
            // 
            this.LogoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LogoutButton.Image = global::GADJIT_WIN_ASW.Properties.Resources.logout_rounded_left_48px;
            this.LogoutButton.Location = new System.Drawing.Point(0, 403);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(50, 50);
            this.LogoutButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoutButton.TabIndex = 3;
            this.LogoutButton.TabStop = false;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // CircularProfilPicture
            // 
            this.CircularProfilPicture.Image = global::GADJIT_WIN_ASW.Properties.Resources.user_60px;
            this.CircularProfilPicture.Location = new System.Drawing.Point(190, 40);
            this.CircularProfilPicture.Name = "CircularProfilPicture";
            this.CircularProfilPicture.Size = new System.Drawing.Size(60, 60);
            this.CircularProfilPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CircularProfilPicture.TabIndex = 8;
            this.CircularProfilPicture.TabStop = false;
            // 
            // cirucularButton
            // 
            this.cirucularButton.BackColor = System.Drawing.Color.Lime;
            this.cirucularButton.FlatAppearance.BorderSize = 2;
            this.cirucularButton.Location = new System.Drawing.Point(223, 106);
            this.cirucularButton.Name = "cirucularButton";
            this.cirucularButton.Size = new System.Drawing.Size(24, 23);
            this.cirucularButton.TabIndex = 7;
            this.cirucularButton.UseVisualStyleBackColor = false;
            this.cirucularButton.Click += new System.EventHandler(this.cirucularButton_Click);
            // 
            // WorkerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(766, 453);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WorkerPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WorkerPanel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkerPanel_FormClosing);
            this.Load += new System.EventHandler(this.WorkerPanel_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoutButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CircularProfilPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CircularPicture LogoutButton;
        private System.Windows.Forms.Button ButtomGestionTicket;
        private System.Windows.Forms.Panel panel2;
        private CirucularButton cirucularButton;
        public CircularPicture CircularProfilPicture;
        public System.Windows.Forms.Label LabelEmail;
        public System.Windows.Forms.Label LabelFirstName;
        public System.Windows.Forms.Label LabelLastName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}