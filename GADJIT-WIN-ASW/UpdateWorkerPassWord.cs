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
    public partial class UpdateWorkerPassWord : Form
    {
        public UpdateWorkerPassWord()
        {
            InitializeComponent();
        }
        public string email;
        private bool CheckIfPasswordIsCorrect()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select COUNT(WorEmail) from Worker where WorEmail = @email and WorPassWord = @pass", GADJIT.sqlConnection);
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
                GADJIT.sqlConnection.Close();
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
                            SqlCommand sqlCommand = new SqlCommand("update Worker set WorPassWord = @pass where WorEmail = @email", GADJIT.sqlConnection);
                            sqlCommand.Parameters.Add("@pass", SqlDbType.NVarChar).Value = TextBoxConfirmNewPassword.Text;
                            sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                            GADJIT.sqlConnection.Open();
                            sqlCommand.ExecuteNonQuery();
                            MessageBox.Show("Mot de passe Modiffier", "Réussi",  MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
