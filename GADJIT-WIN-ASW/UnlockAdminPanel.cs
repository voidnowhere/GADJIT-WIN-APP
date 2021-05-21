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
    public partial class UnlockAdminPanel : Form
    {
        public UnlockAdminPanel()
        {
            InitializeComponent();
        }

        public Login login;
        public AdminPanel adminPanel;
        public string email;

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if(TextBoxPassWord.Text != "")
            {
                try
                {
                    SqlCommand sqlCommandDispo = new SqlCommand("select COUNT(AdmEmail) from Admin where AdmEmail = @email and AdmPassWord = @pass", GADJIT.sqlConnection);
                    sqlCommandDispo.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                    sqlCommandDispo.Parameters.Add("@pass", SqlDbType.NVarChar).Value = TextBoxPassWord.Text;
                    GADJIT.sqlConnection.Open();
                    if ((int)sqlCommandDispo.ExecuteScalar() == 1)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("mot de passe incorrect", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TextBoxPassWord.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error PictureBoxLogOut_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    GADJIT.sqlConnection.Close();
                }
            }
        }

        private void PictureBoxLogOut_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sqlCommandDispo = new SqlCommand("update Admin set AdmDispo = 'Hors Ligne' where AdmEmail = @email", GADJIT.sqlConnection);
                sqlCommandDispo.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                GADJIT.sqlConnection.Open();
                sqlCommandDispo.ExecuteNonQuery();
                this.Close();
                adminPanel.Close();
                login.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error PictureBoxLogOut_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
        }

        private void UnlockAdminPanel_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
