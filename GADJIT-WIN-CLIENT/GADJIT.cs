using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GADJIT_WIN_CLIENT
{
    class GADJIT
    {
        public static SqlConnection sqlConnection = new SqlConnection(@"Server=.\SQLEXPRESS; Database=GADJIT; User Id=gadjit_basic; Password=g_2021;");
    }
}
