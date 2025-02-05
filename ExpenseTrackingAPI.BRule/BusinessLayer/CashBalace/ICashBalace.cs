using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.CashBalace
{
    public interface ICashBalace
    {
        Task<CashBalaceModel> GetCashBalanceWithUserID(Int32 UserID);

        Task InsertCashBalance(CashBalaceModel cashBalaceModel);
        Task UpdateCashBalance(CashBalaceModel cashBalaceModel);
        Task DeleteCashBalance(Int32 UserID);
    }
}
