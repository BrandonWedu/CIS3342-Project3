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
    internal static class ReadHome
    {
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
                DataRow row = dataSet.Tables[0].Rows[0];
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
                    ReadImage.GetByHomeID(homeID),
                    ReadAmenity.GetByHomeID(homeID),
                    ReadTempatureControl.GetByHomeID(homeID),
                    ReadRoom.GetByHomeID(homeID),
                    ReadUtility.GetByHomeID(homeID)
                ));
            }
            return new Homes();
        }
    }
}
