using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.BankBalance
{
    public interface IBankBalance
    {
        List<BankBalanceModel> GetAllBankBalance(Int32 UserID);
        BankBalanceModel GetBankBalance(Int32 BankID, Int32 UserID);
        void AddBankBalance(BankBalanceModel bankBalanceModel);
        void UpdateBankBalance(BankBalanceModel bankBalanceModel);
        void DeleteBankBalance(Int32 BankID, Int32 UserID);
    }
}
