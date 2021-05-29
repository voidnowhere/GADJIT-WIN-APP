
namespace GADJIT_WIN_ASW
{
    partial class ClientManagment
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
            this.TextBoxDeactivatedClients = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TextBoxActivedClients = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.TextBoxTotalClients = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboBoxStatusSearch = new System.Windows.Forms.ComboBox();
            this.ComboBoxCitySearch = new System.Windows.Forms.ComboBox();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.TextBoxEmailSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxLastNameSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DGVClient = new System.Windows.Forms.DataGridView();
            this.ColumnTextBoxID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTextBoxLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTextBoxFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTextBoxEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTextBoxTelephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTextBoxAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTextBoxCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnComboBoxStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVClient)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBoxDeactivatedClients
            // 
            this.TextBoxDeactivatedClients.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxDeactivatedClients.BackColor = System.Drawing.Color.Red;
            this.TextBoxDeactivatedClients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxDeactivatedClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxDeactivatedClients.Location = new System.Drawing.Point(837, 520);
            this.TextBoxDeactivatedClients.Name = "TextBoxDeactivatedClients";
            this.TextBoxDeactivatedClients.ReadOnly = true;
            this.TextBoxDeactivatedClients.Size = new System.Drawing.Size(49, 15);
            this.TextBoxDeactivatedClients.TabIndex = 57;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(748, 520);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 16);
            this.label16.TabIndex = 56;
            this.label16.Text = "Desavtiver";
            // 
            // TextBoxActivedClients
            // 
            this.TextBoxActivedClients.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxActivedClients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.TextBoxActivedClients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxActivedClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxActivedClients.Location = new System.Drawing.Point(693, 520);
            this.TextBoxActivedClients.Name = "TextBoxActivedClients";
            this.TextBoxActivedClients.ReadOnly = true;
            this.TextBoxActivedClients.Size = new System.Drawing.Size(49, 15);
            this.TextBoxActivedClients.TabIndex = 55;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(631, 520);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 16);
            this.label17.TabIndex = 54;
            this.label17.Text = "Activer";
            // 
            // TextBoxTotalClients
            // 
            this.TextBoxTotalClients.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxTotalClients.BackColor = System.Drawing.Color.White;
            this.TextBoxTotalClients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxTotalClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxTotalClients.Location = new System.Drawing.Point(942, 520);
            this.TextBoxTotalClients.Name = "TextBoxTotalClients";
            this.TextBoxTotalClients.ReadOnly = true;
            this.TextBoxTotalClients.Size = new System.Drawing.Size(48, 15);
            this.TextBoxTotalClients.TabIndex = 53;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(892, 520);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 16);
            this.label18.TabIndex = 52;
            this.label18.Text = "Total";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ButtonReset);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ComboBoxStatusSearch);
            this.groupBox1.Controls.Add(this.ComboBoxCitySearch);
            this.groupBox1.Controls.Add(this.ButtonSearch);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.TextBoxEmailSearch);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TextBoxLastNameSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 48);
            this.groupBox1.MinimumSize = new System.Drawing.Size(945, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(983, 55);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recherche";
            // 
            // ButtonReset
            // 
            this.ButtonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonReset.Location = new System.Drawing.Point(880, 24);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(97, 24);
            this.ButtonReset.TabIndex = 54;
            this.ButtonReset.Text = "Réinitialiser";
            this.ButtonReset.UseVisualStyleBackColor = true;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(572, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 50;
            this.label3.Text = "Status";
            // 
            // ComboBoxStatusSearch
            // 
            this.ComboBoxStatusSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxStatusSearch.FormattingEnabled = true;
            this.ComboBoxStatusSearch.Items.AddRange(new object[] {
            "--tous--",
            "Activer",
            "Désactiver"});
            this.ComboBoxStatusSearch.Location = new System.Drawing.Point(623, 24);
            this.ComboBoxStatusSearch.Name = "ComboBoxStatusSearch";
            this.ComboBoxStatusSearch.Size = new System.Drawing.Size(121, 24);
            this.ComboBoxStatusSearch.TabIndex = 3;
            // 
            // ComboBoxCitySearch
            // 
            this.ComboBoxCitySearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxCitySearch.FormattingEnabled = true;
            this.ComboBoxCitySearch.Location = new System.Drawing.Point(445, 24);
            this.ComboBoxCitySearch.Name = "ComboBoxCitySearch";
            this.ComboBoxCitySearch.Size = new System.Drawing.Size(121, 24);
            this.ComboBoxCitySearch.TabIndex = 2;
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSearch.Location = new System.Drawing.Point(792, 23);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(82, 25);
            this.ButtonSearch.TabIndex = 4;
            this.ButtonSearch.Text = "Recherche";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(405, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Ville";
            // 
            // TextBoxEmailSearch
            // 
            this.TextBoxEmailSearch.Location = new System.Drawing.Point(54, 24);
            this.TextBoxEmailSearch.Name = "TextBoxEmailSearch";
            this.TextBoxEmailSearch.Size = new System.Drawing.Size(196, 22);
            this.TextBoxEmailSearch.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Email";
            // 
            // TextBoxLastNameSearch
            // 
            this.TextBoxLastNameSearch.Location = new System.Drawing.Point(299, 24);
            this.TextBoxLastNameSearch.Name = "TextBoxLastNameSearch";
            this.TextBoxLastNameSearch.Size = new System.Drawing.Size(100, 22);
            this.TextBoxLastNameSearch.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(417, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 25);
            this.label2.TabIndex = 50;
            this.label2.Text = "Liste Clients";
            // 
            // DGVClient
            // 
            this.DGVClient.AllowUserToAddRows = false;
            this.DGVClient.AllowUserToDeleteRows = false;
            this.DGVClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVClient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTextBoxID,
            this.ColumnTextBoxLastName,
            this.ColumnTextBoxFirstName,
            this.ColumnTextBoxEmail,
            this.ColumnTextBoxTelephone,
            this.ColumnTextBoxAddress,
            this.ColumnTextBoxCity,
            this.ColumnComboBoxStatus});
            this.DGVClient.Location = new System.Drawing.Point(14, 112);
            this.DGVClient.Name = "DGVClient";
            this.DGVClient.Size = new System.Drawing.Size(981, 402);
            this.DGVClient.TabIndex = 49;
            this.DGVClient.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVClient_CellValueChanged);
            // 
            // ColumnTextBoxID
            // 
            this.ColumnTextBoxID.HeaderText = "Code";
            this.ColumnTextBoxID.MinimumWidth = 50;
            this.ColumnTextBoxID.Name = "ColumnTextBoxID";
            this.ColumnTextBoxID.ReadOnly = true;
            this.ColumnTextBoxID.Width = 50;
            // 
            // ColumnTextBoxLastName
            // 
            this.ColumnTextBoxLastName.HeaderText = "Nom";
            this.ColumnTextBoxLastName.MinimumWidth = 100;
            this.ColumnTextBoxLastName.Name = "ColumnTextBoxLastName";
            this.ColumnTextBoxLastName.ReadOnly = true;
            // 
            // ColumnTextBoxFirstName
            // 
            this.ColumnTextBoxFirstName.HeaderText = "Prénom";
            this.ColumnTextBoxFirstName.MinimumWidth = 100;
            this.ColumnTextBoxFirstName.Name = "ColumnTextBoxFirstName";
            this.ColumnTextBoxFirstName.ReadOnly = true;
            // 
            // ColumnTextBoxEmail
            // 
            this.ColumnTextBoxEmail.HeaderText = "Email";
            this.ColumnTextBoxEmail.MinimumWidth = 150;
            this.ColumnTextBoxEmail.Name = "ColumnTextBoxEmail";
            this.ColumnTextBoxEmail.ReadOnly = true;
            this.ColumnTextBoxEmail.Width = 150;
            // 
            // ColumnTextBoxTelephone
            // 
            this.ColumnTextBoxTelephone.HeaderText = "Téléphone";
            this.ColumnTextBoxTelephone.MinimumWidth = 100;
            this.ColumnTextBoxTelephone.Name = "ColumnTextBoxTelephone";
            this.ColumnTextBoxTelephone.ReadOnly = true;
            // 
            // ColumnTextBoxAddress
            // 
            this.ColumnTextBoxAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnTextBoxAddress.HeaderText = "Adresse";
            this.ColumnTextBoxAddress.MinimumWidth = 200;
            this.ColumnTextBoxAddress.Name = "ColumnTextBoxAddress";
            this.ColumnTextBoxAddress.ReadOnly = true;
            // 
            // ColumnTextBoxCity
            // 
            this.ColumnTextBoxCity.HeaderText = "Ville";
            this.ColumnTextBoxCity.MinimumWidth = 100;
            this.ColumnTextBoxCity.Name = "ColumnTextBoxCity";
            this.ColumnTextBoxCity.ReadOnly = true;
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
            // ClientManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 542);
            this.Controls.Add(this.TextBoxDeactivatedClients);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.TextBoxActivedClients);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.TextBoxTotalClients);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DGVClient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ClientManagment";
            this.Text = "ClientManagment";
            this.Load += new System.EventHandler(this.ClientManagment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVClient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxDeactivatedClients;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TextBoxActivedClients;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox TextBoxTotalClients;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboBoxStatusSearch;
        private System.Windows.Forms.ComboBox ComboBoxCitySearch;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TextBoxEmailSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBoxLastNameSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGVClient;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxTelephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxCity;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnComboBoxStatus;
    }
}