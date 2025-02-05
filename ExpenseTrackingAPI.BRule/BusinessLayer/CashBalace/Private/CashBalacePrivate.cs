using ExpenseTrackingAPI.BRule.DataLayer;
using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.CashBalace.Private
{
    public class CashBalacePrivate : ICashBalacePrivate
    {
        private readonly IDataHelper _dataHelper;
        public CashBalacePrivate(IDataHelper dataHelper)
        {
            _dataHelper = dataHelper;
        }

        public async Task<CashBalaceModel> GetCashBalanceWithUserIDPrivate(SqlConnection sqlConnection, Int32 UserID)
        {
            CashBalaceModel cashBalaceModel = new CashBalaceModel();
            try
            {
                StringBuilder sb = CashBalanceQueryWithUserID(UserID);
                SqlDataReader reader = _dataHelper.ExecuteReader(sb, sqlConnection);

                while (await reader.ReadAsync())
                {
                    cashBalaceModel.CashBalaceID = reader["CashBalaceID"] != DBNull.Value ? Convert.ToInt32(reader["CashBalaceID"]) : 0;
                    cashBalaceModel.UserID = reader["UserID"] != DBNull.Value ? Convert.ToInt32(reader["UserID"]) : 0;
                    cashBalaceModel.CashAmount = reader["CashAmount"] != DBNull.Value ? Convert.ToDecimal(reader["CashAmount"]) : 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return cashBalaceModel;
        }

        internal StringBuilder CashBalanceQueryWithUserID(Int32 UserID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SELECT * FROM CashBalace where UserID={0}", UserID);
            return sb;
        }

        public async Task InsertCashBalancePrivate(SqlConnection sqlConnection, CashBalaceModel cashBalaceModel)
        {
            try
            {
                StringBuilder sb = InsertCashBalanceQuery(cashBalaceModel);
                SqlCommand cmd = new SqlCommand(sb.ToString(), sqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal StringBuilder InsertCashBalanceQuery(CashBalaceModel cashBalaceModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("INSERT Into CashBalace(UserID,CashAmount) values({0},{1})", cashBalaceModel.UserID, cashBalaceModel.CashAmount);
            return sb;
        }

        public async Task UpdateCashBalancePrivate(SqlConnection sqlConnection, CashBalaceModel cashBalaceModel)
        {
            try
            {
                StringBuilder sb = UpdateCashBalanceQuery(cashBalaceModel);
                SqlCommand cmd = new SqlCommand(sb.ToString(), sqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal StringBuilder UpdateCashBalanceQuery(CashBalaceModel cashBalaceModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("UPDATE CashBalace SET UserID = {0},CashAmount = {1} Where CashBalaceID = {2}", cashBalaceModel.UserID, cashBalaceModel.CashAmount, cashBalaceModel.CashBalaceID);
            return sb;
        }

        public async Task DeleteCashBalancePrivate(SqlConnection sqlConnection, Int32 UserID)
        {
            try
            {
                StringBuilder sb = DeleteCashBalanceQuery(UserID);
                SqlCommand cmd = new SqlCommand(sb.ToString(), sqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        internal StringBuilder DeleteCashBalanceQuery(Int32 UserID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Delete FROM CashBalace where UserID={0}", UserID);
            return sb;
        }
    }
}
