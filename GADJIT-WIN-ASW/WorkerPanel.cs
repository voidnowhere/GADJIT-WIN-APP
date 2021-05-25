using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace GADJIT_WIN_ASW
{
    public partial class WorkerPanel : Form
    {
        public WorkerPanel()
        {
            InitializeComponent();
        }

        private void cirucularButton_Click(object sender, EventArgs e)
        {
            if (cirucularButton.BackColor == Color.Lime)
            {
                cirucularButton.BackColor = Color.Orange;
                SqlCommand cmd = new SqlCommand("UPDATE Worker SET WorDispo='Break' where WorEmail=@Email", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@Email", LabelEmail.Text);
                GADJIT.sqlConnection.Open();
                cmd.ExecuteNonQuery();
                GADJIT.sqlConnection.Close();
            }
            else
            {
                UnlockWorkerPanel unlockWorkerPanel = new UnlockWorkerPanel();
                unlockWorkerPanel.email = LabelEmail.Text;
                unlockWorkerPanel.workerPanel = this;
                unlockWorkerPanel.ShowDialog();
                cirucularButton.BackColor = Color.Lime;
                SqlCommand cmd = new SqlCommand("UPDATE Worker SET WorDispo='En Ligne' where WorEmail=@Email", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@Email", LabelEmail.Text);
                GADJIT.sqlConnection.Open();
                cmd.ExecuteNonQuery();
                GADJIT.sqlConnection.Close();
            }
        }

        private void WorkerPanel_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Worker SET WorDispo='En Ligne' where WorEmail=@Email", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@Email", LabelEmail.Text);
            GADJIT.sqlConnection.Open();
            cmd.ExecuteNonQuery();
            GADJIT.sqlConnection.Close();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WorkerPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Worker SET WorDispo='Hors Ligne' where WorEmail=@Email", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@Email", LabelEmail.Text);
            GADJIT.sqlConnection.Open();
            cmd.ExecuteNonQuery();
            GADJIT.sqlConnection.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
