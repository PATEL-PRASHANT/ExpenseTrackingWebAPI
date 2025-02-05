using ExpenseTrackingAPI.BRule.BusinessLayer.Categorie.Private;
using ExpenseTrackingAPI.BRule.DataLayer;
using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.Categorie
{
    public class Category: ICategory
    {
        private readonly IDataHelper _dataHelper;
        private readonly ICategoryPrivate _categoryPrivate;
        public Category(IDataHelper dataHelper, ICategoryPrivate categoryPrivate)
        {
            _dataHelper = dataHelper;
            _categoryPrivate = categoryPrivate;
        }

        public async Task<List<CategoryModel>> GetCategory()
        {
            List<CategoryModel> categoryModelList = new List<CategoryModel>();
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                await using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    categoryModelList = await _categoryPrivate.GetCategoryPrivate(sqlConnection);
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

            return categoryModelList;
        }

        public async Task InsertGetCategory(CategoryModel categoryModel)
        {
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                await using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    await _categoryPrivate.InsertGetCategoryPrivate(sqlConnection, categoryModel);
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

        public async Task UpdateCategory(CategoryModel categoryModel)
        {
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                await using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    await _categoryPrivate.UpdateCategoryPrivate(sqlConnection, categoryModel);
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

        public async Task DeleteCategory(Int32 CategoryID)
        {
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                await using (sqlConnection = _dataHelper.OpenConnection())
                {
                    sqlConnection.Open();
                    await _categoryPrivate.DeleteCategoryPrivate(sqlConnection, CategoryID);
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
