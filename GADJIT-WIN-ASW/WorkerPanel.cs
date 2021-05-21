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
        public static string WID;
        private void cirucularButton_Click(object sender, EventArgs e)
        {
            GADJIT.sqlConnection.Open();
            if (cirucularButton.BackColor == Color.Lime)
            {
                cirucularButton.BackColor = Color.Orange;
                SqlCommand cmd = new SqlCommand("UPDATE Worker SET WorDispo='Break' where WorEmail=@Email", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@Email", LabelEmail.Text);
                cmd.ExecuteNonQuery();
            }
            else
            {
                cirucularButton.BackColor = Color.Lime;
                cirucularButton.BackColor = Color.Orange;
                SqlCommand cmd = new SqlCommand("UPDATE Worker SET WorDispo='En Ligne' where WorEmail=@Email", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@Email", LabelEmail.Text);
                cmd.ExecuteNonQuery();
            }
            GADJIT.sqlConnection.Close();
        }

        private void WorkerPanel_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Worker SET WorDispo='En Ligne' where WorEmail=@Email", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@Email", LabelEmail.Text);
            GADJIT.sqlConnection.Open();
            cmd.ExecuteNonQuery();
            GADJIT.sqlConnection.Close();
            cmd = new SqlCommand("select WorID from Worker where WorEmail=@Email", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@Email", LabelEmail.Text);
            GADJIT.sqlConnection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            WID = dr["WorID"].ToString();
            dr.Close();
            GADJIT.sqlConnection.Close();
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.CenterToScreen();
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

        private void ShowSubMenuButton_Click(object sender, EventArgs e)
        {
            TicketConsultationWorker ticketworker = new TicketConsultationWorker();
            ticketworker.MdiParent = this;
            ticketworker.Dock = DockStyle.Fill;
            ticketworker.Show();
        }
    }
}
