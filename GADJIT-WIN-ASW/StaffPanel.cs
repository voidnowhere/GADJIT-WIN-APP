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
    public partial class StaffPanel : Form
    {
        public StaffPanel()
        {
            InitializeComponent();
        }

        private void StaffPanel_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Staff SET StafDispo='En Ligne' where StafEmail=@Email", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@Email", LabelEmail.Text);
            GADJIT.sqlConnection.Open();
            cmd.ExecuteNonQuery();
            GADJIT.sqlConnection.Close();
        }

        private void cirucularButton_Click(object sender, EventArgs e)
        {
            GADJIT.sqlConnection.Open();
            if (cirucularButton.BackColor == Color.Lime)
            {
                cirucularButton.BackColor = Color.Orange;
                SqlCommand cmd = new SqlCommand("UPDATE Staff SET StafDispo='Break' where StafEmail=@Email", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@Email", LabelEmail.Text);
                cmd.ExecuteNonQuery();        
            }
            else
            {
                cirucularButton.BackColor = Color.Lime;
                SqlCommand cmd = new SqlCommand("UPDATE Staff SET StafDispo='En Ligne' where StafEmail=@Email", GADJIT.sqlConnection);
                cmd.Parameters.AddWithValue("@Email", LabelEmail.Text);
                cmd.ExecuteNonQuery();
            }
            GADJIT.sqlConnection.Close();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StaffPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            GADJIT.sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Staff SET StafDispo='Hors Ligne' where StafEmail=@Email", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@Email", LabelEmail.Text);
            GADJIT.sqlConnection.Open();
            cmd.ExecuteNonQuery();
            GADJIT.sqlConnection.Close();
        }
    }
}
