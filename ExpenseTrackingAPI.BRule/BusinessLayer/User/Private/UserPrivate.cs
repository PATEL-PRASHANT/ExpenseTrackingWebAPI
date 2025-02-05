using ExpenseTrackingAPI.BRule.DataLayer;
using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.User.Private
{
    public class UserPrivate: IUserPrivate
    {
        private readonly IDataHelper _dataHelper;
        public UserPrivate(IDataHelper dataHelper)
        {
            _dataHelper = dataHelper;
        }

        public List<UserModel> GetAllUserPrivate(SqlConnection sqlConnection)
        {
            List<UserModel> userModelList = new List<UserModel>();
            try
            {
                StringBuilder sb = GetAllUserQuery();
                SqlDataReader reader = _dataHelper.ExecuteReader(sb, sqlConnection);

                while (reader.Read())
                {
                    UserModel userModel = new UserModel();
                    userModel.UserID = reader["UserID"] != DBNull.Value ? Convert.ToInt32(reader["UserID"]) : 0;
                    userModel.UserName = reader["UserName"] != DBNull.Value ? reader["UserName"].ToString() : string.Empty;
                    userModel.Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty;
                    userModel.CountryCode = reader["CountryCode"] != DBNull.Value ? reader["CountryCode"].ToString() : string.Empty;
                    userModel.MobileNo1 = reader["MobileNo1"] != DBNull.Value ? reader["MobileNo1"].ToString() : string.Empty;
                    userModel.MobileNo2 = reader["MobileNo2"] != DBNull.Value ? reader["MobileNo2"].ToString() : string.Empty;
                    userModel.PhoneNo = reader["PhoneNo"] != DBNull.Value ? reader["PhoneNo"].ToString() : string.Empty;
                    userModel.AlternateAddress = reader["AlternateAddress"] != DBNull.Value ? reader["AlternateAddress"].ToString() : string.Empty;
                    userModel.PermanentAddress = reader["PermanentAddress"] != DBNull.Value ? reader["PermanentAddress"].ToString() : string.Empty;
                    userModel.City = reader["City"] != DBNull.Value ? reader["City"].ToString() : string.Empty;
                    userModel.State = reader["State"] != DBNull.Value ? reader["State"].ToString() : string.Empty;
                    userModel.PostalCode = reader["PostalCode"] != DBNull.Value ? reader["PostalCode"].ToString() : string.Empty;
                    userModel.Country = reader["Country"] != DBNull.Value ? reader["Country"].ToString() : string.Empty;
                    userModelList.Add(userModel);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return userModelList;
        }

        internal StringBuilder GetAllUserQuery()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Users");
            return sb;
        }

        public UserModel GetUserPrivate(SqlConnection sqlConnection, Int32 UserID)
        {
            UserModel userModel = new UserModel();
            try
            {
                StringBuilder sb = GetUserQuery(UserID);
                SqlDataReader reader = _dataHelper.ExecuteReader(sb, sqlConnection);

                while (reader.Read())
                {
                    userModel.UserID = reader["UserID"] != DBNull.Value ? Convert.ToInt32(reader["UserID"]) : 0;
                    userModel.UserName = reader["UserName"] != DBNull.Value ? reader["UserName"].ToString() : string.Empty;
                    userModel.Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty;
                    userModel.CountryCode = reader["CountryCode"] != DBNull.Value ? reader["CountryCode"].ToString() : string.Empty;
                    userModel.MobileNo1 = reader["MobileNo1"] != DBNull.Value ? reader["MobileNo1"].ToString() : string.Empty;
                    userModel.MobileNo2 = reader["MobileNo2"] != DBNull.Value ? reader["MobileNo2"].ToString() : string.Empty;
                    userModel.PhoneNo = reader["PhoneNo"] != DBNull.Value ? reader["PhoneNo"].ToString() : string.Empty;
                    userModel.AlternateAddress = reader["AlternateAddress"] != DBNull.Value ? reader["AlternateAddress"].ToString() : string.Empty;
                    userModel.PermanentAddress = reader["PermanentAddress"] != DBNull.Value ? reader["PermanentAddress"].ToString() : string.Empty;
                    userModel.City = reader["City"] != DBNull.Value ? reader["City"].ToString() : string.Empty;
                    userModel.State = reader["State"] != DBNull.Value ? reader["State"].ToString() : string.Empty;
                    userModel.PostalCode = reader["PostalCode"] != DBNull.Value ? reader["PostalCode"].ToString() : string.Empty;
                    userModel.Country = reader["Country"] != DBNull.Value ? reader["Country"].ToString() : string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return userModel;
        }

        internal StringBuilder GetUserQuery(Int32 UserID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SELECT * FROM Users Where UserID = {0}",UserID);
            return sb;
        }

        public void AddUserPrivate(SqlConnection sqlConnection, UserModel userModel)
        {
            StringBuilder sb = AddUserQuery(userModel);
            SqlDataReader reader = _dataHelper.ExecuteReader(sb, sqlConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sb.ToString();
            cmd.Connection = sqlConnection;
            _dataHelper.ExecuteCommand(cmd);
        }

        internal StringBuilder AddUserQuery(UserModel userModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("INSERT INTO Users(UserName, Email, CountryCode, MobileNo1, MobileNo2, PhoneNo, AlternateAddress, PermanentAddress, City, State, PostalCode, Country) Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')",
                userModel.UserName, userModel.Email, userModel.CountryCode, userModel.MobileNo1, userModel.MobileNo2, userModel.PhoneNo, userModel.AlternateAddress, userModel.PermanentAddress, userModel.City, userModel.State, userModel.PostalCode, userModel.Country);
            return sb;
        }

        public void UpdateUserPrivate(SqlConnection sqlConnection, UserModel userModel)
        {
            StringBuilder sb = UpdateUserQuery(userModel);
            SqlDataReader reader = _dataHelper.ExecuteReader(sb, sqlConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sb.ToString();
            cmd.Connection = sqlConnection;
            _dataHelper.ExecuteCommand(cmd);
        }

        internal StringBuilder UpdateUserQuery(UserModel userModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("UPDATE Users Set UserName = '{0}', Email = '{1}', CountryCode = '{2}', MobileNo1 = '{3}', MobileNo2 = '{4}', PhoneNo = '{5}', AlternateAddress = '{6}', PermanentAddress = '{7}', City = '{8}', State = '{9}', PostalCode = '{10}', Country = '{11}' Where UserID = {12}",
                userModel.UserName, userModel.Email, userModel.CountryCode, userModel.MobileNo1, userModel.MobileNo2, userModel.PhoneNo, userModel.AlternateAddress, userModel.PermanentAddress, userModel.City, userModel.State, userModel.PostalCode, userModel.Country, userModel.UserID);
            return sb;
        }

        public void DeleteUserPrivate(SqlConnection sqlConnection, Int32 UserID)
        {
            StringBuilder sb = DeleteUserQuery(UserID);
            SqlDataReader reader = _dataHelper.ExecuteReader(sb, sqlConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sb.ToString();
            cmd.Connection = sqlConnection;
            _dataHelper.ExecuteCommand(cmd);
        }

        internal StringBuilder DeleteUserQuery(Int32 UserID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("DELETE From Users Where UserID = {0}", UserID);
            return sb;
        }
    }
}
