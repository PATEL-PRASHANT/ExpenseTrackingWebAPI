using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.Models.Model
{
    public class BankBalanceModel
    {
        public Int32 BankBalanceID { get; set; }    
        public Int32 UserID { get; set; }
        public Int32 BankID { get; set; }
        public Decimal BankAmount { get; set; }
    }
}
