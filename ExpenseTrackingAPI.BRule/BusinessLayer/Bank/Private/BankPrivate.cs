using ExpenseTrackingAPI.BRule.DataLayer;
using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.Bank.Private
{
    public class BankPrivate : IBankPrivate
    {
        private readonly IDataHelper _dataHelper;
        public BankPrivate(IDataHelper dataHelper)
        {
            _dataHelper = dataHelper;
        }
        public List<BankModel> GetAllBankPrivate(SqlConnection sqlConnection)
        {
            List<BankModel> bankModelList = new List<BankModel>();
            try
            {
                StringBuilder sb = GetAllBanksQuery();
                SqlDataReader reader = _dataHelper.ExecuteReader(sb, sqlConnection);

                while (reader.Read())
                {
                    BankModel bankModel = new BankModel();
                    bankModel.BankId = reader["BankID"] != DBNull.Value ? Convert.ToInt32(reader["BankID"]) : 0;
                    bankModel.BankName = reader["BankName"] != DBNull.Value ? reader["BankName"].ToString() : string.Empty;

                    //if (reader["BankLogo"] != DBNull.Value)
                    //{
                    //    byte[] myBytes = (byte[])reader["BankLogo"];
                    //    bankModel.BankLogo = myBytes;
                    //}

                    //bankResponse.BankLogo = reader["BankLogo"] != DBNull.Value ? reader["BankLogo"].ToString() : string.Empty;
                    bankModelList.Add(bankModel);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return bankModelList;
        }

        internal StringBuilder GetAllBanksQuery()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Bank");
            return sb;
        }

        public BankModel GetBankPrivate(SqlConnection sqlConnection, Int32 BankID)
        {
            BankModel bankModel = new BankModel();
            try
            {
                StringBuilder sb = GetBankQuery(BankID);
                SqlDataReader reader = _dataHelper.ExecuteReader(sb, sqlConnection);

                while (reader.Read())
                {
                    bankModel.BankId = reader["BankID"] != DBNull.Value ? Convert.ToInt32(reader["BankID"]) : 0;
                    bankModel.BankName = reader["BankName"] != DBNull.Value ? reader["BankName"].ToString() : string.Empty;

                    if (reader["BankLogo"] != DBNull.Value)
                    {
                        byte[] myBytes = (byte[])reader["BankLogo"];
                        bankModel.BankLogo = myBytes;
                    }

                    //bankResponse.BankLogo = reader["BankLogo"] != DBNull.Value ? reader["BankLogo"].ToString() : string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return bankModel;
        }

        internal StringBuilder GetBankQuery(Int32 BankID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SELECT * FROM Bank where BankID = {0}", BankID);
            return sb;
        }

        public void AddBankPrivate(SqlConnection sqlConnection, BankModel bankModel)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("SP_AddBank", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BankName", bankModel.BankName);
                cmd.Parameters.AddWithValue("@BankLogo", bankModel.BankLogo);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateBankPrivate(SqlConnection sqlConnection, BankModel bankModel)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("SP_UpdateBank", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BankID", bankModel.BankId);
                cmd.Parameters.AddWithValue("@BankName", bankModel.BankName);
                cmd.Parameters.AddWithValue("@BankLogo", bankModel.BankLogo);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteBankPrivate(SqlConnection sqlConnection, Int32 BankID)
        {
            try
            {
                StringBuilder sb = DeleteBankPrivateQuery(BankID);
                SqlDataReader reader = _dataHelper.ExecuteReader(sb, sqlConnection);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sb.ToString();
                cmd.Connection = sqlConnection;
                _dataHelper.ExecuteCommand(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal StringBuilder DeleteBankPrivateQuery(Int32 BankID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("DELETE FROM Bank where BankID = {0}", BankID);
            return sb;
        }
    }
}
