using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.Models.Model
{
    public class CashWithdrawlDetailModel
    {
        public Int32 CashWithdrawlDetailID { get; set; }
        public Int32 UserID { get; set; }
        public Int32 BankId { get; set; }
        public String? BankATM { get; set; }
        public Decimal WithdrawlAmount { get; set; }
        public String? WithdrawlDate { get; set; }
    }
}
