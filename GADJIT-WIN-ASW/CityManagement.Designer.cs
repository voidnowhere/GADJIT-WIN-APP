
namespace GADJIT_WIN_ASW
{
    partial class CityManagement
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
            this.DGVCity = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxDeactivatedCategory = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.TextBoxTotalCategory = new System.Windows.Forms.TextBox();
            this.TextBoxActivedCategory = new System.Windows.Forms.TextBox();
            this.ColumnTextBoxCityID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTextBoxCityDesignation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnComboBoxCityStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCity)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVCity
            // 
            this.DGVCity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.DGVCity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVCity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTextBoxCityID,
            this.ColumnTextBoxCityDesignation,
            this.ColumnComboBoxCityStatus});
            this.DGVCity.Location = new System.Drawing.Point(12, 69);
            this.DGVCity.Name = "DGVCity";
            this.DGVCity.Size = new System.Drawing.Size(437, 275);
            this.DGVCity.TabIndex = 61;
            this.DGVCity.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVCity_CellEndEdit);
            this.DGVCity.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DGVCity_CellValidating);
            this.DGVCity.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVCity_CellValueChanged);
            this.DGVCity.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGVCity_EditingControlShowing);
            this.DGVCity.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.DGVCity_UserDeletedRow);
            this.DGVCity.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DGVCity_UserDeletingRow);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(164, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 25);
            this.label1.TabIndex = 62;
            this.label1.Text = "Gestion Ville";
            // 
            // TextBoxDeactivatedCategory
            // 
            this.TextBoxDeactivatedCategory.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.TextBoxDeactivatedCategory.BackColor = System.Drawing.Color.Red;
            this.TextBoxDeactivatedCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxDeactivatedCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxDeactivatedCategory.Location = new System.Drawing.Point(316, 350);
            this.TextBoxDeactivatedCategory.Name = "TextBoxDeactivatedCategory";
            this.TextBoxDeactivatedCategory.ReadOnly = true;
            this.TextBoxDeactivatedCategory.Size = new System.Drawing.Size(40, 15);
            this.TextBoxDeactivatedCategory.TabIndex = 68;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(119, 349);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 16);
            this.label13.TabIndex = 65;
            this.label13.Text = "Activer";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(227, 349);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 16);
            this.label7.TabIndex = 67;
            this.label7.Text = "Desavtiver";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(359, 350);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 16);
            this.label14.TabIndex = 63;
            this.label14.Text = "Total";
            // 
            // TextBoxTotalCategory
            // 
            this.TextBoxTotalCategory.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.TextBoxTotalCategory.BackColor = System.Drawing.Color.White;
            this.TextBoxTotalCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxTotalCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxTotalCategory.Location = new System.Drawing.Point(409, 350);
            this.TextBoxTotalCategory.Name = "TextBoxTotalCategory";
            this.TextBoxTotalCategory.ReadOnly = true;
            this.TextBoxTotalCategory.Size = new System.Drawing.Size(40, 15);
            this.TextBoxTotalCategory.TabIndex = 64;
            // 
            // TextBoxActivedCategory
            // 
            this.TextBoxActivedCategory.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.TextBoxActivedCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.TextBoxActivedCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxActivedCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxActivedCategory.Location = new System.Drawing.Point(181, 350);
            this.TextBoxActivedCategory.Name = "TextBoxActivedCategory";
            this.TextBoxActivedCategory.ReadOnly = true;
            this.TextBoxActivedCategory.Size = new System.Drawing.Size(40, 15);
            this.TextBoxActivedCategory.TabIndex = 66;
            // 
            // ColumnTextBoxCityID
            // 
            this.ColumnTextBoxCityID.HeaderText = "Code";
            this.ColumnTextBoxCityID.MinimumWidth = 50;
            this.ColumnTextBoxCityID.Name = "ColumnTextBoxCityID";
            this.ColumnTextBoxCityID.ReadOnly = true;
            this.ColumnTextBoxCityID.Width = 50;
            // 
            // ColumnTextBoxCityDesignation
            // 
            this.ColumnTextBoxCityDesignation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnTextBoxCityDesignation.HeaderText = "Designation";
            this.ColumnTextBoxCityDesignation.MinimumWidth = 200;
            this.ColumnTextBoxCityDesignation.Name = "ColumnTextBoxCityDesignation";
            // 
            // ColumnComboBoxCityStatus
            // 
            this.ColumnComboBoxCityStatus.HeaderText = "Status";
            this.ColumnComboBoxCityStatus.Items.AddRange(new object[] {
            "Activer",
            "Désactiver"});
            this.ColumnComboBoxCityStatus.MinimumWidth = 100;
            this.ColumnComboBoxCityStatus.Name = "ColumnComboBoxCityStatus";
            this.ColumnComboBoxCityStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnComboBoxCityStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CityManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 377);
            this.Controls.Add(this.DGVCity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxDeactivatedCategory);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.TextBoxTotalCategory);
            this.Controls.Add(this.TextBoxActivedCategory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CityManagement";
            this.Text = "CityManagement";
            this.Load += new System.EventHandler(this.CityManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVCity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVCity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxDeactivatedCategory;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TextBoxTotalCategory;
        private System.Windows.Forms.TextBox TextBoxActivedCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxCityID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxCityDesignation;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnComboBoxCityStatus;
    }
}