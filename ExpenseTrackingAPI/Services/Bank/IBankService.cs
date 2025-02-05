using ExpenseTrackingAPI.Models.Model;

namespace ExpenseTrackingAPI.Services.Bank
{
    public interface IBankService
    {
        Task<List<BankModel>> GetAllBank();
        Task<BankModel> GetBank(Int32 BankID);
        Task AddBank(BankModel bankModel);
        Task UpdateBank(BankModel bankModel);
       Task DeleteBank(Int32 BankID);
    }
}
