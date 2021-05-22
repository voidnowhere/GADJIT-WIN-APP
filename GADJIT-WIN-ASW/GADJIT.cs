using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace GADJIT_WIN_ASW
{
    static class GADJIT
    {
        //azure
        public static SqlConnection sqlConnection = new SqlConnection(@"Server=pff-win-app.database.windows.net; Database=GADJIT; User Id=gadjit_basic; Password=cz3l@K$H%!W2;");
        //local
        //public static SqlConnection sqlConnection = new SqlConnection(@".\SQLEXPRESS; Database=GADJIT; Integrated Security=true");

        public static string IDGenerator(string id)
        {
            String code = Regex.Match(id, @"^\D+").ToString();
            String num = Regex.Match(id, @"\d+$").ToString();
            
            return code + ((num == "") ? 0 : int.Parse(num) + 1).ToString();
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
    }
}
