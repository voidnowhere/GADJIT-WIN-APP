
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
            this.LogoutButton = new GADJIT_WIN_ASW.CircularPicture();
            this.ShowSubMenuButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Resetmdp = new System.Windows.Forms.PictureBox();
            this.CircularProfilPicture = new GADJIT_WIN_ASW.CircularPicture();
            this.cirucularButton = new GADJIT_WIN_ASW.CirucularButton();
            this.LabelEmail = new System.Windows.Forms.Label();
            this.LabelFirstName = new System.Windows.Forms.Label();
            this.LabelLastName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoutButton)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Resetmdp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CircularProfilPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.LogoutButton);
            this.panel1.Controls.Add(this.ShowSubMenuButton);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(197, 626);
            this.panel1.TabIndex = 1;
            // 
            // LogoutButton
            // 
            this.LogoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LogoutButton.Image = global::GADJIT_WIN_ASW.Properties.Resources.logout_rounded_left_48px;
            this.LogoutButton.Location = new System.Drawing.Point(0, 576);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(50, 50);
            this.LogoutButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoutButton.TabIndex = 3;
            this.LogoutButton.TabStop = false;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // ShowSubMenuButton
            // 
            this.ShowSubMenuButton.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ShowSubMenuButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ShowSubMenuButton.FlatAppearance.BorderSize = 0;
            this.ShowSubMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowSubMenuButton.ForeColor = System.Drawing.Color.White;
            this.ShowSubMenuButton.Location = new System.Drawing.Point(0, 93);
            this.ShowSubMenuButton.Name = "ShowSubMenuButton";
            this.ShowSubMenuButton.Size = new System.Drawing.Size(197, 40);
            this.ShowSubMenuButton.TabIndex = 1;
            this.ShowSubMenuButton.Text = "Gestion Ticket";
            this.ShowSubMenuButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ShowSubMenuButton.UseCompatibleTextRendering = true;
            this.ShowSubMenuButton.UseVisualStyleBackColor = false;
            this.ShowSubMenuButton.Click += new System.EventHandler(this.ShowSubMenuButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Resetmdp);
            this.panel2.Controls.Add(this.CircularProfilPicture);
            this.panel2.Controls.Add(this.cirucularButton);
            this.panel2.Controls.Add(this.LabelEmail);
            this.panel2.Controls.Add(this.LabelFirstName);
            this.panel2.Controls.Add(this.LabelLastName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(197, 93);
            this.panel2.TabIndex = 0;
            // 
            // Resetmdp
            // 
            this.Resetmdp.Location = new System.Drawing.Point(137, 70);
            this.Resetmdp.Name = "Resetmdp";
            this.Resetmdp.Size = new System.Drawing.Size(29, 20);
            this.Resetmdp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Resetmdp.TabIndex = 9;
            this.Resetmdp.TabStop = false;
            this.Resetmdp.Click += new System.EventHandler(this.Resetmdp_Click);
            // 
            // CircularProfilPicture
            // 
            this.CircularProfilPicture.Image = global::GADJIT_WIN_ASW.Properties.Resources.user_60px;
            this.CircularProfilPicture.Location = new System.Drawing.Point(137, 0);
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
            this.cirucularButton.Location = new System.Drawing.Point(170, 70);
            this.cirucularButton.Name = "cirucularButton";
            this.cirucularButton.Size = new System.Drawing.Size(24, 23);
            this.cirucularButton.TabIndex = 7;
            this.cirucularButton.UseVisualStyleBackColor = false;
            this.cirucularButton.Click += new System.EventHandler(this.cirucularButton_Click);
            // 
            // LabelEmail
            // 
            this.LabelEmail.AutoSize = true;
            this.LabelEmail.ForeColor = System.Drawing.Color.White;
            this.LabelEmail.Location = new System.Drawing.Point(12, 73);
            this.LabelEmail.Name = "LabelEmail";
            this.LabelEmail.Size = new System.Drawing.Size(95, 17);
            this.LabelEmail.TabIndex = 6;
            this.LabelEmail.Text = "Worker  Email";
            // 
            // LabelFirstName
            // 
            this.LabelFirstName.AutoSize = true;
            this.LabelFirstName.ForeColor = System.Drawing.Color.White;
            this.LabelFirstName.Location = new System.Drawing.Point(12, 36);
            this.LabelFirstName.Name = "LabelFirstName";
            this.LabelFirstName.Size = new System.Drawing.Size(124, 17);
            this.LabelFirstName.TabIndex = 5;
            this.LabelFirstName.Text = "Worker First Name";
            // 
            // LabelLastName
            // 
            this.LabelLastName.AutoSize = true;
            this.LabelLastName.ForeColor = System.Drawing.Color.White;
            this.LabelLastName.Location = new System.Drawing.Point(12, 9);
            this.LabelLastName.Name = "LabelLastName";
            this.LabelLastName.Size = new System.Drawing.Size(122, 17);
            this.LabelLastName.TabIndex = 4;
            this.LabelLastName.Text = "Worker Last Name";
            // 
            // WorkerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(952, 626);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WorkerPanel";
            this.Text = "WorkerPanel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkerPanel_FormClosing);
            this.Load += new System.EventHandler(this.WorkerPanel_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogoutButton)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Resetmdp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CircularProfilPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CircularPicture LogoutButton;
        private System.Windows.Forms.Button ShowSubMenuButton;
        private System.Windows.Forms.Panel panel2;
        private CirucularButton cirucularButton;
        public CircularPicture CircularProfilPicture;
        public System.Windows.Forms.Label LabelEmail;
        public System.Windows.Forms.Label LabelFirstName;
        public System.Windows.Forms.Label LabelLastName;
        private System.Windows.Forms.PictureBox Resetmdp;
    }
}