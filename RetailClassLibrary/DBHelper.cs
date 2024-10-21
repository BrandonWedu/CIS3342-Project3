using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace RetailClassLibrary
{
    internal static class DBHelper
    {
        internal static SqlParameter InputParameter(string parameter, object value, SqlDbType type, int size)
        {
            SqlParameter inputParameter = new SqlParameter(parameter, value);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = type;
            inputParameter.Size = size;
            return inputParameter;
        }
    }
}
