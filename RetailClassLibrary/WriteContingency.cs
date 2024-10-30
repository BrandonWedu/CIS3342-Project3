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
    internal static class WriteContingency
    {
        internal static bool CreateNew(int offerID, Contingency contingency)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "CreateNewContingency";

            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<int>("@offerID", offerID, SqlDbType.Int, 8));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@description", contingency.Description, SqlDbType.VarChar));

            SqlParameter outputParam = DBParameterHelper.OutputParameter("@contingencyID", SqlDbType.Int, 8);
            sqlCommand.Parameters.Add(outputParam);

            dbConnect.DoUpdate(sqlCommand);
            return (int)outputParam.Value > 1;

        }
    }
}
