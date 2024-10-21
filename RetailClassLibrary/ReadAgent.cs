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
    internal static class ReadAgent : IReadable<Agent>
    {
        public static Agent GetById(int id)
        {
            throw new NotImplementedException();
        }
        public static Agent GetByUsername(string username)
        {
            
        }
        public static bool Login(string username, string password)
        {
            DBConnect dBConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "AgentLogin";

            //add parameters
            sqlCommand.Parameters.Add(DBHelper.InputParameter("@username", username, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBHelper.InputParameter("@password", password, SqlDbType.VarChar, 50));

            //Excecute scalar function
            object statusCode = dBConnect.ExecuteScalarFunction(sqlCommand);
            
            // return true is login successful 
            return (Convert.ToInt32(statusCode) == 0);
        }
    }
}
