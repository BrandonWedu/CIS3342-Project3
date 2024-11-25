﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Utilities;

namespace RealEstateClassLibrary
{
    internal static class ReadAgent 
    {
        internal static int Login(string username, string password)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "AgentLogin";

            //add parameters
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@username", username, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@password", password, SqlDbType.VarChar, 50));

            //add Output Param
            SqlParameter outputParam = DBParameterHelper.OutputParameter("@agentID", SqlDbType.Int, 8);
            sqlCommand.Parameters.Add(outputParam);

            //Excecute scalar function
            object statusCode = dbConnect.GetDataSet(sqlCommand);
            
            // agentID if login successful
            // -1 if login unsucessful
            return (int)outputParam.Value;
        }

        internal static Agent GetAgentByUsername(string username)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "GetAgentByUsername";

            //add parameter
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@agentUsername", username, SqlDbType.VarChar, 50));

            //run sql
            DataSet dataSet = dbConnect.GetDataSet(sqlCommand);
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];
                return
                    new Agent
                    (
                        (int)row["AgentID"],
                        new LoginData((string)row["AgentUsername"], (string)row["AgentPassword"]),
                        Serializer.DeserializeData<Address>((byte[])row["WorkAddress"]),
                        (string)row["WorkPhoneNumber"],
                        (string)row["WorkEmail"],
                        new Company((int?)row["CompanyID"], (string)row["CompanyName"], Serializer.DeserializeData<Address>((byte[])row["CompanyAddress"]), (string)row["CompanyPhoneNumber"], (string)row["CompanyEmail"]),
                        (string)row["FirstName"],
                        (string)row["LastName"],
                        Serializer.DeserializeData<Address>((byte[])row["PersonalAddress"]),
                        (string)row["PersonalPhoneNumber"],
                        (string)row["PersonalEmail"]
                    );
            } else
            {
                //return null if id does not exist
                return null;
            }
        }

        //Generate Agent Object by ID
        internal static Agent GetAgentByID(int agentID) 
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "GetAgentByID";

            //add parameter
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<int>("@agentID", agentID, SqlDbType.Int, 8));

            //run sql
            DataSet dataSet = dbConnect.GetDataSet(sqlCommand);
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];
                return
                    new Agent
                    (
                        (int)row["AgentID"],
                        new LoginData((string)row["AgentUsername"], (string)row["AgentPassword"]),
                        Serializer.DeserializeData<Address>((byte[])row["WorkAddress"]),
                        (string)row["WorkPhoneNumber"],
                        (string)row["WorkEmail"],
                        new Company((int?)row["CompanyID"], (string)row["CompanyName"], Serializer.DeserializeData<Address>((byte[])row["CompanyAddress"]), (string)row["CompanyPhoneNumber"], (string)row["CompanyEmail"]),
                        (string)row["FirstName"],
                        (string)row["LastName"],
                        Serializer.DeserializeData<Address>((byte[])row["PersonalAddress"]),
                        (string)row["PersonalPhoneNumber"],
                        (string)row["PersonalEmail"]
                    );
            } else
            {
                //return null if id does not exist
                return null;
            }
        }

    }
}
