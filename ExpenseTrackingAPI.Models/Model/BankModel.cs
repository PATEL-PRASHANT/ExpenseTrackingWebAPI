using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.Models.Model
{
    public class BankModel
    {
        public Int64 BankId { get; set; }
        public string? BankName { get; set; }
        public byte[]? BankLogo { get; set; }
    }
}
