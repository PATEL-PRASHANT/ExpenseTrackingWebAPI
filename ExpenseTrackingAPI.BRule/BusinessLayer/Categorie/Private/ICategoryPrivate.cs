using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.Categorie.Private
{
    public interface ICategoryPrivate
    {
        Task<List<CategoryModel>> GetCategoryPrivate(SqlConnection sqlConnection);
        Task InsertGetCategoryPrivate(SqlConnection sqlConnection, CategoryModel categoryModel);
        Task UpdateCategoryPrivate(SqlConnection sqlConnection, CategoryModel categoryModel);
        Task DeleteCategoryPrivate(SqlConnection sqlConnection, Int32 CategoryID);
    }
}
