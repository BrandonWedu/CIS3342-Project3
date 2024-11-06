using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace RetailClassLibrary
{
    internal static class ReadContingency
    {
        internal static OfferContingencies GetByOfferID(int offerID)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "GetContingencyByOfferID";

            //add parameter
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<int>("@offerID", offerID, SqlDbType.Int, 8));

            OfferContingencies contingencies = new OfferContingencies();

            //run sql
            DataSet dataSet = dbConnect.GetDataSet(sqlCommand);
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                    contingencies.Add (new Contingency
                        (
                            (int?)row["ContingencyID"],
                            (string)row["Description"]
                        ));
            }
            return contingencies;
        }
    }
}
