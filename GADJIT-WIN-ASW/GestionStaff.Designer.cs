
namespace GADJIT_WIN_ASW
{
    partial class GestionStaff
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
            this.TextBoxClosedTickets = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TextBoxActiveTickets = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboBoxCitySearch = new System.Windows.Forms.ComboBox();
            this.ComboBoxStatusSearch = new System.Windows.Forms.ComboBox();
            this.TextBoxEmailSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.TextBoxCINSearch = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TextBoxLastNameSearch = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.TextBoxTotalTickets = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.DGVStaff = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.ColumnTextBoxID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTextBoxCIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPictureBox = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnTextBoxLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTextBoxFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTextBoxEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTextBoxPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTextBoxPhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTextBoxAdress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnComboBoxCity = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnTextBoxSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTextBoxDisponibility = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnComboBoxStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVStaff)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBoxClosedTickets
            // 
            this.TextBoxClosedTickets.BackColor = System.Drawing.Color.Red;
            this.TextBoxClosedTickets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxClosedTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxClosedTickets.Location = new System.Drawing.Point(897, 421);
            this.TextBoxClosedTickets.Name = "TextBoxClosedTickets";
            this.TextBoxClosedTickets.Size = new System.Drawing.Size(49, 15);
            this.TextBoxClosedTickets.TabIndex = 8;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(808, 420);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 16);
            this.label16.TabIndex = 50;
            this.label16.Text = "Desavtiver";
            // 
            // TextBoxActiveTickets
            // 
            this.TextBoxActiveTickets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.TextBoxActiveTickets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxActiveTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxActiveTickets.Location = new System.Drawing.Point(753, 420);
            this.TextBoxActiveTickets.Name = "TextBoxActiveTickets";
            this.TextBoxActiveTickets.Size = new System.Drawing.Size(49, 15);
            this.TextBoxActiveTickets.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ComboBoxCitySearch);
            this.groupBox1.Controls.Add(this.ComboBoxStatusSearch);
            this.groupBox1.Controls.Add(this.TextBoxEmailSearch);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ButtonSearch);
            this.groupBox1.Controls.Add(this.TextBoxCINSearch);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.TextBoxLastNameSearch);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1044, 58);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recherche";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(714, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 52;
            this.label3.Text = "Status";
            // 
            // ComboBoxCitySearch
            // 
            this.ComboBoxCitySearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxCitySearch.FormattingEnabled = true;
            this.ComboBoxCitySearch.Location = new System.Drawing.Point(587, 24);
            this.ComboBoxCitySearch.Name = "ComboBoxCitySearch";
            this.ComboBoxCitySearch.Size = new System.Drawing.Size(121, 24);
            this.ComboBoxCitySearch.TabIndex = 3;
            // 
            // ComboBoxStatusSearch
            // 
            this.ComboBoxStatusSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxStatusSearch.FormattingEnabled = true;
            this.ComboBoxStatusSearch.Items.AddRange(new object[] {
            "Activer",
            "Désactiver"});
            this.ComboBoxStatusSearch.Location = new System.Drawing.Point(765, 24);
            this.ComboBoxStatusSearch.Name = "ComboBoxStatusSearch";
            this.ComboBoxStatusSearch.Size = new System.Drawing.Size(121, 24);
            this.ComboBoxStatusSearch.TabIndex = 4;
            // 
            // TextBoxEmailSearch
            // 
            this.TextBoxEmailSearch.Location = new System.Drawing.Point(196, 25);
            this.TextBoxEmailSearch.Name = "TextBoxEmailSearch";
            this.TextBoxEmailSearch.Size = new System.Drawing.Size(196, 22);
            this.TextBoxEmailSearch.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 31;
            this.label4.Text = "Email";
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Location = new System.Drawing.Point(929, 25);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(85, 24);
            this.ButtonSearch.TabIndex = 5;
            this.ButtonSearch.Text = "Recherche";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            // 
            // TextBoxCINSearch
            // 
            this.TextBoxCINSearch.Location = new System.Drawing.Point(42, 25);
            this.TextBoxCINSearch.Name = "TextBoxCINSearch";
            this.TextBoxCINSearch.Size = new System.Drawing.Size(100, 22);
            this.TextBoxCINSearch.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 16);
            this.label11.TabIndex = 26;
            this.label11.Text = "CIN";
            // 
            // TextBoxLastNameSearch
            // 
            this.TextBoxLastNameSearch.Location = new System.Drawing.Point(441, 25);
            this.TextBoxLastNameSearch.Name = "TextBoxLastNameSearch";
            this.TextBoxLastNameSearch.Size = new System.Drawing.Size(100, 22);
            this.TextBoxLastNameSearch.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(398, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 16);
            this.label13.TabIndex = 26;
            this.label13.Text = "Nom";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(547, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "Ville";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(696, 420);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 16);
            this.label17.TabIndex = 48;
            this.label17.Text = "Activer";
            // 
            // TextBoxTotalTickets
            // 
            this.TextBoxTotalTickets.BackColor = System.Drawing.Color.White;
            this.TextBoxTotalTickets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxTotalTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxTotalTickets.Location = new System.Drawing.Point(1002, 421);
            this.TextBoxTotalTickets.Name = "TextBoxTotalTickets";
            this.TextBoxTotalTickets.Size = new System.Drawing.Size(49, 15);
            this.TextBoxTotalTickets.TabIndex = 9;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(952, 421);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 16);
            this.label18.TabIndex = 46;
            this.label18.Text = "Total";
            // 
            // DGVStaff
            // 
            this.DGVStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVStaff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTextBoxID,
            this.ColumnTextBoxCIN,
            this.ColumnPictureBox,
            this.ColumnTextBoxLastName,
            this.ColumnTextBoxFirstName,
            this.ColumnTextBoxEmail,
            this.ColumnTextBoxPassword,
            this.ColumnTextBoxPhoneNumber,
            this.ColumnTextBoxAdress,
            this.ColumnComboBoxCity,
            this.ColumnTextBoxSalary,
            this.ColumnTextBoxDisponibility,
            this.ColumnComboBoxStatus});
            this.DGVStaff.Location = new System.Drawing.Point(11, 113);
            this.DGVStaff.Name = "DGVStaff";
            this.DGVStaff.Size = new System.Drawing.Size(1044, 302);
            this.DGVStaff.TabIndex = 6;
            this.DGVStaff.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVStaff_CellDoubleClick);
            this.DGVStaff.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVStaff_CellMouseClick);
            this.DGVStaff.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVStaff_CellValueChanged);
            this.DGVStaff.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGVStaff_EditingControlShowing);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(433, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 25);
            this.label1.TabIndex = 43;
            this.label1.Text = "Gestion Employé";
            // 
            // ColumnTextBoxID
            // 
            this.ColumnTextBoxID.HeaderText = "Code";
            this.ColumnTextBoxID.Name = "ColumnTextBoxID";
            this.ColumnTextBoxID.ReadOnly = true;
            // 
            // ColumnTextBoxCIN
            // 
            this.ColumnTextBoxCIN.HeaderText = "CIN";
            this.ColumnTextBoxCIN.Name = "ColumnTextBoxCIN";
            // 
            // ColumnPictureBox
            // 
            this.ColumnPictureBox.HeaderText = "Photo";
            this.ColumnPictureBox.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ColumnPictureBox.Name = "ColumnPictureBox";
            this.ColumnPictureBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPictureBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnTextBoxLastName
            // 
            this.ColumnTextBoxLastName.HeaderText = "Nom";
            this.ColumnTextBoxLastName.Name = "ColumnTextBoxLastName";
            // 
            // ColumnTextBoxFirstName
            // 
            this.ColumnTextBoxFirstName.HeaderText = "Prénom";
            this.ColumnTextBoxFirstName.Name = "ColumnTextBoxFirstName";
            // 
            // ColumnTextBoxEmail
            // 
            this.ColumnTextBoxEmail.HeaderText = "Email";
            this.ColumnTextBoxEmail.Name = "ColumnTextBoxEmail";
            // 
            // ColumnTextBoxPassword
            // 
            this.ColumnTextBoxPassword.HeaderText = "Mot de passe";
            this.ColumnTextBoxPassword.Name = "ColumnTextBoxPassword";
            // 
            // ColumnTextBoxPhoneNumber
            // 
            this.ColumnTextBoxPhoneNumber.HeaderText = "Téléphone";
            this.ColumnTextBoxPhoneNumber.Name = "ColumnTextBoxPhoneNumber";
            // 
            // ColumnTextBoxAdress
            // 
            this.ColumnTextBoxAdress.HeaderText = "Adresse";
            this.ColumnTextBoxAdress.Name = "ColumnTextBoxAdress";
            // 
            // ColumnComboBoxCity
            // 
            this.ColumnComboBoxCity.HeaderText = "Ville";
            this.ColumnComboBoxCity.Name = "ColumnComboBoxCity";
            // 
            // ColumnTextBoxSalary
            // 
            this.ColumnTextBoxSalary.HeaderText = "Salaire";
            this.ColumnTextBoxSalary.Name = "ColumnTextBoxSalary";
            // 
            // ColumnTextBoxDisponibility
            // 
            this.ColumnTextBoxDisponibility.HeaderText = "Disponibilité";
            this.ColumnTextBoxDisponibility.Name = "ColumnTextBoxDisponibility";
            // 
            // ColumnComboBoxStatus
            // 
            this.ColumnComboBoxStatus.HeaderText = "Status";
            this.ColumnComboBoxStatus.Items.AddRange(new object[] {
            "Activer",
            "Désactiver"});
            this.ColumnComboBoxStatus.Name = "ColumnComboBoxStatus";
            this.ColumnComboBoxStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnComboBoxStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // GestionStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 443);
            this.Controls.Add(this.TextBoxClosedTickets);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.TextBoxActiveTickets);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.TextBoxTotalTickets);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.DGVStaff);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GestionStaff";
            this.Text = "GestionStaff";
            this.Load += new System.EventHandler(this.GestionStaff_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVStaff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxClosedTickets;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TextBoxActiveTickets;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboBoxCitySearch;
        private System.Windows.Forms.ComboBox ComboBoxStatusSearch;
        private System.Windows.Forms.TextBox TextBoxEmailSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.TextBox TextBoxCINSearch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TextBoxLastNameSearch;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox TextBoxTotalTickets;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridView DGVStaff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxCIN;
        private System.Windows.Forms.DataGridViewImageColumn ColumnPictureBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxPhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxAdress;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnComboBoxCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxDisponibility;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnComboBoxStatus;
    }
}