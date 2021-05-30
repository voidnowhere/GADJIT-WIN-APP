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
    public partial class TicketCancellationReason : Form
    {
        public TicketCancellationReason()
        {
            InitializeComponent();
        }

        public StaffTicketVerification staffTicketVerification;
        public StaffTicketProgression staffTicketProgression;

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if(RichTextBoxDescription.Text != "")
            {
                if (MessageBox.Show("Voulez-vous confirmer l'annulation ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (staffTicketVerification != null)
                    {
                        staffTicketVerification.isTicCanceled = true;
                        staffTicketVerification.ticCancelDes = RichTextBoxDescription.Text;
                    }
                    else if (staffTicketProgression != null)
                    {
                        staffTicketProgression.isTicCanceled = true;
                        staffTicketProgression.ticCancelDes = RichTextBoxDescription.Text;
                    }
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Veuillez remplir l'observation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            if (staffTicketVerification != null)
            {
                staffTicketVerification.isTicCanceled = false;
            }
            else if (staffTicketProgression != null)
            {
                staffTicketProgression.isTicCanceled = false;
            }
            this.Close();
        }

        private void TicketCancellationReason_Load(object sender, EventArgs e)
        {

        }
    }
}
