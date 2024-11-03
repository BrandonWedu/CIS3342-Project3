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
    internal static class ReadCompany
    {
        internal static Company GetByCompanyID(int companyID)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "GetCompanyByCompanyID";

            //add parameter
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<int>("@companyID", companyID, SqlDbType.Int, 8));

            //run sql
            DataSet dataSet = dbConnect.GetDataSet(sqlCommand);
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];
                return new Company
                        (
                            (int?)row["CompanyID"],
                            (string)row["CompanyName"],
                            Serializer.DeserializeData<Address>((byte[])row["CompanyAddress"]),
                            (string)row["CompanyPhoneNumber"],
                            (string)row["CompanyEmail"]
                        );
            }
            return null;
        }
        internal static Company GetByCompanyName(string companyName)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "GetCompanyByCompanyName";

            //add parameter
            sqlCommand.Parameters.Add(DBParameterHelper.InputParameter<string>("@companyName", companyName, SqlDbType.VarChar, 50));

            //run sql
            DataSet dataSet = dbConnect.GetDataSet(sqlCommand);
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];
                return new Company
                        (
                            (int?)row["CompanyID"],
                            (string)row["CompanyName"],
                            Serializer.DeserializeData<Address>((byte[])row["CompanyAddress"]),
                            (string)row["CompanyPhoneNumber"],
                            (string)row["CompanyEmail"]
                        );
            }
            return null;
        }

        internal static Companies GetCompanies()
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "GetCompanies";

            Companies companies = new Companies();  

            DataSet dataSet = dbConnect.GetDataSet(sqlCommand);
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                    companies.Add (new Company
                        (
                            (int?)row["CompanyID"],
                            (string)row["CompanyName"],
                            Serializer.DeserializeData<Address>((byte[])row["CompanyAddress"]),
                            (string)row["CompanyPhoneNumber"],
                            (string)row["CompanyEmail"]
                        ));
            }
            return companies;
        }
    }
}
