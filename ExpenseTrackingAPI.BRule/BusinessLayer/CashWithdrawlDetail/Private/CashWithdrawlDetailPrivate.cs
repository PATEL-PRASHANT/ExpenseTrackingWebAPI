using ExpenseTrackingAPI.BRule.DataLayer;
using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.CashWithdrawlDetail.Private
{
    public class CashWithdrawlDetailPrivate: ICashWithdrawlDetailPrivate
    {
        private readonly IDataHelper _dataHelper;
        public CashWithdrawlDetailPrivate(IDataHelper dataHelper)
        {
            _dataHelper = dataHelper;
        }

        public async Task<List<CashWithdrawlDetailModel>> GetCashWithdrawlDetaileWithUserIDPrivate(SqlConnection sqlConnection, Int32 UserID)
        {
            List<CashWithdrawlDetailModel> cashWithdrawlDetailModelList = new List<CashWithdrawlDetailModel>();
            try
            {
                StringBuilder sb = CashWithdrawlDetaileWithUserIDQuery(UserID);
                SqlDataReader reader = _dataHelper.ExecuteReader(sb, sqlConnection);

                while (await reader.ReadAsync())
                {
                    CashWithdrawlDetailModel cashWithdrawlDetailModel = new CashWithdrawlDetailModel();
                    cashWithdrawlDetailModel.CashWithdrawlDetailID = reader["BankBalanceID"] != DBNull.Value ? Convert.ToInt32(reader["BankBalanceID"]) : 0;
                    cashWithdrawlDetailModel.UserID = reader["UserID"] != DBNull.Value ? Convert.ToInt32(reader["UserID"]) : 0;
                    cashWithdrawlDetailModel.BankId = reader["BankId"] != DBNull.Value ? Convert.ToInt32(reader["BankId"]) : 0;
                    cashWithdrawlDetailModel.BankATM = reader["BankATM"] != DBNull.Value ? reader["BankATM"].ToString() : string.Empty;
                    cashWithdrawlDetailModel.WithdrawlAmount = reader["WithdrawlAmount"] != DBNull.Value ? Convert.ToDecimal(reader["WithdrawlAmount"]) : 0;
                    cashWithdrawlDetailModel.WithdrawlDate = reader["WithdrawlDate"] != DBNull.Value ? reader["WithdrawlDate"].ToString() : string.Empty;
                    cashWithdrawlDetailModelList.Add(cashWithdrawlDetailModel);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return cashWithdrawlDetailModelList;
        }

        internal StringBuilder CashWithdrawlDetaileWithUserIDQuery(Int32 UserID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SELECT * FROM CashWithdrawlDetail where UserID={0}", UserID);
            return sb;
        }

        public async Task InsertCashWithdrawlDetailePrivate(SqlConnection sqlConnection, CashWithdrawlDetailModel cashWithdrawlDetailModel)
        {
            try
            {
                StringBuilder sb = InsertCashWithdrawlDetaileQuery(cashWithdrawlDetailModel);
                SqlCommand cmd = new SqlCommand(sb.ToString(), sqlConnection);
                cmd.ExecuteNonQuery();                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal StringBuilder InsertCashWithdrawlDetaileQuery(CashWithdrawlDetailModel cashWithdrawlDetailModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("INSERT Into CashWithdrawlDetail(UserId,BankID,BankATM,WithdrawlAmount,WithdrawlDate) Values({0},{1},'{2}',{3},'{4})",
                cashWithdrawlDetailModel.UserID, cashWithdrawlDetailModel.BankId, cashWithdrawlDetailModel.BankATM, cashWithdrawlDetailModel.WithdrawlAmount, cashWithdrawlDetailModel.WithdrawlDate);
            return sb;
        }

        public async Task UpdateCashWithdrawlDetailePrivate(SqlConnection sqlConnection, CashWithdrawlDetailModel cashWithdrawlDetailModel)
        {
            try
            {
                StringBuilder sb = UpdateCashWithdrawlDetaileQuery(cashWithdrawlDetailModel);
                SqlCommand cmd = new SqlCommand(sb.ToString(), sqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal StringBuilder UpdateCashWithdrawlDetaileQuery(CashWithdrawlDetailModel cashWithdrawlDetailModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("UPDATE CashWithdrawlDetail SET BankID = {1},BankATM = '{2}',WithdrawlAmount = {3},WithdrawlDate = '{4} Where CashWithdrawlDetailID = {5} AND  UserId = {0}",
                cashWithdrawlDetailModel.UserID, cashWithdrawlDetailModel.BankId, cashWithdrawlDetailModel.BankATM, cashWithdrawlDetailModel.WithdrawlAmount, cashWithdrawlDetailModel.WithdrawlDate, cashWithdrawlDetailModel.CashWithdrawlDetailID);
            return sb;
        }

        public async Task DeleteCashWithdrawlDetailePrivate(SqlConnection sqlConnection, Int32 UserID, Int32 CashWithdrawlDetailID)
        {
            try
            {
                StringBuilder sb = DeleteCashWithdrawlDetaileQuery(UserID, CashWithdrawlDetailID);
                SqlCommand cmd = new SqlCommand(sb.ToString(), sqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        internal StringBuilder DeleteCashWithdrawlDetaileQuery(Int32 UserID, Int32 CashWithdrawlDetailID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("DELETE FROM CashWithdrawlDetail where UserID={0} AND CashWithdrawlDetailID = {1}", UserID, CashWithdrawlDetailID);
            return sb;
        }
    }
}
