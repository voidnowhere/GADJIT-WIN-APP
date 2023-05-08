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
        public static SqlConnection sqlConnection = new SqlConnection(@"Server=localhost; Database=GADJIT; Trusted_Connection=True;");

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

        public static string PasswordGenerator(int length)
        {
            Random random = new Random();
            string passChar = "abcdefghijklmnopqursuvwxyz" + "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + "0123456789";
            StringBuilder pass = new StringBuilder();
            while(0 < length--)
            {
                pass.Append(passChar[random.Next(passChar.Length)]);
            }
            return pass.ToString();
        }
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
                "Compte GADJIT",
                "Bonjour:\n\n" + msg + "\n\nGADJIT MAROC.");
            smtp.Send(mail);
        }
    }
}
