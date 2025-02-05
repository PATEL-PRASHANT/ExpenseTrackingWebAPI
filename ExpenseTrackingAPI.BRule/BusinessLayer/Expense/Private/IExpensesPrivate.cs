using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.Expense.Private
{
    public interface IExpensesPrivate
    {
        Task<List<ExpensesModel>> GetExpensesWithUserIDPrivate(SqlConnection sqlConnection, Int32 UserID);

        Task InsertExpensesPrivate(SqlConnection sqlConnection, ExpensesModel expensesModel);
        Task UpdateExpensePrivate(SqlConnection sqlConnection, ExpensesModel expensesModel);
        Task DeleteExpensePrivate(SqlConnection sqlConnection, Int32 ExpensesID);
    }
}
