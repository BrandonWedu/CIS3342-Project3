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
    internal static class WriteAgent
    {
        //Create new agent
        internal static int CreateNew(Agent agent)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "CreateNewAgent";

            //add parameters
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<int>("@companyID", (int)agent.Company.CompanyID, SqlDbType.Int, 8));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@username", agent.LoginData.Username, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@password", agent.LoginData.Password, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@firstName", agent.FirstName, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@lastName", agent.LastName, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<byte[]>("@personalAddress", Serializer.SerializeData<Address>(agent.Address), SqlDbType.VarBinary, 0));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@personalPhoneNumber", agent.PhoneNumber, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@personalEmail", agent.Email, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<byte[]>("@workAddress", Serializer.SerializeData<Address>(agent.WorkAddress), SqlDbType.VarBinary, 0));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@workPhoneNumber", agent.WorkPhoneNumber, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@workEmail", agent.WorkEmail, SqlDbType.VarChar, 50));
            //add Output Param
            SqlParameter outputParam = DBParameterHelper.OutputParameter("@agentID", SqlDbType.Int, 8);
            sqlCommand.Parameters.Add(outputParam);
            //Excecute sql
            dbConnect.DoUpdate(sqlCommand);
            //return -1 if unsuccessful
            return (int)outputParam.Value;
        }
    }
}
