using ExpenseTrackingAPI.BRule.DataLayer;
using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.BankBalance.Private
{
    public class BankBalancePrivate: IBankBalancePrivate
    {
        private readonly IDataHelper _dataHelper;
        public BankBalancePrivate(IDataHelper dataHelper)
        {
            _dataHelper = dataHelper;
        }

        public List<BankBalanceModel> GetAllBankBalancePrivate(SqlConnection sqlConnection, Int32 UserID)
        {
            List<BankBalanceModel> bankBalanceModelList = new List<BankBalanceModel>();
            try
            {
                StringBuilder sb = GetAllBankBalanceQuery(UserID);
                SqlDataReader reader = _dataHelper.ExecuteReader(sb, sqlConnection);

                while (reader.Read())
                {
                    BankBalanceModel bankBalanceModel = new BankBalanceModel();
                    bankBalanceModel.BankBalanceID = reader["BankBalanceID"] != DBNull.Value ? Convert.ToInt32(reader["BankBalanceID"]) : 0;
                    bankBalanceModel.UserID = reader["UserID"] != DBNull.Value ? Convert.ToInt32(reader["UserID"]) : 0;
                    bankBalanceModel.BankID = reader["BankID"] != DBNull.Value ? Convert.ToInt32(reader["BankID"]) : 0;
                    bankBalanceModel.BankAmount = reader["BankAmount"] != DBNull.Value ? Convert.ToDecimal(reader["BankAmount"]) : 0;
                    bankBalanceModelList.Add(bankBalanceModel);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return bankBalanceModelList;
        }

        internal StringBuilder GetAllBankBalanceQuery(Int32 UserID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SELECT * FROM BankBalance where UserID={0}", UserID);
            return sb;
        }

        public BankBalanceModel GetBankBalancePrivate(SqlConnection sqlConnection, Int32 BankID, Int32 UserID)
        {
            BankBalanceModel bankBalanceModel = new BankBalanceModel();
            try
            {
                StringBuilder sb = GetBankBalanceQuery(BankID,UserID);
                SqlDataReader reader = _dataHelper.ExecuteReader(sb, sqlConnection);

                while (reader.Read())
                {
                    bankBalanceModel.BankBalanceID = reader["BankBalanceID"] != DBNull.Value ? Convert.ToInt32(reader["BankBalanceID"]) : 0;
                    bankBalanceModel.UserID = reader["UserID"] != DBNull.Value ? Convert.ToInt32(reader["UserID"]) : 0;
                    bankBalanceModel.BankID = reader["BankID"] != DBNull.Value ? Convert.ToInt32(reader["BankID"]) : 0;
                    bankBalanceModel.BankAmount = reader["BankAmount"] != DBNull.Value ? Convert.ToDecimal(reader["BankAmount"]) : 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return bankBalanceModel;
        }

        internal StringBuilder GetBankBalanceQuery(Int32 BankID,Int32 UserID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SELECT * FROM BankBalance where BankID = {0} And UserID={1}", BankID,UserID);
            return sb;
        }        

        public void AddBankBalancePrivate(SqlConnection sqlConnection, BankBalanceModel bankBalanceModel)
        {
            try
            {
                StringBuilder sb = AddBankBalanceQuery(bankBalanceModel);
                SqlCommand cmd = new SqlCommand(sb.ToString(), sqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal StringBuilder AddBankBalanceQuery(BankBalanceModel bankBalanceModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("INSERT INTI BankBalance(UserID,BankID,BankAmount) Values({0},{1},{2})", bankBalanceModel.UserID, bankBalanceModel.BankID, bankBalanceModel.BankAmount);
            return sb;
        }

        public void UpdateBankBalancePrivate(SqlConnection sqlConnection, BankBalanceModel bankBalanceModel)
        {
            try
            {
                StringBuilder sb = UpdateBankBalanceQuery(bankBalanceModel);
                SqlCommand cmd = new SqlCommand(sb.ToString(), sqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal StringBuilder UpdateBankBalanceQuery(BankBalanceModel bankBalanceModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("UPDATE BankBalance SET BankAmount = {0} Where BankID = {1} And UserID = {2})", bankBalanceModel.BankAmount, bankBalanceModel.BankID, bankBalanceModel.UserID);
            return sb;
        }

        public void DeleteBankBalancePrivate(SqlConnection sqlConnection, Int32 BankID, Int32 UserID)
        {
            try
            {
                StringBuilder sb = DeleteBankBalanceQuery(BankID, UserID);
                SqlCommand cmd = new SqlCommand(sb.ToString(), sqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal StringBuilder DeleteBankBalanceQuery(Int32 BankID, Int32 UserID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Delete From BankBalance Where BankID = {0} And UserID = {1})", BankID, UserID);
            return sb;
        }
    }
}
