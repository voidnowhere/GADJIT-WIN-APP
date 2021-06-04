
namespace GADJIT_WIN_ASW
{
    partial class Statistics
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
            this.CrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.RadioButtonWorkerStats = new System.Windows.Forms.RadioButton();
            this.RadioButtonGadgetCategoryStats = new System.Windows.Forms.RadioButton();
            this.DTPFrom = new System.Windows.Forms.DateTimePicker();
            this.DTPTo = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RadioButtonGadgetBrandStats = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CrystalReportViewer
            // 
            this.CrystalReportViewer.ActiveViewIndex = -1;
            this.CrystalReportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrystalReportViewer.Location = new System.Drawing.Point(12, 126);
            this.CrystalReportViewer.Name = "CrystalReportViewer";
            this.CrystalReportViewer.ShowCloseButton = false;
            this.CrystalReportViewer.ShowGroupTreeButton = false;
            this.CrystalReportViewer.ShowLogo = false;
            this.CrystalReportViewer.ShowParameterPanelButton = false;
            this.CrystalReportViewer.ShowRefreshButton = false;
            this.CrystalReportViewer.ShowTextSearchButton = false;
            this.CrystalReportViewer.Size = new System.Drawing.Size(648, 386);
            this.CrystalReportViewer.TabIndex = 0;
            this.CrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(274, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Statistiques";
            // 
            // RadioButtonWorkerStats
            // 
            this.RadioButtonWorkerStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RadioButtonWorkerStats.AutoSize = true;
            this.RadioButtonWorkerStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButtonWorkerStats.Location = new System.Drawing.Point(570, 48);
            this.RadioButtonWorkerStats.Name = "RadioButtonWorkerStats";
            this.RadioButtonWorkerStats.Size = new System.Drawing.Size(92, 20);
            this.RadioButtonWorkerStats.TabIndex = 2;
            this.RadioButtonWorkerStats.TabStop = true;
            this.RadioButtonWorkerStats.Text = "Technicien";
            this.RadioButtonWorkerStats.UseVisualStyleBackColor = true;
            this.RadioButtonWorkerStats.Click += new System.EventHandler(this.RadioButtonWorkerStats_Click);
            // 
            // RadioButtonGadgetCategoryStats
            // 
            this.RadioButtonGadgetCategoryStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RadioButtonGadgetCategoryStats.AutoSize = true;
            this.RadioButtonGadgetCategoryStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButtonGadgetCategoryStats.Location = new System.Drawing.Point(570, 74);
            this.RadioButtonGadgetCategoryStats.Name = "RadioButtonGadgetCategoryStats";
            this.RadioButtonGadgetCategoryStats.Size = new System.Drawing.Size(85, 20);
            this.RadioButtonGadgetCategoryStats.TabIndex = 3;
            this.RadioButtonGadgetCategoryStats.TabStop = true;
            this.RadioButtonGadgetCategoryStats.Text = "Catégorie";
            this.RadioButtonGadgetCategoryStats.UseVisualStyleBackColor = true;
            this.RadioButtonGadgetCategoryStats.Click += new System.EventHandler(this.RadioButtonGadgetCategoryStats_Click);
            // 
            // DTPFrom
            // 
            this.DTPFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFrom.Location = new System.Drawing.Point(38, 28);
            this.DTPFrom.Name = "DTPFrom";
            this.DTPFrom.Size = new System.Drawing.Size(87, 22);
            this.DTPFrom.TabIndex = 4;
            // 
            // DTPTo
            // 
            this.DTPTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPTo.Location = new System.Drawing.Point(153, 28);
            this.DTPTo.Name = "DTPTo";
            this.DTPTo.Size = new System.Drawing.Size(87, 22);
            this.DTPTo.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DTPFrom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DTPTo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Goldenrod;
            this.groupBox1.Location = new System.Drawing.Point(12, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(552, 69);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(131, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "De";
            // 
            // RadioButtonGadgetBrandStats
            // 
            this.RadioButtonGadgetBrandStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RadioButtonGadgetBrandStats.AutoSize = true;
            this.RadioButtonGadgetBrandStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButtonGadgetBrandStats.Location = new System.Drawing.Point(569, 100);
            this.RadioButtonGadgetBrandStats.Name = "RadioButtonGadgetBrandStats";
            this.RadioButtonGadgetBrandStats.Size = new System.Drawing.Size(72, 20);
            this.RadioButtonGadgetBrandStats.TabIndex = 7;
            this.RadioButtonGadgetBrandStats.TabStop = true;
            this.RadioButtonGadgetBrandStats.Text = "Marque";
            this.RadioButtonGadgetBrandStats.UseVisualStyleBackColor = true;
            this.RadioButtonGadgetBrandStats.Click += new System.EventHandler(this.RadioButtonGadgetBrandStats_Click);
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 524);
            this.Controls.Add(this.RadioButtonGadgetBrandStats);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RadioButtonGadgetCategoryStats);
            this.Controls.Add(this.RadioButtonWorkerStats);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CrystalReportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Statistics";
            this.Text = "Statistics";
            this.Load += new System.EventHandler(this.Statistics_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrystalReportViewer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RadioButtonWorkerStats;
        private System.Windows.Forms.RadioButton RadioButtonGadgetCategoryStats;
        private System.Windows.Forms.DateTimePicker DTPFrom;
        private System.Windows.Forms.DateTimePicker DTPTo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton RadioButtonGadgetBrandStats;
    }
}