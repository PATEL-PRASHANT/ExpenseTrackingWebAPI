using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.Bank
{
    public interface IBank
    {
        List<BankModel> GetAllBank();
        BankModel GetBank(Int32 BankID);        
        void AddBank(BankModel bankModel);
        void UpdateBank(BankModel bankModel);
        void DeleteBank(Int32 BankID);
    }
}
