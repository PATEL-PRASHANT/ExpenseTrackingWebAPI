using ExpenseTrackingAPI.BRule.BusinessLayer.User.Private;
using ExpenseTrackingAPI.BRule.DataLayer;
using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.User
{
    public class User: IUser
    {
        private readonly IDataHelper _dataHelper;
        private readonly IUserPrivate _userPrivate;
        public User(IDataHelper dataHelper, IUserPrivate userPrivate)
        {
            _dataHelper = dataHelper;
            _userPrivate = userPrivate;
        }

        public List<UserModel> GetAllUser()
        {
            List<UserModel> userModelList = new List<UserModel>();
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    userModelList = _userPrivate.GetAllUserPrivate(sqlConnection);
                }
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return userModelList;
        }

        public UserModel GetUser(Int32 UserID)
        {
            UserModel userModel = new UserModel();
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    userModel = _userPrivate.GetUserPrivate(sqlConnection, UserID);
                }
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return userModel;
        }

        public void AddUser(UserModel userModel)
        {
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    _userPrivate.AddUserPrivate(sqlConnection, userModel);
                }
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void UpdateUser(UserModel userModel)
        {
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    _userPrivate.UpdateUserPrivate(sqlConnection, userModel);
                }
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void DeleteUser(Int32 UserID)
        {
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    _userPrivate.DeleteUserPrivate(sqlConnection, UserID);
                }
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
