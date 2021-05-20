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

        private void CloseMdiChildIdExists()
        {
            if (this.ActiveMdiChild != null) this.ActiveMdiChild.Close();
        }

        private void AdminDispoChanger(string dispo)
        {
            try
            {
                SqlCommand sqlCommandDispo = new SqlCommand("update Admin set AdmDispo = @dispo where AdmEmail = @email", GADJIT.sqlConnection);
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

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            //AdminDispoChanger("En Ligne");
            //
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.CenterToScreen();
            PanelStatistics.Visible = false;
            PanelGadgetManagment.Visible = false;
        }

        private void ButtonDisponibility_Click(object sender, EventArgs e)
        {
            if (ButtonDisponibility.BackColor == Color.Lime)
            {
                AdminDispoChanger("Break");
                ButtonDisponibility.BackColor = Color.Orange;
            }
            else if (ButtonDisponibility.BackColor == Color.Orange)
            {
                AdminDispoChanger("En Ligne");
                ButtonDisponibility.BackColor = Color.Lime;
            }
        }

        private void PictureBoxLogOut_Click(object sender, EventArgs e)
        {
            AdminDispoChanger("Hors Ligne");
            this.Close();
            login.Show();
        }

        private void ButtonStatisticsMenu_Click(object sender, EventArgs e)
        {
            PanelStatistics.Visible = true;
            PanelGadgetManagment.Visible = false;
        }

        private void ButtonGadgetMenu_Click(object sender, EventArgs e)
        {
            PanelStatistics.Visible = false;
            PanelGadgetManagment.Visible = true;
        }

        private void ButtonStaffManagment_Click(object sender, EventArgs e)
        {
            CloseMdiChildIdExists();
            PanelStatistics.Visible = false;
            PanelGadgetManagment.Visible = false;
            StaffManagment staffManage = new StaffManagment();
            staffManage.MdiParent = this;
            staffManage.Dock = DockStyle.Fill;
            staffManage.Show();
        }

        private void ButtonWorkerManagment_Click(object sender, EventArgs e)
        {
            CloseMdiChildIdExists();
            PanelStatistics.Visible = false;
            PanelGadgetManagment.Visible = false;
            WorkerManagment workerManage = new WorkerManagment();
            workerManage.MdiParent = this;
            workerManage.Dock = DockStyle.Fill;
            workerManage.Show();
        }

        private void ButtonGadgetCategoryBrandManagment_Click(object sender, EventArgs e)
        {
            CloseMdiChildIdExists();
            GadgetCategoryBrandManagment categoryBrandManagment = new GadgetCategoryBrandManagment();
            categoryBrandManagment.MdiParent = this;
            categoryBrandManagment.Dock = DockStyle.Fill;
            categoryBrandManagment.Show();
        }

        private void ButtonGadgetReferenceManagment_Click(object sender, EventArgs e)
        {
            CloseMdiChildIdExists();
            GadgetReferenceManagment referenceManagment = new GadgetReferenceManagment();
            referenceManagment.MdiParent = this;
            referenceManagment.Dock = DockStyle.Fill;
            referenceManagment.Show();
        }

        private void ButtonClientManagment_Click(object sender, EventArgs e)
        {
            CloseMdiChildIdExists();
            PanelStatistics.Visible = false;
            PanelGadgetManagment.Visible = false;
            ClientManagment clientManagment = new ClientManagment();
            clientManagment.MdiParent = this;
            clientManagment.Dock = DockStyle.Fill;
            clientManagment.Show();
        }
    }
}
