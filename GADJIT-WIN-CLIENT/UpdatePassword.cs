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

namespace GADJIT_WIN_CLIENT
{
    public partial class UpdatePassword : Form
    {
        public UpdatePassword()
        {
            InitializeComponent();
        }

        public int CID;
        public string mdp;
        public string email;
        public string nom;

        private void UpdatePassword_Load(object sender, EventArgs e)
        {

        }

        private void ButtonAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if(mdp == textBoxOldpass.Text)
            {
                if (TextBoxNewPass.Text == TextBoxConfNewPass.Text)
                {
                    SqlCommand cmd = new SqlCommand("update Client set CliPassWord=@pass where CliID =@CID", GADJIT.sqlConnection);
                    cmd.Parameters.AddWithValue("@CID", CID);
                    cmd.Parameters.AddWithValue("@pass", TextBoxNewPass.Text);
                    GADJIT.sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    GADJIT.sqlConnection.Close();
                    errorProviderConfPass.SetError(TextBoxConfNewPass, null);
                    MessageBox.Show("Mot de passe modifie avec succes", "modification mot de passe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GADJIT.SendEmail(email, "Bonjour " + nom + " :\nvous avez modifier votre mot de passe voici le nouveau mot de pass." + TextBoxNewPass.Text + " \nGADJIT MAROC.");
                    this.Close();
                }
                else
                {
                    errorProviderConfPass.SetError(TextBoxConfNewPass, "mot de passe doit Être identique");
                }
            }
            else
            {
                MessageBox.Show("Entrez l'ancien mot de passe correct", "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
