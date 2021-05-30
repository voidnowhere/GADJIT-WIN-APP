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
using System.Net;
using System.Net.Mail;

namespace GADJIT_WIN_CLIENT
{
    public partial class DiagnosticTicketForClient : Form
    {
        public DiagnosticTicketForClient()
        {
            InitializeComponent();
        }
        int TMID ;
        public int CID;
        public string email;
        private void PictureBoxExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DiagnosticTicketForClient_Load(object sender, EventArgs e)
        {
            MessageBox.Show(ConsultationTicketForClient.Ref);
            TextBoxCatDiag.Text = ConsultationTicketForClient.Cat;
            TextBoxMarDiag.Text = ConsultationTicketForClient.Brand;
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
            SqlCommand cmd = new SqlCommand("update Ticket set TicSta = 'DV' where TicID=@TID", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@TID", ConsultationTicketForClient.TID);
            GADJIT.sqlConnection.Open();
            cmd.ExecuteNonQuery();
            GADJIT.sqlConnection.Close();
            MessageBox.Show("Ticket Accepter!!", "Ticket Accepter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GADJIT.SendEmail(email, "\n \n Votre Ticket a été Accepté.\n Merci pour votre confiance. \n reparation en cours.\n \n");
            //
            cmd = new SqlCommand("insert into TicketMonitoring values (@TID,GETDATE(),'diagnostic validé','C',@CID,1)", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@TID", ConsultationTicketForClient.TID);
            cmd.Parameters.AddWithValue("@CID",CID);
            GADJIT.sqlConnection.Open();
            cmd.ExecuteNonQuery();
            GADJIT.sqlConnection.Close();
            this.Close();
        }

        private void ButtonRejeter_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Ticket set TicSta = 'DR' where TicID=@TID", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@TID", ConsultationTicketForClient.TID);
            GADJIT.sqlConnection.Open();
            cmd.ExecuteNonQuery();
            GADJIT.sqlConnection.Close();
            MessageBox.Show("Ticket Annuler , on vous contactera pour livre votre Gadget dans le plus bref délais  ", "Ticket Annuler", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GADJIT.SendEmail(email, "\n \n Votre Ticket a été Accepté.\n Merci pour votre confiance. \n reparation en cours.\n \n");
            //
            cmd = new SqlCommand("insert into TicketMonitoring values (@TID,GETDATE(),'diagnostic rejeté','C',@CID,1)", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@TID", ConsultationTicketForClient.TID);
            cmd.Parameters.AddWithValue("@CID", CID);
            GADJIT.sqlConnection.Open();
            cmd.ExecuteNonQuery();
            GADJIT.sqlConnection.Close();
            this.Close();
        }
        private void getclientemail()
        {
            SqlCommand cmd = new SqlCommand("select CliEmail from Client where CliID=@CID", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@CID", CID);
            GADJIT.sqlConnection.Open();
            email = cmd.ExecuteScalar().ToString();
            GADJIT.sqlConnection.Close();
        }
    }
}
