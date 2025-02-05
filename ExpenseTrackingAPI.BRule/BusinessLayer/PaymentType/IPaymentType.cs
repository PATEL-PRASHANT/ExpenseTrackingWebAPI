using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.PaymentType
{
    public interface IPaymentType
    {
        Task<List<PaymentTypeModel>> GetPaymentTypes();
        Task InsertPaymentTypes(PaymentTypeModel paymentTypeModel);
    }
}
