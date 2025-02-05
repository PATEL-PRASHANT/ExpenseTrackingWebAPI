using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.Models.Model
{
    public class UserModel
    {
        public Int32 UserID { get; set; }
        public String? UserName { get; set; }
        public String? Email { get; set; }
        public String? CountryCode { get; set; }
        public String? MobileNo1 { get; set; }
        public String? MobileNo2 { get; set; }
        public String? PhoneNo { get; set; }
        public String? AlternateAddress { get; set; }
        public String? PermanentAddress { get; set; }
        public String? City { get; set; }
        public String? State { get; set; }
        public String? PostalCode { get; set; }
        public String? Country { get; set; }
    }
}
