using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.CashWithdrawlDetail
{
    public interface ICashWithdrawlDetail
    {
        Task<List<CashWithdrawlDetailModel>> GetCashWithdrawlDetaileWithUserID(Int32 UserID);

        Task InsertCashWithdrawlDetaile(CashWithdrawlDetailModel cashWithdrawlDetailModel);
        Task UpdateCashWithdrawlDetaile(CashWithdrawlDetailModel cashWithdrawlDetailModel);
        Task DeleteCashWithdrawlDetaile(Int32 UserID, Int32 CashWithdrawlDetailID);
    }
}
