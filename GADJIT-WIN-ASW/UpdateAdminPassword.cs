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
    public partial class UpdateAdminPassword : Form
    {
        public UpdateAdminPassword()
        {
            InitializeComponent();
        }

        public string email;
        public int adminID;

        private bool CheckIfPasswordIsCorrect()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select COUNT(AdmID) from Admin where AdmID = @adminID and AdmPassWord = @pass", GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@adminID", SqlDbType.Int).Value = adminID;
                sqlCommand.Parameters.Add("@pass", SqlDbType.NVarChar).Value = TextBoxOldPassword.Text;
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommand.ExecuteScalar() == 1) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIfPasswordIsCorrect (string pass)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
            return false;
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (TextBoxOldPassword.Text != "")
            {
                if (TextBoxNewPassword.Text == TextBoxConfirmNewPassword.Text)
                {
                    if (CheckIfPasswordIsCorrect())
                    {
                        if (MessageBox.Show("Voulez-vous modifier votre mot de passe ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            try
                            {
                                SqlCommand sqlCommand = new SqlCommand("update Admin set AdmPassWord = @pass where AdmID = @adminID", GADJIT.sqlConnection);
                                sqlCommand.Parameters.Add("@pass", SqlDbType.NVarChar).Value = TextBoxConfirmNewPassword.Text;
                                sqlCommand.Parameters.Add("@adminID", SqlDbType.Int).Value = adminID;
                                GADJIT.sqlConnection.Open();
                                sqlCommand.ExecuteNonQuery();
                                MessageBox.Show("Modification réussi", "Changement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                GADJIT.SendEmail(email, "Votre mot de passe a été changé");
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error ButtonUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                GADJIT.sqlConnection.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ancien mot de passe incorrect", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TextBoxOldPassword.Clear();
                        TextBoxOldPassword.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Confirmation mot de passe incorrect", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextBoxConfirmNewPassword.Clear();
                    TextBoxConfirmNewPassword.Focus();
                }
            }
            else
            {
                MessageBox.Show("Veuillez taper votre ancien mot de passe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
