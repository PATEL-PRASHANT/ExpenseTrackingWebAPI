using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.User
{
    public interface IUser
    {
        List<UserModel> GetAllUser();
        UserModel GetUser(Int32 UserID);
        void AddUser(UserModel userModel);
        void UpdateUser(UserModel userModel);
        void DeleteUser(Int32 UserID);
    }
}
