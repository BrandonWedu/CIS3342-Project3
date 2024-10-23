﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using System.Data;

namespace RetailClassLibrary
{
    internal static class WriteHome
    {
        internal static int CreateNew(Home home)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "CreateNewHome";

            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<int>("@agentID", (int)home.Agent.AgentID, SqlDbType.Int, 8));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<byte[]>("@homeAddress", Serializer.SerializeData<Address>(home.Address), SqlDbType.VarBinary, 0));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@propertyType", home.PropertyType.ToString(), SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<int>("@homeSize", home.HomeSize, SqlDbType.Int, 8));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<int>("@constructionYear", home.YearConstructed, SqlDbType.Int, 8));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@garageType", home.GarageType.ToString(), SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@homeDescription", home.Description, SqlDbType.VarChar, 0));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<DateTime>("@dateListed", home.DateListed, SqlDbType.DateTime));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@homeStatus", home.SaleStatus.ToString(), SqlDbType.VarChar, 50));

            //add Output Param
            SqlParameter outputParam = DBParameterHelper.OutputParameter("@homeID", SqlDbType.Int, 8);
            sqlCommand.Parameters.Add(outputParam);
            //Excecute sql
            dbConnect.DoUpdate(sqlCommand);
            return (int)outputParam.Value;
        }
    }
}
