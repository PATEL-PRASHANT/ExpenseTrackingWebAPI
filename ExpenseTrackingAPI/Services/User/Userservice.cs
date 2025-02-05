using ExpenseTrackingAPI.BRule.BusinessLayer.User;
using ExpenseTrackingAPI.Models.Model;

namespace ExpenseTrackingAPI.Services.User
{
    public class UserService: IUserService
    {
        private readonly IUser _user;

        public UserService(IUser user)
        {
            _user = user;
        }

        public async Task<List<UserModel>> GetAllUser()
        {
            try
            {
                List<UserModel> userModelList = new List<UserModel>();
                userModelList = _user.GetAllUser();
                return userModelList;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserModel> GetUser(Int32 UserID)
        {
            try
            {
                UserModel userModel = new UserModel();
                userModel = _user.GetUser(UserID);
                return userModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AddUser(UserModel  userModel)
        {
            try
            {
                _user.AddUser(userModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateUser(UserModel userModel)
        {
            try
            {
                _user.UpdateUser(userModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteUser(Int32 UserID)
        {
            try
            {
                _user.DeleteUser(UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
