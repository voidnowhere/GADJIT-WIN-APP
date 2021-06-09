
namespace GADJIT_WIN_ASW
{
    partial class WorkerSpeciality
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkerSpeciality));
            this.DGVWorkerSpecialistes = new System.Windows.Forms.DataGridView();
            this.ColumnComboBoxCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnComboBoxBrand = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVWorkerSpecialistes)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVWorkerSpecialistes
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Menu;
            this.DGVWorkerSpecialistes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVWorkerSpecialistes.BackgroundColor = System.Drawing.Color.White;
            this.DGVWorkerSpecialistes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVWorkerSpecialistes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVWorkerSpecialistes.ColumnHeadersHeight = 30;
            this.DGVWorkerSpecialistes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVWorkerSpecialistes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnComboBoxCategory,
            this.ColumnComboBoxBrand});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(181)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVWorkerSpecialistes.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVWorkerSpecialistes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVWorkerSpecialistes.EnableHeadersVisualStyles = false;
            this.DGVWorkerSpecialistes.Location = new System.Drawing.Point(0, 0);
            this.DGVWorkerSpecialistes.Name = "DGVWorkerSpecialistes";
            this.DGVWorkerSpecialistes.Size = new System.Drawing.Size(447, 270);
            this.DGVWorkerSpecialistes.TabIndex = 0;
            this.DGVWorkerSpecialistes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVWorkerSpecialistes_CellValueChanged);
            this.DGVWorkerSpecialistes.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DGVWorkerSpecialistes_UserDeletingRow);
            // 
            // ColumnComboBoxCategory
            // 
            this.ColumnComboBoxCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnComboBoxCategory.HeaderText = "Catégorie";
            this.ColumnComboBoxCategory.Name = "ColumnComboBoxCategory";
            // 
            // ColumnComboBoxBrand
            // 
            this.ColumnComboBoxBrand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnComboBoxBrand.HeaderText = "Marque";
            this.ColumnComboBoxBrand.Name = "ColumnComboBoxBrand";
            // 
            // WorkerSpeciality
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 270);
            this.Controls.Add(this.DGVWorkerSpecialistes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WorkerSpeciality";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employé Spécialité";
            this.Load += new System.EventHandler(this.WorkerSpeciality_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVWorkerSpecialistes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVWorkerSpecialistes;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnComboBoxCategory;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnComboBoxBrand;
    }
}