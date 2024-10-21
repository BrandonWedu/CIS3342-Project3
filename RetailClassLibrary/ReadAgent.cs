using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Utilities;

namespace RetailClassLibrary
{
    internal static class ReadAgent 
    {
        public static (bool, int) Login(string username, string password)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "AgentLogin";

            //add parameters
            sqlCommand.Parameters.Add(DBHelper.InputParameter<string>("@username", username, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBHelper.InputParameter<string>("@password", password, SqlDbType.VarChar, 50));

            //add Output Param
            SqlParameter outputParam = DBHelper.OutputParameter("@agentID", SqlDbType.Int, 8);
            sqlCommand.Parameters.Add(outputParam);

            //Excecute scalar function
            object statusCode = dbConnect.ExecuteScalarFunction(sqlCommand);
            
            // return (true, agentID) if login successful
            // return (false, -1) if login unsucessful
            return ((Convert.ToInt32(statusCode) == 0), (int)outputParam.Value);
        }
    }
}
