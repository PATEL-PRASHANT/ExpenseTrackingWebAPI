using ExpenseTrackingAPI.Models.Model;

namespace ExpenseTrackingAPI.Services.User
{
    public interface IUserService
    {
        Task<List<UserModel>> GetAllUser();
        Task<UserModel> GetUser(Int32 UserID);
        Task AddUser(UserModel userModel);
        Task UpdateUser(UserModel userModel);
        Task DeleteUser(Int32 UserID);

    }
}
