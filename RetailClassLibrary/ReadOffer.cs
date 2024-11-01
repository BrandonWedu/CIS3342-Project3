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
    internal static class ReadOffer
    {
    // [OfferID]            INT          IDENTITY (1, 1) NOT NULL,
    //[HomeID]             INT          NOT NULL,
    //[ClientID]           INT          NOT NULL,
    //[OfferCreated]       DATETIME     NOT NULL,
    //[Amount]             INT          NOT NULL,
    //[OfferType]          VARCHAR (50) NOT NULL,
    //[SellPriorHomeFirst] BIT          NOT NULL,
    //[MoveInByDate]       DATETIME     NOT NULL,
    //[OfferStatus]        VARCHAR (50) NOT NULL,
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
    }
}
