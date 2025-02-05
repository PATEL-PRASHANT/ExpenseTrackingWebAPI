using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.Models.Model
{
    public class CashBalaceModel
    {
        public Int32 CashBalaceID { get; set; }
        public Int32 UserID { get; set; }
        public Decimal CashAmount { get; set; }
    }
}
