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
    internal static class WriteRoom
    {
        internal static int CreateNew(int homeID, Room room)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "CreateNewRoom";

            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<int>("@homeID", (int)homeID, SqlDbType.Int, 8));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@roomType", room.Type.ToString(), SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<int>("@height", room.Height, SqlDbType.Int, 8));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<int>("@width", room.Width, SqlDbType.Int, 8));

            SqlParameter outputParam = DBParameterHelper.OutputParameter("@roomID", SqlDbType.Int, 8);
            sqlCommand.Parameters.Add(outputParam);

            return (int)outputParam.Value;
        }
    }
}
