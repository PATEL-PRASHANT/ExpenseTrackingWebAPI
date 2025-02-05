using ExpenseTrackingAPI.BRule.BusinessLayer.CashWithdrawlDetail.Private;
using ExpenseTrackingAPI.BRule.DataLayer;
using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.CashWithdrawlDetail
{
    public class CashWithdrawlDetail: ICashWithdrawlDetail
    {
        private readonly IDataHelper _dataHelper;
        private readonly ICashWithdrawlDetailPrivate _cashWithdrawlDetailPrivate;
        public CashWithdrawlDetail(IDataHelper dataHelper, ICashWithdrawlDetailPrivate cashWithdrawlDetailPrivate)
        {
            _dataHelper = dataHelper;
            _cashWithdrawlDetailPrivate = cashWithdrawlDetailPrivate;
        }

        public async Task<List<CashWithdrawlDetailModel>> GetCashWithdrawlDetaileWithUserID(Int32 UserID)
        {
            List<CashWithdrawlDetailModel> cashWithdrawlDetailModelList = new List<CashWithdrawlDetailModel>();
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                await using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    cashWithdrawlDetailModelList = await _cashWithdrawlDetailPrivate.GetCashWithdrawlDetaileWithUserIDPrivate(sqlConnection, UserID);
                }
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            return cashWithdrawlDetailModelList;
        }

        public async Task InsertCashWithdrawlDetaile(CashWithdrawlDetailModel cashWithdrawlDetailModel)
        {
            
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                await using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    await _cashWithdrawlDetailPrivate.InsertCashWithdrawlDetailePrivate(sqlConnection, cashWithdrawlDetailModel);
                }
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public async Task UpdateCashWithdrawlDetaile(CashWithdrawlDetailModel cashWithdrawlDetailModel)
        {

            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                await using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    await _cashWithdrawlDetailPrivate.UpdateCashWithdrawlDetailePrivate(sqlConnection, cashWithdrawlDetailModel);
                }
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public async Task DeleteCashWithdrawlDetaile(Int32 UserID, Int32 CashWithdrawlDetailID)
        {
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                await using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    await _cashWithdrawlDetailPrivate.DeleteCashWithdrawlDetailePrivate(sqlConnection, UserID, CashWithdrawlDetailID);
                }
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
