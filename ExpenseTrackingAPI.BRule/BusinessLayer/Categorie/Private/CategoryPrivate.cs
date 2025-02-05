using ExpenseTrackingAPI.BRule.DataLayer;
using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.Categorie.Private
{
    public class CategoryPrivate: ICategoryPrivate
    {
        private readonly IDataHelper _dataHelper;
        public CategoryPrivate(IDataHelper dataHelper)
        {
            _dataHelper = dataHelper;
        }

        public async Task<List<CategoryModel>> GetCategoryPrivate(SqlConnection sqlConnection)
        {
            List<CategoryModel> categoryModelList = new List<CategoryModel>();
            try
            {
                StringBuilder sb = CategoryQuery();
                SqlDataReader reader = _dataHelper.ExecuteReader(sb, sqlConnection);

                while (await reader.ReadAsync())
                {
                    CategoryModel categoryModel = new CategoryModel();
                    categoryModel.CategoryID = reader["CategoryID"] != DBNull.Value ? Convert.ToInt32(reader["CategoryID"]) : 0;
                    categoryModel.CategoryName = reader["CategoryName"] != DBNull.Value ? reader["CategoryName"].ToString() : string.Empty;
                    categoryModelList.Add(categoryModel);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return categoryModelList;
        }

        internal StringBuilder CategoryQuery()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Category");
            return sb;
        }

        public async Task InsertGetCategoryPrivate(SqlConnection sqlConnection, CategoryModel categoryModel)
        {
            try
            {
                StringBuilder sb = InsertCategoryQuery(categoryModel);
                SqlCommand cmd = new SqlCommand(sb.ToString(), sqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        internal StringBuilder InsertCategoryQuery(CategoryModel categoryModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("INSERT Into Category(CategoryName) Values('{0}')", categoryModel.CategoryName);
            return sb;
        }

        public async Task UpdateCategoryPrivate(SqlConnection sqlConnection, CategoryModel categoryModel)
        {
            try
            {
                StringBuilder sb = UpdateCategoryQuery(categoryModel);
                SqlCommand cmd = new SqlCommand(sb.ToString(), sqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        internal StringBuilder UpdateCategoryQuery(CategoryModel categoryModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("UPDATE Category SET CategoryName = '{0}' Where CategoryID = {1}", categoryModel.CategoryName, categoryModel.CategoryID);
            return sb;
        }

        public async Task DeleteCategoryPrivate(SqlConnection sqlConnection, Int32 CategoryID)
        {
            try
            {
                StringBuilder sb = DeleteCategoryQuery(CategoryID);
                SqlCommand cmd = new SqlCommand(sb.ToString(), sqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        internal StringBuilder DeleteCategoryQuery(Int32 CategoryID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("DELETE FROM Category Where CategoryID = {0}", CategoryID);
            return sb;
        }
    }
}
