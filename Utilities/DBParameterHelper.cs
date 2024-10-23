﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Utilities
{
    public static class DBParameterHelper
    {
        public static SqlParameter InputParameter<T>(string parameter, T value, SqlDbType type, int size)
        {
            SqlParameter inputParameter = new SqlParameter(parameter, type, size);
            inputParameter.Value = value;
            inputParameter.Direction = ParameterDirection.Input;
            return inputParameter;
        }
        public static SqlParameter InputParameter<T>(string parameter, T value, SqlDbType type)
        {
            SqlParameter inputParameter = new SqlParameter(parameter, type);
            inputParameter.Value = value;
            inputParameter.Direction = ParameterDirection.Input;
            return inputParameter;
        }
        public static SqlParameter OutputParameter(string parameter, SqlDbType type, int size)
        {
            SqlParameter outputParameter = new SqlParameter(parameter, type, size);
            outputParameter.Direction = ParameterDirection.Output;
            return outputParameter;
        }
    }
}