
namespace GADJIT_WIN_ASW
{
    partial class TicketManagment
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TextBoxWhoName = new System.Windows.Forms.TextBox();
            this.RichTextBoxDiscription = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.TextBoxWhoID = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.TextBoxStaffLastName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxStaffID = new System.Windows.Forms.TextBox();
            this.TextBoxTotalTicketMonitoring = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.DTPTicketFromSearch = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.ComboBoxStatusSearch = new System.Windows.Forms.ComboBox();
            this.TextBoxWorkerLastName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TextBoxWorkerID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.RichTextBoxProblem = new System.Windows.Forms.RichTextBox();
            this.DTPTicketToSearch = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TextBoxClientID = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.TextBoxRepairePriceToSearch = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.TextBoxRepairePriceFromSearch = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.TextBoxClientName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DGVTicket = new System.Windows.Forms.DataGridView();
            this.ColumnTicketID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTicketDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTicketStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGadgetReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRepairePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TextBoxTotalTickets = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GroupBoxTicketDeails = new System.Windows.Forms.GroupBox();
            this.DGVTicketMonitoring = new System.Windows.Forms.DataGridView();
            this.ColumnTicketMonitoringID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTicketMonitoringDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTicketMonitoringWho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTicketMonitoringStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTicket)).BeginInit();
            this.GroupBoxTicketDeails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTicketMonitoring)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox1.Controls.Add(this.TextBoxWhoName);
            this.groupBox1.Controls.Add(this.RichTextBoxDiscription);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.TextBoxWhoID);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(489, 345);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 277);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Détails d\'historique";
            // 
            // TextBoxWhoName
            // 
            this.TextBoxWhoName.BackColor = System.Drawing.Color.White;
            this.TextBoxWhoName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxWhoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxWhoName.Location = new System.Drawing.Point(147, 52);
            this.TextBoxWhoName.Name = "TextBoxWhoName";
            this.TextBoxWhoName.ReadOnly = true;
            this.TextBoxWhoName.Size = new System.Drawing.Size(121, 15);
            this.TextBoxWhoName.TabIndex = 17;
            // 
            // RichTextBoxDiscription
            // 
            this.RichTextBoxDiscription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RichTextBoxDiscription.BackColor = System.Drawing.Color.White;
            this.RichTextBoxDiscription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBoxDiscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextBoxDiscription.Location = new System.Drawing.Point(147, 80);
            this.RichTextBoxDiscription.Name = "RichTextBoxDiscription";
            this.RichTextBoxDiscription.ReadOnly = true;
            this.RichTextBoxDiscription.Size = new System.Drawing.Size(246, 179);
            this.RichTextBoxDiscription.TabIndex = 15;
            this.RichTextBoxDiscription.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(135, 16);
            this.label13.TabIndex = 16;
            this.label13.Text = "Par qui Nom Complet";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 16);
            this.label12.TabIndex = 14;
            this.label12.Text = "Description";
            // 
            // TextBoxWhoID
            // 
            this.TextBoxWhoID.BackColor = System.Drawing.Color.White;
            this.TextBoxWhoID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxWhoID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxWhoID.Location = new System.Drawing.Point(147, 27);
            this.TextBoxWhoID.Name = "TextBoxWhoID";
            this.TextBoxWhoID.ReadOnly = true;
            this.TextBoxWhoID.Size = new System.Drawing.Size(121, 15);
            this.TextBoxWhoID.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 16);
            this.label14.TabIndex = 14;
            this.label14.Text = "Par qui Code";
            // 
            // TextBoxStaffLastName
            // 
            this.TextBoxStaffLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxStaffLastName.BackColor = System.Drawing.Color.White;
            this.TextBoxStaffLastName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxStaffLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxStaffLastName.Location = new System.Drawing.Point(138, 192);
            this.TextBoxStaffLastName.Name = "TextBoxStaffLastName";
            this.TextBoxStaffLastName.ReadOnly = true;
            this.TextBoxStaffLastName.Size = new System.Drawing.Size(121, 15);
            this.TextBoxStaffLastName.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Nom Personnel";
            // 
            // TextBoxStaffID
            // 
            this.TextBoxStaffID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxStaffID.BackColor = System.Drawing.Color.White;
            this.TextBoxStaffID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxStaffID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxStaffID.Location = new System.Drawing.Point(138, 164);
            this.TextBoxStaffID.Name = "TextBoxStaffID";
            this.TextBoxStaffID.ReadOnly = true;
            this.TextBoxStaffID.Size = new System.Drawing.Size(121, 15);
            this.TextBoxStaffID.TabIndex = 11;
            // 
            // TextBoxTotalTicketMonitoring
            // 
            this.TextBoxTotalTicketMonitoring.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.TextBoxTotalTicketMonitoring.BackColor = System.Drawing.Color.White;
            this.TextBoxTotalTicketMonitoring.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxTotalTicketMonitoring.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxTotalTicketMonitoring.Location = new System.Drawing.Point(839, 324);
            this.TextBoxTotalTicketMonitoring.Name = "TextBoxTotalTicketMonitoring";
            this.TextBoxTotalTicketMonitoring.ReadOnly = true;
            this.TextBoxTotalTicketMonitoring.Size = new System.Drawing.Size(49, 15);
            this.TextBoxTotalTicketMonitoring.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 164);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 16);
            this.label11.TabIndex = 10;
            this.label11.Text = "Code Personnel";
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSearch.Location = new System.Drawing.Point(379, 33);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(88, 23);
            this.ButtonSearch.TabIndex = 5;
            this.ButtonSearch.Text = "Recherche";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // DTPTicketFromSearch
            // 
            this.DTPTicketFromSearch.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPTicketFromSearch.Location = new System.Drawing.Point(106, 20);
            this.DTPTicketFromSearch.Name = "DTPTicketFromSearch";
            this.DTPTicketFromSearch.Size = new System.Drawing.Size(100, 22);
            this.DTPTicketFromSearch.TabIndex = 4;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 51);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(94, 16);
            this.label21.TabIndex = 8;
            this.label21.Text = "Prix réparation";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 16);
            this.label16.TabIndex = 0;
            this.label16.Text = "Date";
            // 
            // ComboBoxStatusSearch
            // 
            this.ComboBoxStatusSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxStatusSearch.FormattingEnabled = true;
            this.ComboBoxStatusSearch.Items.AddRange(new object[] {
            "--tous--",
            "pas encore vérifié",
            "vérifié",
            "en cours de diagnostic",
            "confirmation diagnostic",
            "en cours de reparation",
            "reparé",
            "validé",
            "annulé",
            "retour au client",
            "en cours de livraison",
            "livré"});
            this.ComboBoxStatusSearch.Location = new System.Drawing.Point(106, 76);
            this.ComboBoxStatusSearch.Name = "ComboBoxStatusSearch";
            this.ComboBoxStatusSearch.Size = new System.Drawing.Size(228, 24);
            this.ComboBoxStatusSearch.TabIndex = 2;
            // 
            // TextBoxWorkerLastName
            // 
            this.TextBoxWorkerLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxWorkerLastName.BackColor = System.Drawing.Color.White;
            this.TextBoxWorkerLastName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxWorkerLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxWorkerLastName.Location = new System.Drawing.Point(138, 248);
            this.TextBoxWorkerLastName.Name = "TextBoxWorkerLastName";
            this.TextBoxWorkerLastName.ReadOnly = true;
            this.TextBoxWorkerLastName.Size = new System.Drawing.Size(121, 15);
            this.TextBoxWorkerLastName.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 248);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "Nom Employé";
            // 
            // TextBoxWorkerID
            // 
            this.TextBoxWorkerID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxWorkerID.BackColor = System.Drawing.Color.White;
            this.TextBoxWorkerID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxWorkerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxWorkerID.Location = new System.Drawing.Point(138, 220);
            this.TextBoxWorkerID.Name = "TextBoxWorkerID";
            this.TextBoxWorkerID.ReadOnly = true;
            this.TextBoxWorkerID.Size = new System.Drawing.Size(121, 15);
            this.TextBoxWorkerID.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 220);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 16);
            this.label9.TabIndex = 6;
            this.label9.Text = "Code Employé";
            // 
            // RichTextBoxProblem
            // 
            this.RichTextBoxProblem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RichTextBoxProblem.BackColor = System.Drawing.Color.White;
            this.RichTextBoxProblem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBoxProblem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextBoxProblem.Location = new System.Drawing.Point(138, 73);
            this.RichTextBoxProblem.Name = "RichTextBoxProblem";
            this.RichTextBoxProblem.ReadOnly = true;
            this.RichTextBoxProblem.Size = new System.Drawing.Size(323, 82);
            this.RichTextBoxProblem.TabIndex = 5;
            this.RichTextBoxProblem.Text = "";
            // 
            // DTPTicketToSearch
            // 
            this.DTPTicketToSearch.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPTicketToSearch.Location = new System.Drawing.Point(234, 20);
            this.DTPTicketToSearch.Name = "DTPTicketToSearch";
            this.DTPTicketToSearch.Size = new System.Drawing.Size(100, 22);
            this.DTPTicketToSearch.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Probleme";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Client Nom Complet";
            // 
            // TextBoxClientID
            // 
            this.TextBoxClientID.BackColor = System.Drawing.Color.White;
            this.TextBoxClientID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxClientID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxClientID.Location = new System.Drawing.Point(138, 27);
            this.TextBoxClientID.Name = "TextBoxClientID";
            this.TextBoxClientID.ReadOnly = true;
            this.TextBoxClientID.Size = new System.Drawing.Size(121, 15);
            this.TextBoxClientID.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(789, 324);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 16);
            this.label15.TabIndex = 29;
            this.label15.Text = "Total";
            // 
            // TextBoxRepairePriceToSearch
            // 
            this.TextBoxRepairePriceToSearch.Location = new System.Drawing.Point(234, 48);
            this.TextBoxRepairePriceToSearch.Name = "TextBoxRepairePriceToSearch";
            this.TextBoxRepairePriceToSearch.Size = new System.Drawing.Size(100, 22);
            this.TextBoxRepairePriceToSearch.TabIndex = 12;
            this.TextBoxRepairePriceToSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumbersKeyPress_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(212, 51);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(16, 16);
            this.label19.TabIndex = 11;
            this.label19.Text = "a";
            // 
            // TextBoxRepairePriceFromSearch
            // 
            this.TextBoxRepairePriceFromSearch.Location = new System.Drawing.Point(106, 48);
            this.TextBoxRepairePriceFromSearch.Name = "TextBoxRepairePriceFromSearch";
            this.TextBoxRepairePriceFromSearch.Size = new System.Drawing.Size(100, 22);
            this.TextBoxRepairePriceFromSearch.TabIndex = 10;
            this.TextBoxRepairePriceFromSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumbersKeyPress_KeyPress);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(212, 23);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(16, 16);
            this.label18.TabIndex = 7;
            this.label18.Text = "a";
            // 
            // TextBoxClientName
            // 
            this.TextBoxClientName.BackColor = System.Drawing.Color.White;
            this.TextBoxClientName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxClientName.Location = new System.Drawing.Point(138, 52);
            this.TextBoxClientName.Name = "TextBoxClientName";
            this.TextBoxClientName.ReadOnly = true;
            this.TextBoxClientName.Size = new System.Drawing.Size(121, 15);
            this.TextBoxClientName.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.ButtonReset);
            this.groupBox2.Controls.Add(this.TextBoxRepairePriceToSearch);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.TextBoxRepairePriceFromSearch);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.DTPTicketToSearch);
            this.groupBox2.Controls.Add(this.ButtonSearch);
            this.groupBox2.Controls.Add(this.DTPTicketFromSearch);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.ComboBoxStatusSearch);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(473, 106);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recherche";
            // 
            // ButtonReset
            // 
            this.ButtonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonReset.Location = new System.Drawing.Point(379, 62);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(88, 23);
            this.ButtonReset.TabIndex = 13;
            this.ButtonReset.Text = "Réinitialiser";
            this.ButtonReset.UseVisualStyleBackColor = true;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 79);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 16);
            this.label17.TabIndex = 3;
            this.label17.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Client Code";
            // 
            // DGVTicket
            // 
            this.DGVTicket.AllowUserToAddRows = false;
            this.DGVTicket.AllowUserToDeleteRows = false;
            this.DGVTicket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.DGVTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVTicket.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTicketID,
            this.ColumnTicketDateTime,
            this.ColumnTicketStatus,
            this.ColumnGadgetReference,
            this.ColumnRepairePrice});
            this.DGVTicket.Location = new System.Drawing.Point(12, 121);
            this.DGVTicket.Name = "DGVTicket";
            this.DGVTicket.ReadOnly = true;
            this.DGVTicket.Size = new System.Drawing.Size(471, 197);
            this.DGVTicket.TabIndex = 24;
            this.DGVTicket.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVTicket_CellMouseDoubleClick);
            // 
            // ColumnTicketID
            // 
            this.ColumnTicketID.HeaderText = "Code";
            this.ColumnTicketID.MinimumWidth = 50;
            this.ColumnTicketID.Name = "ColumnTicketID";
            this.ColumnTicketID.ReadOnly = true;
            this.ColumnTicketID.Width = 50;
            // 
            // ColumnTicketDateTime
            // 
            this.ColumnTicketDateTime.HeaderText = "Date";
            this.ColumnTicketDateTime.MinimumWidth = 100;
            this.ColumnTicketDateTime.Name = "ColumnTicketDateTime";
            this.ColumnTicketDateTime.ReadOnly = true;
            // 
            // ColumnTicketStatus
            // 
            this.ColumnTicketStatus.HeaderText = "Status";
            this.ColumnTicketStatus.MinimumWidth = 100;
            this.ColumnTicketStatus.Name = "ColumnTicketStatus";
            this.ColumnTicketStatus.ReadOnly = true;
            // 
            // ColumnGadgetReference
            // 
            this.ColumnGadgetReference.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnGadgetReference.HeaderText = "Référence";
            this.ColumnGadgetReference.MinimumWidth = 100;
            this.ColumnGadgetReference.Name = "ColumnGadgetReference";
            this.ColumnGadgetReference.ReadOnly = true;
            // 
            // ColumnRepairePrice
            // 
            dataGridViewCellStyle1.Format = "0:00";
            dataGridViewCellStyle1.NullValue = null;
            this.ColumnRepairePrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnRepairePrice.HeaderText = "Prix réparation";
            this.ColumnRepairePrice.MinimumWidth = 100;
            this.ColumnRepairePrice.Name = "ColumnRepairePrice";
            this.ColumnRepairePrice.ReadOnly = true;
            // 
            // TextBoxTotalTickets
            // 
            this.TextBoxTotalTickets.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.TextBoxTotalTickets.BackColor = System.Drawing.Color.White;
            this.TextBoxTotalTickets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxTotalTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxTotalTickets.Location = new System.Drawing.Point(434, 324);
            this.TextBoxTotalTickets.Name = "TextBoxTotalTickets";
            this.TextBoxTotalTickets.ReadOnly = true;
            this.TextBoxTotalTickets.Size = new System.Drawing.Size(49, 15);
            this.TextBoxTotalTickets.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(384, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Total";
            // 
            // GroupBoxTicketDeails
            // 
            this.GroupBoxTicketDeails.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.GroupBoxTicketDeails.Controls.Add(this.TextBoxStaffLastName);
            this.GroupBoxTicketDeails.Controls.Add(this.label4);
            this.GroupBoxTicketDeails.Controls.Add(this.TextBoxStaffID);
            this.GroupBoxTicketDeails.Controls.Add(this.label11);
            this.GroupBoxTicketDeails.Controls.Add(this.TextBoxWorkerLastName);
            this.GroupBoxTicketDeails.Controls.Add(this.label8);
            this.GroupBoxTicketDeails.Controls.Add(this.TextBoxWorkerID);
            this.GroupBoxTicketDeails.Controls.Add(this.label9);
            this.GroupBoxTicketDeails.Controls.Add(this.RichTextBoxProblem);
            this.GroupBoxTicketDeails.Controls.Add(this.label7);
            this.GroupBoxTicketDeails.Controls.Add(this.TextBoxClientName);
            this.GroupBoxTicketDeails.Controls.Add(this.label6);
            this.GroupBoxTicketDeails.Controls.Add(this.TextBoxClientID);
            this.GroupBoxTicketDeails.Controls.Add(this.label5);
            this.GroupBoxTicketDeails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxTicketDeails.Location = new System.Drawing.Point(12, 345);
            this.GroupBoxTicketDeails.Name = "GroupBoxTicketDeails";
            this.GroupBoxTicketDeails.Size = new System.Drawing.Size(471, 277);
            this.GroupBoxTicketDeails.TabIndex = 25;
            this.GroupBoxTicketDeails.TabStop = false;
            this.GroupBoxTicketDeails.Text = "Détails du ticket";
            // 
            // DGVTicketMonitoring
            // 
            this.DGVTicketMonitoring.AllowUserToAddRows = false;
            this.DGVTicketMonitoring.AllowUserToDeleteRows = false;
            this.DGVTicketMonitoring.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.DGVTicketMonitoring.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVTicketMonitoring.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTicketMonitoringID,
            this.ColumnTicketMonitoringDateTime,
            this.ColumnTicketMonitoringWho,
            this.ColumnTicketMonitoringStatus});
            this.DGVTicketMonitoring.Location = new System.Drawing.Point(489, 121);
            this.DGVTicketMonitoring.Name = "DGVTicketMonitoring";
            this.DGVTicketMonitoring.ReadOnly = true;
            this.DGVTicketMonitoring.Size = new System.Drawing.Size(399, 197);
            this.DGVTicketMonitoring.TabIndex = 27;
            this.DGVTicketMonitoring.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVTicketMonitoring_CellMouseDoubleClick);
            // 
            // ColumnTicketMonitoringID
            // 
            this.ColumnTicketMonitoringID.HeaderText = "Code";
            this.ColumnTicketMonitoringID.Name = "ColumnTicketMonitoringID";
            this.ColumnTicketMonitoringID.ReadOnly = true;
            // 
            // ColumnTicketMonitoringDateTime
            // 
            this.ColumnTicketMonitoringDateTime.HeaderText = "Date";
            this.ColumnTicketMonitoringDateTime.Name = "ColumnTicketMonitoringDateTime";
            this.ColumnTicketMonitoringDateTime.ReadOnly = true;
            // 
            // ColumnTicketMonitoringWho
            // 
            this.ColumnTicketMonitoringWho.HeaderText = "Par qui";
            this.ColumnTicketMonitoringWho.Name = "ColumnTicketMonitoringWho";
            this.ColumnTicketMonitoringWho.ReadOnly = true;
            // 
            // ColumnTicketMonitoringStatus
            // 
            this.ColumnTicketMonitoringStatus.HeaderText = "Status";
            this.ColumnTicketMonitoringStatus.Name = "ColumnTicketMonitoringStatus";
            this.ColumnTicketMonitoringStatus.ReadOnly = true;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(593, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(164, 25);
            this.label10.TabIndex = 26;
            this.label10.Text = "Gestion Ticket";
            // 
            // TicketManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 634);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TextBoxTotalTicketMonitoring);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.DGVTicket);
            this.Controls.Add(this.GroupBoxTicketDeails);
            this.Controls.Add(this.TextBoxTotalTickets);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGVTicketMonitoring);
            this.Controls.Add(this.label10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TicketManagment";
            this.Text = "TicketManagment";
            this.Load += new System.EventHandler(this.TicketManagment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTicket)).EndInit();
            this.GroupBoxTicketDeails.ResumeLayout(false);
            this.GroupBoxTicketDeails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTicketMonitoring)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TextBoxWhoName;
        private System.Windows.Forms.RichTextBox RichTextBoxDiscription;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TextBoxWhoID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TextBoxStaffLastName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBoxStaffID;
        private System.Windows.Forms.TextBox TextBoxTotalTicketMonitoring;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.DateTimePicker DTPTicketFromSearch;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox ComboBoxStatusSearch;
        private System.Windows.Forms.TextBox TextBoxWorkerLastName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TextBoxWorkerID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox RichTextBoxProblem;
        private System.Windows.Forms.DateTimePicker DTPTicketToSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TextBoxClientID;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TextBoxRepairePriceToSearch;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox TextBoxRepairePriceFromSearch;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox TextBoxClientName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView DGVTicket;
        private System.Windows.Forms.TextBox TextBoxTotalTickets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox GroupBoxTicketDeails;
        private System.Windows.Forms.DataGridView DGVTicketMonitoring;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTicketID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTicketDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTicketStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGadgetReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRepairePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTicketMonitoringID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTicketMonitoringDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTicketMonitoringWho;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTicketMonitoringStatus;
    }
}