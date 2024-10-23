﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace RetailClassLibrary
{
    internal static class WriteHomeImage
    {
        internal static int CreateNew(int homeID, Image homeImage)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "CreateNewHomeImage";

            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<int>("@homeID", (int)homeID, SqlDbType.Int, 8));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@imageURL", homeImage.Url, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@imageLocation", homeImage.Url, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@imageDescription", homeImage.Url, SqlDbType.VarChar, 0));

            SqlParameter outputParam = DBParameterHelper.OutputParameter("@imageID", SqlDbType.Int, 8);
            sqlCommand.Parameters.Add(outputParam);

            return (int)outputParam.Value;
        }
    }
}
