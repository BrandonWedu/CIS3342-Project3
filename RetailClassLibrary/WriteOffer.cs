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
    internal static class WriteOffer
    {
        internal static int CreateNew(Offer offer)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "CreateNewOffer";

            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@firstName", offer.Client.FirstName, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@lastName", offer.Client.LastName, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<byte[]>("@clientAddress", Serializer.SerializeData<Address>(offer.Client.Address), SqlDbType.VarBinary));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@clientPhoneNumber", offer.Client.PhoneNumber, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@clientEmail", offer.Client.Email, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<int>("@homeID", (int)offer.Home.HomeID, SqlDbType.Int, 8));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<DateTime>("@offerCreated", offer.OfferCreated, SqlDbType.DateTime));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<int>("@amount", (int)offer.Amount, SqlDbType.Int, 8));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@offerType", offer.Type.ToString(), SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<bool>("@sellPriorHomeFirst", offer.SellPriorHomeFirst, SqlDbType.Bit));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<DateTime>("@moveInByDate", offer.MoveInByDate, SqlDbType.DateTime));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@offerStatus", offer.Status.ToString(), SqlDbType.VarChar, 50));
            //add Output Param
            SqlParameter outputParam = DBParameterHelper.OutputParameter("@offerID", SqlDbType.Int, 8);
            sqlCommand.Parameters.Add(outputParam);
            //Excecute sql
            dbConnect.DoUpdate(sqlCommand);
            return (int)outputParam.Value;
        }
    }
}
