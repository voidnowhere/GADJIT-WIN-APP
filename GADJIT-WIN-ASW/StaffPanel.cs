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

        public Login login;

        private void CloseMdiChildIdExists()
        {
            if (this.ActiveMdiChild != null) this.ActiveMdiChild.Close();
        }

        private void StaffDispoChanger(string dispo)
        {
            try
            {
                SqlCommand sqlCommandDispo = new SqlCommand("update Staff set StafDispo = @dispo where StafEmail = @email", GADJIT.sqlConnection);
                sqlCommandDispo.Parameters.Add("@dispo", SqlDbType.VarChar).Value = dispo;
                sqlCommandDispo.Parameters.Add("@email", SqlDbType.NVarChar).Value = LabelEmail.Text;
                GADJIT.sqlConnection.Open();
                sqlCommandDispo.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error AdminDispo(string dispo)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GADJIT.sqlConnection.Close();
            }
        }

        private void StaffPanel_Load(object sender, EventArgs e)
        {
            StaffDispoChanger("En Ligne");
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.CenterToScreen();
        }

        private void PannelButtonsLock(bool tf)
        {
            ShowSubMenuButton.Enabled = tf;
            ButtonTicketVerification.Enabled = tf;
            ButtonTicketProgression.Enabled = tf;
        }

        private void cirucularButton_Click(object sender, EventArgs e)
        {
            if (ButtonDisponibility.BackColor == Color.Lime)
            {
                StaffDispoChanger("Break");
                ButtonDisponibility.BackColor = Color.Orange;
                CloseMdiChildIdExists();
                PannelButtonsLock(false);
            }
            else if (ButtonDisponibility.BackColor == Color.Orange)
            {
                UnlockStaffPanel unlockStaffPanel = new UnlockStaffPanel();
                unlockStaffPanel.login = login;
                unlockStaffPanel.staffPanel = this;
                unlockStaffPanel.email = LabelEmail.Text;
                unlockStaffPanel.ShowDialog();
                PannelButtonsLock(true);
                //
                StaffDispoChanger("En Ligne");
                ButtonDisponibility.BackColor = Color.Lime;
            }
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            StaffDispoChanger("Hors Ligne");
            this.Close();
            login.Show();
        }

        private void ButtonTicketVerification_Click(object sender, EventArgs e)
        {
            CloseMdiChildIdExists();
            StaffTicketVerification staffTicketVerification = new StaffTicketVerification();
            staffTicketVerification.email = LabelEmail.Text;
            staffTicketVerification.MdiParent = this;
            staffTicketVerification.Dock = DockStyle.Fill;
            staffTicketVerification.Show();
        }

        private void ButtonTicketProgression_Click(object sender, EventArgs e)
        {
            CloseMdiChildIdExists();
            StaffTicketProgression staffTicketProgression = new StaffTicketProgression();
            staffTicketProgression.email = LabelEmail.Text;
            staffTicketProgression.MdiParent = this;
            staffTicketProgression.Dock = DockStyle.Fill;
            staffTicketProgression.Show();
        }

        private void CircularPicturePasswordChange_Click(object sender, EventArgs e)
        {
            UpdateStaffPassword updateStaffPassword = new UpdateStaffPassword();
            updateStaffPassword.email = LabelEmail.Text;
            updateStaffPassword.ShowDialog();
        }
    }
}
