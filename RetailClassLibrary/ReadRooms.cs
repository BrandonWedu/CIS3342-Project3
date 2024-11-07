using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace RealEstateClassLibrary
{
    internal static class ReadRooms
    {
        internal static HomeRooms GetByHomeID(int homeID)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "GetRoomByHomeID";

            //add parameter
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<int>("@homeID", homeID, SqlDbType.Int, 8));

            HomeRooms homeRooms = new HomeRooms();

            //run sql
            DataSet dataSet = dbConnect.GetDataSet(sqlCommand);
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                    homeRooms.Add (new Room
                        (
                            (int?)row["RoomID"],
                            (RoomType)Enum.Parse(typeof(RoomType), (string)row["RoomType"]),
                            (int)row["Height"],
                            (int)row["Width"]
                        ));
            }
            return homeRooms;
        }
    }
}
