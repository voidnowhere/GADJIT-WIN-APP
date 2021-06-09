
namespace GADJIT_WIN_ASW
{
    partial class StaffPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffPanel));
            this.panel1 = new System.Windows.Forms.Panel();
            this.LogoutButton = new GADJIT_WIN_ASW.CircularPicture();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ButtonTicketProgression = new System.Windows.Forms.Button();
            this.ButtonTicketVerification = new System.Windows.Forms.Button();
            this.ShowSubMenuButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CircularPicturePasswordChange = new GADJIT_WIN_ASW.CircularPicture();
            this.label1 = new System.Windows.Forms.Label();
            this.CircularProfilPicture = new GADJIT_WIN_ASW.CircularPicture();
            this.ButtonDisponibility = new GADJIT_WIN_ASW.CirucularButton();
            this.LabelEmail = new System.Windows.Forms.Label();
            this.LabelFirstName = new System.Windows.Forms.Label();
            this.LabelLastName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoutButton)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CircularPicturePasswordChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CircularProfilPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this.LogoutButton);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.ShowSubMenuButton);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 565);
            this.panel1.TabIndex = 0;
            // 
            // LogoutButton
            // 
            this.LogoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LogoutButton.Image = global::GADJIT_WIN_ASW.Properties.Resources.logout_rounded_left_48pxblue;
            this.LogoutButton.Location = new System.Drawing.Point(0, 515);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(50, 50);
            this.LogoutButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoutButton.TabIndex = 3;
            this.LogoutButton.TabStop = false;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.ButtonTicketProgression);
            this.panel3.Controls.Add(this.ButtonTicketVerification);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 208);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(220, 82);
            this.panel3.TabIndex = 2;
            // 
            // ButtonTicketProgression
            // 
            this.ButtonTicketProgression.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonTicketProgression.FlatAppearance.BorderSize = 0;
            this.ButtonTicketProgression.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonTicketProgression.ForeColor = System.Drawing.Color.DarkCyan;
            this.ButtonTicketProgression.Location = new System.Drawing.Point(0, 40);
            this.ButtonTicketProgression.Name = "ButtonTicketProgression";
            this.ButtonTicketProgression.Size = new System.Drawing.Size(220, 40);
            this.ButtonTicketProgression.TabIndex = 1;
            this.ButtonTicketProgression.Text = "Ticket Progression";
            this.ButtonTicketProgression.UseVisualStyleBackColor = true;
            this.ButtonTicketProgression.Click += new System.EventHandler(this.ButtonTicketProgression_Click);
            // 
            // ButtonTicketVerification
            // 
            this.ButtonTicketVerification.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonTicketVerification.FlatAppearance.BorderSize = 0;
            this.ButtonTicketVerification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonTicketVerification.ForeColor = System.Drawing.Color.DarkCyan;
            this.ButtonTicketVerification.Location = new System.Drawing.Point(0, 0);
            this.ButtonTicketVerification.Name = "ButtonTicketVerification";
            this.ButtonTicketVerification.Size = new System.Drawing.Size(220, 40);
            this.ButtonTicketVerification.TabIndex = 0;
            this.ButtonTicketVerification.Text = "Ticket Verification";
            this.ButtonTicketVerification.UseVisualStyleBackColor = true;
            this.ButtonTicketVerification.Click += new System.EventHandler(this.ButtonTicketVerification_Click);
            // 
            // ShowSubMenuButton
            // 
            this.ShowSubMenuButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.ShowSubMenuButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ShowSubMenuButton.Enabled = false;
            this.ShowSubMenuButton.FlatAppearance.BorderSize = 0;
            this.ShowSubMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowSubMenuButton.ForeColor = System.Drawing.Color.White;
            this.ShowSubMenuButton.Location = new System.Drawing.Point(0, 168);
            this.ShowSubMenuButton.Name = "ShowSubMenuButton";
            this.ShowSubMenuButton.Size = new System.Drawing.Size(220, 40);
            this.ShowSubMenuButton.TabIndex = 1;
            this.ShowSubMenuButton.Text = "Gestion Ticket";
            this.ShowSubMenuButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ShowSubMenuButton.UseCompatibleTextRendering = true;
            this.ShowSubMenuButton.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.CircularPicturePasswordChange);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.CircularProfilPicture);
            this.panel2.Controls.Add(this.ButtonDisponibility);
            this.panel2.Controls.Add(this.LabelEmail);
            this.panel2.Controls.Add(this.LabelFirstName);
            this.panel2.Controls.Add(this.LabelLastName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 168);
            this.panel2.TabIndex = 0;
            // 
            // CircularPicturePasswordChange
            // 
            this.CircularPicturePasswordChange.Image = global::GADJIT_WIN_ASW.Properties.Resources.passwordChangeStaff;
            this.CircularPicturePasswordChange.Location = new System.Drawing.Point(192, 114);
            this.CircularPicturePasswordChange.Name = "CircularPicturePasswordChange";
            this.CircularPicturePasswordChange.Size = new System.Drawing.Size(25, 25);
            this.CircularPicturePasswordChange.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CircularPicturePasswordChange.TabIndex = 2;
            this.CircularPicturePasswordChange.TabStop = false;
            this.CircularPicturePasswordChange.Click += new System.EventHandler(this.CircularPicturePasswordChange_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Espace administration";
            // 
            // CircularProfilPicture
            // 
            this.CircularProfilPicture.Image = global::GADJIT_WIN_ASW.Properties.Resources.user_60px;
            this.CircularProfilPicture.Location = new System.Drawing.Point(157, 48);
            this.CircularProfilPicture.Name = "CircularProfilPicture";
            this.CircularProfilPicture.Size = new System.Drawing.Size(60, 60);
            this.CircularProfilPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CircularProfilPicture.TabIndex = 8;
            this.CircularProfilPicture.TabStop = false;
            // 
            // ButtonDisponibility
            // 
            this.ButtonDisponibility.BackColor = System.Drawing.Color.Lime;
            this.ButtonDisponibility.FlatAppearance.BorderSize = 2;
            this.ButtonDisponibility.Location = new System.Drawing.Point(158, 114);
            this.ButtonDisponibility.Name = "ButtonDisponibility";
            this.ButtonDisponibility.Size = new System.Drawing.Size(25, 25);
            this.ButtonDisponibility.TabIndex = 7;
            this.ButtonDisponibility.UseVisualStyleBackColor = false;
            this.ButtonDisponibility.Click += new System.EventHandler(this.cirucularButton_Click);
            // 
            // LabelEmail
            // 
            this.LabelEmail.AutoSize = true;
            this.LabelEmail.ForeColor = System.Drawing.Color.White;
            this.LabelEmail.Location = new System.Drawing.Point(3, 122);
            this.LabelEmail.Name = "LabelEmail";
            this.LabelEmail.Size = new System.Drawing.Size(79, 17);
            this.LabelEmail.TabIndex = 6;
            this.LabelEmail.Text = "Staff  Email";
            // 
            // LabelFirstName
            // 
            this.LabelFirstName.AutoSize = true;
            this.LabelFirstName.ForeColor = System.Drawing.Color.White;
            this.LabelFirstName.Location = new System.Drawing.Point(3, 82);
            this.LabelFirstName.Name = "LabelFirstName";
            this.LabelFirstName.Size = new System.Drawing.Size(108, 17);
            this.LabelFirstName.TabIndex = 5;
            this.LabelFirstName.Text = "Staff First Name";
            // 
            // LabelLastName
            // 
            this.LabelLastName.AutoSize = true;
            this.LabelLastName.ForeColor = System.Drawing.Color.White;
            this.LabelLastName.Location = new System.Drawing.Point(3, 55);
            this.LabelLastName.Name = "LabelLastName";
            this.LabelLastName.Size = new System.Drawing.Size(106, 17);
            this.LabelLastName.TabIndex = 4;
            this.LabelLastName.Text = "Staff Last Name";
            // 
            // StaffPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 565);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StaffPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StaffPanel";
            this.Load += new System.EventHandler(this.StaffPanel_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogoutButton)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CircularPicturePasswordChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CircularProfilPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button ButtonTicketProgression;
        private System.Windows.Forms.Button ButtonTicketVerification;
        private System.Windows.Forms.Button ShowSubMenuButton;
        private System.Windows.Forms.Panel panel2;
        private CirucularButton ButtonDisponibility;
        private CircularPicture LogoutButton;
        public System.Windows.Forms.Label LabelEmail;
        public System.Windows.Forms.Label LabelFirstName;
        public System.Windows.Forms.Label LabelLastName;
        public CircularPicture CircularProfilPicture;
        public System.Windows.Forms.Label label1;
        private CircularPicture CircularPicturePasswordChange;
    }
}