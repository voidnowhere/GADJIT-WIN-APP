﻿
namespace GADJIT_WIN_ASW
{
    partial class GadgetCategoryBrandManagment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.TextBoxDeactivatedCategory = new System.Windows.Forms.TextBox();
            this.DGVCategory = new System.Windows.Forms.DataGridView();
            this.ColumnTextBoxCategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTextBoxCategoryDesignation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnComboBoxCategoryStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.TextBoxTotalCategory = new System.Windows.Forms.TextBox();
            this.TextBoxActivedCategory = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.TextBoxDeactivatedBrand = new System.Windows.Forms.TextBox();
            this.DGVBrand = new System.Windows.Forms.DataGridView();
            this.ColumnTextBoxBrandID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTextBoxBrandDesignation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnComboBoxBrandStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxTotalBrand = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxActivedBrand = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCategory)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBrand)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(210, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(398, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gestion Gadget Catégorie et Marque";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox5.Controls.Add(this.TextBoxDeactivatedCategory);
            this.groupBox5.Controls.Add(this.DGVCategory);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.TextBoxTotalCategory);
            this.groupBox5.Controls.Add(this.TextBoxActivedCategory);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.Goldenrod;
            this.groupBox5.Location = new System.Drawing.Point(7, 51);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(390, 451);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Catégorie";
            // 
            // TextBoxDeactivatedCategory
            // 
            this.TextBoxDeactivatedCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxDeactivatedCategory.BackColor = System.Drawing.Color.Red;
            this.TextBoxDeactivatedCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxDeactivatedCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxDeactivatedCategory.Location = new System.Drawing.Point(251, 430);
            this.TextBoxDeactivatedCategory.Name = "TextBoxDeactivatedCategory";
            this.TextBoxDeactivatedCategory.ReadOnly = true;
            this.TextBoxDeactivatedCategory.Size = new System.Drawing.Size(40, 15);
            this.TextBoxDeactivatedCategory.TabIndex = 60;
            // 
            // DGVCategory
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Menu;
            this.DGVCategory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVCategory.BackgroundColor = System.Drawing.Color.White;
            this.DGVCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVCategory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVCategory.ColumnHeadersHeight = 30;
            this.DGVCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTextBoxCategoryID,
            this.ColumnTextBoxCategoryDesignation,
            this.ColumnComboBoxCategoryStatus});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(181)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVCategory.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVCategory.EnableHeadersVisualStyles = false;
            this.DGVCategory.Location = new System.Drawing.Point(6, 21);
            this.DGVCategory.Name = "DGVCategory";
            this.DGVCategory.Size = new System.Drawing.Size(378, 403);
            this.DGVCategory.TabIndex = 1;
            this.DGVCategory.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVCategory_CellEndEdit);
            this.DGVCategory.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DGVCategory_CellValidating);
            this.DGVCategory.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVCategory_CellValueChanged);
            this.DGVCategory.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGVCategory_EditingControlShowing);
            this.DGVCategory.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.DGVCategory_UserDeletedRow);
            this.DGVCategory.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DGVCategory_UserDeletingRow);
            // 
            // ColumnTextBoxCategoryID
            // 
            this.ColumnTextBoxCategoryID.HeaderText = "Code";
            this.ColumnTextBoxCategoryID.MinimumWidth = 50;
            this.ColumnTextBoxCategoryID.Name = "ColumnTextBoxCategoryID";
            this.ColumnTextBoxCategoryID.ReadOnly = true;
            this.ColumnTextBoxCategoryID.Width = 50;
            // 
            // ColumnTextBoxCategoryDesignation
            // 
            this.ColumnTextBoxCategoryDesignation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnTextBoxCategoryDesignation.HeaderText = "Designation";
            this.ColumnTextBoxCategoryDesignation.MinimumWidth = 100;
            this.ColumnTextBoxCategoryDesignation.Name = "ColumnTextBoxCategoryDesignation";
            // 
            // ColumnComboBoxCategoryStatus
            // 
            this.ColumnComboBoxCategoryStatus.HeaderText = "Etat";
            this.ColumnComboBoxCategoryStatus.Items.AddRange(new object[] {
            "Activer",
            "Désactiver"});
            this.ColumnComboBoxCategoryStatus.MinimumWidth = 100;
            this.ColumnComboBoxCategoryStatus.Name = "ColumnComboBoxCategoryStatus";
            this.ColumnComboBoxCategoryStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnComboBoxCategoryStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(54, 429);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 16);
            this.label13.TabIndex = 57;
            this.label13.Text = "Activer";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(162, 429);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 16);
            this.label7.TabIndex = 59;
            this.label7.Text = "Desavtiver";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(294, 430);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 16);
            this.label14.TabIndex = 55;
            this.label14.Text = "Total";
            // 
            // TextBoxTotalCategory
            // 
            this.TextBoxTotalCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxTotalCategory.BackColor = System.Drawing.Color.White;
            this.TextBoxTotalCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxTotalCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxTotalCategory.Location = new System.Drawing.Point(344, 430);
            this.TextBoxTotalCategory.Name = "TextBoxTotalCategory";
            this.TextBoxTotalCategory.ReadOnly = true;
            this.TextBoxTotalCategory.Size = new System.Drawing.Size(40, 15);
            this.TextBoxTotalCategory.TabIndex = 56;
            // 
            // TextBoxActivedCategory
            // 
            this.TextBoxActivedCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxActivedCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.TextBoxActivedCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxActivedCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxActivedCategory.Location = new System.Drawing.Point(116, 430);
            this.TextBoxActivedCategory.Name = "TextBoxActivedCategory";
            this.TextBoxActivedCategory.ReadOnly = true;
            this.TextBoxActivedCategory.Size = new System.Drawing.Size(40, 15);
            this.TextBoxActivedCategory.TabIndex = 58;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox6.Controls.Add(this.TextBoxDeactivatedBrand);
            this.groupBox6.Controls.Add(this.DGVBrand);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.TextBoxTotalBrand);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.TextBoxActivedBrand);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.Goldenrod;
            this.groupBox6.Location = new System.Drawing.Point(403, 51);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(390, 451);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Marque";
            // 
            // TextBoxDeactivatedBrand
            // 
            this.TextBoxDeactivatedBrand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxDeactivatedBrand.BackColor = System.Drawing.Color.Red;
            this.TextBoxDeactivatedBrand.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxDeactivatedBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxDeactivatedBrand.Location = new System.Drawing.Point(251, 430);
            this.TextBoxDeactivatedBrand.Name = "TextBoxDeactivatedBrand";
            this.TextBoxDeactivatedBrand.ReadOnly = true;
            this.TextBoxDeactivatedBrand.Size = new System.Drawing.Size(40, 15);
            this.TextBoxDeactivatedBrand.TabIndex = 66;
            // 
            // DGVBrand
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Menu;
            this.DGVBrand.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVBrand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVBrand.BackgroundColor = System.Drawing.Color.White;
            this.DGVBrand.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVBrand.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DGVBrand.ColumnHeadersHeight = 30;
            this.DGVBrand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVBrand.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTextBoxBrandID,
            this.ColumnTextBoxBrandDesignation,
            this.ColumnComboBoxBrandStatus});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(181)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVBrand.DefaultCellStyle = dataGridViewCellStyle6;
            this.DGVBrand.EnableHeadersVisualStyles = false;
            this.DGVBrand.Location = new System.Drawing.Point(6, 21);
            this.DGVBrand.Name = "DGVBrand";
            this.DGVBrand.Size = new System.Drawing.Size(378, 403);
            this.DGVBrand.TabIndex = 4;
            this.DGVBrand.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVBrand_CellEndEdit);
            this.DGVBrand.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DGVBrand_CellValidating);
            this.DGVBrand.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVBrand_CellValueChanged);
            this.DGVBrand.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGVBrand_EditingControlShowing);
            this.DGVBrand.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.DGVBrand_UserDeletedRow);
            this.DGVBrand.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DGVBrand_UserDeletingRow);
            // 
            // ColumnTextBoxBrandID
            // 
            this.ColumnTextBoxBrandID.HeaderText = "Code";
            this.ColumnTextBoxBrandID.MinimumWidth = 50;
            this.ColumnTextBoxBrandID.Name = "ColumnTextBoxBrandID";
            this.ColumnTextBoxBrandID.ReadOnly = true;
            this.ColumnTextBoxBrandID.Width = 50;
            // 
            // ColumnTextBoxBrandDesignation
            // 
            this.ColumnTextBoxBrandDesignation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnTextBoxBrandDesignation.HeaderText = "Designation";
            this.ColumnTextBoxBrandDesignation.MinimumWidth = 150;
            this.ColumnTextBoxBrandDesignation.Name = "ColumnTextBoxBrandDesignation";
            // 
            // ColumnComboBoxBrandStatus
            // 
            this.ColumnComboBoxBrandStatus.HeaderText = "Etat";
            this.ColumnComboBoxBrandStatus.Items.AddRange(new object[] {
            "Activer",
            "Désactiver"});
            this.ColumnComboBoxBrandStatus.MinimumWidth = 100;
            this.ColumnComboBoxBrandStatus.Name = "ColumnComboBoxBrandStatus";
            this.ColumnComboBoxBrandStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnComboBoxBrandStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(54, 429);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 63;
            this.label2.Text = "Activer";
            // 
            // TextBoxTotalBrand
            // 
            this.TextBoxTotalBrand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxTotalBrand.BackColor = System.Drawing.Color.White;
            this.TextBoxTotalBrand.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxTotalBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxTotalBrand.Location = new System.Drawing.Point(344, 430);
            this.TextBoxTotalBrand.Name = "TextBoxTotalBrand";
            this.TextBoxTotalBrand.ReadOnly = true;
            this.TextBoxTotalBrand.Size = new System.Drawing.Size(40, 15);
            this.TextBoxTotalBrand.TabIndex = 62;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(162, 429);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 65;
            this.label3.Text = "Desavtiver";
            // 
            // TextBoxActivedBrand
            // 
            this.TextBoxActivedBrand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxActivedBrand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.TextBoxActivedBrand.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxActivedBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxActivedBrand.Location = new System.Drawing.Point(116, 430);
            this.TextBoxActivedBrand.Name = "TextBoxActivedBrand";
            this.TextBoxActivedBrand.ReadOnly = true;
            this.TextBoxActivedBrand.Size = new System.Drawing.Size(40, 15);
            this.TextBoxActivedBrand.TabIndex = 64;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(294, 430);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 61;
            this.label4.Text = "Total";
            // 
            // GadgetCategoryBrandManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 514);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GadgetCategoryBrandManagment";
            this.Text = "GadgetCategoryBrandManagment";
            this.Load += new System.EventHandler(this.GadgetCategoryBrandManagment_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCategory)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBrand)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox TextBoxDeactivatedCategory;
        private System.Windows.Forms.DataGridView DGVCategory;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TextBoxTotalCategory;
        private System.Windows.Forms.TextBox TextBoxActivedCategory;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox TextBoxDeactivatedBrand;
        private System.Windows.Forms.DataGridView DGVBrand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxTotalBrand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxActivedBrand;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxCategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxCategoryDesignation;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnComboBoxCategoryStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxBrandID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextBoxBrandDesignation;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnComboBoxBrandStatus;
    }
}