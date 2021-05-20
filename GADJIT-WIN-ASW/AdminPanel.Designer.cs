﻿
namespace GADJIT_WIN_ASW
{
    partial class AdminPanel
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
            this.LabelFirstName = new System.Windows.Forms.Label();
            this.PanelGadgetManagment = new System.Windows.Forms.Panel();
            this.ButtonGadgetReferenceManagment = new System.Windows.Forms.Button();
            this.ButtonGadgetCategoryBrandManagment = new System.Windows.Forms.Button();
            this.LabelEmail = new System.Windows.Forms.Label();
            this.ButtonIncomes = new System.Windows.Forms.Button();
            this.ButtonGadgetMenu = new System.Windows.Forms.Button();
            this.ButtonWorkerManagment = new System.Windows.Forms.Button();
            this.ButtonStaffManagment = new System.Windows.Forms.Button();
            this.ButtonTicketManagment = new System.Windows.Forms.Button();
            this.ButtonClientManagment = new System.Windows.Forms.Button();
            this.LabelLastName = new System.Windows.Forms.Label();
            this.PanelStatistics = new System.Windows.Forms.Panel();
            this.ButtonStatisticsMenu = new System.Windows.Forms.Button();
            this.PanelTop = new System.Windows.Forms.Panel();
            this.PanelBottom = new System.Windows.Forms.Panel();
            this.PictureBoxLogOut = new System.Windows.Forms.PictureBox();
            this.SideMenuPanel = new System.Windows.Forms.Panel();
            this.ButtonDisponibility = new GADJIT_WIN_ASW.CirucularButton();
            this.PanelGadgetManagment.SuspendLayout();
            this.PanelStatistics.SuspendLayout();
            this.PanelTop.SuspendLayout();
            this.PanelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogOut)).BeginInit();
            this.SideMenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelFirstName
            // 
            this.LabelFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFirstName.Location = new System.Drawing.Point(3, 37);
            this.LabelFirstName.Name = "LabelFirstName";
            this.LabelFirstName.Size = new System.Drawing.Size(125, 17);
            this.LabelFirstName.TabIndex = 6;
            this.LabelFirstName.Text = "First Name";
            // 
            // PanelGadgetManagment
            // 
            this.PanelGadgetManagment.BackColor = System.Drawing.Color.White;
            this.PanelGadgetManagment.Controls.Add(this.ButtonGadgetReferenceManagment);
            this.PanelGadgetManagment.Controls.Add(this.ButtonGadgetCategoryBrandManagment);
            this.PanelGadgetManagment.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelGadgetManagment.Location = new System.Drawing.Point(0, 384);
            this.PanelGadgetManagment.Name = "PanelGadgetManagment";
            this.PanelGadgetManagment.Size = new System.Drawing.Size(197, 96);
            this.PanelGadgetManagment.TabIndex = 3;
            // 
            // ButtonGadgetReferenceManagment
            // 
            this.ButtonGadgetReferenceManagment.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonGadgetReferenceManagment.FlatAppearance.BorderSize = 0;
            this.ButtonGadgetReferenceManagment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonGadgetReferenceManagment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonGadgetReferenceManagment.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonGadgetReferenceManagment.Location = new System.Drawing.Point(0, 40);
            this.ButtonGadgetReferenceManagment.Name = "ButtonGadgetReferenceManagment";
            this.ButtonGadgetReferenceManagment.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.ButtonGadgetReferenceManagment.Size = new System.Drawing.Size(197, 38);
            this.ButtonGadgetReferenceManagment.TabIndex = 3;
            this.ButtonGadgetReferenceManagment.Text = "Référence";
            this.ButtonGadgetReferenceManagment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonGadgetReferenceManagment.UseVisualStyleBackColor = true;
            this.ButtonGadgetReferenceManagment.Click += new System.EventHandler(this.ButtonGadgetReferenceManagment_Click);
            // 
            // ButtonGadgetCategoryBrandManagment
            // 
            this.ButtonGadgetCategoryBrandManagment.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonGadgetCategoryBrandManagment.FlatAppearance.BorderSize = 0;
            this.ButtonGadgetCategoryBrandManagment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonGadgetCategoryBrandManagment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonGadgetCategoryBrandManagment.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonGadgetCategoryBrandManagment.Location = new System.Drawing.Point(0, 0);
            this.ButtonGadgetCategoryBrandManagment.Name = "ButtonGadgetCategoryBrandManagment";
            this.ButtonGadgetCategoryBrandManagment.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.ButtonGadgetCategoryBrandManagment.Size = new System.Drawing.Size(197, 40);
            this.ButtonGadgetCategoryBrandManagment.TabIndex = 2;
            this.ButtonGadgetCategoryBrandManagment.Text = "Marque et Catégorie";
            this.ButtonGadgetCategoryBrandManagment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonGadgetCategoryBrandManagment.UseVisualStyleBackColor = true;
            this.ButtonGadgetCategoryBrandManagment.Click += new System.EventHandler(this.ButtonGadgetCategoryBrandManagment_Click);
            // 
            // LabelEmail
            // 
            this.LabelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelEmail.Location = new System.Drawing.Point(3, 67);
            this.LabelEmail.Name = "LabelEmail";
            this.LabelEmail.Size = new System.Drawing.Size(182, 17);
            this.LabelEmail.TabIndex = 4;
            this.LabelEmail.Text = "Admin Mail";
            // 
            // ButtonIncomes
            // 
            this.ButtonIncomes.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonIncomes.FlatAppearance.BorderSize = 0;
            this.ButtonIncomes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonIncomes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonIncomes.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonIncomes.Location = new System.Drawing.Point(0, 0);
            this.ButtonIncomes.Name = "ButtonIncomes";
            this.ButtonIncomes.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.ButtonIncomes.Size = new System.Drawing.Size(197, 34);
            this.ButtonIncomes.TabIndex = 2;
            this.ButtonIncomes.Text = "Revenus";
            this.ButtonIncomes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonIncomes.UseVisualStyleBackColor = true;
            // 
            // ButtonGadgetMenu
            // 
            this.ButtonGadgetMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonGadgetMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(181)))), ((int)(((byte)(46)))));
            this.ButtonGadgetMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonGadgetMenu.FlatAppearance.BorderSize = 0;
            this.ButtonGadgetMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonGadgetMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonGadgetMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(206)))));
            this.ButtonGadgetMenu.Location = new System.Drawing.Point(0, 344);
            this.ButtonGadgetMenu.Name = "ButtonGadgetMenu";
            this.ButtonGadgetMenu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ButtonGadgetMenu.Size = new System.Drawing.Size(197, 40);
            this.ButtonGadgetMenu.TabIndex = 8;
            this.ButtonGadgetMenu.Text = "Gestion Gadget";
            this.ButtonGadgetMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonGadgetMenu.UseVisualStyleBackColor = false;
            this.ButtonGadgetMenu.Click += new System.EventHandler(this.ButtonGadgetMenu_Click);
            // 
            // ButtonWorkerManagment
            // 
            this.ButtonWorkerManagment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonWorkerManagment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(181)))), ((int)(((byte)(46)))));
            this.ButtonWorkerManagment.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonWorkerManagment.FlatAppearance.BorderSize = 0;
            this.ButtonWorkerManagment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonWorkerManagment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonWorkerManagment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(206)))));
            this.ButtonWorkerManagment.Location = new System.Drawing.Point(0, 304);
            this.ButtonWorkerManagment.Name = "ButtonWorkerManagment";
            this.ButtonWorkerManagment.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ButtonWorkerManagment.Size = new System.Drawing.Size(197, 40);
            this.ButtonWorkerManagment.TabIndex = 6;
            this.ButtonWorkerManagment.Text = "Gestion Employé";
            this.ButtonWorkerManagment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonWorkerManagment.UseVisualStyleBackColor = false;
            this.ButtonWorkerManagment.Click += new System.EventHandler(this.ButtonWorkerManagment_Click);
            // 
            // ButtonStaffManagment
            // 
            this.ButtonStaffManagment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonStaffManagment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(181)))), ((int)(((byte)(46)))));
            this.ButtonStaffManagment.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonStaffManagment.FlatAppearance.BorderSize = 0;
            this.ButtonStaffManagment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonStaffManagment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonStaffManagment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(206)))));
            this.ButtonStaffManagment.Location = new System.Drawing.Point(0, 264);
            this.ButtonStaffManagment.Name = "ButtonStaffManagment";
            this.ButtonStaffManagment.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ButtonStaffManagment.Size = new System.Drawing.Size(197, 40);
            this.ButtonStaffManagment.TabIndex = 4;
            this.ButtonStaffManagment.Text = "Gestion Personnel";
            this.ButtonStaffManagment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonStaffManagment.UseVisualStyleBackColor = false;
            this.ButtonStaffManagment.Click += new System.EventHandler(this.ButtonStaffManagment_Click);
            // 
            // ButtonTicketManagment
            // 
            this.ButtonTicketManagment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonTicketManagment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(181)))), ((int)(((byte)(46)))));
            this.ButtonTicketManagment.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonTicketManagment.FlatAppearance.BorderSize = 0;
            this.ButtonTicketManagment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonTicketManagment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonTicketManagment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(206)))));
            this.ButtonTicketManagment.Location = new System.Drawing.Point(0, 224);
            this.ButtonTicketManagment.Name = "ButtonTicketManagment";
            this.ButtonTicketManagment.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ButtonTicketManagment.Size = new System.Drawing.Size(197, 40);
            this.ButtonTicketManagment.TabIndex = 10;
            this.ButtonTicketManagment.Text = "Gestion Ticket";
            this.ButtonTicketManagment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonTicketManagment.UseVisualStyleBackColor = false;
            // 
            // ButtonClientManagment
            // 
            this.ButtonClientManagment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonClientManagment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(181)))), ((int)(((byte)(46)))));
            this.ButtonClientManagment.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonClientManagment.FlatAppearance.BorderSize = 0;
            this.ButtonClientManagment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonClientManagment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonClientManagment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(206)))));
            this.ButtonClientManagment.Location = new System.Drawing.Point(0, 184);
            this.ButtonClientManagment.Name = "ButtonClientManagment";
            this.ButtonClientManagment.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ButtonClientManagment.Size = new System.Drawing.Size(197, 40);
            this.ButtonClientManagment.TabIndex = 9;
            this.ButtonClientManagment.Text = "Gestion Client";
            this.ButtonClientManagment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonClientManagment.UseVisualStyleBackColor = false;
            this.ButtonClientManagment.Click += new System.EventHandler(this.ButtonClientManagment_Click);
            // 
            // LabelLastName
            // 
            this.LabelLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelLastName.Location = new System.Drawing.Point(3, 9);
            this.LabelLastName.Name = "LabelLastName";
            this.LabelLastName.Size = new System.Drawing.Size(125, 17);
            this.LabelLastName.TabIndex = 5;
            this.LabelLastName.Text = "Last Name";
            // 
            // PanelStatistics
            // 
            this.PanelStatistics.BackColor = System.Drawing.Color.White;
            this.PanelStatistics.Controls.Add(this.ButtonIncomes);
            this.PanelStatistics.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelStatistics.Location = new System.Drawing.Point(0, 136);
            this.PanelStatistics.Name = "PanelStatistics";
            this.PanelStatistics.Size = new System.Drawing.Size(197, 48);
            this.PanelStatistics.TabIndex = 2;
            // 
            // ButtonStatisticsMenu
            // 
            this.ButtonStatisticsMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonStatisticsMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(181)))), ((int)(((byte)(46)))));
            this.ButtonStatisticsMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonStatisticsMenu.FlatAppearance.BorderSize = 0;
            this.ButtonStatisticsMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonStatisticsMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonStatisticsMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(206)))));
            this.ButtonStatisticsMenu.Location = new System.Drawing.Point(0, 96);
            this.ButtonStatisticsMenu.Name = "ButtonStatisticsMenu";
            this.ButtonStatisticsMenu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ButtonStatisticsMenu.Size = new System.Drawing.Size(197, 40);
            this.ButtonStatisticsMenu.TabIndex = 1;
            this.ButtonStatisticsMenu.Text = "Statistiques";
            this.ButtonStatisticsMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonStatisticsMenu.UseVisualStyleBackColor = false;
            this.ButtonStatisticsMenu.Click += new System.EventHandler(this.ButtonStatisticsMenu_Click);
            // 
            // PanelTop
            // 
            this.PanelTop.Controls.Add(this.ButtonDisponibility);
            this.PanelTop.Controls.Add(this.LabelFirstName);
            this.PanelTop.Controls.Add(this.LabelLastName);
            this.PanelTop.Controls.Add(this.LabelEmail);
            this.PanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTop.Location = new System.Drawing.Point(0, 0);
            this.PanelTop.Name = "PanelTop";
            this.PanelTop.Size = new System.Drawing.Size(197, 96);
            this.PanelTop.TabIndex = 0;
            // 
            // PanelBottom
            // 
            this.PanelBottom.Controls.Add(this.PictureBoxLogOut);
            this.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelBottom.Location = new System.Drawing.Point(0, 570);
            this.PanelBottom.Name = "PanelBottom";
            this.PanelBottom.Size = new System.Drawing.Size(197, 56);
            this.PanelBottom.TabIndex = 3;
            // 
            // PictureBoxLogOut
            // 
            this.PictureBoxLogOut.BackColor = System.Drawing.Color.Goldenrod;
            this.PictureBoxLogOut.Image = global::GADJIT_WIN_ASW.Properties.Resources.shutdown_60px;
            this.PictureBoxLogOut.Location = new System.Drawing.Point(0, 0);
            this.PictureBoxLogOut.Name = "PictureBoxLogOut";
            this.PictureBoxLogOut.Size = new System.Drawing.Size(56, 52);
            this.PictureBoxLogOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxLogOut.TabIndex = 3;
            this.PictureBoxLogOut.TabStop = false;
            this.PictureBoxLogOut.Click += new System.EventHandler(this.PictureBoxLogOut_Click);
            // 
            // SideMenuPanel
            // 
            this.SideMenuPanel.AutoScroll = true;
            this.SideMenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(33)))));
            this.SideMenuPanel.Controls.Add(this.PanelGadgetManagment);
            this.SideMenuPanel.Controls.Add(this.ButtonGadgetMenu);
            this.SideMenuPanel.Controls.Add(this.ButtonWorkerManagment);
            this.SideMenuPanel.Controls.Add(this.ButtonStaffManagment);
            this.SideMenuPanel.Controls.Add(this.ButtonTicketManagment);
            this.SideMenuPanel.Controls.Add(this.ButtonClientManagment);
            this.SideMenuPanel.Controls.Add(this.PanelBottom);
            this.SideMenuPanel.Controls.Add(this.PanelStatistics);
            this.SideMenuPanel.Controls.Add(this.ButtonStatisticsMenu);
            this.SideMenuPanel.Controls.Add(this.PanelTop);
            this.SideMenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SideMenuPanel.Location = new System.Drawing.Point(0, 0);
            this.SideMenuPanel.Name = "SideMenuPanel";
            this.SideMenuPanel.Size = new System.Drawing.Size(197, 626);
            this.SideMenuPanel.TabIndex = 1;
            // 
            // ButtonDisponibility
            // 
            this.ButtonDisponibility.BackColor = System.Drawing.Color.Lime;
            this.ButtonDisponibility.Location = new System.Drawing.Point(174, 3);
            this.ButtonDisponibility.Name = "ButtonDisponibility";
            this.ButtonDisponibility.Size = new System.Drawing.Size(20, 20);
            this.ButtonDisponibility.TabIndex = 3;
            this.ButtonDisponibility.UseVisualStyleBackColor = false;
            this.ButtonDisponibility.Click += new System.EventHandler(this.ButtonDisponibility_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 626);
            this.Controls.Add(this.SideMenuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "AdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AdminPanel";
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            this.PanelGadgetManagment.ResumeLayout(false);
            this.PanelStatistics.ResumeLayout(false);
            this.PanelTop.ResumeLayout(false);
            this.PanelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogOut)).EndInit();
            this.SideMenuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PanelGadgetManagment;
        private System.Windows.Forms.Button ButtonGadgetReferenceManagment;
        private System.Windows.Forms.Button ButtonGadgetCategoryBrandManagment;
        private System.Windows.Forms.Button ButtonIncomes;
        private System.Windows.Forms.Button ButtonGadgetMenu;
        private System.Windows.Forms.Button ButtonWorkerManagment;
        private System.Windows.Forms.Button ButtonStaffManagment;
        private System.Windows.Forms.Button ButtonTicketManagment;
        private System.Windows.Forms.PictureBox PictureBoxLogOut;
        private System.Windows.Forms.Button ButtonClientManagment;
        private System.Windows.Forms.Panel PanelStatistics;
        private System.Windows.Forms.Button ButtonStatisticsMenu;
        private System.Windows.Forms.Panel PanelTop;
        private System.Windows.Forms.Panel PanelBottom;
        private System.Windows.Forms.Panel SideMenuPanel;
        private CirucularButton ButtonDisponibility;
        public System.Windows.Forms.Label LabelFirstName;
        public System.Windows.Forms.Label LabelEmail;
        public System.Windows.Forms.Label LabelLastName;
    }
}