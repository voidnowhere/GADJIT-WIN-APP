using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADJIT_WIN_ASW
{
    public partial class UpdateStaffPassword : Form
    {
        public UpdateStaffPassword()
        {
            InitializeComponent();
        }

        public string email;
        public int staffID;

        private bool CheckIfPasswordIsCorrect()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select COUNT(StafID) from Staff where StafID = @staffID and StafPassWord = @pass", GADJIT.sqlConnection);
                sqlCommand.Parameters.Add("@staffID", SqlDbType.Int).Value = staffID;
                sqlCommand.Parameters.Add("@pass", SqlDbType.NVarChar).Value = TextBoxOldPassword.Text;
                GADJIT.sqlConnection.Open();
                if ((int)sqlCommand.ExecuteScalar() == 1) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error CheckIfPasswordIsCorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if (MessageBox.Show("Voulez vous modifier votre mot de passe ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            try
                            {
                                SqlCommand sqlCommand = new SqlCommand("update Staff set StafPassWord = @pass where StafID = @staffID", GADJIT.sqlConnection);
                                sqlCommand.Parameters.Add("@pass", SqlDbType.NVarChar).Value = TextBoxConfirmNewPassword.Text;
                                sqlCommand.Parameters.Add("@staffID", SqlDbType.Int).Value = staffID;
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
