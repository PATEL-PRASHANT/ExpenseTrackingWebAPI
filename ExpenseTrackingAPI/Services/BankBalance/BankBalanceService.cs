using ExpenseTrackingAPI.BRule.BusinessLayer.BankBalance;
using ExpenseTrackingAPI.Models.Model;

namespace ExpenseTrackingAPI.Services.BankBalance
{
    public class BankBalanceService: IBankBalanceService
    {
        private readonly IBankBalance _bankBalance;

        public BankBalanceService(IBankBalance bankBalance)
        {
            _bankBalance = bankBalance;
        }

        public async Task<List<BankBalanceModel>> GetAllBankBalance(Int32 UserID)
        {
            List<BankBalanceModel> bankBalanceModelList = new List<BankBalanceModel>();
            try
            {
                bankBalanceModelList = _bankBalance.GetAllBankBalance(UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bankBalanceModelList;
        }

        public async Task<BankBalanceModel> GetBankBalance(Int32 BankID, Int32 UserID)
        {
            BankBalanceModel bankBalanceModel = new BankBalanceModel();
            try
            {
                bankBalanceModel = _bankBalance.GetBankBalance(BankID, UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bankBalanceModel;
        }

        public async Task AddBankBalance(BankBalanceModel bankBalanceModel)
        {
            try
            {
                _bankBalance.AddBankBalance(bankBalanceModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateBankBalance(BankBalanceModel bankBalanceModel)
        {
            try
            {
                _bankBalance.UpdateBankBalance(bankBalanceModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteBankBalance(Int32 BankID, Int32 UserID)
        {
            try
            {
                _bankBalance.DeleteBankBalance(BankID, UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
