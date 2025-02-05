using ExpenseTrackingAPI.BRule.BusinessLayer.Expense.Private;
using ExpenseTrackingAPI.BRule.DataLayer;
using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.Expense
{
    public class Expenses: IExpenses
    {
        private readonly IDataHelper _dataHelper;
        private readonly IExpensesPrivate _expensesPrivate;
        public Expenses(IDataHelper dataHelper, IExpensesPrivate expensesPrivate)
        {
            _dataHelper = dataHelper;
            _expensesPrivate = expensesPrivate;
        }

        public async Task<List<ExpensesModel>> GetExpensesWithUserID(Int32 UserID)
        {
            List<ExpensesModel> expensesModelList = new List<ExpensesModel>();
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                await using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    expensesModelList = await _expensesPrivate.GetExpensesWithUserIDPrivate(sqlConnection, UserID);
                }
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            return expensesModelList;
        }

        public async Task InsertExpenses(ExpensesModel expensesModel)
        {
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                await using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    await _expensesPrivate.InsertExpensesPrivate(sqlConnection, expensesModel);
                }
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public async Task UpdateExpense(ExpensesModel expensesModel)
        {
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                await using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    await _expensesPrivate.UpdateExpensePrivate(sqlConnection, expensesModel);
                }
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public async Task DeleteExpense(Int32 ExpensesID)
        {
            List<ExpensesModel> expensesModelList = new List<ExpensesModel>();
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                await using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    await _expensesPrivate.DeleteExpensePrivate(sqlConnection, ExpensesID);
                }
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
