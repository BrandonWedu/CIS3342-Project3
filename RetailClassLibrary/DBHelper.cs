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
        internal static SqlParameter InputParameter<T>(string parameter, T value, SqlDbType type, int size)
        {
            SqlParameter inputParameter = new SqlParameter();
            inputParameter.ParameterName = parameter;
            inputParameter.Value = value;
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = type;
            inputParameter.Size = size;
            return inputParameter;
        }
        internal static SqlParameter InputParameter<T>(string parameter, T value, SqlDbType type)
        {
            SqlParameter inputParameter = new SqlParameter();
            inputParameter.ParameterName = parameter;
            inputParameter.Value = value;
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = type;
            return inputParameter;
        }
        internal static SqlParameter OutputParameter(string parameter, SqlDbType type, int size)
        {
            SqlParameter outputParameter = new SqlParameter();
            outputParameter.ParameterName = parameter;
            outputParameter.Direction = ParameterDirection.Output;
            outputParameter.SqlDbType = type;
            outputParameter.Size = size;
            return outputParameter;
        }
    }
}
