
namespace GADJIT_WIN_ASW
{
    partial class TicketConsultationWorker
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.GroupeBoxDiag = new System.Windows.Forms.GroupBox();
            this.textBoxWorkTime = new System.Windows.Forms.TextBox();
            this.richTextBoxDiag = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxPrice = new System.Windows.Forms.TextBox();
            this.TextBoxGadget = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.ComboBoxPorg = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ButtonEnregistrer = new System.Windows.Forms.Button();
            this.RichTextBoxProblem = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ComboBoxReferenceSearch = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.ComboBoxCategorySearch = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.ComboBoxBrandSearch = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.DTPTicketToSearch = new System.Windows.Forms.DateTimePicker();
            this.DTPTicketFromSearch = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ButtonRecherche = new System.Windows.Forms.Button();
            this.TextBoxTicketsNoRepare = new System.Windows.Forms.TextBox();
            this.TextBoxTotalTickets = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxTicketRepare = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DGVTicket = new System.Windows.Forms.DataGridView();
            this.CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GADGET = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.GroupeBoxDiag.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTicket)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.GroupeBoxDiag);
            this.groupBox1.Controls.Add(this.TextBoxGadget);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.ComboBoxPorg);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.ButtonEnregistrer);
            this.groupBox1.Controls.Add(this.RichTextBoxProblem);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Teal;
            this.groupBox1.Location = new System.Drawing.Point(424, 212);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(317, 540);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ticket détail";
            // 
            // ButtonReset
            // 
            this.ButtonReset.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ButtonReset.BackColor = System.Drawing.Color.Teal;
            this.ButtonReset.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.ButtonReset.FlatAppearance.BorderSize = 0;
            this.ButtonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonReset.ForeColor = System.Drawing.Color.White;
            this.ButtonReset.Location = new System.Drawing.Point(614, 92);
            this.ButtonReset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(117, 30);
            this.ButtonReset.TabIndex = 53;
            this.ButtonReset.Text = "Reinitialiser";
            this.ButtonReset.UseVisualStyleBackColor = false;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // GroupeBoxDiag
            // 
            this.GroupeBoxDiag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupeBoxDiag.Controls.Add(this.textBoxWorkTime);
            this.GroupeBoxDiag.Controls.Add(this.richTextBoxDiag);
            this.GroupeBoxDiag.Controls.Add(this.label14);
            this.GroupeBoxDiag.Controls.Add(this.label6);
            this.GroupeBoxDiag.Controls.Add(this.label4);
            this.GroupeBoxDiag.Controls.Add(this.TextBoxPrice);
            this.GroupeBoxDiag.Location = new System.Drawing.Point(5, 169);
            this.GroupeBoxDiag.Name = "GroupeBoxDiag";
            this.GroupeBoxDiag.Size = new System.Drawing.Size(303, 237);
            this.GroupeBoxDiag.TabIndex = 34;
            this.GroupeBoxDiag.TabStop = false;
            // 
            // textBoxWorkTime
            // 
            this.textBoxWorkTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWorkTime.BackColor = System.Drawing.Color.White;
            this.textBoxWorkTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxWorkTime.Location = new System.Drawing.Point(1, 209);
            this.textBoxWorkTime.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxWorkTime.Name = "textBoxWorkTime";
            this.textBoxWorkTime.Size = new System.Drawing.Size(287, 22);
            this.textBoxWorkTime.TabIndex = 51;
            // 
            // richTextBoxDiag
            // 
            this.richTextBoxDiag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxDiag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxDiag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxDiag.Location = new System.Drawing.Point(4, 35);
            this.richTextBoxDiag.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.richTextBoxDiag.Name = "richTextBoxDiag";
            this.richTextBoxDiag.Size = new System.Drawing.Size(284, 106);
            this.richTextBoxDiag.TabIndex = 47;
            this.richTextBoxDiag.Text = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(6, 15);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 17);
            this.label14.TabIndex = 46;
            this.label14.Text = "Diagnostic";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(1, 189);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 17);
            this.label6.TabIndex = 50;
            this.label6.Text = "Reparation Temp en Heure";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(6, 144);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 17);
            this.label4.TabIndex = 48;
            this.label4.Text = "Reparation Prix";
            // 
            // TextBoxPrice
            // 
            this.TextBoxPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxPrice.BackColor = System.Drawing.Color.White;
            this.TextBoxPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxPrice.Location = new System.Drawing.Point(1, 164);
            this.TextBoxPrice.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TextBoxPrice.Name = "TextBoxPrice";
            this.TextBoxPrice.Size = new System.Drawing.Size(286, 22);
            this.TextBoxPrice.TabIndex = 49;
            // 
            // TextBoxGadget
            // 
            this.TextBoxGadget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxGadget.BackColor = System.Drawing.Color.White;
            this.TextBoxGadget.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxGadget.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxGadget.Location = new System.Drawing.Point(8, 148);
            this.TextBoxGadget.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TextBoxGadget.Name = "TextBoxGadget";
            this.TextBoxGadget.ReadOnly = true;
            this.TextBoxGadget.Size = new System.Drawing.Size(285, 15);
            this.TextBoxGadget.TabIndex = 33;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(5, 128);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(122, 17);
            this.label17.TabIndex = 32;
            this.label17.Text = "Gadget Information";
            // 
            // ComboBoxPorg
            // 
            this.ComboBoxPorg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxPorg.BackColor = System.Drawing.Color.White;
            this.ComboBoxPorg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxPorg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBoxPorg.FormattingEnabled = true;
            this.ComboBoxPorg.Location = new System.Drawing.Point(5, 427);
            this.ComboBoxPorg.Name = "ComboBoxPorg";
            this.ComboBoxPorg.Size = new System.Drawing.Size(288, 29);
            this.ComboBoxPorg.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(3, 407);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Progression";
            // 
            // ButtonEnregistrer
            // 
            this.ButtonEnregistrer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonEnregistrer.BackColor = System.Drawing.Color.Teal;
            this.ButtonEnregistrer.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.ButtonEnregistrer.FlatAppearance.BorderSize = 0;
            this.ButtonEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonEnregistrer.ForeColor = System.Drawing.Color.White;
            this.ButtonEnregistrer.Location = new System.Drawing.Point(172, 490);
            this.ButtonEnregistrer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ButtonEnregistrer.Name = "ButtonEnregistrer";
            this.ButtonEnregistrer.Size = new System.Drawing.Size(120, 30);
            this.ButtonEnregistrer.TabIndex = 14;
            this.ButtonEnregistrer.Text = "Enregistrer";
            this.ButtonEnregistrer.UseVisualStyleBackColor = false;
            this.ButtonEnregistrer.Click += new System.EventHandler(this.ButtonEnregistrer_Click);
            // 
            // RichTextBoxProblem
            // 
            this.RichTextBoxProblem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RichTextBoxProblem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBoxProblem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextBoxProblem.Location = new System.Drawing.Point(7, 45);
            this.RichTextBoxProblem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.RichTextBoxProblem.Name = "RichTextBoxProblem";
            this.RichTextBoxProblem.Size = new System.Drawing.Size(285, 74);
            this.RichTextBoxProblem.TabIndex = 9;
            this.RichTextBoxProblem.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(13, 25);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Probleme";
            // 
            // ComboBoxReferenceSearch
            // 
            this.ComboBoxReferenceSearch.BackColor = System.Drawing.Color.White;
            this.ComboBoxReferenceSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxReferenceSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBoxReferenceSearch.FormattingEnabled = true;
            this.ComboBoxReferenceSearch.Location = new System.Drawing.Point(420, 42);
            this.ComboBoxReferenceSearch.Name = "ComboBoxReferenceSearch";
            this.ComboBoxReferenceSearch.Size = new System.Drawing.Size(187, 29);
            this.ComboBoxReferenceSearch.TabIndex = 50;
            this.ComboBoxReferenceSearch.SelectedIndexChanged += new System.EventHandler(this.ComboBoxReferenceSearch_SelectedIndexChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(418, 23);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(71, 16);
            this.label23.TabIndex = 49;
            this.label23.Text = "Référence";
            // 
            // ComboBoxCategorySearch
            // 
            this.ComboBoxCategorySearch.BackColor = System.Drawing.Color.White;
            this.ComboBoxCategorySearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxCategorySearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBoxCategorySearch.FormattingEnabled = true;
            this.ComboBoxCategorySearch.Location = new System.Drawing.Point(13, 42);
            this.ComboBoxCategorySearch.Name = "ComboBoxCategorySearch";
            this.ComboBoxCategorySearch.Size = new System.Drawing.Size(187, 29);
            this.ComboBoxCategorySearch.TabIndex = 48;
            this.ComboBoxCategorySearch.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCategorySearch_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(10, 23);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 16);
            this.label22.TabIndex = 47;
            this.label22.Text = "Catégorie";
            // 
            // ComboBoxBrandSearch
            // 
            this.ComboBoxBrandSearch.BackColor = System.Drawing.Color.White;
            this.ComboBoxBrandSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxBrandSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBoxBrandSearch.FormattingEnabled = true;
            this.ComboBoxBrandSearch.Location = new System.Drawing.Point(215, 42);
            this.ComboBoxBrandSearch.Name = "ComboBoxBrandSearch";
            this.ComboBoxBrandSearch.Size = new System.Drawing.Size(187, 29);
            this.ComboBoxBrandSearch.TabIndex = 46;
            this.ComboBoxBrandSearch.SelectedIndexChanged += new System.EventHandler(this.ComboBoxBrandSearch_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(10, 74);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(25, 16);
            this.label21.TabIndex = 45;
            this.label21.Text = "Du";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(221, 74);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(24, 16);
            this.label20.TabIndex = 44;
            this.label20.Text = "Au";
            // 
            // DTPTicketToSearch
            // 
            this.DTPTicketToSearch.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DTPTicketToSearch.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPTicketToSearch.Location = new System.Drawing.Point(215, 93);
            this.DTPTicketToSearch.Name = "DTPTicketToSearch";
            this.DTPTicketToSearch.Size = new System.Drawing.Size(187, 29);
            this.DTPTicketToSearch.TabIndex = 43;
            // 
            // DTPTicketFromSearch
            // 
            this.DTPTicketFromSearch.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPTicketFromSearch.Location = new System.Drawing.Point(12, 93);
            this.DTPTicketFromSearch.Name = "DTPTicketFromSearch";
            this.DTPTicketFromSearch.Size = new System.Drawing.Size(187, 29);
            this.DTPTicketFromSearch.TabIndex = 42;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Nirmala UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Teal;
            this.label10.Location = new System.Drawing.Point(253, 9);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(266, 37);
            this.label10.TabIndex = 73;
            this.label10.Text = "Tickets Consulation";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(221, 23);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 16);
            this.label11.TabIndex = 39;
            this.label11.Text = "Marque";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ButtonReset);
            this.groupBox2.Controls.Add(this.ComboBoxReferenceSearch);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.ComboBoxCategorySearch);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.ComboBoxBrandSearch);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.DTPTicketToSearch);
            this.groupBox2.Controls.Add(this.DTPTicketFromSearch);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.ButtonRecherche);
            this.groupBox2.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Teal;
            this.groupBox2.Location = new System.Drawing.Point(3, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(738, 133);
            this.groupBox2.TabIndex = 76;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recherche :";
            // 
            // ButtonRecherche
            // 
            this.ButtonRecherche.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ButtonRecherche.BackColor = System.Drawing.Color.Teal;
            this.ButtonRecherche.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.ButtonRecherche.FlatAppearance.BorderSize = 0;
            this.ButtonRecherche.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonRecherche.ForeColor = System.Drawing.Color.White;
            this.ButtonRecherche.Location = new System.Drawing.Point(614, 42);
            this.ButtonRecherche.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ButtonRecherche.Name = "ButtonRecherche";
            this.ButtonRecherche.Size = new System.Drawing.Size(117, 29);
            this.ButtonRecherche.TabIndex = 36;
            this.ButtonRecherche.Text = "Recherche";
            this.ButtonRecherche.UseVisualStyleBackColor = false;
            this.ButtonRecherche.Click += new System.EventHandler(this.ButtonRecherche_Click);
            // 
            // TextBoxTicketsNoRepare
            // 
            this.TextBoxTicketsNoRepare.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxTicketsNoRepare.BackColor = System.Drawing.Color.Red;
            this.TextBoxTicketsNoRepare.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxTicketsNoRepare.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxTicketsNoRepare.Location = new System.Drawing.Point(174, 107);
            this.TextBoxTicketsNoRepare.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TextBoxTicketsNoRepare.Multiline = true;
            this.TextBoxTicketsNoRepare.Name = "TextBoxTicketsNoRepare";
            this.TextBoxTicketsNoRepare.Size = new System.Drawing.Size(116, 23);
            this.TextBoxTicketsNoRepare.TabIndex = 48;
            // 
            // TextBoxTotalTickets
            // 
            this.TextBoxTotalTickets.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxTotalTickets.BackColor = System.Drawing.Color.White;
            this.TextBoxTotalTickets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxTotalTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxTotalTickets.Location = new System.Drawing.Point(174, 20);
            this.TextBoxTotalTickets.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TextBoxTotalTickets.Multiline = true;
            this.TextBoxTotalTickets.Name = "TextBoxTotalTickets";
            this.TextBoxTotalTickets.Size = new System.Drawing.Size(116, 23);
            this.TextBoxTotalTickets.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 16);
            this.label3.TabIndex = 47;
            this.label3.Text = "Tickets Non Reparé";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 45;
            this.label2.Text = "Tickets Reparé";
            // 
            // TextBoxTicketRepare
            // 
            this.TextBoxTicketRepare.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxTicketRepare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.TextBoxTicketRepare.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxTicketRepare.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxTicketRepare.Location = new System.Drawing.Point(174, 68);
            this.TextBoxTicketRepare.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TextBoxTicketRepare.Multiline = true;
            this.TextBoxTicketRepare.Name = "TextBoxTicketRepare";
            this.TextBoxTicketRepare.Size = new System.Drawing.Size(116, 23);
            this.TextBoxTicketRepare.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 43;
            this.label1.Text = "Total Tickets";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.TextBoxTicketsNoRepare);
            this.groupBox3.Controls.Add(this.TextBoxTotalTickets);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.TextBoxTicketRepare);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(12, 615);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(316, 137);
            this.groupBox3.TabIndex = 77;
            this.groupBox3.TabStop = false;
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
            this.CODE,
            this.DATE,
            this.GADGET,
            this.STATUT});
            this.DGVTicket.Location = new System.Drawing.Point(3, 212);
            this.DGVTicket.Name = "DGVTicket";
            this.DGVTicket.ReadOnly = true;
            this.DGVTicket.Size = new System.Drawing.Size(419, 397);
            this.DGVTicket.TabIndex = 78;
            this.DGVTicket.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVTicket_CellMouseDoubleClick);
            // 
            // CODE
            // 
            this.CODE.HeaderText = "Code";
            this.CODE.MinimumWidth = 50;
            this.CODE.Name = "CODE";
            this.CODE.ReadOnly = true;
            this.CODE.Width = 50;
            // 
            // DATE
            // 
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.DATE.DefaultCellStyle = dataGridViewCellStyle3;
            this.DATE.HeaderText = "Date";
            this.DATE.MinimumWidth = 115;
            this.DATE.Name = "DATE";
            this.DATE.ReadOnly = true;
            this.DATE.Width = 115;
            // 
            // GADGET
            // 
            this.GADGET.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GADGET.HeaderText = "Gadget";
            this.GADGET.MinimumWidth = 100;
            this.GADGET.Name = "GADGET";
            this.GADGET.ReadOnly = true;
            // 
            // STATUT
            // 
            this.STATUT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.STATUT.HeaderText = "Etat";
            this.STATUT.MinimumWidth = 100;
            this.STATUT.Name = "STATUT";
            this.STATUT.ReadOnly = true;
            // 
            // TicketConsultationWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 758);
            this.Controls.Add(this.DGVTicket);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TicketConsultationWorker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConsultationTicketWorker";
            this.Load += new System.EventHandler(this.TicketConsultationWorker_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GroupeBoxDiag.ResumeLayout(false);
            this.GroupeBoxDiag.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTicket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox GroupeBoxDiag;
        private System.Windows.Forms.TextBox TextBoxGadget;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox ComboBoxPorg;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button ButtonEnregistrer;
        private System.Windows.Forms.RichTextBox RichTextBoxProblem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.ComboBox ComboBoxReferenceSearch;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox ComboBoxCategorySearch;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox ComboBoxBrandSearch;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker DTPTicketToSearch;
        private System.Windows.Forms.DateTimePicker DTPTicketFromSearch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ButtonRecherche;
        private System.Windows.Forms.TextBox TextBoxTicketsNoRepare;
        private System.Windows.Forms.TextBox TextBoxTotalTickets;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxTicketRepare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView DGVTicket;
        private System.Windows.Forms.TextBox textBoxWorkTime;
        private System.Windows.Forms.RichTextBox richTextBoxDiag;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBoxPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn GADGET;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUT;
    }
}