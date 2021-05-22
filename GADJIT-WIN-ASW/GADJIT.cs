using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;

namespace GADJIT_WIN_ASW
{
    static class GADJIT
    {
        public static SqlConnection sqlConnection = new SqlConnection(@"Server=pff-win-app.database.windows.net; Database=GADJIT; User Id=gadjit_basic; Password=cz3l@K$H%!W2;");

        public static string IDGenerator(string id)
        {
            String code = Regex.Match(id, @"^\D+").ToString();
            String num = Regex.Match(id, @"\d+$").ToString();

            return code + (int.Parse(num) + 1).ToString();
        }

        public static bool IsCINValid(string cin)
        {
            if (Regex.IsMatch(cin, @"^[A-Z]{1,2}\d{6}$"))
            {
                return true;
            }
            return false;
        }

        public static bool IsEmailValid(string email)
        {
            if (Regex.IsMatch(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                return true;
            }
            return false;
        }

        public static bool IsSalaryValid(string salary)
        {
            if(Regex.IsMatch(salary, @"^\d+(\.\d+)?$"))
            {
                return true;
            }
            return false;
        }

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
                "Compte GADJIT",
                "Bonjour:\n\n" + msg + "\n\nGADJIT MAROC.");
            smtp.Send(mail);
        }
    }
}
