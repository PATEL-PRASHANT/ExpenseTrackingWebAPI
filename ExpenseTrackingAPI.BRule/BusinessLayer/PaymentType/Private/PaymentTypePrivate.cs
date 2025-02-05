using ExpenseTrackingAPI.BRule.DataLayer;
using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.PaymentType.Private
{
    public class PaymentTypePrivate: IPaymentTypePrivate
    {
        private readonly IDataHelper _dataHelper;
        public PaymentTypePrivate(IDataHelper dataHelper)
        {
            _dataHelper = dataHelper;
        }

        public async Task<List<PaymentTypeModel>> GetPaymentTypesPrivate(SqlConnection sqlConnection)
        {
            List<PaymentTypeModel> paymentTypeModelList = new List<PaymentTypeModel>();
            try
            {
                StringBuilder sb = PaymentTypesQuery();
                SqlDataReader reader = _dataHelper.ExecuteReader(sb, sqlConnection);

                while (await reader.ReadAsync())
                {
                    PaymentTypeModel paymentTypeModel = new PaymentTypeModel();
                    paymentTypeModel.PaymentTypeID = reader["PaymentTypeID"] != DBNull.Value ? Convert.ToInt32(reader["PaymentTypeID"]) : 0;
                    paymentTypeModel.PaymentTypeName = reader["PaymentTypeName"] != DBNull.Value ? reader["PaymentTypeName"].ToString() : string.Empty;


                    paymentTypeModelList.Add(paymentTypeModel);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return paymentTypeModelList;
        }

        internal StringBuilder PaymentTypesQuery()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM PaymentType");
            return sb;
        }

        public async Task InsertPaymentTypesPrivate(SqlConnection sqlConnection, PaymentTypeModel paymentTypeModel)
        {
            try
            {
                StringBuilder sb = InsertPaymentTypesQuery(paymentTypeModel);
                SqlCommand cmd = new SqlCommand(sb.ToString(), sqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        internal StringBuilder InsertPaymentTypesQuery(PaymentTypeModel paymentTypeModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("INSERT Into PaymentType() Values('{0}')",
                paymentTypeModel.PaymentTypeName);
            return sb;
        }
    }
}
