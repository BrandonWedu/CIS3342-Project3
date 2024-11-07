using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace RealEstateClassLibrary
{
    internal static class WriteShowing
    {
        internal static int CreateNew(Showing showing)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "CreateNewShowing";

            //add parameters
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@firstName", showing.Client.FirstName, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@lastName", showing.Client.LastName, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<byte[]>("@clientAddress", Serializer.SerializeData<Address>(showing.Client.Address), SqlDbType.VarBinary));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@clientPhoneNumber", showing.Client.PhoneNumber, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@clientEmail", showing.Client.Email, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<int>("@homeID", (int)showing.Home.HomeID, SqlDbType.Int, 8));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<DateTime>("@timeRequestCreated", showing.TimeRequestCreated, SqlDbType.DateTime));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<DateTime>("@showingTime", showing.ShowingTime, SqlDbType.DateTime));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@showingStatus", showing.Status.ToString(), SqlDbType.VarChar, 50));

            //add Output Param
            SqlParameter outputParam = DBParameterHelper.OutputParameter("@showingID", SqlDbType.Int, 8);
            sqlCommand.Parameters.Add(outputParam);
            //Excecute sql
            dbConnect.DoUpdate(sqlCommand);
            //return -1 if unsuccessful
            return (int)outputParam.Value;
        }
        internal static bool UpdateStatus(Showing showing)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "UpdateShowingStatus";


            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<int>("@showingID", (int)showing.ShowingID, SqlDbType.Int, 8));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@showingStatus", showing.Status.ToString(), SqlDbType.VarChar, 50));

            //add Output Param
            SqlParameter outputParam = DBParameterHelper.OutputParameter("@statusCode", SqlDbType.Int, 8);
            sqlCommand.Parameters.Add(outputParam);
            //Excecute sql
            dbConnect.DoUpdate(sqlCommand);
            //return -1 if unsuccessful
            return (int)outputParam.Value > -1;
        }
    }
}
