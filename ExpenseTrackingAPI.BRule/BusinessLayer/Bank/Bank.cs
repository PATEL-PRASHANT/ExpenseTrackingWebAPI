using ExpenseTrackingAPI.BRule.BusinessLayer.Bank.Private;
using ExpenseTrackingAPI.BRule.DataLayer;
using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.Bank
{
    public class Bank: IBank
    {
        private readonly IDataHelper _dataHelper;
        private readonly IBankPrivate _bankPrivate;
        public Bank(IDataHelper dataHelper, IBankPrivate bankPrivate) 
        {
            _dataHelper = dataHelper;
            _bankPrivate = bankPrivate;
        }

        public List<BankModel> GetAllBank()
        {
            List<BankModel> bankModelList = new List<BankModel>();
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    bankModelList = _bankPrivate.GetAllBankPrivate(sqlConnection);
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

            return bankModelList;
        }

        public BankModel GetBank(Int32 BankID)
        {
            BankModel bankModel = new BankModel();
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                using(sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    bankModel = _bankPrivate.GetBankPrivate(sqlConnection, BankID);
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

            return bankModel;
        }

        public  void AddBank(BankModel bankModel)
        {
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    _bankPrivate.AddBankPrivate(sqlConnection, bankModel);
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

        public void UpdateBank(BankModel bankModel)
        {
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    _bankPrivate.UpdateBankPrivate(sqlConnection, bankModel);
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

        public void DeleteBank(Int32 BankID)
        {
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    _bankPrivate.DeleteBankPrivate(sqlConnection, BankID);
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
