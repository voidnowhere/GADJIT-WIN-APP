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
        //Azure
        public static SqlConnection sqlConnection = new SqlConnection(@"Server=pff-win-app.database.windows.net; Database=GADJIT; User Id=gadjit_basic; Password=cz3l@K$H%!W2;");
        //LOCAL
        //public static SqlConnection sqlConnection = new SqlConnection(@"Server=.\SQLEXPRESS; Database=GADJIT; User Id=gadjit_basic; Password=cz3l@K$H%!W2;");

        public static void SendEmail(string toEmail, string msg)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("GADJITMA@gmail.com", "GADJIT2021");
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
