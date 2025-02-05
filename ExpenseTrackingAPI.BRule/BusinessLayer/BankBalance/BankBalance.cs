using ExpenseTrackingAPI.BRule.BusinessLayer.BankBalance.Private;
using ExpenseTrackingAPI.BRule.DataLayer;
using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.BankBalance
{
    public class BankBalance: IBankBalance
    {
        private readonly IDataHelper _dataHelper;
        private readonly IBankBalancePrivate _bankBalancePrivate;

        public BankBalance(IDataHelper dataHelper, IBankBalancePrivate bankBalancePrivate)
        {
            _dataHelper = dataHelper;
            _bankBalancePrivate = bankBalancePrivate;
        }

        public List<BankBalanceModel> GetAllBankBalance(Int32 UserID)
        {
            List<BankBalanceModel> bankBalanceModelList = new List<BankBalanceModel>();
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    bankBalanceModelList = _bankBalancePrivate.GetAllBankBalancePrivate(sqlConnection, UserID);
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

            return bankBalanceModelList;
        }

        public BankBalanceModel GetBankBalance(Int32 BankID, Int32 UserID)
        {
            BankBalanceModel bankBalanceModel = new BankBalanceModel();
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    bankBalanceModel = _bankBalancePrivate.GetBankBalancePrivate(sqlConnection, BankID, UserID);
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return bankBalanceModel;
        }        

        public void AddBankBalance(BankBalanceModel bankBalanceModel)
        {
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    _bankBalancePrivate.AddBankBalancePrivate(sqlConnection, bankBalanceModel);
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateBankBalance(BankBalanceModel bankBalanceModel)
        {
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    _bankBalancePrivate.UpdateBankBalancePrivate(sqlConnection, bankBalanceModel);
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteBankBalance(Int32 BankID, Int32 UserID)
        {
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    _bankBalancePrivate.DeleteBankBalancePrivate(sqlConnection, BankID, UserID);
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
