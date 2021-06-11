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
    public partial class UnlockStaffPanel : Form
    {
        public UnlockStaffPanel()
        {
            InitializeComponent();
        }

        public Login login;
        public StaffPanel staffPanel;
        public int staffID;

        private void UnlockStaffPanel_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (TextBoxPassWord.Text != "")
            {
                try
                {
                    SqlCommand sqlCommandDispo = new SqlCommand("select COUNT(StafID) from Staff where StafID = @staffID and StafPassWord = @pass", GADJIT.sqlConnection);
                    sqlCommandDispo.Parameters.Add("@staffID", SqlDbType.Int).Value = staffID;
                    sqlCommandDispo.Parameters.Add("@pass", SqlDbType.NVarChar).Value = TextBoxPassWord.Text;
                    GADJIT.sqlConnection.Open();
                    if ((int)sqlCommandDispo.ExecuteScalar() == 1)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Mot de passe incorrect", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
            {
                MessageBox.Show("Veuillez taper votre mot de passe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sqlCommandDispo = new SqlCommand("update Staff set StafDispo = 'Hors Ligne' where StafID = @staffID", GADJIT.sqlConnection);
                sqlCommandDispo.Parameters.Add("@staffID", SqlDbType.Int).Value = staffID;
                GADJIT.sqlConnection.Open();
                sqlCommandDispo.ExecuteNonQuery();
                GADJIT.sqlConnection.Close();
                staffPanel.logout = true;
                this.Close();
                staffPanel.Close();
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
