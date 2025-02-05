using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.User.Private
{
    public interface IUserPrivate
    {
        List<UserModel> GetAllUserPrivate(SqlConnection sqlConnection);
        UserModel GetUserPrivate(SqlConnection sqlConnection, Int32 UserID);
        void AddUserPrivate(SqlConnection sqlConnection, UserModel userModel);
        void UpdateUserPrivate(SqlConnection sqlConnection, UserModel userModel);
        void DeleteUserPrivate(SqlConnection sqlConnection, Int32 UserID);
    }
}
