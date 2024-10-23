using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace RetailClassLibrary
{
    internal static class WriteUtility
    {
        internal static int CreateNew(int homeID, Utility utility)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "CreateNewUtility";

            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<int>("@homeID", (int)homeID, SqlDbType.Int, 8));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@utilityType", utility.Type.ToString(), SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@utilityInformation", utility.Information, SqlDbType.VarChar, 0));

            SqlParameter outputParam = DBParameterHelper.OutputParameter("@utilityID", SqlDbType.Int, 8);
            sqlCommand.Parameters.Add(outputParam);

            return (int)outputParam.Value;
        }
    }
}
