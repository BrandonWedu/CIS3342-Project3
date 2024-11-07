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
    internal static class ReadShowing
    {
        internal static Showings GetShowings()
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "GetShowings";

            DataSet dataSet = dbConnect.GetDataSet(sqlCommand);
            Showings showings = new Showings();

            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow row in dataSet.Tables[0].Rows)
                {
                    int showingID = (int)row["ShowingID"];
                    showings.Add(new Showing
                    (
                        showingID,
                        ReadHome.GetHomeByID((int)row["HomeID"]),
                        ReadClient.GetClientByID((int)row["ClientID"]),
                        (DateTime)row["TimeRequestCreated"],
                        (DateTime)row["ShowingTime"],
                        (ShowingStatus)Enum.Parse(typeof(ShowingStatus), (string)row["ShowingStatus"])
                    ));
                }
            }
            return showings;
        }
        internal static Showings GetShowingsByAgentID(int agentID)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "GetShowingsByAgentID";

            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<int>("@agentID", agentID, SqlDbType.Int, 8));

            DataSet dataSet = dbConnect.GetDataSet(sqlCommand);
            Showings showings = new Showings();

            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow row in dataSet.Tables[0].Rows)
                {
                    showings.Add(new Showing
                    (
                        (int)row["ShowingID"],
                        ReadHome.GetHomeByID((int)row["HomeID"]),
                        ReadClient.GetClientByID((int)row["ClientID"]),
                        (DateTime)row["TimeRequestCreated"],
                        (DateTime)row["ShowingTime"],
                        (ShowingStatus)Enum.Parse(typeof(ShowingStatus), (string)row["ShowingStatus"])
                    ));
                }
            }
            return showings;
        }
    }
}
