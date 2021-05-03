using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADJIT_WIN_ASW
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void CloseMdiChildIdExists()
        {
            if (this.ActiveMdiChild != null) this.ActiveMdiChild.Close();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {

        }

        private void ButtonStaffManagment_Click(object sender, EventArgs e)
        {
            CloseMdiChildIdExists();
            this.Size = new Size(1600, 650);
            GestionStaff gestionStaff = new GestionStaff();
            gestionStaff.MdiParent = this;
            gestionStaff.Dock = DockStyle.Fill;
            gestionStaff.Show();
        }
    }
}
