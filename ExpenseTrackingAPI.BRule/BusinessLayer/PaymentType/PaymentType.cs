using ExpenseTrackingAPI.BRule.BusinessLayer.PaymentType.Private;
using ExpenseTrackingAPI.BRule.DataLayer;
using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.PaymentType
{
    public class PaymentType: IPaymentType
    {
        private readonly IDataHelper _dataHelper;
        private readonly IPaymentTypePrivate _paymentTypePrivate;
        public PaymentType(IDataHelper dataHelper, IPaymentTypePrivate paymentTypePrivate)
        {
            _dataHelper = dataHelper;
            _paymentTypePrivate = paymentTypePrivate;
        }

        public async Task<List<PaymentTypeModel>> GetPaymentTypes()
        {
            List<PaymentTypeModel> paymentTypeModelList = new List<PaymentTypeModel>();
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                await using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    paymentTypeModelList = await _paymentTypePrivate.GetPaymentTypesPrivate(sqlConnection);
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

            return paymentTypeModelList;
        }

        public async Task InsertPaymentTypes(PaymentTypeModel paymentTypeModel)
        {
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                await using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    await _paymentTypePrivate.InsertPaymentTypesPrivate(sqlConnection, paymentTypeModel);
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
