
namespace GADJIT_WIN_ASW
{
    partial class WorkerManagment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGVWorker = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ButtonReset = new System.Windows.Forms.Button();
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
            this.TextBoxDeactivatedStaffs = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TextBoxActivedStaffs = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.TextBoxTotalStaffs = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
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
            this.ColumnSpecialty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnComboBoxDisponibility = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnComboBoxStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVWorker)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVWorker
            // 
            this.DGVWorker.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVWorker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVWorker.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.ColumnSpecialty,
            this.ColumnComboBoxDisponibility,
            this.ColumnComboBoxStatus});
            this.DGVWorker.Location = new System.Drawing.Point(12, 133);
            this.DGVWorker.Name = "DGVWorker";
            this.DGVWorker.Size = new System.Drawing.Size(928, 374);
            this.DGVWorker.TabIndex = 7;
            this.DGVWorker.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVWorker_CellDoubleClick);
            this.DGVWorker.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVWorker_CellMouseClick);
            this.DGVWorker.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DGVWorker_CellValidating);
            this.DGVWorker.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVWorker_CellValueChanged);
            this.DGVWorker.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGVStaff_EditingControlShowing);
            this.DGVWorker.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.DGVWorker_UserDeletedRow);
            this.DGVWorker.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DGVWorker_UserDeletingRow);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ButtonReset);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(928, 85);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recherche";
            // 
            // ButtonReset
            // 
            this.ButtonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonReset.Location = new System.Drawing.Point(835, 35);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(87, 24);
            this.ButtonReset.TabIndex = 53;
            this.ButtonReset.Text = "Réinitialiser";
            this.ButtonReset.UseVisualStyleBackColor = true;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 52;
            this.label3.Text = "Status";
            // 
            // ComboBoxCitySearch
            // 
            this.ComboBoxCitySearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxCitySearch.FormattingEnabled = true;
            this.ComboBoxCitySearch.Location = new System.Drawing.Point(46, 51);
            this.ComboBoxCitySearch.Name = "ComboBoxCitySearch";
            this.ComboBoxCitySearch.Size = new System.Drawing.Size(121, 24);
            this.ComboBoxCitySearch.TabIndex = 3;
            // 
            // ComboBoxStatusSearch
            // 
            this.ComboBoxStatusSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxStatusSearch.FormattingEnabled = true;
            this.ComboBoxStatusSearch.Items.AddRange(new object[] {
            "--tous--",
            "Activer",
            "Désactiver"});
            this.ComboBoxStatusSearch.Location = new System.Drawing.Point(224, 51);
            this.ComboBoxStatusSearch.Name = "ComboBoxStatusSearch";
            this.ComboBoxStatusSearch.Size = new System.Drawing.Size(121, 24);
            this.ComboBoxStatusSearch.TabIndex = 4;
            // 
            // TextBoxEmailSearch
            // 
            this.TextBoxEmailSearch.Location = new System.Drawing.Point(224, 23);
            this.TextBoxEmailSearch.Name = "TextBoxEmailSearch";
            this.TextBoxEmailSearch.Size = new System.Drawing.Size(196, 22);
            this.TextBoxEmailSearch.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 31;
            this.label4.Text = "Email";
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSearch.Location = new System.Drawing.Point(744, 35);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(85, 24);
            this.ButtonSearch.TabIndex = 5;
            this.ButtonSearch.Text = "Recherche";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // TextBoxCINSearch
            // 
            this.TextBoxCINSearch.Location = new System.Drawing.Point(46, 23);
            this.TextBoxCINSearch.Name = "TextBoxCINSearch";
            this.TextBoxCINSearch.Size = new System.Drawing.Size(121, 22);
            this.TextBoxCINSearch.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 16);
            this.label11.TabIndex = 26;
            this.label11.Text = "CIN";
            // 
            // TextBoxLastNameSearch
            // 
            this.TextBoxLastNameSearch.Location = new System.Drawing.Point(469, 23);
            this.TextBoxLastNameSearch.Name = "TextBoxLastNameSearch";
            this.TextBoxLastNameSearch.Size = new System.Drawing.Size(100, 22);
            this.TextBoxLastNameSearch.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(426, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 16);
            this.label13.TabIndex = 26;
            this.label13.Text = "Nom";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "Ville";
            // 
            // TextBoxDeactivatedStaffs
            // 
            this.TextBoxDeactivatedStaffs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxDeactivatedStaffs.BackColor = System.Drawing.Color.Red;
            this.TextBoxDeactivatedStaffs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxDeactivatedStaffs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxDeactivatedStaffs.Location = new System.Drawing.Point(786, 513);
            this.TextBoxDeactivatedStaffs.Name = "TextBoxDeactivatedStaffs";
            this.TextBoxDeactivatedStaffs.ReadOnly = true;
            this.TextBoxDeactivatedStaffs.Size = new System.Drawing.Size(49, 15);
            this.TextBoxDeactivatedStaffs.TabIndex = 52;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(697, 512);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 16);
            this.label16.TabIndex = 56;
            this.label16.Text = "Desavtiver";
            // 
            // TextBoxActivedStaffs
            // 
            this.TextBoxActivedStaffs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxActivedStaffs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.TextBoxActivedStaffs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxActivedStaffs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxActivedStaffs.Location = new System.Drawing.Point(642, 513);
            this.TextBoxActivedStaffs.Name = "TextBoxActivedStaffs";
            this.TextBoxActivedStaffs.ReadOnly = true;
            this.TextBoxActivedStaffs.Size = new System.Drawing.Size(49, 15);
            this.TextBoxActivedStaffs.TabIndex = 51;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(580, 512);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 16);
            this.label17.TabIndex = 55;
            this.label17.Text = "Activer";
            // 
            // TextBoxTotalStaffs
            // 
            this.TextBoxTotalStaffs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxTotalStaffs.BackColor = System.Drawing.Color.White;
            this.TextBoxTotalStaffs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxTotalStaffs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxTotalStaffs.Location = new System.Drawing.Point(891, 513);
            this.TextBoxTotalStaffs.Name = "TextBoxTotalStaffs";
            this.TextBoxTotalStaffs.ReadOnly = true;
            this.TextBoxTotalStaffs.Size = new System.Drawing.Size(49, 15);
            this.TextBoxTotalStaffs.TabIndex = 53;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(841, 512);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 16);
            this.label18.TabIndex = 54;
            this.label18.Text = "Total";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(383, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 25);
            this.label1.TabIndex = 57;
            this.label1.Text = "Gestion Employé";
            // 
            // ColumnTextBoxID
            // 
            this.ColumnTextBoxID.HeaderText = "Code";
            this.ColumnTextBoxID.MinimumWidth = 100;
            this.ColumnTextBoxID.Name = "ColumnTextBoxID";
            this.ColumnTextBoxID.ReadOnly = true;
            // 
            // ColumnTextBoxCIN
            // 
            this.ColumnTextBoxCIN.HeaderText = "CIN";
            this.ColumnTextBoxCIN.MaxInputLength = 8;
            this.ColumnTextBoxCIN.MinimumWidth = 100;
            this.ColumnTextBoxCIN.Name = "ColumnTextBoxCIN";
            // 
            // ColumnPictureBox
            // 
            this.ColumnPictureBox.HeaderText = "Photo";
            this.ColumnPictureBox.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ColumnPictureBox.MinimumWidth = 50;
            this.ColumnPictureBox.Name = "ColumnPictureBox";
            this.ColumnPictureBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPictureBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnPictureBox.Width = 50;
            // 
            // ColumnTextBoxLastName
            // 
            this.ColumnTextBoxLastName.HeaderText = "Nom";
            this.ColumnTextBoxLastName.MinimumWidth = 100;
            this.ColumnTextBoxLastName.Name = "ColumnTextBoxLastName";
            // 
            // ColumnTextBoxFirstName
            // 
            this.ColumnTextBoxFirstName.HeaderText = "Prénom";
            this.ColumnTextBoxFirstName.MinimumWidth = 100;
            this.ColumnTextBoxFirstName.Name = "ColumnTextBoxFirstName";
            // 
            // ColumnTextBoxEmail
            // 
            this.ColumnTextBoxEmail.HeaderText = "Email";
            this.ColumnTextBoxEmail.MinimumWidth = 150;
            this.ColumnTextBoxEmail.Name = "ColumnTextBoxEmail";
            this.ColumnTextBoxEmail.Width = 150;
            // 
            // ColumnTextBoxPassword
            // 
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            this.ColumnTextBoxPassword.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnTextBoxPassword.HeaderText = "Mot de passe";
            this.ColumnTextBoxPassword.MinimumWidth = 100;
            this.ColumnTextBoxPassword.Name = "ColumnTextBoxPassword";
            // 
            // ColumnTextBoxPhoneNumber
            // 
            this.ColumnTextBoxPhoneNumber.HeaderText = "Téléphone";
            this.ColumnTextBoxPhoneNumber.MaxInputLength = 10;
            this.ColumnTextBoxPhoneNumber.MinimumWidth = 100;
            this.ColumnTextBoxPhoneNumber.Name = "ColumnTextBoxPhoneNumber";
            // 
            // ColumnTextBoxAdress
            // 
            this.ColumnTextBoxAdress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnTextBoxAdress.HeaderText = "Adresse";
            this.ColumnTextBoxAdress.MinimumWidth = 200;
            this.ColumnTextBoxAdress.Name = "ColumnTextBoxAdress";
            // 
            // ColumnComboBoxCity
            // 
            this.ColumnComboBoxCity.HeaderText = "Ville";
            this.ColumnComboBoxCity.MinimumWidth = 100;
            this.ColumnComboBoxCity.Name = "ColumnComboBoxCity";
            // 
            // ColumnTextBoxSalary
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "0.00";
            dataGridViewCellStyle2.NullValue = null;
            this.ColumnTextBoxSalary.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnTextBoxSalary.HeaderText = "Salaire";
            this.ColumnTextBoxSalary.MinimumWidth = 100;
            this.ColumnTextBoxSalary.Name = "ColumnTextBoxSalary";
            // 
            // ColumnSpecialty
            // 
            this.ColumnSpecialty.HeaderText = "Spécialité";
            this.ColumnSpecialty.MinimumWidth = 60;
            this.ColumnSpecialty.Name = "ColumnSpecialty";
            this.ColumnSpecialty.ReadOnly = true;
            this.ColumnSpecialty.Width = 60;
            // 
            // ColumnComboBoxDisponibility
            // 
            this.ColumnComboBoxDisponibility.HeaderText = "Disponibilité";
            this.ColumnComboBoxDisponibility.Items.AddRange(new object[] {
            "Hors Ligne",
            "En Ligne",
            "Break"});
            this.ColumnComboBoxDisponibility.MinimumWidth = 100;
            this.ColumnComboBoxDisponibility.Name = "ColumnComboBoxDisponibility";
            this.ColumnComboBoxDisponibility.ReadOnly = true;
            this.ColumnComboBoxDisponibility.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnComboBoxDisponibility.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnComboBoxStatus
            // 
            this.ColumnComboBoxStatus.HeaderText = "Status";
            this.ColumnComboBoxStatus.Items.AddRange(new object[] {
            "Activer",
            "Désactiver"});
            this.ColumnComboBoxStatus.MinimumWidth = 100;
            this.ColumnComboBoxStatus.Name = "ColumnComboBoxStatus";
            this.ColumnComboBoxStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnComboBoxStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // WorkerManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 540);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxDeactivatedStaffs);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.TextBoxActivedStaffs);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.TextBoxTotalStaffs);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DGVWorker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(800, 0);
            this.Name = "WorkerManagment";
            this.Text = "WorkerManagment";
            this.Load += new System.EventHandler(this.WorkerManagment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVWorker)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVWorker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ButtonReset;
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
        private System.Windows.Forms.TextBox TextBoxDeactivatedStaffs;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TextBoxActivedStaffs;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox TextBoxTotalStaffs;
        private System.Windows.Forms.Label label18;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSpecialty;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnComboBoxDisponibility;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnComboBoxStatus;
    }
}