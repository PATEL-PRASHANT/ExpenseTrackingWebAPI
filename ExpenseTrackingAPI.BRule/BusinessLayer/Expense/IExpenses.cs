using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.Expense
{
    public interface IExpenses
    {
        Task<List<ExpensesModel>> GetExpensesWithUserID(Int32 UserID);

        Task InsertExpenses(ExpensesModel expensesModel);
        Task UpdateExpense(ExpensesModel expensesModel);
        Task DeleteExpense(Int32 ExpensesID);
    }
}
