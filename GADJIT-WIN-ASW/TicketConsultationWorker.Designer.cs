
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ButtonRecherche = new System.Windows.Forms.Button();
            this.TextBoxGadget = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TextBoxTicketsNoRepare = new System.Windows.Forms.TextBox();
            this.TextBoxTotalTickets = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxTicketRepare = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.ComboBoxCode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ComboBoxReferenceSearch = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.ComboBoxCategorySearch = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.ComboBoxBrandSearch = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.DTPTicketToSearch = new System.Windows.Forms.DateTimePicker();
            this.DTPTicketFromSearch = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.DGVTicket = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.ComboBoxPorg = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ButtonEnregistrer = new System.Windows.Forms.Button();
            this.RichTextBoxProblem = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Refrence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupeBoxDiag = new System.Windows.Forms.GroupBox();
            this.textBoxWorkTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TextBoxPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBoxDiag = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTicket)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.GroupeBoxDiag.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonRecherche
            // 
            this.ButtonRecherche.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonRecherche.BackColor = System.Drawing.Color.Teal;
            this.ButtonRecherche.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.ButtonRecherche.FlatAppearance.BorderSize = 0;
            this.ButtonRecherche.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonRecherche.ForeColor = System.Drawing.Color.White;
            this.ButtonRecherche.Location = new System.Drawing.Point(945, 28);
            this.ButtonRecherche.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ButtonRecherche.Name = "ButtonRecherche";
            this.ButtonRecherche.Size = new System.Drawing.Size(105, 29);
            this.ButtonRecherche.TabIndex = 36;
            this.ButtonRecherche.Text = "Rechercher";
            this.ButtonRecherche.UseVisualStyleBackColor = false;
            this.ButtonRecherche.Click += new System.EventHandler(this.ButtonRecherche_Click);
            // 
            // TextBoxGadget
            // 
            this.TextBoxGadget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxGadget.BackColor = System.Drawing.Color.White;
            this.TextBoxGadget.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxGadget.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxGadget.Location = new System.Drawing.Point(183, 167);
            this.TextBoxGadget.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TextBoxGadget.Multiline = true;
            this.TextBoxGadget.Name = "TextBoxGadget";
            this.TextBoxGadget.ReadOnly = true;
            this.TextBoxGadget.Size = new System.Drawing.Size(295, 24);
            this.TextBoxGadget.TabIndex = 33;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox3.Controls.Add(this.TextBoxTicketsNoRepare);
            this.groupBox3.Controls.Add(this.TextBoxTotalTickets);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.TextBoxTicketRepare);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(24, 393);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(316, 145);
            this.groupBox3.TabIndex = 72;
            this.groupBox3.TabStop = false;
            // 
            // TextBoxTicketsNoRepare
            // 
            this.TextBoxTicketsNoRepare.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxTicketsNoRepare.BackColor = System.Drawing.Color.Red;
            this.TextBoxTicketsNoRepare.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxTicketsNoRepare.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxTicketsNoRepare.Location = new System.Drawing.Point(174, 111);
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
            this.TextBoxTotalTickets.Location = new System.Drawing.Point(174, 24);
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
            this.label3.Location = new System.Drawing.Point(11, 118);
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
            this.label2.Location = new System.Drawing.Point(43, 79);
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
            this.TextBoxTicketRepare.Location = new System.Drawing.Point(174, 72);
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
            this.label1.Location = new System.Drawing.Point(53, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 43;
            this.label1.Text = "Total Tickets";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.ButtonReset);
            this.groupBox2.Controls.Add(this.ComboBoxCode);
            this.groupBox2.Controls.Add(this.label5);
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
            this.groupBox2.Location = new System.Drawing.Point(24, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1069, 100);
            this.groupBox2.TabIndex = 71;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recherche :";
            // 
            // ButtonReset
            // 
            this.ButtonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonReset.BackColor = System.Drawing.Color.Teal;
            this.ButtonReset.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.ButtonReset.FlatAppearance.BorderSize = 0;
            this.ButtonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonReset.ForeColor = System.Drawing.Color.White;
            this.ButtonReset.Location = new System.Drawing.Point(945, 65);
            this.ButtonReset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(105, 29);
            this.ButtonReset.TabIndex = 53;
            this.ButtonReset.Text = "Annuler";
            this.ButtonReset.UseVisualStyleBackColor = false;
            // 
            // ComboBoxCode
            // 
            this.ComboBoxCode.BackColor = System.Drawing.Color.White;
            this.ComboBoxCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBoxCode.FormattingEnabled = true;
            this.ComboBoxCode.Location = new System.Drawing.Point(614, 64);
            this.ComboBoxCode.Name = "ComboBoxCode";
            this.ComboBoxCode.Size = new System.Drawing.Size(187, 29);
            this.ComboBoxCode.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(536, 71);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 51;
            this.label5.Text = "CODE";
            // 
            // ComboBoxReferenceSearch
            // 
            this.ComboBoxReferenceSearch.BackColor = System.Drawing.Color.White;
            this.ComboBoxReferenceSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxReferenceSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBoxReferenceSearch.FormattingEnabled = true;
            this.ComboBoxReferenceSearch.Location = new System.Drawing.Point(614, 28);
            this.ComboBoxReferenceSearch.Name = "ComboBoxReferenceSearch";
            this.ComboBoxReferenceSearch.Size = new System.Drawing.Size(187, 29);
            this.ComboBoxReferenceSearch.TabIndex = 50;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(536, 35);
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
            this.ComboBoxCategorySearch.Location = new System.Drawing.Point(87, 28);
            this.ComboBoxCategorySearch.Name = "ComboBoxCategorySearch";
            this.ComboBoxCategorySearch.Size = new System.Drawing.Size(187, 29);
            this.ComboBoxCategorySearch.TabIndex = 48;
            this.ComboBoxCategorySearch.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCategorySearch_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(9, 29);
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
            this.ComboBoxBrandSearch.Location = new System.Drawing.Point(342, 28);
            this.ComboBoxBrandSearch.Name = "ComboBoxBrandSearch";
            this.ComboBoxBrandSearch.Size = new System.Drawing.Size(187, 29);
            this.ComboBoxBrandSearch.TabIndex = 46;
            this.ComboBoxBrandSearch.SelectedIndexChanged += new System.EventHandler(this.ComboBoxBrandSearch_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(51, 64);
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
            this.label20.Location = new System.Drawing.Point(311, 72);
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
            this.DTPTicketToSearch.Location = new System.Drawing.Point(342, 62);
            this.DTPTicketToSearch.Name = "DTPTicketToSearch";
            this.DTPTicketToSearch.Size = new System.Drawing.Size(187, 29);
            this.DTPTicketToSearch.TabIndex = 43;
            // 
            // DTPTicketFromSearch
            // 
            this.DTPTicketFromSearch.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPTicketFromSearch.Location = new System.Drawing.Point(87, 62);
            this.DTPTicketFromSearch.Name = "DTPTicketFromSearch";
            this.DTPTicketFromSearch.Size = new System.Drawing.Size(187, 29);
            this.DTPTicketFromSearch.TabIndex = 42;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(281, 35);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 16);
            this.label11.TabIndex = 39;
            this.label11.Text = "Marque";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Nirmala UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Teal;
            this.label10.Location = new System.Drawing.Point(406, 9);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(266, 37);
            this.label10.TabIndex = 68;
            this.label10.Text = "Tickets Consulation";
            // 
            // DGVTicket
            // 
            this.DGVTicket.AllowUserToAddRows = false;
            this.DGVTicket.AllowUserToDeleteRows = false;
            this.DGVTicket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.DGVTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVTicket.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CODE,
            this.DATE,
            this.Refrence,
            this.Sta});
            this.DGVTicket.Location = new System.Drawing.Point(24, 170);
            this.DGVTicket.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DGVTicket.Name = "DGVTicket";
            this.DGVTicket.ReadOnly = true;
            this.DGVTicket.Size = new System.Drawing.Size(439, 217);
            this.DGVTicket.TabIndex = 69;
            this.DGVTicket.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVTicket_CellClick);
            this.DGVTicket.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVTicket_CellContentClick);
            this.DGVTicket.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVTicket_CellContentDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
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
            this.groupBox1.Location = new System.Drawing.Point(471, 170);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(622, 468);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ticket détail";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(44, 174);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(122, 17);
            this.label17.TabIndex = 32;
            this.label17.Text = "Gadget Information";
            // 
            // ComboBoxPorg
            // 
            this.ComboBoxPorg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxPorg.BackColor = System.Drawing.Color.White;
            this.ComboBoxPorg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBoxPorg.FormattingEnabled = true;
            this.ComboBoxPorg.Location = new System.Drawing.Point(183, 421);
            this.ComboBoxPorg.Name = "ComboBoxPorg";
            this.ComboBoxPorg.Size = new System.Drawing.Size(295, 29);
            this.ComboBoxPorg.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(88, 433);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Progression";
            // 
            // ButtonEnregistrer
            // 
            this.ButtonEnregistrer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonEnregistrer.BackColor = System.Drawing.Color.Teal;
            this.ButtonEnregistrer.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.ButtonEnregistrer.FlatAppearance.BorderSize = 0;
            this.ButtonEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonEnregistrer.ForeColor = System.Drawing.Color.White;
            this.ButtonEnregistrer.Location = new System.Drawing.Point(491, 419);
            this.ButtonEnregistrer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ButtonEnregistrer.Name = "ButtonEnregistrer";
            this.ButtonEnregistrer.Size = new System.Drawing.Size(112, 30);
            this.ButtonEnregistrer.TabIndex = 14;
            this.ButtonEnregistrer.Text = "Enregistrer";
            this.ButtonEnregistrer.UseVisualStyleBackColor = false;
            this.ButtonEnregistrer.Click += new System.EventHandler(this.ButtonEnregistrer_Click);
            // 
            // RichTextBoxProblem
            // 
            this.RichTextBoxProblem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBoxProblem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextBoxProblem.Location = new System.Drawing.Point(183, 28);
            this.RichTextBoxProblem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.RichTextBoxProblem.Name = "RichTextBoxProblem";
            this.RichTextBoxProblem.Size = new System.Drawing.Size(420, 133);
            this.RichTextBoxProblem.TabIndex = 9;
            this.RichTextBoxProblem.Text = "";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(102, 31);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Probleme";
            // 
            // CODE
            // 
            this.CODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CODE.HeaderText = "CODE";
            this.CODE.Name = "CODE";
            this.CODE.ReadOnly = true;
            // 
            // DATE
            // 
            this.DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.DATE.DefaultCellStyle = dataGridViewCellStyle1;
            this.DATE.HeaderText = "DATE";
            this.DATE.Name = "DATE";
            this.DATE.ReadOnly = true;
            // 
            // Refrence
            // 
            this.Refrence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Refrence.HeaderText = "GADGET";
            this.Refrence.Name = "Refrence";
            this.Refrence.ReadOnly = true;
            // 
            // Sta
            // 
            this.Sta.HeaderText = "STATUT";
            this.Sta.Name = "Sta";
            this.Sta.ReadOnly = true;
            // 
            // GroupeBoxDiag
            // 
            this.GroupeBoxDiag.Controls.Add(this.textBoxWorkTime);
            this.GroupeBoxDiag.Controls.Add(this.label6);
            this.GroupeBoxDiag.Controls.Add(this.TextBoxPrice);
            this.GroupeBoxDiag.Controls.Add(this.label4);
            this.GroupeBoxDiag.Controls.Add(this.richTextBoxDiag);
            this.GroupeBoxDiag.Controls.Add(this.label14);
            this.GroupeBoxDiag.Location = new System.Drawing.Point(7, 197);
            this.GroupeBoxDiag.Name = "GroupeBoxDiag";
            this.GroupeBoxDiag.Size = new System.Drawing.Size(608, 203);
            this.GroupeBoxDiag.TabIndex = 34;
            this.GroupeBoxDiag.TabStop = false;
            // 
            // textBoxWorkTime
            // 
            this.textBoxWorkTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWorkTime.BackColor = System.Drawing.Color.White;
            this.textBoxWorkTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxWorkTime.Location = new System.Drawing.Point(176, 157);
            this.textBoxWorkTime.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxWorkTime.Multiline = true;
            this.textBoxWorkTime.Name = "textBoxWorkTime";
            this.textBoxWorkTime.Size = new System.Drawing.Size(295, 24);
            this.textBoxWorkTime.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(10, 164);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 17);
            this.label6.TabIndex = 44;
            this.label6.Text = "Reparation Temp en Heur";
            // 
            // TextBoxPrice
            // 
            this.TextBoxPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxPrice.BackColor = System.Drawing.Color.White;
            this.TextBoxPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxPrice.Location = new System.Drawing.Point(176, 127);
            this.TextBoxPrice.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TextBoxPrice.Multiline = true;
            this.TextBoxPrice.Name = "TextBoxPrice";
            this.TextBoxPrice.Size = new System.Drawing.Size(295, 24);
            this.TextBoxPrice.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(62, 129);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 17);
            this.label4.TabIndex = 42;
            this.label4.Text = "Reparation Prix";
            // 
            // richTextBoxDiag
            // 
            this.richTextBoxDiag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxDiag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxDiag.Location = new System.Drawing.Point(176, 15);
            this.richTextBoxDiag.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.richTextBoxDiag.Name = "richTextBoxDiag";
            this.richTextBoxDiag.Size = new System.Drawing.Size(420, 106);
            this.richTextBoxDiag.TabIndex = 41;
            this.richTextBoxDiag.Text = "";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(90, 17);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 17);
            this.label14.TabIndex = 40;
            this.label14.Text = "Diagnostic";
            // 
            // TicketConsultationWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1117, 652);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.DGVTicket);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TicketConsultationWorker";
            this.Text = "TicketConsultationWorker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TicketConsultationWorker_FormClosing);
            this.Load += new System.EventHandler(this.TicketConsultationWorker_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTicket)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GroupeBoxDiag.ResumeLayout(false);
            this.GroupeBoxDiag.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ButtonRecherche;
        private System.Windows.Forms.TextBox TextBoxGadget;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TextBoxTicketsNoRepare;
        private System.Windows.Forms.TextBox TextBoxTotalTickets;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxTicketRepare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView DGVTicket;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox ComboBoxPorg;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button ButtonEnregistrer;
        private System.Windows.Forms.RichTextBox RichTextBoxProblem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ComboBoxCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ComboBoxReferenceSearch;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox ComboBoxCategorySearch;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox ComboBoxBrandSearch;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker DTPTicketToSearch;
        private System.Windows.Forms.DateTimePicker DTPTicketFromSearch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Refrence;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sta;
        private System.Windows.Forms.GroupBox GroupeBoxDiag;
        private System.Windows.Forms.TextBox textBoxWorkTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TextBoxPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBoxDiag;
        private System.Windows.Forms.Label label14;
    }
}