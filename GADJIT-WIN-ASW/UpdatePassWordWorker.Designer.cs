﻿
namespace GADJIT_WIN_ASW
{
    partial class UpdatePassWordWorker
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
            this.components = new System.ComponentModel.Container();
            this.ButtonAnnuler = new System.Windows.Forms.Button();
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxNewPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxConfNewPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProviderConfPass = new System.Windows.Forms.ErrorProvider(this.components);
            this.TextBoxOldPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderConfPass)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonAnnuler
            // 
            this.ButtonAnnuler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonAnnuler.BackColor = System.Drawing.Color.White;
            this.ButtonAnnuler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonAnnuler.ForeColor = System.Drawing.Color.Teal;
            this.ButtonAnnuler.Location = new System.Drawing.Point(23, 282);
            this.ButtonAnnuler.Name = "ButtonAnnuler";
            this.ButtonAnnuler.Size = new System.Drawing.Size(213, 37);
            this.ButtonAnnuler.TabIndex = 63;
            this.ButtonAnnuler.Text = "Annuler";
            this.ButtonAnnuler.UseVisualStyleBackColor = false;
            this.ButtonAnnuler.Click += new System.EventHandler(this.ButtonAnnuler_Click);
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonUpdate.BackColor = System.Drawing.Color.Teal;
            this.ButtonUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonUpdate.FlatAppearance.BorderSize = 0;
            this.ButtonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonUpdate.ForeColor = System.Drawing.Color.White;
            this.ButtonUpdate.Location = new System.Drawing.Point(279, 282);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(213, 37);
            this.ButtonUpdate.TabIndex = 62;
            this.ButtonUpdate.Text = "Sauvgarder";
            this.ButtonUpdate.UseVisualStyleBackColor = false;
            this.ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(91, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 27);
            this.label1.TabIndex = 61;
            this.label1.Text = "Modifier Mot de passe";
            // 
            // TextBoxNewPass
            // 
            this.TextBoxNewPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxNewPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.TextBoxNewPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxNewPass.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxNewPass.Location = new System.Drawing.Point(96, 152);
            this.TextBoxNewPass.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TextBoxNewPass.Multiline = true;
            this.TextBoxNewPass.Name = "TextBoxNewPass";
            this.TextBoxNewPass.PasswordChar = '*';
            this.TextBoxNewPass.Size = new System.Drawing.Size(336, 37);
            this.TextBoxNewPass.TabIndex = 57;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 126);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 60;
            this.label4.Text = "Nouveau mot de passe";
            // 
            // TextBoxConfNewPass
            // 
            this.TextBoxConfNewPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxConfNewPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.TextBoxConfNewPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxConfNewPass.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxConfNewPass.Location = new System.Drawing.Point(96, 220);
            this.TextBoxConfNewPass.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TextBoxConfNewPass.Multiline = true;
            this.TextBoxConfNewPass.Name = "TextBoxConfNewPass";
            this.TextBoxConfNewPass.PasswordChar = '*';
            this.TextBoxConfNewPass.Size = new System.Drawing.Size(336, 37);
            this.TextBoxConfNewPass.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 193);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Confirmer mot de passe";
            // 
            // errorProviderConfPass
            // 
            this.errorProviderConfPass.ContainerControl = this;
            // 
            // TextBoxOldPass
            // 
            this.TextBoxOldPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxOldPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.TextBoxOldPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxOldPass.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxOldPass.Location = new System.Drawing.Point(96, 85);
            this.TextBoxOldPass.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TextBoxOldPass.Multiline = true;
            this.TextBoxOldPass.Name = "TextBoxOldPass";
            this.TextBoxOldPass.PasswordChar = '*';
            this.TextBoxOldPass.Size = new System.Drawing.Size(336, 37);
            this.TextBoxOldPass.TabIndex = 64;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 65;
            this.label3.Text = "Ancien mot de passe";
            // 
            // UpdatePassWordWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(517, 331);
            this.Controls.Add(this.TextBoxOldPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ButtonAnnuler);
            this.Controls.Add(this.ButtonUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxNewPass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TextBoxConfNewPass);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UpdatePassWordWorker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdatePassWord";
            this.Load += new System.EventHandler(this.UpdatePassWordWorker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderConfPass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonAnnuler;
        private System.Windows.Forms.Button ButtonUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxNewPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBoxConfNewPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProviderConfPass;
        private System.Windows.Forms.TextBox TextBoxOldPass;
        private System.Windows.Forms.Label label3;
    }
}