﻿
namespace GADJIT_WIN_CLIENT
{
    partial class CreationTicket
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
            this.ButtonAnnuler = new System.Windows.Forms.Button();
            this.ButtonConfirmer = new System.Windows.Forms.Button();
            this.RichTextBoxProbTicket = new System.Windows.Forms.RichTextBox();
            this.ComboBoxRefGadjit = new System.Windows.Forms.ComboBox();
            this.ComboBoxMarque = new System.Windows.Forms.ComboBox();
            this.ComboBoxCatGadjit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RichTextBoxAdress = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ComboBoxville = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ButtonAnnuler
            // 
            this.ButtonAnnuler.BackColor = System.Drawing.Color.White;
            this.ButtonAnnuler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonAnnuler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.ButtonAnnuler.Location = new System.Drawing.Point(198, 470);
            this.ButtonAnnuler.Name = "ButtonAnnuler";
            this.ButtonAnnuler.Size = new System.Drawing.Size(216, 35);
            this.ButtonAnnuler.TabIndex = 7;
            this.ButtonAnnuler.Text = "Annuler";
            this.ButtonAnnuler.UseVisualStyleBackColor = false;
            this.ButtonAnnuler.Click += new System.EventHandler(this.ButtonAnnuler_Click);
            // 
            // ButtonConfirmer
            // 
            this.ButtonConfirmer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonConfirmer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.ButtonConfirmer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonConfirmer.FlatAppearance.BorderSize = 0;
            this.ButtonConfirmer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonConfirmer.ForeColor = System.Drawing.Color.White;
            this.ButtonConfirmer.Location = new System.Drawing.Point(426, 470);
            this.ButtonConfirmer.Name = "ButtonConfirmer";
            this.ButtonConfirmer.Size = new System.Drawing.Size(216, 35);
            this.ButtonConfirmer.TabIndex = 6;
            this.ButtonConfirmer.Text = "Confirmer";
            this.ButtonConfirmer.UseVisualStyleBackColor = false;
            this.ButtonConfirmer.Click += new System.EventHandler(this.ButtonConfirmer_Click);
            // 
            // RichTextBoxProbTicket
            // 
            this.RichTextBoxProbTicket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RichTextBoxProbTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.RichTextBoxProbTicket.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBoxProbTicket.ForeColor = System.Drawing.Color.Black;
            this.RichTextBoxProbTicket.Location = new System.Drawing.Point(198, 164);
            this.RichTextBoxProbTicket.Name = "RichTextBoxProbTicket";
            this.RichTextBoxProbTicket.Size = new System.Drawing.Size(444, 99);
            this.RichTextBoxProbTicket.TabIndex = 3;
            this.RichTextBoxProbTicket.Text = "";
            // 
            // ComboBoxRefGadjit
            // 
            this.ComboBoxRefGadjit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxRefGadjit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.ComboBoxRefGadjit.DisplayMember = "reference";
            this.ComboBoxRefGadjit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxRefGadjit.FormattingEnabled = true;
            this.ComboBoxRefGadjit.Location = new System.Drawing.Point(198, 119);
            this.ComboBoxRefGadjit.Name = "ComboBoxRefGadjit";
            this.ComboBoxRefGadjit.Size = new System.Drawing.Size(444, 25);
            this.ComboBoxRefGadjit.TabIndex = 2;
            this.ComboBoxRefGadjit.SelectedIndexChanged += new System.EventHandler(this.ComboBoxRefGadjit_SelectedIndexChanged);
            // 
            // ComboBoxMarque
            // 
            this.ComboBoxMarque.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxMarque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.ComboBoxMarque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxMarque.FormattingEnabled = true;
            this.ComboBoxMarque.Location = new System.Drawing.Point(198, 88);
            this.ComboBoxMarque.Name = "ComboBoxMarque";
            this.ComboBoxMarque.Size = new System.Drawing.Size(444, 25);
            this.ComboBoxMarque.TabIndex = 1;
            this.ComboBoxMarque.SelectedIndexChanged += new System.EventHandler(this.ComboBoxMarque_SelectedIndexChanged);
            // 
            // ComboBoxCatGadjit
            // 
            this.ComboBoxCatGadjit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxCatGadjit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.ComboBoxCatGadjit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxCatGadjit.FormattingEnabled = true;
            this.ComboBoxCatGadjit.Items.AddRange(new object[] {
            "Choisissez une categotie"});
            this.ComboBoxCatGadjit.Location = new System.Drawing.Point(198, 57);
            this.ComboBoxCatGadjit.Name = "ComboBoxCatGadjit";
            this.ComboBoxCatGadjit.Size = new System.Drawing.Size(444, 25);
            this.ComboBoxCatGadjit.TabIndex = 0;
            this.ComboBoxCatGadjit.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCatGadjit_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(117, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 26;
            this.label5.Text = "Problème :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Reference du gadget :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Marques du gadget :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Catégories du gadget :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.label1.Location = new System.Drawing.Point(239, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 27);
            this.label1.TabIndex = 22;
            this.label1.Text = "NOUVEAU TICKET";
            // 
            // RichTextBoxAdress
            // 
            this.RichTextBoxAdress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RichTextBoxAdress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.RichTextBoxAdress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBoxAdress.ForeColor = System.Drawing.Color.Black;
            this.RichTextBoxAdress.Location = new System.Drawing.Point(198, 289);
            this.RichTextBoxAdress.Name = "RichTextBoxAdress";
            this.RichTextBoxAdress.Size = new System.Drawing.Size(444, 99);
            this.RichTextBoxAdress.TabIndex = 4;
            this.RichTextBoxAdress.Text = "";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 17);
            this.label6.TabIndex = 33;
            this.label6.Text = "Adresse du livraison :";
            // 
            // ComboBoxville
            // 
            this.ComboBoxville.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxville.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.ComboBoxville.DisplayMember = "reference";
            this.ComboBoxville.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxville.FormattingEnabled = true;
            this.ComboBoxville.Location = new System.Drawing.Point(198, 394);
            this.ComboBoxville.Name = "ComboBoxville";
            this.ComboBoxville.Size = new System.Drawing.Size(444, 25);
            this.ComboBoxville.TabIndex = 5;
            // 
            // CreationTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(735, 520);
            this.Controls.Add(this.ComboBoxville);
            this.Controls.Add(this.RichTextBoxAdress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ButtonAnnuler);
            this.Controls.Add(this.ButtonConfirmer);
            this.Controls.Add(this.RichTextBoxProbTicket);
            this.Controls.Add(this.ComboBoxRefGadjit);
            this.Controls.Add(this.ComboBoxMarque);
            this.Controls.Add(this.ComboBoxCatGadjit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CreationTicket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreationTicket";
            this.Load += new System.EventHandler(this.CreationTicket_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonAnnuler;
        private System.Windows.Forms.Button ButtonConfirmer;
        private System.Windows.Forms.RichTextBox RichTextBoxProbTicket;
        private System.Windows.Forms.ComboBox ComboBoxRefGadjit;
        private System.Windows.Forms.ComboBox ComboBoxMarque;
        private System.Windows.Forms.ComboBox ComboBoxCatGadjit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox RichTextBoxAdress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ComboBoxville;
    }
}