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
    internal static class ReadAmenities
    {
        internal static HomeAmenities GetByHomeID(int homeID)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "GetAmenityByHomeID";

            //add parameter
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<int>("@homeID", homeID, SqlDbType.Int, 8));

            HomeAmenities homeAmenities = new HomeAmenities();

            //run sql
            DataSet dataSet = dbConnect.GetDataSet(sqlCommand);
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                    homeAmenities.Add (new Amenity
                        (
                            (int?)row["AmenityID"],
                            (AmenityType)Enum.Parse(typeof(AmenityType), (string)row["AmenityType"]),
                            (string)row["AmenityDescription"]
                        ));
            }
            return homeAmenities;
        }
    }
}
