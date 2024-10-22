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
    internal static class WriteAgent
    {
        //Create new agent
        internal static bool CreateNewAgent(Agent agent)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "CreateNewAgent";

            if (agent.Company.CompanyID == null)
            {
                throw new Exception("Comapny ID NULL");
            }
            //add parameters
            sqlCommand.Parameters.Add(DBHelper.InputParameter<int?>("@companyID", agent.Company.CompanyID, SqlDbType.Int, 8));
            sqlCommand.Parameters.Add(DBHelper.InputParameter<string>("@username", agent.LoginData.Username, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBHelper.InputParameter<string>("@password", agent.LoginData.Password, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBHelper.InputParameter<string>("@firstName", agent.FirstName, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBHelper.InputParameter<string>("@lastName", agent.LastName, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBHelper.InputParameter<byte[]>("@personalAddress", Serializer.SerializeData<Address>(agent.Address), SqlDbType.VarBinary, 0));
            sqlCommand.Parameters.Add(DBHelper.InputParameter<string>("@personalPhoneNumber", agent.PhoneNumber, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBHelper.InputParameter<string>("@personalEmail", agent.Email, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBHelper.InputParameter<byte[]>("@workAddress", Serializer.SerializeData<Address>(agent.WorkAddress), SqlDbType.VarBinary, 0));
            sqlCommand.Parameters.Add(DBHelper.InputParameter<string>("@workPhoneNumber", agent.WorkPhoneNumber, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBHelper.InputParameter<string>("@workEmail", agent.WorkEmail, SqlDbType.VarChar, 50));
            //add Output Param
            SqlParameter outputParam = DBHelper.OutputParameter("@agentID", SqlDbType.Int, 8);
            sqlCommand.Parameters.Add(outputParam);
            //Excecute sql
            dbConnect.DoUpdate(sqlCommand);
            if ((int)outputParam.Value > -1)
            {
                //set agent id
                agent.AgentID = (int)outputParam.Value;
                //Return true if creation is sucessful
                return true;
            }
            //return false if creation is unsucessful
            return false; 
        }
    }
}
