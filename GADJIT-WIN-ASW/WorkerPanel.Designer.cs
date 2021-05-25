
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
            this.ShowSubMenuButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LabelEmail = new System.Windows.Forms.Label();
            this.LabelFirstName = new System.Windows.Forms.Label();
            this.LabelLastName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.ShowSubMenuButton);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(197, 626);
            this.panel1.TabIndex = 1;
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
            this.panel2.Controls.Add(this.LabelEmail);
            this.panel2.Controls.Add(this.LabelFirstName);
            this.panel2.Controls.Add(this.LabelLastName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(197, 93);
            this.panel2.TabIndex = 0;
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
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
    }
}