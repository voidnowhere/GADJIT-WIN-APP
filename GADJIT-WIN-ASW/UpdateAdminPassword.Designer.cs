
namespace GADJIT_WIN_ASW
{
    partial class UpdateAdminPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateAdminPassword));
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxNewPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxConfirmNewPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxOldPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.BackColor = System.Drawing.Color.Goldenrod;
            this.ButtonUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonUpdate.FlatAppearance.BorderSize = 0;
            this.ButtonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonUpdate.ForeColor = System.Drawing.Color.White;
            this.ButtonUpdate.Location = new System.Drawing.Point(76, 217);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(147, 37);
            this.ButtonUpdate.TabIndex = 3;
            this.ButtonUpdate.Text = "Sauvegarder";
            this.ButtonUpdate.UseVisualStyleBackColor = false;
            this.ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Goldenrod;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 27);
            this.label1.TabIndex = 63;
            this.label1.Text = "Modifier Mot de passe";
            // 
            // TextBoxNewPassword
            // 
            this.TextBoxNewPassword.BackColor = System.Drawing.Color.White;
            this.TextBoxNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxNewPassword.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxNewPassword.Location = new System.Drawing.Point(76, 125);
            this.TextBoxNewPassword.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxNewPassword.Name = "TextBoxNewPassword";
            this.TextBoxNewPassword.PasswordChar = '*';
            this.TextBoxNewPassword.Size = new System.Drawing.Size(147, 18);
            this.TextBoxNewPassword.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(72, 105);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 16);
            this.label4.TabIndex = 62;
            this.label4.Text = "Nouveau mot de passe";
            // 
            // TextBoxConfirmNewPassword
            // 
            this.TextBoxConfirmNewPassword.BackColor = System.Drawing.Color.White;
            this.TextBoxConfirmNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxConfirmNewPassword.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxConfirmNewPassword.Location = new System.Drawing.Point(76, 172);
            this.TextBoxConfirmNewPassword.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxConfirmNewPassword.Name = "TextBoxConfirmNewPassword";
            this.TextBoxConfirmNewPassword.PasswordChar = '*';
            this.TextBoxConfirmNewPassword.Size = new System.Drawing.Size(147, 18);
            this.TextBoxConfirmNewPassword.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(73, 152);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 16);
            this.label2.TabIndex = 61;
            this.label2.Text = "Confirmer mot de passe";
            // 
            // TextBoxOldPassword
            // 
            this.TextBoxOldPassword.BackColor = System.Drawing.Color.White;
            this.TextBoxOldPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxOldPassword.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxOldPassword.Location = new System.Drawing.Point(76, 70);
            this.TextBoxOldPassword.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxOldPassword.Name = "TextBoxOldPassword";
            this.TextBoxOldPassword.PasswordChar = '*';
            this.TextBoxOldPassword.Size = new System.Drawing.Size(147, 18);
            this.TextBoxOldPassword.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(73, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 16);
            this.label3.TabIndex = 67;
            this.label3.Text = "Ancien mot de passe";
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.BackColor = System.Drawing.Color.White;
            this.ButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonCancel.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCancel.ForeColor = System.Drawing.Color.Goldenrod;
            this.ButtonCancel.Location = new System.Drawing.Point(76, 276);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(147, 37);
            this.ButtonCancel.TabIndex = 4;
            this.ButtonCancel.Text = "Annuler";
            this.ButtonCancel.UseVisualStyleBackColor = false;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // UpdateAdminPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(306, 340);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxNewPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TextBoxConfirmNewPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBoxOldPassword);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateAdminPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateAdminPassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ButtonUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxNewPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBoxConfirmNewPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxOldPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ButtonCancel;
    }
}