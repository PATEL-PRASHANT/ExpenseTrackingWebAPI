using ExpenseTrackingAPI.BRule.DataLayer;
using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.Expense.Private
{
    public class ExpensesPrivate: IExpensesPrivate
    {
        private readonly IDataHelper _dataHelper;
        public ExpensesPrivate(IDataHelper dataHelper)
        {
            _dataHelper = dataHelper;
        }

        public async Task<List<ExpensesModel>> GetExpensesWithUserIDPrivate(SqlConnection sqlConnection, Int32 UserID)
        {
            List<ExpensesModel> expensesModelList = new List<ExpensesModel>();
            try
            {
                StringBuilder sb = ExpensesQuery(UserID);
                SqlDataReader reader = _dataHelper.ExecuteReader(sb, sqlConnection);

                while (await reader.ReadAsync())
                {
                    ExpensesModel expensesModel = new ExpensesModel();
                    expensesModel.ExpensesID = reader["ExpensesID"] != DBNull.Value ? Convert.ToInt32(reader["ExpensesID"]) : 0;
                    expensesModel.UserID = reader["UserID"] != DBNull.Value ? Convert.ToInt32(reader["UserID"]) : 0;
                    expensesModel.Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : string.Empty;
                    expensesModel.ExpenseDate = reader["ExpenseDate"] != DBNull.Value ? Convert.ToDateTime(reader["ExpenseDate"]).ToString("yyyy-MM-dd") : string.Empty;
                    expensesModel.Amount = reader["Amount"] != DBNull.Value ? Convert.ToDecimal(reader["Amount"]) : 0;
                    expensesModel.CategoryName = reader["CategoryName"] != DBNull.Value ? reader["CategoryName"].ToString() : string.Empty;
                    expensesModel.PaymentTypeName = reader["PaymentTypeName"] != DBNull.Value ? reader["PaymentTypeName"].ToString() : string.Empty;
                    expensesModel.PaymentDetail = reader["PaymentDetail"] != DBNull.Value ? reader["PaymentDetail"].ToString() : string.Empty;
                    expensesModel.UPI = reader["UPI"] != DBNull.Value ? reader["UPI"].ToString() : string.Empty;
                    expensesModel.CardNumber = reader["CardNumber"] != DBNull.Value ? reader["CardNumber"].ToString() : string.Empty;
                    expensesModelList.Add(expensesModel);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return expensesModelList;
        }

        internal StringBuilder ExpensesQuery(Int32 UserID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SELECT * FROM Expenses where UserID={0}", UserID);
            return sb;
        }

        public async Task InsertExpensesPrivate(SqlConnection sqlConnection, ExpensesModel expensesModel)
        {

            try
            {

                //SqlCommand cmd = new SqlCommand("SP_AddBank", sqlConnection);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@BankName", bankRequest.BankName);
                //cmd.Parameters.AddWithValue("@BankLogo", bankRequest.BankLogo);
                //int i = cmd.ExecuteNonQuery();


                StringBuilder sb = InsertExpensesQuery(expensesModel);
                SqlCommand cmd = new SqlCommand(sb.ToString(), sqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        internal StringBuilder InsertExpensesQuery(ExpensesModel expensesModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("INSERT INTO Expenses(UserID, Description, ExpenseDate, Amount, CategoryName, PaymentTypeName, PaymentDetail, UPI, CardNumber) VALUES({0},'{1}','{2}',{3},'{4}','{5}','{6}','{7}','{8}')", expensesModel.UserID, expensesModel.Description, expensesModel.ExpenseDate, expensesModel.Amount, expensesModel.CategoryName, expensesModel.PaymentTypeName, expensesModel.PaymentDetail, expensesModel.UPI, expensesModel.CardNumber);
            sb.Append("\r\n");
            sb.Append("SELECT SCOPE_IDENTITY()");
            return sb;
        }

        public async Task UpdateExpensePrivate(SqlConnection sqlConnection, ExpensesModel expensesModel)
        {

            try
            {
                StringBuilder sb = UpdateExpenseQuery(expensesModel);
                SqlCommand cmd = new SqlCommand(sb.ToString(), sqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        internal StringBuilder UpdateExpenseQuery(ExpensesModel expensesModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("UPDATE Expenses SET UserID = {0}, Description = '{1}', ExpenseDate = '{2}', Amount = {3}, CategoryName = '{4}', PaymentTypeName = '{5}', PaymentDetail = '{6}', UPI = '{7}', CardNumber = '{8}' Where ExpensesID = {9}", 
                expensesModel.UserID, expensesModel.Description, expensesModel.ExpenseDate, expensesModel.Amount, 
                expensesModel.CategoryName, expensesModel.PaymentTypeName, expensesModel.PaymentDetail, expensesModel.UPI, 
                expensesModel.CardNumber, expensesModel.ExpensesID);
            sb.Append("\r\n");
            sb.Append("SELECT SCOPE_IDENTITY()");
            return sb;
        }

        public async Task DeleteExpensePrivate(SqlConnection sqlConnection, Int32 ExpensesID)
        {
            List<ExpensesModel> expensesModelList = new List<ExpensesModel>();
            try
            {
                StringBuilder sb = DeleteExpenseQuery(ExpensesID);
                SqlCommand cmd = new SqlCommand(sb.ToString(), sqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal StringBuilder DeleteExpenseQuery(Int32 ExpensesID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("DELETE FROM Expenses where ExpensesID={0}", ExpensesID);
            return sb;
        }
    }
}
