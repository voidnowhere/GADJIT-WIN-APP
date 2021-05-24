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
            hidemessage();
            CreationTicket creationTicket = new CreationTicket();
            creationTicket.MdiParent = this;
            creationTicket.Dock = DockStyle.Fill;
            creationTicket.Show();
        }

        private void HOME_Load(object sender, EventArgs e)
        {
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.CenterToScreen();
            if (label1.Visible == false && richTextBox1.Visible == false)
            {
                label1.Visible = true;
                richTextBox1.Visible = true;
            }
        }

        private void ButtonConsultationTicket_Click(object sender, EventArgs e)
        {
            CloseMdiChildIdExists();
            hidemessage();
            ConsultationTicketForClient consultationTicket = new ConsultationTicketForClient();
            consultationTicket.MdiParent = this;
            consultationTicket.Dock = DockStyle.Fill;
            consultationTicket.Show();
        }

        private void ButtonProfil_Click(object sender, EventArgs e)
        {
            CloseMdiChildIdExists();
            hidemessage();
            ClientInformation clientinfo = new ClientInformation();
            clientinfo.MdiParent = this;
            clientinfo.Dock = DockStyle.Fill;
            clientinfo.Show();
        }
         private void hidemessage()
         {
            if(label1.Visible == true && richTextBox1.Visible == true)
            {
                label1.Visible = false;
                richTextBox1.Visible = false;
            }
         }
    }
}
