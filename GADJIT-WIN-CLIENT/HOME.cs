using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADJIT_WIN_CLIENT
{
    public partial class HOME : Form
    {
        public HOME()
        {
            InitializeComponent();
        }

        private void CloseMdiChildIdExists()
        {
            if (this.ActiveMdiChild != null) this.ActiveMdiChild.Close();
        }

        private void PictureBoxLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBoxExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void ButtonNewTicket_Click(object sender, EventArgs e)
        {
            CloseMdiChildIdExists();
            CreationTicket creationTicket = new CreationTicket();
            creationTicket.MdiParent = this;
            creationTicket.Dock = DockStyle.Fill;
            creationTicket.Show();
        }

        private void HOME_Load(object sender, EventArgs e)
        {

        }

        private void ButtonConsultationTicket_Click(object sender, EventArgs e)
        {
            CloseMdiChildIdExists();
            ConsultationTicketForClient consultationTicket = new ConsultationTicketForClient();
            consultationTicket.MdiParent = this;
            consultationTicket.Dock = DockStyle.Fill;
            consultationTicket.Show();
        }

        private void ButtonProfil_Click(object sender, EventArgs e)
        {
            CloseMdiChildIdExists();
            ClientInformation clientinfo = new ClientInformation();
            clientinfo.MdiParent = this;
            clientinfo.Dock = DockStyle.Fill;
            clientinfo.Show();
        }
    }
}
