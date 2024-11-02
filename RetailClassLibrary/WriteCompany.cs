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
    internal static class WriteCompany
    {
        internal static int CreateNew(Company company)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "CreateNewCompany";

            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@companyName", company.Name, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<byte[]>("@companyAddress", Serializer.SerializeData<Address>(company.Address), SqlDbType.VarBinary, 0));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@companyPhoneNumber", company.PhoneNumber, SqlDbType.VarChar, 50));
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@companyEmail", company.Email, SqlDbType.VarChar, 50));

            //add Output Param
            SqlParameter outputParam = DBParameterHelper.OutputParameter("@companyID", SqlDbType.Int, 8);
            sqlCommand.Parameters.Add(outputParam);
            //Excecute sql
            dbConnect.DoUpdate(sqlCommand);
            return (int)outputParam.Value;
        }
    }
}
