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

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            AdminDispo("En Ligne");
            //
            PanelStatistics.Visible = false;
            PanelGadgetManagment.Visible = false;
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
            this.Size = new Size(1575, 690);
            StaffManagment staffManage = new StaffManagment();
            staffManage.MdiParent = this;
            staffManage.Dock = DockStyle.Fill;
            staffManage.Show();
        }

        private void ButtonWorkerManagment_Click(object sender, EventArgs e)
        {
            CloseMdiChildIdExists();
            this.Size = new Size(1675, 685);
            WorkerManagment workerManage = new WorkerManagment();
            workerManage.MdiParent = this;
            workerManage.Dock = DockStyle.Fill;
            workerManage.Show();
        }

        private void AdminDispo(string dispo)
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

        private void ButtonDisponibility_Click(object sender, EventArgs e)
        {
            if (ButtonDisponibility.BackColor == Color.Lime)
            {
                AdminDispo("Break");
                ButtonDisponibility.BackColor = Color.Orange;
            }
            else if (ButtonDisponibility.BackColor == Color.Orange)
            {
                AdminDispo("En Ligne");
                ButtonDisponibility.BackColor = Color.Lime;
            }
        }

        private void PictureBoxLogOut_Click(object sender, EventArgs e)
        {
            AdminDispo("Hors Ligne");
            this.Close();
            login.Show();
        }
    }
}
