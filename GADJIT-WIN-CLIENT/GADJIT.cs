using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;

namespace GADJIT_WIN_CLIENT
{
    class GADJIT
    {
        public static SqlConnection sqlConnection = new SqlConnection(@"Server=localhost; Database=GADJIT; Trusted_Connection=True;");

        public static void SendEmail(string toEmail, string msg)
        {
            string mailHost = "";
            int mailPort = 0;
            string mailUsername = "";
            string mailPassword = "";
            SmtpClient smtp = new SmtpClient(mailHost, mailPort)
            {
                Credentials = new NetworkCredential(mailUsername, mailPassword),
                EnableSsl = true,
            };
            //
            MailMessage mail = new MailMessage(
                "GADJITMA@gmail.com",
                toEmail,
                "GADJIT",
                "Bonjour " + msg + "\n\nGADJIT MAROC.");
            smtp.Send(mail);
        }
    }
}
