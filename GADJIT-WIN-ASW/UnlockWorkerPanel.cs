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
    public partial class UnlockWorkerPanel : Form
    {
        public UnlockWorkerPanel()
        {
            InitializeComponent();
        }
        public Login login;
        public WorkerPanel workerPanel;
        public string email = "";
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (TextBoxPassWord.Text != "")
            {
                try
                {
                    SqlCommand sqlCommandDispo = new SqlCommand("select COUNT(WorEmail) from Worker where WorEmail = @email and WorPassWord = @pass", GADJIT.sqlConnection);
                    sqlCommandDispo.Parameters.AddWithValue("@email", email);
                    sqlCommandDispo.Parameters.AddWithValue("@pass", TextBoxPassWord.Text);
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
                    MessageBox.Show(ex.Message, "Error ButtonLogin_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    GADJIT.sqlConnection.Close();
                }
            }
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sqlCommandDispo = new SqlCommand("update Worker set WorDispo = 'Hors Ligne' where WorEmail = @email", GADJIT.sqlConnection);
                sqlCommandDispo.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                GADJIT.sqlConnection.Open();
                sqlCommandDispo.ExecuteNonQuery();
                this.Close();
                workerPanel.Close();
                login.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error LogoutButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
        }
    }
}
