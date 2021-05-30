
namespace GADJIT_WIN_ASW
{
    partial class StaffTicketProgression
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TextBoxTicketAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RichTextBoxProblem = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ComboBoxProgression = new System.Windows.Forms.ComboBox();
            this.TextBoxWorker = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ComboBoxReferenceSearch = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.ComboBoxCategorySearch = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.ComboBoxBrandSearch = new System.Windows.Forms.ComboBox();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.DTPTicketToSearch = new System.Windows.Forms.DateTimePicker();
            this.DTPTicketFromSearch = new System.Windows.Forms.DateTimePicker();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.TextBoxWorkerLastNameSearch = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TextBoxClientLastNameSearch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.DGVTicket = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVTicketMonitoring = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TextBoxTotalTickets = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GroupBoxClient = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TextBoxClientEmail = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TextBoxClientPhoneNumber = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTicket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTicketMonitoring)).BeginInit();
            this.GroupBoxClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.GroupBoxClient);
            this.groupBox1.Controls.Add(this.TextBoxTicketAddress);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.RichTextBoxProblem);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.ComboBoxProgression);
            this.groupBox1.Controls.Add(this.TextBoxWorker);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.ButtonSave);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(513, 165);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(351, 413);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ticket détail";
            // 
            // TextBoxTicketAddress
            // 
            this.TextBoxTicketAddress.BackColor = System.Drawing.Color.White;
            this.TextBoxTicketAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxTicketAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxTicketAddress.Location = new System.Drawing.Point(103, 120);
            this.TextBoxTicketAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TextBoxTicketAddress.Multiline = true;
            this.TextBoxTicketAddress.Name = "TextBoxTicketAddress";
            this.TextBoxTicketAddress.ReadOnly = true;
            this.TextBoxTicketAddress.Size = new System.Drawing.Size(234, 31);
            this.TextBoxTicketAddress.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 122);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 47;
            this.label2.Text = "Adresse";
            // 
            // RichTextBoxProblem
            // 
            this.RichTextBoxProblem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RichTextBoxProblem.BackColor = System.Drawing.Color.White;
            this.RichTextBoxProblem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBoxProblem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextBoxProblem.Location = new System.Drawing.Point(102, 164);
            this.RichTextBoxProblem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.RichTextBoxProblem.Name = "RichTextBoxProblem";
            this.RichTextBoxProblem.ReadOnly = true;
            this.RichTextBoxProblem.Size = new System.Drawing.Size(235, 111);
            this.RichTextBoxProblem.TabIndex = 40;
            this.RichTextBoxProblem.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 166);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 39;
            this.label7.Text = "Probleme";
            // 
            // ComboBoxProgression
            // 
            this.ComboBoxProgression.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ComboBoxProgression.BackColor = System.Drawing.Color.White;
            this.ComboBoxProgression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxProgression.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBoxProgression.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxProgression.FormattingEnabled = true;
            this.ComboBoxProgression.Location = new System.Drawing.Point(102, 327);
            this.ComboBoxProgression.Name = "ComboBoxProgression";
            this.ComboBoxProgression.Size = new System.Drawing.Size(235, 24);
            this.ComboBoxProgression.TabIndex = 19;
            // 
            // TextBoxWorker
            // 
            this.TextBoxWorker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TextBoxWorker.BackColor = System.Drawing.Color.White;
            this.TextBoxWorker.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxWorker.Location = new System.Drawing.Point(102, 296);
            this.TextBoxWorker.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TextBoxWorker.Name = "TextBoxWorker";
            this.TextBoxWorker.ReadOnly = true;
            this.TextBoxWorker.Size = new System.Drawing.Size(235, 15);
            this.TextBoxWorker.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 330);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Progression";
            // 
            // ButtonSave
            // 
            this.ButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSave.BackColor = System.Drawing.Color.RoyalBlue;
            this.ButtonSave.Enabled = false;
            this.ButtonSave.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.ButtonSave.FlatAppearance.BorderSize = 0;
            this.ButtonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonSave.ForeColor = System.Drawing.Color.White;
            this.ButtonSave.Location = new System.Drawing.Point(238, 377);
            this.ButtonSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(105, 30);
            this.ButtonSave.TabIndex = 14;
            this.ButtonSave.Text = "Enregistrer";
            this.ButtonSave.UseVisualStyleBackColor = false;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 297);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Employé";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(336, 9);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(209, 25);
            this.label10.TabIndex = 32;
            this.label10.Text = "Ticket Progression";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ComboBoxReferenceSearch);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.ComboBoxCategorySearch);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.ComboBoxBrandSearch);
            this.groupBox2.Controls.Add(this.ButtonReset);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.DTPTicketToSearch);
            this.groupBox2.Controls.Add(this.DTPTicketFromSearch);
            this.groupBox2.Controls.Add(this.ButtonSearch);
            this.groupBox2.Controls.Add(this.TextBoxWorkerLastNameSearch);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.TextBoxClientLastNameSearch);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(853, 109);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recherche";
            // 
            // ComboBoxReferenceSearch
            // 
            this.ComboBoxReferenceSearch.BackColor = System.Drawing.Color.White;
            this.ComboBoxReferenceSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxReferenceSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBoxReferenceSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxReferenceSearch.FormattingEnabled = true;
            this.ComboBoxReferenceSearch.Location = new System.Drawing.Point(85, 76);
            this.ComboBoxReferenceSearch.Name = "ComboBoxReferenceSearch";
            this.ComboBoxReferenceSearch.Size = new System.Drawing.Size(187, 24);
            this.ComboBoxReferenceSearch.TabIndex = 31;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(7, 77);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(71, 16);
            this.label23.TabIndex = 30;
            this.label23.Text = "Référence";
            // 
            // ComboBoxCategorySearch
            // 
            this.ComboBoxCategorySearch.BackColor = System.Drawing.Color.White;
            this.ComboBoxCategorySearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxCategorySearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBoxCategorySearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxCategorySearch.FormattingEnabled = true;
            this.ComboBoxCategorySearch.Location = new System.Drawing.Point(85, 22);
            this.ComboBoxCategorySearch.Name = "ComboBoxCategorySearch";
            this.ComboBoxCategorySearch.Size = new System.Drawing.Size(187, 24);
            this.ComboBoxCategorySearch.TabIndex = 29;
            this.ComboBoxCategorySearch.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCategorySearch_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(7, 23);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 16);
            this.label22.TabIndex = 28;
            this.label22.Text = "Catégorie";
            // 
            // ComboBoxBrandSearch
            // 
            this.ComboBoxBrandSearch.BackColor = System.Drawing.Color.White;
            this.ComboBoxBrandSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxBrandSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBoxBrandSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxBrandSearch.FormattingEnabled = true;
            this.ComboBoxBrandSearch.Location = new System.Drawing.Point(85, 49);
            this.ComboBoxBrandSearch.Name = "ComboBoxBrandSearch";
            this.ComboBoxBrandSearch.Size = new System.Drawing.Size(187, 24);
            this.ComboBoxBrandSearch.TabIndex = 27;
            this.ComboBoxBrandSearch.SelectedIndexChanged += new System.EventHandler(this.ComboBoxBrandSearch_SelectedIndexChanged);
            // 
            // ButtonReset
            // 
            this.ButtonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonReset.BackColor = System.Drawing.Color.RoyalBlue;
            this.ButtonReset.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.ButtonReset.FlatAppearance.BorderSize = 0;
            this.ButtonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonReset.ForeColor = System.Drawing.Color.White;
            this.ButtonReset.Location = new System.Drawing.Point(739, 61);
            this.ButtonReset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(107, 30);
            this.ButtonReset.TabIndex = 26;
            this.ButtonReset.Text = "Réinitialiser";
            this.ButtonReset.UseVisualStyleBackColor = false;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(286, 79);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(25, 16);
            this.label21.TabIndex = 25;
            this.label21.Text = "Du";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(415, 79);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(24, 16);
            this.label20.TabIndex = 24;
            this.label20.Text = "Au";
            // 
            // DTPTicketToSearch
            // 
            this.DTPTicketToSearch.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DTPTicketToSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPTicketToSearch.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPTicketToSearch.Location = new System.Drawing.Point(445, 76);
            this.DTPTicketToSearch.Name = "DTPTicketToSearch";
            this.DTPTicketToSearch.Size = new System.Drawing.Size(90, 22);
            this.DTPTicketToSearch.TabIndex = 23;
            // 
            // DTPTicketFromSearch
            // 
            this.DTPTicketFromSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPTicketFromSearch.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPTicketFromSearch.Location = new System.Drawing.Point(318, 76);
            this.DTPTicketFromSearch.Name = "DTPTicketFromSearch";
            this.DTPTicketFromSearch.Size = new System.Drawing.Size(90, 22);
            this.DTPTicketFromSearch.TabIndex = 22;
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSearch.BackColor = System.Drawing.Color.RoyalBlue;
            this.ButtonSearch.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.ButtonSearch.FlatAppearance.BorderSize = 0;
            this.ButtonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonSearch.ForeColor = System.Drawing.Color.White;
            this.ButtonSearch.Location = new System.Drawing.Point(739, 21);
            this.ButtonSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(107, 30);
            this.ButtonSearch.TabIndex = 21;
            this.ButtonSearch.Text = "Rechercher";
            this.ButtonSearch.UseVisualStyleBackColor = false;
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // TextBoxWorkerLastNameSearch
            // 
            this.TextBoxWorkerLastNameSearch.BackColor = System.Drawing.Color.White;
            this.TextBoxWorkerLastNameSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxWorkerLastNameSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxWorkerLastNameSearch.Location = new System.Drawing.Point(391, 52);
            this.TextBoxWorkerLastNameSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TextBoxWorkerLastNameSearch.Name = "TextBoxWorkerLastNameSearch";
            this.TextBoxWorkerLastNameSearch.Size = new System.Drawing.Size(145, 15);
            this.TextBoxWorkerLastNameSearch.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(286, 50);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 16);
            this.label12.TabIndex = 9;
            this.label12.Text = "Nom Employé ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(7, 50);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 16);
            this.label11.TabIndex = 7;
            this.label11.Text = "Marque";
            // 
            // TextBoxClientLastNameSearch
            // 
            this.TextBoxClientLastNameSearch.BackColor = System.Drawing.Color.White;
            this.TextBoxClientLastNameSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxClientLastNameSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxClientLastNameSearch.Location = new System.Drawing.Point(391, 24);
            this.TextBoxClientLastNameSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TextBoxClientLastNameSearch.Name = "TextBoxClientLastNameSearch";
            this.TextBoxClientLastNameSearch.Size = new System.Drawing.Size(145, 15);
            this.TextBoxClientLastNameSearch.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(286, 23);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 16);
            this.label9.TabIndex = 5;
            this.label9.Text = "Nom Client";
            // 
            // DGVTicket
            // 
            this.DGVTicket.AllowUserToAddRows = false;
            this.DGVTicket.AllowUserToDeleteRows = false;
            this.DGVTicket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVTicket.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5,
            this.Column3,
            this.Column10});
            this.DGVTicket.Location = new System.Drawing.Point(12, 165);
            this.DGVTicket.Name = "DGVTicket";
            this.DGVTicket.ReadOnly = true;
            this.DGVTicket.Size = new System.Drawing.Size(495, 206);
            this.DGVTicket.TabIndex = 50;
            this.DGVTicket.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVTicket_CellMouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Code";
            this.Column1.MinimumWidth = 50;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            dataGridViewCellStyle22.Format = "g";
            dataGridViewCellStyle22.NullValue = null;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle22;
            this.Column2.HeaderText = "Date";
            this.Column2.MinimumWidth = 115;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 115;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Etat";
            this.Column4.MinimumWidth = 200;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            dataGridViewCellStyle23.Format = "0:00";
            dataGridViewCellStyle23.NullValue = null;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle23;
            this.Column5.HeaderText = "Prix Réparation";
            this.Column5.MinimumWidth = 80;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 80;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Gadget";
            this.Column3.MinimumWidth = 200;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column10.HeaderText = "Description";
            this.Column10.MinimumWidth = 300;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // DGVTicketMonitoring
            // 
            this.DGVTicketMonitoring.AllowUserToAddRows = false;
            this.DGVTicketMonitoring.AllowUserToDeleteRows = false;
            this.DGVTicketMonitoring.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVTicketMonitoring.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVTicketMonitoring.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7,
            this.Column8});
            this.DGVTicketMonitoring.Location = new System.Drawing.Point(12, 396);
            this.DGVTicketMonitoring.Name = "DGVTicketMonitoring";
            this.DGVTicketMonitoring.ReadOnly = true;
            this.DGVTicketMonitoring.Size = new System.Drawing.Size(495, 182);
            this.DGVTicketMonitoring.TabIndex = 51;
            // 
            // Column6
            // 
            dataGridViewCellStyle24.Format = "g";
            dataGridViewCellStyle24.NullValue = null;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle24;
            this.Column6.HeaderText = "Date";
            this.Column6.MinimumWidth = 115;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 115;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Qui";
            this.Column7.MinimumWidth = 70;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 70;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.HeaderText = "Déscription";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // TextBoxTotalTickets
            // 
            this.TextBoxTotalTickets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxTotalTickets.BackColor = System.Drawing.Color.White;
            this.TextBoxTotalTickets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxTotalTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxTotalTickets.Location = new System.Drawing.Point(463, 377);
            this.TextBoxTotalTickets.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TextBoxTotalTickets.Name = "TextBoxTotalTickets";
            this.TextBoxTotalTickets.ReadOnly = true;
            this.TextBoxTotalTickets.Size = new System.Drawing.Size(45, 15);
            this.TextBoxTotalTickets.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(356, 377);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 52;
            this.label1.Text = "Total Tickets";
            // 
            // GroupBoxClient
            // 
            this.GroupBoxClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxClient.Controls.Add(this.label5);
            this.GroupBoxClient.Controls.Add(this.TextBoxClientEmail);
            this.GroupBoxClient.Controls.Add(this.label13);
            this.GroupBoxClient.Controls.Add(this.TextBoxClientPhoneNumber);
            this.GroupBoxClient.Location = new System.Drawing.Point(7, 19);
            this.GroupBoxClient.Name = "GroupBoxClient";
            this.GroupBoxClient.Size = new System.Drawing.Size(337, 83);
            this.GroupBoxClient.TabIndex = 50;
            this.GroupBoxClient.TabStop = false;
            this.GroupBoxClient.Text = "Client";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Email";
            // 
            // TextBoxClientEmail
            // 
            this.TextBoxClientEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxClientEmail.BackColor = System.Drawing.Color.White;
            this.TextBoxClientEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxClientEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxClientEmail.Location = new System.Drawing.Point(95, 28);
            this.TextBoxClientEmail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TextBoxClientEmail.Name = "TextBoxClientEmail";
            this.TextBoxClientEmail.ReadOnly = true;
            this.TextBoxClientEmail.Size = new System.Drawing.Size(235, 15);
            this.TextBoxClientEmail.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(7, 57);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 16);
            this.label13.TabIndex = 24;
            this.label13.Text = "Telephone";
            // 
            // TextBoxClientPhoneNumber
            // 
            this.TextBoxClientPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxClientPhoneNumber.BackColor = System.Drawing.Color.White;
            this.TextBoxClientPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxClientPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxClientPhoneNumber.Location = new System.Drawing.Point(95, 57);
            this.TextBoxClientPhoneNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TextBoxClientPhoneNumber.Name = "TextBoxClientPhoneNumber";
            this.TextBoxClientPhoneNumber.ReadOnly = true;
            this.TextBoxClientPhoneNumber.Size = new System.Drawing.Size(235, 15);
            this.TextBoxClientPhoneNumber.TabIndex = 25;
            // 
            // StaffTicketProgression
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 590);
            this.Controls.Add(this.TextBoxTotalTickets);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGVTicketMonitoring);
            this.Controls.Add(this.DGVTicket);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StaffTicketProgression";
            this.Text = "StaffTicketProgression";
            this.Load += new System.EventHandler(this.StaffTicketProgression_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTicket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTicketMonitoring)).EndInit();
            this.GroupBoxClient.ResumeLayout(false);
            this.GroupBoxClient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ComboBoxProgression;
        private System.Windows.Forms.TextBox TextBoxWorker;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TextBoxTicketAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox RichTextBoxProblem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox ComboBoxReferenceSearch;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox ComboBoxCategorySearch;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox ComboBoxBrandSearch;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker DTPTicketToSearch;
        private System.Windows.Forms.DateTimePicker DTPTicketFromSearch;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.TextBox TextBoxWorkerLastNameSearch;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TextBoxClientLastNameSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView DGVTicket;
        private System.Windows.Forms.DataGridView DGVTicketMonitoring;
        private System.Windows.Forms.TextBox TextBoxTotalTickets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.GroupBox GroupBoxClient;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TextBoxClientEmail;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TextBoxClientPhoneNumber;
    }
}