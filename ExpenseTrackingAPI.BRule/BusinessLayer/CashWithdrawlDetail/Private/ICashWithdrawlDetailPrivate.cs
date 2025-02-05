using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.CashWithdrawlDetail.Private
{
    public interface ICashWithdrawlDetailPrivate
    {
        Task<List<CashWithdrawlDetailModel>> GetCashWithdrawlDetaileWithUserIDPrivate(SqlConnection sqlConnection, Int32 UserID);
        Task InsertCashWithdrawlDetailePrivate(SqlConnection sqlConnection, CashWithdrawlDetailModel cashWithdrawlDetailModel);
        Task UpdateCashWithdrawlDetailePrivate(SqlConnection sqlConnection, CashWithdrawlDetailModel cashWithdrawlDetailModel);
        Task DeleteCashWithdrawlDetailePrivate(SqlConnection sqlConnection, Int32 UserID, Int32 CashWithdrawlDetailID);
    }
}
