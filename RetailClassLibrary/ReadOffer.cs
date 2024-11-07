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
    internal static class ReadOffer
    {
        internal static Offers GetOffers()
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "GetShowings";

            DataSet dataSet = dbConnect.GetDataSet(sqlCommand);
            Showings showings = new Showings();

            Offers offers = new Offers();

            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow row in dataSet.Tables[0].Rows)
                {
                    int offerID = (int)row["OfferID"];
                    offers.Add(new Offer
                    (
                        offerID,
                        ReadHome.GetHomeByID((int)row["HomeID"]),
                        ReadClient.GetClientByID((int)row["ClientID"]),
                        (DateTime)row["OfferCreated"],
                        (int)row["Amount"],
                        (TypeOfSale)Enum.Parse(typeof(TypeOfSale), (string)row["OfferType"]),
                        (bool)row["SellPriorHomeFirst"],
                        (DateTime)row["MoveInByDate"],
                        (OfferStatus)Enum.Parse(typeof(OfferStatus), (string)row["OfferStatus"]),
                        ReadContingency.GetByOfferID(offerID)
                    )) ;
                }
            }
            return offers;
        }
        internal static Offers GetOffersByAgentID(int agentID)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "GetOffersByAgentID";

            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<int>("@agentID", agentID, SqlDbType.Int, 8));

            DataSet dataSet = dbConnect.GetDataSet(sqlCommand);
            Offers offers = new Offers();

            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    int offerID = (int)row["OfferID"];
                    offers.Add(new Offer
                    (
                        offerID,
                        ReadHome.GetHomeByID((int)row["HomeID"]),
                        ReadClient.GetClientByID((int)row["ClientID"]),
                        (DateTime)row["OfferCreated"],
                        (int)row["Amount"],
                        (TypeOfSale)Enum.Parse(typeof(TypeOfSale), (string)row["OfferType"]),
                        (bool)row["SellPriorHomeFirst"],
                        (DateTime)row["MoveInByDate"],
                        (OfferStatus)Enum.Parse(typeof(OfferStatus), (string)row["OfferStatus"]),
                        ReadContingency.GetByOfferID(offerID)
                    ));
                }
            }
            return offers;
        }
    }
}
