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

        private bool CheckIfPasswordIsCorrect()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select COUNT(AdmEmail) from Admin where AdmEmail = @email and AdmPassWord = @pass", GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
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
                GADJIT.sqlConnection.Open();
            }
            return false;
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (TextBoxOldPassword.Text != "" && TextBoxNewPassword.Text == TextBoxConfirmNewPassword.Text)
            {
                if (CheckIfPasswordIsCorrect())
                {
                    if (MessageBox.Show("Voulez vous modifier votre mot de passe", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        try
                        {
                            SqlCommand sqlCommand = new SqlCommand("update Admin set AdmPassWord = @pass where AdmEmail = @email", GADJIT.sqlConnection);
                            sqlCommand.Parameters.Add("@pass", SqlDbType.NVarChar).Value = TextBoxConfirmNewPassword.Text;
                            sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                            GADJIT.sqlConnection.Open();
                            MessageBox.Show(sqlCommand.ExecuteNonQuery() + " réussi", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error ButtonUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            GADJIT.sqlConnection.Open();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("ancien mot de passe incorrect", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextBoxOldPassword.Clear();
                    TextBoxOldPassword.Focus();
                }
            }
            else
            {
                MessageBox.Show("confirmation mot de passe incorrect", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxConfirmNewPassword.Clear();
                TextBoxConfirmNewPassword.Focus();
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
