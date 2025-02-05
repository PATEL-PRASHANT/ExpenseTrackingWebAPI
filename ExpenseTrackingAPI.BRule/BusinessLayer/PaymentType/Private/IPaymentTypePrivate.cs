using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.PaymentType.Private
{
    public interface IPaymentTypePrivate
    {
        Task<List<PaymentTypeModel>> GetPaymentTypesPrivate(SqlConnection sqlConnection);
        Task InsertPaymentTypesPrivate(SqlConnection sqlConnection, PaymentTypeModel paymentTypeModel);
    }
}
