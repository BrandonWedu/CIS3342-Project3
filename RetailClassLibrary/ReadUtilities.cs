﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace RetailClassLibrary
{
    internal static class ReadUtilities
    {
        internal static HomeUtilities GetByHomeID(int homeID)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "GetUtilityByHomeID";

            //add parameter
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<int>("@homeID", homeID, SqlDbType.Int, 8));

            HomeUtilities homeUtilities = new HomeUtilities();

            //run sql
            DataSet dataSet = dbConnect.GetDataSet(sqlCommand);
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                    homeUtilities.Add (new Utility
                        (
                            (int?)row["UtilityId"],
                            (UtilityTypes)Enum.Parse(typeof(UtilityTypes), (string)row["UtilityType"]),
                            (string)row["UtilityInformation"]
                        ));
            }
            return homeUtilities;
        }
    }
}