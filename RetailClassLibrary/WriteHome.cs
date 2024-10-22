using System;
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
        internal static bool CreateNewHome(Home home)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "CreateNewHome";

            sqlCommand.Parameters.Add(DBHelper.InputParameter<int>("@agentID", (int)home.Agent.AgentID, SqlDbType.Int, 8));
            sqlCommand.Parameters.Add(DBHelper.InputParameter<byte[]>("@homeAddress", Serializer.SerializeData<Address>(home.Address), SqlDbType.VarBinary, 0));
            sqlCommand.Parameters.Add(DBHelper.InputParameter<string>("@propertyType", home.PropertyType.ToString(), SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBHelper.InputParameter<int>("@homeSize", home.HomeSize, SqlDbType.Int, 8));
            sqlCommand.Parameters.Add(DBHelper.InputParameter<int>("@constructionYear", home.YearConstructed, SqlDbType.Int, 8));
            sqlCommand.Parameters.Add(DBHelper.InputParameter<string>("@garageType", home.GarageType.ToString(), SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBHelper.InputParameter<string>("@homeDescription", home.Description, SqlDbType.VarChar, 0));
            sqlCommand.Parameters.Add(DBHelper.InputParameter<DateTime>("@dateListed", home.DateListed, SqlDbType.DateTime));
            sqlCommand.Parameters.Add(DBHelper.InputParameter<string>("@homeStatus", home.SaleStatus.ToString(), SqlDbType.VarChar, 50));

            //add Output Param
            SqlParameter outputParam = DBHelper.OutputParameter("@homeID", SqlDbType.Int, 8);
            sqlCommand.Parameters.Add(outputParam);
            //Excecute sql
            dbConnect.DoUpdate(sqlCommand);
            if ((int)outputParam.Value > -1)
            {
                //set home id
                home.HomeID = (int)outputParam.Value;
                //Return true if creation is sucessful
                return true;
            }
            //return false if creation is unsucessful
            return false; 
        }
    }
}
