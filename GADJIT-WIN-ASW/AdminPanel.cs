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
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        public Login login;
        public int adminID;
        public bool logout = false;

        private void CloseMdiChildIdExists()
        {
            if (this.ActiveMdiChild != null) this.ActiveMdiChild.Close();
        }

        private void AdminDispoChanger(string dispo)
        {
            try
            {
                SqlCommand sqlCommandDispo = new SqlCommand("update Admin set AdmDispo = @dispo where AdmID = @adminID", GADJIT.sqlConnection);
                sqlCommandDispo.Parameters.Add("@dispo", SqlDbType.VarChar).Value = dispo;
                sqlCommandDispo.Parameters.Add("@adminID", SqlDbType.Int).Value = adminID;
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

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            AdminDispoChanger("En Ligne");
            //
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.CenterToScreen();
            PanelGadgetManagment.Visible = false;
        }

        private void PannelButtonsLock(bool tf)
        {
            CircularPicturePasswordChange.Enabled = tf;
            ButtonStatistics.Enabled = tf;
            ButtonClientManagment.Enabled = tf;
            ButtonTicketManagment.Enabled = tf;
            ButtonStaffManagment.Enabled = tf;
            ButtonWorkerManagment.Enabled = tf;
            ButtonGadgetMenu.Enabled = tf;
            ButtonCityManagement.Enabled = tf;
        }

        private void ButtonDisponibility_Click(object sender, EventArgs e)
        {
            if (ButtonDisponibility.BackColor == Color.Lime)
            {
                AdminDispoChanger("Break");
                ButtonDisponibility.BackColor = Color.Orange;
                CloseMdiChildIdExists();
                ResetButtonsColor();
                PannelButtonsLock(false);
            }
            else if (ButtonDisponibility.BackColor == Color.Orange)
            {
                UnlockAdminPanel unlockAdminPanel = new UnlockAdminPanel();
                unlockAdminPanel.login = login;
                unlockAdminPanel.adminPanel = this;
                unlockAdminPanel.adminID = adminID;
                unlockAdminPanel.ShowDialog();
                PannelButtonsLock(true);
                //
                if(!logout) AdminDispoChanger("En Ligne");
                ButtonDisponibility.BackColor = Color.Lime;
            }
        }

        private void PictureBoxLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdminPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            AdminDispoChanger("Hors Ligne");
            login.Show();
        }

        private void ResetButtonsColor()
        {
            ButtonStatistics.BackColor = Color.FromArgb(247, 181, 46);
            ButtonTicketManagment.BackColor = Color.FromArgb(247, 181, 46);
            ButtonClientManagment.BackColor = Color.FromArgb(247, 181, 46);
            ButtonStaffManagment.BackColor = Color.FromArgb(247, 181, 46);
            ButtonWorkerManagment.BackColor = Color.FromArgb(247, 181, 46);
            ButtonCityManagement.BackColor = Color.FromArgb(247, 181, 46);
            //
            ButtonGadgetCategoryBrandManagment.BackColor = Color.White;
            ButtonGadgetCategoryBrandManagment.ForeColor = Color.FromArgb(218, 165, 33);
            //
            ButtonGadgetReferenceManagment.BackColor = Color.White;
            ButtonGadgetReferenceManagment.ForeColor = Color.FromArgb(218, 165, 33);
        }

        private void ButtonStatistics_Click(object sender, EventArgs e)
        {
            ResetButtonsColor();
            ButtonStatistics.BackColor = Color.FromArgb(239, 190, 34);
            //
            CloseMdiChildIdExists();
            PanelGadgetManagment.Visible = false;
            Statistics statistics = new Statistics();
            statistics.MdiParent = this;
            statistics.Dock = DockStyle.Fill;
            statistics.Show();
        }

        private void ButtonTicketManagment_Click(object sender, EventArgs e)
        {
            ResetButtonsColor();
            ButtonTicketManagment.BackColor = Color.FromArgb(239, 190, 34);
            //
            CloseMdiChildIdExists();
            PanelGadgetManagment.Visible = false;
            TicketManagment ticketManagment = new TicketManagment();
            ticketManagment.MdiParent = this;
            ticketManagment.Dock = DockStyle.Fill;
            ticketManagment.Show();
        }

        private void ButtonClientManagment_Click(object sender, EventArgs e)
        {
            ResetButtonsColor();
            ButtonClientManagment.BackColor = Color.FromArgb(239, 190, 34);
            //
            CloseMdiChildIdExists();
            PanelGadgetManagment.Visible = false;
            ClientManagment clientManagment = new ClientManagment();
            clientManagment.MdiParent = this;
            clientManagment.Dock = DockStyle.Fill;
            clientManagment.Show();
        }

        private void ButtonStaffManagment_Click(object sender, EventArgs e)
        {
            ResetButtonsColor();
            ButtonStaffManagment.BackColor = Color.FromArgb(239, 190, 34);
            //
            CloseMdiChildIdExists();
            PanelGadgetManagment.Visible = false;
            StaffManagment staffManage = new StaffManagment();
            staffManage.MdiParent = this;
            staffManage.Dock = DockStyle.Fill;
            staffManage.Show();
        }

        private void ButtonWorkerManagment_Click(object sender, EventArgs e)
        {
            ResetButtonsColor();
            ButtonWorkerManagment.BackColor = Color.FromArgb(239, 190, 34);
            //
            CloseMdiChildIdExists();
            PanelGadgetManagment.Visible = false;
            WorkerManagment workerManage = new WorkerManagment();
            workerManage.MdiParent = this;
            workerManage.Dock = DockStyle.Fill;
            workerManage.Show();
        }

        private void ButtonGadgetCategoryBrandManagment_Click(object sender, EventArgs e)
        {
            ResetButtonsColor();
            ButtonGadgetCategoryBrandManagment.BackColor = Color.FromArgb(239, 190, 34);
            ButtonGadgetCategoryBrandManagment.ForeColor = Color.White;
            //
            CloseMdiChildIdExists();
            GadgetCategoryBrandManagment categoryBrandManagment = new GadgetCategoryBrandManagment();
            categoryBrandManagment.MdiParent = this;
            categoryBrandManagment.Dock = DockStyle.Fill;
            categoryBrandManagment.Show();
        }

        private void ButtonGadgetReferenceManagment_Click(object sender, EventArgs e)
        {
            ResetButtonsColor();
            ButtonGadgetReferenceManagment.BackColor = Color.FromArgb(239, 190, 34);
            ButtonGadgetReferenceManagment.ForeColor = Color.White;
            //
            CloseMdiChildIdExists();
            GadgetReferenceManagment referenceManagment = new GadgetReferenceManagment();
            referenceManagment.MdiParent = this;
            referenceManagment.Dock = DockStyle.Fill;
            referenceManagment.Show();
        }

        private void ButtonCityManagement_Click(object sender, EventArgs e)
        {
            ResetButtonsColor();
            ButtonCityManagement.BackColor = Color.FromArgb(239, 190, 34);
            ButtonCityManagement.ForeColor = Color.White;
            PanelGadgetManagment.Visible = false;
            //
            CloseMdiChildIdExists();
            CityManagement cityManagement = new CityManagement();
            cityManagement.MdiParent = this;
            cityManagement.Dock = DockStyle.Fill;
            cityManagement.Show();
        }

        private void ButtonGadgetMenu_Click(object sender, EventArgs e)
        {
            ResetButtonsColor();
            PanelGadgetManagment.Visible = true;
            CloseMdiChildIdExists();
        }

        private void CircularPicturePasswordChange_Click(object sender, EventArgs e)
        {
            UpdateAdminPassword updateAdminPassword = new UpdateAdminPassword();
            updateAdminPassword.email = LabelEmail.Text;
            updateAdminPassword.adminID = adminID;
            updateAdminPassword.ShowDialog();
        }
    }
}
