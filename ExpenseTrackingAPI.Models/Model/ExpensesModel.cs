using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.Models.Model
{
    public class ExpensesModel
    {
        public Int32? ExpensesID { get; set; }
        public Int32 UserID { get; set; }
        public String? Description { get; set; }
        public String? ExpenseDate { get; set; }
        public Decimal Amount { get; set; }
        public String? CategoryName { get; set; }
        public String? PaymentTypeName { get; set; }
        public String? PaymentDetail { get; set; }
        public String? UPI { get; set; }
        public String? CardNumber { get; set; }
    }
}
