using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace RetailClassLibrary
{
    internal static class ReadImages
    {
        internal static HomeImages GetByHomeID(int homeID)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "GetHomeImagesByHomeID";

            //add parameter
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<int>("@homeID", homeID, SqlDbType.Int, 8));

            HomeImages homeImages = new HomeImages();

            //run sql
            DataSet dataSet = dbConnect.GetDataSet(sqlCommand);
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                    homeImages.Add (new Image
                        (
                            (int?)row["HomeImageID"],
                            (string)row["ImageURL"],
                            (RoomType)Enum.Parse(typeof(RoomType), (string)row["ImageLocation"]),
                            (string)row["ImageDescription"],
                            (bool)row["MainImage"]
                        ));
            }
            return homeImages;
        }
    }
}
