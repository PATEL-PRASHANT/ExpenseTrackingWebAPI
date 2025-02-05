using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.CashBalace.Private
{
    public interface ICashBalacePrivate
    {
        Task<CashBalaceModel> GetCashBalanceWithUserIDPrivate(SqlConnection sqlConnection, Int32 UserID);
        Task InsertCashBalancePrivate(SqlConnection sqlConnection, CashBalaceModel cashBalaceModel);
        Task UpdateCashBalancePrivate(SqlConnection sqlConnection, CashBalaceModel cashBalaceModel);
        Task DeleteCashBalancePrivate(SqlConnection sqlConnection, Int32 UserID);
    }
}
