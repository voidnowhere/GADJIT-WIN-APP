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
        string emailtemp = "";
        int TMID ;
        private void PictureBoxExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DiagnosticTicketForClient_Load(object sender, EventArgs e)
        {
            emailtemp = Login.Cemail;
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
            SqlCommand cmd = new SqlCommand("update Ticket set TicSta = 'DV' where TicID=@TID", GADJIT.sqlConnection);
            cmd.Parameters.AddWithValue("@TID", ConsultationTicketForClient.TID);
            GADJIT.sqlConnection.Open();
            cmd.ExecuteNonQuery();
            GADJIT.sqlConnection.Close();
            MessageBox.Show("Ticket Accepter!!", "Ticket Accepter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("GADJITMA@gmail.com", "GADJIT2021");
            MailMessage msg = new MailMessage();
            msg.To.Add(emailtemp);
            msg.From = new MailAddress("GADJITMA@gmail.com");
            msg.Subject = "Acceptation Ticket chez GADJIT";
            msg.Body = "Bonjour:\n \n Votre Ticket a été Accepté.\n Merci pour votre confiance. \n reparation en cours.\n \nGADJIT MAROC.";
            client.Send(msg);
            cmd = new SqlCommand("insert into TicketMonitoring values (@TID,GETDATE(),'Diagnostic Accepter','C',@CID,1)", GADJIT.sqlConnection);
            TicketMonitoringID();
            cmd.Parameters.AddWithValue("@TID", TMID);
            cmd.Parameters.AddWithValue("@CID", ConsultationTicketForClient.CID);
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
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("GADJITMA@gmail.com", "GADJIT2021");
            MailMessage msg = new MailMessage();
            msg.To.Add(emailtemp);
            msg.From = new MailAddress("GADJITMA@gmail.com");
            msg.Subject = "Annulation ticket chez GADJIT";
            msg.Body = "Bonjour:\n \n Votre Ticket a été Annuler.\n Merci de nous envoyer votre feedback sur la cause d'annulation de ticket pour améliorer notre service.\n \nGADJIT MAROC.";
            client.Send(msg);
            cmd = new SqlCommand("insert into TicketMonitoring values (@TID,GETDATE(),'Diagnostic Annuler','C',@CID,1)", GADJIT.sqlConnection);
            TicketMonitoringID();
            cmd.Parameters.AddWithValue("@TID", TMID);
            cmd.Parameters.AddWithValue("@CID", ConsultationTicketForClient.CID);
            GADJIT.sqlConnection.Open();
            cmd.ExecuteNonQuery();
            GADJIT.sqlConnection.Close();
            this.Close();
        }
        private void TicketMonitoringID()
        {
            SqlCommand cmd = new SqlCommand("select max(TicID) from TicketMonitoring", GADJIT.sqlConnection);
            GADJIT.sqlConnection.Open();
            TMID = (int)cmd.ExecuteScalar();
            GADJIT.sqlConnection.Close();
        }
    }
}
