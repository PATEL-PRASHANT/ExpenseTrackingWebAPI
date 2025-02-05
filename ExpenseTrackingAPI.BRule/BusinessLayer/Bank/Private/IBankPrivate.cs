using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.Bank.Private
{
    public interface IBankPrivate
    {
        List<BankModel> GetAllBankPrivate(SqlConnection sqlConnection);
        BankModel GetBankPrivate(SqlConnection sqlConnection,Int32 BankID); 
        void AddBankPrivate(SqlConnection sqlConnection, BankModel bankModel);
        void UpdateBankPrivate(SqlConnection sqlConnection, BankModel bankModel);
        void DeleteBankPrivate(SqlConnection sqlConnection, Int32 BankID);
    }
}
