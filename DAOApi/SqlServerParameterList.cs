using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOApi
{
    public class SqlServerParameterList
    {
        public List<SqlParameter> Parameters { get; set; }

        public SqlServerParameterList()
        {
            Parameters = new List<SqlParameter> { };
        }
    }
}
