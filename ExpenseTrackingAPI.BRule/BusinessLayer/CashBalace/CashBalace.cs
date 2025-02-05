using ExpenseTrackingAPI.BRule.BusinessLayer.CashBalace.Private;
using ExpenseTrackingAPI.BRule.DataLayer;
using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.CashBalace
{
    public class CashBalace: ICashBalace
    {
        private readonly IDataHelper _dataHelper;
        private readonly ICashBalacePrivate _cashBalacePrivate;
        public CashBalace(IDataHelper dataHelper, ICashBalacePrivate cashBalacePrivate)
        {
            _dataHelper = dataHelper;
            _cashBalacePrivate = cashBalacePrivate;
        }

        public async Task<CashBalaceModel> GetCashBalanceWithUserID(Int32 UserID)
        {
            CashBalaceModel cashBalaceModel = new CashBalaceModel();
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                await using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    cashBalaceModel = await _cashBalacePrivate.GetCashBalanceWithUserIDPrivate(sqlConnection,UserID);
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return cashBalaceModel;
        }

        public async Task InsertCashBalance(CashBalaceModel cashBalaceModel)
        {
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                await using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    await _cashBalacePrivate.InsertCashBalancePrivate(sqlConnection, cashBalaceModel);
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateCashBalance(CashBalaceModel cashBalaceModel)
        {
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                await using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    await _cashBalacePrivate.UpdateCashBalancePrivate(sqlConnection, cashBalaceModel);
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteCashBalance(Int32 UserID)
        {
           
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                await using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    await _cashBalacePrivate.DeleteCashBalancePrivate(sqlConnection, UserID);
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
