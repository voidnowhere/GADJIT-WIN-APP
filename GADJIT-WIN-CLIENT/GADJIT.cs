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
        public static SqlConnection sqlConnection = new SqlConnection(@"Server=pff-win-app.database.windows.net; Database=GADJIT; User Id=gadjit_basic; Password=cz3l@K$H%!W2;");
    }
}
