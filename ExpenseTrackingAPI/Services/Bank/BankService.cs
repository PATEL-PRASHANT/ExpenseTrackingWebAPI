using ExpenseTrackingAPI.BRule.BusinessLayer.Bank;
using ExpenseTrackingAPI.Models.Model;

namespace ExpenseTrackingAPI.Services.Bank
{
    public class BankService: IBankService
    {
        private readonly IBank _bank;

        public BankService(IBank bank)
        {
            _bank = bank;
        }

        public async Task<List<BankModel>> GetAllBank()
        {
            try
            {
                List<BankModel> bankModelList = new List<BankModel>();
                bankModelList = _bank.GetAllBank();
                return bankModelList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BankModel> GetBank(Int32 BankID)
        {
            try
            {
                BankModel bankModel = new BankModel();
                bankModel = _bank.GetBank(BankID);
                return bankModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AddBank(BankModel bankModel)
        {
            try
            {                
                _bank.AddBank(bankModel);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateBank(BankModel bankModel)
        {
            try
            {
                _bank.UpdateBank(bankModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteBank(Int32 BankID)
        {
            try
            {
               _bank.DeleteBank(BankID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
