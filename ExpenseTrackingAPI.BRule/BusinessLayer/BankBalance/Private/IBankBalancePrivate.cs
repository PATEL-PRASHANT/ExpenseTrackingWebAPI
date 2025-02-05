using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.BankBalance.Private
{
    public interface IBankBalancePrivate
    {
        List<BankBalanceModel> GetAllBankBalancePrivate(SqlConnection sqlConnection, Int32 UserID);
        BankBalanceModel GetBankBalancePrivate(SqlConnection sqlConnection, Int32 BankID, Int32 UserID);
        void AddBankBalancePrivate(SqlConnection sqlConnection, BankBalanceModel bankBalanceModel);
        void UpdateBankBalancePrivate(SqlConnection sqlConnection, BankBalanceModel bankBalanceModel);
        void DeleteBankBalancePrivate(SqlConnection sqlConnection, Int32 BankID, Int32 UserID);
    }
}
