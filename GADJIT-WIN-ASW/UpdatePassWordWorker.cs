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

namespace GADJIT_WIN_ASW
{
    public partial class UpdatePassWordWorker : Form
    {
        public UpdatePassWordWorker()
        {
            InitializeComponent();
        }
        string oldpass="";
        private void ButtonAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdatePassWordWorker_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select WorPassWord from Worker where WorID=@WID", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@WID", WorkerPanel.WID);
            GADJIT.sqlConnection.Open();
            oldpass = cmd.ExecuteScalar().ToString();
            GADJIT.sqlConnection.Close();
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (TextBoxOldPass.Text == oldpass)
            {
                if (TextBoxNewPass.Text == TextBoxConfNewPass.Text)
                {
                    SqlCommand cmd = new SqlCommand("update Worker set WorPassWord=@pass where CliID =@ID", GADJIT.sqlConnection);
                    cmd.Parameters.AddWithValue("@pass", TextBoxNewPass.Text);
                    cmd.Parameters.AddWithValue("@ID", WorkerPanel.WID);
                    GADJIT.sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    GADJIT.sqlConnection.Close();
                }
                else
                {
                    MessageBox.Show("confirmation mot de passe doit etre identique au nouveau mot de passe", "non identique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ancien mot de passe incorrect", "incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
