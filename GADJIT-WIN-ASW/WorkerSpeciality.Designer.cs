
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
            this.DGVWorkerSpecialistes = new System.Windows.Forms.DataGridView();
            this.ColumnComboBoxCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnComboBoxBrand = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVWorkerSpecialistes)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVWorkerSpecialistes
            // 
            this.DGVWorkerSpecialistes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVWorkerSpecialistes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnComboBoxCategory,
            this.ColumnComboBoxBrand});
            this.DGVWorkerSpecialistes.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WorkerSpeciality";
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