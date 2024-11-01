using System;
using Utilities;
using System.Data;
using System.Data.SqlClient;


namespace RetailClassLibrary
{
    internal static class ReadHome
    {
        internal static Home GetHomeByID(int homeID)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "GetHomeByID";

            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<int>("@homeID", homeID, SqlDbType.Int, 8));

            DataSet dataSet = dbConnect.GetDataSet(sqlCommand);
            DataRow row = dataSet.Tables[0].Rows[0];
            return new Home
                (
                    homeID,
                    ReadAgent.GetAgentByID((int)row["AgentID"]),
                    (int)row["Cost"],
                    Serializer.DeserializeData<Address>((byte[])row["HomeAddress"]),
                    (PropertyType)Enum.Parse(typeof(PropertyType), (string)row["PropertyType"]),
                    (int)row["ConstructionYear"],
                    (GarageType)Enum.Parse(typeof(GarageType), (string)row["Garage"]),
                    (string)row["HomeDescription"],
                    (DateTime)row["DateListed"],
                    (SaleStatus)Enum.Parse(typeof(SaleStatus), (string)row["SaleStatus"]),
                    ReadImages.GetByHomeID(homeID),
                    ReadAmenities.GetByHomeID(homeID),
                    ReadTemperatureControl.GetByHomeID(homeID),
                    ReadRooms.GetByHomeID(homeID),
                    ReadUtilities.GetByHomeID(homeID)
                );
        }
        internal static Homes GetHomes()
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "GetHomes";

            DataSet dataSet = dbConnect.GetDataSet(sqlCommand);
            Homes homes = new Homes();

            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow row in dataSet.Tables[0].Rows)
                {
                    int homeID = (int)row["HomeID"];
                    homes.Add(new Home
                    (
                        homeID,
                        ReadAgent.GetAgentByID((int)row["AgentID"]),
                        (int)row["Cost"],
                        Serializer.DeserializeData<Address>((byte[])row["HomeAddress"]),
                        (PropertyType)Enum.Parse(typeof(PropertyType), (string)row["PropertyType"]),
                        (int)row["ConstructionYear"],
                        (GarageType)Enum.Parse(typeof(GarageType), (string)row["Garage"]),
                        (string)row["HomeDescription"],
                        (DateTime)row["DateListed"],
                        (SaleStatus)Enum.Parse(typeof(SaleStatus), (string)row["SaleStatus"]),
                        ReadImages.GetByHomeID(homeID),
                        ReadAmenities.GetByHomeID(homeID),
                        ReadTemperatureControl.GetByHomeID(homeID),
                        ReadRooms.GetByHomeID(homeID),
                        ReadUtilities.GetByHomeID(homeID)
                    ));
                }
            }
            return homes;
        }
    }
}
