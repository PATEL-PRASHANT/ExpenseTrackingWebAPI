using ExpenseTrackingAPI.Models.Model;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackingAPI.Services.BankBalance
{
    public interface IBankBalanceService
    {
        Task<List<BankBalanceModel>> GetAllBankBalance(Int32 UserID);
        Task<BankBalanceModel> GetBankBalance(Int32 BankID, Int32 UserID);
        Task AddBankBalance(BankBalanceModel bankBalanceModel);
        Task UpdateBankBalance(BankBalanceModel bankBalanceModel);
        Task DeleteBankBalance(Int32 BankID, Int32 UserID);
    }
}
