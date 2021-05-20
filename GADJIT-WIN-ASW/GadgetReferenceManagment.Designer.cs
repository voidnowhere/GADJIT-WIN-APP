
namespace GADJIT_WIN_ASW
{
    partial class GadgetReferenceManagment
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
            this.TextBoxActivedReference = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.TextBoxTotalReference = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboBoxStatus = new System.Windows.Forms.ComboBox();
            this.ComboBoxBrand = new System.Windows.Forms.ComboBox();
            this.ComboBoxCategory = new System.Windows.Forms.ComboBox();
            this.TextBoxDesignation = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TextBoxDeactivatedReference = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.DGVReference = new System.Windows.Forms.DataGridView();
            this.ColumnTextBoxID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnComboBoxCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnComboBoxBrand = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnTextBoxDesignation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTextBoxDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnComboBoxStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label20 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVReference)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBoxActivedReference
            // 
            this.TextBoxActivedReference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxActivedReference.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.TextBoxActivedReference.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxActivedReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxActivedReference.Location = new System.Drawing.Point(697, 546);
            this.TextBoxActivedReference.Name = "TextBoxActivedReference";
            this.TextBoxActivedReference.ReadOnly = true;
            this.TextBoxActivedReference.Size = new System.Drawing.Size(38, 15);
            this.TextBoxActivedReference.TabIndex = 76;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(635, 545);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 16);
            this.label19.TabIndex = 75;
            this.label19.Text = "Activer";
            // 
            // TextBoxTotalReference
            // 
            this.TextBoxTotalReference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxTotalReference.BackColor = System.Drawing.Color.White;
            this.TextBoxTotalReference.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxTotalReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxTotalReference.Location = new System.Drawing.Point(923, 547);
            this.TextBoxTotalReference.Name = "TextBoxTotalReference";
            this.TextBoxTotalReference.ReadOnly = true;
            this.TextBoxTotalReference.Size = new System.Drawing.Size(40, 15);
            this.TextBoxTotalReference.TabIndex = 74;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(593, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 52;
            this.label3.Text = "Status";
            // 
            // ComboBoxStatus
            // 
            this.ComboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxStatus.FormattingEnabled = true;
            this.ComboBoxStatus.Items.AddRange(new object[] {
            "--tous--",
            "Activer",
            "Désactiver"});
            this.ComboBoxStatus.Location = new System.Drawing.Point(640, 23);
            this.ComboBoxStatus.Name = "ComboBoxStatus";
            this.ComboBoxStatus.Size = new System.Drawing.Size(121, 24);
            this.ComboBoxStatus.TabIndex = 3;
            // 
            // ComboBoxBrand
            // 
            this.ComboBoxBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxBrand.FormattingEnabled = true;
            this.ComboBoxBrand.Location = new System.Drawing.Point(245, 24);
            this.ComboBoxBrand.Name = "ComboBoxBrand";
            this.ComboBoxBrand.Size = new System.Drawing.Size(100, 24);
            this.ComboBoxBrand.TabIndex = 1;
            // 
            // ComboBoxCategory
            // 
            this.ComboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxCategory.FormattingEnabled = true;
            this.ComboBoxCategory.Location = new System.Drawing.Point(79, 24);
            this.ComboBoxCategory.Name = "ComboBoxCategory";
            this.ComboBoxCategory.Size = new System.Drawing.Size(100, 24);
            this.ComboBoxCategory.TabIndex = 0;
            // 
            // TextBoxDesignation
            // 
            this.TextBoxDesignation.Location = new System.Drawing.Point(437, 24);
            this.TextBoxDesignation.Name = "TextBoxDesignation";
            this.TextBoxDesignation.Size = new System.Drawing.Size(150, 22);
            this.TextBoxDesignation.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(351, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 16);
            this.label9.TabIndex = 6;
            this.label9.Text = "Désignation";
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSearch.Location = new System.Drawing.Point(766, 24);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(86, 24);
            this.ButtonSearch.TabIndex = 4;
            this.ButtonSearch.Text = "Recherche";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Catégorie";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(185, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "Marque";
            // 
            // TextBoxDeactivatedReference
            // 
            this.TextBoxDeactivatedReference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxDeactivatedReference.BackColor = System.Drawing.Color.Red;
            this.TextBoxDeactivatedReference.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxDeactivatedReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxDeactivatedReference.Location = new System.Drawing.Point(830, 547);
            this.TextBoxDeactivatedReference.Name = "TextBoxDeactivatedReference";
            this.TextBoxDeactivatedReference.ReadOnly = true;
            this.TextBoxDeactivatedReference.Size = new System.Drawing.Size(37, 15);
            this.TextBoxDeactivatedReference.TabIndex = 78;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.ButtonReset);
            this.groupBox8.Controls.Add(this.label3);
            this.groupBox8.Controls.Add(this.ComboBoxStatus);
            this.groupBox8.Controls.Add(this.ComboBoxBrand);
            this.groupBox8.Controls.Add(this.ComboBoxCategory);
            this.groupBox8.Controls.Add(this.TextBoxDesignation);
            this.groupBox8.Controls.Add(this.label9);
            this.groupBox8.Controls.Add(this.ButtonSearch);
            this.groupBox8.Controls.Add(this.label6);
            this.groupBox8.Controls.Add(this.label8);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(12, 57);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(949, 60);
            this.groupBox8.TabIndex = 72;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Recherche";
            // 
            // ButtonReset
            // 
            this.ButtonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonReset.Location = new System.Drawing.Point(858, 24);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(86, 24);
            this.ButtonReset.TabIndex = 5;
            this.ButtonReset.Text = "Réinitialiser";
            this.ButtonReset.UseVisualStyleBackColor = true;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(741, 545);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 16);
            this.label15.TabIndex = 77;
            this.label15.Text = "Desavtiver";
            // 
            // DGVReference
            // 
            this.DGVReference.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVReference.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVReference.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTextBoxID,
            this.ColumnComboBoxCategory,
            this.ColumnComboBoxBrand,
            this.ColumnTextBoxDesignation,
            this.ColumnTextBoxDescription,
            this.ColumnComboBoxStatus});
            this.DGVReference.Location = new System.Drawing.Point(12, 123);
            this.DGVReference.Name = "DGVReference";
            this.DGVReference.Size = new System.Drawing.Size(951, 419);
            this.DGVReference.TabIndex = 71;
            this.DGVReference.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DGVReference_CellValidating);
            this.DGVReference.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVReference_CellValueChanged);
            this.DGVReference.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGVReference_EditingControlShowing);
            this.DGVReference.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.DGVReference_UserDeletedRow);
            this.DGVReference.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DGVReference_UserDeletingRow);
            // 
            // ColumnTextBoxID
            // 
            this.ColumnTextBoxID.HeaderText = "Code";
            this.ColumnTextBoxID.MinimumWidth = 100;
            this.ColumnTextBoxID.Name = "ColumnTextBoxID";
            this.ColumnTextBoxID.ReadOnly = true;
            // 
            // ColumnComboBoxCategory
            // 
            this.ColumnComboBoxCategory.HeaderText = "Catégorie";
            this.ColumnComboBoxCategory.MinimumWidth = 100;
            this.ColumnComboBoxCategory.Name = "ColumnComboBoxCategory";
            this.ColumnComboBoxCategory.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnComboBoxCategory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnComboBoxBrand
            // 
            this.ColumnComboBoxBrand.HeaderText = "Marque";
            this.ColumnComboBoxBrand.MinimumWidth = 100;
            this.ColumnComboBoxBrand.Name = "ColumnComboBoxBrand";
            this.ColumnComboBoxBrand.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnComboBoxBrand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnTextBoxDesignation
            // 
            this.ColumnTextBoxDesignation.HeaderText = "Désignation";
            this.ColumnTextBoxDesignation.MinimumWidth = 150;
            this.ColumnTextBoxDesignation.Name = "ColumnTextBoxDesignation";
            this.ColumnTextBoxDesignation.Width = 150;
            // 
            // ColumnTextBoxDescription
            // 
            this.ColumnTextBoxDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnTextBoxDescription.HeaderText = "Déscription";
            this.ColumnTextBoxDescription.MinimumWidth = 400;
            this.ColumnTextBoxDescription.Name = "ColumnTextBoxDescription";
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
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(873, 546);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(44, 16);
            this.label20.TabIndex = 73;
            this.label20.Text = "Total";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(348, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 25);
            this.label1.TabIndex = 70;
            this.label1.Text = "Gestion Gadget Référence";
            // 
            // GadgetReferenceManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 574);
            this.Controls.Add(this.TextBoxActivedReference);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.TextBoxTotalReference);
            this.Controls.Add(this.TextBoxDeactivatedReference);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.DGVReference);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(975, 400);
            this.Name = "GadgetReferenceManagment";
            this.Text = "GadgetReferenceManagment";
            this.Load += new System.EventHandler(this.GadgetReferenceManagment_Load);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVReference)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxActivedReference;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox TextBoxTotalReference;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboBoxStatus;
        private System.Windows.Forms.ComboBox ComboBoxBrand;
        private System.Windows.Forms.ComboBox ComboBoxCategory;
        private System.Windows.Forms.TextBox TextBoxDesignation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TextBoxDeactivatedReference;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView DGVReference;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxID;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnComboBoxCategory;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnComboBoxBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxDesignation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxDescription;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnComboBoxStatus;
    }
}