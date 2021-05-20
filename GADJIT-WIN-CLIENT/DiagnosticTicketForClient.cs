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

namespace GADJIT_WIN_CLIENT
{
    public partial class DiagnosticTicketForClient : Form
    {
        public DiagnosticTicketForClient()
        {
            InitializeComponent();
        }

        private void PictureBoxExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DiagnosticTicketForClient_Load(object sender, EventArgs e)
        {
            TextBoxCatDiag.Text = ConsultationTicketForClient.Cat;
            TextBoxMarDiag.Text = ConsultationTicketForClient.Cat;
            TextBoxRefDiag.Text = ConsultationTicketForClient.Ref;
            RichtextBoxProbDiag.Text = ConsultationTicketForClient.prob;
            TextBoxPrice.Text = ConsultationTicketForClient.price;
            SqlCommand cmd = new SqlCommand("select DiagCom from Diagnostic where TicID=@TID", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@TID", ConsultationTicketForClient.TID);
            GADJIT.sqlConnection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                RichTextBoxDiag.Text = dr["DiagCom"].ToString();
                dr.Close();
            }
            GADJIT.sqlConnection.Close();
        }

        private void ButtonAccepter_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Ticket set TicSta = 'validé' where TicID=@TID", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@TID", ConsultationTicketForClient.TID);
            GADJIT.sqlConnection.Open();
            cmd.ExecuteNonQuery();
            GADJIT.sqlConnection.Close();
            MessageBox.Show("Ticket Accepter , merci pour votre confiance reparation en cours ", "Ticket Accepter",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void ButtonRejeter_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Ticket set TicSta = 'Annulé' where TicID=@TID", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@TID", ConsultationTicketForClient.TID);
            GADJIT.sqlConnection.Open();
            cmd.ExecuteNonQuery();
            GADJIT.sqlConnection.Close();
            MessageBox.Show("Ticket Annuler , on vous contactera pour livre votre Gadget dans le plus bref délais  ", "Ticket Annuler", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
